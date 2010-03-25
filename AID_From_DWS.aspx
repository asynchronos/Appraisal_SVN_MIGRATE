<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AID_From_DWS.aspx.vb" Inherits="AID_From_DWS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="Js/common.js" type="text/javascript"></script>
    <script type="text/javascript">

        function returnValue(AID) {
        
             var _aid = getValueFromQueryString("AID");
             var _PopupModal = getValueFromQueryString("PopupModal");
             window.parent.$("input[myId='" + _aid + "']")[0].value = AID;
             window.parent.$find(_PopupModal).hide();
        }    
        
    </script>   
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="100%">
        <tr align="center">
            <td>
                <asp:GridView ID="GridViewAID" runat="server" 
                BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                CellPadding="2" ForeColor="Black" GridLines="None" 
                AutoGenerateColumns="False">
                    <Columns>
                <asp:TemplateField HeaderText="CIF">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBoxCifNo" runat="server" Text='<%# Bind("CIF") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblcif" runat="server" Text='<%# Bind("CIF") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="APPRAISAL_ID">
                <ItemStyle  Width="250px"/>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBoxAppraisalId" runat="server" Text='<%# Bind("APPRAISAL_ID") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblAppraisal_Id" runat="server" Text='<%# Bind("APPRAISAL_ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgLocation" runat="server" ImageUrl="~/Images/Select_user.png"
                                        Height="22px" Width="22px" ToolTip="เลือกลูกค้า" OnClientClick='<%# "returnValue(""" +Eval("APPRAISAL_ID").toString() +"""); return false;" %>' />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
                <FooterStyle BackColor="Tan" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                    HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                </asp:GridView>            
        <asp:Label ID="LabelCif" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
