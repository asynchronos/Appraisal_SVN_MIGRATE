
Partial Class Appraisal_Step_Follow
    Inherits System.Web.UI.Page

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim lblHub As Label = TryCast(Me.Form.FindControl("lblHub_Id"), Label)
        HiddenHubId.Value = lblHub.Text
    End Sub
End Class
