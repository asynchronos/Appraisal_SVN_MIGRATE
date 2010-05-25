Imports Appraisal_Manager

Partial Class Appraisal_Building
    Inherits System.Web.UI.Page

    Dim StringNotice As String
    Dim StringMessage As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Request.QueryString("ID").ToString = "" Then
                lblReq_Id.Text = Request.QueryString("Req_Id").ToString
                lblHub_Id.Text = Request.QueryString("Hub_Id").ToString
                lblCif.Text = Request.QueryString("Cif").ToString
                lblCifName.Text = Request.QueryString("CifName").ToString
                hdfAppraisal_Id.Value = Request.QueryString("Appraisal_Id").ToString
            Else
                If Request.QueryString("ID").ToString <> "0" Then
                    lblReq_Id.Text = Request.QueryString("Req_Id").ToString
                    lblHub_Id.Text = Request.QueryString("Hub_Id").ToString
                    lblCif.Text = Request.QueryString("Cif").ToString
                    lblCifName.Text = Request.QueryString("CifName").ToString
                    hdfAppraisal_Id.Value = Request.QueryString("Appraisal_Id").ToString
                    lblId.Text = Request.QueryString("ID").ToString
                    lblTemp_AID.Text = Request.QueryString("Temp_AID").ToString
                    'GET_DATA()
                End If
            End If
        End If
        Appraisal_Request_Info()
    End Sub

    Protected Sub ImageSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSave.Click
        Dim Id As Integer = 0

        Dim Price2_70 As Integer = GET_PRICE2_70_NEW_COUNT(lblReq_Id.Text, lblHub_Id.Text, txtBuild_No.Text)
        If Price2_70 = 0 Then
            'ถ้าไม่มีอยู่ตาราง Price2_70_New
            If DDLSubCollType.SelectedValue <= 45 Or DDLSubCollType.SelectedValue = 50 Then
                'เป็นสิ่งปลูกสร้าง
                'If rdbAppraisal_Type.SelectedValue = 1 Then

                'Else
                '    txtMarketPrice.Text = "0"
                'End If

                Id = GET_ID_18_50_70("70")
                UPDATE_ID_70()  'Update ID CollType 70
                lblId.Text = Id
                ADD_PRICE2_PRICE3_70(Id, lblReq_Id.Text, lblHub_Id.Text, 0, 0, 0, _
                    DDLSubCollType.SelectedValue, txtBuild_No.Text, txtTumbon.Text, txtAmphur.Text, _
                    ddlProvince.SelectedValue, ddlBuild_Character.SelectedValue, txtFloor.Text, txtItem.Text, ddlBuild_Construct.SelectedValue, _
                    ddlRoof.SelectedValue, txtRoof_Detail.Text, ddlBuild_State.SelectedValue, _
                    txtBuild_State_Detail.Text, txtBuilding_Detail.Text, CDec(txtMarketPrice.Text), _
                    chkDoc1.Checked, chkDoc2.Checked, String.Empty, String.Empty, txtChanodeNo.Text, txtOwnership.Text, txtBuildingArea.Text, CDec(txtBuildingUnitPrice.Text), _
                    CDec(txtBuildingPrice.Text), txtBuildingAge.Text, CDec(txtBuildingPersent1.Text), CDec(txtBuildingPersent2.Text), CDec(txtBuildingPersent3.Text), _
                    CDec(txtBuildingPriceTotalDeteriorate.Text), CInt(txtFinishPercent.Text), CDec(txtPriceNotFinish.Text), 0, 0, 0, _
                    0, 0, 0, 0, 0, 0, 0, _
                    txtBuildingDetail.Text, ddlInteriorState.SelectedValue, TextBoxStandardNo.Text, ddlRoofConstructure.SelectedValue, ddlRoofState.SelectedValue, _
                    hdfAppraisal_Id.Value, Now())

            ElseIf DDLSubCollType.SelectedValue = 53 Then
                'เป็นส่วนต่อเติมสิ่งปลูกสร้าง
                'lblMessageNotice_Building.Text = "คุณไม่สามารถเพิ่มส่วนต่อเติมได้เพราะยังไม่มีสิ่งปลูกสร้างหลัก"

            ElseIf DDLSubCollType.SelectedValue >= 54 Then 'And DDLSubCollType.SelectedValue <= 61 Then
                'เป็นส่วนควบ
                's = "<Script language=""javascript"">alert('คุณไม่สามารถเพิ่มควบได้เพราะยังไม่มีสิ่งปลูกสร้างหลัก');</Script>"
                'Page.ClientScript.RegisterStartupScript(Me.GetType, "Noticeส่วนต่อเติม", s)
                'lblMessageNotice_Building.Text = "คุณไม่สามารถเพิ่มควบได้เพราะยังไม่มีสิ่งปลูกสร้างหลัก"
            End If
        Else
            'ถ้ามีอยู่ตาราง(Price2_70_New)
            Dim ID_Building As Integer
            Dim p2_70new As List(Of Price2_70_New) = GET_PRICE2_70_NEW_VERIFY_UPDATE(lblReq_Id.Text, lblHub_Id.Text, txtBuild_No.Text)
            ID_Building = p2_70new.Item(0).ID

            If DDLSubCollType.SelectedValue <= 45 Or DDLSubCollType.SelectedValue = 50 Then
                'เป็นสิ่งปลูกสร้าง

                'ระบบออก ID ให้สิ่งปลูกสร้าง
                Id = GET_ID_18_50_70("70")
                UPDATE_ID_70()  'Update ID CollType 70
                lblId.Text = Id
                ADD_PRICE2_PRICE3_70(Id, lblReq_Id.Text, lblHub_Id.Text, 0, 0, 0, _
                    DDLSubCollType.SelectedValue, txtBuild_No.Text, txtTumbon.Text, txtAmphur.Text, _
                    ddlProvince.SelectedValue, ddlBuild_Character.SelectedValue, txtFloor.Text, txtItem.Text, ddlBuild_Construct.SelectedValue, _
                    ddlRoof.SelectedValue, txtRoof_Detail.Text, ddlBuild_State.SelectedValue, _
                    txtBuild_State_Detail.Text, txtBuilding_Detail.Text, CDec(txtMarketPrice.Text), _
                    chkDoc1.Checked, chkDoc2.Checked, String.Empty, String.Empty, txtChanodeNo.Text, txtOwnership.Text, txtBuildingArea.Text, CDec(txtBuildingUnitPrice.Text), _
                    CDec(txtBuildingPrice.Text), txtBuildingAge.Text, CDec(txtBuildingPersent1.Text), CDec(txtBuildingPersent2.Text), CDec(txtBuildingPersent3.Text), _
                    CDec(txtBuildingPriceTotalDeteriorate.Text), CInt(txtFinishPercent.Text), CDec(txtPriceNotFinish.Text), 0, 0, 0, _
                    0, 0, 0, 0, 0, 0, 0, _
                    txtBuildingDetail.Text, ddlInteriorState.SelectedValue, TextBoxStandardNo.Text, ddlRoofConstructure.SelectedValue, ddlRoofState.SelectedValue, _
                    hdfAppraisal_Id.Value, Now())

            ElseIf DDLSubCollType.SelectedValue = 53 Then
                'เป็นส่วนต่อเติมสิ่งปลูกสร้าง
                txtMarketPrice.Text = "0"
                UPDATE_PRICE2_PRICE3_70_BUILDING_PLUS(lblReq_Id.Text, lblHub_Id.Text, txtBuild_No.Text, txtBuildingArea.Text, CDec(txtBuildingUnitPrice.Text), _
                    CDec(txtBuildingPrice.Text), txtBuildingAge.Text, CDec(txtBuildingPersent1.Text), CDec(txtBuildingPersent2.Text), CDec(txtBuildingPersent3.Text), _
                    CDec(txtBuildingPriceTotalDeteriorate.Text), CInt(txtFinishPercent.Text), CDec(txtPriceNotFinish.Text), CDec(txtPriceTotal1.Text), hdfAppraisal_Id.Value, Now())
            ElseIf DDLSubCollType.SelectedValue >= 54 Then 'And DDLSubCollType.SelectedValue <= 61 Then
                'เป็นส่วนควบ
                Dim Partake_Id As Integer
                Partake_Id = DDLSubCollType.SelectedValue - 53
                txtMarketPrice.Text = "0"
                ADD_PRICE2_PRICE3_70_PARTAKE(ID_Building, lblReq_Id.Text, lblHub_Id.Text, 0, "", Partake_Id, txtBuild_No.Text, _
                 txtBuildingArea.Text, CDec(txtBuildingUnitPrice.Text), CDec(txtBuildingPrice.Text), txtBuildingAge.Text, _
                 CDec(txtBuildingPersent1.Text), CDec(txtBuildingPersent2.Text), CDec(txtBuildingPersent3.Text), CDec(txtBuildingPriceTotalDeteriorate.Text), _
                 CInt(txtFinishPercent.Text), CDec(txtPriceNotFinish.Text) * (CInt(txtFinishPercent.Text) / 100), String.Empty, hdfAppraisal_Id.Value, Now())
            End If
        End If

    End Sub

    Sub Appraisal_Request_Info()
        Dim Request As List(Of Appraisal_Request_v2) = GET_APPRAISAL_REQUEST_V2(lblReq_Id.Text)
        txtChanodeNo.Text = Request.Item(0).CollOfNumber
        If IsNumeric(Request.Item(0).Tumbon) Then
            Dim Tumbon As List(Of Cls_Tumbon) = GET_TUMBON_INFO(Request.Item(0).Tumbon, Request.Item(0).Amphur, Request.Item(0).Province)
            txtTumbon.Text = Tumbon.Item(0).tumbon_new2_name
        Else
            'txtTumbon.Text = Request.Tables(0).Rows(0).Item("Tumbon")
        End If

        If IsNumeric(Request.Item(0).Amphur) Then
            Dim Amphur As List(Of Cls_Amphur) = GET_AMPHUR_INFO(Request.Item(0).Amphur, Request.Item(0).Province)
            txtAmphur.Text = Amphur.Item(0).am_name
        Else
            'txtAmphur.Text = Obj_GetP50.Item(0).Amphur
        End If
        ddlProvince.SelectedValue = Request.Item(0).Province 
    End Sub

End Class
