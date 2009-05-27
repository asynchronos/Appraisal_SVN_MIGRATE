﻿Imports Appraisal_Manager

Partial Class Appraisal_Price3_18
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblReq_Id.Text = Context.Items("Req_Id")
            lblHub_Id.Text = Context.Items("Hub_Id")
            hhdfSubCollType.Value = Context.Items("Coll_Type")
            hdfId.Value = Context.Items("ID")
            lblId.Text = Context.Items("ID")
            'ตรวจสอบ ID ว่าเป็นการแก้ไข หรือ กำหนดไอดีใหม่
            If Context.Items("ID") Is Nothing Then

            Else
                Dim ObjP3_18 As List(Of Price3_18) = GET_PRICE3_18(hdfId.Value, lblReq_Id.Text, lblHub_Id.Text)
                If ObjP3_18.Count > 0 Then
                    lblId.Text = ObjP3_18.Item(0).ID
                    lblReq_Id.Text = ObjP3_18.Item(0).Req_Id
                    lblHub_Id.Text = ObjP3_18.Item(0).Hub_Id
                    txtAID.Text = ObjP3_18.Item(0).AID
                    txtCID.Text = ObjP3_18.Item(0).CID
                    DDLSubCollType.SelectedValue = ObjP3_18.Item(0).MysubColl_ID
                    txtFloors.Text = ObjP3_18.Item(0).Floors_All
                    txtelevator_No.Text = ObjP3_18.Item(0).Elevator
                    txtAddressNo.Text = ObjP3_18.Item(0).Address_No
                    txtArea.Text = ObjP3_18.Item(0).Room_Area
                    txtHeight.Text = ObjP3_18.Item(0).Room_Height
                    txtBuildingName.Text = ObjP3_18.Item(0).Building_Name
                    txtFloorsAt.Text = ObjP3_18.Item(0).Floors
                    txtBuild_Number.Text = ObjP3_18.Item(0).Building_No
                    txtRegister_No.Text = ObjP3_18.Item(0).Building_Reg_No
                    txtTumbon.Text = ObjP3_18.Item(0).Tumbon
                    txtAmphur.Text = ObjP3_18.Item(0).Amphur
                    ddlProvince.SelectedValue = ObjP3_18.Item(0).Province
                    txtRoad.Text = ObjP3_18.Item(0).Road
                    ddlRoad_Detail.SelectedValue = ObjP3_18.Item(0).Road_Detail
                    txtRoadAccress.Text = ObjP3_18.Item(0).Road_Access
                    ddlRoad_Forntoff.SelectedValue = ObjP3_18.Item(0).Road_Frontoff
                    txtRoadWidth.Text = ObjP3_18.Item(0).RoadWidth
                    ddlSite.SelectedValue = ObjP3_18.Item(0).Site
                    txtSite_Detail.Text = ObjP3_18.Item(0).Site_Detail
                    ddlPublic_Utility.SelectedValue = ObjP3_18.Item(0).Public_Utility
                    txtPublic_Utility_Detail.Text = ObjP3_18.Item(0).Public_Utility_Detail
                    ddlBinifit.SelectedValue = ObjP3_18.Item(0).Binifit
                    txtBinifit.Text = ObjP3_18.Item(0).Binifit_Detail
                    ddlTendency.SelectedValue = ObjP3_18.Item(0).Tendency
                    ddlBuySale_State.SelectedValue = ObjP3_18.Item(0).BuySale_State
                    ddlBuild_Construct.SelectedValue = ObjP3_18.Item(0).Building_Construc
                    ddlInteriorState.SelectedValue = ObjP3_18.Item(0).InteriorState_Id
                    ddlCharacter_Room.SelectedValue = ObjP3_18.Item(0).Character_Room_Id
                    txtRoomWidth_BehideSiteWalk.Text = ObjP3_18.Item(0).RoomWidth_BehideSiteWalk
                    txtRoomdeep.Text = ObjP3_18.Item(0).Roomdeep
                    txtBackside_Width.Text = ObjP3_18.Item(0).Backside_Width
                    ddlFloors.SelectedValue = ObjP3_18.Item(0).SideWalk_Is
                    txtSideWalk_Width.Text = ObjP3_18.Item(0).SideWalk_Width
                    txtPartake.Text = ObjP3_18.Item(0).Partake_Detail
                    txtOwnership.Text = ObjP3_18.Item(0).Ownership
                    txtObligation.Text = ObjP3_18.Item(0).Obligation
                    txtUnitPrice.Text = String.Format("{0:N2}", ObjP3_18.Item(0).Unit_Price)
                    txtCondoPrice.Text = String.Format("{0:N2}", ObjP3_18.Item(0).PriceTotal)

                Else
                    Price2_18()
                End If

            End If
        End If
    End Sub

    Private Sub Price2_18()
        Dim ObjP2_18 As List(Of PRICE2_18) = Get_Price2_18(hdfId.Value, lblReq_Id.Text, lblHub_Id.Text)
        If ObjP2_18.Count > 0 Then
            lblId.Text = ObjP2_18.Item(0).ID
            lblReq_Id.Text = ObjP2_18.Item(0).Req_Id
            lblHub_Id.Text = ObjP2_18.Item(0).Hub_Id
            txtAID.Text = ObjP2_18.Item(0).AID
            txtCID.Text = ObjP2_18.Item(0).CID
            DDLSubCollType.SelectedValue = ObjP2_18.Item(0).MysubColl_ID
            txtFloors.Text = ObjP2_18.Item(0).Floors_All
            txtelevator_No.Text = ObjP2_18.Item(0).Elevator
            txtAddressNo.Text = ObjP2_18.Item(0).Address_No
            txtArea.Text = ObjP2_18.Item(0).Room_Area
            txtHeight.Text = ObjP2_18.Item(0).Room_Height
            txtBuildingName.Text = ObjP2_18.Item(0).Building_Name
            txtFloorsAt.Text = ObjP2_18.Item(0).Floors
            txtBuild_Number.Text = ObjP2_18.Item(0).Building_No
            txtRegister_No.Text = ObjP2_18.Item(0).Building_Reg_No
            txtTumbon.Text = ObjP2_18.Item(0).Tumbon
            txtAmphur.Text = ObjP2_18.Item(0).Amphur
            ddlProvince.SelectedValue = ObjP2_18.Item(0).Province
            txtRoad.Text = ObjP2_18.Item(0).Road
            ddlRoad_Detail.SelectedValue = ObjP2_18.Item(0).Road_Detail
            txtRoadAccress.Text = ObjP2_18.Item(0).Road_Access
            ddlRoad_Forntoff.SelectedValue = ObjP2_18.Item(0).Road_Frontoff
            txtRoadWidth.Text = ObjP2_18.Item(0).RoadWidth
            ddlSite.SelectedValue = ObjP2_18.Item(0).Site
            txtSite_Detail.Text = ObjP2_18.Item(0).Site_Detail
            ddlPublic_Utility.SelectedValue = ObjP2_18.Item(0).Public_Utility
            txtPublic_Utility_Detail.Text = ObjP2_18.Item(0).Public_Utility_Detail
            ddlBinifit.SelectedValue = ObjP2_18.Item(0).Binifit
            txtBinifit.Text = ObjP2_18.Item(0).Binifit_Detail
            ddlTendency.SelectedValue = ObjP2_18.Item(0).Tendency
            ddlBuySale_State.SelectedValue = ObjP2_18.Item(0).BuySale_State
            ddlBuild_Construct.SelectedValue = ObjP2_18.Item(0).Building_Construc
            ddlInteriorState.SelectedValue = ObjP2_18.Item(0).InteriorState_Id
            ddlCharacter_Room.SelectedValue = ObjP2_18.Item(0).Character_Room_Id
            txtRoomWidth_BehideSiteWalk.Text = ObjP2_18.Item(0).RoomWidth_BehideSiteWalk
            txtRoomdeep.Text = ObjP2_18.Item(0).Roomdeep
            txtBackside_Width.Text = ObjP2_18.Item(0).Backside_Width
            ddlFloors.SelectedValue = ObjP2_18.Item(0).SideWalk_Is
            txtSideWalk_Width.Text = ObjP2_18.Item(0).SideWalk_Width
            txtUnitPrice.Text = String.Format("{0:N2}", ObjP2_18.Item(0).Unit_Price)
            txtCondoPrice.Text = String.Format("{0:N2}", ObjP2_18.Item(0).PriceTotal)
        End If
    End Sub

    Protected Sub ImageSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSave.Click
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        Dim ObjP3_18 As List(Of Price3_18) = GET_PRICE3_18(hdfId.Value, lblReq_Id.Text, lblHub_Id.Text)
        If ObjP3_18.Count = 0 Then
            ADD_PRICE3_18(lblId.Text, lblReq_Id.Text, lblHub_Id.Text, txtAID.Text, txtCID.Text, 0, DDLSubCollType.SelectedValue, txtFloors.Text, txtelevator_No.Text, _
                              txtAddressNo.Text, txtArea.Text, txtHeight.Text, txtBuildingName.Text, txtFloorsAt.Text, txtBuild_Number.Text, txtRegister_No.Text, _
                              txtTumbon.Text, txtAmphur.Text, ddlProvince.SelectedValue, txtRoad.Text, ddlRoad_Detail.SelectedValue, txtRoadAccress.Text, _
                              ddlRoad_Forntoff.SelectedValue, txtRoadWidth.Text, ddlSite.SelectedValue, txtSite_Detail.Text, ddlPublic_Utility.SelectedValue, _
                              txtPublic_Utility_Detail.Text, ddlBinifit.SelectedValue, txtBinifit.Text, ddlTendency.SelectedValue, ddlBuySale_State.SelectedValue, _
                              ddlBuild_Construct.SelectedValue, ddlInteriorState.SelectedValue, ddlCharacter_Room.SelectedValue, txtRoomWidth_BehideSiteWalk.Text, _
                              txtRoomdeep.Text, txtBackside_Width.Text, ddlFloors.SelectedValue, txtSideWalk_Width.Text, txtPartake.Text, txtOwnership.Text, _
                              txtObligation.Text, txtUnitPrice.Text, txtCondoPrice.Text, lbluserid.Text, Now())
        Else
            UPDATE_PRICE3_18(lblId.Text, lblReq_Id.Text, lblHub_Id.Text, txtAID.Text, txtCID.Text, 0, DDLSubCollType.SelectedValue, txtFloors.Text, txtelevator_No.Text, _
                              txtAddressNo.Text, txtArea.Text, txtHeight.Text, txtBuildingName.Text, txtFloorsAt.Text, txtBuild_Number.Text, txtRegister_No.Text, _
                              txtTumbon.Text, txtAmphur.Text, ddlProvince.SelectedValue, txtRoad.Text, ddlRoad_Detail.SelectedValue, txtRoadAccress.Text, _
                              ddlRoad_Forntoff.SelectedValue, txtRoadWidth.Text, ddlSite.SelectedValue, txtSite_Detail.Text, ddlPublic_Utility.SelectedValue, _
                              txtPublic_Utility_Detail.Text, ddlBinifit.SelectedValue, txtBinifit.Text, ddlTendency.SelectedValue, ddlBuySale_State.SelectedValue, _
                              ddlBuild_Construct.SelectedValue, ddlInteriorState.SelectedValue, ddlCharacter_Room.SelectedValue, txtRoomWidth_BehideSiteWalk.Text, _
                              txtRoomdeep.Text, txtBackside_Width.Text, ddlFloors.SelectedValue, txtSideWalk_Width.Text, txtPartake.Text, txtOwnership.Text, _
                              txtObligation.Text, txtUnitPrice.Text, txtCondoPrice.Text, lbluserid.Text, Now())
        End If

    End Sub
End Class