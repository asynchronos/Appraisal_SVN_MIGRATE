Imports Appraisal_Manager
Partial Class Appraisal_Price2_Add_By_Colltype70_New
    Inherits System.Web.UI.Page
    Dim xId, xTemp_AID As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            lblReq_Id.Text = Context.Items("Req_Id")
            lblHub_Id.Text = Context.Items("Hub_Id")
            hhhfSubCollType.Value = Context.Items("Coll_Type")
            hdfCif.Value = Context.Items("Cif")
            If Context.Items("Temp_AID") = String.Empty Then
                'lblTemp_AID.Text = 0
                lblTemp_AID.Text = "0"
            Else
                lblTemp_AID.Text = Context.Items("Temp_AID")
            End If
            If Context.Items("ID") = String.Empty Then
                'กรณีที่เพิ่มชิ้นทรัพย์ใหม่จะยังไม่มี ID
                'lblId.Text = 0
                lblId.Text = 0
            Else
                'กรณีมีชิ้นทรัพย์แล้วต้องการดูหรือแก้ไขข้อมูล
                lblId.Text = Context.Items("ID")
                'ตรวจสอบว่ามีข้อมูลอยู่หรือไม่
                Dim P2_70New As List(Of Price2_70_New) = GET_PRICE2_70_NEW(lblId.Text, lblReq_Id.Text, lblHub_Id.Text)
                If P2_70New.Count = 0 Then
                Else
                    'Display Data Price2_70_New
                    GET_DATA(P2_70New)
                End If
            End If



        End If
    End Sub

    Private Sub SAVE_DATA()
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label) 'หา Control จาก Master Page ที่ control ไม่อยู่ใน  ContentPlaceHolder1 ของ Master Page
        'If lblId.Text = String.Empty Then
        '    xId = 0
        'End If
        If lblTemp_AID.Text = String.Empty Then
            lblTemp_AID.Text = 0
        End If
        Dim ID As Integer = GET_ID_18_50_70("70")
        lblId.Text = ID
        ADD_PRICE2_70_NEW(lblId.Text, CInt(lblReq_Id.Text), CInt(lblHub_Id.Text), lblTemp_AID.Text, _
                CInt(DDLSubCollType.SelectedValue), txtBuild_No.Text, txtTumbon.Text, txtAmphur.Text, _
                ddlProvince.SelectedValue, ddlBuild_Character.SelectedValue, _
                txtFloor.Text, txtItem.Text, ddlBuild_Construct.SelectedValue, _
                ddlRoof.SelectedValue, txtRoof_Detail.Text, ddlBuild_State.SelectedValue, _
                txtBuild_State_Detail.Text, txtBuilding_Detail.Text, CDec(txtPriceTotal1.Text), _
                chkDoc1.Checked, chkDoc2.Checked, txtDoc_Detail.Text, String.Empty, txtChanodeNo.Text, txtOwnership.Text, txtBuildingArea.Text, CDec(txtBuildingUnitPrice.Text), _
                CDec(txtBuildingPrice.Text), txtBuildingAge.Text, txtBuildingPersent1.Text, txtBuildingPersent2.Text, txtBuildingPersent3.Text, _
                CDec(txtBuildingPriceTotalDeteriorate.Text), CInt(txtFinishPercent.Text), CDec(txtPriceNotFinish.Text), txtBuildAddArea.Text, CDec(txtBuildAddUnitPrice.Text), CDec(txtBuildAddPrice.Text), _
                txtBuildAddAge.Text, txtBuildAddPersent1.Text, txtBuildAddPersent2.Text, txtBuildAddPersent3.Text, CDec(txtBuildAddTotalDeteriorate.Text), CInt(txtFinishPercent1.Text), CDec(txtPriceNotFinish1.Text), _
                txtBuildingDetail.Text, ddlInteriorState.SelectedValue, lbluserid.Text, Now())
        UPDATE_Status_Appraisal_Request(lblReq_Id.Text, lblHub_Id.Text, 5)
    End Sub

    Private Sub UPDATE_DATA()
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label) 'หา Control จาก Master Page ที่ control ไม่อยู่ใน  ContentPlaceHolder1 ของ Master Page
        UPDATE_PRICE2_70_NEW(lblId.Text, CInt(lblReq_Id.Text), CInt(lblHub_Id.Text), lblTemp_AID.Text, _
                CInt(DDLSubCollType.SelectedValue), txtBuild_No.Text, txtTumbon.Text, txtAmphur.Text, _
                ddlProvince.SelectedValue, ddlBuild_Character.SelectedValue, _
                txtFloor.Text, txtItem.Text, ddlBuild_Construct.SelectedValue, _
                ddlRoof.SelectedValue, txtRoof_Detail.Text, ddlBuild_State.SelectedValue, _
                txtBuild_State_Detail.Text, txtBuilding_Detail.Text, CDec(txtPriceTotal1.Text), _
                chkDoc1.Checked, chkDoc2.Checked, txtDoc_Detail.Text, String.Empty, txtChanodeNo.Text, txtOwnership.Text, txtBuildingArea.Text, CDec(txtBuildingUnitPrice.Text), _
                CDec(txtBuildingPrice.Text), txtBuildingAge.Text, txtBuildingPersent1.Text, txtBuildingPersent2.Text, txtBuildingPersent3.Text, _
                CDec(txtBuildingPriceTotalDeteriorate.Text), CInt(txtFinishPercent.Text), CDec(txtPriceNotFinish.Text), txtBuildAddArea.Text, CDec(txtBuildAddUnitPrice.Text), CDec(txtBuildAddPrice.Text), _
                txtBuildAddAge.Text, txtBuildAddPersent1.Text, txtBuildAddPersent2.Text, txtBuildAddPersent3.Text, CDec(txtBuildAddTotalDeteriorate.Text), CInt(txtFinishPercent1.Text), CDec(txtPriceNotFinish1.Text), _
                txtBuildingDetail.Text, ddlInteriorState.SelectedValue, lbluserid.Text, Now())
        'UPDATE_Status_Appraisal_Request(lblReq_Id.Text, lblHub_Id.Text, 6)
    End Sub

    Private Sub GET_DATA(ByVal P2_70New As List(Of Price2_70_New))
        lblId.Text = P2_70New.Item(0).ID
        lblReq_Id.Text = P2_70New.Item(0).Req_Id
        lblHub_Id.Text = P2_70New.Item(0).Hub_Id
        DDLSubCollType.SelectedValue = P2_70New.Item(0).MysubColl_ID
        txtChanodeNo.Text = P2_70New.Item(0).Put_On_Chanode
        txtOwnership.Text = P2_70New.Item(0).Ownership
        txtBuild_No.Text = P2_70New.Item(0).Build_No
        txtTumbon.Text = P2_70New.Item(0).Tumbon
        txtAmphur.Text = P2_70New.Item(0).Amphur
        ddlProvince.SelectedValue = P2_70New.Item(0).Province
        ddlBuild_Character.SelectedValue = P2_70New.Item(0).Build_Character
        txtFloor.Text = P2_70New.Item(0).Floors
        txtItem.Text = P2_70New.Item(0).Item
        ddlBuild_Construct.SelectedValue = P2_70New.Item(0).Build_Construct
        ddlRoof.SelectedValue = P2_70New.Item(0).Roof
        txtRoof_Detail.Text = P2_70New.Item(0).Roof_Detail
        ddlBuild_State.SelectedValue = P2_70New.Item(0).Build_State
        txtBuild_State_Detail.Text = P2_70New.Item(0).Build_State_Detail
        txtBuilding_Detail.Text = P2_70New.Item(0).Building_Detail
        txtPriceTotal1.Text = String.Format("{0:N2}", P2_70New.Item(0).PriceTotal1)
        chkDoc1.Checked = P2_70New.Item(0).Doc1
        chkDoc2.Checked = P2_70New.Item(0).Doc2
        txtDoc_Detail.Text = P2_70New.Item(0).Doc_Detail
        txtBuildingArea.Text = P2_70New.Item(0).BuildingArea
        txtBuildingUnitPrice.Text = P2_70New.Item(0).BuildingUintPrice
        txtBuildingPrice.Text = String.Format("{0:N2}", P2_70New.Item(0).BuildingPrice)
        txtBuildingAge.Text = P2_70New.Item(0).BuildingAge
        txtBuildingPersent1.Text = P2_70New.Item(0).BuildingPersent1
        txtBuildingPersent2.Text = P2_70New.Item(0).BuildingPersent2
        txtBuildingPersent3.Text = P2_70New.Item(0).BuildingPersent3
        txtBuildingTotalDeteriorate.Text = P2_70New.Item(0).BuildingAge * (P2_70New.Item(0).BuildingPersent1 + P2_70New.Item(0).BuildingPersent2 + P2_70New.Item(0).BuildingPersent3)
        txtFinishPercent.Text = P2_70New.Item(0).BuildingPercentFinish
        txtPriceNotFinish.Text = String.Format("{0:N2}", P2_70New.Item(0).BuildingPriceFinish)
        txtBuildingPriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtPriceNotFinish.Text) * CDec(txtBuildingTotalDeteriorate.Text)) / 100)
        txtBuildAddArea.Text = P2_70New.Item(0).BuildAddArea
        txtBuildAddUnitPrice.Text = P2_70New.Item(0).BuildAddUintPrice
        txtBuildAddPrice.Text = String.Format("{0:N2}", P2_70New.Item(0).BuildAddPrice)
        txtBuildAddAge.Text = P2_70New.Item(0).BuildAddAge
        txtBuildAddPersent1.Text = P2_70New.Item(0).BuildAddPersent1
        txtBuildAddPersent2.Text = P2_70New.Item(0).BuildAddPersent2
        txtBuildAddPersent3.Text = P2_70New.Item(0).BuildAddPersent3
        txtFinishPercent1.Text = P2_70New.Item(0).BuildAddPercentFinish
        txtPriceNotFinish1.Text = String.Format("{0:N2}", P2_70New.Item(0).BuildAddPriceFinish)
        txtBuildAddTotalDeteriorate.Text = P2_70New.Item(0).BuildAddAge * (P2_70New.Item(0).BuildAddPersent1 + P2_70New.Item(0).BuildAddPersent2 + P2_70New.Item(0).BuildAddPersent3) 'Obj_GetP70.Item(0).BuildAddPriceTotalDeteriorate
        txtBuildAddPriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtPriceNotFinish1.Text) * CDec(txtBuildAddTotalDeteriorate.Text)) / 100)
        txtBuildingDetail.Text = P2_70New.Item(0).BuildingDetail
        ddlInteriorState.SelectedValue = P2_70New.Item(0).Decoration
        Dim Obj_P2_70D As List(Of Cls_Price2_70_Detail) = GET_PRICE2_70_DETAIL(lblId.Text, lblReq_Id.Text, lblHub_Id.Text, lblTemp_AID.Text, 0)
        If Obj_P2_70D.Count > 0 Then
            chkDetail.Checked = True
        End If
    End Sub

    Private Sub INITIAL_DATA()
        lblId.Text = String.Empty
        'txtChanodeNo.Text = P2_70New.Item(0).Put_On_Chanode
        'txtOwnership.Text = P2_70New.Item(0).Ownership
        txtBuild_No.Text = String.Empty
        'txtTumbon.Text = P2_70New.Item(0).Tumbon
        'txtAmphur.Text = P2_70New.Item(0).Amphur
        ddlProvince.SelectedValue = 1
        ddlBuild_Character.SelectedValue = 1
        txtFloor.Text = String.Empty
        txtItem.Text = String.Empty
        ddlBuild_Construct.SelectedValue = 1
        ddlRoof.SelectedValue = 1
        txtRoof_Detail.Text = String.Empty
        'ddlBuild_State.SelectedValue = P2_70New.Item(0).Build_State
        txtBuild_State_Detail.Text = String.Empty
        txtBuilding_Detail.Text = String.Empty
        txtPriceTotal1.Text = "0.00"
        chkDoc1.Checked = False
        chkDoc2.Checked = False
        txtDoc_Detail.Text = String.Empty
        txtBuildingArea.Text = "0"
        txtBuildingUnitPrice.Text = "0.00"
        txtBuildingPrice.Text = "0.00"
        txtBuildingAge.Text = "0"
        txtBuildingPersent1.Text = "0"
        txtBuildingPersent2.Text = "0"
        txtBuildingPersent3.Text = "0"
        txtBuildingTotalDeteriorate.Text = "0.00"
        txtFinishPercent.Text = "0"
        txtPriceNotFinish.Text = "0.00"
        txtBuildingPriceTotalDeteriorate.Text = "0.00"
        txtBuildAddArea.Text = "0"
        txtBuildAddUnitPrice.Text = "0.00"
        txtBuildAddPrice.Text = "0.00"
        txtBuildAddAge.Text = "0"
        txtBuildAddPersent1.Text = "0"
        txtBuildAddPersent2.Text = "0"
        txtBuildAddPersent3.Text = "0"
        txtFinishPercent1.Text = "0"
        txtPriceNotFinish1.Text = "0.00"
        txtBuildAddTotalDeteriorate.Text = "0.00"
        txtBuildAddPriceTotalDeteriorate.Text = "0.00"
        txtBuildingDetail.Text = String.Empty
        ddlInteriorState.SelectedValue = 1
        chkDetail.Checked = False

    End Sub

    Protected Sub ImageSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSave.Click
        Operation()
    End Sub

    Protected Sub btnAddDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddDetail.Click
        'Operation()
        If lblId.Text = String.Empty Or lblId.Text = "0" Then
            SAVE_DATA()
        Else

        End If
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        Context.Items("Req_Id") = lblReq_Id.Text
        Context.Items("Hub_Id") = lblHub_Id.Text
        Context.Items("Temp_AID") = lblTemp_AID.Text
        Context.Items("ID") = lblId.Text
        Context.Items("User_ID") = lbluserid.Text
        Server.Transfer("Appraisal_Price2_Add_Colltype70_Detail.aspx")
    End Sub

    Protected Sub btnAdPartake_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdPartake.Click
        'Operation()
        If lblId.Text = String.Empty Or lblId.Text = "0" Then
            SAVE_DATA()
        Else

        End If
        Context.Items("Id") = lblId.Text
        Context.Items("Temp_AID") = lblTemp_AID.Text
        Context.Items("Req_Id") = lblReq_Id.Text
        Context.Items("Hub_Id") = lblHub_Id.Text
        Context.Items("Building_No") = txtBuild_No.Text
        Server.Transfer("Appraisal_Price2_70_Partake.aspx")
    End Sub

    Private Sub Operation()
        If lblId.Text = String.Empty Or lblId.Text = "0" Then
            SAVE_DATA()
        Else
            UPDATE_DATA()
        End If
    End Sub

    Protected Sub ImagePrint_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImagePrint.Click
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        Context.Items("ID") = lblId.Text
        Context.Items("Req_Id") = lblReq_Id.Text
        Context.Items("Hub_Id") = lblHub_Id.Text
        Context.Items("Temp_AID") = lblTemp_AID.Text
        Context.Items("User_ID") = lbluserid.Text
        Server.Transfer("Appraisal_Price3_Print_CollType70.aspx")

        'HiddenField1.Value = CInt(Context.Items("ID"))
        'HiddenField2.Value = CInt(Context.Items("Req_Id"))
        'HiddenField3.Value = CInt(Context.Items("Hub_Id"))
        'HiddenField4.Value = CInt(Context.Items("Temp_AID"))
        'HiddenField5.Value = CStr(Context.Items("User_ID"))
    End Sub
End Class
