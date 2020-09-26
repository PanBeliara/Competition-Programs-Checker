using Competition_Programs_Checker.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Competition_Programs_Checker.Admin.CRUD
{
    public partial class Solutions_CRUD : System.Web.UI.Page
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
            List<Solution> allSolutions = null;

            using (DatabaseEntities dc = new DatabaseEntities())
            {
                var solutions = (from a in dc.Solutions
                                select new
                                {
                                    a
                                });
                if (solutions != null)
                {
                    allSolutions = new List<Solution>();
                    foreach (var x in solutions)
                    {
                        Solution u = x.a;
                        allSolutions.Add(u);
                    }
                }
            }

            if (allSolutions == null || allSolutions.Count == 0)
            {
                allSolutions.Add(new Solution());
                myGridview.DataSource = allSolutions;
                myGridview.DataBind();
                myGridview.Rows[0].Visible = false;
            }
            else
            {
                myGridview.DataSource = allSolutions;
                myGridview.DataBind();
            }
        }

        protected void myGridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Insert new contact
            if (e.CommandName == "Insert")
            {
                Page.Validate("Add");
                if (Page.IsValid)
                {
                    var fRow = myGridview.FooterRow;

                    TextBox txtProblemId = (TextBox)fRow.FindControl("txtProblemId");
                    TextBox txtSolverId = (TextBox)fRow.FindControl("txtSolverId");
                    TextBox txtCode = (TextBox)fRow.FindControl("txtCode");
                    TextBox txtCodeLanguage = (TextBox)fRow.FindControl("txtCodeLanguage");
                    TextBox txtSubmittedTime = (TextBox)fRow.FindControl("txtSubmittedTime");
                    TextBox txtCheckedTime = (TextBox)fRow.FindControl("txtCheckedTime");
                    TextBox txtTimeOffset = (TextBox)fRow.FindControl("txtTimeOffset");
                    TextBox txtIsError = (TextBox)fRow.FindControl("txtIsError");
                    TextBox txtScore = (TextBox)fRow.FindControl("txtScore");

                    using (DatabaseEntities dc = new DatabaseEntities())
                    {
                        dc.Solutions.Add(new Solution
                        {
                            id = Guid.NewGuid(),
                            problem_id = Convert.ToInt32(txtProblemId.Text.Trim()),
                            solver_id = txtSolverId.Text.Trim(),
                            code = txtCode.Text.Trim(),
                            code_language = Convert.ToInt32(txtCodeLanguage.Text.Trim()),
                            submitted_time = Convert.ToDateTime(txtSubmittedTime.Text.Trim()),
                            checked_time = Convert.ToDateTime(txtCheckedTime.Text.Trim()),
                            time_offset = txtTimeOffset.Text.Trim(),
                            is_error = Convert.ToBoolean(txtIsError.Text.Trim()),
                            score = txtScore.Text.Trim()

                        });

                        dc.SaveChanges();
                        PopulateTable();
                    }
                }
            }
        }

        protected void myGridview_RowEditing(object sender, GridViewEditEventArgs e)
        {
            myGridview.EditIndex = e.NewEditIndex;
            PopulateTable();
        }

        protected void myGridview_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Cancel Edit Mode 
            myGridview.EditIndex = -1;
            PopulateTable();
        }

        protected void myGridview_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Validate Page
            Page.Validate("edit");
            if (!Page.IsValid)
            {
                return;
            }

            //Get Contact ID
            //int userID = (int)myGridview.DataKeys[e.RowIndex]["Id"];
            Guid solutionId = (Guid)myGridview.DataKeys[e.RowIndex]["Id"];

            //Find Controls
            TextBox txtProblemId = (TextBox)myGridview.Rows[e.RowIndex].FindControl("txtProblemId");
            TextBox txtSolverId = (TextBox)myGridview.Rows[e.RowIndex].FindControl("txtSolverId");
            TextBox txtCode = (TextBox)myGridview.Rows[e.RowIndex].FindControl("txtCode");
            TextBox txtCodeLanguage = (TextBox)myGridview.Rows[e.RowIndex].FindControl("txtCodeLanguage");
            TextBox txtSubmittedTime = (TextBox)myGridview.Rows[e.RowIndex].FindControl("txtSubmittedTime");
            TextBox txtCheckedTime = (TextBox)myGridview.Rows[e.RowIndex].FindControl("txtCheckedTime");
            TextBox txtTimeOffset = (TextBox)myGridview.Rows[e.RowIndex].FindControl("txtTimeOffset");
            TextBox txtIsError = (TextBox)myGridview.Rows[e.RowIndex].FindControl("txtIsError");
            TextBox txtScore = (TextBox)myGridview.Rows[e.RowIndex].FindControl("txtScore");

            //Get Values (updated) and Save to database
            using (DatabaseEntities dc = new DatabaseEntities())
            {
                var v = dc.Solutions.Where(a => a.id.Equals(solutionId)).FirstOrDefault();
                var backup = v;
                if (v != null)
                {
                    v.problem_id = Convert.ToInt32(txtProblemId.Text.Trim());
                    v.solver_id = txtSolverId.Text.Trim();
                    v.code = txtCode.Text.Trim();
                    v.code_language = Convert.ToInt32(txtCodeLanguage.Text.Trim());
                    v.submitted_time = Convert.ToDateTime(txtCheckedTime.Text.Trim());
                    v.checked_time = Convert.ToDateTime(txtSubmittedTime.Text.Trim());
                    v.time_offset = txtTimeOffset.Text.Trim();
                    v.is_error = Convert.ToBoolean(txtIsError.Text.Trim());
                    v.score = txtScore.Text.Trim();

                }
                dc.SaveChanges();
                myGridview.EditIndex = -1;
                PopulateTable();
            }
        }

        protected void myGridview_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Guid solutionId = (Guid)myGridview.DataKeys[e.RowIndex]["Id"];

            using (DatabaseEntities dc = new DatabaseEntities())
            {
                var v = dc.Solutions.Where(a => a.id.Equals(solutionId)).FirstOrDefault();
                if (v != null)
                {
                    dc.Solutions.Remove(v);
                    dc.SaveChanges();
                    PopulateTable();
                }
            }
        }
    }
}