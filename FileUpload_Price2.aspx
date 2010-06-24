<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FileUpload_Price2.aspx.vb" Inherits="FileUpload_Price2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        แนบรูปภาพจากสถานที่จริง
    </title>
    <style type="text/css">

        .style1
        {
            color: #993300;
            font-weight: bold;
        }
    </style>
</head>
<body>
<form id="form1" runat="server" enctype="multipart/form-data">
<div id="mainDiv">

<p id="upload-area">
   <input id="File1" type="file" runat="server" size="60" />
</p>

<input id="AddFile" type="button" value="Add file" onclick="addFileUploadBox()" />
    <br />
    <p class="style1">ไฟล์ที่จะทำการ Upload ต้องเป็นนามสกุล .gif,.png,.jpeg,.jpg,.bmp 
        และ .tiff เท่านั้น</p>
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

                <asp:BoundField DataField="Temp_AID" HeaderText="Temp_AID" ReadOnly="True" 
                    SortExpression="Temp_AID" />

                <asp:TemplateField HeaderText="File upload">
                    <ItemTemplate>
                     <asp:HyperLink ID="linkPath" runat="server"  target='_blank'  text='<%#EVAL("Picture_Path") %>' NavigateUrl='<%#  "UploadedFiles/Pic_Price2/" &  EVAL("Picture_Path") %>'>HyperLink</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
               
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
               
            </Columns>
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:SqlDataSource ID="Appraisal_Request_PicturePath" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
            
    
    
    SelectCommand="SELECT Appraisal_Price2_PicturePath.Req_ID, Appraisal_Price2_PicturePath.Hub_ID, Appraisal_Price2_PicturePath.Temp_AID, TB_HUB.HUB_NAME, Appraisal_Price2_PicturePath.Picture_Path FROM Appraisal_Price2_PicturePath INNER JOIN TB_HUB ON Appraisal_Price2_PicturePath.Hub_ID = TB_HUB.HUB_ID WHERE (Appraisal_Price2_PicturePath.Req_ID = @Req_Id) AND (Appraisal_Price2_PicturePath.Hub_ID = @Hub_Id)" 
    DeleteCommand="DELETE FROM Appraisal_Price2_PicturePath WHERE (Req_ID = @Req_ID) AND (Hub_ID = @Hub_ID) AND (Picture_Path = @Picture_Path)">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblReq_Id" Name="Req_Id" PropertyName="Text" />
                <asp:ControlParameter ControlID="lblHub_Id" Name="Hub_Id" PropertyName="Text" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="Req_ID" />
                <asp:Parameter Name="Hub_ID" />
                <asp:Parameter Name="Picture_Path" />
            </DeleteParameters>
        </asp:SqlDataSource>
        <br />
        <asp:Label ID="lblReq_Id" runat="server" Visible="False"></asp:Label>
        <br />
        <asp:Label ID="lblHub_Id" runat="server" Visible="False"></asp:Label>
    
<script type="text/javascript">
function addFileUploadBox()
{
    if (!document.getElementById || !document.createElement)
        return false;
		
    var uploadArea = document.getElementById ("upload-area");
	
    if (!uploadArea)
        return;

    var newLine = document.createElement ("br");
    uploadArea.appendChild (newLine);
	
    var newUploadBox = document.createElement ("input");
	
    // Set up the new input for file uploads
    newUploadBox.type = "file";
    newUploadBox.size = "60";
	
    // The new box needs a name and an ID
    if (!addFileUploadBox.lastAssignedId)
        addFileUploadBox.lastAssignedId = 100;
	    
    newUploadBox.setAttribute ("id", "dynamic" + addFileUploadBox.lastAssignedId);
    newUploadBox.setAttribute ("name", "dynamic:" + addFileUploadBox.lastAssignedId);
    uploadArea.appendChild (newUploadBox);
    addFileUploadBox.lastAssignedId++;
}


</script>
<br />
        <asp:Label ID="lblTemp_AID" runat="server" Visible="False"></asp:Label>
    
</form>
</body>
</html>
