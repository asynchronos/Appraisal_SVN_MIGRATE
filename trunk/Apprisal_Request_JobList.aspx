<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Apprisal_Request_JobList.aspx.vb" Inherits="Apprisal_Request_JobList"
    UICulture="th-TH" Culture="th-TH" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="ExportControl/ExportControl.ascx" TagName="ExportControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src="Js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="Js/common.js" type="text/javascript"></script>
    <script src="Js/jquery.js" type="text/javascript"></script>

    <title>รายงานการประเมิน</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
        }
        .style11
        {
            width: 290px;
        }
        .style31
        {
            width: 144px;
        }
        .style32
        {
            width: 157px;
        }
        .style7
        {
            width: 89px;
        }
        .style33
        {
            height: 22px;
        }
        .style8
        {
            width: 92px;
        }
        .style4
        {
            width: 75px;
        }
        .style22
        {
            width: 24px;
        }
        .style28
        {
            width: 119px;
        }
        .style29
        {
            width: 10px;
        }
        .style27
        {
            width: 132px;
        }
        .style26
        {
            width: 21px;
        }
        .style23
        {
            width: 87px;
        }
        .style34
        {
            width: 595px;
        }
        .notes
        {
            margin-bottom: 5px;
            width: 900px;
            height: 100px;
            padding: 5px;
            background-color: #fff;
            background-repeat: repeat;
            display: block;
            overflow: auto;
            font-family: Tahoma;
            font-size: medium;
        }
        .txtbox
        {
            background-repeat: repeat;
            overflow: auto;
            font-family: Tahoma;
            font-size: medium;
        }
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
        .expleanColour1
        {
            background-color: red;
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
    <br />
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptLocalization="true"
        EnableScriptGlobalization="true">
    </asp:ScriptManager>
    <div>
        <table width="100%" runat="server">
            <tr>
                <td align="center" style="font-size: x-large; font-weight: bold">
                    ทะเบียนงานเข้า
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlHubList"
                        DataTextField="HUB_NAME" DataValueField="HUB_ID">
                    </asp:DropDownList>
                    &nbsp;<asp:Label ID="Label1" runat="server" Text="ชนิดงานเข้า"></asp:Label>
                    &nbsp;<asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource_APPLICATION_TYPE"
                        DataTextField="APP_TYPE_NAME" DataValueField="APP_TYPE_ID">
                    </asp:DropDownList>
                    ประจำวันที่
                    <asp:TextBox ID="TxtCalendar" runat="server"></asp:TextBox>
                    &nbsp;
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TxtCalendar"
                        Format="dd/MM/yyyy">
                    </cc1:CalendarExtender>
                    <asp:Button ID="Button1" runat="server" Text="ค้นหา" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        DataSourceID="SqlGridView" BackColor="LightGoldenrodYellow" BorderColor="Tan"
                        BorderWidth="1px" CellPadding="2" DataKeyNames="Hub_ID,Req_ID" ForeColor="Black"
                        GridLines="None" Width="100%" style="font-size: small">
                        <Columns>
                            <asp:BoundField DataField="Req_ID" HeaderText="REQ ID" ReadOnly="True" SortExpression="Req_ID" />
                            <asp:BoundField DataField="Cif" HeaderText="Cif" SortExpression="Cif" />
                            <asp:BoundField DataField="CustomerName" HeaderText="ชื่อลูกค้า" SortExpression="CustomerName"
                                ReadOnly="True" />
                            <asp:BoundField DataField="CollOfNumber" HeaderText="เลขที่หลักประกัน" SortExpression="CollOfNumber" />
                            <asp:BoundField DataField="TambonName" HeaderText="ตำบล" SortExpression="TambonName" />
                            <asp:BoundField DataField="AmphurName" HeaderText="อำเภอ" SortExpression="AmphurName" />
                            <asp:BoundField DataField="ProvinceName" HeaderText="จังหวัด" SortExpression="ProvinceName" />
                            <asp:BoundField DataField="Branch_Id" HeaderText="รหัสฝ่ายงาน/สาขา" SortExpression="Branch_Id"
                                ReadOnly="True" />
                            <asp:BoundField DataField="DeptSender" HeaderText="ฝ่ายงาน/สาขา ที่ส่ง" SortExpression="DeptSender"
                                ReadOnly="True" />
                            <asp:TemplateField HeaderText="วันที่ส่งเรื่อง" SortExpression="Create_Date">
                                <ItemTemplate>
                                    <asp:HiddenField ID="HiddenFieldTitle" runat="server" Value='<%# Eval("Title") %>'/>
                                    <asp:HiddenField ID="HiddenFieldName" runat="server" Value='<%# Eval("Name") %>'/>
                                    <asp:HiddenField ID="HiddenFieldLastname" runat="server" Value='<%# Eval("Lastname") %>'/>                                
                                    <asp:Label ID="LabelCreate_Date" runat="server" Text='<%# Bind("Create_Date", "{0:d}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Hub_ID" HeaderText="รหัสศูนย์" SortExpression="Hub_ID"
                                ReadOnly="True" />
                            <asp:BoundField DataField="HUB_NAME" HeaderText="ศูนย์ประเมิน" SortExpression="HUB_NAME" />
                            <asp:TemplateField HeaderText="ประเภทงาน" SortExpression="APP_TYPE_NAME">
                                <ItemTemplate>
                                    <asp:Label ID="LabelAPP_TYPE_NAME" runat="server" Text='<%# Bind("APP_TYPE_NAME") %>'></asp:Label>
                                    <asp:HiddenField ID="HiddenFieldAPP_TYPE_ID" runat="server" Value='<%# Bind("APP_TYPE_ID") %>'/>                               
                                </ItemTemplate>
                            </asp:TemplateField>
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
<%--            <div style="white-space: nowrap; text-align: center;">
                <asp:Button ID="ButtonClose" runat="server" Text="Close" Width="65px" myId="ButtonClose" />
            </div>--%>
        </asp:Panel>
    </div>
    <asp:SqlDataSource ID="SqlHubList" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT HUB_ID, HUB_NAME FROM TB_HUB WHERE (HUB_ID &lt; '998')">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlGridView" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="GET_APPRAISAL_LIST_BY_HUB" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" Name="Hub_Id" PropertyName="SelectedValue"
                Type="Int32" />
            <asp:ControlParameter ControlID="DropDownList2" Name="APP_TYPE_ID" PropertyName="SelectedValue"
                Type="Int32" />
            <asp:ControlParameter ControlID="TxtCalendar" Name="CREATE_DATE" PropertyName="Text"
                Type="DateTime" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource_APPLICATION_TYPE" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [APP_TYPE_ID], [APP_TYPE_NAME] FROM [TB_APPLICATION_TYPE]">
    </asp:SqlDataSource>
    <uc1:ExportControl ID="ExportControl1" runat="server" 
    ControlName="GridView1" Filename="ReportOut" AutoGenerateColumns="false" />
</asp:Content>
