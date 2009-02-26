<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Appraisal_CheckCollType_Add.aspx.vb" Inherits="Appraisal_CheckCollType_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .tb_backgrund 
        {
           background-color: #C0C0C0;
           color: #0000FF;
           font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table border="1" class="style1">
            <tr>
                <td class="tb_backgrund">
                    Req ID :</td>
                <td>
                    <asp:Label ID="lblReq_Id" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tb_backgrund">
                    Hub ID :</td>
                <td>
                    <asp:Label ID="lblHub_Id" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tb_backgrund">
                    Cif :</td>
                <td>
                    <asp:Label ID="lblCif" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tb_backgrund">
                    AID :</td>
                <td>
                    <asp:Label ID="lblAID" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tb_backgrund">
                    Appraisal Type :</td>
                <td>
                    <asp:DropDownList ID="ddlCollType" runat="server" DataSourceID="sdsCollType" 
                        DataTextField="CollType_Name" DataValueField="CollType_ID">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tb_backgrund">
                    &nbsp;</td>
                <td class="tb_backgrund">
                    <asp:Button ID="btnOk" runat="server" Text="เพิ่มหลักประกัน" />
                </td>
            </tr>
        </table>
    
    </div>
    <asp:SqlDataSource ID="sdsCollType" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="SELECT [CollType_ID], [CollType_Name] FROM [CollType]">
    </asp:SqlDataSource>
    </form>
</body>
</html>
