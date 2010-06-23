Imports Appraisal_Manager
Imports System.Data

Partial Class Appraisal_Building
    Inherits System.Web.UI.Page

    Dim StringNotice As String
    Dim StringMessage As String

    Dim MarketPrice As Double = 0

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
                If Request.QueryString("ID").ToString <> "0" Then

                    lblId.Text = Request.QueryString("ID").ToString
                    lblReq_Id.Text = Request.QueryString("Req_Id").ToString
                    lblHub_Id.Text = Request.QueryString("Hub_Id").ToString
                    lblCif.Text = Request.QueryString("Cif").ToString
                    lblCifName.Text = Request.QueryString("CifName").ToString
                    hdfAppraisal_Id.Value = Request.QueryString("Appraisal_Id").ToString
                    lblId.Text = Request.QueryString("ID").ToString
                    lblTemp_AID.Text = Request.QueryString("Temp_AID").ToString
                    'DDLSubCollType.SelectedValue = Request.QueryString("MysubColl_ID").ToString
                    HiddenApprisalType.Value = Request.QueryString("Appraisal_Type")
                End If
                GET_BUILDING_DATA(Request.QueryString("MysubColl_ID").ToString)
            End If
        End If

    End Sub

    Protected Sub ImageSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSave.Click

        If lblId.Text = String.Empty Then
            'เพิ่มชิ้นทรัพย์ใหม่       
            INSERT_NEW_BUILDING()
        Else
            '***********ถ้ามีข้อมูลแล้วต้อง Update ข้อมูล  แก้ไขข้อมูลเดิม     *****************
            UPDATE_BUILDING()
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

    Sub GET_BUILDING_DATA(ByVal SubCollType As Integer)
        Dim Building_Data As List(Of Price2_70_New) = GET_PRICE2_70_NEW(lblId.Text, lblReq_Id.Text, lblHub_Id.Text)
        If Building_Data.Count > 0 Then
            lblTemp_AID.Text = Building_Data.Item(0).Temp_AID
            DDLSubCollType.SelectedValue = SubCollType 'Building_Data.Item(0).MysubColl_ID
            txtChanodeNo.Text = Building_Data.Item(0).Put_On_Chanode
            txtOwnership.Text = Building_Data.Item(0).Ownership
            txtBuild_No.Text = Building_Data.Item(0).Build_No
            txtTumbon.Text = Building_Data.Item(0).Tumbon
            txtAmphur.Text = Building_Data.Item(0).Amphur
            ddlProvince.SelectedValue = Building_Data.Item(0).Province
            ddlBuild_Character.SelectedValue = Building_Data.Item(0).Build_Character
            txtFloor.Text = Building_Data.Item(0).Floors
            txtItem.Text = Building_Data.Item(0).Item
            ddlBuild_Construct.SelectedValue = Building_Data.Item(0).Build_Construct
            ddlRoof.SelectedValue = Building_Data.Item(0).Roof
            txtRoof_Detail.Text = Building_Data.Item(0).Roof_Detail
            ddlBuild_State.SelectedValue = Building_Data.Item(0).Build_State
            txtBuild_State_Detail.Text = Building_Data.Item(0).Build_State_Detail
            txtBuilding_Detail.Text = Building_Data.Item(0).Building_Detail
            'txtPriceTotal1.Text = String.Format("{0:N2}", Building_Data.Item(0).PriceTotal1)
            chkDoc1.Checked = Building_Data.Item(0).Doc1
            chkDoc2.Checked = Building_Data.Item(0).Doc2

            ddlInteriorState.SelectedValue = Building_Data.Item(0).Decoration
            ddlRoofConstructure.SelectedValue = Building_Data.Item(0).RoofStructure_Id
            ddlRoofState.SelectedValue = Building_Data.Item(0).RoofState_Id
            'ddlStandard.SelectedValue = Building_Data.Item(0).Standard_Id
            Dim StandardInfo As List(Of Cls_Standard) = GET_STANDARD_INFO_BY_ID(Building_Data.Item(0).Standard_Id)
            TextBoxStandardNo.Text = StandardInfo.Item(0).STANDARD_ID
            TextBoxStandardName.Text = StandardInfo.Item(0).STANDARD_NAME
            'txtDoc_Detail.Text = Building_Data.Item(0).Doc_Detail

            If SubCollType <= 45 Or SubCollType = 50 Then
                txtBuildingArea.Text = Building_Data.Item(0).BuildingArea
                txtBuildingUnitPrice.Text = Building_Data.Item(0).BuildingUintPrice
                txtBuildingPrice.Text = String.Format("{0:N2}", CDec(Building_Data.Item(0).BuildingArea) * CDec(Building_Data.Item(0).BuildingUintPrice))
                txtPriceTotal1.Text = String.Format("{0:N2}", Building_Data.Item(0).PriceTotal1)
                txtBuildingAge.Text = Building_Data.Item(0).BuildingAge
                txtBuildingPersent1.Text = Building_Data.Item(0).BuildingPersent1
                txtBuildingPersent2.Text = Building_Data.Item(0).BuildingPersent2
                txtBuildingPersent3.Text = Building_Data.Item(0).BuildingPersent3
                txtBuildingTotalDeteriorate.Text = (Building_Data.Item(0).BuildingAge * (Building_Data.Item(0).BuildingPersent1)) - Building_Data.Item(0).BuildingPersent2 + Building_Data.Item(0).BuildingPersent3
                txtFinishPercent.Text = Building_Data.Item(0).BuildingPercentFinish
                txtPriceNotFinish.Text = String.Format("{0:N2}", Building_Data.Item(0).BuildingPriceFinish)
                txtBuildingPriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtPriceNotFinish.Text) * CDec(txtBuildingTotalDeteriorate.Text)) / 100)
                txtNetPrice.Text = String.Format("{0:N2}", CDec(txtPriceNotFinish.Text) - CDec(txtBuildingPriceTotalDeteriorate.Text))
                txtBuildingDetail.Text = Building_Data.Item(0).BuildingDetail
            ElseIf SubCollType = 53 Then
                txtBuildingArea.Text = Building_Data.Item(0).BuildAddArea
                txtBuildingUnitPrice.Text = Building_Data.Item(0).BuildAddUintPrice
                txtBuildingPrice.Text = String.Format("{0:N2}", CDec(Building_Data.Item(0).BuildAddArea) * CDec(Building_Data.Item(0).BuildAddUintPrice))
                txtBuildingAge.Text = Building_Data.Item(0).BuildAddAge
                txtBuildingPersent1.Text = Building_Data.Item(0).BuildAddPersent1
                txtBuildingPersent2.Text = Building_Data.Item(0).BuildAddPersent2
                txtBuildingPersent3.Text = Building_Data.Item(0).BuildAddPersent3
                txtFinishPercent.Text = Building_Data.Item(0).BuildAddPercentFinish
                txtPriceNotFinish.Text = String.Format("{0:N2}", Building_Data.Item(0).BuildAddPriceFinish)
                txtBuildingTotalDeteriorate.Text = (Building_Data.Item(0).BuildAddAge * Building_Data.Item(0).BuildAddPersent1) - Building_Data.Item(0).BuildAddPersent2 + Building_Data.Item(0).BuildAddPersent3 'Obj_GetP70.Item(0).BuildAddPriceTotalDeteriorate
                txtBuildingPriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtPriceNotFinish.Text) * CDec(txtBuildingTotalDeteriorate.Text)) / 100)
                txtNetPrice.Text = String.Format("{0:N2}", CDec(txtPriceNotFinish.Text) - CDec(txtBuildingPriceTotalDeteriorate.Text))
                txtBuildingDetail.Text = Building_Data.Item(0).BuildingDetail
            ElseIf SubCollType >= 54 Then
                'ข้อมูลส่วนควบ
                Dim Partake As List(Of Price2_70_Partake) = GET_PRICE2_70_PARTAKE(lblId.Text, lblReq_Id.Text, lblHub_Id.Text, lblTemp_AID.Text, SubCollType)
                txtBuildingArea.Text = Partake.Item(0).PartakeArea
                txtBuildingUnitPrice.Text = Partake.Item(0).PartakeUintPrice
                txtBuildingPrice.Text = String.Format("{0:N2}", CDec(Partake.Item(0).PartakeArea) * CDec(Partake.Item(0).PartakeUintPrice))
                txtBuildingAge.Text = Partake.Item(0).PartakeAge
                txtBuildingPersent1.Text = Partake.Item(0).PartakePersent1
                txtBuildingPersent2.Text = Partake.Item(0).PartakePersent2
                txtBuildingPersent3.Text = Partake.Item(0).PartakePersent3
                txtFinishPercent.Text = Partake.Item(0).PercentFinish
                txtPriceNotFinish.Text = String.Format("{0:N2}", Partake.Item(0).PriceFinish)
                txtBuildingTotalDeteriorate.Text = (Partake.Item(0).PartakeAge * Partake.Item(0).PartakePersent1) - Partake.Item(0).PartakePersent2 + Partake.Item(0).PartakePersent3 'Obj_GetP70.Item(0).BuildAddPriceTotalDeteriorate
                txtBuildingPriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtPriceNotFinish.Text) * CDec(txtBuildingTotalDeteriorate.Text)) / 100)
                txtNetPrice.Text = String.Format("{0:N2}", CDec(txtPriceNotFinish.Text) - CDec(txtBuildingPriceTotalDeteriorate.Text))
                txtBuildingDetail.Text = Partake.Item(0).PartakeDetail
            Else

            End If
        End If
    End Sub

    Sub Update_Building_Header(ByVal SubCollType As Integer)
        Dim p2_70new As List(Of Price2_70_New) = GET_PRICE2_70_NEW_VERIFY_UPDATE(lblReq_Id.Text, lblHub_Id.Text, txtBuild_No.Text)
        UPDATE_PRICE2_PRICE3_70_HEADER(lblId.Text, lblReq_Id.Text, lblHub_Id.Text, 0, 0, 0, _
            SubCollType, txtBuild_No.Text, txtTumbon.Text, txtAmphur.Text, _
            ddlProvince.SelectedValue, ddlBuild_Character.SelectedValue, txtFloor.Text, txtItem.Text, ddlBuild_Construct.SelectedValue, _
            ddlRoof.SelectedValue, txtRoof_Detail.Text, ddlBuild_State.SelectedValue, _
            txtBuild_State_Detail.Text, txtBuilding_Detail.Text, _
            chkDoc1.Checked, chkDoc2.Checked, String.Empty, String.Empty, txtChanodeNo.Text, txtOwnership.Text, _
            ddlInteriorState.SelectedValue, TextBoxStandardNo.Text, _
            ddlRoofConstructure.SelectedValue, ddlRoofState.SelectedValue, _
            hdfAppraisal_Id.Value, Now())
    End Sub

    Protected Sub imgSearchChanode_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgSearchChanode.Click
        'ตรวจสอบเลขโฉนด จากระบบว่าเคยให้ราคาแล้วหรือไม่
        Dim Get_Chanode As List(Of Price2_70_New) = GET_PRICE2_70_NEW_CHANODE(txtChanodeNo.Text)
        If Get_Chanode.Count > 0 Then
            StringMessage = "<script language=""javascript"">alert('พบชิ้นทรัพย์บนเลขที่โฉนดดังกล่าวระบบจะแสดงรายละเอียดดังกล่าว'); </script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "พบทรัพย์ประเมิน", StringMessage)

            DDLSubCollType.SelectedValue = Get_Chanode.Item(0).MysubColl_ID
            txtChanodeNo.Text = Get_Chanode.Item(0).Put_On_Chanode
            txtOwnership.Text = Get_Chanode.Item(0).Ownership
            txtBuild_No.Text = Get_Chanode.Item(0).Build_No
            txtTumbon.Text = Get_Chanode.Item(0).Tumbon
            txtAmphur.Text = Get_Chanode.Item(0).Amphur
            ddlProvince.SelectedValue = Get_Chanode.Item(0).Province
            ddlBuild_Character.SelectedValue = Get_Chanode.Item(0).Build_Character
            txtFloor.Text = Get_Chanode.Item(0).Floors
            txtItem.Text = Get_Chanode.Item(0).Item
            ddlBuild_Construct.SelectedValue = Get_Chanode.Item(0).Build_Construct
            ddlRoof.SelectedValue = Get_Chanode.Item(0).Roof
            txtRoof_Detail.Text = Get_Chanode.Item(0).Roof_Detail
            ddlBuild_State.SelectedValue = Get_Chanode.Item(0).Build_State
            txtBuild_State_Detail.Text = Get_Chanode.Item(0).Build_State_Detail
            txtBuilding_Detail.Text = Get_Chanode.Item(0).Building_Detail
            txtPriceTotal1.Text = String.Format("{0:N2}", Get_Chanode.Item(0).PriceTotal1)
            chkDoc1.Checked = Get_Chanode.Item(0).Doc1
            chkDoc2.Checked = Get_Chanode.Item(0).Doc2
            'txtDoc_Detail.Text = Get_Chanode.Item(0).Doc_Detail
            txtBuildingArea.Text = Get_Chanode.Item(0).BuildingArea
            txtBuildingUnitPrice.Text = Get_Chanode.Item(0).BuildingUintPrice
            txtBuildingPrice.Text = String.Format("{0:N2}", Get_Chanode.Item(0).BuildingPrice)
            txtBuildingAge.Text = Get_Chanode.Item(0).BuildingAge
            txtBuildingPersent1.Text = Get_Chanode.Item(0).BuildingPersent1
            txtBuildingPersent2.Text = Get_Chanode.Item(0).BuildingPersent2
            txtBuildingPersent3.Text = Get_Chanode.Item(0).BuildingPersent3
            txtBuildingTotalDeteriorate.Text = (Get_Chanode.Item(0).BuildingAge * Get_Chanode.Item(0).BuildingPersent1) - Get_Chanode.Item(0).BuildingPersent2 + Get_Chanode.Item(0).BuildingPersent3
            txtFinishPercent.Text = Get_Chanode.Item(0).BuildingPercentFinish
            txtPriceNotFinish.Text = String.Format("{0:N2}", Get_Chanode.Item(0).BuildingPriceFinish)
            txtBuildingPriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtPriceNotFinish.Text) * CDec(txtBuildingTotalDeteriorate.Text)) / 100)
            txtBuildingDetail.Text = Get_Chanode.Item(0).BuildingDetail
            ddlInteriorState.SelectedValue = Get_Chanode.Item(0).Decoration
            Dim StandardInfo As List(Of Cls_Standard) = GET_STANDARD_INFO_BY_ID(Get_Chanode.Item(0).Standard_Id)
            TextBoxStandardNo.Text = StandardInfo.Item(0).STANDARD_ID
            TextBoxStandardName.Text = StandardInfo.Item(0).STANDARD_NAME
        Else
        End If
    End Sub

    Sub INSERT_NEW_BUILDING()
        lblId.Text = String.Empty
        If HiddenApprisalType.Value = 2 Then
            MarketPrice = 0
        Else
            MarketPrice = CDec(txtPriceTotal1.Text)
        End If

        Dim Id As Integer = 0
        Dim Price2_70 As Integer = GET_PRICE2_70_NEW_COUNT(lblReq_Id.Text, lblHub_Id.Text, txtBuild_No.Text)
        If Price2_70 = 0 Then
            'ถ้าไม่มีอยู่ตาราง Price2_70_New
            If HiddenApprisalType.Value = 2 Then
                txtPriceTotal1.Text = "0.00"
            End If
            If DDLSubCollType.SelectedValue <= 45 Or DDLSubCollType.SelectedValue = 50 Then
                'เป็นสิ่งปลูกสร้าง
                Id = GET_ID_18_50_70("70")
                UPDATE_ID_70()  'Update ID CollType 70
                lblId.Text = Id
                ADD_PRICE2_PRICE3_70(Id, lblReq_Id.Text, lblHub_Id.Text, 0, 0, 0, _
                    DDLSubCollType.SelectedValue, txtBuild_No.Text, txtTumbon.Text, txtAmphur.Text, _
                    ddlProvince.SelectedValue, ddlBuild_Character.SelectedValue, txtFloor.Text, txtItem.Text, ddlBuild_Construct.SelectedValue, _
                    ddlRoof.SelectedValue, txtRoof_Detail.Text, ddlBuild_State.SelectedValue, _
                    txtBuild_State_Detail.Text, txtBuilding_Detail.Text, MarketPrice, _
                    chkDoc1.Checked, chkDoc2.Checked, String.Empty, String.Empty, txtChanodeNo.Text, txtOwnership.Text, txtBuildingArea.Text, CDec(txtBuildingUnitPrice.Text), _
                    CDec(txtBuildingArea.Text) * CDec(txtBuildingUnitPrice.Text), txtBuildingAge.Text, CDec(txtBuildingPersent1.Text), CDec(txtBuildingPersent2.Text), CDec(txtBuildingPersent3.Text), _
                    CDec(txtBuildingPriceTotalDeteriorate.Text), CInt(txtFinishPercent.Text), CDec(txtPriceNotFinish.Text), 0, 0, 0, _
                    0, 0, 0, 0, 0, 0, 0, _
                    txtBuildingDetail.Text, ddlInteriorState.SelectedValue, TextBoxStandardNo.Text, ddlRoofConstructure.SelectedValue, ddlRoofState.SelectedValue, _
                    hdfAppraisal_Id.Value, Now())

            ElseIf DDLSubCollType.SelectedValue = 53 Then
                'เป็นส่วนต่อเติมสิ่งปลูกสร้าง
                StringMessage = "<script language=""javascript"">alert('ไม่สามารถบันทึกได้ เพราะยังไม่มีสิ่งปลูกสร้างหลัก'); </script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "เตือนยังไม่มีสิ่งปลูกสร้างหลัก", StringMessage)

            ElseIf DDLSubCollType.SelectedValue >= 54 Then 'And DDLSubCollType.SelectedValue <= 61 Then
                'เป็นส่วนควบ
                StringMessage = "<Script language=""javascript"">alert('ไม่สามารถบันทึกได้ เพราะยังไม่มีสิ่งปลูกสร้างหลัก');</Script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice ส่วนต่อเติม", StringMessage)
            End If
        Else
            'ถ้ามีอยู่ตาราง(Price2_70_New)
            StringMessage = "<script language=""javascript"">alert('ไม่สามารถบันทึกได้ เพราะมีบ้านเลขที่ดังกล่าวบนเลขคำขอนี้แล้ว'); </script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "พบชิ้นทรัพย์", StringMessage)
        End If
    End Sub

    Sub UPDATE_BUILDING()
        If HiddenApprisalType.Value = 2 Then
            'ถ้าเป็นวิธีทุน
            txtPriceTotal1.Text = "0.00"
        End If

        Dim p2_70new As List(Of Price2_70_New) = GET_PRICE2_70_NEW_VERIFY_UPDATE(lblReq_Id.Text, lblHub_Id.Text, txtBuild_No.Text)

        If DDLSubCollType.SelectedValue <= 45 Or DDLSubCollType.SelectedValue = 50 Then
            'สิ่งปลูกสร้างหลัก
            If p2_70new.Count > 0 Then  'ตรวจสอบว่า เลขคำขอ และ Hub นี้ และ สิ่งปลูกสร้างนี้ มีอยู่ในฐานข้อมูลแล้วหรือไม่ ถ้ามี
                Update_Building_Header(DDLSubCollType.SelectedValue)
            Else ' ถ้าไม่มี

            End If

        ElseIf DDLSubCollType.SelectedValue = 53 Then
            'ส่วนต่อเติม
            Update_Building_Header(p2_70new.Item(0).MysubColl_ID)

        Else
            'ส่วนควบ
            Dim Chk_Partake As List(Of Price2_70_Partake) = GET_PRICE2_70_PARTAKE_CHECK(lblReq_Id.Text, lblHub_Id.Text, txtBuild_No.Text, DDLSubCollType.SelectedValue)
            If Chk_Partake.Count > 0 Then
                Update_Building_Header(p2_70new.Item(0).MysubColl_ID)
            Else
                'StringMessage = "<Script language=""javascript"">alert('ไม่สามารถบันทึกได้ เพราะยังไม่มีสิ่งปลูกสร้างหลัก');</Script>"
                'Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice ส่วนต่อเติม", StringMessage)
            End If

        End If


        If DDLSubCollType.SelectedValue <= 45 Or DDLSubCollType.SelectedValue = 50 Then
            'Dim p2_70new As List(Of Price2_70_New) = GET_PRICE2_70_NEW_VERIFY_UPDATE(lblReq_Id.Text, lblHub_Id.Text, txtBuild_No.Text)
            'ตรวจสอบว่า เลขคำขอ และ Hub นี้ และ สิ่งปลูกสร้างนี้ มีอยู่ในฐานข้อมูลแล้วหรือไม่
            If p2_70new.Count > 0 Then
                'ถ้ามี  ให้ทำการ Update ข้อมูลรายละเอียดของสิ่งปลูกสร้างหลัก

                UPDATE_PRICE2_PRICE3_70_BUILDING_ONLY(lblId.Text, lblReq_Id.Text, lblHub_Id.Text, txtBuild_No.Text, txtBuildingArea.Text, CDec(txtBuildingUnitPrice.Text), _
                    CDec(txtBuildingArea.Text) * CDec(txtBuildingUnitPrice.Text), txtBuildingAge.Text, CDec(txtBuildingPersent1.Text), CDec(txtBuildingPersent2.Text), CDec(txtBuildingPersent3.Text), _
                     CDec(txtBuildingPriceTotalDeteriorate.Text), CInt(txtFinishPercent.Text), CDec(txtPriceNotFinish.Text), txtBuildingDetail.Text, _
                     CDec(txtPriceTotal1.Text), hdfAppraisal_Id.Value, Now())
            Else
                'ถ้าไม่มี  ให้ทำการ ADD เพิ่มข้อมูลรายละเอียดของสิ่งปลูกสร้างหลัก
                INSERT_NEW_BUILDING()
            End If

        ElseIf DDLSubCollType.SelectedValue = 53 Then
            'เป็นส่วนต่อเติมสิ่งปลูกสร้าง
            txtNetPrice.Text = "0"
            UPDATE_PRICE2_PRICE3_70_BUILDING_PLUS(lblId.Text, lblReq_Id.Text, lblHub_Id.Text, txtBuild_No.Text, txtBuildingArea.Text, _
                                                  CDec(txtBuildingUnitPrice.Text), CDec(txtBuildingArea.Text) * CDec(txtBuildingUnitPrice.Text), txtBuildingAge.Text, _
                                                  CDec(txtBuildingPersent1.Text), CDec(txtBuildingPersent2.Text), CDec(txtBuildingPersent3.Text), _
                                                  CDec(txtBuildingPriceTotalDeteriorate.Text), CInt(txtFinishPercent.Text), CDec(txtPriceNotFinish.Text), _
                                                  CDec(txtPriceTotal1.Text), hdfAppraisal_Id.Value, Now())
        ElseIf DDLSubCollType.SelectedValue >= 54 Then
            'ตรวจสอบส่วนควบก่อนทำการบันทึกหรือแก้ไข
            Dim Partake As DataSet = GET_PRICE2_70_PARTAKE_DATASET(lblId.Text, lblReq_Id.Text, lblHub_Id.Text, lblTemp_AID.Text, DDLSubCollType.SelectedValue)
            'If Partake.Item(0).Partake_Id = Nothing Then
            If Partake.Tables(0).Rows.Count > 0 Then
                'Update Building Partake By Partake Id
                UPDATE_PRICE2_PRICE3_70_PARTAKE(lblId.Text, lblReq_Id.Text, lblHub_Id.Text, lblTemp_AID.Text, "", DDLSubCollType.SelectedValue, txtBuild_No.Text, _
                                     txtBuildingArea.Text, txtBuildingUnitPrice.Text, CDec(txtBuildingArea.Text) * CDec(txtBuildingUnitPrice.Text), txtBuildingAge.Text, _
                                     txtBuildingPersent1.Text, txtBuildingPersent2.Text, txtBuildingPersent3.Text, txtBuildingPriceTotalDeteriorate.Text, _
                                     txtFinishPercent.Text, txtPriceNotFinish.Text, txtBuildingDetail.Text, hdfAppraisal_Id.Value, Now())
            Else
                'Add New Building Partake
                ADD_PRICE2_PRICE3_70_PARTAKE(lblId.Text, lblReq_Id.Text, lblHub_Id.Text, lblTemp_AID.Text, "", DDLSubCollType.SelectedValue, txtBuild_No.Text, _
                 txtBuildingArea.Text, CDec(txtBuildingUnitPrice.Text), CDec(txtBuildingArea.Text) * CDec(txtBuildingUnitPrice.Text), txtBuildingAge.Text, _
                 CDec(txtBuildingPersent1.Text), CDec(txtBuildingPersent2.Text), CDec(txtBuildingPersent3.Text), CDec(txtBuildingPriceTotalDeteriorate.Text), _
                 CInt(txtFinishPercent.Text), CDec(txtPriceNotFinish.Text) * (CInt(txtFinishPercent.Text) / 100), txtBuildingDetail.Text, hdfAppraisal_Id.Value, Now())
            End If

        End If
    End Sub

    'Protected Sub ImagePrint_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImagePrint.Click
    '    If lblId.Text = String.Empty Then
    '        'เพิ่มชิ้นทรัพย์ใหม่       
    '        INSERT_NEW_BUILDING()
    '    Else
    '        '***********ถ้ามีข้อมูลแล้วต้อง Update ข้อมูล  แก้ไขข้อมูลเดิม     *****************
    '        UPDATE_BUILDING()
    '    End If
    'End Sub
End Class
