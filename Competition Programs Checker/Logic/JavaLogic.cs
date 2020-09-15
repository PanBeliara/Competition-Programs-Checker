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
        public static string Run(string code, string input, string output, string className)
        {
            Process process = new Process();

            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor

                StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath("~/Logic/" + className + ".java"));

                

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
                
                process.StartInfo.Arguments = "/c javac " + Convert.ToChar(34) + HttpContext.Current.Server.MapPath("~/Logic/" + className + ".java") + Convert.ToChar(34);
                process.StartInfo.CreateNoWindow = false;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                process.WaitForExit();
                process.Close();

                process.StartInfo.FileName = "C:\\Windows\\System32\\cmd.exe";
                //Wskazanie pliku .class
                process.StartInfo.Arguments = "/c java -cp " + Convert.ToChar(34) + HttpContext.Current.Server.MapPath("~/Logic") + Convert.ToChar(34)+" " + className;
                Debug.WriteLine("/c java " + Convert.ToChar(34) + HttpContext.Current.Server.MapPath("~/Logic") + Convert.ToChar(34) + " " + className);
                process.StartInfo.CreateNoWindow = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                process.StandardInput.WriteLine(input);
                //Pobranie wyników pliku .class i przypisanie ich do zmiennej string
                string strOutput = process.StandardOutput.ReadToEnd().Trim();

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