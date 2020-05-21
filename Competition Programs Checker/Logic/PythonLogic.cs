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
        public static string Run(TextBox codeTextBox, TextBox inputAddingTextBox, TextBox outputAddingTextBox, TextBox functionTextBox) 
        {
            //Przypisanie zmiennych
            string code = codeTextBox.Text;
            string input = inputAddingTextBox.Text;
            string output = outputAddingTextBox.Text;
            string func = functionTextBox.Text;

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
                return "Podana funkcja nie istnieje";
            }

            try
            {
                //Wywołanie funkcji testowej ze zmienną input i przypisanie wyniku do zmiennej typu var
                result = Convert.ToString(testFunction(input));
            }
            catch (Exception e)
            {
                return "Podano nieprawidłowe dane wejściowe";
            }

            if (result.Equals(output))
            {
                return "Prawidłowy wynik";
            }
            else
            {
                return "Błędny wynik";
            }

        }
    }
}