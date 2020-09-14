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
    [Serializable]
    public class ItemsRow
    {
        private static int rowID_identity = 0;
        private int rowID = rowID_identity;

        Label input = new Label();
        Label output = new Label();
        Button button = new Button();

        Panel div1 = new Panel();
        Panel div2 = new Panel();
        Panel div3 = new Panel();

        TableCell td1 = new TableCell();
        TableCell td2 = new TableCell();
        TableCell td3 = new TableCell();

        TableRow tr = new TableRow();

        public ItemsRow(string input, string output)
        {
            this.input.Text = input;
            this.output.Text = output;

            AddProperties();
            AddCssClasses();
            LinkElements();

            ItemsRow.rowID_identity++;
        }
        public ItemsRow(string input, string output, bool noControls)
        {
            this.input.Text = input;
            this.output.Text = output;

            AddProperties();
            AddCssClasses();
            if (noControls)
                LinkInputOutput();
            else
                LinkElements();

            ItemsRow.rowID_identity++;
        }
        public void SetOnClickEvent(EventHandler eventHandler)
        {
            this.button.Click += eventHandler;
        }
        public void DontCauseValidation() //BARDZO WAŻNE NIE ZMIENIAĆ CHYBA ŻE ABSOLUTNA PEWNOŚĆ PLS ;_;
        {
            this.button.CausesValidation = false;
            this.button.ValidationGroup = "plsdontfire";
            this.button.UseSubmitBehavior = false;
        }
        public TableRow Row
        {
            get => tr;
        }
        public int ID
        {
            get => rowID;
        }
        public string Input
        {
            get => input.Text;
        }
        public string Output
        {
            get => output.Text;
        }


        private void AddProperties()
        {
            this.input.Style.Add("word-wrap", "normal");
            this.input.Style.Add("word-break", "break-all");

            this.output.Style.Add("word-wrap", "normal");
            this.output.Style.Add("word-break", "break-all");

            this.button.Text = "Usuń";
            this.button.CommandArgument = rowID.ToString();
        }
        private void AddCssClasses()
        {
            this.input.CssClass = "data-label";
            this.output.CssClass = "data-label";
            this.button.CssClass = "data-label btn btn-danger";

            this.div1.CssClass = "data-div h-auto d-inline-block d-inline p-2 bg-primary text-white";
            this.div2.CssClass = "data-div h-auto d-inline-block d-inline p-2 bg-primary text-white";
            this.div3.CssClass = "data-div h-auto d-inline-block d-inline";

            this.td1.CssClass = "data-cell";
            this.td2.CssClass = "data-cell";
            this.td3.CssClass = "data-cell";

            this.tr.CssClass = "data-row";
        }
        private void LinkElements()
        {
            this.div1.Controls.Add(this.input);
            this.div2.Controls.Add(this.output);
            this.div3.Controls.Add(this.button);

            this.td1.Controls.Add(this.div1);
            this.td2.Controls.Add(this.div2);
            this.td3.Controls.Add(this.div3);

            this.tr.Cells.Add(td1);
            this.tr.Cells.Add(td2);
            this.tr.Cells.Add(td3);
        }
        private void LinkInputOutput()
        {
            this.div1.Controls.Add(this.input);
            this.div2.Controls.Add(this.output);

            this.td1.Controls.Add(this.div1);
            this.td2.Controls.Add(this.div2);

            this.tr.Cells.Add(td1);
            this.tr.Cells.Add(td2);
        }
    }
}