Imports Appraisal_Manager
Partial Class Appraisal_Price3_70_Review_Edit
    Inherits System.Web.UI.Page
    Dim s As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'hdfColl_Type.Value = 70
        If Not Page.IsPostBack Then
            lblId.Text = Context.Items("ID")
            lblReq_Id.Text = Context.Items("Req_Id")
            lblHub_Id.Text = Context.Items("Hub_Id")
            hdfAID.Value = Context.Items("AID")
            TextBoxAID.Text = Context.Items("AID")
            lblTemp_AID.Text = Context.Items("Temp_AID")
            hdfColl_Type.Value = Context.Items("Coll_Type")
            lblHub_Id.Text = Context.Items("Hub_Id")
            hdfCif.Value = Context.Items("Cif")
            'lblCifName.Text = Context.Items("CifName")

            Show_Price3_50_Find_Chanode()
            Show_Price3_70_Review()

        End If
    End Sub

    Private Sub Show_Price3_50_Find_Chanode()
        Dim Obj_GetP50 As List(Of Price3_50) = GET_PRICE3_50_FIND_CHANODE(lblReq_Id.Text, lblHub_Id.Text, lblTemp_AID.Text)
        'MsgBox(Obj_GetP50.Count)
        If Obj_GetP50.Count > 0 Then
            For i = 0 To Obj_GetP50.Count - 1
                txtChanodeNo.Text += Obj_GetP50.Item(i).Address_No & ","
            Next
            txtChanodeNo.Text = Mid(txtChanodeNo.Text, 1, Len(txtChanodeNo.Text) - 1)
        End If
    End Sub

    Private Sub Show_Price3_70_Review()
        'Dim Obj_GetP70_Review As List(Of Price3_70_Review) = GET_PRICE3_70_REVIEW(lblReq_Id.Text, lblHub_Id.Text, lblId.Text)
        Dim Obj_GetP70 As List(Of Price3_70) = GET_PRICE3_70(lblId.Text, lblReq_Id.Text, lblHub_Id.Text, lblTemp_AID.Text)
        If Obj_GetP70.Count > 0 Then
            lblId.Text = Obj_GetP70.Item(0).ID
            lblReq_Id.Text = Obj_GetP70.Item(0).Req_Id
            lblHub_Id.Text = Obj_GetP70.Item(0).Hub_Id
            TextBoxAID.Text = Obj_GetP70.Item(0).AID
            TextBoxCID.Text = Obj_GetP70.Item(0).CID
            DDLSubCollType.SelectedValue = Obj_GetP70.Item(0).MysubColl_ID
            If Obj_GetP70.Item(0).Build_No <> String.Empty Or Obj_GetP70.Item(0).Build_No <> Nothing Then
                txtChanodeNo.Text = Obj_GetP70.Item(0).Put_On_Chanode
            Else

            End If

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
            txtPriceTotal1.Text = String.Format("{0:N2}", Obj_GetP70.Item(0).PriceTotal1)
            chkDoc1.Checked = Obj_GetP70.Item(0).Doc1
            chkDoc2.Checked = Obj_GetP70.Item(0).Doc2
            txtDoc_Detail.Text = Obj_GetP70.Item(0).Doc_Detail
            txtBuildingArea.Text = Obj_GetP70.Item(0).BuildingArea
            txtBuildingUnitPrice.Text = Obj_GetP70.Item(0).BuildingUintPrice 'String.Format("{0:N2}", Obj_GetP70.Item(0).BuildingUintPrice)
            txtBuildingPrice.Text = String.Format("{0:N2}", Obj_GetP70.Item(0).BuildingPrice)
            txtBuildingAge.Text = Obj_GetP70.Item(0).BuildingAge
            txtBuildingPersent1.Text = Obj_GetP70.Item(0).BuildingPersent1
            txtBuildingPersent2.Text = Obj_GetP70.Item(0).BuildingPersent2
            txtBuildingPersent3.Text = Obj_GetP70.Item(0).BuildingPersent3
            txtBuildingTotalDeteriorate.Text = (Obj_GetP70.Item(0).BuildingAge * (Obj_GetP70.Item(0).BuildingPersent1) - Obj_GetP70.Item(0).BuildingPersent2 + Obj_GetP70.Item(0).BuildingPersent3)
            txtFinishPercent.Text = Obj_GetP70.Item(0).BuildingPercentFinish
            txtPriceNotFinish.Text = Obj_GetP70.Item(0).BuildingPriceFinish
            txtBuildingPriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtPriceNotFinish.Text) * CDec(txtBuildingTotalDeteriorate.Text)) / 100)
            txtBuildAddArea.Text = Obj_GetP70.Item(0).BuildAddArea
            txtBuildAddUnitPrice.Text = Obj_GetP70.Item(0).BuildAddUintPrice 'String.Format("{0:N2}", Obj_GetP70.Item(0).BuildAddUintPrice)
            txtBuildAddPrice.Text = String.Format("{0:N2}", Obj_GetP70.Item(0).BuildAddPrice)
            txtBuildAddAge.Text = Obj_GetP70.Item(0).BuildAddAge
            txtBuildAddPersent1.Text = Obj_GetP70.Item(0).BuildAddPersent1
            txtBuildAddPersent2.Text = Obj_GetP70.Item(0).BuildAddPersent2
            txtBuildAddPersent3.Text = Obj_GetP70.Item(0).BuildAddPersent3
            txtFinishPercent1.Text = Obj_GetP70.Item(0).BuildAddPercentFinish
            txtPriceNotFinish1.Text = Obj_GetP70.Item(0).BuildAddPriceFinish
            txtBuildAddTotalDeteriorate.Text = (Obj_GetP70.Item(0).BuildAddAge * Obj_GetP70.Item(0).BuildAddPersent1) - Obj_GetP70.Item(0).BuildAddPersent2 + Obj_GetP70.Item(0).BuildAddPersent3 'Obj_GetP70.Item(0).BuildAddPriceTotalDeteriorate
            txtBuildAddPriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtPriceNotFinish1.Text) * CDec(txtBuildAddTotalDeteriorate.Text)) / 100)
            txtBuildingDetail.Text = Obj_GetP70.Item(0).BuildingDetail
            ddlInteriorState.SelectedValue = Obj_GetP70.Item(0).Decoration
            ddlStandard.SelectedValue = Obj_GetP70.Item(0).Standard_Id
            ddlRoofConstructure.SelectedValue = Obj_GetP70.Item(0).RoofStructure_Id
            ddlRoofState.SelectedValue = Obj_GetP70.Item(0).RoofState_Id
            Dim Obj_P3_70D As List(Of ClsPrice3_70_Detail) = GET_PRICE3_70_DETAIL(lblId.Text, lblReq_Id.Text, lblHub_Id.Text, lblTemp_AID.Text, 0)
            If Obj_P3_70D.Count > 0 Then
                chkDetail.Checked = True
            End If
            CalBuildingNotFinish()
        End If
    End Sub

    Protected Sub ImageSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSave.Click
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label) 'หา Control จาก Master Page ที่ control ไม่อยู่ใน  ContentPlaceHolder1 ของ Master Page
        'UPDATE_PRICE3_70_REVIEW(CInt(lblId.Text), CInt(lblReq_Id.Text), CInt(lblHub_Id.Text), CInt(lblTemp_AID.Text), _
        '        CInt(DDLSubCollType.SelectedValue), txtBuild_No.Text, txtTumbon.Text, txtAmphur.Text, _
        '        CInt(ddlProvince.SelectedValue), CInt(ddlBuild_Character.SelectedValue), _
        '        txtFloor.Text, txtItem.Text, CInt(ddlBuild_Construct.SelectedValue), _
        '        CInt(ddlRoof.SelectedValue), txtRoof_Detail.Text, CInt(ddlBuild_State.SelectedValue), _
        '        txtBuild_State_Detail.Text, txtBuilding_Detail.Text, CDbl(txtPriceTotal1.Text), _
        '        chkDoc1.Checked, chkDoc2.Checked, txtDoc_Detail.Text, String.Empty, txtChanodeNo.Text, txtOwnership.Text, CDbl(txtBuildingArea.Text), CDbl(txtBuildingUnitPrice.Text), _
        '        CDbl(txtBuildingPrice.Text), CDbl(txtBuildingAge.Text), CDbl(txtBuildingPersent1.Text), CDbl(txtBuildingPersent2.Text), CDbl(txtBuildingPersent3.Text), _
        '        CDbl(txtBuildingTotalDeteriorate.Text), CDbl(txtBuildAddArea.Text), CDbl(txtBuildAddUnitPrice.Text), CDbl(txtBuildAddPrice.Text), _
        '        CInt(txtBuildAddAge.Text), CDbl(txtBuildAddPersent1.Text), CDbl(txtBuildAddPersent2.Text), CDbl(txtBuildAddPersent3.Text), CDbl(txtBuildAddTotalDeteriorate.Text), _
        '        txtBuildingDetail.Text, ddlInteriorState.SelectedValue, lbluserid.Text, Now())

        'save Price3 70
        'AddPRICE3_70(lblId.Text, CInt(lblReq_Id.Text), CInt(lblHub_Id.Text), lblTemp_AID.Text, lblAID.Text, lblCID.Text, _
        'CInt(DDLSubCollType.SelectedValue), txtBuild_No.Text, txtTumbon.Text, txtAmphur.Text, _
        'ddlProvince.SelectedValue, ddlBuild_Character.SelectedValue, _
        'txtFloor.Text, txtItem.Text, ddlBuild_Construct.SelectedValue, _
        'ddlRoof.SelectedValue, txtRoof_Detail.Text, ddlBuild_State.SelectedValue, _
        'txtBuild_State_Detail.Text, txtBuilding_Detail.Text, CDec(txtPriceTotal1.Text), _
        'chkDoc1.Checked, chkDoc2.Checked, txtDoc_Detail.Text, String.Empty, txtChanodeNo.Text, txtOwnership.Text, txtBuildingArea.Text, CDec(txtBuildingUnitPrice.Text), _
        'CDec(txtBuildingPrice.Text), txtBuildingAge.Text, txtBuildingPersent1.Text, txtBuildingPersent2.Text, txtBuildingPersent3.Text, _
        'CDec(txtBuildingPriceTotalDeteriorate.Text), CInt(txtFinishPercent.Text), CDec(txtPriceNotFinish.Text), txtBuildAddArea.Text, CDec(txtBuildAddUnitPrice.Text), CDec(txtBuildAddPrice.Text), _
        'txtBuildAddAge.Text, txtBuildAddPersent1.Text, txtBuildAddPersent2.Text, txtBuildAddPersent3.Text, CDec(txtBuildAddPriceTotalDeteriorate.Text), CInt(txtFinishPercent1.Text), CDec(txtPriceNotFinish1.Text), _
        'txtBuildingDetail.Text, ddlInteriorState.SelectedValue, ddlStandard.SelectedValue, lbluserid.Text, Now())
        SAVE_DATA()
    End Sub

    Protected Sub ImgBtnClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnClose.Click
        Context.Items("Id") = lblId.Text
        Context.Items("Req_Id") = lblReq_Id.Text
        Context.Items("Hub_Id") = lblHub_Id.Text
        Context.Items("Coll_Type") = hdfColl_Type.Value
        Context.Items("AID") = TextBoxAID.Text
        Context.Items("Temp_AID") = lblTemp_AID.Text
        Context.Items("Cif") = hdfCif.Value
        Server.Transfer("Appraisal_Price3_Form_Review.Aspx")
    End Sub

    Protected Sub btnAddPartTake_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddPartTake.Click
        SAVE_DATA()
        Context.Items("Id") = lblId.Text
        Context.Items("Temp_AID") = lblTemp_AID.Text
        Context.Items("Req_Id") = lblReq_Id.Text
        Context.Items("Hub_Id") = lblHub_Id.Text
        Context.Items("AID") = hdfAID.Value
        Context.Items("Building_No") = txtBuild_No.Text
        'Server.Transfer("Appraisal_Price3_70_Review_Partake.aspx")
        Server.Transfer("Appraisal_Price3_70_Partake.aspx")

    End Sub

    Protected Sub btnAddDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddDetail.Click
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        SAVE_DATA()
        Context.Items("Req_Id") = lblReq_Id.Text
        Context.Items("Hub_Id") = lblHub_Id.Text
        Context.Items("Temp_AID") = lblTemp_AID.Text
        Context.Items("ID") = lblId.Text
        Context.Items("User_ID") = lbluserid.Text
        'Server.Transfer("Appraisal_Price3_70_Detail_Review.aspx")
        Server.Transfer("Appraisal_Price3_Add_Colltype70Detail.aspx")
    End Sub

    Protected Sub ImagePrint_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImagePrint.Click
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        Context.Items("ID") = lblId.Text
        Context.Items("Req_Id") = lblReq_Id.Text
        Context.Items("Hub_Id") = lblHub_Id.Text
        Context.Items("Temp_AID") = lblTemp_AID.Text
        Context.Items("User_ID") = lbluserid.Text
        'Server.Transfer("Appraisal_Price3_70_Review_Print.aspx")
        Server.Transfer("Appraisal_Price3_Print_CollType70_New.aspx")
    End Sub

    Protected Sub txtBuildingTotalDeteriorate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuildingTotalDeteriorate.TextChanged
        Dim TotPersent As Decimal
        TotPersent = CInt(txtBuildingAge.Text) * (CDec(txtBuildingPersent1.Text) + CDec(txtBuildingPersent2.Text) + CDec(txtBuildingPersent1.Text))
    End Sub

    Protected Sub txtBuildingArea_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuildingArea.TextChanged
        If txtBuildingArea.Text = String.Empty Or txtBuildingUnitPrice.Text = String.Empty Then
            Exit Sub
        Else
            txtBuildingPrice.Text = String.Format("{0:N2}", CDec(txtBuildingArea.Text) * CDec(txtBuildingUnitPrice.Text))
        End If
    End Sub

    Protected Sub txtBuildingUnitPrice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuildingUnitPrice.TextChanged
        If txtBuildingArea.Text = String.Empty Or txtBuildingUnitPrice.Text = String.Empty Then
            Exit Sub
        Else
            txtBuildingPrice.Text = String.Format("{0:N2}", CDec(txtBuildingArea.Text) * CDec(txtBuildingUnitPrice.Text))
        End If
    End Sub

    Protected Sub txtBuildingAge_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuildingAge.TextChanged
        If txtBuildingAge.Text = String.Empty Or txtBuildingPersent1.Text = String.Empty Or txtBuildingPersent2.Text = String.Empty Or txtBuildingPersent3.Text = String.Empty Then
            Exit Sub
        Else
            txtBuildingTotalDeteriorate.Text = CInt(txtBuildingAge.Text) * (CDec(txtBuildingPersent1.Text) + CDec(txtBuildingPersent2.Text) + CDec(txtBuildingPersent3.Text))
            txtBuildingPriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtBuildingPrice.Text) * CDec(txtBuildingTotalDeteriorate.Text)) / 100)
        End If
    End Sub

    Protected Sub txtBuildingPersent3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuildingPersent3.TextChanged
        If txtBuildingAge.Text = String.Empty Or txtBuildingPersent1.Text = String.Empty Or txtBuildingPersent2.Text = String.Empty Or txtBuildingPersent3.Text = String.Empty Then
            Exit Sub
        Else
            txtBuildingTotalDeteriorate.Text = CInt(txtBuildingAge.Text) * (CDec(txtBuildingPersent1.Text) + CDec(txtBuildingPersent2.Text) + CDec(txtBuildingPersent3.Text))
            txtBuildingPriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtBuildingPrice.Text) * CDec(txtBuildingTotalDeteriorate.Text)) / 100)
        End If
    End Sub

    Protected Sub txtBuildingPersent1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuildingPersent1.TextChanged
        If txtBuildingAge.Text = String.Empty Or txtBuildingPersent1.Text = String.Empty Or txtBuildingPersent2.Text = String.Empty Or txtBuildingPersent3.Text = String.Empty Then
            Exit Sub
        Else
            txtBuildingTotalDeteriorate.Text = CInt(txtBuildingAge.Text) * (CDec(txtBuildingPersent1.Text) + CDec(txtBuildingPersent2.Text) + CDec(txtBuildingPersent3.Text))
            txtBuildingPriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtBuildingPrice.Text) * CDec(txtBuildingTotalDeteriorate.Text)) / 100)
        End If
    End Sub

    Protected Sub txtBuildingPersent2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuildingPersent2.TextChanged
        If txtBuildingAge.Text = String.Empty Or txtBuildingPersent1.Text = String.Empty Or txtBuildingPersent2.Text = String.Empty Or txtBuildingPersent3.Text = String.Empty Then
            Exit Sub
        Else
            txtBuildingTotalDeteriorate.Text = CInt(txtBuildingAge.Text) * (CDec(txtBuildingPersent1.Text) + CDec(txtBuildingPersent2.Text) + CDec(txtBuildingPersent3.Text))
            txtBuildingPriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtBuildingPrice.Text) * CDec(txtBuildingTotalDeteriorate.Text)) / 100)
        End If
    End Sub

    Protected Sub txtBuildAddArea_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuildAddArea.TextChanged
        If txtBuildAddAge.Text = String.Empty Or txtBuildAddPersent1.Text = String.Empty Or txtBuildAddPersent2.Text = String.Empty Or txtBuildAddPersent3.Text = String.Empty Then
            Exit Sub
        Else
            txtBuildingTotalDeteriorate.Text = CInt(txtBuildAddAge.Text) * (CDec(txtBuildAddPersent1.Text) + CDec(txtBuildAddPersent2.Text) + CDec(txtBuildingPersent3.Text))
            txtBuildAddPriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtBuildAddPrice.Text) * CDec(txtBuildAddTotalDeteriorate.Text)) / 100)
        End If
    End Sub

    Protected Sub txtBuildAddUnitPrice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuildAddUnitPrice.TextChanged
        If txtBuildAddAge.Text = String.Empty Or txtBuildAddPersent1.Text = String.Empty Or txtBuildAddPersent2.Text = String.Empty Or txtBuildAddPersent3.Text = String.Empty Then
            Exit Sub
        Else
            txtBuildingTotalDeteriorate.Text = CInt(txtBuildAddAge.Text) * (CDec(txtBuildAddPersent1.Text) + CDec(txtBuildAddPersent2.Text) + CDec(txtBuildingPersent3.Text))
            txtBuildAddPriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtBuildAddPrice.Text) * CDec(txtBuildAddTotalDeteriorate.Text)) / 100)
        End If
    End Sub

    Private Sub CalBuildingNotFinish()
        If CDec(txtBuildingPrice.Text) >= 0 Then
            If CDec(txtFinishPercent.Text) <= 100 Then
                txtPriceNotFinish.Text = String.Format("{0:N2}", CDec(txtBuildingPrice.Text) * ((CInt(txtFinishPercent.Text) / 100)))
            Else
                s = "<script language=""javascript"">alert('เปอร์เซ็นต์สิ่งปลูกสร้างสร้างเสร็จมีค่ามากกว่า 100 %');</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", s)
            End If
        Else
            txtPriceNotFinish.Text = "0.00"
        End If
        If CDec(txtBuildAddPrice.Text) >= 0 Then
            If CDec(txtFinishPercent1.Text) <= 100 Then
                txtPriceNotFinish1.Text = String.Format("{0:N2}", CDec(txtBuildAddPrice.Text) * ((CInt(txtFinishPercent1.Text) / 100)))
            Else
                s = "<script language=""javascript"">alert('เปอร์เซ็นต์ส่วนต่อเติมสร้างเสร็จมีค่ามากกว่า 100 %');</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", s)
            End If
        Else
            txtPriceNotFinish1.Text = "0.00"
        End If

    End Sub

    Protected Sub ImageButton_Verify_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton_Verify.Click
        If txtChanodeNo.Text = String.Empty Or txtBuild_No.Text = String.Empty Or ddlProvince.SelectedValue = 0 Then
            s = "<script language=""javascript"">alert('คุณยังไม่ได้ใส่ เลขโฉนด หรือ เลขสิ่งปลูกสร้าง หรือ จังหวัด');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "แจ้งเตือนการค้นหา", s)
        Else
            Dim Get_Address As List(Of Price3_70) = GET_PRICE3_70_ADDRESS(txtChanodeNo.Text, txtBuild_No.Text, ddlProvince.SelectedValue)
            If Get_Address.Count > 0 Then
                txtOwnership.Text = Get_Address.Item(0).Ownership
                txtBuild_No.Text = Get_Address.Item(0).Build_No
                txtTumbon.Text = Get_Address.Item(0).Tumbon
                txtAmphur.Text = Get_Address.Item(0).Amphur
                ddlProvince.SelectedValue = Get_Address.Item(0).Province
                ddlBuild_Character.SelectedValue = Get_Address.Item(0).Build_Character
                txtFloor.Text = Get_Address.Item(0).Floors
                txtItem.Text = Get_Address.Item(0).Item
                ddlBuild_Construct.SelectedValue = Get_Address.Item(0).Build_Construct
                ddlRoof.SelectedValue = Get_Address.Item(0).Roof
                txtRoof_Detail.Text = Get_Address.Item(0).Roof_Detail
                ddlBuild_State.SelectedValue = Get_Address.Item(0).Build_State
                txtBuild_State_Detail.Text = Get_Address.Item(0).Build_State_Detail
                txtBuilding_Detail.Text = Get_Address.Item(0).Building_Detail
                txtPriceTotal1.Text = String.Format("{0:N2}", Get_Address.Item(0).PriceTotal1)
                chkDoc1.Checked = Get_Address.Item(0).Doc1
                chkDoc2.Checked = Get_Address.Item(0).Doc2
                txtDoc_Detail.Text = Get_Address.Item(0).Doc_Detail
                txtBuildingArea.Text = Get_Address.Item(0).BuildingArea
                txtBuildingUnitPrice.Text = Get_Address.Item(0).BuildingUintPrice 'String.Format("{0:N2}", Obj_GetP70.Item(0).BuildingUintPrice)
                txtBuildingPrice.Text = String.Format("{0:N2}", Get_Address.Item(0).BuildingPrice)
                txtBuildingAge.Text = Get_Address.Item(0).BuildingAge
                txtBuildingPersent1.Text = Get_Address.Item(0).BuildingPersent1
                txtBuildingPersent2.Text = Get_Address.Item(0).BuildingPersent2
                txtBuildingPersent3.Text = Get_Address.Item(0).BuildingPersent3
                txtBuildingTotalDeteriorate.Text = (Get_Address.Item(0).BuildingAge * (Get_Address.Item(0).BuildingPersent1) - Get_Address.Item(0).BuildingPersent2 + Get_Address.Item(0).BuildingPersent3)
                txtFinishPercent.Text = Get_Address.Item(0).BuildingPercentFinish
                txtPriceNotFinish.Text = Get_Address.Item(0).BuildingPriceFinish
                txtBuildingPriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtPriceNotFinish.Text) * CDec(txtBuildingTotalDeteriorate.Text)) / 100)
                txtBuildAddArea.Text = Get_Address.Item(0).BuildAddArea
                txtBuildAddUnitPrice.Text = Get_Address.Item(0).BuildAddUintPrice 'String.Format("{0:N2}", Obj_GetP70.Item(0).BuildAddUintPrice)
                txtBuildAddPrice.Text = String.Format("{0:N2}", Get_Address.Item(0).BuildAddPrice)
                txtBuildAddAge.Text = Get_Address.Item(0).BuildAddAge
                txtBuildAddPersent1.Text = Get_Address.Item(0).BuildAddPersent1
                txtBuildAddPersent2.Text = Get_Address.Item(0).BuildAddPersent2
                txtBuildAddPersent3.Text = Get_Address.Item(0).BuildAddPersent3
                txtFinishPercent1.Text = Get_Address.Item(0).BuildAddPercentFinish
                txtPriceNotFinish1.Text = Get_Address.Item(0).BuildAddPriceFinish
                txtBuildAddTotalDeteriorate.Text = (Get_Address.Item(0).BuildAddAge * Get_Address.Item(0).BuildAddPersent1) - Get_Address.Item(0).BuildAddPersent2 + Get_Address.Item(0).BuildAddPersent3 'Obj_GetP70.Item(0).BuildAddPriceTotalDeteriorate
                txtBuildAddPriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtPriceNotFinish1.Text) * CDec(txtBuildAddTotalDeteriorate.Text)) / 100)
                txtBuildingDetail.Text = Get_Address.Item(0).BuildingDetail
                ddlInteriorState.SelectedValue = Get_Address.Item(0).Decoration
                ddlStandard.SelectedValue = Get_Address.Item(0).Standard_Id
                Dim Obj_P3_70D As List(Of ClsPrice3_70_Detail) = GET_PRICE3_70_DETAIL(lblId.Text, lblReq_Id.Text, lblHub_Id.Text, lblTemp_AID.Text, 0)
                If Obj_P3_70D.Count > 0 Then
                    chkDetail.Checked = True
                End If
                CalBuildingNotFinish()
            End If
        End If
    End Sub

    Private Sub SAVE_DATA()
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label) 'หา Control จาก Master Page ที่ control ไม่อยู่ใน  ContentPlaceHolder1 ของ Master Page
        If lblId.Text = "" Or lblId.Text = String.Empty Or lblId.Text = "0" Then
            'เหตุการณ์นี้เกิดจากการทบทวนประเมิน กรณีเพิ่มหลักประกันที่ดินใหม่ผูกเข้ากับ เลข AID เดิม จึงจำเป็นต้องออกเลข ID ใหม่ ให้กับที่ดิน
            lblId.Text = GET_ID_18_50_70(70)
            UPDATE_ID_70()
        End If

        AddPRICE3_70(lblId.Text, CInt(lblReq_Id.Text), CInt(lblHub_Id.Text), lblTemp_AID.Text, TextBoxAID.Text, TextBoxCID.Text, _
        CInt(DDLSubCollType.SelectedValue), txtBuild_No.Text, txtTumbon.Text, txtAmphur.Text, _
        ddlProvince.SelectedValue, ddlBuild_Character.SelectedValue, _
        txtFloor.Text, txtItem.Text, ddlBuild_Construct.SelectedValue, _
        ddlRoof.SelectedValue, txtRoof_Detail.Text, ddlBuild_State.SelectedValue, _
        txtBuild_State_Detail.Text, txtBuilding_Detail.Text, CDec(txtPriceTotal1.Text), _
        chkDoc1.Checked, chkDoc2.Checked, txtDoc_Detail.Text, String.Empty, txtChanodeNo.Text, txtOwnership.Text, txtBuildingArea.Text, CDec(txtBuildingUnitPrice.Text), _
        CDec(txtBuildingPrice.Text), txtBuildingAge.Text, txtBuildingPersent1.Text, txtBuildingPersent2.Text, txtBuildingPersent3.Text, _
        CDec(txtBuildingPriceTotalDeteriorate.Text), CInt(txtFinishPercent.Text), CDec(txtPriceNotFinish.Text), txtBuildAddArea.Text, CDec(txtBuildAddUnitPrice.Text), CDec(txtBuildAddPrice.Text), _
        txtBuildAddAge.Text, txtBuildAddPersent1.Text, txtBuildAddPersent2.Text, txtBuildAddPersent3.Text, CDec(txtBuildAddPriceTotalDeteriorate.Text), CInt(txtFinishPercent1.Text), CDec(txtPriceNotFinish1.Text), _
        txtBuildingDetail.Text, ddlInteriorState.SelectedValue, ddlStandard.SelectedValue, ddlRoofConstructure.SelectedValue, ddlRoofState.SelectedValue, lbluserid.Text, Now())

        'Save Data Price3 Detail and Partake
        'ADD_PRICE3_DETAIL_AND_PARTAKE(lblReq_Id.Text, lblHub_Id.Text, lblTemp_AID.Text)

        Dim Obj_GetP70_Review As List(Of Price3_70) = GET_PRICE3_70(lblId.Text, lblReq_Id.Text, lblHub_Id.Text, lblTemp_AID.Text)
        If Obj_GetP70_Review.Count > 0 Then
        Else
            UPDATE_Status_Appraisal_Request(lblReq_Id.Text, lblHub_Id.Text, 10)
        End If

    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Context.Items("Id") = lblId.Text
        Context.Items("Req_Id") = lblReq_Id.Text
        Context.Items("Hub_Id") = lblHub_Id.Text
        Context.Items("Coll_Type") = hdfColl_Type.Value
        Context.Items("AID") = hdfAID.Value
        Context.Items("Temp_AID") = lblTemp_AID.Text
        'Context.Items("Cif") = lblCif.Text

        'Server.Transfer("Appraisal_Price3_Form_Review.Aspx")
        Server.Transfer("Appraisal_Price3_List_AID.Aspx")
    End Sub
End Class
