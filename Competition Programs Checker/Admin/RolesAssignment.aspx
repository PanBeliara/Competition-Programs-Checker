<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RolesAssignment.aspx.cs" Inherits="Competition_Programs_Checker.Admin.RolesAssignment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="width: 100%; overflow: scroll">
        <asp:GridView ID="UserRoleGridview" runat="server" AutoGenerateColumns="false" OnRowCommand="UserRoleGridview_RowCommand">
            <columns>
                <asp:BoundField HeaderText="User ID" DataField="UserId" />
                <asp:BoundField HeaderText="User Name" DataField="UserName" />
                <asp:BoundField HeaderText="Role ID" DataField="RoleId" />
                <asp:BoundField HeaderText="Role Name" DataField="RoleName" />
                <asp:TemplateField>
                    <HeaderTemplate>
                        Change role
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="AddAdmin" runat="server" Text="Admin" CommandName="AddAdmin" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />  
                        <asp:Button ID="AddTeacher" runat="server" Text="Teacher" CommandName="AddTeacher" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />  
                        <asp:Button ID="AddUser" runat="server" Text="User" CommandName="AddUser" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />  
                    </ItemTemplate>
                </asp:TemplateField>
            </columns>
        </asp:GridView>
    </div>
</asp:Content>
