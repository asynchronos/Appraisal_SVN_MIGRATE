<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PrintPreviewPrice3Review.aspx.vb" Inherits="PrintPreviewPrice3Review" %>

<%@ Register assembly="Mytextbox" namespace="Mytextbox" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CSS/print.css" rel="stylesheet" type="text/css" media="print"/>
        <style type="text/css">
            .StyleBody
            {
                font-family:Tahoma; 
                font-size:medium;
            }
            .MainTable
            {
                width: 100%;
            }
            .Center
            {
                text-align: center; 
                border-bottom-style: double; 
                border-bottom-width: thin; 
                border-bottom-color: #000000;
            }        
        .notes
        {
            margin-bottom:5px;
            width: 900px;
            height: 100px;
            padding: 5px;
            background-color: #fff;
            background-repeat: repeat;
            display: block;
            overflow:auto;
            font-family:Tahoma;
            font-size:medium;
        }
            .style1
            {
                height: 23px;
            }
        </style>
        <style type="text/css" media="print">

            .style1
            {
                height: 23px;
            }
        .notes
        {
            margin-bottom:5px;
            width: 900px;
            height: 100px;
            padding: 5px;
            background-color: #fff;
            background-repeat: repeat;
            display: block;
            overflow:auto;
            font-family:Tahoma;
            font-size:medium;
        }
        .txtbox {
            background-repeat: repeat;
            overflow:auto;
            font-family:Tahoma;
            font-size:medium;
        }
        .style11
        {
            width: 290px;
        }
        .style31
        {
            width: 144px;
        }
        .style32
        {
            width: 157px;
        }
        .style7
        {
            width: 89px;
        }
        .style8
        {
            width: 92px;
        }
        .style4
        {
            width: 75px;
        }
        .style22
        {
            width: 24px;
        }
        .style29
        {
            width: 10px;
        }
        .style26
        {
            width: 21px;
        }
        .style28
        {
            width: 119px;
        }
        .style27
        {
            width: 132px;
        }
        .style23
        {
            width: 87px;
        }
        .NotshowOnPrint
        {
            display:none;
        }
        </style>
        
    <script type="text/javascript" language="javascript">
        function windowSize() {
            if (parseInt(navigator.appVersion) > 3) {
                if (navigator.appName == "Netscape") {
                    winW = window.innerWidth - 16;
                    winH = window.innerHeight - 16;
                }
                if (navigator.appName.indexOf("Microsoft") != -1) {
                    winW = document.body.offsetWidth - 20;
                    winH = document.body.offsetHeight - 20;
                }
            }
            //alert(winW);
            //alert(winH);
            window.open('Testprint.aspx', 'PrintMe', 'height=' + winH + ',' + 'width='+ winH + ',scrollbars=1,resizable=yes');
        }
        function windowPrint() {
            window.print();
        }   
    </script>
</head>
<body class="StyleBody">
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="PanelPrint" runat="server">
        <table class="MainTable">
            <tr>
                <td align="right">
                    <table>
                        <tr>
                            <td align="right" class="NotshowOnPrint">
                                <asp:ImageButton ID="ImageButtonReturn" runat="server" Height="25px" 
                                    ImageUrl="~/Images/repeat.ico" ToolTip="กลับไปหน้ารายการทบทวนประเมิน" 
                                    Width="25px" />
                            </td>
                            <td>
                            </td>
                            <td class="NotshowOnPrint">
                                <asp:ImageButton ID="ImageButtonPrint" runat="server" Height="25px" 
                                    ImageUrl="~/Images/printer.png" OnClientClick="windowPrint();" 
                                    ToolTip="พิมพ์หน้านี้" Width="25px" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <img alt="BayLogo" src="Images/logo_bank.jpg" 
                        style="width: 250px; height: 60px" />
                </td>
            </tr>
            <tr class="Center">
                <td>
                <asp:Label ID="lblDescript1" runat="server" 
                    Text="รายงานทบทวนการประเมินราคาหลักประกัน" 
                    style="font-weight: 700; font-size: x-large"></asp:Label>
                </td>
            </tr>            
            <tr class="Center">
                <td>
                <asp:Label ID="Label87" runat="server" Text="ทบทวนตามบันทึกลงวันที่" 
                    Width="180px"></asp:Label>
                    <asp:Label ID="LabelMemoDate" runat="server"></asp:Label>
&nbsp;<asp:Label ID="LabelSeq" runat="server" Text="ครั้งที่"></asp:Label>
                &nbsp;<asp:Label ID="LabelSeqValue" runat="server"></asp:Label>
                </td>
            </tr>            
            <tr>
                <td>
                    <table class="MainTable">
                        <tr>
                            <td>
                                <asp:Label ID="lblSubjectDesc" runat="server" Font-Size="Large" style="font-weight: 700" Text="เรียน"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LabelInform_To" runat="server" 
                                    style="font-size: medium; font-weight: 700"></asp:Label>
                            </td>
                            <td><asp:Label ID="LabelReceive_Date" runat="server" Text="วันที่รับเรื่อง"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LabelReceive_DateValue" runat="server" style="font-size: medium; font-weight: 700"></asp:Label>
                            </td>
                            <td></td>
                            <td></td>                            
                        </tr>
                    </table>
                </td>
            </tr>            
            <tr>
                <td>
                    <table class="MainTable">
                        <tr>
                            <td>
                                <asp:Label ID="lblCifDesc" runat="server" Font-Size="Large" 
                                    style="font-weight: 700" Text="CIF"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LabelCif" runat="server" Text="CIF" style="font-weight: 700; font-size: large"></asp:Label>
                                <asp:Label ID="lblCifName" runat="server" 
                                    style="font-size: medium; font-weight: 700"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LabelBranch" runat="server" Text="สาขา/ฝ่ายงาน"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LabelBranchValue" runat="server" 
                                    style="font-size: medium; font-weight: 700"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LabelAID" runat="server" Text="AID"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LabelAIDValue" runat="server" 
                                    style="font-size: medium; font-weight: 700"></asp:Label>                            
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>            
            <tr>
                <td>
                    <table class="MainTable">
                        <tr>
                            <td>
                                <asp:Label ID="LabelLand" runat="server" Text="หลักประกันที่ดิน" style="font-weight: 700; font-size: large"></asp:Label>
                            </td>
                            <td>
                <asp:Label ID="lblChanode" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LabelSizeTotal" runat="server" Text="เนื้อที่รวม "></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LabelSizeTotalValue" runat="server" 
                                    style="font-size: medium; font-weight: 700"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LabelAppraisalDate" runat="server" Text="วันที่ประเมิน"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LabelAppraisalDateValue" runat="server" 
                                    style="font-size: medium;"></asp:Label>                            
                            </td>
                        </tr>
                    </table>                
                </td>
            </tr>            
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
    <asp:Label ID="Label80" runat="server" Text="หลักประกันที่ดิน" 
                    style="font-weight: 700; font-size: large;"></asp:Label>
    
                            </td>
                            <td>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="0">ไม่เปลี่ยนแปลง</asp:ListItem>
                    <asp:ListItem Value="1">เปลี่ยนแปลง</asp:ListItem>
                </asp:RadioButtonList>
                            </td>
                            <td style="width:auto">
                                <asp:Label ID="LabelLandDetail" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
    <asp:Label ID="Label8" runat="server" Text="ภาระผูกพัน" 
                    style="font-weight: 700; font-size: large;"></asp:Label>
    
                            </td>
                            <td>
                <asp:RadioButtonList ID="RadioButtonList2" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="0">ไม่เปลี่ยนแปลง</asp:ListItem>
                    <asp:ListItem Value="1">เปลี่ยนแปลง</asp:ListItem>
                </asp:RadioButtonList>
                            </td>
                            <td>
                                <asp:Label ID="LabelObligation" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text="ที่ตั้งและสภาพที่ดิน" style="font-weight: 700; font-size: large;" 
                                                Width="220px" Height="22px"></asp:Label>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="RadioButtonList3" runat="server" 
                                    RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="0">ไม่เปลี่ยนแปลง</asp:ListItem>
                                    <asp:ListItem Value="1">เปลี่ยนแปลง</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <asp:Label ID="LabelLandAddress" runat="server"></asp:Label>
                            </td>
                        </tr>                                                
                        <tr>
                            <td>
    <asp:Label ID="Label10" runat="server" Text="ฝังเมืองรวม" 
                    style="font-weight: 700; font-size: large;"></asp:Label>
    
                            </td>
                            <td colspan="2">
                                <asp:Label ID="LabelAppraisalDate0" runat="server" Text="ที่ดินอยู่ในเขตพื้นที่สี "></asp:Label>
                <asp:Label ID="lblAreaColour" runat="server"></asp:Label>
                                &nbsp;<asp:Label ID="lblBuildingAge" runat="server" Text=" อายุอาคาร"></asp:Label>
                            &nbsp;<asp:Label ID="LabelBuildingAge" runat="server"></asp:Label>
                                &nbsp;<asp:Label ID="lblYear" runat="server" Text="ปี"></asp:Label>
                            </td>
                        </tr>                                                
                        <tr>
                            <td>
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
                            <td>
    <asp:Label ID="Label81" runat="server" Text="สภาพการซื้อ-ขาย"></asp:Label>
            &nbsp;<asp:Label ID="lblBuySaleState_Name" runat="server"></asp:Label>
                            </td>
                        </tr>                                                
                        <tr>
                            <td>
    <asp:Label ID="Label12" runat="server" Text="สิ่งปลูกสร้าง" 
                    style="font-weight: 700; font-size: large;"></asp:Label>
    
                            </td>
                            <td>
                <asp:RadioButtonList ID="RadioButtonList5" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="0">ไม่เปลี่ยนแปลง</asp:ListItem>
                    <asp:ListItem Value="1">เปลี่ยนแปลง</asp:ListItem>
                </asp:RadioButtonList>
                            </td>
                            <td>
                                &nbsp;<asp:Label ID="LabelBuilding" runat="server"></asp:Label>
                            </td>
                        </tr>                                                
                    </table>
                </td>
            </tr>            
            <tr>
                <td>
    <asp:Label ID="Label13" runat="server" Text="เขตการปกครอง" style="font-weight: 700; font-size: large;" 
                    Width="150px"></asp:Label>
                <asp:Label ID="LableAddress1" runat="server"></asp:Label>
                </td>
            </tr>            
            <tr>
                <td>
    <asp:Label ID="Label14" runat="server" Text="สภาพการตกแต่ง"></asp:Label>
            &nbsp;<asp:Label ID="LabelDecoration" runat="server"></asp:Label>
                &nbsp;<asp:Label ID="Label90" runat="server" 
                        Text="วันที่เริ่มต้นนับอายุสิ่งปลูกสร้าง"></asp:Label>
            &nbsp;<asp:Label ID="LabelBuildingStartDate" runat="server"></asp:Label>
                </td>
            </tr>            
            <tr>
                <td style="font-size: small">
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
                <td>
    <asp:Label ID="LabelStrandard" runat="server" Text="มารตฐาน"></asp:Label>
            &nbsp;<asp:Label ID="LabelStrandardValue" runat="server" ></asp:Label>
                </td>
            </tr>            
            <tr>
                <td>
                <asp:Label ID="lblMessage" runat="server" 
                    style="font-weight: 700; color: #000000; font-size: large;">รายการสิ่งปลูกสร้างตามเอกสารแนบ</asp:Label>
                </td>
            </tr>            
            <tr>
                <td class="style1">
                    <asp:Label ID="Label15" runat="server" Text="ภาวะแวดล้อมกับผลกระทบ" 
                                    style="font-weight: 700"></asp:Label>
                    &nbsp;
                                (<asp:Label ID="Label16" runat="server" 
                                    Text="การตรวจสอบปัญหาภาวะแวดล้อมใกล้เคียงเท่าที่สามารถตรวจสอบได้ ณ วันสำรวจ"></asp:Label>
                                )</td>                
                </td>
            </tr>            
            <tr>
                <td>
    <asp:Label ID="LabelProblemDesc" runat="server" Text="ปัญหา"></asp:Label>
            &nbsp;<asp:Label ID="LabelProblem" runat="server"></asp:Label>
            &nbsp;<asp:Label ID="Label49" runat="server" Text="(ถ้ามีอธิบายเพิ่มเติม) " Width="180px"></asp:Label>
    <asp:Label ID="LabelProblemDetail" runat="server"></asp:Label>
                </td>
            </tr>            
            <tr>
                <td>
                    <table>
                        <tr>
                            <td valign="top">
    <asp:Label ID="Label18" runat="server" Text="การประเมินราคา" 
                    style="font-weight: 700; font-size: large;" Width="180px"></asp:Label>
                                <br />
    <asp:Label ID="LabelBaySale" runat="server" Text="ข้อมูลซื้อขาย"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBuy_Sale_Comment" runat="server" cssclass="notes" 
                                    readonly="true" 
                                    textmode="MultiLine" 
                                    borderstyle="None" 
                                    borderwidth="0" >
                                </asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>            
            <tr>
                <td>
                <asp:Label ID="Label52" runat="server" Font-Bold="True" Text="วิธีการประเมินราคา"></asp:Label>
            &nbsp;<asp:Label ID="LabelAppraisalTypeName" runat="server"></asp:Label>
                </td>
            </tr>            
            <tr>
                <td>
                    &nbsp;</td>
            </tr>            
            <tr>
                <td>
                                
    <table width="100%">
        <tr>
            <td class="style11">
                <asp:Label ID="lblCollName" runat="server"></asp:Label>
                &nbsp;<asp:Label ID="Label53" runat="server" Text="เนื้อที่"></asp:Label>
            </td>
            <td class="style31">
                <asp:Label ID="lblSize" runat="server" Width="100px"></asp:Label>
            </td>
            <td class="style32">
                <asp:Label ID="lblSubUnit" runat="server" Width="135px"></asp:Label>&nbsp;
            </td>
            <td class="style30">
                <asp:Label ID="lblPriceWah" runat="server" ></asp:Label>
                &nbsp;บาท</td>
            <td class="style7">
                <asp:Label ID="Label55" runat="server" Text="เป็นเงิน"></asp:Label>
            </td>
            <td align="right">
                                  <cc1:mytext ID="txtLandTotal" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" Width="120px" 
                                      AutoCurrencyFormatOnKeyUp="True" BorderStyle="None" CssClass="txtbox" 
                                      BorderWidth="0px">0.00</cc1:mytext>
                                  &nbsp;บาท</td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="Label56" runat="server" Text="สิ่งปลูกสร้าง"></asp:Label>
            </td>
            <td class="style31">
                <asp:Label ID="lblBuilding_Detail" runat="server"></asp:Label>
            </td>
            <td class="style32">
                <asp:Label ID="lblSubUnit0" runat="server" Width="135px"></asp:Label>
            </td>
            <td class="style30">
                &nbsp;</td>
            <td class="style7">
                <asp:Label ID="Label57" runat="server" Text="เป็นเงิน"></asp:Label>
            </td>
            <td align="right">
                                  <cc1:mytext ID="txtBuildingPrice" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" Width="120px" 
                                      AutoCurrencyFormatOnKeyUp="True" BorderStyle="None" BorderWidth="0px" 
                                      CssClass="txtbox">0.00</cc1:mytext>
                                  &nbsp;บาท</td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="Label48" runat="server" Text="ที่ดินพร้อมสิ่งปลูกสร้าง"></asp:Label>
            </td>
            <td class="style31">
                <asp:Label ID="lblLand_Build" runat="server" ></asp:Label>
            </td>
            <td class="style32">
                <asp:Label ID="lblSubUnit1" runat="server" Width="135px"></asp:Label>
            </td>
            <td class="style30">
                <asp:Label ID="lblTotal3" runat="server" ></asp:Label>
            </td>
            <td class="style7">
                <asp:Label ID="Label60" runat="server" Text="เป็นเงิน"></asp:Label>
            </td>
            <td align="right">
                                  <cc1:mytext ID="txtSubTotal" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" Width="120px" 
                                      AutoCurrencyFormatOnKeyUp="True" BorderStyle="None" BorderWidth="0px" 
                                      CssClass="txtbox">0.00</cc1:mytext>
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
                <asp:Label ID="Label88" runat="server" Text="รวมเป็นเงิน"></asp:Label>
            </td>
            <td align="right">
                <cc1:mytext ID="txtGrandTotal" runat="server" AllowUserKey="num_Numeric" 
                    AutoCurrencyFormatOnKeyUp="True" 
                    EnableTextAlignRight="True" Width="120px" BorderStyle="None" 
                    BorderWidth="0px" CssClass="txtbox">0.00</cc1:mytext>
                &nbsp;บาท</td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td colspan="3">
                <asp:Label ID="lblThaiBaht" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
                                
                </td>
            </tr>            
            <tr>
                <td>
                <asp:Label ID="Label62" runat="server" Text="ราคาประเมินครั้งล่าสุด"></asp:Label>
                &nbsp;<asp:Label ID="LabelLast_Appraisal_Detail" runat="server"></asp:Label>
                </td>
            </tr>            
            <tr>
                <td class="style1">
                <asp:Label ID="Label63" runat="server" Text="COMMENT"></asp:Label>
            &nbsp;<asp:Label ID="LabelCommentValue" runat="server"></asp:Label>
                </td>
            </tr>            
            <tr>
                <td>
                <asp:Label ID="Label64" runat="server" Text="WARNING"></asp:Label>
            &nbsp;<asp:Label ID="LabelWarningValue" runat="server"></asp:Label>
                </td>
            </tr>            
            <tr>
                <td>
                    <asp:TextBox ID="txtWarning_Detail" runat="server" cssclass="notes" 
readonly="true" 
textmode="MultiLine" 
borderstyle="None" 
borderwidth="0" ></asp:TextBox>
                </td>
            </tr>            
            <tr>
                <td align="right">
                    <table>
                        <tr >
                            <td></td>
                            <td>
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
                            <asp:Label ID="Label89" runat="server" Text="ลงชื่อ"></asp:Label>
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
                            &nbsp;</td>
                        <td>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="style8">
                            &#160;&#160;
                        </td>
                        <td align="center">
                            <asp:Label ID="lblAppraisal_Name" runat="server" style="font-weight: 700" ></asp:Label>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td class="style8" valign="top">
                            &#160;&#160;
                        </td>
                        <td class="style4">
                            &nbsp;</td>
                        <td>
                            &#160;&#160;</td>
                    </tr>
                    <tr>
                        <td class="style8" valign="top">
                            &nbsp;</td>
                        <td class="style4">
                            <asp:Label ID="Label59" runat="server" 
                                Text="..............................................."></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label67" runat="server" Text="วัน / เดือน / ปี"></asp:Label>
                        </td>
                    </tr>
                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>            
            <tr>
                <td align="right">
                    &nbsp;</td>
            </tr>            
            <tr>
                <td class="Center">
                <asp:Label ID="Label69" runat="server" Text="ความเห็นคณะอนุกรรมพิจารณาการประเมินมูลค่าสินทรัพย์ภายใน"
                    Style="font-weight: 700"></asp:Label>
                </td>
            </tr>            
            <tr>
                <td>
                <table width="100%" >
                    <tr>
                        <td class="style22" >
                            &nbsp;</td>
                        <td width="30%">
                            &nbsp;</td>
                        <td class="style29">
                            &nbsp;</td>
                        <td width="30%">
                            &nbsp;</td>
                        <td class="style26">
                            &nbsp;</td>
                        <td width="30%">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style22" >
                            <asp:Label ID="Label70" runat="server" Text="1.)"></asp:Label>
                        </td>
                        <td width="30%">
                            &nbsp;</td>
                        <td class="style29">
                            <asp:Label ID="Label71" runat="server" Text="2.)"></asp:Label>
                        </td>
                        <td width="30%">
                            &nbsp;</td>
                        <td class="style26">
                            <asp:Label ID="Label72" runat="server" Text="3.)"></asp:Label>
                        </td>
                        <td width="30%">
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
                            &nbsp;</td>
                        <td 
                            
                            
                            
                            style="border-bottom-style: dotted; border-bottom-width: thin; border-bottom-color: #000000;">
                            &nbsp;</td>
                        <td class="style29">
                            &nbsp;</td>
                        <td style="border-bottom-style: dotted; border-bottom-width: thin; border-bottom-color: #000000;">
                            &nbsp;</td>
                        <td class="style26">
                            &nbsp;</td>
                        <td style="border-bottom-style: dotted; border-bottom-width: thin; border-bottom-color: #000000;">
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
                            <asp:Label ID="lblApprove1" runat="server" style="font-weight: 700"></asp:Label>
                        </td>
                        <td class="style29">
                            &#160;&#160;
                        </td>
                        <td align="center">
                            <asp:Label ID="lblApprove2" runat="server" style="font-weight: 700"></asp:Label>
                        </td>
                        <td class="style26">
                            &#160;&#160;
                        </td>
                        <td align="center">
                            <asp:Label ID="lblApprove3" runat="server" style="font-weight: 700"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style22">
                            &#160;&#160;
                        </td>
                        <td align="center">
                            <asp:Label ID="lblPos_Approve1" runat="server" style="font-weight: 700" 
                                Width="130px"></asp:Label>
                        </td>
                        <td class="style29">
                            &#160;&#160;
                        </td>
                        <td align="center">
                            <asp:Label ID="lblPos_Approve2" runat="server" style="font-weight: 700" 
                                Width="130px"></asp:Label>
                        </td>
                        <td class="style26">
                            &#160;&#160;
                        </td>
                        <td align="center" >
                            <asp:Label ID="lblPos_Approve3" runat="server" style="font-weight: 700" 
                                ></asp:Label>
                        </td>
                    </tr>
                </table>
                </td>
            </tr>            
        </table>        
        </asp:Panel>

    </div>
    <asp:HiddenField ID="hdfReq_Id" runat="server" />
    <asp:HiddenField ID="hdfHub_Id" runat="server" />
        
    <asp:HiddenField ID="hdfAID" runat="server" />
    <asp:HiddenField ID="hdfCollType" runat="server" />
    <asp:HiddenField ID="hdfTemp_AID" runat="server" />
        
    <asp:SqlDataSource ID="SDSWarning" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Warning_ID], [Warning_Name] FROM [Warning]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSComment" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Comment_ID], [Comment_Name] FROM [Comment]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSAppraisal_Type" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [App_Type_ID], [App_Type_Name] FROM [Appraisal_Type]">
    </asp:SqlDataSource>
    
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
        
    <asp:Label ID="LabelProvinceName" runat="server" Visible="False"></asp:Label>
        
    </form>
</body>
</html>
