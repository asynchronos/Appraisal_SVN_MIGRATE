Imports System
Imports System.Web
Imports System.Web.Services
Imports System.Threading
Imports System.Net
Imports System.Data
Imports System.Collections
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Math
Imports Appraisal_Manager
Imports ThaiBaht
Partial Class Appraisal_Report_FullForm4Other
    Inherits System.Web.UI.Page
    Dim Obligation As String = ""
    Dim StringMessage As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblYear.Text = Year(Now)
            hdfReq_Id.Value = Request.QueryString("Req_Id")
            hdfHub_Id.Value = Request.QueryString("Hub_Id")
            HiddenField_ApproveId.Value = Request.QueryString("ApproveId")
            Dim Obj_P3M As List(Of clsPrice3_Master) = GET_PRICE3_MASTER_FOR_CONFIRM(hdfReq_Id.Value) 'มีข้อมูลที่บันทึกแล้วหรือไม่
            If Obj_P3M.Count > 0 Then
                'ถ้ามีแล้วให้เอาข้อมูลเดิมมาแสดง
                Appraisal_Request_Info()
                PRICE2_MASTER()
                If hdfChkColl.Value = 18 Then
                    Condo_Info()
                    FullForm_Info(Obj_P3M)
                    'ImageButtonBuilding.Visible = False
                ElseIf hdfChkColl.Value = 50 Then
                    Land_Info()
                    FullForm_Info(Obj_P3M)
                ElseIf hdfChkColl.Value = 70 Then
                    Land_Info()
                    Building_Info()
                    FullForm_Info(Obj_P3M)
                End If
                lblThaiBaht.Text = ThaiBahtFun(CDec(txtGrandTotal.Text))
            Else
                'ถ้ายังไม่มีข้อมูล
                StringMessage = "<script language=""javascript"">alert('เจ้าหน้าที่ประเมินยังไม่ได้บันทึกรายละเอียดรายงานการประเมิน'); </script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "เตือนรายงานการประเมิน", StringMessage)
            End If
        End If
    End Sub

    Sub Appraisal_Request_Info()
        Dim App_Request As List(Of Appraisal_Request_v2) = GET_APPRAISAL_REQUEST_V2(hdfReq_Id.Value)
        lblCif.Text = App_Request.Item(0).Cif
        Dim Obj_title As List(Of Cls_Title) = GET_TITLE_INFO(App_Request.Item(0).Title)
        lblCifName.Text = Obj_title.Item(0).TITLE_NAME & App_Request.Item(0).Name & "  " & App_Request.Item(0).Lastname
        Dim Obj_Branch As List(Of Class_Branch) = GET_BRANCH_BY_KEY(App_Request.Item(0).Branch_Id)
        lblBranch.Text = Obj_Branch.Item(0).BRANCH_NAME
        'Dim Obj_Emp As List = GET_SYSTEM_USER(App_Request.Item(0).Appraisal_Id
        Dim Obj_Appraisal As DataSet = GET_APPRAISAL_APPROVAL(App_Request.Item(0).Appraisal_Id)
        HiddenField_Appraisal_Id.Value = App_Request.Item(0).Appraisal_Id
        lblAppraisal_Name.Text = Obj_Appraisal.Tables(0).Rows(0).Item("UserAppraisal")

    End Sub

    Sub Land_Info()
        Dim SumP3 As DataSet = GET_SUM_PRICE3_50(hdfReq_Id.Value, hdfHub_Id.Value, hdfTemp_AID.Value)
        Dim Obj_GetP50 As List(Of Price3_50) = GET_PRICE3_CONFORM(hdfReq_Id.Value, hdfHub_Id.Value, hdfTemp_AID.Value)
        '    If Obj_GetP50.Count > 0 Then
        '        'มีชิ้นทรัพย์ที่เป็นที่ดิน
        If Obj_GetP50.Count = 1 Then 'ถ้ามีที่ดิน 1 ชิ้น
            Dim Osubtype As List(Of Cls_SubCollType) = GET_SUBCOLLTYPE(Obj_GetP50.Item(0).MysubColl_ID)
            lblDetail1.Text = Replace(Space(10), " ", "&nbsp;") & Osubtype.Item(0).SubCollType_Name & " เลขที่" & Replace(Space(5), " ", "&nbsp;") & Obj_GetP50.Item(0).Address_No & Replace(Space(3), " ", "&nbsp;") & "ระวาง" & Replace(Space(3), " ", "&nbsp;") & Obj_GetP50.Item(0).Rawang & Replace(Space(3), " ", "&nbsp;") & "เลขที่ดิน" & Replace(Space(3), " ", "&nbsp;") & Obj_GetP50.Item(0).LandNumber
            lblDetail2.Text = Replace(Space(10), " ", "&nbsp;") & "หน้าสำรวจ " & Replace(Space(5), " ", "&nbsp;") & Obj_GetP50.Item(0).Surway & Replace(Space(5), " ", "&nbsp;") & "สารบัญ เล่มที่" & Obj_GetP50.Item(0).DocNo & Replace(Space(5), " ", "&nbsp;") & "หน้า" & Obj_GetP50.Item(0).PageNo
            Dim Obj_Provinceas As List(Of Cls_PROVINCE) = GET_PROVINCE_INFO(Obj_GetP50.Item(0).Province)
            Obligation = Obj_GetP50.Item(0).Obligation
            lblDetail3.Text = Replace(Space(10), " ", "&nbsp;") & "ตำบล" & Replace(Space(5), " ", "&nbsp;") & Obj_GetP50.Item(0).Tumbon & Replace(Space(5), " ", "&nbsp;") & "อำเภอ" & Replace(Space(5), " ", "&nbsp;") & Obj_GetP50.Item(0).Amphur & Replace(Space(5), " ", "&nbsp;") & "จังหวัด" & Replace(Space(5), " ", "&nbsp;") & Obj_Provinceas.Item(0).PROV_NAME & Replace(Space(5), " ", "&nbsp;") & "เนื้อที่" & Replace(Space(5), " ", "&nbsp;") & Obj_GetP50.Item(0).Rai & " ไร่  " & Obj_GetP50.Item(0).Ngan & Replace(Space(5), " ", "&nbsp;") & "งาน " & Obj_GetP50.Item(0).Wah & " วา"
            lblDetail4.Text = Replace(Space(10), " ", "&nbsp;") & "ผู้ถือกรรมสิทธิ์ที่ดิน  " & Replace(Space(5), " ", "&nbsp;") & Obj_GetP50.Item(0).Ownership & Replace(Space(5), " ", "&nbsp;")

            lblPriceWah.Text = Format(Obj_GetP50.Item(0).PriceWah, "#,##0.00")
            lblSize.Text = Obj_GetP50.Item(0).Rai & "-" & Obj_GetP50.Item(0).Ngan & "-" & Obj_GetP50.Item(0).Wah
        Else
            '            'ถ้ามีที่ดินมากกว่า 1 ชิ้น
            Obligation = Obj_GetP50.Item(0).Obligation
            Dim Osubtype As List(Of Cls_SubCollType) = GET_SUBCOLLTYPE(Obj_GetP50.Item(0).MysubColl_ID)
            If Obj_GetP50.Count > 1 And Obj_GetP50.Count < 4 Then
                Dim DS As DataSet = GET_PRICE3_50_GROUP(hdfReq_Id.Value, hdfHub_Id.Value, hdfTemp_AID.Value)
                lblDetail1.Text = Replace(Space(10), " ", "&nbsp;") & Osubtype.Item(0).SubCollType_Name & " เลขที่" & Replace(Space(5), " ", "&nbsp;") & DS.Tables(0).Rows(0).Item("Address_no") & Replace(Space(3), " ", "&nbsp;") & "ระวาง" & Replace(Space(3), " ", "&nbsp;") & DS.Tables(0).Rows(0).Item("Rawang") & Replace(Space(3), " ", "&nbsp;") & "เลขที่ดิน" & Replace(Space(3), " ", "&nbsp;") & DS.Tables(0).Rows(0).Item("LandNumber")
                lblDetail2.Text = Replace(Space(10), " ", "&nbsp;") & "หน้าสำรวจ " & Replace(Space(5), " ", "&nbsp;") & DS.Tables(0).Rows(0).Item("Surway")
            Else
                lblDetail1.Text = Replace(Space(10), " ", "&nbsp;") & Osubtype.Item(0).SubCollType_Name & " เลขที่" & Replace(Space(5), " ", "&nbsp;") & "ตามเอกสารแนบ" & Replace(Space(3), " ", "&nbsp;") & "ระวาง" & Replace(Space(3), " ", "&nbsp;") & "ตามเอกสารแนบ" & Replace(Space(3), " ", "&nbsp;") & "เลขที่ดิน" & Replace(Space(3), " ", "&nbsp;") & "ตามเอกสารแนบ"
                lblDetail2.Text = Replace(Space(10), " ", "&nbsp;") & "หน้าสำรวจ " & Replace(Space(5), " ", "&nbsp;") & "ตามเอกสารแนบ"
            End If
            'lblDetail1.Text = Replace(Space(10), " ", "&nbsp;") & Osubtype.Item(0).SubCollType_Name & " เลขที่" & Replace(Space(5), " ", "&nbsp;") & Obj_GetP50.Item(0).Address_No & Replace(Space(3), " ", "&nbsp;") & "ระวาง" & Replace(Space(3), " ", "&nbsp;") & Obj_GetP50.Item(0).Rawang & Replace(Space(3), " ", "&nbsp;") & "เลขที่ดิน" & Replace(Space(3), " ", "&nbsp;") & Obj_GetP50.Item(0).LandNumber
            'lblDetail2.Text = Replace(Space(10), " ", "&nbsp;") & "หน้าสำรวจ " & Replace(Space(5), " ", "&nbsp;") & "ตามเอกสารแนบ"
            Dim Obj_Provinceas As List(Of Cls_PROVINCE) = GET_PROVINCE_INFO(Obj_GetP50.Item(0).Province)
            lblDetail3.Text = Replace(Space(10), " ", "&nbsp;") & "ตำบล" & Replace(Space(5), " ", "&nbsp;") & Obj_GetP50.Item(0).Tumbon & Replace(Space(5), " ", "&nbsp;") & "อำเภอ" & Replace(Space(5), " ", "&nbsp;") & Obj_GetP50.Item(0).Amphur & Replace(Space(5), " ", "&nbsp;") & "จังหวัด" & Replace(Space(5), " ", "&nbsp;") & Obj_Provinceas.Item(0).PROV_NAME
            lblDetail4.Text = Replace(Space(10), " ", "&nbsp;") & "ผู้ถือกรรมสิทธิ์ที่ดิน  " & Replace(Space(5), " ", "&nbsp;") & Obj_GetP50.Item(0).Ownership & Replace(Space(5), " ", "&nbsp;")
            '            txtLandTotal.Text = Format(SumP3.Tables(0).Rows(0).Item("PriceTotal1"), "#,##0.00")
            If SumP3.Tables(0).Rows(0).Item("TotalWah") <= 100 Then
                lblSize.Text = "0" & "-" & "0" & "-" & SumP3.Tables(0).Rows(0).Item("TotalWah")
            Else
                lblSize.Text = SumP3.Tables(0).Rows(0).Item("Rai") & "-" & SumP3.Tables(0).Rows(0).Item("Ngan") & "-" & SumP3.Tables(0).Rows(0).Item("Wah")
            End If
        End If

        '        'ใช้ข้อมูลด้วยกัน ถึงแม้จะมีที่ดินกี่ชิ้น
        lblCollName.Text = "ที่ดิน เนื้อที่"
        Dim Obj_RoadAccess_Detail As List(Of Cls_Road_Detail) = GET_ROAD_DETAIL_INFO(Obj_GetP50.Item(0).Road_Detail)
        Dim Obj_Land_State As List(Of Cls_LandState) = GET_LANDSTATE_INFO(Obj_GetP50.Item(0).Land_State)
        Dim Obj_Road_Forntoff As List(Of Cls_RoadFrontOff) = GET_ROADFRONTOFF_INFO(Obj_GetP50.Item(0).Road_Frontoff)
        Dim Obj_Site As List(Of Cls_SITE) = GET_SITE_INFO(Obj_GetP50.Item(0).Sited)
        Dim Obj_AreaColour As List(Of Cls_Area_Colour) = GET_AREA_COLOUR_INFO(Obj_GetP50.Item(0).AreaColour_No)
        Dim Obj_Public_Utility As List(Of Cls_Public_Utility) = GET_PUBLIC_UTILITY_INFO(Obj_GetP50.Item(0).Public_Utility)
        Dim Obj_TENDENCY As List(Of Cls_TENDENCY) = GET_TENDENCY_INFO(Obj_GetP50.Item(0).Tendency)
        Dim Obj_BuySale_State As List(Of Cls_Buy_Sale_State) = GET_BUYSALE_STATE_INFO(Obj_GetP50.Item(0).BuySale_State)
        Dim Obj_SubUnit As List(Of Cls_SubUnit) = GET_SubUnit_Info(Obj_GetP50.Item(0).SubUnit)

        lblLandDetail1.Text = Replace(Space(10), " ", "&nbsp;") & "หลักประกัน ตั้งอยู่ที่ถนน  " & Replace(Space(5), " ", "&nbsp;") & Obj_GetP50.Item(0).Road & Replace(Space(5), " ", "&nbsp;") & Obj_RoadAccess_Detail.Item(0).Road_Detail_Name & Replace(Space(5), " ", "&nbsp;") & Obj_GetP50.Item(0).Soi & " ระยะประมาณ" & Replace(Space(5), " ", "&nbsp;") & Obj_GetP50.Item(0).Road_Access & " เมตร "
        lblLandDetail2.Text = Replace(Space(10), " ", "&nbsp;") & "ถนนหน้าหลักประกัน  " & Replace(Space(5), " ", "&nbsp;") & Obj_Road_Forntoff.Item(0).Road_Frontoff_Name & Replace(Space(5), " ", "&nbsp;") & Replace(Space(5), " ", "&nbsp;") & " กว้าง " & Obj_GetP50.Item(0).RoadWidth & Replace(Space(5), " ", "&nbsp;") & " เมตร (รายละเอียดตามรูปแผนที่สังเขป)"
        lblLandDetail3.Text = Replace(Space(10), " ", "&nbsp;") & "สภาพลักษณะรูปที่ดิน  " & Replace(Space(5), " ", "&nbsp;") & Obj_GetP50.Item(0).Binifit_Detail
        lblLandDetail4.Text = Replace(Space(10), " ", "&nbsp;") & "ขนาดที่ดิน กว้างติดถนน " & Replace(Space(3), " ", "&nbsp;") & Replace(Space(3), " ", "&nbsp;") & SumP3.Tables(0).Rows(0).Item("Land_Closeto_RoadWidth") & Replace(Space(3), " ", "&nbsp;") & " เมตร  " & Replace(Space(3), " ", "&nbsp;") & " ลึกซ้าย/ขวา  " & Replace(Space(3), " ", "&nbsp;") & Obj_GetP50.Item(0).DeepWidth & Replace(Space(3), " ", "&nbsp;") & " เมตร  " & Replace(Space(3), " ", "&nbsp;") & " ด้านหลัง  " & SumP3.Tables(0).Rows(0).Item("BehindWidth") & " เมตร "
        lblLandDetail5.Text = Replace(Space(10), " ", "&nbsp;") & "สภาพและการปรับปรุงระดับของที่ดินกับถนน  " & Replace(Space(5), " ", "&nbsp;") & Obj_Land_State.Item(0).Land_State_Name & Replace(Space(5), " ", "&nbsp;") & Obj_GetP50.Item(0).Land_State_Detail & Replace(Space(5), " ", "&nbsp;") & " ทำเล  " & Replace(Space(5), " ", "&nbsp;") & Obj_Site.Item(0).Site_Name
        lblLandDetail6.Text = Replace(Space(10), " ", "&nbsp;") & "ผังเมืองรวม   ที่ดินอยู่ในเขตพื้นที่สี  " & Replace(Space(5), " ", "&nbsp;") & Obj_AreaColour.Item(0).AreaColour_Name
        lblLandDetail7.Text = Replace(Space(10), " ", "&nbsp;") & "สาธารณูปโภค  " & Replace(Space(5), " ", "&nbsp;") & Obj_Public_Utility.Item(0).Public_Utility_Name & Replace(Space(5), " ", "&nbsp;") & Obj_GetP50.Item(0).Public_Utility_Detail & Replace(Space(5), " ", "&nbsp;") & "แนวโน้มความเจริญ" & Replace(Space(5), " ", "&nbsp;") & Obj_TENDENCY.Item(0).Tendency_Name
        lblLandDetail8.Text = Replace(Space(10), " ", "&nbsp;") & "สภาพการซื้อขาย " & Replace(Space(5), " ", "&nbsp;") & Obj_BuySale_State.Item(0).BuySale_State_Name

        lblSubUnit.Text = Obj_SubUnit.Item(0).SubUnit_Name
    End Sub

    Sub Building_Info()
        Dim Obj_GetP70G As DataSet = GET_PRICE3_70_GROUP_V1(hdfReq_Id.Value, hdfHub_Id.Value, hdfTemp_AID.Value)
        Dim Cnt As Integer = GET_BUILDING_ITEMS_PRICE2(hdfReq_Id.Value, hdfHub_Id.Value)

        If Obj_GetP70G.Tables(0).Rows.Count > 0 Then
            If Cnt = 0 Then
                lblLandDetail9.Text = ""
            ElseIf Cnt = 1 Then
                lblDetail4.Text = lblDetail4.Text & "สิ่งปลูกสร้างของ" & Replace(Space(5), " ", "&nbsp;") & Obj_GetP70G.Tables(0).Rows(0).Item("Ownership") & Replace(Space(5), " ", "&nbsp;") & "ภาระผูกพัน" & Replace(Space(5), " ", "&nbsp;") & Obligation
                lblLandDetail9.Text = "สิ่งปลูกสร้างเลขที่  " & Obj_GetP70G.Tables(0).Rows(0).Item("Build_No") & " รวมจำนวน  " & Cnt & " รายการ (ตามรายละเอียดสิ่งปลูกสร้างแนบ)"
            Else
                lblLandDetail9.Text = "สิ่งปลูกสร้างจำนวน  " & Cnt & " รายการ ตามรายละเอียดเอกสารสิ่งปลูกสร้างแนบ "
            End If
            lblBuilding_Detail.Text = "จำนวน  " & Cnt & " รายการ"
            Dim P2Master As List(Of Price2_Master) = GET_PRICE2_MASTER(hdfReq_Id.Value, hdfHub_Id.Value)
            If P2Master.Item(0).Appraisal_Type = 1 Then
                'วิธีตลาด
                txtBuildingPrice.Text = String.Format("{0:N2}", ((Obj_GetP70G.Tables(0).Rows(0).Item("PriceTotal1"))))
            Else
                'วิธีทุน
            End If
        Else

        End If
    End Sub

    Sub Condo_Info()
        Dim Obj_GetP18 As List(Of Price3_18) = GET_PRICE3_18(hdfReq_Id.Value, hdfHub_Id.Value, hdfTemp_AID.Value)
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
            'lblDetail1.Text = Replace(Space(10), " ", "&nbsp;") & "หนังสือกรรมสิทธิ์ห้องชุดเลขที่ " & Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(0).Address_No & Replace(Space(10), " ", "&nbsp;") & "ชั้นที่  " & Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(0).Floors & Replace(Space(10), " ", "&nbsp;") & "อาคารเลขที่" & Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(0).Building_No
            lblDetail2.Text = Replace(Space(10), " ", "&nbsp;") & "ชื่ออาคารชุด" & Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(0).Building_Name & Replace(Space(10), " ", "&nbsp;") & "ทะเบียนอาคารชุดเลขที่     " & Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(0).Building_Reg_No
            lblDetail3.Text = Replace(Space(10), " ", "&nbsp;") & "ตำแหน่งที่ตั้ง     ตำบล" & Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(0).Tumbon & Replace(Space(10), " ", "&nbsp;") & "อำเภอ" & Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(0).Amphur & "จังหวัด" & Replace(Space(10), " ", "&nbsp;") & Obj_Provinceas.Item(0).PROV_NAME
            'lblDetail4.Text = Replace(Space(3), " ", "&nbsp;") & "เนื้อที่ห้องชุด" & Replace(Space(4), " ", "&nbsp;") & Obj_GetP18.Item(0).Room_Area & Replace(Space(5), " ", "&nbsp;") & "ตารางเมตร" & Replace(Space(5), " ", "&nbsp;") & "สูง" & Replace(Space(5), " ", "&nbsp;") & Obj_GetP18.Item(0).Room_Height & Replace(Space(5), " ", "&nbsp;") & "เมตร" & Obj_GetP18.Item(0).Other_Detail & Replace(Space(5), " ", "&nbsp;") & "ทรัพย์สินส่วนบุคคลภายนอกห้องชุด" & Replace(Space(5), " ", "&nbsp;") & Obj_GetP18.Item(0).Partake_Detail
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
            Dim Obj_Character_Room As DataSet = GET_CHARACTER_ROOM_INFO(Obj_GetP18.Item(0).Character_Room_Id)
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
            lblLandDetail3.Text = Replace(Space(10), " ", "&nbsp;") & "สภาพลักษณะรูปห้องชุด  " & Replace(Space(10), " ", "&nbsp;") & Obj_Character_Room.Tables(0).Rows(0).Item("CHARACTER_ROOM_NAME")
            lblLandDetail4.Text = Replace(Space(10), " ", "&nbsp;") & "ขนาดห้องชุด กว้างติดทางเดิน  " & Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(0).RoomWidth_BehideSiteWalk & Replace(Space(10), " ", "&nbsp;") & " เมตร  " & Replace(Space(10), " ", "&nbsp;") & " ลึก  " & Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(0).Roomdeep & " เมตร  " & Replace(Space(10), " ", "&nbsp;") & " ด้านหลัง  " & Replace(Space(10), " ", "&nbsp;") & Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(0).Backside_Width & Replace(Space(10), " ", "&nbsp;") & " เมตร "
            lblLandDetail5.Text = Replace(Space(10), " ", "&nbsp;") & "สภาพทางเดินในอาคารชุด  " & Obj_SiteWalkIs.Item(0).Floor_Name
            lblLandDetail6.Text = Replace(Space(10), " ", "&nbsp;") & "ทำเลใกล้เคียงอาคารชุด  " & Replace(Space(10), " ", "&nbsp;") & Obj_Binifit.Item(0).Binifit_Name
            lblLandDetail7.Text = Replace(Space(10), " ", "&nbsp;") & "สาธารณูปโภค  " & Obj_Public_Utility.Item(0).Public_Utility_Name & Replace(Space(10), " ", "&nbsp;") & "สิ่งอำนวยความสะดวก" & Replace(Space(10), " ", "&nbsp;") & other & Replace(Space(10), " ", "&nbsp;") & "แนวโน้มความเจริญ   " & Obj_TENDENCY.Item(0).Tendency_Name
            lblLandDetail8.Text = Replace(Space(10), " ", "&nbsp;") & "สภาพการซื้อขาย  " & Obj_BuySale_State.Item(0).BuySale_State_Name
            lblLandDetail9.Text = Replace(Space(10), " ", "&nbsp;") & "เขตการปกครอง   แขวง/ตำบล" & Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(0).Tumbon1 & Replace(Space(10), " ", "&nbsp;") & "อำเภอ" & Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(0).Amphur1 & Replace(Space(10), " ", "&nbsp;") & "จังหวัด" & Replace(Space(10), " ", "&nbsp;") & Obj_Provinceas.Item(0).PROV_NAME
            lblLandDetail10.Text = Replace(Space(10), " ", "&nbsp;") & "สภาพการตกแต่ง" & Replace(Space(10), " ", "&nbsp;") & Obj_Interior.Item(0).InteriorState_Name
            lblLandDetail11.Text = Replace(Space(10), " ", "&nbsp;") & "สภาพการปรับปรุงห้องชุด" & Replace(Space(5), " ", "&nbsp;") & Obj_GetP18.Item(0).Adjust_Condo
            lblSize.Text = Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(0).Address_No
            lblPriceWah.Text = String.Format("{0:N2}", Obj_GetP18.Item(0).Unit_Price)
            txtLandTotal.Text = String.Format("{0:N2}", Round(CDec(Obj_GetP18.Item(0).PriceTotal) / 1000, System.MidpointRounding.AwayFromZero) * 1000)
            'txtLandTotal.Text = String.Format("{0:N2}", Round(CDec(Obj_GetP18.Item(0).PriceTotal) / 1000, System.MidpointRounding.AwayFromZero) * 1000)
            txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtLandTotal.Text))
            '--------------------------------------------------------
            Dim add As String = String.Empty
            Dim area As Double = 0
            For i = 0 To Obj_GetP18.Count - 1
                If i = 1 Then
                    lblBuilding_Detail.Text = Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(i).Address_No
                    lblUnit_Price_Condo.Text = String.Format("{0:N2}", Obj_GetP18.Item(i).Unit_Price)
                    txtBuildingPrice.Text = String.Format("{0:N2}", Round(CDec(Obj_GetP18.Item(i).PriceTotal) / 1000, System.MidpointRounding.AwayFromZero) * 1000)
                    'txtBuildingPrice.Text = String.Format("{0:N2}", Obj_GetP18.Item(i).PriceTotal)
                ElseIf i = 2 Then
                    lblBuilding_Detail.Text = Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(i).Address_No
                    lblTotal3.Text = String.Format("{0:N2}", Obj_GetP18.Item(i).Unit_Price)
                    txtSubTotal.Text = String.Format("{0:N2}", Round(CDec(Obj_GetP18.Item(i).PriceTotal) / 1000, System.MidpointRounding.AwayFromZero) * 1000)
                    'txtBuildingPrice.Text = String.Format("{0:N2}", Obj_GetP18.Item(i).PriceTotal)
                Else
                    'รวมแล้วนำไปไว้ที่บรรทัดบนสุด
                End If
                add += Obj_GetP18.Item(i).Address_No & Replace(Space(5), " ", "&nbsp;")
                area += Obj_GetP18.Item(i).Room_Area
            Next
            lblDetail1.Text = Replace(Space(10), " ", "&nbsp;") & "หนังสือกรรมสิทธิ์ห้องชุดเลขที่ " & Replace(Space(10), " ", "&nbsp;") & add.ToString & Replace(Space(10), " ", "&nbsp;") & "ชั้นที่  " & Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(0).Floors & Replace(Space(10), " ", "&nbsp;") & "อาคารเลขที่" & Replace(Space(10), " ", "&nbsp;") & Obj_GetP18.Item(0).Building_No
            lblDetail4.Text = Replace(Space(3), " ", "&nbsp;") & "เนื้อที่ห้องชุด" & Replace(Space(4), " ", "&nbsp;") & area & Replace(Space(5), " ", "&nbsp;") & "ตารางเมตร" & Replace(Space(5), " ", "&nbsp;") & "สูง" & Replace(Space(5), " ", "&nbsp;") & Obj_GetP18.Item(0).Room_Height & Replace(Space(5), " ", "&nbsp;") & "เมตร" & Obj_GetP18.Item(0).Other_Detail & Replace(Space(5), " ", "&nbsp;") & "ทรัพย์สินส่วนบุคคลภายนอกห้องชุด" & Replace(Space(5), " ", "&nbsp;") & Obj_GetP18.Item(0).Partake_Detail
            txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtLandTotal.Text) + CDec(txtBuildingPrice.Text) + CDec(txtSubTotal.Text))
        End If
    End Sub

    Sub PRICE2_MASTER()
        Dim P2M As DataSet = GET_PRICE2_MASTER_NEW(hdfReq_Id.Value, hdfHub_Id.Value)
        hdfTemp_AID.Value = P2M.Tables(0).Rows(0).Item("Temp_AID")

        If P2M.Tables(0).Rows(0).Item("Appraisal_Type") = 1 Then
            'วิธีตลาด
            If P2M.Tables(0).Rows(0).Item("Building") > 0 Then
                hdfChkColl.Value = 70
                txtLandTotal.Text = String.Format("{0:N2}", P2M.Tables(0).Rows(0).Item("Land"))
                'txtBuildingPrice.Text = "0.00"
                txtSubTotal.Text = String.Format("{0:N2}", P2M.Tables(0).Rows(0).Item("Building"))
                txtGrandTotal.Text = String.Format("{0:N2}", P2M.Tables(0).Rows(0).Item("Building"))
            ElseIf P2M.Tables(0).Rows(0).Item("Condo") > 0 Then
                hdfChkColl.Value = 18
                txtLandTotal.Text = String.Format("{0:N2}", P2M.Tables(0).Rows(0).Item("Condo"))
                txtGrandTotal.Text = String.Format("{0:N2}", P2M.Tables(0).Rows(0).Item("Condo"))
            End If

        ElseIf P2M.Tables(0).Rows(0).Item("Appraisal_Type") = 2 Then
            'วิธีทุน
            If P2M.Tables(0).Rows(0).Item("Land") > 0 Then
                If P2M.Tables(0).Rows(0).Item("Building") > 0 Then
                    hdfChkColl.Value = 70
                    txtLandTotal.Text = String.Format("{0:N2}", P2M.Tables(0).Rows(0).Item("Land"))
                    txtBuildingPrice.Text = String.Format("{0:N2}", P2M.Tables(0).Rows(0).Item("Building"))
                    txtSubTotal.Text = "0.00"
                    txtGrandTotal.Text = String.Format("{0:N2}", P2M.Tables(0).Rows(0).Item("Land") + P2M.Tables(0).Rows(0).Item("Building"))
                Else
                    hdfChkColl.Value = 50
                    txtLandTotal.Text = String.Format("{0:N2}", P2M.Tables(0).Rows(0).Item("Land"))
                    txtBuildingPrice.Text = String.Format("{0:N2}", P2M.Tables(0).Rows(0).Item("Building"))
                    txtSubTotal.Text = "0.00"
                    txtGrandTotal.Text = String.Format("{0:N2}", P2M.Tables(0).Rows(0).Item("Land") + P2M.Tables(0).Rows(0).Item("Building"))
                End If
            Else
                hdfChkColl.Value = 70
                txtLandTotal.Text = String.Format("{0:N2}", P2M.Tables(0).Rows(0).Item("Land"))
                txtBuildingPrice.Text = String.Format("{0:N2}", P2M.Tables(0).Rows(0).Item("Building"))
                txtSubTotal.Text = "0.00"
                txtGrandTotal.Text = String.Format("{0:N2}", P2M.Tables(0).Rows(0).Item("Land") + P2M.Tables(0).Rows(0).Item("Building"))
            End If
        End If
        HiddenFieldLandPriceValue.Value = txtLandTotal.Text
    End Sub

    Sub FullForm_Info(ByVal Obj_P3M As List(Of clsPrice3_Master))
        'ค้นหาว่ามีการกำหนดราคาที่ 3 แล้วหรือไม่
        If Obj_P3M.Count > 0 Then
            'มีการกำหนดราคาที่ 3 แล้ว

            Dim Obj_Branch As List(Of Class_Branch) = GET_BRANCH_BY_KEY(Obj_P3M.Item(0).Req_Dept)
            lblBranch.Text = Obj_Branch.Item(0).BRANCH_NAME
            lblAID.Text = Obj_P3M.Item(0).AID
            lblInform_To.Text = Obj_P3M.Item(0).Inform_To

            lblReceive_Date.Text = Obj_P3M.Item(0).Receive_Date
            lblYear.Text = Year(Obj_P3M.Item(0).Receive_Date)
            lblAppraisal_Date.Text = Obj_P3M.Item(0).Appraisal_Date
            If Obj_P3M.Item(0).Env_Effect = 1 Then
                lblProblem.Text = "ไม่มีปัญหา"
            Else
                lblProblem.Text = "อาจมีปัญหา"
            End If
            lblProblem_Detail.Text = Obj_P3M.Item(0).Env_Effect_Detail
            txtBuy_Sale_Comment.Text = Obj_P3M.Item(0).Appraisal_Detail
            HiddenField_Appraisal_Type.Value = Obj_P3M.Item(0).Appraisal_Type_ID
            If Obj_P3M.Item(0).Appraisal_Type_ID = 1 Then
                lblAppraisal_Type.Text = "วิธีเปรียบเทียบตลาด"
            ElseIf Obj_P3M.Item(0).Appraisal_Type_ID = 2 Then
                lblAppraisal_Type.Text = "วิธีต้นทุน"
            End If

            Dim Obj_Comment As DataSet = GET_COMMENT_INFO(Obj_P3M.Item(0).Comment_ID)
            lblComment.Text = Obj_Comment.Tables(0).Rows(0).Item("Comment_Name")
            Dim Obj_Warning As DataSet = GET_WARNING_INFO(Obj_P3M.Item(0).Warning_ID)
            lblWarning.Text = Obj_Warning.Tables(0).Rows(0).Item("Warning_Name")
            txtWarning_Detail.Text = Obj_P3M.Item(0).Warning_Detail

            Dim Obj_Approve1 As DataSet = GET_APPRAISAL_APPROVAL(Obj_P3M.Item(0).Approved1)
            lblApprove1.Text = Obj_Approve1.Tables(0).Rows(0).Item("UserAppraisal")
            Dim Obj_Position1 As DataSet = GET_POSITION_INFO(Obj_P3M.Item(0).Position_Approved1)
            lblPos_Approve1.Text = Obj_Position1.Tables(0).Rows(0).Item("POSITION_NAME")


            If HiddenField_ApproveId.Value = Obj_P3M.Item(0).Approved1 Then
                'ButtonConfirm1.Visible = True
                'ButtonConfirm2.Visible = False
                'ButtonConfirm3.Visible = False
                Dim Check_Approve As List(Of Wait_For_Approve) = GET_CHECK_APPROVED(hdfReq_Id.Value, hdfHub_Id.Value, HiddenField_ApproveId.Value)
                If Check_Approve.Item(0).Chk_Approve = 1 Then
                    'ButtonConfirm1.Visible = False
                Else
                    ImageButtonApproved1.Visible = False
                End If

                ImageButtonApproved2.Visible = False
                ImageButtonApproved3.Visible = False

            End If
            'แสดงรูปว่ายืนยันแล้วคนที่ 1
            Dim Obj_approve_check1 As DataSet = GET_WAIT_FOR_APPROVE_CHECK(hdfReq_Id.Value, hdfHub_Id.Value, Obj_P3M.Item(0).Approved1)
            If Obj_approve_check1.Tables(0).Rows(0).Item("Chk_Approve") = 1 Then
                ImageButtonApproved1.Visible = True
            Else
                ImageButtonApproved1.Visible = False
            End If

            Dim Obj_Approve2 As DataSet = GET_APPRAISAL_APPROVAL(Obj_P3M.Item(0).Approved2)
            lblApprove2.Text = Obj_Approve2.Tables(0).Rows(0).Item("UserAppraisal")
            Dim Obj_Position2 As DataSet = GET_POSITION_INFO(Obj_P3M.Item(0).Position_Approved2)
            lblPos_Approve2.Text = Obj_Position1.Tables(0).Rows(0).Item("POSITION_NAME")
            If HiddenField_ApproveId.Value = Obj_P3M.Item(0).Approved2 Then
                'ButtonConfirm1.Visible = False
                'ButtonConfirm2.Visible = True
                'ButtonConfirm3.Visible = False
                Dim Check_Approve2 As List(Of Wait_For_Approve) = GET_CHECK_APPROVED(hdfReq_Id.Value, hdfHub_Id.Value, HiddenField_ApproveId.Value)
                If Check_Approve2.Item(0).Chk_Approve = 1 Then
                    'ButtonConfirm2.Visible = False
                Else
                    ImageButtonApproved2.Visible = False
                End If
                'ImageButtonApproved1.Visible = False
                'ImageButtonApproved3.Visible = False
            End If
            'แสดงรูปว่ายืนยันแล้วคนที่ 2
            Dim Obj_approve_check2 As DataSet = GET_WAIT_FOR_APPROVE_CHECK(hdfReq_Id.Value, hdfHub_Id.Value, Obj_P3M.Item(0).Approved2)
            If Obj_approve_check2.Tables(0).Rows(0).Item("Chk_Approve") > 0 Then
                ImageButtonApproved2.Visible = True
            Else
                ImageButtonApproved2.Visible = False
            End If

            Dim Obj_Approve3 As DataSet = GET_APPRAISAL_APPROVAL(Obj_P3M.Item(0).Approved3)
            lblApprove3.Text = Obj_Approve3.Tables(0).Rows(0).Item("UserAppraisal")
            Dim Obj_Position3 As DataSet = GET_POSITION_INFO(Obj_P3M.Item(0).Position_Approved3)
            lblPos_Approve3.Text = Obj_Position1.Tables(0).Rows(0).Item("POSITION_NAME")
            If HiddenField_ApproveId.Value = Obj_P3M.Item(0).Approved3 Then
                'ButtonConfirm1.Visible = False
                'ButtonConfirm2.Visible = False
                'ButtonConfirm3.Visible = True
                Dim Check_Approve As List(Of Wait_For_Approve) = GET_CHECK_APPROVED(hdfReq_Id.Value, hdfHub_Id.Value, HiddenField_ApproveId.Value)
                If Check_Approve.Item(0).Chk_Approve = 1 Then
                    'ButtonConfirm3.Visible = False
                Else
                    ImageButtonApproved3.Visible = False
                End If
                'ImageButtonApproved1.Visible = False
                'ImageButtonApproved2.Visible = False
            End If
            'แสดงรูปว่ายืนยันแล้วคนที่ 3
            Dim Obj_approve_check3 As DataSet = GET_WAIT_FOR_APPROVE_CHECK(hdfReq_Id.Value, hdfHub_Id.Value, Obj_P3M.Item(0).Approved3)
            If Obj_approve_check3.Tables(0).Rows(0).Item("Chk_Approve") > 0 Then
                ImageButtonApproved3.Visible = True
            Else
                ImageButtonApproved3.Visible = False
            End If
        Else
            'มีการกำหนดราคาที่ 3 แล้ว แสดงชื่อลูกค้า
            'Dim Obj_Cif As List(Of Appraisal_Request) = GET_APPRAISAL_REQUEST(HiddenField1.Value)
            'Dim Obj_title As List(Of Cls_Title) = GET_TITLE_INFO(Obj_Cif.Item(0).Title)
            'lblCifName.Text = Obj_title.Item(0).TITLE_NAME & Obj_Cif.Item(0).Name & "  " & Obj_Cif.Item(0).Lastname
        End If


    End Sub

    <System.Web.Script.Services.ScriptMethod()> _
<System.Web.Services.WebMethod()> _
Public Shared Function ConfirmPrice(ByVal ReqId As Integer, ByVal HubId As Integer, ByVal AppraisalId As String) As Boolean
        ' simulate a longer operation ... 
        System.Threading.Thread.Sleep(1000)

        Dim isValid As Boolean = False

        Try
            UPDATE_PRICE2_APPROVED(ReqId, HubId, AppraisalId)
            UPDATE_APPROVE_ID_WAIT_FOR_APPROVE(ReqId, HubId, AppraisalId)
            isValid = True
        Catch
            isValid = False
        End Try
        Return isValid

    End Function

    <System.Web.Script.Services.ScriptMethod()> _
<System.Web.Services.WebMethod()> _
Public Shared Function ConfirmPriceCommittee(ByVal ReqId As Integer, ByVal HubId As Integer, ByVal AppraisalId As String) As Boolean
        ' simulate a longer operation ... 
        System.Threading.Thread.Sleep(1000)

        Dim isValid As Boolean = False

        Try
            UPDATE_APPROVE_ID_WAIT_FOR_APPROVE(ReqId, HubId, AppraisalId)
            isValid = True
        Catch
            isValid = False
        End Try
        Return isValid

    End Function


End Class
