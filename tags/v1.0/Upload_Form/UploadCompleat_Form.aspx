<%@ Page Language="VB" AutoEventWireup="false" CodeFile="UploadCompleat_Form.aspx.vb" Inherits="Upload_Form_UploadCompleat_Form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Upload Complete</title>
    <script language="javascript" type="text/javascript">
    // <!CDATA[

    function CloseButton_onclick() {
    //window.opener.window.messagearea.innerHTML = "File Upload Complete.";
    window.close();
    }

    // ]]>
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
    Done
        <br />
        <br />
        <input id="CloseButton" type="button" value="Close" onclick="return CloseButton_onclick()" />
    </div>
    </form>
</body>
</html>
