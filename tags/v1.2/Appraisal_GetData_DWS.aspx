<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_GetData_DWS.aspx.vb" Inherits="Appraisal_GetData_DWS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .style1
        {
            width: 100%;
        }
        .tb_backgrund 
        {
           background-color: #C0C0C0;
           color: #0000FF;
           font-weight: bold;
        }
        .style2
        {
            background-color: #C0C0C0;
            color: #0000FF;
            font-weight: bold;
            width: 184px;
        }
        .style3
        {
            width: 187px;
        }
        .style4
        {
            width: 187px;
            background-color: #C0C0C0;
            color: #0000FF;
            font-weight: bold;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
<br />
    
        <table border="0" class="style1">
            <tr>
                <td class="style2">
                    Req ID :</td>
                <td>
                    <asp:Label ID="lblReq_Id" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Hub ID :</td>
                <td>
                    <asp:Label ID="lblHub_Id" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Cif :</td>
                <td>
                    <asp:Label ID="lblCif" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    AID :</td>
                <td>
                    <asp:Label ID="lblAID" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="tb_backgrund">
                    <asp:Button ID="btnOk" runat="server" Text="เพิ่มหลักประกัน" />
                </td>
            </tr>
        </table>
    
        <asp:GridView ID="GridView_CID_DETAIL" runat="server" 
        BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
        CellPadding="2" ForeColor="Black" GridLines="None" 
        AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox runat="server" ID="cb1" AutoPostBack="true" 
                            OnCheckedChanged="cb1_Checked"/> 
                    </HeaderTemplate>
                   <ItemTemplate>
                     <asp:CheckBox runat="server" ID="cb2"/>  
                   </ItemTemplate> 
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
             </asp:TemplateField> 
                <asp:TemplateField HeaderText="CIF_NO">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CIF") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblcif" runat="server" Text='<%# Bind("CIF") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="APPRAISAL_ID">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("APPRAISAL_ID") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblAppraisal_Id" runat="server" Text='<%# Bind("APPRAISAL_ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="COLLATERAL_ID">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("COLLATERAL_ID") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCollateral_Id" runat="server" Text='<%# Bind("COLLATERAL_ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="COLLATERAL_KEY">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("COLLATERAL_KEY") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCollateral_Key" runat="server" Text='<%# Bind("COLLATERAL_KEY") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="APPRAISAL_DATE">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("APPRAISAL_DATE") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblAppraisal_Date" runat="server" Text='<%# Bind("APPRAISAL_DATE") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>                                                               
                <asp:CommandField ButtonType="Button" ShowSelectButton="True" 
                    SelectText="รายละเอียด" />
            </Columns>
            <FooterStyle BackColor="Tan" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
        </asp:GridView>

        <table class="style1" border="1">
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3" style="background-color: #C0C0C0;">
                    <asp:Button ID="btnOk0" runat="server" Text="เพิ่มหลักประกัน" />
                </td>
                <td class="style4">
                    &nbsp;</td>
                <td style="background-color: #C0C0C0;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    CID</td>
                <td class="style3">
                    <asp:Label ID="lblCID" runat="server"></asp:Label>
                </td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    เลขประเภทหลักประกัน</td>
                <td class="style3">
                    <asp:Label ID="lblSubCollTypeNo" runat="server"></asp:Label>
                </td>
                <td class="style4">
                    ประเภทหลักประกัน</td>
                <td>
                    <asp:Label ID="lblSubCollType" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    เลขโฉนด</td>
                <td class="style3">
                    <asp:Label ID="lblChanode" runat="server"></asp:Label>
                </td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    ถนน</td>
                <td class="style3">
                    <asp:Label ID="lblRoad" runat="server"></asp:Label>
                </td>
                <td class="style4">
                    ตำบล</td>
                <td>
                    <asp:Label ID="lblDistrict" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    อำเภอ</td>
                <td class="style3">
                    <asp:Label ID="lblAmphur" runat="server"></asp:Label>
                </td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    รหัสจังหวัด</td>
                <td class="style3">
                    <asp:Label ID="lblProvince_Code" runat="server"></asp:Label>
                </td>
                <td class="style4">
                    จังหวัด</td>
                <td>
                    <asp:Label ID="lblProvince" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    จำนวนไร่</td>
                <td class="style3">
                    <asp:Label ID="lblRai" runat="server"></asp:Label>
                </td>
                <td class="style4">
                    จำนวนงาน</td>
                <td>
                    <asp:Label ID="lblNgan" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    จำนวนวา</td>
                <td class="style3">
                    <asp:Label ID="lblWah" runat="server"></asp:Label>
                </td>
                <td class="style4">
                    เนื่อที่</td>
                <td>
                    <asp:Label ID="lblArea" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        
</asp:Content>

