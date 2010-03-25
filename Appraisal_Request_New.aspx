<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_Request_New.aspx.vb" Inherits="Appraisal_Request_New" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .expleanColour
        {
         background-color: Silver;
        }
        .expleanColour1
        {
         background-color: red;
        }        
		.headDetail
        {
         font-weight:bold;
         color: Blue;
         background-color:Yellow;
        }
		.fColor
        {
            color: red;
        }
			.style1
        {
            width: 100%;
        }
			.style2
        {
            width: 350px;
        }
			</style>
      <script type="text/javascript" language="javascript">
        var reqid;
        var hubid;
//        reqid = document.getElementById('<%=lblRequestID.ClientID%>').innerHTML;
//        alert(reqid);
//        hubid = document.getElementById('<%=ddlHub.ClientID%>').value;
//        alert(hubid);

        function call_url_attach1() {
            reqid = document.getElementById('<%=lblRequestID.ClientID%>').innerHTML;
            hubid = document.getElementById('<%=ddlHub.ClientID%>').value;
            if (reqid == '') {
                alert('คุณยังไม่ได้ออกเลขคำขอประเมิน');
            }
            else {
                window.open('Upload_Form/Upload_File_Request_Form.aspx?req_id=' + reqid + '&hub_id=' + hubid + '&req_form=' + 1, 'Open1', 'toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, copyhistory=no, directories=no, status=yes,height=400px,width=600px');       
            }

	    }
	    function call_url_attach2() {
	        reqid = document.getElementById('<%=lblRequestID.ClientID%>').innerHTML;
	        //alert(reqid);
	        hubid = document.getElementById('<%=ddlHub.ClientID%>').value;
	        //alert(hubid);
	        if (reqid == '') {
	            alert('คุณยังไม่ได้ออกเลขคำขอประเมิน');
	        }
	        else {
	            window.open('Upload_Form/Upload_File_Request_Form.aspx?req_id=' + reqid + '&hub_id=' + hubid + '&req_form=' + 2, 'Open2', 'toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, copyhistory=no, directories=no, status=yes,height=400px,width=600px');	    
	        }
	    }
	    function call_url_attach3() {
	        reqid = document.getElementById('<%=lblRequestID.ClientID%>').innerHTML;
	        hubid = document.getElementById('<%=ddlHub.ClientID%>').value;
	        if (reqid == '') {
	            alert('คุณยังไม่ได้ออกเลขคำขอประเมิน');
	        }
	        else {
	        window.open('Upload_Form/Upload_File_Request_Form.aspx?req_id=' + reqid + '&hub_id=' + hubid + '&req_form=' + 3, 'Open3', 'toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, copyhistory=no, directories=no, status=yes,height=400px,width=600px');	        
	        }

	    }
	    function call_url_attach4() {
	        reqid = document.getElementById('<%=lblRequestID.ClientID%>').innerHTML;
	        hubid = document.getElementById('<%=ddlHub.ClientID%>').value;
	        if (reqid == '') {
	            alert('คุณยังไม่ได้ออกเลขคำขอประเมิน');
	        }
	        else {
	        window.open('Upload_Form/Upload_File_Request_Form.aspx?req_id=' + reqid + '&hub_id=' + hubid + '&req_form=' + 4, 'Open4', 'toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, copyhistory=no, directories=no, status=yes,height=400px,width=600px');	        
	        }

	    }
	    function call_search_emp() {
	        window.open('Search_Employee.aspx', 'search_emp', 'toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, directories=no, status=yes,height=550px,width=650px');
	    }
	    function copyDataCif() {
	        var _chk = document.getElementById('<%=ChkBoxCopy.ClientID%>').checked;
	        var _cif = document.getElementById('<%=txtCif.ClientID%>').value;
	        var _title =  document.getElementById('<%=ddlTitle.ClientID%>').value;
	        var _name = document.getElementById('<%=TxtCifName.ClientID%>').value;
	        var _lastname = document.getElementById('<%=TxtCifLastName.ClientID%>').value;
	        //alert(_chk);
	                if (_chk == true) {
	                    document.getElementById('<%=TxtCifColl.ClientID%>').value =_cif;
	                    document.getElementById('<%=ddlTitleColl.ClientID%>').value =_title;
	                    document.getElementById('<%=TxtCifNameColl.ClientID%>').value = _name;
	                    document.getElementById('<%=TxtCifLastNameColl.ClientID%>').value = _lastname;	                
                    }
                    else {
                        document.getElementById('<%=TxtCifColl.ClientID%>').value = '';
                        document.getElementById('<%=ddlTitleColl.ClientID%>').value = 1;
                        document.getElementById('<%=TxtCifNameColl.ClientID%>').value ='';
                        document.getElementById('<%=TxtCifLastNameColl.ClientID%>').value = '';	      
                    }
	    } 
	</script>	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
<br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
            <table>
                <tr>
                    <td>
                        <table style="border-color:Blue; border-width:15px; width:500px">
                            <tr>
                                <td style="text-align:left; color:Blue;"  bgcolor="Yellow" colspan="2" 
                class="headDetail">
                                    ประเภทคำขอประเมิน</td>
                            </tr>
                            <tr>
                                <td style="text-align:left;" class="expleanColour">
                                    ประเภทคำขอ</td>
                                <td style="text-align:left;" >
                                    <asp:DropDownList ID="ddlAppraisal_Method" runat="server" 
                            DataSourceID="sdsAppraisal_Method" DataTextField="Method_Name" 
                            DataValueField="Method_ID">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:left;" class="headDetail" bgcolor="Yellow" colspan="2">
                                    ส่วนข้อมูลลูกค้า</td>
                            </tr>
                            <tr>
                                <td style="text-align:left;" class="expleanColour">
                                    CIF</td>
                                <td style="text-align:left;">
                                    <asp:TextBox ID="TxtCif" runat="server" MaxLength="9" Width="90px"></asp:TextBox>
                                    &nbsp;<asp:ImageButton ID="ImgBtFindCif" runat="server" ImageUrl="~/Images/find1.jpg" 
							Height="25px" Width="28px" ToolTip="ค้นหารหัสลูกค้า" ValidationGroup="1" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_Cif" 
                                        runat="server" ControlToValidate="TxtCif" Display="Dynamic" 
                                        ErrorMessage="ใส่ รหัสลูกค้า" ValidationGroup="1"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:left;" class="expleanColour">
                                    คำนำหน้า</td>
                                <td style="text-align:left;">
                                    <asp:DropDownList ID="ddlTitle" runat="server" DataSourceID="SDSTitle" 
							DataTextField="TITLE_NAME" DataValueField="TITLE_CODE">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:left;" class="expleanColour">
                                    ชื่อ</td>
                                <td style="text-align:left;">
                                    <asp:TextBox ID="TxtCifName" runat="server" Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_Name" runat="server" 
                                        ControlToValidate="TxtCifName" Display="Dynamic" ErrorMessage="ใส่ชื่อ ลูกค้า" 
                                        ValidationGroup="4"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:left;" class="expleanColour">
                                    นามสกุล</td>
                                <td style="text-align:left;">
                                    <asp:TextBox ID="TxtCifLastName" runat="server" Width="180px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:left;"  bgcolor="#FFFF66" colspan="2" class="headDetail">
                                    ส่วนข้อมูลเจ้าของหลักประกัน</td>
                            </tr>
                            <tr>
                                <td style="text-align:left;" class="expleanColour" bgcolor="Silver">
                                    &nbsp;</td>
                                <td style="text-align:left;">
                                    <asp:CheckBox ID="ChkBoxCopy" runat="server" 
                    Text="ใช้ข้อมูลเดียวกันกับข้อมูลลูกค้า" />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:left;" class="expleanColour">
                                    CIF</td>
                                <td style="text-align:left;">
                                    <asp:TextBox ID="TxtCifColl" runat="server" MaxLength="9" Width="90px"></asp:TextBox>
                                    <asp:ImageButton ID="ImgBtFindCollOwner" runat="server" ImageUrl="~/Images/find1.jpg" 
							Height="25px" Width="28px" ToolTip="ค้นหารหัสลูกค้า" ValidationGroup="1" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_CifColl" runat="server" 
                                        ControlToValidate="TxtCifColl" Display="Dynamic" 
                                        ErrorMessage="ใส่รหัสเจ้าของหลักประกัน" ValidationGroup="3"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:left;" class="expleanColour">
                                    คำนำหน้า</td>
                                <td style="text-align:left;">
                                    <asp:DropDownList ID="ddlTitleColl" runat="server" DataSourceID="SDSTitle" 
							DataTextField="TITLE_NAME" DataValueField="TITLE_CODE">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:left;" class="expleanColour">
                                    ชื่อ</td>
                                <td style="text-align:left;">
                                    <asp:TextBox ID="TxtCifNameColl" runat="server" Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_NameColl" runat="server" 
                                        ControlToValidate="TxtCifNameColl" Display="Dynamic" 
                                        ErrorMessage="ใส่ชื่อเจ้าของหลักประกัน" ValidationGroup="4"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:left;" class="expleanColour">
                                    นามสกุล</td>
                                <td style="text-align:left;">
                                    <asp:TextBox ID="TxtCifLastNameColl" runat="server" Width="180px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:left;" class="headDetail" bgcolor="Yellow" colspan="2">
                                    ที่ตั้งหลักประกัน</td>
                            </tr>
                            <tr>
                                <td style="text-align:left;" class="expleanColour">
                                    จังหวัด</td>
                                <td style="text-align:left;">
                                    <asp:DropDownList ID="ddlProvince" runat="server" DataSourceID="sdsProvince" 
							DataTextField="PROV_NAME" DataValueField="PROV_CODE" AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:left;" class="expleanColour">
                                    อำเภอ</td>
                                <td style="text-align:left;">
                                    <asp:DropDownList ID="ddlAmphur" runat="server" DataSourceID="sdsAmphur" 
							DataTextField="am_name" DataValueField="amcode" AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:left;" class="expleanColour">
                                    ตำบล</td>
                                <td style="text-align:left;">
                                    <asp:DropDownList ID="ddlTumbon" runat="server" DataSourceID="sdsTumbon" 
							DataTextField="Tumbon_Name" DataValueField="ttcode" AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:left;" class="expleanColour">
                                    ศูนย์หลักประกันที่รับผิดชอบ</td>
                                <td style="text-align:left;">
                                    <asp:DropDownList ID="ddlHub" runat="server" DataSourceID="sdsHub" 
                    DataTextField="HUB_NAME" DataValueField="hub_id">
                                    </asp:DropDownList>
                                </td>
                            </tr>

                            <tr>
                                <td style="text-align:left;" class="expleanColour">
                                    AID</td>
                                <td style="text-align:left;">
                                    <asp:DropDownList ID="ddlAID" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:left;" class="headDetail" bgcolor="Yellow" colspan="2">
                                    ข้อมูลผู้ขอให้ประเมิน</td>
                            </tr>
                            <tr>
                                <td style="text-align:left;" class="expleanColour">
                                    รหัสผู้ขอให้ประเมิน(จ.สาขา)</td>
                                <td style="text-align:left;" >
                                    <asp:TextBox ID="TxtSender" runat="server" MaxLength="9" Width="90px"></asp:TextBox>
                                    <asp:ImageButton ID="ImgBtSearchEmp" runat="server" ImageUrl="~/Images/book_blue_view.png" 
							Height="25px" ToolTip="ค้นหาผู้ขอให้ประเมิน" ValidationGroup="2"/>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_Sender" runat="server" 
                                        ControlToValidate="TxtSender" Display="Dynamic" 
                                        ErrorMessage="ใส่รหัสพนักงานผู้ขอให้ประเมิน" ValidationGroup="4"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:left;" class="expleanColour">
                                    ชื่อ-สกุลผู้ขอให้ประเมิน</td>
                                <td style="text-align:left;">
                                    <asp:TextBox ID="TxtAppraisalName" runat="server" Width="240px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_SenderName" 
                                        runat="server" ControlToValidate="TxtAppraisalName" Display="Dynamic" 
                                        ErrorMessage="ใส่ชื่อพนักงานผู้ขอให้ประเมิน" ValidationGroup="4"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="expleanColour" style="text-align:left;">
                                    สาขา/ฝ่ายงาน</td>
                                <td style="text-align:left;">
                                    <asp:DropDownList ID="ddlBranch_Dept" runat="server" DataSourceID="sdsBranch" 
                                        DataTextField="BRANCH_T" DataValueField="ID_BRANCH">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:left; text-align:center;" class="headDetail" colspan="2">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                    <td valign="top" class="style2">
                                        <table class="style1">
                                            <tr>
                                                <td align="center">
                                                    <asp:Button ID="bntRequest_ID" runat="server" Text="ออกเลขคำขอประเมิน" 
                    style="font-weight: 700" Height="50px" ValidationGroup="1,2" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="headDetail">
                                                    คำขอประเมินเลขที่</td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:Label CssClass="fColor" ID="lblRequestID" runat="server" Font-Bold="True" 
						Font-Size="Large"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:Label ID="lblMessage" runat="server" 
							style="color: #FF0000; font-weight: 700"></asp:Label>
                                                </td>
                                            </tr>

                                        </table>
                                         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <table class="style1">
                                                    <tr>
                                                        <td class="headDetail" colspan="2">
                                                            แนบไฟล์</td>
                                                    </tr>
                                                    <tr class="expleanColour1">
                                                        <td class="expleanColour1">
                                                            แนบใบคำขอประเมิน</td>
                                                        <td>
                                                            <asp:Button ID="BtnAttach1" runat="server" Text="แนบไฟล์" 
                                        OnClientClick="call_url_attach1(); return false;" />
                                                        </td>
                                                    </tr>
                                                    <tr class="expleanColour1">
                                                        <td class="expleanColour1">
                                                            แนบแผนที่</td>
                                                        <td>
                                                            <asp:Button ID="BtnAttach2" runat="server" Text="แนบไฟล์" 
                                        OnClientClick="call_url_attach2(); return false;" />
                                                        </td>
                                                    </tr>
                                                    <tr class="expleanColour1"> 
                                                        <td class="expleanColour1">
                                                            แนบหน้าโฉนด/ใบกรรมสิทธิห้องชุด</td>
                                                        <td>
                                                            <asp:Button ID="BtnAttach3" runat="server" Text="แนบไฟล์" 
                                        OnClientClick="call_url_attach3(); return false;" />
                                                        </td>
                                                    </tr>
                                                    <tr class="expleanColour">
                                                        <td class="expleanColour">
                                                            อื่น ๆ</td>
                                                        <td>
                                                            <asp:Button ID="BtnAttach4" runat="server" Text="แนบไฟล์" 
                                        OnClientClick="call_url_attach4(); return false;" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="center">
                                                            <asp:Button ID="btnFinish" runat="server" Height="50px" 
                                                                Text="ออกเลขคำขอเสร็จสมบูรณ์" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>                                       
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                            ValidationGroup="1" />
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" 
                                            ValidationGroup="2" />
                                        <asp:ValidationSummary ID="ValidationSummary3" runat="server" 
                                            ValidationGroup="3" />
                                        <asp:ValidationSummary ID="ValidationSummary4" runat="server" 
                                            ValidationGroup="4" />
                            

                            
                    </td>
                </tr>
            </table>
	<asp:SqlDataSource ID="sdsHub" runat="server" 
		ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
		
        SelectCommand="SELECT TB_Hub_Responsibility.hub_id, TB_HUB.HUB_NAME FROM TB_Hub_Responsibility INNER JOIN TB_HUB ON TB_Hub_Responsibility.hub_id = TB_HUB.HUB_ID WHERE (TB_Hub_Responsibility.Province_code = @Province_Code) AND (TB_Hub_Responsibility.amcode = @Amphur_Code) AND (TB_Hub_Responsibility.ttcode = @Tumbon_Code)">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlProvince" Name="Province_Code" 
                PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="ddlAmphur" Name="Amphur_Code" 
                PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="ddlTumbon" Name="Tumbon_Code" 
                PropertyName="SelectedValue" />
        </SelectParameters>
	</asp:SqlDataSource>
	<asp:SqlDataSource ID="sdsProvince" runat="server" 
		ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
		SelectCommand="SELECT PROV_CODE, PROV_NAME FROM TB_PROVINCE Order By PROV_CODE">
	</asp:SqlDataSource>
    
	<asp:SqlDataSource ID="sdsAmphur" runat="server" 
		ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
		
        
        SelectCommand="SELECT TB_AMPHUR.amcode, TB_AMPHUR.am_name FROM TB_AMPHUR INNER JOIN TB_PROVINCE ON TB_AMPHUR.pvcode = TB_PROVINCE.PROV_CODE WHERE (TB_AMPHUR.pvcode = @Province_Code)">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlProvince" Name="Province_Code" 
                PropertyName="SelectedValue" />
        </SelectParameters>
	</asp:SqlDataSource>
    
	<asp:SqlDataSource ID="sdsTumbon" runat="server" 
		ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
		
        
        
        SelectCommand="SELECT TB_TUMBON.ttcode, TB_TUMBON.tumbon_new2_name AS Tumbon_Name FROM TB_TUMBON INNER JOIN TB_AMPHUR ON TB_TUMBON.pvcode = TB_AMPHUR.pvcode AND TB_TUMBON.amcode = TB_AMPHUR.amcode WHERE (TB_TUMBON.pvcode = @Province_Code) AND (TB_TUMBON.amcode = @Amphur_Code)">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlProvince" Name="Province_Code" 
                PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="ddlAmphur" Name="Amphur_Code" 
                PropertyName="SelectedValue" />
        </SelectParameters>
	</asp:SqlDataSource>
    
	<asp:SqlDataSource ID="SDSTitle" runat="server" 
		ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
		SelectCommand="SELECT [TITLE_CODE], [TITLE_NAME] FROM [TB_TITLE]">
	</asp:SqlDataSource>
        <asp:SqlDataSource ID="sdsAppraisal_Method" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
            SelectCommand="SELECT [Method_ID], [Method_Name] FROM [Appraisal_Method]">
        </asp:SqlDataSource>
    
    <asp:SqlDataSource ID="sdsBranch" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="GET_BRANCH" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    
    </asp:Content>

