<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Amphur.aspx.vb" Inherits="Amphur" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="Js/common.js" type="text/javascript"></script>
    <script type="text/javascript">

        function returnValue(amphurCode, amphurName) {
            //Cif=TxtCifColl&Title=ddlTitleColl&CifName=TxtCifNameColl&CifLastname=TxtCifLastNameColl&PopupModal=mpeBehaviorSearchCifColl
            //alert(1);
            var _amphurCode = getValueFromQueryString("AmphurCode");
            //alert(_proCode);
            var _amphurName = getValueFromQueryString("AmphurName");
            //alert(_proName);
           var _PopupModal = getValueFromQueryString("PopupModal");
            //alert(_PopupModal);

           window.parent.$("input[myId='" + _amphurCode + "']")[0].value = amphurCode;
            //setDataToDropdownList(_Title,title);
           window.parent.$("input[myId='" + _amphurName + "']")[0].value = amphurName;
            window.parent.$find(_PopupModal).hide();
        }    
    </script>   
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    ชื่ออำเภอ
                </td>
                <td>
                    <asp:TextBox ID="TextBoxProvinceName" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="ButtonSearch" runat="server" Text="ค้นหา" />
                </td>
            </tr>
        </table>
        <asp:GridView ID="GridViewAmphur" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="pvcode,amcode" DataSourceID="SqlDataSourceAmphur" 
            AllowPaging="True" BackColor="LightGoldenrodYellow" BorderColor="Tan" 
            BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" 
            PageSize="5">
            <Columns>
                <asp:TemplateField HeaderText="รหัสอำเภอ" SortExpression="amcode">
                     <ItemStyle HorizontalAlign="Center" Width= "150px"/>
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("amcode") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("amcode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ชื่อ อำเภอ" SortExpression="am_name">
                    <ItemStyle Width="300px"/>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("am_name") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("am_name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
<asp:ImageButton ID="imgLocation" runat="server" ImageUrl="~/Images/Select_user.png"
                                        Height="22px" Width="22px" ToolTip="เลือกลูกค้า" OnClientClick='<%# "returnValue(" +Eval("amcode").toString() +","""+Eval("am_name").toString()+"""); return false;" %>' />
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
    <asp:SqlDataSource ID="SqlDataSourceAmphur" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
            SelectCommand="GET_AMPHUR_INFO_BY_PROCODE" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="PROVINCE_CODE" QueryStringField="ProCode" 
                Type="Int32" />
        </SelectParameters>
                    </asp:SqlDataSource>

    </div>
    </form>
</body>
</html>
