<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Apprisal_Request_JobList.aspx.vb" Inherits="Apprisal_Request_JobList" UICulture="th-TH" Culture="th-TH" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="ExportControl/ExportControl.ascx" tagname="ExportControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
<br />
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptLocalization="true" EnableScriptGlobalization="true">
    </asp:ScriptManager>
    <div>
    <table width="100%">
                        
                <tr>
                    <td align="center" style="font-size: x-large; font-weight: bold" >
                        ทะเบียนงานออก
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                            DataSourceID="SqlHubList" DataTextField="HUB_NAME" DataValueField="HUB_ID">
                        </asp:DropDownList>
                        &nbsp;
                        ประจำวันที่ <asp:TextBox ID="TxtCalendar" runat="server"></asp:TextBox>
                        &nbsp;
                        <cc1:CalendarExtender ID="CalendarExtender1"
                            runat="server" TargetControlID="TxtCalendar" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                        <asp:Button ID="Button1" runat="server" Text="ค้นหา" />
                    </td>
                </tr>
          
            
                <tr>
                    <td>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" DataSourceID="SqlGridView" BackColor="LightGoldenrodYellow" 
        BorderColor="Tan" BorderWidth="1px" CellPadding="2" 
        DataKeyNames="Hub_ID,Req_ID" ForeColor="Black" GridLines="None" Width="100%">
        <Columns>
            <asp:BoundField DataField="Req_ID" HeaderText="REQ ID" ReadOnly="True" 
                SortExpression="Req_ID" />        
            <asp:BoundField DataField="Cif" HeaderText="Cif" 
                SortExpression="Cif" />           
            <asp:BoundField DataField="CustomerName" HeaderText="CustomerName" 
                SortExpression="CustomerName" ReadOnly="True" />             
            <asp:BoundField DataField="CollOfNumber" HeaderText="CollOfNumber" 
                SortExpression="CollOfNumber" />
            <asp:BoundField DataField="TambonName" HeaderText="TambonName" 
                SortExpression="TambonName" />
            <asp:BoundField DataField="AmphurName" HeaderText="AmphurName" 
                SortExpression="AmphurName" />
            <asp:BoundField DataField="ProvinceName" HeaderText="ProvinceName" 
                SortExpression="ProvinceName" />
            <asp:BoundField DataField="DeptSender" HeaderText="DeptSender" 
            
                SortExpression="DeptSender" ReadOnly="True" />
            <asp:BoundField DataField="Create_Date" HeaderText="Create_Date" 
                SortExpression="Create_Date" />
            <asp:BoundField DataField="Hub_ID" HeaderText="Hub_ID" 
                SortExpression="Hub_ID" ReadOnly="True" />
            <asp:BoundField DataField="HUB_NAME" HeaderText="Hub Name" 
                SortExpression="HUB_NAME" />
        </Columns>
        <FooterStyle BackColor="Tan" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
            HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
                    </td>
                </tr>
          
            
    </table>
    </div>
    <asp:SqlDataSource ID="SqlHubList" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="SELECT HUB_ID, HUB_NAME FROM TB_HUB WHERE (HUB_ID &lt;&gt; '998')">
    </asp:SqlDataSource>
    
    <asp:SqlDataSource ID="SqlGridView" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="GET_APPRAISAL_LIST_BY_HUB" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" 
                Name="Hub_Id" PropertyName="SelectedValue" Type="Int32" />
            <asp:ControlParameter ControlID="TxtCalendar" Name="CREATE_DATE" 
                PropertyName="Text" Type="DateTime" />
        </SelectParameters>
    </asp:SqlDataSource>
    <uc1:ExportControl ID="ExportControl1" runat="server" ControlName="GridView1" 
        Filename="ReportOut" />
</asp:Content>

