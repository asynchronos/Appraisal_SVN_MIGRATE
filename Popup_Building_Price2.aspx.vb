Imports Appraisal_Manager

Partial Class Popup_Building_Price2
    Inherits System.Web.UI.Page

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        lblReq_Id.Text = Session("reqId")
        lblHub_Id.Text = Session("hubId")
        lblId.Text = Session("id")
        lblTemp_AID.Text = Session("tempAid")
        hhhfSubCollType.Value = 70

        If lblId.Text = String.Empty Then
        Else
            Dim P2_70New As List(Of Price2_70_New) = GET_PRICE2_70_NEW(lblId.Text, lblReq_Id.Text, lblHub_Id.Text)
            'MsgBox(P2_70New.Item(0).MysubColl_ID)
            If P2_70New.Count > 0 Then
                'lblId.Text = CDec(P2_70New.Item(0).ID)
                'lblReq_Id.Text = P2_70New.Item(0).Req_Id
                'lblHub_Id.Text = P2_70New.Item(0).Hub_Id
                DDLSubCollType.SelectedValue = P2_70New.Item(0).MysubColl_ID
                txtChanodeNo.Text = P2_70New.Item(0).Put_On_Chanode
                txtOwnership.Text = P2_70New.Item(0).Ownership
                txtBuild_No.Text = P2_70New.Item(0).Build_No
                txtTumbon.Text = P2_70New.Item(0).Tumbon
                txtAmphur.Text = P2_70New.Item(0).Amphur
                ddlProvince.SelectedValue = P2_70New.Item(0).Province
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
                ddlStandard.SelectedValue = P2_70New.Item(0).Standard_Id
            End If

        End If
    End Sub
End Class
