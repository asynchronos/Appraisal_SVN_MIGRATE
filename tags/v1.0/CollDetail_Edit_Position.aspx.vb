
Partial Class CollDetail_Edit_Position
    Inherits System.Web.UI.Page

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        hdfReq_Id.Value = Request.QueryString("Req_Id")
        hdfHub_Id.Value = Request.QueryString("Hub_Id")

        'MsgBox(hdfReq_Id.Value).ToString()
        'MsgBox(hdfHub_Id.Value).ToString()
    End Sub
End Class
