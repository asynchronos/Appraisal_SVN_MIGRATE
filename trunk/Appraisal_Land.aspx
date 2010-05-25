<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Appraisal_Land.aspx.vb"
    Inherits="Appraisal_Land" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="Mytextbox" Namespace="Mytextbox" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="Js/jquery.js" type="text/javascript"></script>

    <script src="Js/common.js" type="text/javascript"></script>

    <script src="Js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        function CalSection_Land(sender, e) {
            //ต้องกำหนด ชนิด input type MyClintID ที่ตัว Control ของแต่ละตัวที่จะส่ง และชื่อ Property  Name ของ Control นั้น ๆ ก่อน
            //var subunit_array = [0, 400, 1, 400, 1];
            var subunit_array = [0, 1, 1, 400, 1];  //คำอธิบาย 400 คือ 400 ตรว., 1 คือ 1 ตรว.
            var txtrai = getEleByProperty("input", "MyClintID", "txtRai");
            var txtngan = getEleByProperty("input", "MyClintID", "txtNgan");
            var txtwah = getEleByProperty("input", "MyClintID", "txtWah");
            var txtsubunit = getEleByProperty("select", "MyClintID", "ddlSubUnit");  //dropdownlist ส่งค่ามา
            var txtpricewah = getEleByProperty("input", "MyClintID", "txtPriceWah");
            var txtland_Price = getEleByProperty("input", "MyClintID", "txtTotal");

            var unitdiv = subunit_array[txtsubunit.options[txtsubunit.selectedIndex].value];   //หาค่าว่าแล้วจำมาแมปกับค่า Array ที่กำหนดไว้
            //alert(unitdiv);
            var wah_rai = Number(txtrai.value) * 400;
            //alert(wah_rai);
            var wah_ngan = Number(txtngan.value) * 100;
            var wah = Number(txtwah.value);
            var totalwar = wah_rai + wah_ngan + wah;

            var unit_price = Number(txtpricewah.value);

            var land_price = (totalwar * unit_price) / unitdiv;

            //ส่งแสดงผลกลับให้กับ Textbox ที่อยู่หน้า Design
            txtland_Price.value = addCommas(land_price);
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

//        function returnValue() 

//            var _landPrice = getValueFromQueryString("LandPrice");
//            var _buildingPrice = getValueFromQueryString("BuildingPrice");
//            var _condoPrice = getValueFromQueryString("CondoPrice");
//            var _grandTotal = getValueFromQueryString("GrandTotal");
//            var _PopupModal = getValueFromQueryString("PopupModal");
//            var _pricingLand = getEleByProperty("input", "MyClintID", "txtTotal");
//            window.parent.$("input[myId='" + _landPrice + "']")[0].value = _pricingLand.value;
//            window.parent.$("input[myId='" + _buildingPrice + "']")[0].value = '0.00';
//            window.parent.$("input[myId='" + _grandTotal + "']")[0].value = _pricingLand.value;
//            window.parent.$find(_PopupModal).hide();
//        }  
        
    </script>

    <script type="text/javascript">

        function returnValue() {

           var _PopupModal = getValueFromQueryString("PopupModal");
           
           //window.location.reload();
            id = "IframeLandEdit";
            var iframe = window.parent.document.getElementById(id);
            window.parent.$find(_PopupModal).hide();
            window.parent.location.replace(window.parent.location);            
        }
    </script>

</head>
<body style="border-left: 0px; border-top: 0px;">
    <form id="form1" runat="server">
    <div>
        <table style="background-color: #B5C7DE;" width="100%">
            <tr>
                <td>
                    เลขลำดับ
                </td>
                <td>
                    <asp:Label ID="lblId" runat="server" Style="font-weight: 700; color: #FF0000;"></asp:Label>
                </td>
                <td>
                    Temp AID
                </td>
                <td>
                    <asp:Label ID="lblTemp_AID" runat="server" Style="font-weight: 700; color: #FF0000;"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    เลขคำขอประเมิน
                </td>
                <td>
                    <asp:Label ID="lblReq_Id" runat="server" Style="font-weight: 700"></asp:Label>
                </td>
                <td>
                    รหัส Hub
                </td>
                <td>
                    <asp:Label ID="lblHub_Id" runat="server" Style="font-weight: 700"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
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
                <td>
                    ชนิดหลักประกัน
                </td>
                <td>
                    <asp:DropDownList ID="DDLSubCollType" runat="server" DataSourceID="sdsSubCollType"
                        DataTextField="SubCollType_Name" DataValueField="MysubColl_ID">
                    </asp:DropDownList>
                </td>
                <td>
                    ประกอบด้วยเลขที่
                </td>
                <td>
                    <asp:TextBox ID="txtChanode" runat="server" Width="190px"></asp:TextBox>
                    <asp:ImageButton ID="imgSearchChanode" runat="server" ImageUrl="~/Images/find1.jpg"
                        Height="22px" Width="22px" ToolTip="ค้นหา" />
                </td>
            </tr>
            <tr>
                <td>
                    ระวาง
                </td>
                <td>
                    <asp:TextBox ID="txtRaWang" runat="server" BackColor="#FFFF66" MaxLength="50"></asp:TextBox>
                </td>
                <td>
                    เลขที่ดิน
                </td>
                <td>
                    <asp:TextBox ID="txtLandNumber" runat="server" BackColor="#FFFF66"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    หน้าสำรวจ
                </td>
                <td>
                    <asp:TextBox ID="txtSurway" runat="server" BackColor="#FFFF66"></asp:TextBox>
                </td>
                <td>
                    สารบัญเล่มที่
                </td>
                <td>
                    <asp:TextBox ID="txtDocNo" runat="server" BackColor="#FFFF66"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    หน้า
                </td>
                <td>
                    <asp:TextBox ID="txtPage" runat="server" BackColor="#FFFF66"></asp:TextBox>
                </td>
                <td>
                    ตำบล/แขวง
                </td>
                <td>
                    <asp:TextBox ID="txtTumbon" runat="server" Width="222px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    อำเภอ/เขต
                </td>
                <td>
                    <asp:TextBox ID="txtAmphur" runat="server" Width="222px"></asp:TextBox>
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
                <td>
                    เนื้อที่
                </td>
                <td>
                    <cc1:mytext ID="txtRai" runat="server" AllowUserKey="int_Integer" EnableTextAlignRight="True"
                        Width="50px" MyClintID="txtRai" onkeyup="CalSection_Land(this,event);">0</cc1:mytext>
                    &nbsp;ไร่
                    <cc1:mytext ID="txtNgan" runat="server" AllowUserKey="int_Integer" EnableTextAlignRight="True"
                        MaxLength="1" Width="50px" MyClintID="txtNgan" onkeyup="CalSection_Land(this,event);">0</cc1:mytext>
                    &nbsp;งาน
                    <cc1:mytext ID="txtWah" runat="server" AllowUserKey="num_Numeric" EnableTextAlignRight="True"
                        MaxLength="5" Width="50px" MyClintID="txtWah" onkeyup="CalSection_Land(this,event);">0</cc1:mytext>
                    &nbsp;ตรว.
                </td>
                <td>
                    ผู้ถือกรรมสิทธิ์ที่ดิน
                </td>
                <td>
                    <asp:TextBox ID="txtOwnerShip" runat="server" Width="222px" BackColor="#FFFF66"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    ภาระผูกพัน
                </td>
                <td>
                    <asp:TextBox ID="txtObligation" runat="server" Width="222px" BackColor="#FFFF66"></asp:TextBox>
                </td>
                <td>
                    ที่ตั้งหลักประกัน ตั้งอยู่ถนน
                </td>
                <td>
                    <asp:TextBox ID="txtRoad" runat="server" Width="222px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    การตั้งอยู่ของหลักประกัน
                </td>
                <td>
                    <asp:DropDownList ID="ddlRoad_Detail" runat="server" DataSourceID="SDSRoad_Detail"
                        DataTextField="Road_Detail_Name" DataValueField="Road_Detail_ID">
                    </asp:DropDownList>
                    <cc1:mytext ID="txtMeter" runat="server" AllowUserKey="num_Numeric" EnableTextAlignRight="True"
                        MaxLength="6" Width="50px">0</cc1:mytext>
                    เมตร
                </td>
                <td>
                    ชื่อ ซอย (ถ้ามี)
                </td>
                <td>
                    <asp:TextBox ID="txtSoi" runat="server" Width="222px" BackColor="#FFFF66"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    สถาพที่ดิน
                </td>
                <td>
                    <asp:DropDownList ID="ddlLand_State" runat="server" DataSourceID="SDSLand_State"
                        DataTextField="Land_State_Name" DataValueField="Land_State_Id">
                    </asp:DropDownList>
                </td>
                <td>
                    รายละเอียดสภาพที่ดิน
                </td>
                <td>
                    <asp:TextBox ID="txtLand_State_Detail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    ถนนหน้าหลักประกัน
                </td>
                <td>
                    <asp:DropDownList ID="ddlRoad_Forntoff" runat="server" DataSourceID="SDSRoad_Forntoff"
                        DataTextField="Road_Frontoff_Name" DataValueField="Road_Frontoff_ID">
                    </asp:DropDownList>
                </td>
                <td>
                    ผิวจราจรกว้าง
                </td>
                <td>
                    <cc1:mytext ID="txtRoadWidth" runat="server" AllowUserKey="num_Numeric" MaxLength="5"
                        Width="50px" EnableTextAlignRight="True">0</cc1:mytext>
                    &nbsp;เมตร
                </td>
            </tr>
            <tr>
                <td>
                    ขนาดที่ดินกว้างติดถนน
                </td>
                <td>
                    <cc1:mytext ID="txtLand_Closeto_RoadWidth" runat="server" AllowUserKey="num_Numeric"
                        MaxLength="5" Width="50px" EnableTextAlignRight="True" BackColor="#FFFF66">0</cc1:mytext>
                    &nbsp;เมตร ที่ดินลึก(ซ้าย/ขวา)
                    <cc1:mytext ID="txtDeepWidth" runat="server" AllowUserKey="txt_Text" MaxLength="10"
                        Width="50px" EnableTextAlignRight="True" BackColor="#FFFF66">0</cc1:mytext>
                    &nbsp;เมตร
                </td>
                <td>
                    ิที่ดินด้านหลังกว้าง
                </td>
                <td>
                    <cc1:mytext ID="txtBehindWidth" runat="server" AllowUserKey="num_Numeric" MaxLength="5"
                        Width="50px" EnableTextAlignRight="True" BackColor="#FFFF66">0</cc1:mytext>
                    &nbsp;เมตร
                </td>
            </tr>
            <tr>
                <td>
                    ทำเล
                </td>
                <td>
                    <asp:DropDownList ID="ddlSite" runat="server" DataSourceID="SDSSite" DataTextField="Site_Name"
                        DataValueField="Site_ID">
                    </asp:DropDownList>
                </td>
                <td>
                    รายละเอียดทำเล
                </td>
                <td>
                    <asp:TextBox ID="txtSite_Detail" runat="server" Width="222px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    สาธารณูปโภค
                </td>
                <td>
                    <asp:DropDownList ID="ddlPublic_Utility" runat="server" DataSourceID="SDSPublic_Utility"
                        DataTextField="Public_Utility_Name" DataValueField="Public_Utility_ID">
                    </asp:DropDownList>
                </td>
                <td>
                    รายละเอียดสาธารณูปโภค
                </td>
                <td>
                    <asp:TextBox ID="txtPublic_Utility_Detail" runat="server" Width="222px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    การใช้ประโยชน์ในที่ดิน
                </td>
                <td>
                    <asp:DropDownList ID="ddlBinifit" runat="server" DataSourceID="SDSBinifit" DataTextField="Binifit_Name"
                        DataValueField="Binifit_ID">
                    </asp:DropDownList>
                </td>
                <td>
                    ลักษณะรูปที่ดิน
                </td>
                <td>
                    <asp:TextBox ID="txtBinifit" runat="server" Width="222px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    แนวโน้มความเจริญ
                </td>
                <td>
                    <asp:DropDownList ID="ddlTendency" runat="server" DataSourceID="SDSTendency" DataTextField="Tendency_Name"
                        DataValueField="Tendency_ID">
                    </asp:DropDownList>
                </td>
                <td>
                    สภาพคล่องการซื้อขาย
                </td>
                <td>
                    <asp:DropDownList ID="ddlBuySale_State" runat="server" DataSourceID="SDSBuySale_State"
                        DataTextField="BuySale_State_Name" DataValueField="BuySale_State_ID">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    ราคาต่อหน่วย
                </td>
                <td>
                    <asp:DropDownList ID="ddlSubUnit" runat="server" DataSourceID="SDSSubUnit" DataTextField="SubUnit_Name"
                        DataValueField="SubUnit_Id" MyClintID="ddlSubUnit" onkeyup="CalSection_Land(this,event);">
                    </asp:DropDownList>
                    &nbsp;<cc1:mytext ID="txtPriceWah" runat="server" AllowUserKey="num_Numeric" Width="120px"
                        EnableTextAlignRight="True" MyClintID="txtPriceWah" onkeyup="CalSection_Land(this,event);">0</cc1:mytext>
                    &nbsp;บาท
                </td>
                <td>
                    เป็นเงิน
                </td>
                <td>
                    <cc1:mytext ID="txtTotal" runat="server" AllowUserKey="num_Numeric" Width="120px"
                        AutoCurrencyFormatOnKeyUp="True" EnableTextAlignRight="True" MyClintID="txtTotal"
                        onfocus="this.blur();">0</cc1:mytext>
                    &nbsp;บาท
                </td>
            </tr>
            <tr>
                <td>
                    ที่ดินอยู่ในเขตพื้นที่สี
                </td>
                <td>
                    <asp:DropDownList ID="ddlAreaColur" runat="server" DataSourceID="SDSArea_Color" DataTextField="AreaColour_Name"
                        DataValueField="AreaColour_No" BackColor="#FFFF66">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="lbAppraisal_Id" runat="server" Style="font-weight: 700"></asp:Label>
                </td>
                <td>
                    <asp:HiddenField ID="hdfAppraisal_Id" runat="server" />
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
                                <asp:ImageButton ID="ImgBtnBack" runat="server" Height="35px" 
                                                  ImageUrl="~/Images/Button Previous.png" Width="35px" OnClientClick="returnValue(); return false;" />
<%--                                <asp:ImageButton ID="ImgBtnBack" runat="server" Height="35px" ImageUrl="~/Images/Button Previous.png"
                                    Width="35px" />--%>
                            </td>
                            <td>
                                <asp:Label ID="lblSave0" runat="server" Style="font-weight: 700" Text="BACK"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="hdfColl_Type" runat="server" />
    <asp:SqlDataSource ID="sdsSubCollType" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [SubCollType_Name], [MysubColl_ID] FROM [CollType_All]">
        <%--        <SelectParameters>
            <asp:QueryStringParameter Name="CollType_ID" QueryStringField="Coll_Type" 
                Type="Int32" />
        </SelectParameters>--%>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSRoad_Detail" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Road_Detail_ID], [Road_Detail_Name] FROM [Road_Detail]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSLand_State" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Land_State_Id], [Land_State_Name] FROM [Land_State]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSRoad_Forntoff" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Road_Frontoff_ID], [Road_Frontoff_Name] FROM [Road_Frontoff]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSSite" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Site_ID], [Site_Name] FROM [Site]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSPublic_Utility" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Public_Utility_ID], [Public_Utility_Name] FROM [Public_Utility]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSBinifit" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Binifit_ID], [Binifit_Name] FROM [Binifit]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSTendency" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Tendency_ID], [Tendency_Name] FROM [Tendency]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSBuySale_State" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [BuySale_State_ID], [BuySale_State_Name] FROM [BuySale_State]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSProvince" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT PROV_CODE, PROV_NAME FROM Bay01.dbo.TB_PROVINCE
Order by prov_code"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSArea_Color" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [AreaColour_No], [AreaColour_Name] FROM [AreaColour]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSSubUnit" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [SubUnit_Id], [SubUnit_Name] FROM [TB_SubUnit] WHERE ([SubUnit_Id] &lt;= @SubUnit_Id)">
        <SelectParameters>
            <asp:Parameter DefaultValue="3" Name="SubUnit_Id" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    </form>
</body>
</html>
