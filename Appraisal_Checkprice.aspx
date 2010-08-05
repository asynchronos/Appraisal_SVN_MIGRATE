<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Appraisal_Checkprice.aspx.vb" Inherits="Appraisal_Checkprice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        function makeNewOpenWindow(redid, hubid, appraisalId, tempAID, cif, reqType) {
            var windowFeatures;
            var newWindow;

            var approveId = document.getElementById('<%=hdfEmp_Id.ClientID%>').value;
            if (reqType == 1) {
                windowFeatures = "top=0,left=0,resizable=yes,scrollbars=yes,width=" + (screen.width) + ",height=" + (screen.height);
                newWindow = window.open("Appraisal_Report_FullForm4Other.aspx?Req_Id=" + redid + "&Hub_Id=" + hubid + "&ApproveId=" + approveId, "openWindow", windowFeatures);
            }
            else {
                windowFeatures = "top=0,left=0,resizable=yes,scrollbars=yes,width=" + (screen.width) + ",height=" + (screen.height);
                newWindow = window.open("PrintPreviewPrice3Review.aspx?Req_Id=" + redid + "&Hub_Id=" + hubid + "&ApproveId=" + approveId + "&Appraisal_Id=" + appraisalId + "&Temp_AID=" + tempAID + "&Cif=" + cif, "openWindow", windowFeatures);
            }
            newWindow.focus();
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <table width="100%">
        <tr style="background-color: Gray;">
            <td>
                <table>
                    <tr>
                        <td>
                            ค้นหาตาม :
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListOption" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSearch" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="ButtonSearch" runat="server" Text="ค้นหา" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="sdsCheckprice"
                    EmptyDataText="There are no data records to display." Width='100%' BackColor="LightGoldenrodYellow"
                    BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" 
                    GridLines="None" PageSize="15" Font-Size="Small" AllowPaging="True">
                    <FooterStyle BackColor="Tan" />
                    <Columns>
                        <asp:BoundField DataField="Req_ID" HeaderText="Req_ID" SortExpression="Req_ID" />
                        <asp:BoundField DataField="Hub_ID" HeaderText="Hub_ID" SortExpression="Hub_ID" />
                        <asp:BoundField DataField="Hub_Name" HeaderText="Hub_Name" SortExpression="Hub_Name" />
                        <asp:BoundField DataField="Cif" HeaderText="Cif" SortExpression="Cif" />
                        <asp:BoundField DataField="CustomerName" HeaderText="CustomerName" ReadOnly="True"
                            SortExpression="CustomerName" />
                        <asp:BoundField DataField="Temp_AID" HeaderText="Temp_AID" ReadOnly="True" SortExpression="Temp_AID" />
                        <asp:TemplateField HeaderText="Price1" SortExpression="Price1">
                        <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Price1", "{0:N}") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Price1", "{0:N}") %>'></asp:Label>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Price2" SortExpression="Price2">
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Price2", "{0:N}") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Price2", "{0:N}") %>'></asp:Label>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Appraisal_Id" HeaderText="Appraisal_Id" SortExpression="Appraisal_Id" />
                        <asp:BoundField DataField="AppraisalName" HeaderText="AppraisalName" ReadOnly="True"
                            SortExpression="AppraisalName" />
                        <asp:BoundField DataField="Status_ID" HeaderText="Status_ID" SortExpression="Status_ID" />
                        <asp:BoundField DataField="Status_Name" HeaderText="Status_Name" SortExpression="Status_Name" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="imgConfirm" runat="server" Height="22px" ImageUrl="~/Images/dollar.jpg"
                                    ToolTip="รายละเอียดการกำหนดราคา" Width="22px" OnClientClick='<%# "makeNewOpenWindow("+Eval("Req_Id").toString()+","+EVAL("Hub_Id").toString()+","+EVAL("Appraisal_Id").toString()+","+EVAL("Temp_AID").toString()+","+EVAL("Cif").toString()+","+EVAL("Req_Type").toString()+"); return false;" %>' />
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
    <asp:SqlDataSource ID="sdsCheckprice" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="GET_USER_CHECK_PRICE" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:HiddenField ID="hdfEmp_Id" runat="server" />
</asp:Content>
