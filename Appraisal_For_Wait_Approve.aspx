<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_For_Wait_Approve.aspx.vb" Inherits="Appraisal_For_Wait_Approve" Culture="th-TH" uiCulture="th-TH" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="Mytextbox" namespace="Mytextbox" tagprefix="cc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 196px;
            font-weight: bold;
            color: #3333CC;
        }
        .style3
        {
            width: 131px;
        }
        .style4
        {
            width: 74px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
<br />
<br />
    <asp:HiddenField ID="hdfApproved" runat="server" Value="0" />
    <table class="style1">
        <tr>
            <td class="style2">
                รหัสคำขอปะเมิน เลขที่</td>
            <td class="style3">
                <cc2:mytext ID="txtReq_Id" runat="server" AllowUserKey="int_Integer"></cc2:mytext>
            </td>
            <td class="style4">
                <asp:Button ID="bntSearch" runat="server" Text="ค้นหา" />
            </td>
            <td>
            
                &nbsp;<asp:Label ID="lblMessage" runat="server" 
                    style="color: #3333CC; font-weight: 700"></asp:Label>
            </td>
        </tr>
    </table>
<br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
        CellPadding="2" DataKeyNames="Req_Id,AID,Temp_AID" DataSourceID="sdsForApprove" 
        ForeColor="Black" GridLines="None" style="font-size: small" 
        AllowPaging="True">
        <Columns>
            <asp:TemplateField HeaderText="เลขคำขอ" SortExpression="Req_Id">
                <EditItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Req_Id") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblReq_Id" runat="server" Text='<%# Bind("Req_Id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="AID" SortExpression="AID">
                <EditItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("AID") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblAID" runat="server" Text='<%# Bind("AID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Temp AID" SortExpression="Temp_AID">
                <EditItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("Temp_AID") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblTemp_AID" runat="server" Text='<%# Bind("Temp_AID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Hub ID" SortExpression="Hub_Id">
                <EditItemTemplate>
                    <asp:Label ID="lblHubID" runat="server" Text='<%# Eval("Hub_Id") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblHub_Id" runat="server" Text='<%# Bind("Hub_Id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>            
            <asp:TemplateField HeaderText="เรียน" SortExpression="Inform_To">
                <ItemStyle Width="150px"/>
                <EditItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("Inform_To") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("Inform_To") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cif" SortExpression="Cif">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Cif") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblCif" runat="server" Text='<%# Bind("Cif") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Lat" SortExpression="Lat">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Lat") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblLat" runat="server" Text='<%# Bind("Lat") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Lng" SortExpression="Lng">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Lng") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblLng" runat="server" Text='<%# Bind("Lng") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="วันประเมิน" SortExpression="Appraisal_Date">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# string.Format( "{0:dd/MM/yyyy}", Eval("Appraisal_Date")) %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" 
                        Text='<%# Bind("Appraisal_Date", "{0:d}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="รหัสวิธีการขอ" SortExpression="Req_Type" Visible= "false">
                <EditItemTemplate>
                    <asp:TextBox ID="txtReq_Type" runat="server" Text='<%# Bind("Req_Type") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblReq_Type" runat="server" Text='<%# Bind("Req_Type") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>          
            <asp:TemplateField HeaderText="ชื่อวิธีการขอ">
                <ItemTemplate>
                    <asp:Label ID="lblMethod_Name" runat="server" Text='<%# Bind("Method_Name") %>'></asp:Label>
                </ItemTemplate>              
            </asp:TemplateField>
            <asp:TemplateField HeaderText="อนุกรรมการที่1" SortExpression="Approved1">
                <ItemStyle Width="150px" />
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Approve_Name1") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:HiddenField ID="hdfApproved1" runat="server" Value ='<%# Bind("Approved1") %>' />
                    <asp:Label ID="lblApproved1" runat="server" Text='<%# Bind("Approve_Name1") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="อนุกรรมการที่2" SortExpression="Approved2">
            <ItemStyle Width="150px" />
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Approve_Name2") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:HiddenField ID="hdfApproved2" runat="server" Value ='<%# Bind("Approved2") %>' />
                    <asp:Label ID="lblApproved2" runat="server" Text='<%# Bind("Approve_Name2") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="อนุกรรมการที่3" SortExpression="Approved3">
            <ItemStyle Width="150px" />
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Approve_Name3") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:HiddenField ID="hdfApproved3" runat="server" Value ='<%# Bind("Approved3") %>' />
                    <asp:Label ID="lblApproved3" runat="server" Text='<%# Bind("Approve_Name3") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="อนุมัติ" SortExpression="Approved">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Approved") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblApproved" runat="server" Text='<%# Bind("Approved") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ฝ่ายที่ขอประเมิน" SortExpression="Req_Dept">
                <EditItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("Req_Dept") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label14" runat="server" Text='<%# Bind("Req_Dept") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ผู้ประเมิน" SortExpression="Appraisal_Id">
                <EditItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("Appraisal_Id") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblAppraisal_Id" runat="server" Text='<%# Bind("Appraisal_Id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="">
                <ItemStyle Width="25px" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgAttach" runat="server" 
                        ImageUrl="~/Images/ico_attachments.gif" Height="22px" Width="22px" 
                        ToolTip="แนบไฟล์เอกสาร" CommandName="Select" OnClick="imgAttach_Click" />
                </ItemTemplate>                              
            </asp:TemplateField>
            <asp:TemplateField HeaderText="">
                <ItemStyle Width="25px" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgEditData" runat="server" 
                        ImageUrl="~/Images/pencil.png" Height="22px" Width="22px" 
                        ToolTip="แก้ไขข้อมูล" CommandName="Select" OnClick="imgEditData_Click" />
                </ItemTemplate>                              
            </asp:TemplateField>               
            <asp:TemplateField HeaderText="">
                <ItemStyle Width="25px" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgEditPosition" runat="server" 
                        ImageUrl="~/Images/houses.png" Height="22px" Width="22px" 
                        ToolTip="แก้ไขพิกัด" CommandName="Select" OnClick="imgEditPosition_Click" />
                </ItemTemplate>                              
            </asp:TemplateField>               
            <asp:TemplateField HeaderText="">
                <ItemStyle Width="25px" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgApprove" runat="server" 
                        ImageUrl="~/Images/book_blue_preferences.png" Height="22px" Width="22px" 
                        ToolTip="อนุมัติ" CommandName="Select" OnClick="imgApprove_Click" />
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
    <asp:SqlDataSource ID="sdsForApprove" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="GET_PRICE3_MASTER_FOR_APPROVE" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="hdfApproved" Name="Approved" 
                PropertyName="Value" Type="Int32" DefaultValue="" />
            <asp:ControlParameter ControlID="txtReq_Id" DefaultValue=" " Name="Req_Id" 
                PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>

