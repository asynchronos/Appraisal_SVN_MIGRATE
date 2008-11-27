<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Appraisal_Select.aspx.vb" Inherits="Appraisal_Select" %>

<%@ Register src="CifControl.ascx" tagname="CifControl" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:CifControl ID="CifControl1" runat="server" />
    
    </div>
    ราคาที่ 1&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="Button1" runat="server" Text="อ้างอิงราคาที่1" />
    <br />
    ราคาที่ 2&nbsp;&nbsp;&nbsp;     <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="Button2" runat="server" Text="Button" />
    <br />
    ราคาที่ 3&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="Button3" runat="server" Text="Button" />
    <br />
    </form>
</body>
</html>
