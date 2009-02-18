<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Appraisal_Price3_List_AID.aspx.vb" Inherits="Appraisal_Price3_List_AID" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

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
               
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <asp:HiddenField ID="hdfHub_ID" runat="server" />
    <asp:HiddenField ID="hdfAppraisal_Method" runat="server" />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AID,Req_ID"
        DataSourceID="sdsPriceList3_Review" EmptyDataText="There are no data records to display."
        Width='100%' BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px"
        CellPadding="2" ForeColor="Black" GridLines="None" ShowFooter="True" PageSize="15"
        Font-Size="Medium">
        <FooterStyle BackColor="Tan" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <a href="javascript:expandcollapse('div<%# Eval("Req_ID") %>', 'one');">
                        <img id="imgdiv<%# Eval("Req_ID") %>" alt="Click to show/hide Queue for Appraisal <%# Eval("Req_ID") %>"
                            width="9px" src="Images/plus.gif" />
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
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
            <asp:TemplateField HeaderText="AID">
                <ItemTemplate>
                    <asp:Label ID="lblAID" runat="server" Text='<%# Bind("AID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
<%--            <asp:TemplateField HeaderText="TEMP AID">
                <ItemTemplate>
                    <asp:Label ID="lblTemp_AID" runat="server" Text='<%# Bind("Temp_AID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>
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
            <asp:TemplateField HeaderText="รหัสวิธี">
                <ItemTemplate>
                    <asp:Label ID="lblReq_Type" runat="server" Text='<%# Bind("Req_Type") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="วิธีส่งประเมิน">
                <ItemTemplate>
                    <asp:Label ID="lblAppraisal_Method_Name" runat="server" Text='<%# Bind("Method_Name") %>'></asp:Label>
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
            <asp:TemplateField HeaderText="">
                <ItemStyle Width="25px" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgPrintPreview" runat="server" ImageUrl="~/Images/find1.jpg"
                        Height="22px" Width="22px" ToolTip="ดูผลก่อนพิมพ์" CommandName="Select" OnClick="imgPrintPreview_Click" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="">
                <ItemStyle Width="25px" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgaddplus" runat="server" ImageUrl="~/Images/add_plus2.jpg"
                        Height="22px" Width="22px" ToolTip="เพิ่มหลักประกัน" CommandName="View" OnClick="imgaddplus_Click" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <tr>
                        <td colspan="100%">
                            <div id="div<%# Eval("Req_ID") %>" style="display: none; position: relative; left: 15px;
                                overflow: auto; width: 97%">
                                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" BackColor="#EEEEDD" BorderColor="#0083C1" BorderStyle="Double"
                                    DataKeyNames="AID,Req_ID" Font-Names="Verdana" Font-Size="Small" GridLines="None" OnPageIndexChanging="GridView2_PageIndexChanging"
                                    OnSelectedIndexChanging="GridView2_SelectedIndexChanging" OnSorting="GridView2_Sorting"
                                    OnRowCommand="GridView2_RowCommand" ShowFooter="True" Width="100%" FooterStyle-BorderStyle="NotSet">
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
                                        <asp:TemplateField HeaderText="ID">
                                            <ItemStyle VerticalAlign="Middle" Width="80px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Temp AID">
                                            <ItemStyle VerticalAlign="Middle" Width="80px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblTemp_AID" runat="server" Text='<%# Eval("Temp_AID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Req Id">
                                            <ItemStyle VerticalAlign="Middle" Width="50px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblReq_Id" runat="server" Text='<%# Eval("Req_Id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="cif name">
                                            <ItemStyle VerticalAlign="Middle" Width="250px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblcifname" runat="server" Text='<%# Eval("cifname") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="HUB ID">
                                            <ItemStyle VerticalAlign="Middle" Width="50px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblHub_Id" runat="server" Text='<%# Eval("Hub_Id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="HUB_NAME">
                                            <ItemStyle VerticalAlign="Middle" Width="350px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblHUB_NAME" runat="server" Text='<%# Eval("HUB_NAME") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ชนิดหลักประกัน">
                                            <ItemStyle VerticalAlign="Middle" Width="100px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblColltype" runat="server" Text='<%# Eval("CollType_ID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Address_No">
                                            <ItemStyle VerticalAlign="Middle" Width="100px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblAddress_No" runat="server" Text='<%# Eval("Address_No") %>'></asp:Label>
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
                                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/edit.gif" ToolTip="Select"
                                                    Width="22px" Height="22px" CommandName="Select" />
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
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
    <asp:SqlDataSource ID="sdsPriceList3_Review" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="GET_PRICE3_LIST_REVIEW" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="hdfHub_ID" Name="HUB_ID" PropertyName="Value" Type="Int32" />
            <asp:ControlParameter ControlID="hdfAppraisal_Method" Name="APPRAISAL_METHOD" PropertyName="Value"
                Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
