<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Appraisal_Building.aspx.vb"
    Inherits="Appraisal_Building" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Mytextbox" Namespace="Mytextbox" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
            width: 220px;
        }
    </style>

    <script type="text/javascript">

        function CalSection_Building(sender, e) {
            //ต้องกำหนด ชนิด input type MyClintID ที่ตัว Control ของแต่ละตัวที่จะส่ง และชื่อ Property  Name ของ Control นั้น ๆ ก่อน
            var building_area = getEleByProperty("input", "MyClintID", "txtBuildingArea");
            var price_per_unit = getEleByProperty("input", "MyClintID", "txtBuildingUnitPrice");
            var txtbuildingPrice = getEleByProperty("input", "MyClintID", "txtBuildingPrice");
            var txtpercent_finish = getEleByProperty("input", "MyClintID", "txtFinishPercent");
            var txtprice_finish = getEleByProperty("input", "MyClintID", "txtPriceNotFinish");
            var txtBuildingAge = getEleByProperty("input", "MyClintID", "txtBuildingAge");
            var txtBuildingPersent1 = getEleByProperty("input", "MyClintID", "txtBuildingPersent1");
            var txtBuildingPersent2 = getEleByProperty("input", "MyClintID", "txtBuildingPersent2");
            var txtBuildingPersent3 = getEleByProperty("input", "MyClintID", "txtBuildingPersent3");
            var txtBuildingTotalDeteriorate = getEleByProperty("input", "MyClintID", "txtBuildingTotalDeteriorate");
            var txtBuildingPriceTotalDeteriorate = getEleByProperty("input", "MyClintID", "txtBuildingPriceTotalDeteriorate");
            var txtNetPrice = getEleByProperty("input", "MyClintID", "txtNetPrice");

            var b_area = Number(building_area.value);
            //alert(b_area);
            var pp_unit = Number(price_per_unit.value);
            //alert(pp_unit);
            var percent_finish = Number(txtpercent_finish.value);
            //alert(percent_finish);
            var buildingAge = Number(txtBuildingAge.value);
            //         alert(buildingAge);
            var BuildingPersent1 = Number(txtBuildingPersent1.value);
            //         alert(BuildingPersent1);
            var BuildingPersent2 = Number(txtBuildingPersent2.value);
            //         alert(BuildingPersent2);
            var BuildingPersent3 = Number(txtBuildingPersent3.value);

            var building_price = b_area * pp_unit;
            var building_price2 = building_price * (percent_finish / 100);
            txtbuildingPrice.value = addCommas(building_price);
            txtprice_finish.value = addCommas(building_price2);
            var percent_total = (buildingAge * BuildingPersent1) - BuildingPersent2 + BuildingPersent3;
            txtBuildingTotalDeteriorate.value = percent_total;
            var BuildingPriceTotalDeteriorate = addCommas(building_price2 * (percent_total / 100));
            txtBuildingPriceTotalDeteriorate.value = addCommas(BuildingPriceTotalDeteriorate);
            var netprice = (building_price2 - (building_price2 * (percent_total / 100)));
            //alert(netprice);
            txtNetPrice.value = addCommas(netprice);
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

        function changeStandardIframeSrc() {
            clearTextStandard();
            var myId = "IframeSearchStandard";
            var url = "Appraisal_Standard.aspx";
            var param = "StandardCode=TextBoxStandardNo&StandardName=TextBoxStandardName&PopupModal=mpeBehaviorSearchStandard";

            changeIframeSrcById(myId
                , url
                , param
            );
        }

        function changeBuildingDetailIframeSrc() {
            var buildingid = document.getElementById('<%=lblId.ClientID%>').innerHTML;
            var temp_AID = document.getElementById('<%=lblTemp_AID.ClientID%>').innerHTML;
            alert(temp_AID);
            if (buildingid > 0) {

                var myId = "IframeBuildingDetail";
                var url = "Appraisal_Building_Detail.aspx";
                var param = "Id=" + buildingid + "&Req_Id=" + getValueFromQueryString("Req_Id") + "&Hub_Id=" + getValueFromQueryString("Hub_Id") + "&Temp_AID=" + temp_AID + "&PopupModal=mpeBehaviorSearchStandard";

                changeIframeSrcById(myId
                , url
                , param
            );
            } else {
                alert('คุณต้องบันทึกรายละเอียดสิ่งปลูกสร้างก่อนเพิ่มรายละเอียดพื้นผนัง');
                //window.location.replace(window.location);
            }
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

        function clearTextStandard() {
            var StandardNo = getEleByProperty("input", "myId", "TextBoxStandardNo")
            StandardNo.value = ''
            var StandardName = getEleByProperty("input", "myId", "TextBoxStandardName")
            StandardName.value = ''
        }

        function concatParam(oldParam, addParamTag, addParamMyId, addParamKey) {
            var result = oldParam;
            var dom = null;

            if (addParamTag == "input") {
                dom = getEleByProperty(addParamTag, "myId", addParamMyId);
            } else if (addParamTag == "span") {
                dom = getEleByProperty(addParamTag, "myId", addParamMyId);
            }

            if (dom.value.length >= 1) {
                result = result + "&" + addParamKey + "=" + dom.value;
            } else {

            }
            return result;
        }

        function returnValue() {
            var _PopupModal = getValueFromQueryString("PopupModal");
            id = "IframeBuilding";
            var iframe = window.parent.document.getElementById(id);
            window.parent.$find(_PopupModal).hide();
            window.parent.location.replace(window.parent.location);
        }

        function makeNewOpenWindow() {
            var windowFeatures
            var newWindow
            var reqId = document.getElementById('<%=lblReq_Id.ClientID%>').innerHTML;
            var hubId = document.getElementById('<%=lblHub_Id.ClientID%>').innerHTML;
            var id = document.getElementById('<%=lblId.ClientID%>').innerHTML;
            var tempAID = document.getElementById('<%=lblTemp_AID.ClientID%>').innerHTML;

            windowFeatures = "top=0,left=0,resizable=yes,width=" + (screen.width) + ",height=" + (screen.height);
            newWindow = window.open("Appraisal_Price3_Print_CollType70_New.aspx?Req_Id=" + reqId + "&Hub_Id=" + hubId + "&ID=" + id + "&Temp_AID=" + tempAID, "openWindow", windowFeatures);
            newWindow.focus();
        }
                          
    </script>

</head>
<body style="border-left: 0px; border-top: 0px;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <table style="background-color: #B5C7DE; font-size: small;" width="100%">
            <tr>
                <td class="style1">
                    เลขลำดับ
                </td>
                <td>
                    <asp:Label ID="lblId" runat="server" Style="font-weight: 700; color: #FF0000;" myId="lblId"></asp:Label>
                </td>
                <td>
                    Temp AID
                </td>
                <td>
                    <asp:Label ID="lblTemp_AID" runat="server" Style="font-weight: 700; color: #FF0000;"
                        myId="lblTemp_AID"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    เลขคำขอประเมิน
                </td>
                <td>
                    <asp:Label ID="lblReq_Id" runat="server" Style="font-weight: 700" myId="lblReq_Id"></asp:Label>
                </td>
                <td>
                    รหัส Hub
                </td>
                <td>
                    <asp:Label ID="lblHub_Id" runat="server" Style="font-weight: 700" myId="lblHub_Id"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    ผู้ขอสินเชื่อ
                </td>
                <td>
                    <asp:Label ID="lblCifName" runat="server" Style="font-weight: 700"></asp:Label>
                </td>
                <td>
                    Cif
                </td>
                <td>
                    <asp:Label ID="lblCif" runat="server" Style="font-weight: 700"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    ปลูกสร้างบนโฉนดเลขที่
                </td>
                <td>
                    <asp:TextBox ID="txtChanodeNo" runat="server" BackColor="#FFFF66" MyClintID="txtChanodeNo"></asp:TextBox>
                    <asp:ImageButton ID="imgSearchChanode" runat="server" ImageUrl="~/Images/find1.jpg"
                        Height="22px" Width="22px" ToolTip="ค้นหา สิ่งที่จำเป็นคือ เลขโฉนด เลขที่สิ่งปลูกสร้างและจังหวัดที่ตั้งหลักประกัน" />
                </td>
                <td>
                    สิ่งปลูกสร้างกรรมสิทธิ์ของ
                </td>
                <td>
                    <asp:TextBox ID="txtOwnership" runat="server" Width="250px" BackColor="#FFFF66"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    บ้านเลขที่
                </td>
                <td>
                    <asp:TextBox ID="txtBuild_No" runat="server" MyClintID="txtBuild_No"></asp:TextBox>
                </td>
                <td>
                    ตำบล
                </td>
                <td>
                    <asp:TextBox ID="txtTumbon" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    อำเภอ
                </td>
                <td>
                    <asp:TextBox ID="txtAmphur" runat="server"></asp:TextBox>
                </td>
                <td>
                    จังหวัด
                </td>
                <td>
                    <asp:DropDownList ID="ddlProvince" runat="server" DataSourceID="SDSProvince" DataTextField="PROV_NAME"
                        DataValueField="PROV_CODE">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    ลักษณะอาคาร
                </td>
                <td>
                    <asp:DropDownList ID="ddlBuild_Character" runat="server" DataSourceID="SDSlBuild_Character"
                        DataTextField="Build_Character_Name" DataValueField="Build_Character_ID">
                    </asp:DropDownList>
                </td>
                <td>
                    จำนวน
                </td>
                <td>
                    <cc1:mytext ID="txtFloor" runat="server" AllowUserKey="num_Numeric" Width="35px">0</cc1:mytext>
                    &nbsp;ชั้น
                    <asp:TextBox ID="txtItem" runat="server" Width="35px">0</asp:TextBox>
                    &nbsp;หลัง
                </td>
            </tr>
            <tr>
                <td class="style1">
                    โครงสร้างอาคาร
                </td>
                <td>
                    <asp:DropDownList ID="ddlBuild_Construct" runat="server" DataSourceID="SDSBuild_Construct"
                        DataTextField="Build_Construct_Name" DataValueField="Build_Construct_ID">
                    </asp:DropDownList>
                </td>
                <td>
                    หลังคา
                </td>
                <td>
                    <asp:DropDownList ID="ddlRoof" runat="server" DataSourceID="SDSRoof" DataTextField="Roof_Name"
                        DataValueField="Roof_ID">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    รายละเอียดหลังคาเพิ่มเติม(ถ้ามี)
                </td>
                <td>
                    <asp:TextBox ID="txtRoof_Detail" runat="server"></asp:TextBox>
                </td>
                <td>
                    สภาพอาคาร
                </td>
                <td>
                    <asp:DropDownList ID="ddlBuild_State" runat="server" DataSourceID="SDSBuild_State"
                        DataTextField="Build_State_Name" DataValueField="Build_State_ID">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    รายละเอียดสภาพอื่น ๆ
                </td>
                <td>
                    <asp:TextBox ID="txtBuild_State_Detail" runat="server"></asp:TextBox>
                </td>
                <td>
                    สิ่งปลูกสร้าง
                </td>
                <td>
                    <asp:TextBox ID="txtBuilding_Detail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    โครงสร้างหลังคา
                </td>
                <td>
                    <asp:DropDownList ID="ddlRoofConstructure" runat="server" DataSourceID="SDSRoofStructure"
                        DataTextField="RoofStructure_Name" DataValueField="RoofStructure_Id">
                    </asp:DropDownList>
                </td>
                <td>
                    สภาพหลังคา
                </td>
                <td>
                    <asp:DropDownList ID="ddlRoofState" runat="server" DataSourceID="SDSRoof_State" DataTextField="RoofState_Name"
                        DataValueField="RoofState_Id">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    สภาพการตกแต่ง
                </td>
                <td>
                    <asp:DropDownList ID="ddlInteriorState" runat="server" DataSourceID="SDSInterior_State"
                        DataTextField="InteriorState_Name" DataValueField="InteriorState_Id">
                    </asp:DropDownList>
                </td>
                <td>
                    เอกสารประกอบเพิ่มเติม
                </td>
                <td>
                    <asp:CheckBox ID="chkDoc1" runat="server" Text="ใบอนุญาติปลูกสร้าง" />
                    &nbsp;<asp:CheckBox ID="chkDoc2" runat="server" Text="เรื่องทางภารจำยอม" />
                </td>
            </tr>
            <tr>
                <td class="style1">
                    มาตรฐาน
                </td>
                <td colspan="3">
                    <asp:TextBox ID="TextBoxStandardNo" runat="server" Width="30px" myId="TextBoxStandardNo"
                        onfocus="this.blur();"></asp:TextBox>
                    <asp:TextBox ID="TextBoxStandardName" runat="server" Width="300px" myId="TextBoxStandardName"
                        onfocus="this.blur();"></asp:TextBox>
                    <asp:Button ID="ButtonSearchStandard" runat="server" Text="...." OnClientClick="changeStandardIframeSrc(); return false;" />
                </td>
            </tr>
        </table>
        <table style="border-width: thin; border-color: #FFFF00; background-color: #B5C7DE;
            font-size: small;" width="100%">
            <tr>
                <td>
                    ชนิดหลักประกัน
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="DDLSubCollType" runat="server" DataSourceID="sdsSubCollType"
                        DataTextField="SubCollType_Name" DataValueField="MysubColl_ID">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    พื้นที่สิ่งปลูกสร้างทั้งหมด
                </td>
                <td>
                    <cc1:mytext ID="txtBuildingArea" runat="server" AllowUserKey="num_Numeric" EnableTextAlignRight="True"
                        MaxLength="5" Width="35px" BackColor="#FFFF66" MyClintID="txtBuildingArea" onkeyup="CalSection_Building(this,event);">0</cc1:mytext>
                    ตรม.
                </td>
                <td>
                    ตรว.ละ(สร้างเสร็จ)
                </td>
                <td>
                    <cc1:mytext ID="txtBuildingUnitPrice" runat="server" AllowUserKey="num_Numeric" EnableTextAlignRight="True"
                        Width="110px" BackColor="#FFFF66" MyClintID="txtBuildingUnitPrice" onkeyup="CalSection_Building(this,event);">0.00</cc1:mytext>
                    บาท
                </td>
            </tr>
            <tr>
                <td>
                    มูลค่า(สร้างเสร็จ)
                </td>
                <td>
                    <cc1:mytext ID="txtBuildingPrice" runat="server" AllowUserKey="num_Numeric" EnableTextAlignRight="True"
                        Width="110px" BackColor="#FFFF66" ReadOnly="True" MyClintID="txtBuildingPrice">0.00</cc1:mytext>
                    บาท
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;% สิ่งปลูกสร้างสร้างเสร็จ
                </td>
                <td>
                    <cc1:mytext ID="txtFinishPercent" runat="server" AllowUserKey="num_Numeric" Width="35px"
                        BackColor="#FFFF66" MaxLength="3" EnableTextAlignRight="True" MyClintID="txtFinishPercent"
                        onkeyup="CalSection_Building(this,event);">100</cc1:mytext>
                    &nbsp;%
                </td>
                <td>
                    มูลค่า
                </td>
                <td>
                    <cc1:mytext ID="txtPriceNotFinish" runat="server" AllowUserKey="num_Numeric" EnableTextAlignRight="True"
                        Width="110px" BackColor="#FFFF66" MyClintID="txtPriceNotFinish">0.00</cc1:mytext>
                    บาท
                </td>
            </tr>
            <tr>
                <td>
                    อายุการใช้งาน
                </td>
                <td>
                    <cc1:mytext ID="txtBuildingAge" runat="server" AllowUserKey="num_Numeric" EnableTextAlignRight="True"
                        MaxLength="2" Width="35px" BackColor="#FFFF66" MyClintID="txtBuildingAge" onkeyup="CalSection_Building(this,event);">0</cc1:mytext>
                    ปี
                </td>
                <td>
                    ค่าเสื่อมต่อปี
                </td>
                <td>
                    <cc1:mytext ID="txtBuildingPersent1" runat="server" AllowUserKey="num_Numeric" EnableTextAlignRight="True"
                        MaxLength="5" Width="35px" BackColor="#FFFF66" MyClintID="txtBuildingPersent1"
                        onkeyup="CalSection_Building(this,event);">0</cc1:mytext>
                    %
                </td>
            </tr>
            <tr>
                <td>
                    ค่าเสื่อมตามสภาพปรับปรุง
                </td>
                <td>
                    <cc1:mytext ID="txtBuildingPersent2" runat="server" AllowUserKey="num_Numeric" EnableTextAlignRight="True"
                        MaxLength="5" Width="35px" BackColor="#FFFF66" MyClintID="txtBuildingPersent2"
                        onkeyup="CalSection_Building(this,event);">0</cc1:mytext>
                    %
                </td>
                <td>
                    ค่าเสื่อมตามสภาพเสื่อมโทรม
                </td>
                <td>
                    <cc1:mytext ID="txtBuildingPersent3" runat="server" AllowUserKey="num_Numeric" EnableTextAlignRight="True"
                        MaxLength="5" Width="35px" BackColor="#FFFF66" MyClintID="txtBuildingPersent3"
                        onkeyup="CalSection_Building(this,event);">0</cc1:mytext>
                    %
                </td>
            </tr>
            <tr>
                <td>
                    รวมค่าเสื่อม
                </td>
                <td>
                    <cc1:mytext ID="txtBuildingTotalDeteriorate" runat="server" AllowUserKey="num_Numeric"
                        EnableTextAlignRight="True" MaxLength="5" Width="35px" BackColor="#FFFF66" MyClintID="txtBuildingTotalDeteriorate"
                        onkeyup="CalSection_Building(this,event);">0</cc1:mytext>
                    %
                </td>
                <td>
                    รวมค่าเสื่อมราคา
                </td>
                <td>
                    <cc1:mytext ID="txtBuildingPriceTotalDeteriorate" runat="server" AllowUserKey="num_Numeric"
                        EnableTextAlignRight="True" Width="110px" BackColor="#FFFF66" MyClintID="txtBuildingPriceTotalDeteriorate">0.00</cc1:mytext>
                    บาท
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;เป็นเงิน(ราคาตลาด)
                </td>
                <td>
                    <cc1:mytext ID="txtPriceTotal1" runat="server" AllowUserKey="num_Numeric" AutoCurrencyFormatOnKeyUp="True"
                        EnableTextAlignRight="True" BackColor="#FFFF66" Width="110px">0</cc1:mytext>
                    บาท
                </td>
                <td>
                    ราคาหลังหักค่าเสื่อม
                </td>
                <td>
                    <cc1:mytext ID="txtNetPrice" runat="server" AllowUserKey="num_Numeric" BackColor="#FFFF66"
                        EnableTextAlignRight="True" MyClintID="txtNetPrice" Width="110px" AutoCurrencyFormatOnKeyUp="True">0.00</cc1:mytext>
                    บาท
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="ButtonBuildingDetail" runat="server" Text="รายละเอียดพื้น/ผนัง" OnClientClick="changeBuildingDetailIframeSrc(); return false;" />
                </td>
                <td>
                    <asp:HiddenField ID="hdfAppraisal_Id" runat="server" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    รายละเอียดขนาด
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtBuildingDetail" runat="server" Height="50px" TextMode="MultiLine"
                        Width="500px" BackColor="#FFFF66"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <table>
                        <tr>
                            <td>
                                <asp:ImageButton ID="ImageSave" runat="server" ImageUrl="~/Images/Save.jpg" Width="35px"
                                    Height="35px" />
                            </td>
                            <td>
                                <asp:Label ID="lblSave" runat="server" Style="font-weight: 700" Text="SAVE"></asp:Label>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImagePrint" runat="server" ImageUrl="~/Images/Printer.png" Width="35px"
                                    Height="35px" OnClientClick="makeNewOpenWindow(); return false;" />
                            </td>
                            <td>
                                <asp:Label ID="lblPrint" runat="server" Style="font-weight: 700" Text="Print Preview"></asp:Label>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImgBtnBack" runat="server" Height="35px" ImageUrl="~/Images/Button Previous.png"
                                    Width="35px" OnClientClick="returnValue(); return false;" />
                            </td>
                            <td>
                                <asp:Label ID="lblBack" runat="server" Style="font-weight: 700" Text="BACK"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <cc1:ModalPopupExtender ID="ModalPopupExtenderSearchStandard" runat="server" TargetControlID="ButtonSearchStandard"
        PopupControlID="panelSearchStandard" BackgroundCssClass="modalBackground1" BehaviorID="mpeBehaviorSearchStandard">
    </cc1:ModalPopupExtender>
    <cc1:RoundedCornersExtender ID="RoundedCornersExtenderSearchStandard" runat="server"
        TargetControlID="pnlInnerPopupSearchStandard" BorderColor="black" Radius="6">
    </cc1:RoundedCornersExtender>
    <asp:Panel ID="panelSearchStandard" runat="server" CssClass="outerPopup" Style="display: none;">
        <asp:Panel ID="pnlInnerPopupSearchStandard" runat="server" Width="600px" CssClass="innerPopup">
            <iframe id="IframeSearchStandard" src="" width="600" height="480" frameborder="0"
                scrolling="yes"></iframe>
        </asp:Panel>
    </asp:Panel>
    <asp:Button ID="BtnBuildingDetail" runat="server" Style="display: none;" BehaviorID="BtnBuildingDetail" />
    <cc1:ModalPopupExtender ID="ModalPopupExtenderBuildingDetail" runat="server" TargetControlID="ButtonBuildingDetail"
        PopupControlID="panelBuildingDetail" CancelControlID="ButtonCloseBuilding" BackgroundCssClass="modalBackground1"
        BehaviorID="mpeBehaviorBuildingDetail">
    </cc1:ModalPopupExtender>
    <cc1:RoundedCornersExtender ID="RoundedCornersExtenderBuildingDetail" runat="server"
        TargetControlID="pnlInnerPopupBuildingDetail" BorderColor="black" Radius="4">
    </cc1:RoundedCornersExtender>
    <asp:Panel ID="panelBuildingDetail" runat="server" CssClass="outerPopup" Style="display: none;">
        <asp:Panel ID="pnlInnerPopupBuildingDetail" runat="server" Width="800px" CssClass="innerPopup">
            <iframe id="IframeBuildingDetail" src="" width="800" height="500" frameborder="0"
                scrolling="yes"></iframe>
        </asp:Panel>
        <div style="white-space: nowrap; text-align: center;">
            <asp:Button ID="ButtonCloseBuilding" runat="server" Text="Close" Width="65px" myId="ButtonCloseLand" />
        </div>
    </asp:Panel>
    <asp:SqlDataSource ID="sdsSubCollType" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [SubCollType_Name], [MysubColl_ID] FROM [CollType_All] WHERE ([CollType_ID] = @CollType_ID)">
        <SelectParameters>
            <asp:Parameter DefaultValue="70" Name="CollType_ID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSlBuild_Character" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Build_Character_ID], [Build_Character_Name] FROM [Build_Character]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSBuild_Construct" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Build_Construct_ID], [Build_Construct_Name] FROM [Build_Construct]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSRoof" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Roof_ID], [Roof_Name] FROM [Roof]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSBuild_State" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Build_State_ID], [Build_State_Name] FROM [Build_State]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSProvince" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT PROV_CODE, PROV_NAME FROM Bay01.dbo.TB_PROVINCE
Order by prov_code"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSRoofStructure" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [RoofStructure_Id], [RoofStructure_Name] FROM [Roof_Structure]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSRoof_State" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [RoofState_Id], [RoofState_Name] FROM [Roof_State]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSInterior_State" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [InteriorState_Id], [InteriorState_Name] FROM [Interior_State]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsStandard" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="GET_STANDARD_INFO" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:HiddenField ID="HiddenApprisalType" runat="server" Value="104" />
    </form>
</body>
</html>
