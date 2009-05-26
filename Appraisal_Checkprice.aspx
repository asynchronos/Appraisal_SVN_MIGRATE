<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_Checkprice.aspx.vb" Inherits="Appraisal_Checkprice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
<br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="Req_Id,Hub_Id" DataSourceID="sdsCheckprice" 
            EmptyDataText="There are no data records to display." Width='100%' 
            BackColor="LightGoldenrodYellow" 
            BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" 
            GridLines="None" ShowFooter="True" PageSize="15" Font-Size="Small">
        <FooterStyle BackColor="Tan" />
        <Columns>
            <%--                <asp:TemplateField>
                    <ItemTemplate>
                        <a href="javascript:expandcollapse('div<%# Eval("Req_Id") %>', 'one');">
                            <img id="imgdiv<%# Eval("Req_Id") %>" alt="Click to show/hide Queue for Appraisal <%# Eval("Req_Id") %>"
                                width="9px" src="Images/plus.gif" />
                        </a>
                    </ItemTemplate>
                </asp:TemplateField> --%>
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
            <asp:TemplateField HeaderText="Price1">
            <ItemStyle  HorizontalAlign="Right"/>
                <ItemTemplate>
                    <asp:Label ID="LabelPrice1" runat="server" 
                            Text='<%# Bind("Price1", "{0:N}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>  
            <asp:TemplateField HeaderText="Price2">
            <ItemStyle  HorizontalAlign="Right"/>
                <ItemTemplate>
                    <asp:Label ID="LabelPrice2" runat="server" 
                            Text='<%# Bind("Price2", "{0:N}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>  
            <asp:TemplateField HeaderText="Price3">
            <ItemStyle  HorizontalAlign="Right"/>
                <ItemTemplate>
                    <asp:Label ID="LabelPrice3" runat="server" 
                            Text='<%# Bind("Price3", "{0:N}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>                                    
            <asp:TemplateField HeaderText="ชื่อผู้ส่งประเมิน">
                <ItemTemplate>
                    <asp:Label ID="LabelEmp_Name" runat="server" Text='<%# Bind("Sender_Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="สถานะการประเมิน">
                <ItemTemplate>
                    <asp:Label ID="LabelStatus_Name" runat="server" 
                            Text='<%# Bind("Status_Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="">
                <ItemStyle Width="25px" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgEditPosition" runat="server" 
                        ImageUrl="~/Images/houses.png" Height="22px" Width="22px" 
                        ToolTip="ดูแผนที่" CommandName="Select" OnClick="imgEditPosition_Click" />
                </ItemTemplate>                              
            </asp:TemplateField>              
            <%--                <asp:HyperLinkField DataNavigateUrlFields="Req_Id,Hub_Id" 
                    DataNavigateUrlFormatString="Appraisal_Assign_Update_Job.aspx?Req_Id={0}&amp;Hub_Id={1}" 
                    HeaderText="Edit" Text="Edit" />--%>
            <%--                <asp:TemplateField HeaderText="EDIT">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                            CommandName="Select" Text="Select"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>--%>
        </Columns>
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
    <asp:SqlDataSource ID="sdsCheckprice" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="GET_PRICE_ALL" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="hdfEmp_Id" Name="Emp_Id" PropertyName="Value" 
                Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:HiddenField ID="hdfEmp_Id" runat="server" />
</asp:Content>

