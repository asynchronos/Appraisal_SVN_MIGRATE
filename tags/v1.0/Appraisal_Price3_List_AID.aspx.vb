Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Collections.Generic
Imports Appraisal_Manager

Partial Class Appraisal_Price3_List_AID
    Inherits System.Web.UI.Page
    Dim s As String = ""

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

    Private Function ChildDataSource(ByVal strAID As Integer, ByVal ReqId As Integer, ByVal strSort As String) As SqlDataSource
        Dim strQRY As String = ""
        Dim dsTemp As New SqlDataSource

        Dim conn As String = "server=172.19.54.2;Database=Appraisal;User ID=sa;Password=sa0123"
        dsTemp.ConnectionString = conn
        strQRY = "SELECT Id,Temp_AID, Req_Id, Cif, CIFNAME, Hub_Id, HUB_NAME, Temp_AID, CollType_ID, MysubColl_ID, SubCollType_Name, Address_No, Tumbon, Amphur, Province,PROV_NAME, AID" _
                 & " FROM View_Appraisal_Price3_Review WHERE AID = " & strAID & " AND Req_Id = " & ReqId & ""
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
            ClientScript.RegisterStartupScript([GetType](), "Expand", "<SCRIPT LANGUAGE='javascript'>expandcollapse('div" + DirectCast(e.Row.DataItem, DataRowView)("AID").ToString() + "','one');</script>")
        End If

        'Prepare the query for Child GridView by passing the Customer ID of the parent row 
        gv.DataSource = ChildDataSource(DirectCast(e.Row.DataItem, DataRowView)("AID"), DirectCast(e.Row.DataItem, DataRowView)("Req_Id"), strSort)
        'gv.DataSource = GET_PRICE3_DETAIL_LIST(DirectCast(e.Row.DataItem, DataRowView)("Temp_AID").ToString())
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

            If DirectCast(e.Row.DataItem, DataRowView)("AID").ToString() = String.Empty Then
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

    Protected Sub GridView2_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        Dim gvTemp As GridView = DirectCast(sender, GridView)
        Dim gvRow As GridViewRow
        Dim lblcollid As Label = DirectCast(gvTemp.Rows.Item(0).FindControl("lblcoll_id"), Label)
        Dim lblUserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        If e.CommandName = "ViewPicture" Then
            gvUniqueID = gvTemp.UniqueID
            Response.Redirect("View_Picture_Appraisal.aspx")
        ElseIf e.CommandName = "AddReview" Then
            'MsgBox("Add Review")
            For Each gvRow In gvTemp.Rows
                Dim chk1 As CheckBox = gvRow.FindControl("cb2")
                If chk1.Checked = True Then
                    Dim Req_Id As Label = gvRow.FindControl("lblReq_Id")
                    Dim Id As Label = gvRow.FindControl("lblID")
                    Dim Temp_AID As Label = gvRow.FindControl("lblTemp_AID")
                    Dim Hub_Id As Label = gvRow.FindControl("lblHub_Id")
                    Dim CollType_Id As Label = gvRow.FindControl("lblColltype")
                    Try
                        'ADD_PRICE3_MASTER_REVIEW()
                        ADD_PRICE3_REVIEW_ALL_TYPE(Id.Text, Req_Id.Text, Hub_Id.Text, Temp_AID.Text, CollType_Id.Text, lblUserid.Text)
                    Catch ex As Exception
                        s = "<script language=""javascript"">alert('บันทึกผิดพลาด');</script>"
                        Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", s)
                    End Try

                End If
            Next
        End If
    End Sub

    Protected Sub GridView2_SelectedIndexChanging(ByVal sender As Object, ByVal e As GridViewSelectEventArgs)
        'Dim str As String = ""
        Dim gvTemp As GridView = DirectCast(sender, GridView)
        Dim Req_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblReq_Id"), Label)
        Dim Hub_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblHub_Id"), Label)
        Dim lblTemp_AID As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblTemp_AID"), Label)
        Dim lblCollType_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblColltype"), Label)
        Dim ID As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblID"), Label)
        Dim lblColl_type As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblColltype"), Label)

        Context.Items("Req_Id") = Req_Id.Text
        Context.Items("Hub_Id") = Hub_Id.Text
        Context.Items("Temp_AID") = lblTemp_AID.Text
        Context.Items("ID") = ID.Text
        Context.Items("Coll_Type") = lblColl_type.Text
        Context.Items("SpecialAdd") = "เพิ่มกรณีปกติ"
        If lblColl_type.Text = 50 Then
            'Response.Redirect("Appraisal_Price3_Add_Colltype50.aspx?Req_id=" & Req_Id.Text & "&Hub_Id=" & Hub_Id.Text & "&Coll_Type=" & lblColl_type.Text & "&Temp_AID=" & lblTemp_AID.Text & "&ID=" & ID.Text)
            Server.Transfer("Appraisal_Price3_Add_Colltype50.aspx")
        ElseIf lblColl_type.Text = 70 Then
            'Response.Redirect("Appraisal_Price3_Add_Colltype70.aspx?Req_id=" & Req_Id.Text & "&Hub_Id=" & Hub_Id.Text & "&Coll_Type=" & lblColl_type.Text & "&Temp_AID=" & lblTemp_AID.Text & "&ID=" & Hid_ID.Value)
            Context.Items("Req_Id") = Req_Id.Text
            Context.Items("Hub_Id") = Hub_Id.Text
            Context.Items("Temp_AID") = lblTemp_AID.Text
            Context.Items("ID") = ID.Text
            Context.Items("Coll_Type") = lblColl_type.Text
            Server.Transfer("Appraisal_Price3_Add_Colltype70.aspx")
        ElseIf lblColl_type.Text = 15 Then

        ElseIf lblColl_type.Text = 18 Then
        End If

        'MsgBox("Select Index Changing")
    End Sub

#End Region

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

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim lblHub_Id As Label = TryCast(Me.Form.FindControl("lblHub_Id"), Label)
        hdfHub_ID.Value = lblHub_Id.Text
        hdfAppraisal_Method.Value = 2
    End Sub

    Protected Sub imgPrintPreview_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)

        Dim ImgBtAdd As ImageButton = DirectCast(sender, ImageButton)
        Dim Req_Id As Label = ImgBtAdd.Parent.FindControl("lblReq_Id")
        Dim Hub_Id As Label = ImgBtAdd.Parent.FindControl("lblHub_Id")
        Dim AID As Label = ImgBtAdd.Parent.FindControl("lblAID")
        Dim Cif As Label = ImgBtAdd.Parent.FindControl("lblCif")
        Context.Items("Req_Id") = Req_Id.Text
        Context.Items("Hub_Id") = Hub_Id.Text
        Context.Items("AID") = AID.Text
        Context.Items("Cif") = Cif.Text
        Server.Transfer("Appraisal_Price3_Form_Review.aspx")
    End Sub

    Protected Sub imgaddplus_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim ImgBtAdd As ImageButton = DirectCast(sender, ImageButton)
        Dim Req_Id As Label = ImgBtAdd.Parent.FindControl("lblReq_Id")
        Dim Hub_Id As Label = ImgBtAdd.Parent.FindControl("lblHub_Id")
        Dim lblAID As Label = ImgBtAdd.Parent.FindControl("lblAID")
        Dim lblCif As Label = ImgBtAdd.Parent.FindControl("lblCif")

        Context.Items("Req_Id") = Req_Id.Text
        Context.Items("Hub_Id") = Hub_Id.Text
        Context.Items("Cif") = lblCif.Text
        Context.Items("AID") = lblAID.Text
        'Context.Items("Aid") = "50"

        Server.Transfer("Appraisal_GetData_DWS.aspx")
        'Server.Transfer("Appraisal_CheckCollType_Add.aspx")

        'Dim str As String
        'str = "Appraisal_CheckCollType_Add.aspx?Req_Id=" & Req_Id.Text & "&Hub_Id=" & Hub_Id.Text & "&Aid=" & lblAID.Text & "&Cif=" & lblCif.Text
        's = "<script language=""javascript"">window.open('" + str + "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, copyhistory=no, directories=no, status=yes,height=250px,width=350px');</script>"
        'Page.ClientScript.RegisterStartupScript(Me.GetType, "จัดกลุ่ม", s)
    End Sub
End Class
