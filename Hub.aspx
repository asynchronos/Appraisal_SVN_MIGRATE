<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Hub.aspx.vb" Inherits="Hub" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="Js/common.js" type="text/javascript"></script>
    <script type="text/javascript">

        function returnValue(hubId, hubName) {
            //Cif=TxtCifColl&Title=ddlTitleColl&CifName=TxtCifNameColl&CifLastname=TxtCifLastNameColl&PopupModal=mpeBehaviorSearchCifColl
            //alert(1);
            var _hubId = getValueFromQueryString("HubCode");
            var _hubName = getValueFromQueryString("HubName");
           var _PopupModal = getValueFromQueryString("PopupModal");

           window.parent.$("input[myId='" + _hubId + "']")[0].value = hubId;
           window.parent.$("input[myId='" + _hubName + "']")[0].value = hubName;
           window.parent.$find(_PopupModal).hide();
        }    
    </script>      
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" 
            BorderWidth="1px" CellPadding="2" DataSourceID="SqlDataSourceHub" 
            ForeColor="Black" GridLines="None">
            <Columns>
                <asp:TemplateField HeaderText="รหัส HUB" SortExpression="hub_id">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBoxHubId" runat="server" Text='<%# Bind("hub_id") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LabelHubId" runat="server" Text='<%# Bind("hub_id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ชื่อ HUB" SortExpression="HUB_NAME">
                <ItemStyle Width="300px"/>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBoxHubName" runat="server" Text='<%# Bind("HUB_NAME") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LabelHubName" runat="server" Text='<%# Bind("HUB_NAME") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgLocation" runat="server" ImageUrl="~/Images/Select_user.png"
                                        Height="22px" Width="22px" ToolTip="เลือกลูกค้า" OnClientClick='<%# "returnValue(" +Eval("hub_id").toString() +","""+Eval("HUB_NAME").toString()+"""); return false;" %>' />
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
        <asp:SqlDataSource ID="SqlDataSourceHub" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
            SelectCommand="GET_HUB_INFO_BY_KEY" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:QueryStringParameter Name="PROVINCE_CODE" QueryStringField="ProCode" 
                    Type="Int32" />
                <asp:QueryStringParameter DefaultValue="" Name="AMPHUR_CODE" 
                    QueryStringField="AmphurCode" Type="Int32" />
                <asp:QueryStringParameter DefaultValue="" Name="TAMBON_CODE" 
                    QueryStringField="TambonCode" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
