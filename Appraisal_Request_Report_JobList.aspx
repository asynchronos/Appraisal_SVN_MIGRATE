<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Appraisal_Request_Report_JobList.aspx.vb" Inherits="Appraisal_Request_Report_JobList"
    UICulture="th-TH" Culture="th-TH" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="ExportControl/ExportControl.ascx" TagName="ExportControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="Js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="Js/common.js" type="text/javascript"></script>
    <script src="Js/jquery.js" type="text/javascript"></script>
    <style type="text/css">
        .tablewidth
        {
            width: 100%;
        }
        .bgColour
        {
            background-color: Gray;
        }
        .GrayedOut
        {
            background-color: Gray;
            filter: alpha(opacity=95);
            -moz-opacity: 0.5;
            -khtml-opacity: 0.5;
            opacity: 0.5;
        }
        .modalBox
        {
            background-color: #f5f5f5;
            border-width: 3px;
            border-style: solid;
            border-color: Blue;
            padding: 1px;
        }
        .modalBackground
        {
            background-color: #CCCCFF;
            filter: alpha(opacity=40);
            opacity: 0.5;
        }
        .ModalWindow
        {
            border: solid1px#c0c0c0;
            background: #f0f0f0;
            padding: 0px10px10px10px;
            position: absolute;
            top: -1000px;
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
            filter: alpha(opacity=80);
            opacity: 0.7;
        }        
    </style>

    <script type="text/javascript">
        var _popup;
        function changeIframeSrcById(id, url, param) {
            var urlFull = "";
            //var popup = $find('mpeBehaviorBuilding');
            var iframe = document.getElementById(id);
            if (param) {
                urlFull = url + "?" + param;
            } else {
                urlFull = url;
            }
            iframe.src = encodeURI(urlFull);

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
        function changeAppraisalRequestIframeSrc(reqid, hubid, cif,title, name,lastname, collnumber, appid, branchid, ceateDate) {
            //alert(reqid);
            //alert(hubid);
            //alert(cif);
            //alert(cifname);
            //alert(collnumber);
            //alert('App ID : ' + appid);
            //alert('Branch ID : ' + branchid);
            //alert('Create Date : ' + ceateDate);
            var myId = "IframeEditAppraisalRequest";
            var url = "Appraisal_Request_Edit.aspx";
            var param = "Req_Id=" + reqid + "&Hub_Id=" + hubid + "&Cif=" + cif + "&Title=" + title + "&CifName=" + name + "&CifLastname=" + lastname + "&CollNumber=" + collnumber + "&AppId=" + appid + "&BranchId=" + branchid + "&CeateDate=" + ceateDate + "&PopupModal=mpeBehaviorEditAppraisalRequest";
            
            changeIframeSrcById(myId
                , url
                , param
            );
            _popup = $find('mpeBehaviorEditAppraisalRequest');
            _popup.show();
        }        
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptLocalization="true"
        EnableScriptGlobalization="true">
    </asp:ScriptManager>
    <br />
    <br />
    <table class="tablewidth">
        <tr class="bgColour">
            <td>
                <table>
                    <tr>
                        <td class="bgColour">
                            รหัสพนักงาน Register
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxEmp_Id" runat="server" Width="80px" myId="TextBoxAppraisal_Id"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="bgColour">
                            CIF ลูกค้า
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxCIF" runat="server" myId="TextBoxAppraisal_Name"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="bgColour">
                            รหัสศูนย์หรือHubที่สังกัด
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListHub" runat="server" DataSourceID="SqlHubList" DataTextField="HUB_NAME"
                                DataValueField="HUB_ID">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="bgColour">
                            ชนิดงานเข้า
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListApptype" runat="server" DataSourceID="SqlDataSource_APPLICATION_TYPE"
                                DataTextField="APP_TYPE_NAME" DataValueField="APP_TYPE_ID">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="bgColour">
                            วันที่นำเรื่องเข้า
                        </td>
                        <td>
                            <asp:TextBox ID="TxtCalendar" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TxtCalendar"
                                Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="bgColour">
                            <uc1:ExportControl ID="ExportControl1" runat="server" ControlName="GridView1" Filename="ReportRegisterList"
                                AutoGenerateColumns="False" />
                        </td>
                        <td>
                            <asp:Button ID="ButtonSearch" runat="server" Text="ค้นหา" Width="120px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" DataSourceID="SqlDataSourceReportList"
                    AutoGenerateColumns="False" DataKeyNames="Req_ID,Hub_ID" Style="font-size: small"
                    BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2"
                    ForeColor="Black" GridLines="None" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="Req_ID" HeaderText="Req_ID" ReadOnly="True" SortExpression="Req_ID" />
                        <asp:BoundField DataField="Cif" HeaderText="Cif" SortExpression="Cif" />
                       
                        
                        <asp:BoundField DataField="CustomerName" HeaderText="ชื่อ-สกุล ลูกค้า" ReadOnly="True"
                            SortExpression="CustomerName" />
                        <asp:BoundField DataField="CollOfNumber" HeaderText="เลขที่หลักประกัน" SortExpression="CollOfNumber" />
                        <asp:BoundField DataField="TambonName" HeaderText="ตำบล" SortExpression="TambonName" />
                        <asp:BoundField DataField="AmphurName" HeaderText="อำเภอ" SortExpression="AmphurName" />
                        <asp:BoundField DataField="ProvinceName" HeaderText="จังหวัด" SortExpression="ProvinceName" />
                        <asp:BoundField DataField="Branch_Id" HeaderText="รหัสสาขา" SortExpression="Branch_Id" />
                       
                        <asp:BoundField DataField="Create_Date" HeaderText="วันนำเรื่องเข้า" SortExpression="Create_Date" />
                        <asp:BoundField DataField="Hub_ID" HeaderText="รหัสศูนย์" ReadOnly="True" SortExpression="Hub_ID" />
                        <asp:BoundField DataField="HUB_NAME" HeaderText="ศูนย์ประเมิน" SortExpression="HUB_NAME" />
                        <asp:BoundField DataField="APP_TYPE_NAME" HeaderText="ประเภทงานเข้า" SortExpression="APP_TYPE_NAME" />
                        <asp:BoundField DataField="Emp_Name" HeaderText="เจ้าหน้าที่นำเข้า" SortExpression="Emp_Name" />
                        <asp:TemplateField HeaderText="">
                            <ItemStyle HorizontalAlign="Center" Width="25px" />
                            <ItemTemplate>
                                <asp:ImageButton ID="imgEdit" runat="server" Height="22px" ImageUrl="~/Images/pencil.png"
                                    ToolTip="มอบหมายงานให้เจ้าหน้าที่ประเมิน" Width="22px" OnClientClick='<%# "changeAppraisalRequestIframeSrc("+Eval("Req_ID").toString()+","+Eval("Hub_ID").toString()+","+Eval("Cif").toString()+","+Eval("Title").toString()+","""+Eval("Name").toString()+""","""+Eval("Lastname").toString()+""","""+Eval("CollOfNumber").toString()+""","+Eval("APP_TYPE_ID").toString()+","+Eval("Branch_Id").toString()+","""+Eval("Create_Date").toString()+"""); return false;" %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="Tan" />
                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <asp:Button ID="bntEdit" runat="server" Style="display: none" />
    <cc1:ModalPopupExtender ID="ModalPopupExtenderEditAppraisalRequest" runat="server"
        TargetControlID="bntEdit" PopupControlID="panelEditAppraisalRequest" BackgroundCssClass="modalBackground1"
        BehaviorID="mpeBehaviorEditAppraisalRequest">
    </cc1:ModalPopupExtender>
    <cc1:RoundedCornersExtender ID="RoundedCornersExtenderEditAppraisalRequest" runat="server"
        TargetControlID="pnlInnerPopupEditAppraisalRequest" BorderColor="black" Radius="4">
    </cc1:RoundedCornersExtender>
    <asp:Panel ID="panelEditAppraisalRequest" runat="server" CssClass="outerPopup" Style="display: none;">
        <asp:Panel ID="pnlInnerPopupEditAppraisalRequest" runat="server" Width="600px" CssClass="innerPopup">
            <iframe id="IframeEditAppraisalRequest" src="" width="600" height="480" frameborder="0"
                scrolling="no"></iframe>
        </asp:Panel>
    </asp:Panel>
    <asp:SqlDataSource ID="SqlDataSourceReportList" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="GET_APPRAISAL_LIST_BY_HUB_MASTER" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="LabelWhereCondition" Name="WhereCondition" PropertyName="Text"
                Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlHubList" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT HUB_ID, HUB_NAME FROM TB_HUB WHERE (HUB_ID &lt; '998')">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource_APPLICATION_TYPE" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [APP_TYPE_ID], [APP_TYPE_NAME] FROM [TB_APPLICATION_TYPE]">
    </asp:SqlDataSource>
    <asp:Label ID="LabelWhereCondition" runat="server" Style="display: none"></asp:Label>
</asp:Content>
