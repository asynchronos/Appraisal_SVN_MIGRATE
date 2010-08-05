<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Appraisal_Create_Password_Approval.aspx.vb"
    Inherits="Appraisal_Create_Password_Approval" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <script src="Js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="Js/common.js" type="text/javascript"></script>

    <script src="Js/jquery.js" type="text/javascript"></script>

    <title></title>
    <style type="text/css">
        .body
        {
            margin-top: 0;
            background-image: url('images/shiny.gif');
            background-repeat: repeat;
        }
        .outerPopup
        {
            background-color: Gray;
            padding: 1em 16px;
            border-style: solid;
            border-color: Yellow;
            border-width: 1px;
        }
        .innerPopup
        {
            background-color: #fff;
        }
        .modalBackground1
        {
            background-color: #000;
            filter: alpha(opacity=80);
            opacity: 0.8;
        }
        .GrayedOut
        {
            background-color: Transparent;
            filter: alpha(opacity=95);
            -moz-opacity: 0.5;
            -khtml-opacity: 0.5;
            opacity: 0.5;
        }
        .modalBox
        {
            background-color: #f5f5f5;
            border-width: 3px;
            border-style: solid;
            border-color: Blue;
            padding: 3px;
        }
        .headDetail
        {
            font-weight: bold;
            color: Blue;
            background-color: Yellow;
        }
        .expleanColour
        {
            background-color: Silver;
            width: 300px;
        }
        .fColor
        {
            color: red;
        }
        .TableWidth
        {
            width: 100%;
        }
        .bgcolour
        {
            background-color: Gray;
        }
        .style1
        {
            font-weight: bold;
            text-decoration: underline;
            color: #CC3300;
        }
        .style2
        {
            color: #CC3300;
        }
    </style>

    <script type="text/javascript">
        var _PopupModal;
        function Encryption() {
            var empid = getEleByProperty("input", "myId", "TextBoxId")
            var oldpass = getEleByProperty("input", "myId", "TextBoxOld_Password")
            var newpass = getEleByProperty("input", "myId", "TextBoxNew_Password")
            var confirm_newpass = getEleByProperty("input", "myId", "TextBoxConfirm_Password")
            //ต้อง Check รหัสผ่านว่าเคยตั้งไว้หรือไม่
            //ถ้า Check แล้วไม่เคยตั้ง ให้ Default เป็นรหัสพนักงานโดยการแจ้งเตือน
            //ถ้า Check แล้วเคยตั้งแล้ว ให้ใส่รหัสผ่านเก่า เพื่อแก้รหัสผ่านในการ Approve ใหม่
            //Check รหัสผ่านใหม่ กับ การยืนยันรหัสผ่านว่าตรงกันหรือไม่
            PageMethods.ConfirmPrice(empid, oldpass, this.callbackConfirm);
        }
        function callbackConfirm(result) {
            //  let the user know if their credit card was validated
            if (result == 0) {
                alert('Error!!');
                //window.location.replace(window.location);
            } else if (result == 1) {
                alert('คุณยังไม่เคยตั้งรหัสผ่าน โปรดกรอกรหัสพนักงานในช่อง Old Password!!');
            } else if (result == 2) {
                alert('รหัสผ่านเก่าของคุณไม่ถูกต้อง!!');
            } else if (result == 3) {
                if (newpass == confirm_newpass) {
                    PageMethods.SavePassword(empid, newpass, this.callback);
                } else {
                    alert('คุณกรอกช่องรหัสผ่านใหม่ กับ ช่องยืนยันรหัสผ่านไม่เหมือนกัน !!');
                }
            }
        }
        function callback(result) {
            _PopupModal = getValueFromQueryString("PopupModal");
            if (result) {
                alert('Save Password compleate!');
                window.parent.$find(_PopupModal).hide();
                window.parent.location.replace(window.parent.location);
            }
            else {
                alert('Warning, Save Password not compleate!');
            }
        }
        function returnWindow() {
            _PopupModal = getValueFromQueryString("PopupModal");
            window.parent.$find(_PopupModal).hide();
            window.parent.location.replace(window.parent.location);
        }
        function stepChangPassword() {
            var empid = getEleByProperty("input", "myId", "TextBoxId").value;
            //alert(empid);
            var oldpass = getEleByProperty("input", "myId", "TextBoxOld_Password").value;
            var newpass = getEleByProperty("input", "myId", "TextBoxNew_Password").value;
            var confirmpass = getEleByProperty("input", "myId", "TextBoxConfirm_Password").value;
            //alert(oldpass);
            //PageMethods.Test2(empid, oldpass, this.testCallback);
            //PageMethods.EncriptAllPassword(this.testCallback);
            PageMethods.stepChangPassword(empid, oldpass, newpass, confirmpass, this.testCallback); 
        }
        function testCallback(result) {
            //alert(result);
            //var texthash = getEleByProperty("input", "myId", "TextBoxTestHash")
            //texthash.value = result;
            if (result == 0) {
                alert('Change Password compleated');
                _PopupModal = getValueFromQueryString("PopupModal");
                window.parent.$find(_PopupModal).hide();
                window.parent.location.replace(window.parent.location);
            } else if (result == 1) {
                alert('รหัสผ่านเก่าของคุณไม่ถูกต้อง!!');
            } else if (result == 2) {
                alert('รหัสผ่านเก่าของคุณไม่ควรเป็นรหัสเดียวกันกับพนักงาน!!');
            } else if (result == 3) {
                alert('คุณกรอกช่องรหัสผ่านใหม่ กับ ช่องยืนยันรหัสผ่านไม่เหมือนกัน !!');
            } else if (result == 4) {
                alert('Warning, Save Password not compleate!');
            }           
        }        
    </script>

</head>
<body class="body">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <div>
        <table>
            <tr>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    ID
                </td>
                <td>
                    <asp:TextBox ID="TextBoxId" runat="server" myId="TextBoxId" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Name
                </td>
                <td>
                    <asp:TextBox ID="TextBoxName" runat="server" Width="250px" myId="TextBoxName" onfocus="this.blur();"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Old Password
                </td>
                <td>
                    <asp:TextBox ID="TextBoxOld_Password" runat="server" myId="TextBoxOld_Password" 
                        TextMode="Password" MaxLength="12"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    New Password
                </td>
                <td>
                    <asp:TextBox ID="TextBoxNew_Password" runat="server" myId="TextBoxNew_Password" TextMode="Password" MaxLength="12"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Confirm Password
                </td>
                <td>
                    <asp:TextBox ID="TextBoxConfirm_Password" runat="server" myId="TextBoxConfirm_Password" TextMode="Password" MaxLength="12"></asp:TextBox>
                </td>
            </tr>
            <tr align="center">
                <td colspan="2">
                    <input id="Button1" style="width: 100px" type="button" value="Save" onclick="stepChangPassword(); return false;" />
                    <input id="Button2" style="width: 100px" type="button" value="Cancel" onclick="returnWindow(); return false;"/>
                    <asp:Button ID="ButtonResetPwd" runat="server" Text="Reset Password" />
                </td>
            </tr>
            <tr align="center">
                <td colspan="2">
                    <span class="style1">คำแนะนำ</span><span class="style2"> หากกำหนดรหัสผ่านครั้งแรกให้กำหนดรหัสผ่านเก่าเป็นรหัสพนักงาน</span>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="TextBoxTestHash" runat="server" Width="250px" myId="TextBoxTestHash" style="display:none;"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
