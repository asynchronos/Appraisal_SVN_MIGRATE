<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Appraisal_Price3_Add_Colltype70Detail.aspx.vb" Inherits="Appraisal_Price3_Add_Colltype70Detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>รายละเอียดโครงสร้างหลักของอาคาร</title>
    <style type="text/css">
        .style1
        {
            color: #6600FF;
            font-weight: bold;
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    โครงสร้างหลักอาคารเป็น</td>
                <td colspan="3">
                    <asp:TextBox ID="txtBuilding_Struc" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>  
            <tr>
                <td>
                    ชั้น</td>
                <td>
                    <asp:TextBox ID="txtBuildFloor" runat="server" Width="60px"></asp:TextBox>
                </td>
                <td>
                    พื้น</td>
                <td>
                    <asp:CheckBox ID="chkConcrete" runat="server" Text="คอนกรีต" />
                    <asp:CheckBox ID="chkGranite" runat="server" Text="หินแกรนิต" />
                    <asp:CheckBox ID="chkParquet" runat="server" Text="ลามิเนต/ปาร์เก้" />
                    <asp:CheckBox ID="chkCeramic" runat="server" Text="เซรามิค" />
                    <asp:CheckBox ID="chkWood" runat="server" Text="ไม้" />
                    <asp:CheckBox ID="CheckBox5" runat="server" Text="อื่น ๆ" />
                    &nbsp;
                    </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;รายละเอียดอื่นๆ <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
            </tr>               
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td class="style1">
                    ผนัง</td>
                <td>
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="ก่ออิฐฉาบปูน" />
                    <asp:CheckBox ID="CheckBox2" runat="server" Text="ก่ออิฐบล็อค" />
                    <asp:CheckBox ID="CheckBox3" runat="server" Text="ไม้" />
                    <asp:CheckBox ID="CheckBox4" runat="server" Text="อื่น ๆ" />
                    &nbsp;</td>
            </tr> 
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    รายละเอียดอื่นๆ <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>              
        </table>
    </div>
    <p>
        &nbsp;</p>
    </form>
</body>
</html>
