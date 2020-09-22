using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Competition_Programs_Checker.Teacher
{
    public partial class Edit_Assignment : System.Web.UI.Page
    {
        protected List<ItemsRow> rows = new List<ItemsRow>();

        private List<string> inputs = new List<string>();
        private List<string> outputs = new List<string>();
        private int _lastUsedProblemId = 0;
        private string _problemId = null;

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["rows"] != null)
                rows = (List<ItemsRow>)Session["rows"];

            foreach (ItemsRow row in rows)
            {
                row.SetOnClickEvent(new EventHandler(RemoveRow));
                row.DontCauseValidation();
            }

            _problemId = Request.QueryString.Get("id");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["code"] != null)
                    code.Text = Session["code"].ToString();
                if (Session["title"] != null)
                    title.Text = Session["title"].ToString();

                GetFieldsDataOnce();
                InitializeTableRowsOnce();
            }

            FillTable();
        }

        private void GetFieldsDataOnce()
        {
            if(Session["code"] == null || Session["title"] == null)
            {
                DataView view = (DataView)problem.Select(new DataSourceSelectArguments());
                DataTable _groupsTable = view.ToTable();
                DataRow dataRow = _groupsTable.Rows[0];

                Session["code"] = dataRow["code"];
                Session["title"] = dataRow["title"];
            }


        }
        private void InitializeTableRowsOnce()
        {
            if (rows.Count == 0)
            {
                //testRuns.SelectParameters["problem_id"].DefaultValue = _problemId;
                DataView view = (DataView)testRuns.Select(new DataSourceSelectArguments());
                DataTable _groupsTable = view.ToTable();

                foreach (DataRow dataRow in _groupsTable.Rows)
                {
                    ItemsRow itemRow = new ItemsRow(dataRow["input"].ToString(), dataRow["output"].ToString());
                    rows.Add(itemRow);
                }
                Session["rows"] = rows;

                Response.Redirect("Edit_Assignment.aspx?id=" + _problemId);
            }
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
            problem.Delete();
            HttpPostedFile file = FileUpload1.PostedFile;

            string author = User.Identity.GetUserId();
            problem.InsertParameters["author"].DefaultValue = author;
            problem.InsertParameters["code"].DefaultValue = code.Text;
            problem.Insert();

            foreach (ItemsRow row in this.rows)
            {
                string input = row.Input;
                string output = row.Output;

                maxTestRunPosition.InsertParameters["input"].DefaultValue = input;
                maxTestRunPosition.InsertParameters["output"].DefaultValue = output;

                maxTestRunPosition.InsertParameters["problem_id"].DefaultValue = _lastUsedProblemId.ToString();

                DataView view = (DataView)maxTestRunPosition.Select(new DataSourceSelectArguments());
                DataTable groupsTable = view.ToTable();
                int maxPosition = int.Parse(groupsTable.Rows[0][0].ToString());
                maxPosition++;
                maxTestRunPosition.InsertParameters["order_position"].DefaultValue = maxPosition.ToString();

                maxTestRunPosition.Insert();
            }

            Session.Clear();
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

            Response.Redirect("Edit_Assignment.aspx?id=" + _problemId); //kluczowe
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

                    Response.Redirect("Edit_Assignment.aspx?id=" + _problemId); //kluczowe
                }
            }
        }

        protected void ValidateDataTable(object source, ServerValidateEventArgs args)
        {
            args.IsValid = rows.Count > 0;
        }
    }
}