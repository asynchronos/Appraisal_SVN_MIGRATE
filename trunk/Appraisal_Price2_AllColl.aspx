<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_Price2_AllColl.aspx.vb" Inherits="Appraisal_Price2_AllColl" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register assembly="Mytextbox" namespace="Mytextbox" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 169px;
        }
    
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
    function CalSection_Land(sender, e) {
        //ต้องกำหนด ชนิด input type MyClintID ที่ตัว Control ของแต่ละตัวที่จะส่ง และชื่อ Property  Name ของ Control นั้น ๆ ก่อน
        var txtrai = getEleByProperty("input", "MyClintID", "txtRai");
        var txtngan = getEleByProperty("input", "MyClintID", "txtNgan");
        var txtwah = getEleByProperty("input", "MyClintID", "txtWah");
        var txtpricewah = getEleByProperty("input", "MyClintID", "txtPriceWah");
        var txtland_Price = getEleByProperty("input", "MyClintID", "txtTotal");

        var wah_rai = Number(txtrai.value) * 400;
        //alert(wah_rai);
        var wah_ngan = Number(txtngan.value) * 100;
        var wah = Number(txtwah.value);
        var totalwar = wah_rai + wah_ngan + wah;
        var unit_price = Number(txtpricewah.value);
        var land_price = (totalwar * unit_price);

        //ส่งแสดงผลกลับให้กับ Textbox ที่อยู่หน้า Design
        txtland_Price.value = addCommas(land_price);
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

    function ActiveTabChanged(sender, e) {
        if (sender._activeTabIndex == 0) {
            ($get('<%=hdfColltype.ClientID%>').value == 50);
            var txtcolltype = getEleByProperty("input", "MyClintID", "txt_CollType");
            var colltype = 50;
            txtcolltype.value = colltype;
        }
        else if (sender._activeTabIndex == 1) {
        ($get('<%=hdfColltype.ClientID%>').value == 70);
        var txtcolltype = getEleByProperty("input", "MyClintID", "txt_CollType");
        var colltype = 70;
        txtcolltype.value = colltype;
        }
        else if (sender._activeTabIndex == 2) {
        ($get('<%=hdfColltype.ClientID%>').value == 18);
        var txtcolltype = getEleByProperty("input", "MyClintID", "txt_CollType");
        var colltype = 18;
        txtcolltype.value = colltype;
        }
    }
    
</script>                       
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
<br />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table class="style1">
            <tr>
                <td class="style2">
                    Req ID
                </td>
                <td>
                    <asp:Label ID="lblReq_Id" runat="server"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Hub ID
                </td>
                <td>
                    <asp:Label ID="lblHub_Id" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblHub_Name" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Cif No.
                </td>
                <td>
                    <asp:Label ID="lblCif" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblCifName" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" OnClientActiveTabChanged="ActiveTabChanged" Height="927px" Width="100%"
            ActiveTabIndex="0">
            <ajaxToolkit:TabPanel runat="server" ID="tabPanelGeneral">
                <HeaderTemplate>
                    หลักประกันที่ดิน
                </HeaderTemplate>
                <ContentTemplate>
                    <table width="100%">
                        <tr>
                            <td>
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
                                        <td class="style29">
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
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
                                            <asp:ImageButton ID="imSearchAID" runat="server" Height="22px" 
                                                ImageUrl="~/Images/find1.jpg" ToolTip="ค้นหา" Width="22px" />
                                        </td>
                                        <td class="style29">
                                            <asp:DropDownList ID="ddlAID" runat="server" Visible="False">
                                            </asp:DropDownList>
                                        </td>
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
                                            เนื้อที่
                                        </td>
                                        <td class="style22">
                                            <cc1:mytext ID="txtRai" runat="server" AllowUserKey="int_Integer" 
                                                EnableTextAlignRight="True" MyClintID="txtRai" 
                                                onkeyup="CalSection_Land(this,event);" Width="50px">0</cc1:mytext>
                                            &nbsp;ไร่
                                            <cc1:mytext ID="txtNgan" runat="server" AllowUserKey="int_Integer" 
                                                EnableTextAlignRight="True" MaxLength="1" MyClintID="txtNgan" 
                                                onkeyup="CalSection_Land(this,event);" Width="50px">0</cc1:mytext>
                                            &nbsp;งาน
                                            <cc1:mytext ID="txtWah" runat="server" AllowUserKey="num_Numeric" 
                                                EnableTextAlignRight="True" MaxLength="4" MyClintID="txtWah" 
                                                onkeyup="CalSection_Land(this,event);" Width="50px">0</cc1:mytext>
                                            &nbsp;ตรว.</td>
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
                                            <cc1:mytext ID="txtMeter" runat="server" AllowUserKey="int_Integer" 
                                                EnableTextAlignRight="True" MaxLength="6" Width="50px">0</cc1:mytext>
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
                                            <cc1:mytext ID="txtRoadWidth" runat="server" AllowUserKey="num_Numeric" 
                                                EnableTextAlignRight="True" MaxLength="5" Width="50px">0</cc1:mytext>
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
                                            ราคาต่อหน่วย</td>
                                        <td class="style22">
                                            <asp:DropDownList ID="ddlSubUnit" runat="server" DataSourceID="SDSSubUnit" 
                                                DataTextField="SubUnit_Name" DataValueField="SubUnit_Id">
                                            </asp:DropDownList>
                                            <cc1:mytext ID="txtPriceWah" runat="server" allowuserkey="num_Numeric" 
                                                EnableTextAlignRight="True" MyClintID="txtPriceWah" 
                                                onkeyup="CalSection_Land(this,event);" width="120px">0</cc1:mytext>
                                        </td>
                                        <td class="style5">
                                            เป็นเงิน</td>
                                        <td class="style27">
                                            <cc1:mytext ID="txtTotal" runat="server" AllowUserKey="num_Numeric" 
                                                AutoCurrencyFormatOnKeyUp="True" EnableTextAlignRight="True" 
                                                MyClintID="txtTotal" Width="120px">0</cc1:mytext>
                                        </td>
                                        <td class="style29">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr style="background-color:#E7E7FF;">
                                        <td align="center" colspan="6">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:ImageButton ID="ImageSave" runat="server" ImageUrl="~/Images/Save.jpg" />
                                                    </td>
                                                    <td>
                                                        SAVE</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            
            <ajaxToolkit:TabPanel runat="server" ID="talPanelAdditional" HeaderText="หลักประกันสิ่งปลูกสร้าง">
                <ContentTemplate>
                    <div>
                        <span class="style29">รายละเอียดสิ่งปลูกสร้างราคาที่ 2</span>
                        <table style="background-color: #B5C7DE; font-size: small;" width="100%">
                            <tr>
                                <td class="style21">
                                    เลขลำดับ</td>
                                <td>
                                    <asp:Label ID="lblId_Building" runat="server" 
                                        style="font-weight: 700; color: #FF0000;"></asp:Label>
                                </td>
                                <td>
                                    Temp AID</td>
                                <td class="style27">
                                    <asp:Label ID="lblTemp_AID" runat="server" 
                                        style="font-weight: 700; color: #FF0000;"></asp:Label>
                                </td>
                                <td class="style25">
                                    &nbsp;</td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td class="style21">
                                    เลขคำขอประเมิน</td>
                                <td class="style17">
                                    <asp:Label ID="lblReq_Id1" runat="server" MyClintID="lblReq_Id" 
                                        style="font-weight: 700"></asp:Label>
                                </td>
                                <td class="style17">
                                    รหัส Hub</td>
                                <td class="style27">
                                    <asp:Label ID="lblHub_Id1" runat="server" style="font-weight: 700"></asp:Label>
                                </td>
                                <td class="style25">
                                </td>
                                <td class="style17">
                                </td>
                            </tr>
                            <tr>
                                <td class="style22">
                                    ชนิดหลักประกัน</td>
                                <td colspan="5">
                                    <asp:DropDownList ID="DDLSubCollType0" runat="server" BackColor="#FFFF66" 
                                        DataSourceID="sdsSubCollType_Building" DataTextField="SubCollType_Name" 
                                        DataValueField="MysubColl_ID">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style22">
                                    ปลูกสร้างบนโฉนดเลขที่</td>
                                <td>
                                    <asp:TextBox ID="txtChanodeNo" runat="server" BackColor="#FFFF66" 
                                        MyClintID="txtChanodeNo"></asp:TextBox>
                                    &nbsp;<asp:ImageButton ID="ImageButton_Verify" runat="server" Height="20px" 
                                        ImageUrl="~/Images/page_accept.ico" ToolTip="ตรวสอบเลขที่โฉนด" Width="20px" />
                                </td>
                                <td>
                                    ิสิ่งปลูกสร้างกรรมสิทธิ์ของ</td>
                                <td class="style19">
                                    <asp:TextBox ID="txtOwnership" runat="server" BackColor="#FFFF66" Width="222px"></asp:TextBox>
                                </td>
                                <td class="style26">
                                    &nbsp;</td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td class="style22">
                                    สิ่งปลูกสร้าง บ้านเลขที่
                                </td>
                                <td class="style8">
                                    <asp:TextBox ID="txtBuild_No" runat="server" BackColor="#FFFF66" 
                                        MyClintID="txtBuild_No"></asp:TextBox>
                                </td>
                                <td class="style5">
                                    ตำบล</td>
                                <td class="style19">
                                    <asp:TextBox ID="txtTumbon0" runat="server" BackColor="#FFFF66"></asp:TextBox>
                                </td>
                                <td class="style26">
                                    อำเภอ</td>
                                <td>
                                    <asp:TextBox ID="txtAmphur0" runat="server" BackColor="#FFFF66"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style21">
                                    จังหวัด</td>
                                <td class="style17">
                                    <asp:DropDownList ID="ddlProvince0" runat="server" BackColor="#FFFF66" 
                                        DataSourceID="SDSProvince" DataTextField="PROV_NAME" DataValueField="PROV_CODE">
                                    </asp:DropDownList>
                                </td>
                                <td class="style17">
                                    ลักษณะอาคาร</td>
                                <td class="style27">
                                    <asp:DropDownList ID="ddlBuild_Character" runat="server" BackColor="#FFFF66" 
                                        DataSourceID="SDSlBuild_Character" DataTextField="Build_Character_Name" 
                                        DataValueField="Build_Character_ID">
                                    </asp:DropDownList>
                                </td>
                                <td class="style25">
                                    จำนวน</td>
                                <td class="style17">
                                    <cc1:mytext ID="txtFloor" runat="server" AllowUserKey="num_Numeric" 
                                        BackColor="#FFFF66" Width="35px"></cc1:mytext>
                                    &nbsp;ชั้น
                                    <asp:TextBox ID="txtItem" runat="server" BackColor="#FFFF66" Width="35px">0</asp:TextBox>
                                    &nbsp;หลัง</td>
                            </tr>
                            <tr>
                                <td class="style23">
                                    โครงสร้างอาคาร
                                </td>
                                <td class="style10">
                                    <asp:DropDownList ID="ddlBuild_Construct" runat="server" BackColor="#FFFF66" 
                                        DataSourceID="SDSBuild_Construct" DataTextField="Build_Construct_Name" 
                                        DataValueField="Build_Construct_ID">
                                    </asp:DropDownList>
                                </td>
                                <td class="style7">
                                    หลังคา
                                </td>
                                <td class="style20">
                                    <asp:DropDownList ID="ddlRoof" runat="server" BackColor="#FFFF66" 
                                        DataSourceID="SDSRoof" DataTextField="Roof_Name" DataValueField="Roof_ID">
                                    </asp:DropDownList>
                                </td>
                                <td class="style16">
                                    รายละเอียดเพิ่มเติม(ถ้ามี)
                                </td>
                                <td class="style4">
                                    <asp:TextBox ID="txtRoof_Detail" runat="server" BackColor="#FFFF66"></asp:TextBox>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style22">
                                    สภาพอาคาร
                                </td>
                                <td class="style8">
                                    <asp:DropDownList ID="ddlBuild_State" runat="server" BackColor="#FFFF66" 
                                        DataSourceID="SDSBuild_State" DataTextField="Build_State_Name" 
                                        DataValueField="Build_State_ID">
                                    </asp:DropDownList>
                                </td>
                                <td class="style5">
                                    รายละเอียดสภาพอื่น ๆ
                                </td>
                                <td class="style19">
                                    <asp:TextBox ID="txtBuild_State_Detail" runat="server"></asp:TextBox>
                                </td>
                                <td class="style26">
                                    สิ่งปลูกสร้าง</td>
                                <td>
                                    <asp:TextBox ID="txtBuilding_Detail" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style22">
                                    โครงสร้างหลังคา</td>
                                <td class="style8">
                                    <asp:DropDownList ID="ddlRoofConstructure" runat="server" BackColor="#FFFF66" 
                                        DataSourceID="SDSRoofStructure" DataTextField="RoofStructure_Name" 
                                        DataValueField="RoofStructure_Id">
                                    </asp:DropDownList>
                                </td>
                                <td class="style5">
                                    สภาพหลังคา</td>
                                <td class="style19">
                                    <asp:DropDownList ID="ddlRoofState" runat="server" BackColor="#FFFF66" 
                                        DataSourceID="SDSRoof_State" DataTextField="RoofState_Name" 
                                        DataValueField="RoofState_Id">
                                    </asp:DropDownList>
                                </td>
                                <td class="style26">
                                    สภาพการตกแต่ง</td>
                                <td>
                                    <asp:DropDownList ID="ddlInteriorState" runat="server" BackColor="#FFFF66" 
                                        DataSourceID="SDSInterior_State" DataTextField="InteriorState_Name" 
                                        DataValueField="InteriorState_Id">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style22">
                                    เป็นเงิน
                                </td>
                                <td class="style8">
                                    <cc1:mytext ID="txtPriceTotal1" runat="server" AllowUserKey="num_Numeric" 
                                        AutoCurrencyFormatOnKeyUp="True" BackColor="#FFFF66" 
                                        EnableTextAlignRight="True">0</cc1:mytext>
                                </td>
                                <td class="style5">
                                    &nbsp;</td>
                                <td class="style19">
                                    &nbsp;</td>
                                <td class="style26">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style22">
                                    &nbsp;เอกสารประกอบเพิ่มเติม
                                </td>
                                <td class="style8">
                                    <asp:CheckBox ID="chkDoc1" runat="server" Text="ใบอนุญาติปลูกสร้าง" />
                                </td>
                                <td class="style5">
                                    <asp:CheckBox ID="chkDoc2" runat="server" Text="เรื่องทางภารจำยอม" />
                                </td>
                                <td class="style19">
                                    &nbsp;</td>
                                <td class="style26">
                                    ระบุเอกสารอื่น
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDoc_Detail" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style22">
                                    &nbsp;</td>
                                <td class="style8">
                                    &nbsp;</td>
                                <td class="style5">
                                    &nbsp;</td>
                                <td class="style19">
                                    &nbsp;</td>
                                <td class="style26">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style28">
                                    พื้นที่สิ่งปลูกสร้างทั้งหมด</td>
                                <td class="style8">
                                    <cc1:mytext ID="txtBuildingArea" runat="server" AllowUserKey="num_Numeric" 
                                        BackColor="#FFFF66" EnableTextAlignRight="True" MaxLength="6" 
                                        MyClintID="txtBuildingArea" onkeyup="CalSection_Building(this,event);" 
                                        Width="35px">0</cc1:mytext>
                                    ตรม.</td>
                                <td class="style5">
                                    ราคาต่อหน่วย(สร้างเสร็จ)</td>
                                <td class="style19">
                                    <cc1:mytext ID="txtBuildingUnitPrice" runat="server" AllowUserKey="num_Numeric" 
                                        BackColor="#FFFF66" EnableTextAlignRight="True" 
                                        MyClintID="txtBuildingUnitPrice" onkeyup="CalSection_Building(this,event);" 
                                        Width="110px">0.00</cc1:mytext>
                                    บาท</td>
                                <td class="style26">
                                    มูลค่า(สร้างเสร็จ)</td>
                                <td>
                                    <cc1:mytext ID="txtBuildingPrice" runat="server" AllowUserKey="num_Numeric" 
                                        AutoCurrencyFormatOnKeyUp="True" BackColor="#FFFF66" 
                                        EnableTextAlignRight="True" MyClintID="txtBuildingPrice" Width="110px">0.00</cc1:mytext>
                                    บาท</td>
                            </tr>
                            <tr>
                                <td class="style22">
                                    เปอร์เซ็นต์สิ่งปลูกสร้างสร้างเสร็จ</td>
                                <td class="style8">
                                    <cc1:mytext ID="txtFinishPercent" runat="server" AllowUserKey="num_Numeric" 
                                        BackColor="#FFFF66" EnableTextAlignRight="True" MaxLength="3" 
                                        MyClintID="txtFinishPercent" onkeyup="CalSection_Building(this,event);" 
                                        Width="35px">100</cc1:mytext>
                                    &nbsp;%</td>
                                <td class="style5">
                                    มูลค่า</td>
                                <td class="style19">
                                    <cc1:mytext ID="txtPriceNotFinish" runat="server" AllowUserKey="num_Numeric" 
                                        AutoPostBack="True" BackColor="#FFFF66" EnableTextAlignRight="True" 
                                        MyClintID="txtPriceNotFinish" Width="110px">0.00</cc1:mytext>
                                    บาท</td>
                                <td class="style26">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style22">
                                    อายุการใช้งาน</td>
                                <td class="style8">
                                    <cc1:mytext ID="txtBuildingAge" runat="server" AllowUserKey="num_Numeric" 
                                        BackColor="#FFFF66" EnableTextAlignRight="True" MaxLength="2" 
                                        MyClintID="txtBuildingAge" onkeyup="CalSection_Building(this,event);" 
                                        Width="35px">0</cc1:mytext>
                                    ปี</td>
                                <td class="style5">
                                    ค่าเสื่อมต่อปี</td>
                                <td class="style19">
                                    <cc1:mytext ID="txtBuildingPersent1" runat="server" AllowUserKey="num_Numeric" 
                                        BackColor="#FFFF66" EnableTextAlignRight="True" MaxLength="5" 
                                        MyClintID="txtBuildingPersent1" onkeyup="CalSection_Building(this,event);" 
                                        Width="35px">0</cc1:mytext>
                                    %</td>
                                <td class="style26">
                                    ค่าเสื่อมตามสภาพปรับปรุง</td>
                                <td>
                                    <cc1:mytext ID="txtBuildingPersent2" runat="server" AllowUserKey="num_Numeric" 
                                        BackColor="#FFFF66" EnableTextAlignRight="True" MaxLength="5" 
                                        MyClintID="txtBuildingPersent2" onkeyup="CalSection_Building(this,event);" 
                                        Width="35px">0</cc1:mytext>
                                    %</td>
                            </tr>
                            <tr>
                                <td class="style22">
                                    ค่าเสื่อมตามสภาพเสื่อมโทรม</td>
                                <td class="style8">
                                    <cc1:mytext ID="txtBuildingPersent3" runat="server" AllowUserKey="num_Numeric" 
                                        BackColor="#FFFF66" EnableTextAlignRight="True" MaxLength="5" 
                                        MyClintID="txtBuildingPersent3" onkeyup="CalSection_Building(this,event);" 
                                        Width="35px">0</cc1:mytext>
                                    %</td>
                                <td class="style5">
                                    รวมค่าเสื่อม</td>
                                <td class="style19">
                                    <cc1:mytext ID="txtBuildingTotalDeteriorate" runat="server" 
                                        AllowUserKey="num_Numeric" BackColor="#FFFF66" EnableTextAlignRight="True" 
                                        MaxLength="5" MyClintID="txtBuildingTotalDeteriorate" 
                                        onkeyup="CalSection_Building(this,event);" Width="35px">0</cc1:mytext>
                                    %</td>
                                <td class="style26">
                                    รวมค่าเสื่อมราคา</td>
                                <td>
                                    <cc1:mytext ID="txtBuildingPriceTotalDeteriorate" runat="server" 
                                        AllowUserKey="num_Numeric" BackColor="#FFFF66" EnableTextAlignRight="True" 
                                        MyClintID="txtBuildingPriceTotalDeteriorate" Width="110px">0.00</cc1:mytext>
                                    บาท</td>
                            </tr>
                            <tr>
                                <td class="style24">
                                    &nbsp;</td>
                                <td class="style8">
                                    &nbsp;</td>
                                <td class="style5">
                                    &nbsp;</td>
                                <td class="style19">
                                    &nbsp;</td>
                                <td class="style26">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style28">
                                    ส่วนต่อเติม</td>
                                <td class="style8">
                                    <cc1:mytext ID="txtBuildAddArea" runat="server" AllowUserKey="num_Numeric" 
                                        BackColor="#FFFF66" EnableTextAlignRight="True" MaxLength="5" 
                                        MyClintID="txtBuildAddArea" onkeyup="CalSection_Building_Addplus(this,event);" 
                                        Width="35px">0</cc1:mytext>
                                    ตรม.</td>
                                <td class="style5">
                                    ราคาต่อหน่วย(สร้างเสร็จ)</td>
                                <td class="style19">
                                    <cc1:mytext ID="txtBuildAddUnitPrice" runat="server" AllowUserKey="num_Numeric" 
                                        BackColor="#FFFF66" EnableTextAlignRight="True" 
                                        MyClintID="txtBuildAddUnitPrice" 
                                        onkeyup="CalSection_Building_Addplus(this,event);" Width="110px">0.00</cc1:mytext>
                                    บาท</td>
                                <td class="style26">
                                    มูลค่า(สร้างเสร็จ)</td>
                                <td>
                                    <cc1:mytext ID="txtBuildAddPrice" runat="server" AllowUserKey="num_Numeric" 
                                        BackColor="#FFFF66" EnableTextAlignRight="True" MyClintID="txtBuildAddPrice" 
                                        Width="110px">0.00</cc1:mytext>
                                    บาท</td>
                            </tr>
                            <tr>
                                <td class="style22">
                                    เปอร์เซ็นต์ส่วนต่อเติมสร้างเสร็จ</td>
                                <td class="style8">
                                    <cc1:mytext ID="txtFinishPercent1" runat="server" AllowUserKey="num_Numeric" 
                                        BackColor="#FFFF66" EnableTextAlignRight="True" MaxLength="3" 
                                        MyClintID="txtFinishPercent1" 
                                        onkeyup="CalSection_Building_Addplus(this,event);" Width="35px">100</cc1:mytext>
                                    %</td>
                                <td class="style5">
                                    มูลค่า</td>
                                <td class="style19">
                                    <cc1:mytext ID="txtPriceNotFinish1" runat="server" AllowUserKey="num_Numeric" 
                                        BackColor="#FFFF66" EnableTextAlignRight="True" MyClintID="txtPriceNotFinish1" 
                                        Width="110px">0.00</cc1:mytext>
                                    บาท</td>
                                <td class="style26">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style22">
                                    อายุการใช้งาน</td>
                                <td class="style8">
                                    <cc1:mytext ID="txtBuildAddAge" runat="server" AllowUserKey="num_Numeric" 
                                        BackColor="#FFFF66" EnableTextAlignRight="True" MaxLength="2" 
                                        MyClintID="txtBuildAddAge" onkeyup="CalSection_Building_Addplus(this,event);" 
                                        Width="35px">0</cc1:mytext>
                                    ปี</td>
                                <td class="style5">
                                    ค่าเสื่อมต่อปี</td>
                                <td class="style19">
                                    <cc1:mytext ID="txtBuildAddPersent1" runat="server" AllowUserKey="num_Numeric" 
                                        BackColor="#FFFF66" EnableTextAlignRight="True" MaxLength="5" 
                                        MyClintID="txtBuildAddPersent1" 
                                        onkeyup="CalSection_Building_Addplus(this,event);" Width="35px">0</cc1:mytext>
                                    %</td>
                                <td class="style26">
                                    ค่าเสื่อมตามสภาพปรับปรุง
                                </td>
                                <td>
                                    <cc1:mytext ID="txtBuildAddPersent2" runat="server" AllowUserKey="num_Numeric" 
                                        BackColor="#FFFF66" EnableTextAlignRight="True" MaxLength="5" 
                                        MyClintID="txtBuildAddPersent2" 
                                        onkeyup="CalSection_Building_Addplus(this,event);" Width="35px">0</cc1:mytext>
                                    %</td>
                            </tr>
                            <tr>
                                <td class="style22">
                                    ค่าเสื่อมตามสภาพเสื่อมโทรม</td>
                                <td class="style8">
                                    <cc1:mytext ID="txtBuildAddPersent3" runat="server" AllowUserKey="num_Numeric" 
                                        BackColor="#FFFF66" EnableTextAlignRight="True" MaxLength="5" 
                                        MyClintID="txtBuildAddPersent3" 
                                        onkeyup="CalSection_Building_Addplus(this,event);" Width="35px">0</cc1:mytext>
                                    %</td>
                                <td class="style5">
                                    รวมค่าเสื่อม</td>
                                <td class="style19">
                                    <cc1:mytext ID="txtBuildAddTotalDeteriorate" runat="server" 
                                        AllowUserKey="num_Numeric" BackColor="#FFFF66" EnableTextAlignRight="True" 
                                        MaxLength="5" MyClintID="txtBuildAddTotalDeteriorate" Width="35px">0</cc1:mytext>
                                    %</td>
                                <td class="style26">
                                    รวมค่าเสื่อมราคา</td>
                                <td>
                                    <cc1:mytext ID="txtBuildAddPriceTotalDeteriorate" runat="server" 
                                        AllowUserKey="num_Numeric" BackColor="#FFFF66" EnableTextAlignRight="True" 
                                        MyClintID="txtBuildAddPriceTotalDeteriorate" Width="110px">0.00</cc1:mytext>
                                    บาท</td>
                            </tr>
                            <tr>
                                <td class="style22">
                                    &nbsp;</td>
                                <td class="style8">
                                    <asp:CheckBox ID="chkDetail" runat="server" Text="รายละเอียดเพิ่มเติม" />
                                </td>
                                <td ID="z" class="style5">
                                    <asp:Button ID="btnAddDetail" runat="server" Text="พื้น/ผนัง" />
                                </td>
                                <td class="style19">
                                    <asp:Button ID="btnAdPartake" runat="server" Text="เพิ่มส่วนควบ" />
                                </td>
                                <td class="style26">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style28" colspan="6">
                                    มาตรฐาน
                                    <asp:DropDownList ID="ddlStandard" runat="server" BackColor="#FFFF66" 
                                        DataSourceID="sdsStandard" DataTextField="Standard_Name" 
                                        DataValueField="Standard_Id">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style22">
                                    รายละเอียด&nbsp;</td>
                                <td class="style8" colspan="5">
                                    <asp:TextBox ID="txtBuildingDetail" runat="server" BackColor="#FFFF66" 
                                        Height="70px" TextMode="MultiLine" Width="600px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="background-color:#E7E7FF;">
                                <td align="center" colspan="6">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="ImageSave0" runat="server" Height="35px" 
                                                    ImageUrl="~/Images/Save.jpg" 
                                                    onclientclick="return ConfirmOnSave(getEleByProperty('span', 'MyClintID', 'lblReq_Id').innerHTML,getEleByProperty('input', 'MyClintID', 'txtBuild_No').value);" 
                                                    Width="35px" />
                                            </td>
                                            <td>
                                                SAVE
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImagePrint" runat="server" Height="35px" 
                                                    ImageUrl="~/Images/Printer.png" Width="35px" />
                                            </td>
                                            <td>
                                                Print Preview
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>

            <ajaxToolkit:TabPanel runat="server" ID="TabPanel1" HeaderText="หลักประกันคอนโด/ห้องชุด">
                <ContentTemplate>
                    <div>
                        <table style="background-color: #B5C7DE; font-size: small;" width="100%">
                            <tr>
                                <td class="style26">
                                    เลขลำดับ</td>
                                <td>
                                    <asp:Label ID="lblId_Condo" runat="server" 
                                        style="font-weight: 700; color: #FF0000;"></asp:Label>
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
                                    AID</td>
                                <td>
                                    <asp:TextBox ID="txtAID0" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    CID</td>
                                <td class="style27">
                                    <asp:TextBox ID="txtCID0" runat="server"></asp:TextBox>
                                    <asp:ImageButton ID="imSearchAID0" runat="server" Height="22px" 
                                        ImageUrl="~/Images/find1.jpg" ToolTip="ดูผลก่อนพิมพ์" Width="22px" />
                                </td>
                                <td class="style29">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style26">
                                    ชนิดหลักประกัน</td>
                                <td>
                                    <asp:DropDownList ID="DDLSubCollType1" runat="server" 
                                        DataSourceID="sdsSubCollType_Condo" DataTextField="SubCollType_Name" 
                                        DataValueField="MysubColl_ID">
                                    </asp:DropDownList>
                                    &nbsp;จำนวนชั้นทั้งหมด
                                    <cc1:mytext ID="txtFloors" runat="server" AllowUserKey="int_Integer" 
                                        AutoCurrencyFormatOnKeyUp="True" EnableTextAlignRight="True" Width="50px"></cc1:mytext>
                                    &nbsp;ชั้น</td>
                                <td>
                                    จำนวนลิฟท์</td>
                                <td class="style27">
                                    <cc1:mytext ID="txtelevator_No" runat="server" AllowUserKey="int_Integer" 
                                        AutoCurrencyFormatOnKeyUp="True" EnableTextAlignRight="True" Width="50px"></cc1:mytext>
                                    ชุด</td>
                                <td class="style29">
                                    &nbsp;</td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td class="style26">
                                    ชื่ออาคารชุด</td>
                                <td>
                                    <asp:TextBox ID="txtBuildingName" runat="server" Width="270px"></asp:TextBox>
                                </td>
                                <td>
                                    อยู่ชั้นที่</td>
                                <td class="style27">
                                    <cc1:mytext ID="txtFloorsAt" runat="server" AllowUserKey="int_Integer" 
                                        AutoCurrencyFormatOnKeyUp="True" EnableTextAlignRight="True" Width="50px"></cc1:mytext>
                                </td>
                                <td class="style29">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style26">
                                    ประกอบด้วยเลขที่</td>
                                <td>
                                    <asp:TextBox ID="txtAddressNo" runat="server" Width="222px"></asp:TextBox>
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
                                    ึอาคารเลขที่</td>
                                <td class="style22">
                                    <cc1:mytext ID="txtBuild_Number" runat="server" AllowUserKey="txt_Text" 
                                        EnableTextAlignRight="True" Width="50px"></cc1:mytext>
                                </td>
                                <td class="style5">
                                    ทะเบียนอาคารชุดเลขที่</td>
                                <td class="style27">
                                    <cc1:mytext ID="txtRegister_No" runat="server" AllowUserKey="txt_Text" 
                                        Width="130px"></cc1:mytext>
                                </td>
                                <td class="style29">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style26">
                                    เนื้อที่
                                </td>
                                <td class="style22">
                                    <cc1:mytext ID="txtArea" runat="server" AllowUserKey="num_Numeric" 
                                        AutoCurrencyFormatOnKeyUp="True" AutoPostBack="True" 
                                        EnableTextAlignRight="True" Width="50px">0</cc1:mytext>
                                    &nbsp;ตรม.&nbsp; สูง
                                    <cc1:mytext ID="txtHeight" runat="server" AllowUserKey="num_Numeric" 
                                        EnableTextAlignRight="True" MaxLength="5" Width="50px">0</cc1:mytext>
                                    &nbsp;เมตร</td>
                                <td class="style5">
                                    ที่ตั้งหลักประกัน ตั้งอยู่ถนน</td>
                                <td class="style27">
                                    <asp:TextBox ID="txtRoad0" runat="server"></asp:TextBox>
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
                                    <asp:DropDownList ID="ddlRoad_Detail0" runat="server" 
                                        DataSourceID="SDSRoad_Detail" DataTextField="Road_Detail_Name" 
                                        DataValueField="Road_Detail_ID">
                                    </asp:DropDownList>
                                    <cc1:mytext ID="txtRoadAccress" runat="server" AllowUserKey="num_Numeric" 
                                        EnableTextAlignRight="True" MaxLength="4" Width="50px">0</cc1:mytext>
                                    เมตร</td>
                                <td class="style5">
                                    ตำบล/แขวง</td>
                                <td class="style27">
                                    <asp:TextBox ID="txtTumbon1" runat="server"></asp:TextBox>
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
                                    <asp:TextBox ID="txtAmphur1" runat="server"></asp:TextBox>
                                </td>
                                <td class="style5">
                                    จังหวัด</td>
                                <td class="style27">
                                    <asp:DropDownList ID="ddlProvince1" runat="server" DataSourceID="SDSProvince" 
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
                                    <asp:DropDownList ID="ddlRoad_Forntoff0" runat="server" 
                                        DataSourceID="SDSRoad_Forntoff" DataTextField="Road_Frontoff_Name" 
                                        DataValueField="Road_Frontoff_ID">
                                    </asp:DropDownList>
                                </td>
                                <td class="style19">
                                    ผิวจราจรกว้าง
                                </td>
                                <td class="style28">
                                    <cc1:mytext ID="txtRoadWidth0" runat="server" AllowUserKey="num_Numeric" 
                                        EnableTextAlignRight="True" MaxLength="5" Width="50px">0</cc1:mytext>
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
                                    <asp:DropDownList ID="ddlSite0" runat="server" DataSourceID="SDSSite" 
                                        DataTextField="Site_Name" DataValueField="Site_ID">
                                    </asp:DropDownList>
                                </td>
                                <td class="style5">
                                    รายละเอียดทำเล
                                </td>
                                <td class="style27">
                                    <asp:TextBox ID="txtSite_Detail0" runat="server"></asp:TextBox>
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
                                    <asp:DropDownList ID="ddlPublic_Utility0" runat="server" 
                                        DataSourceID="SDSPublic_Utility" DataTextField="Public_Utility_Name" 
                                        DataValueField="Public_Utility_ID">
                                    </asp:DropDownList>
                                </td>
                                <td class="style5">
                                    รายละเอียดสาธารณูปโภค
                                </td>
                                <td class="style27">
                                    <asp:TextBox ID="txtPublic_Utility_Detail0" runat="server"></asp:TextBox>
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
                                    <asp:DropDownList ID="ddlBinifit0" runat="server" DataSourceID="SDSBinifit" 
                                        DataTextField="Binifit_Name" DataValueField="Binifit_ID">
                                    </asp:DropDownList>
                                </td>
                                <td class="style5">
                                    รายละเอียด
                                </td>
                                <td class="style27">
                                    <asp:TextBox ID="txtBinifit0" runat="server"></asp:TextBox>
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
                                    <asp:DropDownList ID="ddlTendency0" runat="server" DataSourceID="SDSTendency" 
                                        DataTextField="Tendency_Name" DataValueField="Tendency_ID">
                                    </asp:DropDownList>
                                </td>
                                <td class="style5">
                                    สภาพคล่องการซื้อขาย
                                </td>
                                <td class="style27">
                                    <asp:DropDownList ID="ddlBuySale_State0" runat="server" 
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
                                    <asp:DropDownList ID="ddlBuild_Construct0" runat="server" 
                                        DataSourceID="SDSBuild_Construct" DataTextField="Build_Construct_Name" 
                                        DataValueField="Build_Construct_ID">
                                    </asp:DropDownList>
                                </td>
                                <td class="style5">
                                    สภาพการตกแต่ง</td>
                                <td class="style27">
                                    <asp:DropDownList ID="ddlInteriorState0" runat="server" 
                                        DataSourceID="SDSInterior_State" DataTextField="InteriorState_Name" 
                                        DataValueField="InteriorState_Id">
                                    </asp:DropDownList>
                                </td>
                                <td class="style29">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
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
                                    <cc1:mytext ID="txtRoomWidth_BehideSiteWalk" runat="server" 
                                        AllowUserKey="num_Numeric" EnableTextAlignRight="True" Width="50px"></cc1:mytext>
                                </td>
                                <td class="style29">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style26">
                                    ขนาดห้องลึกติดทางเดิน</td>
                                <td class="style22">
                                    <cc1:mytext ID="txtRoomdeep" runat="server" AllowUserKey="num_Numeric" 
                                        AutoCurrencyFormatOnKeyUp="True" EnableTextAlignRight="True" Width="50px"></cc1:mytext>
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
                                    &nbsp;</td>
                            </tr>
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
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style26">
                                    ตรม. ละ</td>
                                <td class="style22">
                                    <cc1:mytext ID="txtUnitPrice" runat="server" allowuserkey="num_Numeric" 
                                        autocurrencyformatonkeyup="True" AutoPostBack="True" 
                                        EnableTextAlignRight="True" width="120px">0</cc1:mytext>
                                </td>
                                <td class="style5">
                                    เป็นเงิน</td>
                                <td class="style27">
                                    <cc1:mytext ID="txtCondoPrice" runat="server" AllowUserKey="txt_Text" 
                                        AutoCurrencyFormatOnKeyUp="True" EnableTextAlignRight="True" ReadOnly="True" 
                                        Width="120px">0</cc1:mytext>
                                </td>
                                <td class="style29">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr style="background-color:#E7E7FF;">
                                <td align="center" colspan="6">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="ImageSave1" runat="server" ImageUrl="~/Images/Save.jpg" />
                                            </td>
                                            <td>
                                                SAVE</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>            
        </ajaxToolkit:TabContainer>
        
    <asp:HiddenField runat="server" ID="hdfColltype"></asp:HiddenField>
    <asp:HiddenField runat="server" ID="hdfCif"></asp:HiddenField>
    <asp:SqlDataSource runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="SELECT [SubCollType_Name], [MysubColl_ID] FROM [CollType_All] WHERE ([CollType_ID] = @CollType_ID)" 
        ID="sdsSubCollType">
        <SelectParameters>
            <asp:Parameter DefaultValue="50" Name="CollType_ID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="SELECT [SubCollType_Name], [MysubColl_ID] FROM [CollType_All] WHERE ([CollType_ID] = @CollType_ID)" 
        ID="sdsSubCollType_Building">
        <SelectParameters>
            <asp:Parameter DefaultValue="70" Name="CollType_ID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="SELECT [SubCollType_Name], [MysubColl_ID] FROM [CollType_All] WHERE ([CollType_ID] = @CollType_ID)" 
        ID="sdsSubCollType_Condo">
        <SelectParameters>
            <asp:Parameter DefaultValue="18" Name="CollType_ID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="SELECT [Road_Detail_ID], [Road_Detail_Name] FROM [Road_Detail]" 
        ID="SDSRoad_Detail"></asp:SqlDataSource>
    <asp:SqlDataSource runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="SELECT [Land_State_Id], [Land_State_Name] FROM [Land_State]" 
        ID="SDSLand_State"></asp:SqlDataSource>
    <asp:SqlDataSource runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="SELECT [Road_Frontoff_ID], [Road_Frontoff_Name] FROM [Road_Frontoff]" 
        ID="SDSRoad_Forntoff"></asp:SqlDataSource>
    <asp:SqlDataSource runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="SELECT [Site_ID], [Site_Name] FROM [Site]" ID="SDSSite">
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="SELECT [Public_Utility_ID], [Public_Utility_Name] FROM [Public_Utility]" 
        ID="SDSPublic_Utility"></asp:SqlDataSource>
    <asp:SqlDataSource runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="SELECT [Binifit_ID], [Binifit_Name] FROM [Binifit]" 
        ID="SDSBinifit"></asp:SqlDataSource>
    <asp:SqlDataSource runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="SELECT [Tendency_ID], [Tendency_Name] FROM [Tendency]" 
        ID="SDSTendency"></asp:SqlDataSource>
    <asp:SqlDataSource runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="SELECT [BuySale_State_ID], [BuySale_State_Name] FROM [BuySale_State]" 
        ID="SDSBuySale_State"></asp:SqlDataSource>
    <asp:SqlDataSource runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" SelectCommand="SELECT PROV_CODE, PROV_NAME FROM Bay01.dbo.TB_PROVINCE
Order by prov_code" ID="SDSProvince"></asp:SqlDataSource>
    <asp:SqlDataSource runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="SELECT [SubUnit_Id], [SubUnit_Name] FROM [TB_SubUnit] WHERE ([SubUnit_Id] &lt;= @SubUnit_Id)" 
        ID="SDSSubUnit">
        <SelectParameters>
            <asp:Parameter DefaultValue="3" Name="SubUnit_Id" Type="Int32"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSlBuild_Character" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Build_Character_ID], [Build_Character_Name] FROM [Build_Character]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSBuild_Construct" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Build_Construct_ID], [Build_Construct_Name] FROM [Build_Construct]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSRoof" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Roof_ID], [Roof_Name] FROM [Roof]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSBuild_State" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Build_State_ID], [Build_State_Name] FROM [Build_State]">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SDSRoofStructure" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        
        
        SelectCommand="SELECT [RoofStructure_Id], [RoofStructure_Name] FROM [Roof_Structure]">
    </asp:SqlDataSource>
    
    <asp:SqlDataSource ID="SDSRoof_State" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        
        SelectCommand="SELECT [RoofState_Id], [RoofState_Name] FROM [Roof_State]">
    </asp:SqlDataSource>
    
    <asp:SqlDataSource ID="SDSInterior_State" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        
        
        SelectCommand="SELECT [InteriorState_Id], [InteriorState_Name] FROM [Interior_State]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsStandard" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="GET_STANDARD_INFO" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            
    <asp:SqlDataSource ID="SDSFloors" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Floor_Id], [Floor_Name] FROM [Floor]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSCharacter_Room" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        
        SelectCommand="SELECT [Character_Room_ID], [Character_Room_Name] FROM [Character_Room]"></asp:SqlDataSource>
                
                                <asp:TextBox ID="txt_CollType" runat="server" MyClintID="txt_CollType"></asp:TextBox>

                            </asp:Content>

