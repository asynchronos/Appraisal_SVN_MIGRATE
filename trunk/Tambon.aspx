<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Tambon.aspx.vb" Inherits="Tambon" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="Js/common.js" type="text/javascript"></script>
    <script type="text/javascript">

        function returnValue(tambonCode, tambonName) {
            //Cif=TxtCifColl&Title=ddlTitleColl&CifName=TxtCifNameColl&CifLastname=TxtCifLastNameColl&PopupModal=mpeBehaviorSearchCifColl
            //alert(1);
            var _tambonCode = getValueFromQueryString("TambonCode");
            //alert(_proCode);
            var _tambonName = getValueFromQueryString("TambonName");
            //alert(_proName);
           var _PopupModal = getValueFromQueryString("PopupModal");
            //alert(_PopupModal);

           window.parent.$("input[myId='" + _tambonCode + "']")[0].value = tambonCode;
           window.parent.$("input[myId='" + _tambonName + "']")[0].value = tambonName;
           window.parent.$find(_PopupModal).hide();
        }    
    </script>       
</head>
<body>
    <form id="form1" runat="server">
     <div>
<%--         <table>
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
        </table> --%>  
        <asp:GridView ID="GridViewAmphur" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="pvcode,amcode,ttcode" DataSourceID="SqlDataSourceTambon" 
            AllowPaging="True" BackColor="LightGoldenrodYellow" BorderColor="Tan" 
            BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" 
            PageSize="8">
            <Columns>
                <asp:TemplateField HeaderText="รหัสตำบล" SortExpression="ttcode">
                    <ItemStyle HorizontalAlign="Center" Width="150px"/>
                    <EditItemTemplate>
                        <asp:Label ID="LabelTambonCode" runat="server" Text='<%# Eval("ttcode") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LabelTambonCode1" runat="server" Text='<%# Bind("ttcode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ชื่อ ตำบล" SortExpression="tumbon_new2_name">
                    <ItemStyle Width="300px"/>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBoxTambonName" runat="server" 
                            Text='<%# Bind("tumbon_new2_name") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LabelTambonName" runat="server" Text='<%# Bind("tumbon_new2_name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgLocation" runat="server" ImageUrl="~/Images/Select_user.png"
                                        Height="22px" Width="22px" ToolTip="เลือกลูกค้า" OnClientClick='<%# "returnValue(" +Eval("ttcode").toString() +","""+Eval("tumbon_new2_name").toString()+"""); return false;" %>' />
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
    <asp:SqlDataSource ID="SqlDataSourceTambon" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
            SelectCommand="GET_TUMBON_INFO_BY_PROVINCE_CODE_AMPHUR_CODE" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="AMPHUR_CODE" QueryStringField="AmphurCode" 
                Type="Int32" />
            <asp:QueryStringParameter Name="PROVINCE_CODE" QueryStringField="ProCode" 
                Type="Int32" />
        </SelectParameters>
                    </asp:SqlDataSource>

    </div>
    </form>
</body>
</html>
