Imports Appraisal_Manager
Partial Class LandFileAttach
    Inherits System.Web.UI.Page


    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        LabelReqIdValue.Text = Context.Items("Req_Id")
        LabelCifValue.Text = Context.Items("Cif")
        LabelCifNameValue.Text = Context.Items("CifName")
        Dim req As List(Of Appraisal_Request_v2) = GET_APPRAISAL_REQUEST_V2(LabelReqIdValue.Text)
        LabelHubIdValue.Text = req.Item(0).Hub_ID
        If req.Count > 0 Then
            Dim hub As List(Of Cls_Hub) = GET_Hub_Info(req.Item(0).Hub_ID)
            LabelHubNameValue.Text = hub.Item(0).HUB_NAME
        Else
            LabelHubNameValue.Text = String.Empty
        End If
    End Sub
End Class
