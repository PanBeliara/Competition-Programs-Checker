using Competition_Programs_Checker.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Competition_Programs_Checker
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void sendTask_Click(object sender, EventArgs e)
        {
            switch (DropDownList2.SelectedValue)
            {
                case ("Python"):
                    string result = Logic.PythonLogic.Run(codeTextBox, inputTextBox, outputTextBox, functionName);
                    resultTextBox.Text = result;
                    break;
                case ("Java"):
                    string resultJava = Logic.JavaLogic.Run(codeTextBox, inputTextBox, outputTextBox, JavaClassName);
                    resultTextBox.Text = resultJava;
                    break;
                case ("C++"):
                    Logic.CLogic.Run();
                    break;
                case ("Javascript"):
                    Logic.JavascriptLogic.Run();
                    break;
            }
        }
    }
}