<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add_Assignment.aspx.cs" Inherits="Competition_Programs_Checker.Teacher.Add_Assignment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:SqlDataSource ID="problem" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Problem]" InsertCommand="INSERT INTO Problem(code, title, author, assignment, is_active) 
VALUES (@code, @title, @author, @assignment, @is_active);
SELECT @inserted_id = SCOPE_IDENTITY();" OnInserted="GetLastUsedProblemId">
            <InsertParameters>
                <asp:ControlParameter ControlID="code" Name="code" PropertyName="Text" />
                <asp:ControlParameter ControlID="title" Name="title" PropertyName="Text" />
                <asp:Parameter Name="author" />
                <asp:ControlParameter ControlID="FileUpload1" Name="assignment" PropertyName="FileBytes" />
                <asp:Parameter DefaultValue="1" Name="is_active" />
                <asp:Parameter Direction="Output" Name="inserted_id" Type="Int32" />
            </InsertParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="testRuns" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" InsertCommand="INSERT INTO TestRuns(problem_id, order_position, input, output) VALUES (@problem_id, @order_position, @input, @output)" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT MAX([order_position]) FROM [TestRuns]">
            <InsertParameters>
                <asp:Parameter Name="problem_id" Type="Int32" />
                <asp:Parameter Name="order_position" Type="Int32" />
                <asp:Parameter Name="input" />
                <asp:Parameter Name="output" />
            </InsertParameters>
        </asp:SqlDataSource>
        <div class="jumbotron">
            <div class="row">
                <div class="col-md-4">
                    Nazwa kodowa:
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <asp:TextBox ID="code" runat="server" MaxLength="20"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Podaj nazwę kodową" Text="*" ControlToValidate="code" ValidationGroup="mainGroup"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    Tytuł:
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <asp:TextBox ID="title" runat="server" MaxLength="100"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Podaj tytuł" ControlToValidate="title" Text="*" ValidationGroup="mainGroup"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    Testowe dane wejściowe:
                </div>
                <div class="col-md-4">
                    Testowe dane wyjściowe:
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <asp:TextBox ID="inputAddingTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="inputAddingTextBox" ErrorMessage="Dane wejściowe nie mogą być puste!" ValidationGroup="addingData">*</asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="outputAddingTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="outputAddingTextBox" ErrorMessage="Dane wyjściowe nie mogą być puste!" ValidationGroup="addingData">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <asp:Button ID="addDataButton" runat="server" Text="Dodaj zestaw testowy" OnClick="addDataButton_Click" ValidationGroup="addingData" />
                    <asp:CustomValidator ID="testDataValidator" runat="server" ErrorMessage="Musisz podać przynajmniej jeden zestaw testowy!" OnServerValidate="ValidateDataTable" ValidationGroup="mainGroup">*</asp:CustomValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="addingData" />
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-4">
                    <asp:Table ID="Table1" runat="server" CssClass="data-table"></asp:Table>
                </div>
            </div>

            <br /><br /><br />
        
            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="Label1" runat="server" Text="Opis zadania [.pdf]:"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:RegularExpressionValidator ID="uplValidator" runat="server" ControlToValidate="FileUpload1"
                    ErrorMessage="Dozwolonym formatem jest jedynie PDF!" 
                    ValidationExpression="(.+\.([Pp][Dd][Ff]))" ValidationGroup="mainGroup">*</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Wysłanie pliku z opisem zadania jest wymagane!" ValidationGroup="mainGroup">*</asp:RequiredFieldValidator>
                </div>
            </div>

            <br /><br /><br />

            <div class="row">
                <div class="col-md-4">
                    <asp:Button ID="Button1" runat="server" OnClick="sendButton_Click" Text="Wyślij" ValidationGroup="mainGroup" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="mainGroup" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
