<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ListOfAppraisal_Approve.aspx.vb" Inherits="ListOfAppraisal_Approve" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ยืนยันการเซ็นต์อนุมัติ</title>
</head>
<body>

    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label6" runat="server" Text="ผลยืนยันการเซ็นต์อนุมัติ"></asp:Label>    
    <asp:Label ID="Label7" runat="server" Text="อนุกรรมการยังเซ็นต์อนุมัติไม่ครบ" 
            style="color: #CC6600; font-weight: 700"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#E7E7FF" BorderWidth="1px" 
            CellPadding="3" DataKeyNames="Req_Id,Hub_Id,AID,Temp_AID,Approve_Id" 
            DataSourceID="sdsList_Appraisal_Approve" GridLines="Horizontal" 
            BorderStyle="None" ShowFooter="True">
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <Columns>
                <asp:TemplateField HeaderText="Req ID" SortExpression="Req_Id">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Req_Id") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Req_Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Hub ID" SortExpression="Hub_Id">
                    <EditItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Hub_Id") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Hub_Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText=" AID " SortExpression="AID">
                    <EditItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("AID") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("AID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="อนุกรรมการเซ็นต์อนุมัติ" SortExpression="ApproveName">
                <ItemStyle Width="250px"/>
                    <EditItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("ApproveName") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblApproveName" runat="server" Text='<%# Bind("ApproveName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ยืนยันการอนุมัติ" SortExpression="ChkColl">
                <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:RadioButton ID="Approve" runat="server" Checked='<%# Eval("Chk_Approve") %>' Enabled="False" />
                    </ItemTemplate>
                </asp:TemplateField>               
                <asp:TemplateField HeaderText="วันที่ยืนยันการอนุมัติ" SortExpression="Approve_Date">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Approve_Date") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label10" runat="server" 
                            Text='<%# Bind("Approve_Date", "{0}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
			    <asp:TemplateField HeaderText="">
                    <FooterTemplate>
                        <asp:Button ID="bntClose"  runat="server" Text="Close" 
                            onclick="bntClose_Click"/>
                    </FooterTemplate>
                </asp:TemplateField>                
            </Columns>

            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" 
                HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#738A9C" ForeColor="#F7F7F7" Font-Bold="True" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <AlternatingRowStyle BackColor="#F7F7F7" />
        </asp:GridView>
        
        <asp:SqlDataSource ID="sdsList_Appraisal_Approve" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
            SelectCommand="GET_WAIT_FOR_APPROVE1" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="hdfReq_Id" Name="Req_Id" PropertyName="Value" 
                    Type="Int32" />
                <asp:ControlParameter ControlID="hdfHub_Id" Name="Hub_Id" PropertyName="Value" 
                    Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:HiddenField ID="hdfReq_Id" runat="server" />
        <asp:HiddenField ID="hdfHub_Id" runat="server" />
    
    </div>
    </form>
</body>
</html>
