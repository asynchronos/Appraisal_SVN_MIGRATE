<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_Price2_Add_By_Colltype18.aspx.vb" Inherits="Appraisal_Price2_Add_By_Colltype18" %>

<%@ Register assembly="Mytextbox" namespace="Mytextbox" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="Js/jquery.js" type="text/javascript"></script>
<script src="Js/common.js" type="text/javascript"></script>
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
        .style30
        {
            width: 88px;
            height: 30px;
        }
            .style20
        {
            height: 30px;
        }
            </style>
            
        <script type="text/javascript">
            function CalSection_Building(sender, e) {
                //ต้องกำหนด ชนิด input type MyClintID ที่ตัว Control ของแต่ละตัวที่จะส่ง และชื่อ Property  Name ของ Control นั้น ๆ ก่อน
                var building_area = getEleByProperty("input", "MyClintID", "txtArea");
                var price_per_unit = getEleByProperty("input", "MyClintID", "txtUnitPrice");
                var txtCondo_Price = getEleByProperty("input", "MyClintID", "txtCondoPrice");
                var b_area = Number(building_area.value);
                //alert(b_area);
                var pp_unit = Number(price_per_unit.value);
                //alert(pp_unit);
                var Condo_price = b_area * pp_unit;
                txtCondo_Price.value = addCommas(Condo_price);
            }

            function addCommas(nStr) {
                nStr += '';
                x = nStr.split('.');
                x1 = x[0];
                x2 = x.length > 1 ? '.' + x[1] : '';
                var rgx = /(\d+)(\d{3})/;
                while (rgx.test(x1)) {
                    x1 = x1.replace(rgx, '$1' + ',' + '$2');
                }
                return x1 + x2;
            }
        </script>               
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
<br />
    <asp:HiddenField ID="hhdfSubCollType" runat="server" />
    <asp:HiddenField ID="hdfId" runat="server" />
    <table style="background-color: #B5C7DE; font-size: small;" width="100%">
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
            <td class="style29">
                &nbsp;</td>
            <td>
            </td>
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
            <td class="style29">
                &nbsp;</td>
            <td>
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
                <asp:ImageButton ID="imSearchAID" runat="server" 
                        ImageUrl="~/Images/find1.jpg" Height="22px" Width="22px" 
                        ToolTip="ดูผลก่อนพิมพ์"/>
            </td>
            <td class="style29">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>    
        <tr>
            <td class="style26">
                เลขที่ทะเบียนอาคารชุด</td>
            <td>

                    <cc1:mytext ID="txtRegister_No" runat="server" AllowUserKey="txt_Text" 
                        Width="130px" BackColor="Yellow"></cc1:mytext>
                </td>
            <td>
                    เลขที่อาคาร</td>
            <td class="style27">

                    <cc1:mytext ID="txtBuild_Number" runat="server" AllowUserKey="txt_Text"
                        EnableTextAlignRight="True" Width="50px" BackColor="Yellow"></cc1:mytext>
            </td>
            <td class="style29">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style26">
                                เลขที่ห้อง</td>
            <td>
                <asp:TextBox ID="txtAddressNo" runat="server" Width="222px" BackColor="Yellow"></asp:TextBox>
                <asp:ImageButton ID="ImageButton_Verify" runat="server" 
                            ImageUrl="~/Images/page_accept.ico" Width="20px" Height="20px" 
                            ToolTip="ตรวสอบเลขที่ห้องชุด" />
                </td>
            <td>
                อยู่ชั้นที่</td>
            <td class="style27">

                    <cc1:mytext ID="txtFloorsAt" runat="server" AllowUserKey="int_Integer" AutoCurrencyFormatOnKeyUp="True"
                        EnableTextAlignRight="True" Width="50px"></cc1:mytext>
            </td>
            <td class="style29">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style26">
                ชื่ออาคารชุด</td>
            <td>
                <asp:TextBox ID="txtBuildingName" runat="server" Width="270px"></asp:TextBox>
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
                ชนิดหลักประกัน</td>
            <td>
                <asp:DropDownList ID="DDLSubCollType" runat="server" 
                        DataSourceID="sdsSubCollType" DataTextField="SubCollType_Name"
                        DataValueField="MysubColl_ID">
                </asp:DropDownList>
            &nbsp;จำนวนชั้นทั้งหมด

                    <cc1:mytext ID="txtFloors" runat="server" AllowUserKey="int_Integer" AutoCurrencyFormatOnKeyUp="True"
                        EnableTextAlignRight="True" Width="50px"></cc1:mytext>
                    &nbsp;ชั้น</td>
            <td>
                    จำนวนลิฟท์</td>
            <td class="style27">

                    <cc1:mytext ID="txtelevator_No" runat="server" AllowUserKey="int_Integer" AutoCurrencyFormatOnKeyUp="True"
                        EnableTextAlignRight="True" Width="50px"></cc1:mytext>
                ชุด</td>
            <td class="style29">
                &nbsp;</td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="style26">
                    เนื้อที่
                </td>
            <td class="style22">

                    <cc1:mytext ID="txtArea" runat="server" AllowUserKey="num_Numeric" AutoCurrencyFormatOnKeyUp="True"
                        EnableTextAlignRight="True" Width="50px" AutoPostBack="True" MyClintID="txtArea" onkeyup="CalSection_Building(this,event);" >0</cc1:mytext>
                    &nbsp;ตรม.&nbsp; สูง
                    <cc1:mytext ID="txtHeight" runat="server" AllowUserKey="num_Numeric" EnableTextAlignRight="True"
                        MaxLength="5" Width="50px">0</cc1:mytext>
                    &nbsp;เมตร</td>
            <td class="style5">
                                        ที่ตั้งหลักประกัน ตั้งอยู่ถนน</td>
            <td class="style27">
                    <asp:TextBox ID="txtRoad" runat="server"></asp:TextBox>
                </td>
            <td class="style29">
                &nbsp;</td>
            <td>
                &nbsp;</td>
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
                   <cc1:mytext ID="txtRoadAccress" runat="server" AllowUserKey="num_Numeric" EnableTextAlignRight="True"
                        MaxLength="4" Width="50px">0</cc1:mytext>
                    เมตร</td>
            <td class="style5">
                    ตำบล/แขวง</td>
            <td class="style27">
                <asp:TextBox ID="txtTumbon" runat="server"></asp:TextBox>
            </td>
            <td class="style29">
                &nbsp;</td>
            <td>
                    &nbsp;&nbsp;
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
            <td class="style29">
                &nbsp;</td>
            <td>
                    &nbsp;&nbsp;
                </td>
        </tr>        
        <tr>
            <td class="style17">
                    ถนนหน้าหลักประกัน</td>
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
                    โครงสร้างอาคาร</td>
            <td class="style22">
                    <asp:DropDownList ID="ddlBuild_Construct" runat="server" 
                        DataSourceID="SDSBuild_Construct" DataTextField="Build_Construct_Name" 
                        DataValueField="Build_Construct_ID">
                    </asp:DropDownList>
            </td>
            <td class="style5">
                    สภาพการตกแต่ง</td>
            <td class="style27">
                    <asp:DropDownList ID="ddlInteriorState" runat="server" 
                        DataSourceID="SDSInterior_State" DataTextField="InteriorState_Name" 
                        DataValueField="InteriorState_Id">
                    </asp:DropDownList>
            </td>
            <td class="style29">
                    &nbsp;</td>
            <td>
                &nbsp;</td></tr>
        <tr>
            <td class="style26">
                    สภาพและลักษณะห้องชุด</td>
            <td class="style22">
                <asp:DropDownList ID="ddlCharacter_Room" runat="server" 
                    DataSourceID="SDSCharacter_Room" DataTextField="Character_Room_Name" 
                    DataValueField="Character_Room_ID">
                </asp:DropDownList>
            </td>
            <td class="style5">
                    ขนาดห้องกว้างติดทางเดิน</td>
            <td class="style27">

                    <cc1:mytext ID="txtRoomWidth_BehideSiteWalk" runat="server" AllowUserKey="num_Numeric"
                        EnableTextAlignRight="True" Width="50px"></cc1:mytext>
            </td>
            <td class="style29">
                    &nbsp;</td>
            <td>
                &nbsp;</td></tr>
        <tr>
            <td class="style26">
                    ขนาดห้องลึกติดทางเดิน</td>
            <td class="style22">

                    <cc1:mytext ID="txtRoomdeep" runat="server" AllowUserKey="num_Numeric" AutoCurrencyFormatOnKeyUp="True"
                        EnableTextAlignRight="True" Width="50px"></cc1:mytext>
            </td>
            <td class="style5">
                    ขนาดห้องด้านหลังกว้าง</td>
            <td class="style27">

                    <cc1:mytext ID="txtBackside_Width" runat="server" AllowUserKey="num_Numeric"
                        EnableTextAlignRight="True" Width="50px"></cc1:mytext>
            </td>
            <td class="style29">
                    &nbsp;</td>
            <td>
                &nbsp;</td></tr>
        <tr>
            <td class="style26">
                    สภาพทางเดินในอาคารชุดเป็น</td>
            <td class="style22">
                <asp:DropDownList ID="ddlFloors" runat="server" DataSourceID="SDSFloors" 
                    DataTextField="Floor_Name" DataValueField="Floor_Id">
                </asp:DropDownList>
            </td>
            <td class="style5">
                    ทางเดินกว้าง</td>
            <td class="style27">

                    <cc1:mytext ID="txtSideWalk_Width" runat="server" AllowUserKey="num_Numeric"
                        EnableTextAlignRight="True" Width="50px"></cc1:mytext>
            &nbsp;เมตร</td>
            <td class="style29">
                    &nbsp;</td>
            <td>
                &nbsp;</td></tr>
        <tr>
            <td class="style26">
                    ตรม. ละ</td>
            <td class="style22">
                <cc1:mytext id="txtUnitPrice" runat="server" allowuserkey="num_Numeric" 
                    width="120px" EnableTextAlignRight="True" MyClintID="txtUnitPrice"
                        onkeyup="CalSection_Building(this,event);" >0</cc1:mytext>
            </td>
            <td class="style5">
                    เป็นเงิน</td>
            <td class="style27">
                <cc1:mytext ID="txtCondoPrice" runat="server" AllowUserKey="txt_Text" Width="120px"
                        AutoCurrencyFormatOnKeyUp="True" EnableTextAlignRight="True" 
                    MyClintID="txtCondoPrice" >0</cc1:mytext>
            </td>
            <td class="style29">
                    &nbsp;
                </td>
            <td>
                &nbsp;</td></tr><tr>
            <td>
                &nbsp;</td><td>
                &nbsp;</td><td>
            </td>
            <td>
            </td>
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
                                    <asp:ImageButton ID="ImageSave" runat="server" ImageUrl="~/Images/Save.jpg" />
                                </td>
                                   <td>SAVE</td></tr></table></td></tr></table><asp:SqlDataSource ID="SDSGroup_TempAID" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="GET_TEMP_AID_FROM_DETAIL" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="Q_ID" QueryStringField="Q_ID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsSubCollType" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        
        SelectCommand="SELECT [SubCollType_Name], [MysubColl_ID] FROM [CollType_All] WHERE ([CollType_ID] = @CollType_ID)">
        <SelectParameters>
            <asp:ControlParameter ControlID="hhdfSubCollType" Name="CollType_ID" 
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
    <asp:SqlDataSource ID="SDSBuild_Construct" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Build_Construct_ID], [Build_Construct_Name] FROM [Build_Construct]">
    </asp:SqlDataSource>
    
    <asp:SqlDataSource ID="SDSInterior_State" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        
        
        SelectCommand="SELECT [InteriorState_Id], [InteriorState_Name] FROM [Interior_State]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSFloors" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Floor_Id], [Floor_Name] FROM [Floor]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSCharacter_Room" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        
        SelectCommand="SELECT [Character_Room_ID], [Character_Room_Name] FROM [Character_Room]"></asp:SqlDataSource>
    </asp:Content>

