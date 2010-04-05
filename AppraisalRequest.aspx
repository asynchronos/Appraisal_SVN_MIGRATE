<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="AppraisalRequest.aspx.vb" Inherits="AppraisalRequest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src="Js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="Js/common.js" type="text/javascript"></script>
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
        .style2
        {
            width: 350px;
        }
        .style1
        {
            width: 100%;
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
        .modalBox {
	        background-color : #f5f5f5;
	        border-width: 3px;
	        border-style: solid;
	        border-color: Blue;
	        padding: 3px;
        }   
        .modalBackground
        {
          background-color:#CCCCFF;
          filter:alpha(opacity=40);
          opacity:0.5;
        }

        .ModalWindow
        {
          border: solid1px#c0c0c0;
          background:#f0f0f0;
          padding: 0px10px10px10px;
          position:absolute;
          top:-1000px;
        }  
        
        .outerPopup 
        {
            background-color:transparent;  
            padding:1em 6px;
        }

        .innerPopup
        {
            background-color:#fff;
        }

        .modalBackground1
        {
             background-color:#000;
             filter:alpha(opacity=70);
             opacity:0.7;
        }                  
    </style>

    <script type="text/javascript">

        var reqid;
        var hubid;

        function call_url_attach1() {
            reqid = document.getElementById('<%=lblRequestID.ClientID%>').innerHTML;
            hubid = document.getElementById('<%=TextBoxHubCode.ClientID%>').value;
            if (reqid == '') {
                alert('คุณยังไม่ได้ออกเลขคำขอประเมิน');
            }
            else {
                window.open('Upload_Form/Upload_File_Request_Form.aspx?req_id=' + reqid + '&hub_id=' + hubid + '&req_form=' + 1, 'Open1', 'toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, copyhistory=no, directories=no, status=yes,height=400px,width=600px');
            }

        }
        
        function call_url_attach2() {
            reqid = document.getElementById('<%=lblRequestID.ClientID%>').innerHTML;
            //alert(reqid);
            hubid = document.getElementById('<%=TextBoxHubCode.ClientID%>').value;
            //alert(hubid);
            if (reqid == '') {
                alert('คุณยังไม่ได้ออกเลขคำขอประเมิน');
            }
            else {
                window.open('Upload_Form/Upload_File_Request_Form.aspx?req_id=' + reqid + '&hub_id=' + hubid + '&req_form=' + 2, 'Open2', 'toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, copyhistory=no, directories=no, status=yes,height=400px,width=600px');
            }
        }
        
        function call_url_attach3() {
            reqid = document.getElementById('<%=lblRequestID.ClientID%>').innerHTML;
            hubid = document.getElementById('<%=TextBoxHubCode.ClientID%>').value;
            if (reqid == '') {
                alert('คุณยังไม่ได้ออกเลขคำขอประเมิน');
            }
            else {
                window.open('Upload_Form/Upload_File_Request_Form.aspx?req_id=' + reqid + '&hub_id=' + hubid + '&req_form=' + 3, 'Open3', 'toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, copyhistory=no, directories=no, status=yes,height=400px,width=600px');
            }

        }
        function call_url_attach4() {
            reqid = document.getElementById('<%=lblRequestID.ClientID%>').innerHTML;
            hubid = document.getElementById('<%=TextBoxHubCode.ClientID%>').value;
            if (reqid == '') {
                alert('คุณยังไม่ได้ออกเลขคำขอประเมิน');
            }
            else {
                window.open('Upload_Form/Upload_File_Request_Form.aspx?req_id=' + reqid + '&hub_id=' + hubid + '&req_form=' + 4, 'Open4', 'toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, copyhistory=no, directories=no, status=yes,height=400px,width=600px');
            }
        }

        function onCancel() {

        }

        function callback(result) {
            //  hide the popup
            this._popup.hide();

            //  let the user know if their credit card was validated
            if (result) {
                alert('Save data compleate!');
            }
            else {
                alert('Warning, Save not compleate!');
            }
        }
        function copyDataCif() {
            var _chk = document.getElementById('<%=ChkBoxCopy.ClientID%>').checked;
            var _cif = document.getElementById('<%=txtCif.ClientID%>').value;
            var _title = document.getElementById('<%=ddlTitle.ClientID%>').value;
            var _name = document.getElementById('<%=TxtCifName.ClientID%>').value;
            var _lastname = document.getElementById('<%=TxtCifLastName.ClientID%>').value;
            //alert(_chk);
            if (_chk == true) {
                document.getElementById('<%=TxtCifColl.ClientID%>').value = _cif;
                document.getElementById('<%=ddlTitleColl.ClientID%>').value = _title;
                document.getElementById('<%=TxtCifNameColl.ClientID%>').value = _name;
                document.getElementById('<%=TxtCifLastNameColl.ClientID%>').value = _lastname;
            }
            else {
                document.getElementById('<%=TxtCifColl.ClientID%>').value = '';
                document.getElementById('<%=ddlTitleColl.ClientID%>').value = 1;
                document.getElementById('<%=TxtCifNameColl.ClientID%>').value = '';
                document.getElementById('<%=TxtCifLastNameColl.ClientID%>').value = '';
            }
        }

        function changeIframeSrc(myid, url, param) {
            var iframe = $("iframe[myid=" + myid + "]");
            changeIframeSrcById(iframe[0].id, url, param);
        }

        function changeIframeSrcById(id, url, param) {
            var urlFull = "";

            var iframe = document.getElementById(id);

            if (param) {
                urlFull = url + "?" + param;
                //                alert(getEleByProperty("input", "myId", "TextBoxProvinceCode").value);
                //                //alert(document.getElementById("TextBoxProvinceCode").value);
                //                if (getEleByProperty("input", "myId", "TextBoxProvinceCode").value.length <1) {
                //                    urlFull = url + "?" + param;
                //                    alert('1: ' + urlFull);
                //                }
                //                else {

                //                    urlFull = url + "?" + param + "&ProCode=" + getEleByProperty("input", "myId", "TextBoxProvinceCode").value;
                //                    alert('2: ' + urlFull);                   
                //                }
            } else {
                urlFull = url;
            }

            iframe.src = urlFull;
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
                alert('โปรดตรวจสอบว่ามีรายละเอียดจังหวัด รายละเอียดอำเภอ แล้วหรือไม่');


            }
            //alert(result);
            return result;
        }

        function changeProvinceIframeSrc() {
            clearTextProvince();
            clearTextAmphur();
            clearTextTambon();
            clearTextHub();
            var myId = "IframeSearchProvince";
            var url = "Province.aspx";
            var param = "ProvinceCode=TextBoxProvinceCode&ProvinceName=TextBoxProvinceName&PopupModal=mpeBehaviorSearchProvince";

            changeIframeSrcById(myId
                , url
                , param
            );
        }

        function changeAumphurIframeSrc() {
            clearTextAmphur();
            clearTextTambon();
            clearTextHub();
            var myId = "IframeSearchAmphur";
            var url = "Amphur.aspx";
            var param = "AmphurCode=TextBoxAmphurCode&AmphurName=TextBoxAmphurName&PopupModal=mpeBehaviorSearchAmphur";

            param = param + concatParam('', 'input', 'TextBoxProvinceCode', 'ProCode');
            //param = param + concatParam('AmphurCode=TextBoxAmphurCode&AmphurName=TextBoxAmphurName', 'input', 'TextBoxProvinceCode', 'ProCode');
            //param = param + concatParam();

            changeIframeSrcById(myId
                , url
                , param
            );
        }

        function changeTambonIframeSrc() {
            clearTextHub();
            clearTextAID();
            var myId = "IframeSearchTambon";
            var url = "Tambon.aspx";
            var param = "TambonCode=TextBoxTambonCode&TambonName=TextBoxTambonName&PopupModal=mpeBehaviorSearchTambon";

            param = param + concatParam('', 'input', 'TextBoxProvinceCode', 'ProCode');
            param = param + concatParam('', 'input', 'TextBoxAmphurCode', 'AmphurCode');

            changeIframeSrcById(myId
                , url
                , param
            );
        }

        function changeHubIframeSrc() {
            clearTextHub();
            clearTextAID();
            var myId = "IframeSearchHub";
            var url = "Hub.aspx";
            // Control ที่ส่งไปให้กับ Page ลูก เพื่อนำข้อมูลกลับมายังหน้าหลัก
            var param = "HubCode=TextBoxHubCode&HubName=TextBoxHubName&PopupModal=mpeBehaviorSearchHub";

            // Parameter ที่ส่งไปให้กับ Page ลูก เพื่อนำข้อมูลกลับมายังหน้าหลัก 
            //***********************************************************************************************
            param = param + concatParam('', 'input', 'TextBoxProvinceCode', 'ProCode');
            param = param + concatParam('', 'input', 'TextBoxAmphurCode', 'AmphurCode');
            param = param + concatParam('', 'input', 'TextBoxTambonCode', 'TambonCode');
            //***********************************************************************************************

            changeIframeSrcById(myId
                , url
                , param
            );
        }

        function changeAIDIframeSrc() {
            var popup = $find('mpeBehaviorSearchAID');
            //alert(popup);
            var IndexValue = $get('<%=ddlAppraisal_Method.ClientID %>').selectedIndex;
            var SelectedVal = $get('<%=ddlAppraisal_Method.ClientID %>').options[IndexValue].value;
            //alert(SelectedVal);
            clearTextAID();
            if (SelectedVal == '2') {
                //alert('ทบทวน');
                if (getEleByProperty("input", "myId", "TxtCifColl").value > 1) {
                    popup.show();
                    var myId = "IframeSearchAID";
                    var url = "AID_From_DWS.aspx";
                    // Control ที่ส่งไปให้กับ Page ลูก เพื่อนำข้อมูลกลับมายังหน้าหลัก
                    var param = "AID=TextBoxAID&PopupModal=mpeBehaviorSearchAID";

                    // Parameter ที่ส่งไปให้กับ Page ลูก เพื่อนำข้อมูลกลับมายังหน้าหลัก 
                    //***********************************************************************************************
                    param = param + concatParam('', 'input', 'TxtCifColl', 'Cif');
                    //param = param + concatParam('', 'input', 'TextBoxAmphurCode', 'AmphurCode');
                    //param = param + concatParam('', 'input', 'TextBoxTambonCode', 'TambonCode');
                    //***********************************************************************************************

                    changeIframeSrcById(myId
                        , url
                        , param
                    );
                } else {
                    alert('ไม่มี Cif ที่เป็นเจ้าของหลักประกัน');
                }


            } else {
                alert('วิธีการส่งประเมิน ไม่ใช่การทบทวนตาม AID เดิม');
                //var popup = $find('mpeBehaviorSearchAID').hide();
                //var popup = $find('mpeBehaviorSearchAID');
                popup.hide();
            }
        }

        function changeEmpIframeSrc() {
            //clearTextHub();
            //clearTextAID();
            var myId = "IframeSearchEmp";
            var url = "Employees.aspx";
            // Control ที่ส่งไปให้กับ Page ลูก เพื่อนำข้อมูลกลับมายังหน้าหลัก
            var param = "EmpId=TxtSender&EmpName=TxtSenderName&PopupModal=mpeBehaviorSearchEmp";

            // Parameter ที่ส่งไปให้กับ Page ลูก เพื่อนำข้อมูลกลับมายังหน้าหลัก 
            //***********************************************************************************************
            //param = param + concatParam('', 'input', 'TextBoxProvinceCode', 'ProCode');
            //param = param + concatParam('', 'input', 'TextBoxAmphurCode', 'AmphurCode');
            //param = param + concatParam('', 'input', 'TextBoxTambonCode', 'TambonCode');
            //***********************************************************************************************

            changeIframeSrcById(myId
                , url
                , param
            );
        }

        function changeDeptBranchIframeSrc() {
            //clearTextHub();
            //clearTextAID();
            var myId = "IframeSearchDeptBranch";
            var url = "DeptBranch.aspx";
            // Control ที่ส่งไปให้กับ Page ลูก เพื่อนำข้อมูลกลับมายังหน้าหลัก
            var param = "DeptBranchId=TextBoxDepartmentCode&DeptBranchName=TextBoxDepartmentName&Flag=TextBoxFlag&PopupModal=mpeBehaviorSearchDeptBranch";

            // Parameter ที่ส่งไปให้กับ Page ลูก เพื่อนำข้อมูลกลับมายังหน้าหลัก 
            //***********************************************************************************************
            //param = param + concatParam('', 'input', 'TextBoxProvinceCode', 'ProCode');
            //param = param + concatParam('', 'input', 'TextBoxAmphurCode', 'AmphurCode');
            //param = param + concatParam('', 'input', 'TextBoxTambonCode', 'TambonCode');
            //***********************************************************************************************

            changeIframeSrcById(myId
                , url
                , param
            );
        }

        function clearTextProvince() {
            var provinceCode = getEleByProperty("input", "myId", "TextBoxProvinceCode")
            provinceCode.value = ''
            var provinceName = getEleByProperty("input", "myId", "TextBoxProvinceName")
            provinceName.value = ''
        }

        function clearTextAmphur() {
            var amCode = getEleByProperty("input", "myId", "TextBoxAmphurCode")
            amCode.value = ''
            var amName = getEleByProperty("input", "myId", "TextBoxAmphurName")
            amName.value = ''
        }

        function clearTextTambon() {
            var tambonCode = getEleByProperty("input", "myId", "TextBoxTambonCode")
            tambonCode.value = ''
            var tambonName = getEleByProperty("input", "myId", "TextBoxTambonName")
            tambonName.value = ''
        }

        function clearTextHub() {
            var hubCode = getEleByProperty("input", "myId", "TextBoxHubCode")
            hubCode.value = ''
            var hubName = getEleByProperty("input", "myId", "TextBoxHubName")
            hubName.value = ''
        }

        function clearTextAID() {
            var aid = getEleByProperty("input", "myId", "TextBoxAID")
            aid.value = ''
        }                
     
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
    <br />
    <table class="TableWidth">
        <tr align="center">
            <td>
                <table>
                    <tr>
                        <td>
                            <table style="border-color: Blue; border-width: 15px; width: 500px">
                                <tr>
                                    <td style="text-align: left; color: Blue;" bgcolor="Yellow" colspan="2" class="headDetail">
                                        ประเภทคำขอประเมิน
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;" class="expleanColour">
                                        ประเภทคำขอ
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:DropDownList ID="ddlAppraisal_Method" runat="server" DataSourceID="sdsAppraisal_Method"
                                            DataTextField="Method_Name" DataValueField="Method_ID">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;" class="expleanColour">
                                        ประเภท Application Form
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:DropDownList ID="ddlAPPLICATION_TYPE" runat="server" DataSourceID="SqlDataSourceApplicationType"
                                            DataTextField="APP_TYPE_NAME" DataValueField="APP_TYPE_ID">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;" class="headDetail" bgcolor="Yellow" colspan="2">
                                        ส่วนข้อมูลลูกค้า
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;" class="expleanColour">
                                        CIF
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="TxtCif" runat="server" MaxLength="9" Width="90px" myId="TxtCif"></asp:TextBox>
                                        <asp:Button ID="ButtonSearchCif" runat="server" Text="...." 
                                            
                                            OnClientClick="changeIframeSrcById('myIframe','Search_Cif.aspx','Cif=TxtCif&Title=ddlTitle&CifName=TxtCifName&CifLastname=TxtCifLastName&PopupModal=mpeBehaviorSearchCif'); return false;" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Cif" runat="server" ControlToValidate="TxtCif"
                                            Display="Dynamic" ErrorMessage="ใส่ รหัสลูกค้า" ValidationGroup="1"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;" class="expleanColour">
                                        คำนำหน้า
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:DropDownList ID="ddlTitle" runat="server" DataSourceID="SDSTitle" DataTextField="TITLE_NAME"
                                            DataValueField="TITLE_CODE" myId="ddlTitle" BehaviorId="BehaviorddlTitle">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;" class="expleanColour">
                                        ชื่อ
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="TxtCifName" runat="server" Width="180px" myId="TxtCifName"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Name" runat="server" ControlToValidate="TxtCifName"
                                            Display="Dynamic" ErrorMessage="ใส่ชื่อ ลูกค้า" ValidationGroup="4"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;" class="expleanColour">
                                        นามสกุล
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="TxtCifLastName" runat="server" Width="180px" myId="TxtCifLastName"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;" bgcolor="#FFFF66" colspan="2" class="headDetail">
                                        ส่วนข้อมูลเจ้าของหลักประกัน
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;" class="expleanColour" bgcolor="Silver">
                                        &nbsp;
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:CheckBox ID="ChkBoxCopy" runat="server" Text="ใช้ข้อมูลเดียวกันกับข้อมูลลูกค้า" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;" class="expleanColour">
                                        CIF
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="TxtCifColl" runat="server" MaxLength="9" Width="90px" myId="TxtCifColl"></asp:TextBox>
                                        <asp:Button ID="ButtonSearchCifColl" runat="server" Text="...." OnClientClick="changeIframeSrcById('myIframe','Search_Cif.aspx','Cif=TxtCifColl&Title=ddlTitleColl&CifName=TxtCifNameColl&CifLastname=TxtCifLastNameColl&PopupModal=mpeBehaviorSearchCifColl'); return false;" />
                                        <cc1:ModalPopupExtender ID="ButtonSearchCifColl_ModalPopupExtender" runat="server"
                                            BackgroundCssClass="GrayedOut" OnOkScript="onOk()" PopupControlID="panel_SearchCif"
                                            TargetControlID="ButtonSearchCifColl" BehaviorID="mpeBehaviorSearchCifColl" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_CifColl" runat="server" ControlToValidate="TxtCifColl"
                                            Display="Dynamic" ErrorMessage="ใส่รหัสเจ้าของหลักประกัน" ValidationGroup="3"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;" class="expleanColour">
                                        คำนำหน้า
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:DropDownList ID="ddlTitleColl" runat="server" BehaviorId="ddlBehaviorTitleColl"
                                            DataSourceID="SDSTitle" DataTextField="TITLE_NAME" DataValueField="TITLE_CODE"
                                            myId="ddlTitleColl">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;" class="expleanColour">
                                        ชื่อ
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="TxtCifNameColl" runat="server" Width="180px" myId="TxtCifNameColl"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_NameColl" runat="server" ControlToValidate="TxtCifNameColl"
                                            Display="Dynamic" ErrorMessage="ใส่ชื่อเจ้าของหลักประกัน" ValidationGroup="4"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;" class="expleanColour">
                                        นามสกุล
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="TxtCifLastNameColl" runat="server" Width="180px" myId="TxtCifLastNameColl"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;" class="headDetail" bgcolor="Yellow" colspan="2">
                                        ที่ตั้งหลักประกัน
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;" class="expleanColour">
                                        เลขที่ โฉนด/นส.3/นส.3ก-ข/ คอนโด
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="TextBoxChanode" runat="server" Width="240px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;" class="expleanColour">
                                        จังหวัด
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="TextBoxProvinceCode" runat="server" Width="30px" myId="TextBoxProvinceCode"
                                            onfocus="this.blur();"></asp:TextBox>
                                        <asp:TextBox ID="TextBoxProvinceName" runat="server" Width="170px" myId="TextBoxProvinceName"
                                            onfocus="this.blur();"></asp:TextBox>
                                        <asp:Button ID="ButtonSearchProvince" runat="server" Text="...." OnClientClick="changeProvinceIframeSrc();return false;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;" class="expleanColour">
                                        อำเภอ
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="TextBoxAmphurCode" runat="server" Width="30px" onfocus="this.blur();"
                                            myId="TextBoxAmphurCode"></asp:TextBox>
                                        <asp:TextBox ID="TextBoxAmphurName" runat="server" Width="170px" Style="margin-right: 0px"
                                            myId="TextBoxAmphurName" onfocus="this.blur();"></asp:TextBox>
                                        <%--                                       <asp:Button ID="ButtonSearchAmphur" runat="server" Text="...." onclientclick="changeIframeSrcById('IframeSearchAmphur','Amphur.aspx',concatParam('AmphurCode=TextBoxAmphurCode&AmphurName=TextBoxAmphurName&PopupModal=mpeBehaviorSearchAmphur','input','TextBoxProvinceCode','ProCode')); return false;"/>--%>
                                        <asp:Button ID="ButtonSearchAmphur" runat="server" Text="...." OnClientClick="changeAumphurIframeSrc(); return false;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;" class="expleanColour">
                                        ตำบล
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="TextBoxTambonCode" runat="server" Width="30px" onfocus="this.blur();"
                                            myId="TextBoxTambonCode"></asp:TextBox>
                                        <asp:TextBox ID="TextBoxTambonName" runat="server" Width="170px" onfocus="this.blur();"
                                            myId="TextBoxTambonName"></asp:TextBox>
                                        <asp:Button ID="ButtonSearchTambon" runat="server" Text="...." OnClientClick="changeTambonIframeSrc(); return false;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;" class="expleanColour">
                                        ศูนย์หลักประกันที่รับผิดชอบ
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="TextBoxHubCode" runat="server" Width="30px" onfocus="this.blur();"
                                            myId="TextBoxHubCode"></asp:TextBox>
                                        <asp:TextBox ID="TextBoxHubName" runat="server" Width="170px" onfocus="this.blur();"
                                            myId="TextBoxHubName"></asp:TextBox>
                                        <asp:Button ID="ButtonSearchHub" runat="server" Text="...." OnClientClick="changeHubIframeSrc(); return false;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;" class="expleanColour">
                                        AID
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="TextBoxAID" runat="server" Width="170px" myId="TextBoxAID" onfocus="this.blur();"></asp:TextBox>
                                        <asp:Button ID="ButtonSearchAID" runat="server" Text="...." OnClientClick="changeAIDIframeSrc(); return false;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;" class="headDetail" bgcolor="Yellow" colspan="2">
                                        ข้อมูลผู้ขอให้ประเมิน
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;" class="expleanColour">
                                        รหัสผู้ขอให้ประเมิน(จ.สาขา)
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="TxtSender" runat="server" MaxLength="9" Width="90px" myId="TxtSender"
                                            onfocus="this.blur();"></asp:TextBox>
                                        <asp:Button ID="ButtonSearchEmp" runat="server" Text="...." OnClientClick="changeEmpIframeSrc(); return false;" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Sender" runat="server" ControlToValidate="TxtSender"
                                            Display="Dynamic" ErrorMessage="ใส่รหัสพนักงานผู้ขอให้ประเมิน" ValidationGroup="4"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;" class="expleanColour">
                                        ชื่อ-สกุลผู้ขอให้ประเมิน
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="TxtSenderName" runat="server" Width="240px" myId="TxtSenderName"
                                            onfocus="this.blur();"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_SenderName" runat="server"
                                            ControlToValidate="TxtSenderName" Display="Dynamic" ErrorMessage="ใส่ชื่อพนักงานผู้ขอให้ประเมิน"
                                            ValidationGroup="4"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="expleanColour" style="text-align: left;">
                                        สาขา/ฝ่ายงาน
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="TextBoxDepartmentCode" runat="server" Width="30px" myId="TextBoxDepartmentCode"
                                            onfocus="this.blur();"></asp:TextBox>
                                        <asp:TextBox ID="TextBoxDepartmentName" runat="server" Width="170px" myId="TextBoxDepartmentName"
                                            onfocus="this.blur();"></asp:TextBox>
                                        <asp:Button ID="ButtonSearchDeptBranch" runat="server" Text="...." OnClientClick="changeDeptBranchIframeSrc(); return false;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="expleanColour" style="text-align: left;">
                                        รหัส Flag 1 = ฝ่ายงาน 2 = สาขา
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="TextBoxFlag" runat="server" Width="30px" myId="TextBoxFlag" onfocus="this.blur();"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; text-align: center;" class="headDetail" colspan="2">
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top" class="style2">
                            <table class="style1">
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="bntRequest_ID" runat="server" Text="ออกเลขคำขอประเมิน" Style="font-weight: 700"
                                            Height="50px" ValidationGroup="1,2" Width="200px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                                <asp:Button ID="btnJobList" runat="server" Height="50px" 
                                                    Text="ทะเบียนงานออก" Font-Bold="True" Width="200px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" class="headDetail">
                                        คำขอประเมินเลขที่
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Label CssClass="fColor" ID="lblRequestID" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="lblMessage" runat="server" Style="color: #FF0000; font-weight: 700"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <table class="style1">
                                        <tr>
                                            <td class="headDetail" colspan="2">
                                                แนบไฟล์
                                            </td>
                                        </tr>
                                        <tr class="expleanColour1">
                                            <td class="expleanColour1">
                                                แนบใบคำขอประเมิน
                                            </td>
                                            <td>
                                                <asp:Button ID="BtnAttach1" runat="server" Text="แนบไฟล์" OnClientClick="call_url_attach1(); return false;" />
                                            </td>
                                        </tr>
                                        <tr class="expleanColour1">
                                            <td class="expleanColour1">
                                                แนบแผนที่
                                            </td>
                                            <td>
                                                <asp:Button ID="BtnAttach2" runat="server" Text="แนบไฟล์" OnClientClick="call_url_attach2(); return false;" />
                                            </td>
                                        </tr>
                                        <tr class="expleanColour1">
                                            <td class="expleanColour1">
                                                แนบหน้าโฉนด/ใบกรรมสิทธิห้องชุด
                                            </td>
                                            <td>
                                                <asp:Button ID="BtnAttach3" runat="server" Text="แนบไฟล์" OnClientClick="call_url_attach3(); return false;" />
                                            </td>
                                        </tr>
                                        <tr class="expleanColour">
                                            <td class="expleanColour">
                                                อื่น ๆ
                                            </td>
                                            <td>
                                                <asp:Button ID="BtnAttach4" runat="server" Text="แนบไฟล์" OnClientClick="call_url_attach4(); return false;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <asp:Button ID="btnFinish" runat="server" Height="50px" 
                                                    Text="ออกเลขคำขอเสร็จสมบูรณ์" Font-Bold="True" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="1" />
                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="2" />
                            <asp:ValidationSummary ID="ValidationSummary3" runat="server" ValidationGroup="3" />
                            <asp:ValidationSummary ID="ValidationSummary4" runat="server" ValidationGroup="4" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:SqlDataSource ID="SDSTitle" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
                    SelectCommand="SELECT [TITLE_CODE], [TITLE_NAME] FROM [TB_TITLE]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="sdsAppraisal_Method" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
                    SelectCommand="SELECT [Method_ID], [Method_Name] FROM [Appraisal_Method]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSourceApplicationType" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
                    SelectCommand="SELECT [APP_TYPE_ID], [APP_TYPE_NAME] FROM [TB_APPLICATION_TYPE]">
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
    
    <%-- ค้นหา Cif และ  Cif เจ้าของหลักประกัน--%>
    <cc1:ModalPopupExtender ID="btn_SearchCif" runat="server" BackgroundCssClass="GrayedOut"
        OnOkScript="onOk()" PopupControlID="panel_SearchCif" TargetControlID="ButtonSearchCif"
        BehaviorID="mpeBehaviorSearchCif" />    
       <asp:Panel ID="panel_SearchCif" runat="server" Style="display: none;" CssClass="modalBox" width="600" height="225">
            <iframe id="myIframe" src="" width="600" height="200" frameborder="0" scrolling="no">
            </iframe>
            <div style="white-space: nowrap; text-align: center; background-color: White;">
                <asp:Button ID="btnCloseIframe" runat="server" Text="Close" Width="50px" myId="btnCloseIframe" />
            </div>
        </asp:Panel>    
            
    
    <%-- ค้นหา จังหวัด --%>
    <cc1:ModalPopupExtender ID="ModalPopupExtenderSearchProvince" runat="server" BackgroundCssClass="GrayedOut"
        OnOkScript="onOk()" PopupControlID="panelSearchProvince" TargetControlID="ButtonSearchProvince"
        BehaviorID="mpeBehaviorSearchProvince" />

                <asp:Panel ID="panelSearchProvince" runat="server" Style="display: none;" CssClass="modalBox">
                    <iframe id="IframeSearchProvince" src="" width="600" height="200" frameborder="0"
                        scrolling="no"></iframe>
                    <div style="white-space: nowrap; text-align: center; background-color: White;">
                        <asp:Button ID="ButtonCloseSearchProvince" runat="server" Text="Close" Width="50px"
                            myId="ButtonCloseSearchProvince" />
                    </div>
                </asp:Panel>

    <%-- ค้นหา อำเภอ --%>
    <cc1:ModalPopupExtender ID="ModalPopupExtenderSearchAmphur" runat="server" BackgroundCssClass="GrayedOut"
        OnOkScript="onOk()" PopupControlID="panelSearchAmphur" TargetControlID="ButtonSearchAmphur"
        BehaviorID="mpeBehaviorSearchAmphur" />
    <asp:Panel ID="panelSearchAmphur" runat="server" Style="display: none;" CssClass="modalBox">
        <iframe id="IframeSearchAmphur" src="" width="600" height="250" frameborder="0" scrolling="no">
        </iframe>
        <div style="white-space: nowrap; text-align: center; background-color: White;">
            <asp:Button ID="ButtonCloseSearchAmphur" runat="server" Text="Close" Width="50px"
                myId="ButtonCloseSearchAmphur" />
        </div>
    </asp:Panel>
    
    <%-- ค้นหา ตำบล--%>
    <cc1:ModalPopupExtender ID="ModalPopupExtenderSearchTambon" runat="server" BackgroundCssClass="GrayedOut"
        OnOkScript="onOk()" PopupControlID="panelSearchTambon" TargetControlID="ButtonSearchTambon"
        BehaviorID="mpeBehaviorSearchTambon" />
    <asp:Panel ID="panelSearchTambon" runat="server" Style="display: none;" CssClass="modalBox">
        <iframe id="IframeSearchTambon" src="" width="540" height="300" frameborder="0" scrolling="no">
        </iframe>
        <div style="white-space: nowrap; text-align: center; background-color: White;">
            <asp:Button ID="ButtonClossSearchTambon" runat="server" Text="Close" Width="50px"
                myId="ButtonCloseSearchTambon" />
        </div>
    </asp:Panel>
    
    <%-- ค้นหา Hub --%>
    <cc1:ModalPopupExtender ID="ModalPopupSearchHub" runat="server" BackgroundCssClass="GrayedOut"
        OnOkScript="onOk()" PopupControlID="panelSearchHub" TargetControlID="ButtonSearchHub"
        BehaviorID="mpeBehaviorSearchHub" />
    <asp:Panel ID="panelSearchHub" runat="server" Style="display: none;" CssClass="modalBox">
        <iframe id="IframeSearchHub" src="" width="540" height="300" frameborder="0" scrolling="no">
        </iframe>
        <div style="white-space: nowrap; text-align: center; background-color: White;">
            <asp:Button ID="ButtonCloseSearchHub" runat="server" Text="Close" Width="50px" myId="ButtonCloseSearchHub" />
        </div>
    </asp:Panel>
    
    <%-- ค้นหา AID --%>
    <asp:Button ID="tempSearchAID" runat="server" Style="display: none;" />
    <cc1:ModalPopupExtender ID="ModalPopupExtenderSearchAID" runat="server" BackgroundCssClass="GrayedOut"
        OnOkScript="onOk()" PopupControlID="panelSearchAID" TargetControlID="tempSearchAID"
        BehaviorID="mpeBehaviorSearchAID" />
    <asp:Panel ID="panelSearchAID" runat="server" Style="display: none;" CssClass="modalBox">
        <iframe id="IframeSearchAID" src="" width="540" height="300" frameborder="0" scrolling="no">
        </iframe>
        <div style="white-space: nowrap; text-align: center; background-color: White;">
            <asp:Button ID="ButtonCloseSearchAID" runat="server" Text="Close" Width="50px" myId="ButtonCloseSearchAID" />
        </div>
    </asp:Panel>
    
    <%-- ค้นหา พนักงานที่ส่งประเมิน --%>
    <cc1:ModalPopupExtender ID="ModalPopupExtenderSearchEmp" runat="server" BackgroundCssClass="GrayedOut"
        OnOkScript="onOk()" PopupControlID="panelSearchEmp" TargetControlID="ButtonSearchEmp"
        BehaviorID="mpeBehaviorSearchEmp" />
    <asp:Panel ID="panelSearchEmp" runat="server" Style="display: none;" CssClass="modalBox">
        <iframe id="IframeSearchEmp" src="" width="580" height="350" frameborder="0" scrolling="no">
        </iframe>
        <div style="white-space: nowrap; text-align: center; background-color: White;">
            <asp:Button ID="ButtonCloseSearchEmp" runat="server" Text="Close" Width="50px" myId="ButtonCloseSearchEmp" />
        </div>
    </asp:Panel>
    
    <%-- ค้นหา ฝ่ายงานหรือสาขา --%>
    <cc1:ModalPopupExtender ID="ModalPopupExtenderSearchDeptBranch" runat="server" BackgroundCssClass="GrayedOut"
        OnOkScript="onOk()" PopupControlID="panelSearchDeptBranch" TargetControlID="ButtonSearchDeptBranch"
        BehaviorID="mpeBehaviorSearchDeptBranch" />
    <asp:Panel ID="panelSearchDeptBranch" runat="server" Style="display: none;" CssClass="modalBox">
        <iframe id="IframeSearchDeptBranch" src="" width="600" height="400" frameborder="0"
            scrolling="no"></iframe>
        <div style="white-space: nowrap; text-align: center; background-color: White;">
            <asp:Button ID="ButtonCloseSearchDeptBranch" runat="server" Text="Close" Width="50px"
                myId="ButtonCloseSearchDeptBranch" />
        </div>
    </asp:Panel>
</asp:Content>
