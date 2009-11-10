Imports Appraisal_Manager

Partial Class Appraisal_Price3_50_Review_Edit
    Inherits System.Web.UI.Page
    Dim s As String

    Private Sub Show_Price3_50_Review()
        Dim Obj_GetP50_Review As List(Of Price3_50) = GET_PRICE3_50(lblId.Text, lblReq_Id.Text, lblHub_Id.Text, lblTemp_AID.Text)
        If Obj_GetP50_Review.Count > 0 Then
            lblId.Text = Obj_GetP50_Review.Item(0).ID
            lblReq_Id.Text = Obj_GetP50_Review.Item(0).Req_Id
            lblHub_Id.Text = Obj_GetP50_Review.Item(0).Hub_Id
            lblAID.Text = Obj_GetP50_Review.Item(0).AID
            lblCID.Text = Obj_GetP50_Review.Item(0).CID
            lblTemp_AID.Text = Obj_GetP50_Review.Item(0).Temp_AID
            DDLSubCollType.SelectedValue = Obj_GetP50_Review.Item(0).MysubColl_ID
            txtChanode.Text = Obj_GetP50_Review.Item(0).Address_No
            txtRai.Text = Obj_GetP50_Review.Item(0).Rai
            txtNgan.Text = Obj_GetP50_Review.Item(0).Ngan
            txtWah.Text = Obj_GetP50_Review.Item(0).Wah
            txtRoad.Text = Obj_GetP50_Review.Item(0).Road
            ddlRoad_Detail.SelectedValue = Obj_GetP50_Review.Item(0).Road_Detail
            txtMeter.Text = Obj_GetP50_Review.Item(0).Road_Access
            txtTumbon.Text = Obj_GetP50_Review.Item(0).Tumbon
            txtAmphur.Text = Obj_GetP50_Review.Item(0).Amphur
            ddlProvince.SelectedValue = Obj_GetP50_Review.Item(0).Province
            ddlLand_State.SelectedValue = Obj_GetP50_Review.Item(0).Land_State
            txtLand_State_Detail.Text = Obj_GetP50_Review.Item(0).Land_State_Detail
            ddlRoad_Forntoff.SelectedValue = Obj_GetP50_Review.Item(0).Road_Frontoff
            txtRoadWidth.Text = Obj_GetP50_Review.Item(0).RoadWidth
            ddlSite.Text = Obj_GetP50_Review.Item(0).Sited
            txtSite_Detail.Text = Obj_GetP50_Review.Item(0).Site_Detail
            ddlPublic_Utility.SelectedValue = Obj_GetP50_Review.Item(0).Public_Utility
            txtPublic_Utility_Detail.Text = Obj_GetP50_Review.Item(0).Public_Utility_Detail
            ddlBinifit.SelectedValue = Obj_GetP50_Review.Item(0).Binifit
            txtBinifit.Text = Obj_GetP50_Review.Item(0).Binifit_Detail
            ddlTendency.SelectedValue = Obj_GetP50_Review.Item(0).Tendency
            ddlSubUnit.SelectedValue = Obj_GetP50_Review.Item(0).SubUnit
            ddlBuySale_State.SelectedValue = Obj_GetP50_Review.Item(0).BuySale_State
            txtPriceWah.Text = Obj_GetP50_Review.Item(0).PriceWah 'Format(Obj_GetP50_Review.Item(0).PriceWah, "#,##0.00")
            txtTotal.Text = Format(Obj_GetP50_Review.Item(0).PriceTotal1, "#,##0.00")
            txtRaWang.Text = Obj_GetP50_Review.Item(0).Rawang
            txtLandNumber.Text = Obj_GetP50_Review.Item(0).LandNumber
            txtSurway.Text = Obj_GetP50_Review.Item(0).Surway
            txtDocNo.Text = Obj_GetP50_Review.Item(0).DocNo
            txtPage.Text = Obj_GetP50_Review.Item(0).PageNo
            txtOwnerShip.Text = Obj_GetP50_Review.Item(0).Ownership
            txtObligation.Text = Obj_GetP50_Review.Item(0).Obligation
            txtLand_Closeto_RoadWidth.Text = Obj_GetP50_Review.Item(0).Land_Closeto_RoadWidth
            txtDeepWidth.Text = Obj_GetP50_Review.Item(0).DeepWidth
            txtBehindWidth.Text = Obj_GetP50_Review.Item(0).BehindWidth
            ddlAreaColur.SelectedValue = Obj_GetP50_Review.Item(0).AreaColour_No
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblId.Text = Context.Items("ID")
            lblReq_Id.Text = Context.Items("Req_Id")
            lblHub_Id.Text = Context.Items("Hub_Id")
            hdfAID.Value = Context.Items("AID")
            lblTemp_AID.Text = Context.Items("Temp_AID")
            hdfColl_Type.Value = Context.Items("Coll_Type")
            lblHub_Id.Text = Context.Items("Hub_Id")
            lblCif.Text = Context.Items("Cif")
            lblCifName.Text = Context.Items("CifName")
            lblMethodDesc.Text = Context.Items("SpecialAdd")
            If lblMethodDesc.Text = "ทบทวนประเมิน" Then
                ImageSave.Visible = False
                lblSave.Visible = False
                lblCLOSE.Visible = False
                ImageButton1.Visible = False
            End If
            Show_Price3_50_Review()
        End If
    End Sub

    Protected Sub ImageSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSave.Click
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label) 'หา Control จาก Master Page ที่ control ไม่อยู่ใน  ContentPlaceHolder1 ของ Master Page
        'UPDATE_PRICE3_50_REVIEW(lblId.Text, CInt(lblReq_Id.Text), CInt(lblHub_Id.Text), lblTemp_AID.Text, CInt(DDLSubCollType.SelectedValue), txtChanode.Text, String.Empty, txtTumbon.Text, txtAmphur.Text, _
        '                                              ddlProvince.SelectedValue, CInt(txtRai.Text), CInt(txtNgan.Text), CDec(txtWah.Text), _
        '                                              txtRoad.Text, CInt(ddlRoad_Detail.SelectedValue), CDec(txtMeter.Text), CInt(ddlRoad_Forntoff.SelectedValue), _
        '                                              CDec(txtRoadWidth.Text), CInt(ddlSite.SelectedValue), CStr(txtSite_Detail.Text), CInt(ddlLand_State.SelectedValue), _
        '                                              txtLand_State_Detail.Text, CInt(ddlPublic_Utility.SelectedValue), txtPublic_Utility_Detail.Text, CInt(ddlBinifit.SelectedValue), _
        '                                              txtBinifit.Text, CInt(ddlTendency.SelectedValue), CInt(ddlBuySale_State.SelectedValue), ddlSubUnit.SelectedValue, _
        '                                              CInt(txtPriceWah.Text), CInt(txtTotal.Text), txtRaWang.Text, txtLandNumber.Text, txtSurway.Text, txtDocNo.Text, txtPage.Text, txtOwnerShip.Text, _
        '                                              txtObligation.Text, txtLand_Closeto_RoadWidth.Text, txtDeepWidth.Text, txtBehindWidth.Text, ddlAreaColur.SelectedValue, lbluserid.Text, Now())

        'เป็นการเพิ่มข้อมูลที่ดินเข้าไปในตาราง Price3_50 ถ้าหากตรวจสอบแล้วว่ามีชิ้นทรัยพ์ ID ที่ส่งไปแล้วจะทำการ Update แทนการ Save
        AddPRICE3_50(lblId.Text, CInt(lblReq_Id.Text), CInt(lblHub_Id.Text), lblTemp_AID.Text, lblAID.Text, lblCID.Text, CInt(DDLSubCollType.SelectedValue), txtChanode.Text, String.Empty, txtTumbon.Text, txtAmphur.Text, _
                     ddlProvince.SelectedValue, CInt(txtRai.Text), CInt(txtNgan.Text), CDec(txtWah.Text), _
                     txtRoad.Text, CInt(ddlRoad_Detail.SelectedValue), CDec(txtMeter.Text), txtSoi.Text, CInt(ddlRoad_Forntoff.SelectedValue), _
                     CDec(txtRoadWidth.Text), CInt(ddlSite.SelectedValue), CStr(txtSite_Detail.Text), CInt(ddlLand_State.SelectedValue), _
                     txtLand_State_Detail.Text, CInt(ddlPublic_Utility.SelectedValue), txtPublic_Utility_Detail.Text, CInt(ddlBinifit.SelectedValue), _
                     txtBinifit.Text, CInt(ddlTendency.SelectedValue), CInt(ddlBuySale_State.SelectedValue), ddlSubUnit.SelectedValue, _
                     CDec(txtPriceWah.Text), CDec(txtTotal.Text), txtRaWang.Text, txtLandNumber.Text, txtSurway.Text, txtDocNo.Text, txtPage.Text, txtOwnerShip.Text, _
                     txtObligation.Text, txtLand_Closeto_RoadWidth.Text, txtDeepWidth.Text, txtBehindWidth.Text, ddlAreaColur.SelectedValue, lbluserid.Text, Now())
        's = "<script language=""javascript"">alert('บันทึกเสร็จสมบูรณ์');</script>"
        'Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Context.Items("Id") = lblId.Text
        Context.Items("Req_Id") = lblReq_Id.Text
        Context.Items("Hub_Id") = lblHub_Id.Text
        Context.Items("Coll_Type") = hdfColl_Type.Value
        Context.Items("AID") = hdfAID.Value
        Context.Items("Temp_AID") = lblTemp_AID.Text
        Context.Items("Cif") = lblCif.Text

        'Server.Transfer("Appraisal_Price3_Form_Review.Aspx")
        Server.Transfer("Appraisal_Price3_List_AID.Aspx")

    End Sub

    Protected Sub txtPriceWah_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPriceWah.TextChanged
        Dim TotalWah As Double = 0
        If txtRai.Text = String.Empty Then
            txtRai.Text = "0"
        End If
        If txtNgan.Text = String.Empty Then
            txtNgan.Text = "0"
        End If
        If txtWah.Text = String.Empty Then
            txtWah.Text = "0"
        End If

        If txtRai.Text = "0" And txtNgan.Text = "0" And txtWah.Text = "0" Then
            s = "<script language=""javascript"">alert('ไม่มีพื้นที่ให้คำนวณราคา');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)
        Else
            TotalWah = (CDec(txtRai.Text) * 400) + (CDec(txtNgan.Text) * 100) + CDec(txtWah.Text)
            txtTotal.Text = String.Format("{0:N2}", TotalWah * CDec(txtPriceWah.Text))
        End If
    End Sub

    Protected Sub txtRai_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRai.TextChanged
        Dim TotalWah As Double = 0
        If txtRai.Text = String.Empty Then
            txtRai.Text = "0"
        End If
        If txtNgan.Text = String.Empty Then
            txtNgan.Text = "0"
        End If
        If txtWah.Text = String.Empty Then
            txtWah.Text = "0"
        End If

        If txtRai.Text = "0" And txtNgan.Text = "0" And txtWah.Text = "0" Then
            s = "<script language=""javascript"">alert('ไม่มีพื้นที่ให้คำนวณราคา');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)
        Else
            TotalWah = (CDec(txtRai.Text) * 400) + (CDec(txtNgan.Text) * 100) + CDec(txtWah.Text)
            txtTotal.Text = String.Format("{0:N2}", TotalWah * CDec(txtPriceWah.Text))
        End If
    End Sub

    Protected Sub txtNgan_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNgan.TextChanged
        Dim TotalWah As Double = 0
        If txtRai.Text = String.Empty Then
            txtRai.Text = "0"
        End If
        If txtNgan.Text = String.Empty Then
            txtNgan.Text = "0"
        End If
        If txtWah.Text = String.Empty Then
            txtWah.Text = "0"
        End If

        If txtRai.Text = "0" And txtNgan.Text = "0" And txtWah.Text = "0" Then
            s = "<script language=""javascript"">alert('ไม่มีพื้นที่ให้คำนวณราคา');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)
        Else
            TotalWah = (CDec(txtRai.Text) * 400) + (CDec(txtNgan.Text) * 100) + CDec(txtWah.Text)
            txtTotal.Text = String.Format("{0:N2}", TotalWah * CDec(txtPriceWah.Text))
        End If
    End Sub

    Protected Sub txtWah_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWah.TextChanged
        Dim TotalWah As Double = 0
        If txtRai.Text = String.Empty Then
            txtRai.Text = "0"
        End If
        If txtNgan.Text = String.Empty Then
            txtNgan.Text = "0"
        End If
        If txtWah.Text = String.Empty Then
            txtWah.Text = "0"
        End If

        If txtRai.Text = "0" And txtNgan.Text = "0" And txtWah.Text = "0" Then
            s = "<script language=""javascript"">alert('ไม่มีพื้นที่ให้คำนวณราคา');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)
        Else
            TotalWah = (CDec(txtRai.Text) * 400) + (CDec(txtNgan.Text) * 100) + CDec(txtWah.Text)
            txtTotal.Text = String.Format("{0:N2}", TotalWah * CDec(txtPriceWah.Text))
        End If
    End Sub

    Protected Sub ImageButton_Verify_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton_Verify.Click
        Dim Obj_GetP50 As List(Of Price3_50) = GET_PRICE3_50_CHANODE(txtChanode.Text, ddlProvince.SelectedValue)
        If Obj_GetP50.Count > 0 Then
            s = "<script language=""javascript"">alert('พบเลขที่โฉนดดังกล่าวระบบจะแสดงรายละเอียดดังกล่าว'); </script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)
            'lblId.Text = Obj_GetP50.Item(0).ID
            lblReq_Id.Text = Obj_GetP50.Item(0).Req_Id
            lblHub_Id.Text = Obj_GetP50.Item(0).Hub_Id
            'lblAID.Text = Obj_GetP50.Item(0).AID
            'lblCID.Text = Obj_GetP50.Item(0).CID
            DDLSubCollType.SelectedValue = Obj_GetP50.Item(0).MysubColl_ID
            txtChanode.Text = Obj_GetP50.Item(0).Address_No
            txtRai.Text = Obj_GetP50.Item(0).Rai
            txtNgan.Text = Obj_GetP50.Item(0).Ngan
            txtWah.Text = Obj_GetP50.Item(0).Wah
            txtRoad.Text = Obj_GetP50.Item(0).Road
            ddlRoad_Detail.SelectedValue = Obj_GetP50.Item(0).Road_Detail
            txtMeter.Text = Obj_GetP50.Item(0).Road_Access
            txtSoi.Text = Obj_GetP50.Item(0).Soi
            txtTumbon.Text = Obj_GetP50.Item(0).Tumbon
            txtAmphur.Text = Obj_GetP50.Item(0).Amphur
            ddlProvince.SelectedValue = Obj_GetP50.Item(0).Province
            ddlLand_State.SelectedValue = Obj_GetP50.Item(0).Land_State
            txtLand_State_Detail.Text = Obj_GetP50.Item(0).Land_State_Detail
            ddlRoad_Forntoff.SelectedValue = Obj_GetP50.Item(0).Road_Frontoff
            txtRoadWidth.Text = Obj_GetP50.Item(0).RoadWidth
            ddlSite.Text = Obj_GetP50.Item(0).Sited
            txtSite_Detail.Text = Obj_GetP50.Item(0).Site_Detail
            ddlPublic_Utility.SelectedValue = Obj_GetP50.Item(0).Public_Utility
            txtPublic_Utility_Detail.Text = Obj_GetP50.Item(0).Public_Utility_Detail
            ddlBinifit.SelectedValue = Obj_GetP50.Item(0).Binifit
            txtBinifit.Text = Obj_GetP50.Item(0).Binifit_Detail
            ddlTendency.SelectedValue = Obj_GetP50.Item(0).Tendency
            ddlBuySale_State.SelectedValue = Obj_GetP50.Item(0).BuySale_State
            ddlSubUnit.SelectedValue = Obj_GetP50.Item(0).SubUnit
            txtPriceWah.Text = Obj_GetP50.Item(0).PriceWah 'String.Format("{0:N2}", Obj_GetP50.Item(0).PriceWah)
            txtTotal.Text = String.Format("{0:N2}", Obj_GetP50.Item(0).PriceTotal1)
            txtRaWang.Text = Obj_GetP50.Item(0).Rawang
            txtLandNumber.Text = Obj_GetP50.Item(0).LandNumber
            txtSurway.Text = Obj_GetP50.Item(0).Surway
            txtDocNo.Text = Obj_GetP50.Item(0).DocNo
            txtPage.Text = Obj_GetP50.Item(0).PageNo
            txtOwnerShip.Text = Obj_GetP50.Item(0).Ownership
            txtObligation.Text = Obj_GetP50.Item(0).Obligation
            txtLand_Closeto_RoadWidth.Text = Obj_GetP50.Item(0).Land_Closeto_RoadWidth
            txtDeepWidth.Text = Obj_GetP50.Item(0).DeepWidth
            txtBehindWidth.Text = Obj_GetP50.Item(0).BehindWidth
            ddlAreaColur.SelectedValue = Obj_GetP50.Item(0).AreaColour_No
        Else
            s = "<script language=""javascript"">alert('ไม่พบเลขที่โฉนดดังกล่าว'); </script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)
            txtRai.Text = "0"
            txtNgan.Text = "0"
            txtWah.Text = "0"
            txtRoad.Text = ""
            txtMeter.Text = "0"
            txtTumbon.Text = ""
            txtAmphur.Text = ""
            txtLand_State_Detail.Text = ""
            txtRoadWidth.Text = "0"
            txtSite_Detail.Text = ""
            txtPublic_Utility_Detail.Text = ""
            txtBinifit.Text = ""
            txtPriceWah.Text = "0"
            txtTotal.Text = "0"
            Dim Objp1 As List(Of ClsPrice1_Master) = GetPrice1_Master(lblReq_Id.Text, lblHub_Id.Text)
            If Objp1.Count > 0 Then
                txtPriceWah.Text = Objp1.Item(0).Pricewah
                txtTotal.Text = String.Format("{0:N2}", Objp1.Item(0).Price)
            Else
            End If
        End If
    End Sub
End Class
