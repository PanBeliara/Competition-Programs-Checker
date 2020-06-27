<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestRuns_CRUD.aspx.cs" Inherits="Competition_Programs_Checker.Admin.CRUD.TestRuns_CRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="jumbotron">
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
                        <HeaderTemplate>Problem ID</HeaderTemplate>
                        <ItemTemplate><%#Eval("problem_id") %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtProblemId" runat="server" Text='<%#Bind("problem_id") %>' />
                            <asp:RequiredFieldValidator ID="rfCPEdit" runat="server" ForeColor="Red" ErrorMessage="*"
                                 Display="Dynamic" ValidationGroup="edit" ControlToValidate="txtProblemId">Required</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtProblemId" runat="server"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="rfCP" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" ValidationGroup="Add" ControlToValidate="txtProblemId">Required</asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>Order Position</HeaderTemplate>
                        <ItemTemplate><%#Eval("order_position") %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtOrderPosition" runat="server" Text='<%#Bind("order_position") %>' />
                            <asp:RequiredFieldValidator ID="orderPositionEdit" runat="server" ForeColor="Red" ErrorMessage="*"
                                 Display="Dynamic" ValidationGroup="edit" ControlToValidate="txtOrderPosition">Required</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtOrderPosition" runat="server"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="orderPositionAdd" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" ValidationGroup="Add" ControlToValidate="txtOrderPosition">Required</asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>Input</HeaderTemplate>
                        <ItemTemplate><%#Eval("input") %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtInputFile" runat="server" Text='<%#Bind("input") %>' />
                            <asp:RequiredFieldValidator ID="inputFileEdit" runat="server" ForeColor="Red" ErrorMessage="*"
                                 Display="Dynamic" ValidationGroup="edit" ControlToValidate="txtInputFile">Required</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtInputFile" runat="server"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="inputFileAdd" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" ValidationGroup="Add" ControlToValidate="txtInputFile">Required</asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>Output</HeaderTemplate>
                        <ItemTemplate><%#Eval("output") %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtOutputFile" runat="server" Text='<%#Bind("output") %>' />
                            <asp:RequiredFieldValidator ID="outputFileEdit" runat="server" ForeColor="Red" ErrorMessage="*"
                                 Display="Dynamic" ValidationGroup="edit" ControlToValidate="txtOutputFile">Required</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtOutputFile" runat="server"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="outputFileAdd" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" ValidationGroup="Add" ControlToValidate="txtOutputFile">Required</asp:RequiredFieldValidator>
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
