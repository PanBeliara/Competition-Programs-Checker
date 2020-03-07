using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Competition_Programs_Checker
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string[] inputs;
        private string[] outputs;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void sendButton_Click(object sender, EventArgs e)
        {
            this.inputs = test_input.InnerText.Split(new String[] { "\r\n\r\n" }, StringSplitOptions.None);
            this.outputs = test_output.InnerText.Split(new String[] { "\r\n\r\n" }, StringSplitOptions.None);
            AlignDataContents();


            //tests
            testMessage.Text += "sent ";
        }
        private void AlignDataContents()
        {
            //upewnia się że każdy input ma swój output i odwrotnie

            int diversity = Math.Abs(inputs.Length - outputs.Length);

            if (inputs.Length > outputs.Length)
            {
                inputs = inputs.Take(inputs.Length - diversity).ToArray();
            }
            else if (outputs.Length > inputs.Length)
            {
                outputs = outputs.Take(outputs.Length - diversity).ToArray();
            }
        }
        /*
         * Do zapisu pliku znalazłem coś takiego
         * 
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