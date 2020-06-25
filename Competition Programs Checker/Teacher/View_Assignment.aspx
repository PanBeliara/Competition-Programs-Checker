<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View_Assignment.aspx.cs" Inherits="Competition_Programs_Checker.Teacher.View_Assignment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="jumbotron">
            <asp:SqlDataSource ID="Problem" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [id], [code], [title], [author], [assignment], [is_active], [best_scores_cache], [worst_best_score] FROM [Problem]
WHERE [id] = @id">
                <SelectParameters>
                    <asp:QueryStringParameter Name="id" QueryStringField="id" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="TestRuns" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [input], [output] FROM [TestRuns]
WHERE [problem_id]=@problem_id">
                <SelectParameters>
                    <asp:Parameter DefaultValue="0" Name="problem_id" />
                </SelectParameters>
            </asp:SqlDataSource>
            <div class="row">
                <div class="col-md-4">
                    Nazwa kodowa:
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="code" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    Tytuł:
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="title" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    Testowe dane wejściowe:
                </div>
                <div class="col-md-2">
                    Testowe dane wyjściowe:
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
                    <asp:Label ID="Label1" runat="server" Text="Opis zadania [.pdf]:"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
