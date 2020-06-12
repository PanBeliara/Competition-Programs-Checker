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

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayPythonControls();
        }

        public void DisplayPythonControls()
        {
            Console.WriteLine(DropDownList2.SelectedValue);
            if (DropDownList2.SelectedValue.Equals("Python"))
            {
                pythonLabel.Visible = true;
                functionName.Visible = true;
            }
            else
            {
                pythonLabel.Visible = false;
                functionName.Visible = false;
            }
        }
        /* To powinno zadziałać jeżeli doda się update panel, próbowałem, nie działa a teraz chciałem wrzucić logikę javy że działa
        public void DisplayControls()
        {
            switch (DropDownList2.SelectedValue)
            {
                case "Python":
                    DropControls();
                    pythonLabel.Visible = true;
                    functionName.Visible = true;
                    break;
                case "Java":
                    DropControls();
                    JavaClassLabel.Visible = true;
                    JavaClassName.Visible = true;
                    break;
            }
        }
        public void DropControls()
        {
            JavaClassLabel.Visible = false;
            JavaClassName.Visible = false;
            pythonLabel.Visible = false;
            functionName.Visible = false;
        }
        */
    }
}