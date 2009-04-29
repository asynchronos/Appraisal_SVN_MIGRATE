﻿Imports Appraisal_Manager
Imports System.Data
Imports System.Data.SqlClient
Imports ThaiBaht
Imports SME_SERVICE

Partial Class Appraisal_Price3_Conform_New
    Inherits System.Web.UI.Page
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
                'txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtSubTotal.Text))
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
            'txtGrandTotal.Text = String.Format("{0:N2}", (Obj_P3M.Item(0).TotalPrice + Obj_P3M.Item(0).BuildingPrice + Obj_P3M.Item(0).Land_Building_Price))
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
            lblCollName.Text = "หลักประกันห้องชุด เลขที่"
            Label56.Text = "หลักประกันห้องชุด เลขที่"
            Label48.Text = "หลักประกันห้องชุด เลขที่"
            lblSubUnit.Text = "เฉลี่ย ตารางเมตรละ"
            lblSubUnit0.Text = "เฉลี่ย ตารางเมตรละ"
            lblSubUnit1.Text = "เฉลี่ย ตารางเมตรละ"
            Label5.Text = "หลักประกัน"
            Label22.Text = "ที่ตั้งและสภาพอาคารชุด"
            Dim Obj_Provinceas As List(Of Cls_PROVINCE) = GET_PROVINCE_INFO(Obj_GetP18.Item(0).Province)
            lblDetail1.Text = Replace(Space(10), " ", "&nbsp;") & "หนังสือกรรมสิทธิ์ห้องชุดเลขที่ " & Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(0).Address_No & Replace(Space(10), " ", "&nbsp;") & "ชั้นที่  " & Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(0).Floors & Replace(Space(10), " ", "&nbsp;") & "อาคารเลขที่" & Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(0).Building_No
            lblDetail2.Text = Replace(Space(10), " ", "&nbsp;") & "ชื่ออาคารชุด" & Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(0).Building_Name & Replace(Space(10), " ", "&nbsp;") & "ทะเบียนอาคารชุดเลขที่     " & Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(0).Building_Reg_No
            lblDetail3.Text = Replace(Space(10), " ", "&nbsp;") & "ตำแหน่งที่ตั้ง     ตำบล" & Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(0).Tumbon & Replace(Space(10), " ", "&nbsp;") & "อำเภอ" & Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(0).Amphur & "จังหวัด" & Replace(Space(10), " ", "&nbsp;") & Obj_Provinceas.Item(0).PROV_NAME
            lblDetail4.Text = Replace(Space(10), " ", "&nbsp;") & "เนื้อที่ห้องชุด" & Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(0).Room_Area & Replace(Space(10), " ", "&nbsp;") & "ตารางเมตร" & Replace(Space(10), " ", "&nbsp;") & "สูง" & Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(0).Room_Height & Replace(Space(10), " ", "&nbsp;") & "เมตร" & Obj_GetP18.Item(0).Other_Detail & Replace(Space(10), " ", "&nbsp;") & "ทรัพย์สินส่วนบุคคลภายนอกห้องชุด" & Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(0).Partake_Detail
            lblDetail5.Text = "ผู้ถือกรรมสิทธิ์ห้องชุด" & Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(0).Ownership & Replace(Space(10), " ", "&nbsp;") & "ภาระผูกพัน" & Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(0).Obligation

            '-----------------------------------------------------
            Dim Obj_RoadAccess_Detail As List(Of Cls_Road_Detail) = GET_ROAD_DETAIL_INFO(Obj_GetP18.Item(0).Road_Detail)
            Dim Obj_Binifit As List(Of Cls_BINIFIT) = GET_BINIFIT_INFO(Obj_GetP18.Item(0).Binifit)
            Dim Obj_Road_Forntoff As List(Of Cls_RoadFrontOff) = GET_ROADFRONTOFF_INFO(Obj_GetP18.Item(0).Road_Frontoff)
            'Dim Obj_Site As List(Of Cls_SITE) = GET_SITE_INFO(Obj_GetP18.Item(0).Sited)
            'Dim Obj_AreaColour As List(Of Cls_Area_Colour) = GET_AREA_COLOUR_INFO(Obj_GetP18.Item(0).AreaColour_No)
            Dim Obj_Public_Utility As List(Of Cls_Public_Utility) = GET_PUBLIC_UTILITY_INFO(Obj_GetP18.Item(0).Public_Utility)
            Dim Obj_TENDENCY As List(Of Cls_TENDENCY) = GET_TENDENCY_INFO(Obj_GetP18.Item(0).Tendency)
            Dim Obj_BuySale_State As List(Of Cls_Buy_Sale_State) = GET_BUYSALE_STATE_INFO(Obj_GetP18.Item(0).BuySale_State)
            Dim Obj_SiteWalkIs As List(Of Cls_Floor) = GET_FLOOR_INFO(Obj_GetP18.Item(0).SideWalk_Is)
            Dim Obj_Interior As List(Of Cls_Interior) = GET_INTERIOR_INFO(Obj_GetP18.Item(0).InteriorState_Id)
            Dim other As String = ""

            If Obj_GetP18.Item(0).Elevator_Util = -1 Then
                other = "ลิฟท์"
            End If

            If Obj_GetP18.Item(0).Parking_Util = -1 Then
                other = other & "  " & "ที่จอดรถ"
            End If

            If Obj_GetP18.Item(0).Pool_Util = -1 Then
                other = other & "  " & "สระว่ายน้ำ"
            End If

            If Obj_GetP18.Item(0).Fitness_Util = -1 Then
                other = other & "  " & "ฟิตเนส"
            End If

            If Obj_GetP18.Item(0).Other_Util = -1 Then
                other = other & "  " & "และ อื่น ๆ" & Obj_GetP18.Item(0).Other_Util_Detail
            End If


            lblLandDetail1.Text = Replace(Space(10), " ", "&nbsp;") & "อาคารชุด ตั้งอยู่ที่ถนน  " & Obj_GetP18.Item(0).Road & "   " & Obj_RoadAccess_Detail.Item(0).Road_Detail_Name & "  ระยะประมาณ " & Obj_GetP18.Item(0).Road_Access & " เมตร "
            lblLandDetail2.Text = Replace(Space(10), " ", "&nbsp;") & "ถนนหน้าหลักประกัน  " & Replace(Space(10), " ", "&nbsp;") & Obj_Road_Forntoff.Item(0).Road_Frontoff_Name & Replace(Space(10), " ", "&nbsp;") & " กว้าง " & Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(0).RoadWidth & Replace(Space(10), " ", "&nbsp;") & " เมตร (รายละเอียดตามรูปแผนที่สังเขป)"
            lblLandDetail3.Text = Replace(Space(10), " ", "&nbsp;") & "สภาพลักษณะรูปห้องชุด  "
            lblLandDetail4.Text = Replace(Space(10), " ", "&nbsp;") & "ขนาดห้องชุด กว้างติดทางเดิน  " & Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(0).RoomWidth_BehideSiteWalk & Replace(Space(10), " ", "&nbsp;") & " เมตร  " & Replace(Space(10), " ", "&nbsp;") & " ลึก  " & Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(0).Roomdeep & " เมตร  " & Replace(Space(10), " ", "&nbsp;") & " ด้านหลัง  " & Replace(Space(10), " ", "&nbsp;") & Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(0).Backside_Width & Replace(Space(10), " ", "&nbsp;") & " เมตร "
            lblLandDetail5.Text = Replace(Space(10), " ", "&nbsp;") & "สภาพทางเดินในอาคารชุด  " & Obj_SiteWalkIs.Item(0).Floor_Name
            lblLandDetail6.Text = Replace(Space(10), " ", "&nbsp;") & "ทำเลใกล้เคียงอาคารชุด  " & Replace(Space(10), " ", "&nbsp;") & Obj_Binifit.Item(0).Binifit_Name
            lblLandDetail7.Text = Replace(Space(10), " ", "&nbsp;") & "สาธารณูปโภค  " & Obj_Public_Utility.Item(0).Public_Utility_Name & Replace(Space(10), " ", "&nbsp;") & "สิ่งอำนวยความสะดวก" & Replace(Space(10), " ", "&nbsp;") & other & Replace(Space(10), " ", "&nbsp;") & "แนวโน้มความเจริญ   " & Obj_TENDENCY.Item(0).Tendency_Name
            lblLandDetail8.Text = Replace(Space(10), " ", "&nbsp;") & "สภาพการซื้อขาย  " & Obj_BuySale_State.Item(0).BuySale_State_Name
            lblLandDetail9.Text = Replace(Space(10), " ", "&nbsp;") & "เขตการปกครอง   แขวง/ตำบล" & Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(0).Tumbon1 & Replace(Space(10), " ", "&nbsp;") & "อำเภอ" & Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(0).Amphur1 & Replace(Space(10), " ", "&nbsp;") & "จังหวัด" & Replace(Space(10), " ", "&nbsp;") & Obj_Provinceas.Item(0).PROV_NAME
            lblLandDetail10.Text = "สภาพการตกแต่ง" & Replace(Space(10), " ", "&nbsp;") & Obj_Interior.Item(0).InteriorState_Name
            lblLandDetail11.Text = Replace(Space(10), " ", "&nbsp;") & "สภาพการปรับปรุงห้องชุด" & Replace(Space(5), " ", "&nbsp;") & Obj_GetP18.Item(0).Adjust_Condo
            lblSize.Text = Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(0).Address_No
            lblPriceWah.Text = String.Format("{0:N2}", Obj_GetP18.Item(0).Unit_Price)
            txtLandTotal.Text = String.Format("{0:N2}", Obj_GetP18.Item(0).PriceTotal)
            txtGrandTotal.Text = String.Format("{0:N2}", Obj_GetP18.Item(0).PriceTotal)
            '--------------------------------------------------------
            'lblChanode_No.Text = Obj_GetP18.Item(0).Address_No
            'lblRoad.Text = Obj_GetP18.Item(0).Road
            'Dim Obj_RoadAccess_Detail As List(Of Cls_Road_Detail) = GET_ROAD_DETAIL_INFO(Obj_GetP18.Item(0).Road_Detail)
            'lblRoadAccess_Detail.Text = Obj_RoadAccess_Detail.Item(0).Road_Detail_Name
            'lblMeter_Access.Text = Obj_GetP18.Item(0).Road_Access
            'lblTumbon.Text = Obj_GetP18.Item(0).Tumbon
            'lblAmphur.Text = Obj_GetP18.Item(0).Amphur

            'lblProvince.Text = Obj_Provinceas.Item(0).PROV_NAME
            'Dim Obj_Road_Forntoff As List(Of Cls_RoadFrontOff) = GET_ROADFRONTOFF_INFO(Obj_GetP18.Item(0).Road_Frontoff)
            'lblRoad_Forntoff.Text = Obj_Road_Forntoff.Item(0).Road_Frontoff_Name
            'lblRoad_Forntoff_Width.Text = Obj_GetP18.Item(0).RoadWidth
            'Dim Obj_Public_Utility As List(Of Cls_Public_Utility) = GET_PUBLIC_UTILITY_INFO(Obj_GetP18.Item(0).Public_Utility)
            'lblPublic_Utility.Text = Obj_Public_Utility.Item(0).Public_Utility_Name
            'Dim Obj_TENDENCY As List(Of Cls_TENDENCY) = GET_TENDENCY_INFO(Obj_GetP18.Item(0).Tendency)
            'lblTendency_Name.Text = Obj_TENDENCY.Item(0).Tendency_Name
            'Dim Obj_BuySale_State As List(Of Cls_Buy_Sale_State) = GET_BUYSALE_STATE_INFO(Obj_GetP18.Item(0).BuySale_State)
            'lblBuySale_StateName.Text = Obj_BuySale_State.Item(0).BuySale_State_Name
            'lblLandOwnerShip.Text = Obj_GetP18.Item(0).Ownership
            'lblObligation.Text = Obj_GetP18.Item(0).Obligation
            'txtBuildingPrice.Text = String.Format("{0:N2}", Obj_GetP18.Item(0).PriceTotal)
        End If
    End Sub

    Private Sub Show_Price3_50()
        Dim Obj_GetP50 As List(Of Price3_50) = GET_PRICE3_CONFORM(HiddenField1.Value, HiddenField2.Value, HiddenField3.Value)
        If Obj_GetP50.Count > 0 Then
            lblDetail1.Text = Replace(Space(10), " ", "&nbsp;") & "โฉนดที่ดินที่ เลขที่ " & Obj_GetP50.Item(0).Address_No & " ระวาง " & Obj_GetP50.Item(0).Rawang & " เลขที่ดิน " & Obj_GetP50.Item(0).LandNumber
            lblDetail2.Text = Replace(Space(10), " ", "&nbsp;") & "หน้าสำรวจ  " & Obj_GetP50.Item(0).Surway & " สารบัญ เล่มที่ " & Obj_GetP50.Item(0).DocNo & " หน้า " & Obj_GetP50.Item(0).PageNo
            Dim Obj_Provinceas As List(Of Cls_PROVINCE) = GET_PROVINCE_INFO(Obj_GetP50.Item(0).Province)
            lblDetail3.Text = Replace(Space(10), " ", "&nbsp;") & "ตำบล  " & Obj_GetP50.Item(0).Tumbon & " อำเภอ " & Obj_GetP50.Item(0).Amphur & " จังหวัด " & Obj_Provinceas.Item(0).PROV_NAME & " เนื้อที่ " & Obj_GetP50.Item(0).Rai & " ไร่  " & Obj_GetP50.Item(0).Ngan & " งาน  " & Obj_GetP50.Item(0).Wah & " วา"
            lblDetail4.Text = Replace(Space(10), " ", "&nbsp;") & "ผู้ถือกรรมสิทธิ์ที่ดิน  " & Obj_GetP50.Item(0).Ownership & " ภาระผูกพัน " & Obj_GetP50.Item(0).Obligation & " สิ่งปลูกสร้างของ "
            lblCollName.Text = "ที่ดิน เนื้อที่"
            '---------------------------------------
            'lblChanode_No.Text = Obj_GetP50.Item(0).Address_No
            'lblRai.Text = Obj_GetP50.Item(0).Rai
            'lblNgan.Text = Obj_GetP50.Item(0).Ngan
            'lblWah.Text = Obj_GetP50.Item(0).Wah
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

            lblLandDetail1.Text = Replace(Space(10), " ", "&nbsp;") & "หลักประกัน ตั้งอยู่ที่ถนน  " & Obj_GetP50.Item(0).Road & "   " & Obj_RoadAccess_Detail.Item(0).Road_Detail_Name & "  ระยะประมาณ " & Obj_GetP50.Item(0).Road_Access & " เมตร "
            lblLandDetail2.Text = Replace(Space(10), " ", "&nbsp;") & "ถนนหน้าหลักประกัน  " & Obj_Road_Forntoff.Item(0).Road_Frontoff_Name & " กว้าง " & Obj_GetP50.Item(0).RoadWidth & " เมตร (รายละเอียดตามรูปแผนที่สังเขป)"
            lblLandDetail3.Text = Replace(Space(10), " ", "&nbsp;") & "สภาพลักษณะรูปที่ดิน  "
            lblLandDetail4.Text = Replace(Space(10), " ", "&nbsp;") & "ขนาดที่ดิน กว้างติดถนน  " & Obj_GetP50.Item(0).Land_Closeto_RoadWidth & " เมตร  " & " ลึก  " & Obj_GetP50.Item(0).DeepWidth & " เมตร  " & " ด้านหลัง  " & Obj_GetP50.Item(0).BehindWidth & " เมตร "
            lblLandDetail5.Text = Replace(Space(10), " ", "&nbsp;") & "สภาพและการปรับปรุงระดับของที่ดินกับถนน  " & Obj_Land_State.Item(0).Land_State_Name & Obj_GetP50.Item(0).Land_State_Detail & " ทำเล  " & Obj_Site.Item(0).Site_Name
            lblLandDetail6.Text = Replace(Space(10), " ", "&nbsp;") & "ผังเมืองรวม   ที่ดินอยู่ในเขตพื้นที่สี  " & Obj_AreaColour.Item(0).AreaColour_Name
            lblLandDetail7.Text = Replace(Space(10), " ", "&nbsp;") & "สาธารณูปโภค  " & Obj_Public_Utility.Item(0).Public_Utility_Name & "  แนวโน้มความเจริญ   " & Obj_TENDENCY.Item(0).Tendency_Name
            lblLandDetail8.Text = Replace(Space(10), " ", "&nbsp;") & "สภาพการซื้อขาย  " & Obj_BuySale_State.Item(0).BuySale_State_Name

            '---------------------------------------
            'lblRoad.Text = Obj_GetP50.Item(0).Road
            'lblRoadAccess_Detail.Text = Obj_RoadAccess_Detail.Item(0).Road_Detail_Name
            'lblMeter_Access.Text = Obj_GetP50.Item(0).Road_Access
            'lblTumbon.Text = Obj_GetP50.Item(0).Tumbon
            'lblAmphur.Text = Obj_GetP50.Item(0).Amphur
            'lblProvince.Text = Obj_Provinceas.Item(0).PROV_NAME

            'lblLandState.Text = Obj_Land_State.Item(0).Land_State_Name
            'lblLandStateDetail.Text = Obj_GetP50.Item(0).Land_State_Detail

            'lblRoad_Forntoff.Text = Obj_Road_Forntoff.Item(0).Road_Frontoff_Name
            'lblRoad_Forntoff_Width.Text = Obj_GetP50.Item(0).RoadWidth
            'lblRoadWidth.Text = Obj_GetP50.Item(0).Land_Closeto_RoadWidth

            'lblSiteName.Text = Obj_Site.Item(0).Site_Name
            ''txtSite_Detail.Text = Obj_GetP50.Item(0).Site_Detail

            'lblPublic_Utility.Text = Obj_Public_Utility.Item(0).Public_Utility_Name
            ''txtBinifit.Text = Obj_GetP50.Item(0).Binifit_Detail

            'lblTendency_Name.Text = Obj_TENDENCY.Item(0).Tendency_Name

            'lblBuySale_StateName.Text = Obj_BuySale_State.Item(0).BuySale_State_Name

            lblSubUnit.Text = Obj_SubUnit.Item(0).SubUnit_Name
            'ตรวจสอบราคาของราคา Price 3 Master ที่จะแสดง
            If CInt(Cnt_P3M) = 0 Then
                lblPriceWah.Text = Format(Obj_GetP50.Item(0).PriceWah, "#,##0.00")
                txtLandTotal.Text = Format(Obj_GetP50.Item(0).PriceTotal1, "#,##0.00")
            Else
                txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtLandTotal.Text))
            End If

            'lblRaWang.Text = Obj_GetP50.Item(0).Rawang
            'lblLandNumber.Text = Obj_GetP50.Item(0).LandNumber
            'lblSurway.Text = Obj_GetP50.Item(0).Surway
            'lblDocNo.Text = Obj_GetP50.Item(0).DocNo
            'lblPage.Text = Obj_GetP50.Item(0).PageNo
            'lblLandOwnerShip.Text = Obj_GetP50.Item(0).Ownership
            'lblObligation.Text = Obj_GetP50.Item(0).Obligation
            'lblDeepWidth.Text = Obj_GetP50.Item(0).DeepWidth
            'lblBehindWidth.Text = Obj_GetP50.Item(0).BehindWidth

            'lblArea_Colour.Text = Obj_AreaColour.Item(0).AreaColour_Name
            lblSize.Text = Obj_GetP50.Item(0).Rai & "-" & Obj_GetP50.Item(0).Ngan & "-" & Obj_GetP50.Item(0).Wah
        End If
    End Sub

    Private Sub Show_Price3_70_GROUP()
        Dim Obj_GetP70G As DataSet = GET_PRICE3_70_GROUP(Context.Items("Req_Id"), Context.Items("Hub_Id"), Context.Items("Temp_AID"))
        If Obj_GetP70G.Tables(0).Rows.Count > 0 Then
            If Obj_GetP70G.Tables(0).Rows(0).Item("CntBuild_No") = 1 Then
                lblLandDetail9.Text = "สิ่งปลูกสร้างเลขที่  " & Obj_GetP70G.Tables(0).Rows(0).Item("Build_No") & " รวมจำนวน 1 " & " หลัง (ตามรายละเอียดสิ่งปลูกสร้างแนบ)"
            Else
                lblLandDetail9.Text = "ตามรายละเอียดสิ่งปลูกสร้างแนบ "
            End If

            'lblBuilding_No.Text = Obj_GetP70G.Tables(0).Rows(0).Item("Build_No").ToString()
            lblTotal2.Text = Format(CDec(Obj_GetP70G.Tables(0).Rows(0).Item("UnitPrice").ToString), "#,##0.00")
            'lblItem.Text = Obj_GetP70G.Tables(0).Rows(0).Item("Item").ToString()
            'ตรวจสอบราคาของราคา Price 3 Master ที่จะแสดง
            If CInt(Cnt_P3M) = 0 Then
                txtBuildingPrice.Text = Format(CDec(Obj_GetP70G.Tables(0).Rows(0).Item("Buildingprice").ToString), "#,##0.00")
                txtSubTotal.Text = String.Format("{0:N2}", Obj_GetP70G.Tables(0).Rows(0).Item("PriceTotal1"))
                txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtSubTotal.Text))
            Else
                txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtSubTotal.Text))
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
                Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
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

    Protected Sub ddlAppraisal_Type_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAppraisal_Type.SelectedIndexChanged
        If ddlAppraisal_Type.SelectedValue = 1 Then
            'วิธีตลาด
            If lblCollName.Text = "หลักประกันห้องชุด เลขที่" Then
                'คอนโด

            Else
                'ที่ดิน สิ่งปลูกสร้าง
            End If
        Else
            'วิธีทุน
            If lblCollName.Text = "หลักประกันห้องชุด เลขที่" Then
                'คอนโด
            Else
                'ที่ดิน สิ่งปลูกสร้าง
            End If
        End If
    End Sub
End Class