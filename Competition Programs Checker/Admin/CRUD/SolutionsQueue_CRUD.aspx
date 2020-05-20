<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SolutionsQueue_CRUD.aspx.cs" Inherits="Competition_Programs_Checker.Admin.CRUD.SolutionsQueue_CRUD" %>
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
                        <HeaderTemplate>Solver ID</HeaderTemplate>
                        <ItemTemplate><%#Eval("solver_id") %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtSolverId" runat="server" Text='<%#Bind("solver_id") %>' />
                            <asp:RequiredFieldValidator ID="rfCEdit" runat="server" ForeColor="Red" ErrorMessage="*"
                                 Display="Dynamic" ValidationGroup="edit" ControlToValidate="txtSolverId">Required</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtSolverId" runat="server"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="rfCN" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" ValidationGroup="Add" ControlToValidate="txtSolverId">Required</asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>Code</HeaderTemplate>
                        <ItemTemplate><%#Eval("code") %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCode" runat="server" Text='<%#Bind("author") %>' />
                            <asp:RequiredFieldValidator ID="codeEdit" runat="server" ForeColor="Red" ErrorMessage="*"
                                 Display="Dynamic" ValidationGroup="edit" ControlToValidate="txtCode">Required</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtCode" runat="server"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="codeAdd" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" ValidationGroup="Add" ControlToValidate="txtCode">Required</asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>Code Language</HeaderTemplate>
                        <ItemTemplate><%#Eval("code_language") %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCodeLanguage" runat="server" Text='<%#Bind("code_language") %>' />
                            <asp:RequiredFieldValidator ID="codeLanguageEdit" runat="server" ForeColor="Red" ErrorMessage="*"
                                 Display="Dynamic" ValidationGroup="edit" ControlToValidate="txtCodeLanguage">Required</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtCodeLanguage" runat="server"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="codeLanguageAdd" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" ValidationGroup="Add" ControlToValidate="txtCodeLanguage">Required</asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>Submitted Time</HeaderTemplate>
                        <ItemTemplate><%#Eval("submitted_time") %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtSubmittedTime" runat="server" Text='<%#Bind("submitted_time") %>' />
                            <asp:RequiredFieldValidator ID="submittedTimeEdit" runat="server" ForeColor="Red" ErrorMessage="*"
                                 Display="Dynamic" ValidationGroup="edit" ControlToValidate="txtSubmittedTime">Required</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtSubmittedTime" runat="server"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="submittedTimeAdd" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" ValidationGroup="Add" ControlToValidate="txtSubmittedTime">Required</asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>Time Offset</HeaderTemplate>
                        <ItemTemplate><%#Eval("time_offset") %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtTimeOffset" runat="server" Text='<%#Bind("time_offset") %>' />
                            <asp:RequiredFieldValidator ID="timeOffsetEdit" runat="server" ForeColor="Red" ErrorMessage="*"
                                 Display="Dynamic" ValidationGroup="edit" ControlToValidate="txtTimeOffset">Required</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtTimeOffset" runat="server"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="timeOffsetAdd" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" ValidationGroup="Add" ControlToValidate="txtTimeOffset">Required</asp:RequiredFieldValidator>
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
