<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_Price3_Add_Colltype70.aspx.vb" Inherits="Appraisal_Price3_Add_Colltype70" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register assembly="Mytextbox" namespace="Mytextbox" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
            .style17
        {
            height: 24px;
        }
        .style8
        {
        }
        .style5
        {
        }
        .style10
        {
            height: 15px;
            width: 180px;
        }
        .style7
        {
            height: 15px;
            width: 187px;
        }
        .style4
        {
            height: 15px;
        }
        .style16
        {
            height: 15px;
            width: 168px;
        }
            .style19
        {
            width: 222px;
        }
        .style20
        {
            height: 15px;
            width: 222px;
        }
        .style21
        {
            height: 24px;
            width: 211px;
        }
        .style22
        {
            width: 211px;
        }
        .style23
        {
            height: 15px;
            width: 211px;
        }
        .style24
        {
            width: 211px;
            color: #000000;
            }
        .style25
        {
            height: 24px;
            width: 168px;
        }
        .style26
        {
            width: 168px;
        }
        .style27
        {
            height: 24px;
            width: 222px;
        }
        .style28
        {
            width: 211px;
            color: #3333CC;
            font-weight: bold;
        }
        .style29
        {
            color: #3333CC;
            font-weight: bold;
        }
    </style>
    
        <script type="text/javascript">
<!--
var updated="";

// http://www.boutell.com/newfaq/creating/windowcenter.html
function wopen(url, name, w, h) {
    // Fudge factors for window decoration space.
    // In my tests these work well on all platforms & browsers.
    w += 32;
    h += 96;
    wleft = (screen.width - w) / 2;
    wtop = (screen.height - h) / 2;
    // IE5 and other old browsers might allow a window that is
    // partially offscreen or wider than the screen. Fix that.
    // (Newer browsers fix this for us, but let's be thorough.)
    if (wleft < 0) {
        w = screen.width;
        wleft = 0;
    }
    if (wtop < 0) {
        h = screen.height;
        wtop = 0;
    }
    var win = window.open(url,
    name,
    'width=' + w + ', height=' + h + ', ' +
    'left=' + wleft + ', top=' + wtop + ', ' +
    'location=no, menubar=no, modal=yes' +
    'status=no, toolbar=no, scrollbars=no, resizable=no', 'tite=no', 'resizable=no', 'directories=no', 'status=no');
    // Just in case width and height are ignored
    win.resizeTo(w, h);
    // Just in case left and top are ignored
    win.moveTo(wleft, wtop);
    win.focus();
}

// -->

function ConfirmOnSave(item) {
        if (confirm("����բ�������觻�١���ҧ��� �س��ͧ��úѹ�֡��觻�١���ҧ�Ţ���: " + item + " ��������� ?") == true)
            return true;
        else
            return false;
    }  
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<br />
<br />
    <span class="style29">��������´��觻�١���ҧ�Ҥҷ�� 3</span>
              <table width="100%" 
        style="background-color: #B5C7DE; font-size: small;">
        <tr>
            <td class="style21">
                �Ţ�ӴѺ</td>
            <td>
                <asp:Label ID="lblId" runat="server" style="font-weight: 700; color: #FF0000;"></asp:Label>
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
                �Ţ�Ӣͻ����Թ</td>
            <td class="style17">
                <asp:Label ID="lblReq_Id" runat="server" style="font-weight: 700"></asp:Label>
            </td>
            <td class="style17">
                ���� Hub</td>
            <td class="style27">
                <asp:Label ID="lblHub_Id" runat="server" style="font-weight: 700"></asp:Label>
            </td>
            <td class="style25">
            </td>
            <td class="style17">

            </td>
        </tr>                  
              <tr>
                <td class="style22">��Դ��ѡ��Сѹ</td>
                    <td colspan="5">
                        <asp:DropDownList ID="DDLSubCollType" runat="server" 
                            DataSourceID="sdsSubCollType" DataTextField="SubCollType_Name"
                            DataValueField="MysubColl_ID">
                        </asp:DropDownList>
                        <asp:HiddenField ID="hhhfSubCollType" runat="server" />
                    </td>
              </tr>
              <tr>
                <td class="style22">��١���ҧ��⩹��Ţ���</td>
                    <td>
                    <asp:TextBox ID="txtChanodeNo" runat="server" BackColor="#FFFF66"></asp:TextBox>
                    </td>
                    <td>���觻�١���ҧ�����Է���ͧ</td>
                    <td class="style19">
                    <asp:TextBox ID="txtOwnership" runat="server" Width="222px" BackColor="#FFFF66"></asp:TextBox>
                    </td>
                  <td class="style26">&nbsp;</td>
                  <td></td>
              </tr>              
            <tr>
                <td class="style22">
                    ��觻�١���ҧ ��ҹ�Ţ���
                </td>
                <td class="style8">
                    <asp:TextBox ID="txtBuild_No" runat="server"></asp:TextBox>
                </td>
                <td class="style5">
                    �Ӻ�</td>
                <td class="style19">
                <asp:TextBox ID="txtTumbon" runat="server"></asp:TextBox>
                </td>
                <td class="style26">
                    �����</td>
                <td>
                <asp:TextBox ID="txtAmphur" runat="server"></asp:TextBox>
                </td>
            </tr>
        <tr>
            <td class="style21">
                �ѧ��Ѵ</td>
            <td class="style17">
                <asp:DropDownList ID="ddlProvince" runat="server" DataSourceID="SDSProvince" 
                    DataTextField="PROV_NAME" DataValueField="PROV_CODE">
                </asp:DropDownList>
            </td>
            <td class="style17">
                    �ѡɳ��Ҥ��</td>
            <td class="style27">
                    <asp:DropDownList ID="ddlBuild_Character" runat="server" 
                        DataSourceID="SDSlBuild_Character" DataTextField="Build_Character_Name" 
                        DataValueField="Build_Character_ID">
                    </asp:DropDownList>
            </td>
            <td class="style25">
                    �ӹǹ</td>
            <td class="style17">
                    <cc1:mytext ID="txtFloor" runat="server" AllowUserKey="num_Numeric" 
                        Width="35px"></cc1:mytext>
                    &nbsp;���
                    <asp:TextBox ID="txtItem" runat="server" Width="35px">0</asp:TextBox>
                    &nbsp;��ѧ</td>
        </tr>             
            <tr>
                <td class="style23">
                    �ç���ҧ�Ҥ��
                </td>
                <td class="style10">
                    <asp:DropDownList ID="ddlBuild_Construct" runat="server" 
                        DataSourceID="SDSBuild_Construct" DataTextField="Build_Construct_Name" 
                        DataValueField="Build_Construct_ID">
                    </asp:DropDownList>
                </td>
                <td class="style7">
                    ��ѧ��
                </td>
                <td class="style20">
                    <asp:DropDownList ID="ddlRoof" runat="server" DataSourceID="SDSRoof" 
                        DataTextField="Roof_Name" DataValueField="Roof_ID">
                    </asp:DropDownList>
                </td>
                <td class="style16">
                    ��������´�������(�����)
                </td>
                <td class="style4">
                    <asp:TextBox ID="txtRoof_Detail" runat="server"></asp:TextBox>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style22">
                    ��Ҿ�Ҥ��
                </td>
                <td class="style8">
                    <asp:DropDownList ID="ddlBuild_State" runat="server" 
                        DataSourceID="SDSBuild_State" DataTextField="Build_State_Name" 
                        DataValueField="Build_State_ID">
                    </asp:DropDownList>
                </td>
                <td class="style5">
                    ��������´��Ҿ��� �
                </td>
                <td class="style19">
                    <asp:TextBox ID="txtBuild_State_Detail" runat="server"></asp:TextBox>
                </td>
                <td class="style26">
                    ��觻�١���ҧ</td>
                <td>
                    <asp:TextBox ID="txtBuilding_Detail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style22">
                    �ç���ҧ��ѧ��</td>
                <td class="style8">
                    <asp:DropDownList ID="ddlRoofConstructure" runat="server" 
                        DataSourceID="SDSRoofStructure" DataTextField="RoofStructure_Name" 
                        DataValueField="RoofStructure_Id">
                    </asp:DropDownList>
                </td>
                <td class="style5">
                    ��Ҿ��ѧ��</td>
                <td class="style19">
                    <asp:DropDownList ID="ddlRoofState" runat="server" DataSourceID="SDSRoof_State" 
                        DataTextField="RoofState_Name" DataValueField="RoofState_Id">
                    </asp:DropDownList>
                </td>
                <td class="style26">
                    ��Ҿ��õ���</td>
                <td>
                    <asp:DropDownList ID="ddlInteriorState" runat="server" 
                        DataSourceID="SDSInterior_State" DataTextField="InteriorState_Name" 
                        DataValueField="InteriorState_Id">
                    </asp:DropDownList>
                </td>
            </tr>              
            <tr>
                <td class="style22">
                    ���Թ
                </td>
                <td class="style8">
                    <cc1:mytext ID="txtPriceTotal1" runat="server" AllowUserKey="num_Numeric" AutoCurrencyFormatOnKeyUp="True"
                        EnableTextAlignRight="True" onblur="GrandTotal_ActiveChanged();">0</cc1:mytext>
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
                    &nbsp;�͡��û�Сͺ�������
                </td>
                <td class="style8">
                    <asp:CheckBox ID="chkDoc1" runat="server" Text="�͹حҵԻ�١���ҧ" />
                </td>
                <td class="style5">
                    <asp:CheckBox ID="chkDoc2" runat="server" Text="����ͧ�ҧ��è����" />
                </td>
                <td class="style19">
                    &nbsp;</td>
                <td class="style26">
                    �к��͡������
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
                    ��鹷����觻�١���ҧ������</td>
                <td class="style8">
                    <cc1:mytext ID="txtBuildingArea" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" MaxLength="5" Width="35px" BackColor="#FFFF66" 
                        AutoPostBack="True">0</cc1:mytext>
                    ���.</td>
                <td class="style5">
                    �Ҥҵ��˹���(���ҧ����)</td>
                <td class="style19">
                    <cc1:mytext ID="txtBuildingUnitPrice" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" Width="110px" BackColor="#FFFF66" 
                        AutoPostBack="True" AutoCurrencyFormatOnKeyUp="True">0.00</cc1:mytext>
                    �ҷ</td>
                <td class="style26">
                    ��Ť��(���ҧ����)</td>
                <td>
                    <cc1:mytext ID="txtBuildingPrice" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" Width="110px" BackColor="#FFFF66" 
                        AutoPostBack="True" ReadOnly="True">0.00</cc1:mytext>
                    �ҷ</td>
            </tr>
            <tr>
                <td class="style22">
                    �����繵���觻�١���ҧ���ҧ����</td>
                <td class="style8">
                    <cc1:mytext ID="txtFinishPercent" runat="server" AllowUserKey="num_Numeric" 
                        Width="35px" BackColor="#FFFF66" MaxLength="3" AutoPostBack="True" 
                        EnableTextAlignRight="True">100</cc1:mytext>
                    &nbsp;%</td>
                <td class="style5">
                                        ��Ť��</td>
                <td class="style19">
                    <cc1:mytext ID="txtPriceNotFinish" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" Width="110px" BackColor="#FFFF66" 
                        AutoPostBack="True" ReadOnly="True">0.00</cc1:mytext>
                    �ҷ</td>
                <td class="style26">
                                        &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style22">
                    ���ء����ҹ</td>
                <td class="style8">
                    <cc1:mytext ID="txtBuildingAge" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" MaxLength="2" Width="35px" BackColor="#FFFF66" 
                        AutoPostBack="True">0</cc1:mytext>
                    ��</td>
                <td class="style5">
                                        �����������ͻ�</td>
                <td class="style19">
                    <cc1:mytext ID="txtBuildingPersent1" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" MaxLength="5" Width="35px" BackColor="#FFFF66" 
                        AutoPostBack="True">0</cc1:mytext>
                    %</td>
                <td class="style26">
                                        ��������������Ҿ��Ѻ��ا</td>
                <td>
                    <cc1:mytext ID="txtBuildingPersent2" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" MaxLength="5" Width="35px" BackColor="#FFFF66" 
                        AutoPostBack="True">0</cc1:mytext>
                    %</td>
            </tr>
            <tr>
                <td class="style22">
                                        ��������������Ҿ���������</td>
                <td class="style8">
                    <cc1:mytext ID="txtBuildingPersent3" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" MaxLength="5" Width="35px" BackColor="#FFFF66" 
                        AutoPostBack="True">0</cc1:mytext>
                    %</td>
                <td class="style5">
                    ������������</td>
                <td class="style19">
                    <cc1:mytext ID="txtBuildingTotalDeteriorate" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" MaxLength="5" Width="35px" BackColor="#FFFF66" 
                        ReadOnly="True">0</cc1:mytext>
                    %</td>
                <td class="style26">
                    �������������Ҥ�</td>
                <td>
                    <cc1:mytext ID="txtBuildingPriceTotalDeteriorate" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" Width="110px" BackColor="#FFFF66" 
                        ReadOnly="True">0.00</cc1:mytext>
                    �ҷ</td>
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
                    ��ǹ������</td>
                <td class="style8">
                    <cc1:mytext ID="txtBuildAddArea" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" MaxLength="5" Width="35px" BackColor="#FFFF66" 
                        AutoPostBack="True">0</cc1:mytext>
                    ���.</td>
                <td class="style5">
                    �Ҥҵ��˹���(���ҧ����)</td>
                <td class="style19">
                    <cc1:mytext ID="txtBuildAddUnitPrice" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" Width="110px" BackColor="#FFFF66" 
                        AutoPostBack="True" AutoCurrencyFormatOnKeyUp="True" ReadOnly="True">0.00</cc1:mytext>
                    �ҷ</td>
                <td class="style26">
                    ��Ť��(���ҧ����)</td>
                <td>
                    <cc1:mytext ID="txtBuildAddPrice" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" Width="110px" BackColor="#FFFF66" 
                        AutoPostBack="True" ReadOnly="True" AutoCurrencyFormatOnKeyUp="True">0.00</cc1:mytext>
                    �ҷ</td>
            </tr>
            <tr>
                <td class="style22">
                    �����繵���ǹ���������ҧ����</td>
                <td class="style8">
                    <cc1:mytext ID="txtFinishPercent1" runat="server" AllowUserKey="num_Numeric" 
                        Width="35px" BackColor="#FFFF66" MaxLength="3" AutoPostBack="True" 
                        EnableTextAlignRight="True">100</cc1:mytext>
                    %</td>
                <td class="style5">
                                        ��Ť��</td>
                <td class="style19">
                    <cc1:mytext ID="txtPriceNotFinish1" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" Width="110px" BackColor="#FFFF66" 
                        AutoPostBack="True" ReadOnly="True">0.00</cc1:mytext>
                    �ҷ</td>
                <td class="style26">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style22">
                    ���ء����ҹ</td>
                <td class="style8">
                    <cc1:mytext ID="txtBuildAddAge" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" MaxLength="2" Width="35px" BackColor="#FFFF66" 
                        AutoPostBack="True">0</cc1:mytext>
                    ��</td>
                <td class="style5">
                                        �����������ͻ�</td>
                <td class="style19">
                    <cc1:mytext ID="txtBuildAddPersent1" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" MaxLength="5" Width="35px" BackColor="#FFFF66" 
                        AutoPostBack="True">0</cc1:mytext>
                    %</td>
                <td class="style26">
                    ��������������Ҿ��Ѻ��ا 
                </td>
                <td>
                    <cc1:mytext ID="txtBuildAddPersent2" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" MaxLength="5" Width="35px" BackColor="#FFFF66" 
                        AutoPostBack="True">0</cc1:mytext>
                    %</td>
            </tr>
            <tr>
                <td class="style22">
                                        ��������������Ҿ���������</td>
                <td class="style8">
                    <cc1:mytext ID="txtBuildAddPersent3" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" MaxLength="5" Width="35px" BackColor="#FFFF66" 
                        AutoPostBack="True">0</cc1:mytext>
                    %</td>
                <td class="style5">
                                        ������������</td>
                <td class="style19">
                    <cc1:mytext ID="txtBuildAddTotalDeteriorate" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" MaxLength="5" Width="35px" BackColor="#FFFF66" 
                        ReadOnly="True">0</cc1:mytext>
                    %</td>
                <td class="style26">
                    �������������Ҥ�</td>
                <td>
                    <cc1:mytext ID="txtBuildAddPriceTotalDeteriorate" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" Width="110px" BackColor="#FFFF66" 
                        ReadOnly="True">0.00</cc1:mytext>
                    �ҷ</td>
            </tr>
            <tr>
                <td class="style22">
                                        &nbsp;</td>
                <td class="style8">
                    <asp:CheckBox ID="chkDetail" runat="server" Text="��������´�������" />
                </td>
                <td class="style5">
                    <asp:Button ID="btnAddDetail" runat="server" Text="��������´�������" />
                </td>
                <td class="style19">
                    <asp:Button ID="btnAdPartake" runat="server" Text="������ǹ�Ǻ" />
                </td>
                <td class="style26">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style28">
                                        �ҵðҹ</td>
                <td class="style8" colspan="5">
                <asp:DropDownList ID="ddlStandard" runat="server" DataSourceID="sdsStandard" 
                    DataTextField="Standard_Name" DataValueField="Standard_Id">
                </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style22">
                    ��������´&nbsp;</td>
                <td class="style8" colspan="5">
                    <asp:TextBox ID="txtBuildingDetail" runat="server" Height="70px" 
                        TextMode="MultiLine" Width="600px" BackColor="#FFFF66"></asp:TextBox>
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
                                <td>
                                    <asp:ImageButton ID="ImagePrint" runat="server" ImageUrl="~/Images/Printer.png" Width="35px" Height="35px" />
                                </td>
                                <td>
                                    Print
                                    Preview                                 </td>                                
                            </tr>
                        </table>
                    </td>
                </tr>            
        </table> 
    <asp:SqlDataSource ID="sdsSubCollType" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        
        SelectCommand="SELECT [SubCollType_Name], [MysubColl_ID] FROM [CollType_All] WHERE ([CollType_ID] = @CollType_ID)">
        <SelectParameters>
            <asp:ControlParameter ControlID="hhhfSubCollType" Name="CollType_ID" 
                PropertyName="Value" Type="Int32" />
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

    <asp:SqlDataSource ID="SDSProvince" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        
        SelectCommand="SELECT PROV_CODE, PROV_NAME FROM Bay01.dbo.TB_PROVINCE
Order by prov_code">
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
        
    </asp:Content>

