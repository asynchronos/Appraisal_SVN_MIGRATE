Imports Appraisal_Manager
Imports System.Data
Imports System.Data.SqlClient
Imports ThaiBaht
Imports SME_SERVICE

Partial Class Appraisal_Price3_Conform
    Inherits System.Web.UI.Page
    'Private t1, t2 As Integer
    Dim cus_class As Customer_Class
    Dim SV As New SME_SERVICE.Service
    Dim Cnt_P3M As Object
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            HiddenField1.Value = Context.Items("Req_Id")
            HiddenField2.Value = Context.Items("Hub_Id")
            HiddenField3.Value = Context.Items("Temp_AID")
            txtCif.Text = Context.Items("Cif")
            ddlUserAppraisal.SelectedValue = Context.Items("Appraisal_Id")
            'lblCif.Text = Context.Items("Temp_AID").Text
            'MsgBox(Context.Items("Req_Id").ToString, Context.Items("Hub_Id").ToString, Context.Items("Temp_AID").ToString)

            Show_Price3_Master()
            Show_Price3_18()
            Show_Price3_50()
            Show_Price3_70_GROUP()
            Try
                'txtSubTotal.Text = Format(CDec(txtLandTotal.Text) + CDec(txtBuildingPrice.Text), "#,##0.00")
                txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtSubTotal.Text))
                lblThaiBaht.Text = ThaiBahtFun(CDec(txtGrandTotal.Text))
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
        Session("ctrl") = Panel1
    End Sub

    Private Sub Show_Price3_Master()
        Dim Obj_P3M As List(Of clsPrice3_Master) = GET_PRICE3_MASTER(HiddenField1.Value, HiddenField3.Value)
        Cnt_P3M = Obj_P3M.Count
        If Obj_P3M.Count > 0 Then
            txtAID.Text = Obj_P3M.Item(0).AID
            txtInform_To.Text = Obj_P3M.Item(0).Inform_To
            txtCif.Text = Obj_P3M.Item(0).Cif
            cus_class = SV.GetCifInfo(txtCif.Text)(0)
            If cus_class.Cif.ToString <> 0 Then
                lblCifName.Text = cus_class.cifName
            Else
                lblCifName.Text = ""
            End If
            txtReceive_Date.Text = Obj_P3M.Item(0).Receive_Date
            txtAppraisal_Date.Text = Obj_P3M.Item(0).Appraisal_Date
            ddlProblem.SelectedValue = Obj_P3M.Item(0).Env_Effect
            txtProblem_Detail.Text = Obj_P3M.Item(0).Env_Effect_Detail
            txtBuy_Sale_Comment.Text = Obj_P3M.Item(0).Appraisal_Detail
            ddlAppraisal_Type.SelectedValue = Obj_P3M.Item(0).Appraisal_Type_ID
            ddlComment.SelectedValue = Obj_P3M.Item(0).Comment_ID
            ddlWarning.SelectedValue = Obj_P3M.Item(0).Warning_ID
            txtWarning_Detail.Text = Obj_P3M.Item(0).Warning_Detail
            ddlApprove1.SelectedValue = Obj_P3M.Item(0).Approved1
            ddlApprove2.SelectedValue = Obj_P3M.Item(0).Approved2
            ddlApprove3.SelectedValue = Obj_P3M.Item(0).Approved3
            ddlUserAppraisal.SelectedValue = Obj_P3M.Item(0).Appraisal_ID
            If Obj_P3M.Item(0).Req_Dept <> 0 Then
                ddlBranch.SelectedValue = Obj_P3M.Item(0).Req_Dept
            Else
            End If
            lblPriceWah.Text = Format(Obj_P3M.Item(0).PriceWah, "#,##0.00")
            txtLandTotal.Text = Format(Obj_P3M.Item(0).TotalPrice, "#,##0.00")
            txtBuildingPrice.Text = Format(Obj_P3M.Item(0).BuildingPrice, "#,##0.00")
            txtSubTotal.Text = Format(Obj_P3M.Item(0).Land_Building_Price, "#,##0.00")
            txtGrandTotal.Text = String.Format("{0:N2}", (Obj_P3M.Item(0).TotalPrice + Obj_P3M.Item(0).BuildingPrice + Obj_P3M.Item(0).Land_Building_Price))
        Else
            cus_class = SV.GetCifInfo(txtCif.Text)(0)
            If cus_class.Cif.ToString <> 0 Then
                lblCifName.Text = cus_class.cifName
            Else
                lblCifName.Text = ""
            End If
        End If
    End Sub

    Private Sub Show_Price3_18()
        Dim Obj_GetP18 As List(Of Price3_18) = GET_PRICE3_18(HiddenField3.Value, HiddenField1.Value, HiddenField2.Value)
        If Obj_GetP18.Count > 0 Then
            lblCollName.Text = "หลักประกันห้องชุด"
            Label5.Text = "หลักประกัน"
            lblChanode_No.Text = Obj_GetP18.Item(0).Address_No
            'lblRai.Text = Obj_GetP50.Item(0).Rai
            'lblNgan.Text = Obj_GetP50.Item(0).Ngan
            'lblWah.Text = Obj_GetP50.Item(0).Wah
            lblRoad.Text = Obj_GetP18.Item(0).Road
            Dim Obj_RoadAccess_Detail As List(Of Cls_Road_Detail) = GET_ROAD_DETAIL_INFO(Obj_GetP18.Item(0).Road_Detail)
            lblRoadAccess_Detail.Text = Obj_RoadAccess_Detail.Item(0).Road_Detail_Name
            lblMeter_Access.Text = Obj_GetP18.Item(0).Road_Access
            lblTumbon.Text = Obj_GetP18.Item(0).Tumbon
            lblAmphur.Text = Obj_GetP18.Item(0).Amphur
            Dim Obj_Provinceas As List(Of Cls_PROVINCE) = GET_PROVINCE_INFO(Obj_GetP18.Item(0).Province)
            lblProvince.Text = Obj_Provinceas.Item(0).PROV_NAME
            'Dim Obj_Land_State As List(Of Cls_LandState) = GET_LANDSTATE_INFO(Obj_GetP50.Item(0).Land_State)
            'lblLandState.Text = Obj_Land_State.Item(0).Land_State_Name
            'lblLandStateDetail.Text = Obj_GetP50.Item(0).Land_State_Detail
            Dim Obj_Road_Forntoff As List(Of Cls_RoadFrontOff) = GET_ROADFRONTOFF_INFO(Obj_GetP18.Item(0).Road_Frontoff)
            lblRoad_Forntoff.Text = Obj_Road_Forntoff.Item(0).Road_Frontoff_Name
            lblRoad_Forntoff_Width.Text = Obj_GetP18.Item(0).RoadWidth
            'lblRoadWidth.Text = Obj_GetP50.Item(0).Land_Closeto_RoadWidth
            'Dim Obj_Site As List(Of Cls_SITE) = GET_SITE_INFO(Obj_GetP50.Item(0).Sited)
            'lblSiteName.Text = Obj_Site.Item(0).Site_Name
            'txtSite_Detail.Text = Obj_GetP50.Item(0).Site_Detail
            Dim Obj_Public_Utility As List(Of Cls_Public_Utility) = GET_PUBLIC_UTILITY_INFO(Obj_GetP18.Item(0).Public_Utility)
            lblPublic_Utility.Text = Obj_Public_Utility.Item(0).Public_Utility_Name
            'txtBinifit.Text = Obj_GetP50.Item(0).Binifit_Detail
            Dim Obj_TENDENCY As List(Of Cls_TENDENCY) = GET_TENDENCY_INFO(Obj_GetP18.Item(0).Tendency)
            lblTendency_Name.Text = Obj_TENDENCY.Item(0).Tendency_Name
            Dim Obj_BuySale_State As List(Of Cls_Buy_Sale_State) = GET_BUYSALE_STATE_INFO(Obj_GetP18.Item(0).BuySale_State)
            lblBuySale_StateName.Text = Obj_BuySale_State.Item(0).BuySale_State_Name
            'lblPriceWah.Text = Format(Obj_GetP50.Item(0).PriceWah, "#,##0.00")
            'txtLandTotal.Text = Format(Obj_GetP50.Item(0).PriceTotal1, "#,##0.00")
            'lblRaWang.Text = Obj_GetP50.Item(0).Rawang
            'lblLandNumber.Text = Obj_GetP50.Item(0).LandNumber
            'lblSurway.Text = Obj_GetP50.Item(0).Surway
            'lblDocNo.Text = Obj_GetP50.Item(0).DocNo
            'lblPage.Text = Obj_GetP50.Item(0).PageNo
            lblLandOwnerShip.Text = Obj_GetP18.Item(0).Ownership
            lblObligation.Text = Obj_GetP18.Item(0).Obligation
            txtBuildingPrice.Text = String.Format("{0:N2}", Obj_GetP18.Item(0).PriceTotal)
        End If
    End Sub

    Private Sub Show_Price3_50()
        Dim Obj_GetP50 As List(Of Price3_50) = GET_PRICE3_CONFORM(HiddenField1.Value, HiddenField2.Value, HiddenField3.Value)
        If Obj_GetP50.Count > 0 Then
            lblDetail1.Text = "โฉนดที่ดินที่ เลขที่ " & Obj_GetP50.Item(0).Address_No & " ระวาง " & Obj_GetP50.Item(0).Rawang & " เลขที่ดิน " & Obj_GetP50.Item(0).LandNumber
            lblDetail2.Text = "หน้าสำรวจ  " & Obj_GetP50.Item(0).Surway & " สารบัญ เล่มที่ " & Obj_GetP50.Item(0).DocNo & " หน้า " & Obj_GetP50.Item(0).PageNo
            Dim Obj_Provinceas As List(Of Cls_PROVINCE) = GET_PROVINCE_INFO(Obj_GetP50.Item(0).Province)
            lblDetail3.Text = "ตำบล  " & Obj_GetP50.Item(0).Tumbon & " อำเภอ " & Obj_GetP50.Item(0).Amphur & " จังหวัด " & Obj_Provinceas.Item(0).PROV_NAME & " เนื้อที่ " & Obj_GetP50.Item(0).Rai & " ไร่  " & Obj_GetP50.Item(0).Ngan & " งาน  " & Obj_GetP50.Item(0).Wah & " วา"
            lblDetail4.Text = "ผู้ถือกรรมสิทธิ์ที่ดิน  " & Obj_GetP50.Item(0).Ownership & " ภาระผูกพัน " & Obj_GetP50.Item(0).Obligation & " สิ่งปลูกสร้างของ "
            lblCollName.Text = "ที่ดิน"
            '---------------------------------------
            lblChanode_No.Text = Obj_GetP50.Item(0).Address_No
            lblRai.Text = Obj_GetP50.Item(0).Rai
            lblNgan.Text = Obj_GetP50.Item(0).Ngan
            lblWah.Text = Obj_GetP50.Item(0).Wah
            '---------------------------------------
            Dim Obj_RoadAccess_Detail As List(Of Cls_Road_Detail) = GET_ROAD_DETAIL_INFO(Obj_GetP50.Item(0).Road_Detail)
            Dim Obj_Land_State As List(Of Cls_LandState) = GET_LANDSTATE_INFO(Obj_GetP50.Item(0).Land_State)
            Dim Obj_Road_Forntoff As List(Of Cls_RoadFrontOff) = GET_ROADFRONTOFF_INFO(Obj_GetP50.Item(0).Road_Frontoff)
            Dim Obj_Site As List(Of Cls_SITE) = GET_SITE_INFO(Obj_GetP50.Item(0).Sited)
            Dim Obj_AreaColour As List(Of Cls_Area_Colour) = GET_AREA_COLOUR_INFO(Obj_GetP50.Item(0).AreaColour_No)
            Dim Obj_Public_Utility As List(Of Cls_Public_Utility) = GET_PUBLIC_UTILITY_INFO(Obj_GetP50.Item(0).Public_Utility)
            Dim Obj_TENDENCY As List(Of Cls_TENDENCY) = GET_TENDENCY_INFO(Obj_GetP50.Item(0).Tendency)
            Dim Obj_BuySale_State As List(Of Cls_Buy_Sale_State) = GET_BUYSALE_STATE_INFO(Obj_GetP50.Item(0).BuySale_State)
            Dim Obj_SubUnit As List(Of Cls_SubUnit) = GET_SubUnit_Info(Obj_GetP50.Item(0).SubUnit)

            lblLandDetail1.Text = "หลักประกัน ตั้งอยู่ที่ถนน  " & Obj_GetP50.Item(0).Road & "   " & Obj_RoadAccess_Detail.Item(0).Road_Detail_Name & "  ระยะประมาณ " & Obj_GetP50.Item(0).Road_Access & " เมตร "
            lblLandDetail2.Text = "ถนนหน้าหลักประกัน  " & Obj_Road_Forntoff.Item(0).Road_Frontoff_Name & " กว้าง " & Obj_GetP50.Item(0).RoadWidth & " เมตร (รายละเอียดตามรูปแผนที่สังเขป)"
            lblLandDetail3.Text = "สภาพลักษระรูปที่ดิน  "
            lblLandDetail4.Text = "ขนาดที่ดิน กว้างติดถนน  " & Obj_GetP50.Item(0).Land_Closeto_RoadWidth & " เมตร  " & " ลึก  " & Obj_GetP50.Item(0).DeepWidth & " เมตร  " & " ด้านหลัง  " & Obj_GetP50.Item(0).BehindWidth & " เมตร "
            lblLandDetail5.Text = "สภาพและการปรับปรุงระดับของที่ดินกับถนน  " & Obj_Land_State.Item(0).Land_State_Name & Obj_GetP50.Item(0).Land_State_Detail & " ทำเล  " & Obj_Site.Item(0).Site_Name
            lblLandDetail6.Text = "ผังเมืองรวม   ที่ดินอยู่ในเขตพื้นที่สี  " & Obj_AreaColour.Item(0).AreaColour_Name
            lblLandDetail7.Text = "สาธารณูปโภค  " & Obj_Public_Utility.Item(0).Public_Utility_Name & "  แนวโน้มความเจริญ   " & Obj_TENDENCY.Item(0).Tendency_Name
            lblLandDetail7.Text = "สภาพการซื้อขาย  " & Obj_BuySale_State.Item(0).BuySale_State_Name

            '---------------------------------------
            lblRoad.Text = Obj_GetP50.Item(0).Road
            lblRoadAccess_Detail.Text = Obj_RoadAccess_Detail.Item(0).Road_Detail_Name
            lblMeter_Access.Text = Obj_GetP50.Item(0).Road_Access
            lblTumbon.Text = Obj_GetP50.Item(0).Tumbon
            lblAmphur.Text = Obj_GetP50.Item(0).Amphur
            lblProvince.Text = Obj_Provinceas.Item(0).PROV_NAME

            lblLandState.Text = Obj_Land_State.Item(0).Land_State_Name
            lblLandStateDetail.Text = Obj_GetP50.Item(0).Land_State_Detail

            lblRoad_Forntoff.Text = Obj_Road_Forntoff.Item(0).Road_Frontoff_Name
            lblRoad_Forntoff_Width.Text = Obj_GetP50.Item(0).RoadWidth
            lblRoadWidth.Text = Obj_GetP50.Item(0).Land_Closeto_RoadWidth

            lblSiteName.Text = Obj_Site.Item(0).Site_Name
            'txtSite_Detail.Text = Obj_GetP50.Item(0).Site_Detail

            lblPublic_Utility.Text = Obj_Public_Utility.Item(0).Public_Utility_Name
            'txtBinifit.Text = Obj_GetP50.Item(0).Binifit_Detail

            lblTendency_Name.Text = Obj_TENDENCY.Item(0).Tendency_Name

            lblBuySale_StateName.Text = Obj_BuySale_State.Item(0).BuySale_State_Name

            lblSubUnit.Text = Obj_SubUnit.Item(0).SubUnit_Name
            'ตรวจสอบราคาของราคา Price 3 Master ที่จะแสดง
            If CInt(Cnt_P3M) = 0 Then
                lblPriceWah.Text = Format(Obj_GetP50.Item(0).PriceWah, "#,##0.00")
                txtLandTotal.Text = Format(Obj_GetP50.Item(0).PriceTotal1, "#,##0.00")
            End If

            lblRaWang.Text = Obj_GetP50.Item(0).Rawang
            lblLandNumber.Text = Obj_GetP50.Item(0).LandNumber
            lblSurway.Text = Obj_GetP50.Item(0).Surway
            lblDocNo.Text = Obj_GetP50.Item(0).DocNo
            lblPage.Text = Obj_GetP50.Item(0).PageNo
            lblLandOwnerShip.Text = Obj_GetP50.Item(0).Ownership
            lblObligation.Text = Obj_GetP50.Item(0).Obligation
            lblDeepWidth.Text = Obj_GetP50.Item(0).DeepWidth
            lblBehindWidth.Text = Obj_GetP50.Item(0).BehindWidth

            lblArea_Colour.Text = Obj_AreaColour.Item(0).AreaColour_Name
            lblSize.Text = Obj_GetP50.Item(0).Rai & "-" & Obj_GetP50.Item(0).Ngan & "-" & Obj_GetP50.Item(0).Wah
        End If
    End Sub

    Private Sub Show_Price3_70_GROUP()
        Dim Obj_GetP70G As DataSet = GET_PRICE3_70_GROUP(Context.Items("Req_Id"), Context.Items("Hub_Id"), Context.Items("Temp_AID"))
        If Obj_GetP70G.Tables(0).Rows.Count > 0 Then
            If Obj_GetP70G.Tables(0).Rows(0).Item("CntBuild_No") = 1 Then
                lblLandDetail7.Text = "สิ่งปลูกสร้างเลขที่  " & Obj_GetP70G.Tables(0).Rows(0).Item("Build_No") & " รวมจำนวน 1 " & " หลัง "
            Else
                lblLandDetail7.Text = "ตามรายละเอียดสิ่งปลูกสร้างแนบ "
            End If

            lblBuilding_No.Text = Obj_GetP70G.Tables(0).Rows(0).Item("Build_No").ToString()
            lblTotal2.Text = Format(CDec(Obj_GetP70G.Tables(0).Rows(0).Item("UnitPrice").ToString), "#,##0.00")
            lblItem.Text = Obj_GetP70G.Tables(0).Rows(0).Item("Item").ToString()
            'ตรวจสอบราคาของราคา Price 3 Master ที่จะแสดง
            If CInt(Cnt_P3M) = 0 Then
                txtBuildingPrice.Text = Format(CDec(Obj_GetP70G.Tables(0).Rows(0).Item("Buildingprice").ToString), "#,##0.00")
                txtSubTotal.Text = String.Format("{0:N2}", Obj_GetP70G.Tables(0).Rows(0).Item("PriceTotal1"))
            End If

        Else
            'lblTotal2.Text = "0.00"
            'txtBuildingPrice.Text = "0.00"
        End If
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
            Dim Obj_P3M As List(Of clsPrice3_Master) = GET_PRICE3_MASTER(HiddenField1.Value, HiddenField3.Value)
            If Obj_P3M.Count = 0 Then
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
                 CDec(txtLandTotal.Text), _
                 CDec(txtBuildingPrice.Text), _
                 CDec(txtSubTotal.Text), _
                 ddlApprove1.SelectedValue, _
                 ddlPos_Approve1.SelectedValue, _
                 ddlApprove2.SelectedValue, _
                 ddlPos_Approve2.SelectedValue, _
                 ddlApprove3.SelectedValue, _
                 ddlPos_Approve3.SelectedValue, _
                 0, _
                 ddlProblem.SelectedValue, _
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
                s = "<script language=""javascript"">alert('บันทึกเสร็จสมบูรณ์');</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "ผิดพลาด", s)
            Else
                UPDATE_PRICE3_MASTER(HiddenField1.Value, _
                 AID, _
                 HiddenField3.Value, _
                 txtInform_To.Text, _
                 cif, _
                 Lat, _
                 Lng, _
                 AppraisalDate, _
                 ReceiveDate, _
                 CDec(lblPriceWah.Text), _
                 CDec(txtLandTotal.Text), _
                 CDec(txtBuildingPrice.Text), _
                 CDec(txtSubTotal.Text), _
                 ddlApprove1.SelectedValue, _
                 ddlApprove2.SelectedValue, _
                 ddlApprove3.SelectedValue, _
                 0, _
                 ddlProblem.SelectedValue, _
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
                s = "<script language=""javascript"">alert('บันทึกเสร็จสมบูรณ์');</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "ผิดพลาด", s)
            End If

            Server.Transfer("Appraisal_Price3_List.aspx")
        Else
            s = "<script language=""javascript"">alert('ไม่มีเลขที่คำขอนี้ หรือ ไม่มีการกำหนด Lat Lng อยู่ในระบบ');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "ผิดพลาด", s)
        End If

    End Sub

    Protected Sub ImagePrint_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImagePrint.Click
        'Dim ctrl As Control = CType(Session("ctrl"), Control)
        'PrintHelper.PrintWebControl(ctrl)
        'ImagePrint.Visible = False
        'lblSave.Visible = False
        'ImageSave.Visible = False
        'btnEditPosition.ValidationGroup = False
        Session("ctrl") = Panel1
        ClientScript.RegisterStartupScript(Me.GetType(), "onclick", "<script language=javascript>window.open('Testprint.aspx','PrintMe','height=768px,width=1024px,scrollbars=1');</script>")
    End Sub

End Class
