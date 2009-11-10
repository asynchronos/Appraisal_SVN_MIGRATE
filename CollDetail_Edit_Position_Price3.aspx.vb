
Partial Class CollDetail_Edit_Position_Price3
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'MsgBox(Request.QueryString("UserId"))
        If Not Page.IsPostBack Then
            hdfReq_Id.Value = Request.QueryString("Req_Id")
            hdfTemp_AID.Value = Request.QueryString("Temp_AID")
            'hdfUserId.Value = Request.QueryString("UserId")
        End If
    End Sub
End Class
