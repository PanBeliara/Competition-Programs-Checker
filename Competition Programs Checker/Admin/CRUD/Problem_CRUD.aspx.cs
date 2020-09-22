using Competition_Programs_Checker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Competition_Programs_Checker.Admin.CRUD
{
    public partial class Problem_CRUD : System.Web.UI.Page
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
            List<Problem> allProblems = null;

            using (DatabaseEntities dc = new DatabaseEntities())
            {
                var problems = (from a in dc.Problems
                             select new
                             {
                                 a
                             });
                if (problems != null)
                {
                    allProblems = new List<Problem>();
                    foreach (var x in problems)
                    {
                        Problem u = x.a;
                        allProblems.Add(u);
                    }
                }
            }

            if (allProblems == null || allProblems.Count == 0)
            {
                allProblems.Add(new Problem());
                myGridview.DataSource = allProblems;
                myGridview.DataBind();
                myGridview.Rows[0].Visible = false;
            }
            else
            {
                myGridview.DataSource = allProblems;
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
                    TextBox txtCode = (TextBox)fRow.FindControl("txtCode");
                    TextBox txtTitle = (TextBox)fRow.FindControl("txtTitle");
                    TextBox txtAuthor = (TextBox)fRow.FindControl("txtAuthor");
                    TextBox txtAssignment = (TextBox)fRow.FindControl("txtAssignment");
                    TextBox txtIsActive = (TextBox)fRow.FindControl("txtIsActive");
                    TextBox txtBestScoresCache = (TextBox)fRow.FindControl("txtBestScoresCache");
                    TextBox txtWorstBestScore = (TextBox)fRow.FindControl("txtWorstBestScore");

                    using (DatabaseEntities dc = new DatabaseEntities())
                    {
                        dc.Problems.Add(new Problem
                        {
                            code = txtCode.Text.Trim(),
                            title = txtTitle.Text.Trim(),
                            author = txtAuthor.Text.Trim(),
                            assignment = Encoding.ASCII.GetBytes(txtAssignment.Text.Trim()),
                            is_active = Convert.ToBoolean(txtIsActive.Text.Trim()),
                            best_scores_cache = txtBestScoresCache.Text.Trim(),
                            worst_best_score = txtWorstBestScore.Text.Trim()

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
            string problemId = (string)myGridview.DataKeys[e.RowIndex]["id"];

            //Find Controls
            TextBox txtCode = (TextBox)myGridview.Rows[e.RowIndex].FindControl("txtCode");
            TextBox txtTitle = (TextBox)myGridview.Rows[e.RowIndex].FindControl("txtTitle");
            TextBox txtAuthor = (TextBox)myGridview.Rows[e.RowIndex].FindControl("txtAuthor");
            TextBox txtAssignment = (TextBox)myGridview.Rows[e.RowIndex].FindControl("txtAssignment");
            TextBox txtIsActive = (TextBox)myGridview.Rows[e.RowIndex].FindControl("txtIsActive");
            TextBox txtBestScoresCache = (TextBox)myGridview.Rows[e.RowIndex].FindControl("txtBestScoresCache");
            TextBox txtWorstBestScore = (TextBox)myGridview.Rows[e.RowIndex].FindControl("txtWorstBestScore");
            //Get Values (updated) and Save to database
            using (DatabaseEntities dc = new DatabaseEntities())
            {
                var v = dc.Problems.Where(a => a.id.Equals(problemId)).FirstOrDefault();
                var backup = v;
                if (v != null)
                {
                    v.code = txtCode.Text.Trim();
                    v.title = txtTitle.Text.Trim();
                    v.author = txtAuthor.Text.Trim();
                    v.assignment = Encoding.ASCII.GetBytes(txtAssignment.Text.Trim());
                    v.is_active = Convert.ToBoolean(txtIsActive.Text.Trim());
                    v.best_scores_cache = txtBestScoresCache.Text.Trim();
                    v.worst_best_score = txtWorstBestScore.Text.Trim();

                }
                dc.SaveChanges();
                myGridview.EditIndex = -1;
                PopulateTable();
            }
        }

        protected void myGridview_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //int userID = (int)myGridview.DataKeys[e.RowIndex]["Id"];
            string problemId = (string)myGridview.DataKeys[e.RowIndex]["id"];
            using (DatabaseEntities dc = new DatabaseEntities())
            {
                var v = dc.Problems.Where(a => a.id.Equals(problemId)).FirstOrDefault();
                if (v != null)
                {
                    dc.Problems.Remove(v);
                    dc.SaveChanges();
                    PopulateTable();
                }
            }
        }
    }
}