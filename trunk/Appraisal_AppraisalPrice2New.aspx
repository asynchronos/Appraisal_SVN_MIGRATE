<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_AppraisalPrice2New.aspx.vb" Inherits="Appraisal_AppraisalPrice2New" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 238px;
            background-color:Aqua;
        }
        .style3
        {
            background-color:Yellow;
        }
        .style4
        {
            background-color: Aqua;
            height: 57px;
        }
        .style5
        {
            background-color: Aqua;
            height: 34px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
<br />
    <asp:Label ID="lblPage" runat="server" 
        style="font-weight: 700; color: #3333CC" Text="ตรวจสอบราคาหลักประกัน"></asp:Label>
    <div>
    
        <table class="style1" border="1">
            <tr>
                <td class="style2">
                    เลขที่คำขอประเมิน</td>
                <td class="style3">
                    <asp:Label ID="lblReq_Id" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    รหัสศูนย์ประเมิน</td>
                <td class="style3">
                    <asp:Label ID="lblHub_Id" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    ชื่อศูนย์ประเมิน</td>
                <td class="style3">
                    <asp:Label ID="lblHub_Name" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Cif</td>
                <td class="style3">
                    <asp:Label ID="lblCif" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Cif Name</td>
                <td class="style3">
                    <asp:Label ID="lblCifName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    ผู้ขอให้ประเมิน</td>
                <td class="style3">
                    <asp:Label ID="lblSender_Name" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    ผู้ประเมิน</td>
                <td class="style3">
                    <asp:Label ID="lblAppraisal_Name" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    ราคาที่1</td>
                <td class="style3">
                    <asp:Label ID="lblPrice1" runat="server"></asp:Label>
                &nbsp;บาท</td>
            </tr>
            <tr>
                <td class="style2">
                    ราคาที่2</td>
                <td class="style3">
                    <asp:Label ID="lblPrice2" runat="server"></asp:Label>
                &nbsp;บาท</td>
            </tr>
            <tr>
                <td class="style2" valign="top">
                    Comment</td>
                <td class="style3">
                    <asp:TextBox ID="txtComment" runat="server" Height="22px" TextMode="MultiLine" 
                        Width="800px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    ความเห็นการกำหนดราคา</td>
                <td class="style3">
                    <asp:RadioButtonList ID="rdbAccept" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="8">เห็นชอบ</asp:ListItem>
                        <asp:ListItem Value="7">ไม่เห็นชอบ</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="style4" valign="top">
                    หมายเหตุ</td>
                <td class="style3">
                    <asp:TextBox ID="txtNote" runat="server" Height="65px" TextMode="MultiLine" 
                        Width="799px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style5" valign="top" align="center" colspan="2">
                               <table>
                                   <tr>
                                       <td>
                               <asp:ImageButton ID="ImageOk" runat="server" 
                        ImageUrl="~/Images/books_preferences.png" Height="40px" Width="40px" ToolTip="ยืนยัน" />
                                       </td>
                                       <td>
                               <asp:ImageButton ID="ImgLocation" runat="server" 
                        ImageUrl="~/Images/viewmap.jpg" Height="40px" Width="40px" ToolTip="แผนที่" />
                                       </td>
                                       <td>
                               <asp:ImageButton ID="ImgImformation" runat="server" 
                        ImageUrl="~/Images/info.ico" Height="40px" Width="40px" ToolTip="รายละเอียด" />
                                       </td>
                                       <td>
                                           &nbsp;</td>
                                       <td>
                               <asp:ImageButton ID="ImageCancel" runat="server" 
                        ImageUrl="~/Images/cancel1.jpg" Height="40px" Width="40px" ToolTip="ออก" />
                                       </td>
                                   </tr>
                               </table>
                </td>
            </tr>
            </table>
    
    </div>
</asp:Content>

