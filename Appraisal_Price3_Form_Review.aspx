<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_Price3_Form_Review.aspx.vb" Inherits="Appraisal_Price3_Form_Review" %>

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
            width: 173px;
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
            width: 296px;
        }
        .style13
        {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<br />
<br />
<%--<h5 style="text-align:center;">��Ҥ�á�ا�����ظ�� �ӡѴ (��Ҫ�)</h5>
<h5 style="text-align:center;">��§ҹ���ǹ��û����Թ�Ҥ���ѡ��Сѹ</h5>--%>
<div style="text-align:center;">
    <asp:Label ID="Label1" runat="server" Text="��Ҥ�á�ا�����ظ�� �ӡѴ (��Ҫ�)" 
        style="font-weight: 700"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" 
        Text="��§ҹ���ǹ��û����Թ�Ҥ���ѡ��Сѹ" style="font-weight: 700"></asp:Label>
</div>
    <table class="style1">
        <tr>
            <td class="style12">
    <asp:Label ID="Label3" runat="server" Text="���¹"></asp:Label>
            </td>
            <td class="style13">
                <asp:Label ID="lblSubjectName" runat="server"></asp:Label>
            </td>
            <td>
                �ѹ����Ѻ����ͧ</td>
            <td>
                &nbsp;</td>
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
            <td class="style13">
    <asp:Label ID="Label5" runat="server" Text="�١������"></asp:Label>
    
            &nbsp;<asp:Label ID="lblCifName" runat="server"></asp:Label>
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
            <td class="style12">
    <asp:Label ID="Label6" runat="server" Text="��ѡ��Сѹ���Թ" style="font-weight: 700"></asp:Label>
    
            </td>
            <td class="style13">
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">�������¹�ŧ</asp:ListItem>
                    <asp:ListItem Value="1">����¹�ŧ</asp:ListItem>
                </asp:CheckBoxList>
            </td>
            <td>
    <asp:Label ID="Label7" runat="server" Text="�Ң�"></asp:Label>
    
            </td>
            <td>
                <asp:Label ID="lblBranchName" runat="server"></asp:Label>
            </td>
            <td>
                �ѹ�������Թ</td>
            <td>
                <asp:TextBox ID="txtReceive_Date" runat="server" Width="112px"></asp:TextBox><ajaxToolkit:CalendarExtender
                    ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtReceive_Date">
                </ajaxToolkit:CalendarExtender>
                <span style="color: Red">*</span>
            </td>
        </tr>
        <tr>
            <td class="style12">
                &nbsp;</td>
            <td class="style13">
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
        <tr>
            <td class="style12">
    <asp:Label ID="Label8" runat="server" Text="���м١�ѹ" style="font-weight: 700"></asp:Label>
    
            </td>
            <td class="style13">
                <asp:CheckBoxList ID="CheckBoxList2" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">�������¹�ŧ</asp:ListItem>
                    <asp:ListItem Value="1">����¹�ŧ</asp:ListItem>
                </asp:CheckBoxList>
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
            <td class="style12">
    <asp:Label ID="Label9" runat="server" Text="����������Ҿ���Թ" style="font-weight: 700"></asp:Label>
    
            </td>
            <td class="style13">
                <asp:CheckBoxList ID="CheckBoxList3" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">�������¹�ŧ</asp:ListItem>
                    <asp:ListItem Value="1">����¹�ŧ</asp:ListItem>
                </asp:CheckBoxList>
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
            <td class="style12">
    <asp:Label ID="Label10" runat="server" Text="�ѧ���ͧ���" style="font-weight: 700"></asp:Label>
    
            </td>
            <td class="style13" colspan="5">
                ���Թ�����ࢵ��鹷����
                <asp:DropDownList ID="ddlAreaColur" runat="server" 
                        DataSourceID="SDSArea_Color" DataTextField="AreaColour_Name" 
                        DataValueField="AreaColour_No" BackColor="#FFFF66">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style12">
    <asp:Label ID="Label11" runat="server" Text="�����������ԭ" style="font-weight: 700"></asp:Label>
    
            </td>
            <td class="style13">
                <asp:CheckBoxList ID="CheckBoxList4" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">�������¹�ŧ</asp:ListItem>
                    <asp:ListItem Value="1">����¹�ŧ</asp:ListItem>
                </asp:CheckBoxList>
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
            <td class="style12">
    <asp:Label ID="Label12" runat="server" Text="��觻�١���ҧ" style="font-weight: 700"></asp:Label>
    
            </td>
            <td class="style13">
                <asp:CheckBoxList ID="CheckBoxList5" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">�������¹�ŧ</asp:ListItem>
                    <asp:ListItem Value="1">����¹�ŧ</asp:ListItem>
                </asp:CheckBoxList>
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
            <td class="style12">
    <asp:Label ID="Label13" runat="server" Text="ࢵ��û���ͧ" style="font-weight: 700"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;
    �ǧ/�Ӻ�</td>
            <td class="style13">
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
            <td class="style13">
                <asp:CheckBoxList ID="CheckBoxList6" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">���觾��������</asp:ListItem>
                    <asp:ListItem Value="1">���觺ҧ��ǹ</asp:ListItem>
                    <asp:ListItem Value="2">��赡��</asp:ListItem>
                </asp:CheckBoxList>
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
                <asp:TextBox ID="txtBuy_Sale_Comment" runat="server" Height="80px" TextMode="MultiLine"
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
            <td class="style8">
                &nbsp;</td>
            <td class="style10">
                &nbsp;</td>
            <td class="style9">
            </td>
            <td class="style6">
                &nbsp;</td>
            <td class="style7">
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style8">
                <asp:Label ID="Label53" runat="server" Text="���Թ ���ͷ��"></asp:Label>
            </td>
            <td class="style10">
                <asp:Label ID="lblSize" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style9">
                <asp:Label ID="Label54" runat="server" Text="���. ��"></asp:Label>&#160;&#160;
            </td>
            <td class="style6">
                <asp:Label ID="lblPriceWah" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style7">
                <asp:Label ID="Label55" runat="server" Text="���Թ"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblLandTotal" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style8">
                <asp:Label ID="Label56" runat="server" Text="��觻�١���ҧ"></asp:Label>
            </td>
            <td class="style10">
                <asp:Label ID="lblBuilding_Detail" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style9">
            </td>
            <td class="style6">
                <asp:Label ID="lblTotal2" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style7">
                <asp:Label ID="Label57" runat="server" Text="���Թ"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblBuildingPrice" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style8">
                <asp:Label ID="Label48" runat="server" Text="���Թ�������觻�١���ҧ"></asp:Label>
            </td>
            <td class="style10">
                <asp:Label ID="lblLand_Build" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style9">
            </td>
            <td class="style6">
                <asp:Label ID="lblTotal3" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
            <td class="style7">
                <asp:Label ID="Label60" runat="server" Text="������Թ"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblGrantotal" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style8">
                <asp:Label ID="Label61" runat="server" Font-Bold="True" 
                    Text="��ػ�š�û����Թ�Ҥ�"></asp:Label>
            </td>
            <td class="style10">
            </td>
            <td class="style9">
            </td>
            <td class="style6">
                &nbsp;</td>
            <td class="style7">
                &nbsp;</td>
            <td>
                <asp:Label ID="lblGrantotalAll" runat="server" Style="color: #FF0000"></asp:Label>
            </td>
        </tr>
    </table>
            </td>
        </tr>
        <tr>
            <td class="style12">
                &nbsp;</td>
            <td class="style13">
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
        <tr>
            <td class="style12">
                <asp:Label ID="Label62" runat="server" Text="�Ҥһ����Թ��������ش"></asp:Label>
            </td>
            <td class="style13">
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
        <tr>
            <td class="style12">
                <asp:Label ID="Label63" runat="server" Text="COMMENT"></asp:Label>
            </td>
            <td class="style13">
                <asp:DropDownList ID="ddlComment" runat="server" DataSourceID="SDSComment" 
                    DataTextField="Comment_Name" DataValueField="Comment_ID" 
                    BackColor="#FFFF66">
                </asp:DropDownList>
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
            <td class="style12">
                <asp:Label ID="Label64" runat="server" Text="WARNING"></asp:Label>
            </td>
            <td class="style13">
                <asp:DropDownList ID="ddlWarning" runat="server" DataSourceID="SDSWarning" 
                    DataTextField="Warning_Name" DataValueField="Warning_ID" 
                    BackColor="#FFFF66">
                </asp:DropDownList>
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
            <td class="style12">
                &nbsp;</td>
            <td class="style13">
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
        <tr>
            <td class="style5" colspan="6">
            
    <table width="100%">
        <tr>
            <td valign="top" class="style11">
                </td>
            <td class="style11" align="right">
                <table class="style2">
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
                            <asp:Label ID="Label79" runat="server" Text="ŧ����"></asp:Label>
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
                            <asp:Label ID="lblAppraisalName" runat="server" Width="200px"></asp:Label>
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
                <table class="style2" width="100%">
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
                </table>
            </td>
        </tr>
    </table>
            
            </td>
        </tr>
        <tr>
            <td class="style12">
                &nbsp;</td>
            <td class="style13">
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
    
</asp:Content>

