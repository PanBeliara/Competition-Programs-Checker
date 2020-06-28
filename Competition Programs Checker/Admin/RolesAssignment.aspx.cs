using Competition_Programs_Checker.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Competition_Programs_Checker.Admin
{
    public partial class RolesAssignment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                UserRoleGridview.DataSource = getRoles();
                UserRoleGridview.DataBind();
            }  
        }

        protected List<RoleViewModel> getRoles()
        {
            List<RoleViewModel> model = new List<RoleViewModel>();

            using(DatabaseEntities dc = new DatabaseEntities())
            {
                var userWithRoles = dc.AspNetUsers.Include(u => u.AspNetRoles).ToList();

                foreach(AspNetUser user in userWithRoles)
                {
                    RoleViewModel userView = new RoleViewModel();

                    userView.UserId = user.Id;
                    userView.UserName = user.UserName;
                    foreach(AspNetRole role in user.AspNetRoles)
                    {
                        userView.RoleId = role.Id;
                        userView.RoleName = role.Name;
                    }

                    model.Add(userView);
                }
            }

            return model;
        }

        protected void UserRoleGridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = UserRoleGridview.Rows[index];
            var _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var _userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            if (e.CommandName == "AddAdmin")
            {
                _userManager.RemoveFromRole(row.Cells[0].Text, row.Cells[3].Text);
                _userManager.AddToRole(row.Cells[0].Text, "Admin");
            }
            if (e.CommandName == "AddTeacher")
            {
                _userManager.RemoveFromRole(row.Cells[0].Text, row.Cells[3].Text);
                _userManager.AddToRole(row.Cells[0].Text, "Teacher");
            }
            if (e.CommandName == "AddUser")
            {
                _userManager.RemoveFromRole(row.Cells[0].Text, row.Cells[3].Text);
                _userManager.AddToRole(row.Cells[0].Text, "User");
            }

            UserRoleGridview.DataSource = getRoles();
            UserRoleGridview.DataBind();
        }
    }
}