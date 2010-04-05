<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Appraisal_Step_Follow.aspx.vb" Inherits="Appraisal_Step_Follow" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src="Js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="Js/common.js" type="text/javascript"></script>

    <style type="text/css">
        .body
        {
            background: #fff;
            font-size: small;
            color: #000;
        }
        .outerPopup
        {
            background-color: Gray;
            padding: 1em 16px;
            border-style: solid;
            border-color: Yellow;
            border-width: 1px;
        }
        .innerPopup
        {
            background-color: #fff;
        }
        .modalBackground
        {
            background-color: #000;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }
        .GrayedOut
        {
            background-color: Transparent;
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
            padding: 3px;
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
    </style>

    <script type="text/javascript" language="javascript">

        function changeAttachIframeSrc(reqid,hubid) {
            //alert(reqid);
            //alert(hubid);
            var popup = $find('mpeBehaviorAttach');
            //alert(popup);

            popup.show();
            var myId = "IframeAttach";
            //var url = "\Upload_Form/Upload_Request_Form.aspx";
            var url = "AttachFile.aspx";

            // Control ที่ส่งไปให้กับ Page ลูก เพื่อนำข้อมูลกลับมายังหน้าหลัก
            //var param = "req_id=" + reqid + "hub_id=" + hubid + "PopupModal=mpeBehaviorAttach";
            var param = "PopupModal=mpeBehaviorAttach";
                       
            // Parameter ที่ส่งไปให้กับ Page ลูก เพื่อนำข้อมูลกลับมายังหน้าหลัก 
            //***********************************************************************************************
            param = param + "&lblReq_Id=" + reqid;
            //alert(param);
            param = concatParam(param, 'span', 'lblHub_id' + hubid, 'hub_id');
            //param = param + concatParam('', 'input', 'TextBoxTambonCode', 'TambonCode');
            //***********************************************************************************************
            //alert(param);
            
            changeIframeSrcById(myId
                , url
                , param
            );
        } 
        
        function changeIframeSrcById(id, url, param) {
            var urlFull = "";
            //alert("id:"+id);
            var iframe = document.getElementById(id);
            //alert("iframe:" + iframe);
            if (param) {
                urlFull = url + "?" + param;
            } else {
                urlFull = url;
            }
            //alert(urlFull);
            
            iframe.src = urlFull;
        }
        
        function concatParam(oldParam, addParamTag, addParamMyId, addParamKey) {
            var result = oldParam;
            var dom = null;
            var value = null;

            if (addParamTag == "input") {
                dom = getEleByProperty(addParamTag, "myId", addParamMyId);
                value = dom.value;
            } else if (addParamTag == "span") {
                dom = getEleByProperty(addParamTag, "myId", addParamMyId)
                value = dom.innerText;          
            } else if (addParamTag == "select") {

            }

            if (value.length >= 1) {
                result = result + "&" + addParamKey + "=" + value;
            } else {
                alert('โปรดตรวจสอบว่ามีรายละเอียดจังหวัด รายละเอียดอำเภอ แล้วหรือไม่');

            }
            //alert(result);
            return result;
        }               
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Req_Id,Hub_Id"
        DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display."
        Width='100%' BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px"
        CellPadding="2" ForeColor="Black" GridLines="None" ShowFooter="True" PageSize="15"
        Font-Size="Small" AllowPaging="True">
        <FooterStyle BackColor="Tan" />
        <Columns>
            <asp:TemplateField HeaderText="Req No.">
                <ItemTemplate>
                    <asp:Label ID="lblReq_id" runat="server" Text='<%# Bind("Req_Id") %>' myId='<%# "lblReq_id" +Eval("Req_Id").toString() %>'> </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Hub ID">
                <ItemTemplate>
                    <asp:Label ID="lblHub_Id" runat="server" Text='<%# Bind("Hub_Id") %>' myId='<%# "lblHub_id" +Eval("Hub_Id").toString() %>'> </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Hub Name">
                <ItemTemplate>
                    <asp:Label ID="lblHub_Name" runat="server" Text='<%# Bind("Hub_Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cif">
                <ItemTemplate>
                    <asp:Label ID="lblCif" runat="server" Text='<%# Bind("Cif") %>' myId='<%# "lblCif" +Eval("Cif").toString() %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cif Name">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("CifName") %>'></asp:Label>
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
                    <asp:Label ID="LabelStatus_Name" runat="server" Text='<%# Bind("Status_Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="วันที่ส่งประเมิน">
                <ItemTemplate>
                    <asp:Label ID="LabelCreate_Date" runat="server" Text='<%# Bind("Create_Date") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="">
                <ItemStyle HorizontalAlign="Center" Width="25px" />
                <ItemTemplate>
                    <%--                            <asp:ImageButton ID="imgAttach" runat="server" Height="22px" 
                                ImageUrl="~/Images/attachment.png" ToolTip="แนบเอกสาร" Width="22px" OnClientClick='changeAttachIframeSrc(); return false;' />--%>
                    <asp:ImageButton ID="imgAttach" runat="server" Height="22px" ImageUrl="~/Images/attachment.png"
                        ToolTip="แนบเอกสาร" Width="22px" OnClientClick='<%# "changeAttachIframeSrc(" +Eval("Req_Id").toString()+ "," +EVAL("Hub_Id").toString()+ "); return false;" %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="">
                <ItemStyle Width="25px" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgLocation" runat="server" ImageUrl="~/Images/camera2.png"
                        Height="22px" Width="22px" ToolTip="รูปไฟล์แนบ" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
    
    <%-- Popup ข้อมูล การแนบเอกสาร --%>
    <asp:Panel ID="pnlPopup1" runat="server" CssClass="outerPopup" Style="display: none;">
        <asp:Panel ID="pnlInnerPopup1" runat="server" Width="550px" CssClass="innerPopup">
            <iframe id="IframeAttach" src="" width="500" height="250" frameborder="0" scrolling="no">
            </iframe>
        </asp:Panel>
        <br />
        <div style="white-space: nowrap; text-align: center;">
            <asp:Button ID="btnOK" runat="server" Text="OK" Width="65px" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="65px" />
        </div>
    </asp:Panel>
    <asp:Button ID="ButtonAttach" runat="server" Style="display: none;" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderAttach" runat="server" TargetControlID="ButtonAttach"
        PopupControlID="pnlPopup1" CancelControlID="btnCancel" OkControlID="btnOK" BackgroundCssClass="modalBackground"
        BehaviorID="mpeBehaviorAttach">
    </ajaxToolkit:ModalPopupExtender>
    <ajaxToolkit:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" TargetControlID="pnlInnerPopup1"
        BorderColor="black" Radius="6">
    </ajaxToolkit:RoundedCornersExtender>
    <%-- สิ้นสุด การ Popup ข้อมูล การแนบเอกสาร --%>
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="GET_APPRAISAL_VERIFY_PROCESS_BY_HUB" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="HiddenHubId" Name="HUB_ID" PropertyName="Value"
                Type="Int32" />
            <asp:ControlParameter ControlID="HdfStatus" Name="Status_Id" PropertyName="Value"
                Type="Int32" />
            <asp:ControlParameter ControlID="hdfAppraisal_Id" Name="Appraisal_Id" PropertyName="Value"
                Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:HiddenField ID="HdfStatus" runat="server" Value="4" />
    <asp:HiddenField ID="HiddenHubId" runat="server" />
    <asp:HiddenField ID="hdfAppraisal_Id" runat="server" />
</asp:Content>
