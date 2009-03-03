<%@ Page Language="VB" AutoEventWireup="true" CodeFile="Gmap.aspx.vb"  Inherits="_Gmap" %>
<html>
<head>
    <style type="text/css">
        .style1
        {
            width: 226px;
        }
    </style>
</head>
<body>
<form id="formGmap"  runat="server">
<asp:Panel ID="PanelGridGmap" runat="server" Height="200px" Width="500px">
<table>
	<tr><td>
		<asp:Label ID="lblSearchVar" runat="server" Text="Search DB"></asp:Label>
		<asp:DropDownList ID="ddlFieldValue" runat="server" >
		<asp:ListItem Text="COLL_ID" Value="COLL_ID"></asp:ListItem>
		<asp:ListItem Text="Lat" Value="Lat"></asp:ListItem>
		<asp:ListItem Text="Lng" Value="Lng"></asp:ListItem>
		<asp:ListItem Text="Name" Value="Name"></asp:ListItem>
		<asp:ListItem Text="Detail" Value="Detail"></asp:ListItem>
		<asp:ListItem Text="Price1" Value="Price1"></asp:ListItem>
		<asp:ListItem Text="Price2" Value="Price2"></asp:ListItem>
		<asp:ListItem Text="Price3" Value="Price3"></asp:ListItem>
		<asp:ListItem Text="Pic1" Value="Pic1"></asp:ListItem>
		<asp:ListItem Text="Pic2" Value="Pic2"></asp:ListItem>
		</asp:DropDownList>
		<asp:DropDownList ID="ddlOperator" runat="server" >
		<asp:ListItem Text="Contains" Value=" LIKE "></asp:ListItem>
		<asp:ListItem Text="Does Not Contain" Value=" Not LIKE "></asp:ListItem>
		<asp:ListItem Text="Less Than" Value=" &lt; "></asp:ListItem>
		<asp:ListItem Text="Equal To" Value=" = "></asp:ListItem>
		<asp:ListItem Text="Greater Than" Value=" &gt; "></asp:ListItem>
		<asp:ListItem Text="Not Equal To" Value=" &lt;&gt; "></asp:ListItem>
		</asp:DropDownList>
		<asp:TextBox ID="tbSearchValue" runat="server"></asp:TextBox>
		<asp:Button ID="btnSearchVar" runat="server" Text="Search" />
		<asp:Button ID="btnAddNew" runat="server" Text="Add" />
	</td></tr>
	<tr><td>
<asp:GridView ID="GridGmap" runat="server" AutoGenerateColumns="False"  
            AllowPaging="True" Height="254px" Width="636px">
	<Columns>
		<asp:CommandField ShowSelectButton="True" />
		<asp:BoundField DataField="COLL_ID" HeaderText="COLL_ID"  Visible="True" />
		<asp:BoundField DataField="Lat" HeaderText="Lat"  Visible="True" />
		<asp:BoundField DataField="Lng" HeaderText="Lng"  Visible="True" />
		<asp:BoundField DataField="Name" HeaderText="Name"  Visible="True" />
		<asp:BoundField DataField="Detail" HeaderText="Detail"  Visible="True" />
		<asp:BoundField DataField="Price1" HeaderText="Price1"  Visible="False" />
		<asp:BoundField DataField="Price2" HeaderText="Price2"  Visible="False" />
		<asp:BoundField DataField="Price3" HeaderText="Price3"  Visible="False" />
		<asp:BoundField DataField="Pic1" HeaderText="Pic1"  Visible="False" />
		<asp:BoundField DataField="Pic2" HeaderText="Pic2"  Visible="False" />
	</Columns>
	<EmptyDataTemplate>
	 Don't have data
	</EmptyDataTemplate>
	</asp:GridView>
	</td></tr>
	</table>
	</asp:Panel>
<asp:Panel ID="PanelGmap" runat="server" Height="200px" Width="400px">
<table border="0">
<tr><td colspan="3">Gmap</td></tr><tr><td><asp:Label ID="lblCOLL_ID" text="COLL_ID" runat="server"></asp:Label></td>
    <td class="style1"><asp:TextBox ID="tbCOLL_ID" runat="server" maxlength="50"></asp:TextBox>
<asp:Button ID="btnSearch" runat="server" Text="Search" /> 
</td></tr>
<tr><td><asp:Label ID="lblLat" text="Lat" runat="server"></asp:Label></td>
    <td class="style1"><asp:TextBox ID="tbLat" runat="server" maxlength="53"></asp:TextBox>
</td></tr>
<tr><td><asp:Label ID="lblLng" text="Lng" runat="server"></asp:Label></td>
    <td class="style1"><asp:TextBox ID="tbLng" runat="server" maxlength="53"></asp:TextBox>
</td></tr>
<tr><td><asp:Label ID="lblName" text="Name" runat="server"></asp:Label></td>
    <td class="style1"><asp:TextBox ID="tbName" runat="server" maxlength="50"></asp:TextBox>
</td></tr>
<tr><td><asp:Label ID="lblDetail" text="Detail" runat="server"></asp:Label></td>
    <td class="style1"><asp:TextBox ID="tbDetail" runat="server" maxlength="100"></asp:TextBox>
</td></tr>
<tr><td><asp:Label ID="lblPrice1" text="Price1" runat="server"></asp:Label></td>
    <td class="style1"><asp:TextBox ID="tbPrice1" runat="server" maxlength="18"></asp:TextBox>
</td></tr>
<tr><td><asp:Label ID="lblPrice2" text="Price2" runat="server"></asp:Label></td>
    <td class="style1"><asp:TextBox ID="tbPrice2" runat="server" maxlength="18"></asp:TextBox>
</td></tr>
<tr><td><asp:Label ID="lblPrice3" text="Price3" runat="server"></asp:Label></td>
    <td class="style1"><asp:TextBox ID="tbPrice3" runat="server" maxlength="18"></asp:TextBox>
</td></tr>
<tr><td><asp:Label ID="lblPic1" text="Pic1" runat="server"></asp:Label></td>
    <td class="style1"><asp:TextBox ID="tbPic1" runat="server" maxlength="100"></asp:TextBox>
</td></tr>
<tr><td><asp:Label ID="lblPic2" text="Pic2" runat="server"></asp:Label></td>
    <td class="style1"><asp:TextBox ID="tbPic2" runat="server" maxlength="100"></asp:TextBox>
</td></tr>
<tr><td colspan="3">
<asp:Button ID="btnAdd" runat="server" Text="Add" /> 
<asp:Button ID="btnUpdate" runat="server" Text="Update" /> 
<asp:Button ID="btnDelete" runat="server" Text="Delete" />
<asp:Button ID="btnCancel" runat="server" Text="Cancel" />
</td></tr>
</table></asp:Panel></form>
</body>
</html>

