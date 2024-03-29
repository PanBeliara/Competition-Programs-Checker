﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AspNetUsers_CRUD.aspx.cs" Inherits="Competition_Programs_Checker.Admin.CRUD.AspNetUsers_CRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="width: 100%; overflow: scroll">
        <asp:GridView ID="myGridview" runat="server" AutoGenerateColumns="false"
                DataKeyNames="Id" CellPadding="10" CellSpacing="0"
                ShowFooter="true"
                CssClass="myGrid"  HeaderStyle-CssClass="header" RowStyle-CssClass="trow1" 
                AlternatingRowStyle-CssClass="trow2" 
                OnRowCommand="myGridview_RowCommand"
                OnRowCancelingEdit="myGridview_RowCancelingEdit" 
                OnRowDeleting="myGridview_RowDeleting" 
                OnRowEditing="myGridview_RowEditing" 
                OnRowUpdating="myGridview_RowUpdating" >

                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>Email</HeaderTemplate>
                        <ItemTemplate><%#Eval("Email") %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEmail" runat="server" Text='<%#Bind("Email") %>' />
                            <asp:RequiredFieldValidator ID="rfCPEdit" runat="server" ForeColor="Red" ErrorMessage="*"
                                 Display="Dynamic" ValidationGroup="edit" ControlToValidate="txtEmail">Required</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="rfCP" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" ValidationGroup="Add" ControlToValidate="txtEmail">Required</asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>Hashed Password</HeaderTemplate>
                        <ItemTemplate><%#Eval("PasswordHash") %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPassword" runat="server" Text='<%#Bind("PasswordHash") %>' />
                            <asp:RequiredFieldValidator ID="rfCEdit" runat="server" ForeColor="Red" ErrorMessage="*"
                                 Display="Dynamic" ValidationGroup="edit" ControlToValidate="txtPassword">Required</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="rfCN" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" ValidationGroup="Add" ControlToValidate="txtPassword">Required</asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit">Edit</asp:LinkButton>
                        &nbsp;|&nbsp;
                        <asp:LinkButton ID="lbDelete" runat="server" CommandName="Delete" OnClientClick="return confirm('Are you confirm?')">Delete</asp:LinkButton>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ID="lbUpdate" runat="server" CommandName="Update" ValidationGroup="edit">Update</asp:LinkButton>
                        &nbsp;|&nbsp;
                        <asp:LinkButton ID="lbCancel" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:Button ID="btnInsert" runat="server" Text="Save" CommandName="Insert" ValidationGroup="Add" />
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
