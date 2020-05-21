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
        public static void Run(TextBox codeTextBox, TextBox inputAddingTextBox, TextBox outputAddingTextBox) 
        {
            //Przypisanie zmiennych
            string code = codeTextBox.Text;
            var input = inputAddingTextBox.Text;
            var output = outputAddingTextBox.Text;

            //Utworzenie nowego obiektu typu ScriptEngine
            ScriptEngine engine = IronPython.Hosting.Python.CreateEngine();

            //Utworzenie nowego obiektu typu ScriptSource
            ScriptSource source = engine.CreateScriptSourceFromString(code);

            //Utworzenie nowego obiektu typu ScriptScope
            ScriptScope scope = engine.CreateScope();

            //Przypisanie zawartości pliku Pythona do obiektu scope typu ScriptScope
            source.Execute(scope);

            //Przypisanie funkcji testowej do zmiennej typu dynamic
            dynamic testFunction = scope.GetVariable("test_func");

            //Wywołanie funkcji testowej ze zmiennymi var1, var2 i przypisanie wyniku do zmiennej typu var
            var result = testFunction(input);
        }
    }
}