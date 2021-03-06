<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_Review_List.aspx.vb" Inherits="Appraisal_Review_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:HiddenField ID="HiddenField1" runat="server" Value="4" />
    <br />
    <br />
        <table>
            <tr>
                <td>
                    CIF</td>
                <td>
                    <asp:TextBox ID="txtCif" runat="server" Width="102px"></asp:TextBox>
                &nbsp;<asp:Button ID="btnSeachCif" runat="server" Text="Search" />
                    <asp:RangeValidator ID="RangeValidator1" runat="server" 
                        ControlToValidate="txtCif" ErrorMessage="ใส่ฉพาะตัวเลขเท่านั้น" 
                        MaximumValue="999999999" MinimumValue="0"></asp:RangeValidator>
                </td>
                <td>
                    ชื่อสกุล</td>
                <td>
                    <asp:Label ID="lblCifName" runat="server" Width="250px"></asp:Label>
                </td>
                <td>
                    สาขา/ฝ่ายงาน</td>
                <td>
                    <asp:Label ID="lblDepartName" runat="server"></asp:Label>
                </td>
            </tr>    
            <tr>
                <td>&nbsp;</td>
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
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="Req_Id" DataSourceID="SqlDataSource1" 
            EmptyDataText="There are no data records to display." Width='100%' 
            BackColor="LightGoldenrodYellow" 
            BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" 
            GridLines="None" ShowFooter="True" PageSize="15">
            <FooterStyle BackColor="Tan" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href="javascript:expandcollapse('div<%# Eval("Req_Id") %>', 'one');">
                            <img id="imgdiv<%# Eval("Req_Id") %>" alt="Click to show/hide Queue for Appraisal <%# Eval("Req_Id") %>"
                                width="9px" src="Images/plus.gif" />
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Req No.">
                    <ItemTemplate>
                        <asp:Label ID="lblReq_id" runat="server" Text='<%# Bind("Req_Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>                          
                <asp:TemplateField HeaderText="Hub ID">
                    <ItemTemplate>
                        <asp:Label ID="lblHub_Id" runat="server" Text='<%# Bind("Hub_Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Hub Name">
                    <ItemTemplate>
                        <asp:Label ID="lblHub_Name" runat="server" Text='<%# Bind("Hub_Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AID">
                    <ItemTemplate>
                        <asp:Label ID="lblAID" runat="server" Text='<%# Bind("AID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>                
                <asp:TemplateField HeaderText="Cif">
                    <ItemTemplate>
                        <asp:Label ID="lblCif" runat="server" Text='<%# Bind("Cif") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>                                
                <asp:TemplateField HeaderText="Cif Name">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("CifName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="ชื่อผู้ส่งประเมิน">
                    <ItemTemplate>
                        <asp:Label ID="LabelEmp_Name" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="สถานะการประเมิน">
                    <ItemTemplate>
                        <asp:Label ID="LabelStatus_Name" runat="server" Text='<%# Bind("Status_Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="วันที่ส่งประเมิน">
                    <ItemTemplate>
                        <asp:Label ID="LabelCreate_Date" runat="server" Text='<%# Bind("Create_Date") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
<%--                <asp:TemplateField HeaderText="รายละเอียดการดำเนินการ">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlOperation" runat="server" OnPreRender="DDL_Load" ></asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:Button ID="btnOperation1" runat="server" Text="กำหนดราคาประเมินครั้งที่ 3" CommandName="Select"/>
                    </ItemTemplate>
                </asp:TemplateField>                                                                                   
            </Columns>
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
        </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        
        
        SelectCommand="GET_REQUEST_APPRAISAL_LIST_BY_HUB" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="HUB_ID" SessionField="Hub_Id" Type="Int32" />
            <asp:ControlParameter ControlID="HiddenField1" Name="Status_Id" 
                PropertyName="Value" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

