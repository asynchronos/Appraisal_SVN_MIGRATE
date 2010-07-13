<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Appraisal_Price2.aspx.vb" Inherits="Appraisal_Price2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Mytextbox" Namespace="Mytextbox" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .TableWidth
        {
            width: 100%;
        }
        .bgcolour
        {
            background-color: Gray;
        }
    </style>
    <asp:ScriptManager ID="asm" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hdfield_statusid" runat="server" Value="7" />
    <br />
    <div>
        <br />
        <%--        <cc1:CollapsiblePanelExtender ID="cpeMyPanelExtender" runat="server" TargetControlID="cntPanel" ExpandControlID="ttlPanel" CollapseControlID="ttlPanel" Collapsed="false" ImageControlID="imgTitlePanel" ExpandedImage="~/Images/minus.gif" CollapsedImage="~/Images/plus.gif" SuppressPostBack="true" ExpandDirection="Vertical">
        </cc1:CollapsiblePanelExtender>--%>
        <asp:Panel ID="ttlPanel" runat="server">
            <%--            <asp:Image ID="imgTitlePanel" runat="server" ImageAlign="Left" />--%>
        </asp:Panel>
    </div>
    <table width="100%">
        <tr class="bgcolour">
            <td>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label8" runat="server" Style="font-weight: 700; color: #0000FF" Text="รายชื่อลูกค้าที่อยู่ระหว่างการให้ราคาที่ 2"></asp:Label>
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
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
                    BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="Req_ID,Hub_ID"
                    DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display."
                    ForeColor="Black" GridLines="None" PageSize="15" Width="100%"
                    Style="font-size: small" AllowPaging="True">
                    <FooterStyle BackColor="Tan" />
                    <Columns>
                        <%--                <asp:TemplateField HeaderText="รายละเอียดการดำเนินการ">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlOperation" runat="server" OnPreRender="DDL_Load" ></asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Req_ID" SortExpression="Req_ID">
                            <EditItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Req_ID") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblReq_Id" runat="server" Text='<%# Bind("Req_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hub_ID" SortExpression="Hub_ID">
                            <EditItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Hub_ID") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblHub_ID" runat="server" Text='<%# Bind("Hub_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="HUB_NAME" SortExpression="HUB_NAME">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("HUB_NAME") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblHUB_NAME" runat="server" Text='<%# Bind("HUB_NAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="รหัสวิธี">
                            <ItemTemplate>
                                <asp:Label ID="lblReq_Type" runat="server" Text='<%# Bind("Req_Type") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="วิธีส่งประเมิน">
                            <ItemTemplate>
                                <asp:Label ID="lblAppraisal_Method_Name" runat="server" Text='<%# Bind("Method_Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cif" SortExpression="Cif">
                            <ItemTemplate>
                                <asp:Label ID="lblCif" runat="server" Text='<%# Bind("Cif") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cifname" SortExpression="Cifname">
                            <ItemTemplate>
                                <asp:Label ID="LabelCifName" runat="server" Text='<%# Bind("Cifname") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status_Name" SortExpression="Status_Name">
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("Status_Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="รหัสผู้ประเมิน" SortExpression="Appraisal_Id">
                            <ItemTemplate>
                                <asp:Label ID="LabelAppraisal_Id" runat="server" Text='<%# Bind("Appraisal_Id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ชื่อ - สกุลผู้ประเมิน" SortExpression="AppraisalName">
                            <ItemTemplate>
                                <asp:Label ID="LabelAppraisalName" runat="server" Text='<%# Bind("AppraisalName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="หลักประกัน">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlOperation" runat="server" OnPreRender="DDL_Load" OnTextChanged="DDL_Click">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:Button ID="btnOperation1" runat="server" Text="กำหนดราคาประเมินครั้งที่ 2" CommandName="Select" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="GET_REQUEST_APPRAISAL_LIST_BY_HUB" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="HUB_ID" SessionField="Hub_Id" Type="Int32" />
            <asp:ControlParameter ControlID="hdfield_statusid" Name="Status_Id" PropertyName="Value"
                Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsCollType" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT C.CollType_ID, C.CollType_Name FROM CollType C "></asp:SqlDataSource>
</asp:Content>
