<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Competition_Programs_Checker.WebForm1" %>
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        &nbsp;<asp:Label ID="Label1" runat="server" Text="Opis zadania [.pdf]"></asp:Label>
        :</p>
    <p>
        <asp:FileUpload ID="FileUpload1" runat="server" />
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Testowe dane wejściowe (testy rozdzielone pustą linią)"></asp:Label>
        :</p>
    <p>
        <textarea id="test_input" name="test_input" runat="server"></textarea></p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="Oczekiwane dane wyjściowe (testy rozdzielone pustą linią)"></asp:Label>
    </p>
    <p>
        <textarea id="test_output" aria-disabled="True" name="test_output" runat="server"></textarea></p>
    <p>
        <asp:Button ID="sendButton" runat="server" OnClick="sendButton_Click" Text="Wyślij" />
    </p>
    <p>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Wysłanie pliku z opisem zadania jest wymagane!"></asp:RequiredFieldValidator>
</p>
    <p>
        <asp:RegularExpressionValidator ID="uplValidator" runat="server" ControlToValidate="FileUpload1"
        ErrorMessage="Dozwolonym formatem jest jedynie PDF!" 
        ValidationExpression="(.+\.([Pp][Dd][Ff]))"></asp:RegularExpressionValidator>
</p>
    <p>
        &nbsp;</p>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="test_input" ErrorMessage="Testowe dane wejściowe są wymagane!"></asp:RequiredFieldValidator>
<p>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="test_output" ErrorMessage="Testowe dane wyjściowe są wymagane!"></asp:RequiredFieldValidator>
</p>
<p>
        <asp:Label ID="testMessage" runat="server"></asp:Label>
</p>
    <p>
        &nbsp;</p>
</asp:Content>
