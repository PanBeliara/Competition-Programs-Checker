using Competition_Programs_Checker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Competition_Programs_Checker.Admin.CRUD
{
    public partial class AspNetRoles_CRUD : System.Web.UI.Page
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
            List<AspNetRole> allRoles = null;

            using (DatabaseEntities dc = new DatabaseEntities())
            {
                var roles = (from a in dc.AspNetRoles
                             select new
                             {
                                 a
                             });
                if (roles != null)
                {
                    allRoles = new List<AspNetRole>();
                    foreach (var x in roles)
                    {
                        AspNetRole u = x.a;
                        allRoles.Add(u);
                    }
                }
            }

            if (allRoles == null || allRoles.Count == 0)
            {
                allRoles.Add(new AspNetRole());
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
                    TextBox txtName = (TextBox)fRow.FindControl("txtName");
                    using (DatabaseEntities dc = new DatabaseEntities())
                    {
                        dc.AspNetRoles.Add(new AspNetRole
                        {
                            Name = txtName.Text.Trim()
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
            string roleID = (string)myGridview.DataKeys[e.RowIndex]["Id"];

            //Find Controls 
            TextBox txtName = (TextBox)myGridview.Rows[e.RowIndex].FindControl("txtName");
            //Get Values (updated) and Save to database
            using (DatabaseEntities dc = new DatabaseEntities())
            {
                var v = dc.AspNetRoles.Where(a => a.Id.Equals(roleID)).FirstOrDefault();
                var backup = v;
                if (v != null)
                {
                    v.Name = txtName.Text.Trim();
                }
                dc.SaveChanges();
                myGridview.EditIndex = -1;
                PopulateTable();
            }
        }

        protected void myGridview_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //int userID = (int)myGridview.DataKeys[e.RowIndex]["Id"];
            string roleID = (string)myGridview.DataKeys[e.RowIndex]["Id"];
            using (DatabaseEntities dc = new DatabaseEntities())
            {
                var v = dc.AspNetRoles.Where(a => a.Id.Equals(roleID)).FirstOrDefault();
                if (v != null)
                {
                    dc.AspNetRoles.Remove(v);
                    dc.SaveChanges();
                    PopulateTable();
                }
            }
        }
    }
}