Imports Appraisal_Manager
Imports System.Data
Imports System.Data.SqlClient

Partial Class Appraisal_Assign_Job_V2
    Inherits System.Web.UI.Page
    Private strMessage As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim cph As ContentPlaceHolder = TryCast(Me.Form.FindControl("ContentPlaceHolder1"), ContentPlaceHolder) 'หา Control จาก Master Page ที่ control อยู่ใน  ContentPlaceHolder1
        Dim lblHub As Label = TryCast(Me.Form.FindControl("lblHub_Id"), Label)
        HdfHub_Id.Value = lblHub.Text
        Dim ReqId As Label = DirectCast(cph.FindControl("lblRequestID"), Label) 'Me.FindControl("lblRequestID")
    End Sub

#Region "person"
    Protected Sub btnEditPerson_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btnEdit As ImageButton = TryCast(sender, ImageButton)
        'Dim row As GridViewRow = DirectCast(btnEdit.NamingContainer, GridViewRow)
        Dim Req_Id As Label = btnEdit.Parent.FindControl("lblReq_Id")
        Dim Hub_Id As Label = btnEdit.Parent.FindControl("lblHub_Id")
        Dim Cus_Name As Label = btnEdit.Parent.FindControl("lblCifName")
        Dim Sentder_Name As Label = btnEdit.Parent.FindControl("LabelEmp_Name")
        Dim Date_Sent As Label = btnEdit.Parent.FindControl("LabelCreate_Date")
        Dim StatusId As HiddenField = DirectCast(btnEdit.Parent.FindControl("hdfStatus_Id"), HiddenField)
        HdfStatus.Value = StatusId.Value

        Dim ChkDoc As DataSet = GET_APPRAISAL_REQUEST_PICTURE_PATH(Req_Id.Text, HdfHub_Id.Value)
        If ChkDoc.Tables(0).Rows.Count > 0 Then
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

                UpdatePanel1.Update()
                mpeAttachFile.Show()
            Else
                hidPersonEditIndex.Value = Req_Id.Text '(row.Cells(0).Text)
                txtReqId.Text = Req_Id.Text '(row.Cells(2).Text)
                txtReqId.ReadOnly = True
                txtLastName.Text = Sentder_Name.Text  '(row.Cells(3).Text)
                txtMiddleName.Text = Cus_Name.Text '(row.Cells(4).Text)
                lblSent_Date.Text = Date_Sent.Text
                lblError.Text = ""
                UpdatePanel1.Update()
                mpePerson.Show()
            End If
        Else

            txtAppraisalForm.Text = "ยังไม่ได้แนบไฟล์"
            txtPicMap.Text = "ยังไม่ได้แนบไฟล์"
            txtPicChanode.Text = "ยังไม่ได้แนบไฟล์"

            UpdatePanel1.Update()
            mpeAttachFile.Show()
        End If


    End Sub

    Protected Sub btnDeletePerson_Click(ByVal sender As Object, ByVal e As EventArgs)
        'delete would occur here, skipping for demo 
        'grdPerson.DataBind()
        'updPerson.Update()
    End Sub

    Protected Sub btnSavePerson_Click(ByVal sender As Object, ByVal e As EventArgs)
        'If grdPerson.DataSourceID = dsPerson.ID Then
        '    SavePerson(dsPerson, Convert.ToInt32(hidPersonEditIndex.Value), txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, Convert.ToDateTime(Date1.Text))
        'Else
        '    SavePerson(dsPersonXml, Convert.ToInt32(hidPersonEditIndex.Value), txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, Convert.ToDateTime(Date1.Text))
        'End If

        'grdPerson.DataBind()
        'updPerson.Update()
        'mpePerson.Hide()

        'MsgBox(txtReqId.Text)
        'MsgBox(HdfHub_Id.Value)
        'MsgBox(ddlStatus.SelectedValue)
        'MsgBox(ddlAppraisal2.SelectedValue)

        Dim ChkDoc As DataSet = GET_APPRAISAL_REQUEST_PICTURE_PATH(txtReqId.Text, HdfHub_Id.Value)

        'MsgBox(ChkDoc.Tables(0).Rows(0).Item("Req_Form"))
        'MsgBox(ChkDoc.Tables(0).Rows(0).Item("Map"))
        'MsgBox(ChkDoc.Tables(0).Rows(0).Item("Chanode"))

        'If ChkDoc.Tables(0).Rows.Count = 0 Then
        If ChkDoc.Tables(0).Rows(0).Item("Req_Form") = 0 Or ChkDoc.Tables(0).Rows(0).Item("Map") = 0 Or ChkDoc.Tables(0).Rows(0).Item("Chanode") = 0 Then
            lblError.Text = "เอกสารแนบตามที่ระบบกำหนดไม่ครบถ้วน"
            UpdatePanel1.Update()
            mpePerson.Show()
        Else

            UPDATE_APPRAISAL_ID(txtReqId.Text, HdfHub_Id.Value, ddlStatus.SelectedValue, ddlAppraisal2.SelectedValue)
            UpdatePanel1.Update()
            mpePerson.Hide()
            GridAssignJob.DataBind()
        End If


    End Sub

#End Region

End Class
