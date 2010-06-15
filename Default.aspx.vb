
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim A1 As String
        Dim i As Integer
        Dim ApprroveID As String
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        A1 = lbluserid.Text
        i = A1.IndexOf("_")
        If i > 0 Then
            ApprroveID = Left(A1, i)
        Else
            ApprroveID = lbluserid.Text
        End If
        HiddenFieldUserLogin.Value = ApprroveID.ToString
    End Sub
End Class
