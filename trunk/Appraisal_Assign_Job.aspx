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
            GridLines="None" ShowFooter="True" PageSize="15" Font-Size="Small" 
        AllowPaging="True">
            <FooterStyle BackColor="Tan" />
            <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <a href="javascript:expandcollapse('div<%# Eval("Req_Id") %>', 'one');">
                    <img id="imgdiv<%# Eval("Req_Id") %>" alt="Click to show/hide Queue for Appraisal <%# Eval("Req_Id") %>"
                                width="9px" src="Images/plus.gif" /> </a>
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
                <asp:TemplateField>
                    <ItemTemplate>
                        <tr>
                            <td colspan="100%">
                                <div id="div<%# Eval("Req_Id") %>" style="display:none;position: relative; 
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
                                                    <asp:ImageButton ID="ImageEdit" runat="server" ImageUrl="~/Images/edit.gif" ToolTip="Select" Width="22px" Height="22px" CommandName="Select"  />              
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
    </asp:Content>

