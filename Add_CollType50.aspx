<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Add_CollType50.aspx.vb" Inherits="Add_CollType50" %>

<%@ Register assembly="Mytextbox" namespace="Mytextbox" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">

        .style5
        {
            width: 187px;
        }
        .style17
        {
            width: 204px;
            height: 30px;
        }
        .style19
        {
            width: 187px;
            height: 30px;
        }
        .style20
        {
            height: 30px;
        }
        .style22
        {
            width: 293px;
        }
        .style23
        {
            width: 293px;
            height: 30px;
        }
            .style26
        {
            width: 204px;
        }
        .style27
        {
            width: 226px;
        }
        .style28
        {
            width: 226px;
            height: 30px;
        }
        .style29
        {
            width: 88px;
        }
        .style30
        {
            width: 88px;
            height: 30px;
        }
            .style31
        {
            width: 100%;
        }
            .style32
        {
            width: 40px;
        }
            </style>
</head>
<body>
    <form id="form2" runat="server">
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="2" DataSourceID="SDSTemp_AID" 
            ForeColor="Black" GridLines="None" BackColor="LightGoldenrodYellow" 
            BorderColor="Tan" BorderWidth="1px" Width="100%" AllowPaging="True" 
            DataKeyNames="Q_ID,Coll_ID" PageSize="12">
            <FooterStyle BackColor="Tan" />
            <Columns>
                <asp:BoundField DataField="Q_ID" HeaderText="เลขที่คิว" ReadOnly="True" 
                    SortExpression="Q_ID" />
                <asp:BoundField DataField="Coll_ID" HeaderText="เลข COLL ID" ReadOnly="True" 
                    SortExpression="Coll_ID" />
                <asp:BoundField DataField="Detail1" HeaderText="Detail1" ReadOnly="True" 
                    SortExpression="Detail1" />
                <asp:BoundField DataField="PROV_NAME" HeaderText="จังหวัด" 
                    SortExpression="PROV_NAME" />
                <asp:BoundField DataField="Detail2" HeaderText="Detail2" ReadOnly="True" 
                    SortExpression="Detail2" />
            </Columns>
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
        </asp:GridView>
        <asp:SqlDataSource ID="SDSTemp_AID" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
            
            
            SelectCommand="GET_Appraisal_Detail_BY_CollType" 
            SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:QueryStringParameter Name="TEMP_AID" QueryStringField="Temp_Aid" />
                <asp:QueryStringParameter Name="Q_ID" QueryStringField="Q_ID" />
                <asp:QueryStringParameter Name="CollType" QueryStringField="CollType" 
                    Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    <div>
    
    </div>
    <div>
    
           <table>
            <tr>
                <td class="style26">ชนิดหลักประกัน</td>
                <td>
                    <asp:DropDownList ID="DDLSubCollType" runat="server" 
                        DataSourceID="sdsSubCollType" DataTextField="SubCollType_Name"
                        DataValueField="MysubColl_ID">
                    </asp:DropDownList>
    
                </td>
                <td>ประกอบด้วยเลขที่</td>
                <td class="style27">
                    <asp:TextBox ID="txtChanode" runat="server" Width="222px"></asp:TextBox>
                </td>
                <td class="style29"></td>
                <td></td>
            </tr>
            <tr>
                <td class="style26">
                    เนื้อที่
                </td>
                <td class="style22">
                    <cc1:mytext ID="txtRai" runat="server" AllowUserKey="int_Integer" AutoCurrencyFormatOnKeyUp="True"
                        EnableTextAlignRight="True" Width="50px" 
                        ReadOnly="True">0</cc1:mytext>
                    ไร่
                    <cc1:mytext ID="txtNgan" runat="server" AllowUserKey="int_Integer" EnableTextAlignRight="True"
                        MaxLength="1" Width="50px" ReadOnly="True">0</cc1:mytext>
                    งาน
                    <cc1:mytext ID="txtWah" runat="server" AllowUserKey="int_Integer" EnableTextAlignRight="True"
                        MaxLength="3" Width="50px" ReadOnly="True">0</cc1:mytext>
                    &nbsp;ตรว.</td>
                <td class="style5">
                    &nbsp;
                </td>
                <td class="style27">
                    &nbsp;
                </td>
                <td class="style29">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style26">
                    ที่ตั้งหลักประกัน ตั้งอยู่ถนน
                </td>
                <td class="style22">
                    <asp:TextBox ID="txtRoad" runat="server"></asp:TextBox>
                </td>
                <td class="style5">
                    ตั้งอยู่
                </td>
                <td class="style27">
                    <asp:DropDownList ID="ddlRoad_Detail" runat="server" 
                        DataSourceID="SDSRoad_Detail" DataTextField="Road_Detail_Name" 
                        DataValueField="Road_Detail_ID">
                    </asp:DropDownList>
                    <cc1:mytext ID="txtMeter" runat="server" AllowUserKey="num_Numeric" Width="50px"
                        AutoCurrencyFormatOnKeyUp="True" EnableTextAlignRight="True">0</cc1:mytext>
                    เมตร</td>
                <td class="style29">
                    &nbsp;</td>
                <td>
                    &nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td class="style26">
                    สถาพที่ดิน
                </td>
                <td class="style22">
                    <asp:DropDownList ID="ddlLand_State" runat="server" 
                        DataSourceID="SDSLand_State" DataTextField="Land_State_Name" 
                        DataValueField="Land_State_Id">
                    </asp:DropDownList>
                </td>
                <td class="style5">
                    รายละเอียดสภาพที่ดิน
                </td>
                <td class="style27">
                    <asp:TextBox ID="txtLand_State_Detail" runat="server"></asp:TextBox>
                </td>
                <td class="style29">
                    &nbsp;
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style17">
                    ถนนหน้าหลักประกัน
                </td>
                <td class="style23">
                    <asp:DropDownList ID="ddlRoad_Forntoff" runat="server" 
                        DataSourceID="SDSRoad_Forntoff" DataTextField="Road_Frontoff_Name" 
                        DataValueField="Road_Frontoff_ID">
                    </asp:DropDownList>
                </td>
                <td class="style19">
                    ผิวจราจรกว้าง
                </td>
                <td class="style28">
                    <cc1:mytext ID="txtRoadWidth" runat="server" AllowUserKey="num_Numeric" MaxLength="2"
                        Width="50px">0</cc1:mytext>
                    &nbsp;เมตร
                </td>
                <td class="style30">
                </td>
                <td class="style20">
                </td>
            </tr>
            <tr>
                <td class="style26">
                    ทำเล
                </td>
                <td class="style22">
                    <asp:DropDownList ID="ddlSite" runat="server" DataSourceID="SDSSite" 
                        DataTextField="Site_Name" DataValueField="Site_ID">
                    </asp:DropDownList>
                </td>
                <td class="style5">
                    รายละเอียดทำเล
                </td>
                <td class="style27">
                    <asp:TextBox ID="txtSite_Detail" runat="server"></asp:TextBox>
                </td>
                <td class="style29">
                    &nbsp;
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style26">
                    สาธารณูปโภค
                </td>
                <td class="style22">
                    <asp:DropDownList ID="ddlPublic_Utility" runat="server" 
                        DataSourceID="SDSPublic_Utility" DataTextField="Public_Utility_Name" 
                        DataValueField="Public_Utility_ID">
                    </asp:DropDownList>
                </td>
                <td class="style5">
                    รายละเอียดสาธารณูปโภค
                </td>
                <td class="style27">
                    <asp:TextBox ID="txtPublic_Utility_Detail" runat="server"></asp:TextBox>
                </td>
                <td class="style29">
                    &nbsp;
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style26">
                    การใช้ประโยชน์ในอาคาร
                </td>
                <td class="style22">
                    <asp:DropDownList ID="ddlBinifit" runat="server" DataSourceID="SDSBinifit" 
                        DataTextField="Binifit_Name" DataValueField="Binifit_ID">
                    </asp:DropDownList>
                </td>
                <td class="style5">
                    รายละเอียด
                </td>
                <td class="style27">
                    <asp:TextBox ID="txtBinifit" runat="server"></asp:TextBox>
                </td>
                <td class="style29">
                    &nbsp;
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style26">
                    แนวโน้มความเจริญ
                </td>
                <td class="style22">
                    <asp:DropDownList ID="ddlTendency" runat="server" DataSourceID="SDSTendency" 
                        DataTextField="Tendency_Name" DataValueField="Tendency_ID">
                    </asp:DropDownList>
                </td>
                <td class="style5">
                    สภาพคล่องการซื้อขาย
                </td>
                <td class="style27">
                    <asp:DropDownList ID="ddlBuySale_State" runat="server" 
                        DataSourceID="SDSBuySale_State" DataTextField="BuySale_State_Name" 
                        DataValueField="BuySale_State_ID">
                    </asp:DropDownList>
                </td>
                <td class="style29">
                    &nbsp;
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style26">
                    ตรว. ละ</td>
                <td class="style22">
                    <cc1:mytext ID="txtPriceWah" runat="server" AllowUserKey="num_Numeric" Width="120px"
                        AutoCurrencyFormatOnKeyUp="True" EnableTextAlignRight="True">0</cc1:mytext>
                </td>
                <td class="style5">
                    เป็นเงิน</td>
                <td class="style27">
                    <cc1:mytext ID="txtTotal" runat="server" AllowUserKey="num_Numeric" Width="120px"
                        AutoCurrencyFormatOnKeyUp="True" EnableTextAlignRight="True">0</cc1:mytext>
                </td>
                <td class="style29">
                    &nbsp;
                </td>
                <td>
                    &nbsp;</td>
            </tr>    
                <tr>
                    <td>แนบไฟล์รูป</td>
                    <td>
                    <input id="AddFileButton" onclick="wopen('FileUpload.aspx', 'popup', 500, 300); return false;"
                        type="button" value="Add File" /></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>  
                <tr>
                    <td></td>
                    <td></td>
                    <td style="background-color: #C0C0C0; color: #0000FF; text-align: center; vertical-align: middle; font-weight: bold; font-size: large;">
                        <table class="style31">
                            <tr>
                                <td class="style32">
                        <asp:ImageButton ID="imgBtnSave" runat="server" ImageUrl="~/Images/Save.jpg" />
                                </td>
                                   <td>SAVE</td>
                            </tr>
                        </table>
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>                  
            </table>
    
    </div>
    <asp:SqlDataSource ID="SDSGroup_TempAID" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="GET_TEMP_AID_FROM_DETAIL" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="Q_ID" QueryStringField="Q_ID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsSubCollType" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        
        SelectCommand="SELECT [SubCollType_Name], [MysubColl_ID] FROM [CollType_All] WHERE ([CollType_ID] = @CollType_ID)">
        <SelectParameters>
            <asp:QueryStringParameter Name="CollType_ID" QueryStringField="CollType" 
                Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSRoad_Detail" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Road_Detail_ID], [Road_Detail_Name] FROM [Road_Detail]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSLand_State" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Land_State_Id], [Land_State_Name] FROM [Land_State]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSRoad_Forntoff" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Road_Frontoff_ID], [Road_Frontoff_Name] FROM [Road_Frontoff]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSSite" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Site_ID], [Site_Name] FROM [Site]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSPublic_Utility" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Public_Utility_ID], [Public_Utility_Name] FROM [Public_Utility]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSBinifit" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Binifit_ID], [Binifit_Name] FROM [Binifit]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSTendency" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Tendency_ID], [Tendency_Name] FROM [Tendency]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSBuySale_State" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [BuySale_State_ID], [BuySale_State_Name] FROM [BuySale_State]">
    </asp:SqlDataSource>
    </form>
</body>
</html>
