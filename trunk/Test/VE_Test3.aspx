<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VE_Test3.aspx.vb" Inherits="Test_VE_Test3" %>

<%@ Register assembly="Microsoft.Live.ServerControls.VE" namespace="Microsoft.Live.ServerControls.VE" tagprefix="ve" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
        </asp:ScriptManager>
        <ve:Map ID="Map1" runat="server" Height="400px" Width="400px" ZoomLevel="4" />
    
    </div>
    <p>
        <asp:Label ID="MouseLat" runat="server"></asp:Label>
        <br />
        <asp:Label ID="MouseLng" runat="server"></asp:Label>
        <br />
        <asp:Label ID="MarkerLat" runat="server"></asp:Label>
        <br />
        <asp:Label ID="MarkerLng" runat="server"></asp:Label>
        </p>
    <p>
        <input id="Button1" type="button" value="button" onclick ="AddPushpin()" /></p>
    </form>
</body>
</html>
