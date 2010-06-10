<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Appraisal_Delete_Land.aspx.vb" Inherits="Appraisal_Delete_Land" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="Js/common.js" type="text/javascript"></script>
    <script type="text/javascript">
        function returnWindow() {
            var _PopupModal = getValueFromQueryString("PopupModal");
            window.parent.$find(_PopupModal).hide();
            window.parent.location.replace(window.parent.location);
        }

        function deleteSubCollType(id, subCollType) {

            var Req_Id = document.getElementById('<%=HiddenFieldReq_Id.ClientID%>').value;
            var Hub_Id = document.getElementById('<%=HiddenFieldHub_Id.ClientID%>').value;
            var Condo_Id = document.getElementById('<%=HiddenFieldLand_Id.ClientID%>').value;
            var SubCollType = document.getElementById('<%=HiddenFieldSubCollType.ClientID%>').value;
            //alert(id);
            //alert(subCollType);
            //alert(_req_Id.value);
            //alert(_hub_Id.value);
            PageMethods.DeleteCondo(Req_Id, Hub_Id, Condo_Id, SubCollType, this.callback);

        }
                
        function callback(result) {
            var _PopupModal = getValueFromQueryString("PopupModal");
            if (result) {
                alert('Delete data compleate!');
                window.parent.$find(_PopupModal).hide();
                window.parent.location.replace(window.parent.location);
            }
            else {
                alert('Warning, Delete not compleate!');
            }
        }           
         
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        <Services>
            <asp:ServiceReference Path="~/Service.svc" />
        </Services>
    </asp:ScriptManager>
    <div style="text-align: center;">
        <asp:Label ID="LabelInfo" runat="server" Text="คุณต้องการลบข้อมูลใช่หรือไม่" Style="font-weight: 700;
            color: #CC3300"></asp:Label>
        <br />
        <br />
        <asp:Button ID="ButtonDelete" runat="server" Text="Delete" OnClientClick="deleteSubCollType(); return false;" />
        &nbsp;
        <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" OnClientClick="returnWindow(); return false;" />
    </div>
    <asp:HiddenField ID="HiddenFieldReq_Id" runat="server" />
    <asp:HiddenField ID="HiddenFieldHub_Id" runat="server" />
    <asp:HiddenField ID="HiddenFieldLand_Id" runat="server" />
    <asp:HiddenField ID="HiddenFieldSubCollType" runat="server" />
    </form>
</body>
</html>
