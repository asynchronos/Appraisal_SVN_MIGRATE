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
    </style>

    <script type="text/javascript">

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
                var param = "LandPrice=TextBoxLand&BuildingPrice=TextBoxBuilding&CondoPrice=TextBoxCondo&GrandTotal=TextBoxGrandTotal&PopupModal=mpeBehaviorLand";

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
                var param = "LandPrice=TextBoxLand&BuildingPrice=TextBoxBuilding&CondoPrice=TextBoxCondo&GrandTotal=TextBoxGrandTotal&PopupModal=mpeBehaviorLand";

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

        function changeBuildingIframeSrc() {
            if (document.getElementsByName("ctl00$ContentPlaceHolder1$rdbAppraisal_Type")[0].checked == true) {
                var myId = "IframeBuilding";
                var url = "Appraisal_Building_List.aspx"
                var param = "LandPrice=TextBoxLand&BuildingPrice=TextBoxBuilding&CondoPrice=TextBoxCondo&GrandTotal=TextBoxGrandTotal&PopupModal=mpeBehaviorLand";

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
                var myId = "IframeBuilding";
                var url = "Appraisal_Building_List.aspx"
                var param = "LandPrice=TextBoxLand&BuildingPrice=TextBoxBuilding&CondoPrice=TextBoxCondo&GrandTotal=TextBoxGrandTotal&PopupModal=mpeBehaviorLand";

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
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
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
                        onfocus="this.blur();" Style="text-align: right;">0</asp:TextBox>
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
                    <asp:Button ID="ButtonCondo" runat="server" Text="คอนโด" Width="140px" />
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
                    <asp:ImageButton ID="ImageButton1" runat="server" Height="30px" ImageUrl="~/Images/attachment.png"
                        ToolTip="แนบไฟล์" Width="30px" />
                    &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" Font-Bold="True" ImageUrl="~/Images/save.jpg"
                        Width="30px" Height="30px" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
        <asp:GridView ID="GridView1" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan"
            BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
            <FooterStyle BackColor="Tan" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
        </asp:GridView>
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
            <iframe id="IframeLand" src="" width="1100" height="600" frameborder="0" scrolling="no">
            </iframe>
        </asp:Panel>
        <div style="white-space: nowrap; text-align: center;">
            <asp:Button ID="ButtonCloseLand" runat="server" Text="Close" Width="65px" myId="ButtonCloseLand" />
        </div>
    </asp:Panel>
    <cc1:ModalPopupExtender ID="ModalPopupExtenderBuilding" runat="server" TargetControlID="ButtonBuilding"
        PopupControlID="panelBuilding" CancelControlID="ButtonCloseBuilding" BackgroundCssClass="modalBackground1"
        BehaviorID="mpeBehaviorBuilding">
    </cc1:ModalPopupExtender>
    <cc1:RoundedCornersExtender ID="RoundedCornersExtenderBuilding" runat="server" TargetControlID="pnlInnerPopupBuilding"
        BorderColor="black" Radius="4">
    </cc1:RoundedCornersExtender>
    <asp:Panel ID="panelBuilding" runat="server" CssClass="outerPopup" Style="display: none;">
        <asp:Panel ID="pnlInnerPopupBuilding" runat="server" Width="1100px" CssClass="innerPopup">
            <iframe id="IframeBuilding" src="" width="1100" height="600" frameborder="0" scrolling="no">
            </iframe>
        </asp:Panel>
        <div style="white-space: nowrap; text-align: center;">
            <asp:Button ID="ButtonCloseBuilding" runat="server" Text="Close" Width="65px" myId="ButtonCloseBuilding" />
        </div>
    </asp:Panel>
    <asp:SqlDataSource ID="SDSComment" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Comment_ID], [Comment_Name] FROM [Comment]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSWarning" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Warning_ID], [Warning_Name] FROM [Warning]"></asp:SqlDataSource>
</asp:Content>
