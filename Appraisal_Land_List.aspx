<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Appraisal_Land_List.aspx.vb"
    Inherits="Appraisal_Land_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Mytextbox" Namespace="Mytextbox" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

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
            //alert(encodeURI(urlFull));
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

            var myId = "IframeLand";
            var url = "Appraisal_Land.aspx";
            var param = "ID=" + '' + "&Temp_AID=" + '' + "&PopupModal=mpeBehaviorLand&Gridgiew=mpeBehaviorGridView1";
            //var param = "LandPrice=TextBoxLand&BuildingPrice=TextBoxBuilding&CondoPrice=TextBoxCondo&GrandTotal=TextBoxGrandTotal&PopupModal=mpeBehaviorLand";

            param = param + concatParam('', 'input', 'TextBoxReq_Id', 'Req_Id');
            param = param + concatParam('', 'input', 'TextBoxHub_Id', 'Hub_Id');
            param = param + concatParam('', 'input', 'TextBoxCif', 'Cif');
            param = param + concatParam('', 'input', 'TextBoxCifName', 'CifName');
            param = param + concatParam('', 'input', 'TextBoxAppraisal_Id', 'Appraisal_Id');

            changeIframeSrcById(myId
                , url
                , param
            );

            var popup = $find('mpeBehaviorLand');
            popup.show();
        }

        function changeEditLandIframeSrc(id, temp_aid) {
            //alert(temp_aid);
            var popup = $find('mpeBehaviorLandEdit');
            popup.show();

            var myId = "IframeLandEdit";
            var url = "Appraisal_Land.aspx";
            var param = "ID=" + id + "&Temp_AID=" + temp_aid + "&PopupModal=mpeBehaviorLandEdit";

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

        function returnValue() {
            var _landPrice = getValueFromQueryString("LandPrice");
            var _GrandTotal = getValueFromQueryString("GrandTotal");
            var _pricingLand = getEleByProperty("input", "myId", "TextBoxTotal");
            var _PopupModal = getValueFromQueryString("PopupModal");
            //alert(1);
            window.parent.$("input[myId='" + _landPrice + "']")[0].value = _pricingLand.value;
            window.parent.$("input[myId='" + _GrandTotal + "']")[0].value = _pricingLand.value;
            window.parent.$find(_PopupModal).hide();
        }

        function deleteLand(id, subCollType) {

            var _req_Id = getEleByProperty("input", "myId", "TextBoxReq_Id");
            var _hub_Id = getEleByProperty("input", "myId", "TextBoxHub_Id");
            //alert(id);
            //alert(subCollType);
            //alert(_req_Id.value);
            //alert(_hub_Id.value);
            //PageMethods.DeleteSubCollType(_req_Id, _hub_Id, id, subCollType, this.callback);

            var myId = "IframeDelete";
            var url = "Appraisal_Delete_Land.aspx";
            var param = "MysubColl_ID=" + subCollType + "&LandId=" + id + "&PopupModal=mpeBehaviorDelete";

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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
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
                                <asp:ImageButton ID="ImageButtonAddLand" runat="server" ImageUrl="Images/add_plus.jpg"
                                    Width="50" OnClientClick="changeLandIframeSrc(); return false;" ToolTip="เพิ่มที่ดินแปลงใหม่" />
                                <asp:HiddenField ID="HiddenReq_No" runat="server" />
                                <asp:HiddenField ID="HiddenHubId" runat="server" Value="104" />
                                <asp:HiddenField ID="HiddenBuildingPrice" runat="server" Value="104" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="style2" style="background-image: url('Images/center_tile.gif')">
                                ::รายการที่ดิน::
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="2"
                                    DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="None" BackColor="LightGoldenrodYellow"
                                    BorderColor="Tan" BorderWidth="1px" Width="100%" Font-Size="Small" AllowPaging="True"
                                    DataKeyNames="Req_Id,Hub_Id,ID" BehaviorID="mpeBehaviorGridView1" ShowFooter="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID" SortExpression="ID">
                                            <ItemTemplate>
                                                <asp:Label ID="LabelID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Temp_AID" SortExpression="Temp_AID">
                                            <ItemTemplate>
                                                <asp:Label ID="LabelTemp_AID" runat="server" Text='<%# Bind("Temp_AID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ชนิดหลักประกัน" SortExpression="MysubColl_ID">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="HiddenFieldMysubColl_ID" runat="server" Value='<%# Bind("MysubColl_ID") %>' />
                                                <asp:Label ID="LabelSubCollType_Name" runat="server" Text='<%# Bind("SubCollType_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Address_No" HeaderText="เลขที่โฉนด" SortExpression="Address_No" />
                                        <asp:BoundField DataField="Tumbon" HeaderText="Tumbon" SortExpression="Tumbon" />
                                        <asp:BoundField DataField="Amphur" HeaderText="Amphur" SortExpression="Amphur" />
                                        <asp:BoundField DataField="PROV_NAME" HeaderText="PROV_NAME" SortExpression="PROV_NAME" />
                                        <asp:BoundField DataField="Rai" HeaderText="Rai" SortExpression="Rai" />
                                        <asp:BoundField DataField="Ngan" HeaderText="Ngan" SortExpression="Ngan" />
                                        <asp:BoundField DataField="Wah" HeaderText="Wah" ReadOnly="True" SortExpression="Wah" />
                                        <asp:TemplateField HeaderText="วาละ" SortExpression="PriceWah">
                                            <ItemStyle HorizontalAlign="Right" />
                                            <ItemTemplate>
                                                <asp:Label ID="LabelPriceWah" runat="server" Text='<%# Bind("PriceWah") %>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="LabelDesctext" runat="server" Text="ราคารวม :"></asp:Label>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ราคาที่ให้">
                                            <ItemStyle HorizontalAlign="Right" />
                                            <ItemTemplate>
                                                <%#GetPrice(Decimal.Parse(Eval("PriceTotal1").ToString())).ToString("N2")%>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <%--                                                <asp:TextBox ID="TextBoxTotal" runat="server" Text='<%#GetTotalPrice().ToString("N0")%>' myId="TextBoxTotal" onfocus="this.blur();" ></asp:TextBox>--%>
                                                <cc1:mytext ID="TextBoxTotal" runat="server" AllowUserKey="num_Numeric" AutoCurrencyFormatOnKeyUp="True"
                                                    EnableTextAlignRight="True" myId="TextBoxTotal" ReadOnly="True" Width="120px" Text='<%#GetTotalPrice().ToString("N2")%>'>0</cc1:mytext>
                                                <asp:Label ID="LabelBaht" runat="server" Text=" บาท"></asp:Label>
                                            </FooterTemplate>
                                            <FooterStyle Font-Bold="True" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemStyle Width="25px" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgDetail" runat="server" ImageUrl="~/Images/find1.jpg" Height="22px"
                                                    Width="22px" ToolTip="รายละเอียด" OnClientClick='<%# "changeEditLandIframeSrc("+Eval("ID").toString()+","""+Eval("Temp_AID").toString()+"""); return false;" %>' />
                                                <%-- <asp:ImageButton ID="imgDetail" runat="server" ImageUrl="~/Images/find1.jpg" Height="22px"
                                                    Width="22px" ToolTip="รายละเอียด" onclick="imgDetail_Click" />--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemStyle VerticalAlign="Middle" Width="30px" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgDelete" runat="server" ImageUrl="~/Images/cancel1.jpg" ToolTip="Delete"
                                                    Width="22px" Height="22px" OnClientClick='<%# "deleteLand("+Eval("ID").toString()+","""+Eval("MysubColl_ID").toString()+"""); return false;" %>' />
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Button ID="ButtonOK" runat="server" Text="ยืนยัน" OnClientClick='<%# "returnValue(); return false;" %>' />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="Tan" />
                                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
                                    SelectCommand="GET_PRICE3_50_BY_REQ_ID" SelectCommandType="StoredProcedure" DeleteCommand="DELETE_PRICE2_PRICE3_50"
                                    DeleteCommandType="StoredProcedure">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="TextBoxReq_Id" Name="Req_Id" PropertyName="Text"
                                            Type="Int32" />
                                        <asp:ControlParameter ControlID="TextBoxHub_Id" Name="Hub_Id" PropertyName="Text"
                                            Type="Int32" />
                                    </SelectParameters>
                                    <DeleteParameters>
                                        <asp:Parameter Name="Req_Id" Type="Int32" />
                                        <asp:Parameter Name="Hub_Id" Type="Int32" />
                                        <asp:Parameter Name="Id" Type="Int32" />
                                    </DeleteParameters>
                                </asp:SqlDataSource>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <cc1:ModalPopupExtender ID="ModalPopupExtenderLand" runat="server" TargetControlID="ImageButtonAddLand"
            PopupControlID="panelLand" BackgroundCssClass="modalBackground1" BehaviorID="mpeBehaviorLand">
        </cc1:ModalPopupExtender>
        <cc1:RoundedCornersExtender ID="RoundedCornersExtenderLand" runat="server" TargetControlID="pnlInnerPopupLand"
            BorderColor="black" Radius="4">
        </cc1:RoundedCornersExtender>
        <asp:Panel ID="panelLand" runat="server" CssClass="outerPopup" Style="display: none;">
            <asp:Panel ID="pnlInnerPopupLand" runat="server" Width="1100px" CssClass="innerPopup">
                <iframe id="IframeLand" src="" width="1100" height="610" frameborder="0" scrolling="yes">
                </iframe>
            </asp:Panel>
        </asp:Panel>
        
        <asp:Button ID="ButtonLandEdit" runat="server" Style="display: none;" BehaviorID="ButtonLandEdit" />
        <cc1:ModalPopupExtender ID="ModalPopupExtenderLandEdit" runat="server" TargetControlID="ButtonLandEdit"
            PopupControlID="panelLandEdit" BackgroundCssClass="modalBackground1" BehaviorID="mpeBehaviorLandEdit">
        </cc1:ModalPopupExtender>
        <cc1:RoundedCornersExtender ID="RoundedCornersExtenderLandEdit" runat="server" TargetControlID="pnlInnerPopupLandEdit"
            BorderColor="black" Radius="4">
        </cc1:RoundedCornersExtender>
        <asp:Panel ID="panelLandEdit" runat="server" CssClass="outerPopup" Style="display: none;">
            <asp:Panel ID="pnlInnerPopupLandEdit" runat="server" Width="1100px" CssClass="innerPopup">
                <iframe id="IframeLandEdit" src="" width="1100" height="610" frameborder="0" scrolling="yes">
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
