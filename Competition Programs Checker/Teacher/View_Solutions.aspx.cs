using Competition_Programs_Checker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Competition_Programs_Checker.Teacher
{
    public partial class View_Solutions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateTable();
            }
        }

        private void PopulateTable()
        {
            List<SolutionViewModel> allSolutions = null;

            using (DatabaseEntities dc = new DatabaseEntities())
            {
                var solutions = (from a in dc.Solutions
                                 select new
                                 {
                                     a
                                 });

                if (solutions != null)
                {
                    allSolutions = new List<SolutionViewModel>();
                    foreach (var x in solutions)
                    {
                        SolutionViewModel u = new SolutionViewModel();

                        u.problemName = x.a.Problem.code;
                        u.userName = x.a.AspNetUser.UserName;
                        u.code = x.a.code;
                        u.codeLanguage = x.a.ProgrammingLanguage.language_name;
                        u.submittedTime = x.a.submitted_time.ToString();
                        u.execTime = x.a.time_offset;
                        u.is_error = x.a.is_error.ToString();
                        u.score = x.a.score;

                        allSolutions.Add(u);
                    }
                }

                if (allSolutions == null || allSolutions.Count == 0)
                {
                    allSolutions.Add(new SolutionViewModel());
                    completedSolutionsGrid.DataSource = allSolutions;
                    completedSolutionsGrid.DataBind();
                    completedSolutionsGrid.Rows[0].Visible = false;
                }
                else
                {
                    completedSolutionsGrid.DataSource = allSolutions;
                    completedSolutionsGrid.DataBind();
                }
                renameColumns();
            }
        }

        private void renameColumns()
        {
            GridViewRow header = completedSolutionsGrid.HeaderRow;

            header.Cells[0].Text = "Zadanie";
            header.Cells[1].Text = "Rozwiązujący";
            header.Cells[2].Text = "Kod";
            header.Cells[3].Text = "Język Programowania";
            header.Cells[4].Text = "Czas złożenia";
            header.Cells[5].Text = "Czas wykonania programu w sekundach";
            header.Cells[6].Text = "Błąd podczas wykonywania/kompilacji programu";
            header.Cells[7].Text = "Wynik w %";
        }
    }
}