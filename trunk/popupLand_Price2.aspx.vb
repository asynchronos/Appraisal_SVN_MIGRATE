Imports Appraisal_Manager

Partial Class popupLand_Price2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            '    lblReq_Id.Text = Request.QueryString("Req_Id")
            '    lblHub_Id.Text = Request.QueryString("Hub_Id")
            '    lblId.Text = Request.QueryString("ID")

        End If
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        lblReq_Id.Text = Session("reqId")
        lblHub_Id.Text = Session("hubId")
        lblId.Text = Session("id")
        hdfColltype.Value = 50
        If lblId.Text = String.Empty Then
        Else
            Dim Obj_GetP50 As List(Of PRICE2_50) = GET_PRICE2_50(lblId.Text, lblReq_Id.Text, lblHub_Id.Text)
            If Obj_GetP50.Count > 0 Then
                lblId.Text = Obj_GetP50.Item(0).ID
                lblReq_Id.Text = Obj_GetP50.Item(0).Req_Id
                lblHub_Id.Text = Obj_GetP50.Item(0).Hub_Id
                txtAID.Text = Obj_GetP50.Item(0).AID
                txtCID.Text = Obj_GetP50.Item(0).CID
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
                ddlSubUnit.SelectedValue = Obj_GetP50.Item(0).SubUnit
                txtPriceWah.Text = Obj_GetP50.Item(0).PriceWah
                txtTotal.Text = String.Format("{0:N2}", Obj_GetP50.Item(0).PriceTotal1)
            End If
        End If

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        'Session("reqId") = Nothing
        'Session("hubId") = Nothing
        'Session("id") = Nothing
    End Sub
End Class
