<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Competition_Programs_Checker._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [code], [title] FROM [Problem]"></asp:SqlDataSource>
        Wybierz zadanie:
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="code" DataValueField="code"></asp:DropDownList>
        <br />
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [language_name] FROM [ProgrammingLanguages]"></asp:SqlDataSource>
        Wybierz język:
        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2" DataTextField="language_name" DataValueField="language_name"></asp:DropDownList>

        <br />
        Kod programu:
        <br />
        <asp:TextBox CssClass="form-control" ID="codeTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>

        <div id="javaControl" style="display:none;">
            <asp:Label ID="JavaClassLabel" runat="server" Text="Nazwa klasy Javy: "></asp:Label>	
            <asp:TextBox ID="JavaClassName" runat="server"></asp:TextBox>
        </div>

        <div id="pythonControl" style="display:none;">
            <asp:Label ID="pythonLabel" runat="server" Text="Nazwa funkcji do wywołania:"></asp:Label>
            <asp:TextBox ID="functionName" runat="server"></asp:TextBox>
        </div>

        <div>
            <h3 class="text-danger">Tymczasowe kontrolki dodane w celu sprawdzenia poprawności działania logiki sprawdzarki</h3>
            <br />
            Dane wejściowe:
            <asp:TextBox ID="inputTextBox" runat="server"></asp:TextBox>
            <br />
            Dane wyjściowe:
            <asp:TextBox ID="outputTextBox" runat="server"></asp:TextBox>
        </div>  

        <br />
        <asp:Button ID="sendTask" runat="server" Text="Send" OnClick="sendTask_Click" />

        <br />
        <asp:Label ID="resultTextBox" runat="server"></asp:Label>


        <script type="text/javascript">
            $(document).ready(function () {
                $('#<%= DropDownList2.ClientID %>').change(function () {
                    var x = document.getElementById("pythonControl");
                    var y = document.getElementById("javaControl");
                    if ($(this).val() == 'Python') {
                        x.style.display = "block";
                    }
                    else {
                        x.style.display = "none";
                    }

                    if ($(this).val() == 'Java') {
                        y.style.display = "block";
                    }
                    else {
                        y.style.display = "none";
                    }
                });
            });
        </script>
    </div>
</asp:Content>