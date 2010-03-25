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

        Dim conn As String = ConfigurationManager.ConnectionStrings.Item("AppraisalConn").ToString  '"server=172.19.54.2;Database=Appraisal;User ID=sa;Password=sa0123"
        dsTemp.ConnectionString = conn
        strQRY = "SELECT Id,Temp_AID,Req_Id, Cif, CIFNAME, Hub_Id, HUB_NAME, CollType_ID, MysubColl_ID, SubCollType_Name, Address_No, Tumbon, Amphur, Province,PROV_NAME, AID" _
                 & " FROM View_Appraisal_Price3_Review WHERE AID = " & strAID & " AND Req_Id = " & ReqId & ""
        dsTemp.SelectCommand = strQRY
        Return dsTemp
    End Function

#Region "GridView1 Event Handlers"

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        Dim dv As DataView
        Dim row As GridViewRow = e.Row
        Dim strSort As String = String.Empty
        Dim hdf_taid As HiddenField = e.Row.FindControl("hdf_taid")
        Dim hdfCollType As HiddenField = e.Row.FindControl("hdfCollType")
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

        If DirectCast(e.Row.DataItem, DataRowView)("AID").ToString <> String.Empty Then
            'Prepare the query for Child GridView by passing the Customer ID of the parent row 

            gv.DataSource = ChildDataSource(DirectCast(e.Row.DataItem, DataRowView)("AID"), DirectCast(e.Row.DataItem, DataRowView)("Req_Id"), strSort)
            'หาค่าที่อยู่ใน ChildGrid
            dv = CType(gv.DataSource.Select(DataSourceSelectArguments.Empty), Data.DataView)
            If dv.Count > 0 Then
                hdf_taid.Value = dv.Table.Rows(0)(1)
                hdfCollType.Value = dv.Table.Rows(0)(7)
                gv.DataBind()
            End If

        Else
            s = "<script language=""javascript"">alert('ไม่มีรายการให้ทบทวนราคาประเมิน');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
        End If


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
            hdfTemp_AID.Value = DirectCast(e.Row.DataItem, DataRowView)("Temp_AID")
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
        'Dim gvRow As GridViewRow
        Dim lblcollid As Label = DirectCast(gvTemp.Rows.Item(0).FindControl("lblcoll_id"), Label)
        Dim lblUserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        If e.CommandName = "ViewPicture" Then
            gvUniqueID = gvTemp.UniqueID
            Response.Redirect("View_Picture_Appraisal.aspx")
        ElseIf e.CommandName = "AddReview" Then
            'If gvTemp.Rows.Item(0).RowType = DataControlRowType.Footer Then
            '    gvRow = gvTemp.FooterRow
            '    Dim ddl As DropDownList = gvRow.FindControl("DropDownListCollType")
            '    MsgBox(ddl.SelectedValue)
            'End If
            Dim ddl As DropDownList = gvTemp.FooterRow.FindControl("DropDownListCollType")
            'MsgBox(ddl.SelectedValue)
            Dim Req_Id As Label = gvTemp.Rows.Item(0).FindControl("lblReq_Id")
            Dim Id As Label = gvTemp.Rows.Item(0).FindControl("lblID")
            Dim AID As Label = gvTemp.Rows.Item(0).Parent.Parent.Parent.Parent.FindControl("lblAID")
            'Dim AID As Label = gvTemp.Rows.Item(0).FindControl("lblAID")
            Dim Temp_AID As Label = gvTemp.Rows.Item(0).FindControl("lblTemp_AID")
            Dim Hub_Id As Label = gvTemp.Rows.Item(0).FindControl("lblHub_Id")
            '        Dim CollType_Id As Label = gvRow.FindControl("lblColltype")

            Context.Items("ID") = "0" 'Id.Text
            Context.Items("Req_Id") = Req_Id.Text
            Context.Items("Hub_Id") = Hub_Id.Text
            Context.Items("AID") = AID.Text
            Context.Items("CID") = "0"
            Context.Items("Temp_AID") = Temp_AID.Text
            Context.Items("Coll_Type") = "70"
            Select Case ddl.SelectedValue
                Case 50
                    Server.Transfer("Appraisal_Price3_50_Review_Edit.aspx")
                Case 70
                    Server.Transfer("Appraisal_Price3_70_Review_Edit.aspx")
                Case 18
                    Server.Transfer("Appraisal_Price3_18_Review_Edit.aspx")
            End Select
        End If
    End Sub

    Protected Sub GridView2_SelectedIndexChanging(ByVal sender As Object, ByVal e As GridViewSelectEventArgs)
        'Dim str As String = ""
        Dim gvTemp As GridView = DirectCast(sender, GridView)
        Dim Req_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblReq_Id"), Label)
        Dim Hub_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblHub_Id"), Label)
        Dim lblTemp_AID As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblTemp_AID"), Label)
        Dim Cif As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblCif"), Label)
        Dim lblCollType_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblColltype"), Label)
        Dim ID As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblID"), Label)
        Dim lblColl_type As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblColltype"), Label)


        Context.Items("Req_Id") = Req_Id.Text
        Context.Items("Hub_Id") = Hub_Id.Text
        Context.Items("Temp_AID") = lblTemp_AID.Text
        Context.Items("Cif") = Cif.Text
        Context.Items("ID") = ID.Text
        Context.Items("Coll_Type") = lblColl_type.Text
        Context.Items("SpecialAdd") = "เพิ่มกรณีปกติ"

        If Check_Appraisal_Id(Req_Id.Text) = True Then
            If lblColl_type.Text = 50 Then
                'Response.Redirect("Appraisal_Price3_Add_Colltype50.aspx?Req_id=" & Req_Id.Text & "&Hub_Id=" & Hub_Id.Text & "&Coll_Type=" & lblColl_type.Text & "&Temp_AID=" & lblTemp_AID.Text & "&ID=" & ID.Text)
                'Server.Transfer("Appraisal_Price3_Add_Colltype50.aspx")
                Server.Transfer("Appraisal_Price3_50_Review_Edit.aspx")
            ElseIf lblColl_type.Text = 70 Then
                'Response.Redirect("Appraisal_Price3_Add_Colltype70.aspx?Req_id=" & Req_Id.Text & "&Hub_Id=" & Hub_Id.Text & "&Coll_Type=" & lblColl_type.Text & "&Temp_AID=" & lblTemp_AID.Text & "&ID=" & Hid_ID.Value)
                'Context.Items("Req_Id") = Req_Id.Text
                'Context.Items("Hub_Id") = Hub_Id.Text
                'Context.Items("Temp_AID") = lblTemp_AID.Text
                'Context.Items("ID") = ID.Text
                'Context.Items("Coll_Type") = lblColl_type.Text
                'Server.Transfer("Appraisal_Price3_Add_Colltype70.aspx")

                Server.Transfer("Appraisal_Price3_70_Review_Edit.aspx")
            ElseIf lblColl_type.Text = 15 Then

            ElseIf lblColl_type.Text = 18 Then
                Context.Items("Req_Id") = Req_Id.Text
                Context.Items("Hub_Id") = Hub_Id.Text
                Context.Items("Temp_AID") = lblTemp_AID.Text
                Context.Items("ID") = ID.Text
                Context.Items("Coll_Type") = lblColl_type.Text
                Server.Transfer("Appraisal_Price3_18.aspx")
            End If
        Else
            s = "<script language=""javascript"">alert('ยังไม่ได้กำหนดผู้ประเมินราคา');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
        End If
        'MsgBox("Select Index Changing")
    End Sub

    'Protected Sub GridView2_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs)
    '    If e.Exception IsNot Nothing Then
    '        ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" & e.Exception.Message.ToString().Replace("'", "") & "');</script>")
    '        e.ExceptionHandled = True
    '    Else
    '        MsgBox("Not Deleted")
    '    End If
    'End Sub

    'Protected Sub GridView2_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs)

    'End Sub

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
        Dim Appraisal_Id As Label = ImgBtAdd.Parent.FindControl("lblAppraisal_Id")
        Dim hdf_taid As HiddenField = ImgBtAdd.Parent.FindControl("hdf_taid")
        Dim hdfCollType As HiddenField = ImgBtAdd.Parent.FindControl("hdfCollType")
        Dim HiddenFieldStatus_ID As HiddenField = ImgBtAdd.Parent.FindControl("HiddenFieldStatus_ID")
        'MsgBox(hdf_taid.Value)
        Context.Items("Req_Id") = Req_Id.Text
        Context.Items("Hub_Id") = Hub_Id.Text
        Context.Items("AID") = AID.Text
        Context.Items("Cif") = Cif.Text
        Context.Items("Appraisal_Id") = Appraisal_Id.Text
        Context.Items("Temp_AID") = hdf_taid.Value
        Context.Items("CollType") = hdfCollType.Value

        'If HiddenFieldStatus_ID.Value > 3 Then
        '    If Check_Appraisal_Id(Req_Id.Text) = True Then
        '        Server.Transfer("Appraisal_Price3_Form_Review.aspx")
        '    Else
        '        s = "<script language=""javascript"">alert('ยังไม่ได้กำหนดผู้ประเมินราคา');</script>"
        '        Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
        '    End If
        'Else
        '    s = "<script language=""javascript"">alert('ไม่มีเจ้าหน้าที่ประเมิน กรุณากำหนดผู้ประเมินก่อน!!!');</script>"
        '    Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
        'End If

        If HiddenFieldStatus_ID.Value < 3 Then
            s = "<script language=""javascript"">alert('ไม่มีเจ้าหน้าที่ประเมิน กรุณากำหนดผู้ประเมินก่อน!!!');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
        ElseIf HiddenFieldStatus_ID.Value = 3 Then
            s = "<script language=""javascript"">alert('ยังไม่มีชิ้นทรัพย์ ที่จะทบทวน กรุณาเพิ่มชิ้นทรัพย์ก่อน !!!');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
            'ElseIf HiddenFieldStatus_ID.Value > 3 And HiddenFieldStatus_ID.Value <= 10 Then
            '    s = "<script language=""javascript"">alert('อยู่ระหว่างให้รายละเอียดราคาที่ 3 !!!');</script>"
            '    Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
        ElseIf HiddenFieldStatus_ID.Value >= 10 Then
            Server.Transfer("Appraisal_Price3_Form_Review.aspx")
        End If

    End Sub

    Protected Sub imgaddplus_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim ImgBtAdd As ImageButton = DirectCast(sender, ImageButton)
        Dim Req_Id As Label = ImgBtAdd.Parent.FindControl("lblReq_Id")
        Dim Hub_Id As Label = ImgBtAdd.Parent.FindControl("lblHub_Id")
        Dim lblAID As Label = ImgBtAdd.Parent.FindControl("lblAID")
        Dim lblCif As Label = ImgBtAdd.Parent.FindControl("lblCif")
        Dim HiddenFieldStatus_ID As HiddenField = ImgBtAdd.Parent.FindControl("HiddenFieldStatus_ID")
        Context.Items("Req_Id") = Req_Id.Text
        Context.Items("Hub_Id") = Hub_Id.Text
        Context.Items("Cif") = lblCif.Text
        Context.Items("AID") = lblAID.Text
        'Context.Items("Aid") = "50"
        If HiddenFieldStatus_ID.Value >= 3 Then
            Server.Transfer("Appraisal_GetData_DWS.aspx")
        Else
            s = "<script language=""javascript"">alert('ไม่มีเจ้าหน้าที่ประเมิน กรุณากำหนดผู้ประเมินก่อน!!!');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
        End If


    End Sub

    Protected Sub imgaddplusNew_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim ImgBtAdd As ImageButton = DirectCast(sender, ImageButton)
        Dim Req_Id As Label = ImgBtAdd.Parent.FindControl("lblReq_Id")
        Dim Hub_Id As Label = ImgBtAdd.Parent.FindControl("lblHub_Id")
        Dim lblAID As Label = ImgBtAdd.Parent.FindControl("lblAID")
        Dim lblCif As Label = ImgBtAdd.Parent.FindControl("lblCif")
        Dim HiddenFieldStatus_ID As HiddenField = ImgBtAdd.Parent.FindControl("HiddenFieldStatus_ID")
        Context.Items("Req_Id") = Req_Id.Text
        Context.Items("Hub_Id") = Hub_Id.Text
        Context.Items("Cif") = lblCif.Text
        Context.Items("AID") = lblAID.Text
        'Context.Items("Aid") = "50"
        If HiddenFieldStatus_ID.Value >= 3 Then
            Server.Transfer("Appraisal_Price3_50_Review_Edit.aspx")
        Else
            s = "<script language=""javascript"">alert('ไม่มีเจ้าหน้าที่ประเมิน กรุณากำหนดผู้ประเมินก่อน!!!');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
        End If


    End Sub

    Protected Sub ImageDelete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim ImgBtDelete As ImageButton = DirectCast(sender, ImageButton)
        'ImgBtDelete.Attributes.Add("onClick", "aa")
        Dim Req_Id As Label = ImgBtDelete.Parent.FindControl("lblReq_Id")
        Dim Hub_Id As Label = ImgBtDelete.Parent.FindControl("lblHub_Id")
        Dim ID As Label = ImgBtDelete.Parent.FindControl("lblID")
        Dim TempAID As Label = ImgBtDelete.Parent.FindControl("lblTemp_AID")
        Dim CollType As Label = ImgBtDelete.Parent.FindControl("lblColltype")
        'MsgBox(Req_Id.Text)
        'MsgBox(Hub_Id.Text)
        'MsgBox(ID.Text)
        'MsgBox(CollType.Text)

        'CreateMessageAlert(Me, "Do you want to Delete data? ", "strKey1")
        'CreateConfirmBox(sender, "Do you want to Delete data? ")
        Select Case CollType.Text
            Case "18"
                DELETE_PRICE3_18(ID.Text, Req_Id.Text, Hub_Id.Text, TempAID.Text)
            Case "50"
                DELETE_PRICE3_50(ID.Text, Req_Id.Text, Hub_Id.Text, TempAID.Text)
            Case "70"
                'ใช้สำหรับการลบหลักประกันที่เป็นสิ่งปลูกสร้าง รวมทั้งส่วนควบ และรายละเอียดของสิ่งปลูกสร้าง
                DELETE_PRICE3_70_REVIEW(ID.Text, Req_Id.Text, Hub_Id.Text, TempAID.Text)
        End Select
        GridView1.DataBind()
        s = "<script language=""javascript"">alert('ลบข้อมูลเสร็จสมบูรณ์!!!');</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือนการลบ", s)
    End Sub

    Private Function Check_Appraisal_Id(ByVal ReqId As Integer) As Boolean
        Dim Appraisal_Req As List(Of Appraisal_Request) = GET_APPRAISAL_REQUEST(ReqId)
        If Appraisal_Req.Item(0).Appraisal_Id = String.Empty Or Appraisal_Req.Item(0).Appraisal_Id = String.Empty Then
            Return False
        Else
            Return True

        End If
    End Function



End Class
