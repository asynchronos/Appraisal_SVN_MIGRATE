<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_Price2.aspx.vb" Inherits="Appraisal_Price2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="asm" runat="server">
    </asp:ScriptManager>

<br />
<br />
    <div>
    <br />
        <cc1:CollapsiblePanelExtender ID="cpeMyPanelExtender" runat="server" TargetControlID="cntPanel" ExpandControlID="ttlPanel" CollapseControlID="ttlPanel" Collapsed="false" ImageControlID="imgTitlePanel" ExpandedImage="~/Images/minus.gif" CollapsedImage="~/Images/plus.gif" SuppressPostBack="true" ExpandDirection="Vertical">
        </cc1:CollapsiblePanelExtender>
        <asp:Panel ID="ttlPanel" runat="server">
            <asp:Image ID="imgTitlePanel" runat="server" ImageAlign="Left" />
            <img src="Images/imagesCAMBBQTW.jpg" alt="" />
        </asp:Panel> 
        <asp:Panel ID="cntPanel" runat="server" Height="0px" style="overflow: hidden;">
            <div align="center">
                <p>PLACE COLLAPSIBLE PANEL CONTENTS HERE</p>
                <img src="UploadedFiles/Pic_RegID/1_2_Sunset.jpg" alt="" />
            </div>
        </asp:Panel>
    </div>
</asp:Content>

