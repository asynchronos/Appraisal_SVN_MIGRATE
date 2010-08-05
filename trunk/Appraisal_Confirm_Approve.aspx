<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Appraisal_Confirm_Approve.aspx.vb"
    Inherits="Appraisal_Confirm_Approve" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <script src="Js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="Js/common.js" type="text/javascript"></script>

    <script src="Js/jquery.js" type="text/javascript"></script>

    <title>Register Approve</title>
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
    </style>

    <script type="text/javascript">
        var _PopupModal;
        function confirmPrice() {

            var reqid = getValueFromQueryString("Req_Id");
            //alert(reqid);
            var hubid = getValueFromQueryString("Hub_Id");
            //alert(hubid);
            var ApproveId = getValueFromQueryString("ApproveId");
            //alert(ApproveId);
            var pwd = getEleByProperty("input", "myId", "TextBoxPassword").value;
            //alert(pwd);
            PageMethods.ConfirmPrice(reqid, hubid, ApproveId,pwd, this.callbackConfirm);
        }
        function callbackConfirm(result) {
            //  let the user know if their credit card was validated
            _PopupModal = getValueFromQueryString("PopupModal");
            if (result) {
                alert('Confirm data compleate!');
                window.parent.$find(_PopupModal).hide();
                window.parent.location.replace(window.parent.location);
            }
            else {
                alert('Warning, รหัสการยืนยันการอนุมัติราคาไม่ถูกต้อง!');
            }
        }
        function returnWindow() {
            _PopupModal = getValueFromQueryString("PopupModal");
            window.parent.$find(_PopupModal).hide();
            window.parent.location.replace(window.parent.location);
        }
        function openRegisterPage() {

        }
        function changeIframeSrcById(id, url, param) {
            var urlFull = "";
            var iframe = document.getElementById(id);
            if (param) {
                urlFull = url + "?" + param;
            } else {
                urlFull = url;
            }
            iframe.src = encodeURI(urlFull);
        }

        function concatParam(oldParam, addParamTag, addParamMyId, addParamKey) {
            var result = oldParam;
            var dom = null;

            if (addParamTag == "input") {
                dom = getEleByProperty(addParamTag, "myId", addParamMyId)
            } else if (addParamTag == "select") {

            }

            if (dom.value.length >= 1) {
                result = result + "&" + addParamKey + "=" + dom.value
            } else {

            }
            //alert(result);
            return result;
        }
        function changeRegisterIframeSrc() {

            var ApproveId = getValueFromQueryString("ApproveId");
            //alert(ApproveId);
            var myId = "IframeRegister";
            var url = "Appraisal_Create_Password_Approval.aspx";
            var param = "Approve_Id=" + ApproveId + "&PopupModal=mpeBehaviorRegister";
            //alert(param);
            changeIframeSrcById(myId
                , url
                , param
            );
        }             
    </script>

</head>
<body class="body">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <br />
    <br />
    <div>
        <table class="TableWidth">
            <tr>
                <td colspan="2" align="center">
                    โปรดกรอกรหัสผ่านเพื่อยืนยันการกำหนดราคา
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" 
                        Style="text-align: center;" myId="TextBoxPassword"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <input id="ButtonConfirm" type="button" value="Confirm" style="width: 100px" onclick="confirmPrice(); return false;" />
                    <input id="ButtonCancel" type="button" value="Cancel" style="width: 100px" onclick="returnWindow(); return false;" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Label ID="LabelMessage" runat="server" Text="หากยังไม่มีรหัสผ่านกรุณากด"></asp:Label>
                    <asp:LinkButton ID="LinkButtonRegister" runat="server" Style="font-weight: 700" OnClientClick="changeRegisterIframeSrc(); return false;">Register</asp:LinkButton>
                    </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
        <cc1:ModalPopupExtender ID="ModalPopupExtenderRegister" runat="server" TargetControlID="LinkButtonRegister"
            PopupControlID="panelRegister" BackgroundCssClass="modalBackground1" 
            BehaviorID="mpeBehaviorRegister">
        </cc1:ModalPopupExtender>
        <cc1:RoundedCornersExtender ID="RoundedCornersExtenderRegister" runat="server" TargetControlID="pnlInnerPopupRegister"
            BorderColor="black" Radius="4">
        </cc1:RoundedCornersExtender>
        <asp:Panel ID="panelRegister" runat="server" CssClass="outerPopup" Style="display: none;">
            <asp:Panel ID="pnlInnerPopupRegister" runat="server" Width="550px" CssClass="innerPopup">
                <iframe id="IframeRegister" src="" width="550" height="220" frameborder="0" scrolling="no">
                </iframe>
            </asp:Panel>
<%--            <div style="white-space: nowrap; text-align: center;">
                <asp:Button ID="ButtonCloseRegister" runat="server" Text="Close" Width="65px" myId="ButtonCloseRegister" />
            </div>--%>
        </asp:Panel>    
    </form>
</body>
</html>
