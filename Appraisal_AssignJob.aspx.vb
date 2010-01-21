Imports Appraisal_Manager
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Imports System.Web.UI

Partial Class Appraisal_AssignJob
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cph As ContentPlaceHolder = TryCast(Me.Form.FindControl("ContentPlaceHolder1"), ContentPlaceHolder) 'หา Control จาก Master Page ที่ control อยู่ใน  ContentPlaceHolder1
        If Not Page.IsPostBack Then
            Dim ReqId As Label = DirectCast(cph.FindControl("lblRequestID"), Label) 'Me.FindControl("lblRequestID")
        End If
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender

        Dim lblHub As Label = TryCast(Me.Form.FindControl("lblHub_Id"), Label)
        HdfHub_Id.Value = lblHub.Text

    End Sub

    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging

        'Dim row As GridViewRow = DirectCast(btnEdit.NamingContainer, GridViewRow)
        Dim gvTemp As GridView = DirectCast(sender, GridView)
        Dim Req_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblReq_Id"), Label)
        Dim Status_Id As HiddenField = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("HiddenStatus_Id"), HiddenField)
        Dim Hub_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblHub_id"), Label)


        up1.Update()
        txtReqId.Text = Req_Id.Text
        'If CInt(Status_Id.Value) >= 97 Then
        '    mdlPopup.Hide()
        'Else
        mdlPopup.Show()

        'End If
    End Sub

    Protected Sub btnSaveAssignJob_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btnEdit As ImageButton = TryCast(sender, ImageButton)
        'Dim row As GridViewRow = DirectCast(btnEdit.NamingContainer, GridViewRow)
        Dim Req_Id As Label = btnEdit.Parent.FindControl("lblReq_id")
        Dim Hub_Id As Label = btnEdit.Parent.FindControl("lblHub_Id")
        Dim Cusname As Label = btnEdit.Parent.FindControl("lblCifName")
        Dim SenderName As Label = btnEdit.Parent.FindControl("LabelEmp_Name")
        Dim DateSent As Label = btnEdit.Parent.FindControl("LabelCreate_Date")
        Dim StatusId As HiddenField = btnEdit.Parent.FindControl("hdfStatus_Id")
        'Dim gvTemp As GridView = DirectCast(sender, GridView)
        'Dim Req_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblReq_Id"), Label)
        'Dim Status_Id As HiddenField = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("HiddenStatus_Id"), HiddenField)
        'Dim Hub_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblHub_id"), Label)


        If CInt(StatusId.Value) = 6 Then
            HdfStatus.Value = 6
            txtReqId.Text = Req_Id.Text
            txtMiddleName.Text = Cusname.Text
            txtSenderName.Text = SenderName.Text
            lblSent_Date.Text = DateSent.Text
            'ddlStatus.SelectedValue = StatusId.Value
            up1.Update()
            mdlPopup.Show()
        ElseIf CInt(StatusId.Value) >= 97 Then
            mdlPopup.Hide()
        Else
            txtReqId.Text = Req_Id.Text
            txtMiddleName.Text = Cusname.Text
            txtSenderName.Text = SenderName.Text
            lblSent_Date.Text = DateSent.Text
            'ddlStatus.SelectedValue = StatusId.Value
            up1.Update()
            mdlPopup.Show()
        End If
    End Sub

    Protected Sub imgConfirm_Click(ByVal sender As Object, ByVal e As EventArgs)
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

        Dim Obj_P2 As DataSet = GET_APPRAISAL_PRICE2(Req_Id.Text, Hub_Id.Text)
        If Obj_P2.Tables(0).Rows.Count > 0 Then
            lblPrice1.Text = String.Format("{0:N2}", Obj_P2.Tables(0).Rows(0).Item("Price1"))
            If Obj_P2.Tables(0).Rows(0).Item("Appraisal_Type") = 1 Then
                lblPrice2.Text = String.Format("{0:N2}", Obj_P2.Tables(0).Rows(0).Item("PriceMarket"))
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
            'lblPrice2.Text = Obj_P2.Tables(0).Rows(0).Item("Price2")
            txtNote_Confirm.Text = Obj_P2.Tables(0).Rows(0).Item("Note")
            up1.Update()
            mdlconfirm.Show()
        Else
            'MsgBox("No Data")
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

        sdsAppraisal.SelectParameters.Clear()
        sdsPictureList.SelectCommand = "GET_APPRAISAL_PRICE2_PICTUREPATH"
        sdsPictureList.SelectCommandType = SqlDataSourceCommandType.StoredProcedure
        sdsPictureList.SelectParameters.Add("Req_Id", lblReq_Id_Picture.Text)

        lvPhotos.DataSource = sdsPictureList
        lvPhotos.DataBind()

        up1.Update()
        mdlShowPicture.Show()
    End Sub

    Protected Sub btnSaveConfrim_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim A1 As String
        Dim i As Integer
        Dim lblApprove_id As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        Dim ApprroveID As String
        'MsgBox(lblApprove_id)
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

            's = "<script language=""javascript"">alert('ยืนยันการกำหนดราคาที่ 2 แล้ว');</script>"
            'Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)
        End If
    End Sub

End Class
