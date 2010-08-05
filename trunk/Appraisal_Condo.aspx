<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Appraisal_Condo.aspx.vb" Inherits="Appraisal_Condo" %>

<%@ Register assembly="Mytextbox" namespace="Mytextbox" tagprefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Js/jquery.js" type="text/javascript"></script>
    <script src="Js/common.js" type="text/javascript"></script>
    <script src="Js/jquery-1.4.2.min.js" type="text/javascript"></script>    
    <style type="text/css">

    </style>
    <script type="text/javascript" >
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
            txtCondo_Price.value = Condo_price;
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
              
        function returnValue() {
            var _PopupModal = getValueFromQueryString("PopupModal");
            id = "IframeCondo";
            var iframe = window.parent.document.getElementById(id);
            window.parent.$find(_PopupModal).hide();
            window.parent.location.replace(window.parent.location);
        }


    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <asp:HiddenField ID="hhdfSubCollType" runat="server" Value="18" />
    <asp:HiddenField ID="hdfId" runat="server" />
    <table style="background-color: #B5C7DE; font-size: small;" width="100%">
        <tr>
            <td>
                เลขลำดับ</td>
            <td>
                <asp:Label ID="lblId" runat="server" style="font-weight: 700; color: #FF0000;"></asp:Label>
            </td>
            <td>
                Temp_AID</td>
            <td>
                <asp:Label ID="lblTemp_AID" runat="server" 
                    style="font-weight: 700; color: #FF0000;"></asp:Label>
            </td>
        </tr>     
        <tr>
            <td>
                เลขคำขอประเมิน</td>
            <td>
                <asp:Label ID="lblReq_Id" runat="server" style="font-weight: 700"></asp:Label>
            </td>
            <td>
                รหัส Hub</td>
            <td>
                <asp:Label ID="lblHub_Id" runat="server" style="font-weight: 700"></asp:Label>
            </td>
        </tr>    
        <tr>
            <td>
                    ผู้ขอสินเชื่อ</td>
            <td>
                    <asp:Label ID="lblCifName" runat="server" Style="font-weight: 700"></asp:Label>
                </td>
            <td>
                    Cif</td>
            <td>

                    <asp:Label ID="lblCif" runat="server" Style="font-weight: 700"></asp:Label>
                </td>
        </tr>
        <tr>
            <td>
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
            <td>

                    <cc1:mytext ID="txtelevator_No" runat="server" AllowUserKey="int_Integer" AutoCurrencyFormatOnKeyUp="True"
                        EnableTextAlignRight="True" Width="50px"></cc1:mytext>
                ชุด</td>
        </tr>
        <tr>
            <td>
                ชื่ออาคารชุด</td>
            <td>
                <asp:TextBox ID="txtBuildingName" runat="server" Width="270px"></asp:TextBox>
            </td>
            <td>
                                        ทะเบียนอาคารชุดเลขที่</td>
            <td>

                    <cc1:mytext ID="txtRegister_No" runat="server" AllowUserKey="txt_Text" 
                        Width="130px"></cc1:mytext>
            </td>
        </tr>
        <tr>
            <td>
                อาคารเลขที่</td>
            <td>

                    <cc1:mytext ID="txtBuild_Number" runat="server" AllowUserKey="txt_Text"
                        Width="50px" MaxLength="8"></cc1:mytext>
            </td>
            <td>
                อยู่ชั้นที่</td>
            <td>

                    <cc1:mytext ID="txtFloorsAt" runat="server" AllowUserKey="int_Integer" AutoCurrencyFormatOnKeyUp="True"
                        EnableTextAlignRight="True" Width="50px"></cc1:mytext>
            </td>
        </tr>
        <tr>
            <td>
                    ึประกอบด้วยเลขที่</td>
            <td>

                <asp:TextBox ID="txtAddressNo" runat="server" Width="222px"></asp:TextBox>
                <asp:ImageButton ID="ImageButton_Verify" runat="server" 
                            ImageUrl="~/Images/page_accept.ico" Width="20px" Height="20px" 
                            ToolTip="ตรวสอบเลขที่ห้องชุด" />
            </td>
            <td>
                เนื้อที่
            </td>
            <td >

                    <cc1:mytext ID="txtArea" runat="server" AllowUserKey="num_Numeric" AutoCurrencyFormatOnKeyUp="True"
                    EnableTextAlignRight="True" Width="50px" AutoPostBack="True" MyClintID="txtArea" onkeyup="CalSection_Building(this,event);" >0</cc1:mytext>
                    &nbsp;ตรม.&nbsp; สูง
                    <cc1:mytext ID="txtHeight" runat="server" AllowUserKey="num_Numeric" EnableTextAlignRight="True"
                        MaxLength="5" Width="50px">0</cc1:mytext>
                    &nbsp;เมตร</td>
        </tr>
        <tr>
            <td>
                    อายุอาคาร</td>
            <td>

                    <cc1:mytext ID="txtBuilding_Age" runat="server" AllowUserKey="int_Integer" AutoCurrencyFormatOnKeyUp="True"
                        EnableTextAlignRight="True" Width="50px" BackColor="#FFFF66">0</cc1:mytext>
            &nbsp;ปี</td>
            <td>
                    รายละเอียดเพิ่มเติม</td>
            <td>

                <asp:TextBox ID="txtOtherDetail" runat="server" Width="240px" BackColor="#FFFF66"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td>
                    &nbsp;ที่ตั้งหลักประกัน ตั้งอยู่ถนน</td>
            <td>

                    <asp:TextBox ID="txtRoad" runat="server" Width="222px"></asp:TextBox>
                </td>
            <td>
                    ตั้งอยู่
                </td>
            <td>
                <asp:DropDownList ID="ddlRoad_Detail" runat="server" 
                        DataSourceID="SDSRoad_Detail" DataTextField="Road_Detail_Name" 
                        DataValueField="Road_Detail_ID">
                </asp:DropDownList>
                   <cc1:mytext ID="txtRoadAccress" runat="server" AllowUserKey="num_Numeric" EnableTextAlignRight="True"
                        MaxLength="5" Width="50px">0</cc1:mytext>
                    เมตร</td>
        </tr>
        <tr>
            <td>
                    ทรัพย์สินส่วนบุคคลนอกห้องชุด</td>
            <td>
                    <asp:TextBox ID="txtPartake" runat="server" Width="222px" 
                    BackColor="#FFFF66"></asp:TextBox>
                    </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                    ตำบล/แขวง</td>
            <td>
                <asp:TextBox ID="txtTumbon" runat="server"></asp:TextBox>
            </td>
            <td>
                    อำเภอ/เขต</td>
            <td>
                <asp:TextBox ID="txtAmphur" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                    จังหวัด</td>
            <td>
                <asp:DropDownList ID="ddlProvince" runat="server" DataSourceID="SDSProvince" 
                    DataTextField="PROV_NAME" DataValueField="PROV_CODE">
                </asp:DropDownList>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>        
        <tr>
            <td>
                    เขตการปกครอง&nbsp; แขวง/ตำบล</td>
            <td>
                <asp:TextBox ID="txtTumbon1" runat="server"></asp:TextBox>
            </td>
            <td>
                    อำเภอ/เขต</td>
            <td>
                <asp:TextBox ID="txtAmphur1" runat="server"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td>
                    จังหวัด</td>
            <td>
                <asp:DropDownList ID="ddlProvince1" runat="server" DataSourceID="SDSProvince" 
                    DataTextField="PROV_NAME" DataValueField="PROV_CODE">
                </asp:DropDownList>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                    ผู้ถือกรรมสิทธิ์ห้องชุด</td>
            <td>
                    <asp:TextBox ID="txtOwnership" runat="server" Width="222px" BackColor="#FFFF66"></asp:TextBox>
            </td>
            <td>
                ภาระผูกพัน</td>
            <td>
                <asp:TextBox ID="txtObligation" runat="server" Width="222px" 
                    BackColor="#FFFF66"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td>
                    ถนนหน้าหลักประกัน</td>
            <td>
                <asp:DropDownList ID="ddlRoad_Forntoff" runat="server" 
                        DataSourceID="SDSRoad_Forntoff" DataTextField="Road_Frontoff_Name" 
                        DataValueField="Road_Frontoff_ID">
                </asp:DropDownList>
            </td>
            <td>
                    ผิวจราจรกว้าง
                </td>
            <td>
                <cc1:mytext id="txtRoadWidth" runat="server" AllowUserKey="num_Numeric" MaxLength="5"
                        Width="50px" EnableTextAlignRight="True">0</cc1:mytext>
                    &nbsp;เมตร
                </td>
        </tr>
        <tr>
            <td>
                    ทำเล
                </td>
            <td>
                <asp:DropDownList ID="ddlSite" runat="server" DataSourceID="SDSSite" 
                        DataTextField="Site_Name" DataValueField="Site_ID">
                </asp:DropDownList>
            </td>
            <td>
                    รายละเอียดทำเล
                </td>
            <td>
                <asp:TextBox ID="txtSite_Detail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                    สาธารณูปโภค
                </td>
            <td>
                <asp:DropDownList ID="ddlPublic_Utility" runat="server" 
                        DataSourceID="SDSPublic_Utility" DataTextField="Public_Utility_Name" 
                        DataValueField="Public_Utility_ID">
                </asp:DropDownList>
            </td>
            <td>
                    รายละเอียดสาธารณูปโภค
                </td>
            <td>
                <asp:TextBox ID="txtPublic_Utility_Detail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                    การใช้ประโยชน์ในอาคาร
                </td>
            <td>
                <asp:DropDownList ID="ddlBinifit" runat="server" DataSourceID="SDSBinifit" 
                        DataTextField="Binifit_Name" DataValueField="Binifit_ID">
                </asp:DropDownList>
            </td>
            <td>
                    รายละเอียด
                </td>
            <td>
                <asp:TextBox ID="txtBinifit" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                    แนวโน้มความเจริญ
                </td>
            <td>
                <asp:DropDownList ID="ddlTendency" runat="server" DataSourceID="SDSTendency" 
                        DataTextField="Tendency_Name" DataValueField="Tendency_ID">
                </asp:DropDownList>
            </td>
            <td>
                    สภาพคล่องการซื้อขาย
                </td>
            <td>
                <asp:DropDownList ID="ddlBuySale_State" runat="server" 
                        DataSourceID="SDSBuySale_State" DataTextField="BuySale_State_Name" 
                        DataValueField="BuySale_State_ID">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                    โครงสร้างอาคาร</td>
            <td>
                    <asp:DropDownList ID="ddlBuild_Construct" runat="server" 
                        DataSourceID="SDSBuild_Construct" DataTextField="Build_Construct_Name" 
                        DataValueField="Build_Construct_ID">
                    </asp:DropDownList>
            </td>
            <td>
                    สภาพการตกแต่ง</td>
            <td>
                    <asp:DropDownList ID="ddlInteriorState" runat="server" 
                        DataSourceID="SDSInterior_State" DataTextField="InteriorState_Name" 
                        DataValueField="InteriorState_Id">
                    </asp:DropDownList>
            </td>
            </tr>
        <tr>
            <td>
                    สภาพและลักษณะห้องชุด</td>
            <td>
                <asp:DropDownList ID="ddlCharacter_Room" runat="server" 
                    DataSourceID="SDSCharacter_Room" DataTextField="Character_Room_Name" 
                    DataValueField="Character_Room_ID">
                </asp:DropDownList>
            </td>
            <td>
                    ขนาดห้องกว้างติดทางเดิน</td>
            <td>

                    <cc1:mytext ID="txtRoomWidth_BehideSiteWalk" runat="server" AllowUserKey="num_Numeric"
                        EnableTextAlignRight="True" Width="50px"></cc1:mytext>
                    เมตร</td>
            </tr>
        <tr>
            <td>
                    ขนาดห้องลึกติดทางเดิน</td>
            <td>

                    <cc1:mytext ID="txtRoomdeep" runat="server" AllowUserKey="num_Numeric" AutoCurrencyFormatOnKeyUp="True"
                        EnableTextAlignRight="True" Width="50px"></cc1:mytext>
                    เมตร</td>
            <td>
                    ขนาดห้องด้านหลังกว้าง</td>
            <td>

                    <cc1:mytext ID="txtBackside_Width" runat="server" AllowUserKey="num_Numeric"
                        EnableTextAlignRight="True" Width="50px"></cc1:mytext>
                    เมตร</td>
            </tr>
        <tr>
            <td>
                    สภาพทางเดินในอาคารชุดเป็น</td>
            <td>
                <asp:DropDownList ID="ddlFloors" runat="server" DataSourceID="SDSFloors" 
                    DataTextField="Floor_Name" DataValueField="Floor_Id">
                </asp:DropDownList>
            </td>
            <td>
                    ทางเดินกว้าง</td>
            <td>

                    <cc1:mytext ID="txtSideWalk_Width" runat="server" AllowUserKey="num_Numeric"
                        EnableTextAlignRight="True" Width="50px"></cc1:mytext>
            &nbsp;เมตร</td>
            </tr>
        <tr>
            <td>
                    สิ่งอำนวยความสะดวก</td>
            <td colspan="2">
                <asp:CheckBox ID="CheckBox1" runat="server" BackColor="#FFFF66" Text="ลิฟท์" />
                <asp:CheckBox ID="CheckBox2" runat="server" BackColor="#FFFF66" 
                    Text="ที่จอดรถ" />
                <asp:CheckBox ID="CheckBox3" runat="server" BackColor="#FFFF66" 
                    Text="สระว่ายน้ำ" />
                <asp:CheckBox ID="CheckBox4" runat="server" BackColor="#FFFF66" Text="ฟิตเนส" />
                <asp:CheckBox ID="CheckBox5" runat="server" BackColor="#FFFF66" Text="อื่น ๆ" />
            </td>
            <td >
            </td>
            </tr>
        <tr>
            <td>
                    รายละเอียดอื่น ๆ</td>
            <td>

                <asp:TextBox ID="txtUtilityOther_Detail" runat="server" Width="240px" 
                    BackColor="#FFFF66"></asp:TextBox>
            </td>
            <td>
                    <asp:HiddenField ID="hdfAppraisal_Id" runat="server" />
                </td>
            <td>
            </td>
            </tr>
        <tr>
            <td>
                    สภาพการปรับปรุงห้องชุด</td>
            <td colspan="3">

                <asp:TextBox ID="txtAdjust_Condo" runat="server" Width="800px" 
                    BackColor="#FFFF66"></asp:TextBox>
            </td>
            </tr>
        <tr>
            <td>
                    ตรม. ละ</td>
            <td>
                <cc1:mytext id="txtUnitPrice" runat="server" allowuserkey="num_Numeric" 
                    width="120px" EnableTextAlignRight="True" MyClintID="txtUnitPrice"
                        onkeyup="CalSection_Building(this,event);" >0</cc1:mytext>
            &nbsp;บาท</td>
            <td>
                    เป็นเงิน</td>
            <td>
                <cc1:mytext ID="txtCondoPrice" runat="server" AllowUserKey="txt_Text" Width="120px"
                        AutoCurrencyFormatOnKeyUp="True" EnableTextAlignRight="True" 
                    MyClintID="txtCondoPrice" onfocus="this.blur();">0</cc1:mytext>
            &nbsp;บาท</td>
            </tr><tr>
            <td colspan="4" align="center">
                    <table>
                        <tr>
                            <td>
                                <asp:ImageButton ID="ImageSave" runat="server" ImageUrl="~/Images/Save.jpg" Width="35px"
                                    Height="35px" />
                            </td>
                            <td>
                                <asp:Label ID="lblSave" runat="server" Style="font-weight: 700" Text="SAVE"></asp:Label>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImgBtnBack" runat="server" Height="35px" ImageUrl="~/Images/Button Previous.png"
                                    Width="35px" OnClientClick="returnValue(); return false;" />
                            </td>
                            <td>
                                <asp:Label ID="lblBack" runat="server" Style="font-weight: 700" Text="BACK"></asp:Label>
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
        
        SelectCommand="SELECT [SubCollType_Name], [MysubColl_ID] FROM [CollType_All] WHERE ([CollType_ID] = @CollType_ID)">
        <SelectParameters>
            <asp:Parameter DefaultValue="18" Name="CollType_ID" Type="Int32" />
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
Order by prov_code">
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
    
    </div>
    </form>
</body>
</html>
