Imports Appraisal_Manager
Partial Class Appraisal_Price2_Add_By_Colltype18
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
                Dim Objp1 As List(Of ClsPrice1_Master) = GetPrice1_Master(lblReq_Id.Text, lblHub_Id.Text)
                If Objp1.Count > 0 Then
                    txtUnitPrice.Text = String.Format("{0:N2}", Objp1.Item(0).Pricewah)
                    txtCondoPrice.Text = String.Format("{0:N2}", Objp1.Item(0).Price)
                Else
                End If
            Else
                Dim ObjP2_18 As List(Of PRICE2_18) = GET_PRICE2_18(hdfId.Value, lblReq_Id.Text, lblHub_Id.Text)
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
                    txtUnitPrice.Text = ObjP2_18.Item(0).Unit_Price 'String.Format("{0:N2}", ObjP2_18.Item(0).Unit_Price)
                    txtCondoPrice.Text = String.Format("{0:N2}", ObjP2_18.Item(0).PriceTotal)
                End If
            End If
        End If
    End Sub

    Protected Sub txtPriceWah_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUnitPrice.TextChanged
        If txtArea.Text = String.Empty Or txtArea.Text = "0" Then
            'Message Error
            txtArea.Text = "0"
            MsgBox("คุณไม่ได้ใส่เนื้อที่ที่จะใช้คำนวน")
            Exit Sub
        Else
            txtCondoPrice.Text = String.Format("{0:N2}", CDec(txtArea.Text) * CDec(txtUnitPrice.Text))
        End If
    End Sub

    Protected Sub txtArea_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtArea.TextChanged
        txtCondoPrice.Text = String.Format("{0:N2}", CDec(txtArea.Text) * CDec(txtUnitPrice.Text))
    End Sub

    Protected Sub ImageSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSave.Click
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        Dim ID As Integer
        If lblId.Text = String.Empty Then
            ID = GET_ID_18_50_70(18)
            UPDATE_ID_18()
        Else
            ID = CInt(lblId.Text)
        End If
        Dim ObjP2_18 As List(Of PRICE2_18) = GET_PRICE2_18(ID, lblReq_Id.Text, lblHub_Id.Text)
        If ObjP2_18.Count = 0 Then
            ADD_PRICE2_18(ID, lblReq_Id.Text, lblHub_Id.Text, txtAID.Text, txtCID.Text, 0, DDLSubCollType.SelectedValue, txtFloors.Text, txtelevator_No.Text, _
                           txtAddressNo.Text, txtArea.Text, txtHeight.Text, txtBuildingName.Text, txtFloorsAt.Text, txtBuild_Number.Text, txtRegister_No.Text, _
                          txtTumbon.Text, txtAmphur.Text, ddlProvince.SelectedValue, txtRoad.Text, ddlRoad_Detail.SelectedValue, txtRoadAccress.Text, _
                          ddlRoad_Forntoff.SelectedValue, txtRoadWidth.Text, ddlSite.SelectedValue, txtSite_Detail.Text, ddlPublic_Utility.SelectedValue, _
                          txtPublic_Utility_Detail.Text, ddlBinifit.SelectedValue, txtBinifit.Text, ddlTendency.SelectedValue, ddlBuySale_State.SelectedValue, _
                          ddlBuild_Construct.SelectedValue, ddlInteriorState.SelectedValue, ddlCharacter_Room.SelectedValue, txtRoomWidth_BehideSiteWalk.Text, _
                          txtRoomdeep.Text, txtBackside_Width.Text, ddlFloors.SelectedValue, txtSideWalk_Width.Text, txtUnitPrice.Text, txtCondoPrice.Text, lbluserid.Text, Now())
            UPDATE_Status_Appraisal_Request(lblReq_Id.Text, lblHub_Id.Text, 5)
        Else
            UPDATE_PRICE2_18(ID, lblReq_Id.Text, lblHub_Id.Text, txtAID.Text, txtCID.Text, 0, DDLSubCollType.SelectedValue, txtFloors.Text, txtelevator_No.Text, _
                           txtAddressNo.Text, txtArea.Text, txtHeight.Text, txtBuildingName.Text, txtFloorsAt.Text, txtBuild_Number.Text, txtRegister_No.Text, _
                          txtTumbon.Text, txtAmphur.Text, ddlProvince.SelectedValue, txtRoad.Text, ddlRoad_Detail.SelectedValue, txtRoadAccress.Text, _
                          ddlRoad_Forntoff.SelectedValue, txtRoadWidth.Text, ddlSite.SelectedValue, txtSite_Detail.Text, ddlPublic_Utility.SelectedValue, _
                          txtPublic_Utility_Detail.Text, ddlBinifit.SelectedValue, txtBinifit.Text, ddlTendency.SelectedValue, ddlBuySale_State.SelectedValue, _
                          ddlBuild_Construct.SelectedValue, ddlInteriorState.SelectedValue, ddlCharacter_Room.SelectedValue, txtRoomWidth_BehideSiteWalk.Text, _
                          txtRoomdeep.Text, txtBackside_Width.Text, ddlFloors.SelectedValue, txtSideWalk_Width.Text, txtUnitPrice.Text, txtCondoPrice.Text, lbluserid.Text, Now())
            'UPDATE_Status_Appraisal_Request(lblReq_Id.Text, lblHub_Id.Text, 5)
        End If

    End Sub

    Protected Sub ImageButton_Verify_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton_Verify.Click
        Dim ObjP2_18 As List(Of PRICE2_18) = GET_PRICE2_18_FIND_ADDRESSNO(txtRegister_No.Text, txtBuild_Number.Text, txtAddressNo.Text)
        If ObjP2_18.Count > 0 Then
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
            txtUnitPrice.Text = ObjP2_18.Item(0).Unit_Price 'String.Format("{0:N2}", ObjP2_18.Item(0).Unit_Price)
            txtCondoPrice.Text = String.Format("{0:N2}", ObjP2_18.Item(0).PriceTotal)
        End If
    End Sub

End Class
