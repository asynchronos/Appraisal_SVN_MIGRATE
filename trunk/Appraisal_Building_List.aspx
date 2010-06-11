<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Appraisal_Building_List.aspx.vb" Inherits="Appraisal_Building_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Mytextbox" Namespace="Mytextbox" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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


        function changeBuildingIframeSrc() {
            var AppraisalType = document.getElementById('<%=HiddenApprisalType.ClientID%>').value;
            var myId = "IframeBuilding";
            var url = "Appraisal_Building.aspx";
            var param = "ID=" + '' + "&Temp_AID=" + '' + "&Appraisal_Type=" + AppraisalType + "&PopupModal=mpeBehaviorBuilding";
            //var param = "LandPrice=TextBoxLand&BuildingPrice=TextBoxBuilding&CondoPrice=TextBoxCondo&GrandTotal=TextBoxGrandTotal&PopupModal=mpeBehaviorLand";

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

        function changeEditBuildingIframeSrc(buildingId, subcollTypeId) {
            var AppraisalType = document.getElementById('<%=HiddenApprisalType.ClientID%>').value;
            var myId = "IframeBuildingEdit";
            var url = "Appraisal_Building.aspx";
            var param = "ID=" + buildingId + "&Temp_AID=" + '' + "&MysubColl_ID=" + subcollTypeId + "&Appraisal_Type=" + AppraisalType + "&PopupModal=mpeBehaviorBuildingEdit";

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
            var popup = $find('mpeBehaviorBuildingEdit');
            popup.show();
        }

        function returnValue() {
            //alert(1);
            var _BuildingPrice = getValueFromQueryString("BuildingPrice");
            //alert(_BuildingPrice);               
            var _GrandTotal = getValueFromQueryString("GrandTotal");
            //alert(_GrandTotal);
            var _LandPrice = document.getElementById('<%=HiddenLandPrice.ClientID%>').value;
            //alert(_GrandTotal);
            var _pricingBuilding = getEleByProperty("input", "myId", "mytextBuildingGrandTotal");
            //alert(_pricingBuilding);
            var GrandTotal = document.getElementById('<%=HiddenFieldGrandTotal.ClientID%>').value;
            //alert(GrandTotal);
            var _PopupModal = getValueFromQueryString("PopupModal");

            window.parent.$("input[myId='" + _BuildingPrice + "']")[0].value = _pricingBuilding.value;
            window.parent.$("input[myId='" + _GrandTotal + "']")[0].value = GrandTotal;
            window.parent.$find(_PopupModal).hide();
        }

        function addCommas(nStr) {
            nStr += '';
            x = nStr.split('.');
            x1 = x[0];
            x2 = x.length > 1 ? '.' + x[1] : '';
            var rgx = /(\d+)(\d{3})/;
            while (rgx.test(x1)) {
                x1 = x1.replace(rgx, '$1' + ',' + '$2');
            }
            return x1 + x2;
        }

        function deleteSubCollType(id, subCollType) {

            var _req_Id = getEleByProperty("input", "myId", "TextBoxReq_Id");
            var _hub_Id = getEleByProperty("input", "myId", "TextBoxHub_Id");
            //alert(id);
            //alert(subCollType);
            //alert(_req_Id.value);
            //alert(_hub_Id.value);
            //PageMethods.DeleteSubCollType(_req_Id, _hub_Id, id, subCollType, this.callback);

            var myId = "IframeDelete";
            var url = "Appraisal_Delete_Building.aspx";
            var param = "MysubColl_ID=" + subCollType + "&BuildingId=" + id + "&PopupModal=mpeBehaviorDelete";

            param = param + concatParam('', 'input', 'TextBoxReq_Id', 'Req_Id');
            param = param + concatParam('', 'input', 'TextBoxHub_Id', 'Hub_Id');
            changeIframeSrcById(myId
                , url
                , param
            );
            var popup = $find('mpeBehaviorDelete');
            popup.show();            
        }

        function callback(result) {
            //  let the user know if their credit card was validated
            if (result) {
                alert('Delete data compleate!');
                //location.reload("Appraisal_AssignJob.aspx");
                window.location.replace(window.location);
            }
            else {
                alert('Warning, Delete not compleate!');
            }
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
                                <asp:ImageButton ID="ImageButtonAddBuilding" runat="server" ImageUrl="Images/add_plus.jpg"
                                    Width="50" OnClientClick="changeBuildingIframeSrc(); return false;" ToolTip="เพิ่มที่ดินแปลงใหม่" />
                                <asp:HiddenField ID="HiddenReq_No" runat="server" />
                                <asp:HiddenField ID="HiddenHubId" runat="server" Value="104" />
                                <asp:HiddenField ID="HiddenApprisalType" runat="server" Value="104" />
                                <asp:HiddenField ID="HiddenLandPrice" runat="server" Value="104" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="style2" style="background-image: url('Images/center_tile.gif')">
                                ::รายการสิ่งปลูกสร้าง::
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            <asp:GridView ID="GridView_Building" runat="server" AutoGenerateColumns="False" 
                                BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                                CellPadding="2" ForeColor="Black" GridLines="None" 
                                style="font-size: small" 
                                DataSourceID="SqlDataSourceBuilding" 
                                DataKeyNames="Req_Id,Hub_Id,Id,MysubColl_ID">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID_building" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>                                     
                                    <asp:TemplateField HeaderText="ชื่อหลักประกัน">
                                    <ItemStyle Width="220px" />
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdfColltype_Id" runat="server" 
                                                Value='<%# Bind("MysubColl_ID") %>' />
                                            <asp:Label ID="lblColltype_Name" runat="server" 
                                                Text='<%# Bind("CollName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="เลขที่โฉนด">
                                        <ItemTemplate>
                                            <asp:Label ID="lblChanode" runat="server" Text='<%# Bind("Put_On_Chanode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="บ้านเลขที่">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBuild_No" runat="server" Text='<%# Bind("Build_No") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="พื้นที่">
                                    <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblArea" runat="server" Text='<%# Bind("Area") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ตรม.ละ">
                                    <ItemStyle HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnit_Price" runat="server" 
                                                Text='<%# eval("UintPrice", "{0:N}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="มูลค่าสร้างเสร็จ">
                                    <ItemStyle HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblValue_Price" runat="server" 
                                                Text='<%# Bind("Price", "{0:N}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="%สร้างเสร็จ">
                                    <ItemStyle HorizontalAlign="center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblPercent_Finish" runat="server" 
                                                Text='<%# Bind("PercentFinish") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="มูลค่าที่สร้างเสร็จ">
                                    <ItemStyle HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblFinish_Price" runat="server" 
                                                Text='<%# Bind("Pricepercent", "{0:N}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="อายุใช้งาน">
                                     <ItemStyle HorizontalAlign="center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblAge" runat="server" Text='<%# Bind("Age") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="คส.ต่อปี">
                                     <ItemStyle HorizontalAlign="center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblPercent1" runat="server" Text='<%# Bind("Percent1") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="คส.ปรับปรุง">
                                    <ItemStyle HorizontalAlign="center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblPercent2" runat="server" Text='<%# Bind("Percent2") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="คส.เสื่อมโทรม">
                                    <ItemStyle HorizontalAlign="center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblPercent3" runat="server" Text='<%# Bind("Percent3") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="รวมค่าเสื่อม">
                                    <ItemStyle HorizontalAlign="center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotal_Percent" runat="server" 
                                                Text='<%# Bind("Total_Percent") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="มูลค่าค่าเสื่อม">
                                     <ItemStyle HorizontalAlign="right" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblDeteriorate" runat="server" 
                                                Text='<%# Bind("bpd", "{0:N}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ราคาทุน">
                                         <ItemStyle HorizontalAlign="right" />                                   
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotal_Building" runat="server" 
                                                Text='<%# Bind("NetPrice", "{0:N}") %>'>
                                            </asp:Label>
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ราคาตลาด">
                                        <ItemStyle HorizontalAlign="Right" />                                    
                                        <ItemTemplate>
                                            <asp:Label ID="lblMarketPrice" runat="server" 
                                                Text='<%#GetPrice(Decimal.Parse(Eval("PriceTotal1").ToString())).ToString("N2")%>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                       <%-- <FooterTemplate>
                                                <cc1:mytext ID="TextBoxTotal" runat="server" AllowUserKey="num_Numeric" AutoCurrencyFormatOnKeyUp="True"
                                                    EnableTextAlignRight="True" myId="TextBoxTotal" ReadOnly="True" Width="110px" Text='<%#GetTotalPrice().ToString("N2")%>'>0.00</cc1:mytext>
                                                <asp:Label ID="LabelBaht" runat="server" Text="บาท"></asp:Label>
                                        </FooterTemplate>--%>
                                    </asp:TemplateField>                                    
                                        <asp:TemplateField HeaderText="">
                                            <ItemStyle Width="25px" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgDetail" runat="server" ImageUrl="~/Images/find1.jpg" Height="22px"
                                                    Width="22px" ToolTip="รายละเอียด" OnClientClick='<%# "changeEditBuildingIframeSrc("+Eval("ID").toString()+","""+Eval("MysubColl_ID").toString()+"""); return false;" %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemStyle VerticalAlign="Middle" Width="30px" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgDelete" runat="server" ImageUrl="~/Images/cancel1.jpg" ToolTip="Delete"
                                                    Width="22px" Height="22px" OnClientClick='<%# "deleteSubCollType("+Eval("ID").toString()+","""+Eval("MysubColl_ID").toString()+"""); return false;" %>'/>
                                            </ItemTemplate>
                                        </asp:TemplateField>                                   
                                </Columns>
                                <FooterStyle BackColor="Tan" />
                                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                                    HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                            </asp:GridView>
                            <table class="TableWidth">
                                <tr>
                                    <td align="right">
                                <asp:HiddenField ID="HiddenFieldGrandTotal" runat="server" Value="104" />
                                        <cc1:mytext ID="mytextBuildingGrandTotal" runat="server" AllowUserKey="num_Numeric" 
                                            AutoCurrencyFormatOnKeyUp="True" EnableTextAlignRight="True" Width="100px" myId="mytextBuildingGrandTotal" onfocus="this.blur();"></cc1:mytext>
                                        <asp:Button ID="ButtonConfirm" runat="server" Text="ยืนยัน" OnClientClick="returnValue(); return false;" />
                                    </td>
                                </tr>
                            </table>
                                <asp:SqlDataSource ID="SqlDataSourceBuilding" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
                                    SelectCommand="GET_PRICE2_70_BUILDING_ALL" 
                                    SelectCommandType="StoredProcedure">
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
        
       
        <cc1:ModalPopupExtender ID="ModalPopupExtenderBuilding" runat="server" TargetControlID="ImageButtonAddBuilding"
            PopupControlID="panelBuilding" BackgroundCssClass="modalBackground1" BehaviorID="mpeBehaviorBuilding">
        </cc1:ModalPopupExtender>
        <cc1:RoundedCornersExtender ID="RoundedCornersExtenderBuilding" runat="server" TargetControlID="pnlInnerPopupBuilding"
            BorderColor="black" Radius="4">
        </cc1:RoundedCornersExtender>
        <asp:Panel ID="panelBuilding" runat="server" CssClass="outerPopup" Style="display: none;">
            <asp:Panel ID="pnlInnerPopupBuilding" runat="server" Width="1100px" CssClass="innerPopup">
                <iframe id="IframeBuilding" src="" width="1100" height="610" frameborder="0" scrolling="yes">
                </iframe>
            </asp:Panel>
        </asp:Panel>
        
        <asp:Button ID="ButtonBuildingEdit" runat="server" Style="display: none;" BehaviorID="ButtonBuildingEdit" />
         <cc1:ModalPopupExtender ID="ModalPopupExtenderBuildingEdit" runat="server" TargetControlID="ButtonBuildingEdit"
            PopupControlID="panelBuildingEdit" BackgroundCssClass="modalBackground1" BehaviorID="mpeBehaviorBuildingEdit">
        </cc1:ModalPopupExtender>
        <cc1:RoundedCornersExtender ID="RoundedCornersExtenderBuildingEdit" runat="server" TargetControlID="pnlInnerPopupBuildingEdit"
            BorderColor="black" Radius="4">
        </cc1:RoundedCornersExtender>
        <asp:Panel ID="panelBuildingEdit" runat="server" CssClass="outerPopup" Style="display: none;">
            <asp:Panel ID="pnlInnerPopupBuildingEdit" runat="server" Width="1100px" CssClass="innerPopup">
                <iframe id="IframeBuildingEdit" src="" width="1100" height="610" frameborder="0" scrolling="yes">
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
