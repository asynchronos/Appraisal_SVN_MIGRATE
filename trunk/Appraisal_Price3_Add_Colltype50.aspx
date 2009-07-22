<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_Price3_Add_Colltype50.aspx.vb" Inherits="Appraisal_Price3_Add_Colltype50" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register assembly="Mytextbox" namespace="Mytextbox" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
            .style26
        {
            width: 204px;
        }
        .style27
        {
            width: 226px;
        }
        .style29
        {
            width: 88px;
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
            width: 338px;
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
        .style30
        {
            width: 88px;
            height: 30px;
        }
            .style20
        {
            height: 30px;
        }
            .style31
        {
            width: 338px;
        }
            </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<br />
<br />
    <asp:HiddenField ID="hdfColl_Type" runat="server" />
    <table style="background-color: #B5C7DE;" width="100%">
        <tr>
            <td class="style26">
                รายละเอียดการเพิ่ม</td>
            <td class="style31">
                <asp:Label ID="lblMethodDesc" runat="server" 
                    style="font-weight: 700; color: #FF0000;"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td class="style27">
                &nbsp;</td>
            <td class="style29">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style26">
                เลขลำดับ</td>
            <td class="style31">
                <asp:Label ID="lblId" runat="server" style="font-weight: 700; color: #FF0000;"></asp:Label>
            </td>
            <td>
                Temp AID</td>
            <td class="style27">
                <asp:Label ID="lblTemp_AID" runat="server" 
                    style="font-weight: 700; color: #FF0000;"></asp:Label>
            </td>
            <td class="style29">
                &nbsp;</td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="style26">
                เลขคำขอประเมิน</td>
            <td class="style31">
                <asp:Label ID="lblReq_Id" runat="server" style="font-weight: 700"></asp:Label>
            </td>
            <td>
                รหัส Hub</td>
            <td class="style27">
                <asp:Label ID="lblHub_Id" runat="server" style="font-weight: 700"></asp:Label>
            </td>
            <td class="style29">
                &nbsp;</td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="style26">
                ผู้ขอสินเชื่อ</td>
            <td class="style31">
                <asp:Label ID="lblCifName" runat="server" style="font-weight: 700"></asp:Label>
            </td>
            <td>
                Cif</td>
            <td class="style27">
                <asp:Label ID="lblCif" runat="server" style="font-weight: 700"></asp:Label>
            </td>
            <td class="style29">
                &nbsp;</td>
            <td>
            </td>
        </tr>        
        <tr>
            <td class="style26">
                ชนิดหลักประกัน</td>
            <td class="style31">
                <asp:DropDownList ID="DDLSubCollType" runat="server" 
                        DataSourceID="sdsSubCollType" DataTextField="SubCollType_Name"
                        DataValueField="MysubColl_ID">
                </asp:DropDownList>
            </td>
            <td>
                ประกอบด้วยเลขที่</td>
            <td class="style27">
                <asp:TextBox ID="txtChanode" runat="server" Width="222px"></asp:TextBox>
            </td>
            <td class="style29">
                &nbsp;</td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="style26">
                ระวาง</td>
            <td class="style31">
                <asp:TextBox ID="txtRaWang" runat="server" BackColor="#FFFF66" MaxLength="50"></asp:TextBox>
            </td>
            <td>
                                เลขที่ดิน</td>
            <td class="style27">
                <asp:TextBox ID="txtLandNumber" runat="server" BackColor="#FFFF66"></asp:TextBox>
            </td>
            <td class="style29">
                &nbsp;</td>
            <td>
            </td>
        </tr>  
        <tr>
            <td class="style26">
                หน้าสำรวจ</td>
            <td class="style31">
                <asp:TextBox ID="txtSurway" runat="server" BackColor="#FFFF66"></asp:TextBox>
            </td>
            <td>
                                สารบัญเล่มที่</td>
            <td class="style27">
                <asp:TextBox ID="txtDocNo" runat="server" BackColor="#FFFF66"></asp:TextBox>
            </td>
            <td class="style29">
                &nbsp;</td>
            <td>
            </td>
        </tr>       
        <tr>
            <td class="style26">
                หน้า</td>
            <td class="style31">
                <asp:TextBox ID="txtPage" runat="server" BackColor="#FFFF66"></asp:TextBox>
            </td>
            <td>
                    ตำบล/แขวง</td>
            <td class="style27">
                <asp:TextBox ID="txtTumbon" runat="server" Width="222px"></asp:TextBox>
            </td>
            <td class="style29">
                &nbsp;</td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="style26">
                    อำเภอ/เขต</td>
            <td class="style31">
                <asp:TextBox ID="txtAmphur" runat="server" Width="222px"></asp:TextBox>
            </td>
            <td class="style5">
                    จังหวัด</td>
            <td class="style27">
                <asp:DropDownList ID="ddlProvince" runat="server" DataSourceID="SDSProvince" 
                    DataTextField="PROV_NAME" DataValueField="PROV_CODE">
                </asp:DropDownList>
            </td>
            <td class="style29">
                &nbsp;</td>
            <td>
                    &nbsp;&nbsp;
                </td>
        </tr>        
        <tr>
            <td class="style26">
                    เนื้อที่
                </td>
            <td class="style31">
                <cc1:mytext ID="txtRai" runat="server" AllowUserKey="int_Integer"
                        EnableTextAlignRight="True" Width="50px" AutoPostBack="True">0</cc1:mytext>
                    &nbsp;ไร่
                    <cc1:mytext ID="txtNgan" runat="server" AllowUserKey="int_Integer" EnableTextAlignRight="True"
                        MaxLength="1" Width="50px" AutoPostBack="True">0</cc1:mytext>
                    &nbsp;งาน
                   <cc1:mytext ID="txtWah" runat="server" AllowUserKey="num_Numeric" EnableTextAlignRight="True"
                        MaxLength="5" Width="50px" AutoPostBack="True">0</cc1:mytext>
                    &nbsp;ตรว.</td>
            <td class="style5">
                                ผู้ถือกรรมสิทธิ์ที่ดิน</td>
            <td class="style27">
                <asp:TextBox ID="txtOwnerShip" runat="server" Width="222px" BackColor="#FFFF66"></asp:TextBox>
            </td>
            <td class="style29">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>         
        <tr>
            <td class="style26">
                ภาระผูกพัน</td>
            <td class="style31">
                <asp:TextBox ID="txtObligation" runat="server" Width="222px" 
                    BackColor="#FFFF66"></asp:TextBox>
            </td>
            <td>
                                        ที่ตั้งหลักประกัน ตั้งอยู่ถนน</td>
            <td class="style27">
                <asp:TextBox ID="txtRoad" runat="server" Width="222px"></asp:TextBox>
            </td>
            <td class="style29">
                &nbsp;</td>
            <td>
            </td>
        </tr>                                       
        <tr>
            <td class="style26">
                    การตั้งอยู่ของหลักประกัน</td>
            <td class="style31">
                <asp:DropDownList ID="ddlRoad_Detail" runat="server" 
                        DataSourceID="SDSRoad_Detail" DataTextField="Road_Detail_Name" 
                        DataValueField="Road_Detail_ID">
                </asp:DropDownList>
                <cc1:mytext ID="txtMeter" runat="server" AllowUserKey="num_Numeric" EnableTextAlignRight="True"
                        MaxLength="6" Width="50px">0</cc1:mytext>
                    เมตร</td>
            <td class="style5">
                    ชื่อ ซอย (ถ้ามี)</td>
            <td class="style27">
                <asp:TextBox ID="txtSoi" runat="server" Width="222px" BackColor="#FFFF66"></asp:TextBox>
            </td>
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
            <td class="style31">
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
                    ผิวจราจรกว้าง</td>
            <td class="style28">
                <cc1:mytext id="txtRoadWidth" runat="server" AllowUserKey="num_Numeric" MaxLength="5"
                        Width="50px" EnableTextAlignRight="True">0</cc1:mytext>
                    &nbsp;เมตร
                </td>
            <td class="style30">
            </td>
            <td class="style20">
            </td>
        </tr>
        <tr>
            <td class="style17">
                    ขนาดที่ดินกว้างติดถนน</td>
            <td class="style23">
                <cc1:mytext id="txtLand_Closeto_RoadWidth" runat="server" 
                    AllowUserKey="num_Numeric" MaxLength="5"
                        Width="50px" EnableTextAlignRight="True" BackColor="#FFFF66">0</cc1:mytext>
                    &nbsp;เมตร
                    ที่ดินลึก(ซ้าย/ขวา)
                <cc1:mytext id="txtDeepWidth" runat="server" AllowUserKey="txt_Text" MaxLength="10"
                        Width="50px" EnableTextAlignRight="True" BackColor="#FFFF66">0</cc1:mytext>
                    &nbsp;เมตร</td>
            <td class="style19">
                    ิที่ดินด้านหลังกว้าง</td>
            <td class="style28">
                <cc1:mytext id="txtBehindWidth" runat="server" AllowUserKey="num_Numeric" MaxLength="5"
                        Width="50px" EnableTextAlignRight="True" BackColor="#FFFF66">0</cc1:mytext>
                    &nbsp;เมตร</td>
            <td class="style30">
            </td>
            <td class="style20">
            </td>
        </tr>        
        <tr>
            <td class="style26">
                    ทำเล
                </td>
            <td class="style31">
                <asp:DropDownList ID="ddlSite" runat="server" DataSourceID="SDSSite" 
                        DataTextField="Site_Name" DataValueField="Site_ID">
                </asp:DropDownList>
            </td>
            <td class="style5">
                    รายละเอียดทำเล
                </td>
            <td class="style27">
                <asp:TextBox ID="txtSite_Detail" runat="server" Width="222px"></asp:TextBox>
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
            <td class="style31">
                <asp:DropDownList ID="ddlPublic_Utility" runat="server" 
                        DataSourceID="SDSPublic_Utility" DataTextField="Public_Utility_Name" 
                        DataValueField="Public_Utility_ID">
                </asp:DropDownList>
            </td>
            <td class="style5">
                    รายละเอียดสาธารณูปโภค
                </td>
            <td class="style27">
                <asp:TextBox ID="txtPublic_Utility_Detail" runat="server" Width="222px"></asp:TextBox>
            </td>
            <td class="style29">
                    &nbsp;
                </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style26">
                    การใช้ประโยชน์ในที่ดิน
                </td>
            <td class="style31">
                <asp:DropDownList ID="ddlBinifit" runat="server" DataSourceID="SDSBinifit" 
                        DataTextField="Binifit_Name" DataValueField="Binifit_ID">
                </asp:DropDownList>
            </td>
            <td class="style5">
                    ลักษณะรูปที่ดิน
                </td>
            <td class="style27">
                <asp:TextBox ID="txtBinifit" runat="server" Width="222px"></asp:TextBox>
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
            <td class="style31">
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
                    ราคาต่อหน่วย</td>
            <td class="style31">
                <asp:DropDownList ID="ddlSubUnit" runat="server" DataSourceID="SDSSubUnit" 
                        DataTextField="SubUnit_Name" DataValueField="SubUnit_Id">
                </asp:DropDownList>
            &nbsp;<cc1:mytext id="txtPriceWah" runat="server" allowuserkey="num_Numeric" width="120px"
                        autocurrencyformatonkeyup="True" EnableTextAlignRight="True" 
                    AutoPostBack="True">0</cc1:mytext>
            &nbsp;บาท</td>
            <td class="style5">
                    เป็นเงิน</td>
            <td class="style27">
                <cc1:mytext ID="txtTotal" runat="server" AllowUserKey="num_Numeric" Width="120px"
                        AutoCurrencyFormatOnKeyUp="True" EnableTextAlignRight="True" 
                    ReadOnly="True">0</cc1:mytext>
            &nbsp;บาท</td>
            <td class="style29">
                    &nbsp;
                </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                ที่ดินอยู่ในเขตพื้นที่สี</td>
            <td class="style31">
                <asp:DropDownList ID="ddlAreaColur" runat="server" 
                        DataSourceID="SDSArea_Color" DataTextField="AreaColour_Name" 
                        DataValueField="AreaColour_No" BackColor="#FFFF66">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr style="background-color:#E7E7FF;">
            <td colspan="6" align="center">
                <table>
                    <tr>
                        <td>
                            <asp:ImageButton ID="ImageSave" runat="server" ImageUrl="~/Images/Save.jpg" Width="35px" Height="35px" />
                        </td>
                        <td>
                            SAVE
                        </td>
                    </tr>
               </table>
           </td>    
        </tr>
    </table>
    <asp:SqlDataSource ID="SDSGroup_TempAID" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="GET_TEMP_AID_FROM_DETAIL" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="Q_ID" QueryStringField="Q_ID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsSubCollType" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        
        SelectCommand="SELECT [SubCollType_Name], [MysubColl_ID] FROM [CollType_All]">
<%--        <SelectParameters>
            <asp:QueryStringParameter Name="CollType_ID" QueryStringField="Coll_Type" 
                Type="Int32" />
        </SelectParameters>--%>
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
Order by prov_code">
    </asp:SqlDataSource>
    
    <asp:SqlDataSource ID="SDSArea_Color" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        
        
        SelectCommand="SELECT [AreaColour_No], [AreaColour_Name] FROM [AreaColour]">
    </asp:SqlDataSource>
    
    <asp:SqlDataSource ID="SDSSubUnit" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        
        SelectCommand="SELECT [SubUnit_Id], [SubUnit_Name] FROM [TB_SubUnit] WHERE ([SubUnit_Id] &lt;= @SubUnit_Id)">
        <SelectParameters>
            <asp:Parameter DefaultValue="3" Name="SubUnit_Id" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
        
</asp:Content>

