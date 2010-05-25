<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Appraisal_Standard.aspx.vb"
    Inherits="Appraisal_Standard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="Js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="Js/common.js" type="text/javascript"></script>

    <script type="text/javascript">

        function returnValue(standardId, standardName) {

            var _standardId = getValueFromQueryString("StandardCode");
            var _standardName = getValueFromQueryString("StandardName");
            var _PopupModal = getValueFromQueryString("PopupModal");

            window.parent.$("input[myId='" + _standardId + "']")[0].value = standardId;
            window.parent.$("input[myId='" + _standardName + "']")[0].value = standardName;
           window.parent.$find(_PopupModal).hide();
        }    
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
            BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="Standard_Id"
            DataSourceID="SqlDataSourceSTANDARD_INFO" ForeColor="Black" 
            GridLines="None" AllowPaging="True" style="font-size: small">
            <Columns>
                <asp:TemplateField HeaderText="Standard Id" SortExpression="Standard_Id">
                    <ItemTemplate>
                        <asp:Label ID="LabelStandard_Id" runat="server" Text='<%# Bind("Standard_Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Standard Name" SortExpression="Standard_Name">
                <ItemStyle Width="450px" />
                    <ItemTemplate>
                        <asp:Label ID="LabelStandard_Name" runat="server" Text='<%# Bind("Standard_Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgLocation" runat="server" ImageUrl="~/Images/Select_user.png"
                            Height="22px" Width="22px" ToolTip="เลือกลูกค้า" OnClientClick='<%# "returnValue(""" +Eval("Standard_Id").toString() +""","""+Eval("Standard_Name").toString()+"""); return false;" %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="Tan" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceSTANDARD_INFO" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
            SelectCommand="GET_STANDARD_INFO" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
