﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Appraisal_Price3_Print_CollType70.aspx.vb" Inherits="Appraisal_Price3_Print_CollType70" %>

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
        .style3
        {
            height: 22px;
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
        .style5
        {
            width: 226px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h5 style="text-align:center">รายละเอียดส่งปลูกสร้าง</h5>
        
    </div>
    <table class="style1">
        <tr>
            <td colspan="6">
                ลูกค้าราย
                <asp:Label ID="lblCifName" runat="server"></asp:Label>
            &nbsp;Cif
                <asp:Label ID="lblCif" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5">
                สิ่งปลูกสร้าง&nbsp;&nbsp;&nbsp;&nbsp;บ้านเลขที่&nbsp;</td>
            <td>
                <asp:Label ID="lblAddressNo" runat="server"></asp:Label>
            </td>
            <td>
                ปลูกสร้างบนโฉนดเลขที่</td>
            <td>
                <asp:Label ID="lbChanodeNo" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="6">
                เขตการปกครอง&nbsp;&nbsp;ตำบล
                <asp:Label ID="lblTumbon" runat="server"></asp:Label>
            &nbsp;อำเภอ
                <asp:Label ID="lblAmphur" runat="server"></asp:Label>
            &nbsp;จังหวัด
                <asp:Label ID="lblProvinceName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5">
                ลักษณะ</td>
            <td>
                <asp:CheckBox ID="CheckBox1" runat="server" Text="ตึกแถว" />
            &nbsp;<asp:Label ID="lblFloors1" runat="server"></asp:Label>
&nbsp;ชั้น</td>
            <td>
                <asp:CheckBox ID="CheckBox2" runat="server" Text="ทาวน์เฮ้าส์" />
            &nbsp;<asp:Label ID="lblFloors0" runat="server"></asp:Label>
&nbsp;ชั้น</td>
            <td>
                <asp:CheckBox ID="CheckBox3" runat="server" Text="บ้านพักอาศัย" />
            &nbsp;<asp:Label ID="lblFloors" runat="server"></asp:Label>
&nbsp;ชั้น</td>
            <td>
                <asp:CheckBox ID="CheckBox4" runat="server" Text="อื่น ๆ" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td colspan="4" rowspan="3" valign="top">
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                โครงสร้างหลักของอาคาร</td>
            <td>
                <asp:Label ID="lblBuilding_Struc" runat="server"></asp:Label>
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
            <td colspan="5" rowspan="10">
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
            CellPadding="2" DataKeyNames="ID,Req_Id,Hub_Id,Temp_AID,Floors" 
            DataSourceID="DdsPrice3_70_Detail" ForeColor="Black" GridLines="None" PageSize="8">
            <Columns>
                <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="False">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Req_Id" SortExpression="Req_Id" Visible="False">
                    <EditItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Req_Id") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblReq_Id" runat="server" Text='<%# Bind("Req_Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Hub_Id" SortExpression="Hub_Id" Visible="False">
                    <EditItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Hub_Id") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblHub_Id" runat="server" Text='<%# Bind("Hub_Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Temp_AID" SortExpression="Temp_AID" 
                    Visible="False">
                    <EditItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("Temp_AID") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblTemp_AID" runat="server" Text='<%# Bind("Temp_AID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="โครงสร้างหลักอาคาร" SortExpression="Main_Construction">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Main_Construction") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblMain_Construction" runat="server" Text='<%# Bind("Main_Construction") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ชั้น" SortExpression="Floors">
                    <EditItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("Floors") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblFloors" runat="server" Text='<%# Bind("Floors") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>                
                <asp:TemplateField HeaderText="คอนกรีต" SortExpression="Concrete">
                    <ItemStyle HorizontalAlign="Center" />
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Concrete") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:checkbox ID="chkConcrete" runat="server" checked='<%# Bind("Concrete") %>'></asp:checkbox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="แกรนิต" SortExpression="Granite">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Granite") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:checkbox ID="chkGranite" runat="server" checked='<%# Bind("Granite") %>'></asp:checkbox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ลามิเนต/ปาร์เก้" SortExpression="Parquet">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Parquet") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:checkbox ID="chkParquet" runat="server" checked='<%# Bind("Parquet") %>'></asp:checkbox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="เซรามิค" SortExpression="Ceramic">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Ceramic") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:checkbox ID="chkCeramic" runat="server" checked='<%# Bind("Ceramic") %>'></asp:checkbox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ไม้" SortExpression="Wood">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Wood") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:checkbox ID="chkWood" runat="server" checked='<%# Bind("Wood") %>'></asp:checkbox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="อื่น ๆ" SortExpression="Other">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Other") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:checkbox ID="chkOther" runat="server" checked='<%# Bind("Other") %>'></asp:checkbox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="รายละเอียดอื่น ๆ" SortExpression="Other_Detail">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Other_Detail") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblOther_Detail" runat="server" Text='<%# Bind("Other_Detail") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BrickWall" SortExpression="BrickWall">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("BrickWall") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:checkbox ID="chkBrickWall" runat="server" checked='<%# Bind("BrickWall") %>'></asp:checkbox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BlockBrickWall" SortExpression="BlockBrickWall">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("BlockBrickWall") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:checkbox ID="chkBlockBrickWall" runat="server" checked='<%# Bind("BlockBrickWall") %>'></asp:checkbox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="WoodWall" SortExpression="WoodWall">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("WoodWall") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:checkbox ID="chkWoodWall" runat="server" checked='<%# Bind("WoodWall") %>'></asp:checkbox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="OtherWall" SortExpression="OtherWall">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("OtherWall") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:checkbox ID="chkOtherWall" runat="server" checked='<%# Bind("OtherWall") %>'></asp:checkbox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="OtherWall_Detail" 
                    SortExpression="OtherWall_Detail">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox13" runat="server" 
                            Text='<%# Bind("OtherWall_Detail") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblOtherWall_Detail" runat="server" Text='<%# Bind("OtherWall_Detail") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="Tan" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
        </asp:GridView>

    <asp:SqlDataSource ID="DdsPrice3_70_Detail" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="GET_PRICE3_70_DETAIL" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="HiddenField1" Name="ID" PropertyName="Value" 
                Type="Int32" />
            <asp:ControlParameter ControlID="HiddenField2" Name="Req_Id" 
                PropertyName="Value" Type="Int32" />
            <asp:ControlParameter ControlID="HiddenField3" Name="Hub_Id" 
                PropertyName="Value" Type="Int32" />
            <asp:ControlParameter ControlID="HiddenField4" Name="Temp_AID" 
                PropertyName="Value" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    
            </td>
            <td>
                &nbsp;</td>
        </tr>  
        <tr>
            <td>
                &nbsp;</td>
        </tr> 
        <tr>
            <td>
                &nbsp;</td>
        </tr> 
        <tr>
            <td>
                &nbsp;</td>
        </tr>  
        <tr>
            <td>
                &nbsp;</td>
        </tr>  
        <tr>
            <td>
                &nbsp;</td>
        </tr> 
        <tr>
            <td>
                &nbsp;</td>
        </tr> 
        <tr>
            <td>
                &nbsp;</td>
        </tr> 
        <tr>
            <td>
                &nbsp;</td>
        </tr> 
        <tr>
            <td>
                &nbsp;</td>
        </tr> 
        <tr>
            <td class="style5">
                สภาพการตกแต่ง</td>
            <td>
                <asp:CheckBox ID="CheckBox5" runat="server" Text="ตกแต่งพร้อมอยู่" />
            </td>
            <td>
                <asp:CheckBox ID="CheckBox6" runat="server" Text="ตกแต่งบางส่วน" />
            </td>
            <td>
                <asp:CheckBox ID="CheckBox7" runat="server" Text="ไม่ตกแต่ง" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr> 
        <tr>
            <td class="style2" colspan="5" rowspan="5" valign="top">
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
            <td class="style2">
                </td>
        </tr> 
        <tr>
            <td>
                &nbsp;</td>
        </tr> 
        <tr>
            <td>
                &nbsp;</td>
        </tr>   
        <tr>
            <td>
                &nbsp;</td>
        </tr> 
        <tr>
            <td>
                &nbsp;</td>
        </tr> 
        <tr>
            <td class="style5">
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
    <br />
    - มูลค่าสิ่งปลูกสร้าง ณ ปัจจุบัน<br />
    - 
    ราคาประเมินค่าก่อสร้างถื่อตามมาตรฐานของสมาคมผู้ประเมินค่าทรัพย์สินแห่งประเทศไทย 
    พ.ศ. 2550<br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; รวมราคาสิ่งปลูกสร้าง&nbsp;<asp:Label ID="lblItems" runat="server"></asp:Label>
&nbsp;รายการ&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    เป็นเงินทั้งสิ้น&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblGrandTotal0" 
        runat="server"></asp:Label>
                        &nbsp;&nbsp;&nbsp; 
    บาท<br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    ลงชื่อ<br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    วันที่<asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="HiddenField2" runat="server" />
        <asp:HiddenField ID="HiddenField3" runat="server" />
        <asp:HiddenField ID="HiddenField4" runat="server" />
        <asp:HiddenField ID="HiddenField5" runat="server" />

        </form>
</body>
</html>