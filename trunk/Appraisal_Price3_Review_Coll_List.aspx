<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_Price3_Review_Coll_List.aspx.vb" Inherits="Appraisal_Price3_Review_Coll_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            color: #6600FF;
            font-size: medium;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
    <h5 class="style1">รายการหลักประกันที่ทบทวนประเมิน</h5>
    <asp:HiddenField ID="hdfReq_Id" runat="server" />
    <asp:HiddenField ID="hdfHub_ID" runat="server" />
    <asp:HiddenField ID="hdfCollType" runat="server" />
    <asp:HiddenField ID="hdfAID" runat="server" />
    <asp:HiddenField ID="hdfAppraisal_Method" runat="server" />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Req_ID"
        DataSourceID="sdsPrice3List_Review" EmptyDataText="There are no data records to display."
        Width='100%' BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px"
        CellPadding="2" ForeColor="Black" GridLines="None" ShowFooter="True"
        Font-Size="Medium" AllowPaging="True">
        <FooterStyle BackColor="Tan" />
        <Columns>
            <asp:TemplateField HeaderText="ID.">
                <ItemTemplate>
                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
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
            <asp:TemplateField HeaderText="Temp_AID">
            <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:Label ID="lblTemp_AID" runat="server" Text='<%# Bind("Temp_AID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cif">
                <ItemTemplate>
                    <asp:Label ID="lblCif" runat="server" Text='<%# Bind("Cif") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cif Name">
                <ItemTemplate>
                    <asp:Label ID="lblCifName" runat="server" Text='<%# Bind("CifName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="รหัสหลักประกัน">
            <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:Label ID="lblCollType_Id" runat="server" Text='<%# Bind("COLLTYPE_ID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ชนิดหลักประกัน">
                <ItemTemplate>
                    <asp:Label ID="lblSubCollType" runat="server" Text='<%# Bind("SUBCOLLTYPE_NAME") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>                          
            <asp:TemplateField HeaderText="">
                <ItemStyle Width="25px" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgPrintPreview" runat="server" ImageUrl="~/Images/edit.gif"
                        Height="22px" Width="22px" ToolTip="แก้ไขข้อมล" CommandName="Select"/>
                </ItemTemplate>
            </asp:TemplateField>
<%--            <asp:TemplateField HeaderText="">
                <ItemStyle Width="25px" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgaddplus" runat="server" ImageUrl="~/Images/add_plus2.jpg"
                        Height="22px" Width="22px" ToolTip="เพิ่มหลักประกัน"/>
                </ItemTemplate>
            </asp:TemplateField>--%>
        </Columns>
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
    <asp:SqlDataSource ID="sdsPrice3List_Review" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="GET_PRICE3_COLL_LIST" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="hdfHub_ID" Name="HUB_ID" PropertyName="Value" Type="Int32" />
            <asp:ControlParameter ControlID="hdfReq_Id" Name="Req_Id" PropertyName="Value" 
                Type="Int32" />
            <asp:ControlParameter ControlID="hdfCollType" Name="CollType" PropertyName="Value" 
                Type="Int32" />                
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

