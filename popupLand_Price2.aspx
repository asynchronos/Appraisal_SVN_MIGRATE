<%@ Page Language="VB" AutoEventWireup="false" CodeFile="popupLand_Price2.aspx.vb" Inherits="popupLand_Price2" %>

<%@ Register assembly="Mytextbox" namespace="Mytextbox" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        
            .style26
        {
            width: 204px;
        }
        .style27
        {
            width: 226px;
        }
        .style22
        {
            width: 293px;
        }
        
        .style5
        {
            width: 187px;
        }
        .style17
        {
            width: 204px;
            height: 30px;
        }
        .style23
        {
            width: 293px;
            height: 30px;
        }
            .style19
        {
            width: 187px;
            height: 30px;
        }
        .style28
        {
            width: 226px;
            height: 30px;
        }
            </style>
</head>
<body style="margin-top:0px; margin-left:0px; margin-right:0px;">
    <form id="form1" runat="server">
    <div>

    
    <table style="background-color: #B5C7DE;" width="100%">
        <tr>
            <td class="style26">
                เลขลำดับ</td>
            <td>
                <asp:Label ID="lblId" runat="server" style="font-weight: 700; color: #FF0000;"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td class="style27">
                    &nbsp;</td>
        </tr>     
        <tr>
            <td class="style26">
                เลขคำขอประเมิน</td>
            <td>
                <asp:Label ID="lblReq_Id" runat="server" style="font-weight: 700"></asp:Label>
            </td>
            <td>
                รหัส Hub</td>
            <td class="style27">
                <asp:Label ID="lblHub_Id" runat="server" style="font-weight: 700"></asp:Label>
            </td>
        </tr>    
        <tr>
            <td class="style26">
                AID</td>
            <td>
                    <asp:TextBox ID="txtAID" runat="server"></asp:TextBox>
            </td>
            <td>
                CID</td>
            <td class="style27">
                    <asp:TextBox ID="txtCID" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style26">
                ชนิดหลักประกัน</td>
            <td>
                <asp:DropDownList ID="DDLSubCollType" runat="server" 
                        DataSourceID="sdsSubCollType" DataTextField="SubCollType_Name"
                        DataValueField="MysubColl_ID">
                </asp:DropDownList>
            </td>
            <td>
                เลขที่โฉนด</td>
            <td class="style27">
                <asp:TextBox ID="txtChanode" runat="server" Width="180px"></asp:TextBox>
            &nbsp;</td>
        </tr>
        <tr>
            <td class="style26">
                    เนื้อที่
                </td>
            <td class="style22">

                    <cc1:mytext ID="txtRai" runat="server" AllowUserKey="int_Integer"
                        EnableTextAlignRight="True" Width="50px"
                        MyClintID="txtRai"
                        onkeyup="CalSection_Land(this,event);" >0</cc1:mytext>
                    &nbsp;ไร่
                    <cc1:mytext ID="txtNgan" runat="server" AllowUserKey="int_Integer" EnableTextAlignRight="True"
                        MaxLength="1" Width="50px"
                        MyClintID="txtNgan"
                        onkeyup="CalSection_Land(this,event);" >0</cc1:mytext>
                    &nbsp;งาน
                   <cc1:mytext ID="txtWah" runat="server" AllowUserKey="num_Numeric" EnableTextAlignRight="True"
                        MaxLength="4" Width="50px"
                        MyClintID="txtWah"
                        onkeyup="CalSection_Land(this,event);" >0</cc1:mytext>
                    &nbsp;ตรว.</td>
            <td class="style5">
                                        ที่ตั้งหลักประกัน ตั้งอยู่ถนน</td>
            <td class="style27">
                    <asp:TextBox ID="txtRoad" runat="server"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td class="style26">
                    ตั้งอยู่
                </td>
            <td class="style22">
                <asp:DropDownList ID="ddlRoad_Detail" runat="server" 
                        DataSourceID="SDSRoad_Detail" DataTextField="Road_Detail_Name" 
                        DataValueField="Road_Detail_ID">
                </asp:DropDownList>
                   <cc1:mytext ID="txtMeter" runat="server" AllowUserKey="int_Integer" EnableTextAlignRight="True"
                        MaxLength="6" Width="50px">0</cc1:mytext>
                    เมตร</td>
            <td class="style5">
                    ตำบล/แขวง</td>
            <td class="style27">
                <asp:TextBox ID="txtTumbon" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style26">
                    อำเภอ/เขต</td>
            <td class="style22">
                <asp:TextBox ID="txtAmphur" runat="server"></asp:TextBox>
            </td>
            <td class="style5">
                    จังหวัด</td>
            <td class="style27">
                <asp:DropDownList ID="ddlProvince" runat="server" DataSourceID="SDSProvince" 
                    DataTextField="PROV_NAME" DataValueField="PROV_CODE">
                </asp:DropDownList>
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
        </tr>
        <tr>
            <td class="style17">
                    ถนนหน้าหลักประกันเป็น</td>
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
                <cc1:mytext id="txtRoadWidth" runat="server" AllowUserKey="num_Numeric" MaxLength="5"
                        Width="50px" EnableTextAlignRight="True">0</cc1:mytext>
                    &nbsp;เมตร
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
        </tr>
        <tr>
            <td class="style26">
                    การใช้ประโยชน์ในที่ดิน
                </td>
            <td class="style22">
                <asp:DropDownList ID="ddlBinifit" runat="server" DataSourceID="SDSBinifit" 
                        DataTextField="Binifit_Name" DataValueField="Binifit_ID">
                </asp:DropDownList>
            </td>
            <td class="style5">
                    ลักษณะรูปที่ดิน</td>
            <td class="style27">
                <asp:TextBox ID="txtBinifit" runat="server"></asp:TextBox>
            </td>
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
        </tr>
        <tr>
            <td class="style26">
                    ราคาต่อหน่วย</td>
            <td class="style22">
                <asp:DropDownList ID="ddlSubUnit" runat="server" DataSourceID="SDSSubUnit" 
                        DataTextField="SubUnit_Name" DataValueField="SubUnit_Id" 
                    MyClintID="ddlSubUnit" onkeyup="CalSection_Land(this,event);">
                </asp:DropDownList>
                <cc1:mytext id="txtPriceWah" runat="server" allowuserkey="num_Numeric" 
                    width="120px" EnableTextAlignRight="True"
                    MyClintID="txtPriceWah"
                    onkeyup="CalSection_Land(this,event);" >0</cc1:mytext>
            </td>
            <td class="style5">
                    เป็นเงิน</td>
            <td class="style27">
                <cc1:mytext ID="txtTotal" runat="server" AllowUserKey="num_Numeric" Width="120px"
                        AutoCurrencyFormatOnKeyUp="True" EnableTextAlignRight="True"
                        MyClintID="txtTotal">0</cc1:mytext>
            </td>
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
            <asp:ControlParameter ControlID="hdfColltype" Name="CollType_ID" 
                PropertyName="Value" Type="Int32" />
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
    <asp:SqlDataSource ID="SDSProvince" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT PROV_CODE, PROV_NAME FROM Bay01.dbo.TB_PROVINCE
Order by PROV_NAME">
    </asp:SqlDataSource>
    
    <asp:SqlDataSource ID="SDSSubUnit" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        
        SelectCommand="SELECT [SubUnit_Id], [SubUnit_Name] FROM [TB_SubUnit] WHERE ([SubUnit_Id] &lt;= @SubUnit_Id)">
        <SelectParameters>
            <asp:Parameter DefaultValue="3" Name="SubUnit_Id" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
        
    <asp:HiddenField ID="hdfColltype" runat="server" />
    <asp:HiddenField ID="hdfCif" runat="server" />
    </form>
</body>
</html>
