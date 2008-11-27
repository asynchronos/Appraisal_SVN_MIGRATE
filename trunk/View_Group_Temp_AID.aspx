<%@ Page Language="VB" AutoEventWireup="false" CodeFile="View_Group_Temp_AID.aspx.vb" Inherits="View_Group_Temp_AID" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body style="margin-top:0px; margin-left:0px; margin-right:0px; background-image:url(Images/imagesCAMBBQTW.jpg);">
    <form id="form1" runat="server">
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="2" DataSourceID="SDSTemp_AID" 
            ForeColor="Black" GridLines="None" BackColor="LightGoldenrodYellow" 
            BorderColor="Tan" BorderWidth="1px" Width="100%" AllowPaging="True" 
            DataKeyNames="Q_ID,Coll_ID" PageSize="15">
            <FooterStyle BackColor="Tan" />
            <Columns>
                <asp:BoundField DataField="Q_ID" HeaderText="Q_ID" ReadOnly="True" 
                    SortExpression="Q_ID" />
                <asp:BoundField DataField="Coll_ID" HeaderText="Coll_ID" ReadOnly="True" 
                    SortExpression="Coll_ID" />
                <asp:BoundField DataField="Detail1" HeaderText="Detail1" ReadOnly="True" 
                    SortExpression="Detail1" />
                <asp:BoundField DataField="PROV_NAME" HeaderText="PROV_NAME" 
                    SortExpression="PROV_NAME" />
                <asp:BoundField DataField="Detail2" HeaderText="Detail2" ReadOnly="True" 
                    SortExpression="Detail2" />
            </Columns>
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
        </asp:GridView>
        <asp:SqlDataSource ID="SDSTemp_AID" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
            
            
            SelectCommand="SELECT D.Q_ID, D.Coll_ID, ISNULL(CD.Detail1, '-') AS Detail1, CD.PROV_NAME, ISNULL(CD.Detail2, '-') AS Detail2, CD.RAI, CD.NGAN, CD.WAH FROM Sent_Appraisal_Detail AS D INNER JOIN Bay01.dbo.COLL_ID_DISTINCT AS CD ON D.Coll_ID = CD.COLL_ID AND D.Cif = CD.CIF WHERE (D.PreAID = @Temp_Aid) AND (D.Q_ID = @Q_ID)">
            <SelectParameters>
                <asp:QueryStringParameter Name="TEMP_AID" QueryStringField="Temp_Aid" />
                <asp:QueryStringParameter Name="Q_ID" QueryStringField="Q_ID" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    <div>
    
    </div>
    </form>
</body>
</html>
