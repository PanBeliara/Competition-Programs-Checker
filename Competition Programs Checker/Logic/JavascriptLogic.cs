using Microsoft.ClearScript.V8;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Competition_Programs_Checker.Logic
{
    public static class JavascriptLogic
    {
        public static Tuple<int, string> Run(string code, string inputs, string output)
        {
            //Jeśli input jest pusty przypisz do niego pusty literał
            if (inputs == null)
            {
                inputs = " ";
            }

            //Inicjalizacja silnika Javascript
            using (V8ScriptEngine v8 = new V8ScriptEngine()) {
                //inicjalizacja zmiennych
                //długie nazwy by nie kolidowały z nazwami zmiennych użytkownika
                v8.Script.hiddenVariableStdinString = inputs;
                v8.Execute(@"
                    var hiddenVariableStdinArray = hiddenVariableStdinString.split("","");
                    hiddenVariableStdoutArray = [];
                    function readline(){ 
                        var temp = hiddenVariableStdinArray[0];
                        hiddenVariableStdinArray.shift();
                        return temp;
                    }
                    function print(content){
                        var temp = content.toString();
                        hiddenVariableStdoutArray.push(temp);
                        return temp;
                    }");
                try
                {
                    v8.Execute(code);
                    String strOutput = "";
                    foreach (String line in v8.Script.hiddenVariableStdoutArray)
                        strOutput += line + " ";
                    strOutput = strOutput.Trim();
                    if (strOutput.Equals(output))
                    {
                        return Tuple.Create(0, "Prawidłowy wynik: " + output + " = " + strOutput);
                    }
                    else
                    {
                        return Tuple.Create(1, "Błędny wynik: " + output + " != " + strOutput);
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Exception: " + e.Message);
                    return Tuple.Create(2, "Błąd: "+e.Message);
                }
            }
        }
    }
}