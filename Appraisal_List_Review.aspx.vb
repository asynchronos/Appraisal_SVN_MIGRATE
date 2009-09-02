Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Data.SqlClient
Imports System.IO
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Globalization.CultureInfo
Imports Appraisal_Manager
Partial Class Appraisal_List_Review
    Inherits System.Web.UI.Page
    Dim s As String

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

    Protected Sub cb1_Checked(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb1 As CheckBox = sender
        Dim gv2 As New GridView()
        gv2 = cb1.Parent.Parent.Parent.Parent.Parent.FindControl("GridView2")
        For Each gdi As GridViewRow In gv2.Rows
            If gdi.RowType = DataControlRowType.DataRow Then
                Dim cb2 As CheckBox = gdi.Cells(0).FindControl("cb2")
                cb2.Checked = cb1.Checked
            End If
        Next
    End Sub

    Private Function ChildDataSource(ByVal strReq_Id As String, ByVal strSort As String) As SqlDataSource
        Dim strQRY As String = ""
        Dim dsTemp As New SqlDataSource
        Dim conn As String = ConfigurationManager.ConnectionStrings.Item("AppraisalConn").ToString
        dsTemp.ConnectionString = conn
        strQRY = "SELECT ID, Req_Id, Cif, CIFNAME, Hub_Id, HUB_NAME, Temp_AID, CollType_ID, MysubColl_ID, SubCollType_Name, Address_No, Tumbon, Amphur, Province,PROV_NAME FROM View_Appraisal_Price3_ListDetail WHERE Req_Id = " & strReq_Id & ""
        dsTemp.SelectCommand = strQRY
        Return dsTemp
    End Function

#Region "GridView1 Event Handlers"

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
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
            ClientScript.RegisterStartupScript([GetType](), "Expand", "<SCRIPT LANGUAGE='javascript'>expandcollapse('div" + DirectCast(e.Row.DataItem, DataRowView)("Req_Id").ToString() + "','one');</script>")
        End If

        'Prepare the query for Child GridView by passing the Customer ID of the parent row 
        gv.DataSource = ChildDataSource(DirectCast(e.Row.DataItem, DataRowView)("Req_Id"), strSort)
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

            If DirectCast(e.Row.DataItem, DataRowView)("Temp_AID").ToString() = String.Empty Then
                e.Row.Visible = False
            Else
                Dim Expl As String = String.Empty
                Dim Req_ID As Object = DirectCast(e.Row.DataItem, DataRowView)("Req_Id").ToString()
                Dim Hid_ID As Object = DirectCast(e.Row.DataItem, DataRowView)("ID").ToString()
                Dim ID As Object = DirectCast(e.Row.DataItem, DataRowView)("ID").ToString()
                Dim Address_No As Object = DirectCast(e.Row.DataItem, DataRowView)("Address_No").ToString()
                Expl = "เลขคำขอที่ " & Req_ID & " Hub เลขที่ " & Hid_ID & "" & " หลักประกันเลขที่ " & Address_No
                'MsgBox(DirectCast(e.Row.DataItem, DataRowView)("ID").ToString())
                If e.Row.RowState <> DataControlRowState.Edit Then
                    ' check for RowState 
                    If e.Row.RowType = DataControlRowType.DataRow Then
                        'check for RowType 
                        'Dim id As String = e.Row.Cells(0).Text
                        ' Get the id to be deleted 
                        Dim Ib As ImageButton = DirectCast(e.Row.Cells(11).FindControl("ImgDelete"), ImageButton)
                        'Dim Ib As Object = DirectCast(e.Row.DataItem, DataRowView)("ImgDelete")
                        'access the LinkButton from the TemplateField using FindControl method 
                        If Ib IsNot Nothing Then
                            Ib.Attributes.Add("onclick", "return ConfirmOnDelete('" & Expl & "');")
                            'attach the JavaScript function 
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Protected Sub GridView2_Sorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs)
        Dim gvTemp As GridView = DirectCast(sender, GridView)
        gvUniqueID = gvTemp.UniqueID
        gvSortExpr = e.SortExpression
        GridView1.DataBind()
    End Sub

    Protected Sub GridView2_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        If e.CommandName = "ViewPicture" Then
            Dim gvTemp As GridView = DirectCast(sender, GridView)
            gvUniqueID = gvTemp.UniqueID
            Dim lblcollid As Label = DirectCast(gvTemp.Rows.Item(0).FindControl("lblcoll_id"), Label)
            Response.Redirect("View_Picture_Appraisal.aspx")
        End If
    End Sub

    Protected Sub GridView2_SelectedIndexChanging(ByVal sender As Object, ByVal e As GridViewSelectEventArgs)
        'Dim str As String = ""
        Dim gvTemp As GridView = DirectCast(sender, GridView)
        Dim Req_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblReq_Id"), Label)
        Dim Hub_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblHub_Id"), Label)
        Dim lblTemp_AID As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblTemp_AID"), Label)
        Dim lblCollType_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblColltype"), Label)
        Dim Hid_ID As HiddenField = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("H_ID"), HiddenField)
        Dim lblColl_type As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblColltype"), Label)

        Context.Items("Req_Id") = Req_Id.Text
        Context.Items("Hub_Id") = Hub_Id.Text
        Context.Items("Temp_AID") = lblTemp_AID.Text
        Context.Items("Id") = Hid_ID.Value
        Context.Items("Coll_Type") = lblColl_type.Text
        Context.Items("SpecialAdd") = "ทบทวนประเมิน"

        Dim Obj_Price2 As List(Of Appraisal_Request) = GET_APPRAISAL_REQUEST(Req_Id.Text)
        If Obj_Price2.Item(0).Status_ID < 8 Then
            s = "<script language=""javascript"">alert('หัวหน้ายังไม่ยืนยันการกำหนดราคาที่ 2');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
        Else
            If lblColl_type.Text = 50 Then
                Server.Transfer("Appraisal_Price3_50_Review_Edit.aspx")
                'Server.Transfer("Appraisal_Price3_Add_Colltype50.aspx")
            ElseIf lblColl_type.Text = 70 Then
                'Response.Redirect("Appraisal_Price3_Add_Colltype70.aspx?Req_id=" & Req_Id.Text & "&Hub_Id=" & Hub_Id.Text & "&Coll_Type=" & lblColl_type.Text & "&Temp_AID=" & lblTemp_AID.Text & "&ID=" & Hid_ID.Value)
                Server.Transfer("Appraisal_Price3_Add_Colltype70.aspx")
            ElseIf lblColl_type.Text = 15 Then

            ElseIf lblColl_type.Text = 18 Then
                Server.Transfer("Appraisal_Price3_18.aspx")
            End If
        End If


        'MsgBox("Select Index Changing")
    End Sub

    Protected Sub GridView2_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)
        Dim gvTemp As GridView = DirectCast(sender, GridView)
        gvUniqueID = gvTemp.UniqueID

        'Get the value 
        'Dim strOrderID As String = DirectCast(gvTemp.Rows(e.RowIndex).FindControl("lblOrderID"), Label).Text
        Dim Req_Id As Label = DirectCast(gvTemp.Rows.Item(e.RowIndex).FindControl("lblReq_Id"), Label)
        Dim Hub_Id As Label = DirectCast(gvTemp.Rows.Item(e.RowIndex).FindControl("lblHub_Id"), Label)
        Dim Hid_ID As HiddenField = DirectCast(gvTemp.Rows.Item(e.RowIndex).FindControl("H_ID"), HiddenField)
        Dim lblTemp_AID As Label = DirectCast(gvTemp.Rows.Item(e.RowIndex).FindControl("lblTemp_AID"), Label)
        Dim lblColl_type As Label = DirectCast(gvTemp.Rows.Item(e.RowIndex).FindControl("lblColltype"), Label)
        'MsgBox(Hid_ID.Value.ToString)

        ''Prepare the Update Command of the DataSource control 
        'Dim strSQL As String = ""

        Try
            '    strSQL = "DELETE from Orders WHERE OrderID = " & strOrderID
            '    Dim dsTemp As New AccessDataSource()
            '    dsTemp.DataFile = "App_Data/Northwind.mdb"
            '    dsTemp.DeleteCommand = strSQL
            '    dsTemp.Delete()
            If lblColl_type.Text = 50 Then
                'Check Price3_50
                'Delete Price3_50
                'MsgBox("Delete Price3_50")
                DELETE_PRICE3_50(Hid_ID.Value, Req_Id.Text, Hub_Id.Text, lblTemp_AID.Text)
            ElseIf lblColl_type.Text = 70 Then
                'Check Price3_70
                'Delete Price3_70
                'MsgBox("Delete Price3_70")
                DELETE_PRICE3_70(Hid_ID.Value, Req_Id.Text, Hub_Id.Text, lblTemp_AID.Text)
            ElseIf lblColl_type.Text = 18 Then
                'Check Price3_18
                'Delete Price3_18
                'MsgBox("Delete Price3_18")
                DELETE_PRICE3_18(Hid_ID.Value, Req_Id.Text, Hub_Id.Text, lblTemp_AID.Text)
            End If
            'คำสั่งเมื่อ Delete เสร็จ
            'ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Appraisal deleted successfully');</script>")
            GridView1.DataBind()
        Catch
        End Try
    End Sub

    Protected Sub GridView2_RowDeleted(ByVal sender As Object, ByVal e As GridViewDeletedEventArgs)
        'Check if there is any exception while deleting 
        If e.Exception IsNot Nothing Then
            ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" & e.Exception.Message.ToString().Replace("'", "") & "');</script>")
            e.ExceptionHandled = True
        End If
    End Sub

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblAID.Text = Context.Items("AID")
        End If
        'hdfAID.Value = Context.Items("AID")
    End Sub

    Protected Sub btnConfirmReview_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        'Dim bt1 As Button = sender
        'Dim gv2 As New GridView()
        'gv2 = bt1.Parent.Parent.Parent.Parent.FindControl("GridView2")
        'For Each gdi As GridViewRow In gv2.Rows
        '    If gdi.RowType = DataControlRowType.DataRow Then
        '        Dim cb2 As CheckBox = gdi.Cells(0).FindControl("cb2")
        '        If cb2.Checked = True Then
        '            MsgBox(cb2.Checked)
        '        End If
        '    End If
        'Next
    End Sub
End Class
