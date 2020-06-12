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

                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("D:\\Competition-Programs-Checker\\" + className+".java");

                //Write a line of text
                sw.WriteLine(code);

                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            try
            {
                process.StartInfo.FileName = "C:\\Windows\\System32\\cmd.exe";
                //process.StartInfo.Arguments = "-cp D:\\Competition-Programs-Checker\\" + className + ".java -d D:\\Competition-Programs-Checker\\";
                process.StartInfo.Arguments = "/c javac D:\\Competition-Programs-Checker\\"+className+".java";
                process.StartInfo.CreateNoWindow = false;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                process.WaitForExit();
                process.Close();

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