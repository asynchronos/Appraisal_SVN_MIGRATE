﻿<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<script type="text/javascript">
    function makeNewOpenWindow(redid, hubid) {
        var windowFeatures;
        var newWindow;
        var approveId = document.getElementById('<%=HiddenFieldUserLogin.ClientID%>').value;

        windowFeatures = "top=0,left=0,resizable=yes,scrollbars=yes,width=" + (screen.width) + ",height=" + (screen.height);
        newWindow = window.open("Appraisal_Report_FullForm.aspx?Req_Id=" + redid + "&Hub_Id=" + hubid + "&ApproveId=" + approveId, "openWindow", windowFeatures);
        newWindow.focus();
    }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="background-image: url('Images/imagesCAMBBQTW.jpg')"  >
<br />
<br />
<table width="100%">
    <tr>
        <td>
            <asp:Label ID="Label2" runat="server" style="font-weight: 700" 
                Text="รายการประเมินรอยืนยันราคา"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="GridViewWait_For_Approve" runat="server" 
                AutoGenerateColumns="False" DataSourceID="SqlDataSourceWait_For_Approve" 
                BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                CellPadding="2" ForeColor="Black" GridLines="None" AllowPaging="True">
                <Columns>
                    <asp:TemplateField HeaderText="Req_Id" SortExpression="Req_Id">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Req_Id") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Req_Id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Hub_Id" HeaderText="Hub_Id" 
                        SortExpression="Hub_Id" />
                    <asp:BoundField DataField="Hub_Name" HeaderText="Hub_Name" 
                        SortExpression="Hub_Name" />
                    <asp:BoundField DataField="AID" HeaderText="AID" SortExpression="AID" />
                    <asp:BoundField DataField="Temp_AID" HeaderText="Temp_AID" 
                        SortExpression="Temp_AID" />
                    <asp:BoundField DataField="Approve_Id" HeaderText="Approve_Id" 
                        SortExpression="Approve_Id" />
                    <asp:BoundField DataField="ApproveName" HeaderText="ApproveName" 
                        ReadOnly="True" SortExpression="ApproveName" />
                    <asp:BoundField DataField="Cif" HeaderText="Cif" SortExpression="Cif" />
                    <asp:BoundField DataField="CifName" HeaderText="CifName" ReadOnly="True" 
                        SortExpression="CifName" />
                    <asp:BoundField DataField="ChkColl" HeaderText="ChkColl" 
                        SortExpression="ChkColl" />
                    <asp:BoundField DataField="Appraisal_Id" HeaderText="Appraisal_Id" 
                        SortExpression="Appraisal_Id" />
                    <asp:BoundField DataField="AppraisalName" HeaderText="AppraisalName" 
                        ReadOnly="True" SortExpression="AppraisalName" />
                    <asp:BoundField DataField="Approve_Date" HeaderText="Approve_Date" 
                        SortExpression="Approve_Date" />
                        <asp:TemplateField HeaderText="">
                            <ItemStyle HorizontalAlign="Center" Width="25px" />
                            <ItemTemplate>
                                <asp:ImageButton ID="imgConfirm" runat="server" Height="22px" ImageUrl="~/Images/dollar.jpg"
                                    ToolTip="รายละเอียดการกำหนดราคา" Width="22px" OnClientClick='<%# "makeNewOpenWindow("+Eval("Req_Id").toString()+","+EVAL("Hub_Id").toString()+"); return false;" %>' />
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
            <asp:SqlDataSource ID="SqlDataSourceWait_For_Approve" runat="server" 
                ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
                SelectCommand="GET_LIST_WAIT_FOR_APPROVE_BY_USER" 
                SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:ControlParameter ControlID="HiddenFieldUserLogin" Name="APPROVE_ID" 
                        PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:HiddenField ID="HiddenFieldUserLogin" runat="server" />
        </td>
    </tr>    
</table>
</div>

</asp:Content>

