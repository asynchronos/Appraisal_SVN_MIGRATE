<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Province.aspx.vb" Inherits="Province" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="Js/common.js" type="text/javascript"></script>
    <script type="text/javascript">

        function returnValue(proCode, proName) {
            //Cif=TxtCifColl&Title=ddlTitleColl&CifName=TxtCifNameColl&CifLastname=TxtCifLastNameColl&PopupModal=mpeBehaviorSearchCifColl
            //alert(1);
            var _proCode = getValueFromQueryString("ProvinceCode");
            //alert(_proCode);
            var _proName = getValueFromQueryString("ProvinceName");
            //alert(_proName);
           var _PopupModal = getValueFromQueryString("PopupModal");
            //alert(_PopupModal);

            window.parent.$("input[myId='" + _proCode + "']")[0].value = proCode;
            //setDataToDropdownList(_Title,title);
            window.parent.$("input[myId='" + _proName + "']")[0].value = proName;
            window.parent.$find(_PopupModal).hide();
        }    
    </script>       
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>ชื่อจังหวัด</td>
                <td>
                    <asp:TextBox ID="TextBoxProvinceName" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="ButtonSearch" runat="server" Text="ค้นหา" />
                </td>
            </tr>
        </table>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                    CellPadding="2" DataSourceID="SqlDataSourceProvince" ForeColor="Black" 
                    GridLines="None">
                    <Columns>
                        <asp:TemplateField HeaderText="รหัสจังหวัด" SortExpression="PROV_CODE">
                            <ItemStyle  HorizontalAlign="Center"/>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBoxPROV_CODE" runat="server" Text='<%# Bind("PROV_CODE") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LabelPROV_CODE" runat="server" Text='<%# Bind("PROV_CODE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ชื่อจังหวัด" SortExpression="PROV_NAME">
                            <ItemStyle  Width="250px"/>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBoxPROV_NAME" runat="server" Text='<%# Bind("PROV_NAME") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LabelPROV_NAME" runat="server" Text='<%# Bind("PROV_NAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgLocation" runat="server" ImageUrl="~/Images/Select_user.png"
                                        Height="22px" Width="22px" ToolTip="เลือกลูกค้า" OnClientClick='<%# "returnValue(" +Eval("PROV_CODE").toString() +","""+Eval("PROV_NAME").toString()+"""); return false;" %>' />
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
                <asp:SqlDataSource ID="SqlDataSourceProvince" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
                    SelectCommand="GET_PROVINCE_INFO_BY_NAME" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="TextBoxProvinceName" Name="PROV_NAME" 
                            PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
