<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_Price2_Add_By_Colltype.aspx.vb" Inherits="Appraisal_Price2_Add_By_Colltype" %>


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
    function CalSection_Land(sender, e) {
        //��ͧ��˹� ��Դ input type MyClintID ����� Control �ͧ���е�Ƿ����� ��Ъ��� Property  Name �ͧ Control ��� � ��͹
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

        //���ʴ��š�Ѻ���Ѻ Textbox �������˹�� Design
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
</script>           
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
<br />
    <asp:HiddenField ID="hdfColltype" runat="server" />
    <asp:HiddenField ID="hdfCif" runat="server" />
    <table style="background-color: #B5C7DE;" width="100%">
        <tr>
            <td class="style26">
                �Ţ�ӴѺ</td>
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
                �Ţ�Ӣͻ����Թ</td>
            <td>
                <asp:Label ID="lblReq_Id" runat="server" style="font-weight: 700"></asp:Label>
            </td>
            <td>
                ���� Hub</td>
            <td class="style27">
                <asp:Label ID="lblHub_Id" runat="server" style="font-weight: 700"></asp:Label>
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
                        ToolTip="����"/>
            </td>
            <td class="style29">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style26">
                ��Դ��ѡ��Сѹ</td>
            <td>
                <asp:DropDownList ID="DDLSubCollType" runat="server" 
                        DataSourceID="sdsSubCollType" DataTextField="SubCollType_Name"
                        DataValueField="MysubColl_ID">
                </asp:DropDownList>
            </td>
            <td>
                ��Сͺ�����Ţ���</td>
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
                    ���ͷ��
                </td>
            <td class="style22">

                    <cc1:mytext ID="txtRai" runat="server" AllowUserKey="int_Integer"
                        EnableTextAlignRight="True" Width="50px"
                        MyClintID="txtRai"
                        onkeyup="CalSection_Land(this,event);" >0</cc1:mytext>
                    &nbsp;���
                    <cc1:mytext ID="txtNgan" runat="server" AllowUserKey="int_Integer" EnableTextAlignRight="True"
                        MaxLength="1" Width="50px"
                        MyClintID="txtNgan"
                        onkeyup="CalSection_Land(this,event);" >0</cc1:mytext>
                    &nbsp;�ҹ
                   <cc1:mytext ID="txtWah" runat="server" AllowUserKey="num_Numeric" EnableTextAlignRight="True"
                        MaxLength="4" Width="50px"
                        MyClintID="txtWah"
                        onkeyup="CalSection_Land(this,event);" >0</cc1:mytext>
                    &nbsp;���.</td>
            <td class="style5">
                                        �������ѡ��Сѹ ������趹�</td>
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
                    �������
                </td>
            <td class="style22">
                <asp:DropDownList ID="ddlRoad_Detail" runat="server" 
                        DataSourceID="SDSRoad_Detail" DataTextField="Road_Detail_Name" 
                        DataValueField="Road_Detail_ID">
                </asp:DropDownList>
                   <cc1:mytext ID="txtMeter" runat="server" AllowUserKey="int_Integer" EnableTextAlignRight="True"
                        MaxLength="4" Width="50px">0</cc1:mytext>
                    ����</td>
            <td class="style5">
                    �Ӻ�/�ǧ</td>
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
                    �����/ࢵ</td>
            <td class="style22">
                <asp:TextBox ID="txtAmphur" runat="server"></asp:TextBox>
            </td>
            <td class="style5">
                    �ѧ��Ѵ</td>
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
                    ʶҾ���Թ
                </td>
            <td class="style22">
                <asp:DropDownList ID="ddlLand_State" runat="server" 
                        DataSourceID="SDSLand_State" DataTextField="Land_State_Name" 
                        DataValueField="Land_State_Id">
                </asp:DropDownList>
            </td>
            <td class="style5">
                    ��������´��Ҿ���Թ
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
                    ���˹����ѡ��Сѹ��</td>
            <td class="style23">
                <asp:DropDownList ID="ddlRoad_Forntoff" runat="server" 
                        DataSourceID="SDSRoad_Forntoff" DataTextField="Road_Frontoff_Name" 
                        DataValueField="Road_Frontoff_ID">
                </asp:DropDownList>
            </td>
            <td class="style19">
                    ��Ǩ�Ҩá��ҧ
                </td>
            <td class="style28">
                <cc1:mytext id="txtRoadWidth" runat="server" AllowUserKey="num_Numeric" MaxLength="5"
                        Width="50px" EnableTextAlignRight="True">0</cc1:mytext>
                    &nbsp;����
                </td>
            <td class="style30">
            </td>
            <td class="style20">
            </td>
        </tr>
        <tr>
            <td class="style26">
                    ����
                </td>
            <td class="style22">
                <asp:DropDownList ID="ddlSite" runat="server" DataSourceID="SDSSite" 
                        DataTextField="Site_Name" DataValueField="Site_ID">
                </asp:DropDownList>
            </td>
            <td class="style5">
                    ��������´����
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
                    �Ҹ�óٻ���
                </td>
            <td class="style22">
                <asp:DropDownList ID="ddlPublic_Utility" runat="server" 
                        DataSourceID="SDSPublic_Utility" DataTextField="Public_Utility_Name" 
                        DataValueField="Public_Utility_ID">
                </asp:DropDownList>
            </td>
            <td class="style5">
                    ��������´�Ҹ�óٻ���
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
                    ��������ª��㹷��Թ
                </td>
            <td class="style22">
                <asp:DropDownList ID="ddlBinifit" runat="server" DataSourceID="SDSBinifit" 
                        DataTextField="Binifit_Name" DataValueField="Binifit_ID">
                </asp:DropDownList>
            </td>
            <td class="style5">
                    �ѡɳ��ٻ���Թ</td>
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
                    �����������ԭ
                </td>
            <td class="style22">
                <asp:DropDownList ID="ddlTendency" runat="server" DataSourceID="SDSTendency" 
                        DataTextField="Tendency_Name" DataValueField="Tendency_ID">
                </asp:DropDownList>
            </td>
            <td class="style5">
                    ��Ҿ���ͧ��ë��͢��
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
                    ���. ��</td>
            <td class="style22">
                <cc1:mytext id="txtPriceWah" runat="server" allowuserkey="num_Numeric" 
                    width="120px" EnableTextAlignRight="True"
                    MyClintID="txtPriceWah"
                    onkeyup="CalSection_Land(this,event);" >0</cc1:mytext>
            </td>
            <td class="style5">
                    ���Թ</td>
            <td class="style27">
                <cc1:mytext ID="txtTotal" runat="server" AllowUserKey="num_Numeric" Width="120px"
                        AutoCurrencyFormatOnKeyUp="True" EnableTextAlignRight="True"
                        MyClintID="txtTotal">0</cc1:mytext>
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
Order by prov_code">
    </asp:SqlDataSource>
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    
</asp:Content>

