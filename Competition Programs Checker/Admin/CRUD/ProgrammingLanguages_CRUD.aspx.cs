using Competition_Programs_Checker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Competition_Programs_Checker.Admin.CRUD
{
    public partial class ProgrammingLanguages_CRUD : System.Web.UI.Page
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
            List<ProgrammingLanguage> allRoles = null;

            using (DatabaseEntities dc = new DatabaseEntities())
            {
                var languages = (from a in dc.ProgrammingLanguages
                             select new
                             {
                                 a
                             });
                if (languages != null)
                {
                    allRoles = new List<ProgrammingLanguage>();
                    foreach (var x in languages)
                    {
                        ProgrammingLanguage u = x.a;
                        allRoles.Add(u);
                    }
                }
            }

            if (allRoles == null || allRoles.Count == 0)
            {
                allRoles.Add(new ProgrammingLanguage());
                myGridview.DataSource = allRoles;
                myGridview.DataBind();
                myGridview.Rows[0].Visible = false;
            }
            else
            {
                myGridview.DataSource = allRoles;
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
                    TextBox txtLanguageName = (TextBox)fRow.FindControl("txtLanguageName");
                    using (DatabaseEntities dc = new DatabaseEntities())
                    {
                        dc.ProgrammingLanguages.Add(new ProgrammingLanguage
                        {
                            language_name = txtLanguageName.Text.Trim()
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
            string languageId = (string)myGridview.DataKeys[e.RowIndex]["id"];

            //Find Controls 
            TextBox txtLanguageName = (TextBox)myGridview.Rows[e.RowIndex].FindControl("txtLanguageName");
            //Get Values (updated) and Save to database
            using (DatabaseEntities dc = new DatabaseEntities())
            {
                var v = dc.ProgrammingLanguages.Where(a => a.id.Equals(languageId)).FirstOrDefault();
                var backup = v;
                if (v != null)
                {
                    v.language_name = txtLanguageName.Text.Trim();
                }
                dc.SaveChanges();
                myGridview.EditIndex = -1;
                PopulateTable();
            }
        }

        protected void myGridview_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //int userID = (int)myGridview.DataKeys[e.RowIndex]["Id"];
            string languageId = (string)myGridview.DataKeys[e.RowIndex]["id"];
            using (DatabaseEntities dc = new DatabaseEntities())
            {
                var v = dc.ProgrammingLanguages.Where(a => a.id.Equals(languageId)).FirstOrDefault();
                if (v != null)
                {
                    dc.ProgrammingLanguages.Remove(v);
                    dc.SaveChanges();
                    PopulateTable();
                }
            }
        }
    }
}