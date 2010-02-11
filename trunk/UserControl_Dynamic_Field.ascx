<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UserControl_Dynamic_Field.ascx.vb" Inherits="UserControl_Dynamic_Field" %>
<table>
        <tr>
            <td>เงื่อนไขที่ค้นหา:</td>
            <td>
                <asp:DropDownList ID="ddl1" runat="server" AutoPostBack="True">
                    <asp:ListItem Text="เลขคำขอประเมิน" />
                    <asp:ListItem Text="AID" />
                    <asp:ListItem Text="CIF" />
                    <asp:ListItem Text="ตำบล/แขวง" />
                    <asp:ListItem Text="อำเภอ/เขต" />
                    <asp:ListItem Text="จังหวัด" />
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="txtOption" runat="server"></asp:TextBox>
            </td>
            <td>
      <asp:Button ID="btnRemove" runat="server" Text="Remove" />          
            </td>
        </tr>
        </table>
    

    
    <hr />
