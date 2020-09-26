using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using Competition_Programs_Checker.Models;
using System.Web.UI.WebControls;

namespace Competition_Programs_Checker.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        protected string SuccessMessage
        {
            get;
            private set;
        }

        private bool HasPassword(ApplicationUserManager manager)
        {
            return manager.HasPassword(User.Identity.GetUserId());
        }

        public bool HasPhoneNumber { get; private set; }

        public bool TwoFactorEnabled { get; private set; }

        public bool TwoFactorBrowserRemembered { get; private set; }

        public int LoginsCount { get; set; }

        protected void Page_Load()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            HasPhoneNumber = String.IsNullOrEmpty(manager.GetPhoneNumber(User.Identity.GetUserId()));

            // Enable this after setting up two-factor authentientication
            //PhoneNumber.Text = manager.GetPhoneNumber(User.Identity.GetUserId()) ?? String.Empty;

            TwoFactorEnabled = manager.GetTwoFactorEnabled(User.Identity.GetUserId());

            LoginsCount = manager.GetLogins(User.Identity.GetUserId()).Count;

            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            if (!IsPostBack)
            {
                // Determine the sections to render
                if (HasPassword(manager))
                {
                    ChangePassword.Visible = true;
                }
                else
                {
                    CreatePassword.Visible = true;
                    ChangePassword.Visible = false;
                }

                // Render success message
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    // Strip the query string from action
                    Form.Action = ResolveUrl("~/Account/Manage");

                    SuccessMessage =
                        message == "ChangePwdSuccess" ? "Your password has been changed."
                        : message == "SetPwdSuccess" ? "Your password has been set."
                        : message == "RemoveLoginSuccess" ? "The account was removed."
                        : message == "AddPhoneNumberSuccess" ? "Phone number has been added"
                        : message == "RemovePhoneNumberSuccess" ? "Phone number was removed"
                        : String.Empty;
                    successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
                }

                PopulateTable();
            }

        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        // Remove phonenumber from user
        protected void RemovePhone_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var result = manager.SetPhoneNumber(User.Identity.GetUserId(), null);
            if (!result.Succeeded)
            {
                return;
            }
            var user = manager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                Response.Redirect("/Account/Manage?m=RemovePhoneNumberSuccess");
            }
        }

        // DisableTwoFactorAuthentication
        protected void TwoFactorDisable_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.SetTwoFactorEnabled(User.Identity.GetUserId(), false);

            Response.Redirect("/Account/Manage");
        }

        //EnableTwoFactorAuthentication 
        protected void TwoFactorEnable_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.SetTwoFactorEnabled(User.Identity.GetUserId(), true);

            Response.Redirect("/Account/Manage");
        }

        private void PopulateTable()
        {
            List<SolutionViewModel> allSolutions = null;

            string userid = User.Identity.GetUserId();

            using (DatabaseEntities dc = new DatabaseEntities())
            {
                var solutions = (from a in dc.Solutions where a.solver_id == userid
                                 select new
                                 {
                                     a
                                 }
                                 );

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
                    mySolutions.DataSource = allSolutions;
                    mySolutions.DataBind();
                    mySolutions.Rows[0].Visible = false;
                }
                else
                {
                    mySolutions.DataSource = allSolutions;
                    mySolutions.DataBind();
                }
                renameColumns();
            }
        }

        private void renameColumns()
        {
            GridViewRow header = mySolutions.HeaderRow;

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