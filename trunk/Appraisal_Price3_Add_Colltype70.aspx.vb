﻿Imports Appraisal_Manager
Partial Class Appraisal_Price3_Add_Colltype70
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'lblReq_Id.Text = Request.QueryString("Req_Id")
            'lblHub_Id.Text = Request.QueryString("Hub_Id")
            'lblTemp_AID.Text = Request.QueryString("Temp_AID")
            'Dim lblCollType_Id As String = Request.QueryString("Coll_Type")
            'lblId.Text = Request.QueryString("ID")

            lblReq_Id.Text = Context.Items("Req_Id")
            lblHub_Id.Text = Context.Items("Hub_Id")
            lblTemp_AID.Text = Context.Items("Temp_AID")
            hhhfSubCollType.Value = Context.Items("Coll_Type")
            lblId.Text = Context.Items("ID")
            If CHECK_BEFORE_ADD_PRICE3(lblReq_Id.Text, lblTemp_AID.Text, lblHub_Id.Text, hhhfSubCollType.Value, lblId.Text) = 0 Then
                Show_Price2_70()
            Else
                Show_Price3_70()
            End If

        End If
    End Sub

    Private Sub Show_Price2_70()
        Dim Obj_GetP70 As List(Of PRICE2_70) = GET_PRICE2_70(lblId.Text, lblReq_Id.Text, lblHub_Id.Text)
        If Obj_GetP70.Count > 0 Then
            lblId.Text = Obj_GetP70.Item(0).ID
            lblReq_Id.Text = Obj_GetP70.Item(0).Req_Id
            lblHub_Id.Text = Obj_GetP70.Item(0).Hub_Id
            DDLSubCollType.SelectedValue = Obj_GetP70.Item(0).MysubColl_ID
            'txtChanodeNo.Text = Obj_GetP70.Item(0)
            txtBuild_No.Text = Obj_GetP70.Item(0).Build_No
            txtTumbon.Text = Obj_GetP70.Item(0).Tumbon
            txtAmphur.Text = Obj_GetP70.Item(0).Amphur
            ddlProvince.SelectedValue = Obj_GetP70.Item(0).Province
            ddlBuild_Character.SelectedValue = Obj_GetP70.Item(0).Build_Character
            txtFloor.Text = Obj_GetP70.Item(0).Floors
            txtItem.Text = Obj_GetP70.Item(0).Item
            ddlBuild_Construct.SelectedValue = Obj_GetP70.Item(0).Build_Construct
            ddlRoof.SelectedValue = Obj_GetP70.Item(0).Roof
            txtRoof_Detail.Text = Obj_GetP70.Item(0).Roof_Detail
            ddlBuild_State.SelectedValue = Obj_GetP70.Item(0).Build_State
            txtBuild_State_Detail.Text = Obj_GetP70.Item(0).Build_State_Detail
            txtBuilding_Detail.Text = Obj_GetP70.Item(0).Building_Detail
            txtPriceTotal1.Text = Obj_GetP70.Item(0).PriceTotal1
            chkDoc1.Checked = Obj_GetP70.Item(0).Doc1
            chkDoc2.Checked = Obj_GetP70.Item(0).Doc2
            txtDoc_Detail.Text = Obj_GetP70.Item(0).Doc_Detail
        End If
    End Sub

    Private Sub Show_Price3_70()
        Dim Obj_GetP70 As List(Of Price3_70) = GET_PRICE3_70(lblId.Text, lblReq_Id.Text, lblHub_Id.Text, lblTemp_AID.Text)
        If Obj_GetP70.Count > 0 Then
            lblId.Text = Obj_GetP70.Item(0).ID
            lblReq_Id.Text = Obj_GetP70.Item(0).Req_Id
            lblHub_Id.Text = Obj_GetP70.Item(0).Hub_Id
            DDLSubCollType.SelectedValue = Obj_GetP70.Item(0).MysubColl_ID
            txtChanodeNo.Text = Obj_GetP70.Item(0).Put_On_Chanode
            txtOwnership.Text = Obj_GetP70.Item(0).Ownership
            txtBuild_No.Text = Obj_GetP70.Item(0).Build_No
            txtTumbon.Text = Obj_GetP70.Item(0).Tumbon
            txtAmphur.Text = Obj_GetP70.Item(0).Amphur
            ddlProvince.SelectedValue = Obj_GetP70.Item(0).Province
            ddlBuild_Character.SelectedValue = Obj_GetP70.Item(0).Build_Character
            txtFloor.Text = Obj_GetP70.Item(0).Floors
            txtItem.Text = Obj_GetP70.Item(0).Item
            ddlBuild_Construct.SelectedValue = Obj_GetP70.Item(0).Build_Construct
            ddlRoof.SelectedValue = Obj_GetP70.Item(0).Roof
            txtRoof_Detail.Text = Obj_GetP70.Item(0).Roof_Detail
            ddlBuild_State.SelectedValue = Obj_GetP70.Item(0).Build_State
            txtBuild_State_Detail.Text = Obj_GetP70.Item(0).Build_State_Detail
            txtBuilding_Detail.Text = Obj_GetP70.Item(0).Building_Detail
            txtPriceTotal1.Text = Obj_GetP70.Item(0).PriceTotal1
            chkDoc1.Checked = Obj_GetP70.Item(0).Doc1
            chkDoc2.Checked = Obj_GetP70.Item(0).Doc2
            txtDoc_Detail.Text = Obj_GetP70.Item(0).Doc_Detail
            txtBuildingArea.Text = Obj_GetP70.Item(0).BuildingArea
            txtBuildingUnitPrice.Text = Obj_GetP70.Item(0).BuildingUintPrice
            txtBuildingPrice.Text = Obj_GetP70.Item(0).BuildingPrice
            txtBuildingAge.Text = Obj_GetP70.Item(0).BuildingAge
            txtBuildingPersent1.Text = Obj_GetP70.Item(0).BuildingPersent1
            txtBuildingPersent2.Text = Obj_GetP70.Item(0).BuildingPersent2
            txtBuildingPersent3.Text = Obj_GetP70.Item(0).BuildingPersent3
            txtBuildingTotalDeteriorate.Text = Obj_GetP70.Item(0).BuildingPriceTotalDeteriorate
            txtBuildAddArea.Text = Obj_GetP70.Item(0).BuildAddArea
            txtBuildAddUnitPrice.Text = Obj_GetP70.Item(0).BuildAddUintPrice
            txtBuildAddPrice.Text = Obj_GetP70.Item(0).BuildAddPrice
            txtBuildAddAge.Text = Obj_GetP70.Item(0).BuildAddAge
            txtBuildAddPersent1.Text = Obj_GetP70.Item(0).BuildAddPersent1
            txtBuildAddPersent2.Text = Obj_GetP70.Item(0).BuildAddPersent2
            txtBuildAddPersent3.Text = Obj_GetP70.Item(0).BuildAddPersent3
            txtBuildAddTotalDeteriorate.Text = Obj_GetP70.Item(0).BuildAddPriceTotalDeteriorate
            txtBuildingDetail.Text = Obj_GetP70.Item(0).BuildingDetail
        End If
    End Sub

    Protected Sub ImageSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSave.Click
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label) 'หา Control จาก Master Page ที่ control ไม่อยู่ใน  ContentPlaceHolder1 ของ Master Page
        AddPRICE3_70(lblId.Text, CInt(lblReq_Id.Text), CInt(lblHub_Id.Text), lblTemp_AID.Text, _
                CInt(DDLSubCollType.SelectedValue), txtBuild_No.Text, txtTumbon.Text, txtAmphur.Text, _
                ddlProvince.SelectedValue, ddlBuild_Character.SelectedValue, _
                txtFloor.Text, txtItem.Text, ddlBuild_Construct.SelectedValue, _
                ddlRoof.SelectedValue, txtRoof_Detail.Text, ddlBuild_State.SelectedValue, _
                txtBuild_State_Detail.Text, txtBuilding_Detail.Text, txtPriceTotal1.Text, _
                chkDoc1.Checked, chkDoc2.Checked, txtDoc_Detail.Text, String.Empty, txtChanodeNo.Text, txtOwnership.Text, txtBuildingArea.Text, txtBuildingUnitPrice.Text, _
                txtBuildingPrice.Text, txtBuildingAge.Text, txtBuildingPersent1.Text, txtBuildingPersent2.Text, txtBuildingPersent3.Text, _
                txtBuildingPriceTotalDeteriorate.Text, txtBuildAddArea.Text, txtBuildAddUnitPrice.Text, txtBuildAddPrice.Text, _
                txtBuildAddAge.Text, txtBuildAddPersent1.Text, txtBuildAddPersent2.Text, txtBuildAddPersent3.Text, txtBuildAddPriceTotalDeteriorate.Text, _
                txtBuildingDetail.Text, lbluserid.Text, Now())
        Response.Redirect("Appraisal_Price3_List.aspx")
    End Sub

    Protected Sub btnAddDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddDetail.Click
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        Context.Items("Req_Id") = lblReq_Id.Text
        Context.Items("Hub_Id") = lblHub_Id.Text
        Context.Items("Temp_AID") = lblTemp_AID.Text
        Context.Items("ID") = lblId.Text
        Context.Items("User_ID") = lbluserid.Text
        Server.Transfer("Appraisal_Price3_Add_Colltype70Detail.aspx")
    End Sub
End Class
