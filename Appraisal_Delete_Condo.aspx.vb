Imports Appraisal_Manager

Partial Class Appraisal_Delete_Condo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            HiddenFieldReq_Id.Value = Request.QueryString("Req_Id").ToString
            HiddenFieldHub_Id.Value = Request.QueryString("Hub_Id").ToString
            HiddenFieldCondo_Id.Value = Request.QueryString("CondoId").ToString
            HiddenFieldSubCollType.Value = Request.QueryString("MysubColl_ID").ToString
        End If
    End Sub

    'Protected Sub ButtonDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonDelete.Click
    '    DELETE_PRICE2_PRICE3_70(HiddenFieldReq_Id.Value, HiddenFieldHub_Id.Value, HiddenFieldBuilding_Id.Value, HiddenFieldSubCollType.Value)
    'End Sub

    <System.Web.Script.Services.ScriptMethod()> _
<System.Web.Services.WebMethod()> _
Public Shared Function DeleteCondo(ByVal ReqId As String, ByVal HubId As String, ByVal id As String, ByVal subCollType As String) As Boolean
        Dim isValid As Boolean = False
        Try
            'DELETE_PRICE2_PRICE3_70(ReqId, HubId, id, subCollType)
            DELETE_PRICE2_PRICE3_18(id, ReqId, HubId)
            isValid = True
        Catch ex As Exception
            isValid = False
        End Try
        Return isValid
    End Function
End Class
