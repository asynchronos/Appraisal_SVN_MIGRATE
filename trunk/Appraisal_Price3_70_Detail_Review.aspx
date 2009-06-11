<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Appraisal_Price3_70_Detail_Review.aspx.vb" Inherits="Appraisal_Price3_70_Detail_Review" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>รายละเอียดโครงสร้างหลักของอาคาร</title>
    <script src="Js/CustomDialog.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            color: #6600FF;
            font-weight: bold;
        }
    </style>
    <script type="text/javascript">
    <!--
        function AlertMessage() {
            var r = confirm('คุณมีข้อมูลไม่ครบตามที่ระบบต้องการ?');
            if (r == true)
                event.returnValue = true;
            else
                event.returnValue = false;
        }

        function ShowMessage() {
            SetText('Yes', 'No');
            if (document.getElementById('txtBuilding_Struc').value == '' || document.getElementById('txtBuildFloor').value == '') {
                window.alert('คุณมีข้อมูลไม่ครบตามที่ระบบต้องการ');
            }
            else {
                DisplayConfirmMessage('บันทึกเสร็จสมบูรณ์ คุณต้องการเพิ่มข้อมูลอีกหรือไม่?', 240, 120)
                SetDefaultButton('btnConfOK');
                return false;
            }
        }
    //-->
    </script>
    
</head>
<body>
    <form id="form1" runat="server">
    			<div id="divConfMessage" runat="server" style="BORDER-RIGHT:black thin solid; BORDER-TOP:black thin solid; DISPLAY:none; Z-INDEX:200; BORDER-LEFT:black thin solid; BORDER-BOTTOM:black thin solid">
				<div style="BACKGROUND-COLOR: #6699cc;TEXT-ALIGN: center" id="confirmText">
				</div>
				<div style="Z-INDEX: 105;HEIGHT: 2%;BACKGROUND-COLOR: white;TEXT-ALIGN: center">
				</div>
				<div style="Z-INDEX: 105;BACKGROUND-COLOR: white;TEXT-ALIGN: center">
					<asp:Button ID="btnConfOK" Runat="server" Text="OK"></asp:Button>
					<asp:Button ID="btnConfCancel" Runat="server" Text="Cancel"></asp:Button>
				</div>
			</div>
    <div>
        <table>
            <tr>
                <td>
                    โครงสร้างหลักอาคารเป็น</td>
                <td colspan="3">
                    <asp:TextBox ID="txtBuilding_Struc" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>  
            <tr>
                <td>
                    ชั้น</td>
                <td>
                    <asp:TextBox ID="txtBuildFloor" runat="server" Width="60px"></asp:TextBox>
                </td>
                <td class="style1">
                    พื้น</td>
                <td>
                    <asp:CheckBox ID="chkConcrete" runat="server" Text="คอนกรีต" />
                    <asp:CheckBox ID="chkGranite" runat="server" Text="หินแกรนิต" />
                    <asp:CheckBox ID="chkParquet" runat="server" Text="ลามิเนต/ปาร์เก้" />
                    <asp:CheckBox ID="chkCeramic" runat="server" Text="เซรามิค" />
                    <asp:CheckBox ID="chkWood" runat="server" Text="ไม้" />
                    <asp:CheckBox ID="ChkOther" runat="server" Text="อื่น ๆ" />
                    &nbsp;
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
                    &nbsp;รายละเอียดอื่นๆ <asp:TextBox ID="txtOtherFloor" runat="server"></asp:TextBox>
                </td>
            </tr>               
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td class="style1">
                    ผนัง</td>
                <td>
                    <asp:CheckBox ID="ChkBrickWall" runat="server" Text="ก่ออิฐฉาบปูน" />
                    <asp:CheckBox ID="CheckBlockbrickWall" runat="server" Text="ก่ออิฐบล็อค" />
                    <asp:CheckBox ID="ChkWoodWall" runat="server" Text="ไม้" />
                    <asp:CheckBox ID="ChkOtherWall" runat="server" Text="อื่น ๆ" />
                    &nbsp;</td>
            </tr> 
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    รายละเอียดอื่นๆ <asp:TextBox ID="txtOtherWall" runat="server"></asp:TextBox>
                </td>
            </tr>   
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td>                <table>
                    <tr>
                        <td>
                            <asp:ImageButton ID="ImageSave" runat="server" ImageUrl="~/Images/Save.jpg" 
                                Width="35px" Height="35px" onclientclick="return ShowMessage()"/>
                        </td>
                        <td>
                            <asp:Label ID="LblDescription" runat="server" Text="SAVE"></asp:Label>
                        </td>
                        <td>
                            <asp:ImageButton ID="ImgBack" runat="server" ImageUrl="~/Images/Button Previous.png" 
                                Width="35px" Height="35px" onclientclick="return ShowMessage()"/>
                        </td>
                        <td>BACK</td>
                    </tr>
               </table></td>
            </tr>           
        </table>
    </div>
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
            CellPadding="2" DataKeyNames="ID,Req_Id,Hub_Id,Temp_AID,Floors" 
            DataSourceID="DdsPrice3_70_Detail" ForeColor="Black" GridLines="None" 
            AllowPaging="True" PageSize="8">
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
                <asp:TemplateField HeaderText="Floors" SortExpression="Floors">
                    <EditItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("Floors") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblFloors" runat="server" Text='<%# Bind("Floors") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Main_Construction" 
                    SortExpression="Main_Construction">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" 
                            Text='<%# Bind("Main_Construction") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblMain_Construction" runat="server" Text='<%# Bind("Main_Construction") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Concrete" SortExpression="Concrete">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Concrete") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblConcrete" runat="server" Text='<%# Bind("Concrete") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Granite" SortExpression="Granite">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Granite") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblGranite" runat="server" Text='<%# Bind("Granite") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Parquet" SortExpression="Parquet">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Parquet") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblParquet" runat="server" Text='<%# Bind("Parquet") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ceramic" SortExpression="Ceramic">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Ceramic") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCeramic" runat="server" Text='<%# Bind("Ceramic") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Wood" SortExpression="Wood">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Wood") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblWood" runat="server" Text='<%# Bind("Wood") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Other" SortExpression="Other">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Other") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblOther" runat="server" Text='<%# Bind("Other") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Other_Detail" SortExpression="Other_Detail">
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
                        <asp:Label ID="lblBrickWall" runat="server" Text='<%# Bind("BrickWall") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BlockBrickWall" SortExpression="BlockBrickWall" 
                    Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("BlockBrickWall") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblBlockBrickWall" runat="server" Text='<%# Bind("BlockBrickWall") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="WoodWall" SortExpression="WoodWall" 
                    Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("WoodWall") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblWoodWall" runat="server" Text='<%# Bind("WoodWall") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="OtherWall" SortExpression="OtherWall" 
                    Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("OtherWall") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblOtherWall" runat="server" Text='<%# Bind("OtherWall") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="OtherWall_Detail" 
                    SortExpression="OtherWall_Detail" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox13" runat="server" 
                            Text='<%# Bind("OtherWall_Detail") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblOtherWall_Detail" runat="server" Text='<%# Bind("OtherWall_Detail") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
            </Columns>
            <FooterStyle BackColor="Tan" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
        </asp:GridView>

        <%--<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Add_Product.aspx">Add New</asp:HyperLink>--%>

        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="HiddenField2" runat="server" />
        <asp:HiddenField ID="HiddenField3" runat="server" />
        <asp:HiddenField ID="HiddenField4" runat="server" />
        <asp:HiddenField ID="HiddenField5" runat="server" />

        <br />

    </div>
    
    <asp:SqlDataSource ID="DdsPrice3_70_Detail" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="GET_PRICE3_70_DETAIL_REVIEW" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="HiddenField4" Name="ID" PropertyName="Value" 
                Type="Int32" />
            <asp:ControlParameter ControlID="HiddenField1" Name="Req_Id" 
                PropertyName="Value" Type="Int32" />
            <asp:ControlParameter ControlID="HiddenField2" Name="Hub_Id" 
                PropertyName="Value" Type="Int32" />
            <asp:ControlParameter ControlID="HiddenField3" Name="Temp_AID" 
                PropertyName="Value" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    
    </form>
</body>
</html>
