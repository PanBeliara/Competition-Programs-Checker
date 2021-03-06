﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace Competition_Programs_Checker.Logic
{
    public static class CLogic
    {
        public static Tuple<int, string> Run(string code, string inputs, string output)
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

                StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath("~/Logic/program.cpp"));

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

                process.StartInfo.Arguments = "/c g++ -o "+ Convert.ToChar(34) + HttpContext.Current.Server.MapPath("~/Logic/program") + Convert.ToChar(34)+" "+ Convert.ToChar(34) + HttpContext.Current.Server.MapPath("~/Logic/program.cpp") + Convert.ToChar(34);
                process.StartInfo.CreateNoWindow = false;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();

                string strError = process.StandardError.ReadToEnd().Trim();
                
                process.WaitForExit();
                process.Close();
                if (!strError.Equals(""))
                    return Tuple.Create(2, strError);
                process.StartInfo.FileName = "cmd.exe";
                //Wskazanie pliku .class
                process.StartInfo.Arguments = "/c " +  Convert.ToChar(34) + HttpContext.Current.Server.MapPath("~/Logic/program.exe") + Convert.ToChar(34) + input;
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
                        return Tuple.Create(0, "Prawidłowy wynik: " + output + " = " + strOutput);
                    }
                    else
                    {
                        return Tuple.Create(1, "Błędny wynik: " + output + " != " + strOutput);
                    }
                }
                else
                    return Tuple.Create(2, strError);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception: " + e.Message);
            }
            return Tuple.Create(2, "Error");
        }
    }
}