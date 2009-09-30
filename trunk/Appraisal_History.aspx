<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_History.aspx.vb" Inherits="Appraisal_History" UICulture="th-TH" Culture="th-TH" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
<br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
        CellPadding="2" DataSourceID="sdsHistory" ForeColor="Black" 
        GridLines="None" style="font-size: small">
        <FooterStyle BackColor="Tan" />
        <Columns>
            <asp:BoundField DataField="Req_Id" HeaderText="Req_Id" 
                SortExpression="Req_Id" />
            <asp:BoundField DataField="Hub_ID" HeaderText="Hub_ID" 
                SortExpression="Hub_ID" />
            <asp:BoundField DataField="AID" HeaderText="AID" SortExpression="AID" />
            <asp:BoundField DataField="Cif" HeaderText="Cif" SortExpression="Cif" />
            <asp:BoundField DataField="Cifname" HeaderText="Cifname" ReadOnly="True" 
                SortExpression="Cifname" />
            <asp:BoundField DataField="Appraisal_Date" HeaderText="Appraisal_Date" 
                SortExpression="Appraisal_Date" />
            <asp:BoundField DataField="Status_ID" HeaderText="Status_ID" 
                SortExpression="Status_ID" />
            <asp:BoundField DataField="Status_Name" HeaderText="Status Name" 
                SortExpression="Status_Name" />                
            <asp:BoundField DataField="Appraisal_ID" HeaderText="Appraisal_ID" 
                SortExpression="Appraisal_ID" />
            <asp:BoundField DataField="AppraisalName" HeaderText="AppraisalName" 
                ReadOnly="True" SortExpression="AppraisalName" />
        </Columns>
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
            HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
    <asp:SqlDataSource ID="sdsHistory" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="GET_APPRAISAL_HISTORY" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
</asp:Content>

