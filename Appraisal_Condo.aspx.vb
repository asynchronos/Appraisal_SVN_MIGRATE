Imports Appraisal_Manager
Partial Class Appraisal_Condo
    Inherits System.Web.UI.Page

    Dim StringNotice As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Request.QueryString("ID").ToString = "" Then
                lblReq_Id.Text = Request.QueryString("Req_Id").ToString
                lblHub_Id.Text = Request.QueryString("Hub_Id").ToString
                lblCif.Text = Request.QueryString("Cif").ToString
                lblCifName.Text = Request.QueryString("CifName").ToString
                hdfAppraisal_Id.Value = Request.QueryString("Appraisal_Id").ToString
                lblTemp_AID.Text = "0"
                Appraisal_Request_Info()
            Else
                lblId.Text = Request.QueryString("ID").ToString
                lblReq_Id.Text = Request.QueryString("Req_Id").ToString
                lblHub_Id.Text = Request.QueryString("Hub_Id").ToString
                lblCif.Text = Request.QueryString("Cif").ToString
                lblCifName.Text = Request.QueryString("CifName").ToString
                hdfAppraisal_Id.Value = Request.QueryString("Appraisal_Id").ToString
                lblId.Text = Request.QueryString("ID").ToString

                DATA_CONDO()
                'HiddenApprisalType.Value = Request.QueryString("Appraisal_Type")
            End If
        End If
    End Sub

    Sub Appraisal_Request_Info()
        Dim Request As List(Of Appraisal_Request_v2) = GET_APPRAISAL_REQUEST_V2(lblReq_Id.Text)
        txtAddressNo.Text = Request.Item(0).CollOfNumber
        If IsNumeric(Request.Item(0).Tumbon) Then
            Dim Tumbon As List(Of Cls_Tumbon) = GET_TUMBON_INFO(Request.Item(0).Tumbon, Request.Item(0).Amphur, Request.Item(0).Province)
            txtTumbon.Text = Tumbon.Item(0).tumbon_new2_name
            txtTumbon1.Text = Tumbon.Item(0).tumbon_new2_name
        Else
        End If

        If IsNumeric(Request.Item(0).Amphur) Then
            Dim Amphur As List(Of Cls_Amphur) = GET_AMPHUR_INFO(Request.Item(0).Amphur, Request.Item(0).Province)
            txtAmphur.Text = Amphur.Item(0).am_name
            txtAmphur1.Text = Amphur.Item(0).am_name
        Else
        End If
        ddlProvince.SelectedValue = Request.Item(0).Province
        ddlProvince1.SelectedValue = Request.Item(0).Province
    End Sub

    Protected Sub ImageSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSave.Click
        Dim ID As Integer
        If lblId.Text = String.Empty Then
            Try
                If lblId.Text = String.Empty Then
                    ID = GET_ID_18_50_70(18)
                    UPDATE_ID_18()
                    lblId.Text = ID
                Else
                    'ID = CInt(lblId.Text)
                End If

                ADD_PRICE2_PRICE3_18(lblId.Text, lblReq_Id.Text, lblHub_Id.Text, 0, 0, lblTemp_AID.Text, DDLSubCollType.SelectedValue, txtFloors.Text, txtelevator_No.Text, _
                      txtAddressNo.Text, txtArea.Text, txtHeight.Text, txtBuildingName.Text, txtFloorsAt.Text, txtBuild_Number.Text, txtRegister_No.Text, txtBuilding_Age.Text, _
                      txtTumbon.Text, txtAmphur.Text, ddlProvince.SelectedValue, txtRoad.Text, ddlRoad_Detail.SelectedValue, txtRoadAccress.Text, _
                      ddlRoad_Forntoff.SelectedValue, txtRoadWidth.Text, ddlSite.SelectedValue, txtSite_Detail.Text, ddlPublic_Utility.SelectedValue, _
                      txtPublic_Utility_Detail.Text, ddlBinifit.SelectedValue, txtBinifit.Text, ddlTendency.SelectedValue, ddlBuySale_State.SelectedValue, _
                      ddlBuild_Construct.SelectedValue, ddlInteriorState.SelectedValue, ddlCharacter_Room.SelectedValue, txtRoomWidth_BehideSiteWalk.Text, _
                      txtRoomdeep.Text, txtBackside_Width.Text, ddlFloors.SelectedValue, txtSideWalk_Width.Text, txtPartake.Text, txtOwnership.Text, _
                      txtObligation.Text, txtOtherDetail.Text, txtTumbon1.Text, txtAmphur1.Text, ddlProvince1.SelectedValue, CheckBox1.Checked, _
                      CheckBox2.Checked, CheckBox3.Checked, CheckBox4.Checked, CheckBox5.Checked, txtUtilityOther_Detail.Text, txtAdjust_Condo.Text, txtUnitPrice.Text, txtCondoPrice.Text, hdfAppraisal_Id.Value, Now())
                'UPDATE_Status_Appraisal_Request(lblReq_Id.Text, lblHub_Id.Text, 10)
                StringNotice = "<script language=""javascript"">alert('บันทึกรายละเอียด Condo/อพาร์ตเม็นต์ เสร็จสมบูรณ์');</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "SaveSuccess", StringNotice)
            Catch ex As Exception
                StringNotice = "<script language=""javascript"">alert('ไม่สามารถบันทึกรายละเอียด Condo/อพาร์ตเม็นต์');</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "Error", StringNotice)
            End Try

        Else
            Try

                UPDATE_PRICE2_PRICE3_18(lblId.Text, lblReq_Id.Text, lblHub_Id.Text, 0, 0, lblTemp_AID.Text, DDLSubCollType.SelectedValue, txtFloors.Text, txtelevator_No.Text, _
                      txtAddressNo.Text, txtArea.Text, txtHeight.Text, txtBuildingName.Text, txtFloorsAt.Text, txtBuild_Number.Text, txtRegister_No.Text, txtBuilding_Age.Text, _
                      txtTumbon.Text, txtAmphur.Text, ddlProvince.SelectedValue, txtRoad.Text, ddlRoad_Detail.SelectedValue, txtRoadAccress.Text, _
                      ddlRoad_Forntoff.SelectedValue, txtRoadWidth.Text, ddlSite.SelectedValue, txtSite_Detail.Text, ddlPublic_Utility.SelectedValue, _
                      txtPublic_Utility_Detail.Text, ddlBinifit.SelectedValue, txtBinifit.Text, ddlTendency.SelectedValue, ddlBuySale_State.SelectedValue, _
                      ddlBuild_Construct.SelectedValue, ddlInteriorState.SelectedValue, ddlCharacter_Room.SelectedValue, txtRoomWidth_BehideSiteWalk.Text, _
                      txtRoomdeep.Text, txtBackside_Width.Text, ddlFloors.SelectedValue, txtSideWalk_Width.Text, txtPartake.Text, txtOwnership.Text, _
                      txtObligation.Text, txtOtherDetail.Text, txtTumbon1.Text, txtAmphur1.Text, ddlProvince1.SelectedValue, CheckBox1.Checked, _
                      CheckBox2.Checked, CheckBox3.Checked, CheckBox4.Checked, CheckBox5.Checked, txtUtilityOther_Detail.Text, txtAdjust_Condo.Text, txtUnitPrice.Text, txtCondoPrice.Text, hdfAppraisal_Id.Value, Now())
            Catch ex As Exception

            End Try

        End If
    End Sub

    Sub DATA_CONDO()
        Dim ObjP3_18 As List(Of Price3_18) = GET_PRICE3_18BY_ID(lblId.Text, lblReq_Id.Text, lblHub_Id.Text)
        If ObjP3_18.Count > 0 Then
            lblId.Text = ObjP3_18.Item(0).ID
            lblReq_Id.Text = ObjP3_18.Item(0).Req_Id
            lblHub_Id.Text = ObjP3_18.Item(0).Hub_Id
            'txtAID.Text = ObjP3_18.Item(0).AID
            'txtCID.Text = ObjP3_18.Item(0).CID
            DDLSubCollType.SelectedValue = ObjP3_18.Item(0).MysubColl_ID
            lblTemp_AID.Text = ObjP3_18.Item(0).Temp_AID
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

    Protected Sub ImageButton_Verify_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton_Verify.Click
        If txtRegister_No.Text = String.Empty Or txtBuild_Number.Text = String.Empty Or txtAddressNo.Text = String.Empty Then
            StringNotice = "<script language=""javascript"">alert('คุณต้องใส่เลขทะเบียนห้องชุด เลขที่ตึก และ เลขที่ห้อง ก่อนค้นหา'); </script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", StringNotice)
        Else
            Find_Condo_Info(txtRegister_No.Text, txtBuild_Number.Text, txtAddressNo.Text)
        End If

    End Sub

    Sub Find_Condo_Info(ByVal Register_No As String, ByVal Build_Number As String, ByVal AddressNo As String)
        Dim ObjP3_18 As List(Of Price3_18) = GET_PRICE3_18_FIND_ADDRESSNO(Register_No, Build_Number, AddressNo)
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
        Else
            StringNotice = "<script language=""javascript"">alert('ไม่พบรายละเอียดห้องชุด อพาร์ทเม็นต์ที่คุณค้นหา'); </script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "Invalid Search", StringNotice)
        End If
    End Sub
End Class
