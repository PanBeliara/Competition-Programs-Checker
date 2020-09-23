using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Competition_Programs_Checker;

namespace Competition_Programs_Checker.Teacher
{
    public partial class Add_Assignment : System.Web.UI.Page
    {
        protected List<ItemsRow> rows = new List<ItemsRow>();

        private List<string> inputs = new List<string>();
        private List<string> outputs = new List<string>();
        private int _lastUsedProblemId = 0;

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["rows"] != null)
                rows = (List<ItemsRow>)Session["rows"];

            if (Session["internally_redirected"] == null)
                Session["internally_redirected"] = 'n';

            foreach (ItemsRow row in rows)
            {
                row.SetOnClickEvent(new EventHandler(RemoveRow));
                row.DontCauseValidation();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack || Session["internally_redirected"].ToString() == "n")
                Session["internally_redirected"] = 'n';

            if (Session["code"] != null)
                code.Text = Session["code"].ToString();
            if (Session["title"] != null)
                title.Text = Session["title"].ToString();

            FillTable();
        }
        protected void Page_Unload(object sender, EventArgs e)
        {
            if (Session["internally_redirected"].ToString() == "n")
                Session.Clear();
        }

        private void FillTable()
        {
            Table1.Rows.Clear();
            foreach (var row in rows)
            {
                row.SetOnClickEvent(new EventHandler(RemoveRow));
                row.DontCauseValidation();
                Table1.Rows.Add(row.Row);
            }
        }
        protected void sendButton_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = FileUpload1.PostedFile;

            string author = User.Identity.GetUserId();
            problem.InsertParameters["author"].DefaultValue = author;
            problem.Insert();

            foreach (ItemsRow row in this.rows)
            {
                string input = row.Input;
                string output = row.Output;

                testRuns.InsertParameters["input"].DefaultValue = input;
                testRuns.InsertParameters["output"].DefaultValue = output;

                testRuns.InsertParameters["problem_id"].DefaultValue = _lastUsedProblemId.ToString();

                DataView view = (DataView)testRuns.Select(new DataSourceSelectArguments());
                DataTable groupsTable = view.ToTable();
                int maxPosition = int.Parse(groupsTable.Rows[0][0].ToString());
                maxPosition++;
                testRuns.InsertParameters["order_position"].DefaultValue = maxPosition.ToString();

                testRuns.Insert();
            }

            Response.Redirect("Teacher_Page.aspx");
        }
        protected void GetLastUsedProblemId(object sender, SqlDataSourceStatusEventArgs e)
        {
            _lastUsedProblemId = int.Parse(e.Command.Parameters["@inserted_id"].Value.ToString());
        }

        protected void addDataButton_Click(object sender, EventArgs e)
        {
            string input = inputAddingTextBox.Text;
            string output = outputAddingTextBox.Text;

            rows.Add(new ItemsRow(input, output));

            Session["rows"] = rows;
            Session["code"] = code.Text;
            Session["title"] = title.Text;

            Session["internally_redirected"] = 'y';
            Response.Redirect("Add_Assignment.aspx"); //kluczowe
        }

        public void RemoveRow(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int id = int.Parse(button.CommandArgument);

            foreach (ItemsRow row in this.rows)
            {
                if (row.ID == id)
                {
                    this.rows.Remove(row);
                    Session["rows"] = this.rows;
                    Session["code"] = code.Text;
                    Session["title"] = title.Text;

                    Session["internally_redirected"] = 'y';
                    Response.Redirect("Add_Assignment.aspx"); //kluczowe
                }
            }
        }

        protected void ValidateDataTable(object source, ServerValidateEventArgs args)
        {
            args.IsValid = rows.Count > 0;
        }
    }
}