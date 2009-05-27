<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Appraisal_Price2_Picture.aspx.vb" Inherits="Appraisal_Price2_Picture" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:SqlDataSource ID="Appraisal_Request_PicturePath" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
            
    
        SelectCommand="SELECT Appraisal_Price2_PicturePath.Req_ID, Appraisal_Price2_PicturePath.Hub_ID, Appraisal_Price2_PicturePath.Temp_AID, TB_HUB.HUB_NAME, Appraisal_Price2_PicturePath.Picture_Path FROM Appraisal_Price2_PicturePath INNER JOIN TB_HUB ON Appraisal_Price2_PicturePath.Hub_ID = TB_HUB.HUB_ID WHERE (Appraisal_Price2_PicturePath.Req_ID = @Req_Id) AND (Appraisal_Price2_PicturePath.Hub_ID = @Hub_Id)">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblReq_Id" Name="Req_Id" PropertyName="Text" />
                <asp:ControlParameter ControlID="lblHub_Id" Name="Hub_Id" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
    <div>
    
        <asp:Label ID="lblReq_Id" runat="server" Visible="False"></asp:Label>
        <br />
        <asp:Label ID="lblHub_Id" runat="server" Visible="False"></asp:Label>
    
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" CellPadding="4" 
            DataKeyNames="Req_ID,Hub_ID,Picture_Path" 
            DataSourceID="Appraisal_Request_PicturePath" ForeColor="#333333" 
            GridLines="None" style="font-size: small">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:BoundField DataField="Req_ID" HeaderText="Req ID" ReadOnly="True" 
                    SortExpression="Req_ID" />
                <asp:BoundField DataField="HUB_NAME" HeaderText="ชื่อ Hub" 
                    SortExpression="HUB_NAME" ItemStyle-Width="250px" />
                <asp:TemplateField HeaderText="ภาพถ่ายหลักประกันจากสถานที่จริง">
                    <ItemTemplate>
                     <asp:HyperLink ID="linkPath" runat="server"  target='_blank'  text='<%#EVAL("Picture_Path") %>' NavigateUrl='<%#  "UploadedFiles/Pic_Price2/" &  EVAL("Picture_Path") %>'>HyperLink</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
               
            </Columns>
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
