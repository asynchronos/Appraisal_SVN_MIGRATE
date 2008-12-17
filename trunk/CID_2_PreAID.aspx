<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CID_2_PreAID.aspx.vb" Inherits="CID_2_PreAID" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>จัดกลุ่ม Coll ID</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
        }
        .style3
        {
            width: 211px;
        }
    </style>
</head>
<body style="margin-top:0px; margin-left:0px; margin-right:0px; background-image:url(Images/imagesCAMBBQTW.jpg);">
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td class="style2" colspan="2">
                    <asp:Label ID="lblMessage" runat="server" Font-Bold="True" 
                        style="color: #FF0000" Text="กำหนดกลุ่มประเมินโดย"></asp:Label>
&nbsp;<asp:CheckBox ID="CheckBox1" runat="server" Checked="True" Enabled="False" />
&nbsp;<asp:Label ID="Label1" runat="server" style="font-weight: 700; color: #FF0000" 
                        Text="เพื่อเลือก Coll ID ของตารางด้านล่าง"></asp:Label>
                </td>
            </tr>
            </table>
            <table>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label2" runat="server" Text="กำหนดชื่อผู้ประเมิน" 
                        style="color: #6600FF; font-weight: 700"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" style="margin-left: 0px">
                    </asp:DropDownList>
                </td>
            </tr> 
            <tr>
                <td class="style3">
                    <asp:Label ID="Label3" runat="server" Text="เลข TEMP AID" 
                        style="color: #6600FF; font-weight: 700"></asp:Label>
                </td>
                <td bgcolor="#33CCCC">
                    <asp:Label ID="lblTempAID" runat="server" 
                        style="color: #FF0000; font-weight: 700"></asp:Label>
                </td>
            </tr>  
            <tr>
                <td class="style3">
                    <asp:Label ID="Label4" runat="server" Text="ชื่อศูนย์" 
                        style="color: #6600FF; font-weight: 700"></asp:Label>
                </td>
                <td bgcolor="#33CCCC">
                    <asp:Label ID="Label5" runat="server" 
                        style="color: #FF0000; font-weight: 700"></asp:Label>
                </td>
            </tr>                                     
            <tr>
                <td class="style3">
                    <asp:Button ID="btnSaveGroup" runat="server" Text="บันทึกกลุ่มประเมิน" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="2" DataSourceID="SqlDataSource1" 
            ForeColor="Black" GridLines="None" BackColor="LightGoldenrodYellow" 
            BorderColor="Tan" BorderWidth="1px" Width="100%">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" 
                    SortExpression="ID" />
                <asp:BoundField DataField="Req_Id" HeaderText="Req_Id" ReadOnly="True" 
                    SortExpression="Req_Id" />
                <asp:BoundField DataField="CIF" HeaderText="CIF" SortExpression="CIF" />
                <asp:BoundField DataField="CIFNAME" HeaderText="CIFNAME" ReadOnly="True" 
                    SortExpression="CIFNAME" />
                <asp:BoundField DataField="Hub_Id" HeaderText="Hub_Id" ReadOnly="True" 
                    SortExpression="Hub_Id" />
                <asp:BoundField DataField="HUB_NAME" HeaderText="HUB_NAME" 
                    SortExpression="HUB_NAME" />
                <asp:BoundField DataField="Temp_AID" HeaderText="Temp_AID" ReadOnly="True" 
                    SortExpression="Temp_AID" />
                <asp:BoundField DataField="COLLTYPE_ID" HeaderText="COLLTYPE_ID" 
                    SortExpression="COLLTYPE_ID" />
                <asp:BoundField DataField="MysubColl_ID" HeaderText="MysubColl_ID" 
                    ReadOnly="True" SortExpression="MysubColl_ID" />
                <asp:BoundField DataField="SUBCOLLTYPE_NAME" HeaderText="SUBCOLLTYPE_NAME" 
                    SortExpression="SUBCOLLTYPE_NAME" />
                <asp:BoundField DataField="Address_No" HeaderText="Address_No" ReadOnly="True" 
                    SortExpression="Address_No" />
                <asp:BoundField DataField="Tumbon" HeaderText="Tumbon" ReadOnly="True" 
                    SortExpression="Tumbon" />
                <asp:BoundField DataField="Amphur" HeaderText="Amphur" ReadOnly="True" 
                    SortExpression="Amphur" />
                <asp:BoundField DataField="Province" HeaderText="Province" ReadOnly="True" 
                    SortExpression="Province" />
                <asp:BoundField DataField="Prov_Name" HeaderText="Prov_Name" 
                    SortExpression="Prov_Name" />
            </Columns>
            <FooterStyle BackColor="Tan" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
            SelectCommand="GET_PRICE2_LISTGROUP" SelectCommandType="StoredProcedure">
        </asp:SqlDataSource>
    
    <asp:SqlDataSource ID="SDSUserAppraisal" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="GET_PRICE2_LISTGROUP" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
    
        <asp:Button ID="Button1" runat="server" Text="Button" />
    
    </div>
    </form>
</body>
</html>
