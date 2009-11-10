<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_Price3_50_Review_Edit.aspx.vb" Inherits="Appraisal_Price3_50_Review_Edit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register assembly="Mytextbox" namespace="Mytextbox" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="Js/jquery.js" type="text/javascript"></script>
<script src="Js/common.js" type="text/javascript"></script>
    <style type="text/css">
            .style26
        {
            width: 204px;
        }
            .style31
        {
            width: 338px;
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
            </style>
<script type="text/javascript">
    function CalSection_Land(sender, e) {
        //��ͧ��˹� ��Դ input type MyClintID ����� Control �ͧ���е�Ƿ����� ��Ъ��� Property  Name �ͧ Control ��� � ��͹
        //var subunit_array = [0, 400, 1, 400, 1];
        var subunit_array = [0, 1, 1, 400, 1];  //��͸Ժ�� 400 ��� 400 ���., 1 ��� 1 ���.
        var txtrai = getEleByProperty("input", "MyClintID", "txtRai");
        var txtngan = getEleByProperty("input", "MyClintID", "txtNgan");
        var txtwah = getEleByProperty("input", "MyClintID", "txtWah");
        var txtsubunit = getEleByProperty("select", "MyClintID", "ddlSubUnit");  //dropdownlist �觤����
        var txtpricewah = getEleByProperty("input", "MyClintID", "txtPriceWah");
        var txtland_Price = getEleByProperty("input", "MyClintID", "txtTotal");

        var unitdiv = subunit_array[txtsubunit.options[txtsubunit.selectedIndex].value];   //�Ҥ��������Ǩ�������Ѻ��� Array ����˹����
        //alert(unitdiv);
        var wah_rai = Number(txtrai.value) * 400;
        //alert(wah_rai);
        var wah_ngan = Number(txtngan.value) * 100;
        var wah = Number(txtwah.value);
        var totalwar = wah_rai + wah_ngan + wah;
        
        var unit_price = Number(txtpricewah.value);

        var land_price = (totalwar * unit_price) / unitdiv;

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
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <asp:HiddenField ID="hdfColl_Type" runat="server" />
    <asp:HiddenField ID="hdfAID" runat="server" />
    <br />
    <br />
    <table style="background-color: #B5C7DE;" width="100%">
        <tr>
            <td class="style26">
                ��������´�������</td>
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
            <td>
                �Ţ�ӴѺ</td>
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
            <td>
                AID</td>
            <td class="style31">
                <asp:Label ID="lblAID" runat="server" 
                    style="font-weight: 700; color: #FF0000;"></asp:Label>
            </td>
            <td>
                CID</td>
            <td class="style27">
                <asp:Label ID="lblCID" runat="server" 
                    style="font-weight: 700; color: #FF0000;"></asp:Label>
            </td>
            <td class="style29">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style26">
                �Ţ�Ӣͻ����Թ</td>
            <td class="style31">
                <asp:Label ID="lblReq_Id" runat="server" style="font-weight: 700"></asp:Label>
            </td>
            <td>
                ���� Hub</td>
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
                �����Թ����</td>
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
                ��Դ��ѡ��Сѹ</td>
            <td class="style31">
                <asp:DropDownList ID="DDLSubCollType" runat="server" 
                        DataSourceID="sdsSubCollType" DataTextField="SubCollType_Name"
                        DataValueField="MysubColl_ID">
                </asp:DropDownList>
            </td>
            <td>
                                �Ţ���⩹�</td>
            <td class="style27">
                <asp:TextBox ID="txtChanode" runat="server" Width="180px"></asp:TextBox>
            &nbsp;<asp:ImageButton ID="ImageButton_Verify" runat="server" 
                            ImageUrl="~/Images/page_accept.ico" Width="20px" Height="20px" 
                            ToolTip="����ͺ�Ţ���⩹�" />
            </td>
            <td class="style29">
                &nbsp;</td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="style26">
                ���ҧ</td>
            <td class="style31">
                <asp:TextBox ID="txtRaWang" runat="server" BackColor="#FFFF66" MaxLength="50"></asp:TextBox>
            </td>
            <td>
                                �Ţ���Թ</td>
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
                ˹�����Ǩ</td>
            <td class="style31">
                <asp:TextBox ID="txtSurway" runat="server" BackColor="#FFFF66"></asp:TextBox>
            </td>
            <td>
                                ��úѭ�������</td>
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
                ˹��</td>
            <td class="style31">
                <asp:TextBox ID="txtPage" runat="server" BackColor="#FFFF66"></asp:TextBox>
            </td>
            <td>
                    �Ӻ�/�ǧ</td>
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
                    �����/ࢵ</td>
            <td class="style31">
                <asp:TextBox ID="txtAmphur" runat="server" Width="222px"></asp:TextBox>
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
                    ���ͷ��
                </td>
            <td class="style31">
                <cc1:mytext ID="txtRai" runat="server" AllowUserKey="int_Integer"
                        EnableTextAlignRight="True" Width="50px" MyClintID="txtRai"
                        onkeyup="CalSection_Land(this,event);" >0</cc1:mytext>
                    &nbsp;���
                    <cc1:mytext ID="txtNgan" runat="server" AllowUserKey="int_Integer" EnableTextAlignRight="True"
                        MaxLength="1" Width="50px" MyClintID="txtNgan"
                        onkeyup="CalSection_Land(this,event);" >0</cc1:mytext>
                    &nbsp;�ҹ
                   <cc1:mytext ID="txtWah" runat="server" AllowUserKey="num_Numeric" EnableTextAlignRight="True"
                        MaxLength="5" Width="50px" MyClintID="txtWah"
                        onkeyup="CalSection_Land(this,event);" >0</cc1:mytext>
                    &nbsp;���.</td>
            <td class="style5">
                                ����͡����Է�����Թ</td>
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
                ���м١�ѹ</td>
            <td class="style31">
                <asp:TextBox ID="txtObligation" runat="server" Width="222px" 
                    BackColor="#FFFF66"></asp:TextBox>
            </td>
            <td>
                                        �������ѡ��Сѹ ������趹�</td>
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
                    ��õ������ͧ��ѡ��Сѹ</td>
            <td class="style31">
                <asp:DropDownList ID="ddlRoad_Detail" runat="server" 
                        DataSourceID="SDSRoad_Detail" DataTextField="Road_Detail_Name" 
                        DataValueField="Road_Detail_ID">
                </asp:DropDownList>
                <cc1:mytext ID="txtMeter" runat="server" AllowUserKey="num_Numeric" EnableTextAlignRight="True"
                        MaxLength="6" Width="50px">0</cc1:mytext>
                    ����</td>
            <td class="style5">
                    ���� ��� (�����)</td>
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
                    ʶҾ���Թ
                </td>
            <td class="style31">
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
                    ���˹����ѡ��Сѹ
                </td>
            <td class="style23">
                <asp:DropDownList ID="ddlRoad_Forntoff" runat="server" 
                        DataSourceID="SDSRoad_Forntoff" DataTextField="Road_Frontoff_Name" 
                        DataValueField="Road_Frontoff_ID">
                </asp:DropDownList>
            </td>
            <td class="style19">
                    ��Ǩ�Ҩá��ҧ</td>
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
            <td class="style17">
                    ��Ҵ���Թ���ҧ�Դ���</td>
            <td class="style23">
                <cc1:mytext id="txtLand_Closeto_RoadWidth" runat="server" 
                    AllowUserKey="num_Numeric" MaxLength="5"
                        Width="50px" EnableTextAlignRight="True" BackColor="#FFFF66">0</cc1:mytext>
                    &nbsp;����
                    ���Թ�֡(����/���)
                <cc1:mytext id="txtDeepWidth" runat="server" AllowUserKey="txt_Text" MaxLength="10"
                        Width="50px" EnableTextAlignRight="True" BackColor="#FFFF66">0</cc1:mytext>
                    &nbsp;����</td>
            <td class="style19">
                    Է��Թ��ҹ��ѧ���ҧ</td>
            <td class="style28">
                <cc1:mytext id="txtBehindWidth" runat="server" AllowUserKey="num_Numeric" MaxLength="5"
                        Width="50px" EnableTextAlignRight="True" BackColor="#FFFF66">0</cc1:mytext>
                    &nbsp;����</td>
            <td class="style30">
            </td>
            <td class="style20">
            </td>
        </tr>        
        <tr>
            <td class="style26">
                    ����
                </td>
            <td class="style31">
                <asp:DropDownList ID="ddlSite" runat="server" DataSourceID="SDSSite" 
                        DataTextField="Site_Name" DataValueField="Site_ID">
                </asp:DropDownList>
            </td>
            <td class="style5">
                    ��������´����
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
                    �Ҹ�óٻ���
                </td>
            <td class="style31">
                <asp:DropDownList ID="ddlPublic_Utility" runat="server" 
                        DataSourceID="SDSPublic_Utility" DataTextField="Public_Utility_Name" 
                        DataValueField="Public_Utility_ID">
                </asp:DropDownList>
            </td>
            <td class="style5">
                    ��������´�Ҹ�óٻ���
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
                    ��������ª��㹷��Թ
                </td>
            <td class="style31">
                <asp:DropDownList ID="ddlBinifit" runat="server" DataSourceID="SDSBinifit" 
                        DataTextField="Binifit_Name" DataValueField="Binifit_ID">
                </asp:DropDownList>
            </td>
            <td class="style5">
                    �ѡɳ��ٻ���Թ
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
                    �����������ԭ
                </td>
            <td class="style31">
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
                    �Ҥҵ��˹���</td>
            <td class="style31">
                <asp:DropDownList ID="ddlSubUnit" runat="server" DataSourceID="SDSSubUnit" 
                        DataTextField="SubUnit_Name" DataValueField="SubUnit_Id" MyClintID="ddlSubUnit" onkeyup="CalSection_Land(this,event);">
                </asp:DropDownList>
            &nbsp;<cc1:mytext id="txtPriceWah" runat="server" allowuserkey="num_Numeric" 
                    width="120px" EnableTextAlignRight="True" MyClintID="txtPriceWah"
                    onkeyup="CalSection_Land(this,event);" >0</cc1:mytext>
            &nbsp;�ҷ</td>
            <td class="style5">
                    ���Թ</td>
            <td class="style27">
                <cc1:mytext ID="txtTotal" runat="server" AllowUserKey="num_Numeric" Width="120px"
                        AutoCurrencyFormatOnKeyUp="True" EnableTextAlignRight="True" 
                    ReadOnly="True" MyClintID="txtTotal">0</cc1:mytext>
            &nbsp;�ҷ</td>
            <td class="style29">
                    &nbsp;
                </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                ���Թ�����ࢵ��鹷����</td>
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
                            <asp:Label ID="lblSave" runat="server" style="font-weight: 700" Text="SAVE"></asp:Label>
&nbsp;</td>
                        <td>
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Cancel1.jpg" Width="35px" Height="35px" />
                        </td>
                        <td>
                            <asp:Label ID="lblCLOSE" runat="server" style="font-weight: 700" Text="CLOSE"></asp:Label>
&nbsp;</td>                        
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
            <asp:Parameter DefaultValue="2" Name="SubUnit_Id" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
        
    </asp:Content>

