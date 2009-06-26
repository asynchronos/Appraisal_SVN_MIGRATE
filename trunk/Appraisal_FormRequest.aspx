<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_FormRequest.aspx.vb" Inherits="Appraisal_Form_Appraisal_FormRequest" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <style type="text/css">
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
				width: 471px;
			}
			.style7
			{
				width: 256px;
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
		    .style36
            {
                width: 344px;
            }
		</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type="text/javascript">

        function expandcollapse(obj, row) {
            try {
                var div = document.getElementById(obj);
                var img = document.getElementById('img' + obj);

                if (div.style.display == "none") {
                    div.style.display = "block";
                    if (row == 'alt') {
                        img.src = "Images/minus.gif";
                    }
                    else {
                        img.src = "Images/minus.gif";
                    }
                    img.alt = "Close to view other CIF";
                }
                else {
                    div.style.display = "none";
                    if (row == 'alt') {
                        img.src = "Images/plus.gif";
                    }
                    else {
                        img.src = "Images/plus.gif";
                    }
                    img.alt = "Expand to show Coll ID";
                }
            } catch (err) {
                alert(err);
            }
        }


        var updated = "";

        // http://www.boutell.com/newfaq/creating/windowcenter.html
        function wopen(url, name, w, h) {
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

            wopen_checked(full_url, name, w, h, ctl);
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
<br />
<br />
    <table width="100%">
				<tr>
					<td class="style5" valign="top"> 
				<table class="style2" style="border-color:Blue; border-width:15px; width:469px">
				<tr>
				<td class="style36">เลขที่คำขอ</td>
				<td class="style7">
					<asp:Label CssClass="Fcolor" ID="lblRequestID" runat="server" Font-Bold="True" 
						Font-Size="Large" BackColor="#00FFCC"></asp:Label>
					</td>
				</tr>
				<tr>
					<td style="text-align:left;" class="style36">
						ประเภทคำขอ</td>
					<td style="text-align:left;" class="style7">
					    <asp:DropDownList ID="ddlAppraisal_Method" runat="server" 
                            DataSourceID="sdsAppraisal_Method" DataTextField="Method_Name" 
                            DataValueField="Method_ID">
                        </asp:DropDownList>
					</td>
				</tr>                
				<tr>
					<td style="text-align:left;" class="style36">
					CIF</td>
					<td style="text-align:left;" class="style7">
						<asp:TextBox ID="TxtCif" runat="server" MaxLength="9" Width="90px"></asp:TextBox>
					&nbsp;<asp:ImageButton ID="ImgBtFindCif" runat="server" ImageUrl="~/Images/book_blue_view.png" 
							Height="25px" Width="28px" ToolTip="ค้นหารหัสลูกค้า" />
								</td>
				</tr>
				<tr>
					<td style="text-align:left;" class="style36">
						คำนำหน้าลูกค้า</td>
					<td style="text-align:left;" class="style7">
						<asp:DropDownList ID="ddlTitle" runat="server" DataSourceID="SDSTitle" 
							DataTextField="TITLE_NAME" DataValueField="TITLE_CODE">
						</asp:DropDownList>
					</td>
				</tr>
				<tr>
					<td style="text-align:left;" class="style36">
						ชื่อลูกค้าผู้ขอประเมิน</td>
					<td style="text-align:left;" class="style7">
						<asp:TextBox ID="TxtCifName" runat="server" Width="180px"></asp:TextBox>
					</td>
				</tr>                
				<tr>
					<td style="text-align:left;" class="style36">
						นามสกุล</td>
					<td style="text-align:left;" class="style7">
						<asp:TextBox ID="TxtCifLastName" runat="server" Width="180px"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td style="text-align:left;" class="style36">
						รหัสผู้ขอให้ประเมิน(จ.สาขา)</td>
					<td style="text-align:left;" class="style7">
	
						<asp:TextBox ID="TxtSender" runat="server" MaxLength="9" Width="90px"></asp:TextBox>
					    <asp:ImageButton ID="ImgBtFindEmp" runat="server" ImageUrl="~/Images/book_blue_view.png" 
							Height="25px" Width="28px" ToolTip="ค้นหาผู้ขอให้ประเมิน" Visible="False" />
					    <asp:ImageButton ID="ImgBtSearchEmp" runat="server" ImageUrl="~/Images/book_blue_view.png" 
							Height="25px" ToolTip="ค้นหาผู้ขอให้ประเมิน" />
					</td>
				</tr>
				<tr>
					<td style="text-align:left;" class="style36">
						ชื่อ-สกุลผู้ขอให้ประเมิน</td>
					<td style="text-align:left;" class="style7">
	
						<asp:TextBox ID="TxtAppraisalName" runat="server" Width="240px" Height="21px"></asp:TextBox>
                    </td>
				</tr>
				<tr>
					<td style="text-align:left;" class="style36">
					    AID</td>
					<td style="text-align:left;" class="style7">
	
						<asp:DropDownList ID="ddlAID" runat="server">
                        </asp:DropDownList>
                    </td>
				</tr>
				<tr>
					<td colspan="2" align="center">
					<asp:Button ID="bntRequest_ID" runat="server" Text="ออกเลขคำขอประเมิน" />
					</td>
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
            BorderColor="Tan" BorderWidth="1px" ShowFooter="True" style="font-size: small">
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
						<asp:TextBox ID="txtSearch" runat="server" MaxLength="9" Width="90px"></asp:TextBox>
					    </td>
                        <td>
					<asp:ImageButton ID="ImgBtFind0" runat="server" ImageUrl="~/Images/book_blue_view.png" 
							Height="25px" Width="28px" />
								&nbsp;</td>
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
            GridLines="None" ShowFooter="True" PageSize="15" AllowPaging="True">
            <FooterStyle BackColor="Tan" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href="javascript:expandcollapse('div<%# Eval("Req_ID") %>', 'one');">
                            <img id="imgdiv<%# Eval("Req_Id") %>" alt="Click to show/hide Queue for Appraisal <%# Eval("Req_Id") %>"
                                width="9px" src="Images/plus.gif" />
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
                <asp:TemplateField HeaderText="ชื่อผู้ขอให้ประเมิน">
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
                                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/view.jpg" ToolTip="Select" OnClientClick='<%# "wopen(""Appraisal_Form/Show_Picture_Request_Appraisal.aspx?Req_Id=" + Eval("Req_ID").toString() + "&Hub_Id=" + Eval("Hub_Id").toString() + """, ""popup"", 500, 300); return false;" %>' />
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
		SelectCommand="SELECT HUB_ID, HUB_NAME FROM TB_HUB WHERE (HUB_ID &lt;&gt; 999)">
	</asp:SqlDataSource>
	<asp:SqlDataSource ID="sdsRequest_Appraisal_List" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="GET_REQUEST_APPRAISAL_LIST" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        <asp:SqlDataSource ID="sdsAppraisal_Method" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
            SelectCommand="SELECT [Method_ID], [Method_Name] FROM [Appraisal_Method]">
        </asp:SqlDataSource>
</asp:Content>

