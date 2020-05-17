<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Teacher_Page.aspx.cs" Inherits="Competition_Programs_Checker.Teacher.Teacher_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Welcome to the Teacher page!</h1>

        <div>
            <asp:RadioButtonList RepeatDirection="Horizontal" ID="LanguageButton" runat="server">
                <asp:ListItem runat="server">Python</asp:ListItem>
                <asp:ListItem runat="server">C++</asp:ListItem>
                <asp:ListItem runat="server">Java</asp:ListItem>
                <asp:ListItem runat="server">Javascript</asp:ListItem>
            </asp:RadioButtonList>
            
            <div class="form-row align-items-end">
                <div class="col-auto">
                    <label for="FileUpload1">Opis zadania [.pdf]</label>
                    <asp:FileUpload ID="FileUpload1" CssClass="form-control-file" runat="server" /> 
                </div>
                <div class="col-auto">
                    <asp:RegularExpressionValidator ID="uplValidator" runat="server" ControlToValidate="FileUpload1"
                        ErrorMessage="Dozwolonym formatem jest jedynie PDF!" 
                        ValidationExpression="(.+\.([Pp][Dd][Ff]))" ValidationGroup="mainGroup">*</asp:RegularExpressionValidator>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FileUpload1" 
                        ErrorMessage="Wysłanie pliku z opisem zadania jest wymagane!" 
                        ValidationGroup="mainGroup">*</asp:RequiredFieldValidator>
                </div>
            </div>

            <br />

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col">Testowe dane wejściowe: </div>
                        <div class="col">Testowe dane wyjściowe: </div>
                        <div class="col"></div>

                        <div class="w-100"></div>

                        <div class="col">
                            <asp:TextBox ID="inputAddingTextBox" runat="server" ValidationGroup="addingData"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="inputAddingTextBox" 
                                ErrorMessage="Dane wejściowe nie mogą być puste!" 
                                ValidationGroup="addingData">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="col">
                            <asp:TextBox ID="outputAddingTextBox" runat="server" ValidationGroup="addingData"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="outputAddingTextBox" 
                                ErrorMessage="Dane wyjściowe nie mogą być puste!" 
                                ValidationGroup="addingData">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="col">
                            <asp:Button ID="addDataButton" runat="server" Text="Dodaj zestaw testowy" OnClick="addDataButton_Click" ValidationGroup="addingData" />
                        </div>

                        <div class="w-100"></div>

                        <div class="col">
                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="addingData" />
                        </div>
                        <br />

                        <div class="w-100"></div>

                        <div class="col">
                            <asp:ListBox ID="inputListBox" runat="server" Width="125px" AutoPostBack="True" ValidationGroup="mainGroup" OnSelectedIndexChanged="inputListBox_SelectedIndexChanged"></asp:ListBox>
                        </div>
                        <div class="col">
                            <asp:ListBox ID="outputListBox" runat="server" Width="129px" AutoPostBack="True" ValidationGroup="mainGroup" OnSelectedIndexChanged="outputListBox_SelectedIndexChanged"></asp:ListBox>
                        </div>
                        <div class="col">
                            <asp:Button ID="deleteRowsButton" runat="server" Enabled="False" OnClick="deleteRowsButton_Click" Text="Usuń zestaw testowy" />
                        </div>

                        <div class="w-100"></div>

                        <div class="col">
                            <asp:CustomValidator ID="ListBoxValidator" runat="server" 
                                ErrorMessage="Dane wejściowe muszą być podane!" 
                                OnServerValidate="ListBoxValidator_ServerValidate" 
                                ValidationGroup="mainGroup">*</asp:CustomValidator>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:Button ID="sendButton" runat="server" OnClick="sendButton_Click" Text="Wyślij" ValidationGroup="mainGroup" />
            <br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="mainGroup" />
        </div>
    </div>
</asp:Content>
