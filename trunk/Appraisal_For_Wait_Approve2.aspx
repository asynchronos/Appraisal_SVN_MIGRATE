<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Appraisal_For_Wait_Approve2.aspx.vb" Inherits="Appraisal_For_Wait_Approve2" UICulture="th-TH" Culture="th-TH" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .tableWidthAndBg
        {
            width: 100%;
            background-color: Gray;
        }
        .tableWidth
        {
            width: 100%;
        }
        .style7
        {
            color: #996600;
            font-weight: bold;
        }
        .style8
        {
            color: #0000FF;
            font-weight: bold;
        }
        .style9
        {
            text-decoration: underline;
        }
    </style>
<script type="text/javascript">
    function makeNewOpenWindow(redid, hubid,appraisalId,tempAID,cif,reqType) {
        var windowFeatures;
        var newWindow;
        //alert(reqType);
        var approveId = document.getElementById('<%=HiddenFieldUserLogin.ClientID%>').value;
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
    <table class="tableWidthAndBg">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="เงื่อนไขการค้นหา" class="style8"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownListOptionSearch" runat="server">
                </asp:DropDownList>
                <asp:TextBox ID="TextBoxOptionSearch" runat="server" Width="200px"></asp:TextBox>
                <asp:Button ID="ButtonSearch" runat="server" Text="ค้นหา" />
            </td>
            <td>
                <span class="style8"><span class="style9">หมายเหตุ</span> สี</span><span class="style7">&nbsp;
                </span>
                <asp:TextBox ID="TextBox9" runat="server" BackColor="Yellow" BorderStyle="None"
                    CssClass="style7" Height="19px" Width="38px"></asp:TextBox>
                <span class="style7">&nbsp; </span><span class="style8">อนุกรรมการยังเซ็นต์ไม่ครบ</span>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
                    BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="Req_Id,AID,Temp_AID"
                    ForeColor="Black" GridLines="None" Style="font-size: small"
                    AllowPaging="True" PageSize="30" OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="เลขคำขอ" SortExpression="Req_Id">
                            <ItemTemplate>
                                <asp:Label ID="lblReq_Id" runat="server" Text='<%# Bind("Req_Id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="AID" SortExpression="AID">
                            <ItemTemplate>
                                <asp:Label ID="lblAID" runat="server" Text='<%# Bind("AID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Temp AID" SortExpression="Temp_AID">
                            <ItemTemplate>
                                <asp:Label ID="lblTemp_AID" runat="server" Text='<%# Bind("Temp_AID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hub ID" SortExpression="Hub_Id">
                            <ItemTemplate>
                                <asp:Label ID="lblHub_Id" runat="server" Text='<%# Bind("Hub_Id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="เรียน" SortExpression="Inform_To">
                            <ItemStyle Width="150px" />
                            <ItemTemplate>
                                <asp:Label ID="Label15" runat="server" Text='<%# Bind("Inform_To") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cif" SortExpression="Cif">
                            <ItemTemplate>
                                <asp:Label ID="lblCif" runat="server" Text='<%# Bind("Cif") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="วันประเมิน" SortExpression="Appraisal_Date">
                            <EditItemTemplate>
                                <asp:Label ID="Label17" runat="server" Text='<%# string.Format( "{0:dd/MM/yyyy}", Eval("Appraisal_Date")) %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label16" runat="server" Text='<%# Bind("Appraisal_Date", "{0:d}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ชื่อวิธีการขอ">
                            <ItemTemplate>
                                <asp:HiddenField ID="HiddenFieldReq_Type" runat="server" Value ='<%# Bind("Req_Type") %>'></asp:HiddenField>
                                <asp:Label ID="lblMethod_Name" runat="server" Text='<%# Bind("Method_Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="อนุกรรมการที่1" SortExpression="Approved1">
                            <ItemStyle Width="150px" />
                            <ItemTemplate>
                                <asp:HiddenField ID="hdfApproved1" runat="server" Value='<%# Bind("Approved1") %>' />
                                <asp:Label ID="lblApproved1" runat="server" Text='<%# Bind("Approve_Name1") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="อนุกรรมการที่2" SortExpression="Approved2">
                            <ItemStyle Width="150px" />
                            <ItemTemplate>
                                <asp:HiddenField ID="hdfApproved2" runat="server" Value='<%# Bind("Approved2") %>' />
                                <asp:Label ID="lblApproved2" runat="server" Text='<%# Bind("Approve_Name2") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="อนุกรรมการที่3" SortExpression="Approved3">
                            <ItemStyle Width="150px" />
                            <ItemTemplate>
                                <asp:HiddenField ID="hdfApproved3" runat="server" Value='<%# Bind("Approved3") %>' />
                                <asp:Label ID="lblApproved3" runat="server" Text='<%# Bind("Approve_Name3") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="อนุมัติ" SortExpression="Approved">
                            <ItemTemplate>
                                <asp:Label ID="lblApproved" runat="server" Text='<%# Bind("Approved") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ฝ่ายที่ขอประเมิน" SortExpression="Req_Dept">
                            <ItemTemplate>
                                <asp:Label ID="Label14" runat="server" Text='<%# Bind("Req_Dept") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ผู้ประเมิน" SortExpression="Appraisal_Id">
                            <ItemTemplate>
                                <asp:Label ID="lblAppraisal_Id" runat="server" Text='<%# Bind("Appraisal_Id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="จำนวนผู้อนุมัติ" SortExpression="Cnt_Item">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblCnt_Item" runat="server" Text='<%# Bind("Cnt_Item") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemStyle Width="25px" />
                            <ItemTemplate>
                                <asp:ImageButton ID="imgEditData" runat="server" ImageUrl="~/Images/full_form.ico" Height="22px"
                                    Width="22px" ToolTip="รายงานการประเมิน" OnClientClick='<%# "makeNewOpenWindow("+Eval("Req_Id").toString()+","+EVAL("Hub_Id").toString()+","+EVAL("Appraisal_Id").toString()+","+EVAL("Temp_AID").toString()+","+EVAL("Cif").toString()+","+EVAL("Req_Type").toString()+"); return false;" %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemStyle Width="25px" />
                            <ItemTemplate>
                                <asp:ImageButton ID="imgApprove" runat="server" ImageUrl="~/Images/book_blue_preferences.png"
                                    Height="22px" Width="22px" ToolTip="อนุมัติ" OnClick="imgApprove_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="Tan" />
                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                </asp:GridView>
                <asp:SqlDataSource ID="sdsForApprove" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>">
                </asp:SqlDataSource>
            <asp:HiddenField ID="HiddenFieldUserLogin" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
