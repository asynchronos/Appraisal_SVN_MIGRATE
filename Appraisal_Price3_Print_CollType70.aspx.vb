Imports Appraisal_Manager
Partial Class Appraisal_Price3_Print_CollType70
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            '********* Data Test **************
            'HiddenField1.Value = 5
            'HiddenField2.Value = 1
            'HiddenField3.Value = 4029
            'HiddenField4.Value = 103
            '**********************************

            HiddenField1.Value = CInt(Context.Items("ID"))
            HiddenField2.Value = CInt(Context.Items("Req_Id"))
            HiddenField3.Value = CInt(Context.Items("Hub_Id"))
            HiddenField4.Value = CInt(Context.Items("Temp_AID"))
            HiddenField5.Value = CStr(Context.Items("User_ID"))

            Show_Price3_70()
            Show_Price3_70Main()
            Show_Price3_70_Detail()
        End If

    End Sub
    Private Sub Show_Price3_70()
        Dim Obj_GetP70 As List(Of Price3_70) = GET_PRICE3_70(HiddenField1.Value, HiddenField2.Value, HiddenField3.Value, HiddenField4.Value)
        If Obj_GetP70.Count > 0 Then
            lblAddressNo.Text = Obj_GetP70.Item(0).Build_No
            lbChanodeNo.Text = Obj_GetP70.Item(0).Put_On_Chanode
            If Obj_GetP70.Item(0).MysubColl_ID = 6 Or Obj_GetP70.Item(0).MysubColl_ID = 7 Then
                CheckBox3.Checked = True

            ElseIf Obj_GetP70.Item(0).MysubColl_ID = 8 Then
                CheckBox2.Checked = True

            ElseIf Obj_GetP70.Item(0).MysubColl_ID = 9 Then
                CheckBox1.Checked = True

            Else
                CheckBox4.Checked = True
            End If
            lblTumbon.Text = Obj_GetP70.Item(0).Tumbon
            lblAmphur.Text = Obj_GetP70.Item(0).Amphur
            Dim obj_Province As List(Of Cls_PROVINCE) = GET_PROVINCE_INFO(Obj_GetP70.Item(0).Province)
            lblProvinceName.Text = obj_Province.Item(0).PROV_NAME

        End If
    End Sub

    Private Sub Show_Price3_70Main()

        Dim Obj_P3_70 As List(Of Price3_70) = GET_PRICE3_70(HiddenField1.Value, HiddenField2.Value, HiddenField3.Value, HiddenField4.Value)
        If Obj_P3_70.Count > 0 Then
            Literal1.Text = Obj_P3_70.Item(0).BuildingDetail
            lblArea.Text = Obj_P3_70.Item(0).BuildingArea
            If CheckBox1.Checked = True Then
                lblFloors1.Text = Obj_P3_70.Item(0).Floors
                lblBuildingFloors.Text = CheckBox1.Text & " " & lblFloors1.Text
            ElseIf CheckBox2.Checked = True Then
                lblFloors0.Text = Obj_P3_70.Item(0).Floors
                lblBuildingFloors.Text = CheckBox2.Text & " " & lblFloors0.Text
            ElseIf CheckBox3.Checked = True Then
                lblFloors.Text = Obj_P3_70.Item(0).Floors
                lblBuildingFloors.Text = CheckBox3.Text & " " & lblFloors.Text
            ElseIf CheckBox4.Checked = True Then

            End If
            lblUnitPrice.Text = Format(Obj_P3_70.Item(0).BuildingUintPrice, "#,##0.00")
            lblCostPrice.Text = Format(Obj_P3_70.Item(0).PriceTotal1, "#,##0.00")
            lblAge.Text = Obj_P3_70.Item(0).BuildingAge
            lblYearDamage.Text = Obj_P3_70.Item(0).BuildingPersent1
            lblAdap.Text = Obj_P3_70.Item(0).BuildingPersent2
            lblDecadent.Text = Obj_P3_70.Item(0).BuildingPersent3
            lblP_Damage.Text = CInt(Obj_P3_70.Item(0).BuildingPersent1) + CInt(Obj_P3_70.Item(0).BuildingPersent2) + CInt(Obj_P3_70.Item(0).BuildingPersent3)
            lblDamageBth.Text = Obj_P3_70.Item(0).BuildingPriceTotalDeteriorate
            lbltotalPrice.Text = Format(CDec(Obj_P3_70.Item(0).PriceTotal1), "#,##0.00")
            lblAge1.Text = Obj_P3_70.Item(0).BuildAddAge
            lblArea1.Text = Obj_P3_70.Item(0).BuildAddArea
            lblUnitPrice1.Text = Format(Obj_P3_70.Item(0).BuildAddUintPrice, "#,##0.00")
            lblCostPrice1.Text = Format(Obj_P3_70.Item(0).BuildAddPrice, "#,##0.00")
            lblYearDamage1.Text = Obj_P3_70.Item(0).BuildAddPersent1
            lblAdap1.Text = Obj_P3_70.Item(0).BuildAddPersent2
            lblDecadent1.Text = Obj_P3_70.Item(0).BuildAddPersent3
            lblP_Damage1.Text = CInt(Obj_P3_70.Item(0).BuildAddPersent1) + CInt(Obj_P3_70.Item(0).BuildAddPersent2) + CInt(Obj_P3_70.Item(0).BuildAddPersent3)
            lblDamageBth1.Text = Obj_P3_70.Item(0).BuildAddPriceTotalDeteriorate
            lbltotalPrice1.Text = Format(CDec(Obj_P3_70.Item(0).BuildAddPrice), "#,##0.00")
            lblGrandTotal.Text = Format(CDec(lbltotalPrice.Text) + CDec(lbltotalPrice1.Text), "#,##0.00")
            lblGrandTotal0.Text = Format(CDec(lbltotalPrice.Text) + CDec(lbltotalPrice1.Text), "#,##0.00")
            lblItems.Text = Obj_P3_70.Count
        End If

    End Sub
    Private Sub Show_Price3_70_Detail()

        Dim Obj_P3_70D As List(Of ClsPrice3_70_Detail) = GET_PRICE3_70_DETAIL(HiddenField1.Value, HiddenField2.Value, HiddenField3.Value, HiddenField4.Value, 0)
        If Obj_P3_70D.Count > 0 Then
            lblBuilding_Struc.Text = Obj_P3_70D.Item(0).Main_Construction
        End If

    End Sub

End Class
