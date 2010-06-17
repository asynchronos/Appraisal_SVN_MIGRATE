<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Appraisal_Condo_List.aspx.vb"
    Inherits="Appraisal_Condo_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Mytextbox" Namespace="Mytextbox" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="Js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="Js/common.js" type="text/javascript"></script>

    <script src="Js/jquery.js" type="text/javascript"></script>

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
        .style1
        {
            height: 116px;
        }
        .style2
        {
            color: #0000CC;
            font-weight: bold;
        }
    </style>

    <script type="text/javascript">
        function changeIframeSrcById(id, url, param) {
            var urlFull = "";
            //var popup = $find('mpeBehaviorBuilding');
            var iframe = document.getElementById(id);
            //alert(url);
            if (param) {
                urlFull = url + "?" + param;
            } else {
                urlFull = url;
            }
            //alert(encodeURI(urlFull));
            iframe.src = encodeURI(urlFull);
            //popup.show();
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


        function changeCondoIframeSrc() {
            var AppraisalType = document.getElementById('<%=HiddenApprisalType.ClientID%>').value;
            var myId = "IframeCondo";
            var url = "Appraisal_Condo.aspx";
            var param = "ID=" + '' + "&Temp_AID=" + '' + "&Appraisal_Type=" + AppraisalType + "&PopupModal=mpeBehaviorCondo";

            param = param + concatParam('', 'input', 'TextBoxReq_Id', 'Req_Id');
            param = param + concatParam('', 'input', 'TextBoxHub_Id', 'Hub_Id');
            param = param + concatParam('', 'input', 'TextBoxCif', 'Cif');
            param = param + concatParam('', 'input', 'TextBoxCifName', 'CifName');
            param = param + concatParam('', 'input', 'TextBoxAppraisal_Id', 'Appraisal_Id');
            //alert(param);
            changeIframeSrcById(myId
                , url
                , param
            );
        }

        function changeEditCondoIframeSrc(id, temp_aid) {
            var AppraisalType = document.getElementById('<%=HiddenApprisalType.ClientID%>').value;
            var myId = "IframeCondoEdit";
            var url = "Appraisal_Condo.aspx";
            var param = "ID=" + id + "&Temp_AID=" + temp_aid + "&Appraisal_Type=" + AppraisalType + "&PopupModal=mpeBehaviorCondoEdit";

            param = param + concatParam('', 'input', 'TextBoxReq_Id', 'Req_Id');
            param = param + concatParam('', 'input', 'TextBoxHub_Id', 'Hub_Id');
            param = param + concatParam('', 'input', 'TextBoxCif', 'Cif');
            param = param + concatParam('', 'input', 'TextBoxCifName', 'CifName');
            param = param + concatParam('', 'input', 'TextBoxAppraisal_Id', 'Appraisal_Id');
            //alert(param);
            changeIframeSrcById(myId
                , url
                , param
            );
            var popup = $find('mpeBehaviorCondoEdit');
            popup.show();
        }
        function returnValue() {
            var _Condo = getValueFromQueryString("CondoPrice");
            var _GrandTotal = getValueFromQueryString("GrandTotal");
            var _pricingCondo = getEleByProperty("input", "myId", "TextBoxTotal");
            var _PopupModal = getValueFromQueryString("PopupModal");
            //alert(1);
            window.parent.$("input[myId='" + _Condo + "']")[0].value = _pricingCondo.value;
            window.parent.$("input[myId='" + _GrandTotal + "']")[0].value = _pricingCondo.value;
            window.parent.$find(_PopupModal).hide();
        }

        function deleteCondo(id, subCollType) {

            var _req_Id = getEleByProperty("input", "myId", "TextBoxReq_Id");
            var _hub_Id = getEleByProperty("input", "myId", "TextBoxHub_Id");
            //alert(id);
            //alert(subCollType);
            //alert(_req_Id.value);
            //alert(_hub_Id.value);
            //PageMethods.DeleteSubCollType(_req_Id, _hub_Id, id, subCollType, this.callback);

            var myId = "IframeDelete";
            var url = "Appraisal_Delete_Condo.aspx";
            var param = "MysubColl_ID=" + subCollType + "&CondoId=" + id + "&PopupModal=mpeBehaviorDelete";

            param = param + concatParam('', 'input', 'TextBoxReq_Id', 'Req_Id');
            param = param + concatParam('', 'input', 'TextBoxHub_Id', 'Hub_Id');
            changeIframeSrcById(myId
                , url
                , param
            );
            var popup = $find('mpeBehaviorDelete');
            popup.show();
        } 
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        <Services>
            <asp:ServiceReference Path="~/Service.svc" />
        </Services>
    </asp:ScriptManager>
    <div>
        <table width="100%" style="background-color: #FFC20E;">
            <tr>
                <td>
                    <table width="100%" style="margin-left: 0px">
                        <tr>
                            <td class="style1">
                                <table align="center" border="0" cellpadding="3" cellspacing="5" width="100%" style="background-color: #FFC20E;">
                                    <tr>
                                        <td style="width: 180px">
                                            เลขคำขอประเมิน
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxReq_Id" runat="server" MaxLength="20" myId="TextBoxReq_Id"
                                                onfocus="this.blur();"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 180px">
                                            รหัส Hub
                                        </td>
                                        <td>
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
                                    </tr>
                                    <tr>
                                        <td style="width: 120px">
                                            Cif Name
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxCifName" runat="server" MaxLength="20" myId="TextBoxCifName"
                                                onfocus="this.blur();" Width="250px"></asp:TextBox>
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
                                    </tr>
                                </table>
                            </td>
                            <td align="right" valign="top" style="background-color: #FFC20E;">
                                <asp:ImageButton ID="ImageButtonAddCondo" runat="server" ImageUrl="Images/add_plus.jpg"
                                    Width="50" OnClientClick="changeCondoIframeSrc(); return false;" ToolTip="เพิ่มที่ดินแปลงใหม่" />
                                <asp:HiddenField ID="HiddenReq_No" runat="server" />
                                <asp:HiddenField ID="HiddenHubId" runat="server" Value="104" />
                                <asp:HiddenField ID="HiddenApprisalType" runat="server" Value="104" />
                                <asp:HiddenField ID="HiddenLandPrice" runat="server" Value="104" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="style2" style="background-image: url('Images/center_tile.gif')">
                                ::รายการ Condo::
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="GridView_Condo_List" runat="server" AutoGenerateColumns="False"
                                    BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2"
                                    ForeColor="Black" GridLines="None" Style="font-size: small" DataSourceID="SqlDataSourceCondo"
                                    DataKeyNames="Req_Id,Hub_Id,Id,MysubColl_ID" ShowFooter="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblID_Condo" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ชื่อหลักประกัน">
                                            <ItemStyle Width="230px" />
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdfColltype_Id" runat="server" Value='<%# Bind("MysubColl_ID") %>' />
                                                <asp:Label ID="lblColltype_Name" runat="server" Text='<%# Bind("CollName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="เลขทะเบียนอาคารชุด">
                                            <ItemStyle HorizontalAlign="Left" Width="130px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblRegister_No" runat="server" Text='<%# Bind("Building_Reg_No") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ชื่อโครงการ">
                                            <ItemStyle Width="250px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblBuildingName" runat="server" Text='<%# Bind("Building_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="เลขที่อาคาร">
                                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblBuild_Number" runat="server" Text='<%# Bind("Building_No") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="เลขที่ห้อง">
                                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblAddressNo" runat="server" Text='<%# Bind("Address_No") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ชั้นที่">
                                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblFloor" runat="server" Text='<%# Bind("Floors") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="พื้นที่">
                                            <ItemStyle HorizontalAlign="Right" Width="50px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblArea" runat="server" Text='<%# eval("Room_Area", "{0:N}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ตรม.ละ">
                                            <ItemStyle HorizontalAlign="Right" Width="130px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblUnit_Price" runat="server" Text='<%# eval("Unit_Price", "{0:N}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="รวมราคา">
                                            <ItemStyle HorizontalAlign="right" Width="130px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblTotal_Building" runat="server" Text='<%#GetPrice(Decimal.Parse(Eval("PriceTotal").ToString())).ToString("N2")%>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <cc1:mytext ID="TextBoxTotal" runat="server" AllowUserKey="num_Numeric" AutoCurrencyFormatOnKeyUp="True"
                                                    EnableTextAlignRight="True" myId="TextBoxTotal" ReadOnly="True" Width="110px"
                                                    Text='<%#GetTotalPrice().ToString("N2")%>'>0</cc1:mytext>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemStyle Width="25px" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgDetail" runat="server" ImageUrl="~/Images/find1.jpg" Height="22px"
                                                    Width="22px" ToolTip="รายละเอียด" OnClientClick='<%# "changeEditCondoIframeSrc("+Eval("ID").toString()+","""+Eval("MysubColl_ID").toString()+"""); return false;" %>' />
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="LabelBaht" runat="server" Text=" บาท"></asp:Label>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemStyle VerticalAlign="Middle" Width="30px" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgDelete" runat="server" ImageUrl="~/Images/cancel1.jpg" ToolTip="Delete"
                                                    Width="22px" Height="22px" OnClientClick='<%# "deleteCondo("+Eval("ID").toString()+","""+Eval("MysubColl_ID").toString()+"""); return false;" %>' />
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Button ID="ButtonConfirm" runat="server" Text="ยืนยัน" OnClientClick="returnValue(); return false;" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="Tan" />
                                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                </asp:GridView>
                                <table class="TableWidth">
                                    <tr>
                                        <td align="right">
                                            <asp:HiddenField ID="HiddenFieldGrandTotal" runat="server" Value="104" />
                                        </td>
                                    </tr>
                                </table>
                                <asp:SqlDataSource ID="SqlDataSourceCondo" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
                                    SelectCommand="GET_PRICE2_PRICE3_18" SelectCommandType="StoredProcedure">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="TextBoxReq_Id" Name="Req_Id" PropertyName="Text"
                                            Type="Int32" />
                                        <asp:ControlParameter ControlID="TextBoxHub_Id" Name="Hub_Id" PropertyName="Text"
                                            Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <cc1:ModalPopupExtender ID="ModalPopupExtenderCondo" runat="server" TargetControlID="ImageButtonAddCondo"
            PopupControlID="panelCondo" BackgroundCssClass="modalBackground1" BehaviorID="mpeBehaviorCondo">
        </cc1:ModalPopupExtender>
        <cc1:RoundedCornersExtender ID="RoundedCornersExtenderCondo" runat="server" TargetControlID="pnlInnerPopupCondo"
            BorderColor="black" Radius="4">
        </cc1:RoundedCornersExtender>
        <asp:Panel ID="panelCondo" runat="server" CssClass="outerPopup" Style="display: none;">
            <asp:Panel ID="pnlInnerPopupCondo" runat="server" Width="1100px" CssClass="innerPopup">
                <iframe id="IframeCondo" src="" width="1100" height="610" frameborder="0" scrolling="yes">
                </iframe>
            </asp:Panel>
        </asp:Panel>
        <asp:Button ID="ButtonCondoEdit" runat="server" Style="display: none;" BehaviorID="ButtonCondoEdit" />
        <cc1:ModalPopupExtender ID="ModalPopupExtenderCondoEdit" runat="server" TargetControlID="ButtonCondoEdit"
            PopupControlID="panelCondoEdit" BackgroundCssClass="modalBackground1" BehaviorID="mpeBehaviorCondoEdit">
        </cc1:ModalPopupExtender>
        <cc1:RoundedCornersExtender ID="RoundedCornersExtenderCondoEdit" runat="server" TargetControlID="pnlInnerPopupCondoEdit"
            BorderColor="black" Radius="4">
        </cc1:RoundedCornersExtender>
        <asp:Panel ID="panelCondoEdit" runat="server" CssClass="outerPopup" Style="display: none;">
            <asp:Panel ID="pnlInnerPopupCondoEdit" runat="server" Width="1100px" CssClass="innerPopup">
                <iframe id="IframeCondoEdit" src="" width="1100" height="610" frameborder="0" scrolling="yes">
                </iframe>
            </asp:Panel>
        </asp:Panel>
        <asp:Button ID="ButtonDelete" runat="server" Style="display: none;" BehaviorID="ButtonDelete" />
        <cc1:ModalPopupExtender ID="ModalPopupExtenderDelete" runat="server" TargetControlID="ButtonDelete"
            PopupControlID="panelDelete" BackgroundCssClass="modalBackground1" BehaviorID="mpeBehaviorDelete">
        </cc1:ModalPopupExtender>
        <cc1:RoundedCornersExtender ID="RoundedCornersExtenderDelete" runat="server" TargetControlID="pnlInnerPopupDelete"
            BorderColor="black" Radius="4">
        </cc1:RoundedCornersExtender>
        <asp:Panel ID="panelDelete" runat="server" CssClass="outerPopup" Style="display: none;">
            <asp:Panel ID="pnlInnerPopupDelete" runat="server" Width="400px" CssClass="innerPopup">
                <iframe id="IframeDelete" src="" width="400" height="100" frameborder="0" scrolling="no">
                </iframe>
            </asp:Panel>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
