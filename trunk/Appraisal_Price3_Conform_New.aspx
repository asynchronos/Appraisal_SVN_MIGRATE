<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_Price3_Conform_New.aspx.vb" Inherits="Appraisal_Price3_Conform_New" Culture="th-TH" uiCulture="th-TH" %>

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
        .DonotDisplay
        { 
            display:none;
        }
    </style>
    <style type="text/css">
        .style1
        {
            width: 39px;
        }
        .style4
        {
            width: 75px;
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
            width: 244px;
        }
        .style11
        {
            width: 290px;
        }
        .style12
        {
            width: 204px;
        }
        .style13
        {
            width: 201px;
        }
        .style14
        {
            width: 95px;
        }
        .style15
        {
            width: 186px;
        }
        .style16
        {
            width: 511px;
        }
        .style17
        {
            width: 312px;
        }
        .style22
        {
            width: 24px;
        }
        .style23
        {
            width: 87px;
        }
        .style26
        {
            width: 21px;
        }
        .style27
        {
            width: 132px;
        }
        .style28
        {
            width: 119px;
        }
        .style29
        {
            width: 10px;
        }
        .style30
        {
        }
        .style31
        {
            width: 144px;
        }
        .setdropdownlist
        {
          text-align:center;
          vertical-align:middle;
        }        
        .style32
        {
            width: 157px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <asp:HiddenField ID="hdfChkColl" runat="server" />
     <asp:ScriptManager ID="ScriptManager1" runat="server" 
        EnableScriptGlobalization="True">
    </asp:ScriptManager>   
<asp:Panel ID="Panel1" runat="server">
    <br />
    <br />
    <table width="100%">
        <tr>
            <td colspan="5" style="text-align:center;">
                <img alt="BayLogo" src="Images/logo_bank.jpg" 
                    style="width: 344px; height: 89px" /></td>
        </tr>
        <tr>
            <td colspan="5" 
                style="text-align:center; border-bottom-style: double; border-bottom-width: thin; border-bottom-color: #000000;">
                <asp:Label ID="lblDescript1" runat="server" 
                    Text="รายงานการประเมินราคาหลักประกัน" 
                    style="font-weight: 700; font-size: x-large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="txtDoPrint">
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
                <asp:Label ID="Label1" runat="server" Font-Size="Large" 
                    style="font-weight: 700" Text="เรียน"></asp:Label>
            </td>
            <td class="txtDoPrint">
                <asp:TextBox ID="txtInform_To" runat="server" style="font-weight: 700" 
                    Width="350px"></asp:TextBox>
            </td>
            <td>
                AID</td>
            <td>
                <asp:TextBox ID="txtAID" runat="server"></asp:TextBox>
            </td>
            <td>
                <table class="NotshowOnPrint">
                    <tr>
                        <td>
                            <asp:Button ID="btnEditPosition" runat="server" Text="แก้ไขพิกัด" 
                                Height="26px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td class="style15">
                <asp:Label ID="Label3" runat="server" Text="ผู้ขอสินเชื่อ" Font-Size="Large" 
                    style="font-weight: 700"></asp:Label>
            </td>
            <td class="style14">
                <span style="color: Red">
                    <asp:Label ID="lblCifName" runat="server" Width="220px" 
                    style="font-weight: 700; color: #000000"></asp:Label></span>
            </td>
            <td class="style13">
                <asp:Label ID="Label2" runat="server" Text="Cif" style="font-weight: 700"></asp:Label>
                &nbsp; <asp:TextBox ID="txtCif" runat="server" Width="100px" 
                    style="font-weight: 700"></asp:TextBox>
            </td>
            <td class="style9">
                <asp:Label ID="Label4" runat="server" Text="วันที่รับเรื่อง" 
                    style="font-weight: 700"></asp:Label>
                <span style="color: Red">
                &nbsp;<asp:TextBox ID="txtReceive_Date" runat="server" Width="80px"></asp:TextBox><ajaxToolkit:CalendarExtender
                    ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtReceive_Date">
                </ajaxToolkit:CalendarExtender>
                *</span></td>
            <td class="style12">

                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style15">
    <asp:Label ID="Label80" runat="server" Text="สาขา/ฝ่ายงาน" Font-Bold="True" 
                    Font-Size="Large"></asp:Label>
    
            </td>
            <td class="style14">
                <asp:DropDownList ID="ddlBranch" runat="server" DataSourceID="sdsBranch" 
                    DataTextField="BRANCH_T" DataValueField="ID_BRANCH" 
                    style="margin-left: 0px; font-weight: 700;">
                </asp:DropDownList>
            </td>
            <td class="style13">

            </td>
            <td class="style9">
                <asp:Label ID="Label79" runat="server" Text="วันที่ประเมิน" 
                    style="font-weight: 700"></asp:Label>
                <asp:TextBox ID="txtAppraisal_Date" runat="server" Width="80px"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtAppraisal_Date">
                </ajaxToolkit:CalendarExtender>
                <span style="color: Red">*</span></td>
            <td class="style12">

                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style15">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="หลักประกันที่ดิน"></asp:Label>
            </td>
            <td class="style14">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style17" colspan="6">
                <asp:Label ID="lblDetail1" runat="server" Width="1100px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17" colspan="6">
                <asp:Label ID="lblDetail2" runat="server" Width="1100px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17" colspan="6">
                <asp:Label ID="lblDetail3" runat="server" Width="1100px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17" colspan="6">
                <asp:Label ID="lblDetail4" runat="server" Width="1100px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17" colspan="6">
                <asp:Label ID="lblDetail5" runat="server" Width="1100px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style15">
                <asp:Label ID="Label22" runat="server" Text="ที่ตั้งและสภาพที่ดิน" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17" colspan="6">
                <asp:Label ID="lblLandDetail1" runat="server" Width="1100px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17" colspan="6">
                <asp:Label ID="lblLandDetail2" runat="server" Width="1100px"></asp:Label>
                </td>
        </tr>
        <tr>
            <td class="style17" colspan="6">
                <asp:Label ID="lblLandDetail3" runat="server" Width="1100px"></asp:Label>
                </td>
        </tr>
        <tr>
            <td class="style17" colspan="6">
                <asp:Label ID="lblLandDetail4" runat="server" Width="1100px"></asp:Label>
                </td>
        </tr>
        <tr>
            <td class="style17" colspan="6">
                <asp:Label ID="lblLandDetail5" runat="server" Width="1100px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17" colspan="6">
                <asp:Label ID="lblLandDetail6" runat="server" Width="1100px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17" colspan="6">
                <asp:Label ID="lblLandDetail7" runat="server" Width="1100px"></asp:Label>
                </td>
        </tr>
        <tr>
            <td class="style17" colspan="6">
                <asp:Label ID="lblLandDetail8" runat="server" Width="1100px"></asp:Label>
                </td>
        </tr>
        <tr>
            <td class="style17" colspan="6">
                <asp:Label ID="lblLandDetail9" runat="server" Width="1100px" 
                    style="margin-left: 0px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17" colspan="6">
                <asp:Label ID="lblLandDetail11" runat="server" style="margin-left: 0px" 
                    Width="1100px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17" colspan="6">
                <asp:Label ID="lblLandDetail10" runat="server" style="margin-left: 0px" 
                    Width="1100px"></asp:Label>
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
                <asp:DropDownList ID="ddlProblem" runat="server" BackColor="#FFFF66" 
                    DataSourceID="sdsProblem" DataTextField="Problem_Name" 
                    DataValueField="Problem_Id">
                </asp:DropDownList>
                &#160;<asp:Label
                    ID="Label49" runat="server" Text="(ถ้ามีอธิบายเพิ่มเติม) "></asp:Label>
                      <asp:TextBox  ID="txtProblem_Detail" runat="server" Width="450px" 
                    BackColor="#FFFF66"></asp:TextBox>                  
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label50" runat="server" Font-Bold="True" Text="การประเมินราคา"></asp:Label>&#160;<asp:Label
                    ID="Label51" runat="server" Text="ข้อมูลการซื้อขาย"></asp:Label><br />
                <asp:TextBox ID="txtBuy_Sale_Comment" runat="server" Height="90px" TextMode="MultiLine"
                    Width="800px" BackColor="#FFFF66" style="font-size: large"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td class="style11">
                <asp:Label ID="Label52" runat="server" Font-Bold="True" Text="วิธีการประเมินราคา"></asp:Label>
            </td>
            <td class="style31">
                <asp:DropDownList ID="ddlAppraisal_Type" runat="server" CssClass="txtDoPrint" 
                    DataSourceID="SDSAppraisal_Type" DataTextField="App_Type_Name" 
                    DataValueField="App_Type_ID" BackColor="#FFFF66" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td class="style32">
            </td>
            <td class="style30">
                &nbsp;</td>
            <td class="style7">
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="lblCollName" runat="server"></asp:Label>
                &nbsp;</td>
            <td class="style31">
                <asp:Label ID="lblSize" runat="server" Style="color: #FF0000" Width="100px"></asp:Label>
            </td>
            <td class="style32">
                <asp:Label ID="lblSubUnit" runat="server" Width="135px"></asp:Label>&nbsp;
            </td>
            <td class="style30">
                <asp:Label ID="lblPriceWah" runat="server" Style="color: #FF0000"></asp:Label>
                &nbsp;บาท</td>
            <td class="style7">
                <asp:Label ID="Label55" runat="server" Text="เป็นเงิน"></asp:Label>
            </td>
            <td>
                                  <cc1:mytext ID="txtLandTotal" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" Width="120px" BackColor="#FFFF66" AutoPostBack="True" 
                                      AutoCurrencyFormatOnKeyUp="True">0.00</cc1:mytext>
                                  &nbsp;บาท</td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="Label56" runat="server" Text="สิ่งปลูกสร้าง"></asp:Label>
            </td>
            <td class="style31">
                <asp:Label ID="lblBuilding_Detail" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style32">
                <asp:Label ID="lblSubUnit0" runat="server" Width="135px"></asp:Label>
            </td>
            <td class="style30">
                &nbsp;</td>
            <td class="style7">
                <asp:Label ID="Label57" runat="server" Text="เป็นเงิน"></asp:Label>
            </td>
            <td>
                                  <cc1:mytext ID="txtBuildingPrice" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" Width="120px" BackColor="#FFFF66" AutoPostBack="True" 
                                      AutoCurrencyFormatOnKeyUp="True">0.00</cc1:mytext>
                                  &nbsp;บาท</td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="Label48" runat="server" Text="ที่ดินพร้อมสิ่งปลูกสร้าง"></asp:Label>
            </td>
            <td class="style31">
                <asp:Label ID="lblLand_Build" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style32">
                <asp:Label ID="lblSubUnit1" runat="server" Width="135px"></asp:Label>
            </td>
            <td class="style30">
                <asp:Label ID="lblTotal3" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style7">
                <asp:Label ID="Label60" runat="server" Text="เป็นเงิน"></asp:Label>
            </td>
            <td>
                                  <cc1:mytext ID="txtSubTotal" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" Width="120px" BackColor="#FFFF66" AutoPostBack="True" 
                                      AutoCurrencyFormatOnKeyUp="True">0.00</cc1:mytext>
                                  &nbsp;บาท</td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td class="style31">
                &nbsp;</td>
            <td class="style32">
                &nbsp;</td>
            <td class="style30">
                &nbsp;</td>
            <td class="style7">
                <asp:Label ID="Label81" runat="server" Text="รวมเป็นเงิน"></asp:Label>
            </td>
            <td>
                <cc1:mytext ID="txtGrandTotal" runat="server" AllowUserKey="num_Numeric" 
                    AutoCurrencyFormatOnKeyUp="True" AutoPostBack="True" BackColor="#FFFF66" 
                    EnableTextAlignRight="True" Width="120px">0.00</cc1:mytext>
                &nbsp;บาท</td>
        </tr>
        <tr>
            <td class="style11">
            </td>
            <td class="style31">
            </td>
            <td class="style32">
            </td>
            <td class="style30" colspan="3">
                <asp:Label ID="lblThaiBaht" runat="server"></asp:Label>
            </td>
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
            <td valign="top" class="style16">
                <asp:TextBox ID="txtWarning_Detail" runat="server" Height="80px" TextMode="MultiLine"
                    Width="500px" BackColor="#FFFF66" style="font-size: large"></asp:TextBox>
            </td>
            <td align="left">
                <table width="100%">
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
                        <td>
                            <asp:DropDownList ID="ddlUserAppraisal" runat="server" 
                                DataSourceID="SDSUserAppraisal" DataTextField="UserAppraisal" 
                                DataValueField="Emp_id" Width="200px" style="color:red;font-weight:bold;text-align:center;" >
                            </asp:DropDownList>                            
                        </td>
                        <td>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="style8">
                            &#160;&#160;
                        </td>
                        <td class="style4" align="center">
                            &nbsp;</td>
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
            <td align="center" colspan="2" 
                style="border-top-style: solid; border-top-width: thin; border-top-color: #000000">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="Label69" runat="server" Style="font-weight: 700" 
                    Text="ความเห็นคณะอนุกรรมพิจารณาการประเมินมูลค่าสินทรัพย์ภายใน"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="style22">
                            <asp:Label ID="Label70" runat="server" Text="1.)"></asp:Label>
                        </td>
                        <td class="style28">
                            &nbsp;</td>
                        <td class="style29">
                            <asp:Label ID="Label71" runat="server" Text="2.)"></asp:Label>
                        </td>
                        <td class="style27">
                            &nbsp;</td>
                        <td class="style26">
                            <asp:Label ID="Label72" runat="server" Text="3.)"></asp:Label>
                        </td>
                        <td class="style23">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style22">
                        
                        </td>
                        <td class="style28">
                        
                        </td>
                        <td class="style29">
                        
                        </td>
                        <td class="style27">
                        </td>
                        <td class="style26">
                        </td>
                        <td class="style23">

                        </td>
                    </tr>                    
                    <tr>
                        <td class="style22">
                            .</td>
                        <td class="style28" 
                            style="border-bottom-style: dotted; border-bottom-width: thin; border-bottom-color: #000000;">
                            &nbsp;</td>
                        <td class="style29">
                            .</td>
                        <td class="style27" 
                            style="border-bottom-style: dotted; border-bottom-width: thin; border-bottom-color: #000000;">
                            &nbsp;</td>
                        <td class="style26">
                            .</td>
                        <td class="style23" 
                            style="border-bottom-style: dotted; border-bottom-width: thin; border-bottom-color: #000000;">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style22">
                            &#160;&#160;
                        </td>
                        <td class="style28">
                            &nbsp;</td>
                        <td class="style29">
                            &#160;&#160;
                        </td>
                        <td class="style27">
                            &nbsp;</td>
                        <td class="style26">
                            &#160;&#160;
                        </td>
                        <td class="style23">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style22">
                            &#160;&#160;
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlApprove1" runat="server" BackColor="#FFFF66" 
                                DataSourceID="sdsSubCommittee" DataTextField="SubCommittee_Name" 
                                DataValueField="SubCommittee_ID">
                            </asp:DropDownList>
                        </td>
                        <td class="style29">
                            &#160;&#160;
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlApprove2" runat="server" BackColor="#FFFF66" 
                                DataSourceID="sdsSubCommittee" DataTextField="SubCommittee_Name" 
                                DataValueField="SubCommittee_ID">
                            </asp:DropDownList>
                        </td>
                        <td class="style26">
                            &#160;&#160;
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlApprove3" runat="server" BackColor="#FFFF66" 
                                DataSourceID="sdsSubCommittee" DataTextField="SubCommittee_Name" 
                                DataValueField="SubCommittee_ID">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style22">
                            &#160;&#160;
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlPos_Approve1" runat="server" BackColor="#FFFF66" 
                                DataSourceID="sdsPosition_Approve" DataTextField="Position_Name" 
                                DataValueField="Position_Id" style="font-weight:bold;text-align:center;">
                            </asp:DropDownList>
                        </td>
                        <td class="style29">
                            &#160;&#160;
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlPos_Approve2" runat="server" BackColor="#FFFF66" 
                                DataSourceID="sdsPosition_Approve" DataTextField="Position_Name" 
                                DataValueField="Position_Id" style="font-weight:bold;text-align:center;">
                            </asp:DropDownList>
                        </td>
                        <td class="style26">
                            &#160;&#160;
                        </td>
                        <td align="center" >
                            <asp:DropDownList ID="ddlPos_Approve3" runat="server" BackColor="#FFFF66" 
                                DataSourceID="sdsPosition_Approve" DataTextField="Position_Name" 
                                DataValueField="Position_Id" style="font-weight:bold;text-align:center;">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style22">
                        
                        </td>
                        <td class="style28">
                        
                            &nbsp;</td>
                        <td class="style29">
                        
                        </td>
                        <td class="style27">
                            &nbsp;</td>
                        <td class="style26">
                        </td>
                        <td class="style23">

                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="6"  align="center">
                        
                <table class="NotshowOnPrint">
                    <tr>
                        <td>
                            <asp:ImageButton ID="ImageSave" runat="server" ImageUrl="~/Images/Save.jpg" Width="35px" Height="35px"/>
                        </td>
                        <td class="style1">
                            <asp:Label ID="lblSave" runat="server" Text="SAVE"></asp:Label>
                        </td>
                        <td>
                           <asp:ImageButton ID="ImagePrint" runat="server" ImageUrl="~/Images/Printer.png" Width="35px" Height="35px" />
                                                        
                        </td>
                        <td>Print</td>
                        <td>
                            <asp:ImageButton ID="ImgAttach" runat="server" ImageUrl="~/Images/attachment.ico" Width="35px" Height="35px" />
                        </td>
                        <td>แนบไฟล์</td>
                    </tr>
               </table>
                        
                        </td>
                    </tr>
                </table>
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
    <asp:SqlDataSource ID="sdsSubCommittee" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        
        
        SelectCommand="SELECT [SubCommittee_ID], [SubCommittee_Name] FROM [TB_SubCommittee] ORDER BY [SubCommittee_Name]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsProblem" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="SELECT [Problem_Id], [Problem_Name] FROM [TB_Problem]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsPosition_Approve" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="SELECT [Position_Id], [Position_Name] FROM [TB_POSITION_APPROVE]">
    </asp:SqlDataSource>
</asp:Panel>

        
</asp:Content>

