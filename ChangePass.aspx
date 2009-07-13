<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ChangePass.aspx.vb" Inherits="ChangePass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 213px;
        }
    </style>
    <script type="text/javascript">
        function confirmation() {
            if (confirm("ยืนยันรหัสผ่านเรียบร้อย ระบบจะกลับสู่หน้า Login") == true) {
                return true;
            }
            else {
                return false;
            }
        }               
     </script>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
<br />

    <table class="style1">
        <tr>
            <td class="style2">
                รหัสผู้ใช้</td>
            <td>
                <asp:Label ID="lblEmp_Id" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                ชื่อ-สกุลพนักงาน</td>
            <td>
                <asp:Label ID="lblEmp_Name" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                รหัสผ่านใหม่</td>
            <td>
                <asp:TextBox ID="txtNewPassword" runat="server" MaxLength="10" 
                    TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                ยืนยันรหัสผ่าน</td>
            <td>
                <asp:TextBox ID="txtConfirmNewPassword" runat="server" MaxLength="10" 
                    TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnConfirm" runat="server" Text="Confirm" OnClientClick="return confirmation()" />
            </td>
        </tr>
    </table>

</asp:Content>

