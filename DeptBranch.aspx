<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DeptBranch.aspx.vb" Inherits="DeptBranch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="Js/common.js" type="text/javascript"></script>
    <script type="text/javascript">

        function returnValue(idDepTran, depTranT, flag) {
            //รับค่า Query String ที่ส่งมาจากหน้าแม่
            var _idDepTran = getValueFromQueryString("DeptBranchId");
            var _depTranT = getValueFromQueryString("DeptBranchName");
            var _flag = getValueFromQueryString("Flag");
            var _PopupModal = getValueFromQueryString("PopupModal");

            window.parent.$("input[myId='" + _idDepTran + "']")[0].value = idDepTran;
            window.parent.$("input[myId='" + _depTranT + "']")[0].value = depTranT;
            window.parent.$("input[myId='" + _flag + "']")[0].value = flag;
            window.parent.$find(_PopupModal).hide();
        }    
    </script> 
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="ค้นหาจาก"></asp:Label>
        &nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
        &nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        &nbsp;<asp:Button ID="Button1" runat="server" Text="ค้นหา" />
        &nbsp;<asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            DataKeyNames="Id_DepTran" DataSourceID="SqlDataSource1" Width="551px" BackColor="White"
            BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
            GridLines="Vertical" PageSize="6">
            <RowStyle BackColor="#F7F7DE" />
            <Columns>
                <asp:BoundField DataField="Id_DepTran" HeaderText="รหัสสาขา/ฝ่ายงาน" ReadOnly="True" ItemStyle-Width="150"
                    SortExpression="Id_DepTran">
                    <ItemStyle Width="150px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="DepTranT" HeaderText="ชื่อ สาขา/ฝ่ายงาน" ItemStyle-Width="250" SortExpression="DepTranT">
                    <ItemStyle Width="250px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Flag" HeaderText="FLAG" ItemStyle-Width="80"
                    SortExpression="Flag">
                    <ControlStyle Width="80px"></ControlStyle>
                    <ItemStyle Width="80px"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField ShowHeader="False">
                    <ItemStyle Width="80px"/>
                    <ItemTemplate>
                        <asp:ImageButton ID="imgLocation" runat="server" ImageUrl="~/Images/Select_user.png"
                                        Height="22px" Width="22px" ToolTip="เลือกลูกค้า" OnClientClick='<%# "returnValue(""" +Eval("Id_DepTran").toString() +""","""+Eval("DepTranT").toString()+""","""+Eval("FLAG").toString()+"""); return false;" %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    <div>
    
    </div>
    </form>
</body>
</html>
