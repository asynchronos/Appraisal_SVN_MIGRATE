<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CifControl.ascx.vb" Inherits="CifControl" %>
<style type="text/css">


        .style1
        {
            width: 100%;
        }
        .style4
        {
            font-weight: bold;
            width: 212px;
            background-color: #eeeedd;
        }
        .style5
        {
            width: 313px;
            background-color:Aqua;
        }
        .style6
        {
            font-weight: bold;
            width: 179px;
            background-color: #eeeedd;
        }
        </style>
<table class="style1">
    <tr>
        <td class="style4">
            ชื่อบริษัท/ลูกหนี้ที่ส่งประเมิน
        </td>
        <td class="style5">
            <asp:TextBox ID="TxtCif" runat="server"></asp:TextBox>
            <asp:Button ID="TxtSearch" runat="server" Text="Search" />
        </td>
        <td class="style6">
            &nbsp;</td>
        <td class="style5">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style4">
            เลขทะเบียนนิติบุคคล</td>
        <td class="style5">
            <asp:Label ID="lblId" runat="server" Width="173px"></asp:Label>
        </td>
        <td class="style6">
            ชั้นหนี้</td>
        <td class="style5">
            <asp:Label ID="lblClass" runat="server" Width="173px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style4">
            ประเภทธุรกิจ</td>
        <td class="style5">
            <asp:Label ID="lblBisi_Type" runat="server" Width="311px"></asp:Label>
        </td>
        <td class="style6">
            ฝ่ายงานเจ้าของบัญชี</td>
        <td class="style5">
            <asp:Label ID="lblDept_Acc" runat="server" Width="396px"></asp:Label>
        </td>
    </tr>
</table>
