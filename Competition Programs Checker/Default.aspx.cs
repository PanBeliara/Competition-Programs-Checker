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
            //Program pobiera dane we/wy z bazy danych
            if (RadioButtonList1.SelectedValue.Equals("0"))
            {
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
                            if (currResult.Substring(0, 1).Equals("P"))
                            {
                                good++;
                            }
                            overall++;
                            result = result + "<br />" + currResult;
                        }

                        result = result + "<br />" + "Wynik = " + good + "/" + overall + " || " + (Convert.ToDouble(good) / Convert.ToDouble(overall)) * 100 + "%";
                        resultTextBox.Text = result;
                        break;

                    case ("Java"):
                        string resultJava = Logic.JavaLogic.Run(codeTextBox.Text, inputTextBox.Text, outputTextBox.Text, JavaClassName.Text);
                        resultTextBox.Text = resultJava;
                        break;
                    case ("C++"):
                        Logic.CLogic.Run();
                        break;
                    case ("Javascript"):
                        Logic.JavascriptLogic.Run();
                        break;
                }
            }
            //Program pobiera dane we/wy z textboxów
            else
            {
                switch (DropDownList2.SelectedValue)
                {
                    case ("Python"):
                        string result = Logic.PythonLogic.Run(codeTextBox.Text, inputTextBox.Text, outputTextBox.Text, functionName.Text);
                        resultTextBox.Text = result;
                        break;
                    case ("Java"):
                        string resultJava = Logic.JavaLogic.Run(codeTextBox.Text, inputTextBox.Text, outputTextBox.Text, JavaClassName.Text);
                        resultTextBox.Text = resultJava;
                        break;
                    case ("C++"):
                        Logic.CLogic.Run();
                        break;
                    case ("Javascript"):
                        Logic.JavascriptLogic.Run();
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