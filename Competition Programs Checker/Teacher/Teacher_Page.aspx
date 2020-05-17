<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Teacher_Page.aspx.cs" Inherits="Competition_Programs_Checker.Teacher.Teacher_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Welcome to the Teacher page!</h1>

        <div>
            <a class="btn btn-primary" href="/Teacher/Add_Assignment">Dodaj zadanie &raquo;</a>
            <a class="btn btn-primary" href="/Teacher/Edit_Assignment">Edytuj zadanie &raquo;</a>
        </div>
    </div>
</asp:Content>
