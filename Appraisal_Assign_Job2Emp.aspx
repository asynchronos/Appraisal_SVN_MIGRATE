<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Appraisal_Assign_Job2Emp.aspx.vb" Inherits="Appraisal_Assign_Job2Emp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src="Js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="Js/common.js" type="text/javascript"></script>

    <script src="Js/jquery.js" type="text/javascript"></script>

    <style type="text/css">
        .TableWidth
        {
            width: 100%;
        }
        .headDetail
        {
            font-weight: bold;
            color: Blue;
            background-color: Yellow;
        }
        .expleanColour
        {
            background-color: Silver;
            width: 300px;
        }
        .fColor
        {
            color: red;
        }
        .bgcolour
        {
            background-color: Gray;
        }
        .outerPopup
        {
            background-color: Gray;
            padding: 0px5px5px5px;
            border-style: solid;
            border-color: Yellow;
            border-width: 1px;
        }
        .innerPopup
        {
            background-color: #fff;
        }
        .modalBackground1
        {
            background-color: #000;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }
    </style>

    <script type="text/javascript">
        var popup;
        var reqid;
        var hubid;

        function selectAppraisaler(appraisalId, appraisalName, hubId, hubName) {
            document.getElementById('<%=TextBoxAppraisal_Id.ClientID%>').value = appraisalId
            document.getElementById('<%=TextBoxAppraisal_Name.ClientID%>').value = appraisalName
            document.getElementById('<%=TextBoxHub_Id.ClientID%>').value = hubId
            document.getElementById('<%=TextBoxHub_Name.ClientID%>').value = hubName
            popup.$find('mpeBehaviorAssign2Appraisaler');
            this.popup.hide();
        }
        function HighlightRow(chk) {
            if (chk.checked) {
                var row = $(this);
                $("#" + chk.id).parent("td").parent("tr").css("background-color", "Red");
                $("#<%=GridView1.ClientID %> tr").each(function() {
                    var row = $(this);
                    if (!this.rowIndex) return;
                    if ($(this).find('input:checkbox').attr("checked")) {
                        hubid = $(this).find("td", row).eq(2).text();
                        //alert('Req Id : ' + reqid);
                        //alert('Hub Id : ' + hubid);
                        document.getElementById('<%=HdfHub_Id.ClientID%>').value = hubid;
                        //alert(document.getElementById('<%=HdfHub_Id.ClientID%>').value);
                    } else {

                    }
                });
            } else {
                $("#" + chk.id).parent("td").parent("tr").css("background-color", "white");
            }
        }
        function SelectAllCheckboxes(chk) {
            $('#<%=GridView1.ClientID %> >tbody >tr >td >input:checkbox').attr('checked', chk.checked);
        }

        $(document).ready(function() {
            $('#ImageAssign').click(function() {
                $("#<%=GridView1.ClientID %> tr").each(function() {
                    var row = $(this);
                    if (!this.rowIndex) return;
                    if ($(this).find('input:checkbox').attr("checked")) {
                        //alert($(this).find('input:checkbox').attr("checked"));
                        reqid = $(this).find("td", row).eq(1).text();
                        _hubid = getEleByProperty("input", "myId", "TextBoxHub_Id");
                        //hubid = $(this).find("td", row).eq(2).text();
                        var _AppraisalId = getEleByProperty("input", "myId", "TextBoxAppraisal_Id");
                        var userAssign = document.getElementById('<%=HdfUSER_LOGIN.ClientID%>').value
                        //alert('Req Id : ' + reqid);
                        //alert('Hub Id : ' + _hubid.value);
                        //alert('Appraisal Id : ' + _AppraisalId.value);
                        //document.getElementById('<%=HdfHub_Id.ClientID%>').value = hubid;

                        //******* Update Data ******************
                        if (_AppraisalId.value == '') {
                            alert('คุณไม่ได้เลือกผู้ประเมิน!');
                        } else {
                            PageMethods.SaveAssignJob(reqid, _hubid.value, _AppraisalId.value,userAssign , this.callback1);
                            alert('Save data compleate!');
                            window.location.replace(window.location);
                        }

                    } else {
                        //alert('คุณยังไม่ได้เลือกคำขอประเมิน !!!');
                    }
                });
            });
        });

        function callback(result) {
            //  hide the popup
            this._popup.hide();

            if (result) {
                var _temp_AID = getEleByProperty("input", "myId", "TextBoxTemp_AID");
                //alert(return_result.Temp_AID);
                _temp_AID.value = return_result.Temp_AID;
                alert('Save data compleate!');
            }
            else {
                alert('Warning, Save not compleate!');
            }
        }

        function callback1(result) {
            //  hide the popup
            //this._popup.hide();

            //  let the user know if their credit card was validated
            if (result) {
                alert('Update data compleate!');
            }
            else {
                alert('Warning, Update not compleate!');
            }
        }

        //        $(function() {
        //            $("#GridView1 tr").click(function(event) {
        //                var row = $(this);
        //                var firstParam = $("td", row).eq(0).text();
        //                var secondParam = $("td", row).eq(1).text();
        //                var navUrl = "http://localhost:7250/GridViewRowJQuery/CustomerDetails.aspx?cid=" + firstParam + "&cname=" + secondParam;
        //                top.location = navUrl;
        //            });
        //        });   

        function changeIframeSrcById(id, url, param) {
            var urlFull = "";
            //var popup = $find('mpeBehaviorBuilding');
            var iframe = document.getElementById(id);
            //alert(url);
            if (param) {
                urlFull = url + "?" + param;
            } else {
                urlFull = url;
            }
            //alert(encodeURI(urlFull));
            iframe.src = encodeURI(urlFull);
            //popup.show();
        }

        function concatParam(oldParam, addParamTag, addParamMyId, addParamKey) {
            var result = oldParam;
            var dom = null;

            if (addParamTag == "input") {
                dom = getEleByProperty(addParamTag, "myId", addParamMyId)
            } else if (addParamTag == "select") {

            }

            if (dom.value.length >= 1) {
                result = result + "&" + addParamKey + "=" + dom.value
            } else {
                //alert('โปรดตรวจสอบว่ามีรายละเอียดจังหวัด รายละเอียดอำเภอ แล้วหรือไม่');
            }
            //alert(result);
            return result;
        }


        function changeSearchAppraisalerIframeSrc() {
            var _hubid = document.getElementById('<%=HdfHub_Id.ClientID%>').value;
            var myId = "IframeAssign2Appraisaler";
            var url = "Appraisal_ID.aspx";
            var param = "Appraisal_Id=" + 'TextBoxAppraisal_Id' + "&Appraisal_Name=" + 'TextBoxAppraisal_Name' + "&Hub_Id=" + 'TextBoxHub_Id' + "&Hub_Name=" + 'TextBoxHub_Name' + "&HubId=" + _hubid + "&PopupModal=mpeBehaviorAssign2Appraisaler";

            changeIframeSrcById(myId
                , url
                , param
            );
            //            popup = $find('mpeBehaviorAssign2Appraisaler');
            //            popup.show();
        }
        function makevisible(cur, which) {
            strength = (which == 0) ? 1 : 0.2
            if (cur.style.MozOpacity)
                cur.style.MozOpacity = strength
            else if (cur.filters)
                cur.filters.alpha.opacity = strength * 100
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <br />
    <br />
    <table class="TableWidth">
        <tr class="bgcolour" style="height: 30px;">
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td class="bgcolour">
                            รหัสพนักงานผู้ประเมิน
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxAppraisal_Id" runat="server" Width="80px" myId="TextBoxAppraisal_Id"
                                onfocus="this.blur();"></asp:TextBox>
                            <asp:Button ID="ButtonSearchAppraisal_Id" runat="server" Text="...." OnClientClick="changeSearchAppraisalerIframeSrc(); return false;" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="bgcolour">
                            ชื่อพนักงานผู้ประเมิน
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxAppraisal_Name" runat="server" Width="250px" myId="TextBoxAppraisal_Name"
                                onfocus="this.blur();"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td class="bgcolour">
                            รหัสศูนย์หรือHubที่สังกัด
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxHub_Id" runat="server" Width="80px" myId="TextBoxHub_Id"
                                onfocus="this.blur();"></asp:TextBox>
                        </td>
                        <td rowspan="2" style="border: thin solid #0000FF">
                            <%--<asp:ImageButton ID="ImageButtonAssign" runat="server" ImageUrl="~/Images/8_64x64.png"
                                Width="52px" ToolTip="Assign งานให้กับผู้ประเมิน" />--%>
                            <img id="ImageAssign" alt="" src="Images/8_64x64.png" style="filter:alpha(opacity=20);-moz-opacity:0.2" onmouseover="makevisible(this,0)" onmouseout="makevisible(this,1)" />
                        </td>
                    </tr>
                    <tr>
                        <td class="bgcolour">
                            ชื่อศูนย์หรือ Hub ที่สังกัด
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxHub_Name" runat="server" Width="250px" myId="TextBoxHub_Name"
                                onfocus="this.blur();"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="bgcolour">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="เลือกเงื่อนไขการค้นหา"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListOptionSearch" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSearchValue" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="ButtonSearch" runat="server" Text="Search" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
                    BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataSourceID="SqlDataSource1"
                    EmptyDataText="There are no data records to display." Font-Size="Small" ForeColor="Black"
                    GridLines="None" Width="100%" AllowPaging="True" DataKeyNames="Req_Id" PageSize="11">
                    <FooterStyle BackColor="Tan" />
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox runat="server" ID="cb1" onclick="javascript:SelectAllCheckboxes(this);" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="cb2" onclick="javascript:HighlightRow(this);" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Req No.">
                            <ItemTemplate>
                                <asp:Label ID="lblReq_Id" runat="server" Text='<%# Bind("Req_Id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hub ID">
                            <ItemStyle HorizontalAlign="Center" />
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
                        <%--                        <asp:TemplateField HeaderText="ชื่อผู้ส่งประเมิน">
                            <ItemTemplate>
                                <asp:Label ID="LabelEmp_Name" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="รหัสวิธี">
                            <ItemStyle HorizontalAlign="Center" />
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
                        <%--                        <asp:TemplateField HeaderText="">
                            <ItemStyle HorizontalAlign="Center" Width="25px" />
                            <ItemTemplate>
                                <asp:ImageButton ID="imgEdit" runat="server" Height="22px" ImageUrl="~/Images/8_64x64.png"
                                    ToolTip="มอบหมายงานให้เจ้าหน้าที่ประเมิน" Width="22px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemStyle HorizontalAlign="Center" Width="25px" />
                            <ItemTemplate>
                                <asp:ImageButton ID="imgCancel" runat="server" Height="22px" ImageUrl="~/Images/page_cancel.ico"
                                    ToolTip="ยกเลิกการประเมิน" Width="22px" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                    </Columns>
                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <%--<asp:Button ID="btnsearch1" runat="server" style="display:none" />--%>
    <%--<input type="button" id="btnsearch1" value="" runat="server" style="display: none" />--%>
    <cc1:ModalPopupExtender ID="ModalPopupExtenderAssign2Appraisaler" runat="server"
        TargetControlID="ButtonSearchAppraisal_Id" PopupControlID="panelAssign2Appraisaler"
        BackgroundCssClass="modalBackground1" BehaviorID="mpeBehaviorAssign2Appraisaler">
    </cc1:ModalPopupExtender>
    <cc1:RoundedCornersExtender ID="RoundedCornersExtenderAssign2Appraisaler" runat="server"
        TargetControlID="pnlInnerPopupAssign2Appraisaler" BorderColor="black" Radius="4">
    </cc1:RoundedCornersExtender>
    <asp:Panel ID="panelAssign2Appraisaler" runat="server" CssClass="outerPopup" Style="display: none;">
        <asp:Panel ID="pnlInnerPopupAssign2Appraisaler" runat="server" Width="800px" CssClass="innerPopup">
            <iframe id="IframeAssign2Appraisaler" src="" width="800" height="550" frameborder="0"
                scrolling="yes"></iframe>
        </asp:Panel>
        <div style="white-space: nowrap; text-align: center;">
            <asp:Button ID="ButtonCloseAssign2Appraisaler" runat="server" Text="Close" Width="65px" />
        </div>
    </asp:Panel>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="GET_APPRAISAL_WAIT_FOR_ASSIGN" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="HdfUSER_LOGIN" Name="USER_LOGIN" PropertyName="Value"
                Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:HiddenField ID="HdfUSER_LOGIN" runat="server" />
    <asp:HiddenField ID="HdfHub_Id" runat="server" />
</asp:Content>
