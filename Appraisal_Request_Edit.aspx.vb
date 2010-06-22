Imports System
Imports System.Web
Imports System.Web.Services
Imports System.Threading
Imports System.Net
Imports System.Data
Imports System.Collections
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Math
Imports Appraisal_Manager
Imports System.Globalization

Partial Class Appraisal_Request_Ecit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LabelReq_Id.Text = Request.QueryString("Req_Id")
            LabelHub_Id.Text = Request.QueryString("Hub_Id")
            TextBoxCif.Text = Request.QueryString("Cif")
            ddlTitle.SelectedValue = Request.QueryString("Title")
            TxtCifName.Text = Request.QueryString("CifName")
            TxtCifLastName.Text = Request.QueryString("CifLastname")
            TextBoxChanode.Text = Request.QueryString("CollNumber")
            ddlAPPLICATION_TYPE.SelectedValue = Request.QueryString("AppId")
            ddlBranch.SelectedValue = Request.QueryString("BranchId")
            txtReceive_Date.Text = Request.QueryString("CeateDate")

        End If
    End Sub

    <System.Web.Script.Services.ScriptMethod()> _
<System.Web.Services.WebMethod()> _
Public Shared Function Update_Appraisal_Request(ByVal ReqId As String, ByVal HubId As String, ByVal Cif As String, ByVal Title As String, ByVal Cifname As String, ByVal CifLastname As String, ByVal Chanode As String, ByVal AppType As String, ByVal Branch_Id As String, ByVal Date_Receive As String) As Boolean
        ' simulate a longer operation ... 
        System.Threading.Thread.Sleep(1000)

        Dim isValid As Boolean = False
        Dim createDate As DateTime = Nothing
        'Dim cul As New CultureInfo("en-US")
        'Dim cul As New CultureInfo("th-TH")
        'Try
        '    createDate = DateTime.Parse(Date_Receive, cul)
        '    'createDate = DateAdd(DateInterval.Year, -543, createDate)
        '    'createDate = createDate
        'Catch ex As Exception
        '    createDate = DateTime.Now
        'End Try
        'createDate = Format(CDate(Date_Receive).ToString, "MM/dd/YYYY")
        'MsgBox(CDate(Date_Receive))
        createDate = Format(CDate(Date_Receive), "dd/MM/yyyy")

        Try
            UPDATE_APPRAISAL_REQUEST_EDIT(ReqId, HubId, Cif, Title, Cifname, CifLastname, Chanode, AppType, Branch_Id, createDate)
            isValid = True
        Catch
            isValid = False
        End Try
        Return isValid
    End Function

    <System.Web.Script.Services.ScriptMethod()> _
<System.Web.Services.WebMethod()> _
Public Shared Function Delete_Appraisal_Request(ByVal ReqId As String, ByVal HubId As String, ByVal Cif As String) As Boolean
        ' simulate a longer operation ... 
        System.Threading.Thread.Sleep(1000)

        Dim isValid As String = String.Empty

        Try
            DELETE_APPRAISAL_REQUEST_V2(ReqId, HubId, Cif)
            isValid = True
        Catch
            isValid = False
        End Try
        Return isValid
    End Function
End Class
