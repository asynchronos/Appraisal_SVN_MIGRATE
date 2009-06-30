Imports System.Data

Partial Class Appraisal_Assign_Job
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

    Private Function ChildDataSource(ByVal strReq_Id As Integer, ByVal strSort As String) As SqlDataSource
        Dim strQRY As String = ""
        Dim dsTemp As New SqlDataSource

        Dim conn As String = "server=172.19.54.2;Database=Appraisal;User ID=sa;Password=sa0123"
        dsTemp.ConnectionString = conn
        strQRY = "SELECT ID, Req_Id, Cif, CIFNAME, Hub_Id, HUB_NAME, Temp_AID, CollType_ID, MysubColl_ID, SubCollType_Name, Address_No, Tumbon, Amphur, Province,PROV_NAME FROM View_Appraisal_Price3_ListDetail WHERE Req_Id = " & strReq_Id & ""
        dsTemp.SelectCommand = strQRY
        Return dsTemp
    End Function

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim cph As ContentPlaceHolder = TryCast(Me.Form.FindControl("ContentPlaceHolder1"), ContentPlaceHolder) 'หา Control จาก Master Page ที่ control อยู่ใน  ContentPlaceHolder1
        Dim lblHub As Label = TryCast(Me.Form.FindControl("lblHub_Id"), Label)
        HdfHub_Id.Value = lblHub.Text
        'MsgBox(HdfHub_Id.Value)
        'Session("Hub_Id") = lblHub.Text
        Dim ReqId As Label = DirectCast(cph.FindControl("lblRequestID"), Label) 'Me.FindControl("lblRequestID")
    End Sub

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
        gv.DataSource = ChildDataSource(DirectCast(e.Row.DataItem, DataRowView)("Req_Id"), strSort)
        gv.DataBind()

    End Sub

    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBound
        lblMessage.Text = GridView1.Rows.Count
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

        If lblColl_type.Text = 50 Then
            'Response.Redirect("Appraisal_Price3_Add_Colltype50.aspx?Req_id=" & Req_Id.Text & "&Hub_Id=" & Hub_Id.Text & "&Coll_Type=" & lblColl_type.Text & "&Temp_AID=" & lblTemp_AID.Text & "&ID=" & Hid_ID.Value)
            Server.Transfer("Appraisal_Price2_Add_By_Colltype.aspx")
        ElseIf lblColl_type.Text = 70 Then
            'Response.Redirect("Appraisal_Price3_Add_Colltype70.aspx?Req_id=" & Req_Id.Text & "&Hub_Id=" & Hub_Id.Text & "&Coll_Type=" & lblColl_type.Text & "&Temp_AID=" & lblTemp_AID.Text & "&ID=" & Hid_ID.Value)
            Server.Transfer("Appraisal_Price2_Add_By_Colltype70_New.aspx")
        ElseIf lblColl_type.Text = 15 Then

        ElseIf lblColl_type.Text = 18 Then
            Server.Transfer("Appraisal_Price2_Add_By_Colltype18.aspx")
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
                'DELETE_PRICE3_50(Hid_ID.Value, Req_Id.Text, Hub_Id.Text, lblTemp_AID.Text)
            ElseIf lblColl_type.Text = 70 Then
                'Check Price3_70
                'Delete Price3_70
                'MsgBox("Delete Price3_70")
                'DELETE_PRICE3_70(Hid_ID.Value, Req_Id.Text, Hub_Id.Text, lblTemp_AID.Text)
            ElseIf lblColl_type.Text = 18 Then
                'Check Price3_18
                'Delete Price3_18
                'MsgBox("Delete Price3_18")
                'DELETE_PRICE3_18(Hid_ID.Value, Req_Id.Text, Hub_Id.Text, lblTemp_AID.Text)
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

    Protected Sub imgPrint2View_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        'ให้ราคา
        'MsgBox("รายละเอียดการให้ราคาหลักประกัน")

        Dim ImgEdit As ImageButton = DirectCast(sender, ImageButton)
        Dim Req_Id As Label = ImgEdit.Parent.FindControl("lblReq_id")
        Dim Hub_Id As Label = ImgEdit.Parent.FindControl("lblHub_Id")
        Dim Hub_Name As Label = ImgEdit.Parent.FindControl("lblHub_Name")
        Dim Cif As Label = ImgEdit.Parent.FindControl("lblCif")
        Dim CifName As Label = ImgEdit.Parent.FindControl("lblCifName")
        Dim Status_Id As HiddenField = ImgEdit.Parent.FindControl("hdfStatus_Id")
        Dim myScript As String
        If Status_Id.Value < 6 Then
            myScript = "<script language=""javascript"">alert('กำหนดราคายังไม่เรียบร้อย'); </script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "ผลการบันทึก", myScript)
        Else
            myScript = "<script>" + "window.open('Appraisal_AppraisalPrice2.aspx?Req_Id=" + Trim(Req_Id.Text) + "&Hub_Id=" + Trim(Hub_Id.Text) + "&Hub_Name=" + Trim(Hub_Name.Text) + "&Cif=" + Trim(Cif.Text) + "&Cif_Name=" + Trim(CifName.Text) + "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, directories=no, status=yes,height=500px,width=800px');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "กำหนดงานให้เจ้าหน้าที่ประเมิน", myScript)
            'myScript = "<script>" + "window.open('Appraisal_Assign_Update_Job.aspx?Req_Id=" + Trim(Req_Id.Text) + "&Hub_Id=" + Trim(Hub_Id.Text) + "&Status_Id=" + Trim(Status_Id.Value) + "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, directories=no, status=yes,height=350px,width=450px');</script>"
            'Page.ClientScript.RegisterStartupScript(Me.GetType, "กำหนดงานให้เจ้าหน้าที่ประเมิน", myScript)
        End If

    End Sub

    Protected Sub imgEdit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim myScript As String
        Dim ImgEdit As ImageButton = DirectCast(sender, ImageButton)
        Dim Req_Id As Label = ImgEdit.Parent.FindControl("lblReq_id")
        Dim Hub_Id As Label = ImgEdit.Parent.FindControl("lblHub_id")
        Dim Status_Id As HiddenField = ImgEdit.Parent.FindControl("hdfStatus_Id")
        'MsgBox(Req_Id.Text)
        'If Status_Id.Value < 6 Then
        '    myScript = "<script language=""javascript"">alert('กำหนดราคายังไม่เรียบร้อย'); </script>"
        '    Page.ClientScript.RegisterStartupScript(Me.GetType, "ผลการบันทึก", myScript)
        'Else
        myScript = "<script>" + "window.open('Appraisal_Assign_Update_Job.aspx?Req_Id=" + Trim(Req_Id.Text) + "&Hub_Id=" + Trim(Hub_Id.Text) + "&Status_Id=" + Trim(Status_Id.Value) + "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, directories=no, status=yes,height=350px,width=450px');</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType, "กำหนดงานให้เจ้าหน้าที่ประเมิน", myScript)
        'End If

    End Sub

End Class
