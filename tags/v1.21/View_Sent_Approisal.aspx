<%@ Page Language="VB" AutoEventWireup="false" CodeFile="View_Sent_Approisal.aspx.vb" Inherits="View_Sent_Approisal" %>

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
            width: 98px;
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
            width: 350px;
        }
        .style7
        {
            width: 98px;
            height: 22px;
        }
        .style8
        {
            width: 350px;
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
        .style12
        {
            height: 22px;
            width: 122px;
        }
        .style13
        {
            width: 122px;
        }
        </style>    

    <script language="javascript" type="text/javascript">
        function expandcollapse(obj,row)
    {
    try{
        var div = document.getElementById(obj);
        var img = document.getElementById('img' + obj);
        
        if (div.style.display == "none")
        {
            div.style.display = "block";
            if (row == 'alt')
            {
                img.src = "Images/minus.gif";
            }
            else
            {
                img.src = "Images/minus.gif";
            }
            img.alt = "Close to view other CIF";
        }
        else
        {
            div.style.display = "none";
            if (row == 'alt')
            {
                img.src = "Images/plus.gif";
            }
            else
            {
                img.src = "Images/plus.gif";
            }
            img.alt = "Expand to show Coll ID";
        }
        }catch(err){
            alert(err);
        }
    } 

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
    'status=no, toolbar=no, scrollbars=yes, resizable=no', 'title=no', 'resizable=no', 'directories=no', 'status=no');
  // Just in case width and height are ignored
  win.resizeTo(w, h);
  // Just in case left and top are ignored
  win.moveTo(wleft, wtop);
  win.focus();
}   
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
    
    </div>
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
                <td class="style12">
                    สาขา/ฝ่ายงาน</td>
                <td class="style11">
                    <asp:Label ID="lblDepartName" runat="server"></asp:Label>
                </td>
            </tr>    
            <tr>
                <td class="style3">&nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style13">
                    &nbsp;</td>
                <td class="fstyle1">
                    &nbsp;</td>
            </tr>                   
           </table>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="Q_ID" DataSourceID="SqlDataSource1" 
            EmptyDataText="There are no data records to display." Width='100%' 
            BackColor="LightGoldenrodYellow" 
            BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" 
            GridLines="None" ShowFooter="True" PageSize="15">
            <FooterStyle BackColor="Tan" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href="javascript:expandcollapse('div<%# Eval("Q_ID") %>', 'one');">
                            <img id="imgdiv<%# Eval("Q_ID") %>" alt="Click to show/hide Queue for Appraisal <%# Eval("Q_ID") %>"
                                width="9px" src="Images/plus.gif" />
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Queus No.">
                    <ItemTemplate>
                        <asp:Label ID="lblQid" runat="server" Text='<%# Bind("Q_ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>                          
                <asp:TemplateField HeaderText="Cif">
                    <ItemTemplate>
                        <asp:Label ID="lblCif" runat="server" Text='<%# Bind("Cif") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cif Name">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("CifName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="ชื่อผู้ส่งประเมิน">
                    <ItemTemplate>
                        <asp:Label ID="LabelEmp_Name" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="สถานะการประเมิน">
                    <ItemTemplate>
                        <asp:Label ID="LabelStatus_Name" runat="server" Text='<%# Bind("Status_Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="วันที่ส่งประเมิน">
                    <ItemTemplate>
                        <asp:Label ID="LabelCreate_Date" runat="server" Text='<%# Bind("Create_Date") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="รายละเอียดการดำเนินการ">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlOperation" runat="server" OnPreRender="DDL_Load" ></asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:Button ID="btnOperation1" runat="server" Text="ดำเนินการ" CommandName="Select"/>
                    </ItemTemplate>
                </asp:TemplateField>                                                                            
                <asp:TemplateField>
                    <ItemTemplate>
                        <tr>
                            <td colspan="100%">
                                <div id="div<%# Eval("Q_ID") %>" style="display:none;position: relative; 
                                    left: 15px; overflow: auto; width: 97%">
                                    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                                        AllowSorting="True" AutoGenerateColumns="False" BackColor="#EEEEDD" 
                                        BorderColor="#0083C1" BorderStyle="Double" DataKeyNames="Q_ID" 
                                        Font-Names="Verdana" Font-Size="Small" GridLines="None" 
                                        OnPageIndexChanging="GridView2_PageIndexChanging" 
                                        OnRowCreated="GridView2_RowCreated" OnSorting="GridView2_Sorting" 
                                        OnRowCommand="GridView2_RowCommand" 
                                        ShowFooter="True" Width="100%">
                                        <HeaderStyle BackColor="#0083C1" ForeColor="White" />
                                        <FooterStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="COLL ID">
                                                <ItemStyle VerticalAlign="Middle" Width="70px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblcoll_id" runat="server" Text='<%# Eval("coll_id") %>'  ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ที่ตั้ง ของทรัพย์สิน">
                                                <ItemStyle VerticalAlign="Middle" Width="350px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDetail1" runat="server" Text='<%# Eval("Detail1") %>'  ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField> 
                                            <asp:TemplateField HeaderText="จังหวัดที่ตั้งทรัพย์สิน">
                                                <ItemStyle VerticalAlign="Middle" Width="100px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProv_Name" runat="server" Text='<%# Eval("Prov_Name") %>'  ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>                                                                                           
                                            <asp:TemplateField HeaderText="ขนาด">
                                                <ItemStyle VerticalAlign="Middle" Width="200px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDetail2" runat="server" Text='<%# Eval("Detail2") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>                                            
                                            <asp:TemplateField HeaderText="แสดงรูปภาพ">
                                            <ItemStyle VerticalAlign="Middle" Width="50px" />
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/view.jpg" ToolTip="Select" OnClientClick='<%# "wopen(""View_Picture_Appraisal.aspx?coll_id=" + Eval("coll_id").toString() + """, ""popup"", 1024, 768); return false;" %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>                                                                                       
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:TemplateField>             
            </Columns>
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
        </asp:GridView>
    <asp:SqlDataSource ID="REQUEST_APPRAISAL_LIST_BY_HUB" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        
        
        
        SelectCommand="SELECT [Q_ID], [Cif], [CifName], [Emp_Name], [Status_ID], [Status_Name], [Create_Date] FROM [View_Sented_Approisal] ORDER BY [Q_ID]">
    </asp:SqlDataSource>
    </form>
</body>
</html>
