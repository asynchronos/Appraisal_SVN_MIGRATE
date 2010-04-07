<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Index.aspx.vb" Inherits="Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            height:100%  
                      
        }
        .style2
        {
            width: 170px;
        }
        .height_table
        {

        }
        .style4
        {
            color: #6600FF;
            font-weight: bold;
        }
        .style5
        {
            width: 100%;
        }
        .style6
        {
            color: #3333CC;
            text-decoration: underline;
            font-weight: bold;
            text-align: left;
        }
    </style>
</head>
<body style="margin-top:0px; margin-left:0px; margin-right:0px;">
    <form id="form1" runat="server">
    <div>
        <table border="0" cellspacing="0" cellpadding="0" width="100%" style="height: 80px;">
        <tr>
	        <td align="left" style="background-color:#FFC20E" class="style1">
        	        <img alt="" src="Images/logo.jpg" 
                        style="" /><br />
            </td>
	        <td style="height: 50px; background-color:#FFC20E;" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" >
            
                <table class="style1">
                    <tr valign="top">
                        <td class="style2">
                        <table style="background-color:#ffc20e;">
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td class="style4">
                                                Username</td>
                                            <td>
                                                <asp:TextBox ID="Txtusername" runat="server" Width="100px" MaxLength="13"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style4">
                                                Password</td>
                                            <td >
                                                <asp:TextBox ID="txtPassword" runat="server" Width="100px" TextMode="Password" 
                                                    MaxLength="15"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <asp:ImageButton ID="ImageBtLogin" runat="server" 
                                        ImageUrl="~/Images/btn_login.gif" ToolTip="Login" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
<%--                                    <div align="center">ถ้าไม่มี User ให้ทำการ
										<a id="HyperLink1" href="http://svraamcnet2/AMC/Change_Password.aspx">R</a><a 
                                            href="http://svraamcnet2/AMC/Change_Password.aspx">egister</a>
									</div> --%>                              
                                </td>
                            </tr>
                        </table>
                        </td>
                        <td valign="top">
                            <table class="style5">
                                <tr>
                                    <td class="style6">
                                        &nbsp;ประกาศ</td>
                                </tr>
                                <tr>
                                    <td>
                                        <p>
                                            &nbsp;</p>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <ul>
                                            <li style="color: #CC3300">คู่มือการใช้งานอย่างละเอียดสามารถ Download ได้ที่ เมนู&nbsp; 
                                                Download เลือก เอกสารสำนักงานใหญ่ (ต้องทำการ Login ก่อน)<img alt="" 
                                                    src="Images/ani_new.gif" style="width: 30px; height: 15px" /></li>
                                        </ul>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <ul>
                                            <li style="color: #CC3300">อนุกรรมการคนที่ 2 และ คนที่ 3 
                                                ที่เซ็นต์ในการตรวจสอบราคาที่ 3 ไม่เกิน 10 ล้านบาท ไม่ต้องยืนยันการตรวจสอบแล้ว <img alt="" 
                                                    src="Images/ani_new.gif" style="width: 30px; height: 15px" /></li>
                                        </ul>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <ul>
                                            <li style="color: #CC3300">การกำหนดราคาที่ 1 ได้ใช้แผนที่&nbsp; Google Map แล้ว <img alt="" 
                                                    src="Images/ani_new.gif" style="width: 30px; height: 15px" /></li>
                                        </ul>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <ul>
                                            <li style="color: #CC3300">วิธีทุน หากสิ่งปลูกสร้างได้สร้างเสร็จ ตั้งแต่ 50 % 
                                                ระบบได้ออกราคาให้ได้แล้ว <img alt="" 
                                                    src="Images/ani_new.gif" style="width: 30px; height: 15px" /></li>
                                        </ul>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        </table>
    </div>
    </form>
</body>
</html>
