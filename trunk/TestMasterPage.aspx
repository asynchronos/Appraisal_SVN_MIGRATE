<%@ Page Title="" Language="VB" MasterPageFile="~/Appraisal_MasterPage.master" AutoEventWireup="false" CodeFile="TestMasterPage.aspx.vb" Inherits="Test_TestMasterPage" %>

<%@ Register namespace="EeekSoft.Web" tagprefix="Web" %>
<%@ Register TagPrefix="cc1" Namespace="EeekSoft.Web" Assembly="EeekSoft.Web.PopupWin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript">
    
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <asp:PlaceHolder ID="PlaceHolder" runat="server">
                    <span id="reopen"><b>!! Click here to open popup window !!</b></span>
                    
            </asp:PlaceHolder>

            <br />


</asp:Content>

