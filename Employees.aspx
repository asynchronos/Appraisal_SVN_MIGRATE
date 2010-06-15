<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Employees.aspx.vb" Inherits="Employees" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="Js/common.js" type="text/javascript"></script>
    <script type="text/javascript">

        function returnValue(empId, title,empName,empLastname) {

            var _empNameConcat = title + empName + '  ' + empLastname;
            var _empId = getValueFromQueryString("EmpId");
            var _empName = getValueFromQueryString("EmpName");
            var _PopupModal = getValueFromQueryString("PopupModal");

           window.parent.$("input[myId='" + _empId + "']")[0].value = empId;
           window.parent.$("input[myId='" + _empName + "']")[0].value = _empNameConcat;
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
            DataKeyNames="EMP_ID" DataSourceID="SqlDataSource1" Width="572px" BackColor="LightGoldenrodYellow"
            BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black"
            GridLines="None" PageSize="9">
            <Columns>
                <asp:BoundField DataField="EMP_ID" HeaderText="รหัสพนักงาน" ReadOnly="True" ItemStyle-Width="180"
                    SortExpression="EMP_ID">
                    <ItemStyle Width="180px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="TITLE_NAME" HeaderText="คำนำหน้า" ItemStyle-Width="100"
                    SortExpression="TITLE_NAME">
                    <ItemStyle Width="100px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="EMPNAME" HeaderText="ชื่อ" ItemStyle-Width="200" SortExpression="EMPNAME">
                    <ItemStyle Width="200px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="EMPSURNAME" HeaderText="นามสกุล" ItemStyle-Width="200"
                    SortExpression="EMPSURNAME">
                    <ControlStyle Width="200px"></ControlStyle>
                    <ItemStyle Width="200px"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgLocation" runat="server" ImageUrl="~/Images/Select_user.png"
                                        Height="22px" Width="22px" ToolTip="เลือกลูกค้า" OnClientClick='<%# "returnValue(""" +Eval("EMP_ID").toString() +""","""+Eval("TITLE_NAME").toString()+""","""+Eval("EMPNAME").toString()+""","""+Eval("EMPSURNAME").toString()+"""); return false;" %>' />
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
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    </form>
</body>
</html>
