
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

Partial Class Appraisal_Form_Appraisal_Form
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
        Dim conn As String = "server=172.19.54.2;Database=Appraisal;User ID=sa;Password=sa0123"

        dsTemp.ConnectionString = conn

        strQRY = "SELECT dbo.Appraisal_Request_Master.Req_ID, dbo.Appraisal_Request.Hub_ID, dbo.TB_HUB.HUB_NAME" _
                 & " FROM dbo.Appraisal_Request_Master INNER JOIN" _
                 & " dbo.Appraisal_Request ON dbo.Appraisal_Request_Master.Req_ID = dbo.Appraisal_Request.Req_ID INNER JOIN" _
                 & " dbo.TB_HUB ON dbo.Appraisal_Request.Hub_ID = dbo.TB_HUB.HUB_ID WHERE dbo.Appraisal_Request_Master.Req_ID = " & strRegId & ""
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

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If RadioButtonList1.SelectedValue = "1" Then
            lblMessage.Text = "Cif ไม่จำเป็นต้องใส่ หากไม่ทราบ"
        Else
            lblMessage.Text = "Cif จำเป็นต้องใส่ ทุกครั้ง"
        End If
    End Sub

    Protected Sub cb1_Checked(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb1 As CheckBox = sender
        For Each gdi As GridViewRow In GridView_HubList.Rows
            If gdi.RowType = DataControlRowType.DataRow Then
                Dim cb2 As CheckBox = gdi.Cells(0).FindControl("cb2")
                cb2.Checked = cb1.Checked
            End If
        Next
    End Sub

    Protected Sub Button_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim B1 As Button = DirectCast(sender, Button)
        'Dim L1 As Label = DirectCast(sender, Label)
        Dim chkbox As CheckBox = B1.Parent.FindControl("cb2")
        Dim lblHub As Label = B1.Parent.FindControl("lblHUB_ID")
        Dim RegId As Label = FindControl("lblRequestID")
        'MsgBox(chkbox.ClientID)

        Dim S1 As String = Nothing
        'S1 += "wopen_checked('" + Page.ResolveUrl("~/Upload_Form/Upload_Request_Form.aspx") + ""
        'S1 += "?req_id=" & "document.getElementById('" + RegId.ClientID + "').value"
        'S1 += "&hub_id=" & lblHub.Text
        S1 = "link_url('" + Page.ResolveUrl("~/Upload_Form/Upload_Request_Form.aspx") + "','popup',500,300,'" + chkbox.ClientID + "','" + RegId.ClientID + "','" + lblHub.ClientID + "'); return false;"

        'B1.Attributes.Add("onclick", "wopen_checked('" + Page.ResolveUrl("~/Upload_Form/Upload_Request_Form.aspx") + "', 'popup', 500, 300, '" + chkbox.ClientID + "'); return false;")

        B1.Attributes.Add("onclick", S1)


    End Sub

    Private Function GET_RequestID() As DataSet

        'For Print Data Out
        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        MyConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)

        MyDataAdapter = New SqlDataAdapter("GET_REQUEST_ID", MyConnection)
        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
        'MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Q_ID", SqlDbType.Int))
        'MyDataAdapter.SelectCommand.Parameters("@Q_ID").Value = QID

        DS = New DataSet() 'Create a new DataSet to hold the records.
        MyDataAdapter.Fill(DS, "GET_REQUEST_ID") 'Fill the DataSet with the rows returned.
        Return DS

    End Function

    Protected Sub imgBtnSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnSave.Click
        'Code Save
        If lblRequestID.Text <> String.Empty Then
            Dim dg As GridView = FindControl("GridView_HubList")
            Dim gvr_master As GridViewRow
            Appraisal_Manager.AddAppraisal_Request_Master(lblRequestID.Text, TxtCif.Text, ddlTitle.SelectedValue, TxtCifName.Text, TxtCifLastName.Text, RadioButtonList1.SelectedValue, txtAID.Text, 0, lblUserID.Text, Now)

            For Each gvr_master In dg.Rows
                Dim chk1 As CheckBox = gvr_master.FindControl("cb2")
                Dim lblHubID As Label = gvr_master.FindControl("lblHUB_ID")
                If chk1.Checked = True Then
                    Appraisal_Manager.AddAppraisal_Request(lblRequestID.Text, lblHubID.Text, TxtCif.Text, ddlTitle.SelectedValue, TxtCifName.Text, TxtCifLastName.Text, RadioButtonList1.SelectedValue, 0, lblUserID.Text, Now)
                End If
            Next
            bntRequest_ID.Enabled = True
            imgBtnSave.Enabled = False
        Else
            lblMessage.Text = "ยังไม่มีเลขที่คำขอประเมิน"
        End If
        GridView1.DataBind()


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If lblRequestID.Text = String.Empty Or lblRequestID.Text = "" Then
            lblMessage.Text = "คุณยังไม่มีเลขคำขอประเมิน"
            GridView_HubList.Enabled = False
        Else
            lblMessage.Text = ""
        End If
    End Sub

    Protected Sub bntRequest_ID_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bntRequest_ID.Click
        Dim ds As DataSet
        ds = GET_RequestID()
        If ds.Tables(0).Rows.Count > 0 Then
            lblRequestID.Text = ds.Tables(0).Rows.Item(0).Item("Req_ID")
            bntRequest_ID.Enabled = False
        Else
            'lblRequestID.Text = ""
        End If

        If lblRequestID.Text = String.Empty Or lblRequestID.Text = "" Then
            lblMessage.Text = "คุณยังไม่มีเลขคำขอประเมิน"
            GridView_HubList.Enabled = False
        Else
            GridView_HubList.Enabled = True
            lblMessage.Text = ""
            UPDATE_REQUEST_ID()
            imgBtnSave.Enabled = True
        End If
    End Sub


End Class
