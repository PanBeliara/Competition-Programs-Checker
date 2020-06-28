<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Teacher_Page.aspx.cs" Inherits="Competition_Programs_Checker.Teacher.Teacher_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Welcome to the Teacher page!</h1>

        <div>
            <a class="btn btn-primary" href="/Teacher/Add_Assignment">Dodaj zadanie &raquo;</a>
        </div>
        <div>
            <p>Lista dodanych zadań</p>
            <asp:SqlDataSource ID="Problems" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [id], [code], [title], [author] FROM [Problem]"></asp:SqlDataSource>
            <asp:BulletedList ID="ProblemLinks" runat="server" DisplayMode="HyperLink"></asp:BulletedList>
        </div>
    </div>
</asp:Content>
