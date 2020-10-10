using Competition_Programs_Checker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Microsoft.AspNet.Identity;

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
                bool error = false;
                DateTime time_before_exec = DateTime.Now;
                DateTime time_after_exec;
                TimeSpan time_offset;

                switch (LanguageDropdownList.SelectedValue)
                {
                    case ("1"):
                        foreach (TestRun test in tests)
                        {
                            var currResult = Logic.PythonLogic.Run(codeTextBox.Text.Trim(), test.input, test.output, functionName.Text.Trim());
                            if (currResult.Item1 == 0)
                            {
                                good++;
                            }
                            else if(currResult.Item1 == 2)
                            {
                                error = true;
                            }
                            overall++;
                            result = result + "<br />" + currResult.Item2;
                        }

                        result = result + "<br />" + "Wynik = " + good + "/" + overall + " || " + (Convert.ToDouble(good) / Convert.ToDouble(overall)) * 100 + "%";
                        resultTextBox.Text = result;
                        break;

                    case ("4"):
                        foreach (TestRun test in tests)
                        {
                            var currResult = Logic.JavaLogic.Run(codeTextBox.Text.Trim(), test.input, test.output, JavaClassName.Text.Trim());
                            if (currResult.Item1 == 0)
                            {
                                good++;
                            }
                            else if (currResult.Item1 == 2)
                            {
                                error = true;
                            }
                            overall++;
                            result = result + "<br />" + currResult.Item2;
                        }
                        result = result + "<br />" + "Wynik = " + good + "/" + overall + " || " + (Convert.ToDouble(good) / Convert.ToDouble(overall)) * 100 + "%";
                        resultTextBox.Text = result;
                        break;

                    case ("3"):
                        foreach (TestRun test in tests)
                        {
                            var currResult = Logic.CLogic.Run(codeTextBox.Text.Trim(), test.input, test.output);
                            if (currResult.Item1 == 0)
                            {
                                good++;
                            }
                            else if (currResult.Item1 == 2)
                            {
                                error = true;
                            }
                            overall++;
                            result = result + "<br />" + currResult.Item2;
                        }
                        result = result + "<br />" + "Wynik = " + good + "/" + overall + " || " + (Convert.ToDouble(good) / Convert.ToDouble(overall)) * 100 + "%";
                        resultTextBox.Text = result;
                        break;
                    case ("2"):
                        foreach (TestRun test in tests)
                        {
                            var currResult = Logic.JavascriptLogic.Run(codeTextBox.Text.Trim(), test.input, test.output);
                            if (currResult.Item1 == 0)
                            {
                                good++;
                            }
                            else if (currResult.Item1 == 2)
                            {
                                error = true;
                            }
                            overall++;
                            result = result + "<br />" + currResult.Item2;
                        }
                        result = result + "<br />" + "Wynik = " + good + "/" + overall + " || " + (Convert.ToDouble(good) / Convert.ToDouble(overall)) * 100 + "%";
                        resultTextBox.Text = result;
                        break;
                }
                if (User.Identity.IsAuthenticated)
                {
                    if (uploadCheckBox.Checked)
                    {
                        time_after_exec = DateTime.Now;
                        time_offset = time_after_exec - time_before_exec;

                        uploadResults(Convert.ToInt32(TaskDropdownList.SelectedValue), codeTextBox.Text.Trim(), Convert.ToInt32(LanguageDropdownList.SelectedValue), time_before_exec, time_after_exec, time_offset.TotalSeconds.ToString(), error, ((Convert.ToDouble(good) / Convert.ToDouble(overall)) * 100).ToString());
                    }
                }
                

            }
            //Program pobiera dane we/wy z textboxów
            else
            {
                switch (LanguageDropdownList.SelectedValue)
                {
                    case ("1"):
                        var result = Logic.PythonLogic.Run(codeTextBox.Text, inputTextBox.Text, outputTextBox.Text, functionName.Text);
                        resultTextBox.Text = result.Item2;
                        break;
                    case ("4"):
                        var resultJava = Logic.JavaLogic.Run(codeTextBox.Text, inputTextBox.Text, outputTextBox.Text, JavaClassName.Text);
                        resultTextBox.Text = resultJava.Item2;
                        break;
                    case ("3"):
                        var resultC = Logic.CLogic.Run(codeTextBox.Text, inputTextBox.Text, outputTextBox.Text);
                        resultTextBox.Text = resultC.Item2;
                        break;
                    case ("2"):
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
                int problemId = Convert.ToInt32(TaskDropdownList.SelectedValue);
                var Querabletests = dc.TestRuns.Where(x => x.problem_id == problemId);
                foreach (TestRun test in Querabletests)
                {
                    tests.Add(test);
                }
            }

            return tests;
        }

        protected void uploadResults(int problem_id, string code, int code_language, DateTime submitted_time, DateTime checked_time, string time_offset, bool is_error, string score)
        {
            using (DatabaseEntities dc = new DatabaseEntities())
            {
                dc.Solutions.Add(new Solution
                {
                    id = Guid.NewGuid(),
                    problem_id = problem_id,
                    solver_id = User.Identity.GetUserId(),
                    code = code,
                    code_language = code_language,
                    submitted_time = submitted_time,
                    checked_time = checked_time,
                    time_offset = time_offset,          //Kolumna pokazuje czas wykonania programu w sekundach
                    is_error = is_error,
                    score = score

                });

                dc.SaveChanges();
            }
        }

        protected void displayPDF_Click(object sender, EventArgs e)
        {
            byte[] pdfBytes;

            using (DatabaseEntities dc = new DatabaseEntities())
            {
                int id = Convert.ToInt32(TaskDropdownList.SelectedValue);
                Problem pro = dc.Problems.Where(a => a.id == id).FirstOrDefault();
                pdfBytes = pro.assignment;
            }

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-length", pdfBytes.Length.ToString());
            Response.BinaryWrite(pdfBytes);
        }
    }
}