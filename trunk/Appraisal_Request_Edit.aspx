<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Appraisal_Request_Edit.aspx.vb"
    Inherits="Appraisal_Request_Ecit" UICulture="el" Culture="th-TH" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="Js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="Js/common.js" type="text/javascript"></script>
    <script src="Js/jquery.js" type="text/javascript"></script>

    <style type="text/css">
            .updateProgressMessage
        {
            margin:3px; 
            font-family:Trebuchet MS; 
            font-size:small; 
            vertical-align: middle;
        }  
        .updateProgress
        {
            border-width:1px; 
            border-style:solid; 
            background-color:#FFFFFF; 
            position:absolute; 
            width:350px; 
            height:50px;    
        }  
    </style>
    <script type="text/javascript">
        var _popup;
        function updateAppraisal_Request() {
            _popup = $find('mdlPopupBehavior');
            var reqId = getValueFromQueryString("Req_Id");
            var hubId = getValueFromQueryString("Hub_Id");
            var cif = getValueFromQueryString("Cif");
            //alert(cif);
            var titleid = getValueFromQueryString("Title");
            //alert(titleid);
            var cifName = getEleByProperty("input", "myId", "TxtCifName").value;
            //alert(cifName);
            var cifLastname = getEleByProperty("input", "myId", "TxtCifLastName").value;
            //alert('Lastname' + cifLastname);
            var chanode = getEleByProperty("input", "myId", "TextBoxChanode").value;
            //alert('chanode ' + chanode);
            var appid = getValueFromQueryString("AppId");
            //alert('appid ' + appid);
            var branchId = getValueFromQueryString("BranchId");
            //alert('branchId ' + branchId);
            var dateReceive = getEleByProperty("input", "myId", "txtReceive_Date").value;
            //alert('Date Receive : ' + dateReceive);
            PageMethods.Update_Appraisal_Request(reqId, hubId, cif, titleid, cifName, cifLastname, chanode, appid, branchId, dateReceive, this.callback);
        }

        function delete_Appraisal_Request() {
            _popup = $find('mdlPopupBehavior');
            var reqId = getValueFromQueryString("Req_Id");
            var hubId = getValueFromQueryString("Hub_Id");
            var cif = getValueFromQueryString("Cif");
            PageMethods.Delete_Appraisal_Request(reqId, hubId, cif, this.callback);      
        }
        
        function callback(result) {
            //  hide the popup
           this._popup.hide();
            if (result) {
                //alert('Update data compleate!');
                returnValue();
                window.parent.location.replace(window.parent.location); 
            }
            else {
                //alert('Warning, Update not compleate!');
            }
        }
        function returnValue() {
            var _PopupModal = getValueFromQueryString("PopupModal");
            id = "IframeEditAppraisalRequest";
            var iframe = window.parent.document.getElementById(id);
            window.parent.$find(_PopupModal).hide();
            window.parent.location.replace(window.parent.location);
        }        
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptLocalization="true"
        EnableScriptGlobalization="true" EnablePageMethods="true">
    </asp:ScriptManager>
    <div>
        <table width="100%">
            <tr>
                <td>
                    Req ID
                </td>
                <td>
                    <asp:Label ID="LabelReq_Id" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Hub ID
                </td>
                <td>
                    <asp:Label ID="LabelHub_Id" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Cif
                </td>
                <td>
                    <asp:TextBox ID="TextBoxCif" runat="server" Width="90px" myId="TextBoxCif"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    คำนำหน้าชื่อ
                </td>
                <td>
                    <asp:DropDownList ID="ddlTitle" runat="server" DataSourceID="SDSTitle" DataTextField="TITLE_NAME"
                        DataValueField="TITLE_CODE">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Cif Name
                </td>
                <td>
                    <asp:TextBox ID="TxtCifName" runat="server" Width="180px" myId="TxtCifName"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Cif Lastname
                </td>
                <td>
                    <asp:TextBox ID="TxtCifLastName" runat="server" Width="180px" myId="TxtCifLastName"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    โฉนดเลขที่
                </td>
                <td>
                    <asp:TextBox ID="TextBoxChanode" runat="server" Width="240px" myId="TextBoxChanode"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="100">
                    ประเภทงาน
                </td>
                <td>
                    <asp:DropDownList ID="ddlAPPLICATION_TYPE" runat="server" DataSourceID="SqlDataSourceApplicationType"
                        DataTextField="APP_TYPE_NAME" DataValueField="APP_TYPE_ID">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    รหัสสาขา
                </td>
                <td>
                    <asp:DropDownList ID="ddlBranch" runat="server" DataSourceID="sdsBranch" DataTextField="BRANCH_T"
                        DataValueField="ID_BRANCH" Style="margin-left: 0px;">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    วันที่รับเรื่อง
                </td>
                <td>
                    <span style="color: Red">
                        <asp:TextBox ID="txtReceive_Date" runat="server" Width="110px" 
                        myId="txtReceive_Date"></asp:TextBox>
                        <cc1:calendarextender ID="CalendarExtender1" runat="server" Enabled="True"
                            TargetControlID="txtReceive_Date">
                        </cc1:calendarextender>
                    </span>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="background-color: Gray">
                    <table>
                        <tr>
                            <td>
<%--                                <asp:ImageButton ID="ImageSave" runat="server" ImageUrl="~/Images/Save.jpg" Width="35px"
                                    Height="35px" OnClientClick="updateAppraisal_Request(); return false;" />--%>
                                <asp:ImageButton ID="ImageSave" runat="server" ImageUrl="~/Images/Save.jpg" Width="35px"
                                    Height="35px"/>                                    
                            </td>
                            <td>
                                <asp:Label ID="lblSave" runat="server" Style="font-weight: 700" Text="Update"></asp:Label>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButtonDelete" runat="server" ImageUrl="~/Images/cancel1.jpg" Width="35px"
                                    Height="35px" OnClientClick="delete_Appraisal_Request(); return false;" />
                            </td>
                            <td>
                                <asp:Label ID="LabelDelete" runat="server" Style="font-weight: 700" Text="Delete"></asp:Label>
                            </td>                            
                            <td>
                                <asp:ImageButton ID="ImgBtnBack" runat="server" Height="35px" ImageUrl="~/Images/Button Previous.png"
                                    Width="35px" OnClientClick="returnValue(); return false;" />
                            </td>
                            <td>
                                <asp:Label ID="lblBack" runat="server" Style="font-weight: 700" Text="BACK"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
   <cc1:ModalPopupExtender 
        ID="mdlPopup" runat="server" TargetControlID="ImageButtonDelete" 
        PopupControlID="pnlPopup" BackgroundCssClass="modalBackground"
        BehaviorID="mdlPopupBehavior"  />   
                 
    <asp:Panel ID="pnlPopup" runat="server" CssClass="updateProgress" style="display:none">
        <div align="center" style="margin-top:10px;">
            <img src="Images/progress.gif" alt="" />
            <span class="updateProgressMessage">Please wait will be Processing ...</span>
        </div>
    </asp:Panel>     
    </div>
    <asp:SqlDataSource ID="SDSTitle" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [TITLE_CODE], [TITLE_NAME] FROM [TB_TITLE]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceApplicationType" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [APP_TYPE_ID], [APP_TYPE_NAME] FROM [TB_APPLICATION_TYPE]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsBranch" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="GET_BRANCH" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    </form>
</body>
</html>
