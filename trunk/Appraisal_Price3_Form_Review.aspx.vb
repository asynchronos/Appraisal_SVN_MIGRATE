Imports SME_SERVICE
Imports Appraisal_Manager
Imports System.Data
Imports System.Data.SqlClient

Partial Class Appraisal_Price3_Form_Review
    Inherits System.Web.UI.Page
    Dim s As String
    Dim total As Decimal

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cus_class As Customer_Class
        Dim SV As New SME_SERVICE.Service

        If Not Page.IsPostBack Then
            txtAID.Text = Context.Items("AID")
            lblCif.Text = Context.Items("Cif")
            hdfHub_Id.Value = Context.Items("Hub_Id")
            hdfReq_Id.Value = Context.Items("Req_Id")
            cus_class = SV.GetCifInfo(lblCif.Text)(0)
            If cus_class.Cif.ToString <> 0 Then
                lblCifName.Text = cus_class.cifName
            Else
                'ถ้า cif ที่ส่งมาเท่ากับ 0 ให้ Clear ค่า  ในคอนโทรล
                lblCifName.Text = ""
                Dim l As New Label
                'MessageBox("Format Exception: " & ex.Message)
                l.Text = SV.MSb("ค้นหาข้อมูลลูกค้าไม่พบ ")
                Page.Controls.Add(l)

            End If

            'หาหมายเลขโฉนด
            Dim ObjP3_Review As List(Of Price3_50_Review) = GET_PRICE3_50_REVIEW(hdfReq_Id.Value, hdfHub_Id.Value, 0)
            If ObjP3_Review.Count > 0 Then
                For i = 0 To ObjP3_Review.Count - 1
                    If i <= 1 Then
                        Dim ObjSubColl As List(Of Cls_SubCollType) = GET_SUBCOLLTYPE(ObjP3_Review.Item(i).MysubColl_ID)
                        lblChanode.Text = lblChanode.Text & ObjSubColl.Item(0).SubCollType_Name & ObjP3_Review.Item(i).Address_No & ","
                    Else
                        lblChanode.Text = "ตามเอกสารแนบ"
                        Exit For
                    End If
                Next
            End If
            'แสดงรายละเอียดข้อมูล
            Form_Information()

        End If
    End Sub

    Protected Sub btnChangeLand_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangeLand.Click
        If RadioButtonList1.SelectedValue = 1 Or RadioButtonList2.SelectedValue = 1 Or RadioButtonList3.SelectedValue = 1 Or RadioButtonList4.SelectedValue = 1 Then

            Context.Items("Req_Id") = hdfReq_Id.Value
            Context.Items("Hub_Id") = hdfHub_Id.Value
            Context.Items("CollType") = 50
            Context.Items("Cif") = lblCif.Text
            Context.Items("CifName") = lblCifName.Text
            Context.Items("AID") = txtAID.Text
            Server.Transfer("Appraisal_Price3_Review_Coll_List.aspx")
        Else
            s = "<script language=""javascript"">alert('คุณไม่ได้เลือกเปลี่ยนแปลงคุณสมบัติที่ดิน');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", s)
        End If

    End Sub

    Protected Sub btnChangeBuilding_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangeBuilding.Click
        If RadioButtonList5.SelectedValue = 1 Then
            Context.Items("Req_Id") = hdfReq_Id.Value
            Context.Items("Hub_Id") = hdfHub_Id.Value
            Context.Items("CollType") = 70
            Context.Items("Cif") = lblCif.Text
            Context.Items("CifName") = lblCifName.Text
            Context.Items("AID") = txtAID.Text
            Server.Transfer("Appraisal_Price3_Review_Coll_List.aspx")
        Else
            s = "<script language=""javascript"">alert('คุณไม่ได้เลือกเปลี่ยนแปลงสิ่งปลูกสร้าง');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", s)
        End If
    End Sub

    Private Function CreateDataset(ByVal CollType As Integer, ByVal TableName As String) As DataSet

        'For Print Data Out
        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        MyConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)

        MyDataAdapter = New SqlDataAdapter("GET_TOTAL_COLLTYPE", MyConnection)
        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@CollType", SqlDbType.Int))
        MyDataAdapter.SelectCommand.Parameters("@CollType").Value = CollType
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Req_Id", SqlDbType.Int))
        MyDataAdapter.SelectCommand.Parameters("@Req_Id").Value = hdfReq_Id.Value
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Hub_Id", SqlDbType.Int))
        MyDataAdapter.SelectCommand.Parameters("@Hub_Id").Value = hdfHub_Id.Value
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@TableName", SqlDbType.Text))
        MyDataAdapter.SelectCommand.Parameters("@TableName").Value = TableName

        DS = New DataSet() 'Create a new DataSet to hold the records.
        MyDataAdapter.Fill(DS, "GET_TOTAL_COLLTYPE") 'Fill the DataSet with the rows returned.
        Return DS

    End Function

    Protected Sub ImageSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSave.Click
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label) 'หา Control จาก Master Page ที่ control ไม่อยู่ใน  ContentPlaceHolder1 ของ Master Page
        Dim ReceiveDate As Date = CDate(txtReceive_Date.Text)
        Dim AppraisalDate As Date = CDate(txtAppraisal_Date.Text)
        Dim Memodate As Date = CDate(txtMemo_Date.Text)
        'Dim s As String
        Dim cif As Integer = 0
        Dim AID As Integer = 0
        Dim Lat As Double
        Dim Lng As Double
        If lblCif.Text <> String.Empty Then
            cif = lblCif.Text
        End If
        If txtAID.Text <> String.Empty Then
            AID = txtAID.Text
        End If
        'ตรวจสอบว่ามีการส่งประเมินใหม่หรือทบทวนประเมิน
        'Dim Obj_GetP1Master As List(Of ClsPrice1_Master) = GetPrice1_Master(HiddenField1.Value, HiddenField2.Value)
        'If Obj_GetP1Master.Count > 0 Then
        '    Lat = Obj_GetP1Master.Item(0).Lat
        '    Lng = Obj_GetP1Master.Item(0).Lng

        'ตรวจสอบการบันทึกข้อมูลว่ามีอยู่แล้วหรือไม่
        Dim Obj_P3M_Reveiw As List(Of Price3_Master_Review) = GET_PRICE3_MASTER_REVIEW(lblCif.Text, txtAID.Text, lblCif.Text)
        Dim Obj_P3M As List(Of clsPrice3_Master) = GET_PRICE3_MASTER(hdfReq_Id.Value, hdfTemp_AID.Value)
        'มีข้อมูลแล้วให้ Update
        If Obj_P3M_Reveiw.Count > 0 And Obj_P3M.Count > 0 Then
            'Update Table Price3_Master
            AddPRICE3_Master(hdfReq_Id.Value, _
                 txtAID.Text, _
                 hdfTemp_AID.Value, _
                 txtInform_To.Text, _
                 lblCif.Text, _
                 Lat, _
                 Lng, _
                 AppraisalDate, _
                 ReceiveDate, _
                 CDec(lblPriceWah.Text), _
                 CDec(lblLandTotal.Text), _
                 txtApprove1.Text, _
                 txtApprove2.Text, _
                 txtApprove3.Text, _
                 0, _
                 ChkProblem.Checked, _
                 txtProblem_Detail.Text, _
                 txtBuy_Sale_Comment.Text, _
                 ddlAppraisal_Type.SelectedValue, _
                 ddlComment.SelectedValue, _
                 ddlWarning.SelectedValue, _
                 txtWarning_Detail.Text, _
                 ddlBranch.SelectedValue, _
                 ddlUserAppraisal.SelectedValue, _
                 lbluserid.Text, _
                 Now())
            'Update Table Price3_Master_Review
            MsgBox(RadioButtonList1.SelectedValue)
            UPDATE_PRICE3_MASTER_REVIEW(hdfReq_Id.Value, txtAID.Text, hdfTemp_AID.Value, lblCif.Text, Memodate, txtSequence.Text, RadioButtonList1.SelectedValue, txtLandDetail.Text, _
                                     RadioButtonList2.SelectedValue, txtObligation.Text, RadioButtonList3.SelectedValue, txtLandAddress.Text, RadioButtonList4.SelectedValue, _
                                     RadioButtonList5.SelectedValue, txtBuilding.Text, txtLast_Appraisal_Detail.Text, lbluserid.Text, Now())
        Else 'ยังไม่มีข้อมูลให้ Insert
            Lat = 0
            Lng = 0
            AddPRICE3_Master(hdfReq_Id.Value, _
                             txtAID.Text, _
                             hdfTemp_AID.Value, _
                             txtInform_To.Text, _
                             lblCif.Text, _
                             Lat, _
                             Lng, _
                             AppraisalDate, _
                             ReceiveDate, _
                             CDec(lblPriceWah.Text), _
                             CDec(lblLandTotal.Text), _
                             txtApprove1.Text, _
                             txtApprove2.Text, _
                             txtApprove3.Text, _
                             0, _
                             ChkProblem.Checked, _
                             txtProblem_Detail.Text, _
                             txtBuy_Sale_Comment.Text, _
                             ddlAppraisal_Type.SelectedValue, _
                             ddlComment.SelectedValue, _
                             ddlWarning.SelectedValue, _
                             txtWarning_Detail.Text, _
                             ddlBranch.SelectedValue, _
                             ddlUserAppraisal.SelectedValue, _
                             lbluserid.Text, _
                             Now())
            ADD_PRICE3_MASTER_REVIEW(hdfReq_Id.Value, txtAID.Text, hdfTemp_AID.Value, lblCif.Text, Memodate, txtSequence.Text, RadioButtonList1.SelectedValue, txtLandDetail.Text, _
                                     RadioButtonList2.SelectedValue, txtObligation.Text, RadioButtonList3.SelectedValue, txtLandAddress.Text, RadioButtonList4.SelectedValue, _
                                     RadioButtonList5.SelectedValue, txtBuilding.Text, txtLast_Appraisal_Detail.Text, lbluserid.Text, Now())

        End If


        'Server.Transfer("Appraisal_Price3_List.aspx")
        'Else
        's = "<script language=""javascript"">alert('ไม่มีเลขที่คำขอนี้ หรือ ไม่มีการกำหนด Lat Lng อยู่ในระบบ');</script>"
        'Page.ClientScript.RegisterStartupScript(Me.GetType, "ผิดพลาด", s)
        'End If
    End Sub

    Private Sub Form_Information()

        'หาเนื้อที่รวมที่ดิน
        Dim DS As DataSet
        DS = CreateDataset(50, "PRICE3_50_REVIEW")
        If DS.Tables(0).Rows.Item(0).Item("CntID") > 0 Then
            hdfTemp_AID.Value = DS.Tables(0).Rows.Item(0).Item("Temp_AID")
            lblLandArea.Text = DS.Tables(0).Rows.Item(0).Item("Rai") & "-" & DS.Tables(0).Rows.Item(0).Item("Ngan") & "-" & DS.Tables(0).Rows.Item(0).Item("Wah")
            lblSize.Text = DS.Tables(0).Rows.Item(0).Item("Rai") & "-" & DS.Tables(0).Rows.Item(0).Item("Ngan") & "-" & DS.Tables(0).Rows.Item(0).Item("Wah") & "ไร่"
            lblPriceWah.Text = Format(DS.Tables(0).Rows.Item(0).Item("PriceTotal1") / DS.Tables(0).Rows.Item(0).Item("Totalwah"), "#,##0.00")  'Format(DS.Tables(0).Rows.Item(0).Item("PriceWah"), "#,##0.00") & " บาท"
            lblLandTotal.Text = Format(DS.Tables(0).Rows.Item(0).Item("PriceTotal1"), "#,##0.00")
            Dim OjbColour As List(Of Cls_Area_Colour) = GET_AREA_COLOUR_INFO(DS.Tables(0).Rows.Item(0).Item("AreaColour_No"))
            lblAreaColour.Text = OjbColour.Item(0).AreaColour_Name
            Dim Obj_BuysaleState As List(Of Cls_Buy_Sale_State) = GET_BUYSALE_STATE_INFO(DS.Tables(0).Rows.Item(0).Item("AreaColour_No"))
            lblBuySaleState_Name.Text = Obj_BuysaleState.Item(0).BuySale_State_Name
        End If
        'หาเนื้อที่รวมสิ่งปลูกสร้าง
        DS = CreateDataset(70, "PRICE3_70_REVIEW")
        If DS.Tables(0).Rows.Item(0).Item("CntID") > 0 Then
            If Not IsDBNull(DS.Tables(0).Rows.Item(0).Item("BuildingArea")) Then
                lblDistrict.Text = DS.Tables(0).Rows.Item(0).Item("District")
                lblAmphur.Text = DS.Tables(0).Rows.Item(0).Item("Amphur")
                Dim Obj_province As List(Of Cls_PROVINCE) = GET_PROVINCE_INFO(DS.Tables(0).Rows.Item(0).Item("Province"))
                lblProvinceName.Text = Obj_province.Item(0).PROV_NAME
                'lblArea.Text = DS.Tables(0).Rows.Item(0).Item("BuildingArea")
                'lblUnitPrice.Text = Format(DS.Tables(0).Rows.Item(0).Item("BuildingUintPrice"), "#,##0.00")
                'lblCostPrice.Text = Format(DS.Tables(0).Rows.Item(0).Item("BuildingPrice"), "#,##0.00")
                'lblAge.Text = DS.Tables(0).Rows.Item(0).Item("BuildingAge")
                'lblYearDamage.Text = DS.Tables(0).Rows.Item(0).Item("BuildingPersent1")
                'lblAdap.Text = DS.Tables(0).Rows.Item(0).Item("BuildingPersent2")
                'lblDecadent.Text = DS.Tables(0).Rows.Item(0).Item("BuildingPersent3")
                'lblP_Damage.Text = (DS.Tables(0).Rows.Item(0).Item("BuildingPersent1") + DS.Tables(0).Rows.Item(0).Item("BuildingPersent2") + DS.Tables(0).Rows.Item(0).Item("BuildingPersent3")) * DS.Tables(0).Rows.Item(0).Item("BuildingAge")
                'lblDamageBth.Text = DS.Tables(0).Rows.Item(0).Item("BuildingPriceTotalDeteriorate")
                'Dim obj_Decoration As List(Of cls_
                ddlInteriorState.SelectedValue = DS.Tables(0).Rows.Item(0).Item("Decoration")
                'lblDecoration.Text = DS.Tables(0).Rows.Item(0).Item("Decoration")
                'If CDec(lblCostPrice.Text) <> 0 Then
                '    lblDamageBth.Text = Format(CDec(lblCostPrice.Text) * (CDbl(lblP_Damage.Text) / 100), "#,##0.00")
                '    lbltotalPrice.Text = Format(CDbl(lblCostPrice.Text) - CDbl(lblDamageBth.Text), "#,##0.00")
                'Else
                '    lblDamageBth.Text = "0.00"
                '    lbltotalPrice.Text = "0.00"
                'End If

                'หา PRICE3_MASTER_REVIEW หากมีจะดึงข้อมูลเดิมมาให้
                Dim Obj_P3M_Reveiw As List(Of Price3_Master_Review) = GET_PRICE3_MASTER_REVIEW(lblCif.Text, txtAID.Text, lblCif.Text)
                If Obj_P3M_Reveiw.Count > 0 Then
                    txtMemo_Date.Text = Obj_P3M_Reveiw.Item(0).Memo_Date
                    txtSequence.Text = Obj_P3M_Reveiw.Item(0).Sequence + 1
                    RadioButtonList1.SelectedValue = Obj_P3M_Reveiw.Item(0).Land_Chg
                    If Obj_P3M_Reveiw.Item(0).Land_Chg = 0 Then
                        txtLandDetail.Enabled = False
                    Else
                        txtLandDetail.Enabled = True
                    End If
                    txtLandDetail.Text = Obj_P3M_Reveiw.Item(0).Land_Chg_Detail
                    RadioButtonList2.SelectedValue = Obj_P3M_Reveiw.Item(0).Obligation_Chg
                    If Obj_P3M_Reveiw.Item(0).Obligation_Chg = 0 Then
                        txtObligation.Enabled = False
                    Else
                        txtObligation.Enabled = True
                    End If
                    txtObligation.Text = Obj_P3M_Reveiw.Item(0).Obligation_Chg_Detail
                    RadioButtonList3.SelectedValue = Obj_P3M_Reveiw.Item(0).Site_Chg
                    If Obj_P3M_Reveiw.Item(0).Site_Chg = 0 Then
                        txtLandAddress.Enabled = False
                    Else
                        txtLandAddress.Enabled = True
                    End If
                    txtLandAddress.Text = Obj_P3M_Reveiw.Item(0).Site_Chg_Detail
                    RadioButtonList4.SelectedValue = Obj_P3M_Reveiw.Item(0).Progress_Chg
                    RadioButtonList5.SelectedValue = Obj_P3M_Reveiw.Item(0).Building_Chg
                    If Obj_P3M_Reveiw.Item(0).Building_Chg = 0 Then
                        txtBuilding.Enabled = False
                    Else
                        txtBuilding.Enabled = True
                    End If
                    txtBuilding.Text = Obj_P3M_Reveiw.Item(0).Building_Chg_Detail
                    txtLast_Appraisal_Detail.Text = Obj_P3M_Reveiw.Item(0).Appraisal_Last_Detail
                    Dim Obj_P3M As List(Of clsPrice3_Master) = GET_PRICE3_MASTER(hdfReq_Id.Value, hdfTemp_AID.Value)
                    txtInform_To.Text = Obj_P3M.Item(0).Inform_To
                    txtReceive_Date.Text = Obj_P3M.Item(0).Receive_Date
                    txtAppraisal_Date.Text = Obj_P3M.Item(0).Appraisal_Date
                    ddlBranch.SelectedValue = Obj_P3M.Item(0).Req_Dept
                    ddlUserAppraisal.SelectedValue = Obj_P3M.Item(0).Appraisal_ID
                    ChkProblem.Checked = Obj_P3M.Item(0).Env_Effect
                    txtProblem_Detail.Text = Obj_P3M.Item(0).Env_Effect_Detail
                    txtBuy_Sale_Comment.Text = Obj_P3M.Item(0).Appraisal_Detail
                    ddlAppraisal_Type.SelectedValue = Obj_P3M.Item(0).Appraisal_Type_ID
                    ddlComment.SelectedValue = Obj_P3M.Item(0).Comment_ID
                    ddlWarning.SelectedValue = Obj_P3M.Item(0).Warning_ID
                    txtWarning_Detail.Text = Obj_P3M.Item(0).Warning_Detail
                    txtApprove1.Text = Obj_P3M.Item(0).Approved1
                    txtApprove2.Text = Obj_P3M.Item(0).Approved2
                    txtApprove3.Text = Obj_P3M.Item(0).Approved3

                Else
                    txtSequence.Text = 1
                End If

                'รายละเอียดส่วนต่อเติม
                'lblArea1.Text = DS.Tables(0).Rows.Item(0).Item("BuildAddArea")
                'lblUnitPrice1.Text = Format(DS.Tables(0).Rows.Item(0).Item("BuildAddUintPrice"), "#,##0.00")
                'lblCostPrice1.Text = Format(DS.Tables(0).Rows.Item(0).Item("BuildAddPrice"), "#,##0.00")
                'lblAge1.Text = DS.Tables(0).Rows.Item(0).Item("BuildAddAge")
                'lblYearDamage1.Text = DS.Tables(0).Rows.Item(0).Item("BuildAddPersent1")
                'lblAdap1.Text = DS.Tables(0).Rows.Item(0).Item("BuildAddPersent2")
                'lblDecadent1.Text = DS.Tables(0).Rows.Item(0).Item("BuildAddPersent3")
                'lblP_Damage1.Text = (DS.Tables(0).Rows.Item(0).Item("BuildAddPersent1") + DS.Tables(0).Rows.Item(0).Item("BuildAddPersent2") + DS.Tables(0).Rows.Item(0).Item("BuildAddPersent3")) * DS.Tables(0).Rows.Item(0).Item("BuildAddAge")
                'lblDamageBth1.Text = DS.Tables(0).Rows.Item(0).Item("BuildingPriceTotalDeteriorate")
                'If CDec(lblCostPrice.Text) <> 0 Then
                '    lblDamageBth1.Text = Format(CDec(lblCostPrice1.Text) * (CDbl(lblP_Damage1.Text) / 100), "#,##0.00")
                '    lbltotalPrice1.Text = Format(CDbl(lblCostPrice1.Text) - CDbl(lblDamageBth1.Text), "#,##0.00")
                '    lblGrandTotal.Text = Format(CDbl(lbltotalPrice.Text) + CDbl(lbltotalPrice1.Text), "#,##0.00")
                '    lblBuilding_Detail.Text = DS.Tables(0).Rows.Item(0).Item("CntID") 'CntID
                '    lblBuildingPrice.Text = Format(CDbl(lbltotalPrice.Text) + CDbl(lbltotalPrice1.Text), "#,##0.00")
                '    lblGrantotal.Text = Format(CDbl(lbltotalPrice.Text) + CDbl(lbltotalPrice1.Text) + (CDbl(lbltotalPrice.Text) + CDbl(lbltotalPrice1.Text)), "#,##0.00")
                'Else
                '    lblDamageBth1.Text = "0.00"
                '    lbltotalPrice1.Text = "0.00"
                'End If

                'รายละเอียดส่วนควบ
                'ต้องดึงรายละเอียดของส่วนควบมาแสดงก่อน(On Progress)
                'Dim Obj_Partake_Reveiw As List(Of Price3_70_Review_Partake) = GET_PRICE3_70_REVIEW_PARTAKE_SUM(hdfReq_Id.Value, hdfHub_Id.Value, txtAID.Text, hdfTemp_AID.Value)
                'lblArea2.Text = Obj_Partake_Reveiw.Item(0).PartakeArea
                'lblUnitPrice2.Text = Obj_Partake_Reveiw.Item(0).PartakeUintPrice
                'lblCostPrice2.Text = Obj_Partake_Reveiw.Item(0).PartakePrice
                'lblAge2.Text = Obj_Partake_Reveiw.Item(0).PartakeAge
                'lblYearDamage2.Text = Obj_Partake_Reveiw.Item(0).PartakePersent1
                'lblAdap2.Text = Obj_Partake_Reveiw.Item(0).PartakePersent2
                'lblDecadent2.Text = Obj_Partake_Reveiw.Item(0).PartakePersent2
                'lblP_Damage2.Text = Format((Obj_Partake_Reveiw.Item(0).PartakePersent1 + Obj_Partake_Reveiw.Item(0).PartakePersent2 + Obj_Partake_Reveiw.Item(0).PartakePersent3) * (Obj_Partake_Reveiw.Item(0).PartakeAge), "#,##0.00")
                'lblDamageBth2.Text = Obj_Partake_Reveiw.Item(0).PartakePriceTotalDeteriorate
                'If CDec(lblCostPrice.Text) <> 0 Then
                '    lblDamageBth2.Text = Format(CDec(lblCostPrice2.Text) * (CDbl(lblP_Damage2.Text) / 100), "#,##0.00")
                '    lbltotalPrice2.Text = Format(CDbl(lblCostPrice2.Text) - CDbl(lblDamageBth2.Text), "#,##0.00")
                'Else
                '    lblDamageBth2.Text = "0.00"
                '    lbltotalPrice2.Text = "0.00"
                'End If
                'Else
                '    lblArea.Text = "0"
                '    lblUnitPrice.Text = "0.00"
                '    lblCostPrice.Text = "0.00"
                '    lblAge.Text = "0"
                '    lblYearDamage.Text = "0.00"
                '    lblAdap.Text = "0.00"
                '    lblDecadent.Text = "0.00"
                '    lblP_Damage.Text = "0.00"
                '    lblDamageBth.Text = "0.00"
                '    lbltotalPrice.Text = "0.00"

                '    lblArea1.Text = "0"
                '    lblUnitPrice1.Text = "0.00"
                '    lblCostPrice1.Text = "0.00"
                '    lblAge1.Text = "0"
                '    lblYearDamage1.Text = "0.00"
                '    lblAdap1.Text = "0.00"
                '    lblDecadent1.Text = "0.00"
                '    lblP_Damage1.Text = "0.00"
                '    lblDamageBth1.Text = "0.00"
                '    lbltotalPrice1.Text = "0.00"

                '    lblArea2.Text = "0"
                '    lblUnitPrice2.Text = "0.00"
                '    lblCostPrice2.Text = "0.00"
                '    lblAge2.Text = "0"
                '    lblYearDamage2.Text = "0.00"
                '    lblAdap2.Text = "0.00"
                '    lblDecadent2.Text = "0.00"
                '    lblP_Damage2.Text = "0.00"
                '    lblDamageBth2.Text = "0.00"
                '    lbltotalPrice2.Text = "0.00"
            End If
        End If


    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If RadioButtonList1.SelectedValue = 1 Then
            txtLandDetail.Enabled = True
        Else
            txtLandDetail.Enabled = False
        End If
    End Sub

    Protected Sub RadioButtonList2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList2.SelectedIndexChanged
        If RadioButtonList2.SelectedValue = 1 Then
            txtObligation.Enabled = True
        Else
            txtObligation.Enabled = False
        End If
    End Sub

    Protected Sub RadioButtonList3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList3.SelectedIndexChanged
        If RadioButtonList3.SelectedValue = 1 Then
            txtLandAddress.Enabled = True
        Else
            txtLandAddress.Enabled = False
        End If
    End Sub

    Protected Sub RadioButtonList5_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList5.SelectedIndexChanged
        If RadioButtonList5.SelectedValue = 1 Then
            txtBuilding.Enabled = True
        Else
            txtBuilding.Enabled = False
        End If
    End Sub

    Function Get_Amount(ByVal Age As Decimal, ByVal P1 As Decimal, ByVal P2 As Decimal, ByVal P3 As Decimal) As String

        Dim Amount As Decimal = Age * (P1 + P2 + P3)
        Return String.Format("{0:N2}", Amount)

    End Function

    Function Get_Amount_Bht(ByVal Price As Decimal, ByVal Age As Decimal, ByVal P1 As Decimal, ByVal P2 As Decimal, ByVal P3 As Decimal) As String

        Dim Amount_Price As Decimal = Price * (((P1 + P2 + P3) * Age) / 100)
        Return String.Format("{0:N2}", Amount_Price)

    End Function

    Function Get_Balance(ByVal Price As Decimal, ByVal Age As Decimal, ByVal P1 As Decimal, ByVal P2 As Decimal, ByVal P3 As Decimal) As String

        Dim Amount_Price As Decimal = Price - (Price * (((P1 + P2 + P3) * Age) / 100))
        total += Amount_Price
        Return String.Format("{0:N2}", Amount_Price)
        MsgBox(total)
    End Function

    Function Get_Total() As String
        lblBuildingPrice.Text = String.Format("{0:N2}", total)
        lblGrantotal.Text = String.Format("{0:N2}", CDec(lblLandTotal.Text) + CDec(lblBuildingPrice.Text))
        lblGrantotalAll.Text = String.Format("{0:N2}", CDec(lblLandTotal.Text) + CDec(lblBuildingPrice.Text))
        Return String.Format("{0:N2}", total)

    End Function

End Class
