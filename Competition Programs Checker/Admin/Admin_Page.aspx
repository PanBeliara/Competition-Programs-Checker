<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin_Page.aspx.cs" Inherits="Competition_Programs_Checker.Admin.Admin_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">

        <div class="container">
            <div class="row">
                <div class="col">
                    <h1 style="text-align:center">CRUDs</h1>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <a class="btn btn-primary btn-lg btn-block" href="/Admin/CRUD/AspNetUsers_CRUD">AspNetUsers CRUD &raquo;</a>
                </div>
                <div class="col">
                    <a class="btn btn-primary btn-lg btn-block" href="/Admin/CRUD/AspNetRoles_CRUD">AspNetRoles CRUD &raquo;</a>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <a class="btn btn-primary btn-lg btn-block" href="/Admin/CRUD/Problem_CRUD">Problem CRUD &raquo;</a>
                </div>
                <div class="col">
                    <a class="btn btn-primary btn-lg btn-block" href="/Admin/CRUD/ProgrammingLanguages_CRUD">Programming Languages CRUD &raquo;</a>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <a class="btn btn-primary btn-lg btn-block" href="/Admin/CRUD/Solutions_CRUD">Solutions CRUD &raquo;</a>
                </div>
                <div class="col">
                    <a class="btn btn-primary btn-lg btn-block" href="/Admin/CRUD/SolutionsQueue_CRUD">Solutions Queue CRUD &raquo;</a>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <a class="btn btn-primary btn-lg btn-block" href="/Admin/CRUD/TestRuns_CRUD">TestRuns CRUD &raquo;</a>
                </div>
                <div class="col">
                    
                </div>
            </div>
        </div>

        <div class="container">
            <div class="row">
                <div class="col">
                    <h1 style="text-align:center">User Control</h1>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <a class="btn btn-primary btn-lg btn-block" href="/Admin/RolesAssignment">Change user roles &raquo;</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
