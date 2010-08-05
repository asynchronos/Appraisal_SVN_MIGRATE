<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Appraisal_Building_Detail.aspx.vb"
    Inherits="Appraisal_Building_Detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="Js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="Js/common.js" type="text/javascript"></script>

    <script src="Js/jquery.js" type="text/javascript"></script>

    <style type="text/css">
        .style1
        {
            font-weight: bold;
        }
    </style>

    <script type="text/javascript">
        function onInit() {
            alert('Load');
            var buildingId = document.getElementById('<%=lblId.ClientID%>').innerHTML;
            if (buildingId = ' ') {
                var _PopupModal = getValueFromQueryString("PopupModal");
                window.parent.$find(_PopupModal).hide();
            }
        }

        function returnValue() {
            var _PopupModal = getValueFromQueryString("PopupModal");
            id = "IframeBuildingDetail";
            window.parent.$find(_PopupModal).hide();
            var iframe = window.parent.document.getElementById(_PopupModal);
            window.parent.location.replace(window.parent.location);
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p style="font-weight: 700; color: #3333CC">
            รายละเอียด พื้น ผนัง หลังคา สิ่งปลูกสร้าง</p>
        <div id="divConfMessage" runat="server" style="border-right: black thin solid; border-top: black thin solid;
            display: none; z-index: 200; border-left: black thin solid; border-bottom: black thin solid">
            <div style="background-color: #6699cc; text-align: center" id="confirmText">
            </div>
            <div style="z-index: 105; height: 2%; background-color: white; text-align: center">
            </div>
            <div style="z-index: 105; background-color: white; text-align: center">
                <asp:Button ID="btnConfOK" runat="server" Text="OK"></asp:Button>
                <asp:Button ID="btnConfCancel" runat="server" Text="Cancel"></asp:Button>
            </div>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        โครงสร้างหลักอาคารเป็น
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtBuilding_Struc" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        ชั้น
                    </td>
                    <td>
                        <asp:TextBox ID="txtBuildFloor" runat="server" Width="60px"></asp:TextBox>
                    </td>
                    <td class="style1">
                        พื้น
                    </td>
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
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblId" runat="server" Style="font-weight: 700; color: #FF0000;" 
                            myId="lblId" Visible="False"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;รายละเอียดอื่นๆ
                        <asp:TextBox ID="txtOtherFloor" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HiddenField ID="HiddenField2" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="style1">
                        ผนัง
                    </td>
                    <td>
                        <asp:CheckBox ID="ChkBrickWall" runat="server" Text="ก่ออิฐฉาบปูน" />
                        <asp:CheckBox ID="CheckBlockbrickWall" runat="server" Text="ก่ออิฐบล็อค" />
                        <asp:CheckBox ID="ChkWoodWall" runat="server" Text="ไม้" />
                        <asp:CheckBox ID="ChkOtherWall" runat="server" Text="อื่น ๆ" />
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HiddenField ID="HiddenField3" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        รายละเอียดอื่นๆ
                        <asp:TextBox ID="txtOtherWall" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HiddenField ID="HiddenField4" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="HiddenField5" runat="server" />
                    </td>
                    <td>
                    </td>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:ImageButton ID="ImageSave" runat="server" ImageUrl="~/Images/Save.jpg" Width="35px"
                                        Height="35px" />
                                </td>
                                <td>
                                    <asp:Label ID="LblDescription" runat="server" Text="SAVE" Style="font-weight: 700"></asp:Label>
                                </td>
                                <td>
                                    <asp:ImageButton ID="ImgBack" runat="server" ImageUrl="~/Images/Button Previous.png"
                                        Width="35px" Height="35px" OnClientClick="returnValue(); return false;" />
                                </td>
                                <td>
                                    <b>BACK หน้าสิ่งปลูกสร้าง</b>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
                BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="ID,Req_Id,Hub_Id,Temp_AID,Floors"
                DataSourceID="DdsPrice3_70_Detail" ForeColor="Black" GridLines="None" AllowPaging="True"
                PageSize="6" Style="font-size: small" Width="865px">
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
                    <asp:TemplateField HeaderText="Temp_AID" SortExpression="Temp_AID" Visible="False">
                        <EditItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("Temp_AID") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblTemp_AID" runat="server" Text='<%# Bind("Temp_AID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ชั้นที่" SortExpression="Floors">
                        <EditItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("Floors") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblFloors" runat="server" Text='<%# Bind("Floors") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="โครงสร้างหลัก" SortExpression="Main_Construction">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Main_Construction") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblMain_Construction" runat="server" Text='<%# Bind("Main_Construction") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="คอนกรีต" SortExpression="Concrete">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Concrete") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblConcrete" runat="server" Text='<%# Bind("Concrete") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="แกรนิต" SortExpression="Granite">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Granite") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblGranite" runat="server" Text='<%# Bind("Granite") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ปาร์เก้" SortExpression="Parquet">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Parquet") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblParquet" runat="server" Text='<%# Bind("Parquet") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="เซลามิค" SortExpression="Ceramic">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Ceramic") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblCeramic" runat="server" Text='<%# Bind("Ceramic") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ไม้" SortExpression="Wood">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Wood") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblWood" runat="server" Text='<%# Bind("Wood") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="อื่น ๆ" SortExpression="Other">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Other") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblOther" runat="server" Text='<%# Bind("Other") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="รายละเอียด อื่นๆ" SortExpression="Other_Detail">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Other_Detail") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblOther_Detail" runat="server" Text='<%# Bind("Other_Detail") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ผนังอิฐ" SortExpression="BrickWall">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("BrickWall") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblBrickWall" runat="server" Text='<%# Bind("BrickWall") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ผนังอิฐบล็อค" SortExpression="BlockBrickWall" Visible="False">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("BlockBrickWall") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblBlockBrickWall" runat="server" Text='<%# Bind("BlockBrickWall") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="WoodWall" SortExpression="WoodWall" Visible="False">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("WoodWall") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblWoodWall" runat="server" Text='<%# Bind("WoodWall") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="OtherWall" SortExpression="OtherWall" Visible="False">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("OtherWall") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblOtherWall" runat="server" Text='<%# Bind("OtherWall") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="OtherWall_Detail" SortExpression="OtherWall_Detail"
                        Visible="False">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("OtherWall_Detail") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblOtherWall_Detail" runat="server" Text='<%# Bind("OtherWall_Detail") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
                </Columns>
                <FooterStyle BackColor="Tan" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
            </asp:GridView>
            <asp:SqlDataSource ID="DdsPrice3_70_Detail" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
                SelectCommand="GET_PRICE3_70_DETAIL" SelectCommandType="StoredProcedure" 
                DeleteCommand="DELETE_PRICE2_PRICE3_70_DETAIL" 
                DeleteCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:ControlParameter ControlID="HiddenField4" Name="ID" PropertyName="Value" Type="Int32" />
                    <asp:ControlParameter ControlID="HiddenField1" Name="Req_Id" PropertyName="Value"
                        Type="Int32" />
                    <asp:ControlParameter ControlID="HiddenField2" Name="Hub_Id" PropertyName="Value"
                        Type="Int32" />
                    <asp:ControlParameter ControlID="HiddenField3" Name="Temp_AID" PropertyName="Value"
                        Type="Int32" />
                </SelectParameters>
                <DeleteParameters>
                    <asp:Parameter Name="ID" Type="Int32" />
                    <asp:Parameter Name="Req_Id" Type="Int32" />
                    <asp:Parameter Name="Hub_Id" Type="Int32" />
                    <asp:Parameter Name="Temp_AID" Type="Int32" />
                    <asp:Parameter Name="Floors" Type="String" />
                </DeleteParameters>
            </asp:SqlDataSource>
        </div>
    </div>
    </form>
</body>
</html>
