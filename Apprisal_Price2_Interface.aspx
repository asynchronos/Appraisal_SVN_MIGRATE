<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Apprisal_Price2_Interface.aspx.vb" Inherits="Apprisal_Price2_Interface" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src="Js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="Js/common.js" type="text/javascript"></script>

    <style type="text/css">
        .TableWidth
        {
            width: 100%;
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
        .expleanColour1
        {
            background-color: red;
        }
        .GrayedOut
        {
            background-color: Gray;
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
            padding: 1px;
        }
        .modalBackground
        {
            background-color: #CCCCFF;
            filter: alpha(opacity=40);
            opacity: 0.5;
        }
        .ModalWindow
        {
            border: solid1px#c0c0c0;
            background: #f0f0f0;
            padding: 0px10px10px10px;
            position: absolute;
            top: -1000px;
        }
        .outerPopup
        {
            background-color: Gray;
            padding: 0px5px5px5px;
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
            filter: alpha(opacity=70);
            opacity: 0.7;
        }
        .updateProgressMessage
        {
            margin:3px; 
            font-family:Trebuchet MS; 
            font-size:small; 
            vertical-align: middle;
        }  
        .updateProgress
        {
            border-width:1px; 
            border-style:solid; 
            background-color:#FFFFFF; 
            position:absolute; 
            width:350px; 
            height:50px;    
        }               
    </style>

    <script type="text/javascript">
        var _popup;
        function changeIframeSrc(myid, url, param) {
            var iframe = $("iframe[myid=" + myid + "]");
            changeIframeSrcById(iframe[0].id, url, param);
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
                //alert('โปรดตรวจสอบว่ามีรายละเอียดจังหวัด รายละเอียดอำเภอ แล้วหรือไม่');


            }
            //alert(result);
            return result;
        }


        function changeLandIframeSrc() {

            if (document.getElementsByName("ctl00$ContentPlaceHolder1$rdbAppraisal_Type")[0].checked == true) {
                //alert('กำหนดราคาวิธีทุน ');
                var myId = "IframeLand";
                var url = "Appraisal_Land_List.aspx"
                var param = "LandPrice=TextBoxLand&BuildingPrice=TextBoxBuilding&CondoPrice=TextBoxCondo&GrandTotal=TextBoxGrandTotal&Appraisal_Type=2&PopupModal=mpeBehaviorLand";

                param = param + concatParam('', 'input', 'TextBoxReq_Id', 'Req_Id');
                param = param + concatParam('', 'input', 'TextBoxHub_Id', 'Hub_Id');
                param = param + concatParam('', 'input', 'TextBoxCif', 'Cif');
                param = param + concatParam('', 'input', 'TextBoxTemp_AID', 'Temp_AID');
                param = param + concatParam('', 'input', 'TextBoxCifName', 'CifName');
                param = param + concatParam('', 'input', 'TextBoxAppraisal_Id', 'Appraisal_Id');
                changeIframeSrcById(myId
                , url
                , param
            );
            }
            else if (document.getElementsByName("ctl00$ContentPlaceHolder1$rdbAppraisal_Type")[1].checked == true) {
                //alert('กำหนดราคาวิธีตลาด ');
                var myId = "IframeLand";
                var url = "Appraisal_Land_List.aspx"
                var param = "LandPrice=TextBoxLand&BuildingPrice=TextBoxBuilding&CondoPrice=TextBoxCondo&GrandTotal=TextBoxGrandTotal&Appraisal_Type=1&PopupModal=mpeBehaviorLand";

                param = param + concatParam('', 'input', 'TextBoxReq_Id', 'Req_Id');
                param = param + concatParam('', 'input', 'TextBoxHub_Id', 'Hub_Id');
                param = param + concatParam('', 'input', 'TextBoxCif', 'Cif');
                param = param + concatParam('', 'input', 'TextBoxTemp_AID', 'Temp_AID');
                param = param + concatParam('', 'input', 'TextBoxCifName', 'CifName');
                param = param + concatParam('', 'input', 'TextBoxAppraisal_Id', 'Appraisal_Id');
                param = param + concatParam('', 'input', 'TextBoxLand', 'LandPriceValue');
                param = param + concatParam('', 'input', 'TextBoxBuilding', 'BuildingPriceValue');
                changeIframeSrcById(myId
                , url
                , param
            );
            }
            else {
                alert('คุณไม่ได้เลือกวิธีการให้ราคา');
                window.location.reload();
            }
        }

        function changeBuildingIframeSrc() {
            if (document.getElementsByName("ctl00$ContentPlaceHolder1$rdbAppraisal_Type")[0].checked == true) {
                var myId = "IframeBuilding";
                var url = "Appraisal_Building_List.aspx"
                var param = "LandPrice=TextBoxLand&BuildingPrice=TextBoxBuilding&CondoPrice=TextBoxCondo&GrandTotal=TextBoxGrandTotal&Appraisal_Type=2&PopupModal=mpeBehaviorBuilding";

                param = param + concatParam('', 'input', 'TextBoxReq_Id', 'Req_Id');
                param = param + concatParam('', 'input', 'TextBoxHub_Id', 'Hub_Id');
                param = param + concatParam('', 'input', 'TextBoxCif', 'Cif');
                param = param + concatParam('', 'input', 'TextBoxTemp_AID', 'Temp_AID');
                param = param + concatParam('', 'input', 'TextBoxCifName', 'CifName');
                param = param + concatParam('', 'input', 'TextBoxAppraisal_Id', 'Appraisal_Id');
                param = param + concatParam('', 'input', 'TextBoxLand', 'LandPriceValue');
                param = param + concatParam('', 'input', 'TextBoxBuilding', 'BuildingPriceValue');                
                changeIframeSrcById(myId
                , url
                , param
            );
            }
            else if (document.getElementsByName("ctl00$ContentPlaceHolder1$rdbAppraisal_Type")[1].checked == true) {
                var myId = "IframeBuilding";
                var url = "Appraisal_Building_List.aspx"
                var param = "LandPrice=TextBoxLand&BuildingPrice=TextBoxBuilding&CondoPrice=TextBoxCondo&GrandTotal=TextBoxGrandTotal&Appraisal_Type=1&PopupModal=mpeBehaviorBuilding";

                param = param + concatParam('', 'input', 'TextBoxReq_Id', 'Req_Id');
                param = param + concatParam('', 'input', 'TextBoxHub_Id', 'Hub_Id');
                param = param + concatParam('', 'input', 'TextBoxCif', 'Cif');
                param = param + concatParam('', 'input', 'TextBoxTemp_AID', 'Temp_AID');
                param = param + concatParam('', 'input', 'TextBoxCifName', 'CifName');
                param = param + concatParam('', 'input', 'TextBoxAppraisal_Id', 'Appraisal_Id');
                changeIframeSrcById(myId
                , url
                , param
            );
            }
            else {
                alert('คุณไม่ได้เลือกวิธีการให้ราคา');
                window.location.reload();
            }
        }

        function changeCondoIframeSrc() {

            if (document.getElementsByName("ctl00$ContentPlaceHolder1$rdbAppraisal_Type")[0].checked == true) {
                //alert('กำหนดราคาวิธีทุน ');
                var myId = "IframeCondo";
                var url = "Appraisal_Condo_List.aspx"
                var param = "CondoPrice=TextBoxCondo&GrandTotal=TextBoxGrandTotal&Appraisal_Type=2&PopupModal=mpeBehaviorCondo";

                param = param + concatParam('', 'input', 'TextBoxReq_Id', 'Req_Id');
                param = param + concatParam('', 'input', 'TextBoxHub_Id', 'Hub_Id');
                param = param + concatParam('', 'input', 'TextBoxCif', 'Cif');
                param = param + concatParam('', 'input', 'TextBoxTemp_AID', 'Temp_AID');
                param = param + concatParam('', 'input', 'TextBoxCifName', 'CifName');
                param = param + concatParam('', 'input', 'TextBoxAppraisal_Id', 'Appraisal_Id');
                changeIframeSrcById(myId
                , url
                , param
            );
            }
            else if (document.getElementsByName("ctl00$ContentPlaceHolder1$rdbAppraisal_Type")[1].checked == true) {
                //alert('กำหนดราคาวิธีตลาด ');
            var myId = "IframeCondo";
            var url = "Appraisal_Condo_List.aspx"
            var param = "CondoPrice=TextBoxCondo&GrandTotal=TextBoxGrandTotal&Appraisal_Type=1&PopupModal=mpeBehaviorCondo";

                param = param + concatParam('', 'input', 'TextBoxReq_Id', 'Req_Id');
                param = param + concatParam('', 'input', 'TextBoxHub_Id', 'Hub_Id');
                param = param + concatParam('', 'input', 'TextBoxCif', 'Cif');
                param = param + concatParam('', 'input', 'TextBoxTemp_AID', 'Temp_AID');
                param = param + concatParam('', 'input', 'TextBoxCifName', 'CifName');
                param = param + concatParam('', 'input', 'TextBoxAppraisal_Id', 'Appraisal_Id');
                changeIframeSrcById(myId
                , url
                , param
            );
            }
            else {
                alert('คุณไม่ได้เลือกวิธีการให้ราคา');
                window.location.reload();
            }
        }
        
        function attachFile() {

            var _req_Id = getEleByProperty("input", "myId", "TextBoxReq_Id");
            var _hub_Id = getEleByProperty("input", "myId", "TextBoxHub_Id");
            var _Appraisal_Id = getEleByProperty("input", "myId", "TextBoxAppraisal_Id");
            var _temp_AID = getEleByProperty("input", "myId", "TextBoxTemp_AID");

            var myId = "IframeAttachment";
            var url = "FileUpload_Price2.aspx";
            var param = "Req_Id=" + _req_Id.value + "&Hub_Id=" + _hub_Id.value + "&User_Id=" + _Appraisal_Id.value + "&Temp_AID=" + _temp_AID.value + "&PopupModal=mpeBehaviorAttachment";

            changeIframeSrcById(myId
                , url
                , param
            );
        }


        
        function callback(result) {
            //  hide the popup
            this._popup.hide();
            var return_result = eval('(' + result + ')');
            if (return_result.isValid == 'True') {
                var _temp_AID = getEleByProperty("input", "myId", "TextBoxTemp_AID");
                //alert(return_result.Temp_AID);
                _temp_AID.value = return_result.Temp_AID;
                alert('Save data compleate!');
            }
            else {
                alert('Warning, Save not compleate!');
            }
        }

        function savePrice2_Maseter() {
            _popup = $find('mdlPopupBehavior');
            var _data = new Array();
            var _appraisal_type;
            if (document.getElementsByName("ctl00$ContentPlaceHolder1$rdbAppraisal_Type")[0].checked == true) {
                _appraisal_type = 2;
                //alert(2);
            }
            else {
                _appraisal_type = 1;
                //alert(1);
            }
            //alert('Appraisal_type ' + _appraisal_type);    
            _data[0] = getEleByProperty("input", "myId", "TextBoxReq_Id").value;
            //alert('Req_Id ' + _data[0]);
            _data[1] = getEleByProperty("input", "myId", "TextBoxHub_Id").value;
            //alert('Hub_Id ' + _data[1]);
            _data[2] = getEleByProperty("input", "myId", "TextBoxCif").value;
            //alert('Cif ' + _data[2]);
            _data[3] = getEleByProperty("input", "myId", "TextBoxLand").value;
            //alert('Land ' + _data[3]);
            _data[4] = getEleByProperty("input", "myId", "TextBoxBuilding").value;
            //alert('Building ' + _data[4]);
            _data[5] = 0;
            //alert('Condo ' + _data[5]);
            _data[6] = getEleByProperty("input", "myId", "TextBoxAppraisal_Id").value;
            //alert('User Create ' + _data[6]);
                      
            var IndexValueComment = $get('<%=ddlComment.ClientID %>').selectedIndex;
            _data[7] = $get('<%=ddlComment.ClientID %>').options[IndexValueComment].value;

            //alert('Comment ' + _data[7]);                        
            var IndexValueWarning = $get('<%=ddlWarning.ClientID %>').selectedIndex;
            _data[8] = $get('<%=ddlWarning.ClientID %>').options[IndexValueWarning].value;
            //alert('Warning ' + _data[8]);
            PageMethods.SavePrice2_Master(_data[0], _data[1], _data[2], _data[3], _data[4], _data[5], _appraisal_type, _data[7], _data[8], _data[6], this.callback);
        }
                                            
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <br />
    <br />
    <asp:Panel ID="pHeader" runat="server">
        <table align="center" border="0" cellpadding="3" cellspacing="5" style="background-color: #FFC20E;
            width: 895px">
            <tr>
                <td style="width: 180px">
                    เลขคำขอประเมิน
                </td>
                <td colspan="2">
                    <asp:TextBox ID="TextBoxReq_Id" runat="server" MaxLength="20" myId="TextBoxReq_Id"
                        onfocus="this.blur();"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 180px">
                    รหัส Hub
                </td>
                <td colspan="2">
                    <asp:TextBox ID="TextBoxHub_Id" runat="server" MaxLength="20" myId="TextBoxHub_Id"
                        onfocus="this.blur();"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 120px">
                    Cif
                </td>
                <td>
                    <asp:TextBox ID="TextBoxCif" runat="server" MaxLength="20" myId="TextBoxCif" onfocus="this.blur();"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 120px">
                    Cif Name
                </td>
                <td>
                    <asp:TextBox ID="TextBoxCifName" runat="server" MaxLength="20" myId="TextBoxCifName"
                        onfocus="this.blur();" Width="250px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 120px">
                    รหัส ผู้ประเมิน
                </td>
                <td>
                    <asp:TextBox ID="TextBoxAppraisal_Id" runat="server" MaxLength="20" myId="TextBoxAppraisal_Id"
                        onfocus="this.blur();"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 120px">
                    Temp AID
                </td>
                <td>
                    <asp:TextBox ID="TextBoxTemp_AID" runat="server" MaxLength="20" myId="TextBoxTemp_AID"
                        onfocus="this.blur();"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 120px">
                    วิธีการให้ราคา
                </td>
                <td colspan="2">
                    <asp:RadioButtonList ID="rdbAppraisal_Type" runat="server" BehaviorID="rdbAppraisal_TypeBehavior"
                        MyClintID="rdbAppraisal_Type" RepeatDirection="Horizontal">
                        <asp:ListItem Value="2">วิธีต้นทุน</asp:ListItem>
                        <asp:ListItem Value="1">วิธีตลาด</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pLand" runat="server">
        <table align="center" border="0" cellpadding="3" cellspacing="5" style="background-color: #FFC20E;
            width: 895px">
            <tr>
                <td style="width: 180px">
                    ราคาที่ดิน
                </td>
                <td>
                    <asp:TextBox ID="TextBoxLand" runat="server" MaxLength="20" myId="TextBoxLand" onfocus="this.blur();"
                        Style="text-align: right;"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="ButtonLand" runat="server" Text="ที่ดิน" Width="140px" OnClientClick="changeLandIframeSrc(); return false;" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pBuilding" runat="server">
        <table align="center" border="0" cellpadding="3" cellspacing="5" style="background-color: #FFC20E;
            width: 895px">
            <tr>
                <td style="width: 180px">
                    ราคาสิ่งปลูกสร้าง
                </td>
                <td>
                    <asp:TextBox ID="TextBoxBuilding" runat="server" MaxLength="20" myId="TextBoxBuilding"
                        onfocus="this.blur();" Style="text-align: right;">0.00</asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="ButtonBuilding" runat="server" Text="สิ่งปลูกสร้าง" Width="140px"
                        OnClientClick="changeBuildingIframeSrc(); return false;" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pCondo" runat="server">
        <table align="center" border="0" cellpadding="3" cellspacing="5" style="background-color: #FFC20E;
            width: 895px">
            <tr>
                <td style="width: 180px">
                    ราคาคอนโด
                </td>
                <td>
                    <asp:TextBox ID="TextBoxCondo" runat="server" MaxLength="20" myId="TextBoxCondo"
                        onfocus="this.blur();" Style="text-align: right;">0.00</asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="ButtonCondo" runat="server" Text="คอนโด" Width="140px" OnClientClick="changeCondoIframeSrc(); return false;"/>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pFooter" runat="server">
        <table align="center" border="0" cellpadding="3" cellspacing="5" style="background-color: #FFC20E;
            width: 895px">
            <tr>
                <td style="width: 180px">
                    ราคารวม
                </td>
                <td>
                    <asp:TextBox ID="TextBoxGrandTotal" runat="server" MaxLength="20" myId="TextBoxGrandTotal"
                        onfocus="this.blur();" Style="text-align: right;"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server">
        <table align="center" border="0" cellpadding="3" cellspacing="5" style="background-color: #FFC20E;
            width: 895px; height: 117px;">
            <tr>
                <td style="width: 120px">
                    Comment
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="ddlComment" runat="server" BackColor="Yellow" DataSourceID="SDSComment"
                        DataTextField="Comment_Name" DataValueField="Comment_ID">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 120px">
                    Warning
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="ddlWarning" runat="server" BackColor="Yellow" DataSourceID="SDSWarning"
                        DataTextField="Warning_Name" DataValueField="Warning_ID">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 120px">
                    &nbsp;
                </td>
                <td align="center">
                    <asp:ImageButton ID="ImageButtonAttachment" runat="server" Height="30px" ImageUrl="~/Images/attachment.png"
                        ToolTip="แนบไฟล์" Width="30px" OnClientClick="attachFile(); return false;" />
                    &nbsp;<asp:ImageButton ID="ImageButtonSave" runat="server" Font-Bold="True" ImageUrl="~/Images/save.jpg"
                        Width="30px" Height="30px" OnClientClick="savePrice2_Maseter(); return false;"/>
                    &nbsp;<asp:ImageButton ID="ImageButtonFullForm" runat="server" Font-Bold="True" ImageUrl="~/Images/full_form.ico"
                        Width="30px" Height="30px" ToolTip="ออกรายงานการประเมิน" />                        
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>
    
    <cc1:ModalPopupExtender ID="ModalPopupExtenderLand" runat="server" TargetControlID="ButtonLand"
        PopupControlID="panelLand" CancelControlID="ButtonCloseLand" BackgroundCssClass="modalBackground1"
        BehaviorID="mpeBehaviorLand">
    </cc1:ModalPopupExtender>
    <cc1:RoundedCornersExtender ID="RoundedCornersExtenderLand" runat="server" TargetControlID="pnlInnerPopupLand"
        BorderColor="black" Radius="4">
    </cc1:RoundedCornersExtender>
    <asp:Panel ID="panelLand" runat="server" CssClass="outerPopup" Style="display: none;">
        <asp:Panel ID="pnlInnerPopupLand" runat="server" Width="1100px" CssClass="innerPopup">
            <iframe id="IframeLand" src="" width="1100" height="600" frameborder="0" scrolling="yes">
            </iframe>
        </asp:Panel>
        <div style="white-space: nowrap; text-align: center;">
            <asp:Button ID="ButtonCloseLand" runat="server" Text="Close" Width="65px" myId="ButtonCloseLand" />
        </div>
    </asp:Panel>
    
    <cc1:ModalPopupExtender ID="ModalPopupExtenderBuilding" runat="server" TargetControlID="ButtonBuilding"
        PopupControlID="panelBuilding" BackgroundCssClass="modalBackground1"
        BehaviorID="mpeBehaviorBuilding">
    </cc1:ModalPopupExtender>
    <cc1:RoundedCornersExtender ID="RoundedCornersExtenderBuilding" runat="server" TargetControlID="pnlInnerPopupBuilding"
        BorderColor="black" Radius="4">
    </cc1:RoundedCornersExtender>
    <asp:Panel ID="panelBuilding" runat="server" CssClass="outerPopup" Style="display: none;">
<%--        <div style="white-space: nowrap; text-align: center;">
            <asp:Button ID="ButtonCloseBuilding" runat="server" Text="Close" Width="65px" myId="ButtonCloseBuilding" />
        </div>--%>
        <asp:Panel ID="pnlInnerPopupBuilding" runat="server" Width="1100px" CssClass="innerPopup">
            <iframe id="IframeBuilding" src="" width="1100" height="600" frameborder="0" scrolling="yes">
            </iframe>
        </asp:Panel>
    </asp:Panel>

    <cc1:ModalPopupExtender ID="ModalPopupExtenderCondo" runat="server" TargetControlID="ButtonCondo"
        PopupControlID="panelCondo" BackgroundCssClass="modalBackground1"
        BehaviorID="mpeBehaviorCondo">
    </cc1:ModalPopupExtender>
    <cc1:RoundedCornersExtender ID="RoundedCornersExtenderCondo" runat="server" TargetControlID="pnlInnerPopupCondo"
        BorderColor="black" Radius="4">
    </cc1:RoundedCornersExtender>
    <asp:Panel ID="panelCondo" runat="server" CssClass="outerPopup" Style="display: none;">
<%--        <div style="white-space: nowrap; text-align: center;">
            <asp:Button ID="ButtonCloseBuilding" runat="server" Text="Close" Width="65px" myId="ButtonCloseBuilding" />
        </div>--%>
        <asp:Panel ID="pnlInnerPopupCondo" runat="server" Width="1100px" CssClass="innerPopup">
            <iframe id="IframeCondo" src="" width="1100" height="600" frameborder="0" scrolling="yes">
            </iframe>
        </asp:Panel>
    </asp:Panel>
    
    <cc1:ModalPopupExtender ID="ModalPopupExtenderAttachment" runat="server" TargetControlID="ImageButtonAttachment"
        PopupControlID="panelAttachment" BackgroundCssClass="modalBackground1"
        BehaviorID="mpeBehaviorAttachment">
    </cc1:ModalPopupExtender>
    <cc1:RoundedCornersExtender ID="RoundedCornersExtenderAttachment" runat="server" TargetControlID="pnlInnerPopupAttachment"
        BorderColor="black" Radius="4">
    </cc1:RoundedCornersExtender>
    <asp:Panel ID="panelAttachment" runat="server" CssClass="outerPopup" Style="display: none;">
        <asp:Panel ID="pnlInnerPopupAttachment" runat="server" Width="750px" CssClass="innerPopup">
            <iframe id="IframeAttachment" src="" width="750" height="450" frameborder="0" scrolling="no">
            </iframe>
        </asp:Panel>
        <div style="white-space: nowrap; text-align: center;">
            <asp:Button ID="ButtonCloseAttachment" runat="server" Text="Close" Width="65px" myId="ButtonCloseAttachment" />
        </div>      
    </asp:Panel>
    <asp:Button ID = "bnts" runat="server" style="display:none;" />
    <cc1:ModalPopupExtender 
        ID="mdlPopup" runat="server" TargetControlID="ImageButtonSave" 
        PopupControlID="pnlPopup" BackgroundCssClass="modalBackground"
        BehaviorID="mdlPopupBehavior"  />   
                 
    <asp:Panel ID="pnlPopup" runat="server" CssClass="updateProgress" style="display:none">
        <div align="center" style="margin-top:10px;">
            <img src="Images/progress.gif" alt="" />
            <span class="updateProgressMessage">Please wait will be saving ...</span>
        </div>
    </asp:Panel>    
    
    <asp:SqlDataSource ID="SDSComment" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Comment_ID], [Comment_Name] FROM [Comment]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSWarning" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Warning_ID], [Warning_Name] FROM [Warning]"></asp:SqlDataSource>
</asp:Content>
