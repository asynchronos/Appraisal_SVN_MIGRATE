<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Upload_Request_Form.aspx.vb" Inherits="Upload_Form_Upload_Request_Form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>File Upload Request Form</title>
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
<p><asp:Button ID="btnSubmit" runat="server" Text="Upload Now"  
        OnClick="btnSubmit_Click" Visible="False" />&nbsp;</p>
    <p class="style1">ไฟล์ที่จะทำการ Upload ต้องเป็นนามสกุล .gif,.png,.jpeg,.jpg,.bmp 
        และ .tiff เท่านั้น</p>
</div>
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
<asp:Button ID="Button1" runat="server" Text="Upload Now" />
<asp:HiddenField ID="hdfReq_Id" runat="server" />
<asp:HiddenField ID="hdfHub_Id" runat="server" />
</form>
</body>
</html>
