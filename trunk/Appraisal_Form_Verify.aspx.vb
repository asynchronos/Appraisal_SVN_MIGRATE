Imports Appraisal_Manager
Imports System.Xml.Serialization
Imports System.Xml
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Win32
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Text
Imports System.Web.UI
Imports System.Web.UI.WebControls.WebParts
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Globalization.CultureInfo

Partial Class Appraisal_Form_Appraisal_Form_Verify
    Inherits System.Web.UI.Page

#Region "Variables"
    Dim gvUniqueID As String = String.Empty
    Dim gvNewPageIndex As Integer = 0
    Dim gvEditIndex As Integer = -1
    Dim gvSortExpr As String = String.Empty
#End Region

    Private Property gvSortDir() As String
        Get
            Return IIf(TryCast(ViewState("SortDirection"), String) Is Nothing, "ASC", TryCast(ViewState("SortDirection"), String))
        End Get
        Set(ByVal value As String)
            ViewState("SortDirection") = value
        End Set
    End Property

    'This procedure returns the Sort Direction
    Private Function GetSortDirection() As String
        Select Case gvSortDir
            Case "ASC"
                gvSortDir = "DESC"
                Exit Select
            Case "DESC"
                gvSortDir = "ASC"
                Exit Select
        End Select
        Return gvSortDir
    End Function

    Private Function ChildDataSource(ByVal strRegId As Integer, ByVal strSort As String) As SqlDataSource
        Dim strQRY As String = ""
        Dim dsTemp As New SqlDataSource
        Dim conn As String = ConfigurationManager.ConnectionStrings.Item("AppraisalConn").ToString '"server=172.19.54.2;Database=Appraisal_Test;User ID=sa;Password=sa0123"

        dsTemp.ConnectionString = conn

        strQRY = "SELECT dbo.Appraisal_Request_Master.Req_ID, dbo.Appraisal_Request_PicturePath.Hub_ID, dbo.TB_HUB.HUB_NAME,dbo.Appraisal_Request_PicturePath.Picture_Path,dbo.Appraisal_Request_PicturePath.done" _
                & " FROM dbo.Appraisal_Request_Master INNER JOIN" _
                & " dbo.Appraisal_Request_PicturePath ON dbo.Appraisal_Request_Master.Req_ID = dbo.Appraisal_Request_PicturePath.Req_ID LEFT OUTER JOIN" _
                & " dbo.TB_HUB ON dbo.Appraisal_Request_PicturePath.Hub_ID = dbo.TB_HUB.HUB_ID WHERE dbo.Appraisal_Request_Master.Req_ID = " & strRegId & ""
        dsTemp.SelectCommand = strQRY
        Return dsTemp
    End Function

#Region "GridView1 Event Handlers"
    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        Dim row As GridViewRow = e.Row
        Dim strSort As String = String.Empty

        ' Make sure we aren't in header/footer rows 
        If row.DataItem Is Nothing Then
            Return
        End If

        'Find Child GridView control 
        Dim gv As New GridView()
        gv = DirectCast(row.FindControl("GridView2"), GridView)

        'Check if any additional conditions (Paging, Sorting, Editing, etc) to be applied on child GridView 
        If gv.UniqueID = gvUniqueID Then
            gv.PageIndex = gvNewPageIndex
            gv.EditIndex = gvEditIndex
            'Check if Sorting used 
            If gvSortExpr <> String.Empty Then
                GetSortDirection()
                strSort = " ORDER BY " + String.Format("{0} {1}", gvSortExpr, gvSortDir)
            End If
            'Expand the Child grid 
            ClientScript.RegisterStartupScript([GetType](), "Expand", "<SCRIPT LANGUAGE='javascript'>expandcollapse('div" + DirectCast(e.Row.DataItem, DataRowView)("Q_ID").ToString() + "','one');</script>")
        End If

        'Prepare the query for Child GridView by passing the Customer ID of the parent row 
        gv.DataSource = ChildDataSource(DirectCast(e.Row.DataItem, DataRowView)("Req_Id").ToString(), strSort)
        gv.DataBind()
    End Sub
#End Region

#Region "GridView2 Event Handlers"
    Protected Sub GridView2_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Dim gvTemp As GridView = DirectCast(sender, GridView)
        gvUniqueID = gvTemp.UniqueID
        gvNewPageIndex = e.NewPageIndex
        GridView1.DataBind()
    End Sub

    Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then

            If DirectCast(e.Row.DataItem, DataRowView)("Req_ID").ToString() = String.Empty Then
                e.Row.Visible = False
            End If
        End If

    End Sub

    Protected Sub GridView2_Sorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs)
        Dim gvTemp As GridView = DirectCast(sender, GridView)
        gvUniqueID = gvTemp.UniqueID
        gvSortExpr = e.SortExpression
        GridView1.DataBind()
    End Sub

#End Region

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim lblHub_Id As Label = TryCast(Me.Form.FindControl("lblHub_Id"), Label)
        hdfHub_Id.Value = lblHub_Id.Text
    End Sub
End Class
