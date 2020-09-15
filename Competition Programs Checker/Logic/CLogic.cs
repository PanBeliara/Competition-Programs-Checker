using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace Competition_Programs_Checker.Logic
{
    public static class CLogic
    {
        public static string Run(string code, string inputs, string output, string fileName)
        {
            Process process = new Process();
            string input = "";
            if (inputs == null)
            {
                inputs = " ";
            }

            //Zamiana inputów w postaci stringa na array
            string[] inputArr = inputs.Split(',');
            foreach (string temp in inputArr)
            {
                input += " " + temp;
            }
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor

                StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath("~/Logic/" + fileName + ".cpp"));



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
                process.StartInfo.FileName = "cmd.exe";

                process.StartInfo.Arguments = "/c g++ -o "+ Convert.ToChar(34) + HttpContext.Current.Server.MapPath("~/Logic/" + fileName) + Convert.ToChar(34)+" "+ Convert.ToChar(34) + HttpContext.Current.Server.MapPath("~/Logic/" + fileName + ".cpp") + Convert.ToChar(34);
                process.StartInfo.CreateNoWindow = false;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();

                string strError = process.StandardError.ReadToEnd().Trim();
                
                process.WaitForExit();
                process.Close();
                if (!strError.Equals(""))
                    return strError;
                process.StartInfo.FileName = "cmd.exe";
                //Wskazanie pliku .class
                process.StartInfo.Arguments = "/c " +  Convert.ToChar(34) + HttpContext.Current.Server.MapPath("~/Logic/" + fileName+".exe") + Convert.ToChar(34) + input;
                process.StartInfo.CreateNoWindow = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                /*foreach(string input in inputArr)
                {
                    process.StandardInput.WriteLine(input);
                }*/


                //Pobranie wyników pliku .class i przypisanie ich do zmiennej string
                string strOutput = process.StandardOutput.ReadToEnd().Trim();
                strError = process.StandardError.ReadToEnd().Trim();
                process.Close();
                if (strError.Equals(""))
                {
                    if (strOutput.Equals(output))
                    {
                        return "Prawidłowy wynik: " + output + " = " + strOutput;
                    }
                    else
                    {
                        return "Błędny wynik: " + output + " != " + strOutput;
                    }
                }
                else
                    return strError;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception: " + e.Message);
            }
            return "Error";
        }
    }
}