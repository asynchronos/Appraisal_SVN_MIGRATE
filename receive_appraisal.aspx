<%@ Page Language="VB" AutoEventWireup="false" CodeFile="receive_appraisal.aspx.vb" Inherits="receive_appraisal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Receive Date</title>
</head>
<body style="margin-top:0px; margin-left:7px; margin-right:0px; background-image:url(Images/imagesCAMBBQTW.jpg);">
    <form id="form1" runat="server">
    <div>
    
        <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" 
            BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" 
            Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" 
            ShowGridLines="True" Width="220px">
            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
            <SelectorStyle BackColor="#FFCC66" />
            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#CC9966" />
            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" 
                ForeColor="#FFFFCC" />
        </asp:Calendar>
    
        <asp:Label ID="lblMessage" runat="server" style="color: #FF0000" Width="200px"></asp:Label>
        <asp:Button ID="btnSave" runat="server" Text="บันทึกวันรับเรื่อง" />
    </div>
    </form>
</body>
</html>
