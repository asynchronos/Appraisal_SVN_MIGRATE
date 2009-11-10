<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Print_Price3.aspx.vb" Inherits="Print_Price3" %>

<%@ Register assembly="Mytextbox" namespace="Mytextbox" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
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
        .style33
        {
            height: 22px;
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
        .style28
        {
            width: 119px;
        }
        .style29
        {
            width: 10px;
        }
        .style27
        {
            width: 132px;
        }
        .style26
        {
            width: 21px;
        }
        .style23
        {
            width: 87px;
        }
        .style34
        {
            width: 595px;
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
        </style>
</head>
<body style=" font-family:Tahoma; font-size:medium;">
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td align="center">
                <img alt="BayLogo" src="Images/logo_bank.jpg" 
                    style="width: 344px; height: 89px" /></td>
            </tr>
            <tr>
                <td align="center" 
                    style="text-align: center; border-bottom-style: double; border-bottom-width: thin; border-bottom-color: #000000;">
                <asp:Label ID="lblDescript1" runat="server" 
                    Text="รายงานการประเมินราคาหลักประกัน" 
                    style="font-weight: 700; font-size: x-large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                <asp:Label ID="Label82" runat="server" 
                    style="font-weight: 700; font-size: large" Text="ที่ ปร."></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label83" runat="server" Text="__________________/"></asp:Label>
                <asp:Label ID="lblYear" runat="server" 
                    style="font-weight: 700; font-size: medium"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <table class="style1">
                        <tr>
                            <td>
                <asp:Label ID="Label1" runat="server" Font-Size="Large" 
                    style="font-weight: 700" Text="เรียน"></asp:Label>
            &nbsp;<asp:Label ID="lblSubject" runat="server" style="font-size: medium; font-weight: 700"></asp:Label>
                            </td>
                            <td>
                <asp:Label ID="lblAID_d" runat="server" Font-Size="Large" 
                    style="font-weight: 700" Text="AID"></asp:Label>
            &nbsp;<asp:Label ID="lblAID" runat="server" style="font-weight: 700; font-size: medium"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table class="style1">
                        <tr>
                            <td class="style2">
                <asp:Label ID="Label3" runat="server" Text="ผู้ขอสินเชื่อ" Font-Size="Large" 
                    style="font-weight: 700"></asp:Label>
            &nbsp;<span style="color: Red"><asp:Label ID="lblCifName" runat="server" Width="300px" 
                    style="font-weight: 700; color: #000000"></asp:Label></span>
                            </td>
                            <td>
                <asp:Label ID="Label2" runat="server" Text="Cif" style="font-weight: 700"></asp:Label>
                &nbsp;
                <asp:Label ID="lblCif" runat="server" style="font-weight: 700" Width="130px"></asp:Label>
                            </td>
                            <td>
                <asp:Label ID="Label4" runat="server" Text="วันที่รับเรื่อง" 
                    style="font-weight: 700"></asp:Label>
                &nbsp;
                <asp:Label ID="lbReceive_Date" runat="server" style="font-weight: 700"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style2" colspan="2">
    <asp:Label ID="Label80" runat="server" Text="สาขา/ฝ่ายงาน" Font-Bold="True" 
                    Font-Size="Large"></asp:Label>
    
                            &nbsp;<span style="color: Red"><asp:Label ID="lblBranch" runat="server" Width="300px" 
                    style="font-weight: 700; color: #000000"></asp:Label></span>
    
                            </td>
                            <td>
                <asp:Label ID="Label79" runat="server" Text="วันที่ประเมิน" 
                    style="font-weight: 700"></asp:Label>
                &nbsp;<asp:Label ID="lbAppraisal_Date" runat="server" style="font-weight: 700"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td width="2">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="หลักประกันที่ดิน" 
                        Width="150px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                <asp:Label ID="lblDetail1" runat="server" Width="1100px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                <asp:Label ID="lblDetail2" runat="server" Width="1100px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                <asp:Label ID="lblDetail3" runat="server" Width="1100px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                <asp:Label ID="lblDetail4" runat="server" Width="1100px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                <asp:Label ID="Label22" runat="server" Text="ที่ตั้งและสภาพที่ดิน" 
                    Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                <asp:Label ID="lblLandDetail1" runat="server" Width="1100px"></asp:Label>
                </td>
            </tr>
                        <tr>
                <td>
                <asp:Label ID="lblLandDetail2" runat="server" Width="1100px"></asp:Label>
                            </td>
            </tr>
                        <tr>
                <td>
                    <asp:Label ID="lblLandDetail3" runat="server" Width="1100px"></asp:Label>
                </td>
            </tr>
                        <tr>
                <td>
                <asp:Label ID="lblLandDetail4" runat="server" Width="1100px"></asp:Label>
                            </td>
            </tr>
                        <tr>
                <td>
                <asp:Label ID="lblLandDetail5" runat="server" Width="1100px"></asp:Label>
                            </td>
            </tr>
                        <tr>
                <td>
                    <asp:Label ID="lblLandDetail6" runat="server" Width="1100px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLandDetail7" runat="server" Width="1100px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLandDetail8" runat="server" Width="1100px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLandDetail9" runat="server" Width="1100px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLandDetail10" runat="server" Width="1100px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                <asp:Label ID="Label46" runat="server" Font-Bold="True" 
                    Text="ภาวะแวดล้อมกับผลกระทบ"></asp:Label>&nbsp;<asp:Label
                    ID="Label47" runat="server" 
                    Text="(การตรวจสอบปัญหาภาวะแวดล้อมใกล้เคียงเท่าที่สามารถตรวจสอบได้ ณ วันสำรวจ)"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblProblem" runat="server" 
                        style="font-size: medium; font-weight: 700"></asp:Label>
                            <asp:Label ID="lblProblem_Detail" runat="server" 
                        style="font-size: medium; font-weight: 700"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                <asp:Label ID="Label50" runat="server" Font-Bold="True" Text="การประเมินราคา"></asp:Label>
                    <asp:Label
                    ID="Label51" runat="server" Text="ข้อมูลการซื้อขาย"></asp:Label>
                </td>
            </tr> 
            <tr>
                <td>
                    <asp:TextBox ID="txtBuy_Sale_Comment" runat="server" cssclass="notes" 
readonly="true" 
textmode="MultiLine" 
borderstyle="None" 
borderwidth="0" ></asp:TextBox>
                </td>
            </tr> 
            <tr>
                <td>
                <asp:Label ID="Label52" runat="server" Font-Bold="True" 
                    Text="วิธีการประเมินราคา"></asp:Label>
            &nbsp;<asp:Label ID="lblAppraisal_Type" runat="server" 
                        style="font-size: medium; font-weight: 700"></asp:Label>
                </td>
            </tr> 
            <tr>
                <td>
    <table width="100%">
        <tr>
            <td class="style11">
                <asp:Label ID="lblCollName" runat="server"></asp:Label>
                &nbsp;</td>
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
                <asp:Label ID="Label81" runat="server" Text="รวมเป็นเงิน"></asp:Label>
            </td>
            <td align="right">
                <cc1:mytext ID="txtGrandTotal" runat="server" AllowUserKey="num_Numeric" 
                    AutoCurrencyFormatOnKeyUp="True" 
                    EnableTextAlignRight="True" Width="120px" BorderStyle="None" 
                    BorderWidth="0px" CssClass="txtbox">0.00</cc1:mytext>
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
                </td>
            </tr> 
            <tr>
                <td>
                <asp:Label ID="Label61" runat="server" Text="COMMENT"></asp:Label>
                &nbsp;<asp:Label ID="lblComment" runat="server"></asp:Label>
                </td>
            </tr>                                                                                                             
            <tr>
                <td class="style33">
                <asp:Label ID="Label62" runat="server" Text="WARNING"></asp:Label>
                &nbsp;
                <asp:Label ID="lblWarning" runat="server"></asp:Label>
                </td>
            </tr>                                                                                                             
            <tr>
                <td class="style33">
                    <asp:TextBox ID="txtWarning_Detail" runat="server" cssclass="notes" 
readonly="true" 
textmode="MultiLine" 
borderstyle="None" 
borderwidth="0" ></asp:TextBox>
                </td>
            </tr>                                                                                                             
            <tr>
                <td>
                    <table class="style1">
                        <tr>
                            <td valign="top" class="style34">
                                &nbsp;</td>
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
                <td>
                    &nbsp;</td>
            </tr>                                                                                                             
            <tr>
                <td style="border-top-style: solid; border-top-width: thin; border-top-color: #000000">
                </td>
            </tr>                                                                                                             
            <tr>
                <td align="center">
                <asp:Label ID="Label69" runat="server" Style="font-weight: 700" 
                    Text="ความเห็นคณะอนุกรรมการพิจารณาการประเมินมูลค่าสินทรัพย์ภายใน"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                <table width="100%" >
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
                        
                            &nbsp;</td>
                    </tr>
                </table>
                </td>
            </tr>
            <tr>
                <td>
    
    <asp:HiddenField ID="hdfReq_Id" runat="server" />
    <asp:HiddenField ID="hdfTemp_AID" runat="server" />
                </td>
            </tr>            
        </table>
    
    </div>
    </form>
</body>
</html>
