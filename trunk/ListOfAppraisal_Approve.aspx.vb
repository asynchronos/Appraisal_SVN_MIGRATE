
Partial Class ListOfAppraisal_Approve
    Inherits System.Web.UI.Page

    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        hdfReq_Id.Value = Request.QueryString("Req_Id")
        hdfHub_Id.Value = Request.QueryString("Hub_Id")
        'MsgBox(hdfReq_Id.Value)
        'MsgBox(hdfHub_Id.Value)
    End Sub

    Protected Sub bntClose_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim StrNotice As String
        StrNotice = "<Script language=""javascript"">window.close('');</Script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", StrNotice)
    End Sub
End Class
