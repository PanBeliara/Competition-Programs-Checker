<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddAssignment.aspx.cs" Inherits="Competition_Programs_Checker.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #TextArea1 {
            height: 56px;
            width: 355px;
        }
        #input {
            width: 352px;
            height: 57px;
        }
        #output {
            width: 351px;
            height: 54px;
        }
        #test_output {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ValidationGroup="mainGroup">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <p>
        &nbsp;<asp:Label ID="Label1" runat="server" Text="Opis zadania [.pdf]"></asp:Label>
        :</p>
    <p>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:RegularExpressionValidator ID="uplValidator" runat="server" ControlToValidate="FileUpload1"
        ErrorMessage="Dozwolonym formatem jest jedynie PDF!" 
        ValidationExpression="(.+\.([Pp][Dd][Ff]))" ValidationGroup="mainGroup">*</asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Wysłanie pliku z opisem zadania jest wymagane!" ValidationGroup="mainGroup">*</asp:RequiredFieldValidator>
    </p>
    <p>
    </p>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <p>
        Testowe dane wejściowe:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Testowe dane wyjściowe:</p>
    <p>
        <asp:TextBox ID="inputAddingTextBox" runat="server" ValidationGroup="addingData"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="inputAddingTextBox" ErrorMessage="Dane wejściowe nie mogą być puste!" ValidationGroup="addingData">*</asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="outputAddingTextBox" runat="server" ValidationGroup="addingData"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="outputAddingTextBox" ErrorMessage="Dane wyjściowe nie mogą być puste!" ValidationGroup="addingData">*</asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="addDataButton" runat="server" Text="Dodaj zestaw testowy" OnClick="addDataButton_Click" ValidationGroup="addingData" />
    </p>
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="addingData" />
    <p>
        <asp:ListBox ID="inputListBox" runat="server" Width="125px" AutoPostBack="True" ValidationGroup="mainGroup" OnSelectedIndexChanged="inputListBox_SelectedIndexChanged"></asp:ListBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ListBox ID="outputListBox" runat="server" Width="129px" AutoPostBack="True" ValidationGroup="mainGroup" OnSelectedIndexChanged="outputListBox_SelectedIndexChanged"></asp:ListBox>
        <asp:CustomValidator ID="ListBoxValidator" runat="server" ErrorMessage="Dane wejściowe muszą być podane!" OnServerValidate="ListBoxValidator_ServerValidate" ValidationGroup="mainGroup">*</asp:CustomValidator>
    </p>
            <p>
                &nbsp;</p>
            <p>
                <asp:Button ID="deleteRowsButton" runat="server" Enabled="False" OnClick="deleteRowsButton_Click" Text="Usuń zestaw testowy" />
            </p>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <p>
        <asp:Button ID="sendButton" runat="server" OnClick="sendButton_Click" Text="Wyślij" ValidationGroup="mainGroup" />
    </p>
    <p>
        &nbsp;</p>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="mainGroup" />
        </asp:Content>
