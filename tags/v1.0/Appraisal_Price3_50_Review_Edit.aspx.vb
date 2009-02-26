Imports Appraisal_Manager

Partial Class Appraisal_Price3_50_Review_Edit
    Inherits System.Web.UI.Page

    Private Sub Show_Price3_50_Review()
        Dim Obj_GetP50_Review As List(Of Price3_50_Review) = GET_PRICE3_50_REVIEW(lblReq_Id.Text, lblHub_Id.Text, lblId.Text)
        If Obj_GetP50_Review.Count > 0 Then
            lblId.Text = Obj_GetP50_Review.Item(0).ID
            lblReq_Id.Text = Obj_GetP50_Review.Item(0).Req_Id
            lblHub_Id.Text = Obj_GetP50_Review.Item(0).Hub_Id
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
            ddlBuySale_State.SelectedValue = Obj_GetP50_Review.Item(0).BuySale_State
            txtPriceWah.Text = Format(Obj_GetP50_Review.Item(0).PriceWah, "#,##0.00")
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
            lblId.Text = Context.Items("Id")
            lblReq_Id.Text = Context.Items("Req_Id")
            lblHub_Id.Text = Context.Items("Hub_Id")
            hdfAID.Value = Context.Items("AID")
            hdfColl_Type.Value = Context.Items("Coll_Type")
            lblHub_Id.Text = Context.Items("Hub_Id")
            lblCif.Text = Context.Items("Cif")
            lblCifName.Text = Context.Items("CifName")
            Show_Price3_50_Review()
        End If
    End Sub

    Protected Sub ImageSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSave.Click
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label) 'หา Control จาก Master Page ที่ control ไม่อยู่ใน  ContentPlaceHolder1 ของ Master Page
        UPDATE_PRICE3_50_REVIEW(lblId.Text, CInt(lblReq_Id.Text), CInt(lblHub_Id.Text), lblTemp_AID.Text, CInt(DDLSubCollType.SelectedValue), txtChanode.Text, String.Empty, txtTumbon.Text, txtAmphur.Text, _
                                                      ddlProvince.SelectedValue, CInt(txtRai.Text), CInt(txtNgan.Text), CInt(txtWah.Text), _
                                                      txtRoad.Text, CInt(ddlRoad_Detail.SelectedValue), CDec(txtMeter.Text), CInt(ddlRoad_Forntoff.SelectedValue), _
                                                      CDec(txtRoadWidth.Text), CInt(ddlSite.SelectedValue), CStr(txtSite_Detail.Text), CInt(ddlLand_State.SelectedValue), _
                                                      txtLand_State_Detail.Text, CInt(ddlPublic_Utility.SelectedValue), txtPublic_Utility_Detail.Text, CInt(ddlBinifit.SelectedValue), _
                                                      txtBinifit.Text, CInt(ddlTendency.SelectedValue), CInt(ddlBuySale_State.SelectedValue), _
                                                      CInt(txtPriceWah.Text), CInt(txtTotal.Text), txtRaWang.Text, txtLandNumber.Text, txtSurway.Text, txtDocNo.Text, txtPage.Text, txtOwnerShip.Text, _
                                                      txtObligation.Text, txtLand_Closeto_RoadWidth.Text, txtDeepWidth.Text, txtBehindWidth.Text, ddlAreaColur.SelectedValue, lbluserid.Text, Now())
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Context.Items("Id") = lblId.Text
        Context.Items("Req_Id") = lblReq_Id.Text
        Context.Items("Hub_Id") = lblHub_Id.Text
        Context.Items("Coll_Type") = hdfColl_Type.Value
        Context.Items("AID") = hdfAID.Value
        Context.Items("Cif") = lblCif.Text
        Server.Transfer("Appraisal_Price3_Form_Review.Aspx")
    End Sub
End Class
