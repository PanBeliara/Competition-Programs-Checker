using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Competition_Programs_Checker.Teacher
{
    public partial class Teacher_Page : System.Web.UI.Page
    {
        private DataTable _groupsTable;

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            DataView view = (DataView)Problems.Select(new DataSourceSelectArguments());
            _groupsTable = view.ToTable();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach(DataRow row in _groupsTable.Rows)
            {
                ListItem listItem = new ListItem(row["code"].ToString() +" - " + row["title"].ToString(), "View_Assignment.aspx?id=" + row["id"]);
                ProblemLinks.Items.Add(listItem);
            }
        }
    }
}