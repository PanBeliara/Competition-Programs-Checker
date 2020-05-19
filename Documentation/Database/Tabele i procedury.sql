--Tabele i rzeczy oko³otabelowe

CREATE TABLE Problem ( --Tabela zawieraj¹ca informacje na temat zadania
	id INT IDENTITY(1,1) PRIMARY KEY,
	code NVARCHAR(20) NOT NULL UNIQUE, --Krótka nazwa zadania
	title NVARCHAR(100) NOT NULL, 
	author NVARCHAR(128) NOT NULL ,--REFERENCES AspNetUsers(id),
	assignment VARBINARY(MAX) NOT NULL, --Miejsce na plik PDF
	is_active BIT NOT NULL DEFAULT 0, --Czy problem jest dostêpny? (1 - TAK, 0 - NIE, nie dodasz rozwi¹zania zanim nie bêdzie test runów ) 
	best_scores_cache NVARCHAR(3300) DEFAULT NULL, --Miejsce na JSONa z najlepszymi wynikami by nie liczyæ za ka¿dym razem
	--20x(128 znaków userID + 15 znaków oceny + 15 znaków whitespace)+116 znaków =3276
	worst_best_score NVARCHAR(15) DEFAULT NULL --miejsce na ostatni wynik na liœcie najlepszych wyników
);
GO

CREATE TABLE ProgrammingLanguages (
	id INT IDENTITY(1,1) PRIMARY KEY,
	language_name NVARCHAR(20) UNIQUE NOT NULL --piêknie znormalizowane
);
GO

CREATE TABLE TestRuns (
	id INT IDENTITY(1,1) PRIMARY KEY,
	problem_id INT FOREIGN KEY REFERENCES Problem(id),
	order_position INT NOT NULL DEFAULT(0),
	input_file VARBINARY(MAX) NOT NULL,
	output_file VARBINARY(MAX) NOT NULL
);
GO

-----------------------------------------------------------------------------------------------
----NIE ROBIMY INSERTÓW, UPDATEÓW I DELETEÓW DO TABEL PONI¯EJ TEJ LINII, OD TEGO S¥ PROCEDURY

CREATE TABLE Solutions (
	id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT NEWID(), --na szelki
	problem_id INT FOREIGN KEY REFERENCES Problem(id),
	solver_id NVARCHAR(128) NOT NULL,-- REFERENCES AspNetUsers(id),
	code NVARCHAR(MAX) NOT NULL, --miejsce na kod Ÿród³owy programu
	code_language INT FOREIGN KEY REFERENCES ProgrammingLanguages(id), --wybór jêzyka programowania programu
	submitted_time DATETIME NOT NULL DEFAULT GETUTCDATE(), --daty w UTC i ró¿nica dla strefy czasowej (nie wiadomo po co)
	checked_time DATETIME NOT NULL DEFAULT GETUTCDATE(), 
	time_offset DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(),
	is_error BIT DEFAULT 1, --jak 1 to wywala b³êdy
	score NVARCHAR(15)); --ocena, nie mia³em pojêcia co tu daæ to da³em NVARCHAR(15) xd
GO

CREATE TABLE SolutionsQueue ( --kolejka FIFO z nades³anymi rozwi¹zaniami dla sprawdzarki
	id BIGINT NOT NULL IDENTITY(1,1),
	problem_id INT FOREIGN KEY REFERENCES Problem(id),
	solver_id NVARCHAR(128) NOT NULL, --REFERENCES AspNetUsers(id)
	code NVARCHAR(MAX) NOT NULL, --jak w Solutions
	code_language INT FOREIGN KEY REFERENCES ProgrammingLanguages(id),
	submitted_time DATETIME NOT NULL DEFAULT GETUTCDATE(),
	time_offset DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET());
GO

CREATE CLUSTERED INDEX SolutionsQueueClusteredIndex on SolutionsQueue(id); --indeks do kolejki by œmiga³o lepiej
GO

--PROCEDURY
--Procedury s¹ szybsze od wszystkich insertów i updateów, bo maj¹ swój plan egzekucji i cachuj¹ rzeczy, które mog¹ byæ im potrzebne

CREATE OR ALTER PROCEDURE AddToSolutionsQueue --dodaj rozwi¹zanie do kolejki SolutionsQueue
	@problem_id INT,
	@solver_id NVARCHAR(128),
	@code NVARCHAR(MAX),
	@code_language INT
AS
	SET NOCOUNT ON;
	INSERT INTO SolutionsQueue (problem_id, solver_id, code, code_language) VALUES (@problem_id, @solver_id, @code, @code_language);
GO
	
CREATE OR ALTER PROCEDURE ReadDataOfSolutionsQueue AS --wczytaj kod, jêzyk oraz wejœcia i wyjœcia testów
BEGIN
	SET NOCOUNT ON;
	DECLARE @code NVARCHAR(MAX);
	DECLARE @code_language INT;
	DECLARE @problem_id INT; --w sumie nie wiem czy to bêdzie nam do czegoœ potrzebne
	DECLARE @solver_id NVARCHAR(128); --ale chyba nie
	
	SELECT TOP(1) @code = code, @code_language = code_language, @problem_id = problem_id, @solver_id = solver_id from SolutionsQueue with (ROWLOCK) order by id;
	SELECT * FROM TestRuns where problem_id = @problem_id ORDER BY order_position;
	SELECT @code as Code, @code_language as CodeLanguage, @problem_id as ProblemID, @solver_id as SolverID;
END
GO

--PLACEHOLDER FOR ACTUAL BEST SCORES UPDATE
CREATE OR ALTER PROCEDURE UpdateBestScore  --aktualizacja cache'a z najlepszymi rozwi¹zaniami problemu
	@problem_id INT, @solver_id NVARCHAR(128), @score NVARCHAR(15) --docelowo ma robiæ jsona
AS SELECT 'success' AS Placeholder; --oraz aktualizowaæ wartoœæ najgorszego z dobrych wyników
GO

CREATE OR ALTER PROCEDURE MoveUpSolutionsQueue --przenosi rozwi¹zanie z ocen¹ z SolutionsQueue to Solutions
	@is_error BIT, @score NVARCHAR(15)
AS -- do realizacji przez sprawdzarkê w pêtli: ReadDataOfSolutionsQueue ----jak nie NULL----> SprawdŸ() ------> MoveUpSolutionsQueue
BEGIN
	DECLARE @worst_best_score NVARCHAR(15);
	DECLARE @problem_solver_table TABLE ( problem_id INT, solver_id NVARCHAR(128));
	BEGIN TRANSACTION

	--czêœæ 1) dodawanie rozwi¹zania i wyniku do tabeli z rozwi¹zaniami
	MERGE Solutions As myTarget
	USING ( SELECT TOP(1) * FROM SolutionsQueue ORDER BY id)
	AS mySource ON mySource.problem_id = myTarget.problem_id AND mySource.solver_id = myTarget.solver_id
	WHEN MATCHED THEN UPDATE
		SET code = mySource.code,
		code_language = mySource.code_language,
		submitted_time = mySource.submitted_time,
		checked_time = GETUTCDATE(),
		time_offset = mySource.time_offset,
		is_error = @is_error,
		score = @score
	WHEN NOT MATCHED THEN
		INSERT(problem_id, solver_id, code, code_language, submitted_time, checked_time, time_offset, is_error, score)
		VALUES(mySource.problem_id, mySource.solver_id, mySource.code, mySource.code_language, mySource.submitted_time, GETUTCDATE(), mySource.time_offset, @is_error, @score)
	OUTPUT inserted.problem_id AS problem_id, inserted.solver_id as solver_id INTO @problem_solver_table;
	
	--czêœæ 2) usuwanie rozwi¹zania z kolejki
	WITH TopRowOfQueue AS (
		SELECT TOP(1) * FROM SolutionsQueue ORDER BY id)
	DELETE FROM TopRowOfQueue;

	--czêœæ 3) sprawdzanie czy trzeba aktualizowaæ najlepsze wyniki
	IF @is_error = 0
	BEGIN
		DECLARE @problem_id INT, @solver_id INT
		SELECT TOP(1) @problem_id = problem_id, @solver_id = solver_id FROM @problem_solver_table;
		SELECT @worst_best_score = worst_best_score FROM Problem WHERE id = @problem_id;
		IF @worst_best_score < @score OR @worst_best_score IS NULL
			EXEC UpdateBestScore @problem_id, @solver_id, @score;
	END;
	COMMIT TRANSACTION;
END;
GO
