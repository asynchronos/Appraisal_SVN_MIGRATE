<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Appraisal_Form.aspx.vb" Inherits="Appraisal_Form_Appraisal_Form" %>

<%@ Register src="../MyMenu.ascx" tagname="MyMenu" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
		<style type="text/css">
		.style1
		{
			width: 914px;
		}
		.style2
		{
			width: 95%;
		}
		.fstyle
		{
			font-size: medium;
			color: Blue;
			font-weight: bold;
		}
		.fstyle1
		{
			font-size: small;
			color: Blue;
			font-weight: bold;
		}
		.Fcolor
		{                color: #FF0000;
			}
			.style5
			{
				width: 437px;
			}
			.style7
			{
				width: 256px;
			}
			.style8
			{
				width: 113px;
			}
		    .style31
        {
            width: 100%;
        }
            .style32
        {
            width: 40px;
        }
            .style33
            {
                color: #6600FF;
                font-weight: bold;
            }
		    .style34
            {
                width: 101px;
            }
            .style35
            {
                width: 109px;
            }
		</style>
	<title></title>
	
    <script type="text/javascript">

        function expandcollapse(obj, row) {
            try {
                var div = document.getElementById(obj);
                var img = document.getElementById('img' + obj);

                if (div.style.display == "none") {
                    div.style.display = "block";
                    if (row == 'alt') {
                        img.src = "../Images/minus.gif";
                    }
                    else {
                        img.src = "../Images/minus.gif";
                    }
                    img.alt = "Close to view other CIF";
                }
                else {
                    div.style.display = "none";
                    if (row == 'alt') {
                        img.src = "../Images/plus.gif";
                    }
                    else {
                        img.src = "../Images/plus.gif";
                    }
                    img.alt = "Expand to show Coll ID";
                }
            } catch (err) {
                alert(err);
            }
        } 
        
        
        var updated="";

        // http://www.boutell.com/newfaq/creating/windowcenter.html
        function wopen(url, name, w, h)
        {
           //var chkbox = document.getElementById(
            //alert(chkbox)
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

      function link_url(url, name, w, h, ctl, regId, hubId) {
          //alert("1");
          var full_url = create_url(url, regId, hubId);
          
          wopen_checked(full_url,name,w,h,ctl);
      }

      function wopen_checked(url, name, w, h, ctl) {
          var myCheck = document.getElementById(ctl);
          //alert(myCheck.id);
          myCheck.checked = true
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

      function create_url(url, requestId, hubId) {
          //alert(document.getElementById(requestId).innerText);
          var requestid_value = document.getElementById(requestId).innerText;
          var hubId_value = document.getElementById(hubId).innerText;

          return url + '?req_id=' + requestid_value + '&hub_id=' + hubId_value;
      }
    </script>
</head>
<body style="margin-top:0px; margin-left:0px; margin-right:0px; background-image:url(../Images/imagesCAMBBQTW.jpg)">
	<form id="form1" runat="server">
	<div>
		<asp:ScriptManager ID="ScriptManager1" runat="server">
		</asp:ScriptManager>
<table border="0" cellspacing="0" cellpadding="0" width="100%" style="height: 80px">
			<tr>
				<td align="left" style="background-color: #FFCE40" class="style1">
					<img alt="" src="../Images/logo_bay.gif" />
				</td>
				<td style="height: 50px; background-color: #FFCE40;" valign="top">
					<table class="style2">
						<tr>
							<td class="fstyle">
								User ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
							</td>
							<td>
								<asp:Label ID="lblUserID" runat="server"></asp:Label>
							</td>
						</tr>
						<tr>
							<td class="fstyle">
								User Name&nbsp;&nbsp; :
							</td>
							<td>
								<asp:Label ID="lblUserName" runat="server"></asp:Label>
							</td>
						</tr>
						<tr>
							<td class="fstyle">
								Position&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
							</td>
							<td>
								<asp:Label ID="lblPostion" runat="server"></asp:Label>
							</td>
						</tr>
						<tr>
							<td class="fstyle">
								Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:
							</td>
							<td>
								<asp:Label ID="lblDate" runat="server"></asp:Label>
							</td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
	</div>
    <table width="100%">
				<tr>
					<td class="style5" valign="top"> 
				<table class="style2" style="border-color:Blue; border-width:15px; width:441px">
				<tr>
				<td class="style8">เลขที่คำขอ</td>
				<td class="style7">
					<asp:Label CssClass="Fcolor" ID="lblRequestID" runat="server" Font-Bold="True" 
						Font-Size="Large" BackColor="#00FFCC"></asp:Label>
					</td>
				</tr>
				<tr>
				<td class="style8">&nbsp;</td>
				<td class="style7">
					<asp:Button ID="bntRequest_ID" runat="server" Text="ออกเลขคำขอประเมิน" />
					</td>
				</tr>				
				<tr>
					<td style="text-align:left;" class="style8">
						ประเภทคำขอ</td>
					<td style="text-align:left;" class="style7">
					<asp:RadioButtonList ID="RadioButtonList1" runat="server" 
						RepeatDirection="Horizontal" AutoPostBack="True">
						<asp:ListItem Selected="True" Value="1">ประเมินใหม่</asp:ListItem>
						<asp:ListItem Value="2">ทบทวนการประเมิน</asp:ListItem>
					</asp:RadioButtonList>
					</td>
				</tr>                
				<tr>
					<td style="text-align:left;" class="style8">
					CIF</td>
					<td style="text-align:left;" class="style7">
						<asp:TextBox ID="TxtCif" runat="server" MaxLength="9" Width="90px"></asp:TextBox>
					&nbsp;</td>
				</tr>
				<tr>
					<td style="text-align:left;" class="style8">
						คำนำหน้า</td>
					<td style="text-align:left;" class="style7">
						<asp:DropDownList ID="ddlTitle" runat="server" DataSourceID="SDSTitle" 
							DataTextField="TITLE_NAME" DataValueField="TITLE_CODE">
						</asp:DropDownList>
					</td>
				</tr>
				<tr>
					<td style="text-align:left;" class="style8">
						ชื่อผู้ขอประเมิน</td>
					<td style="text-align:left;" class="style7">
						<asp:TextBox ID="TxtCifName" runat="server" Width="180px"></asp:TextBox>
					</td>
				</tr>                
				<tr>
					<td style="text-align:left;" class="style8">
						นามสกุล</td>
					<td style="text-align:left;" class="style7">
						<asp:TextBox ID="TxtCifLastName" runat="server" Width="180px"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td style="text-align:left;" class="style8">
						<asp:Label ID="lableAID" runat="server" Text="AID"></asp:Label>
                    </td>
					<td style="text-align:left;" class="style7">
	
						<asp:TextBox ID="txtAID" runat="server"></asp:TextBox>
                    </td>
				</tr>
				<tr>
					<td style="text-align:left;" class="style8">
					&nbsp;
					</td>
					<td style="text-align:left;" class="style7">
	
						&nbsp;</td>
				</tr>
				<tr>
					<td colspan="2">
						<asp:Label ID="lblMessage" runat="server" 
							style="color: #FF0000; font-weight: 700"></asp:Label>
					</td>
				</tr>
			</table>
					</td>
					
					<td valign="top" align="left">
					<asp:Label ID="HeaderHub" runat="server" Text="Label" 
							style="font-weight: 700; text-decoration: underline; color: #6600FF">รายชื่อ ศูนย์</asp:Label>
    
        <asp:GridView ID="GridView_HubList" runat="server" AutoGenerateColumns="False" 
            CellPadding="2" DataKeyNames="HUB_ID" DataSourceID="sdsHub" 
            ForeColor="Black" GridLines="Horizontal" BackColor="LightGoldenrodYellow" 
            BorderColor="Tan" BorderWidth="1px" ShowFooter="True">
            <FooterStyle BackColor="Tan" />
            <Columns>
                            <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox runat="server" ID="cb1" AutoPostBack="true" 
                            OnCheckedChanged="cb1_Checked"/> 
                    </HeaderTemplate>
                   <ItemTemplate>
                     <asp:CheckBox runat="server" ID="cb2"/>  
                   </ItemTemplate> 
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
             </asp:TemplateField> 
                            <asp:TemplateField HeaderText="HUB_ID" SortExpression="HUB_ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblHUB_ID" runat="server" Text='<%# Bind("HUB_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="HUB NAME" SortExpression="HUB_NAME">
                                <ItemStyle Width="300px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblHUB_NAME" runat="server" Text='<%# Bind("HUB_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
								    <ItemTemplate>
								            <asp:button runat="server" id="AddFileButton" onload="Button_Load" Text="Add File"
                                            type="button" value="Add File" />
								    </ItemTemplate>
							</asp:TemplateField>
               							
            </Columns>
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
        </asp:GridView>
                        <table class="style31">
                            <tr>
                                <td class="style32">
                        <asp:ImageButton ID="imgBtnSave" runat="server" ImageUrl="~/Images/Save.jpg" Height="33px" 
                                        Width="35px" />
                                </td>
                                   <td class="style33">SAVE</td>
                            </tr>
                        </table>
					</td>
				</tr>
			</table>
	<br />
	
	<table class="style31">
        <tr>
            <td>
                <table class="style31">
                    <tr>
                        <td class="style34">
                            ค้นหา</td>
                        <td class="style35">
						<asp:TextBox ID="TxtCif0" runat="server" MaxLength="9" Width="90px"></asp:TextBox>
					    </td>
                        <td>
					<asp:ImageButton ID="ImgBtFind0" runat="server" ImageUrl="~/Images/book_blue_view.png" 
							Height="25px" Width="28px" />
								</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="Req_Id" DataSourceID="sdsRequest_Appraisal_List" 
            EmptyDataText="There are no data records to display." Width='100%' 
            BackColor="LightGoldenrodYellow" 
            BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" 
            GridLines="None" ShowFooter="True" PageSize="15">
            <FooterStyle BackColor="Tan" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href="javascript:expandcollapse('div<%# Eval("Req_ID") %>', 'one');">
                            <img id="imgdiv<%# Eval("Req_Id") %>" alt="Click to show/hide Queue for Appraisal <%# Eval("Req_Id") %>"
                                width="9px" src="../Images/plus.gif" />
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="เลขคำขอประเมิน">
                    <ItemStyle Width="150px" />
                    <ItemTemplate>
                        <asp:Label ID="lblReq_Id" runat="server" Text='<%# Bind("Req_ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>                                           
                <asp:TemplateField HeaderText="Cif">
                <ItemStyle Width="80px" />
                    <ItemTemplate>
                        <asp:Label ID="lblCif" runat="server" Text='<%# Bind("Cif") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cif Name">
                <ItemStyle Width="200px" />
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("CifName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="ชื่อผู้ส่งประเมิน">
                <ItemStyle Width="200px" />
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
                 <asp:TemplateField>
                    <ItemTemplate>
                        <tr>
                            <td colspan="100%">
                                <div id="div<%# Eval("Req_ID") %>" style="display:none;position: relative; 
                                    left: 15px; overflow: auto; width: 97%">
                                    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                                        AllowSorting="True" AutoGenerateColumns="False" BackColor="#EEEEDD" 
                                        BorderColor="#0083C1" BorderStyle="Double" DataKeyNames="Req_ID" 
                                        Font-Names="Verdana" Font-Size="Small" GridLines="None" 
                                        OnPageIndexChanging="GridView2_PageIndexChanging" 
                                        OnSorting="GridView2_Sorting"
                                        ShowFooter="True" Width="100%">
                                        <HeaderStyle BackColor="#0083C1" ForeColor="White" />
                                        <FooterStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Request ID">
                                                <ItemStyle VerticalAlign="Middle" Width="70px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblcoll_id" runat="server" Text='<%# Eval("Req_ID") %>'  ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Hub ID">
                                                <ItemStyle VerticalAlign="Middle" Width="350px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDetail1" runat="server" Text='<%# Eval("Hub_Id") %>'  ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField> 
                                            <asp:TemplateField HeaderText="Hub Name">
                                                <ItemStyle VerticalAlign="Middle" Width="100px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProv_Name" runat="server" Text='<%# Eval("Hub_Name") %>'  ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>   
                                            <asp:TemplateField HeaderText="แสดงรูปภาพ">
                                            <ItemStyle VerticalAlign="Middle" Width="50px" />
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/view.jpg" ToolTip="Select" OnClientClick='<%# "wopen(""Show_Picture_Request_Appraisal.aspx?Req_Id=" + Eval("Req_ID").toString() + "&Hub_Id=" + Eval("Hub_Id").toString() + """, ""popup"", 500, 300); return false;" %>' />
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
            </td>
        </tr>
    </table>
	
	<asp:SqlDataSource ID="SDSTitle" runat="server" 
		ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
		SelectCommand="SELECT [TITLE_CODE], [TITLE_NAME] FROM [TB_TITLE]">
	</asp:SqlDataSource>
	<asp:SqlDataSource ID="sdsHub" runat="server" 
		ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
		SelectCommand="SELECT [HUB_ID], [HUB_NAME] FROM [TB_HUB]">
	</asp:SqlDataSource>
	<asp:SqlDataSource ID="sdsRequest_Appraisal_List" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="GET_REQUEST_APPRAISAL_LIST" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
	</form>
</body>
</html>
