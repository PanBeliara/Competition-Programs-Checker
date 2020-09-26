<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Competition_Programs_Checker._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">

        <asp:RadioButtonList ID="RadioButtonList1" runat="server" data-toggle="buttons" RepeatLayout="Flow" CssClass="btn-group btn-group-toggle d-flex" role="group">
            <asp:ListItem class="btn btn-secondary w-100 active" Selected="True" Value="0">Zadania</asp:ListItem>
            <asp:ListItem class="btn btn-secondary w-100" Value="1">Test programu z własnym wejściem/wyjściem</asp:ListItem>
        </asp:RadioButtonList>

        <br />
        <div class="container">
            <div class="row">
                <div class="col">
                    Wybierz język:
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [language_name], [id] FROM [ProgrammingLanguages]"></asp:SqlDataSource>
                    <asp:DropDownList ID="LanguageDropdownList" runat="server" DataSourceID="SqlDataSource2" DataTextField="language_name" DataValueField="id"></asp:DropDownList>
                </div>
            </div>
        </div>

        <div class="container" id="tasks">
            <div class="row">
                <div class="col">
                    Wybierz zadanie:
                </div>
                <div class="col">
                    
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [code], [title], [id] FROM [Problem]"></asp:SqlDataSource>
                    <asp:DropDownList ID="TaskDropdownList" runat="server" DataSourceID="SqlDataSource1" DataTextField="code" DataValueField="id"></asp:DropDownList>
                </div>
                <div class="col">
                    
                </div>
            </div>
            
            <div class="row">
                <div class="col">
                    Wyślij wynik do bazy danych: 
                    <asp:CheckBox ID="uploadCheckBox" runat="server" />
                </div>
            </div>
        </div>

        <div class="container" id="test" style="display:none;">
            <div class="row">
                <div class="col">
                    Dane wejściowe:
                </div>
                <div class="col">
                    Dane wyjściowe:
                </div>
            </div>

            <div class="row">
                <div class="col">
                    <asp:TextBox ID="inputTextBox" runat="server"></asp:TextBox>
                </div>
                <div class="col">
                    <asp:TextBox ID="outputTextBox" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>

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

        <asp:Button ID="sendTask" runat="server" Text="Wyślij" OnClick="sendTask_Click" />

        <br />
        <asp:Label ID="resultTextBox" runat="server"></asp:Label>


        <script type="text/javascript">
            $(document).ready(function () {
                checkRadioSelection();
                checkLanguageDropdown();

                $('#<%= LanguageDropdownList.ClientID %>').change(function () {
                    checkLanguageDropdown();
                });

                $('#<%=RadioButtonList1.ClientID %> input').change(function () {
                    checkRadioSelection();
                });
            });

            function checkLanguageDropdown() {
                var java = document.getElementById("javaControl");
                var python = document.getElementById("pythonControl");

                java.style.display = "none";
                python.style.display = "none";

                switch ($('#<%= LanguageDropdownList.ClientID %>').val()) {
                    case '4':
                        java.style.display = "block";
                        break;
                    case '1':
                        python.style.display = "block";
                        break;
                }
            }

            function checkRadioSelection() {
                var tasks = document.getElementById("tasks");
                var test = document.getElementById("test");

                tasks.style.display = "none";
                test.style.display = "none";

                switch ($('#<%=RadioButtonList1.ClientID %> input:checked').val()) {
                    case '0':
                        tasks.style.display = "block";
                        break;
                    case '1':
                        test.style.display = "block";
                        document.getElementById("<%=uploadCheckBox.ClientID%>").checked = false;
                        break;
                }
            }
        </script>
    </div>
</asp:Content>