<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_Assign_Job_V2.aspx.vb" Inherits="Appraisal_Assign_Job_V2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css" >
.divCol{
	font-weight:bold;
	float:left; 
	width:140px;
	text-align:left;
	margin-right:30px; 
	white-space:nowrap;
}
/*no width on the last col so it will expand*/
.divColLast{
	float:left; 
	white-space:nowrap;
}
.caption, table caption {
	background-color: #aaa;
	background-image: url('images/tilebg_tablecaption.gif');
	color: #000;
	font-size: 16pt;
	font-weight: bold;
	border: 0;
	border-bottom: solid 1px #737373;
	white-space: nowrap;
	text-align: center;
}
.clearer {
	clear: both;
	overflow: hidden;
	background-color:transparent;
	filter:alpha(opacity=0);
	opacity:0.0;
	height: 1px;
	margin: 1px 1px 1px 1px;
	max-height: 2px;
}
/* ajax modal dialog styles */
.modalBackground {
	background-color: Gray;
	filter: alpha(opacity=50);
	opacity: 0.5;
}
.modalBox {
	background-color : #f5f5f5;
	border-width: 3px;
	border-style: solid;
	border-color: Blue;
	padding: 3px;
}
.modalBox caption {
	background-image: url(images/window_titlebg.gif);
	background-repeat:repeat-x;
}

/* tweb modal dialog styles */
.modalPanelTitle td {
	padding: 3px;
	font-weight: bold;
	font-size: 0.9em;
	background-image: url(images/window_titlebg.gif);
	cursor: pointer;
	color: black;
	font-family: Verdana;
	width: 100%;
	height: 30px;
	background-color: #6f90dc;
}

.modalPanel {
	z-index: 500;
	width: 500px;
	border: solid 1px #275473;
	position: absolute;
	border-collapse: collapse;
	background-color: #f0faff;
}

.modalPanel td {
	vertical-align: top;
}

.titleIcon {
	padding-right: 20px;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
<br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
    	<Triggers>
			<asp:AsyncPostBackTrigger ControlID="GridAssignJob" EventName="Sorting" />
		</Triggers>
        <ContentTemplate>
            <asp:GridView ID="GridAssignJob" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="Req_Id,Hub_Id" DataSourceID="SqlDataSource1" 
            EmptyDataText="There are no data records to display." Width='100%' 
            BackColor="LightGoldenrodYellow" 
            BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" 
            GridLines="None" ShowFooter="True" Font-Size="Small">
                <FooterStyle BackColor="Tan" />
                <Columns>
                    <asp:TemplateField HeaderText="Req No.">
                        <ItemTemplate>
                            <asp:Label ID="lblReq_id" runat="server" Text='<%# Bind("Req_Id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField HeaderText="Hub ID">
                    <ItemTemplate>
                        <asp:Label ID="lblHub_Id" runat="server" Text='<%# Bind("Hub_Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Hub Name">
                    <ItemTemplate>
                        <asp:Label ID="lblHub_Name" runat="server" Text='<%# Bind("Hub_Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>                    
                    <asp:TemplateField HeaderText="Cif">
                        <ItemTemplate>
                            <asp:Label ID="lblCif" runat="server" Text='<%# Bind("Cif") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cif Name">
                        <ItemTemplate>
                            <asp:Label ID="lblCifName" runat="server" Text='<%# Bind("CifName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ชื่อผู้ส่งประเมิน">
                        <ItemTemplate>
                            <asp:Label ID="LabelEmp_Name" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="รหัสวิธี">
                        <ItemTemplate>
                            <asp:Label ID="lblReq_Type" runat="server" Text='<%# Bind("Req_Type") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="วิธีส่งประเมิน">
                        <ItemTemplate>
                            <asp:Label ID="lblAppraisal_Method_Name" runat="server" 
                            Text='<%# Bind("Method_Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="สถานะการประเมิน">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdfStatus_Id" runat="server" 
                            Value='<%# Bind("Status_Id") %>' />
                            <asp:Label ID="LabelStatus_Name" runat="server" 
                            Text='<%# Bind("Status_Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="วันที่ส่งประเมิน">
                        <ItemTemplate>
                            <asp:Label ID="LabelCreate_Date" runat="server" 
                            Text='<%# Bind("Create_Date", "{0:d}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="มอบหมาย/ยกเลิก">
                        <ItemStyle HorizontalAlign="Center" Width="25px" />
                        <ItemTemplate>
                            <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/Images/pencil.png"
                        Height="22px" Width="22px" ToolTip="มอบหมายงานให้เจ้าหน้าที่ประเมิน" OnClick="btnEditPerson_Click"/>
                        </ItemTemplate>
                        <ItemStyle Width="110px"/>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ยืนยันราคา">
                    <ItemStyle HorizontalAlign="Center" Width="25px" />
                        <ItemTemplate>
                            <asp:ImageButton ID="imgPrint2View" runat="server" 
                                ImageUrl="~/Images/dollar.jpg" Height="22px" Width="22px" 
                                ToolTip="รายละเอียดการกำหนดราคา" />
                        </ItemTemplate>
                        <ItemStyle Width="80px"/>
                    </asp:TemplateField>                    
                    <asp:TemplateField>
                        <ItemTemplate>
                            <tr>
                                <td colspan="100%">
                                    <div id="div<%# Eval("Req_Id") %>" style="display:none;position: relative; 
                                        left: 15px; overflow: auto; width: 97%">
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
			<!--cheesy button for the modal popups target control-->
			<asp:Button ID="btnHiddenPerson" runat="Server" Style="display: none" />
            <cc1:ModalPopupExtender ID="mpePerson" runat="server" TargetControlID="btnHiddenPerson" PopupControlID="pnlPerson"
            CancelControlID="btnCancelPerson" BackgroundCssClass="modalBackground" PopupDragHandleControlID="PersonCaption">
            </cc1:ModalPopupExtender>
			</ajaxToolKit:ModalPopupExtender>
			<asp:Panel ID="pnlPerson" runat="server" CssClass="modalBox" Style="display: none;" Width="500px">
				<asp:Panel ID="PersonCaption" runat="server" CssClass="caption" Style="margin-bottom: 10px; cursor: hand;">
					กำหนดผู้ประเมินราคาหลักประกัน</asp:Panel>
				<asp:HiddenField ID="hidPersonEditIndex" runat="server" Value="-1" />
				<div class="divCol">
					เลขคำขอประเมิน</div>
				<div class="divColLast">
					<asp:TextBox ID="txtReqId" runat="server" MaxLength="64" Width="250" ></asp:TextBox>
				</div>
				<div class="clearer">
				</div>
				<div class="divCol">
					ชื่อ-สุกล ลูกค้า</div>
				<div class="divColLast">
					<asp:TextBox ID="txtMiddleName" runat="server"  MaxLength="64" Width="250" ></asp:TextBox>
				</div>
				<div class="clearer">
				</div>
				<div class="divCol">
					ผู้ส่งประเมิน</div>
				<div class="divColLast">
					<asp:TextBox ID="txtLastName" runat="server"  MaxLength="64" Width="250"></asp:TextBox>
				</div>
				<div class="divCol">
					วันที่ส่งประเมิน
				</div>
				<div class="divColLast">
				    <asp:Label ID="lblSent_Date" runat="server" MaxLength="64" Width="250"></asp:Label>
				</div>
				<div class="clearer">
				</div>
				<div class="divCol">
					สถานะการประเมิน
				</div>
			    <div class="divColLast">
			        <asp:DropDownList ID ="ddlStatus" runat="server" DataSourceID="sdsStatus" 
                    DataTextField="Status_Name" DataValueField="Status_ID" Width="250"></asp:DropDownList>
                </div>	
				<div class="clearer">
				</div>                	
				<div class="divCol">
					ผู้ประเมิน
				</div>
			    <div class="divColLast">
			        <asp:DropDownList ID ="ddlAppraisal2" runat="server" DataSourceID="sdsAppraisal2" 
                    DataTextField="UserAppraisal" DataValueField="Appraisal_Id" Width="250"></asp:DropDownList>
                </div>
				<div class="clearer">
				</div>
				<div class="divCol">
				</div>				
				<div class="divColLast">
                    <asp:Label ID="lblError" runat="server" MaxLength="64" Width="250px" 
                        ForeColor="Red"></asp:Label>                   
				</div>
				<div class="clearer">
				</div>	
				<div class="divCol">
				</div>							
            <div style="white-space: nowrap; text-align: center;">
                <asp:Button ID="btnSave" runat="server" Text="Save" Width="50px" />
                <asp:Button ID="btnClose" runat="server" Text="Close" Width="50px" />
            </div>
			</asp:Panel>   
			<asp:Button ID="btnShowAttachFile" runat="Server" Style="display: none" />
            <cc1:ModalPopupExtender ID="mpeAttachFile" runat="server" TargetControlID="btnShowAttachFile" PopupControlID="pnlAttachFile"
            CancelControlID="btnCancelAttachFile" BackgroundCssClass="modalBackground" PopupDragHandleControlID="PersonCaption">
            </cc1:ModalPopupExtender>
			</ajaxToolKit:ModalPopupExtender>   
			<asp:Panel ID="pnlAttachFile" runat="server" CssClass="modalBox" Style="display: none;" Width="500px">
				<asp:Panel ID="Panel2" runat="server" CssClass="caption" Style="margin-bottom: 10px; cursor: hand;">
					แสดงเอกสารที่ยังไม่ได้แนบ</asp:Panel>
				<asp:HiddenField ID="HiddenField1" runat="server" Value="-1" />
				<div class="divCol">
					ฟอร์มคำขอประเมิน</div>
				<div class="divColLast">
					<asp:TextBox ID="txtAppraisalForm" runat="server" MaxLength="64" Width="250" ></asp:TextBox>
				</div>
				<div class="clearer">
				</div>
				<div class="divCol">
					รูปแผนที่หลักประกัน</div>
				<div class="divColLast">
					<asp:TextBox ID="txtPicMap" runat="server"  MaxLength="64" Width="250" ></asp:TextBox>
				</div>
				<div class="clearer">
				</div>
				<div class="divCol">
					รูปโฉนด</div>
				<div class="divColLast">
					<asp:TextBox ID="txtPicChanode" runat="server"  MaxLength="64" Width="250"></asp:TextBox>
				</div>
				<div class="clearer">
				</div>				
				<div style="white-space: nowrap; text-align: center;">
					<asp:Button ID="btnCancelAttachFile" runat="server" CausesValidation="false" Text="OK"/>
				</div>
			</asp:Panel>   
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="GET_APPRAISAL_VERIFY_PROCESS_BY_HUB" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="HdfHub_Id" Name="HUB_ID" PropertyName="Value" 
                Type="Int32" />
            <asp:ControlParameter ControlID="HdfStatus" Name="Status_Id" 
                PropertyName="Value" Type="Int32" />
            <asp:Parameter DefaultValue="0" Name="Appraisal_Id" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:HiddenField ID="HdfStatus" runat="server" Value="4" />
    <asp:HiddenField ID="HdfHub_Id" runat="server" />
    <asp:SqlDataSource ID="sdsAppraisal" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="GET_USER_APPRAISAL" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="HdfHub_Id" Name="Hub_Id" 
                PropertyName="Value" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsAppraisal2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="SELECT Emp_id AS Appraisal_Id, Title + Name + '  ' + Lastname AS UserAppraisal FROM Tb_UserAppraisal WHERE (Hub_Id = @Hub_Id) OR (Emp_id = '0')">
        <SelectParameters>
            <asp:ControlParameter ControlID="HdfHub_Id" Name="Hub_Id" 
                PropertyName="Value" />
        </SelectParameters>
    </asp:SqlDataSource>
                        <asp:SqlDataSource ID="sdsStatus" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
                            
                            
                            SelectCommand="SELECT Status_ID, Status_Name FROM Status_Appraisal WHERE (Status_ID = @Status_ID) UNION SELECT Status_ID, Status_Name FROM Status_Appraisal AS Status_Appraisal_2 WHERE (Status_ID = 3) UNION SELECT Status_ID, Status_Name FROM Status_Appraisal AS Status_Appraisal_1 WHERE (Status_ID IN (97, 98, 99))">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="HdfStatus" Name="Status_Id" 
                                    PropertyName="Value" />
                            </SelectParameters>
                        </asp:SqlDataSource>    
    </asp:Content>

