<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Appraisal_Queuein.aspx.vb" Inherits="Default3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 20px;
        }
        .style2
        {
        }
        .style3
        {
        }
        .style4
        {
            width: 189px;
        }
        .style5
        {
            width: 120px;
        }
        .style6
        {
            width: 128px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <br />
    <br />
    <table class="style1">
        <tr>
            <td class="style6">
                <asp:Label ID="Label3" runat="server" Text="เรื่องเข้าในระบบ"></asp:Label>
            </td>
            <td>
                <asp:FormView ID="FormView3" runat="server" DataSourceID="SqlSum_In">
                    <EditItemTemplate>
                        sum_in:
                        <asp:TextBox ID="sum_inTextBox" runat="server" Text='<%# Bind("sum_in") %>' />
                        <br />
                        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                            CommandName="Update" Text="Update" />
                        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                            CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        sum_in:
                        <asp:TextBox ID="sum_inTextBox0" runat="server" Text='<%# Bind("sum_in") %>' />
                        <br />
                        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                            CommandName="Insert" Text="Insert" />
                        &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                            CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="sum_inLabel" runat="server" Text='<%# Bind("sum_in") %>' />
                        <br />
                    </ItemTemplate>
                </asp:FormView>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <table class="style1">
        <tr>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2" valign="bottom">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" DataSourceID="SqlCount_Hub" ForeColor="#333333" 
                    GridLines="None">
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="HUB_NAME" HeaderText="ศูนย์ประเมิน" 
                            SortExpression="HUB_NAME" />
                        <asp:BoundField DataField="Count_Hub" HeaderText="งานเข้าระบบ Appraisal" 
                            SortExpression="Count_Hub">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <asp:SqlDataSource ID="SqlSum_In" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="SELECT [sum_in] FROM [View_sum_in]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlCount_Hub" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" SelectCommand="SELECT [HUB_NAME], [Count_Hub] FROM [View_Count_Hub]
order by count_hub desc"></asp:SqlDataSource>
    </form>
</body>
</html>
