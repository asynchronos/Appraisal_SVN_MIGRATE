
Partial Class Appraisal_Step_Follow
    Inherits System.Web.UI.Page

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim lblHub As Label = TryCast(Me.Form.FindControl("lblHub_Id"), Label)
        Dim lblUserId As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        HiddenHubId.Value = lblHub.Text
        hdfAppraisal_Id.Value = lblUserId.Text
    End Sub
End Class
