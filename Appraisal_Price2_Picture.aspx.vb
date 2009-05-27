
Partial Class Appraisal_Price2_Picture
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblReq_Id.Text = Request.QueryString("Req_Id")
            lblHub_Id.Text = Request.QueryString("Hub_Id")
        End If
    End Sub
End Class
