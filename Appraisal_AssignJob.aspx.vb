Imports Appraisal_Manager
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Imports System.Web.UI
Imports System.Web.Services
Imports System.Collections

Partial Class Appraisal_AssignJob
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

    Private Function ChildDataSource(ByVal strReq_Id As Integer, ByVal ReqType As Integer, ByVal strSort As String) As SqlDataSource
        Dim strQRY As String = ""
        Dim dsTemp As New SqlDataSource

        Dim conn As String = ConfigurationManager.ConnectionStrings.Item("AppraisalConn").ToString
        dsTemp.ConnectionString = conn
        'If reqType = "1" Then
        strQRY = "SELECT ID, Req_Id, Cif, CIFNAME, Hub_Id, HUB_NAME, Temp_AID, CollType_ID, MysubColl_ID, SubCollType_Name, Address_No, Tumbon, Amphur, Province,PROV_NAME FROM View_Appraisal_Price3_ListDetail WHERE Req_Id = " & strReq_Id & ""
        'Else
        'strQRY = "SELECT ID, Req_Id, Cif, CIFNAME, Hub_Id, HUB_NAME, Temp_AID, CollType_ID, MysubColl_ID, SubCollType_Name, Address_No, Tumbon, Amphur, Province,PROV_NAME FROM View_Appraisal_Price3_ReviewNew WHERE Req_Id = " & strReq_Id & ""
        'End If
        dsTemp.SelectCommand = strQRY
        Return dsTemp
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim cph As ContentPlaceHolder = TryCast(Me.Form.FindControl("ContentPlaceHolder1"), ContentPlaceHolder) 'หา Control จาก Master Page ที่ control อยู่ใน  ContentPlaceHolder1
        If Not Page.IsPostBack Then
            Dim ReqId As Label = DirectCast(cph.FindControl("lblRequestID"), Label) 'Me.FindControl("lblRequestID")
            Dim lblHub As Label = TryCast(Me.Form.FindControl("lblHub_Id"), Label)
            HdfHub_Id.Value = lblHub.Text
        End If


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
        gv.DataSource = ChildDataSource(DirectCast(e.Row.DataItem, DataRowView)("Req_Id"), DirectCast(e.Row.DataItem, DataRowView)("Req_Type"), strSort)
        gv.DataBind()
    End Sub

    'Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
    'Dim gvTemp As GridView = DirectCast(sender, GridView)
    'Dim Req_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblReq_Id"), Label)
    'Dim Status_Id As HiddenField = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("HiddenStatus_Id"), HiddenField)
    'Dim Hub_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblHub_id"), Label)


    'up1.Update()
    'txtReqId.Text = Req_Id.Text
    'mdlPopup.Show()
    'End Sub

#End Region

    Protected Sub btnSaveAssignJob_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim btnEdit As ImageButton = TryCast(sender, ImageButton)
        'Dim row As GridViewRow = DirectCast(btnEdit.NamingContainer, GridViewRow)

        Dim Req_Id As Label = btnEdit.Parent.FindControl("lblReq_id")
        Dim Hub_Id As Label = btnEdit.Parent.FindControl("lblHub_Id")
        Dim Cusname As Label = btnEdit.Parent.FindControl("lblCifName")
        Dim SenderName As Label = btnEdit.Parent.FindControl("LabelEmp_Name")
        Dim DateSent As Label = btnEdit.Parent.FindControl("LabelCreate_Date")
        Dim StatusId As HiddenField = btnEdit.Parent.FindControl("hdfStatus_Id")
        Dim lblReq_Type As Label = btnEdit.Parent.FindControl("lblReq_Type")
        Dim request As List(Of Appraisal_Request_v2) = GET_APPRAISAL_REQUEST_V2(Req_Id.Text)
        ddlAppraisal2.SelectedValue = 0
        btnSaveAssignJob.Enabled = True
        txtReqId.Text = Req_Id.Text
        txtMiddleName.Text = Cusname.Text
        txtSenderName.Text = SenderName.Text
        lblSent_Date.Text = DateSent.Text

        'MsgBox(StatusId.Value)
        'If CInt(StatusId.Value) = 6 Then
        '    'HdfStatus.Value = 6
        '    If request.Item(0).Appraisal_Id = 0 Then
        '        ddlAppraisal2.SelectedValue = request.Item(0).Appraisal_Id
        '        UPDATE_APPRAISAL_ID(Req_Id.Text, Hub_Id.Text, ddlStatus.SelectedValue, ddlAppraisal2.SelectedValue)
        '    Else

        '        ddlAppraisal2.SelectedValue = request.Item(0).Appraisal_Id
        '        UPDATE_APPRAISAL_ID(Req_Id.Text, Hub_Id.Text, ddlStatus.SelectedValue, ddlAppraisal2.SelectedValue)
        '    End If

        '    up1.Update()
        '    GridView1.DataBind()
        '    mdlPopup.Show()
        'ElseIf CInt(StatusId.Value) >= 97 Then
        '    UPDATE_APPRAISAL_ID(Req_Id.Text, Hub_Id.Text, ddlStatus.SelectedValue, ddlAppraisal2.SelectedValue)
        '    GridView1.DataBind()
        '    mdlPopup.Hide()
        'Else

        If lblReq_Type.Text = 1 Then  'วิธีส่งประเมินใหม่
            Dim ChkDoc As DataSet = GET_APPRAISAL_REQUEST_PICTURE_PATH(Req_Id.Text, HdfHub_Id.Value)
            'ตรวจสอบเอกสารที่แนบว่ามีหรือไม่

            If ChkDoc.Tables(0).Rows(0).Item("Req_Form") = 0 Or ChkDoc.Tables(0).Rows(0).Item("Map") = 0 Or ChkDoc.Tables(0).Rows(0).Item("Chanode") = 0 Then
                If ChkDoc.Tables(0).Rows(0).Item("Req_Form") <> 0 Then
                    txtAppraisalForm.Text = "แนบไฟล์แล้ว"
                Else
                    txtAppraisalForm.Text = "ยังไม่ได้แนบไฟล์"
                End If
                If ChkDoc.Tables(0).Rows(0).Item("Map") <> 0 Then
                    txtPicMap.Text = "แนบไฟล์แล้ว"
                Else
                    txtPicMap.Text = "ยังไม่ได้แนบไฟล์"
                End If
                If ChkDoc.Tables(0).Rows(0).Item("Chanode") <> 0 Then
                    txtPicChanode.Text = "แนบไฟล์แล้ว"
                Else
                    txtPicChanode.Text = "ยังไม่ได้แนบไฟล์"
                End If
                mpeAttachFile.Show()
            Else
                If ChkDoc.Tables(0).Rows.Count > 0 Then
                    mdlPopup.Show()
                    If request.Item(0).Appraisal_Id = 0 Then
                        'If ddlAppraisal2.SelectedValue = 0 Then
                        'Else
                        '    UPDATE_APPRAISAL_ID(Req_Id.Text, Hub_Id.Text, ddlStatus.SelectedValue, ddlAppraisal2.SelectedValue)
                        '    'up1.Update()
                        '    GridView1.DataBind()
                        'End If

                    Else
                        'UPDATE_APPRAISAL_ID(Req_Id.Text, Hub_Id.Text, ddlStatus.SelectedValue, ddlAppraisal2.SelectedValue)
                        ddlAppraisal2.SelectedValue = request.Item(0).Appraisal_Id
                        'up1.Update()
                        'GridView1.DataBind()
                    End If
                End If
            End If
        Else
            'วิธีทบทวนประเมิน
            If CInt(StatusId.Value) >= 3 Then
                ddlAppraisal2.SelectedValue = request.Item(0).Appraisal_Id
                btnSaveAssignJob.Enabled = False
                mdlPopup.Show()
            Else
                ddlAppraisal2.SelectedValue = 0
                mdlPopup.Hide()
            End If

        End If
    End Sub

    <System.Web.Script.Services.ScriptMethod()> _
<System.Web.Services.WebMethod()> _
Public Shared Function SaveAssignJob(ByVal ReqId As String, ByVal HubId As String, ByVal Status As String, ByVal AppraisalId As String) As Boolean
        Dim isValid As Boolean = False
        Try
            UPDATE_APPRAISAL_ID(ReqId, HubId, Status, AppraisalId)
            isValid = True
        Catch ex As Exception
            isValid = False
        End Try
        Return isValid
    End Function

    Protected Sub imgConfirm_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btnEdit As ImageButton = TryCast(sender, ImageButton)
        Dim Req_Id As Label = btnEdit.Parent.FindControl("lblReq_id")
        Dim Hub_Id As Label = btnEdit.Parent.FindControl("lblHub_Id")
        Dim HubName As Label = btnEdit.Parent.FindControl("lblHub_Name")
        Dim Cif As Label = btnEdit.Parent.FindControl("lblCif")
        Dim Cusname As Label = btnEdit.Parent.FindControl("lblCifName")
        Dim SenderName As Label = btnEdit.Parent.FindControl("LabelEmp_Name")
        Dim lblReq_Type As Label = btnEdit.Parent.FindControl("lblReq_Type")
        Dim DateSent As Label = btnEdit.Parent.FindControl("LabelCreate_Date")
        Dim StatusId As HiddenField = btnEdit.Parent.FindControl("hdfStatus_Id")

        If lblReq_Type.Text = "1" Then
            Dim Obj_P2 As DataSet = GET_APPRAISAL_PRICE2(Req_Id.Text, Hub_Id.Text)
            If Obj_P2.Tables(0).Rows.Count > 0 Then
                lblPrice1.Text = String.Format("{0:N2}", Obj_P2.Tables(0).Rows(0).Item("Price1"))

                If Obj_P2.Tables(0).Rows(0).Item("Appraisal_Type") = 1 Then
                    'ตรวจสอบว่าราคาที่ให้ไว้ ณ ราคาที่ 2 นั้นเป็นหลักประกันชนิดอะไร และเป็นวิธีทุน หรือ ตลาด
                    Dim Check_Price_CollType As DataSet = GET_PRICE2_MASTER_NEW(Req_Id.Text, Hub_Id.Text)
                    If Check_Price_CollType.Tables(0).Rows(0).Item("Condo") > 0 Then
                        lblPrice2.Text = String.Format("{0:N2}", Obj_P2.Tables(0).Rows(0).Item("Price2"))
                    Else
                        lblPrice2.Text = String.Format("{0:N2}", Obj_P2.Tables(0).Rows(0).Item("PriceMarket"))
                    End If

                Else
                    lblPrice2.Text = String.Format("{0:N2}", Obj_P2.Tables(0).Rows(0).Item("Price2"))
                End If
                'ddlUserAppraisal.SelectedValue = Obj_P2.Tables(0).Rows(0).Item("Appraisal_Id")
                'ddlSender.SelectedValue = Obj_P2.Tables(0).Rows(0).Item("Sender_Id")
                lblReq_Id_Confirm.Text = Req_Id.Text
                lblHub_Id_Confirm.Text = Hub_Id.Text
                lblHub_Name_Confirm.Text = HubName.Text
                lblCif_Confirmm.Text = Cif.Text
                lblCifName_Confirm.Text = Cusname.Text
                lblSenderName_Confirm.Text = Obj_P2.Tables(0).Rows(0).Item("Sender_Name")
                lblAppraisal_Name_Confirm.Text = Obj_P2.Tables(0).Rows(0).Item("AppraisalName")
                txtComment.Text = Obj_P2.Tables(0).Rows(0).Item("Comment")
                txtNote_Confirm.Text = Obj_P2.Tables(0).Rows(0).Item("Note")
                'up1.Update()
                mdlconfirm.Show()
            Else
                'MsgBox("No Data")
            End If
        Else
            lblNotice.Text = "การทบทวนไม่มีการยืนยันราคาที่ 2"
            mdlNotice.Show()
        End If


    End Sub

    Protected Sub imgCollPic_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btnEdit As ImageButton = TryCast(sender, ImageButton)
        Dim Req_Id As Label = btnEdit.Parent.FindControl("lblReq_id")
        Dim Hub_Id As Label = btnEdit.Parent.FindControl("lblHub_Id")
        Dim HubName As Label = btnEdit.Parent.FindControl("lblHub_Name")
        Dim Cif As Label = btnEdit.Parent.FindControl("lblCif")
        Dim Cusname As Label = btnEdit.Parent.FindControl("lblCifName")
        Dim SenderName As Label = btnEdit.Parent.FindControl("LabelEmp_Name")
        Dim DateSent As Label = btnEdit.Parent.FindControl("LabelCreate_Date")
        Dim StatusId As HiddenField = btnEdit.Parent.FindControl("hdfStatus_Id")


        lblReq_Id_Picture.Text = Req_Id.Text

        If StatusId.Value <= 5 Then
            lblNotice.Text = "ขั้นตอนยังไม่ถึงไม่สามารถดูภาพหลักประกันได้"
            mdlNotice.Show()
        Else
            sdsPictureList.SelectParameters.Clear()
            sdsPictureList.SelectCommand = "GET_APPRAISAL_PRICE2_PICTUREPATH"
            sdsPictureList.SelectCommandType = SqlDataSourceCommandType.StoredProcedure
            sdsPictureList.SelectParameters.Add("Req_Id", lblReq_Id_Picture.Text)

            lvPhotos.DataSource = sdsPictureList


            lvPhotos.DataBind()
            'MsgBox(lvPhotos.Items.Count)
            If lvPhotos.Items.Count > 0 Then
                'up1.Update()
                mdlShowPicture.Show()
            Else
                lblNotice.Text = "ไม่มีรูปภาพหลักประกัน"
                mdlNotice.Show()
            End If
        End If
    End Sub

    Protected Sub imgCollPic_Price1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btnEdit As ImageButton = TryCast(sender, ImageButton)
        Dim Req_Id As Label = btnEdit.Parent.FindControl("lblReq_id")
        Dim Hub_Id As Label = btnEdit.Parent.FindControl("lblHub_Id")
        Dim HubName As Label = btnEdit.Parent.FindControl("lblHub_Name")
        Dim Cif As Label = btnEdit.Parent.FindControl("lblCif")
        Dim Cusname As Label = btnEdit.Parent.FindControl("lblCifName")
        Dim SenderName As Label = btnEdit.Parent.FindControl("LabelEmp_Name")
        Dim DateSent As Label = btnEdit.Parent.FindControl("LabelCreate_Date")
        Dim StatusId As HiddenField = btnEdit.Parent.FindControl("hdfStatus_Id")

        lblReq_Id_Picture.Text = Req_Id.Text

        If StatusId.Value <= 2 Then
            lblNotice.Text = "ขั้นตอนยังไม่ถึงไม่สามารถดูภาพหลักประกันได้"
            mdlNotice.Show()
        Else
            sdsPictureList_Price1.SelectParameters.Clear()
            sdsPictureList_Price1.SelectCommand = "GET_APPRAISAL_PRICE1_PICTUREPATH"
            sdsPictureList_Price1.SelectCommandType = SqlDataSourceCommandType.StoredProcedure
            sdsPictureList_Price1.SelectParameters.Add("Req_Id", lblReq_Id_Picture.Text)

            lvShowPicture_P1.DataSource = sdsPictureList_Price1
            lvShowPicture_P1.DataBind()
            If lvShowPicture_P1.Items.Count > 0 Then
                'up1.Update()
                mdlShowPicture_P1.Show()
            Else
                lblNotice.Text = "ไม่มีรูปภาพที่แนบมาพร้อมกับการขอประเมิน"
                mdlNotice.Show()
            End If
        End If


    End Sub

    Protected Sub btnSaveConfrim_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim A1 As String
        Dim i As Integer
        Dim lblApprove_id As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        Dim ApprroveID As String

        Dim Request As List(Of Appraisal_Request) = GET_APPRAISAL_REQUEST(lblReq_Id_Confirm.Text)
        If Request.Item(0).Status_ID <= 7 Then
            If lblPrice2.Text = String.Empty Then
                's = "<script language=""javascript"">alert('ไม่พบการกำหนดราคาที่ 2 ของเลขคำขอนี้ในระบบ');</script>"
                'Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)
            Else
                A1 = lblApprove_id.Text
                i = A1.IndexOf("_")
                If i > 0 Then
                    ApprroveID = Left(A1, i)
                Else
                    ApprroveID = lblApprove_id.Text
                End If
                UPDATE_PRICE2_MASTER(lblReq_Id_Confirm.Text, lblHub_Id_Confirm.Text, lblPrice2.Text, txtNote_Confirm.Text, ApprroveID)
                UPDATE_Status_Appraisal_Request(lblReq_Id_Confirm.Text, lblHub_Id_Confirm.Text, rdbAccept.SelectedValue)
                GridView1.DataBind()
            End If
        Else
            'up1.Update()
            mdlNotice.Show()
        End If

    End Sub

    Protected Sub ImageCollDetail_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim btnEdit As ImageButton = TryCast(sender, ImageButton)
        Dim Req_Id As Label = btnEdit.Parent.FindControl("lblReq_id")
        Dim Hub_Id As Label = btnEdit.Parent.FindControl("lblHub_Id")
        Dim HubName As Label = btnEdit.Parent.FindControl("lblHub_Name")
        Dim Cif As Label = btnEdit.Parent.FindControl("lblCif")
        Dim Cusname As Label = btnEdit.Parent.FindControl("lblCifName")
        Dim SenderName As Label = btnEdit.Parent.FindControl("LabelEmp_Name")
        'Dim lblPrice2 As Label = btnEdit.Parent.FindControl("lblPrice2")
        Dim DateSent As Label = btnEdit.Parent.FindControl("LabelCreate_Date")
        Dim StatusId As HiddenField = btnEdit.Parent.FindControl("hdfStatus_Id")
        Dim ID As HiddenField = btnEdit.Parent.FindControl("H_ID")
        Dim Colltype As Label = btnEdit.Parent.FindControl("lblColltype")

        'Context.Items("Req_Id") = Req_Id
        'Context.Items("Hub_Id") = Hub_Id
        'Context.Items("ID") = ID
        'Context.Items("AID") = 0
        'Context.Items("Coll_Type") = Colltype
        'Server.Transfer("Appraisal_Price2_Add_By_Colltype.aspx")

        mdlCollDetail.Show()
    End Sub

#Region "GridView2 Event Handlers"

    'Protected Sub GridView2_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
    '    Dim gvTemp As GridView = DirectCast(sender, GridView)
    '    gvUniqueID = gvTemp.UniqueID
    '    gvNewPageIndex = e.NewPageIndex
    '    GridView1.DataBind()
    'End Sub

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
                        'Dim Ib As ImageButton = DirectCast(e.Row.Cells(11).FindControl("ImgDelete"), ImageButton)

                        'access the LinkButton from the TemplateField using FindControl method 
                        'If Ib IsNot Nothing Then
                        '    Ib.Attributes.Add("onclick", "return ConfirmOnDelete('" & Expl & "');")
                        '    'attach the JavaScript function 
                        'End If
                    End If
                End If
            End If
        End If
    End Sub

    'Protected Sub GridView2_Sorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs)
    '    Dim gvTemp As GridView = DirectCast(sender, GridView)
    '    gvUniqueID = gvTemp.UniqueID
    '    gvSortExpr = e.SortExpression
    '    GridView1.DataBind()
    'End Sub

    Protected Sub GridView2_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs)

        'Dim row As GridViewRow = DirectCast(btnEdit.NamingContainer, GridViewRow)
        Dim gvTemp As GridView = DirectCast(sender, GridView)
        Dim Req_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblReq_Id"), Label)
        Dim Status_Id As HiddenField = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("HiddenStatus_Id"), HiddenField)
        Dim Hub_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblHub_id"), Label)
        Dim ID As HiddenField = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("H_ID"), HiddenField)
        Dim Cif As HiddenField = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("H_CIF"), HiddenField)
        Dim CollType As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblColltype"), Label)
        Dim TempAid As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblTemp_AID"), Label)
        up1.Update()
        txtReqId.Text = Req_Id.Text
        'If CInt(Status_Id.Value) >= 97 Then
        '    mdlPopup.Hide()
        'Else
        Session("reqId") = Req_Id.Text
        Session("hubId") = Hub_Id.Text
        Session("id") = ID.Value
        Session("tempAid") = TempAid.Text

        'Dim request As List(Of Appraisal_Request_v2) = GET_APPRAISAL_REQUEST_V2(Req_Id.Text)
        'If request.Item(0).Req_Type = 1 Then
        If CollType.Text = "50" Then
            mdlCollDetail.Show()
        ElseIf CollType.Text = "70" Then
            mdlCollDetail70.Show()
        ElseIf CollType.Text = "18" Then
            'ยังไม่ได้ทำ
            'mdlCollDetail18.Show()
        End If
        'Else
        '    Context.Items("Req_Id") = Req_Id.Text
        '    Context.Items("Hub_Id") = Hub_Id.Text
        '    Context.Items("Temp_AID") = TempAid.Text
        '    Context.Items("Cif") = Cif.Value
        '    Context.Items("ID") = ID.Value
        '    Context.Items("Coll_Type") = CollType.Text
        '    Context.Items("SpecialAdd") = "เพิ่มกรณีปกติ"
        '    If CollType.Text = "50" Then
        '        Server.Transfer("Appraisal_Price3_50_Review_Edit.aspx")
        '    ElseIf CollType.Text = "70" Then
        '        Server.Transfer("Appraisal_Price3_70_Review_Edit.aspx")
        '    ElseIf CollType.Text = "18" Then
        '        Server.Transfer("Appraisal_Price3_18.aspx")
        '    End If
        'End If



        'End If
    End Sub

#End Region

End Class
