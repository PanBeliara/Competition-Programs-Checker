using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Competition_Programs_Checker.Logic
{
    public static class JavaLogic
    {
        public static string Run(TextBox codeTextBox, TextBox inputTextBox, TextBox outputTextBox, TextBox JavaClassName)
        {
            string code = codeTextBox.Text;
            string input = inputTextBox.Text;
            string output = outputTextBox.Text;
            string className = JavaClassName.Text;
            Process process = new Process();
            
            try
            {

                //ścieżka gdzie chcemy zapisać plik
                StreamWriter sw = new StreamWriter("D:\\Competition-Programs-Checker\\" + className+".java");
                sw.WriteLine(code);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            try
            {
                //ścieżka do cmd.exe
                process.StartInfo.FileName = "C:\\Windows\\System32\\cmd.exe";
                //ścieżka do wcześniej zapisanego pliku.java
                process.StartInfo.Arguments = "/c javac D:\\Competition-Programs-Checker\\"+className+".java";
                process.StartInfo.CreateNoWindow = false;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                process.WaitForExit();
                process.Close();

                //ścieżka do java.exe, zwykle C:\\Program Files\\Java\\jdk-14.0.1\\bin\\java.exe
                process.StartInfo.FileName = "C:\\Program Files\\Java\\jdk-14.0.1\\bin\\java.exe";

                //Wskazanie pliku .class
                process.StartInfo.Arguments = "-cp D:\\Competition-Programs-Checker " + className;
                process.StartInfo.CreateNoWindow = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                process.StandardInput.WriteLine(input);
                //Pobranie wyników pliku .class i przypisanie ich do zmiennej string
                string strOutput = process.StandardOutput.ReadToEnd();

                if (strOutput.Equals(output))
                {
                    return "Wynik jest poprawny";
                }
                else
                {
                    return "Błędny wynik, poprawny wynik = " + strOutput + " Podany wynik = " + output;
                }
                    
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception: " + e.Message);
            }
            return "Error";
        }
    }
}