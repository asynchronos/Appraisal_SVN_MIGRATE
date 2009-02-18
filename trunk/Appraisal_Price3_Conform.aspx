<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Appraisal_Price3_Conform.aspx.vb" Inherits="Appraisal_Price3_Conform" UICulture="th-TH" Culture="th-TH" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="Mytextbox" Namespace="Mytextbox" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="CSS/print.css" rel="stylesheet" type="text/css" media="print" />
    <style type="text/css" media="print">
        .style1
        {
            width: 205px;
        }
        .style2
        {
            width: 472px;
        }
        .style3
        {
            width: 259px;
        }
        .style4
        {
            width: 164px;
        }
        .style5
        {
            width: 97px;
        }
        .style6
        {
            width: 144px;
        }
        .style7
        {
            width: 153px;
        }
        .style8
        {
            width: 57px;
        }
        .style9
        {
            width: 230px;
        }
        .style10
        {
            width: 215px;
        }
        .style13
        {
            width: 141px;
        }
        .style16
        {
            width: 239px;
        }
        .style17
        {
            width: 374px;
        }
        .NotshowOnPrint
        {
            display:none;
        }
    </style>
    <style type="text/css">
        .style1
        {
            width: 39px;
        }
        .style2
        {
            width: 473px;
        }
        .style3
        {
            width: 62px;
        }
        .style4
        {
            width: 75px;
        }
        .style5
        {
            width: 80px;
        }
        .style6
        {
            width: 84px;
        }
        .style7
        {
            width: 89px;
        }
        .style8
        {
            width: 92px;
        }
        .style9
        {
            width: 214px;
        }
        .style10
        {
            width: 103px;
        }
        .style11
        {
            width: 319px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" 
        EnableScriptGlobalization="True">
    </asp:ScriptManager>
    <br />
    <br />
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="เรียน"></asp:Label>
            </td>
            <td class="txtDoPrint">
                <asp:TextBox ID="txtInform_To" runat="server" Width="350px"></asp:TextBox>
            </td>
            <td>AID</td>
            <td>
                <asp:TextBox ID="txtAID" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td class="style17">
                <asp:Label ID="Label3" runat="server" Text="ผู้ขอสินเชื่อ"></asp:Label>
            </td>
            <td class="style16">
                <span style="color: Red">
                    <asp:Label ID="lblCifName" runat="server"></asp:Label></span>&#160;
            </td>
            <td class="style13">
                <asp:Label ID="Label2" runat="server" Text="Cif"></asp:Label>
                &nbsp;<asp:TextBox ID="txtCif" runat="server" Width="100px"></asp:TextBox>
            </td>
            <td class="style9">
                <asp:Label ID="Label4" runat="server" Text="วันที่รับเรื่อง"></asp:Label>
                <span style="color: Red">
                <asp:TextBox ID="txtReceive_Date" runat="server" Width="100px"></asp:TextBox><ajaxToolkit:CalendarExtender
                    ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtReceive_Date">
                </ajaxToolkit:CalendarExtender>
                *</span></td>
            <td class="style10">

                <asp:Label ID="Label79" runat="server" Text="วันที่ประเมิน"></asp:Label>

                </td>
            <td>
                <asp:TextBox ID="txtAppraisal_Date" runat="server" Width="100px"></asp:TextBox>
                <ajaxToolkit:CalendarExtender
                    ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtAppraisal_Date">
                </ajaxToolkit:CalendarExtender>
                <span style="color: Red">*</span>
            </td>
        </tr>
        <tr>
            <td class="style17">
    <asp:Label ID="Label80" runat="server" Text="สาขา/ฝ่ายงาน"></asp:Label>
    
            </td>
            <td class="style16">
                <asp:DropDownList ID="ddlBranch" runat="server" DataSourceID="sdsBranch" 
                    DataTextField="BRANCH_T" DataValueField="ID_BRANCH" style="margin-left: 0px">
                </asp:DropDownList>
            </td>
            <td class="style13">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td class="style10">

                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style17">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="หลักประกันที่ดิน"></asp:Label>
            </td>
            <td class="style16">
                <asp:Button ID="btnEditPosition" runat="server" Text="แก้ไขพิกัด" />
            </td>
        </tr>
        <tr>
            <td class="style17">
                <asp:Label ID="Label6" runat="server" Text="โฉนดที่ดิน เลขที่"></asp:Label>
            </td>
            <td class="style16">
                <asp:Label ID="lblChanode_No" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style13">
                <asp:Label ID="Label7" runat="server" Text="ระวาง"></asp:Label>
            </td>
            <td class="style9">
                <asp:Label ID="lblRaWang" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style10">
                <asp:Label ID="Label8" runat="server" Text="เลขที่ดิน"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblLandNumber" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17">
                <asp:Label ID="Label9" runat="server" Text="หน้าสำรวจ"></asp:Label>
            </td>
            <td class="style16">
                <asp:Label ID="lblSurway" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style13">
                <asp:Label ID="Label10" runat="server" Text="สารบัญเล่มที่"></asp:Label>
            </td>
            <td class="style9">
                <asp:Label ID="lblDocNo" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style10">
                <asp:Label ID="Label11" runat="server" Text="หน้า"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblPage" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17">
                <asp:Label ID="Label12" runat="server" Text="ตำบล"></asp:Label>
            </td>
            <td class="style16">
                <asp:Label ID="lblTumbon" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style13">
                <asp:Label ID="Label13" runat="server" Text="อำเภอ"></asp:Label>
            </td>
            <td class="style9">
                <asp:Label ID="lblAmphur" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style10">
                <asp:Label ID="Label14" runat="server" Text="จังหวัด"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblProvince" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17">
                <asp:Label ID="Label16" runat="server" Text="เนื่อที่จำนวนไร่"></asp:Label>
            </td>
            <td class="style16">
                <asp:Label ID="lblRai" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style13">
                <asp:Label ID="Label17" runat="server" Text="จำนวนงาน"></asp:Label>
            </td>
            <td class="style9">
                <asp:Label ID="lblNgan" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style10">
                <asp:Label ID="Label18" runat="server" Text="จำนวนตารางวา"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblWah" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17">
                <asp:Label ID="Label19" runat="server" Text="ผู้ถือกรรมสิทธิ์ที่ดิน"></asp:Label>
            </td>
            <td class="style16">
                <asp:Label ID="lblLandOwnerShip" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style13">
                <asp:Label ID="Label20" runat="server" Text="สิ่งปลูกสร้างของ"></asp:Label>
            </td>
            <td class="style9">
                <asp:Label ID="lbBuildinObligation" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style10">
                <asp:Label ID="Label21" runat="server" Text="ภาระผูกพัน"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblObligation" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17">
                <asp:Label ID="Label22" runat="server" Text="ที่ตั้งและสภาพที่ดิน" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17">
                <asp:Label ID="Label15" runat="server" Text="ตั้งอยู่ที่ถนน"></asp:Label>
            </td>
            <td class="style16">
                <asp:Label ID="lblRoad" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style13">
                การตั้งอยู่</td>
            <td class="style9">
                <asp:Label ID="lblRoadAccess_Detail" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style10">
                <asp:Label ID="Label24" runat="server" Text="ระยะประมาณ"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblMeter_Access" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17">
                <asp:Label ID="Label25" runat="server" Text="ถนนหน้าหลักประกัน"></asp:Label>
            </td>
            <td class="style16">
                <asp:Label ID="lblRoad_Forntoff" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style13">
                <asp:Label ID="Label26" runat="server" Text="กว้าง"></asp:Label>
            </td>
            <td class="style9">
                <asp:Label ID="lblRoad_Forntoff_Width" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style10">
            </td>
            <td>
                <asp:Label ID="Label27" runat="server" Text="(รายละเอียดตามแผนที่สังเขป)"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17">
                <asp:Label ID="Label28" runat="server" Text="สภาพลักษณะที่ดิน"></asp:Label>
            </td>
            <td class="style16">
                <asp:CheckBox ID="ChkLandState1" runat="server" Text="สี่เหลี่ยมผืนผ้า" />
            </td>
            <td class="style13">
                <asp:Label ID="Label29" runat="server" Text="อื่น ๆ"></asp:Label>
            </td>
            <td class="style9">
                <asp:Label ID="lblLandStateDetail" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style10">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="style17">
                <asp:Label ID="Label30" runat="server" Text="ขนาดที่ดิน  กว้างติดถนน"></asp:Label>
            </td>
            <td class="style16">
                <asp:Label ID="lblRoadWidth" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style13">
                <asp:Label ID="Label31" runat="server" Text="ลึก"></asp:Label>
            </td>
            <td class="style9">
                <asp:Label ID="lblDeepWidth" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style10">
                <asp:Label ID="Label32" runat="server" Text="ด้านหลัง"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblBehindWidth" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17">
            </td>
            <td class="style16">
            </td>
            <td class="style13">
                <asp:Label ID="Label33" runat="server" Text="อื่น ๆ"></asp:Label>
            </td>
            <td class="style9">
                &nbsp;</td>
            <td class="style10">
                <asp:Label ID="Label68" runat="server" Text="ทำเล"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblSiteName" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17">
                <asp:Label ID="Label34" runat="server" Text="สภาพและการปรับปรุงที่ดินของที่ดินกับถนน"></asp:Label>
            </td>
            <td class="style16">
                <asp:Label ID="lblLandState" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style13">
                <asp:Label ID="Label35" runat="server" Text="รายละเอียดที่ดิน"></asp:Label>
            </td>
            <td class="style9">
                <asp:Label ID="lblLandState_Detail" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style10">
                <asp:Label ID="Label36" runat="server" Text="อื่น ๆ"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtLandDetail_Other" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style17">
                <asp:Label ID="Label37" runat="server" Text="ผังเมืองรวม"></asp:Label>&#160;<asp:Label
                    ID="Label38" runat="server" Text="ที่ดินอยู่ในเขตพื้นที่สี"></asp:Label>
            </td>
            <td colspan="4">
                        <asp:Label ID="lblArea_Colour" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="style17">
                <asp:Label ID="Label39" runat="server" Text="สาธารณูปโภค"></asp:Label>
            </td>
            <td class="style16">
                <asp:Label ID="lblPublic_Utility" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style13">
                <asp:Label ID="Label40" runat="server" Text="แนวโน้มคามเจริญ"></asp:Label>
            </td>
            <td class="style9">
                <asp:Label ID="lblTendency_Name" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style10">
                <asp:Label ID="Label41" runat="server" Text="สภาพคล่องการซื้อ-ขาย"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblBuySale_StateName" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17">
                <asp:Label ID="Label42" runat="server" Font-Bold="True" Text="สิ่งปลูกสร้าง"></asp:Label>&#160;<asp:Label
                    ID="Label43" runat="server" Text="บ้านเลขที่"></asp:Label>
            </td>
            <td class="style16">
                <asp:Label ID="lblBuilding_No" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style13">
                <asp:Label ID="Label44" runat="server" Text="จำนวนหลัง"></asp:Label>
            </td>
            <td class="style9">
                <asp:Label ID="lblItem" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style10">
                <asp:Label ID="Label45" runat="server" Text="(รายละเอียดตามเอกสาร แนบ)"></asp:Label>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label46" runat="server" Font-Bold="True" Text="ภาวะแวดล้อมกับผลกระทบ"></asp:Label>&#160;<asp:Label
                    ID="Label47" runat="server" Text="(การตรวจสอบปัญหาภาวะแวดล้อมใกล้เคียงเท่าที่สามารถตรวจสอบได้ ณ วันสำรวจ)"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="ChkProblem" runat="server" Text="ไม่มีปัญหา" 
                    BackColor="#FFFF66" />&#160;<asp:Label
                    ID="Label49" runat="server" Text="(ถ้ามีอธิบายเพิ่มเติม) "></asp:Label>
                      <asp:TextBox  ID="txtProblem_Detail" runat="server" Width="450px" 
                    BackColor="#FFFF66"></asp:TextBox>                  
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label50" runat="server" Font-Bold="True" Text="การประเมินราคา"></asp:Label>&#160;<asp:Label
                    ID="Label51" runat="server" Text="ข้อมูลการซื้อขาย"></asp:Label><br />
                <asp:TextBox ID="txtBuy_Sale_Comment" runat="server" Height="80px" TextMode="MultiLine"
                    Width="800px" BackColor="#FFFF66"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td class="style11">
                <asp:Label ID="Label52" runat="server" Font-Bold="True" Text="วิธีการประเมินราคา"></asp:Label>
            </td>
            <td class="style3">
                <asp:DropDownList ID="ddlAppraisal_Type" runat="server" CssClass="txtDoPrint" 
                    DataSourceID="SDSAppraisal_Type" DataTextField="App_Type_Name" 
                    DataValueField="App_Type_ID" BackColor="#FFFF66">
                </asp:DropDownList>
            </td>
            <td class="style5">
            </td>
            <td class="style6">
                &nbsp;</td>
            <td class="style7">
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="Label53" runat="server" Text="ที่ดิน เนื้อที่"></asp:Label>
            </td>
            <td class="style3">
                <asp:Label ID="lblSize" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style5">
                <asp:Label ID="Label54" runat="server" Text="ตรว. ละ"></asp:Label>&#160;&#160;
            </td>
            <td class="style6">
                <asp:Label ID="lblPriceWah" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style7">
                <asp:Label ID="Label55" runat="server" Text="เป็นเงิน"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblLandTotal" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="Label56" runat="server" Text="สิ่งปลูกสร้าง"></asp:Label>
            </td>
            <td class="style3">
                <asp:Label ID="lblBuilding_Detail" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style5">
            </td>
            <td class="style6">
                <asp:Label ID="lblTotal2" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style7">
                <asp:Label ID="Label57" runat="server" Text="เป็นเงิน"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblBuildingPrice" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="Label48" runat="server" Text="ที่ดินพร้อมสิ่งปลูกสร้าง"></asp:Label>
            </td>
            <td class="style3">
                <asp:Label ID="lblLand_Build" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style5">
            </td>
            <td class="style6">
                <asp:Label ID="lblTotal3" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style7">
                <asp:Label ID="Label60" runat="server" Text="รวมเป็นเงิน"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblGrantotal" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style11">
            </td>
            <td class="style3">
            </td>
            <td class="style5">
            </td>
            <td class="style6">
                &nbsp;</td>
            <td class="style7">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label61" runat="server" Text="COMMENT"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlComment" runat="server" DataSourceID="SDSComment" 
                    DataTextField="Comment_Name" DataValueField="Comment_ID" 
                    BackColor="#FFFF66">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label62" runat="server" Text="WARNING"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlWarning" runat="server" DataSourceID="SDSWarning" 
                    DataTextField="Warning_Name" DataValueField="Warning_ID" 
                    BackColor="#FFFF66">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td valign="top">
                <asp:TextBox ID="txtWarning_Detail" runat="server" Height="50px" TextMode="MultiLine"
                    Width="400px" BackColor="#FFFF66"></asp:TextBox>
            </td>
            <td align="right">
                <table class="style2" width="100%">
                    <tr>
                        <td class="style8">
                            &#160;&#160;
                        </td>
                        <td class="style4">
                            &#160;&#160;
                        </td>
                        <td>
                            &#160;&#160;
                        </td>
                    </tr>
                    <tr>
                        <td class="style8">
                            <asp:Label ID="Label63" runat="server" Text="ลงชื่อ"></asp:Label>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td>
                            <asp:Label ID="Label65" runat="server" Text="ผู้ตรวจสอบประเมินราคา"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style8">
                            &#160;&#160;
                        </td>
                        <td class="style4">
                            &#160;&#160;
                        </td>
                        <td>
                            &#160;&#160;
                        </td>
                    </tr>
                    <tr>
                        <td class="style8">
                            &#160;&#160;
                        </td>
                        <td class="style4" align="center">
                    <asp:DropDownList ID="ddlUserAppraisal" runat="server" DataSourceID="SDSUserAppraisal"
                        DataTextField="UserAppraisal" DataValueField="Emp_id" Width="200px">
                    </asp:DropDownList>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td class="style8">
                            &#160;&#160;
                        </td>
                        <td class="style4">
                            <asp:Label ID="Label59" runat="server" 
                                Text="..............................................."></asp:Label>
                        </td>
                        <td>
                            &#160;&#160;<asp:Label ID="Label67" runat="server" Text="วัน / เดือน / ปี"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="Label69" runat="server" Text="ความเห็นคณะอนุกรรมพิจารณาการประเมินมูลค่าสินทรัพย์ภายใน"
                    Style="font-weight: 700"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="Label70" runat="server" Text="1.)"></asp:Label>
                        </td>
                        <td>
                            &#160;&#160;
                        </td>
                        <td>
                            <asp:Label ID="Label71" runat="server" Text="2.)"></asp:Label>
                        </td>
                        <td>
                            &#160;&#160;
                        </td>
                        <td>
                            <asp:Label ID="Label72" runat="server" Text="3.)"></asp:Label>
                        </td>
                        <td>
                            &#160;&#160;
                            <asp:Label ID="lblAppraisalName" runat="server" Width="200px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        
                        </td>
                        <td>
                        
                        </td>
                        <td>
                        
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>

                        </td>
                    </tr>                    
                    <tr>
                        <td>
                            &#160;&#160;
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &#160;&#160;
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &#160;&#160;
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &#160;&#160;
                        </td>
                        <td align="center">
                            <asp:TextBox ID="txtApprove1" runat="server" BackColor="#FFFF66" Width="170px"></asp:TextBox>
                        </td>
                        <td>
                            &#160;&#160;
                        </td>
                        <td align="center">
                            <asp:TextBox ID="txtApprove2" runat="server" BackColor="#FFFF66" 
                                Width="170px"></asp:TextBox>
                        </td>
                        <td>
                            &#160;&#160;
                        </td>
                        <td align="center">
                            <asp:TextBox ID="txtApprove3" runat="server" BackColor="#FFFF66" 
                                Width="170px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &#160;&#160;
                        </td>
                        <td align="center">
                            <asp:Label ID="Label76" runat="server" Text="อนุกรรมการ"></asp:Label>
                        </td>
                        <td>
                            &#160;&#160;
                        </td>
                        <td align="center">
                            <asp:Label ID="Label78" runat="server" Text="อนุกรรมการ"></asp:Label>
                        </td>
                        <td>
                            &#160;&#160;
                        </td>
                        <td align="center">
                            <asp:Label ID="Label77" runat="server" Text="อนุกรรมการ"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        
                        </td>
                        <td>
                        
                        </td>
                        <td>
                        
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>

                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
                <table class="NotshowOnPrint">
                    <tr>
                        <td>
                            <asp:ImageButton ID="ImageSave" runat="server" ImageUrl="~/Images/Save.jpg" Width="35px" Height="35px"/>
                        </td>
                        <td class="style1">
                            SAVE
                            </td>
                    </tr>
               </table>
    <asp:SqlDataSource ID="SDSWarning" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Warning_ID], [Warning_Name] FROM [Warning]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSComment" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Comment_ID], [Comment_Name] FROM [Comment]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSAppraisal_Type" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [App_Type_ID], [App_Type_Name] FROM [Appraisal_Type]">
    </asp:SqlDataSource>
    
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <asp:HiddenField ID="HiddenField3" runat="server" />   
    
    <asp:SqlDataSource ID="sdsBranch" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="GET_BRANCH" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    
    <asp:SqlDataSource ID="SDSUserAppraisal" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT Emp_id, Title + Name + '  ' + Lastname AS UserAppraisal FROM Tb_UserAppraisal">
    </asp:SqlDataSource>
        
</asp:Content>
