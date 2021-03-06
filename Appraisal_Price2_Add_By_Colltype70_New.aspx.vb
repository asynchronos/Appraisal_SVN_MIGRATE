Imports Appraisal_Manager
Imports System.Data

Partial Class Appraisal_Price2_Add_By_Colltype70_New
    Inherits System.Web.UI.Page
    Dim s As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            lblId.Text = Context.Items("ID")
            lblReq_Id.Text = Context.Items("Req_Id")
            lblHub_Id.Text = Context.Items("Hub_Id")
            hhhfSubCollType.Value = Context.Items("Coll_Type")
            hdfCif.Value = Context.Items("Cif")
            lblTemp_AID.Text = Context.Items("Temp_AID")
            Get_Price2_50_Info()
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
                CDec(txtBuildingPrice.Text), txtBuildingAge.Text, CDec(txtBuildingPersent1.Text), CDec(txtBuildingPersent2.Text), CDec(txtBuildingPersent3.Text), _
                CDec(txtBuildingPriceTotalDeteriorate.Text), CInt(txtFinishPercent.Text), CDec(txtPriceNotFinish.Text), txtBuildAddArea.Text, CDec(txtBuildAddUnitPrice.Text), CDec(txtBuildAddPrice.Text), _
                txtBuildAddAge.Text, CDec(txtBuildAddPersent1.Text), CDec(txtBuildAddPersent2.Text), CDec(txtBuildAddPersent3.Text), CDec(txtBuildAddPriceTotalDeteriorate.Text), CInt(txtFinishPercent1.Text), CDec(txtPriceNotFinish1.Text), _
                txtBuildingDetail.Text, ddlInteriorState.SelectedValue, ddlStandard.SelectedValue, ddlRoofConstructure.SelectedValue, ddlRoofState.SelectedValue, lbluserid.Text, Now())
        If lblId.Text = String.Empty Then
            UPDATE_Status_Appraisal_Request(lblReq_Id.Text, lblHub_Id.Text, 5)
        End If
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
                CDec(txtBuildingPrice.Text), txtBuildingAge.Text, CDec(txtBuildingPersent1.Text), CDec(txtBuildingPersent2.Text), CDec(txtBuildingPersent3.Text), _
                CDec(txtBuildingPriceTotalDeteriorate.Text), CInt(txtFinishPercent.Text), CDec(txtPriceNotFinish.Text), txtBuildAddArea.Text, CDec(txtBuildAddUnitPrice.Text), CDec(txtBuildAddPrice.Text), _
                txtBuildAddAge.Text, CDec(txtBuildAddPersent1.Text), CDec(txtBuildAddPersent2.Text), CDec(txtBuildAddPersent3.Text), CDec(txtBuildAddPriceTotalDeteriorate.Text), CInt(txtFinishPercent1.Text), CDec(txtPriceNotFinish1.Text), _
                txtBuildingDetail.Text, ddlInteriorState.SelectedValue, ddlStandard.SelectedValue, lbluserid.Text, Now())
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
        txtBuildingTotalDeteriorate.Text = (P2_70New.Item(0).BuildingAge * (P2_70New.Item(0).BuildingPersent1)) - P2_70New.Item(0).BuildingPersent2 + P2_70New.Item(0).BuildingPersent3
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
        txtBuildAddTotalDeteriorate.Text = (P2_70New.Item(0).BuildAddAge * P2_70New.Item(0).BuildAddPersent1) - P2_70New.Item(0).BuildAddPersent2 - P2_70New.Item(0).BuildAddPersent3 'Obj_GetP70.Item(0).BuildAddPriceTotalDeteriorate
        txtBuildAddPriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtPriceNotFinish1.Text) * CDec(txtBuildAddTotalDeteriorate.Text)) / 100)
        txtBuildingDetail.Text = P2_70New.Item(0).BuildingDetail
        ddlInteriorState.SelectedValue = P2_70New.Item(0).Decoration
        ddlRoofConstructure.SelectedValue = P2_70New.Item(0).RoofStructure_Id
        ddlRoofState.SelectedValue = P2_70New.Item(0).RoofState_Id
        ddlStandard.SelectedValue = P2_70New.Item(0).Standard_Id
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
        If txtBuild_No.Text = String.Empty Then
            s = "<script language=""javascript"">alert('คุณยังไม่ได้ใส่เลขที่สิ่งปลูกสร้าง หากไม่ปรากฎเลขที่สิ่งปลูกสร้าง ให้ใส่ สิ่งปลูกสร้างไม่มีเลขที่หลังที่1 หรือ ตามจำนวนสิ่งปลูกสร้าง'); </script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)
        Else
            Operation()
        End If

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
        'ตรวจเช็คก่อนว่าผู้ประเมินกับหัวหน้าดูข้อมูลเดียวกัน แต่ผู้ประเมินได้จัดกลุ่มไปแล้วแต่หัวหน้าเข้าไปดูก่อนที่เจ้าหน้าที่ประเมินจะจัดกลุ่มทำให้
        'Temp_Aid ที่เกิดขึ้นขัดแย้งกัน จึงจำเป็นต้องเช็คก่อนว่าเลขคำขอนี้ และ Temp_Aid นี้ยังเป็นของเดิมหรือไม่
        Dim P2_70New As List(Of Price2_70_New) = GET_PRICE2_70_NEW_TEMP_AID(lblId.Text, lblReq_Id.Text, lblHub_Id.Text, lblTemp_AID.Text)
        If P2_70New.Count > 0 Then
            s = "<script language=""javascript"">alert('ผู้ประเมินได้จัดกลุ่มทรัพย์ที่จะประเมินแล้วระบบจะทำการ Update ข้อมูลให้ถูกต้อง'); </script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "แจ้งเตือนการUpdate", s)
            lblTemp_AID.Text = P2_70New.Item(0).Temp_AID
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
            txtBuildingTotalDeteriorate.Text = (P2_70New.Item(0).BuildingAge * (P2_70New.Item(0).BuildingPersent1)) - P2_70New.Item(0).BuildingPersent2 + P2_70New.Item(0).BuildingPersent3
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
            txtBuildAddTotalDeteriorate.Text = (P2_70New.Item(0).BuildAddAge * P2_70New.Item(0).BuildAddPersent1) - P2_70New.Item(0).BuildAddPersent2 - P2_70New.Item(0).BuildAddPersent3 'Obj_GetP70.Item(0).BuildAddPriceTotalDeteriorate
            txtBuildAddPriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtPriceNotFinish1.Text) * CDec(txtBuildAddTotalDeteriorate.Text)) / 100)
            txtBuildingDetail.Text = P2_70New.Item(0).BuildingDetail
            ddlInteriorState.SelectedValue = P2_70New.Item(0).Decoration
            ddlStandard.SelectedValue = P2_70New.Item(0).Standard_Id
            Dim Obj_P2_70D As List(Of Cls_Price2_70_Detail) = GET_PRICE2_70_DETAIL(lblId.Text, lblReq_Id.Text, lblHub_Id.Text, lblTemp_AID.Text, 0)
            If Obj_P2_70D.Count > 0 Then
                chkDetail.Checked = True
            End If
            UPDATE_DATA()
        Else
            If lblId.Text = String.Empty Or lblId.Text = "0" Then
                'บันทึกข้อมูลก่อนไปหน้าส่วนควบ
                SAVE_DATA()
            End If
        End If

        Context.Items("Id") = lblId.Text
        Context.Items("Temp_AID") = lblTemp_AID.Text
        Context.Items("Req_Id") = lblReq_Id.Text
        Context.Items("Hub_Id") = lblHub_Id.Text
        Context.Items("Building_No") = txtBuild_No.Text
        Context.Items("Cif") = hdfCif.Value
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

    Private Sub Get_Price2_50_Info()
        Dim Obj_GetP50 As List(Of PRICE2_50) = GET_PRICE2_50(0, lblReq_Id.Text, lblHub_Id.Text)
        If Obj_GetP50.Count > 0 Then
            Dim AR As List(Of Appraisal_Request_v2) = GET_APPRAISAL_REQUEST_V2(lblReq_Id.Text)
            Dim tumbonN As List(Of Cls_Tumbon) = GET_TUMBON_INFO(AR.Item(0).Tumbon, AR.Item(0).Amphur, AR.Item(0).Province)
            Dim amphurN As List(Of Cls_Amphur) = GET_AMPHUR_INFO(AR.Item(0).Amphur, AR.Item(0).Province)

            'txtTumbon.Text = Obj_GetP50.Item(0).Tumbon
            'txtAmphur.Text = Obj_GetP50.Item(0).Amphur
            txtTumbon.Text = tumbonN.Item(0).tumbon_new2_name
            txtAmphur.Text = amphurN.Item(0).am_name
            ddlProvince.SelectedValue = Obj_GetP50.Item(0).Province
            txtChanodeNo.Text = Obj_GetP50.Item(0).Address_No
        End If
    End Sub

    Protected Sub ImageButton_Verify_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton_Verify.Click
        'MsgBox("Verify โฉนด")
        'ตรวจสอบเลขโฉนด จากระบบว่าเคยให้ราคาแล้วหรือไม่
        Dim Get_Chanode As List(Of Price2_70_New) = GET_PRICE2_70_NEW_CHANODE(txtChanodeNo.Text)
        If Get_Chanode.Count > 0 Then
            s = "<script language=""javascript"">alert('พบเลขที่โฉนดดังกล่าวระบบจะแสดงรายละเอียดดังกล่าว'); </script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)

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
            txtDoc_Detail.Text = Get_Chanode.Item(0).Doc_Detail
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
            txtBuildAddArea.Text = Get_Chanode.Item(0).BuildAddArea
            txtBuildAddUnitPrice.Text = Get_Chanode.Item(0).BuildAddUintPrice
            txtBuildAddPrice.Text = String.Format("{0:N2}", Get_Chanode.Item(0).BuildAddPrice)
            txtBuildAddAge.Text = Get_Chanode.Item(0).BuildAddAge
            txtBuildAddPersent1.Text = Get_Chanode.Item(0).BuildAddPersent1
            txtBuildAddPersent2.Text = Get_Chanode.Item(0).BuildAddPersent2
            txtBuildAddPersent3.Text = Get_Chanode.Item(0).BuildAddPersent3
            txtFinishPercent1.Text = Get_Chanode.Item(0).BuildAddPercentFinish
            txtPriceNotFinish1.Text = String.Format("{0:N2}", Get_Chanode.Item(0).BuildAddPriceFinish)
            txtBuildAddTotalDeteriorate.Text = (Get_Chanode.Item(0).BuildAddAge * Get_Chanode.Item(0).BuildAddPersent1) - Get_Chanode.Item(0).BuildAddPersent2 + Get_Chanode.Item(0).BuildAddPersent3 'Obj_GetP70.Item(0).BuildAddPriceTotalDeteriorate
            txtBuildAddPriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtPriceNotFinish1.Text) * CDec(txtBuildAddTotalDeteriorate.Text)) / 100)
            txtBuildingDetail.Text = Get_Chanode.Item(0).BuildingDetail
            ddlInteriorState.SelectedValue = Get_Chanode.Item(0).Decoration
            ddlStandard.SelectedValue = Get_Chanode.Item(0).Standard_Id
        Else
        End If

    End Sub
End Class
