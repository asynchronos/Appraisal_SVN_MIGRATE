<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Appraisal_Review_List_Cid.aspx.vb" Inherits="Appraisal_Review_List_Cid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-weight: 700">
    
        <asp:GridView ID="GridView_Review_List" runat="server" AutoGenerateColumns="False" 
            CellPadding="2" DataKeyNames="APPS_ID" DataSourceID="SqlDataSource1" 
            ForeColor="Black" GridLines="Horizontal" BackColor="LightGoldenrodYellow" 
            BorderColor="Tan" BorderWidth="1px" ShowFooter="True" 
        style="font-size: small" AllowPaging="True" PageSize="15">
            <FooterStyle BackColor="Tan" />
            <Columns>
                            <asp:TemplateField HeaderText="COLL_ID" SortExpression="COLL_ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblCOLL_ID" runat="server" Text='<%# Bind("COLL_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ADDR" SortExpression="ADDR">
                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblADDR" runat="server" Text='<%# Bind("ADDR") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BUILD NAME" SortExpression="BUILDNAME">
                                <ItemStyle Width="300px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblBUILDNAME" runat="server" Text='<%# Bind("BUILDNAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SOI">
                                <ItemStyle HorizontalAlign="Center" Width="80px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSOI" runat="server" Text='<%# Bind("SOI") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="ROAD">
                                <ItemStyle HorizontalAlign="Right" Width="150px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblROAD" runat="server" Text='<%# Bind("ROAD") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="DISTRICT" >
                                <ItemStyle HorizontalAlign="Center" Width="200px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDISTRICT" runat="server" Text='<%# Bind("DISTRICT") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AMPHUR" >
                                <ItemStyle HorizontalAlign="Center" Width="200px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAMPHUR" runat="server" Text='<%# Bind("AMPHUR") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="PROVINCE" >
                                <ItemStyle HorizontalAlign="Center" Width="200px" />
                                <ItemTemplate>
                                    <asp:Label ID="PROV_NAME" runat="server" Text='<%# Bind("PROV_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                                                                                                                   <asp:TemplateField HeaderText="Rai" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <ItemTemplate>
                                    <asp:Label ID="Rai" runat="server" Text='<%# Bind("AREA_RAI") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NGAN" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <ItemTemplate>
                                    <asp:Label ID="AREA_NGAN" runat="server" Text='<%# Bind("AREA_NGAN") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="WAH" >
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <ItemTemplate>
                                    <asp:Label ID="AREA_WAH" runat="server" Text='<%# Bind("AREA_WAH") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ROOM AREA" >
                                <ItemStyle HorizontalAlign="Center" Width="200px" />
                                <ItemTemplate>
                                    <asp:Label ID="ROOM_AREA" runat="server" Text='<%# Bind("ROOM_AREA") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                                                                                       
            </Columns>
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
        </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" > 
      </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
