<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Appraisal_Price3_Conform.aspx.vb" Inherits="Appraisal_Price3_Conform" UICulture="th-TH" Culture="th-TH" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="Mytextbox" Namespace="Mytextbox" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="CSS/print.css" rel="stylesheet" type="text/css" media="print" />
    <style type="text/css" media="print">
        .style1
        {
            width: 205px;
        }
        .style2
        {
            width: 472px;
        }
        .style3
        {
            width: 259px;
        }
        .style4
        {
            width: 164px;
        }
        .style5
        {
            width: 97px;
        }
        .style6
        {
            width: 144px;
        }
        .style7
        {
            width: 153px;
        }
        .style8
        {
            width: 57px;
        }
        .style9
        {
            width: 230px;
        }
        .style10
        {
            width: 215px;
        }
        .style13
        {
            width: 141px;
        }
        .style16
        {
            width: 239px;
        }
        .style17
        {
            width: 374px;
        }
        .NotshowOnPrint
        {
            display:none;
        }
        .DonotDisplay
        { 
            display:none;
        }
    </style>
    <style type="text/css">
        .style1
        {
            width: 39px;
        }
        .style2
        {
            width: 473px;
        }
        .style3
        {
            width: 62px;
        }
        .style4
        {
            width: 75px;
        }
        .style5
        {
            width: 120px;
        }
        .style6
        {
            width: 84px;
        }
        .style7
        {
            width: 89px;
        }
        .style8
        {
            width: 92px;
        }
        .style9
        {
            width: 206px;
        }
        .style11
        {
            width: 319px;
        }
        .style12
        {
            width: 204px;
        }
        .style13
        {
            width: 135px;
        }
        .style14
        {
            width: 159px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" 
        EnableScriptGlobalization="True">
    </asp:ScriptManager>   
<asp:Panel ID="Panel1" runat="server">
    <br />
    <br />
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="���¹"></asp:Label>
            </td>
            <td class="txtDoPrint">
                <asp:TextBox ID="txtInform_To" runat="server" Width="350px"></asp:TextBox>
            </td>
            <td>AID</td>
            <td>
                <asp:TextBox ID="txtAID" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td class="style17">
                <asp:Label ID="Label3" runat="server" Text="�����Թ����"></asp:Label>
            </td>
            <td class="style14">
                <span style="color: Red">
                    <asp:Label ID="lblCifName" runat="server"></asp:Label></span>&#160;
            </td>
            <td class="style13">
                <asp:Label ID="Label2" runat="server" Text="Cif"></asp:Label>
                &nbsp;<asp:TextBox ID="txtCif" runat="server" Width="100px"></asp:TextBox>
            </td>
            <td class="style9">
                <asp:Label ID="Label4" runat="server" Text="�ѹ����Ѻ����ͧ"></asp:Label>
                <span style="color: Red">
                <asp:TextBox ID="txtReceive_Date" runat="server" Width="100px"></asp:TextBox><ajaxToolkit:CalendarExtender
                    ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtReceive_Date">
                </ajaxToolkit:CalendarExtender>
                *</span></td>
            <td class="style12">

                <asp:Label ID="Label79" runat="server" Text="�ѹ�������Թ"></asp:Label>

                </td>
            <td>
                <asp:TextBox ID="txtAppraisal_Date" runat="server" Width="100px"></asp:TextBox>
                <ajaxToolkit:CalendarExtender
                    ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtAppraisal_Date">
                </ajaxToolkit:CalendarExtender>
                <span style="color: Red">*</span>
            </td>
        </tr>
        <tr>
            <td class="style17">
    <asp:Label ID="Label80" runat="server" Text="�Ң�/���§ҹ"></asp:Label>
    
            </td>
            <td class="style14">
                <asp:DropDownList ID="ddlBranch" runat="server" DataSourceID="sdsBranch" 
                    DataTextField="BRANCH_T" DataValueField="ID_BRANCH" style="margin-left: 0px">
                </asp:DropDownList>
            </td>
            <td class="style13">
                &nbsp;</td>
            <td class="style9">
                <table class="NotshowOnPrint">
                    <tr>
                        <td>
                            <asp:Button ID="btnEditPosition" runat="server" Text="��䢾ԡѴ" />
                        </td>
                    </tr>
                </table>
            </td>
            <td class="style12">

                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style17">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="��ѡ��Сѹ���Թ"></asp:Label>
            </td>
            <td class="style14">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style17" colspan="6">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblDetail1" runat="server" Width="1100px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17" colspan="6">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblDetail2" runat="server" Width="1100px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17" colspan="6">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblDetail3" runat="server" Width="1100px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17" colspan="6">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblDetail4" runat="server" Width="1100px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17" colspan="6">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblDetail5" runat="server" Width="1100px"></asp:Label>
            </td>
        </tr>
       <tr>
            <td class="style17">
                <asp:Label ID="Label6" runat="server" Text="⩹����Թ �Ţ���"></asp:Label>
            </td>
            <td class="style14">
                <asp:Label ID="lblChanode_No" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style13">
                <asp:Label ID="Label7" runat="server" Text="���ҧ"></asp:Label>
            </td>
            <td class="style9">
                <asp:Label ID="lblRaWang" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style12">
                <asp:Label ID="Label8" runat="server" Text="�Ţ���Թ"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblLandNumber" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17">
                <asp:Label ID="Label9" runat="server" Text="˹�����Ǩ"></asp:Label>
            </td>
            <td class="style14">
                <asp:Label ID="lblSurway" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style13">
                <asp:Label ID="Label10" runat="server" Text="��úѭ�������"></asp:Label>
            </td>
            <td class="style9">
                <asp:Label ID="lblDocNo" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style12">
                <asp:Label ID="Label11" runat="server" Text="˹��"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblPage" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17">
                <asp:Label ID="Label12" runat="server" Text="�Ӻ�"></asp:Label>
            </td>
            <td class="style14">
                <asp:Label ID="lblTumbon" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style13">
                <asp:Label ID="Label13" runat="server" Text="�����"></asp:Label>
            </td>
            <td class="style9">
                <asp:Label ID="lblAmphur" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style12">
                <asp:Label ID="Label14" runat="server" Text="�ѧ��Ѵ"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblProvince" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17">
                <asp:Label ID="Label16" runat="server" Text="���ͷ��ӹǹ���"></asp:Label>
            </td>
            <td class="style14">
                <asp:Label ID="lblRai" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style13">
                <asp:Label ID="Label17" runat="server" Text="�ӹǹ�ҹ"></asp:Label>
            </td>
            <td class="style9">
                <asp:Label ID="lblNgan" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style12">
                <asp:Label ID="Label18" runat="server" Text="�ӹǹ���ҧ��"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblWah" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17">
                <asp:Label ID="Label19" runat="server" Text="����͡����Է�����Թ"></asp:Label>
            </td>
            <td class="style14">
                <asp:Label ID="lblLandOwnerShip" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style13">
                <asp:Label ID="Label20" runat="server" Text="��觻�١���ҧ�ͧ"></asp:Label>
            </td>
            <td class="style9">
                <asp:Label ID="lbBuildinObligation" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style12">
                <asp:Label ID="Label21" runat="server" Text="���м١�ѹ"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblObligation" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17">
                <asp:Label ID="Label22" runat="server" Text="����������Ҿ���Թ" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17" colspan="6">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; <asp:Label ID="lblLandDetail1" runat="server" Width="1100px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17" colspan="6">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblLandDetail2" runat="server" Width="1100px"></asp:Label>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style17" colspan="6">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblLandDetail3" runat="server" Width="1100px"></asp:Label>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style17" colspan="6">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblLandDetail4" runat="server" Width="1100px"></asp:Label>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style17" colspan="6">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblLandDetail5" runat="server" Width="1100px"></asp:Label>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style17" colspan="6">
                <asp:Label ID="lblLandDetail6" runat="server" Width="1100px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17" colspan="6">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblLandDetail7" runat="server" Width="1100px"></asp:Label>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style17" colspan="6">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblLandDetail8" runat="server" Width="1100px"></asp:Label>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style17" colspan="6">
                <asp:Label ID="lblLandDetail9" runat="server" Width="1100px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17">
                <asp:Label ID="Label15" runat="server" Text="��������趹�"></asp:Label>
            </td>
            <td class="style14">
                <asp:Label ID="lblRoad" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style13">
                ��õ������</td>
            <td class="style9">
                <asp:Label ID="lblRoadAccess_Detail" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style12">
                <asp:Label ID="Label24" runat="server" Text="���л���ҳ"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblMeter_Access" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17">
                <asp:Label ID="Label25" runat="server" Text="���˹����ѡ��Сѹ"></asp:Label>
            </td>
            <td class="style14">
                <asp:Label ID="lblRoad_Forntoff" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style13">
                <asp:Label ID="Label26" runat="server" Text="���ҧ"></asp:Label>
            </td>
            <td class="style9">
                <asp:Label ID="lblRoad_Forntoff_Width" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style12">
            </td>
            <td>
                <asp:Label ID="Label27" runat="server" Text="(��������´���Ἱ����ѧࢻ)"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17">
                <asp:Label ID="Label28" runat="server" Text="��Ҿ�ѡɳз��Թ"></asp:Label>
            </td>
            <td class="style14">
                <asp:CheckBox ID="ChkLandState1" runat="server" Text="�����������׹���" />
            </td>
            <td class="style13">
                <asp:Label ID="Label29" runat="server" Text="��� �"></asp:Label>
            </td>
            <td class="style9">
                <asp:Label ID="lblLandStateDetail" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style12">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="style17">
                <asp:Label ID="Label30" runat="server" Text="��Ҵ���Թ  ���ҧ�Դ���"></asp:Label>
            </td>
            <td class="style14">
                <asp:Label ID="lblRoadWidth" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style13">
                <asp:Label ID="Label31" runat="server" Text="�֡"></asp:Label>
            </td>
            <td class="style9">
                <asp:Label ID="lblDeepWidth" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style12">
                <asp:Label ID="Label32" runat="server" Text="��ҹ��ѧ"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblBehindWidth" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17">
            </td>
            <td class="style14">
            </td>
            <td class="style13">
                <asp:Label ID="Label33" runat="server" Text="��� �"></asp:Label>
            </td>
            <td class="style9">
                &nbsp;</td>
            <td class="style12">
                <asp:Label ID="Label68" runat="server" Text="����"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblSiteName" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17">
                <asp:Label ID="Label34" runat="server" 
                    Text="��Ҿ��С�û�Ѻ��ا���Թ�ͧ���Թ�Ѻ���"></asp:Label>
            </td>
            <td class="style14">
                        <asp:Label ID="lblLandState" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style13">
                <asp:Label ID="Label35" runat="server" Text="��������´���Թ"></asp:Label>
            </td>
            <td class="style9">
                <asp:Label ID="lblLandState_Detail" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style12">
                <asp:Label ID="Label36" runat="server" Text="��� �"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtLandDetail_Other" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style17">
                <asp:Label ID="Label37" runat="server" Text="�ѧ���ͧ���"></asp:Label>
                &nbsp;<asp:Label ID="Label38" runat="server" Text="���Թ�����ࢵ��鹷����"></asp:Label>
            </td>
            <td colspan="4">
                <asp:Label ID="lblArea_Colour" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="style17">
                <asp:Label ID="Label39" runat="server" Text="�Ҹ�óٻ���"></asp:Label>
            </td>
            <td class="style14">
                <asp:Label ID="lblPublic_Utility" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style13">
                <asp:Label ID="Label40" runat="server" Text="����������ԭ"></asp:Label>
            </td>
            <td class="style9">
                <asp:Label ID="lblTendency_Name" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style12">
                <asp:Label ID="Label41" runat="server" Text="��Ҿ���ͧ��ë���-���"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblBuySale_StateName" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style17">
                <asp:Label ID="Label42" runat="server" Font-Bold="True" Text="��觻�١���ҧ"></asp:Label>
                &nbsp;<asp:Label ID="Label43" runat="server" Text="��ҹ�Ţ���"></asp:Label>
            </td>
            <td class="style14">
                <asp:Label ID="lblBuilding_No" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style13">
                <asp:Label ID="Label44" runat="server" Text="�ӹǹ��ѧ"></asp:Label>
            </td>
            <td class="style9">
                <asp:Label ID="lblItem" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style12">
                <asp:Label ID="Label45" runat="server" Text="(��������´����͡��� Ṻ)"></asp:Label>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label46" runat="server" Font-Bold="True" Text="�����Ǵ�����Ѻ�š�з�"></asp:Label>&#160;<asp:Label
                    ID="Label47" runat="server" Text="(��õ�Ǩ�ͺ�ѭ�������Ǵ���������§��ҷ������ö��Ǩ�ͺ�� � �ѹ���Ǩ)"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlProblem" runat="server" BackColor="#FFFF66" 
                    DataSourceID="sdsProblem" DataTextField="Problem_Name" 
                    DataValueField="Problem_Id">
                </asp:DropDownList>
                &#160;<asp:Label
                    ID="Label49" runat="server" Text="(�����͸Ժ���������) "></asp:Label>
                      <asp:TextBox  ID="txtProblem_Detail" runat="server" Width="450px" 
                    BackColor="#FFFF66"></asp:TextBox>                  
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label50" runat="server" Font-Bold="True" Text="��û����Թ�Ҥ�"></asp:Label>&#160;<asp:Label
                    ID="Label51" runat="server" Text="�����š�ë��͢��"></asp:Label><br />
                <asp:TextBox ID="txtBuy_Sale_Comment" runat="server" Height="80px" TextMode="MultiLine"
                    Width="800px" BackColor="#FFFF66"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td class="style11">
                <asp:Label ID="Label52" runat="server" Font-Bold="True" Text="�Ըա�û����Թ�Ҥ�"></asp:Label>
            </td>
            <td class="style3">
                <asp:DropDownList ID="ddlAppraisal_Type" runat="server" CssClass="txtDoPrint" 
                    DataSourceID="SDSAppraisal_Type" DataTextField="App_Type_Name" 
                    DataValueField="App_Type_ID" BackColor="#FFFF66" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td class="style5">
            </td>
            <td class="style6">
                &nbsp;</td>
            <td class="style7">
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="lblCollName" runat="server"></asp:Label>
                &nbsp;<asp:Label ID="Label53" runat="server" Text=" ���ͷ��"></asp:Label>
            </td>
            <td class="style3">
                <asp:Label ID="lblSize" runat="server" Style="color: #FF0000" Width="100px"></asp:Label>
            </td>
            <td class="style5">
                <asp:Label ID="lblSubUnit" runat="server" Width="110px"></asp:Label>&nbsp;
            </td>
            <td class="style6">
                <asp:Label ID="lblPriceWah" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style7">
                <asp:Label ID="Label55" runat="server" Text="���Թ"></asp:Label>
            </td>
            <td>
                                  <cc1:mytext ID="txtLandTotal" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" Width="120px" BackColor="#FFFF66" AutoPostBack="True" 
                                      AutoCurrencyFormatOnKeyUp="True">0.00</cc1:mytext>
            </td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="Label56" runat="server" Text="��觻�١���ҧ"></asp:Label>
            </td>
            <td class="style3">
                <asp:Label ID="lblBuilding_Detail" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style5">
            </td>
            <td class="style6">
                <asp:Label ID="lblTotal2" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style7">
                <asp:Label ID="Label57" runat="server" Text="���Թ"></asp:Label>
            </td>
            <td>
                                  <cc1:mytext ID="txtBuildingPrice" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" Width="120px" BackColor="#FFFF66" AutoPostBack="True" 
                                      AutoCurrencyFormatOnKeyUp="True">0.00</cc1:mytext>
            </td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="Label48" runat="server" Text="���Թ�������觻�١���ҧ"></asp:Label>
            </td>
            <td class="style3">
                <asp:Label ID="lblLand_Build" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style5">
            </td>
            <td class="style6">
                <asp:Label ID="lblTotal3" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style7">
                <asp:Label ID="Label60" runat="server" Text="���Թ"></asp:Label>
            </td>
            <td>
                                  <cc1:mytext ID="txtSubTotal" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" Width="120px" BackColor="#FFFF66" AutoPostBack="True" 
                                      AutoCurrencyFormatOnKeyUp="True">0.00</cc1:mytext>
            </td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td class="style7">
                <asp:Label ID="Label81" runat="server" Text="������Թ"></asp:Label>
            </td>
            <td>
                <cc1:mytext ID="txtGrandTotal" runat="server" AllowUserKey="num_Numeric" 
                    AutoCurrencyFormatOnKeyUp="True" AutoPostBack="True" BackColor="#FFFF66" 
                    EnableTextAlignRight="True" Width="120px">0.00</cc1:mytext>
            </td>
        </tr>
        <tr>
            <td class="style11">
            </td>
            <td class="style3">
            </td>
            <td class="style5">
            </td>
            <td class="style6">
                &nbsp;</td>
            <td class="style7">
                &nbsp;</td>
            <td>
                <asp:Label ID="lblThaiBaht" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label61" runat="server" Text="COMMENT"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlComment" runat="server" DataSourceID="SDSComment" 
                    DataTextField="Comment_Name" DataValueField="Comment_ID" 
                    BackColor="#FFFF66">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label62" runat="server" Text="WARNING"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlWarning" runat="server" DataSourceID="SDSWarning" 
                    DataTextField="Warning_Name" DataValueField="Warning_ID" 
                    BackColor="#FFFF66">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td valign="top">
                <asp:TextBox ID="txtWarning_Detail" runat="server" Height="50px" TextMode="MultiLine"
                    Width="400px" BackColor="#FFFF66"></asp:TextBox>
            </td>
            <td align="right">
                <table class="style2" width="100%">
                    <tr>
                        <td class="style8">
                            &#160;&#160;
                        </td>
                        <td class="style4">
                            &#160;&#160;
                        </td>
                        <td>
                            &#160;&#160;
                        </td>
                    </tr>
                    <tr>
                        <td class="style8">
                            <asp:Label ID="Label63" runat="server" Text="ŧ����"></asp:Label>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td>
                            <asp:Label ID="Label65" runat="server" Text="����Ǩ�ͺ�����Թ�Ҥ�"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style8">
                            &#160;&#160;
                        </td>
                        <td class="style4">
                            &#160;&#160;
                        </td>
                        <td>
                            &#160;&#160;
                        </td>
                    </tr>
                    <tr>
                        <td class="style8">
                            &#160;&#160;
                        </td>
                        <td class="style4" align="center">
                    <asp:DropDownList ID="ddlUserAppraisal" runat="server" DataSourceID="SDSUserAppraisal"
                        DataTextField="UserAppraisal" DataValueField="Emp_id" Width="200px">
                    </asp:DropDownList>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td class="style8">
                            &#160;&#160;
                        </td>
                        <td class="style4">
                            <asp:Label ID="Label59" runat="server" 
                                Text="..............................................."></asp:Label>
                        </td>
                        <td>
                            &#160;&#160;<asp:Label ID="Label67" runat="server" Text="�ѹ / ��͹ / ��"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="Label69" runat="server" Text="������繤��͹ء����Ԩ�óҡ�û����Թ��Ť���Թ��Ѿ������"
                    Style="font-weight: 700"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="Label70" runat="server" Text="1.)"></asp:Label>
                        </td>
                        <td>
                            &#160;&#160;
                        </td>
                        <td>
                            <asp:Label ID="Label71" runat="server" Text="2.)"></asp:Label>
                        </td>
                        <td>
                            &#160;&#160;
                        </td>
                        <td>
                            <asp:Label ID="Label72" runat="server" Text="3.)"></asp:Label>
                        </td>
                        <td>
                            &#160;&#160;
                            </td>
                    </tr>
                    <tr>
                        <td>
                        
                        </td>
                        <td>
                        
                        </td>
                        <td>
                        
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>

                        </td>
                    </tr>                    
                    <tr>
                        <td>
                            &#160;&#160;
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &#160;&#160;
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &#160;&#160;
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &#160;&#160;
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlApprove1" runat="server" BackColor="#FFFF66" 
                                DataSourceID="sdsSubCommittee" DataTextField="SubCommittee_Name" 
                                DataValueField="SubCommittee_ID">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &#160;&#160;
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlApprove2" runat="server" BackColor="#FFFF66" 
                                DataSourceID="sdsSubCommittee" DataTextField="SubCommittee_Name" 
                                DataValueField="SubCommittee_ID">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &#160;&#160;
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlApprove3" runat="server" BackColor="#FFFF66" 
                                DataSourceID="sdsSubCommittee" DataTextField="SubCommittee_Name" 
                                DataValueField="SubCommittee_ID">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &#160;&#160;
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlPos_Approve1" runat="server" BackColor="#FFFF66" 
                                DataSourceID="sdsPosition_Approve" DataTextField="Position_Name" 
                                DataValueField="Position_Id">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &#160;&#160;
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlPos_Approve2" runat="server" BackColor="#FFFF66" 
                                DataSourceID="sdsPosition_Approve" DataTextField="Position_Name" 
                                DataValueField="Position_Id">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &#160;&#160;
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlPos_Approve3" runat="server" BackColor="#FFFF66" 
                                DataSourceID="sdsPosition_Approve" DataTextField="Position_Name" 
                                DataValueField="Position_Id">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        
                        </td>
                        <td>
                        
                        </td>
                        <td>
                        
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>

                        </td>
                    </tr>
                    <tr>
                        <td colspan="6"  align="center">
                        
                <table class="NotshowOnPrint">
                    <tr>
                        <td>
                            <asp:ImageButton ID="ImageSave" runat="server" ImageUrl="~/Images/Save.jpg" Width="35px" Height="35px"/>
                        </td>
                        <td class="style1">
                            <asp:Label ID="lblSave" runat="server" Text="SAVE"></asp:Label>
                        </td>
                        <td>
                                    <asp:ImageButton ID="ImagePrint" runat="server" ImageUrl="~/Images/Printer.png" Width="35px" Height="35px" />
                                                        
                        </td>
                    </tr>
               </table>
                        
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:SqlDataSource ID="SDSWarning" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Warning_ID], [Warning_Name] FROM [Warning]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSComment" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Comment_ID], [Comment_Name] FROM [Comment]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSAppraisal_Type" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [App_Type_ID], [App_Type_Name] FROM [Appraisal_Type]">
    </asp:SqlDataSource>
    
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <asp:HiddenField ID="HiddenField3" runat="server" />   
    
    <asp:SqlDataSource ID="sdsBranch" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="GET_BRANCH" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    
    <asp:SqlDataSource ID="SDSUserAppraisal" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT Emp_id, Title + Name + '  ' + Lastname AS UserAppraisal FROM Tb_UserAppraisal">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsSubCommittee" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="SELECT [SubCommittee_ID], [SubCommittee_Name] FROM [TB_SubCommittee] ORDER BY [SubCommittee_Name]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsProblem" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="SELECT [Problem_Id], [Problem_Name] FROM [TB_Problem]">
    </asp:SqlDataSource>
</asp:Panel>

        
</asp:Content>
