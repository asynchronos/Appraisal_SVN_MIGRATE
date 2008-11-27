<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Price3.aspx.vb" Inherits="Price3" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="Mytextbox" Namespace="Mytextbox" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>กำหนดราคาประเมินราคาที่ 3</title>
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
            width: 169px;
        }
        .style4
        {
            width: 183px;
        }
    </style>
    <%--    <script language="vbscript" type="text/vbscript">
        function document_OnKeyDown    
            if window.event.keyCode = 13 then        
                window.event.keyCode = 9    
            end ifend function
    </script>--%>

    <script language="javascript" type="text/JavaScript">
        function onKeyDown() {   
            var keycode;   
                if (window.event) keycode = window.event.keyCode;   
                if (keycode == 13) {      
                    window.event.keyCode = 9;   
                }   
                return true;
                }
                document.onkeydown = onKeyDown;
    </script>

</head>
<body style="margin-top: 0px; margin-left: 0px; margin-right: 0px;">
    <form id="form1" runat="server">

    <script language="javascript" type="text/javascript"> 
       function ActiveTabChanged(sender, e) { 
          if (sender._activeTabIndex != 0) { 
             if (($get('<%=lblCif.ClientID%>').innerHTML.length == 0) || ($get('<%=lblCifName.ClientID%>').innerHTML.length == 0)) { 
                //ถ้าเป็น Textbox ใช้  ($get('<%=lblCif.ClientID%>').value.length == 0)
                 alert("กรุณากรอกข้อมูลในส่วนแรกให้ครบ."); 
                 sender.set_activeTabIndex(0); 
             } 
         } 
        }
    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
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
    </div>
    <ajaxToolkit:TabContainer runat="server" ID="tabContainerRegister" Height="1000px"
        Width="100%" ActiveTabIndex="0" 
        OnClientActiveTabChanged="ActiveTabChanged">
        <ajaxToolkit:TabPanel runat="server" ID="tabPanelGeneral"><HeaderTemplate>ข้อมูลทั่วไป</HeaderTemplate><ContentTemplate><table><tr><td><asp:Label ID="Label1" runat="server" Text="เรียน"></asp:Label></td><td><asp:TextBox ID="TextBox1" runat="server" Width="350px"></asp:TextBox></td></tr></table><table width="100%"><tr><td><asp:Label ID="Label3" runat="server" Text="ผู้ขอสินเชื่อ"></asp:Label></td><td><span style="color: Red"><asp:Label ID="lblCifName" runat="server"></asp:Label></span>&#160; </td><td><asp:Label 
            ID="Label2" runat="server" Text="Cif"></asp:Label></td><td><asp:Label ID="lblCif" runat="server" Style="color: #FF0000"></asp:Label></td><td><asp:Label 
            ID="Label4" runat="server" Text="วันที่รับเรื่อง"></asp:Label></td><td><asp:TextBox ID="txtReceive_Date" runat="server" Width="112px"></asp:TextBox><ajaxToolkit:CalendarExtender 
                ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" 
                TargetControlID="txtReceive_Date"></ajaxToolkit:CalendarExtender><span 
                style="color: Red">*</span> </td></tr><tr><td><asp:Label ID="Label5" runat="server" Font-Bold="True" Text="หลักประกันที่ดิน"></asp:Label></td><td>&#160;&#160; </td></tr><tr><td><asp:Label ID="Label6" runat="server" Text="โฉนดที่ดิน เลขที่"></asp:Label></td><td><asp:Label ID="lblChanode_No" runat="server" Style="color: #FF0000"></asp:Label></td><td><asp:Label ID="Label7" runat="server" Text="ระวาง"></asp:Label></td><td><asp:TextBox ID="txtRaWang" runat="server"></asp:TextBox></td><td><asp:Label ID="Label8" runat="server" Text="เลขที่ดิน"></asp:Label></td><td><asp:TextBox ID="txtLandNumber" runat="server"></asp:TextBox></td></tr><tr><td><asp:Label ID="Label9" runat="server" Text="หน้าสำรวจ"></asp:Label></td><td><asp:TextBox ID="txtSurway" runat="server"></asp:TextBox></td><td><asp:Label ID="Label10" runat="server" Text="สารบัญเล่มที่"></asp:Label></td><td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td><td><asp:Label ID="Label11" runat="server" Text="หน้า"></asp:Label></td><td><asp:TextBox ID="txtPage" runat="server"></asp:TextBox></td></tr><tr><td><asp:Label ID="Label12" runat="server" Text="ตำบล"></asp:Label></td><td><asp:Label ID="lblTumbon" runat="server" Style="color: #FF0000"></asp:Label></td><td><asp:Label ID="Label13" runat="server" Text="อำเภอ"></asp:Label></td><td><asp:Label ID="lblAmphur" runat="server" Style="color: #FF0000"></asp:Label></td><td><asp:Label ID="Label14" runat="server" Text="จังหวัด"></asp:Label></td><td><asp:Label ID="lblProvince" runat="server" Style="color: #FF0000"></asp:Label></td></tr><tr><td><asp:Label ID="Label16" runat="server" Text="เนื่อที่จำนวนไร่"></asp:Label></td><td><asp:Label ID="lblRai" runat="server" Style="color: #FF0000"></asp:Label></td><td><asp:Label ID="Label17" runat="server" Text="จำนวนงาน"></asp:Label></td><td><asp:Label ID="lblNgan" runat="server" Style="color: #FF0000"></asp:Label></td><td><asp:Label ID="Label18" runat="server" Text="จำนวนตารางวา"></asp:Label></td><td><asp:Label ID="lblWah" runat="server" Style="color: #FF0000"></asp:Label></td></tr><tr><td><asp:Label ID="Label19" runat="server" Text="ผู้ถือกรรมสิทธิ์ที่ดิน"></asp:Label></td><td><asp:TextBox ID="TextBox8" runat="server"></asp:TextBox></td><td><asp:Label ID="Label20" runat="server" Text="สิ่งปลูกสร้างของ"></asp:Label></td><td><asp:TextBox ID="TextBox9" runat="server"></asp:TextBox></td><td><asp:Label ID="Label21" runat="server" Text="ภาระผูกพัน"></asp:Label></td><td><asp:TextBox ID="TextBox10" runat="server"></asp:TextBox></td></tr><tr><td><asp:Label ID="Label22" runat="server" Text="ที่ตั้งและสภาพที่ดิน" Font-Bold="True"></asp:Label></td></tr><tr><td><asp:Label ID="Label15" runat="server" Text="ตั้งอยู่ที่ถนน"></asp:Label></td><td><asp:Label ID="lblRoad" runat="server" Style="color: #FF0000"></asp:Label></td><td><asp:Label ID="Label23" runat="server" Text="แยกเข้า"></asp:Label></td><td><asp:Label ID="lblRoadAccess_Detail" runat="server" Style="color: #FF0000"></asp:Label></td><td><asp:Label ID="Label24" runat="server" Text="ระยะประมาณ"></asp:Label></td><td><asp:Label ID="lblMeter_Access" runat="server" Style="color: #FF0000"></asp:Label></td></tr><tr><td><asp:Label ID="Label25" runat="server" Text="ถนนหน้าหลักประกัน"></asp:Label></td><td><asp:Label ID="lblRoadState" runat="server" Style="color: #FF0000"></asp:Label></td><td><asp:Label ID="Label26" runat="server" Text="กว้าง"></asp:Label></td><td><asp:Label ID="lblRoadWidth" runat="server" Style="color: #FF0000"></asp:Label></td><td></td><td><asp:Label ID="Label27" runat="server" Text="(รายละเอียดตามแผนที่สังเขป)"></asp:Label></td></tr><tr><td><asp:Label ID="Label28" runat="server" Text="สภาพลักษณะที่ดิน"></asp:Label></td><td><asp:CheckBox ID="ChkLandState1" runat="server" Text="สี่เหลี่ยมผืนผ้า" /></td><td><asp:Label ID="Label29" runat="server" Text="อื่น ๆ"></asp:Label></td><td><asp:TextBox ID="txtLandState_Other" runat="server"></asp:TextBox></td><td></td><td></td></tr><tr><td><asp:Label ID="Label30" runat="server" Text="ขนาดที่ดิน  กว้างติดถนน"></asp:Label></td><td><asp:TextBox ID="txtRoadwidth" runat="server"></asp:TextBox></td><td><asp:Label ID="Label31" runat="server" Text="ลึก"></asp:Label></td><td><asp:TextBox ID="txtRoad_Access" runat="server"></asp:TextBox></td><td><asp:Label ID="Label32" runat="server" Text="ด้านหลัง"></asp:Label></td><td><asp:TextBox ID="txtLandSize_Behide" runat="server"></asp:TextBox></td></tr><tr><td></td><td></td><td><asp:Label 
            ID="Label33" runat="server" Text="อื่น ๆ"></asp:Label></td><td><asp:TextBox ID="txtlandSize_Other" runat="server"></asp:TextBox></td><td><asp:Label 
            ID="Label68" runat="server" Text="ทำเล"></asp:Label></td><td><asp:Label ID="lblSiteName" runat="server" Style="color: #FF0000"></asp:Label></td></tr><tr><td><asp:Label ID="Label34" runat="server" Text="สภาพและการปรับปรุงที่ดินของที่ดินกับถนน"></asp:Label></td><td><asp:Label ID="lblLandState" runat="server" Style="color: #FF0000"></asp:Label></td><td><asp:Label ID="Label35" runat="server" Text="รายละเอียดที่ดิน"></asp:Label></td><td><asp:Label ID="lblLandState_Detail" runat="server" Style="color: #FF0000"></asp:Label></td><td><asp:Label ID="Label36" runat="server" Text="อื่น ๆ"></asp:Label></td><td><asp:TextBox ID="txtLandDetail_Other" runat="server"></asp:TextBox></td></tr><tr><td><asp:Label ID="Label37" runat="server" Text="ผังเมืองรวม"></asp:Label>&#160;<asp:Label
                                ID="Label38" runat="server" Text="ที่ดินอยู่ในเขตพื้นที่สี"></asp:Label></td><td 
            colspan="4"><asp:DropDownList ID="DDLAreaColour" runat="server" DataSourceID="SDSArea_Colour"
                                DataTextField="AreaColour_Name" DataValueField="AreaColour_No"></asp:DropDownList></td><td></td></tr><tr><td><asp:Label ID="Label39" runat="server" Text="สาธารณูปโภค"></asp:Label></td><td><asp:Label ID="lblBenifitName" runat="server" Style="color: #FF0000"></asp:Label></td><td><asp:Label ID="Label40" runat="server" Text="แนวโน้มคามเจริญ"></asp:Label></td><td><asp:Label ID="lblTendency_Name" runat="server" Style="color: #FF0000"></asp:Label></td><td><asp:Label ID="Label41" runat="server" Text="สภาพคล่องการซื้อ-ขาย"></asp:Label></td><td><asp:Label ID="lblBuySale_StateName" runat="server" Style="color: #FF0000"></asp:Label></td></tr><tr><td><asp:Label ID="Label42" runat="server" Font-Bold="True" Text="สิ่งปลูกสร้าง"></asp:Label>&#160;<asp:Label
                                ID="Label43" runat="server" Text="บ้านเลขที่"></asp:Label></td><td><asp:Label ID="lblBuilding_No" runat="server" Style="color: #FF0000"></asp:Label></td><td><asp:Label ID="Label44" runat="server" Text="จำนวนหลัง"></asp:Label></td><td><asp:Label ID="lblItem" runat="server" Style="color: #FF0000"></asp:Label></td><td><asp:Label ID="Label45" runat="server" Text="(รายละเอียดตามสิ่งปลูกสร้าง แนบ)"></asp:Label></td><td></td></tr></table><table><tr><td><asp:Label ID="Label46" runat="server" Font-Bold="True" Text="ภาวะแวดล้อมกับผลกระทบ"></asp:Label>&#160;<asp:Label
                                ID="Label47" runat="server" Text="(การตรวจสอบปัญหาภาวะแวดล้อมใกล้เคียงเท่าที่สามารถตรวจสอบได้ ณ วันสำรวจ)"></asp:Label></td></tr><tr><td><asp:CheckBox ID="ChkProblem" runat="server" Text="ไม่มีปัญหา" />&#160;<asp:Label
                                ID="Label49" runat="server" Text="(ถ้ามีอธิบายเพิ่มเติม) "></asp:Label><asp:TextBox
                                    ID="txtProblem_Detail" runat="server" Width="450px"></asp:TextBox></td></tr><tr><td><asp:Label ID="Label50" runat="server" Font-Bold="True" Text="การประเมินราคา"></asp:Label>&#160;<asp:Label
                                ID="Label51" runat="server" Text="ข้อมูลการซื้อขาย"></asp:Label><br /><asp:TextBox ID="txtBuy_Sale_Comment" runat="server" Height="80px" TextMode="MultiLine"
                                Width="800px"></asp:TextBox></td></tr></table><table 
            width="100%"><tr><td class="style3"><asp:Label ID="Label52" runat="server" Font-Bold="True" Text="วิธีการประเมินราคา"></asp:Label></td><td><asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SDSAppraisal_Type"
                                DataTextField="App_Type_Name" DataValueField="App_Type_ID"></asp:DropDownList></td><td></td><td><asp:Label 
                    ID="lblPriceWah" runat="server" Style="color: #FF0000"></asp:Label></td><td></td><td><asp:Label 
                    ID="lblTotal1" runat="server" Style="color: #FF0000"></asp:Label></td></tr><tr><td class="style3"><asp:Label ID="Label53" runat="server" Text="ที่ดิน เนื้อที่"></asp:Label></td><td><asp:Label ID="lblSize" runat="server" Style="color: #FF0000"></asp:Label></td><td><asp:Label ID="Label54" runat="server" Text="ตรว. ละ"></asp:Label>&#160;&#160; </td><td>
                    <cc1:mytext 
                    ID="txtPriceWah" runat="server" AllowUserKey="num_Numeric" 
                        AutoCurrencyFormatOnKeyUp="True" EnableTextAlignRight="True">
                        &nbsp;0.000
                </cc1:mytext>
                </td><td><asp:Label ID="Label55" runat="server" Text="เป็นเงิน"></asp:Label></td><td>
                    <cc1:mytext ID="txtTotal1" runat="server" AllowUserKey="num_Numeric" 
                        AutoCurrencyFormatOnKeyUp="True" EnableTextAlignRight="True">
                        &nbsp;0.000
                    </cc1:mytext>
                    </td></tr><tr><td class="style3"><asp:Label ID="Label56" runat="server" Text="สิ่งปลูกสร้าง"></asp:Label></td><td><asp:Label ID="lblBuilding_Detail" runat="server" Style="color: #FF0000"></asp:Label></td><td></td><td><asp:Label 
                    ID="lblTotal2" runat="server" Style="color: #FF0000"></asp:Label></td><td><asp:Label ID="Label57" runat="server" Text="เป็นเงิน"></asp:Label></td><td>
                    <cc1:mytext ID="txtTotal2" runat="server" AllowUserKey="num_Numeric" 
                        AutoCurrencyFormatOnKeyUp="True" EnableTextAlignRight="True">
                        0.000
                    </cc1:mytext>
                    </td></tr><tr><td class="style3"><asp:Label ID="Label48" runat="server" Text="ที่ดินพร้อมสิ่งปลูกสร้าง"></asp:Label></td><td><asp:Label ID="lblLand_Build" runat="server" Style="color: #FF0000"></asp:Label></td><td></td><td><asp:Label 
                ID="lblTotal3" runat="server" Style="color: #FF0000"></asp:Label></td><td><asp:Label ID="Label58" runat="server" Text="เป็นเงิน"></asp:Label></td><td>
                    <cc1:mytext ID="txtTotal3" runat="server" AllowUserKey="num_Numeric" 
                        AutoCurrencyFormatOnKeyUp="True" EnableTextAlignRight="True">
                        &nbsp;0.000
                    </cc1:mytext>
                    </td></tr><tr><td 
                class="style3"></td><td></td><td></td><td><asp:Label ID="lblGrantotal" 
                runat="server" Style="color: #FF0000"></asp:Label></td><td><asp:Label ID="Label60" runat="server" Text="รวมเป็นเงิน"></asp:Label></td><td>
                    <cc1:mytext ID="txtGrandTotal" runat="server" AllowUserKey="num_Numeric" 
                        AutoCurrencyFormatOnKeyUp="True" EnableTextAlignRight="True">
                        &nbsp;0.000
                    </cc1:mytext>
                    </td></tr></table><table><tr><td><asp:Label ID="Label61" runat="server" Text="COMMENT"></asp:Label></td><td><asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SDSComment" DataTextField="Comment_Name"
                                DataValueField="Comment_ID"></asp:DropDownList></td></tr><tr><td><asp:Label ID="Label62" runat="server" Text="WARNING"></asp:Label></td><td><asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SDSWarning" DataTextField="Warning_Name"
                                DataValueField="Warning_ID"></asp:DropDownList></td></tr></table><table><tr><td 
                valign="top"><asp:TextBox ID="txtBuy_Sale_Comment0" runat="server" Height="50px" TextMode="MultiLine"
                                Width="400px"></asp:TextBox></td><td><table class="style2"><tr><td>&#160;&#160; </td><td class="style4">&#160;&#160; </td><td>&#160;&#160; </td></tr><tr><td><asp:Label ID="Label63" runat="server" Text="ลงชื่อ"></asp:Label></td><td class="style4" align="center"><asp:Label ID="lblAppraisalName" runat="server" Width="200px"></asp:Label></td><td><asp:Label ID="Label65" runat="server" Text="ผู้ตรวจสอบประเมินราคา"></asp:Label></td></tr><tr><td>&#160;&#160; </td><td class="style4">&#160;&#160; </td><td>&#160;&#160; </td></tr><tr><td>&#160;&#160; </td><td class="style4"><asp:Label ID="Label66" runat="server" Text="(.............................................)"></asp:Label></td><td></td></tr><tr><td>&#160;&#160; </td><td class="style4"><asp:Label ID="Label59" runat="server" Text="............................................."></asp:Label></td><td>&#160;&#160;<asp:Label ID="Label67" runat="server" Text="วัน / เดือน / ปี"></asp:Label></td></tr></table></td></tr><tr><td 
                align="center" colspan="2"><asp:Label ID="Label69" runat="server" 
                Text="ความเห็นคณะอนุกรรมพิจารณาการประเมินมูลค่าสินทรัพย์ภายใน" 
                Style="font-weight: 700"></asp:Label></td></tr><tr><td colspan="2"><table class="style2"><tr><td><asp:Label ID="Label70" runat="server" Text="1.)"></asp:Label></td><td>&#160;&#160;</td><td><asp:Label ID="Label71" runat="server" Text="2.)"></asp:Label></td><td>&#160;&#160;</td><td><asp:Label ID="Label72" runat="server" Text="3.)"></asp:Label></td><td>&#160;&#160;</td></tr><tr><td>&#160;&#160;</td><td>&#160;&#160;</td><td>&#160;&#160;</td><td>&#160;&#160;</td><td>&#160;&#160;</td><td>&#160;&#160;</td></tr><tr><td>&#160;&#160;</td><td align="center"><asp:Label ID="Label73" runat="server" Text="(.......................................)"></asp:Label></td><td>&#160;&#160;</td><td align="center"><asp:Label ID="Label74" runat="server" Text="(.......................................)"></asp:Label></td><td>&#160;&#160;</td><td align="center"><asp:Label ID="Label75" runat="server" Text="(.......................................)"></asp:Label></td></tr><tr><td>&#160;&#160;</td><td align="center"><asp:Label ID="Label76" runat="server" Text="อนุกรรมการ"></asp:Label></td><td>&#160;&#160;</td><td align="center"><asp:Label ID="Label78" runat="server" Text="อนุกรรมการ"></asp:Label></td><td>&#160;&#160;</td><td align="center"><asp:Label ID="Label77" runat="server" Text="อนุกรรมการ"></asp:Label></td></tr><tr><td>&#160;&#160;</td><td>&#160;&#160;</td><td>&#160;&#160;</td><td>&#160;&#160;</td><td>&#160;&#160;</td><td>&#160;&#160;</td></tr></table></td></tr></table></ContentTemplate></ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel runat="server" ID="talPanelAdditional" HeaderText="รายละเอียดสิ่งปลูกสร้าง"><ContentTemplate><table><tr><td>อาชีพปัจจุบัน: </td><td><asp:TextBox ID="txtOccupation" runat="server"></asp:TextBox></td></tr><tr><td>สิ่งที่คุณสนใจ: </td><td><asp:CheckBoxList ID="cblInterest" runat="server" RepeatLayout="Table" RepeatColumns="2"><asp:ListItem Text="บันเทิง" Value="1"></asp:ListItem><asp:ListItem Text="การเมือง" Value="2"></asp:ListItem><asp:ListItem Text="กีฬา" Value="3"></asp:ListItem><asp:ListItem Text="วิทยาศาสตร์" Value="4"></asp:ListItem></asp:CheckBoxList></td></tr><tr><td></td><td></td><td><asp:Button ID="btnSave" Text="บันทึก" runat="server" /></td></tr></table></ContentTemplate></ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel runat="server" ID="TabPanel1" HeaderText="รายละเอียดที่ดินแนบท้าย"><ContentTemplate><table><tr><td></td><td></td></tr><tr><td></td><td></td></tr><tr><td></td><td></td></tr></table></ContentTemplate></ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>

        <asp:Button ID="Button1" runat="server" Text="Button" />

    <asp:SqlDataSource ID="SDSArea_Colour" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [AreaColour_No], [AreaColour_Name] FROM [AreaColour]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSWarning" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Warning_ID], [Warning_Name] FROM [Warning]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSComment" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Comment_ID], [Comment_Name] FROM [Comment]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSAppraisal_Type" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [App_Type_ID], [App_Type_Name] FROM [Appraisal_Type]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSUserAppraisal" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT Emp_id, Title + Name + '  ' + Lastname AS ApproveName FROM Tb_UserAppraisal">
    </asp:SqlDataSource>
    </form>
</body>
</html>
