<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Appraisal_AssignJob.aspx.vb" Inherits="Appraisal_AssignJob" Culture="th-TH"
    UICulture="th-TH" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
        .divCol
        {
            font-weight: bold;
            color: blue;
            float: left;
            width: 140px;
            text-align: left;
            margin-right: 30px;
            white-space: nowrap;
        }
        .modalBox
        {
            background-color: #f5f5f5;
            border-width: 3px;
            border-style: solid;
            border-color: Blue;
            padding: 3px;
        }
        .modalBox caption
        {
            background-image: url(images/window_titlebg.gif);
            background-repeat: repeat-x;
        }
        .divColLast
        {
            float: left;
            white-space: nowrap;
        }
        .clearer
        {
            clear: both;
            overflow: hidden;
            background-color: transparent;
            filter: alpha(opacity=0);
            opacity: 0.0;
            height: 1px;
            margin: 1px 1px 1px 1px;
            max-height: 2px;
        }
        .Timg
        {
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

    <script type="text/javascript">
        function openMap(reqid, hubid, reqType) {
            //alert(reqType);
            if (reqType == 1) {
                window.open('CollDetail_Show_Position.aspx?Req_Id=' + reqid + '&Hub_Id=' + hubid, 'mapLocation', 'toolbar=no,menubar=no,scrollbars=yes,target = _blank,height=680px,width=840px');
            }
            else {
                alert('การทบทวนราคาประเมิน ไม่ได้กำหนดจุดที่ตั้งหลักประกัน ของการกำหนดราคาที่ 1 ');

                //popup = $find('mdlCollDetailbeh').show();
                //myIFrame = document.getElementById("frameCollDetail");
                //$find('mdlCollDetailbeh')
                //myIFrame.src = "popupLand_Price2.aspx?Req_Id=" + reqid + "&Hub_Id=" + hubid + "&ID=" + id;
                //popup = $find("mdlCollDetailbeh").show();

                //document.getElementById("frameCollDetail.clientID").src = "popupLand_Price2.aspx?Req_Id=" + reqid + "&Hub_Id=" + hubid + "&ID=" + id;
                //popup = $find("mdlCollDetailbeh").show();               
                //document.frames['frameCollDetail'].location.href = 'popupLand_Price2.aspx?Req_Id=' + reqid + '&Hub_Id=' + hubid + '&ID=' + id;
            }
        }

        function openCollDetail(reqid, hubid, id, collTypeId) {
            //alert(collTypeId);
            var myIFrame;
            var popup;
            if (collTypeId = 50) {

                window.open('popupLand_Price2.aspx?Req_Id=' + reqid + '&Hub_Id=' + hubid + '&ID=' + id, 'mapLocation', 'toolbar=no,menubar=no,scrollbars=yes,/target= _blank,height=680px,width=840px');

            }
            else {

            }
        }

        function saveAssignJob() {
            var req_id = $get('<%=txtReqId.ClientID %>').value;
            //alert(req_id);
            var hub_id = $get('<%=HdfHub_Id.ClientID %>').value;
            //alert(hub_id);
            var IndexValueStatus = $get('<%=ddlStatus.ClientID %>').selectedIndex;
            var SelectedValStatus = $get('<%=ddlStatus.ClientID %>').options[IndexValueStatus].value;
            //alert(SelectedValStatus);                   
            var IndexValue = $get('<%=ddlAppraisal2.ClientID %>').selectedIndex;
            var SelectedVal = $get('<%=ddlAppraisal2.ClientID %>').options[IndexValue].value;
            //alert(SelectedVal);
            PageMethods.SaveAssignJob(req_id, hub_id, SelectedValStatus, SelectedVal, this.callback);
        }

        function callback(result) {
            //  hide the popup
            //this._popup.hide();

            //  let the user know if their credit card was validated
            if (result) {
                alert('Save data compleate!');
                location.reload("Appraisal_AssignJob.aspx");
                //window.opener.location.href = window.opener.location;
            }
            else {
                alert('Warning, Save not compleate!');
            }
        }
        
        function makeNewOpenWindow(redid,hubid) {
            var windowFeatures;
            var newWindow;
            var approveId = document.getElementById('<%=HiddenField_ApproveId.ClientID%>').value;
            //alert(redid);
            //alert(hubid);
            //var reqId = $get('<%=txtReqId.ClientID %>').value;
            //var hubId = $get('<%=HdfHub_Id.ClientID %>').value;

            windowFeatures = "top=0,left=0,resizable=yes,scrollbars=yes,width=" + (screen.width) + ",height=" + (screen.height);
            newWindow = window.open("Appraisal_Report_FullForm.aspx?Req_Id=" + redid + "&Hub_Id=" + hubid + "&ApproveId=" + approveId, "openWindow", windowFeatures);
            newWindow.focus();
        }     
    </script>

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

        function getDropDownListvalue() {
            var IndexValue = $get('<%=ddlAppraisal2.ClientID %>').selectedIndex;
            var SelectedVal = $get('<%=ddlAppraisal2.ClientID %>').options[IndexValue].value;

            alert(SelectedVal);
        }
         
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <asp:ScriptManager ID="sm1" runat="server" EnablePageMethods="true" />
    <%--Collateral Location Popup Display--%>
    <asp:UpdatePanel ID="up1" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="Sorting" />
        </Triggers>
        <ContentTemplate>
            <div>
                <asp:Label ID="Label1" runat="server" Text="รายการที่รอดำเนินการ" Style="font-weight: 700;
                    color: #3333CC"></asp:Label>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
                    BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataSourceID="SqlDataSource1"
                    EmptyDataText="There are no data records to display." Font-Size="Small" ForeColor="Black"
                    GridLines="None" ShowFooter="True" Width="100%" AllowPaging="True" PageSize="15"
                    DataKeyNames="Req_Id">
                    <FooterStyle BackColor="Tan" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <a href="javascript:expandcollapse('div<%# Eval("Req_Id") %>', 'one');">
                                    <img id="imgdiv<%# Eval("Req_Id") %>" alt="Click to show/hide Queue for Appraisal <%# Eval("Req_Id") %>"
                                        width="9px" src="Images/plus.gif" />
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
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
                                <asp:Label ID="lblAppraisal_Method_Name" runat="server" Text='<%# Bind("Method_Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="สถานะการประเมิน">
                            <ItemTemplate>
                                <asp:HiddenField ID="hdfStatus_Id" runat="server" Value='<%# Bind("Status_Id") %>' />
                                <asp:Label ID="LabelStatus_Name" runat="server" Text='<%# Bind("Status_Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="วันที่ส่งประเมิน">
                            <ItemTemplate>
                                <asp:Label ID="LabelCreate_Date" runat="server" Text='<%# Bind("Create_Date", "{0:d}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemStyle HorizontalAlign="Center" Width="25px" />
                            <ItemTemplate>
                                <asp:ImageButton ID="imgEdit" runat="server" Height="22px" ImageUrl="~/Images/pencil.png"
                                    OnClick="btnSaveAssignJob_Click" ToolTip="มอบหมายงานให้เจ้าหน้าที่ประเมิน" Width="22px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemStyle HorizontalAlign="Center" Width="25px" />
                            <ItemTemplate>
                                <%--                           <asp:ImageButton ID="imgConfirm" runat="server" Height="22px" 
                                ImageUrl="~/Images/dollar.jpg" ToolTip="รายละเอียดการกำหนดราคา" Width="22px" OnClick="imgConfirm_Click" />  --%>
                                <asp:ImageButton ID="imgConfirm" runat="server" Height="22px" ImageUrl="~/Images/dollar.jpg"
                                    ToolTip="รายละเอียดการกำหนดราคา" Width="22px" OnClientClick='<%# "makeNewOpenWindow("+Eval("Req_Id").toString()+","+EVAL("Hub_Id").toString()+"); return false;" %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemStyle Width="25px" />
                            <ItemTemplate>
                                <asp:ImageButton ID="imgLocation" runat="server" ImageUrl="~/Images/viewmap.jpg"
                                    Height="22px" Width="22px" ToolTip="แผนที่หลักประกัน" OnClientClick='<%# "openMap("+Eval("Req_Id").toString()+","+EVAL("Hub_Id").toString()+","+EVAL("Req_Type").toString()+"); return false;" %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemStyle Width="25px" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:ImageButton ID="imgCollPic_Price1" runat="server" ImageUrl="~/Images/camera2.png"
                                    Height="22px" Width="22px" ToolTip="รูปภาพรายละเอียดการขอประเมิน" OnClick="imgCollPic_Price1_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--            <asp:TemplateField HeaderText="">
                <ItemStyle Width="25px" HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgCollPic" runat="server" 
                        ImageUrl="~/Images/camera2.png" Height="22px" Width="22px" 
                        ToolTip="รูปหลักประกัน"  OnClick="imgCollPic_Click" />
                </ItemTemplate>                           
            </asp:TemplateField>     --%>
                        <%--            <asp:TemplateField>
                <ItemTemplate>
                    <tr>
                        <td colspan="100%">
                            <div id='div<%# Eval("Req_Id") %>' style="display:none;position: relative; 
                                left: 15px; overflow: auto; width: 97%">
                            </div>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:TemplateField>--%>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <tr>
                                    <td colspan="100%">
                                        <div id="div<%# Eval("Req_Id") %>" style="display: none; position: relative; left: 15px;
                                            overflow: auto; width: 97%">
                                            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True"
                                                AutoGenerateColumns="False" BackColor="#EEEEDD" BorderColor="#0083C1" BorderStyle="Double"
                                                DataKeyNames="Req_Id" Font-Names="Verdana" Font-Size="Small" GridLines="None"
                                                OnRowDataBound="GridView2_RowDataBound" OnSelectedIndexChanging="GridView2_SelectedIndexChanging"
                                                ShowFooter="false" Width="100%">
                                                <HeaderStyle BackColor="#0083C1" ForeColor="White" />
                                                <FooterStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Temp AID">
                                                        <ItemStyle VerticalAlign="Middle" Width="80px" />
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="H_ID" runat="server" Value='<%# Eval("ID") %>' />
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
                                                            <asp:HiddenField ID="H_CIF" runat="server" Value='<%# Eval("Cif") %>' />
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
                                                    <asp:TemplateField HeaderText="หลักประกัน">
                                                        <ItemStyle VerticalAlign="Middle" Width="120px" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblColltype" runat="server" Text='<%# Eval("CollType_ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="ชื่อหลักประกัน">
                                                        <ItemStyle VerticalAlign="Middle" Width="200px" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCollName" runat="server" Text='<%# Eval("SubCollType_Name") %>'></asp:Label>
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
                                                    <%--                                            <asp:TemplateField HeaderText="">
                                                <ItemStyle VerticalAlign="Middle" Width="30px" />
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImageCollDetail" runat="server" ImageUrl="~/Images/page_accept.ico" ToolTip="Select" Width="22px" Height="22px" OnClientClick='<%# "openCollDetail("+Eval("Req_Id").toString()+","+EVAL("Hub_Id").toString()+","+EVAL("ID").toString()+","+EVAL("CollType_ID").toString()+")" %>' />                                               
                                                </ItemTemplate>
                                            </asp:TemplateField>   
                                            <asp:TemplateField HeaderText="">
                                                <ItemStyle VerticalAlign="Middle" Width="30px" />
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImageCollDetail1" runat="server" ImageUrl="~/Images/page_accept.ico" ToolTip="Select" Width="22px" Height="22px" OnClick="ImageCollDetail_Click" />                                                   
                                                </ItemTemplate>
                                            </asp:TemplateField>  --%>
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemStyle VerticalAlign="Middle" Width="30px" />
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImageCollDetail2" runat="server" ImageUrl="~/Images/page_accept.ico"
                                                                ToolTip="Select" Width="22px" Height="22px" CommandName="Select" />
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
                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                </asp:GridView>
                <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
                <cc1:ModalPopupExtender ID="mdlPopup" runat="server" TargetControlID="btnShowPopup"
                    PopupControlID="pnlCities" OkControlID="btnSaveAssignJob" CancelControlID="btnClose"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="pnlCities" runat="server" CssClass="modalBox" Style="display: none;"
                    Width="430px">
                    <asp:Panel ID="Panel2" runat="server" CssClass="caption" Style="margin-bottom: 0px;
                        cursor: hand;">
                        มอบหมายงาน หรือ ยกเลิก</asp:Panel>
                    <div class="divCol">
                        เลขคำขอประเมิน</div>
                    <div class="divColLast">
                        <asp:TextBox ID="txtReqId" runat="server" MaxLength="64" Width="250"></asp:TextBox>
                    </div>
                    <div class="clearer">
                    </div>
                    <div class="divCol">
                        ชื่อ-สุกล ลูกค้า</div>
                    <div class="divColLast">
                        <asp:TextBox ID="txtMiddleName" runat="server" MaxLength="64" Width="250"></asp:TextBox>
                    </div>
                    <div class="clearer">
                    </div>
                    <div class="divCol">
                        ผู้ส่งประเมิน</div>
                    <div class="divColLast">
                        <asp:TextBox ID="txtSenderName" runat="server" MaxLength="64" Width="250"></asp:TextBox>
                    </div>
                    <div class="clearer">
                    </div>
                    <div class="divCol">
                        วันที่ส่งประเมิน
                    </div>
                    <div class="divColLast">
                        <asp:Label ID="lblSent_Date" runat="server" MaxLength="64" Width="250"></asp:Label>
                    </div>
                    <div class="clearer">
                    </div>
                    <div class="divCol">
                        สถานะการประเมิน
                    </div>
                    <div class="divColLast">
                        <asp:DropDownList ID="ddlStatus" runat="server" DataSourceID="sdsStatus" DataTextField="Status_Name"
                            DataValueField="Status_ID" Width="250">
                        </asp:DropDownList>
                    </div>
                    <div class="clearer">
                    </div>
                    <div class="divCol">
                        ผู้ประเมิน
                    </div>
                    <div class="divColLast">
                        <asp:DropDownList ID="ddlAppraisal2" runat="server" DataSourceID="sdsAppraisal2"
                            DataTextField="UserAppraisal" DataValueField="Appraisal_Id" Width="250">
                        </asp:DropDownList>
                    </div>
                    <div class="clearer">
                    </div>
                    <div class="divCol">
                    </div>
                    <div style="white-space: nowrap; text-align: center;">
                        <asp:Button ID="btnSaveAssignJob" runat="server" Text="Save" Width="50px" OnClientClick="saveAssignJob();" />
                        <asp:Button ID="btnClose" runat="server" Text="Close" Width="50px" />
                    </div>
                </asp:Panel>
                <asp:Button ID="btnShowConfirm" runat="server" Style="display: none" />
                <cc1:ModalPopupExtender ID="mdlconfirm" runat="server" TargetControlID="btnShowConfirm"
                    PopupControlID="pnlConfrim" CancelControlID="btnClose" BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="pnlConfrim" runat="server" CssClass="modalBox" Style="display: none;"
                    Width="480px">
                    <asp:Panel ID="PanelTitleConfirm" runat="server" CssClass="caption" Style="margin-bottom: 0px;
                        cursor: hand;">
                        รายละเอียดยืนยันการให้ราคาที่ 2</asp:Panel>
                    <div style="white-space: nowrap; text-align: center;">
                        <asp:Button ID="btnSaveConfrim" runat="server" Text="Save" Width="50px" OnClick="btnSaveConfrim_Click" />
                        <asp:Button ID="btnCancleConfrim" runat="server" Text="Close" Width="50px" />
                    </div>
                    <div class="divCol">
                        เลขคำขอประเมิน
                    </div>
                    <div class="divColLast">
                        <asp:Label ID="lblReq_Id_Confirm" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="clearer">
                    </div>
                    <div class="divCol">
                        รหัสศูนย์ประเมิน</div>
                    <div class="divColLast">
                        <asp:Label ID="lblHub_Id_Confirm" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="clearer">
                    </div>
                    <div class="divCol">
                        ชื่อศูนย์ประเมิน</div>
                    <div class="divColLast">
                        <asp:Label ID="lblHub_Name_Confirm" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="clearer">
                    </div>
                    <div class="divCol">
                        Cif</div>
                    <div class="divColLast">
                        <asp:Label ID="lblCif_Confirmm" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="clearer">
                    </div>
                    <div class="divCol">
                        Cif Name</div>
                    <div class="divColLast">
                        <asp:Label ID="lblCifName_Confirm" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="clearer">
                    </div>
                    <div class="divCol">
                        Sender Name</div>
                    <div class="divColLast">
                        <asp:Label ID="lblSenderName_Confirm" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="clearer">
                    </div>
                    <div class="divCol">
                        Appraisal Name</div>
                    <div class="divColLast">
                        <asp:Label ID="lblAppraisal_Name_Confirm" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="clearer">
                    </div>
                    <div class="divCol">
                        ราคาที่ 1</div>
                    <div class="divColLast">
                        <asp:Label ID="lblPrice1" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="clearer">
                    </div>
                    <div class="divCol">
                        ราคาที่ 2</div>
                    <div class="divColLast">
                        <asp:Label ID="lblPrice2" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="clearer">
                    </div>
                    <div class="divCol">
                        Comment</div>
                    <div class="divColLast">
                        <asp:TextBox ID="txtComment" runat="server" Height="22px" TextMode="MultiLine" Width="200px"
                            ReadOnly="True"></asp:TextBox>
                    </div>
                    <div class="clearer">
                    </div>
                    <div class="divCol">
                        ความเห็น</div>
                    <div class="divColLast">
                        <asp:RadioButtonList ID="rdbAccept" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="8">เห็นชอบ</asp:ListItem>
                            <asp:ListItem Value="7">ไม่เห็นชอบ</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div class="clearer">
                    </div>
                    <div class="divCol">
                        หมายเหตุ</div>
                    <div class="divColLast">
                        <asp:TextBox ID="txtNote_Confirm" runat="server" Height="22px" TextMode="MultiLine"
                            Width="200px"></asp:TextBox>
                    </div>
                    <div class="clearer">
                    </div>
                </asp:Panel>
                <asp:Button ID="btnShowPicture" runat="server" Style="display: none" />
                <cc1:ModalPopupExtender ID="mdlShowPicture" runat="server" TargetControlID="btnShowPicture"
                    PopupControlID="pnlShowPicture" CancelControlID="btnClose" BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="pnlShowPicture" runat="server" CssClass="modalBox" Style="display: none;"
                    Height="600px" Width="700px">
                    <%--<iframe id="frameShowPicture" src="Test/Picture_SlideShow.aspx"  height="600px" width="700px"></iframe>--%>
                    <div style="white-space: nowrap; text-align: center;">
                        <asp:Button ID="btnClose_ShowPicture" runat="server" Text="Close" Width="50px" />
                    </div>
                    <asp:ListView ID="lvPhotos" runat="server" GroupItemCount="3">
                        <LayoutTemplate>
                            <table id="groupPlaceholderContainer" runat="server" border="0" cellpadding="0" cellspacing="0">
                                <tr id="groupPlaceholder" runat="server">
                                </tr>
                            </table>
                        </LayoutTemplate>
                        <GroupTemplate>
                            <tr id="itemPlaceholderContainer" runat="server">
                                <td id="itemPlaceholder" runat="server">
                                </td>
                            </tr>
                        </GroupTemplate>
                        <ItemTemplate>
                            <td id="Td1" runat="server" align="center" style="background-color: #e8e8e8; color: #333333;">
                                <a href='<%# "UploadedFiles/Pic_Price2/" +Eval("Picture_Path") %>' target="_blank">
                                    <asp:Image CssClass="Timg" runat="server" ID="imPhoto" Width="200px" ImageUrl='<%# "UploadedFiles/Pic_Price2/" +Eval("Picture_Path") %>' />
                                </a>
                            </td>
                        </ItemTemplate>
                    </asp:ListView>
                </asp:Panel>
                <asp:Button ID="btnShowPicture_P1" runat="server" Style="display: none" />
                <cc1:ModalPopupExtender ID="mdlShowPicture_P1" runat="server" TargetControlID="btnShowPicture_P1"
                    PopupControlID="pnlShowPicture_P1" CancelControlID="btnClose" BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="pnlShowPicture_P1" runat="server" CssClass="modalBox" Style="display: none;">
                    <div style="white-space: nowrap; text-align: center;">
                        <asp:Button ID="btnClose_ShowPicture_P1" runat="server" Text="Close" Width="50px" />
                    </div>
                    <asp:ListView ID="lvShowPicture_P1" runat="server" GroupItemCount="3">
                        <LayoutTemplate>
                            <table id="groupPlaceholderContainer" runat="server" border="0" cellpadding="0" cellspacing="0">
                                <tr id="groupPlaceholder" runat="server">
                                </tr>
                            </table>
                        </LayoutTemplate>
                        <GroupTemplate>
                            <tr id="itemPlaceholderContainer" runat="server">
                                <td id="itemPlaceholder" runat="server">
                                </td>
                            </tr>
                        </GroupTemplate>
                        <ItemTemplate>
                            <td id="Td1" runat="server" align="center" style="background-color: #e8e8e8; color: #333333;">
                                <a href='<%# Eval("Pic_Path") %>' target="_blank">
                                    <asp:Image CssClass="Timg" runat="server" ID="imPhotop1" Width="100px" ImageUrl='<%# Eval("Pic_Path") %>' />
                                </a>
                            </td>
                        </ItemTemplate>
                    </asp:ListView>
                </asp:Panel>
                <asp:Button ID="btnNotice" runat="server" Style="display: none" />
                <cc1:ModalPopupExtender ID="mdlNotice" runat="server" TargetControlID="btnNotice"
                    PopupControlID="pnlNotice" CancelControlID="btnClose" BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="pnlNotice" runat="server" CssClass="modalBox" Style="display: none;">
                    <div class="divColLast" style="text-align: center;">
                        <asp:Label ID="lblNotice" runat="server" Text="">คุณไม่สามารถดำเนินการได้เนื่องจากขั้นตอนยังไม่ถึง</asp:Label>
                    </div>
                    <div class="clearer">
                    </div>
                    <div class="clearer">
                    </div>
                    <div style="white-space: nowrap; text-align: center;">
                        <asp:Button ID="btnCloseNotice" runat="server" Text="Close" Width="50px" />
                    </div>
                </asp:Panel>
                <asp:Button ID="btnCollDetail" runat="server" Style="display: none" />
                <cc1:ModalPopupExtender ID="mdlCollDetail" runat="server" TargetControlID="btnCollDetail"
                    PopupControlID="pnlCollDetail" CancelControlID="btnClose" BackgroundCssClass="modalBackground"
                    BehaviorID="mdlCollDetailbeh">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="pnlCollDetail" runat="server" CssClass="modalBox" Style="display: none;">
                    <div style="white-space: nowrap; text-align: center;">
                        <asp:Button ID="btnCloseCollDetail" runat="server" Text="Close" Width="50px" />
                    </div>
                    <iframe id="frameCollDetail" src="popupLand_Price2.aspx" height="650px" width="800px">
                    </iframe>
                </asp:Panel>
                <asp:Button ID="btnCollDetail70" runat="server" Style="display: none" />
                <cc1:ModalPopupExtender ID="mdlCollDetail70" runat="server" TargetControlID="btnCollDetail70"
                    PopupControlID="pnlCollDetail70" CancelControlID="btnClose" BackgroundCssClass="modalBackground"
                    BehaviorID="mdlCollDetailbeh70">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="pnlCollDetail70" runat="server" CssClass="modalBox" Style="display: none;">
                    <div style="white-space: nowrap; text-align: center;">
                        <asp:Button ID="btnCloseCollDetail70" runat="server" Text="Close" Width="50px" />
                    </div>
                    <iframe id="frameCollDetail70" src="popup_Building_Price2.aspx" height="650px" width="800px">
                    </iframe>
                </asp:Panel>
                <asp:Button ID="btnShowAttachFile" runat="Server" Style="display: none" />
                <cc1:ModalPopupExtender ID="mpeAttachFile" runat="server" TargetControlID="btnShowAttachFile"
                    PopupControlID="pnlAttachFile" CancelControlID="btnCancelAttachFile" BackgroundCssClass="modalBackground"
                    PopupDragHandleControlID="PersonCaption">
                </cc1:ModalPopupExtender>
                </ajaxToolKit:ModalPopupExtender>
                <asp:Panel ID="pnlAttachFile" runat="server" CssClass="modalBox" Style="display: none;"
                    Width="500px">
                    <asp:Panel ID="Panel1" runat="server" CssClass="caption" Style="margin-bottom: 10px;
                        cursor: hand;">
                        แสดงเอกสารที่ยังไม่ได้แนบ</asp:Panel>
                    <asp:HiddenField ID="HiddenField1" runat="server" Value="-1" />
                    <div class="divCol">
                        ฟอร์มคำขอประเมิน</div>
                    <div class="divColLast">
                        <asp:TextBox ID="txtAppraisalForm" runat="server" MaxLength="64" Width="250"></asp:TextBox>
                    </div>
                    <div class="clearer">
                    </div>
                    <div class="divCol">
                        รูปแผนที่หลักประกัน</div>
                    <div class="divColLast">
                        <asp:TextBox ID="txtPicMap" runat="server" MaxLength="64" Width="250"></asp:TextBox>
                    </div>
                    <div class="clearer">
                    </div>
                    <div class="divCol">
                        รูปโฉนด</div>
                    <div class="divColLast">
                        <asp:TextBox ID="txtPicChanode" runat="server" MaxLength="64" Width="250"></asp:TextBox>
                    </div>
                    <div class="clearer">
                    </div>
                    <div style="white-space: nowrap; text-align: center;">
                        <asp:Button ID="btnCancelAttachFile" runat="server" CausesValidation="false" Text="OK" />
                    </div>
                </asp:Panel>
                <asp:SqlDataSource ID="sdsPictureList" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="sdsPictureList_Price1" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
                    SelectCommand="GET_APPRAISAL_VERIFY_PROCESS_BY_HUB" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="HdfHub_Id" Name="HUB_ID" PropertyName="Value" Type="Int32" />
                        <asp:ControlParameter ControlID="HdfStatus" Name="Status_Id" PropertyName="Value"
                            Type="Int32" />
                        <asp:Parameter DefaultValue="0" Name="Appraisal_Id" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:HiddenField ID="HdfStatus" runat="server" Value="4" />
                <asp:HiddenField ID="HdfHub_Id" runat="server" />
                <asp:SqlDataSource ID="sdsAppraisal" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
                    SelectCommand="GET_USER_APPRAISAL" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="HdfHub_Id" Name="Hub_Id" PropertyName="Value" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="sdsAppraisal2" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
                    SelectCommand="GET_APPRAISAL_ID_BY_HUB" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="HdfHub_Id" Name="Hub_Id" PropertyName="Value" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="sdsStatus" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
                    SelectCommand="SELECT Status_ID, Status_Name FROM Status_Appraisal WHERE (Status_ID = @Status_ID) UNION SELECT Status_ID, Status_Name FROM Status_Appraisal AS Status_Appraisal_2 WHERE (Status_ID = 3) UNION SELECT Status_ID, Status_Name FROM Status_Appraisal AS Status_Appraisal_1 WHERE (Status_ID IN (97, 98, 99))">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="HdfStatus" Name="Status_Id" PropertyName="Value" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:HiddenField ID="HiddenField_ApproveId" runat="server" />
                <asp:Label ID="lblReq_Id_Picture" runat="server" Visible="False"></asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
