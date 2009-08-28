<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Download_Head_Office.aspx.vb" Inherits="Download_Head_Office" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 393px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
<br />

    <table class="style1">
        <tr>
            <td class="style2">
                คู่มือการทำงานของ Admin ประเมิน</td>
            <td>
               <asp:ImageButton ID="ImageMannual1" runat="server" ImageUrl="~/Images/pdf.ico" Width="20px" Height="20px" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                คู่มือการทำงานของเจ้าหน้าที่ประเมิน</td>
            <td>
                                    <asp:ImageButton ID="ImageMannual2" runat="server" ImageUrl="~/Images/pdf.ico" 
                                        Width="20px" Height="20px" />
                                </td>
        </tr>
        <tr>
            <td class="style2">
                คู่มือการทำงานของหัวหน้าศูนย์ หรือ หัวหน้า Hub ประเมิน</td>
            <td>
                                    <asp:ImageButton ID="ImageMannual3" runat="server" ImageUrl="~/Images/pdf.ico" 
                                        Width="20px" Height="20px" />
                                </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>

</asp:Content>

