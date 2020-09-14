using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Competition_Programs_Checker.Teacher
{
    public partial class View_Assignment : System.Web.UI.Page
    {
        private string _problemId;
        private byte[] pdfBytes;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DataView view = (DataView)Problem.Select(new DataSourceSelectArguments());
                DataTable _groupsTable = view.ToTable();
                DataRow row = _groupsTable.Rows[0];

                _problemId = row["id"].ToString();

                code.Text = row["code"].ToString();
                title.Text = row["title"].ToString();

                pdfBytes = (byte[])row["assignment"];

                FillTable();
            }
            catch { }

        }
        private void FillTable()
        {
            Table1.Rows.Clear();
            TestRuns.SelectParameters["problem_id"].DefaultValue = _problemId;
            DataView view = (DataView)TestRuns.Select(new DataSourceSelectArguments());
            DataTable _groupsTable = view.ToTable();

            foreach (DataRow dataRow in _groupsTable.Rows)
            {
                ItemsRow itemRow = new ItemsRow(dataRow["input"].ToString(), dataRow["output"].ToString(), true);
                Table1.Rows.Add(itemRow.Row);
            }
        }

        protected void pdf_link_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-length", pdfBytes.Length.ToString());
            Response.BinaryWrite(pdfBytes);
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            Problem.Delete();
            Response.Redirect("Teacher_Page.aspx");
        }

        protected void edit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Edit_Assignment.aspx?id=" + _problemId);
        }
    }
}