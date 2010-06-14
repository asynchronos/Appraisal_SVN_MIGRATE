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

Partial Class Appraisal_Price3_List
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

    Private Function ChildDataSource(ByVal strTemp_AID As Integer, ByVal strSort As String) As SqlDataSource
        Dim strQRY As String = ""
        Dim dsTemp As New SqlDataSource

        'Dim conn As String = "server=172.19.54.2;Database=Appraisal;User ID=sa;Password=sa0123"
        Dim conn As String = ConfigurationManager.ConnectionStrings.Item("AppraisalConn").ToString '"server=172.19.54.2;Database=Appraisal_Test;User ID=sa;Password=sa0123"
        dsTemp.ConnectionString = conn
        strQRY = "SELECT ID, Req_Id, Cif, CIFNAME, Hub_Id, HUB_NAME, Temp_AID, CollType_ID, MysubColl_ID, SubCollType_Name, Address_No, Tumbon, Amphur, Province,PROV_NAME FROM View_Appraisal_Price3_ListDetail WHERE Temp_AID = " & strTemp_AID & ""
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
            ClientScript.RegisterStartupScript([GetType](), "Expand", "<SCRIPT LANGUAGE='javascript'>expandcollapse('div" + DirectCast(e.Row.DataItem, DataRowView)("Temp_AID").ToString() + "','one');</script>")
        End If

        'Prepare the query for Child GridView by passing the Customer ID of the parent row 
        gv.DataSource = ChildDataSource(DirectCast(e.Row.DataItem, DataRowView)("Temp_AID"), strSort)
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
        Context.Items("ID") = Hid_ID.Value
        Context.Items("Coll_Type") = lblColl_type.Text
        Context.Items("SpecialAdd") = "เพิ่มกรณีปกติ"

        Dim Obj_Price2 As List(Of Appraisal_Request) = GET_APPRAISAL_REQUEST(Req_Id.Text)
        If Obj_Price2.Item(0).Status_ID < 8 Then
            s = "<script language=""javascript"">alert('หัวหน้ายังไม่ยืนยันการกำหนดราคาที่ 2');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
        Else
            If lblColl_type.Text = 50 Then
                'Response.Redirect("Appraisal_Price3_Add_Colltype50.aspx?Req_id=" & Req_Id.Text & "&Hub_Id=" & Hub_Id.Text & "&Coll_Type=" & lblColl_type.Text & "&Temp_AID=" & lblTemp_AID.Text & "&ID=" & Hid_ID.Value)
                Server.Transfer("Appraisal_Price3_Add_Colltype50.aspx")
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

    Protected Sub imgPrintPreview_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim ImgBtAdd As ImageButton = DirectCast(sender, ImageButton)
        Dim Req_Id As Label = ImgBtAdd.Parent.FindControl("lblReq_Id")
        Dim Hub_Id As Label = ImgBtAdd.Parent.FindControl("lblHub_Id")
        Dim Temp_AID As Label = ImgBtAdd.Parent.FindControl("lblTemp_AID")
        Dim MethodNo As Label = ImgBtAdd.Parent.FindControl("lblMethodNo")
        Dim Appraisal_Id As Label = ImgBtAdd.Parent.FindControl("lblAppraisal_Id")
        Dim Cif As Label = ImgBtAdd.Parent.FindControl("lblCif")


        Context.Items("Req_Id") = Req_Id.Text
        Context.Items("Hub_Id") = Hub_Id.Text
        Context.Items("Temp_AID") = Temp_AID.Text
        Context.Items("Cif") = Cif.Text
        Context.Items("Appraisal_Id") = Appraisal_Id.Text

        Dim ChkColl As Integer = 0
        Dim P2Master As List(Of Price2_Master) = GET_PRICE2_MASTER(Req_Id.Text, Hub_Id.Text)
        If P2Master.Item(0).Approve2_Id = String.Empty Then
            s = "<script language=""javascript"">alert('หัวหน้ายังไม่ยืนยันการกำหนดราคาที่ 2');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
        Else
            Dim Obj_GetP18 As List(Of Price3_18) = GET_PRICE3_18(Req_Id.Text, Hub_Id.Text, Temp_AID.Text)
            If Obj_GetP18.Count > 0 Then
                ChkColl = 18
            Else
                Dim Obj_GetP50 As List(Of Price3_50) = GET_PRICE3_CONFORM(Req_Id.Text, Hub_Id.Text, Temp_AID.Text)
                If Obj_GetP50.Count > 0 Then
                    ChkColl = 50
                Else
                    ChkColl = 0
                    s = "<script language=""javascript"">alert('คุณยังไม่ได้กำหนดรายละเอียดในที่ดิน');</script>"
                    Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
                End If
                'มีทรัพย์หลักประกันเป็นที่ดิน หาว่ามีสิ่งปลูกสร้างหรือไม่
                If ChkColl = 50 Then
                    Dim P2_70G As List(Of Price2_70_New) = GET_PRICE2_70_NEW_BY_REQID_HUBID(Req_Id.Text, Hub_Id.Text, Temp_AID.Text)
                    If P2_70G.Count > 0 Then  ' มีสิ่งปลูกสร้างในราคาที่ 2
                        'Dim Obj_GetP70G As DataSet = GET_PRICE3_70_GROUP(Req_Id.Text, Hub_Id.Text, Temp_AID.Text)
                        Dim Cnt As Integer = GET_BUILDING_ITEMS_PRICE3(Req_Id.Text, Hub_Id.Text)
                        'MsgBox(Obj_GetP70G.Tables(0).Rows.Count)
                        If P2_70G.Count = Cnt Then ' มีสิ่งปลูกสร้างในราคาที่ 2 เท่ากับ ปลูกสร้างในราคาที่ 3
                            ChkColl = 70
                        Else ' มีสิ่งปลูกสร้างในราคาที่ 2 ไม่เท่ากับ ปลูกสร้างในราคาที่ 3
                            s = "<script language=""javascript"">alert('รายละเอียดในที่สิ่งปลูกสร้างในราคาที่ 3 ยังไม่สมบูรณ์');</script>"
                            Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
                            Exit Sub
                        End If
                    Else 'ไม่มีสิ่งปลูกสร้างในราคาที่ 2
                        ChkColl = 50
                    End If
                End If
            End If

            Context.Items("ChkColl") = ChkColl
            If ChkColl = 0 Then
                s = "<script language=""javascript"">alert('คุณไม่มีชิ้นทรัพย์ในการประเมิน');</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
            ElseIf ChkColl = 18 Then
                If MethodNo.Text = "1" Then
                    Server.Transfer("Appraisal_Price3_Conform_New.aspx")
                ElseIf MethodNo.Text = "2" Then
                    Server.Transfer("Appraisal_Price3_Form_Review.aspx")
                End If
            ElseIf ChkColl = 50 Then
                If MethodNo.Text = "1" Then
                    Server.Transfer("Appraisal_Price3_Conform_New.aspx")
                ElseIf MethodNo.Text = "2" Then
                    Server.Transfer("Appraisal_Price3_Form_Review.aspx")
                End If
            ElseIf ChkColl = 70 Then
                If MethodNo.Text = "1" Then
                    Server.Transfer("Appraisal_Price3_Conform_New.aspx")
                ElseIf MethodNo.Text = "2" Then
                    Server.Transfer("Appraisal_Price3_Form_Review.aspx")
                End If
            Else
            End If
        End If
    End Sub

    Protected Sub imgAddColl_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim ImgBtAdd As ImageButton = DirectCast(sender, ImageButton)
        Dim Temp_AID As Label = ImgBtAdd.Parent.FindControl("lblTemp_AID")
        Dim Appraisal_Id As Label = ImgBtAdd.Parent.FindControl("lblAppraisal_Id")
        Context.Items("Temp_AID") = Temp_AID.Text
        Context.Items("Appraisal_Id") = Appraisal_Id.Text
        Server.Transfer("Appraisal_Price2_Group.aspx")
    End Sub

    Protected Sub imgaddplus_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim ImgBtAdd As ImageButton = DirectCast(sender, ImageButton)
        Dim Req_Id As Label = ImgBtAdd.Parent.FindControl("lblReq_Id")
        Dim Hub_Id As Label = ImgBtAdd.Parent.FindControl("lblHub_Id")
        Dim lblTemp_AID As Label = ImgBtAdd.Parent.FindControl("lblTemp_AID")
        Dim lblCollType_Id As Label = ImgBtAdd.Parent.FindControl("lblColltype")
        Dim lblUser_Id As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)

        'Context.Items("Req_Id") = Req_Id
        'Context.Items("Hub_Id") = Hub_Id
        'Context.Items("Temp_AID") = lblTemp_AID
        'Context.Items("CollType_Id") = lblCollType_Id
        Dim str As String
        'str = "Server.Transfer" & ("FileUpload_Price2.aspx")

        str = "FileUpload_Price2.aspx?Req_Id=" & Req_Id.Text & "&Hub_Id=" & Hub_Id.Text & "&User_Id=" & lblUser_Id.Text
        s = "<script language=""javascript"">window.open('" + str + "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, copyhistory=no, directories=no, status=yes,height=350px,width=550px');</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType, "จัดกลุ่ม", s)

        'Server.Transfer("FileUpload_Price2.aspx")

        'MsgBox("Add Data " & lblTemp_AID.Text)
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim lblHub_Id As Label = TryCast(Me.Form.FindControl("lblHub_Id"), Label)
        hhfHub_Id.Value = lblHub_Id.Text
    End Sub

    Protected Sub imgPrint2View_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim imgPrint2View As ImageButton = DirectCast(sender, ImageButton)
        Dim Req_Id As Label = imgPrint2View.Parent.FindControl("lblReq_Id")
        Dim Hub_Id As Label = imgPrint2View.Parent.FindControl("lblHub_Id")
        Dim lblTemp_AID As Label = imgPrint2View.Parent.FindControl("lblTemp_AID")
        Context.Items("Req_Id") = Req_Id.Text
        Context.Items("Hub_Id") = Hub_Id.Text
        Context.Items("Temp_AID") = lblTemp_AID
        Server.Transfer("Price2_PrintPreview.aspx")
    End Sub

End Class
