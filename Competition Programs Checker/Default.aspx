<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Competition_Programs_Checker._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        Wybierz zadanie:
        <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
        <br />
        Wybierz język:
        <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList>

        <br />
        Kod programu:
        <br />
        <asp:TextBox CssClass="form-control" ID="codeTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
        <br />

        <asp:Label ID="pythonLabel" runat="server" Text="Nazwa funkcji do wywołania:"></asp:Label>
        <asp:TextBox ID="functionName" runat="server"></asp:TextBox>

        <div>
            <h3 class="text-danger">Tymczasowe kontrolki dodane w celu sprawdzenia poprawności działania logiki sprawdzarki</h3>
            <br />
            Dane wejściowe:
            <asp:TextBox ID="inputTextBox" runat="server"></asp:TextBox>
            <br />
            Dane wyjściowe:
            <asp:TextBox ID="outputTextBox" runat="server"></asp:TextBox>
        </div>  

        <br />
        <asp:Button ID="sendTask" runat="server" Text="Send" OnClick="sendTask_Click" />

        <br />
        <asp:Label ID="resultTextBox" runat="server"></asp:Label>
    </div>
</asp:Content>