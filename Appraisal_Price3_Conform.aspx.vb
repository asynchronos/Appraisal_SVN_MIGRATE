Imports Appraisal_Manager
Imports System.Data
Imports System.Data.SqlClient

Partial Class Appraisal_Price3_Conform
    Inherits System.Web.UI.Page
    'Private t1, t2 As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            HiddenField1.Value = Context.Items("Req_Id")
            HiddenField2.Value = Context.Items("Hub_Id")
            HiddenField3.Value = Context.Items("Temp_AID")
            'lblCif.Text = Context.Items("Temp_AID").Text
            'MsgBox(Context.Items("Req_Id").ToString, Context.Items("Hub_Id").ToString, Context.Items("Temp_AID").ToString)

            Show_Price3_Master()
            Show_Price3_50()
            Show_Price3_70_GROUP()
            Try
                lblGrantotal.Text = Format(CDec(lblLandTotal.Text) + CDec(lblBuildingPrice.Text), "#,##0.00")
            Catch ex As Exception

            End Try

        End If
        Dim s1 As String = Nothing
        Dim CollType As String = "050"

        s1 += "window.open('CollDetail_Edit_Position.aspx"
        s1 += "?Req_Id=" & HiddenField1.Value
        s1 += "&Hub_Id=" & HiddenField2.Value
        btnEditPosition.Attributes.Add("onclick", s1 & "','pop', 'width=820, height=680');")
        'txtAID.Attributes.Add("onfocus", "this.blur();")  ' set textbox to readonly 
        'txtCID.Attributes.Add("onfocus", "this.blur();")  ' set textbox to readonly 
    End Sub

    Private Sub Show_Price3_Master()
        Dim Obj_P3M As List(Of clsPrice3_Master) = GET_PRICE3_MASTER(HiddenField1.Value, HiddenField3.Value)
        If Obj_P3M.Count > 0 Then
            txtAID.Text = Obj_P3M.Item(0).AID
            txtInform_To.Text = Obj_P3M.Item(0).Inform_To
            txtCif.Text = Obj_P3M.Item(0).Cif
            txtReceive_Date.Text = Obj_P3M.Item(0).Receive_Date
            txtAppraisal_Date.Text = Obj_P3M.Item(0).Appraisal_Date
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
            ddlUserAppraisal.SelectedValue = Obj_P3M.Item(0).Appraisal_ID
            If Obj_P3M.Item(0).Req_Dept <> 0 Then
                ddlBranch.SelectedValue = Obj_P3M.Item(0).Req_Dept
            Else
            End If

        Else
        End If
    End Sub

    Private Sub Show_Price3_50()
        Dim Obj_GetP50 As List(Of Price3_50) = GET_PRICE3_CONFORM(HiddenField1.Value, HiddenField2.Value, HiddenField3.Value)
        If Obj_GetP50.Count > 0 Then
            lblChanode_No.Text = Obj_GetP50.Item(0).Address_No
            lblRai.Text = Obj_GetP50.Item(0).Rai
            lblNgan.Text = Obj_GetP50.Item(0).Ngan
            lblWah.Text = Obj_GetP50.Item(0).Wah
            lblRoad.Text = Obj_GetP50.Item(0).Road
            Dim Obj_RoadAccess_Detail As List(Of Cls_Road_Detail) = GET_ROAD_DETAIL_INFO(Obj_GetP50.Item(0).Road_Detail)
            lblRoadAccess_Detail.Text = Obj_RoadAccess_Detail.Item(0).Road_Detail_Name
            lblMeter_Access.Text = Obj_GetP50.Item(0).Road_Access
            lblTumbon.Text = Obj_GetP50.Item(0).Tumbon
            lblAmphur.Text = Obj_GetP50.Item(0).Amphur
            Dim Obj_Provinceas As List(Of Cls_PROVINCE) = GET_PROVINCE_INFO(Obj_GetP50.Item(0).Province)
            lblProvince.Text = Obj_Provinceas.Item(0).PROV_NAME
            Dim Obj_Land_State As List(Of Cls_LandState) = GET_LANDSTATE_INFO(Obj_GetP50.Item(0).Land_State)
            lblLandState.Text = Obj_Land_State.Item(0).Land_State_Name
            lblLandStateDetail.Text = Obj_GetP50.Item(0).Land_State_Detail
            Dim Obj_Road_Forntoff As List(Of Cls_RoadFrontOff) = GET_ROADFRONTOFF_INFO(Obj_GetP50.Item(0).Road_Frontoff)
            lblRoad_Forntoff.Text = Obj_Road_Forntoff.Item(0).Road_Frontoff_Name
            lblRoad_Forntoff_Width.Text = Obj_GetP50.Item(0).RoadWidth
            lblRoadWidth.Text = Obj_GetP50.Item(0).Land_Closeto_RoadWidth
            Dim Obj_Site As List(Of Cls_SITE) = GET_SITE_INFO(Obj_GetP50.Item(0).Sited)
            lblSiteName.Text = Obj_Site.Item(0).Site_Name
            'txtSite_Detail.Text = Obj_GetP50.Item(0).Site_Detail
            Dim Obj_Public_Utility As List(Of Cls_Public_Utility) = GET_PUBLIC_UTILITY_INFO(Obj_GetP50.Item(0).Public_Utility)
            lblPublic_Utility.Text = Obj_Public_Utility.Item(0).Public_Utility_Name
            'txtBinifit.Text = Obj_GetP50.Item(0).Binifit_Detail
            Dim Obj_TENDENCY As List(Of Cls_TENDENCY) = GET_TENDENCY_INFO(Obj_GetP50.Item(0).Tendency)
            lblTendency_Name.Text = Obj_TENDENCY.Item(0).Tendency_Name
            Dim Obj_BuySale_State As List(Of Cls_Buy_Sale_State) = GET_BUYSALE_STATE_INFO(Obj_GetP50.Item(0).BuySale_State)
            lblBuySale_StateName.Text = Obj_BuySale_State.Item(0).BuySale_State_Name
            lblPriceWah.Text = Format(Obj_GetP50.Item(0).PriceWah, "#,##0.00")
            lblLandTotal.Text = Format(Obj_GetP50.Item(0).PriceTotal1, "#,##0.00")
            lblRaWang.Text = Obj_GetP50.Item(0).Rawang
            lblLandNumber.Text = Obj_GetP50.Item(0).LandNumber
            lblSurway.Text = Obj_GetP50.Item(0).Surway
            lblDocNo.Text = Obj_GetP50.Item(0).DocNo
            lblPage.Text = Obj_GetP50.Item(0).PageNo
            lblLandOwnerShip.Text = Obj_GetP50.Item(0).Ownership
            lblObligation.Text = Obj_GetP50.Item(0).Obligation
            lblDeepWidth.Text = Obj_GetP50.Item(0).DeepWidth
            lblBehindWidth.Text = Obj_GetP50.Item(0).BehindWidth
            Dim Obj_AreaColour As List(Of Cls_Area_Colour) = GET_AREA_COLOUR_INFO(Obj_GetP50.Item(0).AreaColour_No)
            lblArea_Colour.Text = Obj_AreaColour.Item(0).AreaColour_Name
        End If
    End Sub

    Private Sub Show_Price3_70_GROUP()
        Dim Obj_GetP70G As DataSet = GET_PRICE3_70_GROUP(Context.Items("Req_Id"), Context.Items("Hub_Id"), Context.Items("Temp_AID"))
        If Obj_GetP70G.Tables(0).Rows.Count > 0 Then
            lblBuilding_No.Text = Obj_GetP70G.Tables(0).Rows(0).Item("Build_No").ToString()
            lblTotal2.Text = Format(CDec(Obj_GetP70G.Tables(0).Rows(0).Item("UnitPrice").ToString), "#,##0.00")
            lblItem.Text = Obj_GetP70G.Tables(0).Rows(0).Item("Item").ToString()
            lblBuildingPrice.Text = Format(CDec(Obj_GetP70G.Tables(0).Rows(0).Item("Buildingprice").ToString), "#,##0.00")
        Else
            lblTotal2.Text = "0.00"
            lblBuildingPrice.Text = "0.00"
        End If


        'Dim Obj_GetP70 As List(Of Price3_70) = GET_PRICE3_70(lblId.Text, lblReq_Id.Text, lblHub_Id.Text, lblTemp_AID.Text)
        'If Obj_GetP70.Count > 0 Then
        '    lblId.Text = Obj_GetP70.Item(0).ID
        '    lblReq_Id.Text = Obj_GetP70.Item(0).Req_Id
        '    lblHub_Id.Text = Obj_GetP70.Item(0).Hub_Id
        '    DDLSubCollType.SelectedValue = Obj_GetP70.Item(0).MysubColl_ID
        '    txtChanodeNo.Text = Obj_GetP70.Item(0).Put_On_Chanode
        '    lbBuildinObligation.Text = Obj_GetP70.Item(0).Ownership
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
        '    txtPriceTotal1.Text = Obj_GetP70.Item(0).PriceTotal1
        '    chkDoc1.Checked = Obj_GetP70.Item(0).Doc1
        '    chkDoc2.Checked = Obj_GetP70.Item(0).Doc2
        '    txtDoc_Detail.Text = Obj_GetP70.Item(0).Doc_Detail
        '    txtBuildingArea.Text = Obj_GetP70.Item(0).BuildingArea
        '    txtBuildingUnitPrice.Text = Obj_GetP70.Item(0).BuildingUintPrice
        '    txtBuildingPrice.Text = Obj_GetP70.Item(0).BuildingPrice
        '    txtBuildingAge.Text = Obj_GetP70.Item(0).BuildingAge
        '    txtBuildingPersent1.Text = Obj_GetP70.Item(0).BuildingPersent1
        '    txtBuildingPersent2.Text = Obj_GetP70.Item(0).BuildingPersent2
        '    txtBuildingPersent3.Text = Obj_GetP70.Item(0).BuildingPersent3
        '    txtBuildingTotalDeteriorate.Text = Obj_GetP70.Item(0).BuildingPriceTotalDeteriorate
        '    txtBuildAddArea.Text = Obj_GetP70.Item(0).BuildAddArea
        '    txtBuildAddUnitPrice.Text = Obj_GetP70.Item(0).BuildAddUintPrice
        '    txtBuildAddPrice.Text = Obj_GetP70.Item(0).BuildAddPrice
        '    txtBuildAddAge.Text = Obj_GetP70.Item(0).BuildAddAge
        '    txtBuildAddPersent1.Text = Obj_GetP70.Item(0).BuildAddPersent1
        '    txtBuildAddPersent2.Text = Obj_GetP70.Item(0).BuildAddPersent2
        '    txtBuildAddPersent3.Text = Obj_GetP70.Item(0).BuildAddPersent3
        '    txtBuildAddTotalDeteriorate.Text = Obj_GetP70.Item(0).BuildAddPriceTotalDeteriorate
        '    txtBuildingDetail.Text = Obj_GetP70.Item(0).BuildingDetail
        'End If
    End Sub

    Protected Sub ImageSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSave.Click
        Dim ReceiveDate As Date = CDate(txtReceive_Date.Text)
        Dim AppraisalDate As Date = CDate(txtAppraisal_Date.Text)
        'MsgBox("Receive Date" & myDate)
        'MsgBox("Appraisal Date" & myDate2)

        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label) 'หา Control จาก Master Page ที่ control ไม่อยู่ใน  ContentPlaceHolder1 ของ Master Page
        Dim s As String
        Dim cif As Integer = 0
        Dim AID As Integer = 0
        Dim Lat As Double
        Dim Lng As Double
        If txtCif.Text <> String.Empty Then
            cif = txtCif.Text
        End If
        If txtAID.Text <> String.Empty Then
            AID = txtAID.Text
        End If
        Dim Obj_GetP1Master As List(Of ClsPrice1_Master) = GetPrice1_Master(HiddenField1.Value, HiddenField2.Value)
        If Obj_GetP1Master.Count > 0 Then
            Lat = Obj_GetP1Master.Item(0).Lat
            Lng = Obj_GetP1Master.Item(0).Lng

            AddPRICE3_Master(HiddenField1.Value, _
                             AID, _
                             HiddenField3.Value, _
                             txtInform_To.Text, _
                             cif, _
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
            Server.Transfer("Appraisal_Price3_List.aspx")
        Else
            s = "<script language=""javascript"">alert('ไม่มีเลขที่คำขอนี้ หรือ ไม่มีการกำหนด Lat Lng อยู่ในระบบ');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "ผิดพลาด", s)
        End If

    End Sub

End Class
