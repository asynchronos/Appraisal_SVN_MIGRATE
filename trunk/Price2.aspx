<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Price2.aspx.vb" Inherits="Price2" %>

<%@ Register Assembly="Mytextbox" Namespace="Mytextbox" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>กำหนดราคาประเมินราคาที่ 2</title>
    <style type="text/css">
        .style1
        {
            width: 914px;
        }
        .style2
        {
            width: 100%;
        }
        .fstyle
        {
            font-size: medium;
            color: Blue;
            font-weight: bold;
        }
        .fstyle1
        {
            font-size: small;
            color: Blue;
            font-weight: bold;
        }
        .Fcolor
        {
            color: Red;
        }
        .style3
        {
            height: 27px;
        }
        .style4
        {
            height: 15px;
        }
        .style5
        {
            width: 187px;
        }
        .style6
        {
            height: 27px;
            width: 187px;
        }
        .style7
        {
            height: 15px;
            width: 187px;
        }
        .style8
        {
            width: 180px;
        }
        .style9
        {
            height: 27px;
            width: 180px;
        }
        .style10
        {
            height: 15px;
            width: 180px;
        }
        .style11
        {
            width: 186px;
        }
        .style12
        {
            height: 27px;
            width: 186px;
        }
        .style13
        {
            height: 15px;
            width: 186px;
        }
        .style14
        {
            width: 193px;
        }
        .style15
        {
            height: 27px;
            width: 193px;
        }
        .style16
        {
            height: 15px;
            width: 193px;
        }
        .style17
        {
            width: 186px;
            height: 30px;
        }
        .style18
        {
            width: 180px;
            height: 30px;
        }
        .style19
        {
            width: 187px;
            height: 30px;
        }
        .style20
        {
            height: 30px;
        }
        .style21
        {
            width: 193px;
            height: 30px;
        }
    </style>

    <script type="text/javascript">
<!--
var updated="";

// http://www.boutell.com/newfaq/creating/windowcenter.html
function wopen(url, name, w, h)
{
  // Fudge factors for window decoration space.
  // In my tests these work well on all platforms & browsers.
  w += 32;
  h += 96;
  wleft = (screen.width - w) / 2;
  wtop = (screen.height - h) / 2;
  // IE5 and other old browsers might allow a window that is
  // partially offscreen or wider than the screen. Fix that.
  // (Newer browsers fix this for us, but let's be thorough.)
  if (wleft < 0) {
    w = screen.width;
    wleft = 0;
  }
  if (wtop < 0) {
    h = screen.height;
    wtop = 0;
  }
  var win = window.open(url,
    name,
    'width=' + w + ', height=' + h + ', ' +
    'left=' + wleft + ', top=' + wtop + ', ' +
    'location=no, menubar=no, modal=yes' +
    'status=no, toolbar=no, scrollbars=no, resizable=no', 'tite=no', 'resizable=no', 'directories=no', 'status=no');
  // Just in case width and height are ignored
  win.resizeTo(w, h);
  // Just in case left and top are ignored
  win.moveTo(wleft, wtop);
  win.focus();
}
// -->
    </script>

</head>
<body style="margin-top: 0px; margin-left: 0px">
    <form id="form1" runat="server">

    <script language="javascript" type="text/javascript"> 
       function txtSizeActiveChanged() { 
//          if (sender._activeTabIndex != 0) { 
             if (($get('<%=txtRai.ClientID%>').value.length != 0) || ($get('<%=txtNgan.ClientID%>').value.length != 0) || ($get('<%=txtSquaremeter.ClientID%>').value.length != 0)) { 
                 //sender.set_activeTabIndex(0); 
                 $get('<%=txtSize.ClientID%>').value = $get('<%=txtRai.ClientID%>').value + '-' + $get('<%=txtNgan.ClientID%>').value + '-' + $get('<%=txtSquaremeter.ClientID%>').value
             } 
//         } 
        }
       function GrandTotal_ActiveChanged() { 
                 $get('<%=txtGrandTotal.ClientID%>').value = $get('<%=txtPriceItem1.ClientID%>').value + $get('<%=txtPriceItem2.ClientID%>').value + $get('<%=txtTotal1.ClientID%>').value + $get('<%=txtTotal2.ClientID%>').value + $get('<%=txtTotal3.ClientID%>').value
        }        
    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <table border="0" cellspacing="0" cellpadding="0" width="100%" style="height: 80px">
            <tr>
                <td align="left" style="background-color: #FFCE40" class="style1">
                    <img alt="" src="Images/logo_bay.gif" style="" /><br />
                </td>
                <td style="height: 50px; background-color: #FFCE40;" valign="top">
                    <table class="style2">
                        <tr>
                            <td class="fstyle">
                                User ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
                            </td>
                            <td>
                                <asp:Label ID="lblUserID" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="fstyle">
                                User Name&nbsp;&nbsp; :
                            </td>
                            <td>
                                <asp:Label ID="lblUserName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="fstyle">
                                Position&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
                            </td>
                            <td>
                                <asp:Label ID="lblPostion" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="fstyle">
                                Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:
                            </td>
                            <td>
                                <asp:Label ID="lblDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    QUEUE ID&nbsp; :
                    <asp:Label CssClass="Fcolor" ID="lblQueueID" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
                </td>
            </tr>
        </table>
        <table class="style2">
            <tr>
                <td class="style11">
                    CIF
                </td>
                <td class="style8">
                    <asp:TextBox ID="txtCif" runat="server" Width="100px"></asp:TextBox>
                    &nbsp;
                </td>
                <td class="style5">
                    ชื่อสกุล
                </td>
                <td class="fstyle1">
                    <asp:Label ID="lblCifName" runat="server"></asp:Label>
                </td>
                <td class="style14">
                    สาขา/ฝ่ายงาน
                </td>
                <td class="fstyle1">
                    <asp:Label ID="lblDepartName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    หลักประกัน
                </td>
                <td class="style8">
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="sdsCollType" DataTextField="SubCollType_Name"
                        DataValueField="MysubColl_ID">
                    </asp:DropDownList>
                </td>
                <td class="style5">
                    <asp:Label ID="Label1" runat="server" Text="เลขที่/ชั้นที่"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAddno" runat="server"></asp:TextBox>
                </td>
                <td class="style14">
                    <asp:Label ID="Label2" runat="server" Text="ชื่ออาคารชุด"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtBuilding_Name" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style12">
                    ตำบล/แขวง
                </td>
                <td class="style9">
                    <asp:TextBox ID="txtTumbon" runat="server"></asp:TextBox>
                </td>
                <td class="style6">
                    อำเภอ/เขต
                </td>
                <td class="style3">
                    <asp:TextBox ID="TxtAmphur" runat="server"></asp:TextBox>
                </td>
                <td class="style15">
                    จังหวัด
                </td>
                <td class="style3">
                    <asp:DropDownList ID="ddlProvince" runat="server" DataSourceID="sdsProvince" DataTextField="PROV_NAME"
                        DataValueField="PROV_CODE">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    เนื้อที่
                </td>
                <td class="style8">
                    <cc1:mytext ID="txtRai" runat="server" AllowUserKey="int_Integer" AutoCurrencyFormatOnKeyUp="True"
                        EnableTextAlignRight="True" Width="50px" onblur="txtSizeActiveChanged();">0</cc1:mytext>
                    &nbsp;ไร่
                </td>
                <td class="style5">
                    &nbsp;
                </td>
                <td>
                    <cc1:mytext ID="txtNgan" runat="server" AllowUserKey="int_Integer" EnableTextAlignRight="True"
                        MaxLength="1" Width="50px">0</cc1:mytext>
                    &nbsp;งาน
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtNgan"
                        ErrorMessage="*" MaximumValue="4" MinimumValue="0"></asp:RangeValidator>
                </td>
                <td class="style14">
                    &nbsp;
                </td>
                <td>
                    <cc1:mytext ID="txtSquaremeter" runat="server" AllowUserKey="int_Integer" EnableTextAlignRight="True"
                        MaxLength="3" Width="50px">0</cc1:mytext>
                    &nbsp; ตรว./ตรม.<asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtSquaremeter"
                        ErrorMessage="*" MaximumValue="999" MinimumValue="0"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    ที่ตั้งหลักประกัน ตั้งอยู่ถนน
                </td>
                <td class="style8">
                    <asp:TextBox ID="txtRoad" runat="server"></asp:TextBox>
                </td>
                <td class="style5">
                    ตั้งอยู่
                </td>
                <td>
                    <asp:DropDownList ID="ddlRoad_Detail" runat="server" DataSourceID="SDSRoad_Detail"
                        DataTextField="Road_Detail_Name" DataValueField="Road_Detail_ID">
                    </asp:DropDownList>
                </td>
                <td class="style14">
                    &nbsp;
                </td>
                <td>
                    <cc1:mytext ID="txtMeter" runat="server" AllowUserKey="num_Numeric" Width="50px"
                        AutoCurrencyFormatOnKeyUp="True" EnableTextAlignRight="True">0</cc1:mytext>
                    &nbsp; เมตร
                </td>
            </tr>
            <tr>
                <td class="style11">
                    สถาพที่ดิน
                </td>
                <td class="style8">
                    <asp:DropDownList ID="ddlLand_State" runat="server" DataSourceID="SDSLand_State"
                        DataTextField="Land_State_Name" DataValueField="Land_State_Id">
                    </asp:DropDownList>
                </td>
                <td class="style5">
                    รายละเอียดสภาพที่ดิน
                </td>
                <td>
                    <asp:TextBox ID="txtLand_State_Detail" runat="server"></asp:TextBox>
                </td>
                <td class="style14">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style17">
                    ถนนหน้าหลักประกัน
                </td>
                <td class="style18">
                    <asp:DropDownList ID="ddlRoad_Forntoff" runat="server" DataSourceID="SDSRoad_Forntoff"
                        DataTextField="Road_Frontoff_Name" DataValueField="Road_Frontoff_ID">
                    </asp:DropDownList>
                </td>
                <td class="style19">
                    ผิวจราจรกว้าง
                </td>
                <td class="style20">
                    <cc1:mytext ID="txtRoadWidth" runat="server" AllowUserKey="num_Numeric" MaxLength="2"
                        Width="50px">0</cc1:mytext>
                    &nbsp;เมตร
                </td>
                <td class="style21">
                </td>
                <td class="style20">
                </td>
            </tr>
            <tr>
                <td class="style11">
                    ทำเล
                </td>
                <td class="style8">
                    <asp:DropDownList ID="ddlSite" runat="server" DataSourceID="SDSSite" DataTextField="Site_Name"
                        DataValueField="Site_ID">
                    </asp:DropDownList>
                </td>
                <td class="style5">
                    รายละเอียดทำเล
                </td>
                <td>
                    <asp:TextBox ID="txtSite_Detail" runat="server"></asp:TextBox>
                </td>
                <td class="style14">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style11">
                    สาธารณูปโภค
                </td>
                <td class="style8">
                    <asp:DropDownList ID="ddlPublic_Utility" runat="server" DataSourceID="SDSPublic_Utility"
                        DataTextField="Public_Utility_Name" DataValueField="Public_Utility_ID">
                    </asp:DropDownList>
                </td>
                <td class="style5">
                    รายละเอียดสาธารณูปโภค
                </td>
                <td>
                    <asp:TextBox ID="txtPublic_Utility_Detail" runat="server"></asp:TextBox>
                </td>
                <td class="style14">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style11">
                    การใช้ประโยชน์ในอาคาร
                </td>
                <td class="style8">
                    <asp:DropDownList ID="ddlBinifit" runat="server" DataSourceID="SDSBinifit" DataTextField="Binifit_Name"
                        DataValueField="Binifit_ID">
                    </asp:DropDownList>
                </td>
                <td class="style5">
                    รายละเอียด
                </td>
                <td>
                    <asp:TextBox ID="txtBinifit" runat="server"></asp:TextBox>
                </td>
                <td class="style14">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style11">
                    แนวโน้มความเจริญ
                </td>
                <td class="style8">
                    <asp:DropDownList ID="ddlTendency" runat="server" DataSourceID="SDSTendency" DataTextField="Tendency_Name"
                        DataValueField="Tendency_ID">
                    </asp:DropDownList>
                </td>
                <td class="style5">
                    สภาพคล่องการซื้อขาย
                </td>
                <td>
                    <asp:DropDownList ID="ddlBuySale_State" runat="server" DataSourceID="SDSBuySale_State"
                        DataTextField="BuySale_State_Name" DataValueField="BuySale_State_ID">
                    </asp:DropDownList>
                </td>
                <td class="style14">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style11">
                    สิ่งปลูกสร้าง บ้านเลขที่
                </td>
                <td class="style8">
                    <asp:TextBox ID="txtBuild_No" runat="server"></asp:TextBox>
                </td>
                <td class="style5">
                    ลักษณะอาคาร
                </td>
                <td>
                    <asp:DropDownList ID="ddlBuild_Character" runat="server" DataSourceID="SDSlBuild_Character"
                        DataTextField="Build_Character_Name" DataValueField="Build_Character_ID">
                    </asp:DropDownList>
                </td>
                <td class="style14">
                    จำนวน
                </td>
                <td>
                    <cc1:mytext ID="txtFloor" runat="server" AllowUserKey="num_Numeric" Width="50px"></cc1:mytext>
                    &nbsp; ชั้น&nbsp;
                    <asp:TextBox ID="txtItem" runat="server" Width="50px">0</asp:TextBox>
                    &nbsp; หลัง
                </td>
            </tr>
            <tr>
                <td class="style13">
                    โครงสร้างอาคาร
                </td>
                <td class="style10">
                    <asp:DropDownList ID="ddlBuild_Construct" runat="server" DataSourceID="SDSBuild_Construct"
                        DataTextField="Build_Construct_Name" DataValueField="Build_Construct_ID">
                    </asp:DropDownList>
                </td>
                <td class="style7">
                    หลังคา
                </td>
                <td class="style4">
                    <asp:DropDownList ID="ddlRoof" runat="server" DataSourceID="SDSRoof" DataTextField="Roof_Name"
                        DataValueField="Roof_ID">
                    </asp:DropDownList>
                </td>
                <td class="style16">
                    รายละเอียดเพิ่มเติม(ถ้ามี)
                </td>
                <td class="style4">
                    <asp:TextBox ID="txtRoof_Detail" runat="server"></asp:TextBox>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style11">
                    สภาพอาคาร
                </td>
                <td class="style8">
                    <asp:DropDownList ID="ddlBuild_State" runat="server" DataSourceID="SDSBuild_State"
                        DataTextField="Build_State_Name" DataValueField="Build_State_ID">
                    </asp:DropDownList>
                </td>
                <td class="style5">
                    รายละเอียดสภาพอื่น ๆ
                </td>
                <td>
                    <asp:TextBox ID="txtBuild_State_Detail" runat="server"></asp:TextBox>
                </td>
                <td class="style14">
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style11">
                    รายการที่ 1 เป็นเงิน
                </td>
                <td class="style8">
                    <cc1:mytext ID="txtPriceItem1" runat="server" AllowUserKey="num_Numeric" AutoCurrencyFormatOnKeyUp="True"
                        EnableTextAlignRight="True" onblur="GrandTotal_ActiveChanged();">0</cc1:mytext>
                </td>
                <td class="style5">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td class="style14">
                    รายการที่ 2 เป็นเงิน
                </td>
                <td>
                    <cc1:mytext ID="txtPriceItem2" runat="server" AllowUserKey="num_Numeric" EnableTextAlignRight="True"
                        AutoCurrencyFormatOnKeyUp="True" onblur="GrandTotal_ActiveChanged();">0</cc1:mytext>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    ที่ดินเนื้อที่
                </td>
                <td class="style8">
                    <asp:TextBox ID="txtSize" runat="server"></asp:TextBox>
                    ไร่
                </td>
                <td class="style5">
                    ตารางวา ละ
                </td>
                <td>
                    <cc1:mytext ID="txtPriceWah" runat="server" AllowUserKey="num_Numeric" AutoCurrencyFormatOnKeyUp="True"
                        EnableTextAlignRight="True" onblur="GrandTotal_ActiveChanged();">0</cc1:mytext>
                </td>
                <td class="style14">
                    &nbsp;เป็นเงิน
                </td>
                <td>
                    <cc1:mytext ID="txtTotal1" runat="server" AllowUserKey="num_Numeric" AutoCurrencyFormatOnKeyUp="True"
                        EnableTextAlignRight="True" onblur="GrandTotal_ActiveChanged();">0</cc1:mytext>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    สิ่งปลูกสร้าง
                </td>
                <td class="style8">
                    <asp:TextBox ID="txtBuilding_Detail" runat="server"></asp:TextBox>
                </td>
                <td class="style5">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td class="style14">
                    &nbsp;เป็นเงิน
                </td>
                <td>
                    <cc1:mytext ID="txtTotal2" runat="server" AllowUserKey="num_Numeric" AutoCurrencyFormatOnKeyUp="True"
                        EnableTextAlignRight="True" onblur="GrandTotal_ActiveChanged();">0</cc1:mytext>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    ที่ดินพร้อมสิ่งปลูกสร้าง
                </td>
                <td class="style8">
                    <asp:TextBox ID="txtLand_Build" runat="server"></asp:TextBox>
                </td>
                <td class="style5">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td class="style14">
                    &nbsp;เป็นเงิน
                </td>
                <td>
                    <cc1:mytext ID="txtTotal3" runat="server" AllowUserKey="num_Numeric" AutoCurrencyFormatOnKeyUp="True"
                        EnableTextAlignRight="True" onblur="GrandTotal_ActiveChanged();">0</cc1:mytext>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;
                </td>
                <td class="style8">
                    &nbsp;
                </td>
                <td class="style5">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td class="style14">
                    รวมราคาประเมินเบี้องต้น
                </td>
                <td>
                    <cc1:mytext ID="txtGrandTotal" runat="server" AllowUserKey="num_Numeric" AutoCurrencyFormatOnKeyUp="True"
                        EnableTextAlignRight="True">0</cc1:mytext>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;เอกสารประกอบเพิ่มเติม
                </td>
                <td class="style8">
                    <asp:CheckBox ID="chkDoc1" runat="server" Text="ใบอนุญาติปลูกสร้าง" />
                </td>
                <td class="style5">
                    <asp:CheckBox ID="chkDoc2" runat="server" Text="เรื่องทางภารจำยอม" />
                </td>
                <td>
                    &nbsp;
                </td>
                <td class="style14">
                    ระบุเอกสารอื่น
                </td>
                <td>
                    <asp:TextBox ID="txtDoc_Detail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;ผู้แจ้งราคาประเมิน
                </td>
                <td class="style8">
                    <asp:DropDownList ID="ddlUserAppraisal" runat="server" DataSourceID="SDSUserAppraisal"
                        DataTextField="UserAppraisal" DataValueField="Emp_id">
                    </asp:DropDownList>
                </td>
                <td class="style5">
                    หัวหน้ากลุ่มงานประเมินราคา
                </td>
                <td>
                    <asp:DropDownList ID="ddlBossAppraisal" runat="server" DataSourceID="SDSUserAppraisal"
                        DataTextField="UserAppraisal" DataValueField="Emp_id">
                    </asp:DropDownList>
                </td>
                <td class="style14">
                    แนบรูปภาพประเมิน
                </td>
                <td>
                    <input id="AddFileButton" onclick="wopen('FileUpload.aspx', 'popup', 500, 300); return false;"
                        type="button" value="Add File" />
                </td>
            </tr>
        </table>
    </div>
    <p id="messagearea">
    </p>
    <asp:Button ID="BtnSave" runat="server" Height="37px" Text="บันทึก" Width="185px" />
    &nbsp;<asp:Button ID="Button1" runat="server" Text="Button" Visible="False" />
    <asp:HyperLink ID="lnkXml" runat="server">View XML</asp:HyperLink>
    <asp:SqlDataSource ID="sdsCollType" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [SubCollType_Name], [MysubColl_ID] FROM [CollType_All]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsProvince" runat="server" ConnectionString="<%$ ConnectionStrings:BAYConn %>"
        SelectCommand="SELECT [PROV_CODE], [PROV_NAME] FROM [TB_PROVINCE] ORDER BY [PROV_CODE]">
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
    <asp:SqlDataSource ID="SDSDocument" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Document_ID], [Document_Name] FROM [Document]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSRoad_Detail" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Road_Detail_ID], [Road_Detail_Name] FROM [Road_Detail]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSUserAppraisal" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT Emp_id, Title + Name + '  ' + Lastname AS UserAppraisal FROM Tb_UserAppraisal">
    </asp:SqlDataSource>
    <asp:Label ID="lblCif" runat="server" Text="Label" Visible="False"></asp:Label>
    </form>
</body>
</html>
