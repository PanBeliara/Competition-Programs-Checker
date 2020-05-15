<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" EnableViewState="true" AutoEventWireup="true" CodeBehind="AddAssignment.aspx.cs" Inherits="Competition_Programs_Checker.AddAssignment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">
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
</asp:Content>
