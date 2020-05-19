--Przyk³adowe dane do bazy danych oraz przyk³ady zastosowania procedur

INSERT INTO ProgrammingLanguages (language_name) VALUES ('Python'), ('JavaScript'), ('C'), ('Java');
INSERT INTO Problem (code, title, author, assignment) VALUES ('ZAD1', N'Przyk³adowe zadanie 1', 'example', CONVERT(VARBINARY(MAX), N'Oto jest przyk³adowa treœæ zadania. Tak naprawdê to to nie jest plik PDF'));
INSERT INTO Problem (code, title, author, assignment) VALUES ('ZAD2', N'Przyk³adowe zadanie 2', 'example', CONVERT(VARBINARY(MAX), N'To te¿ nie jest PDF'));
INSERT INTO TestRuns(problem_id, order_position, input_file, output_file) VALUES 
(2, 1, CONVERT(VARBINARY(MAX), N'coœ'), CONVERT(VARBINARY(MAX), N'rwegawerg')),
(2, 2, CONVERT(VARBINARY(MAX), N'no elhergheczku1'), CONVERT(VARBINARY(MAX), N'no elohwegfwfefku1')),
(2, 3, CONVERT(VARBINARY(MAX), N'fgfdg'), CONVERT(VARBINARY(MAX), N'noawefwefwczku1')),
(2, 4, CONVERT(VARBINARY(MAX), N'sghsrth'), CONVERT(VARBINARY(MAX), N'nwefwefwefth')),
(1, 1, CONVERT(VARBINARY(MAX), N'nwefwefwrthu1'), CONVERT(VARBINARY(MAX), N'newfwefwfwthczku1'));
EXEC AddToSolutionsQueue @problem_id = 1, @solver_id=7, @code = N'DROP DATABASE pwsz', @code_language = 2;
EXEC AddToSolutionsQueue @problem_id = 2, @solver_id=7, @code = N'exit()', @code_language = 1;
EXEC AddToSolutionsQueue @problem_id = 2, @solver_id=3, @code = N'te komendy póki co dzia³aj¹', @code_language = 1;

Select * FROM Problem;
Select * FROM SolutionsQueue;
Select * FROM Solutions;


EXEC MoveUpSolutionsQueue 0, N'4'
--sprawdzarka zg³asza ocenê
EXEC MoveUpSolutionsQueue 1, N'404'
--sprawdzarka zg³asza b³¹d

EXEC UpdateBestScore @problem_id = 7, @solver_id = 3, @score = ':S' 
--to kiedyœ zostanie zrobione

EXEC ReadDataOfSolutionsQueue 
--wczytywanie rekordu z kolejki