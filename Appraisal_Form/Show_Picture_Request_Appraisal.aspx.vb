
Partial Class Upload_Form_Show_Picture_Request_Appraisal
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'MsgBox(Request.QueryString("Req_Id") & "  " & Request.QueryString("Hub_Id"))
        Label1.Text = Request.QueryString("Req_Id")
        Label2.Text = Request.QueryString("Hub_Id")
    End Sub
End Class
