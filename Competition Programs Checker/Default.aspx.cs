using Competition_Programs_Checker.Models;
using System;
using System.Collections.Generic;
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
            PopulateTasks();
            PopulateLanguages();
        }

        private void PopulateTasks()
        {
            List<String> allProblems = null;

            using (DatabaseEntities dc = new DatabaseEntities())
            {
                var problems = (from a in dc.Problems
                                select new
                                {
                                    a
                                });
                if (problems != null)
                {
                    allProblems = new List<String>();
                    foreach (var x in problems)
                    {
                        Problem u = x.a;
                        allProblems.Add(u.title);
                    }
                }
            }

            DropDownList1.DataSource = allProblems;
            DropDownList1.DataBind();
        }

        private void PopulateLanguages()
        {
            List<String> allLanguages = null;

            using (DatabaseEntities dc = new DatabaseEntities())
            {
                var languages = (from a in dc.ProgrammingLanguages
                                select new
                                {
                                    a
                                });
                if (languages != null)
                {
                    allLanguages = new List<String>();
                    foreach (var x in languages)
                    {
                        ProgrammingLanguage u = x.a;
                        allLanguages.Add(u.language_name);
                    }
                }
            }

            DropDownList2.DataSource = allLanguages;
            DropDownList2.SelectedValue = "Python";
            DropDownList2.DataBind();
        }

        protected void sendTask_Click(object sender, EventArgs e)
        {
            switch (DropDownList2.SelectedValue)
            {
                case ("Python"):
                    string result = Logic.PythonLogic.Run(codeTextBox, inputTextBox, outputTextBox, functionName);
                    resultTextBox.Text = result;
                    break;
                case ("Java"):
                    Logic.JavaLogic.Run();
                    break;
                case ("C++"):
                    Logic.CLogic.Run();
                    break;
                case ("Javascript"):
                    Logic.JavascriptLogic.Run();
                    break;
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayPythonControls();
        }

        public void DisplayPythonControls()
        {
            Console.WriteLine(DropDownList2.SelectedValue);
            if (DropDownList2.SelectedValue.Equals("Python"))
            {
                pythonLabel.Visible = true;
                functionName.Visible = true;
            }
            else
            {
                pythonLabel.Visible = false;
                functionName.Visible = false;
            }
        }
    }
}