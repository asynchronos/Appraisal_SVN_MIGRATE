<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Sent_Appraisal.aspx.vb" Inherits="Sent_Appraisal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">

        .style1
        {
            width: 817px;
        }
        .style2
        {
            width: 100%;
        }
        .bg1
        {
        	background-color:#FFCE40;
        }
        .bg2
        {
        	background-image: url(Images/imagesCAV4910W.jpg);
	        background-repeat: repeat-x; 
        }
        .fstyle
        {
        	font-size:medium;
            color:Blue;
            font-weight:bold;
            
        }
        .fstyle1
        {
        	font-size:small;
            color:Blue;
            font-weight:bold;
        }
        .style3
        {
            width: 137px;
        }
        .style4
        {
            font-size: small;
            color: Blue;
            font-weight: bold;
            width: 269px;
        }
        .style5
        {
            font-size: medium;
            color: Blue;
            font-weight: bold;
            width: 178px;
        }
        .style6
        {
            width: 333px;
        }
        .style7
        {
            width: 137px;
            height: 22px;
        }
        .style8
        {
            width: 333px;
            height: 22px;
        }
        .style9
        {
            height: 22px;
        }
        .style10
        {
            font-size: small;
            color: Blue;
            font-weight: bold;
            width: 269px;
            height: 22px;
        }
        .style11
        {
            font-size: small;
            color: Blue;
            font-weight: bold;
            height: 22px;
        }
        </style>
<script type="text/javascript">
<!--
var updated="";

// http://www.boutell.com/newfaq/creating/windowcenter.html
function wopen(url, name, w, h)
{
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
</script>         
</head>
<body   style="margin-top:0px; margin-left:0px; margin-right:0px; background-image:url(Images/imagesCAMBBQTW.jpg);"  >
    <form id="form1" runat="server">
    <div>
<table border="0" cellspacing="0" cellpadding="0" width="100%" style="height: 80px">
<tr>
	<td align="left" style="background-color:#FFCE40" class="style1">
        	<img alt="" src="Images/logo_bay.gif" 
                style="" /><br />
    </td>
	<td style="height: 50px; background-color:#FFCE40;" valign="top">
        <table class="bg1" width="500px">
            <tr>
                <td class="style5">
                    User ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                                <td>
                                    <asp:Label ID="lblUserID" runat="server" >000001</asp:Label>
                                </td>
                            </tr>
                            <tr >
                                <td class="style5" >
                                    User Name&nbsp;&nbsp; :</td>
                                <td><asp:Label ID="lblUserName" runat="server" >ทดสอบ1</asp:Label></td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    Position&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                                <td><asp:Label ID="lblPostion" runat="server" >สาขาทดสอบ1</asp:Label></td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    DepName/Branchname&nbsp; :</td>
                                <td><asp:Label ID="lblDepart" runat="server" >ชื่อฝ่ายงานทดสอบ</asp:Label></td>
                            </tr>                            
                            <tr>
                                <td class="style5">
                                    Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</td>
                                <td>
                                    <asp:Label ID="lblDate" runat="server" ></asp:Label></td>
                            </tr>
                        </table>
    </td>
</tr>
</table>
        <table class="style2">
            <tr>
                <td class="style7">
                    CIF</td>
                <td class="style8">
                    <asp:TextBox ID="txtCif" runat="server" Width="102px"></asp:TextBox>
                &nbsp;<asp:Button ID="btnSeachCif" runat="server" Text="Search" />
                    <asp:RangeValidator ID="RangeValidator1" runat="server" 
                        ControlToValidate="txtCif" ErrorMessage="ใส่ฉพาะตัวเลขเท่านั้น" 
                        MaximumValue="999999999" MinimumValue="0"></asp:RangeValidator>
                </td>
                <td class="style9">
                    ชื่อสกุล</td>
                <td class="style10">
                    <asp:Label ID="lblCifName" runat="server" Width="250px"></asp:Label>
                </td>
                <td class="style9">
                    สาขา/ฝ่ายงาน</td>
                <td class="style11">
                    <asp:Label ID="lblDepartName" runat="server"></asp:Label>
                </td>
            </tr>    
            <tr>
                <td class="style3">ประเภทการประเมิน</td>
                <td class="style6">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="1">ประเมินใหม่</asp:ListItem>
                        <asp:ListItem Value="2">ทบทวนการประเมิน</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    รหัสผู้ส่งประเมิน</td>
                <td class="style4">
                    <asp:TextBox ID="txtSent_Appraisal_ID" runat="server" Width="102px"></asp:TextBox>
                &nbsp;<asp:Button ID="btnSeachAppraisal_ID" runat="server" Text="Search" />
                </td>
                <td>
                    ชื่อผู้ส่งประเมิน</td>
                <td class="fstyle1">
                    <asp:Label ID="lblSentAppraisal_Name" runat="server" Width="250px"></asp:Label>
                </td>
            </tr>                   
           </table>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDS_Appraisal" BackColor="LightGoldenrodYellow" Width="100%" 
            BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" 
            GridLines="None" ShowFooter="True">
            <FooterStyle BackColor="Tan" />
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox runat="server" ID="cb1" AutoPostBack="true" OnCheckedChanged="cb1_Checked"/> 
                    </HeaderTemplate>
                   <ItemTemplate>
                     <asp:CheckBox runat="server" ID="cb2" />  
                   </ItemTemplate> 
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
             </asp:TemplateField>            
                <asp:TemplateField HeaderText="Cif" SortExpression="CIF">
                    <ItemStyle Width="80px" />
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("CIF") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CIF") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="C ID" SortExpression="COLL_ID">
                    <ItemStyle Width="100px" />
                    <ItemTemplate>
                        <asp:Label ID="lblColl_ID" runat="server" Text='<%# Bind("COLL_ID") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("COLL_ID") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="buildtype" SortExpression="buildtype">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("buildtype") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("buildtype") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ชื่อโครงการ/ตึก/อาคาร/ผู้เช่า" 
                    SortExpression="Buildname_Rentname">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Buildname_Rentname") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" 
                            Text='<%# Bind("Buildname_Rentname") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="โฉนดเลขที่/เลขที่ตั้ง" SortExpression="Chanode_Addno">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Chanode_Addno") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Chanode_Addno") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ที่อยู่สถานที่ตั้ง" SortExpression="Detail1">
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Detail1") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Detail1") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="จังหวัด" SortExpression="PROV_NAME">
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("PROV_NAME") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("PROV_NAME") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>                
                <asp:TemplateField HeaderText=" ขนาด " SortExpression="Detail2">
                    <ItemStyle Width="150px" />
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Detail2") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Detail2") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnUpload" runat="server" Text="Upload File" 
                            OnClientClick='<%# "wopen(""FileUpload.aspx?coll_id=" + Eval("COLL_ID").toString() + """, ""popup"", 500, 300); return false;" %>' 
                            OnLoad="Button_Load" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>

                    </ItemTemplate>
                </asp:TemplateField>                               
            </Columns>
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
        </asp:GridView>
        <p id="messagearea"></p>
           
        <asp:Button ID="btnSave" runat="server" Text="SAVE" Height="30px" 
            Width="117px" />                        
    </div>
    <asp:SqlDataSource ID="SqlDS_Appraisal" runat="server" 
        ConnectionString="<%$ ConnectionStrings:BAYConn %>" 
        SelectCommand="SELECT  COLL_ID, buildtype, Buildname_Rentname, Chanode_Addno, Detail1, Detail2, PROV_NAME, CIF FROM COLL_ID_DISTINCT WHERE (CIF = @CIF)">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtCif" DefaultValue="0" Name="CIF" 
                PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    </form>
</body>
</html>
