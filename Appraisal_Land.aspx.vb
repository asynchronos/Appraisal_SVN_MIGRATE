Imports Appraisal_Manager
Partial Class Appraisal_Land
    Inherits System.Web.UI.Page
    Dim StringNotice As String
    Dim StringMessage As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Request.QueryString("ID").ToString = "" Then
                lblReq_Id.Text = Request.QueryString("Req_Id").ToString
                lblHub_Id.Text = Request.QueryString("Hub_Id").ToString
                lblCif.Text = Request.QueryString("Cif").ToString
                lblCifName.Text = Request.QueryString("CifName").ToString
                hdfAppraisal_Id.Value = Request.QueryString("Appraisal_Id").ToString
                lblTemp_AID.Text = "0"
                Appraisal_Request_Info()
            Else
                If Request.QueryString("ID").ToString <> "0" Then
                    lblReq_Id.Text = Request.QueryString("Req_Id").ToString
                    lblHub_Id.Text = Request.QueryString("Hub_Id").ToString
                    lblCif.Text = Request.QueryString("Cif").ToString
                    lblCifName.Text = Request.QueryString("CifName").ToString
                    hdfAppraisal_Id.Value = Request.QueryString("Appraisal_Id").ToString
                    lblId.Text = Request.QueryString("ID").ToString
                    lblTemp_AID.Text = Request.QueryString("Temp_AID").ToString
                    GET_DATA()
                End If
            End If
        End If
        'ImageSave.Attributes.Add("onclick", "return returnValue('" & StatusName.Text & "');")
        'ImgBtnBack.Attributes.Add("onclick", "return returnValue('" & Request.QueryString("PopupModal").ToString & "');")
        'ImgBtnBack.Attributes.Add("onclick", "window.close();")
    End Sub

    Protected Sub ImageSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSave.Click

        If txtRai.Text = 0 And txtNgan.Text = 0 And txtWah.Text = 0 Then
            StringNotice = "<script language=""javascript"">alert('ไม่มีพื้นที่ให้คำนวณราคา');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "บันทึกข้อมูลที่ดิน", StringNotice)
        Else
            Dim Id As Integer = 0
            Dim TempAid As Integer
            If lblId.Text = String.Empty Then
                'ส่งค่าไปขอ Id จาก ตาราง ID_50
                Id = GET_ID_18_50_70(50)
                UPDATE_ID_50()
                ADD_LAND_DATA(Id, 0) 'ADD NEW DATA
            Else

                Id = lblId.Text
                TempAid = lblTemp_AID.Text
                ADD_LAND_DATA(Id, TempAid)  'UPDATE DATA
            End If

        End If
    End Sub

    Protected Sub imgSearchChanode_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgSearchChanode.Click
        Dim Obj_GetP50 As List(Of Price3_50) = GET_PRICE3_50_CHANODE(txtChanode.Text, ddlProvince.SelectedValue)
        If Obj_GetP50.Count > 0 Then
            StringMessage = "<script language=""javascript"">alert('พบเลขที่โฉนดดังกล่าวระบบจะแสดงรายละเอียดดังกล่าว'); </script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "ค้นหาเลขโฉนด", StringMessage)
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
            txtTumbon.Text = Obj_GetP50.Item(0).Tumbon
            txtAmphur.Text = Obj_GetP50.Item(0).Amphur
            ddlProvince.SelectedValue = Obj_GetP50.Item(0).Province
            txtRaWang.Text = Obj_GetP50.Item(0).Rawang()
            txtLandNumber.Text = Obj_GetP50.Item(0).LandNumber
            txtSurway.Text = Obj_GetP50.Item(0).Surway
            txtDocNo.Text = Obj_GetP50.Item(0).DocNo
            txtpage.Text = Obj_GetP50.Item(0).PageNo
            txtOwnerShip.Text = Obj_GetP50.Item(0).Ownership
            txtObligation.Text = Obj_GetP50.Item(0).Obligation
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
            txtPriceWah.Text = Obj_GetP50.Item(0).PriceWah
            txtTotal.Text = String.Format("{0:N2}", Obj_GetP50.Item(0).PriceTotal1)

        Else
            StringMessage = "<script language=""javascript"">alert('ไม่พบเลขที่โฉนดดังกล่าว'); </script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", StringMessage)
            'txtRai.Text = "0"
            'txtNgan.Text = "0"
            'txtWah.Text = "0"
            'txtRoad.Text = ""
            'txtMeter.Text = "0"
            'txtTumbon.Text = ""
            'txtAmphur.Text = ""
            'txtLand_State_Detail.Text = ""
            'txtRoadWidth.Text = "0"
            'txtSite_Detail.Text = ""
            'txtPublic_Utility_Detail.Text = ""
            'txtBinifit.Text = ""
            'txtPriceWah.Text = "0"
            'txtTotal.Text = "0"
            'Dim Objp1 As List(Of ClsPrice1_Master) = GetPrice1_Master(lblReq_Id.Text, lblHub_Id.Text)
            'If Objp1.Count > 0 Then
            '    txtPriceWah.Text = Objp1.Item(0).Pricewah
            '    txtTotal.Text = "0.00"
            'Else
            'End If
        End If
    End Sub

    Private Sub GET_DATA()
        Dim Obj_GetP50 As List(Of Price3_50) = GET_PRICE3_50(lblId.Text, lblReq_Id.Text, lblHub_Id.Text, lblTemp_AID.Text)
        If Obj_GetP50.Count > 0 Then
            lblId.Text = Obj_GetP50.Item(0).ID
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

        End If
    End Sub

    'Protected Sub ImgBtnBack_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnBack.Click
    '    StringNotice = "<script language=""javascript"">window.close();</script>"
    '    Page.ClientScript.RegisterStartupScript(Me.GetType, "Exit", StringNotice)

    'End Sub

    Sub Appraisal_Request_Info()
        Dim Request As List(Of Appraisal_Request_v2) = GET_APPRAISAL_REQUEST_V2(lblReq_Id.Text)
        txtChanode.Text = Request.Item(0).CollOfNumber
        If IsNumeric(Request.Item(0).Tumbon) Then
            Dim Tumbon As List(Of Cls_Tumbon) = GET_TUMBON_INFO(Request.Item(0).Tumbon, Request.Item(0).Amphur, Request.Item(0).Province)
            txtTumbon.Text = Tumbon.Item(0).tumbon_new2_name
        Else
            'txtTumbon.Text = Request.Tables(0).Rows(0).Item("Tumbon")
        End If

        If IsNumeric(Request.Item(0).Amphur) Then
            Dim Amphur As List(Of Cls_Amphur) = GET_AMPHUR_INFO(Request.Item(0).Amphur, Request.Item(0).Province)
            txtAmphur.Text = Amphur.Item(0).am_name
        Else
            'txtAmphur.Text = Obj_GetP50.Item(0).Amphur
        End If
        ddlProvince.SelectedValue = Request.Item(0).Province
    End Sub

    Sub ADD_LAND_DATA(ByVal Id As Integer, ByVal TEMPAID As Integer)
        'ส่งตัวแปรไปที่ Function  ADD_PRICE2_PRICE3_50 เพื่อทำการเพิ่มหรือแก้ไขข้อมูล
        ADD_PRICE2_PRICE3_50(Id, CInt(lblReq_Id.Text), CInt(lblHub_Id.Text), TEMPAID, 0, 0, CInt(DDLSubCollType.SelectedValue), txtChanode.Text, String.Empty, txtTumbon.Text, txtAmphur.Text, _
                                                              ddlProvince.SelectedValue, CInt(txtRai.Text), CInt(txtNgan.Text), CDec(txtWah.Text), _
                                                              txtRoad.Text, CInt(ddlRoad_Detail.SelectedValue), CDec(txtMeter.Text), txtSoi.Text, CInt(ddlRoad_Forntoff.SelectedValue), _
                                                              CDec(txtRoadWidth.Text), CInt(ddlSite.SelectedValue), CStr(txtSite_Detail.Text), CInt(ddlLand_State.SelectedValue), _
                                                              txtLand_State_Detail.Text, CInt(ddlPublic_Utility.SelectedValue), txtPublic_Utility_Detail.Text, CInt(ddlBinifit.SelectedValue), _
                                                              txtBinifit.Text, CInt(ddlTendency.SelectedValue), CInt(ddlBuySale_State.SelectedValue), ddlSubUnit.SelectedValue, _
                                                              CDec(txtPriceWah.Text), CDec(txtTotal.Text), txtRaWang.Text, txtLandNumber.Text, txtSurway.Text, txtDocNo.Text, txtPage.Text, txtOwnerShip.Text, _
                                                              txtObligation.Text, txtLand_Closeto_RoadWidth.Text, txtDeepWidth.Text, txtBehindWidth.Text, ddlAreaColur.SelectedValue, hdfAppraisal_Id.Value, Now())
    End Sub
End Class
