<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_Price3_Form_Review.aspx.vb" Inherits="Appraisal_Price3_Form_Review" UICulture="th-TH" Culture="th-TH" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<%@ Register assembly="Mytextbox" namespace="Mytextbox" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css" media="print">
        .style1
        {
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
            width: 107px;
        }
        .style8
        {
            width: 252px;
        }
        .style10
        {
            height: 22px;
            width: 154px;
        }
        .style11
        {
            height: 124px;
        }
        .style12
        {            font-size: small;
        }
        .style13
        {
        }
        .style14
        {
        }
        .style15
        {
            width: 176px;
        }
        .style16
        {
            width: 226px;
        }
        .style17
        {
            width: 252px;
            height: 49px;
        }
        .style18
        {
            height: 49px;
        }
        .style19
        {
            font-size: small;
            height: 45px;
        }
        .style20
        {
            width: 175px;
        }
        .style21
        {
            width: 226px;
            height: 13px;
        }
        .style22
        {
            height: 13px;
            width: 154px;
        }
        .style23
        {
            width: 124px;
            height: 13px;
        }
        .style24
        {
            height: 13px;
        }
        .style27
        {
            height: 13px;
        }
        .style28
        {
            width: 124px;
        }
                .NotshowOnPrint
        {
            display:none;
        }
    </style>
        <link href="CSS/print.css" rel="stylesheet" type="text/css" media="print"/>
    <style type="text/css">
        .style2
        {
            width: 149px;
        }
        .style5
        {
            width: 172px;
        }
        .style6
        {
            width: 173px;
        }
        .style9
        {
        }
        .style10
        {
        }
        .style11
        {
            height: 22px;
        }
        .style12
        {
            height: 19px;
        }
        .style13
        {
            height: 36px;
        }
        .style14
        {
            height: 36px;
        }
        .style22
        {
            width: 158px;
            height: 18px;
        }
        .style25
        {
            width: 149px;
            height: 9px;
        }
        .style26
        {
            height: 9px;
        }
        .style35
        {
            height: 14px;
        }
        .style40
        {
            height: 8px;
        }
        .NotshowOnPrint
        {
            width: 357px;
        }
        .style42
        {
            width: 149px;
            height: 5px;
        }
        .style44
        {
            width: 149px;
            height: 13px;
        }
        .style47
        {
            width: 149px;
            height: 15px;
        }
        .style49
        {
            height: 15px;
        }
        .style52
        {
            width: 149px;
            height: 20px;
        }
        .style54
        {
            width: 149px;
            height: 12px;
        }
        .style57
        {
            width: 149px;
            height: 16px;
        }
        .style60
        {
            height: 13px;
        }
        .style61
        {
            width: 149px;
            height: 11px;
        }
        .style66
        {
            
            height: 8px;
        }
        .style72
        {
            width: 149px;
            height: 22px;
        }
        .style74
        {
            height: 6px;
        }
        .style78
        {
            height: 6px;
            width: 119px;
        }
        .style79
        {
            height: 8px;
            width: 119px;
        }
        .style81
        {
            height: 13px;
            width: 119px;
        }
        .style82
        {
            width: 119px;
        }
        .style83
        {
            width: 158px;
            height: 14px;
        }
        .style84
        {
            width: 158px;
            height: 8px;
        }
        .style86
        {
            width: 158px;
        }
        .style92
        {
            height: 18px;
            width: 228px;
        }
        .style93
        {
            height: 14px;
            width: 228px;
        }
        .style94
        {
            height: 8px;
            width: 228px;
        }
        .style99
        {
            width: 228px;
        }
        .style100
        {
            width: 123px;
        }
        .style101
        {
            width: 131px;
        }
        .style102
        {
            width: 109px;
        }
        .style107
        {
            width: 185px;
        }
        .style18
        {
            width: 174px;
            height: 32px;
        }
        .style104
        {
            width: 17px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" 
        EnableScriptGlobalization="True">
    </asp:ScriptManager>
    <asp:HiddenField ID="hdfReq_Id" runat="server" />
    <asp:HiddenField ID="hdfHub_Id" runat="server" />
    <asp:HiddenField ID="hdfAID" runat="server" />
    <asp:HiddenField ID="hdfCollType" runat="server" />
    <asp:HiddenField ID="hdfTemp_AID" runat="server" />
<br />

<%--<h5 style="text-align:center;">ธนาคารกรุงศรีอยุธยา จำกัด (มหาชน)</h5>
<h5 style="text-align:center;">รายงานทบทวนการประเมินราคาหลักประกัน</h5>--%><asp:UpdatePanel 
        ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="text-align:center;">
            </div>
        </ContentTemplate>
        
    </asp:UpdatePanel>
&nbsp;<table width="100%">
        <tr style="text-align:center;">
            <td class="style12" colspan="6" >
                <img alt="BayLogo" src="Images/logo_bank.jpg" 
                    style="width: 344px; height: 89px" /></td>
        </tr>
        <tr style="text-align:center;">
            <td class="style12" colspan="6" 
                style="border-bottom-style: double; border-bottom-width: thin; border-bottom-color: #000000" >
                <asp:Label ID="Label2" runat="server" 
        Text="รายงานทบทวนการประเมินราคาหลักประกัน" 
                    style="font-weight: 700; font-size: x-large;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style72">
                </td>
            <td>
                </td>
            <td>
                </td>
            <td>                
                </td>
            <td>
                </td>
            <td class="style11">
                </td>
        </tr>
        <tr>
            <td>
                </td>
            <td>
            </td>
            <td class="style78">
                <asp:Label ID="Label87" runat="server" Text="ทบทวนตามบันทึกลงวันที่" 
                    Width="180px"></asp:Label>
            </td>
            <td>                
                <asp:TextBox ID="txtMemo_Date" runat="server" Width="112px"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CEMemodate" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtMemo_Date">
                </ajaxToolkit:CalendarExtender>
                </td>
            <td class="style74" colspan="2">
                ครั้งที่
                <asp:TextBox ID="txtSequence" runat="server" Width="30px"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td>
    <asp:Label ID="Label3" runat="server" Text="เรียน" 
                    style="font-weight: 700; font-size: large;"></asp:Label>
            </td>
            <td class="style66">
                <asp:TextBox ID="txtInform_To" runat="server" Width="250px" 
                    style="font-weight: 700"></asp:TextBox>
            </td>
            <td class="style79">
                วันที่รับเรื่อง</td>
            <td class="style40">                
            <asp:TextBox ID="txtReceive_Date" runat="server" Width="112px"></asp:TextBox><ajaxToolkit:CalendarExtender
                    ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy" 
                    TargetControlID="txtReceive_Date">
                </ajaxToolkit:CalendarExtender>
                </td>
            <td>
                </td>
            <td class="style40">
                </td>
        </tr>
        <tr>
            <td class="style47">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label4" runat="server" Text="CIF" style="font-weight: 700; font-size: large"></asp:Label>
    
            &nbsp;<asp:Label ID="lblCif" runat="server" style="font-weight: 700"></asp:Label>
    
            </td>
            <td>
    <asp:Label ID="Label5" runat="server" Text="ลูกค้าราย" 
                    style="font-weight: 700; font-size: large"></asp:Label>
    
            &nbsp;<asp:Label ID="lblCifName" runat="server" Width="259px" 
                    style="font-weight: 700; font-size: large" Height="20px"></asp:Label>
            </td>
            <td>
    <asp:Label ID="Label7" runat="server" Text="สาขา/ฝ่ายงาน"></asp:Label>
    
            </td>
            <td>
                <asp:DropDownList ID="ddlBranch" runat="server" DataSourceID="sdsBranch" 
                    DataTextField="BRANCH_T" DataValueField="ID_BRANCH" style="margin-left: 0px">
                </asp:DropDownList>
            </td>
            <td class="style49" colspan="2">
    <asp:Label ID="LblAID" runat="server" Text="AID"></asp:Label>
    
                <asp:TextBox ID="txtAID" runat="server" Width="100px"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td class="style42">
    <asp:Label ID="Label6" runat="server" Text="หลักประกันที่ดิน" 
                    style="font-weight: 700; font-size: large;"></asp:Label>
    
            </td>
            <td colspan="2">
                <asp:Label ID="lblChanode" runat="server" Width="420px"></asp:Label>
            </td>
            <td colspan="3">
    <asp:Label ID="Label83" runat="server" Text="เนื้อที่รวม"></asp:Label>
    
            &nbsp; <asp:Label ID="lblLandArea" runat="server"></asp:Label>
    
            &nbsp; วันที่ประเมิน<asp:TextBox ID="txtAppraisal_Date" runat="server"></asp:TextBox><ajaxToolkit:CalendarExtender
                    ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" 
                    TargetControlID="txtAppraisal_Date">
                </ajaxToolkit:CalendarExtender>
    
            </td>
        </tr>
        <tr>
            <td class="style52">
    <asp:Label ID="Label80" runat="server" Text="หลักประกันที่ดิน" 
                    style="font-weight: 700; font-size: large;"></asp:Label>
    
            </td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                    RepeatDirection="Horizontal" AutoPostBack="True">
                    <asp:ListItem Selected="True" Value="0">ไม่เปลี่ยนแปลง</asp:ListItem>
                    <asp:ListItem Value="1">เปลี่ยนแปลง</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td colspan="4">
                <asp:TextBox ID="txtLandDetail" runat="server" Width="450px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style54">
    <asp:Label ID="Label8" runat="server" Text="ภาระผูกพัน" 
                    style="font-weight: 700; font-size: large;"></asp:Label>
    
            </td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList2" runat="server" 
                    RepeatDirection="Horizontal" AutoPostBack="True">
                    <asp:ListItem Selected="True" Value="0">ไม่เปลี่ยนแปลง</asp:ListItem>
                    <asp:ListItem Value="1">เปลี่ยนแปลง</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td colspan="4">
                <asp:TextBox ID="txtObligation" runat="server" Width="450px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style57">
    <asp:Label ID="Label9" runat="server" Text="ที่ตั้งและสภาพที่ดิน" style="font-weight: 700; font-size: large;" 
                    Width="220px"></asp:Label>
    
            </td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList3" runat="server" 
                    RepeatDirection="Horizontal" AutoPostBack="True">
                    <asp:ListItem Selected="True" Value="0">ไม่เปลี่ยนแปลง</asp:ListItem>
                    <asp:ListItem Value="1">เปลี่ยนแปลง</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td colspan="4">
                <asp:TextBox ID="txtLandAddress" runat="server" Width="450px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style42">
    <asp:Label ID="Label10" runat="server" Text="ฝังเมืองรวม" 
                    style="font-weight: 700; font-size: large;"></asp:Label>
    
            </td>
            <td colspan="5">
                ที่ดินอยู่ในเขตพื้นที่สี
                <asp:Label ID="lblAreaColour" runat="server"></asp:Label>
            &nbsp;<asp:Label ID="Label85" runat="server" Text="อายุอาคาร"></asp:Label>
                &nbsp;<cc1:mytext ID="txtBuilding_Age" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" Width="30px" BackColor="#FFFF66" AutoPostBack="True" 
                                      AutoCurrencyFormatOnKeyUp="True">0</cc1:mytext>
                &nbsp;<asp:Label ID="Label86" runat="server" Text="ปี"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style44">
    <asp:Label ID="Label11" runat="server" Text="แนวโน้มความเจริญ" style="font-weight: 700; font-size: large;" 
                    Width="200px"></asp:Label>
    
            </td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList4" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="0">ไม่เปลี่ยนแปลง</asp:ListItem>
                    <asp:ListItem Value="1">ดีขึ้น</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td class="style81">
                <asp:Button ID="btnChangeLand" runat="server" Text="     แก้ไขที่ดิน     " 
                    CssClass="NotshowOnPrint" Width="150px" />
            </td>
            <td class="style60">
    <asp:Label ID="Label81" runat="server" Text="สภาพการซื้อ-ขาย"></asp:Label>
            </td>
            <td class="style60">
                <asp:Label ID="lblBuySaleState_Name" runat="server"></asp:Label>
            </td>
            <td class="style60">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style47">
    <asp:Label ID="Label12" runat="server" Text="สิ่งปลูกสร้าง" 
                    style="font-weight: 700; font-size: large;"></asp:Label>
    
            </td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList5" runat="server" 
                    RepeatDirection="Horizontal" AutoPostBack="True">
                    <asp:ListItem Selected="True" Value="0">ไม่เปลี่ยนแปลง</asp:ListItem>
                    <asp:ListItem Value="1">เปลี่ยนแปลง</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td colspan="4" class="style49">
                <asp:Button ID="btnChangeBuilding" runat="server" Text="แก้ไขสิ่งปลูกสร้าง" 
                    CssClass="NotshowOnPrint" Width="150px" />
                <asp:TextBox ID="txtBuilding" runat="server" Width="450px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style47" width="200">
    <asp:Label ID="Label13" runat="server" Text="เขตการปกครอง" style="font-weight: 700; font-size: large;" 
                    Width="150px"></asp:Label>
            </td>
            <td>
                แขวงตำบล
                <asp:Label ID="lblDistrict" runat="server"></asp:Label>
            </td>
            <td colspan="2">
                เขต/อำเภอ
                <asp:Label ID="lblAmphur" runat="server"></asp:Label>
            </td>
            <td colspan="2">
                จังหวัด
                <asp:Label ID="lblProvinceName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style61">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label14" runat="server" Text="สภาพการตกแต่ง"></asp:Label>
            </td>
            <td colspan="5">
                    <asp:DropDownList ID="ddlInteriorState" runat="server" 
                        DataSourceID="SDSInterior_State" DataTextField="InteriorState_Name" 
                        DataValueField="InteriorState_Id">
                    </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="6" style="font-size: small">
                <asp:Repeater ID="Repeater1" runat="server" DataSourceID="sdsBuilding_Partake_List">
                <HeaderTemplate>
                    <table border="1px" width="100%">
                    <tr class="bgTable">
                        <td rowspan="2" valign="top">
                            รายการสิ่งปลูกสร้าง</td>
                        <td rowspan="2" valign="top" style="text-align:center;">
                            พื้นที่<br />
                            (ตรม.)</td>
                        <td colspan="2" style="text-align:center;">
                            ราคาต้นทุนทดแทนใหม่
                        </td>
                        <td rowspan="2" valign="top" style="width:60px; text-align:center;">
                            อายุการ<br />
                            ใช้งาน(ปี)</td>
                        <td rowspan="2" valign="top" style="width:60px; text-align:center;">
                            ค่าเสื่อม(ปี)</td>
                        <td colspan="2">
                            ปรับค่าเสื่อมตามสภาพ</td>
                        <td rowspan="2" valign="top" style="width:80px; text-align:center;">
                            รวมค่าเสื่อม<br />
                            %</td>
                        <td rowspan="2" valign="top" style="text-align:center;">
                            รวมค่าเสื่อม<br />
                            (บาท)</td>
                        <td rowspan="2" valign="top" style="text-align:center;">
                            ราคาตามสภาพ<br />
                            ปัจจุบัน(บาท)</td>
                    </tr>
                    <tr class="bgTable">
                        <td valign="top" style="text-align:center;">
                            ต่อหน่วย</td>
                        <td valign="top" style="text-align:center;">
                            มูลค่า(บาท)</td>
                        <td valign="top" style="text-align:center;">
                            ปรับปรุง</td>
                        <td valign="top" style="text-align:center;">
                            เสื่อมโทรม</td>
                    </tr> 
                                        
                </HeaderTemplate>   
                <ItemTemplate>
                     <tr>
                        <td>
                            <%#DataBinder.Eval(Container.DataItem, "CollName")%>
                        </td>
                        <td align="center">
                            <%#Eval("Area")%>
                        </td>
                        <td align="right">
                            <%#String.Format("{0:N2}", Eval("UintPrice"))%>
                        </td>
                        <td align="right">
                            <%#String.Format("{0:N2}", Eval("Price"))%>
                        </td>
                        <td align="center">
                            <%#Eval("Age")%>
                        </td>
                        <td align="center">
                            <%#Eval("Persent1")%>
                        </td>
                        <td align="center">
                            <%#Eval("Persent2")%>
                        </td>
                        <td align="center">
                            <%#Eval("Persent3")%>
                        </td>
                        <td align="center">                     
                            <%# Get_Amount( eval("Age"), eval("Persent1"), eval("Persent2"), eval("Persent3")) %>
                        </td>
                        <td align="right">
                            <%# Get_Amount_Bht( eval("Price") ,eval("Age"), eval("Persent1"), eval("Persent2"), eval("Persent3")) %>
                        </td>
                        <td align="right">
                            <%# Get_Balance( eval("Price") ,eval("Age"), eval("Persent1"), eval("Persent2"), eval("Persent3")) %>
                        </td>
                    </tr>                    
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr style=" background-color:#ccff99">
                        <td>
                            <%#DataBinder.Eval(Container.DataItem, "CollName")%>
                        </td>
                        <td align="center">
                            <%#Eval("Area")%>
                        </td>
                        <td align="right">
                            <%#String.Format("{0:N2}", Eval("UintPrice"))%>
                        </td>
                        <td align="right">
                            <%#String.Format("{0:N2}", Eval("Price"))%>
                        </td>
                        <td align="center">
                            <%#Eval("Age")%>
                        </td>
                        <td align="center">
                            <%#Eval("Persent1")%>
                        </td>
                        <td align="center">
                            <%#Eval("Persent2")%>
                        </td>
                        <td align="center">
                            <%#Eval("Persent3")%>
                        </td>
                        <td align="center">                     
                            <%# Get_Amount( eval("Age"), eval("Persent1"), eval("Persent2"), eval("Persent3")) %>
                        </td>
                        <td align="right">
                            <%# Get_Amount_Bht( eval("Price") ,eval("Age"), eval("Persent1"), eval("Persent2"), eval("Persent3")) %>
                        </td>
                        <td align="right">
                            <%# Get_Balance( eval("Price") ,eval("Age"), eval("Persent1"), eval("Persent2"), eval("Persent3")) %>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
               <FooterTemplate>
                    <tr style ="background-color:Gray">
                        <td colspan="9" style="font-size:10pt; font-style:italic">
<%--                            <asp:DropDownList ID="ddlDrecription" 
                                    runat="server" DataSourceID="sdsDecription" DataTextField="Standard_Name" 
                                    DataValueField="Standard_Id">
                            </asp:DropDownList>--%>
                        </td>
                        <td align="right">
                            รวมราคา
                        </td>
                        <td align="right">
                            <%#String.Format("{0:N2}", (Get_Total()))%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="10" style="font-size:10pt;" align="right">
                            รวมเป็นเงิน(ปัดเศษ)
                        </td>
                        <td align="right">
                            <%#String.Format("{0:N2}", (Get_RoundTotal()))%>
                        </td>
                    </tr>                    
	               </table>
               </FooterTemplate>

                </asp:Repeater>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:DropDownList ID="ddlDrecription" runat="server" 
                    DataSourceID="sdsDecription" DataTextField="Standard_Name" 
                    DataValueField="Standard_Id">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:Label ID="lblMessage" runat="server" 
                    style="font-weight: 700; color: #FF0000; font-size: large;">รายการสิ่งปลูกสร้างตามเอกสารแนบ</asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="6">
    <asp:Label ID="Label15" runat="server" Text="ภาวะแวดล้อมกับผลกระทบ" 
                    style="font-weight: 700"></asp:Label>
    &nbsp;
                (<asp:Label ID="Label16" runat="server" 
                    Text="การตรวจสอบปัญหาภาวะแวดล้อมใกล้เคียงเท่าที่สามารถตรวจสอบได้ ณ วันสำรวจ"></asp:Label>
                )</td>
        </tr>
        <tr>
            <td class="style5" colspan="6">
                <table class="style10">
                    <tr>
                        <td>
                <asp:DropDownList ID="ddlProblem" runat="server" BackColor="#FFFF66" 
                    DataSourceID="sdsProblem" DataTextField="Problem_Name" 
                    DataValueField="Problem_Id">
                </asp:DropDownList>
                        </td>
                        <td>
                <asp:Label ID="Label49" runat="server" Text="(ถ้ามีอธิบายเพิ่มเติม) " Width="180px"></asp:Label>
                        </td>
                        <td>
                      <asp:TextBox  ID="txtProblem_Detail" runat="server" Width="450px" 
                    BackColor="#FFFF66"></asp:TextBox>                  
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="style2">
    <asp:Label ID="Label18" runat="server" Text="การประเมินราคา" 
                    style="font-weight: 700; font-size: large;" Width="180px"></asp:Label>
    &nbsp;ข้อมูลซื้อขาย</td>
            <td class="style6" colspan="5">
                <asp:TextBox ID="txtBuy_Sale_Comment" runat="server" Height="64px" TextMode="MultiLine"
                    Width="716px" BackColor="#FFFF66"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label52" runat="server" Font-Bold="True" Text="วิธีการประเมินราคา"></asp:Label>
            </td>
            <td class="style13" colspan="5">
                <asp:DropDownList ID="ddlAppraisal_Type" runat="server" CssClass="txtDoPrint" 
                    DataSourceID="SDSAppraisal_Type" DataTextField="App_Type_Name" 
                    DataValueField="App_Type_ID" BackColor="#FFFF66" AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style5" colspan="6">
                <table style="width: 695%; height: 132px;">
        <tr>
            <td class="style92">
                <asp:Label ID="lblCollName" runat="server"></asp:Label>
&nbsp;<asp:Label ID="Label53" runat="server" Text="เนื้อที่"></asp:Label>
            </td>
            <td class="style22">
                <asp:Label ID="lblSize" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style101">
                <asp:Label ID="lblSubUnit" runat="server" Width="110px"></asp:Label>&#160;&#160;
            </td>
            <td class="style100" >
                <asp:Label ID="lblPriceWah" runat="server" Style="color: #FF0000" Width="120px">0.00</asp:Label>
            </td>
            <td width="100">
                <asp:Label ID="Label55" runat="server" Text="เป็นเงิน"></asp:Label>
            </td>
            <td style="text-align:left; " class="style102" >
                                  <cc1:mytext ID="txtLandTotal" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" BackColor="#FFFF66" AutoPostBack="True" 
                                      AutoCurrencyFormatOnKeyUp="True">0.00</cc1:mytext>
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="style93">
                <asp:Label ID="Label56" runat="server" Text="สิ่งปลูกสร้าง"></asp:Label>
            </td>
            <td class="style83">
                <asp:Label ID="lblBuilding_Detail" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style101">
            </td>
            <td class="style100">
                </td>
            <td class="style35">
                <asp:Label ID="Label57" runat="server" Text="เป็นเงิน"></asp:Label>
            </td>
            <td style=" text-align:left; " class="style102">
                                  <cc1:mytext ID="txtBuildingPrice" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" BackColor="#FFFF66" AutoPostBack="True" 
                                      AutoCurrencyFormatOnKeyUp="True" >0.00</cc1:mytext>
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="style94">
                <asp:Label ID="Label48" runat="server" Text="ที่ดินพร้อมสิ่งปลูกสร้าง" 
                    Width="220px"></asp:Label>
            </td>
            <td class="style84">
                <asp:Label ID="lblLand_Build" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style101">
            </td>
            <td class="style100">
                </td>
            <td class="style40">
                <asp:Label ID="Label84" runat="server" Text="เป็นเงิน"></asp:Label>
            </td>
            <td style=" text-align:left; " class="style102">
                                  <cc1:mytext ID="txtSubTotal" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" BackColor="#FFFF66" AutoPostBack="True" 
                                      AutoCurrencyFormatOnKeyUp="True">0.00</cc1:mytext>
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="style99" >
                <asp:Label ID="Label61" runat="server" Font-Bold="True" 
                    Text="สรุปผลการประเมินราคา" style="font-size: large"></asp:Label>
            </td>
            <td >
            </td>
            <td class="style101" >
            </td>
            <td class="style100">
                </td>
            <td >
                <asp:Label ID="Label60" runat="server" Text="รวมเป็นเงิน"></asp:Label>
            </td>
            <td style=" text-align:left; " class="style102">
                                  <cc1:mytext ID="txtGrandTotal" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" BackColor="#FFFF66" AutoPostBack="True" 
                                      AutoCurrencyFormatOnKeyUp="True">0.00</cc1:mytext>
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="style99">
                </td>
            <td class="style86">
                </td>
            <td class="style101">
                </td>
            <td align="center" colspan="3">
                (<asp:Label ID="lblThaiBaht" runat="server"></asp:Label>
                )</td>
            <td></td>
        </tr>
    </table>
            </td>
        </tr>
        <tr>
            <td class="style12" colspan="6">
                <asp:Label ID="Label62" runat="server" Text="ราคาประเมินครั้งล่าสุด"></asp:Label>
            &nbsp;<asp:TextBox ID="txtLast_Appraisal_Detail" runat="server" Width="600px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style25">
                <asp:Label ID="Label63" runat="server" Text="COMMENT"></asp:Label>
            </td>
            <td class="style26" colspan="5">
                <asp:DropDownList ID="ddlComment" runat="server" DataSourceID="SDSComment" 
                    DataTextField="Comment_Name" DataValueField="Comment_ID" 
                    BackColor="#FFFF66">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style25">
                <asp:Label ID="Label64" runat="server" Text="WARNING"></asp:Label>
            </td>
            <td class="style26" colspan="5">
                <asp:DropDownList ID="ddlWarning" runat="server" DataSourceID="SDSWarning" 
                    DataTextField="Warning_Name" DataValueField="Warning_ID" 
                    BackColor="#FFFF66">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style12" colspan="2">
                <asp:TextBox ID="txtWarning_Detail" runat="server" Height="50px" TextMode="MultiLine"
                    Width="400px" BackColor="#FFFF66"></asp:TextBox>
            </td>
            <td class="style82">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5" colspan="6">
            
    <table style="width: 694%">
        <tr>
            <td valign="top" class="style107">
                </td>
            <td align="left">
                <table style="width: 727px">
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label79" runat="server" Text="ลงชื่อ"></asp:Label>
                        </td>
                        <td >
                            </td>
                        <td class="style18">
                            <asp:Label ID="Label65" runat="server" Text="ผู้ตรวจสอบประเมินราคา"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                                                        &nbsp;</td>
                        <td>
                            &#160;&#160;
                        </td>
                        <td>
                            &#160;&#160;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="center">
                    <asp:DropDownList ID="ddlUserAppraisal" runat="server" DataSourceID="SDSUserAppraisal"
                        DataTextField="UserAppraisal" DataValueField="Emp_id" Width="200px">
                    </asp:DropDownList>
                           </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td class="style104" align="center">
                            <asp:Label ID="Label59" runat="server" 
                                Text="..............................................."></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="Label67" runat="server" Text="วัน / เดือน / ปี"></asp:Label>
                            &#160;&#160;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" 
                style="border-top-style: double; border-top-width: thin; border-top-color: #000000">
                <asp:Label ID="Label69" runat="server" Text="ความเห็นคณะอนุกรรมพิจารณาการประเมินมูลค่าสินทรัพย์ภายใน"
                    Style="font-weight: 700"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table style="width: 77%">
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
                            &nbsp;</td>
                        <td style="border-bottom-style: dotted; border-bottom-width: thin; border-bottom-color: #000000;">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td style="border-bottom-style: dotted; border-bottom-width: thin; border-bottom-color: #000000;">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td style="border-bottom-style: dotted; border-bottom-width: thin; border-bottom-color: #000000;">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &#160;&#160;
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlApprove1" runat="server" BackColor="#FFFF66" 
                                DataSourceID="sdsSubCommittee" DataTextField="SubCommittee_Name" 
                                DataValueField="SubCommittee_ID">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &#160;&#160;
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlApprove2" runat="server" BackColor="#FFFF66" 
                                DataSourceID="sdsSubCommittee" DataTextField="SubCommittee_Name" 
                                DataValueField="SubCommittee_ID">
                            </asp:DropDownList>
                        </td>
                        <td>
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
                        <td>
                            &#160;&#160;
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlPos_Approve1" runat="server" BackColor="#FFFF66" 
                                DataSourceID="sdsPosition_Approve" DataTextField="Position_Name" 
                                DataValueField="Position_Id">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &#160;&#160;
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlPos_Approve2" runat="server" BackColor="#FFFF66" 
                                DataSourceID="sdsPosition_Approve" DataTextField="Position_Name" 
                                DataValueField="Position_Id">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &#160;&#160;
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlPos_Approve3" runat="server" BackColor="#FFFF66" 
                                DataSourceID="sdsPosition_Approve" DataTextField="Position_Name" 
                                DataValueField="Position_Id">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    </table>
            </td>
        </tr>
    </table>
            
            </td>
        </tr>
        <tr>
            <td align="center" colspan="6">
                <table class="NotshowOnPrint">
                    <tr>
                        <td>
                            <asp:ImageButton ID="ImageSave" runat="server" Height="35px" 
                                ImageUrl="~/Images/Save.jpg" Width="35px" ToolTip="Save Data" />
                        </td>
                        <td>
                            <b>SAVE</b>                         
                        </td>
                        <td>
                            <asp:ImageButton ID="ImageEditPosition" runat="server" Height="35px" 
                                ImageUrl="~/Images/pawn.png" Width="35px" ToolTip="Save Data" />
                        </td>
                        <td style="width:100px"><b>กำหนดพิกัด</b></td>
                        <td>
                            <asp:ImageButton ID="ImgAttach" runat="server" 
                                ImageUrl="~/Images/attachment.ico" Width="35px" Height="35px" />
                        </td>
                        <td>
                            <b>ไฟล์แนบ</b>                         </td>                            
                    </tr>                  
                </table>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style14">
                &nbsp;</td>
            <td class="style82">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style12" colspan="6">
                &nbsp;</td>
        </tr>
    </table>
                                
                            
    <br />
    
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
    
    <asp:SqlDataSource ID="sdsBranch" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="GET_BRANCH" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    
    <asp:SqlDataSource ID="SDSInterior_State" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        
        
        
        SelectCommand="SELECT [InteriorState_Id], [InteriorState_Name] FROM [Interior_State] ORDER BY [InteriorState_Id]">
    </asp:SqlDataSource>
    
    <asp:SqlDataSource ID="SDSUserAppraisal" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT Emp_id, Title + Name + '  ' + Lastname AS UserAppraisal FROM Tb_UserAppraisal">
    </asp:SqlDataSource>
        
    <asp:SqlDataSource ID="sdsBuilding_Partake_List" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="GET_PRICE3_70_REVIEW_BUILDING_PARTAKE_ALL" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="hdfReq_Id" Name="Req_Id" PropertyName="Value" 
                Type="Int32" />
            <asp:ControlParameter ControlID="hdfHub_Id" Name="Hub_Id" PropertyName="Value" 
                Type="Int32" />
            <asp:ControlParameter ControlID="hdfTemp_AID" Name="TEMP_AID" 
                PropertyName="Value" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
        
    <asp:SqlDataSource ID="sdsDecription" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="SELECT [Standard_Id], [Standard_Name] FROM [TB_STANDARD]"></asp:SqlDataSource>
    
    <asp:SqlDataSource ID="sdsSubCommittee" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        
        
        SelectCommand="SELECT [SubCommittee_ID], [SubCommittee_Name] FROM [TB_SubCommittee] ORDER BY [SubCommittee_Name]"></asp:SqlDataSource>
    
    <asp:SqlDataSource ID="sdsProblem" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        
        
        SelectCommand="SELECT [Problem_Id], [Problem_Name] FROM [TB_Problem]"></asp:SqlDataSource>
    
    <asp:SqlDataSource ID="sdsPosition_Approve" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        
        SelectCommand="SELECT [Position_Id], [Position_Name] FROM [TB_POSITION_APPROVE]">
    </asp:SqlDataSource>
    
    </asp:Content>

