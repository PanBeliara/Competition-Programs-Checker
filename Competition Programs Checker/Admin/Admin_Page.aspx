<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin_Page.aspx.cs" Inherits="Competition_Programs_Checker.Admin.Admin_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1 style="text-align:center">CRUDs</h1>
        <a class="btn btn-primary" href="/Admin/CRUD/AspNetUsers_CRUD">AspNetUsers CRUD &raquo;</a>
        <a class="btn btn-primary" href="/Admin/CRUD/AspNetRoles_CRUD">AspNetRoles CRUD &raquo;</a>
        <a class="btn btn-primary" href="/Admin/CRUD/Problem_CRUD">Problem CRUD &raquo;</a>
        <a class="btn btn-primary" href="/Admin/CRUD/ProgrammingLanguages_CRUD">Programming Languages CRUD &raquo;</a>
        <a class="btn btn-primary" href="/Admin/CRUD/Solutions_CRUD">Solutions CRUD &raquo;</a>
        <br />
        <br />
        <a class="btn btn-primary" href="/Admin/CRUD/SolutionsQueue_CRUD">Solutions Queue CRUD &raquo;</a>
        <a class="btn btn-primary" href="/Admin/CRUD/TestRuns_CRUD">TestRuns CRUD &raquo;</a>

        <h1 style="text-align:center">User Control</h1>
        <a class="btn btn-primary" href="/Admin/RolesAssignment">Change user roles &raquo;</a>
    </div>
</asp:Content>
