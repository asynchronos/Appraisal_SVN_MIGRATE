﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FileUpload_Price3.aspx.vb" Inherits="FileUpload_Price3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 366px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td class="style2" valign="top">
                    <div id="mainDiv">

<p id="upload-area">
   <input id="File1" type="file" runat="server" size="40" />
</p>

<input id="AddFile" type="button" value="Add file" onclick="addFileUploadBox()" onclick="return AddFile_onclick()" />
<p><asp:Button ID="btnSubmit" runat="server" Text="Upload Now"  OnClick="btnSubmit_Click" /></p>

</div>
    
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" CellPadding="4" 
            DataKeyNames="Req_ID,Hub_ID,Picture_Path" 
            DataSourceID="Appraisal_Request_PicturePath" ForeColor="#333333" 
            GridLines="None">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:BoundField DataField="Req_ID" HeaderText="Req_ID" ReadOnly="True" 
                    SortExpression="Req_ID" />
                <asp:BoundField DataField="HUB_NAME" HeaderText="HUB_NAME" 
                    SortExpression="HUB_NAME" />
                <asp:BoundField DataField="AID" HeaderText="AID" ReadOnly="True" 
                    SortExpression="AID" />
                <asp:BoundField DataField="Temp_AID" HeaderText="Temp_AID" ReadOnly="True" 
                    SortExpression="Temp_AID" />
                <asp:TemplateField HeaderText="File upload">
                    <ItemTemplate>
                     <asp:HyperLink ID="linkPath" runat="server"  target='_blank'  text='<%#EVAL("Picture_Path") %>' NavigateUrl='<%#  "UploadedFiles/Pic_Price3/" &  EVAL("Picture_Path") %>'>HyperLink</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
               
            </Columns>
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:SqlDataSource ID="Appraisal_Request_PicturePath" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
            
    SelectCommand="GET_APPRAISAL_PRICE3_PICTUREPATH" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblReq_Id" Name="Req_Id" PropertyName="Text" />
                <asp:ControlParameter ControlID="lblHub_Id" Name="Hub_Id" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:Label ID="lblReq_Id" runat="server" Visible="False"></asp:Label>
                    <br />
        <asp:Label ID="lblHub_Id" runat="server" Visible="False"></asp:Label>
        <br />
        <asp:Label ID="lblUserId" runat="server" Visible="False"></asp:Label>
    
<script type="text/javascript">
    function addFileUploadBox() {
        if (!document.getElementById || !document.createElement)
            return false;

        var uploadArea = document.getElementById("upload-area");

        if (!uploadArea)
            return;

        var newLine = document.createElement("br");
        uploadArea.appendChild(newLine);

        var newUploadBox = document.createElement("input");

        // Set up the new input for file uploads
        newUploadBox.type = "file";
        newUploadBox.size = "40";

        // The new box needs a name and an ID
        if (!addFileUploadBox.lastAssignedId)
            addFileUploadBox.lastAssignedId = 100;

        newUploadBox.setAttribute("id", "dynamic" + addFileUploadBox.lastAssignedId);
        newUploadBox.setAttribute("name", "dynamic:" + addFileUploadBox.lastAssignedId);
        uploadArea.appendChild(newUploadBox);
        addFileUploadBox.lastAssignedId++;
    }


function AddFile_onclick() {

}

function AddFile_onclick() {

}

</script>
                    <br />
        <asp:Label ID="lblAID" runat="server" Visible="False"></asp:Label>
<br />
        <asp:Label ID="lblTemp_AID" runat="server" Visible="False"></asp:Label>
                    <br />
        <asp:Label ID="lblCID" runat="server" Visible="False"></asp:Label>
                </td>
                <td valign="top">
    
        <asp:GridView ID="GridView_HubList" runat="server" AutoGenerateColumns="False" 
            CellPadding="2" DataKeyNames="HUB_ID" DataSourceID="sdsHub" 
            ForeColor="Black" GridLines="Horizontal" BackColor="LightGoldenrodYellow" 
            BorderColor="Tan" BorderWidth="1px" ShowFooter="True">
            <FooterStyle BackColor="Tan" />
            <Columns>
                            <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox runat="server" ID="cb1" AutoPostBack="true" 
                            OnCheckedChanged="cb1_Checked"/> 
                    </HeaderTemplate>
                   <ItemTemplate>
                     <asp:CheckBox runat="server" ID="cb2"/>  
                   </ItemTemplate> 
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
             </asp:TemplateField> 
                            <asp:TemplateField HeaderText="รหัส HUB" SortExpression="HUB_ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblHub_Id" runat="server" Text='<%# Bind("HUB_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" ชื่อ HUB" SortExpression="HUB_NAME">
                                <ItemStyle Width="300px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblHUB_NAME" runat="server" Text='<%# Bind("HUB_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>              							
            </Columns>
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
        </asp:GridView>
	<asp:SqlDataSource ID="sdsHub" runat="server" 
		ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
		SelectCommand="SELECT [HUB_ID], [HUB_NAME] FROM [TB_HUB]">
	</asp:SqlDataSource>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
