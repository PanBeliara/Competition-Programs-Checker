<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Problem_CRUD.aspx.cs" Inherits="Competition_Programs_Checker.Admin.CRUD.Problem_CRUD" %>
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
                        <HeaderTemplate>Code</HeaderTemplate>
                        <ItemTemplate><%#Eval("code") %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCode" runat="server" Text='<%#Bind("code") %>' />
                            <asp:RequiredFieldValidator ID="rfCPEdit" runat="server" ForeColor="Red" ErrorMessage="*"
                                 Display="Dynamic" ValidationGroup="edit" ControlToValidate="txtCode">Required</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtCode" runat="server"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="rfCP" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" ValidationGroup="Add" ControlToValidate="txtCode">Required</asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>Title</HeaderTemplate>
                        <ItemTemplate><%#Eval("title") %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtTitle" runat="server" Text='<%#Bind("title") %>' />
                            <asp:RequiredFieldValidator ID="rfCEdit" runat="server" ForeColor="Red" ErrorMessage="*"
                                 Display="Dynamic" ValidationGroup="edit" ControlToValidate="txtTitle">Required</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="rfCN" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" ValidationGroup="Add" ControlToValidate="txtTitle">Required</asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>Author</HeaderTemplate>
                        <ItemTemplate><%#Eval("author") %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAuthor" runat="server" Text='<%#Bind("author") %>' />
                            <asp:RequiredFieldValidator ID="authorEdit" runat="server" ForeColor="Red" ErrorMessage="*"
                                 Display="Dynamic" ValidationGroup="edit" ControlToValidate="txtAuthor">Required</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="authorAdd" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" ValidationGroup="Add" ControlToValidate="txtAuthor">Required</asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>Assignment</HeaderTemplate>
                        <ItemTemplate><%#Eval("assignment") %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAssignment" runat="server" Text='<%#Bind("assignment") %>' />
                            <asp:RequiredFieldValidator ID="assignmentEdit" runat="server" ForeColor="Red" ErrorMessage="*"
                                 Display="Dynamic" ValidationGroup="edit" ControlToValidate="txtAssignment">Required</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtAssignment" runat="server"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="assignmentAdd" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" ValidationGroup="Add" ControlToValidate="txtAssignment">Required</asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>Is Active</HeaderTemplate>
                        <ItemTemplate><%#Eval("is_active") %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtIsActive" runat="server" Text='<%#Bind("is_active") %>' />
                            <asp:RequiredFieldValidator ID="isActiveEdit" runat="server" ForeColor="Red" ErrorMessage="*"
                                 Display="Dynamic" ValidationGroup="edit" ControlToValidate="txtIsActive">Required</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtIsActive" runat="server"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="isActiveDelete" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" ValidationGroup="Add" ControlToValidate="txtIsActive">Required</asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>Best Scores Cache</HeaderTemplate>
                        <ItemTemplate><%#Eval("best_scores_cache") %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtBestScoresCache" runat="server" Text='<%#Bind("best_scores_cache") %>' />
                            <asp:RequiredFieldValidator ID="bestScoresCacheEdit" runat="server" ForeColor="Red" ErrorMessage="*"
                                 Display="Dynamic" ValidationGroup="edit" ControlToValidate="txtBestScoresCache">Required</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtBestScoresCache" runat="server"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="bestScoresCasheDelete" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" ValidationGroup="Add" ControlToValidate="txtBestScoresCache">Required</asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>Worst Best Scores</HeaderTemplate>
                        <ItemTemplate><%#Eval("worst_best_score") %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtWorstBestScore" runat="server" Text='<%#Bind("worst_best_score") %>' />
                            <asp:RequiredFieldValidator ID="worstBestScoreEdit" runat="server" ForeColor="Red" ErrorMessage="*"
                                 Display="Dynamic" ValidationGroup="edit" ControlToValidate="txtWorstBestScore">Required</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtWorstBestScore" runat="server"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="worstBestScoreAdd" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" ValidationGroup="Add" ControlToValidate="txtWorstBestScore">Required</asp:RequiredFieldValidator>
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
