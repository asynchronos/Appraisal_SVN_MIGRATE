<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Appraisal_Reason_Cancel.aspx.vb"
    Inherits="Appraisal_Reason_Cancel" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

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
            color: Blue;
            font-weight: bold;
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
        .styleHeader
        {
            background-color: Gray;
            color: Yellow;
            font-weight: bold;
            text-decoration: underline;
            text-align: center;
        }
        .style1
        {
            color: #CC3300;
            font-weight: bold;
            text-decoration: underline;
        }
        .style2
        {
            color: #CC3300;
            font-weight: bold;
            font-size: medium;
        }
    </style>

    <script type="text/javascript">
        function saveReasonCancel() {
            var reason = getEleByProperty("textarea", "myId", "TextBoxReason").value;
            //alert(reason.length);
            if (reason.length == 0) {
                alert('กรุณาระบุเหตุผลในการยกเลิกคำขอการประเมิน');
            } else {
                var reqid = getEleByProperty("input", "myId", "TextBoxReq_Id");
                var hubid = getEleByProperty("input", "myId", "TextBoxHub_Id");
                var statusId = getValueFromQueryString("StatusId");
                var userCancel = getValueFromQueryString("User_Cancel");
                //---Confirm Save ----
                var r = confirm('คุณต้องการยกเลิกคำขอประเมินเลขที่ ' + reqid.value + ' ใช่หรือไม่ ?')
                if (r) {
                    PageMethods.SaveCancelReqId(reqid.value, hubid.value, statusId, reason.value, userCancel, this.callback1);
                    window.parent.location.replace(window.parent.location);
                }
                else {
                    
                }
            }
        }
        function callback1(result) {
            //  hide the popup
            //this._popup.hide();
            if (result) {
                alert('Save data compleate!');
            }
            else {
                alert('Warning, Save not compleate!');
            }
        }        
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <div>
        <table class="TableWidth">
            <tr>
                <td class="styleHeader" colspan="2">
                    เหตุผลการยกเลิกคำขอประเมิน
                </td>
            </tr>
            <tr>
                <td class="bgcolour">
                    REQ ID
                </td>
                <td>
                    <asp:TextBox ID="TextBoxReq_Id" runat="server" myId="TextBoxReq_Id" onfocus="this.blur();"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="bgcolour">
                    HUB ID
                </td>
                <td>
                    <asp:TextBox ID="TextBoxHub_Id" runat="server" myId="TextBoxHub_Id" onfocus="this.blur();"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="bgcolour">
                    HUB NAME
                </td>
                <td>
                    <asp:TextBox ID="TextBoxHub_Name" runat="server" Width="300px" onfocus="this.blur();"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="bgcolour">
                    CIF
                </td>
                <td>
                    <asp:TextBox ID="TextBoxCif" runat="server" myId="TextBoxHub_Id" onfocus="this.blur();"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="bgcolour">
                    CIF NAME
                </td>
                <td>
                    <asp:TextBox ID="TextBoxCifName" runat="server" Width="300px" onfocus="this.blur();"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td valign="top" class="bgcolour">
                    เหตุผลการยกเลิก
                </td>
                <td>
                    <asp:TextBox ID="TextBoxReason" runat="server" Height="90px" TextMode="MultiLine"
                        Width="550px" myId="TextBoxReason"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="background-color: Yellow;">
                    <span class="style1">คำแนะนำ</span> <span class="style2">คุณต้องระบุเหตุผลการยกเลิกคำขอประเมิน
                        หากยืนยันการยกเลิกแล้วจะไม่ปรากฎคำขอประเมินนั้นอีก</span>
                </td>
            </tr>
            <tr>
                <td class="bgcolour" colspan="2" align="center">
                    <table>
                        <tr>
                            <td>
                                <asp:ImageButton ID="ImageSave" runat="server" ImageUrl="~/Images/Save.jpg" Width="35px"
                                    Height="35px" OnClientClick="saveReasonCancel(); return false;" />
                            </td>
                            <td>
                                <asp:Label ID="lblSave" runat="server" Style="font-weight: 700" Text="SAVE"></asp:Label>
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
