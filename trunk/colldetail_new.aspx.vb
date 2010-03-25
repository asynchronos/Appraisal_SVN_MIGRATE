
Partial Class colldetail_new
    Inherits System.Web.UI.Page

    Protected Sub form1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.PreRender

        HiddenField1.Value = Request.QueryString("Req_Id")
        HiddenField2.Value = Request.QueryString("Hub_Id")
        HiddenField3.Value = Request.QueryString("User_Id")
        HiddenField4.Value = Request.QueryString("cif")
    End Sub

End Class
