using Competition_Programs_Checker.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Competition_Programs_Checker
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sendTask_Click(object sender, EventArgs e)
        {

            /* W sekcji tej wartości zwracane z funkcji logiki są obiektami Tuple<int, string>
             * Pierwsza wartość w obiekcie Tuple określa status wykonanego programu:
             *  0 - Prawidłowy wynik
             *  1 - Błędny wynik
             *  2 - Wystąpił błąd
             *  3 - Wybrana funkcja nie istnieje
             *  4 - 
             * Druga wartość natomiast zawiera wiadomość zwracaną użytkownikowi
             */

            if (RadioButtonList1.SelectedValue.Equals("0")) 
            {
                //Program pobiera dane we/wy z bazy danych
                List<TestRun> tests = getTests();
                string result = "";
                int good = 0;
                int overall = 0;

                switch (DropDownList2.SelectedValue)
                {
                    case ("Python"):
                        foreach (TestRun test in tests)
                        {
                            var currResult = Logic.PythonLogic.Run(codeTextBox.Text.Trim(), test.input, test.output, functionName.Text.Trim());
                            if (currResult.Item1 == 0)
                            {
                                good++;
                            }
                            overall++;
                            result = result + "<br />" + currResult.Item2;
                        }

                        result = result + "<br />" + "Wynik = " + good + "/" + overall + " || " + (Convert.ToDouble(good) / Convert.ToDouble(overall)) * 100 + "%";
                        resultTextBox.Text = result;
                        break;

                    case ("Java"):
                        foreach (TestRun test in tests)
                        {
                            var currResult = Logic.JavaLogic.Run(codeTextBox.Text.Trim(), test.input, test.output, JavaClassName.Text.Trim());
                            if (currResult.Item1 == 0)
                            {
                                good++;
                            }
                            overall++;
                            result = result + "<br />" + currResult.Item2;
                        }
                        result = result + "<br />" + "Wynik = " + good + "/" + overall + " || " + (Convert.ToDouble(good) / Convert.ToDouble(overall)) * 100 + "%";
                        resultTextBox.Text = result;
                        break;

                    case ("C++"):
                        foreach (TestRun test in tests)
                        {
                            var currResult = Logic.CLogic.Run(codeTextBox.Text.Trim(), test.input, test.output);
                            if (currResult.Item1 == 0)
                            {
                                good++;
                            }
                            overall++;
                            result = result + "<br />" + currResult.Item2;
                        }
                        result = result + "<br />" + "Wynik = " + good + "/" + overall + " || " + (Convert.ToDouble(good) / Convert.ToDouble(overall)) * 100 + "%";
                        resultTextBox.Text = result;
                        break;
                    case ("JavaScript"):
                        foreach (TestRun test in tests)
                        {
                            var currResult = Logic.JavascriptLogic.Run(codeTextBox.Text.Trim(), test.input, test.output);
                            if (currResult.Item1 == 0)
                            {
                                good++;
                            }
                            overall++;
                            result = result + "<br />" + currResult.Item2;
                        }
                        result = result + "<br />" + "Wynik = " + good + "/" + overall + " || " + (Convert.ToDouble(good) / Convert.ToDouble(overall)) * 100 + "%";
                        resultTextBox.Text = result;
                        break;
                }
            }
            //Program pobiera dane we/wy z textboxów
            else
            {
                switch (DropDownList2.SelectedValue)
                {
                    case ("Python"):
                        var result = Logic.PythonLogic.Run(codeTextBox.Text, inputTextBox.Text, outputTextBox.Text, functionName.Text);
                        resultTextBox.Text = result.Item2;
                        break;
                    case ("Java"):
                        var resultJava = Logic.JavaLogic.Run(codeTextBox.Text, inputTextBox.Text, outputTextBox.Text, JavaClassName.Text);
                        resultTextBox.Text = resultJava.Item2;
                        break;
                    case ("C++"):
                        var resultC = Logic.CLogic.Run(codeTextBox.Text, inputTextBox.Text, outputTextBox.Text);
                        resultTextBox.Text = resultC.Item2;
                        break;
                    case ("JavaScript"):
                        var resultJavascript = Logic.JavascriptLogic.Run(codeTextBox.Text, inputTextBox.Text, outputTextBox.Text);
                        resultTextBox.Text = resultJavascript.Item2;
                        break;
                }
            }
        }
        
        protected List<TestRun> getTests()
        {
            List<TestRun> tests = new List<TestRun>();
            using (DatabaseEntities dc = new DatabaseEntities())
            {
                int problemId = Convert.ToInt32(DropDownList1.SelectedValue);
                var Querabletests = dc.TestRuns.Where(x => x.problem_id == problemId);
                foreach (TestRun test in Querabletests)
                {
                    tests.Add(test);
                }
            }

            return tests;
        }
    }
}