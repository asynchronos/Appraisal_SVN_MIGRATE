<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_Price2_Group.aspx.vb" Inherits="Appraisal_Price2_Group" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
<br />
    
        <asp:HiddenField ID="HiddenHubId" runat="server" />
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="2" DataSourceID="SqlDataSource1" 
            ForeColor="Black" GridLines="None" BackColor="LightGoldenrodYellow" 
            BorderColor="Tan" BorderWidth="1px" Width="100%" Font-Size="Small">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox runat="server" ID="cb1" AutoPostBack="true" OnCheckedChanged="cb1_Checked"/> 
                    </HeaderTemplate>
                   <ItemTemplate>
                     <asp:CheckBox runat="server" ID="cb2" />  
                   </ItemTemplate> 
                <ItemStyle HorizontalAlign="Center" Width="40px" />
                <HeaderStyle HorizontalAlign="Center" />
             </asp:TemplateField>  
                <asp:TemplateField HeaderText="เลขคำขอ" SortExpression="Req_Id">
                    <EditItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Req_Id") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblReq_Id" runat="server" Text='<%# Bind("Req_Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>                        
                <asp:TemplateField HeaderText="ลำดับที่" SortExpression="ID">
                <ItemStyle HorizontalAlign="Center" />
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Temp AID" SortExpression="Temp_AID">
                <ItemStyle HorizontalAlign="Center" />
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Temp_AID") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblTemp_AID" runat="server" Text='<%# Bind("Temp_AID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CIF" SortExpression="CIF">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CIF") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCif" runat="server" Text='<%# Bind("CIF") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CIFNAME" SortExpression="CIFNAME">
                    <EditItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("CIFNAME") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("CIFNAME") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Hub ID" SortExpression="Hub_Id">
                <ItemStyle HorizontalAlign="Center" />
                    <EditItemTemplate>
                        <asp:Label ID="txtHub_Id" runat="server" Text='<%# Eval("Hub_Id") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblHub_Id" runat="server" Text='<%# Bind("Hub_Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="HUB NAME" SortExpression="HUB_NAME">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("HUB_NAME") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("HUB_NAME") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
<%--                <asp:TemplateField HeaderText="Temp_AID" SortExpression="Temp_AID">
                    <EditItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("Temp_AID") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Temp_AID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="หลักประกัน" SortExpression="COLLTYPE_ID">
                    <ItemStyle HorizontalAlign="Center" />
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("COLLTYPE_ID") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCollType" runat="server" Text='<%# Bind("COLLTYPE_ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
<%--                <asp:TemplateField HeaderText="MysubColl_ID" SortExpression="MysubColl_ID">
                    <EditItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("MysubColl_ID") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("MysubColl_ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="ชื่อชนิดหลักประกัน" 
                    SortExpression="SUBCOLLTYPE_NAME">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" 
                            Text='<%# Bind("SUBCOLLTYPE_NAME") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("SUBCOLLTYPE_NAME") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ที่อยู่" SortExpression="Address_No">
                    <EditItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("Address_No") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label11" runat="server" Text='<%# Bind("Address_No") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ตำบล" SortExpression="Tumbon">
                    <EditItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("Tumbon") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label12" runat="server" Text='<%# Bind("Tumbon") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="อำเภอ" SortExpression="Amphur">
                    <EditItemTemplate>
                        <asp:Label ID="Label9" runat="server" Text='<%# Eval("Amphur") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label13" runat="server" Text='<%# Bind("Amphur") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
<%--                <asp:TemplateField HeaderText="Province" SortExpression="Province">
                    <EditItemTemplate>
                        <asp:Label ID="Label10" runat="server" Text='<%# Eval("Province") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label14" runat="server" Text='<%# Bind("Province") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="จังหวัด" SortExpression="Prov_Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Prov_Name") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label15" runat="server" Text='<%# Bind("Prov_Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                    
                <asp:TemplateField>
                <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:ImageButton ID="ImgBtFind" runat="server" ImageUrl="~/Images/book_blue_view.png" Height="25px" Width="25px" CommandName="Select" />
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

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="GET_PRICE2_LISTGROUP" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="HiddenHubId" Name="Hub_Id" 
                PropertyName="Value" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <div style="text-align: center">
        <table bgcolor="#00FFCC">
            <tr align="left">
                <td>รหัสกลุ่มประเมิน</td>
                <td>
                    <asp:TextBox ID="txtTemp_AID" runat="server" BackColor="#FFFFCC" 
                        BorderStyle="None" ReadOnly="True"></asp:TextBox>
                </td>
                <td></td>
            </tr>
            <tr align="left">
                <td>ผู้ประเมิน</td>
                <td>
                    <asp:DropDownList ID="ddlUserAppraisal" runat="server" DataSourceID="SDSUserAppraisal"
                        DataTextField="UserAppraisal" DataValueField="Emp_id">
                    </asp:DropDownList>
                </td>
                <td></td>
            </tr>   
            <tr align="left">
                <td>แนบไฟล์</td>
                <td>
                    <input id="AddFileButton" onclick="wopen('FileUpload.aspx', 'popup', 500, 300); return false;"
                        type="button" value="Add File" /></td>
                <td></td>
            </tr>
            <tr align="left">
                <td></td>
                <td></td>
                <td></td>
            </tr>    
            <tr align="left">
                <td></td>
                <td>
                               <asp:ImageButton ID="ImageSave" runat="server" 
                        ImageUrl="~/Images/Save.jpg" Height="30px" Width="30px" />
                                <asp:ImageButton ID="ImgBtnPrint" runat="server" ImageUrl="~/Images/printer.png" 
                            Height="30px" Width="30px" CommandName="Select" />
                    </td>
                <td></td>
            </tr>                                              
        </table>
    <asp:SqlDataSource ID="SDSUserAppraisal" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT Emp_id, Title + Name + '  ' + Lastname AS UserAppraisal FROM Tb_UserAppraisal">
    </asp:SqlDataSource>
    </div>
</asp:Content>

