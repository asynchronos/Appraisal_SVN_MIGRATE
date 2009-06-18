<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Appraisal_AppraisalPrice2.aspx.vb" Inherits="Appraisal_AppraisalPrice2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 238px;
        }
        .style3
        {
            width: 500px;
        }
    </style>
</head>
<body onunload="opener.location=('Appraisal_Assign_Job.aspx')">
    <form id="form1" runat="server">
    <asp:Label ID="lblPage" runat="server" 
        style="font-weight: 700; color: #3333CC" Text="ตรวจสอบราคาหลักประกัน"></asp:Label>
    <div>
    
        <table class="style1">
            <tr>
                <td class="style2">
                    เลขที่คำขอประเมิน</td>
                <td class="style3">
                    <asp:Label ID="lblReq_Id" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    รหัสศูนย์ประเมิน</td>
                <td class="style3">
                    <asp:Label ID="lblHub_Id" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    ชื่อศูนย์ประเมิน</td>
                <td class="style3">
                    <asp:Label ID="lblHub_Name" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    Cif</td>
                <td class="style3">
                    <asp:Label ID="lblCif" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    Cif Name</td>
                <td class="style3">
                    <asp:Label ID="lblCifName" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    ผู้ขอให้ประเมิน</td>
                <td class="style3">
                    <asp:DropDownList ID="ddlSender" runat="server" DataSourceID="sdsSender"
                        DataTextField="Emp_Name" DataValueField="EMP_ID" Enabled="False">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    ผู้ประเมิน</td>
                <td class="style3">
                    <asp:DropDownList ID="ddlUserAppraisal" runat="server" DataSourceID="SDSUserAppraisal"
                        DataTextField="UserAppraisal" DataValueField="Emp_id" Enabled="False" 
                        ToolTip="ยืนยันการกำหนดราคาที่ 2">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    ราคาที่1</td>
                <td class="style3">
                    <asp:Label ID="lblPrice1" runat="server"></asp:Label>
                &nbsp;บาท</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    ราคาที่2</td>
                <td class="style3">
                    <asp:Label ID="lblPrice2" runat="server"></asp:Label>
                &nbsp;บาท</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2" >
                    Comment</td>
                <td class="style3">
                    <asp:TextBox ID="txtComment" runat="server" Height="94px" TextMode="MultiLine" 
                        Width="497px" ReadOnly="True"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
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
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3" style="text-align:Center;">
                               <table class="style1">
                                   <tr>
                                       <td align="right">
                               <asp:ImageButton ID="ImageOk" runat="server" 
                        ImageUrl="~/Images/books_preferences.png" Height="40px" Width="40px" ToolTip="ยืนยัน" />
                                       </td>
                                       <td align="left">
                               <asp:ImageButton ID="ImageCancel" runat="server" 
                        ImageUrl="~/Images/cancel1.jpg" Height="40px" Width="40px" ToolTip="ยกเลิก" />
                                       </td>
                                   </tr>
                               </table>
                                </td>
            </tr>
        </table>
    
    </div>
    <asp:SqlDataSource ID="SDSUserAppraisal" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT Emp_id, Title + Name + '  ' + Lastname AS UserAppraisal FROM Tb_UserAppraisal">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsSender" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        
        SelectCommand="SELECT [EMP_ID], [Emp_Name] FROM [View_Employee_Info]">
    </asp:SqlDataSource>
    </form>
</body>
</html>
