<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CID_2_PreAID.aspx.vb" Inherits="CID_2_PreAID" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>จัดกลุ่ม Coll ID</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
        }
        .style3
        {
            width: 211px;
        }
    </style>
</head>
<body style="margin-top:0px; margin-left:0px; margin-right:0px; background-image:url(Images/imagesCAMBBQTW.jpg);">
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td class="style2" colspan="2">
                    <asp:Label ID="lblMessage" runat="server" Font-Bold="True" 
                        style="color: #FF0000" Text="กำหนดกลุ่มประเมินโดย"></asp:Label>
&nbsp;<asp:CheckBox ID="CheckBox1" runat="server" Checked="True" Enabled="False" />
&nbsp;<asp:Label ID="Label1" runat="server" style="font-weight: 700; color: #FF0000" 
                        Text="เพื่อเลือก Coll ID ของตารางด้านล่าง"></asp:Label>
                </td>
            </tr>
            </table>
            <table>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label2" runat="server" Text="กำหนดชื่อผู้ประเมิน" 
                        style="color: #6600FF; font-weight: 700"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" style="margin-left: 0px" 
                        DataSourceID="SDSUserAppraisal" DataTextField="UserAppraisal" 
                        DataValueField="Emp_id">
                    </asp:DropDownList>
                </td>
            </tr> 
            <tr>
                <td class="style3">
                    <asp:Label ID="Label3" runat="server" Text="เลข TEMP AID" 
                        style="color: #6600FF; font-weight: 700"></asp:Label>
                </td>
                <td bgcolor="#33CCCC">
                    <asp:Label ID="lblTempAID" runat="server" 
                        style="color: #FF0000; font-weight: 700"></asp:Label>
                </td>
            </tr>  
            <tr>
                <td class="style3">
                    <asp:Label ID="Label4" runat="server" Text="ชื่อศูนย์" 
                        style="color: #6600FF; font-weight: 700"></asp:Label>
                </td>
                <td bgcolor="#33CCCC">
                    <asp:Label ID="Label5" runat="server" 
                        style="color: #FF0000; font-weight: 700"></asp:Label>
                </td>
            </tr>                                     
            <tr>
                <td class="style3">
                    <asp:Button ID="btnSaveGroup" runat="server" Text="บันทึกกลุ่มประเมิน" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="2" DataKeyNames="Q_ID,coll_id" DataSourceID="SqlDataSource1" 
            ForeColor="Black" GridLines="None" BackColor="LightGoldenrodYellow" 
            BorderColor="Tan" BorderWidth="1px" Width="100%">
            <FooterStyle BackColor="Tan" />
            <Columns>
                            <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox runat="server" ID="cb1" AutoPostBack="true" OnCheckedChanged="cb1_Checked"/> 
                    </HeaderTemplate>
                   <ItemTemplate>
                     <asp:CheckBox runat="server" ID="cb2" />  
                   </ItemTemplate> 
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
             </asp:TemplateField> 
                            <asp:TemplateField HeaderText="Q_ID" SortExpression="Q_ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblQ_ID" runat="server" Text='<%# Bind("Q_ID") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Q_ID") %>'></asp:Label>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="COLL ID" SortExpression="coll_id">
                                <ItemTemplate>
                                    <asp:Label ID="lblColl_ID" runat="server" Text='<%# Bind("coll_id") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("coll_id") %>'></asp:Label>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Detail1" HeaderText="Detail1" 
                                SortExpression="Detail1" />
                <asp:BoundField DataField="Prov_Name" HeaderText="จังหวัด" 
                    SortExpression="Prov_Name" />
                <asp:BoundField DataField="Detail2" HeaderText="Detail2" ReadOnly="True" 
                    SortExpression="Detail2" />
            </Columns>
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" SelectCommand="SELECT D.Q_ID,D.coll_id,isnull(cd.detail1,'-') Detail1,cd.Prov_Name,isnull(cd.detail2,'-')Detail2 From Sent_Appraisal_Detail D INNER JOIN Sent_Appraisal_Master M ON  D.Q_ID = M.Q_ID INNER JOIN Bay01.dbo.COLL_ID_DISTINCT CD ON d.coll_Id = Cd.Coll_ID AND M.Cif = CD.CIF
WHERE D.Q_ID = @QID AND D.Appraisal_ID  IS NULL">
            <SelectParameters>
                <asp:QueryStringParameter Name="QID" QueryStringField="Qid" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    <asp:SqlDataSource ID="SDSUserAppraisal" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="SELECT Emp_id, Title + Name + '  ' + Lastname AS UserAppraisal FROM Tb_UserAppraisal">
    </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
