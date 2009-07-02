<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Appraisal_Price2_Information.aspx.vb" Inherits="Appraisal_Price2_Information" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 169px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table class="style1">
            <tr>
                <td class="style2">
                    Req ID</td>
                <td>
                    <asp:Label ID="lblReq_Id" runat="server"></asp:Label>
                </td>
                <td></td>
            </tr>
            <tr>
                <td class="style2">
                    Hub ID</td>
                <td>
                    <asp:Label ID="lblHub_Id" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblHub_Name" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Cif No.</td>
                <td>
                    <asp:Label ID="lblCif" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblCifName" runat="server"></asp:Label>
                </td>
            </tr>
            </table>
        <br />
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" Height="352px" 
            Width="100%" ActiveTabIndex="0">
            <ajaxToolkit:TabPanel runat="server" ID="tabPanelGeneral">
            <HeaderTemplate> ข้อมูลทั่วไป </HeaderTemplate>
                <ContentTemplate> 
                    <table width="100%">
                        <tr>
                            <td>
                            
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                    BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
                                    CellPadding="3" DataSourceID="sdsPrice2" GridLines="Horizontal" Height="108px" 
                                    Width="100%" style="font-size: small">
                                    <AlternatingRowStyle BackColor="#F7F7F7" />
                                    <Columns>
                                        <asp:BoundField DataField="ID" HeaderText="ลำดับ" 
                                            SortExpression="ID" >                                    
                                            <ItemStyle Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CollType_ID" HeaderText="ประเภท" 
                                            SortExpression="CollType_ID" >
                                            <ItemStyle Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SubCollType_Name" HeaderText="หลักประกัน" 
                                            SortExpression="SubCollType_Name" />
                                        <asp:BoundField DataField="Address_No" HeaderText="เลขที่" ReadOnly="True" 
                                            SortExpression="Address_No" />
                                        <asp:BoundField DataField="Tumbon" HeaderText="ตำบล" ReadOnly="True" 
                                            SortExpression="Tumbon" />
                                        <asp:BoundField DataField="Amphur" HeaderText="อำเภอ" ReadOnly="True" 
                                            SortExpression="Amphur" />
                                        <asp:BoundField DataField="PROV_NAME" HeaderText="จังหวัด" 
                                            SortExpression="PROV_NAME" />
                                    </Columns>
                                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                                </asp:GridView>
                                <asp:SqlDataSource ID="sdsPrice2" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
                                    SelectCommand="WITH PRICE2_GROUPLIST AS (SELECT ID, Req_Id, Hub_Id, Temp_AID, MysubColl_ID, Address_No, Tumbon, Amphur, Province FROM PRICE2_50 UNION SELECT Id, Req_Id, Hub_Id, Temp_AID, MysubColl_ID, Build_No AS Address_No, Tumbon, Amphur, Province FROM PRICE2_70_NEW UNION SELECT ID, Req_Id, Hub_Id, Temp_AID, MysubColl_ID, Address_No, Tumbon, Amphur, Province FROM PRICE2_18) SELECT P2G.ID, P2G.Req_Id, ARM.Cif, TB_TITLE.TITLE_NAME + ARM.Name + '  ' + ARM.Lastname AS CIFNAME, P2G.Hub_Id, H.HUB_NAME, P2G.Temp_AID, CTL.CollType_ID, P2G.MysubColl_ID, CTL.SubCollType_Name, P2G.Address_No, P2G.Tumbon, P2G.Amphur, P2G.Province, P.PROV_NAME FROM TB_TITLE INNER JOIN Appraisal_Request_Master AS ARM ON TB_TITLE.TITLE_CODE = ARM.Title RIGHT OUTER JOIN PRICE2_GROUPLIST AS P2G LEFT OUTER JOIN Bay01.dbo.TB_PROVINCE AS P ON P2G.Province = P.PROV_CODE LEFT OUTER JOIN TB_HUB AS H ON P2G.Hub_Id = H.HUB_ID LEFT OUTER JOIN CollType_All AS CTL ON P2G.MysubColl_ID = CTL.MysubColl_ID ON ARM.Req_ID = P2G.Req_Id WHERE (P2G.Temp_AID IS NOT NULL OR P2G.Temp_AID &lt;&gt; 0) AND (P2G.Req_Id = @Req_Id) AND (P2G.Hub_Id = @Hub_Id) ORDER BY CTL.CollType_ID, P2G.ID">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="lblReq_Id" Name="Req_Id" PropertyName="Text" 
                                            Type="Int32" />
                                        <asp:ControlParameter ControlID="lblHub_Id" Name="Hub_Id" PropertyName="Text" 
                                            Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
<ajaxToolkit:TabPanel runat="server" ID="talPanelAdditional" HeaderText="ข้อมูลเพิ่มเติม"> 
    <ContentTemplate>
        <asp:SqlDataSource ID="Appraisal_Request_PicturePath" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
            SelectCommand="SELECT Appraisal_Price2_PicturePath.Req_ID, Appraisal_Price2_PicturePath.Hub_ID, Appraisal_Price2_PicturePath.Temp_AID, TB_HUB.HUB_NAME, Appraisal_Price2_PicturePath.Picture_Path FROM Appraisal_Price2_PicturePath INNER JOIN TB_HUB ON Appraisal_Price2_PicturePath.Hub_ID = TB_HUB.HUB_ID WHERE (Appraisal_Price2_PicturePath.Req_ID = @Req_Id) AND (Appraisal_Price2_PicturePath.Hub_ID = @Hub_Id)">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblReq_Id" Name="Req_Id" PropertyName="Text" />
                <asp:ControlParameter ControlID="lblHub_Id" Name="Hub_Id" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
        <div>
            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
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
                        ItemStyle-Width="250px" SortExpression="HUB_NAME" />
                    <asp:TemplateField HeaderText="ภาพถ่ายหลักประกันจากสถานที่จริง">
                        <ItemTemplate>
                            <asp:HyperLink ID="linkPath" runat="server" 
                                NavigateUrl='<%#  "UploadedFiles/Pic_Price2/" &  EVAL("Picture_Path") %>' 
                                target="_blank" text='<%#EVAL("Picture_Path") %>'>HyperLink</asp:HyperLink>
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
    </ContentTemplate>
</ajaxToolkit:TabPanel> 
            
        </ajaxToolkit:TabContainer>
        <br />
    </div>
    </form>
</body>
</html>
