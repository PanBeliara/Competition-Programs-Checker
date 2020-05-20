<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Python.aspx.cs" Inherits="Competition_Programs_Checker.Python" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="jumbotron">
            <div>
                <asp:TextBox ID="codeTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="codeTextBox" ErrorMessage="Kod programu nie może być pusty!" ValidationGroup="addingData">*</asp:RequiredFieldValidator>
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
                    <asp:CustomValidator ID="testDataValidator" runat="server" ErrorMessage="Musisz podać przynajmniej jeden zestaw testowy!" ValidationGroup="mainGroup">*</asp:CustomValidator>
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
                    <asp:Button ID="checkButton" runat="server" OnClick="checkButton_Click" Text="Wyślij" ValidationGroup="mainGroup" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="mainGroup" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    
                    <asp:Label ID="Wynik" runat="server"></asp:Label>
                    
                </div>
            </div>
        </div>
    </div>
</asp:Content>
