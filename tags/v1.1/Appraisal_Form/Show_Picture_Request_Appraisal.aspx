<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Show_Picture_Request_Appraisal.aspx.vb" Inherits="Upload_Form_Show_Picture_Request_Appraisal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>แสดงรูปที่ อัฟโหลดแล้ว</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" CellPadding="4" 
            DataKeyNames="Req_ID,Hub_ID,Picture_Path" 
            DataSourceID="Appraisal_Request_PicturePath" ForeColor="#333333" 
            GridLines="None">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:BoundField DataField="Req_ID" HeaderText="Req_ID" ReadOnly="True" 
                    SortExpression="Req_ID" />
                <asp:BoundField DataField="HUB_NAME" HeaderText="HUB_NAME" 
                    SortExpression="HUB_NAME" />

                <asp:TemplateField HeaderText="File upload">
                    <ItemTemplate>
                     <asp:HyperLink ID="linkPath" runat="server"  target='_blank'  text='<%#EVAL("Picture_Path") %>' NavigateUrl='<%#  "../UploadedFiles/Pic_RegID/" &  EVAL("Picture_Path") %>'>HyperLink</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
               
            </Columns>
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:SqlDataSource ID="Appraisal_Request_PicturePath" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
            SelectCommand="SELECT Appraisal_Request_PicturePath.Req_ID, Appraisal_Request_PicturePath.Hub_ID, TB_HUB.HUB_NAME, Appraisal_Request_PicturePath.Picture_Path FROM Appraisal_Request_PicturePath INNER JOIN TB_HUB ON Appraisal_Request_PicturePath.Hub_ID = TB_HUB.HUB_ID WHERE (Appraisal_Request_PicturePath.Req_ID = @Req_Id) AND (Appraisal_Request_PicturePath.Hub_ID = @Hub_Id)">
            <SelectParameters>
                <asp:ControlParameter ControlID="Label1" Name="Req_Id" PropertyName="Text" />
                <asp:ControlParameter ControlID="Label2" Name="Hub_Id" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
    
    </div>
    </form>
</body>
</html>
