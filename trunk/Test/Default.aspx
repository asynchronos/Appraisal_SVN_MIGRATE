<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:BAYConn %>" 
        SelectCommand="SELECT  top 100 [ID],[CIF],[VALUE_CUSTOMER] FROM [ANNALS_CREDIT_ACCOUNT] 
order by ID">
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
            <asp:BoundField DataField="CIF" HeaderText="CIF" 
                SortExpression="CIF" />
            <asp:BoundField DataField="VALUE_CUSTOMER" HeaderText="VALUE_CUSTOMER" 
                SortExpression="VALUE_CUSTOMER" />
        </Columns>
    </asp:GridView>
    </form>
</body>
</html>
