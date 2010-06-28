<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Appraisal_Fill_AID.aspx.vb" Inherits="Appraisal_Fill_AID" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="Js/common.js" type="text/javascript"></script>
    <script src="Js/jquery.js" type="text/javascript"></script>
    <style type="text/css">
        .bg_and_width {
            width:250px;
            background-color:Gray;
        }
    </style>
    <script type="text/javascript" >
        function confirmFillAID() {
            var reqid = document.getElementById('<%=LabelReq_Id.ClientID%>').innerHTML;
            var aid = document.getElementById('<%=TextBoxAID.ClientID%>').value;
            var r = confirm('คุณต้องการยืนยันการใส่เลข AID ใช่หรือไม่ ?')
            if (r) {
                PageMethods.ConfirmAID(reqid, aid, this.callbackConfirm);
            }
            else {
            }
        }
        function callbackConfirm(result) {
            //  let the user know if their credit card was validated
            if (result) {
                alert('Confirm AID compleate!');
               var _PopupModal = getValueFromQueryString("PopupModal");
                id = "IframeShowFillAID";
                var iframe = window.parent.document.getElementById(id);
                window.parent.$find(_PopupModal).hide();
                window.parent.location.replace(window.parent.location);
                window.parent.close;
                
            }
            else {
                alert('Warning, Confirm AID not compleate!');
            }
        }
        function returnValue() {
            var _PopupModal = getValueFromQueryString("PopupModal");
            id = "IframeCondo";
            var iframe = window.parent.document.getElementById(id);
            window.parent.$find(_PopupModal).hide();
            //window.parent.location.replace(window.parent.location);
        }                   
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <div>
        <table width="100%" border="1">
            <tr>
                <td class="bg_and_width" bgcolor="Gray">
                    Req ID
                </td>
                <td>
                    <asp:Label ID="LabelReq_Id" runat="server" 
                        style="font-weight: 700; color: #0000FF"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="bg_and_width">
                    Cif</td>
                <td>
                    <asp:Label ID="LabelCif" runat="server" 
                        style="font-weight: 700; color: #0000FF"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="bg_and_width">
                    Cif Name</td>
                <td>
                    <asp:Label ID="LabelCifName" runat="server" 
                        style="font-weight: 700; color: #0000FF" Width="300px"></asp:Label>
                </td>
            </tr>            
            <tr>
                <td class="bg_and_width">
                    AID
                </td>
                <td>
                    <asp:TextBox ID="TextBoxAID" runat="server"></asp:TextBox>
                </td>
            </tr>            
            <tr align="center" style="background-color:Gray;">
                <td colspan="2">
                    <table>
                        <tr>
                            <td>
                                <asp:ImageButton ID="ImageSave" runat="server" ImageUrl="~/Images/Save.jpg" Width="35px"
                                    Height="35px" OnClientClick="confirmFillAID(); return false;" />
                            </td>
                            <td>
                                <asp:Label ID="lblSave" runat="server" Style="font-weight: 700" Text="SAVE"></asp:Label>
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
    </div>
    </form>
</body>
</html>
