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
            switch (DropDownList2.SelectedValue)
            {
                case ("Python"):
                    List<TestRun> tests = getTests();
                    string result = "";
                    int good = 0;
                    int overall = 0;

                    foreach (TestRun test in tests)
                    {
                        var currResult = Logic.PythonLogic.Run(codeTextBox.Text.Trim(), test.input, test.output, functionName.Text.Trim());
                        if (currResult.Substring(0, 1).Equals("P"))
                        {
                            good++;
                        }
                        overall++;
                        result = result + Environment.NewLine + currResult;
                    }

                    result = result + Environment.NewLine + "Wynik = " + good + "/" + overall + " " + (Convert.ToDouble(good) / Convert.ToDouble(overall))*100 + "%";
                    resultTextBox.Text = result;
                    break;
                case ("Java"):
                    string resultJava = Logic.JavaLogic.Run(codeTextBox, inputTextBox, outputTextBox, JavaClassName);
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

        protected List<TestRun> getTests()
        {
            List<TestRun> tests = new List<TestRun>();
            using (DatabaseEntities dc = new DatabaseEntities())
            {
                var problem = dc.Problems.Where(x => x.code == DropDownList1.SelectedValue).FirstOrDefault();
                var Querabletests = dc.TestRuns.Where(x => x.problem_id == problem.id);
                foreach (TestRun test in Querabletests)
                {
                    tests.Add(test);
                }
            }

            return tests;
        }
    }
}