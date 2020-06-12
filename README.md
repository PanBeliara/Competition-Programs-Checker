# Competition-Programs-Checker
 
JavaLogic:
komendy w kolejności które należy zmienić

StreamWriter sw = new StreamWriter("ścieżka gdzie chcemy zapisać plik" + className+".java");

process.StartInfo.FileName = "ścieżka do cmd.exe"; 

process.StartInfo.Arguments = "/c javac ścieżka do wcześniej zapisanego pliku.java"+className+".java";

process.StartInfo.FileName = "ścieżka do java.exe, zwykle C:\\Program Files\\Java\\jdk-14.0.1\\bin\\java.exe"";

process.StartInfo.Arguments = "-cp ścieżka do naszego pliku " + className;



