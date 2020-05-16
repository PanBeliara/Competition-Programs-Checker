using Competition_Programs_Checker.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Competition_Programs_Checker.Admin.CRUD
{
    public partial class AspNetUsers_CRUD : System.Web.UI.Page
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
            List<AspNetUser> allUsers = null;

            using (User_Model_Connection dc = new User_Model_Connection())
            {
                var users = (from a in dc.AspNetUsers
                             select new
                             {
                                 a
                             });
                if (users != null)
                {
                    allUsers = new List<AspNetUser>();
                    foreach (var x in users)
                    {
                        AspNetUser u = x.a;
                        allUsers.Add(u);
                    }
                }
            }

            if (allUsers == null || allUsers.Count == 0)
            {
                allUsers.Add(new AspNetUser());
                myGridview.DataSource = allUsers;
                myGridview.DataBind();
                myGridview.Rows[0].Visible = false;
            }
            else
            {
                myGridview.DataSource = allUsers;
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
                    TextBox txtEmail = (TextBox)fRow.FindControl("txtEmail");
                    TextBox txtPassword = (TextBox)fRow.FindControl("txtPassword");
                    using (User_Model_Connection dc = new User_Model_Connection())
                    {

                        /*
                        dc.AspNetUsers.Add(new AspNetUser
                        {
                            UserName = txtContactPerson.Text.Trim(),
                            PasswordHash = txtContactNo.Text.Trim(),
                        });
                        */

                        var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                        var user = new ApplicationUser() { UserName = txtEmail.Text, Email = txtEmail.Text };
                        IdentityResult result = manager.Create(user, txtPassword.Text);
                        if (result.Succeeded) { }

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
            string userID = (string)myGridview.DataKeys[e.RowIndex]["Id"];

            //Find Controls 
            TextBox txtEmail = (TextBox)myGridview.Rows[e.RowIndex].FindControl("txtEmail");
            TextBox txtPassword = (TextBox)myGridview.Rows[e.RowIndex].FindControl("txtPassword");
            //Get Values (updated) and Save to database
            using (User_Model_Connection dc = new User_Model_Connection())
            {
                var v = dc.AspNetUsers.Where(a => a.Id.Equals(userID)).FirstOrDefault();
                var backup = v;
                if (v != null)
                {
                    v.Email = txtEmail.Text.Trim();
                    var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

                    /*
                    IdentityResult remove = manager.RemovePassword(userID);
                    IdentityResult add = manager.AddPassword(userID, txtPassword.Text.Trim());
                    */
                    v.PasswordHash = manager.PasswordHasher.HashPassword(txtPassword.Text.Trim());
                }
                dc.SaveChanges();
                myGridview.EditIndex = -1;
                PopulateTable();
            }
        }

        protected void myGridview_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //int userID = (int)myGridview.DataKeys[e.RowIndex]["Id"];
            string userID = (string)myGridview.DataKeys[e.RowIndex]["Id"];
            using (User_Model_Connection dc = new User_Model_Connection())
            {
                var v = dc.AspNetUsers.Where(a => a.Id.Equals(userID)).FirstOrDefault();
                if (v != null)
                {
                    dc.AspNetUsers.Remove(v);
                    dc.SaveChanges();
                    PopulateTable();
                }
            }
        }
    }
}