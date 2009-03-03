Imports System
Imports System.ComponentModel
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Partial Class UserControl_uploadFile
    Inherits System.Web.UI.UserControl

    Public Event Click As MultipleFileUploadClick

    Private _Rows As Integer = 10
    Public Property Rows() As Integer
        'The no of visible rows to display. 
        Get
            Return _Rows
        End Get
        Set(ByVal value As Integer)
            _Rows = IIf(value < 10, 10, value)
        End Set
    End Property

    Private _UpperLimit As Integer = 0
    Public Property UpperLimit() As Integer
        Get
            Return _UpperLimit
        End Get
        Set(ByVal value As Integer)
            _UpperLimit = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        lblCaption.Text = IIf(_UpperLimit = 0, "Maximum Files: No Limit", String.Format("Maximum Files: {0}", _UpperLimit))
        pnlListBox.Attributes("style") = "overflow:auto;"
        pnlListBox.Height = Unit.Pixel(20 * _Rows - 1)
        Page.ClientScript.RegisterStartupScript(GetType(Page), "MyScript", GetJavaScript())
    End Sub

    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Fire the event. 
        RaiseEvent Click(Me, New FileCollectionEventArgs(Me.Request))
    End Sub

    Private Function GetJavaScript() As String
        Dim JavaScript As New StringBuilder()
        JavaScript.Append("<script type='text/javascript'>")
        JavaScript.Append("var Id = 0;\n")
        JavaScript.AppendFormat("var MAX = {0};\n", _UpperLimit)
        JavaScript.AppendFormat("var DivFiles = document.getElementById('{0}');\n", pnlFiles.ClientID)
        JavaScript.AppendFormat("var DivListBox = document.getElementById('{0}');\n", pnlListBox.ClientID)
        JavaScript.AppendFormat("var BtnAdd = document.getElementById('{0}');\n", btnAdd.ClientID)
        JavaScript.Append("function Add()")
        JavaScript.Append("{\n")
        JavaScript.Append("var IpFile = GetTopFile();\n")
        JavaScript.Append("if(IpFile == null || IpFile.value == null || IpFile.value.length == 0)\n")
        JavaScript.Append("{\n")
        JavaScript.Append("alert('Please select a file to add.');\n")
        JavaScript.Append("return;\n")
        JavaScript.Append("}\n")
        JavaScript.Append("var NewIpFile = CreateFile();\n")
        JavaScript.Append("DivFiles.insertBefore(NewIpFile,IpFile);\n")
        JavaScript.Append("if(MAX != 0 && GetTotalFiles() - 1 == MAX)\n")
        JavaScript.Append("{\n")
        JavaScript.Append("NewIpFile.disabled = true;\n")
        JavaScript.Append("BtnAdd.disabled = true;\n")
        JavaScript.Append("}\n")
        JavaScript.Append("IpFile.style.display = 'none';\n")
        JavaScript.Append("DivListBox.appendChild(CreateItem(IpFile));\n")
        JavaScript.Append("}\n")
        JavaScript.Append("function CreateFile()")
        JavaScript.Append("{\n")
        JavaScript.Append("var IpFile = document.createElement('input');\n")
        JavaScript.Append("IpFile.id = IpFile.name = 'IpFile_' + Id++;\n")
        JavaScript.Append("IpFile.type = 'file';\n")
        JavaScript.Append("return IpFile;\n")
        JavaScript.Append("}\n")
        JavaScript.Append("function CreateItem(IpFile)\n")
        JavaScript.Append("{\n")
        JavaScript.Append("var Item = document.createElement('div');\n")
        JavaScript.Append("Item.style.backgroundColor = '#ffffff';\n")
        JavaScript.Append("Item.style.fontWeight = 'normal';\n")
        JavaScript.Append("Item.style.textAlign = 'left';\n")
        JavaScript.Append("Item.style.verticalAlign = 'middle'; \n")
        JavaScript.Append("Item.style.cursor = 'default';\n")
        JavaScript.Append("Item.style.height = 20 + 'px';\n")
        JavaScript.Append("var Splits = IpFile.value.split('\\\\');\n")
        JavaScript.Append("Item.innerHTML = Splits[Splits.length - 1] + '&nbsp;';\n")
        JavaScript.Append("Item.value = IpFile.id;\n")
        JavaScript.Append("Item.title = IpFile.value;\n")
        JavaScript.Append("var A = document.createElement('a');\n")
        JavaScript.Append("A.innerHTML = 'Delete';\n")
        JavaScript.Append("A.id = 'A_' + Id++;\n")
        JavaScript.Append("A.href = '#';\n")
        JavaScript.Append("A.style.color = 'blue';\n")
        JavaScript.Append("A.onclick = function()\n")
        JavaScript.Append("{\n")
        JavaScript.Append("DivFiles.removeChild(document.getElementById(this.parentNode.value));\n")
        JavaScript.Append("DivListBox.removeChild(this.parentNode);\n")
        JavaScript.Append("if(MAX != 0 && GetTotalFiles() - 1 < MAX)\n")
        JavaScript.Append("{\n")
        JavaScript.Append("GetTopFile().disabled = false;\n")
        JavaScript.Append("BtnAdd.disabled = false;\n")
        JavaScript.Append("}\n")
        JavaScript.Append("}\n")
        JavaScript.Append("Item.appendChild(A);\n")
        JavaScript.Append("Item.onmouseover = function()\n")
        JavaScript.Append("{\n")
        JavaScript.Append("Item.bgColor = Item.style.backgroundColor;\n")
        JavaScript.Append("Item.fColor = Item.style.color;\n")
        JavaScript.Append("Item.style.backgroundColor = '#C6790B';\n")
        JavaScript.Append("Item.style.color = '#ffffff';\n")
        JavaScript.Append("Item.style.fontWeight = 'bold';\n")
        JavaScript.Append("}\n")
        JavaScript.Append("Item.onmouseout = function()\n")
        JavaScript.Append("{\n")
        JavaScript.Append("Item.style.backgroundColor = Item.bgColor;\n")
        JavaScript.Append("Item.style.color = Item.fColor;\n")
        JavaScript.Append("Item.style.fontWeight = 'normal';\n")
        JavaScript.Append("}\n")
        JavaScript.Append("return Item;\n")
        JavaScript.Append("}\n")
        JavaScript.Append("function Clear()\n")
        JavaScript.Append("{\n")
        JavaScript.Append("DivListBox.innerHTML = '';\n")
        JavaScript.Append("DivFiles.innerHTML = '';\n")
        JavaScript.Append("DivFiles.appendChild(CreateFile());\n")
        JavaScript.Append("BtnAdd.disabled = false;\n")
        JavaScript.Append("}\n")
        JavaScript.Append("function GetTopFile()\n")
        JavaScript.Append("{\n")
        JavaScript.Append("var Inputs = DivFiles.getElementsByTagName('input');\n")
        JavaScript.Append("var IpFile = null;\n")
        JavaScript.Append("for(var n = 0; n < Inputs.length && Inputs[n].type == 'file'; ++n)\n")
        JavaScript.Append("{\n")
        JavaScript.Append("IpFile = Inputs[n];\n")
        JavaScript.Append("break;\n")
        JavaScript.Append("}\n")
        JavaScript.Append("return IpFile;\n")
        JavaScript.Append("}\n")
        JavaScript.Append("function GetTotalFiles()\n")
        JavaScript.Append("{\n")
        JavaScript.Append("var Inputs = DivFiles.getElementsByTagName('input');\n")
        JavaScript.Append("var Counter = 0;\n")
        JavaScript.Append("for(var n = 0; n < Inputs.length && Inputs[n].type == 'file'; ++n)\n")
        JavaScript.Append("Counter++;\n")
        JavaScript.Append("return Counter;\n")
        JavaScript.Append("}\n")
        JavaScript.Append("function GetTotalItems()\n")
        JavaScript.Append("{\n")
        JavaScript.Append("var Items = DivListBox.getElementsByTagName('div');\n")
        JavaScript.Append("return Items.length;\n")
        JavaScript.Append("}\n")
        JavaScript.Append("function DisableTop()\n")
        JavaScript.Append("{\n")
        JavaScript.Append("if(GetTotalItems() == 0)\n")
        JavaScript.Append("{\n")
        JavaScript.Append("alert('Please browse at least one file to upload.');\n")
        JavaScript.Append("return false;\n")
        JavaScript.Append("}\n")
        JavaScript.Append("GetTopFile().disabled = true;\n")
        JavaScript.Append("return true;\n")
        JavaScript.Append("}\n")
        JavaScript.Append("</script>")

        Return JavaScript.ToString()
    End Function
End Class

Public Class FileCollectionEventArgs
    Inherits EventArgs
    Private _HttpRequest As HttpRequest

    Public ReadOnly Property PostedFiles() As HttpFileCollection
        Get
            Return _HttpRequest.Files
        End Get
    End Property

    Public ReadOnly Property Count() As Integer
        Get
            Return _HttpRequest.Files.Count
        End Get
    End Property

    Public ReadOnly Property HasFiles() As Boolean
        Get
            Return IIf(_HttpRequest.Files.Count > 0, True, False)
        End Get
    End Property

    Public ReadOnly Property TotalSize() As Double
        Get
            Dim Size As Double = 0
            For n As Integer = 0 To _HttpRequest.Files.Count - 1
                If _HttpRequest.Files(n).ContentLength < 0 Then
                    Continue For
                Else
                    Size += _HttpRequest.Files(n).ContentLength
                End If
            Next

            Return Math.Round(Size / 1024, 2)
        End Get
    End Property

    Public Sub New(ByVal oHttpRequest As HttpRequest)
        _HttpRequest = oHttpRequest
    End Sub
End Class

'Delegate that represents the Click event signature for MultipleFileUpload control.
Public Delegate Sub MultipleFileUploadClick(ByVal sender As Object, ByVal e As FileCollectionEventArgs)
