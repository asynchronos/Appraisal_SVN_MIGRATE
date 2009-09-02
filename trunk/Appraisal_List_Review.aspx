<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_List_Review.aspx.vb" Inherits="Appraisal_List_Review" UICulture="th-TH" Culture="th-TH" %>

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
<br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
        DataKeyNames="Req_Id"
        CellPadding="2" DataSourceID="sdsHistory_Review" ForeColor="Black" 
        GridLines="None" style="font-size: small" AllowPaging="True">
        <FooterStyle BackColor="Tan" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <a href="javascript:expandcollapse('div<%# Eval("Req_Id") %>', 'one');">
                    <img id="imgdiv<%# Eval("Req_Id") %>" alt="Click to show/hide Queue for Appraisal <%# Eval("Req_Id") %>"
                                width="9px" src="Images/plus.gif" /> </a>
                </ItemTemplate>
            </asp:TemplateField>        
            <asp:TemplateField HeaderText="Req ID" SortExpression="Req_Id">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Req_Id") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Req_Id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Hub ID" SortExpression="Hub_ID">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Hub_ID") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Hub_ID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="HUB NAME" SortExpression="Hub_NAME">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Hub_NAME") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Hub_NAME") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="AID" SortExpression="AID">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("AID") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("AID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cif" SortExpression="Cif">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Cif") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("Cif") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cifname" SortExpression="Cifname">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Cifname") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("Cifname") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ประเมินวันที่" SortExpression="Appraisal_Date">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Appraisal_Date") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" 
                        Text='<%# Bind("Appraisal_Date", "{0:d}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Req Type" SortExpression="Req_Type">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Req_Type") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("Req_Type") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="รหัสคำขอ" SortExpression="Status_ID">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Status_ID") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("Status_ID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="สถานะคำขอประเมิน" SortExpression="Status_Name">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("Status_Name") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label10" runat="server" Text='<%# Bind("Status_Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ผู้ประเมิน" SortExpression="Appraisal_ID">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("Appraisal_ID") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label11" runat="server" Text='<%# Bind("Appraisal_ID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ชื่อผู้ประเมิน" SortExpression="AppraisalName">
                <EditItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("AppraisalName") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label12" runat="server" Text='<%# Bind("AppraisalName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btnReviewForm" runat="server" CausesValidation="false" CommandName="" 
                        Text="ฟอร์มทบทวนเดิม" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btnConfirmReview" runat="server" CausesValidation="false" 
                        onclick="btnConfirmReview_Click" Text="ยืนยันทบทวน" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <tr>
                        <td colspan="100%">
                            <div id="div<%# Eval("Req_Id") %>" style="display: none; position: relative; 
                                    left: 15px; overflow: auto; width: 97%">
                                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                                        AllowSorting="True" AutoGenerateColumns="False" BackColor="#EEEEDD" 
                                        BorderColor="#0083C1" BorderStyle="Double" DataKeyNames="Req_Id" 
                                        Font-Names="Verdana" Font-Size="Small" GridLines="None" 
                                        OnRowDataBound="GridView2_RowDataBound"
                                        OnPageIndexChanging="GridView2_PageIndexChanging" 
                                        OnSelectedIndexChanging="GridView2_SelectedIndexChanging"
                                        OnSorting="GridView2_Sorting" 
                                        OnRowDeleting = "GridView2_RowDeleting" 
                                        OnRowDeleted = "GridView2_RowDeleted"
                                        OnRowCommand="GridView2_RowCommand" 
                                        ShowFooter="True" Width="100%">
                                    <HeaderStyle BackColor="#0083C1" ForeColor="White" />
                                    <FooterStyle BackColor="White" />
                                    <Columns>
                                                                            <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox runat="server" ID="cb1" AutoPostBack="true" OnCheckedChanged="cb1_Checked" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="cb2" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>                                    
                                        <asp:TemplateField HeaderText="Temp AID">
                                            <ItemStyle VerticalAlign="Middle" Width="80px" />
                                            <ItemTemplate>
                                                <asp:HiddenField ID="H_ID" runat="server" Value='<%# Eval("ID") %>' />                  
                                                <asp:Label ID="lblTemp_AID" runat="server" Text='<%# Eval("Temp_AID") %>'  ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>                                     
                                        <asp:TemplateField HeaderText="Req Id">
                                            <ItemStyle VerticalAlign="Middle" Width="50px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblReq_Id" runat="server" Text='<%# Eval("Req_Id") %>'  ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>                                      
                                        <asp:TemplateField HeaderText="cif name">
                                            <ItemStyle VerticalAlign="Middle" Width="250px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblcifname" runat="server" Text='<%# Eval("cifname") %>'  ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="HUB ID">
                                            <ItemStyle VerticalAlign="Middle" Width="50px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblHub_Id" runat="server" Text='<%# Eval("Hub_Id") %>'  ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:TemplateField HeaderText="HUB_NAME">
                                            <ItemStyle VerticalAlign="Middle" Width="350px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblHUB_NAME" runat="server" Text='<%# Eval("HUB_NAME") %>'  ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="หลักประกัน">
                                            <ItemStyle VerticalAlign="Middle" Width="120px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblColltype" runat="server" Text='<%# Eval("CollType_ID") %>'  ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ชื่อหลักประกัน">
                                            <ItemStyle VerticalAlign="Middle" Width="200px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblCollName" runat="server" Text='<%# Eval("SubCollType_Name") %>'  ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>                                                                                  
                                        <asp:TemplateField HeaderText="เลขที่">
                                            <ItemStyle VerticalAlign="Middle" Width="100px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblAddress_No" runat="server" Text='<%# Eval("Address_No") %>'  ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tumbon">
                                            <ItemStyle VerticalAlign="Middle" Width="200px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblTumbon" runat="server" Text='<%# Eval("Tumbon") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="อำเภอ">
                                            <ItemStyle VerticalAlign="Middle" Width="200px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblAmphur" runat="server" Text='<%# Eval("Amphur") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>     
                                        <asp:TemplateField HeaderText="จังหวัด">
                                            <ItemStyle VerticalAlign="Middle" Width="200px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblProvince_Name" runat="server" Text='<%# Eval("PROV_NAME") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>                                                                              
                                        <asp:TemplateField HeaderText="">
                                            <ItemStyle VerticalAlign="Middle" Width="30px" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/edit.gif" ToolTip="Select" Width="22px" Height="22px" CommandName="Select"  />              
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemStyle VerticalAlign="Middle" Width="30px" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgDelete" runat="server" ImageUrl="~/Images/cancel1.jpg" ToolTip="Delete" Width="22px" Height="22px" CommandName="Delete"  />              
                                            </ItemTemplate>
                                        </asp:TemplateField>   
			                            <asp:TemplateField HeaderText="ADD">
                                            <FooterTemplate>
                                                <asp:Button ID="ADDREVIEW" runat="server" Text="ADD REVIEW" CommandName="AddReview" />
                                            </FooterTemplate>
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
    <asp:SqlDataSource ID="sdsHistory_Review" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="GET_APPRAISAL_HISTORY_BY_AID" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblAID" Name="AID" PropertyName="Text" 
                Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:HiddenField ID="hdfAID" runat="server" />
    <asp:Label ID="lblAID" runat="server" Visible="False"></asp:Label>
</asp:Content>

