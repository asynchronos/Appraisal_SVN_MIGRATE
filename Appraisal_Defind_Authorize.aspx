<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_Defind_Authorize.aspx.vb" Inherits="Appraisal_Defind_Authorize" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 234px;
        }
    </style>
    
    <script type="text/javascript">
            function ConfirmOnUpdate() {
                if (confirm("�س�׹�ѹ�������¹�ŧ�Է���������Թ��������� ?") == true)
                return true;
            else
                return false;
        }          
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
<br />
    <asp:Label ID="Label1" runat="server" Text="��˹��Է��������Թ���᷹" 
        Font-Bold="True" ForeColor="#3333CC"></asp:Label>
    <table class="style1">
        <tr>
            <td class="style2">
                ���� - ʡ��</td>
            <td>
                <asp:DropDownList ID="ddlAppraisal" runat="server" DataSourceID="sdsAppraisal" 
                    DataTextField="UserAppraisal" DataValueField="Appraisal_Id">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2">
                �Է�Է�����</td>
            <td>
                <asp:DropDownList ID="ddlAuthorize" runat="server">
                    <asp:ListItem Value="1">��º������˹�� Hub</asp:ListItem>
                    <asp:ListItem Value="2">��º����ͧ���˹�� Hub</asp:ListItem>
                    <asp:ListItem Value="3">��º��Ҿ�ѡ�ҹ�����Թ</asp:ListItem>
                    <asp:ListItem Value="4">��º��� Adminis Hub</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:SqlDataSource ID="sdsAppraisal" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
                            
                            
                            
                            
                            
                    SelectCommand="SELECT Emp_id as Appraisal_Id, Title + Name + '  ' + Lastname AS UserAppraisal FROM Tb_UserAppraisal WHERE (Hub_Id = @Hub_Id Or Emp_Id = '0')">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hdfHub_Id" Name="Hub_Id" 
                            PropertyName="Value" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:HiddenField ID="hdfHub_Id" runat="server" />
            </td>
            <td>
                <asp:Button ID="btnConfirm" runat="server" Text="�׹�ѹ��á�˹��Է���" OnClientClick=" return ConfirmOnUpdate();" />
            </td>
        </tr>
    </table>

</asp:Content>

