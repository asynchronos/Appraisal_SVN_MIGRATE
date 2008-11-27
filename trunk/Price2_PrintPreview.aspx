<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Price2_PrintPreview.aspx.vb" Inherits="Price2_PrintPreview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Print Short Form</title>
    <style type="text/css">
        .style1
        {
            width: 90%;
        }
        .style2
        {
            width: 215px;
        }
        .style3
        {
            width: 243px;
        }
        .style4
        {
            width: 319px;
        }
        .style5
        {
            width: 38px;
        }
        .style6
        {
            text-decoration: underline;
            font-weight: bold;
        }
        .style7
        {
            width: 236px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <asp:Button 
        ID="Button1" runat="server" Text="Print Page" />
    <br />
    <asp:Panel ID="Panel1" runat="server">
<div>
        <table class="style1">
            <tr>
                <td align="right" class="style7" valign="top" >
                    <img alt="Krungsri Logo" src="Images/Krungsri%20Logo1.jpg" 
                        style="width: 74px; height: 74px" /></td>
                <td valign="top">
        <table class="style1">
            <tr>
                <td><h5 style="text-align:center; vertical-align:top;">ธนาคารกรุงศรีอยุธยา จำกัด 
                    (มหาชน)</h5>
                      
                </td>
            </tr>
                    
            <tr>
                <td><h5 style="text-align:center;">BANK OF AYUDHYA PUBLIC COMPANY LIMITED</h5></td>
            </tr>
            <tr>
                <td><h5 style="text-align:center;">เอกสารประกาอบการพิจารณาราคาประเมินหลักประกันเบื้องต้น</h5></td>
            </tr>
            <tr>
                <td><h5 style="text-align:center;">เพื่อใช้สำหรับสินเชื่อทั่วไป,สินเชื่อรายย่อย วงเงินสินเชื่อไม่เกิน 10 ล้านบาท</h5></td>
            </tr>
        </table>
                </td>
            </tr>
        </table>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox 
            ID="Chk1" runat="server" />
        สินเชื่อทั่วไป                 
        <asp:CheckBox ID="Chk2" runat="server" />
        สินเชื่อรายย่อย                   
        <asp:CheckBox ID="Chk3" runat="server" />
        อื่น ๆ
        <br />
        <br />
        <b>ชื่อผู้ขอ</b> ราย&nbsp;
        <asp:Label ID="lblCifName" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;สาขา&nbsp;
        <asp:Label ID="lblBranchname" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CIF
        <asp:Label ID="lblCif" runat="server"></asp:Label>
        <br />
        <b>หลักประกัน</b>         <asp:Label ID="lblCollTypeName" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#32;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ชันที่
        <asp:Label ID="lblFloor" runat="server"></asp:Label>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;เลขที่ <asp:Label ID="lblAddno" 
            runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ตำบล
        <asp:Label ID="lblTumbon" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;อำเภอ
        <asp:Label ID="lblAmphur" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;จังหวัด
        <asp:Label ID="lblPrivinceName" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;เนื้อที่
        <asp:Label ID="lblSizeAll" runat="server"></asp:Label>
        <br />
        <b>ที่ตั้งหลักประกัน</b>&nbsp; ตั้งอยู่บนถนน &nbsp;<asp:Label 
            ID="lblRoad" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ตั้งอยู่
        <asp:Label ID="lblRoad_Detail" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ระยะ&nbsp;&nbsp;<asp:Label 
            ID="lblMeter" runat="server"></asp:Label>
        &nbsp;&nbsp;เมตร/กิโลเมตร<br />
        <b>สภาพที่ดิน</b>
        <asp:Label ID="lblLand_State" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;รายละเอียดสภาพที่ดิน
        <asp:Label ID="lblLand_State_Detail" runat="server"></asp:Label>
        <br />
        <b>ถนนหน้าหลักประกัน</b>
        <asp:Label ID="lblRoad_Forntoff" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ผิวจราจรกว้าง
        <asp:Label ID="lblRoadWidth" runat="server"></asp:Label>
&nbsp;เมตร<br />
        <b>ทำเล</b>
        <asp:Label ID="lblSite" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; รายละเอียดทำเล
        <asp:Label ID="lblSite_Detail" runat="server"></asp:Label>
        <br />
        <b>สาธารณูปโภค</b>
        <asp:Label ID="lbllPublic_Utility" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; รายละเอียดสาธารณูปโภค
        <asp:Label ID="lbllPublic_Utility_Detail" runat="server"></asp:Label>
        <br />
        <b>การใช้ประโยชน์ในอาคาร</b> 
        <asp:Label ID="lblBinifit" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;รายละเอียดการใช้ประโยชน์ในอาคาร
        <asp:Label ID="lblBinifit_Detail" runat="server"></asp:Label>
        <br />
        <b>แนวโน้มความเจริญ</b>
        <asp:Label ID="lblTendency" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;สภาพคล่องการซื้อขาย<asp:Label 
            ID="lblBuySale_State" runat="server"></asp:Label>
        <br />
        <b>สิ่งปลูกสร้าง</b> บ้านเลขที่         <asp:Label ID="lblBuild_No" runat="server"></asp:Label>
        <br />
        <b>ลักษณะอาคาร</b>
        <asp:Label ID="lblBuild_Character" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ชั้น
        <asp:Label ID="lblBuild_Floor" runat="server"></asp:Label>
&nbsp;&nbsp;หลัง
        <asp:Label ID="lblItem" runat="server"></asp:Label>
        <br />
        <b>โครงสร้างอาคาร</b>
        <asp:Label ID="lblBuild_Construct" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;หลังคา
        <asp:Label ID="lblRoof" runat="server"></asp:Label>
&nbsp;<br />
        รายละเอียดเพิ่มเติม(ถ้ามี)         <asp:Label ID="lblDetail_Other" 
            runat="server"></asp:Label>
        <br />
        <b>สภาพอาคาร</b>
        <asp:Label ID="lblBuild_State" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <table class="style1">
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style2">
                    รายการทีรายการที่ 1 เป็นเงิน</td>
                <td class="style4">
        <asp:Label ID="lblPriceItem1" runat="server"></asp:Label>
                </td>
                <td class="style3">
                    รายงานที่ 2 เป็นเงิน</td>
                <td>
        <asp:Label ID="lblPriceItem2" runat="server" Width="100px"></asp:Label>
                </td>
                <td class="style5">
                    บาท</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style2">
                    - ที่ดินเนื้อที่&nbsp;</td>
                <td class="style4">
         <asp:Label ID="lblSize" runat="server"></asp:Label>
&nbsp;ไร่ ตรว. ละ
        <asp:Label ID="lblPriceWah" runat="server"></asp:Label>
&nbsp;บาท</td>
                <td class="style3">
&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; เป็นเงิน
                </td>
                <td>
        <asp:Label ID="lblTotal1" runat="server" Width="100px"></asp:Label>
                </td>
                <td class="style5">
                    บาท</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style2">
                    - สิ่งปลูกสร้าง</td>
                <td class="style4">
        <asp:Label ID="lblBuilding_Detail" runat="server"></asp:Label>
                </td>
                <td class="style3">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; เป็นเงิน
                </td>
                <td>
        <asp:Label ID="lblTotal2" runat="server" Width="100px"></asp:Label>
                </td>
                <td class="style5">
                    บาท</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style2">
                    - ที่ดินพร้อมสิ่งปลูกสร้าง</td>
                <td class="style4">
        <asp:Label ID="lblLand_Build" runat="server"></asp:Label>
                </td>
                <td class="style3">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; เป็นเงิน</td>
                <td>
        <asp:Label ID="lblTotal3" runat="server" Width="100px"></asp:Label>
                </td>
                <td class="style5">
                    บาท&nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style3">
&nbsp;<b>รวมราคาประเมินเบื้องต้น</b> เป็นเงิน
                </td>
                <td>
        <asp:Label ID="lblGrandTotal" runat="server" Width="100px"></asp:Label>
                </td>
                <td class="style5">
                    บาท</td>
            </tr>
        </table>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <b>ข้อสังเกตุ</b>&nbsp; ให้นำเอกสารประกอบเพิ่มเติม
        <asp:CheckBox ID="chkDoc1" runat="server" Text="ใบอนุญาติปลูกสร้าง" 
            Enabled="False" />
&nbsp;
        <asp:CheckBox ID="chkDoc2" runat="server" Text="เรื่องทางภารจำยอม" 
            Enabled="False" />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        อื่น ๆ ระบุ
        <asp:Label ID="lblDocument_Detail" runat="server"></asp:Label>
                <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ลงชื่อ <asp:Label ID="lblAppraisalName" runat="server" Width="180px"></asp:Label>
        ผู้แจ้งราคาประเมินเบื้องต้น<br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(..............................................)&nbsp;&nbsp; <asp:Label ID="lblYears" runat="server"></asp:Label>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        ราคาประเมินนี้เป็นราคาประเมินเบื้องต้น 
        ซึ่งสามารถนำไปใช้ประกอบการพิจารณาสินเชื่อได้ เมื่อได้จัดทำรายงานและได้รับ   ความเห็นชอบจากคณะกรรมการพิจารณาประเมินมูลค่าสินทรัพย์ภายในแล้ว&nbsp; 
        จึงจะเป็นราคาประเมินของธนาคารที่สมบูรณ์&nbsp; หากราคาประเมินของธนาคารแตกต่างไปจากราคาประเมินเบี้องต้นนี้ 
        ฝ่ายประเมินราคาจะแจ้งให้สาขาและฝ่ายงานที่เกี่ยวข้องทรางโดยเร็ว<br />
        <br />
        ลงชื่อ 
        ........................................................หัวหน้ากลุ่มงานประเมินราคาหลักประกันภูมิภาค<br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        (.........................................................)&nbsp;&nbsp;&nbsp; 
        ......./............./........... วัน/เดือน/ปี<br />
        <br />
        <span class="style6">เอกสารประกอบการประเมินราคาเบื้องต้น</span><br />
&nbsp;&nbsp;&nbsp; 1. แบบฟอร์มขอให้สำรวจประเมินราคา/แผนที่สังเขป พร้อมเอกสารสิทธิ์ฯ 
        ของหลักประกัน<br />
&nbsp;&nbsp;&nbsp; 2. แบบสำรวจประเมินเดิมของธนาคาร(กรณีหลักประกันเดิม)<br />
&nbsp;&nbsp;&nbsp; 3. ใบเสร็จ ค่าธรรมเนียมการประเมินราคา<br />
        <span class="style6">หมายเหตุ</span>&nbsp; รายงานนี้ใช้เฉพาะภายในของธนาคารเท่านั้น 
        ไม่พึงเปิดเผยและใช้ประโยชน์ต่อบุคคลภายนอก</div>    
    </asp:Panel>

    </form>       
</body>
</html>
