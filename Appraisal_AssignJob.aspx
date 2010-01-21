<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_AssignJob.aspx.vb" Inherits="Appraisal_AssignJob" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        div.demo
        {
            width: auto;
            float: left;
            padding: 10px;
            margin: 0px;
            border: solid black 1px;
            font-size: small;
        }
        .caption, table caption
        {
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
        .divCol{
	    font-weight:bold;
	    color:blue;
	    float:left; 
	    width:140px;
	    text-align:left;
	    margin-right:30px; 
	    white-space:nowrap;
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
        .divColLast{
	        float:left; 
	        white-space:nowrap;
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
        .Timg {
          margin: 10px 10px 10px 10px;
          padding: 4px;
          border-top: 1px solid #ddd;
          border-left: 1px solid #ddd;
          border-bottom: 1px solid #c0c0c0;
          border-right: 1px solid #c0c0c0;
          background: #fff;
      }               
    </style>
    <link href="CSS/popupstyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
<br />
    <asp:ScriptManager ID="sm1" runat="server" />
    <%--Collateral Location Popup Display--%>    

    
    <asp:UpdatePanel ID="up1" runat="server" UpdateMode="Conditional">
        <Triggers>
			<asp:AsyncPostBackTrigger ControlID="GridView1" EventName="Sorting" />
		</Triggers>
        <ContentTemplate>
            <div >
                <asp:Label ID="Label1" runat="server" Text="��¡�÷���ʹ��Թ���" 
                    style="font-weight: 700; color: #3333CC"></asp:Label>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                CellPadding="2" DataKeyNames="Req_Id,Hub_Id" DataSourceID="SqlDataSource1" 
                EmptyDataText="There are no data records to display." Font-Size="Small" 
                ForeColor="Black" GridLines="None" ShowFooter="True" Width="100%" 
                    AllowPaging="True">
                <FooterStyle BackColor="Tan" />
                <Columns>
                    <asp:TemplateField HeaderText="Req No.">
                        <ItemTemplate>
                            <asp:Label ID="lblReq_Id" runat="server" Text='<%# Bind("Req_Id") %>'></asp:Label>
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
                    <asp:TemplateField HeaderText="���ͼ���觻����Թ">
                        <ItemTemplate>
                            <asp:Label ID="LabelEmp_Name" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="�����Ը�">
                        <ItemTemplate>
                            <asp:Label ID="lblReq_Type" runat="server" Text='<%# Bind("Req_Type") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="�Ը��觻����Թ">
                        <ItemTemplate>
                            <asp:Label ID="lblAppraisal_Method_Name" runat="server" 
                                Text='<%# Bind("Method_Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ʶҹС�û����Թ">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdfStatus_Id" runat="server" 
                                Value='<%# Bind("Status_Id") %>' />
                            <asp:Label ID="LabelStatus_Name" runat="server" 
                                Text='<%# Bind("Status_Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="�ѹ����觻����Թ">
                        <ItemTemplate>
                            <asp:Label ID="LabelCreate_Date" runat="server" 
                                Text='<%# Bind("Create_Date", "{0:d}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="�ͺ����/¡��ԡ">
                        <ItemStyle HorizontalAlign="Center" Width="25px" />
                        <ItemTemplate>
                            <asp:ImageButton ID="imgEdit" runat="server" Height="22px" 
                                ImageUrl="~/Images/pencil.png" OnClick="btnSaveAssignJob_Click"
                                ToolTip="�ͺ���§ҹ������˹�ҷ������Թ" Width="22px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="�׹�ѹ�Ҥ�">
                        <ItemStyle HorizontalAlign="Center" Width="25px" />
                        <ItemTemplate>
                            <asp:ImageButton ID="imgConfirm" runat="server" Height="22px" 
                                ImageUrl="~/Images/dollar.jpg" ToolTip="��������´��á�˹��Ҥ�" Width="22px" OnClick="imgConfirm_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemStyle Width="25px" />
                            <ItemTemplate>
                                <asp:ImageButton ID="imgLocation" runat="server" ImageUrl="~/Images/viewmap.jpg"
                                    Height="22px" Width="22px" ToolTip="Ἱ�����ѡ��Сѹ" />
                            </ItemTemplate>
                        </asp:TemplateField>   
            <asp:TemplateField HeaderText="">
                <ItemStyle Width="25px" HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgCollPic" runat="server" 
                        ImageUrl="~/Images/camera2.png" Height="22px" Width="22px" 
                        ToolTip="�ٻ��ѡ��Сѹ"  OnClick="imgCollPic_Click" />
                </ItemTemplate>                              
            </asp:TemplateField>                                          
                    <asp:TemplateField>
                        <ItemTemplate>
                            <tr>
                                <td colspan="100%">
                                    <div id='div<%# Eval("Req_Id") %>' style="display:none;position: relative; 
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
                         
    <asp:Button id="btnShowPopup" runat="server" style="display:none" />
    <cc1:ModalPopupExtender ID="mdlPopup" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlCities"
        CancelControlID="btnClose" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
     
    <asp:Panel ID="pnlCities" runat="server" CssClass="modalBox" Style="display: none;" Width="430px">
		<asp:Panel ID="Panel2" runat="server" CssClass="caption" Style="margin-bottom: 0px; cursor: hand;">
			�ͺ���§ҹ ���� ¡��ԡ</asp:Panel>
				<div class="divCol">
					�Ţ�Ӣͻ����Թ</div>
				<div class="divColLast">
					<asp:TextBox ID="txtReqId" runat="server" MaxLength="64" Width="250" ></asp:TextBox>
				</div>
				<div class="clearer">
				</div>
				<div class="divCol">
					����-�ء� �١���</div>
				<div class="divColLast">
					<asp:TextBox ID="txtMiddleName" runat="server"  MaxLength="64" Width="250" ></asp:TextBox>
				</div>
				<div class="clearer">
				</div>
				<div class="divCol">
					����觻����Թ</div>
				<div class="divColLast">
					<asp:TextBox ID="txtSenderName" runat="server"  MaxLength="64" Width="250"></asp:TextBox>
				</div>
				<div class="clearer">
				</div>				
				<div class="divCol">
					�ѹ����觻����Թ
				</div>
				<div class="divColLast">
				    <asp:Label ID="lblSent_Date" runat="server" MaxLength="64" Width="250"></asp:Label>
				</div>
				<div class="clearer">
				</div>
				<div class="divCol">
					ʶҹС�û����Թ
				</div>
                <div class="divColLast">
			        <asp:DropDownList ID ="ddlStatus" runat="server" DataSourceID="sdsStatus" 
                    DataTextField="Status_Name" DataValueField="Status_ID" Width="250"></asp:DropDownList>
                </div>					
				<div class="clearer">
				</div>
				<div class="divCol">
					�������Թ
				</div>
			    <div class="divColLast">
			        <asp:DropDownList ID ="ddlAppraisal2" runat="server" DataSourceID="sdsAppraisal2" 
                    DataTextField="UserAppraisal" DataValueField="Appraisal_Id" Width="250"></asp:DropDownList>
                </div>
				<div class="clearer">
				</div>
				<div class="divCol">
				</div>							
        <div style="white-space: nowrap; text-align: center;">
        <asp:Button ID="btnSaveAssignJob" runat="server" Text="Save" Width="50px" />
            <asp:Button ID="btnClose" runat="server" Text="Close" Width="50px" />
        </div>
    </asp:Panel>                              
                        
                        
    <asp:Button id="btnShowConfirm" runat="server" style="display:none" />
    <cc1:ModalPopupExtender ID="mdlconfirm" runat="server" TargetControlID="btnShowConfirm" PopupControlID="pnlConfrim"
    CancelControlID="btnClose" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
    <asp:Panel ID="pnlConfrim" runat="server" CssClass="modalBox" Style="display: none;" Width="480px">
		<asp:Panel ID="PanelTitleConfirm" runat="server" CssClass="caption" Style="margin-bottom: 0px; cursor: hand;">
			��������´�׹�ѹ�������Ҥҷ�� 2</asp:Panel>  
            <div class="divCol">
					�Ţ�Ӣͻ����Թ
			</div>
			<div class="divColLast">
                <asp:Label ID="lblReq_Id_Confirm" runat="server" Text=""></asp:Label>
			</div>
			<div class="clearer"></div>	
            <div class="divCol">�����ٹ������Թ</div>
		    <div class="divColLast">
                <asp:Label ID="lblHub_Id_Confirm" runat="server" Text=""></asp:Label>
		    </div>
		    <div class="clearer"></div>		
            <div class="divCol">�����ٹ������Թ</div>
		    <div class="divColLast">
                <asp:Label ID="lblHub_Name_Confirm" runat="server" Text=""></asp:Label>
		    </div>
			<div class="clearer"></div>	
            <div class="divCol">Cif</div>
		    <div class="divColLast">
                <asp:Label ID="lblCif_Confirmm" runat="server" Text=""></asp:Label>
		    </div>
		    <div class="clearer"></div>		
            <div class="divCol">Cif Name</div>
		    <div class="divColLast">
                <asp:Label ID="lblCifName_Confirm" runat="server" Text=""></asp:Label>
		    </div>  
			<div class="clearer"></div>	
            <div class="divCol">Sender Name</div>
		    <div class="divColLast">
                <asp:Label ID="lblSenderName_Confirm" runat="server" Text=""></asp:Label>
		    </div>
		    <div class="clearer"></div>		
            <div class="divCol">Appraisal Name</div>
		    <div class="divColLast">
                <asp:Label ID="lblAppraisal_Name_Confirm" runat="server" Text=""></asp:Label>
		    </div>	
			<div class="clearer"></div>	
            <div class="divCol">�Ҥҷ�� 1</div>
		    <div class="divColLast">
                <asp:Label ID="lblPrice1" runat="server" Text=""></asp:Label>
		    </div>
		    <div class="clearer"></div>		
            <div class="divCol">�Ҥҷ��  2</div>
		    <div class="divColLast">
                <asp:Label ID="lblPrice2" runat="server" Text=""></asp:Label>
		    </div>		     
		    <div class="clearer"></div>		
            <div class="divCol">Comment</div>
		    <div class="divColLast">
                <asp:TextBox ID="txtComment" runat="server" Height="22px" TextMode="MultiLine" 
                        Width="200px" ReadOnly="True"></asp:TextBox>
		    </div>	
		    <div class="clearer"></div>		
            <div class="divCol">�������</div>
		    <div class="divColLast">
                <asp:RadioButtonList ID="rdbAccept" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="8">��繪ͺ</asp:ListItem>
                        <asp:ListItem Value="7">�����繪ͺ</asp:ListItem>
                </asp:RadioButtonList>
		    </div>
		    <div class="clearer"></div>		
            <div class="divCol">�����˵�</div>
		    <div class="divColLast">
                <asp:TextBox ID="txtNote_Confirm" runat="server" Height="22px" TextMode="MultiLine" 
                        Width="200px"></asp:TextBox>
		    </div>
		           		
            <div class="clearer"></div>	
            <div style="white-space: nowrap; text-align: center;">
                <asp:Button ID="btnSaveConfrim" runat="server" Text="Save" Width="50px" OnClick="btnSaveConfrim_Click" />
                <asp:Button ID="btnCancleConfrim" runat="server" Text="Close" Width="50px" />
            </div>	  
     </asp:Panel>   
          
    <asp:Button id="btnShowPicture" runat="server" style="display:none" />
    <cc1:ModalPopupExtender ID="mdlShowPicture" runat="server" TargetControlID="btnShowPicture" PopupControlID="pnlShowPicture"
    CancelControlID="btnClose" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>       
    <asp:Panel ID="pnlShowPicture" runat="server" CssClass="modalBox" Style="display: none;" height="600px" width="700px">
        <%--<iframe id="frameShowPicture" src="Test/Picture_SlideShow.aspx"  height="600px" width="700px"></iframe>--%>
        <asp:ListView ID="lvPhotos" runat="server"
                    GroupItemCount="3" >            
            <LayoutTemplate>               
                   <table ID="groupPlaceholderContainer" runat="server" border="0" cellpadding="0" cellspacing="0">
                         <tr ID="groupPlaceholder" runat="server">
                         </tr>
                   </table>                        
            </LayoutTemplate>                        
            <GroupTemplate>
                    <tr ID="itemPlaceholderContainer" runat="server">
                        <td ID="itemPlaceholder" runat="server">
                        </td>
                    </tr>
                </GroupTemplate>           
                <ItemTemplate>
                    <td id="Td1" runat="server" align="center" style="background-color: #e8e8e8;color: #333333;">             
<%--                    <a href='<%# "UploadedFiles/Pic_Price2/" +Eval("Picture_Path") %>' > 
                    <asp:Image CssClass="Timg" runat="server" ID="imPhoto" Width="200px" ImageUrl='<%# "UploadedFiles/Pic_Price2/" +Eval("Picture_Path") %>' />
                    </a>--%>
                    <asp:Image CssClass="Timg" runat="server" ID="imPhoto" Width="200px" ImageUrl='<%# "UploadedFiles/Pic_Price2/" +Eval("Picture_Path") %>'/>
                    </td>                
                </ItemTemplate>             
         </asp:ListView>
            <div style="white-space: nowrap; text-align: center;">
                <asp:Button ID="btnClose_ShowPicture" runat="server" Text="Close" Width="50px" />
            </div>	
    </asp:Panel>    
          
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>     
                <asp:SqlDataSource ID="sdsPictureList" runat="server" 
                ConnectionString="<%$ ConnectionStrings:AppraisalConn %>">
                </asp:SqlDataSource>
                  
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
                          
                <asp:Label ID="lblReq_Id_Picture" runat="server"></asp:Label>
                          
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

