Imports Appraisal_Manager
Partial Class LandFileAttach
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Request.QueryString("Req_Id") Is Nothing Then
                LabelReqIdValue.Text = Context.Items("Req_Id")
                LabelCifValue.Text = Context.Items("Cif")
                LabelCifNameValue.Text = Context.Items("CifName")
            Else
                Context.Items("Req_Id") = Request.QueryString("Req_Id")
                Context.Items("Cif") = Request.QueryString("Cif")
                Context.Items("CifName") = Request.QueryString("CifName")
                LabelReqIdValue.Text = Context.Items("Req_Id")
                LabelCifValue.Text = Context.Items("Cif")
                LabelCifNameValue.Text = Context.Items("CifName")
            End If

            Dim req As List(Of Appraisal_Request_v2) = GET_APPRAISAL_REQUEST_V2(LabelReqIdValue.Text)
            LabelHubIdValue.Text = req.Item(0).Hub_ID
            If req.Count > 0 Then
                Dim hub As List(Of Cls_Hub) = GET_Hub_Info(req.Item(0).Hub_ID)
                LabelHubNameValue.Text = hub.Item(0).HUB_NAME
            Else
                LabelHubNameValue.Text = String.Empty
            End If
        End If
    End Sub

End Class
