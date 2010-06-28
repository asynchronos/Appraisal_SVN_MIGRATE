Imports System
Imports System.Web
Imports System.Web.Services
Imports Appraisal_Manager

Partial Class Appraisal_Fill_AID
    Inherits System.Web.UI.Page

    <System.Web.Script.Services.ScriptMethod()> _
<System.Web.Services.WebMethod()> _
Public Shared Function ConfirmAID(ByVal ReqId As Integer, ByVal AID As String) As Boolean
        ' simulate a longer operation ... 
        'System.Threading.Thread.Sleep(1000)

        Dim isValid As Boolean = False

        Try
            'MsgBox(ReqId)
            'MsgBox(AID)
            UPDATE_AID(ReqId, AID)
            isValid = True
        Catch
            isValid = False
        End Try
        Return isValid

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LabelReq_Id.Text = Request.QueryString("Req_Id")
            LabelCif.Text = Request.QueryString("Cif")
            LabelCifName.Text = Request.QueryString("CifName")
        End If
    End Sub

End Class
