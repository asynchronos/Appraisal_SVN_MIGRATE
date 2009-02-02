<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AID_CID_List.aspx.vb" Inherits="AID_CID_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 62%;
        }
        .style2
        {
            width: 169px;
            background-color: #B5C7DE;
        }
        .style3
        {
            width: 187px;
        }
        .style4
        {
            width: 129px;
            background-color: #B5C7DE;
        }
        .tb_bg
        {
            background-color: #B5C7DE;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" BackColor="LightGoldenrodYellow" 
            BorderColor="Tan" BorderWidth="1px" CellPadding="2" 
            DataKeyNames="CIF,APPRAISAL_ID,COLLATERAL_ID,COLLATERAL_KEY" 
            ForeColor="Black" GridLines="None">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <FooterStyle BackColor="Tan" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
        </asp:GridView>
        <asp:GridView ID="GridView_CID_DETAIL" runat="server">
        </asp:GridView>
        <br />
        <table class="style1" border="1">
            <tr>
                <td class="style2">
                    AID</td>
                <td class="style3">
                    <asp:Label ID="lblAID" runat="server"></asp:Label>
                </td>
                <td class="style4">
                    CID</td>
                <td>
                    <asp:Label ID="lblCID" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    เลขประเภทหลักประกัน</td>
                <td class="style3">
                    <asp:Label ID="lblSubCollTypeNo" runat="server"></asp:Label>
                </td>
                <td class="style4">
                    ประเภทหลักประกัน</td>
                <td>
                    <asp:Label ID="lblSubCollType" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    เลขโฉนด</td>
                <td class="style3">
                    <asp:Label ID="lblChanode" runat="server"></asp:Label>
                </td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    ถนน</td>
                <td class="style3">
                    <asp:Label ID="lblRoad" runat="server"></asp:Label>
                </td>
                <td class="style4">
                    ตำบล</td>
                <td>
                    <asp:Label ID="lblDistrict" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    อำเภอ</td>
                <td class="style3">
                    <asp:Label ID="lblAmphur" runat="server"></asp:Label>
                </td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    รหัสจังหวัด</td>
                <td class="style3">
                    <asp:Label ID="lblProvince_Code" runat="server"></asp:Label>
                </td>
                <td class="style4">
                    จังหวัด</td>
                <td>
                    <asp:Label ID="lblProvince" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    จำนวนไร่</td>
                <td class="style3">
                    <asp:Label ID="lblRai" runat="server"></asp:Label>
                </td>
                <td class="style4">
                    จำนวนงาน</td>
                <td>
                    <asp:Label ID="lblNgan" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    จำนวนวา</td>
                <td class="style3">
                    <asp:Label ID="lblWah" runat="server"></asp:Label>
                </td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <asp:HiddenField ID="hdfCif" runat="server" />
    
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EDW_Connectionstring %>"
        SelectCommand="SELECT * FROM [DWHADMIN.COLLATERAL_MASTER] WHERE ([DWHADMIN.COLLATERAL_MASTER.COLLATERAL_KEY] = @CID_KEY)">
        <SelectParameters>
            <asp:ControlParameter Name ="CID_KEY" ControlID ="Gridview1" PropertyName="SelectedValue" />
        </SelectParameters>
        </asp:SqlDataSource>
    
        <asp:Button ID="Button1" runat="server" Text="เลือก" />
    
    </div>
    </form>
</body>
</html>
