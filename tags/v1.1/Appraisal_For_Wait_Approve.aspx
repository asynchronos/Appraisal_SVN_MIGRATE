<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_For_Wait_Approve.aspx.vb" Inherits="Appraisal_For_Wait_Approve" Culture="th-TH" uiCulture="th-TH" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
<br />

    <asp:HiddenField ID="hdfApproved" runat="server" Value="0" />
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
                <ItemStyle Width="200px"/>
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
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Approved1") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblApproved1" runat="server" Text='<%# Bind("Approved1") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="อนุกรรมการที่2" SortExpression="Approved2">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Approved2") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblApproved2" runat="server" Text='<%# Bind("Approved2") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="อนุกรรมการที่3" SortExpression="Approved3">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Approved3") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblApproved3" runat="server" Text='<%# Bind("Approved3") %>'></asp:Label>
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
                    <asp:Label ID="Label15" runat="server" Text='<%# Bind("Appraisal_Id") %>'></asp:Label>
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
                PropertyName="Value" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>

