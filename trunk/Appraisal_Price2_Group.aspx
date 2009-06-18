<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_Price2_Group.aspx.vb" Inherits="Appraisal_Price2_Group" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
<!--
        var updated = "";

        // http://www.boutell.com/newfaq/creating/windowcenter.html
        function wopen(url, name, w, h) {
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

        function ConfirmOnDelete(item) {
            if (confirm("คุณยืนยันที่จะลบ: " + item + " ใช่หรือไม่ ?") == true)
                return true;
            else
                return false;
        }          
// -->
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
<br />
    
        <asp:HiddenField ID="HiddenHubId" runat="server" />
    
        <asp:HiddenField ID="HiddenReq_No" runat="server" />
    
        <asp:Label ID="lblPage" runat="server" 
        style="font-weight: 700; color: #3333CC" Text="ผูกชิ้นทรัพย์หลักประกัน"></asp:Label>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="2" DataSourceID="SqlDataSource1" 
            ForeColor="Black" GridLines="None" BackColor="LightGoldenrodYellow" 
            BorderColor="Tan" BorderWidth="1px" Width="100%" Font-Size="Small" 
        AllowPaging="True" PageSize="12" DataKeyNames="ID,Req_Id,Hub_Id">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox runat="server" ID="cb1" AutoPostBack="true" OnCheckedChanged="cb1_Checked"/> 
                    </HeaderTemplate>
                   <ItemTemplate>
                     <asp:CheckBox runat="server" ID="cb2" AutoPostBack="true" OnCheckedChanged="cb2_Checked"/>  
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
                <asp:TemplateField HeaderText="จังหวัด" SortExpression="Prov_Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Prov_Name") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label15" runat="server" Text='<%# Bind("Prov_Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ผู้ประเมิน" >
                    <ItemTemplate>
                        <asp:Label ID="lblAppraisal_Id" runat="server" Text='<%# Bind("Appraisal_Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="">
                      <ItemStyle VerticalAlign="Middle" Width="20px" />
                         <ItemTemplate>
                              <asp:ImageButton ID="ImgAddFile" runat="server" 
                                  ImageUrl="~/Images/add_plus2.jpg" ToolTip="แนบไฟล์" Width="22px" Height="22px" 
                                  onclick="ImgAddFile_Click" />              
                                            </ItemTemplate>
                                        </asp:TemplateField>                    
                <asp:TemplateField>
                <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:ImageButton ID="ImgBtFind" runat="server" ImageUrl="~/Images/book_blue_view.png" Height="25px" Width="25px" ToolTip="ดูรายละเอียด" CommandName="Select" />
                    </ItemTemplate>
                </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemStyle VerticalAlign="Middle" Width="30px" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgDelete" runat="server" ImageUrl="~/Images/cancel1.jpg" ToolTip="Delete" Width="22px" Height="22px" CommandName="Delete"  />              
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
        SelectCommand="GET_PRICE2_LISTGROUP" SelectCommandType="StoredProcedure" 
        DeleteCommand="DELETE_PRICE2_70_NEW" DeleteCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="HiddenHubId" Name="Hub_Id" 
                PropertyName="Value" Type="Int32" />
        </SelectParameters>
        <DeleteParameters>
                <asp:Parameter Name="Req_Id" Type="Int32" />
                <asp:Parameter Name="Hub_Id" Type="Int32" />
                <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
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
                <td>
                    Comment</td>
                <td>
                <asp:DropDownList ID="ddlComment" runat="server" DataSourceID="SDSComment" 
                    DataTextField="Comment_Name" DataValueField="Comment_ID">
                </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>            
            <tr align="left" style="display:none">
                <td>Comment</td>
                <td>
                    <asp:TextBox ID="txtComment" runat="server" Height="94px" TextMode="MultiLine" 
                        Width="497px"></asp:TextBox>
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
                <td>&nbsp;</td>
                <td>
                    <input id="AddFileButton" onclick="wopen('FileUpload_Price2.aspx', 'popup', 500, 300); return false;"
                        type="button" value="Add File" style="display:none;"/></td>
                <td></td>
            </tr>    
            <tr align="left">
                <td></td>
                <td style="text-align:center;">
                                <asp:ImageButton ID="ImgBtnAttachment" runat="server" ImageUrl="~/Images/add_plus2.jpg" 
                            Height="30px" Width="30px" CommandName="Select" ToolTip="แนบไฟล์" />
                    &nbsp;
                               <asp:ImageButton ID="ImageSave" runat="server" 
                        ImageUrl="~/Images/Save.jpg" Height="30px" Width="30px" />
                    </td>
                <td></td>
            </tr>                                              
        </table>
    <asp:SqlDataSource ID="SDSUserAppraisal" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT Emp_id, Title + Name + '  ' + Lastname AS UserAppraisal FROM Tb_UserAppraisal">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSComment" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Comment_ID], [Comment_Name] FROM [Comment]"></asp:SqlDataSource>
    </div>
</asp:Content>

