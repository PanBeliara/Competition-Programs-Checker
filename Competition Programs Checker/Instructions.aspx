<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Instructions.aspx.cs" Inherits="Competition_Programs_Checker.Instructions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />

    <input type="button" value="Python" onclick="slidePanel('<%= Panel1.ClientID %>')" />

    <asp:Panel ID="Panel1" runat="server" style="display: none;">
        Python program checker converts every input variable into an array of string variables and passes that array into the python function you're trying to call, so:
        <ul>
            <li>Always add one variable to the python function since the program checker always passes an array there (even if it's empty)</li>
            <li>Separate your variables with commas since that's what they're being split by</li>
            <li>Remember to change the variable types in your python code since they're being passed as string variables</li>
            <li>When returning values to the program checker, remember to change them back into strings, as it's the expected output variable type</li>
        </ul>
    </asp:Panel>

    <script type="text/javascript">
        function slidePanel(div) {
            if ($('#' + div).css('display') == 'none') {
                $('#' + div).slideDown('medium', function () { });
            } else {
                $('#' + div).slideUp('medium', function () { });
            }
        }
    </script>
</asp:Content>
