<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_Price3_70_Partake.aspx.vb" Inherits="Appraisal_Price3_70_Partake" %>
<%@ Register assembly="Mytextbox" namespace="Mytextbox" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .style22
        {
            width: 211px;
        }
        .style23
        {
            color: #3333CC;
            font-weight: 700;
        }
        .style24
        {
            color: #3333CC;
            font-size: medium;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<br />
<br />
<p class="style23">เพิ่มส่วนควบ</p>
    <asp:HiddenField ID="hdfAID" runat="server" />
    <asp:HiddenField ID="hdfCif" runat="server" />

              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                  <ContentTemplate>
                      <table width="100%" 
        style="background-color: #B5C7DE; font-size: small;">
                          <tr>
                              <td>
                                  เลขลำดับ</td>
                              <td>
                                  <asp:Label ID="lblId" runat="server" style="font-weight: 700; color: #FF0000;"></asp:Label>
                              </td>
                              <td>
                                  Temp AID</td>
                              <td>
                                  <asp:Label ID="lblTemp_AID" runat="server" 
                    style="font-weight: 700; color: #FF0000;"></asp:Label>
                              </td>
                              <td>
                                  &nbsp;</td>
                              <td>
                                  &nbsp;</td>
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
                              <td>
                                  &nbsp;</td>
                              <td>
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td>
                                  ชนิดส่วนควบ</td>
                              <td>
                                  <asp:DropDownList ID="ddlPartaked" runat="server" DataSourceID="SDSPartake" 
                                      DataTextField="Partake_Name" DataValueField="Partake_Id">
                                  </asp:DropDownList>
                              </td>
                              <td>
                                  เลขที่</td>
                              <td >
                                  <asp:TextBox ID="txtBuilding_No" runat="server" ReadOnly="True"></asp:TextBox>
                              </td>
                              <td>
                                  &nbsp;</td>
                              <td>
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td>
                                  พื้นที่ส่วนควบ</td>
                              <td>
                                  <cc1:mytext ID="txtPartakeArea" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" MaxLength="6" Width="35px" BackColor="#FFFF66" 
                                      AutoPostBack="True">0</cc1:mytext>
                                  ตรม.</td>
                              <td>
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
                                      AutoCurrencyFormatOnKeyUp="True" AutoPostBack="True" ReadOnly="True" 
                                      Enabled="False">0.00</cc1:mytext>
                                  บาท</td>
                          </tr>
                          <tr>
                              <td class="style22">
                                  เปอร์เซ็นต์ส่วนควบสร้างเสร็จ</td>
                              <td class="">
                                  <cc1:mytext ID="txtFinishPercent" runat="server" AllowUserKey="num_Numeric" 
                                      AutoPostBack="True" BackColor="#FFFF66" EnableTextAlignRight="True" 
                                      MaxLength="3" Width="35px">100</cc1:mytext>
                                  %</td>
                              <td class="">
                                  มูลค่า</td>
                              <td class="">
                                  <cc1:mytext ID="txtPriceNotFinish" runat="server" AllowUserKey="num_Numeric" 
                                      AutoPostBack="True" BackColor="#FFFF66" EnableTextAlignRight="True" 
                                      ReadOnly="True" Width="110px">0.00</cc1:mytext>
                                  บาท</td>
                              <td class="">
                                  &nbsp;</td>
                              <td>
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="style22">
                                  อายุการใช้งาน</td>
                              <td class="">
                                  <cc1:mytext ID="txtPartakeAge" runat="server" AllowUserKey="num_Numeric" 
                                      AutoPostBack="True" BackColor="#FFFF66" EnableTextAlignRight="True" 
                                      MaxLength="5" Width="35px">0</cc1:mytext>
                                  ปี</td>
                              <td class="">
                                  ค่าเสื่อมต่อปี</td>
                              <td class="">
                                  <cc1:mytext ID="txtPartakePersent1" runat="server" AllowUserKey="num_Numeric" 
                                      AutoPostBack="True" BackColor="#FFFF66" EnableTextAlignRight="True" 
                                      MaxLength="5" Width="35px">0</cc1:mytext>
                                  %</td>
                              <td class="">
                                  ค่าเสื่อมตามสภาพปรับปรุง
                              </td>
                              <td>
                                  <cc1:mytext ID="txtPartakePersent2" runat="server" AllowUserKey="num_Numeric" 
                                      AutoPostBack="True" BackColor="#FFFF66" EnableTextAlignRight="True" 
                                      MaxLength="5" Width="35px">0</cc1:mytext>
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
                        EnableTextAlignRight="True" Width="110px" BackColor="#FFFF66" ReadOnly="True" 
                                      Enabled="False">0.00</cc1:mytext>
                                  บาท</td>
                          </tr>
                          <tr>
                              <td class="style22">
                                  รายละเอียด&nbsp;</td>
                              <td class="style8" colspan="5">
                                  <asp:TextBox ID="txtPartake_Detail" runat="server" Height="70px" 
                        TextMode="MultiLine" Width="600px" BackColor="#FFFF66"></asp:TextBox>
                                  <asp:Button ID="btnCal" runat="server" Text="Cal" Visible="False" />
                              </td>
                          </tr>
                          <tr style="background-color:#E7E7FF;">
                              <td colspan="6" align="center">
                                  <table>
                                      <tr>
                                          <td>
                                              <asp:ImageButton ID="ImageSave" runat="server" Height="35px" 
                                                  ImageUrl="~/Images/Save.jpg" Width="35px" />
                                          </td>
                                          <td>
                                              <asp:Label ID="Label2" runat="server" Text="SAVE"></asp:Label>
                                              &nbsp;</td>
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
                                  <asp:Label ID="lblMessage" runat="server" 
                                      style="font-weight: 700; color: #FF0000; font-size: medium;"></asp:Label>
                                  <br />
                                  <br />
                                  <span class="style24"><b>รายละเอียดส่วนควบราคาที่ 3</b></span><asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                                      AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" 
                                      BorderWidth="1px" CellPadding="2" 
                                      DataKeyNames="Id,Req_Id,Hub_Id,Temp_AID" 
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
                                          <asp:TemplateField HeaderText="เปอร์เซ็นต์สร้างเสร็จ" 
                                              SortExpression="PartakeUintPrice">
                                              <ItemTemplate>
                                                  <asp:Label ID="lblPercentFinish" runat="server" 
                                                      Text='<%# Bind("PercentFinish", "{0:N}") %>'></asp:Label>
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
                                  <br />
                                  <span class="style24"><b>รายละเอียดส่วนควบราคาที่ 2</b></span><asp:GridView 
                                      ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False" 
                                      BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                                      CellPadding="2" DataKeyNames="Id,Req_Id,Hub_Id,Temp_AID" 
                                      DataSourceID="sdsPartake2_Grid" ForeColor="Black" GridLines="None" >
                                      <Columns>
                                          <asp:TemplateField HeaderText="รหัสส่วนควบ" SortExpression="Partake_Id">
                                              <EditItemTemplate>
                                                  <asp:Label ID="Label3" runat="server" Text='<%# Eval("Partake_Id") %>'></asp:Label>
                                              </EditItemTemplate>
                                              <ItemTemplate>
                                                  <asp:Label ID="lblPartake_Id0" runat="server" Text='<%# Bind("Partake_Id") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="พื้นที่" SortExpression="PartakeArea">
                                              <EditItemTemplate>
                                                  <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("PartakeArea") %>'></asp:TextBox>
                                              </EditItemTemplate>
                                              <ItemTemplate>
                                                  <asp:Label ID="lblPartakeArea0" runat="server" 
                                                      Text='<%# Bind("PartakeArea") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="เปอร์เซ็นต์สร้างเสร็จ" 
                                              SortExpression="PartakeUintPrice">
                                              <ItemTemplate>
                                                  <asp:Label ID="lblPercentFinish0" runat="server" 
                                                      Text='<%# Bind("PercentFinish", "{0:N}") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="ราคาต่อหน่วย" SortExpression="PartakeUintPrice">
                                              <EditItemTemplate>
                                                  <asp:TextBox ID="TextBox11" runat="server" 
                                                      Text='<%# Bind("PartakeUintPrice") %>'></asp:TextBox>
                                              </EditItemTemplate>
                                              <ItemTemplate>
                                                  <asp:Label ID="lblPartakeUintPrice0" runat="server" 
                                                      Text='<%# Bind("PartakeUintPrice", "{0:N}") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="ราคาส่วนควบ" SortExpression="PartakePrice">
                                              <EditItemTemplate>
                                                  <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("PartakePrice") %>'></asp:TextBox>
                                              </EditItemTemplate>
                                              <ItemTemplate>
                                                  <asp:Label ID="lblPartakePrice0" runat="server" 
                                                      Text='<%# Bind("PartakePrice", "{0:N}") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="อายุใช้งาน" SortExpression="PartakeAge">
                                              <EditItemTemplate>
                                                  <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("PartakeAge") %>'></asp:TextBox>
                                              </EditItemTemplate>
                                              <ItemTemplate>
                                                  <asp:Label ID="lblPartakeAge0" runat="server" Text='<%# Bind("PartakeAge") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="ค่าเสื่อม/ปี" SortExpression="PartakePersent1">
                                              <EditItemTemplate>
                                                  <asp:TextBox ID="TextBox14" runat="server" 
                                                      Text='<%# Bind("PartakePersent1") %>'></asp:TextBox>
                                              </EditItemTemplate>
                                              <ItemTemplate>
                                                  <asp:Label ID="lblPartakePersent4" runat="server" 
                                                      Text='<%# Bind("PartakePersent1") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="ค่าเสื่อมปรับปรุง" 
                                              SortExpression="PartakePersent2">
                                              <EditItemTemplate>
                                                  <asp:TextBox ID="TextBox15" runat="server" 
                                                      Text='<%# Bind("PartakePersent2") %>'></asp:TextBox>
                                              </EditItemTemplate>
                                              <ItemTemplate>
                                                  <asp:Label ID="lblPartakePersent5" runat="server" 
                                                      Text='<%# Bind("PartakePersent2") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="ค่าเสื่อมตามสภาพ" 
                                              SortExpression="PartakePersent3">
                                              <EditItemTemplate>
                                                  <asp:TextBox ID="TextBox16" runat="server" 
                                                      Text='<%# Bind("PartakePersent3") %>'></asp:TextBox>
                                              </EditItemTemplate>
                                              <ItemTemplate>
                                                  <asp:Label ID="lblPartakePersent6" runat="server" 
                                                      Text='<%# Bind("PartakePersent3") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="รวมค่าเสื่อม" 
                                              SortExpression="PartakePriceTotalDeteriorate">
                                              <EditItemTemplate>
                                                  <asp:TextBox ID="TextBox17" runat="server" 
                                                      Text='<%# Bind("PartakePriceTotalDeteriorate") %>'></asp:TextBox>
                                              </EditItemTemplate>
                                              <ItemTemplate>
                                                  <asp:Label ID="lblPartakePriceTotalDeteriorate0" runat="server" 
                                                      Text='<%# Bind("PartakePriceTotalDeteriorate", "{0:N}") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="รายละเอียด" SortExpression="PartakeDetail">
                                              <EditItemTemplate>
                                                  <asp:TextBox ID="TextBox18" runat="server" Text='<%# Bind("PartakeDetail") %>'></asp:TextBox>
                                              </EditItemTemplate>
                                              <ItemTemplate>
                                                  <asp:Label ID="lblPartakeDetail0" runat="server" 
                                                      Text='<%# Bind("PartakeDetail") %>'></asp:Label>
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
                                  &nbsp;</td>
                          </tr>
                      </table>
                  </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    
    <asp:SqlDataSource ID="SDSPartake" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Partake_Id], [Partake_Name] FROM [Partake]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsPartake_Grid" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="GET_PRICE3_70_PARTAKE_INFO" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblId" Name="ID" PropertyName="Text" 
                Type="Int32" />
            <asp:ControlParameter ControlID="lblReq_Id" Name="Req_Id" PropertyName="Text" 
                Type="Int32" />
            <asp:ControlParameter ControlID="lblHub_Id" Name="Hub_Id" PropertyName="Text" 
                Type="Int32" />
            <asp:ControlParameter ControlID="lblTemp_AID" Name="TEMP_AID" 
                PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsPartake2_Grid" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="GET_PRICE2_70_PARTAKE_INFO" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblId" Name="ID" PropertyName="Text" 
                Type="Int32" />
            <asp:ControlParameter ControlID="lblReq_Id" Name="Req_Id" PropertyName="Text" 
                Type="Int32" />
            <asp:ControlParameter ControlID="lblHub_Id" Name="Hub_Id" PropertyName="Text" 
                Type="Int32" />
            <asp:ControlParameter ControlID="lblTemp_AID" Name="TEMP_AID" 
                PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

