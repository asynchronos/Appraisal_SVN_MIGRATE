Imports Appraisal_Manager
Partial Class Appraisal_Price3_Add_Colltype70
    Inherits System.Web.UI.Page
    Dim s As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
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
        'Dim TnBtn As Button = DirectCast(Me.FindControl("btnAddDetail"), Button)
        'TnBtn.Attributes.Add("onclick", "return ConfirmOnSave('" & lblId.Text & "');")
    End Sub

    Private Sub Show_Price2_70()
        'Dim Obj_GetP70 As List(Of PRICE2_70) = GET_PRICE2_70(lblId.Text, lblReq_Id.Text, lblHub_Id.Text)
        'If Obj_GetP70.Count > 0 Then
        '    lblId.Text = Obj_GetP70.Item(0).ID
        '    lblReq_Id.Text = Obj_GetP70.Item(0).Req_Id
        '    lblHub_Id.Text = Obj_GetP70.Item(0).Hub_Id
        '    DDLSubCollType.SelectedValue = Obj_GetP70.Item(0).MysubColl_ID
        '    txtBuild_No.Text = Obj_GetP70.Item(0).Build_No
        '    txtTumbon.Text = Obj_GetP70.Item(0).Tumbon
        '    txtAmphur.Text = Obj_GetP70.Item(0).Amphur
        '    ddlProvince.SelectedValue = Obj_GetP70.Item(0).Province
        '    ddlBuild_Character.SelectedValue = Obj_GetP70.Item(0).Build_Character
        '    txtFloor.Text = Obj_GetP70.Item(0).Floors
        '    txtItem.Text = Obj_GetP70.Item(0).Item
        '    ddlBuild_Construct.SelectedValue = Obj_GetP70.Item(0).Build_Construct
        '    ddlRoof.SelectedValue = Obj_GetP70.Item(0).Roof
        '    txtRoof_Detail.Text = Obj_GetP70.Item(0).Roof_Detail
        '    ddlBuild_State.SelectedValue = Obj_GetP70.Item(0).Build_State
        '    txtBuild_State_Detail.Text = Obj_GetP70.Item(0).Build_State_Detail
        '    txtBuilding_Detail.Text = Obj_GetP70.Item(0).Building_Detail
        '    txtPriceTotal1.Text = String.Format("{0:N2}", Obj_GetP70.Item(0).PriceTotal1)
        '    chkDoc1.Checked = Obj_GetP70.Item(0).Doc1
        '    chkDoc2.Checked = Obj_GetP70.Item(0).Doc2
        '    txtDoc_Detail.Text = Obj_GetP70.Item(0).Doc_Detail
        'End If
        Dim P2_70New As List(Of Price2_70_New) = GET_PRICE2_70_NEW(lblId.Text, lblReq_Id.Text, lblHub_Id.Text)
        If P2_70New.Count = 0 Then
        Else
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
            '***************ยังไม่ได้เพิ่ม field นี้*********************
            'ddlRoofState.SelectedValue = Obj_GetP70.Item(0).Roof
            '****************************************************
            ddlBuild_State.SelectedValue = Obj_GetP70.Item(0).Build_State
            txtBuild_State_Detail.Text = Obj_GetP70.Item(0).Build_State_Detail
            txtBuilding_Detail.Text = Obj_GetP70.Item(0).Building_Detail
            txtPriceTotal1.Text = String.Format("{0:N2}", Obj_GetP70.Item(0).PriceTotal1)
            chkDoc1.Checked = Obj_GetP70.Item(0).Doc1
            chkDoc2.Checked = Obj_GetP70.Item(0).Doc2
            txtDoc_Detail.Text = Obj_GetP70.Item(0).Doc_Detail
            txtBuildingArea.Text = Obj_GetP70.Item(0).BuildingArea
            txtBuildingUnitPrice.Text = String.Format("{0:N2}", Obj_GetP70.Item(0).BuildingUintPrice)
            txtBuildingPrice.Text = String.Format("{0:N2}", Obj_GetP70.Item(0).BuildingPrice)
            txtBuildingAge.Text = Obj_GetP70.Item(0).BuildingAge
            txtBuildingPersent1.Text = Obj_GetP70.Item(0).BuildingPersent1
            txtBuildingPersent2.Text = Obj_GetP70.Item(0).BuildingPersent2
            txtBuildingPersent3.Text = Obj_GetP70.Item(0).BuildingPersent3
            txtBuildingTotalDeteriorate.Text = Obj_GetP70.Item(0).BuildingAge * (Obj_GetP70.Item(0).BuildingPersent1 + Obj_GetP70.Item(0).BuildingPersent2 + Obj_GetP70.Item(0).BuildingPersent3)
            txtFinishPercent.Text = Obj_GetP70.Item(0).BuildingPercentFinish
            txtPriceNotFinish.Text = Obj_GetP70.Item(0).BuildingPriceFinish
            txtBuildingPriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtPriceNotFinish.Text) * CDec(txtBuildingTotalDeteriorate.Text)) / 100)
            txtBuildAddArea.Text = Obj_GetP70.Item(0).BuildAddArea
            txtBuildAddUnitPrice.Text = String.Format("{0:N2}", Obj_GetP70.Item(0).BuildAddUintPrice)
            txtBuildAddPrice.Text = String.Format("{0:N2}", Obj_GetP70.Item(0).BuildAddPrice)
            txtBuildAddAge.Text = Obj_GetP70.Item(0).BuildAddAge
            txtBuildAddPersent1.Text = Obj_GetP70.Item(0).BuildAddPersent1
            txtBuildAddPersent2.Text = Obj_GetP70.Item(0).BuildAddPersent2
            txtBuildAddPersent3.Text = Obj_GetP70.Item(0).BuildAddPersent3
            txtFinishPercent1.Text = Obj_GetP70.Item(0).BuildAddPercentFinish
            txtPriceNotFinish1.Text = Obj_GetP70.Item(0).BuildAddPriceFinish
            txtBuildAddTotalDeteriorate.Text = Obj_GetP70.Item(0).BuildAddAge * (Obj_GetP70.Item(0).BuildAddPersent1 + Obj_GetP70.Item(0).BuildAddPersent2 + Obj_GetP70.Item(0).BuildAddPersent3) 'Obj_GetP70.Item(0).BuildAddPriceTotalDeteriorate
            txtBuildAddPriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtPriceNotFinish1.Text) * CDec(txtBuildAddTotalDeteriorate.Text)) / 100)
            txtBuildingDetail.Text = Obj_GetP70.Item(0).BuildingDetail
            ddlInteriorState.SelectedValue = Obj_GetP70.Item(0).Decoration
            ddlStandard.SelectedValue = Obj_GetP70.Item(0).Standard_Id
            Dim Obj_P3_70D As List(Of ClsPrice3_70_Detail) = GET_PRICE3_70_DETAIL(lblId.Text, lblReq_Id.Text, lblHub_Id.Text, lblTemp_AID.Text, 0)
            If Obj_P3_70D.Count > 0 Then
                chkDetail.Checked = True
            End If
            CalBuildingNotFinish()
        End If
    End Sub

    Protected Sub ImageSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSave.Click
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label) 'หา Control จาก Master Page ที่ control ไม่อยู่ใน  ContentPlaceHolder1 ของ Master Page
        SAVE_DATA()
        'UPDATE_Status_Appraisal_Request(lblReq_Id.Text, lblHub_Id.Text, 6)
        Response.Redirect("Appraisal_Price3_List.aspx")
    End Sub

    Protected Sub btnAddDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddDetail.Click
        'MsgBox("Tranfer to Appraisal_Price3_Add_Colltype70Detail.aspx")
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        SAVE_DATA()
        Context.Items("Req_Id") = lblReq_Id.Text
        Context.Items("Hub_Id") = lblHub_Id.Text
        Context.Items("Temp_AID") = lblTemp_AID.Text
        Context.Items("ID") = lblId.Text
        Context.Items("User_ID") = lbluserid.Text


        'Dim Obj_GetP70 As List(Of Price3_70) = GET_PRICE3_70(lblId.Text, lblReq_Id.Text, lblHub_Id.Text, lblTemp_AID.Text)
        'If Obj_GetP70.Count > 0 Then
        'Else
        '    sender.Attributes.Add("onclick", "return ConfirmOnSave('" & lblId.Text & "');")
        'End If
        Server.Transfer("Appraisal_Price3_Add_Colltype70Detail.aspx")
    End Sub

    Protected Sub ImagePrint_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImagePrint.Click
        Context.Items("ID") = lblId.Text
        Context.Items("Req_Id") = lblReq_Id.Text
        Context.Items("Hub_Id") = lblHub_Id.Text
        Context.Items("Temp_AID") = lblTemp_AID.Text
        Server.Transfer("Appraisal_Price3_Print_CollType70_New.aspx")
    End Sub

    Protected Sub btnAdPartake_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdPartake.Click
        SAVE_DATA()
        Context.Items("Id") = lblId.Text
        Context.Items("Temp_AID") = lblTemp_AID.Text
        Context.Items("Req_Id") = lblReq_Id.Text
        Context.Items("Hub_Id") = lblHub_Id.Text
        Context.Items("Building_No") = txtBuild_No.Text
        Server.Transfer("Appraisal_Price3_70_Partake.aspx")
    End Sub

    Protected Sub txtBuildingTotalDeteriorate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuildingTotalDeteriorate.TextChanged
        Dim TotPersent As Decimal
        TotPersent = CInt(txtBuildingAge.Text) * (CDec(txtBuildingPersent1.Text) + CDec(txtBuildingPersent2.Text) + CDec(txtBuildingPersent1.Text))
    End Sub

    Protected Sub txtBuildingArea_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuildingArea.TextChanged
        'If txtBuildingArea.Text = String.Empty Or txtBuildingUnitPrice.Text = String.Empty Then
        '    Exit Sub
        'Else
        '    txtBuildingPrice.Text = String.Format("{0:N2}", CDec(txtBuildingArea.Text) * CDec(txtBuildingUnitPrice.Text))
        'End If
        CalBuilding()
        CalBuildingNotFinish()
    End Sub

    Protected Sub txtBuildingUnitPrice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuildingUnitPrice.TextChanged
        'If txtBuildingArea.Text = String.Empty Or txtBuildingUnitPrice.Text = String.Empty Then
        '    Exit Sub
        'Else
        '    txtBuildingPrice.Text = String.Format("{0:N2}", CDec(txtBuildingArea.Text) * CDec(txtBuildingUnitPrice.Text))
        'End If
        CalBuilding()
        CalBuildingNotFinish()
    End Sub

    Protected Sub txtBuildingAge_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuildingAge.TextChanged
        'If txtBuildingAge.Text = String.Empty Or txtBuildingPersent1.Text = String.Empty Or txtBuildingPersent2.Text = String.Empty Or txtBuildingPersent3.Text = String.Empty Then
        '    Exit Sub
        'Else
        '    txtBuildingTotalDeteriorate.Text = CInt(txtBuildingAge.Text) * (CDec(txtBuildingPersent1.Text) + CDec(txtBuildingPersent2.Text) + CDec(txtBuildingPersent3.Text))
        '    txtBuildingPriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtBuildingPrice.Text) * CDec(txtBuildingTotalDeteriorate.Text)) / 100)
        'End If
        CalBuildingDeteriorate()
        CalBuildingNotFinish()
    End Sub

    Protected Sub txtBuildingPersent3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuildingPersent3.TextChanged
        'If txtBuildingAge.Text = String.Empty Or txtBuildingPersent1.Text = String.Empty Or txtBuildingPersent2.Text = String.Empty Or txtBuildingPersent3.Text = String.Empty Then
        '    Exit Sub
        'Else
        '    txtBuildingTotalDeteriorate.Text = CInt(txtBuildingAge.Text) * (CDec(txtBuildingPersent1.Text) + CDec(txtBuildingPersent2.Text) + CDec(txtBuildingPersent3.Text))
        '    txtBuildingPriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtBuildingPrice.Text) * CDec(txtBuildingTotalDeteriorate.Text)) / 100)
        'End If
        CalBuildingDeteriorate()
        CalBuildingNotFinish()
    End Sub

    Protected Sub txtBuildingPersent1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuildingPersent1.TextChanged
        'If txtBuildingAge.Text = String.Empty Or txtBuildingPersent1.Text = String.Empty Or txtBuildingPersent2.Text = String.Empty Or txtBuildingPersent3.Text = String.Empty Then
        '    Exit Sub
        'Else
        '    txtBuildingTotalDeteriorate.Text = CInt(txtBuildingAge.Text) * (CDec(txtBuildingPersent1.Text) + CDec(txtBuildingPersent2.Text) + CDec(txtBuildingPersent3.Text))
        '    txtBuildingPriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtBuildingPrice.Text) * CDec(txtBuildingTotalDeteriorate.Text)) / 100)
        'End If
        CalBuildingDeteriorate()
        CalBuildingNotFinish()
    End Sub

    Protected Sub txtBuildingPersent2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuildingPersent2.TextChanged
        'If txtBuildingAge.Text = String.Empty Or txtBuildingPersent1.Text = String.Empty Or txtBuildingPersent2.Text = String.Empty Or txtBuildingPersent3.Text = String.Empty Then
        '    Exit Sub
        'Else
        '    txtBuildingTotalDeteriorate.Text = CInt(txtBuildingAge.Text) * (CDec(txtBuildingPersent1.Text) + CDec(txtBuildingPersent2.Text) + CDec(txtBuildingPersent3.Text))
        '    txtBuildingPriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtBuildingPrice.Text) * CDec(txtBuildingTotalDeteriorate.Text)) / 100)
        'End If
        CalBuildingDeteriorate()
        CalBuildingNotFinish()
    End Sub

    Protected Sub txtBuildAddArea_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuildAddArea.TextChanged
        'If txtBuildAddAge.Text = String.Empty Or txtBuildAddPersent1.Text = String.Empty Or txtBuildAddPersent2.Text = String.Empty Or txtBuildAddPersent3.Text = String.Empty Then
        '    Exit Sub
        'Else
        '    txtBuildAddTotalDeteriorate.Text = CInt(txtBuildAddAge.Text) * (CDec(txtBuildAddPersent1.Text) + CDec(txtBuildAddPersent2.Text) + CDec(txtBuildingPersent3.Text))
        '    txtBuildAddPriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtBuildAddPrice.Text) * CDec(txtBuildAddTotalDeteriorate.Text)) / 100)
        'End If
        CalBuildAddDeteriorate()
    End Sub

    Protected Sub txtBuildAddUnitPrice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuildAddUnitPrice.TextChanged
        If txtBuildAddAge.Text = String.Empty Or txtBuildAddPersent1.Text = String.Empty Or txtBuildAddPersent2.Text = String.Empty Or txtBuildAddPersent3.Text = String.Empty Then
            Exit Sub
        Else
            txtBuildAddPrice.Text = String.Format("{0:N2}", CInt(txtBuildAddArea.Text) * CDec(txtBuildAddUnitPrice.Text))
            txtBuildAddTotalDeteriorate.Text = CInt(txtBuildAddAge.Text) * (CDec(txtBuildAddPersent1.Text) + CDec(txtBuildAddPersent2.Text) + CDec(txtBuildingPersent3.Text))
            txtBuildAddPriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtBuildAddPrice.Text) * CDec(txtBuildAddTotalDeteriorate.Text)) / 100)
        End If
    End Sub

    Protected Sub txtBuildAddAge_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuildAddAge.TextChanged
        'If txtBuildAddAge.Text = String.Empty Or txtBuildAddPersent1.Text = String.Empty Or txtBuildAddPersent2.Text = String.Empty Or txtBuildAddPersent3.Text = String.Empty Then
        '    Exit Sub
        'Else
        '    txtBuildAddTotalDeteriorate.Text = CInt(txtBuildAddAge.Text) * (CDec(txtBuildAddPersent1.Text) + CDec(txtBuildAddPersent2.Text) + CDec(txtBuildAddPersent3.Text))
        '    txtBuildAddPriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtBuildAddPrice.Text) * CDec(txtBuildAddTotalDeteriorate.Text)) / 100)
        'End If
        CalBuildAddDeteriorate()
    End Sub

    Protected Sub txtBuildAddPersent1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuildAddPersent1.TextChanged
        'If txtBuildAddAge.Text = String.Empty Or txtBuildAddPersent1.Text = String.Empty Or txtBuildAddPersent2.Text = String.Empty Or txtBuildAddPersent3.Text = String.Empty Then
        '    Exit Sub
        'Else
        '    txtBuildAddTotalDeteriorate.Text = CInt(txtBuildAddAge.Text) * (CDec(txtBuildAddPersent1.Text) + CDec(txtBuildAddPersent2.Text) + CDec(txtBuildAddPersent3.Text))
        '    txtBuildAddPriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtBuildAddPrice.Text) * CDec(txtBuildAddTotalDeteriorate.Text)) / 100)
        'End If
        CalBuildAddDeteriorate()
    End Sub

    Protected Sub txtBuildAddPersent2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuildAddPersent2.TextChanged
        'If txtBuildAddAge.Text = String.Empty Or txtBuildAddPersent1.Text = String.Empty Or txtBuildAddPersent2.Text = String.Empty Or txtBuildAddPersent3.Text = String.Empty Then
        '    Exit Sub
        'Else
        '    txtBuildAddTotalDeteriorate.Text = CInt(txtBuildAddAge.Text) * (CDec(txtBuildAddPersent1.Text) + CDec(txtBuildAddPersent2.Text) + CDec(txtBuildAddPersent3.Text))
        '    txtBuildAddPriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtBuildAddPrice.Text) * CDec(txtBuildAddTotalDeteriorate.Text)) / 100)
        'End If
        CalBuildAddDeteriorate()
    End Sub

    Protected Sub txtBuildAddPersent3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuildAddPersent3.TextChanged
        'If txtBuildAddAge.Text = String.Empty Or txtBuildAddPersent1.Text = String.Empty Or txtBuildAddPersent2.Text = String.Empty Or txtBuildAddPersent3.Text = String.Empty Then
        '    Exit Sub
        'Else
        '    txtBuildAddTotalDeteriorate.Text = CInt(txtBuildAddAge.Text) * (CDec(txtBuildAddPersent1.Text) + CDec(txtBuildAddPersent2.Text) + CDec(txtBuildAddPersent3.Text))
        '    txtBuildAddPriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtBuildAddPrice.Text) * CDec(txtBuildAddTotalDeteriorate.Text)) / 100)
        'End If
        CalBuildAddDeteriorate()
    End Sub

    Protected Sub txtFinishPercent_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFinishPercent.TextChanged
        CalBuildingNotFinish()
        CalBuildingDeteriorate()
    End Sub

    Protected Sub txtFinishPercent1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFinishPercent1.TextChanged
        CalBuildingNotFinish()
        CalBuildAddDeteriorate()
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

    Private Sub CalBuilding()
        If txtBuildingArea.Text = String.Empty Or txtBuildingUnitPrice.Text = String.Empty Then
            Exit Sub
        Else
            txtBuildingPrice.Text = String.Format("{0:N2}", CDec(txtBuildingArea.Text) * CDec(txtBuildingUnitPrice.Text))
        End If
    End Sub

    Private Sub CalBuildingDeteriorate()
        If txtBuildingAge.Text = String.Empty Or txtBuildingPersent1.Text = String.Empty Or txtBuildingPersent2.Text = String.Empty Or txtBuildingPersent3.Text = String.Empty Then
            Exit Sub
        Else
            txtBuildingTotalDeteriorate.Text = CInt(txtBuildingAge.Text) * (CDec(txtBuildingPersent1.Text) + CDec(txtBuildingPersent2.Text) + CDec(txtBuildingPersent3.Text))
            'txtBuildingPriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtBuildingPrice.Text) * CDec(txtBuildingTotalDeteriorate.Text)) / 100)
            txtBuildingPriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtPriceNotFinish.Text) * CDec(txtBuildingTotalDeteriorate.Text)) / 100)
        End If
    End Sub

    Private Sub CalBuildAddDeteriorate()
        If txtBuildAddAge.Text = String.Empty Or txtBuildAddPersent1.Text = String.Empty Or txtBuildAddPersent2.Text = String.Empty Or txtBuildAddPersent3.Text = String.Empty Then
            Exit Sub
        Else
            txtBuildAddTotalDeteriorate.Text = CInt(txtBuildAddAge.Text) * (CDec(txtBuildAddPersent1.Text) + CDec(txtBuildAddPersent2.Text) + CDec(txtBuildingPersent3.Text))
            txtBuildAddPriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtPriceNotFinish1.Text) * CDec(txtBuildAddTotalDeteriorate.Text)) / 100)
        End If
    End Sub

    Private Sub SAVE_DATA()
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label) 'หา Control จาก Master Page ที่ control ไม่อยู่ใน  ContentPlaceHolder1 ของ Master Page
        AddPRICE3_70(lblId.Text, CInt(lblReq_Id.Text), CInt(lblHub_Id.Text), lblTemp_AID.Text, _
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
        UPDATE_Status_Appraisal_Request(lblReq_Id.Text, lblHub_Id.Text, 10)
    End Sub

End Class
