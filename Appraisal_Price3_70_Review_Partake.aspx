<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_Price3_70_Review_Partake.aspx.vb" Inherits="Appraisal_Price3_70_Review_Pastake" %>
<%@ Register assembly="Mytextbox" namespace="Mytextbox" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<br />
<br />
<h4>เพิ่มส่วนควบ (ทบทวนการประเมิน)</h4>
              <asp:HiddenField ID="hdfColl_Type" runat="server" />
    <asp:HiddenField ID="hdfAID" runat="server" />
    <asp:HiddenField ID="hdfCif" runat="server" />

              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                  <ContentTemplate>
                      <table width="100%" 
        style="background-color: #B5C7DE; font-size: small;">
                          <tr>
                              <td class="style21">
                                  เลขลำดับ</td>
                              <td>
                                  <asp:Label ID="lblId" runat="server" style="font-weight: 700; color: #FF0000;"></asp:Label>
                              </td>
                              <td>
                                  Temp AID</td>
                              <td class="style17">
                                  <asp:Label ID="lblTemp_AID" runat="server" 
                    style="font-weight: 700; color: #FF0000;"></asp:Label>
                              </td>
                              <td class="style17">
                                  AID</td>
                              <td>
                                  <asp:Label ID="lblAID" runat="server" 
                    style="font-weight: 700; color: #FF0000;"></asp:Label>
                              </td>
                          </tr>
                          <tr>
                              <td class="style21">
                                  เลขคำขอประเมิน</td>
                              <td class="style17">
                                  <asp:Label ID="lblReq_Id" runat="server" style="font-weight: 700"></asp:Label>
                              </td>
                              <td class="style17">
                                  รหัส Hub</td>
                              <td class="style18">
                                  <asp:Label ID="lblHub_Id" runat="server" style="font-weight: 700"></asp:Label>
                              </td>
                              <td class="style17">
                                  &nbsp;</td>
                              <td class="style17">
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="style24">
                                  ชนิดส่วนควบ</td>
                              <td class="style8">
                                  <asp:DropDownList ID="ddlPartaked" runat="server" DataSourceID="SDSPartake" 
                                      DataTextField="Partake_Name" DataValueField="Partake_Id">
                                  </asp:DropDownList>
                              </td>
                              <td class="style5">
                                  เลขที่</td>
                              <td class="style19">
                                  <asp:TextBox ID="txtBuilding_No" runat="server" ReadOnly="True"></asp:TextBox>
                              </td>
                              <td class="style14">
                                  &nbsp;</td>
                              <td>
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="style24">
                                  พื้นที่ส่วนควบ</td>
                              <td class="style8">
                                  <cc1:mytext ID="txtPartakeArea" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" MaxLength="4" Width="35px" BackColor="#FFFF66" 
                                      AutoPostBack="True">0</cc1:mytext>
                                  ตรม.</td>
                              <td class="style5">
                                  ราคาต่อหน่วย</td>
                              <td class="style19">
                                  <cc1:mytext ID="txtPartakeUnitPrice" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" Width="110px" BackColor="#FFFF66" AutoPostBack="True" 
                                      AutoCurrencyFormatOnKeyUp="True">0.00</cc1:mytext>
                                  บาท</td>
                              <td class="style14">
                                  มูลค่า</td>
                              <td>
                                  <cc1:mytext ID="txtPartakePrice" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" Width="110px" BackColor="#FFFF66" 
                                      AutoCurrencyFormatOnKeyUp="True" AutoPostBack="True" ReadOnly="True">0.00</cc1:mytext>
                                  บาท</td>
                          </tr>
                          <tr>
                              <td class="style22">
                                  อายุการใช้งาน</td>
                              <td class="style8">
                                  <cc1:mytext ID="txtPartakeAge" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" MaxLength="2" Width="35px" BackColor="#FFFF66">0</cc1:mytext>
                                  ปี</td>
                              <td class="style5">
                                  ค่าเสื่อมต่อปี</td>
                              <td class="style19">
                                  <cc1:mytext ID="txtPartakePersent1" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" MaxLength="5" Width="35px" BackColor="#FFFF66" 
                                      AutoPostBack="True">0</cc1:mytext>
                                  %</td>
                              <td class="style14">
                                  ค่าเสื่อมตามสภาพปรับปรุง
                              </td>
                              <td>
                                  <cc1:mytext ID="txtPartakePersent2" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" MaxLength="5" Width="35px" BackColor="#FFFF66" 
                                      AutoPostBack="True">0</cc1:mytext>
                                  %</td>
                          </tr>
                          <tr>
                              <td class="style22">
                                  ค่าเสื่อมตามสภาพเสื่อมโทรม</td>
                              <td class="style8">
                                  <cc1:mytext ID="txtPartakePersent3" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" MaxLength="5" Width="35px" BackColor="#FFFF66" 
                                      AutoPostBack="True">0</cc1:mytext>
                                  %</td>
                              <td class="style5">
                                  รวมค่าเสื่อม</td>
                              <td class="style19">
                                  <cc1:mytext ID="txtPartakeTotalDeteriorate" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" MaxLength="5" Width="35px" BackColor="#FFFF66" 
                                      ReadOnly="True">0</cc1:mytext>
                                  %</td>
                              <td class="style14">
                                  รวมค่าเสื่อมราคา</td>
                              <td>
                                  <cc1:mytext ID="txtPartakePriceTotalDeteriorate" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" Width="110px" BackColor="#FFFF66" ReadOnly="True">0.00</cc1:mytext>
                                  บาท</td>
                          </tr>
                          <tr>
                              <td class="style22">
                                  รายละเอียด&nbsp;</td>
                              <td class="style8" colspan="5">
                                  <asp:TextBox ID="txtPartake_Detail" runat="server" Height="70px" 
                        TextMode="MultiLine" Width="600px" BackColor="#FFFF66"></asp:TextBox>
                                  <asp:Button ID="btnCal" runat="server" Text="Cal" />
                              </td>
                          </tr>
                          <tr style="background-color:#E7E7FF;">
                              <td colspan="6" align="center">
                                  <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                                      AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" 
                                      BorderWidth="1px" CellPadding="2" 
                                      DataKeyNames="Id,Req_Id,Hub_Id,Temp_AID,AID,Partake_Id" 
                                      DataSourceID="sdsPartake_Grid" ForeColor="Black" GridLines="None">
                                      <Columns>
                                          <asp:TemplateField HeaderText="รหัสส่วนควบ" SortExpression="Partake_Id">
                                              <EditItemTemplate>
                                                  <asp:Label ID="Label1" runat="server" Text='<%# Eval("Partake_Id") %>'></asp:Label>
                                              </EditItemTemplate>
                                              <ItemTemplate>
                                                  <asp:Label ID="lblPartake_Id" runat="server" Text='<%# Bind("Partake_Id") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="พื้นที่" SortExpression="PartakeArea">
                                              <EditItemTemplate>
                                                  <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("PartakeArea") %>'></asp:TextBox>
                                              </EditItemTemplate>
                                              <ItemTemplate>
                                                  <asp:Label ID="lblPartakeArea" runat="server" Text='<%# Bind("PartakeArea") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="ราคาต่อหน่วย" 
                                              SortExpression="PartakeUintPrice">
                                              <EditItemTemplate>
                                                  <asp:TextBox ID="TextBox2" runat="server" 
                                                      Text='<%# Bind("PartakeUintPrice") %>'></asp:TextBox>
                                              </EditItemTemplate>
                                              <ItemTemplate>
                                                  <asp:Label ID="lblPartakeUintPrice" runat="server" 
                                                      Text='<%# Bind("PartakeUintPrice", "{0:N}") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="ราคาส่วนควบ" SortExpression="PartakePrice">
                                              <EditItemTemplate>
                                                  <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("PartakePrice") %>'></asp:TextBox>
                                              </EditItemTemplate>
                                              <ItemTemplate>
                                                  <asp:Label ID="lblPartakePrice" runat="server" 
                                                      Text='<%# Bind("PartakePrice", "{0:N}") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="อายุใช้งาน" SortExpression="PartakeAge">
                                              <EditItemTemplate>
                                                  <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("PartakeAge") %>'></asp:TextBox>
                                              </EditItemTemplate>
                                              <ItemTemplate>
                                                  <asp:Label ID="lblPartakeAge" runat="server" Text='<%# Bind("PartakeAge") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="ค่าเสื่อม/ปี" 
                                              SortExpression="PartakePersent1">
                                              <EditItemTemplate>
                                                  <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("PartakePersent1") %>'></asp:TextBox>
                                              </EditItemTemplate>
                                              <ItemTemplate>
                                                  <asp:Label ID="lblPartakePersent1" runat="server" Text='<%# Bind("PartakePersent1") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="ค่าเสื่อมปรับปรุง" 
                                              SortExpression="PartakePersent2">
                                              <EditItemTemplate>
                                                  <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("PartakePersent2") %>'></asp:TextBox>
                                              </EditItemTemplate>
                                              <ItemTemplate>
                                                  <asp:Label ID="lblPartakePersent2" runat="server" Text='<%# Bind("PartakePersent2") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="ค่าเสื่อมตามสภาพ" 
                                              SortExpression="PartakePersent3">
                                              <EditItemTemplate>
                                                  <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("PartakePersent3") %>'></asp:TextBox>
                                              </EditItemTemplate>
                                              <ItemTemplate>
                                                  <asp:Label ID="lblPartakePersent3" runat="server" Text='<%# Bind("PartakePersent3") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="รวมค่าเสื่อม" 
                                              SortExpression="PartakePriceTotalDeteriorate">
                                              <EditItemTemplate>
                                                  <asp:TextBox ID="TextBox8" runat="server" 
                                                      Text='<%# Bind("PartakePriceTotalDeteriorate") %>'></asp:TextBox>
                                              </EditItemTemplate>
                                              <ItemTemplate>
                                                  <asp:Label ID="lblPartakePriceTotalDeteriorate" runat="server" 
                                                      Text='<%# Bind("PartakePriceTotalDeteriorate", "{0:N}") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="รายละเอียด" SortExpression="PartakeDetail">
                                              <EditItemTemplate>
                                                  <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("PartakeDetail") %>'></asp:TextBox>
                                              </EditItemTemplate>
                                              <ItemTemplate>
                                                  <asp:Label ID="lblPartakeDetail" runat="server" Text='<%# Bind("PartakeDetail") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                                      </Columns>
                                      <FooterStyle BackColor="Tan" />
                                      <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                                          HorizontalAlign="Center" />
                                      <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                      <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                      <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                  </asp:GridView>
                              </td>
                          </tr>
                          <tr style="background-color:#E7E7FF;">
                              <td align="center" colspan="6">
                                  <table>
                                      <tr>
                                          <td>
                                              <asp:ImageButton ID="ImageSave" runat="server" Height="35px" 
                                                  ImageUrl="~/Images/Save.jpg" Width="35px" />
                                          </td>
                                          <td>
                                              <asp:Label ID="Label2" runat="server" Text="SAVE"></asp:Label>
                                          </td>
                                          <td>
                                              <asp:ImageButton ID="ImagePrint" runat="server" Height="35px" 
                                                  ImageUrl="~/Images/add_plus2.jpg" Width="35px" />
                                          </td>
                                          <td>
                                              Add New
                                          </td>
                                          <td>
                                              <asp:ImageButton ID="ImgBtnClose" runat="server" Height="35px" 
                                                  ImageUrl="~/Images/Cancel1.jpg" Width="35px" />
                                          </td>
                                          <td>
                                              CLOSE
                                          </td>
                                      </tr>
                                  </table>
                              </td>
                          </tr>
                      </table>
                  </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:SqlDataSource ID="sdsSubCollType" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        
        SelectCommand="SELECT [SubCollType_Name], [MysubColl_ID] FROM [CollType_All] WHERE ([CollType_ID] = @CollType_ID)">
        <SelectParameters>
            <asp:ControlParameter ControlID="hdfColl_Type" Name="CollType_ID" 
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
    
    <asp:SqlDataSource ID="SDSPartake" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Partake_Id], [Partake_Name] FROM [Partake]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsPartake_Grid" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="GET_PRICE3_70_REVIEW_PARTAKE_INFO" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblId" Name="ID" PropertyName="Text" 
                Type="Int32" />
            <asp:ControlParameter ControlID="lblReq_Id" Name="Req_Id" PropertyName="Text" 
                Type="Int32" />
            <asp:ControlParameter ControlID="lblHub_Id" Name="Hub_Id" PropertyName="Text" 
                Type="Int32" />
            <asp:ControlParameter ControlID="lblAID" Name="AID" PropertyName="Text" 
                Type="Int32" />
            <asp:ControlParameter ControlID="lblTemp_AID" Name="TEMP_AID" 
                PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

