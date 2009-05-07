<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Downloads_Software.aspx.vb" Inherits="Downloads_Software" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
<br />
    <asp:BulletedList ID="BulletedList1" DisplayMode ="HyperLink" runat="server">
        <asp:ListItem Value="~/Software/IE7-WindowsXP-x86-enu.exe">Internet Explorer 7.0</asp:ListItem>
        <asp:ListItem Value="~/Software/AcrobatReader.exe">Acrobat Reader</asp:ListItem>
    </asp:BulletedList>
</asp:Content>

