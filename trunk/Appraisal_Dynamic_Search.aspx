<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_Dynamic_Search.aspx.vb" Inherits="Appraisal_Dynamic_Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
<br />

    <table class="style1">
        <tr>
            <td>
                จังหวัด</td>
            <td>
                <asp:DropDownList ID="ddlProvince" runat="server" DataSourceID="SDSProvince" 
                    DataTextField="PROV_NAME" DataValueField="PROV_CODE">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                ตำบล</td>
            <td>
                <asp:TextBox ID="txtDistrict" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                อำเภอ</td>
            <td>
                <asp:TextBox ID="txtAmphur" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                ถนน</td>
            <td>
                <asp:TextBox ID="txtRoad" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                ชนิดหลักประกัน</td>
            <td>
                <asp:DropDownList ID="ddlCollType" runat="server" DataSourceID="sdsCollType" 
                    DataTextField="SubCollType_Name" DataValueField="MysubColl_ID">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                ราคา</td>
            <td>
                <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label ID="lblSql" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView_CollAll" runat="server" 
                    BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                    CellPadding="2" ForeColor="Black" GridLines="None" AllowPaging="True" 
                    AutoGenerateColumns="False">
                    <FooterStyle BackColor="Tan" />
                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                        HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                    <Columns>
                    <asp:TemplateField HeaderText="APPRAISAL_ID">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("APPRAISAL_ID") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAID" runat="server" Text='<%# Bind("APPRAISAL_ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ประเภทหลักประกัน">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("COLLNAME") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblCollName" runat="server" Text='<%# Bind("COLLNAME") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="วันที่ประเมิน">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("APPRAISAL_DATE") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAppraisal_Date" runat="server" Text='<%# Bind("APPRAISAL_DATE","{0:d}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ซอย">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("SOI") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblSoi" runat="server" Text='<%# Bind("SOI") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>     
                    <asp:TemplateField HeaderText="ถนน">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ROAD") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblRoad" runat="server" Text='<%# Bind("ROAD") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="ตำบล">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DISTRICT") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblDistrict" runat="server" Text='<%# Bind("DISTRICT") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>                                                                                                                    <asp:TemplateField HeaderText="อำเภอ">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("AMPHUR") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAmphur" runat="server" Text='<%# Bind("AMPHUR") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="จังหวัด">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("PROVINCE_DESC") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblProvince_Name" runat="server" 
                                Text='<%# Bind("PROVINCE_DESC") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ราคาประเมิน">
                        <ItemStyle HorizontalAlign="Left" />
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("APPRAISAL_VALUE") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblColl_Value" runat="server" Text='<%# Bind("APPRAISAL_VALUE","{0:N}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>                                           
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    
    <asp:SqlDataSource ID="SDSProvince" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        
        SelectCommand="SELECT PROV_CODE, PROV_NAME FROM Bay01.dbo.TB_PROVINCE
Order by prov_code">
    </asp:SqlDataSource>
            <asp:SqlDataSource ID="sdsCollType" runat="server" 
                ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
                
        SelectCommand="SELECT [MysubColl_ID], [SubCollType_Name] FROM [CollType_All] ORDER BY [SubCollType_ID], [MysubColl_ID]">
            </asp:SqlDataSource>        

</asp:Content>

