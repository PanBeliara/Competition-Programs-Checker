<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View_Solutions.aspx.cs" Inherits="Competition_Programs_Checker.Teacher.View_Solutions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="width: 100%; overflow: scroll">
        <asp:GridView ID="completedSolutionsGrid" runat="server"></asp:GridView>
    </div>
</asp:Content>
