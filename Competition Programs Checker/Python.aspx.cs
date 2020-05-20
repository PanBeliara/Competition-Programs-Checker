using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Competition_Programs_Checker
{
    public partial class Python : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Check_Stuff()
        {
            //Przypisanie zmiennych
            var code = codeTextBox.Text;
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
            string result = testFunction(input);

            Console.WriteLine(result);

            if (String.Equals(result, output))
            {
                Response.Redirect("~/");
            }
        }

        protected void checkButton_Click(object sender, EventArgs e)
        {
            Check_Stuff();
        }

        protected void addDataButton_Click(object sender, EventArgs e)
        {

        }
    }
}