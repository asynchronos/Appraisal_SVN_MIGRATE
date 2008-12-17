<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_Price2_Add_By_Colltype70.aspx.vb" Inherits="Appraisal_Price2_Add_By_Colltype70" %>

<%@ Register assembly="Mytextbox" namespace="Mytextbox" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">



        .style11
        {
            width: 186px;
        }
        .style8
        {
            width: 180px;
        }
        .style5
        {
            width: 187px;
        }
        .style14
        {
            width: 193px;
        }
        .style13
        {
            height: 15px;
            width: 186px;
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
            width: 193px;
        }
            .style17
        {
            height: 24px;
        }
            </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
<br />
              <table width="100%" style="background-color: #B5C7DE;">
        <tr>
            <td class="style17">
                เลขลำดับ</td>
            <td class="style17">
                <asp:Label ID="lblId" runat="server" style="font-weight: 700; color: #FF0000;"></asp:Label>
            </td>
            <td class="style17">
                &nbsp;</td>
            <td class="style17">
                &nbsp;</td>
            <td class="style17">
                </td>
            <td class="style17">
            </td>
        </tr>              
        <tr>
            <td class="style17">
                เลขคำขอประเมิน</td>
            <td class="style17">
                <asp:Label ID="lblReq_Id" runat="server" style="font-weight: 700"></asp:Label>
            </td>
            <td class="style17">
                รหัส Hub</td>
            <td class="style17">
                <asp:Label ID="lblHub_Id" runat="server" style="font-weight: 700"></asp:Label>
            </td>
            <td class="style17">
                </td>
            <td class="style17">
            </td>
        </tr>                  
              <tr>
                <td>ชนิดหลักประกัน</td>
                    <td colspan="5">
                        <asp:DropDownList ID="DDLSubCollType" runat="server" 
                            DataSourceID="sdsSubCollType" DataTextField="SubCollType_Name"
                            DataValueField="MysubColl_ID">
                        </asp:DropDownList>
                    </td>
              </tr>
              <tr>
                <td>ปลูกสร้างบนโฉนดเลขที่</td>
                    <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>
                        &nbsp;</td>
                  <td>&nbsp;</td>
                  <td></td>
              </tr>              
            <tr>
                <td class="style11">
                    สิ่งปลูกสร้าง บ้านเลขที่
                </td>
                <td class="style8">
                    <asp:TextBox ID="txtBuild_No" runat="server"></asp:TextBox>
                </td>
                <td class="style5">
                    ตำบล</td>
                <td>
                <asp:TextBox ID="txtTumbon" runat="server"></asp:TextBox>
                </td>
                <td class="style14">
                    อำเภอ</td>
                <td>
                <asp:TextBox ID="txtAmphur" runat="server"></asp:TextBox>
                </td>
            </tr>
        <tr>
            <td class="style17">
                จังหวัด</td>
            <td class="style17">
                <asp:DropDownList ID="ddlProvince" runat="server" DataSourceID="SDSProvince" 
                    DataTextField="PROV_NAME" DataValueField="PROV_CODE">
                </asp:DropDownList>
            </td>
            <td class="style17">
                    ลักษณะอาคาร</td>
            <td class="style17">
                    <asp:DropDownList ID="ddlBuild_Character" runat="server" 
                        DataSourceID="SDSlBuild_Character" DataTextField="Build_Character_Name" 
                        DataValueField="Build_Character_ID">
                    </asp:DropDownList>
            </td>
            <td class="style17">
                    จำนวน</td>
            <td class="style17">
                    <cc1:mytext ID="txtFloor" runat="server" AllowUserKey="num_Numeric" 
                        Width="35px"></cc1:mytext>
                    &nbsp;ชั้น
                    <asp:TextBox ID="txtItem" runat="server" Width="35px">0</asp:TextBox>
                    &nbsp;หลัง</td>
        </tr>             
            <tr>
                <td class="style13">
                    โครงสร้างอาคาร
                </td>
                <td class="style10">
                    <asp:DropDownList ID="ddlBuild_Construct" runat="server" 
                        DataSourceID="SDSBuild_Construct" DataTextField="Build_Construct_Name" 
                        DataValueField="Build_Construct_ID">
                    </asp:DropDownList>
                </td>
                <td class="style7">
                    หลังคา
                </td>
                <td class="style4">
                    <asp:DropDownList ID="ddlRoof" runat="server" DataSourceID="SDSRoof" 
                        DataTextField="Roof_Name" DataValueField="Roof_ID">
                    </asp:DropDownList>
                </td>
                <td class="style16">
                    รายละเอียดเพิ่มเติม(ถ้ามี)
                </td>
                <td class="style4">
                    <asp:TextBox ID="txtRoof_Detail" runat="server"></asp:TextBox>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style11">
                    สภาพอาคาร
                </td>
                <td class="style8">
                    <asp:DropDownList ID="ddlBuild_State" runat="server" 
                        DataSourceID="SDSBuild_State" DataTextField="Build_State_Name" 
                        DataValueField="Build_State_ID">
                    </asp:DropDownList>
                </td>
                <td class="style5">
                    รายละเอียดสภาพอื่น ๆ
                </td>
                <td>
                    <asp:TextBox ID="txtBuild_State_Detail" runat="server"></asp:TextBox>
                </td>
                <td class="style14">
                    สิ่งปลูกสร้าง</td>
                <td>
                    <asp:TextBox ID="txtBuilding_Detail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    เป็นเงิน
                </td>
                <td class="style8">
                    <cc1:mytext ID="txtPriceTotal1" runat="server" AllowUserKey="num_Numeric" AutoCurrencyFormatOnKeyUp="True"
                        EnableTextAlignRight="True" onblur="GrandTotal_ActiveChanged();">0</cc1:mytext>
                </td>
                <td class="style5">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td class="style14">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;เอกสารประกอบเพิ่มเติม
                </td>
                <td class="style8">
                    <asp:CheckBox ID="chkDoc1" runat="server" Text="ใบอนุญาติปลูกสร้าง" />
                </td>
                <td class="style5">
                    <asp:CheckBox ID="chkDoc2" runat="server" Text="เรื่องทางภารจำยอม" />
                </td>
                <td>
                    &nbsp;
                </td>
                <td class="style14">
                    ระบุเอกสารอื่น
                </td>
                <td>
                    <asp:TextBox ID="txtDoc_Detail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;</td>
                <td class="style8">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td class="style14">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
                <tr style="background-color:#E7E7FF;">
                    <td colspan="6" align="center">
                        <table>
                            <tr>
                                <td>
                                    <asp:ImageButton ID="ImageSave" runat="server" ImageUrl="~/Images/Save.jpg" />
                                </td>
                                   <td>SAVE</td>
                            </tr>
                        </table>
                    </td>
                </tr>            
        </table> 
    <asp:SqlDataSource ID="sdsSubCollType" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        
        SelectCommand="SELECT [SubCollType_Name], [MysubColl_ID] FROM [CollType_All] WHERE ([CollType_ID] = @CollType_ID)">
        <SelectParameters>
            <asp:QueryStringParameter Name="CollType_ID" QueryStringField="Coll_Type" 
                Type="Int32" />
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
    
    </asp:Content>

