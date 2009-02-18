<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_Price3_Form_Review.aspx.vb" Inherits="Appraisal_Price3_Form_Review" UICulture="th-TH" Culture="th-TH" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .bgTable
        {
            background-color:#FFFFCC;
            text-align:center;
        }
        .style4
        {
            width: 97px;
        }
        .style3
        {
            height: 22px;
        }
        .style5
        {
        }
        .style6
        {
        }
        .style7
        {
            width: 107px;
        }
        .style8
        {
            width: 252px;
        }
        .style9
        {
            width: 86px;
        }
        .style10
        {
            height: 22px;
            width: 179px;
        }
        .style11
        {
            height: 124px;
        }
        .style12
        {
        }
        .style13
        {
        }
        .style14
        {
            width: 264px;
        }
        .style15
        {
            width: 176px;
        }
        .style16
        {
            width: 226px;
        }
        .style17
        {
            width: 252px;
            height: 49px;
        }
        .style18
        {
            height: 49px;
        }
    </style>
        <link href="CSS/print.css" rel="stylesheet" type="text/css" media="print"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" 
        EnableScriptGlobalization="True">
    </asp:ScriptManager>
    <asp:HiddenField ID="hdfReq_Id" runat="server" />
    <asp:HiddenField ID="hdfHub_Id" runat="server" />
    <asp:HiddenField ID="hdfAID" runat="server" />
<br />
<br />

<%--<h5 style="text-align:center;">��Ҥ�á�ا�����ظ�� �ӡѴ (��Ҫ�)</h5>
<h5 style="text-align:center;">��§ҹ���ǹ��û����Թ�Ҥ���ѡ��Сѹ</h5>--%><asp:UpdatePanel 
        ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="text-align:center;">
                <asp:Label ID="Label1" runat="server" Text="��Ҥ�á�ا�����ظ�� �ӡѴ (��Ҫ�)" 
        style="font-weight: 700"></asp:Label>
                <br />
                <asp:Label ID="Label2" runat="server" 
        Text="��§ҹ���ǹ��û����Թ�Ҥ���ѡ��Сѹ" style="font-weight: 700"></asp:Label>
            </div>
        </ContentTemplate>
        
    </asp:UpdatePanel>
&nbsp;<table class="style1">
        <tr>
            <td class="style12">
                &nbsp;</td>
            <td class="style14">
    <asp:HiddenField ID="hdfTemp_AID" runat="server" />
            </td>
            <td>
                ���ǹ����ѹ�֡</td>
            <td>                
                ŧ�ѹ���
                <asp:TextBox ID="txtMemo_Date" runat="server" Width="112px"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CEMemodate" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtMemo_Date">
                </ajaxToolkit:CalendarExtender>
                </td>
            <td>
                ���駷��
                <asp:TextBox ID="txtSequence" runat="server" Width="112px"></asp:TextBox>
                </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style12">
    <asp:Label ID="Label3" runat="server" Text="���¹"></asp:Label>
            </td>
            <td class="style14">
                <asp:TextBox ID="txtInform_To" runat="server" Width="250px"></asp:TextBox>
            </td>
            <td>
                �ѹ����Ѻ����ͧ</td>
            <td>                
            <asp:TextBox ID="txtReceive_Date" runat="server" Width="112px"></asp:TextBox><ajaxToolkit:CalendarExtender
                    ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy" 
                    TargetControlID="txtReceive_Date">
                </ajaxToolkit:CalendarExtender>
                </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style12">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label4" runat="server" Text="CIF"></asp:Label>
    
            &nbsp;<asp:Label ID="lblCif" runat="server"></asp:Label>
    
            </td>
            <td class="style14">
    <asp:Label ID="Label5" runat="server" Text="�١������"></asp:Label>
    
            &nbsp;<asp:Label ID="lblCifName" runat="server" Width="180px"></asp:Label>
            </td>
            <td>
    <asp:Label ID="Label7" runat="server" Text="�Ң�/���§ҹ"></asp:Label>
    
            </td>
            <td>
                <asp:DropDownList ID="ddlBranch" runat="server" DataSourceID="sdsBranch" 
                    DataTextField="BRANCH_T" DataValueField="ID_BRANCH" style="margin-left: 0px">
                </asp:DropDownList>
            </td>
            <td>
    <asp:Label ID="LblAID" runat="server" Text="AID"></asp:Label>
    
                &nbsp;<asp:TextBox ID="txtAID" runat="server" Width="112px"></asp:TextBox>
                </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style12">
    <asp:Label ID="Label6" runat="server" Text="��ѡ��Сѹ���Թ" style="font-weight: 700"></asp:Label>
    
            </td>
            <td class="style14">
                <asp:Label ID="lblChanode" runat="server" Width="250px"></asp:Label>
            </td>
            <td>
    <asp:Label ID="Label83" runat="server" Text="���ͷ�����"></asp:Label>
    
            &nbsp;<asp:Label ID="lblLandArea" runat="server"></asp:Label>
    
            </td>
            <td>
                �ѹ�������Թ 
                <asp:TextBox ID="txtAppraisal_Date" runat="server" Width="112px"></asp:TextBox><ajaxToolkit:CalendarExtender
                    ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" 
                    TargetControlID="txtAppraisal_Date">
                </ajaxToolkit:CalendarExtender>
                <span style="color: Red">*</span>
            
            </td>
            <td>
                &nbsp;</td>
            <td>
                </td>
        </tr>
        <tr>
            <td class="style12">
    <asp:Label ID="Label80" runat="server" Text="��ѡ��Сѹ���Թ" style="font-weight: 700"></asp:Label>
    
            </td>
            <td class="style14">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                    RepeatDirection="Horizontal" AutoPostBack="True">
                    <asp:ListItem Selected="True" Value="0">�������¹�ŧ</asp:ListItem>
                    <asp:ListItem Value="1">����¹�ŧ</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td colspan="4">
                <asp:TextBox ID="txtLandDetail" runat="server" Width="450px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style12">
    <asp:Label ID="Label8" runat="server" Text="���м١�ѹ" style="font-weight: 700"></asp:Label>
    
            </td>
            <td class="style14">
                <asp:RadioButtonList ID="RadioButtonList2" runat="server" 
                    RepeatDirection="Horizontal" AutoPostBack="True">
                    <asp:ListItem Selected="True" Value="0">�������¹�ŧ</asp:ListItem>
                    <asp:ListItem Value="1">����¹�ŧ</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td colspan="4">
                <asp:TextBox ID="txtObligation" runat="server" Width="450px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style12">
    <asp:Label ID="Label9" runat="server" Text="����������Ҿ���Թ" style="font-weight: 700"></asp:Label>
    
            </td>
            <td class="style14">
                <asp:RadioButtonList ID="RadioButtonList3" runat="server" 
                    RepeatDirection="Horizontal" AutoPostBack="True">
                    <asp:ListItem Selected="True" Value="0">�������¹�ŧ</asp:ListItem>
                    <asp:ListItem Value="1">����¹�ŧ</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td colspan="4">
                <asp:TextBox ID="txtLandAddress" runat="server" Width="450px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style12">
    <asp:Label ID="Label10" runat="server" Text="�ѧ���ͧ���" style="font-weight: 700"></asp:Label>
    
            </td>
            <td class="style13" colspan="5">
                ���Թ�����ࢵ��鹷����
                <asp:Label ID="lblAreaColour" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style12">
    <asp:Label ID="Label11" runat="server" Text="�����������ԭ" style="font-weight: 700"></asp:Label>
    
            </td>
            <td class="style14">
                <asp:RadioButtonList ID="RadioButtonList4" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="0">�������¹�ŧ</asp:ListItem>
                    <asp:ListItem Value="1">�բ��</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                <asp:Button ID="btnChangeLand" runat="server" Text="     ��䢷��Թ     " />
            </td>
            <td>
    <asp:Label ID="Label81" runat="server" Text="��Ҿ��ë���-���"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblBuySaleState_Name" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style12">
    <asp:Label ID="Label12" runat="server" Text="��觻�١���ҧ" style="font-weight: 700"></asp:Label>
    
            </td>
            <td class="style14">
                <asp:RadioButtonList ID="RadioButtonList5" runat="server" 
                    RepeatDirection="Horizontal" AutoPostBack="True">
                    <asp:ListItem Selected="True" Value="0">�������¹�ŧ</asp:ListItem>
                    <asp:ListItem Value="1">����¹�ŧ</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td colspan="4">
                <asp:Button ID="btnChangeBuilding" runat="server" Text="�����觻�١���ҧ" />
                <asp:TextBox ID="txtBuilding" runat="server" Width="450px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style12">
    <asp:Label ID="Label13" runat="server" Text="ࢵ��û���ͧ" style="font-weight: 700"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;
    �ǧ/�Ӻ�</td>
            <td class="style14">
                <asp:Label ID="lblDistrict" runat="server"></asp:Label>
            </td>
            <td>
                ࢵ/�����</td>
            <td>
                <asp:Label ID="lblAmphur" runat="server"></asp:Label>
            </td>
            <td>
                �ѧ��Ѵ</td>
            <td>
                <asp:Label ID="lblProvinceName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style12">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label14" runat="server" Text="��Ҿ��õ���"></asp:Label>
            </td>
            <td class="style13" colspan="5">
                    <asp:DropDownList ID="ddlInteriorState" runat="server" 
                        DataSourceID="SDSInterior_State" DataTextField="InteriorState_Name" 
                        DataValueField="InteriorState_Id">
                    </asp:DropDownList>
                <asp:Label ID="lblDecoration" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <table class="style1" border="1px" style="font-size:small;">
                    <tr class="bgTable">
                        <td rowspan="2" valign="top">
                            ��¡����觻�١���ҧ</td>
                        <td rowspan="2" valign="top">
                            ��鹷��<br />
                            (���.)</td>
                        <td colspan="2">
                            �Ҥҵ鹷ع��᷹����</td>
                        <td rowspan="2" valign="top">
                            ���ء��<br />
                            ��ҹ(��)</td>
                        <td rowspan="2" valign="top" class="style4">
                            ���������(��)</td>
                        <td colspan="2">
                            ��Ѻ��������������Ҿ</td>
                        <td rowspan="2" valign="top">
                            ������������<br />
                            %</td>
                        <td rowspan="2" valign="top">
                            ������������<br />
                            (�ҷ)</td>
                        <td rowspan="2" valign="top">
                            �Ҥҵ����Ҿ<br />
                            �Ѩ�غѹ(�ҷ)</td>
                    </tr>
                    <tr class="bgTable">
                        <td class="style3" valign="top">
                            ���˹���</td>
                        <td class="style3" valign="top">
                            ��Ť��(�ҷ)</td>
                        <td class="style3" valign="top">
                            ��Ѻ��ا</td>
                        <td class="style3" valign="top">
                            ���������</td>
                    </tr>
                    <tr>
                        <td>
                            1.<asp:Label ID="lblBuildingFloors" runat="server"></asp:Label>
                        &nbsp;���</td>
                        <td align="center">
                            <asp:Label ID="lblArea" runat="server"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblUnitPrice" runat="server"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblCostPrice" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblAge" runat="server"></asp:Label>
                        </td>
                        <td align="center" class="style4">
                            <asp:Label ID="lblYearDamage" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblAdap" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblDecadent" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblP_Damage" runat="server"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblDamageBth" runat="server"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Label ID="lbltotalPrice" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            2.��ǹ������</td>
                        <td align="center">
                            <asp:Label ID="lblArea1" runat="server"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblUnitPrice1" runat="server"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblCostPrice1" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblAge1" runat="server"></asp:Label>
                        </td>
                        <td class="style4" align="center">
                            <asp:Label ID="lblYearDamage1" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblAdap1" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblDecadent1" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblP_Damage1" runat="server"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblDamageBth1" runat="server"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Label ID="lbltotalPrice1" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            3.��ǹ�Ǻ</td>
                        <td align="center">
                            <asp:Label ID="lblArea2" runat="server"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblUnitPrice2" runat="server"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblCostPrice2" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblAge2" runat="server"></asp:Label>
                        </td>
                        <td class="style4" align="center">
                            <asp:Label ID="lblYearDamage2" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblAdap2" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblDecadent2" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblP_Damage2" runat="server"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblDamageBth2" runat="server"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Label ID="lbltotalPrice2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td class="style4">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td align="right">
                            <asp:Label ID="lblGrandTotal" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td class="style4">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="6">
    <asp:Label ID="Label15" runat="server" Text="�����Ǵ�����Ѻ�š�з�" 
                    style="font-weight: 700"></asp:Label>
    &nbsp;
    <asp:Label ID="Label16" runat="server" 
                    Text="��õ�Ǩ�ͺ�ѭ�������Ǵ���������§��ҷ������ö��Ǩ�ͺ�� � �ѹ���Ǩ"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5" colspan="6">
                <asp:CheckBox ID="ChkProblem" runat="server" Text="����ջѭ��" 
                    BackColor="#FFFF66" />&#160;<asp:Label
                    ID="Label49" runat="server" Text="(�����͸Ժ���������) "></asp:Label>
                      <asp:TextBox  ID="txtProblem_Detail" runat="server" Width="450px" 
                    BackColor="#FFFF66"></asp:TextBox>                  
            &nbsp; </td>
        </tr>
        <tr>
            <td class="style12">
    <asp:Label ID="Label18" runat="server" Text="��û����Թ�Ҥ�" style="font-weight: 700"></asp:Label>
    &nbsp;�����ū��͢��</td>
            <td class="style6" colspan="5">
                <asp:TextBox ID="txtBuy_Sale_Comment" runat="server" Height="64px" TextMode="MultiLine"
                    Width="716px" BackColor="#FFFF66"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style12">
                <asp:Label ID="Label52" runat="server" Font-Bold="True" Text="�Ըա�û����Թ�Ҥ�"></asp:Label>
            </td>
            <td class="style13" colspan="5">
                <asp:DropDownList ID="ddlAppraisal_Type" runat="server" CssClass="txtDoPrint" 
                    DataSourceID="SDSAppraisal_Type" DataTextField="App_Type_Name" 
                    DataValueField="App_Type_ID" BackColor="#FFFF66">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style5" colspan="6">
                <table width="100%">
        <tr>
            <td class="style16">
                <asp:Label ID="Label53" runat="server" Text="���Թ ���ͷ��"></asp:Label>
            </td>
            <td class="style10">
                <asp:Label ID="lblSize" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style9">
                <asp:Label ID="Label54" runat="server" Text="���. ��"></asp:Label>&#160;&#160;
            </td>
            <td class="style15">
                <asp:Label ID="lblPriceWah" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style7">
                <asp:Label ID="Label55" runat="server" Text="���Թ"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblLandTotal" runat="server" Style="color: #FF0000" 
                    Width="150px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style16">
                <asp:Label ID="Label56" runat="server" Text="��觻�١���ҧ"></asp:Label>
            </td>
            <td class="style10">
                <asp:Label ID="lblBuilding_Detail" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style9">
            </td>
            <td class="style15">
                <asp:Label ID="lblTotal2" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style7">
                <asp:Label ID="Label57" runat="server" Text="���Թ"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblBuildingPrice" runat="server" Style="color: #FF0000" 
                    Width="150px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style16">
                <asp:Label ID="Label48" runat="server" Text="���Թ�������觻�١���ҧ"></asp:Label>
            </td>
            <td class="style10">
                <asp:Label ID="lblLand_Build" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style9">
            </td>
            <td class="style15">
                <asp:Label ID="lblTotal3" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style7">
                <asp:Label ID="Label60" runat="server" Text="������Թ"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblGrantotal" runat="server" Style="color: #FF0000" 
                    Width="150px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style16">
                <asp:Label ID="Label61" runat="server" Font-Bold="True" 
                    Text="��ػ�š�û����Թ�Ҥ�"></asp:Label>
            </td>
            <td class="style10">
            </td>
            <td class="style9">
            </td>
            <td class="style15">
                &nbsp;</td>
            <td class="style7">
                &nbsp;</td>
            <td>
                <asp:Label ID="lblGrantotalAll" runat="server" Style="color: #FF0000" 
                    Width="150px"></asp:Label>
            </td>
        </tr>
    </table>
            </td>
        </tr>
        <tr>
            <td class="style12" colspan="6">
                <asp:Label ID="Label62" runat="server" Text="�Ҥһ����Թ��������ش"></asp:Label>
            &nbsp;<asp:TextBox ID="txtLast_Appraisal_Detail" runat="server" Width="600px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style12">
                <asp:Label ID="Label63" runat="server" Text="COMMENT"></asp:Label>
            </td>
            <td class="style13" colspan="5">
                <asp:DropDownList ID="ddlComment" runat="server" DataSourceID="SDSComment" 
                    DataTextField="Comment_Name" DataValueField="Comment_ID" 
                    BackColor="#FFFF66">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style12">
                <asp:Label ID="Label64" runat="server" Text="WARNING"></asp:Label>
            </td>
            <td class="style13" colspan="5">
                <asp:DropDownList ID="ddlWarning" runat="server" DataSourceID="SDSWarning" 
                    DataTextField="Warning_Name" DataValueField="Warning_ID" 
                    BackColor="#FFFF66">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style12" colspan="2">
                <asp:TextBox ID="txtWarning_Detail" runat="server" Height="50px" TextMode="MultiLine"
                    Width="400px" BackColor="#FFFF66"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5" colspan="6">
            
    <table width="100%">
        <tr>
            <td valign="top" class="style11">
                </td>
            <td class="style11" align="right">
                <table>
                    <tr>
                        <td class="style17">
                            <asp:Label ID="Label79" runat="server" Text="ŧ����"></asp:Label>
                        </td>
                        <td class="style18" >
                            </td>
                        <td class="style18">
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
                            <asp:Label ID="lblAppraisalName" runat="server" Width="200px"></asp:Label>
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
            <td colspan="2" align="center">
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
                            &#160;&#160;
                        </td>
                        <td align="center">
                            <asp:TextBox ID="txtApprove1" runat="server" BackColor="#FFFF66" Width="170px"></asp:TextBox>
                        </td>
                        <td>
                            &#160;&#160;
                        </td>
                        <td align="center">
                            <asp:TextBox ID="txtApprove2" runat="server" BackColor="#FFFF66" 
                                Width="170px"></asp:TextBox>
                        </td>
                        <td>
                            &#160;&#160;
                        </td>
                        <td align="center">
                            <asp:TextBox ID="txtApprove3" runat="server" BackColor="#FFFF66" 
                                Width="170px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &#160;&#160;
                        </td>
                        <td align="center">
                            <asp:Label ID="Label76" runat="server" Text="͹ء������"></asp:Label>
                        </td>
                        <td>
                            &#160;&#160;
                        </td>
                        <td align="center">
                            <asp:Label ID="Label78" runat="server" Text="͹ء������"></asp:Label>
                        </td>
                        <td>
                            &#160;&#160;
                        </td>
                        <td align="center">
                            <asp:Label ID="Label77" runat="server" Text="͹ء������"></asp:Label>
                        </td>
                    </tr>
                    </table>
            </td>
        </tr>
    </table>
            
            </td>
        </tr>
        <tr>
            <td class="style12" align="center" colspan="6">
                <table>
                    <tr>
                        <td>
                            <asp:ImageButton ID="ImageSave" runat="server" Height="35px" 
                                ImageUrl="~/Images/Save.jpg" Width="35px" />
                        </td>
                        <td>
                            SAVE                         </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="style12">
                &nbsp;</td>
            <td class="style14">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    
    <br />
    
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
    
    <asp:SqlDataSource ID="SDSArea_Color" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        
        
        SelectCommand="SELECT [AreaColour_No], [AreaColour_Name] FROM [AreaColour]">
    </asp:SqlDataSource>
    
    <asp:SqlDataSource ID="sdsBranch" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="GET_BRANCH" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    
    <asp:SqlDataSource ID="SDSInterior_State" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        
        
        SelectCommand="SELECT [InteriorState_Id], [InteriorState_Name] FROM [Interior_State]">
    </asp:SqlDataSource>
    
    <asp:SqlDataSource ID="SDSUserAppraisal" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT Emp_id, Title + Name + '  ' + Lastname AS UserAppraisal FROM Tb_UserAppraisal">
    </asp:SqlDataSource>
        
</asp:Content>

