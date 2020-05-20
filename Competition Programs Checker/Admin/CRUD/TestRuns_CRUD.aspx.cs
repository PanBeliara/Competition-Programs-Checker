using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Competition_Programs_Checker.Admin.CRUD
{
    public partial class TestRuns_CRUD : System.Web.UI.Page
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
            List<TestRun> allTestRuns = null;

            using (DatabaseEntities dc = new DatabaseEntities())
            {
                var testRuns = (from a in dc.TestRuns
                                 select new
                                 {
                                     a
                                 });
                if (testRuns != null)
                {
                    allTestRuns = new List<TestRun>();
                    foreach (var x in testRuns)
                    {
                        TestRun u = x.a;
                        allTestRuns.Add(u);
                    }
                }
            }

            if (allTestRuns == null || allTestRuns.Count == 0)
            {
                allTestRuns.Add(new TestRun());
                myGridview.DataSource = allTestRuns;
                myGridview.DataBind();
                myGridview.Rows[0].Visible = false;
            }
            else
            {
                myGridview.DataSource = allTestRuns;
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
                    TextBox txtOrderPosition = (TextBox)fRow.FindControl("txtOrderPosition");
                    TextBox txtInputFile = (TextBox)fRow.FindControl("txtInputFile");
                    TextBox txtOutputFile = (TextBox)fRow.FindControl("txtOutputFile");

                    using (DatabaseEntities dc = new DatabaseEntities())
                    {
                        dc.TestRuns.Add(new TestRun
                        {
                            problem_id = Convert.ToInt32(txtProblemId.Text.Trim()),
                            order_position = Convert.ToInt32(txtOrderPosition.Text.Trim()),
                            input_file = Encoding.ASCII.GetBytes(txtInputFile.Text.Trim()),
                            output_file = Encoding.ASCII.GetBytes(txtOutputFile.Text.Trim())
                        });

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
            string testRunId = (string)myGridview.DataKeys[e.RowIndex]["id"];

            //Find Controls
            TextBox txtProblemId = (TextBox)myGridview.Rows[e.RowIndex].FindControl("txtProblemId");
            TextBox txtOrderPosition = (TextBox)myGridview.Rows[e.RowIndex].FindControl("txtOrderPosition");
            TextBox txtInputFile = (TextBox)myGridview.Rows[e.RowIndex].FindControl("txtInputFile");
            TextBox txtOutputFile = (TextBox)myGridview.Rows[e.RowIndex].FindControl("txtOutputFile");

            //Get Values (updated) and Save to database
            using (DatabaseEntities dc = new DatabaseEntities())
            {
                var v = dc.TestRuns.Where(a => a.id.Equals(testRunId)).FirstOrDefault();
                var backup = v;
                if (v != null)
                {
                    v.problem_id = Convert.ToInt32(txtProblemId.Text.Trim());
                    v.problem_id = Convert.ToInt32(txtProblemId.Text.Trim());
                    v.order_position = Convert.ToInt32(txtOrderPosition.Text.Trim());
                    v.input_file = Encoding.ASCII.GetBytes(txtInputFile.Text.Trim());
                    v.output_file = Encoding.ASCII.GetBytes(txtOutputFile.Text.Trim());
                }
                dc.SaveChanges();
                myGridview.EditIndex = -1;
                PopulateTable();
            }
        }

        protected void myGridview_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //int userID = (int)myGridview.DataKeys[e.RowIndex]["Id"];
            string testRunId = (string)myGridview.DataKeys[e.RowIndex]["id"];
            using (DatabaseEntities dc = new DatabaseEntities())
            {
                var v = dc.TestRuns.Where(a => a.id.Equals(testRunId)).FirstOrDefault();
                if (v != null)
                {
                    dc.TestRuns.Remove(v);
                    dc.SaveChanges();
                    PopulateTable();
                }
            }
        }
    }
}