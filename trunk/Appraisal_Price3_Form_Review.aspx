<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_Price3_Form_Review.aspx.vb" Inherits="Appraisal_Price3_Form_Review" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .bgTable
        {
            background-color:#FFFFCC;
            text-align:center;
        }
        .style4
        {
            width: 97px;
        }
        .style3
        {
            height: 22px;
        }
        .style5
        {
        }
        .style6
        {
        }
        .style7
        {
            width: 173px;
        }
        .style8
        {
            width: 252px;
        }
        .style9
        {
            width: 86px;
        }
        .style10
        {
            height: 22px;
            width: 179px;
        }
        .style11
        {
            height: 124px;
        }
        .style12
        {
            width: 296px;
        }
        .style13
        {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<br />
<br />
<%--<h5 style="text-align:center;">ธนาคารกรุงศรีอยุธยา จำกัด (มหาชน)</h5>
<h5 style="text-align:center;">รายงานทบทวนการประเมินราคาหลักประกัน</h5>--%>
<div style="text-align:center;">
    <asp:Label ID="Label1" runat="server" Text="ธนาคารกรุงศรีอยุธยา จำกัด (มหาชน)" 
        style="font-weight: 700"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" 
        Text="รายงานทบทวนการประเมินราคาหลักประกัน" style="font-weight: 700"></asp:Label>
</div>
    <table class="style1">
        <tr>
            <td class="style12">
    <asp:Label ID="Label3" runat="server" Text="เรียน"></asp:Label>
            </td>
            <td class="style13">
                <asp:Label ID="lblSubjectName" runat="server"></asp:Label>
            </td>
            <td>
                วันที่รับเรื่อง</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style12">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label4" runat="server" Text="CIF"></asp:Label>
    
            &nbsp;<asp:Label ID="lblCif" runat="server"></asp:Label>
    
            </td>
            <td class="style13">
    <asp:Label ID="Label5" runat="server" Text="ลูกค้าราย"></asp:Label>
    
            &nbsp;<asp:Label ID="lblCifName" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style12">
    <asp:Label ID="Label6" runat="server" Text="หลักประกันที่ดิน" style="font-weight: 700"></asp:Label>
    
            </td>
            <td class="style13">
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">ไม่เปลี่ยนแปลง</asp:ListItem>
                    <asp:ListItem Value="1">เปลี่ยนแปลง</asp:ListItem>
                </asp:CheckBoxList>
            </td>
            <td>
    <asp:Label ID="Label7" runat="server" Text="สาขา"></asp:Label>
    
            </td>
            <td>
                <asp:Label ID="lblBranchName" runat="server"></asp:Label>
            </td>
            <td>
                วันที่ประเมิน</td>
            <td>
                <asp:TextBox ID="txtReceive_Date" runat="server" Width="112px"></asp:TextBox><ajaxToolkit:CalendarExtender
                    ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtReceive_Date">
                </ajaxToolkit:CalendarExtender>
                <span style="color: Red">*</span>
            </td>
        </tr>
        <tr>
            <td class="style12">
                &nbsp;</td>
            <td class="style13">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style12">
    <asp:Label ID="Label8" runat="server" Text="ภาระผูกพัน" style="font-weight: 700"></asp:Label>
    
            </td>
            <td class="style13">
                <asp:CheckBoxList ID="CheckBoxList2" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">ไม่เปลี่ยนแปลง</asp:ListItem>
                    <asp:ListItem Value="1">เปลี่ยนแปลง</asp:ListItem>
                </asp:CheckBoxList>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style12">
    <asp:Label ID="Label9" runat="server" Text="ที่ตั้งและสภาพที่ดิน" style="font-weight: 700"></asp:Label>
    
            </td>
            <td class="style13">
                <asp:CheckBoxList ID="CheckBoxList3" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">ไม่เปลี่ยนแปลง</asp:ListItem>
                    <asp:ListItem Value="1">เปลี่ยนแปลง</asp:ListItem>
                </asp:CheckBoxList>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style12">
    <asp:Label ID="Label10" runat="server" Text="ฝังเมืองรวม" style="font-weight: 700"></asp:Label>
    
            </td>
            <td class="style13" colspan="5">
                ที่ดินอยู่ในเขตพื้นที่สี
                <asp:DropDownList ID="ddlAreaColur" runat="server" 
                        DataSourceID="SDSArea_Color" DataTextField="AreaColour_Name" 
                        DataValueField="AreaColour_No" BackColor="#FFFF66">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style12">
    <asp:Label ID="Label11" runat="server" Text="แนวโน้มความเจริญ" style="font-weight: 700"></asp:Label>
    
            </td>
            <td class="style13">
                <asp:CheckBoxList ID="CheckBoxList4" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">ไม่เปลี่ยนแปลง</asp:ListItem>
                    <asp:ListItem Value="1">เปลี่ยนแปลง</asp:ListItem>
                </asp:CheckBoxList>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style12">
    <asp:Label ID="Label12" runat="server" Text="สิ่งปลูกสร้าง" style="font-weight: 700"></asp:Label>
    
            </td>
            <td class="style13">
                <asp:CheckBoxList ID="CheckBoxList5" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">ไม่เปลี่ยนแปลง</asp:ListItem>
                    <asp:ListItem Value="1">เปลี่ยนแปลง</asp:ListItem>
                </asp:CheckBoxList>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style12">
    <asp:Label ID="Label13" runat="server" Text="เขตการปกครอง" style="font-weight: 700"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;
    แขวง/ตำบล</td>
            <td class="style13">
                <asp:Label ID="lblDistrict" runat="server"></asp:Label>
            </td>
            <td>
                เขต/อำเภอ</td>
            <td>
                <asp:Label ID="lblAmphur" runat="server"></asp:Label>
            </td>
            <td>
                จังหวัด</td>
            <td>
                <asp:Label ID="lblProvinceName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style12">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label14" runat="server" Text="สภาพการตกแต่ง"></asp:Label>
            </td>
            <td class="style13">
                <asp:CheckBoxList ID="CheckBoxList6" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">ตกแต่งพร้อมอยู่</asp:ListItem>
                    <asp:ListItem Value="1">ตกแต่งบางส่วน</asp:ListItem>
                    <asp:ListItem Value="2">ไม่ตกแต่ง</asp:ListItem>
                </asp:CheckBoxList>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="6">
                <table class="style1" border="1px" style="font-size:small;">
                    <tr class="bgTable">
                        <td rowspan="2" valign="top">
                            รายการสิ่งปลูกสร้าง</td>
                        <td rowspan="2" valign="top">
                            พื้นที่<br />
                            (ตรม.)</td>
                        <td colspan="2">
                            ราคาต้นทุนทดแทนใหม่</td>
                        <td rowspan="2" valign="top">
                            อายุการ<br />
                            ใช้งาน(ปี)</td>
                        <td rowspan="2" valign="top" class="style4">
                            ค่าเสื่อม(ปี)</td>
                        <td colspan="2">
                            ปรับค่าเสื่อมตามสภาพ</td>
                        <td rowspan="2" valign="top">
                            รวมค่าเสื่อม<br />
                            %</td>
                        <td rowspan="2" valign="top">
                            รวมค่าเสื่อม<br />
                            (บาท)</td>
                        <td rowspan="2" valign="top">
                            ราคาตามสภาพ<br />
                            ปัจจุบัน(บาท)</td>
                    </tr>
                    <tr class="bgTable">
                        <td class="style3" valign="top">
                            ต่อหน่วย</td>
                        <td class="style3" valign="top">
                            มูลค่า(บาท)</td>
                        <td class="style3" valign="top">
                            ปรับปรุง</td>
                        <td class="style3" valign="top">
                            เสื่อมโทรม</td>
                    </tr>
                    <tr>
                        <td>
                            1.<asp:Label ID="lblBuildingFloors" runat="server"></asp:Label>
                        &nbsp;ชั้น</td>
                        <td align="center">
                            <asp:Label ID="lblArea" runat="server"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblUnitPrice" runat="server"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblCostPrice" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblAge" runat="server"></asp:Label>
                        </td>
                        <td align="center" class="style4">
                            <asp:Label ID="lblYearDamage" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblAdap" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblDecadent" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblP_Damage" runat="server"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblDamageBth" runat="server"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Label ID="lbltotalPrice" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td class="style4">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            2.ส่วนต่อเติม</td>
                        <td align="center">
                            <asp:Label ID="lblArea1" runat="server"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblUnitPrice1" runat="server"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblCostPrice1" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblAge1" runat="server"></asp:Label>
                        </td>
                        <td class="style4" align="center">
                            <asp:Label ID="lblYearDamage1" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblAdap1" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblDecadent1" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblP_Damage1" runat="server"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblDamageBth1" runat="server"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Label ID="lbltotalPrice1" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td class="style4">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td align="right">
                            <asp:Label ID="lblGrandTotal" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td class="style4">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="6">
    <asp:Label ID="Label15" runat="server" Text="ภาวะแวดล้อมกับผลกระทบ" 
                    style="font-weight: 700"></asp:Label>
    &nbsp;
    <asp:Label ID="Label16" runat="server" 
                    Text="การตรวจสอบปัญหาภาวะแวดล้อมใกล้เคียงเท่าที่สามารถตรวจสอบได้ ณ วันสำรวจ"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5" colspan="6">
                <asp:CheckBox ID="ChkProblem" runat="server" Text="ไม่มีปัญหา" 
                    BackColor="#FFFF66" />&#160;<asp:Label
                    ID="Label49" runat="server" Text="(ถ้ามีอธิบายเพิ่มเติม) "></asp:Label>
                      <asp:TextBox  ID="txtProblem_Detail" runat="server" Width="450px" 
                    BackColor="#FFFF66"></asp:TextBox>                  
            &nbsp; </td>
        </tr>
        <tr>
            <td class="style12">
    <asp:Label ID="Label18" runat="server" Text="การประเมินราคา" style="font-weight: 700"></asp:Label>
    &nbsp;ข้อมูลซื้อขาย</td>
            <td class="style6" colspan="5">
                <asp:TextBox ID="txtBuy_Sale_Comment" runat="server" Height="80px" TextMode="MultiLine"
                    Width="716px" BackColor="#FFFF66"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style12">
                <asp:Label ID="Label52" runat="server" Font-Bold="True" Text="วิธีการประเมินราคา"></asp:Label>
            </td>
            <td class="style13" colspan="5">
                <asp:DropDownList ID="ddlAppraisal_Type" runat="server" CssClass="txtDoPrint" 
                    DataSourceID="SDSAppraisal_Type" DataTextField="App_Type_Name" 
                    DataValueField="App_Type_ID" BackColor="#FFFF66">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style5" colspan="6">
                <table width="100%">
        <tr>
            <td class="style8">
                &nbsp;</td>
            <td class="style10">
                &nbsp;</td>
            <td class="style9">
            </td>
            <td class="style6">
                &nbsp;</td>
            <td class="style7">
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style8">
                <asp:Label ID="Label53" runat="server" Text="ที่ดิน เนื้อที่"></asp:Label>
            </td>
            <td class="style10">
                <asp:Label ID="lblSize" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style9">
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
            <td class="style8">
                <asp:Label ID="Label56" runat="server" Text="สิ่งปลูกสร้าง"></asp:Label>
            </td>
            <td class="style10">
                <asp:Label ID="lblBuilding_Detail" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style9">
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
            <td class="style8">
                <asp:Label ID="Label48" runat="server" Text="ที่ดินพร้อมสิ่งปลูกสร้าง"></asp:Label>
            </td>
            <td class="style10">
                <asp:Label ID="lblLand_Build" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style9">
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
            <td class="style8">
                <asp:Label ID="Label61" runat="server" Font-Bold="True" 
                    Text="สรุปผลการประเมินราคา"></asp:Label>
            </td>
            <td class="style10">
            </td>
            <td class="style9">
            </td>
            <td class="style6">
                &nbsp;</td>
            <td class="style7">
                &nbsp;</td>
            <td>
                <asp:Label ID="lblGrantotalAll" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
        </tr>
    </table>
            </td>
        </tr>
        <tr>
            <td class="style12">
                &nbsp;</td>
            <td class="style13">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style12">
                <asp:Label ID="Label62" runat="server" Text="ราคาประเมินครั้งล่าสุด"></asp:Label>
            </td>
            <td class="style13">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style12">
                <asp:Label ID="Label63" runat="server" Text="COMMENT"></asp:Label>
            </td>
            <td class="style13">
                <asp:DropDownList ID="ddlComment" runat="server" DataSourceID="SDSComment" 
                    DataTextField="Comment_Name" DataValueField="Comment_ID" 
                    BackColor="#FFFF66">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style12">
                <asp:Label ID="Label64" runat="server" Text="WARNING"></asp:Label>
            </td>
            <td class="style13">
                <asp:DropDownList ID="ddlWarning" runat="server" DataSourceID="SDSWarning" 
                    DataTextField="Warning_Name" DataValueField="Warning_ID" 
                    BackColor="#FFFF66">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style12">
                &nbsp;</td>
            <td class="style13">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5" colspan="6">
            
    <table width="100%">
        <tr>
            <td valign="top" class="style11">
                </td>
            <td class="style11" align="right">
                <table class="style2">
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
                            <asp:Label ID="Label79" runat="server" Text="ลงชื่อ"></asp:Label>
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
                            <asp:Label ID="lblAppraisalName" runat="server" Width="200px"></asp:Label>
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
            <td colspan="2" align="center">
                <table class="style2" width="100%">
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
            
            </td>
        </tr>
        <tr>
            <td class="style12">
                &nbsp;</td>
            <td class="style13">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
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
    
    <asp:SqlDataSource ID="SDSArea_Color" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        
        
        SelectCommand="SELECT [AreaColour_No], [AreaColour_Name] FROM [AreaColour]">
    </asp:SqlDataSource>
    
</asp:Content>

