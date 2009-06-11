<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Appraisal_Assign_Update_Job.aspx.vb" Inherits="Appraisal_Assign_Update_Job" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body onunload="opener.location=('Appraisal_Assign_Job.aspx')">
    <form id="form1" runat="server">


    <asp:SqlDataSource ID="sdsAssignJob" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConnectionString %>" 
        
        
        SelectCommand="SELECT Req_ID, Hub_ID, Cif, Title, Name, Lastname, Req_Type, Status_ID, CASE WHEN Appraisal_Id IS NULL THEN '0' WHEN Appraisal_Id = '' THEN '0' ELSE Appraisal_Id END AS Appraisal_Id FROM Appraisal_Request WHERE (Req_ID = @Req_ID) AND (Hub_ID = @Hub_Id)" 
        
        
        
        
        
        UpdateCommand="UPDATE Appraisal_Request SET Status_Id = @Status_Id,Appraisal_Id = @Appraisal_Id WHERE (Req_ID = @Req_Id) AND (Hub_ID = @Hub_Id)">
        <SelectParameters>
            <asp:QueryStringParameter Name="Req_ID" QueryStringField="Req_Id" />
            <asp:QueryStringParameter Name="Hub_Id" QueryStringField="Hub_Id" />
        </SelectParameters>
        <UpdateParameters>
            <asp:ControlParameter ControlID="HdfStatus" Name="Status_Id" 
                PropertyName="Value" Type="Int32" />
            <asp:Parameter Name="Appraisal_Id" Type="String" />
            <asp:Parameter Name="Req_Id" Type="Int32" />
            <asp:Parameter Name="Hub_Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
            CellPadding="4" DataKeyNames="Req_ID,Hub_ID" DataSourceID="sdsAssignJob" 
            DefaultMode="Edit" ForeColor="#333333" GridLines="None" Height="50px" 
            Width="314px">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <Fields>
                <asp:TemplateField HeaderText="Req_ID" SortExpression="Req_ID">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Req_ID") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Req_ID") %>'></asp:Label>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Req_ID") %>'></asp:TextBox>
                    </InsertItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Hub_ID" SortExpression="Hub_ID">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Hub_ID") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlHub" runat="server" DataSourceID="sdsHub" 
                            DataTextField="HUB_NAME" DataValueField="HUB_ID" 
                            SelectedValue='<%# Bind("Hub_ID") %>' Enabled="False">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="sdsHub" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:AppraisalConnectionString %>" 
                            
                            SelectCommand="SELECT [HUB_ID], [HUB_NAME] FROM [TB_HUB]">
                        </asp:SqlDataSource>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Hub_ID") %>'></asp:TextBox>
                    </InsertItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cif" SortExpression="Cif">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Cif") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Cif") %>' 
                            Enabled="False"></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Cif") %>'></asp:TextBox>
                    </InsertItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Title" SortExpression="Title">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlTitle" runat="server" DataSourceID="sdsTitle" 
                            DataTextField="TITLE_NAME" DataValueField="TITLE_CODE" 
                            SelectedValue='<%# Bind("Title") %>' Enabled="False">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="sdsTitle" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:AppraisalConnectionString %>" 
                            SelectCommand="SELECT [TITLE_CODE], [TITLE_NAME] FROM [TB_TITLE]">
                        </asp:SqlDataSource>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Title") %>'></asp:TextBox>
                    </InsertItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name" SortExpression="Name">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Name") %>' 
                            Enabled="False"></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                    </InsertItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Lastname" SortExpression="Lastname">
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Lastname") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Lastname") %>' 
                            Enabled="False"></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Lastname") %>'></asp:TextBox>
                    </InsertItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Req_Type" SortExpression="Req_Type">
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Req_Type") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlReq_Type" runat="server" DataSourceID="sdsReq_Type" 
                            DataTextField="Method_Name" DataValueField="Method_ID" 
                            SelectedValue='<%# Bind("Req_Type") %>' Enabled="False">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="sdsReq_Type" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:AppraisalConnectionString %>" 
                            SelectCommand="SELECT [Method_ID], [Method_Name] FROM [Appraisal_Method]">
                        </asp:SqlDataSource>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Req_Type") %>'></asp:TextBox>
                    </InsertItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status_ID" SortExpression="Status_ID">
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("Status_ID") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlStatus" runat="server" DataSourceID="sdsStatus" 
                            DataTextField="Status_Name" DataValueField="Status_ID" 
                            SelectedValue='<%# Bind("Status_ID") %>'>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="sdsStatus" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
                            SelectCommand="SELECT Status_ID, Status_Name FROM Status_Appraisal WHERE (Status_ID &gt;= @Status_ID) ORDER BY Status_ID">
                            <SelectParameters>
                                <asp:QueryStringParameter Name="Status_Id" QueryStringField="Status_Id" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Status_ID") %>'></asp:TextBox>
                    </InsertItemTemplate>
                </asp:TemplateField>
              
                <asp:TemplateField HeaderText="Appraisal_Id" SortExpression="Appraisal_Id">
                    <ItemTemplate>
                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("Appraisal_Id") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlAppraisal" runat="server" DataSourceID="sdsAppraisal" 
                            DataTextField="UserAppraisal" DataValueField="Appraisal_Id" 
                            SelectedValue='<%# Bind("Appraisal_Id") %>'>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="sdsAppraisal" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:AppraisalConnectionString %>" 
                            
                            
                            
                            SelectCommand="SELECT Emp_id as Appraisal_Id, Title + Name + '  ' + Lastname AS UserAppraisal FROM Tb_UserAppraisal WHERE (Hub_Id = @Hub_Id Or Emp_Id = '0')">
                            <SelectParameters>
                                <asp:QueryStringParameter Name="Hub_Id" QueryStringField="Hub_Id" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("Appraisal_Id") %>'></asp:TextBox>
                    </InsertItemTemplate>
                </asp:TemplateField>
              
                <asp:CommandField ShowEditButton="True" />
            </Fields>
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:DetailsView>
    
    <div>
    
    <asp:HiddenField ID="HdfStatus" runat="server" Value="3" />
    
    <asp:HiddenField ID="HdfHubId" runat="server" Value="4" />
    
    </div>
    </form>
</body>
</html>
