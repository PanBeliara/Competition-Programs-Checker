using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Competition_Programs_Checker.Teacher
{
    public partial class Teacher_Page : System.Web.UI.Page
    {
        private List<string> inputs = new List<string>();
        private List<string> outputs = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sendButton_Click(object sender, EventArgs e)
        {
            foreach (ListItem element in inputListBox.Items)
            {
                inputs.Add(element.Text);
            }
            foreach (ListItem element in outputListBox.Items)
            {
                outputs.Add(element.Text);
            }
        }

        protected void addDataButton_Click(object sender, EventArgs e)
        {
            string input = inputAddingTextBox.Text;
            string output = outputAddingTextBox.Text;


            inputListBox.Items.Add(new ListItem(input));
            inputAddingTextBox.Text = String.Empty;

            outputListBox.Items.Add(new ListItem(output));
            outputAddingTextBox.Text = String.Empty;


        }

        protected void ListBoxValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = outputListBox.Items.Count > 0 && inputListBox.Items.Count > 0;
        }

        protected void inputListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            outputListBox.SelectedIndex = inputListBox.SelectedIndex;
            deleteRowsButton.Enabled = true;
        }

        protected void outputListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputListBox.SelectedIndex = outputListBox.SelectedIndex;
            deleteRowsButton.Enabled = true;
        }

        protected void deleteRowsButton_Click(object sender, EventArgs e)
        {
            int id = inputListBox.SelectedIndex;
            inputListBox.Items.RemoveAt(id);
            outputListBox.Items.RemoveAt(id);

            deleteRowsButton.Enabled = false;
        }

        /* Do zapisu pliku znalazłem coś takiego
        protected void Upload(object sender, EventArgs e)
        {
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string contentType = FileUpload1.PostedFile.ContentType;
            using (Stream fs = FileUpload1.PostedFile.InputStream)
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        string query = "INSERT INTO tblFiles VALUES (@Name, @ContentType, @Data)";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("@Name", filename);
                            cmd.Parameters.AddWithValue("@ContentType", contentType);
                            cmd.Parameters.AddWithValue("@Data", bytes);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
            }

            lblMessage.Text = "File uploaded successfully.";
        }
        */
    }
}