<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_Wait_For_Approve.aspx.vb" Inherits="Appraisal_Wait_For_Approve" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
<br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" 
        BorderWidth="1px" CellPadding="2" 
        DataKeyNames="Req_Id,AID,Temp_AID,Hub_Id,Approve_Id" 
        DataSourceID="sdsWaitForApprove" ForeColor="Black" GridLines="None" 
        style="font-size: small" Width="100%">
        <Columns>
            <asp:TemplateField HeaderText="Req_Id" SortExpression="Req_Id">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Req_Id") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblReq_Id" runat="server" Text='<%# Bind("Req_Id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="AID" SortExpression="AID">
                <EditItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("AID") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblAID" runat="server" Text='<%# Bind("AID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Temp_AID" SortExpression="Temp_AID">
                <EditItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Temp_AID") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblTemp_AID" runat="server" Text='<%# Bind("Temp_AID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Hub_Id" SortExpression="Hub_Id">
                <EditItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("Hub_Id") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblHub_Id" runat="server" Text='<%# Bind("Hub_Id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="HUB_NAME" SortExpression="HUB_NAME">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("HUB_NAME") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblHub_Name" runat="server" Text='<%# Bind("HUB_NAME") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Approve_Id" SortExpression="Approve_Id">
                <EditItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("Approve_Id") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblApprove_Id" runat="server" Text='<%# Bind("Approve_Id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="SubCommittee_Name" 
                SortExpression="SubCommittee_Name">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" 
                        Text='<%# Bind("SubCommittee_Name") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("SubCommittee_Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cif" SortExpression="Cif">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Cif") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblCif" runat="server" Text='<%# Bind("Cif") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cifname" SortExpression="Cifname">
                <EditItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("Cifname") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblCifname" runat="server" Text='<%# Bind("Cifname") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="รหัสวิธี" SortExpression="Cif">
                <ItemTemplate>
                    <asp:Label ID="lblMethodNo" runat="server" Text='<%# Bind("Req_Type") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="วิธีส่งประเมิน">
                <ItemTemplate>
                    <asp:Label ID="lblMethod_Name" runat="server" Text='<%# Bind("Method_Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>            
            <asp:TemplateField HeaderText="Appraisal_Id" SortExpression="Appraisal_Id">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Appraisal_Id") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblAppraisal_Id" runat="server" Text='<%# Bind("Appraisal_Id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ชื่อ-สกุลผู้ประเมิน">
                <EditItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("Emp_Name") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label11" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="วันที่ส่งให้อนุมัติ" SortExpression="Save_Date">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Save_Date") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label12" runat="server" Text='<%# Bind("Save_Date", "{0:d}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="">
                <ItemStyle Width="25px" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgPrintPreview" runat="server" 
                        ImageUrl="~/Images/find1.jpg" Height="22px" Width="22px" 
                        ToolTip="ดูรายละเอียด" CommandName="Select" 
                        onclick="imgPrintPreview_Click" />
                </ItemTemplate>
            </asp:TemplateField>            
<%--            <asp:TemplateField HeaderText="">
            <ItemStyle HorizontalAlign="Center" Width="25px" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgConfirm" runat="server" ImageUrl="~/Images/confirm_approve.png"
                        Height="22px" Width="22px" ToolTip="อนุมัติ" onclick="imgConfirm_Click" />               
                </ItemTemplate>
            </asp:TemplateField>  --%>           
        </Columns>
        <FooterStyle BackColor="Tan" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
            HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
    <asp:SqlDataSource ID="sdsWaitForApprove" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="GET_WAIT_FOR_APPROVE" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="HdfApprove_Id" Name="Approve_Id" 
                PropertyName="Value" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:HiddenField ID="HdfApprove_Id" runat="server" />
</asp:Content>

