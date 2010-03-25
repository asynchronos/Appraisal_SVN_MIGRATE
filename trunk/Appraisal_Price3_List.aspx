<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_Price3_List.aspx.vb" Inherits="Appraisal_Price3_List" %>

<%@ Register Assembly="Mytextbox" Namespace="Mytextbox" TagPrefix="cc1" %>
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
    'status=no, toolbar=no, scrollbars=yes, resizable=no', 'title=no', 'resizable=no', 'directories=no', 'status=no');
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
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="Temp_AID" DataSourceID="REQUEST_APPRAISAL_PRICE3_LIST" 
            EmptyDataText="There are no data records to display." Width='100%' 
            BackColor="LightGoldenrodYellow" 
            BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" 
            GridLines="None" ShowFooter="True" PageSize="15" Font-Size="Small">
        <FooterStyle BackColor="Tan" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <a href="javascript:expandcollapse('div<%# Eval("Temp_AID") %>', 'one');">
                    <img id="imgdiv<%# Eval("Temp_AID") %>" alt="Click to show/hide Queue for Appraisal <%# Eval("Temp_AID") %>"
                                width="9px" src="Images/plus.gif" /> </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="TEMP AID">
                <ItemStyle Width="80px" />
                <ItemTemplate>
                    <asp:Label ID="lblTemp_AID" runat="server" Text='<%# Bind("Temp_AID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="REQ ID">
                <ItemStyle Width="80px" />
                <ItemTemplate>
                    <asp:Label ID="lblReq_Id" runat="server" Text='<%# Bind("Req_Id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>    
            <asp:TemplateField HeaderText="HUB ID">
                <ItemStyle Width="60px" />
                <ItemTemplate>
                    <asp:Label ID="lblHub_Id" runat="server" Text='<%# Bind("Hub_Id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="HUB NAME">
                <ItemTemplate>
                    <asp:Label ID="lblHub_Name" runat="server" Text='<%# Bind("Hub_Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>                                      
            <asp:TemplateField HeaderText="Cif">
                <ItemStyle Width="70px" />
                <ItemTemplate>
                    <asp:Label ID="lblCif" runat="server" Text='<%# Bind("Cif") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cif Name">
                <ItemTemplate>
                    <asp:Label ID="lblCifname" runat="server" Text='<%# Bind("CifName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="รหัสวิธี">
                <ItemTemplate>
                    <asp:Label ID="lblMethodNo" runat="server" Text='<%# Bind("Req_Type") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ชื่อวิธีส่งประเมิน">
                <ItemTemplate>
                    <asp:Label ID="lblMethodName" runat="server" Text='<%# Bind("Method_Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>            
            <asp:TemplateField HeaderText="รหัสผู้ประเมิน">
                <ItemStyle Width="100px" />
                <ItemTemplate>
                    <asp:Label ID="lblAppraisal_Id" runat="server" Text='<%# Bind("Appraisal_Id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>            
            <asp:TemplateField HeaderText="ชื่อผู้ประเมิน">
                <ItemTemplate>
                    <asp:Label ID="lblApp_Name" runat="server" Text='<%# Bind("App_Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ราคาประเมินราคาที่ 2">
            <ItemStyle Width="80px" HorizontalAlign="Right" ForeColor="Red" Font-Bold="true" />
                <ItemTemplate>
                    <asp:Label ID="lblPrice2" runat="server" Text='<%# Bind("Price2", "{0:N}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>            
<%--            <asp:TemplateField HeaderText="">
                <ItemStyle Width="25px" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgPrint2View" runat="server" 
                        ImageUrl="~/Images/search.ico" Height="22px" Width="22px" 
                        ToolTip="ฟอร์มอย่างย่อราคาที่ 2" CommandName="Select" OnClick="imgPrint2View_Click" />
                </ItemTemplate>
            </asp:TemplateField> --%>             
            <asp:TemplateField HeaderText="">
            <ItemStyle Width="25px" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgaddplus" runat="server" 
                        ImageUrl="~/Images/add_plus2.jpg" Height="22px" Width="22px" 
                        ToolTip="แนบไฟล์" CommandName="View" onclick="imgaddplus_Click"/>
                </ItemTemplate>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="">
                <ItemStyle Width="25px" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgPrintPreview" runat="server" 
                        ImageUrl="~/Images/find1.jpg" Height="22px" Width="22px" 
                        ToolTip="ดูผลก่อนพิมพ์" CommandName="Select" OnClick="imgPrintPreview_Click" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="">
                <ItemStyle Width="25px" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgAddColl" runat="server" 
                        ImageUrl="~/Images/add_plus.jpg" Height="22px" Width="22px" 
                        ToolTip="เพิ่มชิ้นหลักประกัน" CommandName="Select" OnClick="imgAddColl_Click" />
                </ItemTemplate>
            </asp:TemplateField>                                           
            <asp:TemplateField>
                <ItemTemplate>
                    <tr>
                        <td colspan="100%">
                            <div id="div<%# Eval("Temp_AID") %>" style="display:none;position: relative; 
                                    left: 15px; overflow: auto; width: 97%">
                                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                                        AllowSorting="True" AutoGenerateColumns="False" BackColor="#EEEEDD" 
                                        BorderColor="#0083C1" BorderStyle="Double" DataKeyNames="Temp_AID" 
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
                                        <asp:TemplateField HeaderText="Address_No">
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
<br />
    <asp:SqlDataSource ID="REQUEST_APPRAISAL_PRICE3_LIST" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="GET_PRICE3_LIST" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="hhfHub_Id" Name="HUB_ID" PropertyName="Value" 
                Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:HiddenField ID="hhfHub_Id" runat="server" />
    </asp:Content>

