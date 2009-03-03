Imports Appraisal_Manager
Partial Class Appraisal_Price3_70_Review_Edit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblId.Text = Context.Items("Id")
            lblReq_Id.Text = Context.Items("Req_Id")
            lblHub_Id.Text = Context.Items("Hub_Id")
            hdfAID.Value = Context.Items("AID")
            hdfColl_Type.Value = Context.Items("Coll_Type")
            lblHub_Id.Text = Context.Items("Hub_Id")
            hdfCif.Value = Context.Items("Cif")
            'lblCifName.Text = Context.Items("CifName")
            Show_Price3_70_Review()

        End If
    End Sub

    Private Sub Show_Price3_70_Review()
        Dim Obj_GetP70_Review As List(Of Price3_70_Review) = GET_PRICE3_70_REVIEW(lblReq_Id.Text, lblHub_Id.Text, lblId.Text)
        If Obj_GetP70_Review.Count > 0 Then
            lblId.Text = Obj_GetP70_Review.Item(0).ID
            lblReq_Id.Text = Obj_GetP70_Review.Item(0).Req_Id
            lblHub_Id.Text = Obj_GetP70_Review.Item(0).Hub_Id
            lblTemp_AID.Text = Obj_GetP70_Review.Item(0).Temp_AID
            DDLSubCollType.SelectedValue = Obj_GetP70_Review.Item(0).MysubColl_ID
            txtChanodeNo.Text = Obj_GetP70_Review.Item(0).Put_On_Chanode
            txtOwnership.Text = Obj_GetP70_Review.Item(0).Ownership
            txtBuild_No.Text = Obj_GetP70_Review.Item(0).Build_No
            txtTumbon.Text = Obj_GetP70_Review.Item(0).Tumbon
            txtAmphur.Text = Obj_GetP70_Review.Item(0).Amphur
            ddlProvince.SelectedValue = Obj_GetP70_Review.Item(0).Province
            ddlBuild_Character.SelectedValue = Obj_GetP70_Review.Item(0).Build_Character
            txtFloor.Text = Obj_GetP70_Review.Item(0).Floors
            txtItem.Text = Obj_GetP70_Review.Item(0).Item
            ddlBuild_Construct.SelectedValue = Obj_GetP70_Review.Item(0).Build_Construct
            ddlRoof.SelectedValue = Obj_GetP70_Review.Item(0).Roof
            txtRoof_Detail.Text = Obj_GetP70_Review.Item(0).Roof_Detail
            ddlBuild_State.SelectedValue = Obj_GetP70_Review.Item(0).Build_State
            txtBuild_State_Detail.Text = Obj_GetP70_Review.Item(0).Build_State_Detail
            txtBuilding_Detail.Text = Obj_GetP70_Review.Item(0).Building_Detail
            txtPriceTotal1.Text = Obj_GetP70_Review.Item(0).PriceTotal1
            chkDoc1.Checked = Obj_GetP70_Review.Item(0).Doc1
            chkDoc2.Checked = Obj_GetP70_Review.Item(0).Doc2
            txtDoc_Detail.Text = Obj_GetP70_Review.Item(0).Doc_Detail
            txtBuildingArea.Text = Obj_GetP70_Review.Item(0).BuildingArea
            txtBuildingUnitPrice.Text = Obj_GetP70_Review.Item(0).BuildingUintPrice
            txtBuildingPrice.Text = Obj_GetP70_Review.Item(0).BuildingPrice
            txtBuildingAge.Text = Obj_GetP70_Review.Item(0).BuildingAge
            txtBuildingPersent1.Text = Obj_GetP70_Review.Item(0).BuildingPersent1
            txtBuildingPersent2.Text = Obj_GetP70_Review.Item(0).BuildingPersent2
            txtBuildingPersent3.Text = Obj_GetP70_Review.Item(0).BuildingPersent3
            txtBuildingTotalDeteriorate.Text = Obj_GetP70_Review.Item(0).BuildingPriceTotalDeteriorate
            txtBuildAddArea.Text = Obj_GetP70_Review.Item(0).BuildAddArea
            txtBuildAddUnitPrice.Text = Obj_GetP70_Review.Item(0).BuildAddUintPrice
            txtBuildAddPrice.Text = Obj_GetP70_Review.Item(0).BuildAddPrice
            txtBuildAddAge.Text = Obj_GetP70_Review.Item(0).BuildAddAge
            txtBuildAddPersent1.Text = Obj_GetP70_Review.Item(0).BuildAddPersent1
            txtBuildAddPersent2.Text = Obj_GetP70_Review.Item(0).BuildAddPersent2
            txtBuildAddPersent3.Text = Obj_GetP70_Review.Item(0).BuildAddPersent3
            txtBuildAddTotalDeteriorate.Text = Obj_GetP70_Review.Item(0).BuildAddPriceTotalDeteriorate
            txtBuildingDetail.Text = Obj_GetP70_Review.Item(0).BuildingDetail
            ddlInteriorState.SelectedValue = Obj_GetP70_Review.Item(0).Decoration

            Dim Obj_P3_70DR As List(Of ClsPrice3_70_Detail) = GET_PRICE3_70_DETAIL_REVIEW(lblId.Text, lblReq_Id.Text, lblHub_Id.Text, lblTemp_AID.Text, 0)
            If Obj_P3_70DR.Count > 0 Then
                chkDetail.Checked = True
            End If
        End If
    End Sub

    Protected Sub ImageSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSave.Click
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label) 'หา Control จาก Master Page ที่ control ไม่อยู่ใน  ContentPlaceHolder1 ของ Master Page
        UPDATE_PRICE3_70_REVIEW(CInt(lblId.Text), CInt(lblReq_Id.Text), CInt(lblHub_Id.Text), CInt(lblTemp_AID.Text), _
                CInt(DDLSubCollType.SelectedValue), txtBuild_No.Text, txtTumbon.Text, txtAmphur.Text, _
                CInt(ddlProvince.SelectedValue), CInt(ddlBuild_Character.SelectedValue), _
                txtFloor.Text, txtItem.Text, CInt(ddlBuild_Construct.SelectedValue), _
                CInt(ddlRoof.SelectedValue), txtRoof_Detail.Text, CInt(ddlBuild_State.SelectedValue), _
                txtBuild_State_Detail.Text, txtBuilding_Detail.Text, CDbl(txtPriceTotal1.Text), _
                chkDoc1.Checked, chkDoc2.Checked, txtDoc_Detail.Text, String.Empty, txtChanodeNo.Text, txtOwnership.Text, CDbl(txtBuildingArea.Text), CDbl(txtBuildingUnitPrice.Text), _
                CDbl(txtBuildingPrice.Text), CDbl(txtBuildingAge.Text), CDbl(txtBuildingPersent1.Text), CDbl(txtBuildingPersent2.Text), CDbl(txtBuildingPersent3.Text), _
                CDbl(txtBuildingPriceTotalDeteriorate.Text), CDbl(txtBuildAddArea.Text), CDbl(txtBuildAddUnitPrice.Text), CDbl(txtBuildAddPrice.Text), _
                CInt(txtBuildAddAge.Text), CDbl(txtBuildAddPersent1.Text), CDbl(txtBuildAddPersent2.Text), CDbl(txtBuildAddPersent3.Text), CDbl(txtBuildAddPriceTotalDeteriorate.Text), _
                txtBuildingDetail.Text, ddlInteriorState.SelectedValue, lbluserid.Text, Now())
    End Sub

    Protected Sub ImgBtnClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnClose.Click
        Context.Items("Id") = lblId.Text
        Context.Items("Req_Id") = lblReq_Id.Text
        Context.Items("Hub_Id") = lblHub_Id.Text
        Context.Items("Coll_Type") = hdfColl_Type.Value
        Context.Items("AID") = hdfAID.Value
        Context.Items("Cif") = hdfCif.Value
        Server.Transfer("Appraisal_Price3_Form_Review.Aspx")
    End Sub

    Protected Sub txtBuildingUnitPrice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuildingUnitPrice.TextChanged
        txtBuildingPrice.Text = CDbl(txtBuildingArea.Text) * CDbl(txtBuildingUnitPrice.Text)
    End Sub

    Protected Sub btnAddPartTake_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddPartTake.Click
        Context.Items("Id") = lblId.Text
        Context.Items("Temp_AID") = lblTemp_AID.Text
        Context.Items("Req_Id") = lblReq_Id.Text
        Context.Items("Hub_Id") = lblHub_Id.Text
        Context.Items("AID") = hdfAID.Value
        Context.Items("Building_No") = txtBuild_No.Text
        Server.Transfer("Appraisal_Price3_70_Review_Partake.aspx")

    End Sub

    Protected Sub btnAddDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddDetail.Click
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        Context.Items("Req_Id") = lblReq_Id.Text
        Context.Items("Hub_Id") = lblHub_Id.Text
        Context.Items("Temp_AID") = lblTemp_AID.Text
        Context.Items("ID") = lblId.Text
        Context.Items("User_ID") = lbluserid.Text
        Server.Transfer("Appraisal_Price3_70_Detail_Review.aspx")
    End Sub

    Protected Sub ImagePrint_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImagePrint.Click
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        Context.Items("ID") = lblId.Text
        Context.Items("Req_Id") = lblReq_Id.Text
        Context.Items("Hub_Id") = lblHub_Id.Text
        Context.Items("Temp_AID") = lblTemp_AID.Text
        Context.Items("User_ID") = lbluserid.Text
        Server.Transfer("Appraisal_Price3_70_Review_Print.aspx")
    End Sub
End Class
