Imports Appraisal_Manager
Partial Class Appraisal_Price3_Add_Colltype50
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblReq_Id.Text = Request.QueryString("Req_Id")
            lblHub_Id.Text = Request.QueryString("Hub_Id")
            lblTemp_AID.Text = Request.QueryString("Temp_AID")
            Dim lblCollType_Id As String = Request.QueryString("Coll_Type")
            lblId.Text = Request.QueryString("ID")
            'ตรวจสอบว่ามีการการให้ราคาที่ 3 ของ Temp AID,Hub ID และ Coll Type นี้ แล้วหรือไม่
            If CHECK_BEFORE_ADD_PRICE3(lblReq_Id.Text, lblTemp_AID.Text, lblHub_Id.Text, lblCollType_Id, lblId.Text) = 0 Then
                'ดึงข้อมูลของการให้ราคาที่ 2 ออกมาแสดง
                Show_Price2_50()
            Else
                'ดึงข้อมูลของการให้ราคาที่ 3 ออกมาแสดง
                Show_Price3_50()
            End If
        End If
    End Sub

    Private Sub Show_Price2_50()
        Dim Obj_GetP50 As List(Of PRICE2_50) = GET_PRICE2_50(lblId.Text, lblReq_Id.Text, lblHub_Id.Text)
        If Obj_GetP50.Count > 0 Then
            lblId.Text = Obj_GetP50.Item(0).Id
            lblReq_Id.Text = Obj_GetP50.Item(0).Req_Id
            lblHub_Id.Text = Obj_GetP50.Item(0).Hub_Id
            DDLSubCollType.SelectedValue = Obj_GetP50.Item(0).MysubColl_ID
            txtChanode.Text = Obj_GetP50.Item(0).Address_No
            txtRai.Text = Obj_GetP50.Item(0).Rai
            txtNgan.Text = Obj_GetP50.Item(0).Ngan
            txtWah.Text = Obj_GetP50.Item(0).Wah
            txtRoad.Text = Obj_GetP50.Item(0).Road
            ddlRoad_Detail.SelectedValue = Obj_GetP50.Item(0).Road_Detail
            txtMeter.Text = Obj_GetP50.Item(0).Road_Access
            txtTumbon.Text = Obj_GetP50.Item(0).Tumbon
            txtAmphur.Text = Obj_GetP50.Item(0).Amphur
            ddlProvince.SelectedValue = Obj_GetP50.Item(0).Province
            ddlLand_State.SelectedValue = Obj_GetP50.Item(0).Land_State
            txtLand_State_Detail.Text = Obj_GetP50.Item(0).Land_State_Detail
            ddlRoad_Forntoff.SelectedValue = Obj_GetP50.Item(0).Road_Frontoff
            txtRoadWidth.Text = Obj_GetP50.Item(0).RoadWidth
            ddlSite.Text = Obj_GetP50.Item(0).Site
            txtSite_Detail.Text = Obj_GetP50.Item(0).Site_Detail
            ddlPublic_Utility.SelectedValue = Obj_GetP50.Item(0).Public_Utility
            txtPublic_Utility_Detail.Text = Obj_GetP50.Item(0).Public_Utility_Detail
            ddlBinifit.SelectedValue = Obj_GetP50.Item(0).Binifit
            txtBinifit.Text = Obj_GetP50.Item(0).Binifit_Detail
            ddlTendency.SelectedValue = Obj_GetP50.Item(0).Tendency
            ddlBuySale_State.SelectedValue = Obj_GetP50.Item(0).BuySale_State
            txtPriceWah.Text = Obj_GetP50.Item(0).PriceWah
            txtTotal.Text = Obj_GetP50.Item(0).PriceTotal1
        End If
    End Sub

    Private Sub Show_Price3_50()
        Dim Obj_GetP50 As List(Of Price3_50) = GET_PRICE3_50(lblId.Text, lblReq_Id.Text, lblHub_Id.Text, lblTemp_AID.Text)
        If Obj_GetP50.Count > 0 Then
            lblId.Text = Obj_GetP50.Item(0).Id
            lblReq_Id.Text = Obj_GetP50.Item(0).Req_Id
            lblHub_Id.Text = Obj_GetP50.Item(0).Hub_Id
            DDLSubCollType.SelectedValue = Obj_GetP50.Item(0).MysubColl_ID
            txtChanode.Text = Obj_GetP50.Item(0).Address_No
            txtRai.Text = Obj_GetP50.Item(0).Rai
            txtNgan.Text = Obj_GetP50.Item(0).Ngan
            txtWah.Text = Obj_GetP50.Item(0).Wah
            txtRoad.Text = Obj_GetP50.Item(0).Road
            ddlRoad_Detail.SelectedValue = Obj_GetP50.Item(0).Road_Detail
            txtMeter.Text = Obj_GetP50.Item(0).Road_Access
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
            txtPriceWah.Text = Obj_GetP50.Item(0).PriceWah
            txtTotal.Text = Obj_GetP50.Item(0).PriceTotal1
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
        End If
    End Sub

    Protected Sub ImageSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSave.Click
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label) 'หา Control จาก Master Page ที่ control ไม่อยู่ใน  ContentPlaceHolder1 ของ Master Page
        'ส่งตัวแปรไปที่ Function  AddPRICE3_50 เพื่อทำการเพิ่มหรือแก้ไขข้อมูล
        AddPRICE3_50(lblId.Text, CInt(lblReq_Id.Text), CInt(lblHub_Id.Text), lblTemp_AID.Text, CInt(DDLSubCollType.SelectedValue), txtChanode.Text, String.Empty, txtTumbon.Text, txtAmphur.Text, _
                                                              ddlProvince.SelectedValue, CInt(txtRai.Text), CInt(txtNgan.Text), CInt(txtWah.Text), _
                                                              txtRoad.Text, CInt(ddlRoad_Detail.SelectedValue), CDec(txtMeter.Text), CInt(ddlRoad_Forntoff.SelectedValue), _
                                                              CDec(txtRoadWidth.Text), CInt(ddlSite.SelectedValue), CStr(txtSite_Detail.Text), CInt(ddlLand_State.SelectedValue), _
                                                              txtLand_State_Detail.Text, CInt(ddlPublic_Utility.SelectedValue), txtPublic_Utility_Detail.Text, CInt(ddlBinifit.SelectedValue), _
                                                              txtBinifit.Text, CInt(ddlTendency.SelectedValue), CInt(ddlBuySale_State.SelectedValue), _
                                                              CInt(txtPriceWah.Text), CInt(txtTotal.Text), txtRaWang.Text, txtLandNumber.Text, txtSurway.Text, txtDocNo.Text, txtPage.Text, txtOwnerShip.Text, _
                                                              txtObligation.Text, txtLand_Closeto_RoadWidth.Text, txtDeepWidth.Text, txtBehindWidth.Text, ddlAreaColur.SelectedValue, lbluserid.Text, Now())
        Response.Redirect("Appraisal_Price3_List.aspx")
    End Sub
End Class
