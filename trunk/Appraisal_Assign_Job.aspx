<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_Assign_Job.aspx.vb" Inherits="Appraisal_Assign_Job" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 139px;
            font-weight: bold;
        }
        .style3
        {
            width: 157px;
        }
        .style4
        {
            width: 74px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
<br />  
<asp:Label ID="lblPage" runat="server" 
        style="font-weight: 700; color: #3333CC" Text="กำหนดผู้ประเมินและตรวจสอบราคา"></asp:Label>
<br />
<br />
    <table class="style1">
        <tr>
            <td class="style2">
                เลือกผู้ประเมิน</td>
            <td class="style3">
                <asp:DropDownList ID="ddlAppraisal_User" runat="server" 
                    DataSourceID="sdsAppraisal" DataTextField="UserAppraisal" 
                    DataValueField="Appraisal_Id">
                </asp:DropDownList>
            </td>
            <td class="style4">
                <asp:Button ID="bntSearch" runat="server" Text="ค้นหา" />
            </td>
            <td>
            
                <b>จำนวน</b>
                <asp:Label ID="lblMessage" runat="server" 
                    style="color: #3333CC; font-weight: 700"></asp:Label>
&nbsp;<b>รายการ</b></td>
        </tr>
    </table>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="Req_Id,Hub_Id" DataSourceID="SqlDataSource1" 
            EmptyDataText="There are no data records to display." Width='100%' 
            BackColor="LightGoldenrodYellow" 
            BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" 
            GridLines="None" ShowFooter="True" PageSize="15" Font-Size="Small">
            <FooterStyle BackColor="Tan" />
            <Columns>
<%--                <asp:TemplateField>
                    <ItemTemplate>
                        <a href="javascript:expandcollapse('div<%# Eval("Req_Id") %>', 'one');">
                            <img id="imgdiv<%# Eval("Req_Id") %>" alt="Click to show/hide Queue for Appraisal <%# Eval("Req_Id") %>"
                                width="9px" src="Images/plus.gif" />
                        </a>
                    </ItemTemplate>
                </asp:TemplateField> --%> 
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
                        <asp:HiddenField ID="hdfStatus_Id" runat="server" Value='<%# Bind("Status_Id") %>' />
                        <asp:Label ID="LabelStatus_Name" runat="server" 
                            Text='<%# Bind("Status_Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="วันที่ส่งประเมิน">
                    <ItemTemplate>
                        <asp:Label ID="LabelCreate_Date" runat="server" 
                            Text='<%# Bind("Create_Date") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>    
<%--                <asp:HyperLinkField DataNavigateUrlFields="Req_Id,Hub_Id" 
                    DataNavigateUrlFormatString="Appraisal_Assign_Update_Job.aspx?Req_Id={0}&amp;Hub_Id={1}" 
                    HeaderText="Edit" Text="Edit" />--%>
                <asp:TemplateField HeaderText="ราคา">
                <ItemStyle HorizontalAlign="Center" Width="25px" />
                    <ItemTemplate>
                        <asp:ImageButton ID="imgPrint2View" runat="server" 
                            ImageUrl="~/Images/dollar.jpg" Height="22px" Width="22px" 
                            ToolTip="รายละเอียดการกำหนดราคา" OnClick="imgPrint2View_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            <asp:TemplateField HeaderText="Edit">
            <ItemStyle HorizontalAlign="Center" Width="25px" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/Images/pencil.png"
                        Height="22px" Width="22px" ToolTip="แก้ไขเปลี่ยนแปลง" OnClick="imgEdit_Click" />               
                </ItemTemplate>
            </asp:TemplateField>                  
<%--                <asp:TemplateField HeaderText="EDIT">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                            CommandName="Select" Text="EDIT"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>--%>
            </Columns>
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
        </asp:GridView>               


    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="GET_APPRAISAL_VERIFY_PROCESS_BY_HUB" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="HdfHub_Id" Name="HUB_ID" PropertyName="Value" 
                Type="Int32" />
            <asp:ControlParameter ControlID="HdfStatus" Name="Status_Id" 
                PropertyName="Value" Type="Int32" />
            <asp:ControlParameter ControlID="ddlAppraisal_User" Name="Appraisal_Id" 
                PropertyName="SelectedValue" Type="String" />
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
    <asp:SqlDataSource ID="sdsAppraisal0" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:AppraisalConnectionString %>" 
        
        SelectCommand="SELECT Emp_id as Appraisal_Id, Title + Name + '  ' + Lastname AS UserAppraisal FROM Tb_UserAppraisal WHERE (Hub_Id = @Hub_Id Or Emp_Id = '0')">
        <SelectParameters>
            <asp:ControlParameter ControlID="HdfHub_Id" Name="Hub_Id" 
                PropertyName="Value" />
        </SelectParameters>
    </asp:SqlDataSource>
    </asp:Content>

