using Microsoft.Ajax.Utilities;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Competition_Programs_Checker.Logic
{
    public static class PythonLogic
    {
        public static Tuple<int, string> Run(string code, string input, string output, string func) 
        {
            //Jeśli input jest pusty przypisz do niego pusty literał
            if(input == null)
            {
                input = " ";
            }

            //Zamiana inputów w postaci stringa na array
            string[] inputArr = input.Split(',');

            dynamic testFunction;
            string result;

            //Utworzenie nowego obiektu typu ScriptEngine
            ScriptEngine engine = IronPython.Hosting.Python.CreateEngine();

            //Utworzenie nowego obiektu typu ScriptSource
            ScriptSource source = engine.CreateScriptSourceFromString(code);

            //Utworzenie nowego obiektu typu ScriptScope
            ScriptScope scope = engine.CreateScope();

            //Przypisanie zawartości pliku Pythona do obiektu scope typu ScriptScope
            source.Execute(scope);

            //Przypisanie funkcji testowej do zmiennej typu dynamic
            try
            {
                //Przypisanie funkcji testowej do zmiennej typu dynamic
                testFunction = scope.GetVariable(func);

            }
            catch(Exception e)
            {
                return Tuple.Create(3, "Wybrana funkcja nie istnieje");
            }

            try
            {
                //Wywołanie funkcji testowej ze zmienną input i przypisanie wyniku do zmiennej typu var
                result = Convert.ToString(testFunction(inputArr));
            }
            catch (Exception e)
            {
                return Tuple.Create(2, "Wystąpił błąd: " + e.Message);
            }

            if (result.Equals(output))
            {
                return Tuple.Create(0, "Prawidłowy wynik: " + output + " = " + result);
            }
            else
            {
                return Tuple.Create(1, "Błędny wynik: " + output + " != " + result);
            }

        }
    }
}