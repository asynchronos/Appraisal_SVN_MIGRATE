﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Index.aspx.vb" Inherits="Index" %>

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
    </style>
</head>
<body style="margin-top:0px; margin-left:0px; margin-right:0px;">
    <form id="form1" runat="server">
    <div>
        <table border="0" cellspacing="0" cellpadding="0" width="100%" style="height: 80px;">
        <tr>
	        <td align="left" style="background-color:#FFCE40" class="style1">
        	        <img alt="" src="Images/logo_bay.gif" 
                        style="" /><br />
            </td>
	        <td style="height: 50px; background-color:#FFCE40;" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" >
            
                <table class="style1">
                    <tr>
                        <td class="style2">
                        <table style="background-color:#ffc00e;">
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
                                    <DIV align="center">ถ้าไม่มีรหัสผ่านให้ทำการ
										<a id="HyperLink1" href="http://svraamcnet2/AMC/Change_Password.aspx">Sign Up</a>
									</DIV                                
                                </td>
                            </tr>
                        </table>
                        </td>
                        <td valign="top">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        </table>
    </div>
    </form>
</body>
</html>
