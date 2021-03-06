Imports Appraisal_Manager
Partial Class Appraisal_Price3_18_Review_Edit
    Inherits System.Web.UI.Page
    Dim s As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblReq_Id.Text = Context.Items("Req_Id")
            lblHub_Id.Text = Context.Items("Hub_Id")
            hhdfSubCollType.Value = Context.Items("Coll_Type")
            hdfId.Value = Context.Items("Id")
            lblId.Text = Context.Items("Id")
            'lblTemp_AID.Text = Context.Items("Temp_AID")
            'ตรวจสอบ ID ว่าเป็นการแก้ไข หรือ กำหนดไอดีใหม่
            If Context.Items("Id") Is Nothing Then

            Else
                Dim ObjP3_18 As List(Of Price3_18_Review) = GET_PRICE3_18_REVIEW_BYID(hdfId.Value, lblReq_Id.Text, lblHub_Id.Text)
                If ObjP3_18.Count > 0 Then
                    lblId.Text = ObjP3_18.Item(0).ID
                    lblReq_Id.Text = ObjP3_18.Item(0).Req_Id
                    lblHub_Id.Text = ObjP3_18.Item(0).Hub_Id
                    lblTemp_AID.Text = ObjP3_18.Item(0).Temp_AID
                    txtAID.Text = ObjP3_18.Item(0).AID
                    txtCID.Text = ObjP3_18.Item(0).CID
                    DDLSubCollType.SelectedValue = ObjP3_18.Item(0).MysubColl_ID
                    txtFloors.Text = ObjP3_18.Item(0).Floors_All
                    txtelevator_No.Text = ObjP3_18.Item(0).Elevator
                    txtAddressNo.Text = ObjP3_18.Item(0).Address_No
                    txtArea.Text = ObjP3_18.Item(0).Room_Area
                    txtHeight.Text = ObjP3_18.Item(0).Room_Height
                    txtPartake.Text = ObjP3_18.Item(0).Partake_Detail
                    txtBuildingName.Text = ObjP3_18.Item(0).Building_Name
                    txtFloorsAt.Text = ObjP3_18.Item(0).Floors
                    txtBuild_Number.Text = ObjP3_18.Item(0).Building_No
                    txtRegister_No.Text = ObjP3_18.Item(0).Building_Reg_No
                    txtBuilding_Age.Text = ObjP3_18.Item(0).Building_Age
                    txtTumbon.Text = ObjP3_18.Item(0).Tumbon
                    txtAmphur.Text = ObjP3_18.Item(0).Amphur
                    ddlProvince.SelectedValue = ObjP3_18.Item(0).Province
                    txtOwnership.Text = ObjP3_18.Item(0).Ownership
                    txtObligation.Text = ObjP3_18.Item(0).Obligation
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
                    txtOtherDetail.Text = ObjP3_18.Item(0).Other_Detail
                    txtTumbon1.Text = ObjP3_18.Item(0).Tumbon1
                    txtAmphur1.Text = ObjP3_18.Item(0).Amphur1
                    ddlProvince1.SelectedValue = ObjP3_18.Item(0).Province1
                    CheckBox1.Checked = ObjP3_18.Item(0).Elevator_Util
                    CheckBox2.Checked = ObjP3_18.Item(0).Parking_Util
                    CheckBox3.Checked = ObjP3_18.Item(0).Pool_Util
                    CheckBox4.Checked = ObjP3_18.Item(0).Fitness_Util
                    CheckBox5.Checked = ObjP3_18.Item(0).Other_Util
                    txtUtilityOther_Detail.Text = ObjP3_18.Item(0).Other_Util_Detail
                    txtAdjust_Condo.Text = ObjP3_18.Item(0).Adjust_Condo
                    txtUnitPrice.Text = String.Format("{0:N2}", ObjP3_18.Item(0).Unit_Price)
                    txtCondoPrice.Text = String.Format("{0:N2}", ObjP3_18.Item(0).PriceTotal)
                Else
                    'PRICE2_18()
                End If

            End If
        End If
    End Sub

    Protected Sub ImageSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSave.Click
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        If lblId.Text = "" Or lblId.Text = String.Empty Or lblId.Text = "0" Then
            'เหตุการณ์นี้เกิดจากการทบทวนประเมิน กรณีเพิ่มหลักประกันที่ดินใหม่ผูกเข้ากับ เลข AID เดิม จึงจำเป็นต้องออกเลข ID ใหม่ ให้กับที่ดิน
            lblId.Text = GET_ID_18_50_70(70)
            UPDATE_ID_70()
            ADD_PRICE3_18(lblId.Text, lblReq_Id.Text, lblHub_Id.Text, txtAID.Text, txtCID.Text, lblTemp_AID.Text, DDLSubCollType.SelectedValue, txtFloors.Text, txtelevator_No.Text, _
                      txtAddressNo.Text, txtArea.Text, txtHeight.Text, txtBuildingName.Text, txtFloorsAt.Text, txtBuild_Number.Text, txtRegister_No.Text, txtBuilding_Age.Text, _
                      txtTumbon.Text, txtAmphur.Text, ddlProvince.SelectedValue, txtRoad.Text, ddlRoad_Detail.SelectedValue, txtRoadAccress.Text, _
                      ddlRoad_Forntoff.SelectedValue, txtRoadWidth.Text, ddlSite.SelectedValue, txtSite_Detail.Text, ddlPublic_Utility.SelectedValue, _
                      txtPublic_Utility_Detail.Text, ddlBinifit.SelectedValue, txtBinifit.Text, ddlTendency.SelectedValue, ddlBuySale_State.SelectedValue, _
                      ddlBuild_Construct.SelectedValue, ddlInteriorState.SelectedValue, ddlCharacter_Room.SelectedValue, txtRoomWidth_BehideSiteWalk.Text, _
                      txtRoomdeep.Text, txtBackside_Width.Text, ddlFloors.SelectedValue, txtSideWalk_Width.Text, txtPartake.Text, txtOwnership.Text, _
                      txtObligation.Text, txtOtherDetail.Text, txtTumbon1.Text, txtAmphur1.Text, ddlProvince1.SelectedValue, CheckBox1.Checked, _
                      CheckBox2.Checked, CheckBox3.Checked, CheckBox4.Checked, CheckBox5.Checked, txtUtilityOther_Detail.Text, txtAdjust_Condo.Text, txtUnitPrice.Text, txtCondoPrice.Text, lbluserid.Text, Now())
        Else
            UPDATE_PRICE3_18_REVIEW(lblId.Text, lblReq_Id.Text, lblHub_Id.Text, txtAID.Text, txtCID.Text, lblTemp_AID.Text, DDLSubCollType.SelectedValue, txtFloors.Text, txtelevator_No.Text, _
                      txtAddressNo.Text, txtArea.Text, txtHeight.Text, txtBuildingName.Text, txtFloorsAt.Text, txtBuild_Number.Text, txtRegister_No.Text, txtBuilding_Age.Text, _
                      txtTumbon.Text, txtAmphur.Text, ddlProvince.SelectedValue, txtRoad.Text, ddlRoad_Detail.SelectedValue, txtRoadAccress.Text, _
                      ddlRoad_Forntoff.SelectedValue, txtRoadWidth.Text, ddlSite.SelectedValue, txtSite_Detail.Text, ddlPublic_Utility.SelectedValue, _
                      txtPublic_Utility_Detail.Text, ddlBinifit.SelectedValue, txtBinifit.Text, ddlTendency.SelectedValue, ddlBuySale_State.SelectedValue, _
                      ddlBuild_Construct.SelectedValue, ddlInteriorState.SelectedValue, ddlCharacter_Room.SelectedValue, txtRoomWidth_BehideSiteWalk.Text, _
                      txtRoomdeep.Text, txtBackside_Width.Text, ddlFloors.SelectedValue, txtSideWalk_Width.Text, txtPartake.Text, txtOwnership.Text, _
                      txtObligation.Text, txtOtherDetail.Text, txtTumbon1.Text, txtAmphur1.Text, ddlProvince1.SelectedValue, CheckBox1.Checked, _
                      CheckBox2.Checked, CheckBox3.Checked, CheckBox4.Checked, CheckBox5.Checked, txtUtilityOther_Detail.Text, txtAdjust_Condo.Text, txtUnitPrice.Text, txtCondoPrice.Text, lbluserid.Text, Now())
        End If

        s = "<script language=""javascript"">alert('บันทึกเสร็จสมบูรณ์');</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
    End Sub

    Protected Sub ImageButton_Verify_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton_Verify.Click
        Dim ObjP3_18 As List(Of Price3_18) = GET_PRICE3_18_FIND_ADDRESSNO(txtRegister_No.Text, txtBuild_Number.Text, txtAddressNo.Text)
        If ObjP3_18.Count > 0 Then
            DDLSubCollType.SelectedValue = ObjP3_18.Item(0).MysubColl_ID
            txtFloors.Text = ObjP3_18.Item(0).Floors_All
            txtelevator_No.Text = ObjP3_18.Item(0).Elevator
            txtAddressNo.Text = ObjP3_18.Item(0).Address_No
            txtArea.Text = ObjP3_18.Item(0).Room_Area
            txtHeight.Text = ObjP3_18.Item(0).Room_Height
            txtPartake.Text = ObjP3_18.Item(0).Partake_Detail
            txtBuildingName.Text = ObjP3_18.Item(0).Building_Name
            txtFloorsAt.Text = ObjP3_18.Item(0).Floors
            txtBuild_Number.Text = ObjP3_18.Item(0).Building_No
            txtRegister_No.Text = ObjP3_18.Item(0).Building_Reg_No
            txtBuilding_Age.Text = ObjP3_18.Item(0).Building_Age
            txtTumbon.Text = ObjP3_18.Item(0).Tumbon
            txtAmphur.Text = ObjP3_18.Item(0).Amphur
            ddlProvince.SelectedValue = ObjP3_18.Item(0).Province
            txtOwnership.Text = ObjP3_18.Item(0).Ownership
            txtObligation.Text = ObjP3_18.Item(0).Obligation
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
            txtOtherDetail.Text = ObjP3_18.Item(0).Other_Detail
            txtTumbon1.Text = ObjP3_18.Item(0).Tumbon1
            txtAmphur1.Text = ObjP3_18.Item(0).Amphur1
            ddlProvince1.SelectedValue = ObjP3_18.Item(0).Province1
            CheckBox1.Checked = ObjP3_18.Item(0).Elevator_Util
            CheckBox2.Checked = ObjP3_18.Item(0).Parking_Util
            CheckBox3.Checked = ObjP3_18.Item(0).Pool_Util
            CheckBox4.Checked = ObjP3_18.Item(0).Fitness_Util
            CheckBox5.Checked = ObjP3_18.Item(0).Other_Util
            txtUtilityOther_Detail.Text = ObjP3_18.Item(0).Other_Util_Detail
            txtAdjust_Condo.Text = ObjP3_18.Item(0).Adjust_Condo
            txtUnitPrice.Text = String.Format("{0:N2}", ObjP3_18.Item(0).Unit_Price)
            txtCondoPrice.Text = String.Format("{0:N2}", ObjP3_18.Item(0).PriceTotal)
        End If
    End Sub

End Class
