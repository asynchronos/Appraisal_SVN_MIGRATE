
Partial Class CollDetail_Show_Position
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            hdfReq_Id.Value = Request.QueryString("Req_Id")
            hdfHub_Id.Value = Request.QueryString("Hub_Id")
        End If
    End Sub
End Class
