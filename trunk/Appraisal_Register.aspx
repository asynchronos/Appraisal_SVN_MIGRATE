<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Appraisal_Register.aspx.vb" Inherits="Appraisal_Register" %>

<%@ Register assembly="Mytextbox" namespace="Mytextbox" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 44%;
        }
        .style2
        {
            color: #3333CC;
            font-weight: bold;
        }
        .style3
        {
            width: 284px;
        }
        .style4
        {
            width: 168px;
        }
    </style>
</head>
<body style="margin-top:0px; margin-left:0px; margin-right:0px;">
    <form id="form1" runat="server">
    <div>
        <table border="0" cellspacing="0" cellpadding="0" width="100%" style="height: 80px;">
            <tr>
	            <td align="left" style="background-color:#FFCE40">
        	            <img alt="" src="Images/logo_bay.gif" 
                            style="" /><br />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" bgcolor="Silver" class="style2" >

                    REGISTER</td>
            </tr>
            <tr>
                <td>
                    <table class="style1">
                        <tr>
                            <td class="style4">
                                <asp:Label ID="Label3" runat="server" Text="รหัสพนักงาน"></asp:Label>
                            </td>
                            <td class="style3">
                                <cc1:mytext ID="txtEmp_Id" runat="server"></cc1:mytext>
                            </td>
                            <td>
                                <asp:Button ID="btnSearch" runat="server" Text="ค้นหา" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                <asp:Label ID="Label4" runat="server" Text="ชื่อ-สกุล พนักงาน"></asp:Label>
                            </td>
                            <td class="style3">
                                <asp:Label ID="lblEmpName" runat="server"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style4">
                                <asp:Label ID="Label5" runat="server" Text="กลุ่มหรือ Hub ที่สังกัด"></asp:Label>
                            </td>
                            <td class="style3">
                                <asp:DropDownList ID="ddlHub" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style4">
                                &nbsp;</td>
                            <td class="style3">
                                &nbsp;</td>
                            <td>
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
