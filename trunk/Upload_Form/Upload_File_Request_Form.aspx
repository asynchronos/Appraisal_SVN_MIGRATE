<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Upload_File_Request_Form.aspx.vb" Inherits="Upload_Form_Upload_File_Request_Form" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>File Upload Request Form</title>
    <style type="text/css">
    .modalBox 
    {
	    background-color : #f5f5f5;
	    border-width: 3px;
	    border-style: solid;
	    border-color: Blue;
	    padding: 3px;
    }
    .modalBox caption 
    {
	    background-image: url(images/window_titlebg.gif);
	    background-repeat:repeat-x;
    }
    .caption, table caption {
	    background-color: #aaa;
	    background-image: url('images/tilebg_tablecaption.gif');
	    color: #000;
	    font-size: 16pt;
	    font-weight: bold;
	    border: 0;
	    border-bottom: solid 1px #737373;
	    white-space: nowrap;
	    text-align: center;
    }   
        .updateProgressMessage
        {
            margin:3px; 
            font-family:Trebuchet MS; 
            font-size:small; 
            vertical-align: middle;
        }   
                .updateProgress
        {
            border-width:1px; 
            border-style:solid; 
            background-color:#FFFFFF; 
            position:absolute; 
            width:350px; 
            height:50px;    
        }  
    </style>
</head>
<body>
<form id="form1" runat="server" enctype="multipart/form-data">
<div id="mainDiv">

    <p>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        ไฟล์ที่จะทำการ Upload ต้องเป็นนามสกุล .gif,.png,.jpeg,.jpg,.bmp 
        และ .tiff เท่านั้น</p>

<p id="upload-area">
   <input id="File1" type="file" runat="server" size="60" />
</p>

<input id="AddFile" type="button" value="Add file" onclick="addFileUploadBox()" />
<br />
<br />
<asp:Button ID="btnSubmit" runat="server" Text="Upload รูปทั้งหมด"  
        OnClick="btnSubmit_Click" />   

<%--    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnSubmit" PopupControlID="pnlPhone" BackgroundCssClass="modalBackground"
                BehaviorID="mdlPopupBehavior">
    </cc1:ModalPopupExtender>
			<asp:Panel ID="pnlPhone" runat="server" CssClass="updateProgress" Style="display: none;">
                <div align="center" style="margin-top:13px;">
                    <img src="../Images/progress.gif" alt="" />
                    <span class="updateProgressMessage">Please wait ...</span>
                </div>
			</asp:Panel>  --%>  
    <asp:Image ID="Image_progress" runat="server" 
        ImageUrl="~/Images/progress.gif" />
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
<asp:HiddenField ID="hdfReq_Id" runat="server" />
<asp:HiddenField ID="hdfHub_Id" runat="server" />
<asp:HiddenField ID="hdfReq_form" runat="server" />
</form>
</body>
</html>
