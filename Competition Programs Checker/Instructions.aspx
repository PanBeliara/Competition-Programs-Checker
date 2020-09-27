<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Instructions.aspx.cs" Inherits="Competition_Programs_Checker.Instructions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />

    <input type="button" value="Python" onclick="slidePanel('<%= Panel1.ClientID %>')" class="btn btn-secondary btn-lg btn-block" />

    <asp:Panel ID="Panel1" runat="server" style="display: none;"> 
        <ul>
            <li>Zwracając wartości do sprawdzarki programów, pamiętaj żeby zmienić je na zmienne typu string - jest to oczekiwany typ zmiennej wyjściowej</li>
            <li>Jeśli funkcja Pythona którą próbujesz wywołać wymaga podania zmiennych wejściowych pamiętaj aby:
                <ul>
                    <li>Oddzielić swoje zmienne wejściowe przecinkami</li>
                    <li>Zmienić rodzaj zmiennych w smoim kodzie pythona - domyślnie są one przekazywane jako zmienne typu string</li>
                </ul>
            </li>  
        </ul>
    </asp:Panel>

    <input type="button" value="Java" onclick="slidePanel('<%= Panel2.ClientID %>')" class="btn btn-secondary btn-lg btn-block" />

    <asp:Panel ID="Panel2" runat="server" style="display: none;"> 
        <ul>
            <li>Pole "Nazwa klasy Javy" musi równać się klasie w kodzie programu</li>
            <li>Zwracając wartości do sprawdzarki programów, pamiętaj żeby zmienić je na zmienne typu string - jest to oczekiwany typ zmiennej wyjściowej</li>
            <li>Jeśli program który próbujesz wywołać wymaga podania zmiennych wejściowych pamiętaj aby:
                <ul>
                    <li>Oddzieli swoje zmienne wejściowe przecinkami</li>
                    <li>Zmienić rodzaj zmiennych w swoim kodzie - domyślnie są one przekazywane jako zmienne typu string</li>
                </ul>
            </li>  
        </ul>
    </asp:Panel>

    <input type="button" value="C++" onclick="slidePanel('<%= Panel3.ClientID %>')" class="btn btn-secondary btn-lg btn-block" />

    <asp:Panel ID="Panel3" runat="server" style="display: none;"> 
        <ul>
            <li>Zwracając wartości do sprawdzarki programów, pamiętaj żeby zmienić je na zmienne typu string - jest to oczekiwany typ zmiennej wyjściowej</li>
            <li>Jeśli program który próbujesz wywołać wymaga podania zmiennych wejściowych pamiętaj aby:
                <ul>
                    <li>Oddzieli swoje zmienne wejściowe przecinkami</li>
                    <li>Zmienić rodzaj zmiennych w swoim kodzie - domyślnie są one przekazywane jako zmienne typu string</li>
                </ul>
            </li>  
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