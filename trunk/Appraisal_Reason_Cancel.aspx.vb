Imports Appraisal_Manager
Partial Class Appraisal_Reason_Cancel
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            TextBoxReq_Id.Text = Request.QueryString("Req_Id")
            TextBoxHub_Id.Text = Request.QueryString("Hub_Id")
            TextBoxHub_Name.Text = Request.QueryString("HubName")
            TextBoxCif.Text = Request.QueryString("Cif")
            TextBoxCifName.Text = Request.QueryString("CifName")
        End If
    End Sub

    <System.Web.Script.Services.ScriptMethod()> _
<System.Web.Services.WebMethod()> _
Public Shared Function SaveCancelReqId(ByVal ReqId As String, ByVal HubId As String, ByVal StatusId As String, ByVal Reason As String, ByVal User_Cancel As String) As Boolean
        Dim isValid As Boolean = False
        Try
            'UPDATE_APPRAISAL_ID(ReqId, HubId, 3, AppraisalId)
            ADD_APPRAISAL_REASON_CANCEL(ReqId, HubId, StatusId, Reason, User_Cancel)
            isValid = True
        Catch ex As Exception
            isValid = False
        End Try
        Return isValid
    End Function
End Class
