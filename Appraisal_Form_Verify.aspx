<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_Form_Verify.aspx.vb" Inherits="Appraisal_Form_Appraisal_Form_Verify" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">

        function expandcollapse(obj, row) {
            try {
                var div = document.getElementById(obj);
                var img = document.getElementById('img' + obj);

                if (div.style.display == "none") {
                    div.style.display = "block";
                    if (row == 'alt') {
                        img.src = ".../../Images/minus.gif";
                    }
                    else {
                        img.src = ".../../Images/minus.gif";
                    }
                    img.alt = "Close to view other CIF";
                }
                else {
                    div.style.display = "none";
                    if (row == 'alt') {
                        img.src = ".../../Images/plus.gif";
                    }
                    else {
                        img.src = ".../../Images/plus.gif";
                    }
                    img.alt = "Expand to show Coll ID";
                }
            } catch (err) {
                alert(err);
            }
        } 
     </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
    <table width=100%>
        <tr>
            <td>
                &nbsp;</td>
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
                                                <ItemStyle VerticalAlign="Middle" Width="50px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblReq_id" runat="server" Text='<%# Eval("Req_ID") %>'  ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Hub Name">
                                                <ItemStyle VerticalAlign="Middle" Width="100px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblHub_Name" runat="server" Text='<%# Eval("Hub_Name") %>'  ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>   
                                            <asp:TemplateField HeaderText="Picture">
                                                <ItemStyle VerticalAlign="Middle" Width="250px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPicture_Name" runat="server" Text='<%# Eval("Picture_Path") %>'  ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>                                              
                                           <asp:TemplateField HeaderText="แสดงรูปภาพ ที่แนบมา">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="linkPath" runat="server"  target='_blank'  text='<%#EVAL("Picture_Path") %>' NavigateUrl='<%#  ".../../UploadedFiles/Pic_RegID/" &  EVAL("Picture_Path") %>'>HyperLink</asp:HyperLink>
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
	<asp:SqlDataSource ID="sdsRequest_Appraisal_List" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="GET_REQUEST_APPRAISAL_LIST" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            </td>
        </tr>
    </table>

</asp:Content>

