<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Appraisal_List_By_Hub.aspx.vb" Inherits="Appraisal_List_By_Hub" Culture="th-TH"
    UICulture="th-TH" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="Js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="Js/common.js" type="text/javascript"></script>

    <script src="Js/jquery.js" type="text/javascript"></script>

    <style type="text/css">
        .TableWidth
        {
            width: 100%;
        }
        .headDetail
        {
            font-weight: bold;
            color: Blue;
            background-color: Yellow;
        }
        .expleanColour
        {
            background-color: Silver;
            width: 300px;
        }
        .fColor
        {
            color: red;
        }
        .bgcolour
        {
            background-color: Gray;
        }
        .outerPopup
        {
            background-color: Gray;
            padding: 0px5px5px5px;
            border-style: solid;
            border-color: Yellow;
            border-width: 1px;
        }
        .innerPopup
        {
            background-color: #fff;
        }
        .modalBackground1
        {
            background-color: #000;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="HiddenField1" runat="server" Value="3" />
    <br />
    <br />
    <table class="TableWidth">
        <tr class="bgcolour">
            <td>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label8" runat="server" Style="font-weight: 700; color: #0000FF" Text="รายชื่อลูกค้าที่อยู่ระหว่างการให้ราคาที่ 1"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                                RepeatDirection="Horizontal" style="color: #0000FF; font-weight: 700">
                                <asp:ListItem Selected="True" Value="0">เฉพาะของผู้ประเมินที่ Login</asp:ListItem>
                                <asp:ListItem Value="1">ทั้งหมดที่อยู่ในศูนย์เดียวกัน</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Req_Id"
        DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display."
        Width='100%' BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px"
        CellPadding="2" ForeColor="Black" GridLines="None" PageSize="15"
        Style="font-size: small" AllowPaging="True">
        <FooterStyle BackColor="Tan" />
        <Columns>
            <%--                <asp:TemplateField>
                    <ItemTemplate>
                        <a href="javascript:expandcollapse('div<%# Eval("Req_Id") %>', 'one');">
                            <img id="imgdiv<%# Eval("Req_Id") %>" alt="Click to show/hide Queue for Appraisal <%# Eval("Req_Id") %>"
                                width="9px" src="Images/plus.gif" />
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>  --%>
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
            <asp:TemplateField HeaderText="ชื่อผู้ส่งประเมิน">
                <ItemTemplate>
                    <asp:Label ID="LabelEmp_Name" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="รหัสวิธีประเมิน">
                <ItemTemplate>
                    <asp:Label ID="lblReq_Type" runat="server" Text='<%# Bind("Req_Type") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="วิธีส่งประเมิน">
                <ItemTemplate>
                    <asp:Label ID="lblAppraisal_Method_Name" runat="server" Text='<%# Bind("Method_Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <%--                <asp:TemplateField HeaderText="สถานะการประเมิน">
                    <ItemTemplate>
                        <asp:Label ID="LabelStatus_Name" runat="server" Text='<%# Bind("Status_Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField> --%>
            <asp:TemplateField HeaderText="วันที่ส่งประเมิน">
                <ItemTemplate>
                    <asp:Label ID="LabelCreate_Date" runat="server" Text='<%# Bind("Create_Date", "{0:d}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:Label ID="lblAppraisalId" runat="server" Text='<%# Bind("Appraisal_Id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ผู้ประประเมิน">
                <ItemTemplate>
                    <asp:Label ID="lblAppraisalName" runat="server" Text='<%# Bind("AppraisalName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <%--                <asp:TemplateField HeaderText="รายละเอียดการดำเนินการ">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlOperation" runat="server" OnPreRender="DDL_Load" ></asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:Button ID="btnOperation1" runat="server" Text="กำหนดราคาประเมินครั้งที่ 1" CommandName="Select" />
                </ItemTemplate>
            </asp:TemplateField>
            <%--            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:ImageButton ID="imgSearch" runat="server" ImageUrl="~/Images/find1.jpg"
                        Height="22px" Width="22px" ToolTip="ค้นหา" CommandName="Select" OnClick="imgSearch_Click" />               
                </ItemTemplate>
            </asp:TemplateField>   --%>
        </Columns>
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
            </td>
        </tr>        
    </table>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="GET_REQUEST_APPRAISAL_LIST_BY_HUB" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="HUB_ID" SessionField="Hub_Id" Type="Int32" />
            <asp:ControlParameter ControlID="HiddenField1" Name="Status_Id" PropertyName="Value"
                Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
