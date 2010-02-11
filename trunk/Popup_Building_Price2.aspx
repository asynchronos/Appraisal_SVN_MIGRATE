<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Popup_Building_Price2.aspx.vb" Inherits="Popup_Building_Price2" %>

<%@ Register assembly="Mytextbox" namespace="Mytextbox" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .style21
        {
            height: 24px;
            width: 211px;
        }
        .style27
        {
            height: 24px;
            width: 222px;
        }
        .style25
        {
            height: 24px;
            width: 168px;
        }
            .style17
        {
            height: 24px;
        }
        .style30
        {
            color: #CC0000;
        }
        .style22
        {
            width: 211px;
        }
            .style19
        {
            width: 222px;
        }
        .style26
        {
            width: 168px;
        }
        .style28
        {
            color: #3333CC;
            font-weight: bold;
        }
        .style24
        {
            width: 211px;
            color: #000000;
            }
        .style31
        {
            color: #3333CC;
            font-weight: bold;
            font-size: medium;
        }
    </style>
</head>
<body style="margin-top:0px; margin-left:0px; margin-right:0px;">
    <form id="form1" runat="server">
    <div>
    
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
                <asp:Label ID="lblReq_Id" runat="server" style="font-weight: 700"
                MyClintID="lblReq_Id" CssClass="style30" ></asp:Label>
            </td>
            <td class="style17">
                รหัส Hub</td>
            <td class="style27">
                <asp:Label ID="lblHub_Id" runat="server" style="font-weight: 700" 
                    CssClass="style30"></asp:Label>
            </td>
            <td class="style25">
            </td>
            <td class="style17">

            </td>
        </tr>                  
              <tr>
                <td class="style22">ชนิดหลักประกัน</td>
                    <td colspan="5">
                        <asp:DropDownList ID="DDLSubCollType" runat="server" 
                            DataSourceID="sdsSubCollType" DataTextField="SubCollType_Name"
                            DataValueField="MysubColl_ID" BackColor="#FFFF66">
                        </asp:DropDownList>
                    </td>
              </tr>
              <tr>
                <td class="style22">ปลูกสร้างบนโฉนดเลขที่</td>
                    <td>
                    <asp:TextBox ID="txtChanodeNo" runat="server" BackColor="#FFFF66"
                    MyClintID="txtChanodeNo"></asp:TextBox>
                    &nbsp;</td>
                    <td>ิสิ่งปลูกสร้างกรรมสิทธิ์ของ</td>
                    <td class="style19">
                    <asp:TextBox ID="txtOwnership" runat="server" Width="222px" BackColor="#FFFF66"></asp:TextBox>
                    </td>
                  <td class="style26">&nbsp;</td>
                  <td></td>
              </tr>              
            <tr>
                <td class="style22">
                    สิ่งปลูกสร้าง บ้านเลขที่
                </td>
                <td class="style8">
                    <asp:TextBox ID="txtBuild_No" runat="server"
                    MyClintID="txtBuild_No" BackColor="#FFFF66"></asp:TextBox>
                </td>
                <td class="style5">
                    ตำบล</td>
                <td class="style19">
                <asp:TextBox ID="txtTumbon" runat="server" BackColor="#FFFF66"></asp:TextBox>
                </td>
                <td class="style26">
                    อำเภอ</td>
                <td>
                <asp:TextBox ID="txtAmphur" runat="server" BackColor="#FFFF66"></asp:TextBox>
                </td>
            </tr>
        <tr>
            <td class="style21">
                จังหวัด</td>
            <td class="style17">
                <asp:DropDownList ID="ddlProvince" runat="server" DataSourceID="SDSProvince" 
                    DataTextField="PROV_NAME" DataValueField="PROV_CODE" BackColor="#FFFF66">
                </asp:DropDownList>
            </td>
            <td class="style17">
                    &nbsp;</td>
            <td class="style27">
                    &nbsp;</td>
            <td class="style25">
                    &nbsp;</td>
            <td class="style17">
                    &nbsp;</td>
        </tr>             
            <tr>
                <td class="style28">
                    พื้นที่สิ่งปลูกสร้างทั้งหมด</td>
                <td class="style8">
                    <cc1:mytext ID="txtBuildingArea" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" MaxLength="6" Width="35px" BackColor="#FFFF66" 
                        MyClintID="txtBuildingArea" onkeyup="CalSection_Building(this,event);" >0</cc1:mytext>
                    ตรม.</td>
                <td class="style5">
                    ตรม.(สร้างเสร็จ)</td>
                <td class="style19">
                    <cc1:mytext ID="txtBuildingUnitPrice" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" Width="110px" BackColor="#FFFF66" MyClintID="txtBuildingUnitPrice"
                        onkeyup="CalSection_Building(this,event);" >0.00</cc1:mytext>
                    บาท</td>
                <td class="style26">
                    มูลค่า(สร้างเสร็จ)</td>
                <td>
                    <cc1:mytext ID="txtBuildingPrice" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" Width="110px" BackColor="#FFFF66" MyClintID="txtBuildingPrice" 
                        AutoCurrencyFormatOnKeyUp="True" >0.00</cc1:mytext>
                    บาท</td>
            </tr>
            <tr>
                <td class="style22">
                    เปอร์เซ็นต์สร้างเสร็จ</td>
                <td class="style8">
                    <cc1:mytext ID="txtFinishPercent" runat="server" AllowUserKey="num_Numeric" 
                        Width="35px" BackColor="#FFFF66" MaxLength="3" 
                        EnableTextAlignRight="True" 
                        MyClintID="txtFinishPercent"
                        onkeyup="CalSection_Building(this,event);" >100</cc1:mytext>
                    &nbsp;%</td>
                <td class="style5">
                                        มูลค่า</td>
                <td class="style19">
                    <cc1:mytext ID="txtPriceNotFinish" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" Width="110px" BackColor="#FFFF66" 
                        AutoPostBack="True"
                        MyClintID="txtPriceNotFinish" >0.00</cc1:mytext>
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
                        EnableTextAlignRight="True" MaxLength="2" Width="35px" BackColor="#FFFF66"
                        MyClintID="txtBuildingAge"
                        onkeyup="CalSection_Building(this,event);" >0</cc1:mytext>
                    ปี</td>
                <td class="style5">
                                        ค่าเสื่อมต่อปี</td>
                <td class="style19">
                    <cc1:mytext ID="txtBuildingPersent1" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" MaxLength="5" Width="35px" BackColor="#FFFF66"
                        MyClintID="txtBuildingPersent1"
                        onkeyup="CalSection_Building(this,event);" >0</cc1:mytext>
                    %</td>
                <td class="style26">
                                        ค่าเสื่อมตามสภาพปรับปรุง</td>
                <td>
                    <cc1:mytext ID="txtBuildingPersent2" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" MaxLength="5" Width="35px" BackColor="#FFFF66"
                        MyClintID="txtBuildingPersent2"
                        onkeyup="CalSection_Building(this,event);" >0</cc1:mytext>
                    %</td>
            </tr>
            <tr>
                <td class="style22">
                                        ค่าเสื่อมตามสภาพเสื่อมโทรม</td>
                <td class="style8">
                    <cc1:mytext ID="txtBuildingPersent3" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" MaxLength="5" Width="35px" BackColor="#FFFF66"
                        MyClintID="txtBuildingPersent3"
                        onkeyup="CalSection_Building(this,event);" >0</cc1:mytext>
                    %</td>
                <td class="style5">
                    รวมค่าเสื่อม</td>
                <td class="style19">
                    <cc1:mytext ID="txtBuildingTotalDeteriorate" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" MaxLength="5" Width="35px" BackColor="#FFFF66"
                        MyClintID="txtBuildingTotalDeteriorate" 
                        onkeyup="CalSection_Building(this,event);" >0</cc1:mytext>
                    %</td>
                <td class="style26">
                    รวมค่าเสื่อมราคา</td>
                <td>
                    <cc1:mytext ID="txtBuildingPriceTotalDeteriorate" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" Width="110px" BackColor="#FFFF66"
                        MyClintID="txtBuildingPriceTotalDeteriorate" >0.00</cc1:mytext>
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
                        EnableTextAlignRight="True" MaxLength="5" Width="35px" BackColor="#FFFF66"
                        MyClintID="txtBuildAddArea"
                        onkeyup="CalSection_Building_Addplus(this,event);" >0</cc1:mytext>
                    ตรม.</td>
                <td class="style5">
                    ตรม.(สร้างเสร็จ)</td>
                <td class="style19">
                    <cc1:mytext ID="txtBuildAddUnitPrice" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" Width="110px" BackColor="#FFFF66"
                        MyClintID="txtBuildAddUnitPrice"
                        onkeyup="CalSection_Building_Addplus(this,event);" >0.00</cc1:mytext>
                    บาท</td>
                <td class="style26">
                    มูลค่า(สร้างเสร็จ)</td>
                <td>
                    <cc1:mytext ID="txtBuildAddPrice" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" Width="110px" BackColor="#FFFF66"
                        MyClintID="txtBuildAddPrice" >0.00</cc1:mytext>
                    บาท</td>
            </tr>
            <tr>
                <td class="style22">
                    เปอร์เซ็นต์ส่วนต่อเติมสร้างเสร็จ</td>
                <td class="style8">
                    <cc1:mytext ID="txtFinishPercent1" runat="server" AllowUserKey="num_Numeric" 
                        Width="35px" BackColor="#FFFF66" MaxLength="3" 
                        EnableTextAlignRight="True"
                        MyClintID="txtFinishPercent1"
                        onkeyup="CalSection_Building_Addplus(this,event);" >100</cc1:mytext>
                    %</td>
                <td class="style5">
                                        มูลค่า</td>
                <td class="style19">
                    <cc1:mytext ID="txtPriceNotFinish1" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" Width="110px" BackColor="#FFFF66"
                        MyClintID="txtPriceNotFinish1" >0.00</cc1:mytext>
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
                        EnableTextAlignRight="True" MaxLength="2" Width="35px" BackColor="#FFFF66"
                        MyClintID="txtBuildAddAge"
                        onkeyup="CalSection_Building_Addplus(this,event);" >0</cc1:mytext>
                    ปี</td>
                <td class="style5">
                                        ค่าเสื่อมต่อปี</td>
                <td class="style19">
                    <cc1:mytext ID="txtBuildAddPersent1" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" MaxLength="5" Width="35px" BackColor="#FFFF66"
                        MyClintID="txtBuildAddPersent1"
                        onkeyup="CalSection_Building_Addplus(this,event);" >0</cc1:mytext>
                    %</td>
                <td class="style26">
                    ค่าเสื่อมตามสภาพปรับปรุง 
                </td>
                <td>
                    <cc1:mytext ID="txtBuildAddPersent2" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" MaxLength="5" Width="35px" BackColor="#FFFF66"
                        MyClintID="txtBuildAddPersent2"
                        onkeyup="CalSection_Building_Addplus(this,event);" >0</cc1:mytext>
                    %</td>
            </tr>
            <tr>
                <td class="style22">
                                        ค่าเสื่อมตามสภาพเสื่อมโทรม</td>
                <td class="style8">
                    <cc1:mytext ID="txtBuildAddPersent3" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" MaxLength="5" Width="35px" BackColor="#FFFF66" 
                        MyClintID="txtBuildAddPersent3"
                        onkeyup="CalSection_Building_Addplus(this,event);" >0</cc1:mytext>
                    %</td>
                <td class="style5">
                                        รวมค่าเสื่อม</td>
                <td class="style19">
                    <cc1:mytext ID="txtBuildAddTotalDeteriorate" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" MaxLength="5" Width="35px" BackColor="#FFFF66"
                        MyClintID="txtBuildAddTotalDeteriorate" >0</cc1:mytext>
                    %</td>
                <td class="style26">
                    รวมค่าเสื่อมราคา</td>
                <td>
                    <cc1:mytext ID="txtBuildAddPriceTotalDeteriorate" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" Width="110px" BackColor="#FFFF66"
                        MyClintID="txtBuildAddPriceTotalDeteriorate" >0.00</cc1:mytext>
                    บาท</td>
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
                <td class="style22">
                    เป็นเงิน(ราคาตลาด)</td>
                <td class="style8">
                    <cc1:mytext ID="txtPriceTotal1" runat="server" AllowUserKey="num_Numeric" AutoCurrencyFormatOnKeyUp="True"
                        EnableTextAlignRight="True" 
                        BackColor="#FFFF66">0</cc1:mytext>
                &nbsp;บาท</td>
                <td class="style5" id="z">
                    &nbsp;</td>
                <td class="style19">
                    &nbsp;</td>
                <td class="style26">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style28" colspan="6">
                                        มาตรฐาน
                <asp:DropDownList ID="ddlStandard" runat="server" DataSourceID="sdsStandard" 
                    DataTextField="Standard_Name" DataValueField="Standard_Id" BackColor="#FFFF66">
                </asp:DropDownList>
                </td>
            </tr>
                <tr style="background-color:#E7E7FF;">
                    <td colspan="6" align="center" class="style31">
                        ส่วนควบ</td>
                </tr>            
        </table> 
    
    </div>
                                  <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                                      AutoGenerateColumns="False" 
        BackColor="LightGoldenrodYellow" BorderColor="Tan" 
                                      BorderWidth="1px" CellPadding="2" 
                                      DataKeyNames="Id,Req_Id,Hub_Id,Temp_AID,Partake_Id" 
                                      DataSourceID="sdsPartake_Grid" 
        ForeColor="Black" GridLines="None" 
                                      Width="100%" style="font-size: small">
                                      <Columns>
                                          <asp:TemplateField HeaderText="รหัสส่วนควบ" SortExpression="Partake_Id">
                                              <EditItemTemplate>
                                                  <asp:HiddenField ID="hdf_ID" runat="server" Value='<%# Eval("ID") %>' />                  
                                                  <asp:HiddenField ID="hdfReq_Id" runat="server" Value='<%# Eval("Req_Id") %>' />
                                                  <asp:HiddenField ID="hdfHub_Id" runat="server" Value='<%# Eval("Hub_Id") %>' />
                                                  <asp:HiddenField ID="hdfTemp_AID" runat="server" Value='<%# Eval("Temp_AID") %>' />
                                                  <asp:Label ID="Label1" runat="server" Text='<%# Eval("Partake_Id") %>'></asp:Label>
                                              </EditItemTemplate>
                                              <ItemTemplate>
                                                  <asp:Label ID="lblPartake_Id" runat="server" Text='<%# Bind("Partake_Id") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="ชื่อส่วนควบ" SortExpression="Partake_Name">
                                              <ItemTemplate>
                                                  <asp:Label ID="lblPartakeName" runat="server" Text='<%# Bind("Partake_Name") %>'></asp:Label>
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
                                      </Columns>
                                      <FooterStyle BackColor="Tan" />
                                      <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                                          HorizontalAlign="Center" />
                                      <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                      <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                      <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                  </asp:GridView>
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
Order by PROV_NAME">
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
<asp:HiddenField ID="hhhfSubCollType" runat="server" />
    <asp:SqlDataSource ID="sdsPartake_Grid" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="GET_PRICE2_70_PARTAKE_INFO" 
        SelectCommandType="StoredProcedure" 
        DeleteCommand="DELETE_PRICE2_70_PARTAKE" DeleteCommandType="StoredProcedure">
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
        <DeleteParameters>
            <asp:Parameter Name="Req_Id" Type="Int32" />
            <asp:Parameter Name="Hub_Id" Type="Int32" />
            <asp:Parameter Name="Id" Type="Int32" />
            <asp:Parameter Name="Temp_AID" Type="Int32" />
            <asp:Parameter Name="Partake_Id" Type="Int32" />
        </DeleteParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsSubCollType" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        
        SelectCommand="SELECT [SubCollType_Name], [MysubColl_ID] FROM [CollType_All] WHERE ([CollType_ID] = @CollType_ID)">
        <SelectParameters>
            <asp:Parameter DefaultValue="70" Name="CollType_ID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    </form>
</body>
</html>
