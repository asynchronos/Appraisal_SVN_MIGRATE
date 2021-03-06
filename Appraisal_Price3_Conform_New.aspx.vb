Imports Appraisal_Manager
Imports System.Data
Imports System.Data.SqlClient
Imports ThaiBaht
Imports SME_SERVICE
Imports System.Math

Partial Class Appraisal_Price3_Conform_New
    Inherits System.Web.UI.Page
    Dim cus_class As Customer_Class
    Dim SV As New SME_SERVICE.Service
    Dim Cnt_P3M As Object
    Dim StrPath As String
    Dim S1 As String
    Dim Obligation As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            lblYear.Text = Year(Now)
            HiddenField1.Value = Context.Items("Req_Id")
            HiddenField2.Value = Context.Items("Hub_Id")
            HiddenField3.Value = Context.Items("Temp_AID")
            txtCif.Text = Context.Items("Cif")
            hdfChkColl.Value = Context.Items("ChkColl")
            ddlUserAppraisal.SelectedValue = Context.Items("Appraisal_Id")
            Dim ar As List(Of Appraisal_Request_v2) = GET_APPRAISAL_REQUEST_V2(HiddenField1.Value)
            If ar.Count > 0 Then
                ddlBranch.SelectedValue = ar.Item(0).Branch_Id
            End If

            Dim P2Master As List(Of Price2_Master) = GET_PRICE2_MASTER(HiddenField1.Value, HiddenField2.Value)
            If P2Master.Count > 0 Then
                'Dim xx As String = P2Master.Item(0).Comment

                ddlAppraisal_Type.SelectedValue = P2Master.Item(0).Appraisal_Type
                If P2Master.Item(0).Approve2_Id = "" Or IsDBNull(P2Master.Item(0).Approve2_Id) Then
                    ddlApprove1.SelectedValue = 0
                Else
                    ddlApprove1.SelectedValue = P2Master.Item(0).Approve2_Id
                End If

                ViewState("Comment") = P2Master.Item(0).Comment
            End If
            If hdfChkColl.Value = 18 Then
                'คอนโดอย่างเดียว
                Show_Price3_Master(P2Master.Item(0).Appraisal_Type)
                Show_Price3_18()
            ElseIf hdfChkColl.Value = 50 Then
                'ที่ดินอย่างเดียว
                Show_Price3_Master(P2Master.Item(0).Appraisal_Type)
                Show_Price3_50()
            ElseIf hdfChkColl.Value = 70 Then
                'มีทั้งที่ดินและสิ่งปลูกสร้าง
                Show_Price3_Master(P2Master.Item(0).Appraisal_Type)
                Show_Price3_50()
                Show_Price3_70_GROUP()
                GET_PRICE2_DATA()
                'Show_Price3_70_Group_Parttake()
            Else
                'ไม่มีชนิดหลักประกันที่จะหาข้อมูล
            End If

            Try
                If txtGrandTotal.Text >= 10000000 Then
                    ddlApprove1.Enabled = True
                Else
                    ddlApprove1.Enabled = True
                End If
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

    Private Sub Show_Price3_Master(ByVal Appraisal_Type As Integer)
        Dim Obj_P3M As List(Of clsPrice3_Master) = GET_PRICE3_MASTER(HiddenField1.Value, HiddenField3.Value)
        Cnt_P3M = Obj_P3M.Count
        'ค้นหาว่ามีการกำหนดราคาที่ 3 แล้วหรือไม่
        If Obj_P3M.Count > 0 Then
            'มีการกำหนดราคาที่ 3 แล้ว

            txtAID.Text = Obj_P3M.Item(0).AID
            txtInform_To.Text = Obj_P3M.Item(0).Inform_To
            txtCif.Text = Obj_P3M.Item(0).Cif
            Try
                cus_class = SV.GetCifInfo(txtCif.Text)(0)
            Catch ex As Exception

            End Try

            Dim Obj_Cif As List(Of Appraisal_Request) = GET_APPRAISAL_REQUEST(HiddenField1.Value)
            Dim Obj_title As List(Of Cls_Title) = GET_TITLE_INFO(Obj_Cif.Item(0).Title)
            lblCifName.Text = Obj_title.Item(0).TITLE_NAME & Obj_Cif.Item(0).Name & "  " & Obj_Cif.Item(0).Lastname

            txtReceive_Date.Text = Obj_P3M.Item(0).Receive_Date
            lblYear.Text = Year(Obj_P3M.Item(0).Receive_Date)
            txtAppraisal_Date.Text = Obj_P3M.Item(0).Appraisal_Date
            ddlProblem.SelectedValue = Obj_P3M.Item(0).Env_Effect
            txtProblem_Detail.Text = Obj_P3M.Item(0).Env_Effect_Detail
            txtBuy_Sale_Comment.Text = Obj_P3M.Item(0).Appraisal_Detail
            ddlAppraisal_Type.SelectedValue = Obj_P3M.Item(0).Appraisal_Type_ID
            'MsgBox(Obj_P3M.Item(0).Comment_ID)
            ddlComment.SelectedValue = CInt(Obj_P3M.Item(0).Comment_ID)
            ddlWarning.SelectedValue = Obj_P3M.Item(0).Warning_ID
            txtWarning_Detail.Text = Obj_P3M.Item(0).Warning_Detail
            ddlApprove1.SelectedValue = Obj_P3M.Item(0).Approved1
            ddlPos_Approve1.SelectedValue = Obj_P3M.Item(0).Position_Approved1
            ddlApprove2.SelectedValue = Obj_P3M.Item(0).Approved2
            ddlPos_Approve2.SelectedValue = Obj_P3M.Item(0).Position_Approved2
            ddlApprove3.SelectedValue = Obj_P3M.Item(0).Approved3
            ddlPos_Approve3.SelectedValue = Obj_P3M.Item(0).Position_Approved3
            ddlUserAppraisal.SelectedValue = Obj_P3M.Item(0).Appraisal_ID
            If Obj_P3M.Item(0).Req_Dept <> 0 Then
                ddlBranch.SelectedValue = Obj_P3M.Item(0).Req_Dept
            Else
            End If
            'lblPriceWah.Text = Format(Obj_P3M.Item(0).PriceWah, "#,##0.00")
            'txtLandTotal.Text = Format(Obj_P3M.Item(0).TotalPrice, "#,##0.00")
            'txtBuildingPrice.Text = Format(Obj_P3M.Item(0).BuildingPrice, "#,##0.00")
            'txtSubTotal.Text = Format(Obj_P3M.Item(0).Land_Building_Price, "#,##0.00")
            'If Appraisal_Type = 1 Then
            '    txtGrandTotal.Text = String.Format("{0:N2}", txtSubTotal.Text)
            'Else
            '    txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtLandTotal.Text) + CDec(txtBuildingPrice.Text))
            'End If
            'txtGrandTotal.Text = String.Format("{0:N2}", (Obj_P3M.Item(0).TotalPrice + Obj_P3M.Item(0).BuildingPrice + Obj_P3M.Item(0).Land_Building_Price))
        Else
            'มีการกำหนดราคาที่ 3 แล้ว แสดงชื่อลูกค้า
            Dim Obj_Cif As List(Of Appraisal_Request) = GET_APPRAISAL_REQUEST(HiddenField1.Value)
            Dim Obj_title As List(Of Cls_Title) = GET_TITLE_INFO(Obj_Cif.Item(0).Title)
            lblCifName.Text = Obj_title.Item(0).TITLE_NAME & Obj_Cif.Item(0).Name & "  " & Obj_Cif.Item(0).Lastname
        End If
    End Sub

    Private Sub Show_Price3_18()
        Dim Obj_GetP18 As List(Of Price3_18) = GET_PRICE3_18(HiddenField1.Value, HiddenField2.Value, HiddenField3.Value)
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
            lblDetail2.Text = Replace(Space(5), " ", "&nbsp;") & "ชื่ออาคารชุด" & Replace(Space(5), " ", "&nbsp;") & Obj_GetP18.Item(0).Building_Name & Replace(Space(5), " ", "&nbsp;") & "ทะเบียนอาคารชุดเลขที่     " & Replace(Space(5), " ", "&nbsp;") & Obj_GetP18.Item(0).Building_Reg_No
            lblDetail3.Text = Replace(Space(5), " ", "&nbsp;") & "ตำแหน่งที่ตั้ง  ตำบล" & Replace(Space(5), " ", "&nbsp;") & Obj_GetP18.Item(0).Tumbon & Replace(Space(5), " ", "&nbsp;") & "อำเภอ" & Replace(Space(5), " ", "&nbsp;") & Obj_GetP18.Item(0).Amphur & "จังหวัด" & Replace(Space(5), " ", "&nbsp;") & Obj_Provinceas.Item(0).PROV_NAME
            lblDetail5.Text = "ผู้ถือกรรมสิทธิ์ห้องชุด" & Replace(Space(5), " ", "&nbsp;") & Obj_GetP18.Item(0).Ownership & Replace(Space(5), " ", "&nbsp;") & "ภาระผูกพัน" & Replace(Space(5), " ", "&nbsp;") & Obj_GetP18.Item(0).Obligation

            '-----------------------------------------------------
            Dim Obj_RoadAccess_Detail As List(Of Cls_Road_Detail) = GET_ROAD_DETAIL_INFO(Obj_GetP18.Item(0).Road_Detail)
            Dim Obj_Binifit As List(Of Cls_BINIFIT) = GET_BINIFIT_INFO(Obj_GetP18.Item(0).Binifit)
            Dim Obj_Road_Forntoff As List(Of Cls_RoadFrontOff) = GET_ROADFRONTOFF_INFO(Obj_GetP18.Item(0).Road_Frontoff)
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


            lblLandDetail1.Text = Replace(Space(5), " ", "&nbsp;") & "อาคารชุด ตั้งอยู่ที่ถนน  " & Obj_GetP18.Item(0).Road & "   " & Obj_RoadAccess_Detail.Item(0).Road_Detail_Name & "  ระยะประมาณ " & Obj_GetP18.Item(0).Road_Access & " เมตร "
            lblLandDetail2.Text = Replace(Space(5), " ", "&nbsp;") & "ถนนหน้าหลักประกัน  " & Replace(Space(5), " ", "&nbsp;") & Obj_Road_Forntoff.Item(0).Road_Frontoff_Name & Replace(Space(5), " ", "&nbsp;") & " กว้าง " & Replace(Space(5), " ", "&nbsp;") & Obj_GetP18.Item(0).RoadWidth & Replace(Space(5), " ", "&nbsp;") & " เมตร (รายละเอียดตามรูปแผนที่สังเขป)"
            lblLandDetail3.Text = Replace(Space(5), " ", "&nbsp;") & "สภาพลักษณะรูปห้องชุด  " & Replace(Space(5), " ", "&nbsp;") & Obj_Character_Room.Tables(0).Rows(0).Item("CHARACTER_ROOM_NAME")
            lblLandDetail4.Text = Replace(Space(5), " ", "&nbsp;") & "ขนาดห้องชุด กว้างติดทางเดิน  " & Replace(Space(5), " ", "&nbsp;") & Obj_GetP18.Item(0).RoomWidth_BehideSiteWalk & Replace(Space(5), " ", "&nbsp;") & " เมตร" & Replace(Space(5), " ", "&nbsp;") & " ลึก " & Replace(Space(5), " ", "&nbsp;") & Obj_GetP18.Item(0).Roomdeep & " เมตร  " & Replace(Space(5), " ", "&nbsp;") & " ด้านหลัง  " & Replace(Space(5), " ", "&nbsp;") & Replace(Space(5), " ", "&nbsp;") & Obj_GetP18.Item(0).Backside_Width & Replace(Space(5), " ", "&nbsp;") & " เมตร "
            lblLandDetail5.Text = Replace(Space(5), " ", "&nbsp;") & "สภาพทางเดินในอาคารชุด  " & Obj_SiteWalkIs.Item(0).Floor_Name
            lblLandDetail6.Text = Replace(Space(5), " ", "&nbsp;") & "ทำเลใกล้เคียงอาคารชุด  " & Replace(Space(5), " ", "&nbsp;") & Obj_Binifit.Item(0).Binifit_Name
            lblLandDetail7.Text = Replace(Space(5), " ", "&nbsp;") & "สาธารณูปโภค  " & Obj_Public_Utility.Item(0).Public_Utility_Name & Replace(Space(5), " ", "&nbsp;") & "สิ่งอำนวยความสะดวก" & Replace(Space(5), " ", "&nbsp;") & other & Replace(Space(5), " ", "&nbsp;") & "แนวโน้มความเจริญ   " & Obj_TENDENCY.Item(0).Tendency_Name
            lblLandDetail8.Text = Replace(Space(5), " ", "&nbsp;") & "สภาพการซื้อขาย  " & Obj_BuySale_State.Item(0).BuySale_State_Name
            lblLandDetail9.Text = Replace(Space(5), " ", "&nbsp;") & "เขตการปกครอง   แขวง/ตำบล" & Replace(Space(5), " ", "&nbsp;") & Obj_GetP18.Item(0).Tumbon1 & Replace(Space(5), " ", "&nbsp;") & "อำเภอ" & Replace(Space(5), " ", "&nbsp;") & Obj_GetP18.Item(0).Amphur1 & Replace(Space(5), " ", "&nbsp;") & "จังหวัด" & Replace(Space(5), " ", "&nbsp;") & Obj_Provinceas.Item(0).PROV_NAME
            lblLandDetail10.Text = Replace(Space(5), " ", "&nbsp;") & "สภาพการตกแต่ง" & Replace(Space(5), " ", "&nbsp;") & Obj_Interior.Item(0).InteriorState_Name
            lblLandDetail11.Text = Replace(Space(5), " ", "&nbsp;") & "สภาพการปรับปรุงห้องชุด" & Replace(Space(5), " ", "&nbsp;") & Obj_GetP18.Item(0).Adjust_Condo
            lblSize.Text = Replace(Space(5), " ", "&nbsp;") & Obj_GetP18.Item(0).Address_No
            lblPriceWah.Text = String.Format("{0:N2}", Obj_GetP18.Item(0).Unit_Price)
            'txtLandTotal.Text = String.Format("{0:N2}", Obj_GetP18.Item(0).PriceTotal)
            txtLandTotal.Text = String.Format("{0:N2}", Round(CDec(Obj_GetP18.Item(0).PriceTotal) / 1000, System.MidpointRounding.AwayFromZero) * 1000)
            txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtLandTotal.Text))
            '--------------------------------------------------------
            Dim add As String = String.Empty
            Dim area As Double = 0
            For i = 0 To Obj_GetP18.Count - 1
                If i = 1 Then
                    lblBuilding_Detail.Text = Replace(Space(5), " ", "&nbsp;") & Obj_GetP18.Item(i).Address_No
                    lblUnit_Price_Condo.Text = String.Format("{0:N2}", Obj_GetP18.Item(i).Unit_Price) & " บาท"
                    txtBuildingPrice.Text = String.Format("{0:N2}", Round(CDec(Obj_GetP18.Item(i).PriceTotal) / 1000, System.MidpointRounding.AwayFromZero) * 1000)
                    'txtBuildingPrice.Text = String.Format("{0:N2}", Round(Obj_GetP18.Item(i).PriceTotal) / 1000, System.MidpointRounding.AwayFromZero) * 1000
                ElseIf i = 2 Then
                    lblBuilding_Detail.Text = Replace(Space(5), " ", "&nbsp;") & Obj_GetP18.Item(i).Address_No
                    lblTotal3.Text = String.Format("{0:N2}", Obj_GetP18.Item(i).Unit_Price)
                    txtSubTotal.Text = String.Format("{0:N2}", Round(CDec(Obj_GetP18.Item(i).PriceTotal) / 1000, System.MidpointRounding.AwayFromZero) * 1000)
                    'txtBuildingPrice.Text = String.Format("{0:N2}", Round(Obj_GetP18.Item(i).PriceTotal) / 1000, System.MidpointRounding.AwayFromZero) * 1000
                Else
                    'รวมแล้วนำไปไว้ที่บรรทัดบนสุด
                End If
                add += Obj_GetP18.Item(i).Address_No & Replace(Space(5), " ", "&nbsp;")
                area += Obj_GetP18.Item(i).Room_Area
            Next
            lblDetail1.Text = Replace(Space(3), " ", "&nbsp;") & "หนังสือกรรมสิทธิ์ห้องชุดเลขที่ " & Replace(Space(3), " ", "&nbsp;") & add.ToString & Replace(Space(3), " ", "&nbsp;") & "ชั้นที่  " & Replace(Space(3), " ", "&nbsp;") & Obj_GetP18.Item(0).Floors & Replace(Space(3), " ", "&nbsp;") & "อาคารเลขที่" & Replace(Space(3), " ", "&nbsp;") & Obj_GetP18.Item(0).Building_No
            lblDetail4.Text = Replace(Space(3), " ", "&nbsp;") & "เนื้อที่ห้องชุด" & Replace(Space(3), " ", "&nbsp;") & area & Replace(Space(3), " ", "&nbsp;") & "ตารางเมตร" & Replace(Space(3), " ", "&nbsp;") & "สูง" & Replace(Space(3), " ", "&nbsp;") & Obj_GetP18.Item(0).Room_Height & Replace(Space(3), " ", "&nbsp;") & "เมตร" & Obj_GetP18.Item(0).Other_Detail & Replace(Space(3), " ", "&nbsp;") & "ทรัพย์สินส่วนบุคคลภายนอกห้องชุด" & Replace(Space(3), " ", "&nbsp;") & Obj_GetP18.Item(0).Partake_Detail
            txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtLandTotal.Text) + CDec(txtBuildingPrice.Text) + CDec(txtSubTotal.Text))
        End If
    End Sub

    Private Sub Show_Price3_50()
        Dim SumP3 As DataSet = GET_SUM_PRICE3_50(HiddenField1.Value, HiddenField2.Value, HiddenField3.Value)
        Dim Obj_GetP50 As List(Of Price3_50) = GET_PRICE3_CONFORM(HiddenField1.Value, HiddenField2.Value, HiddenField3.Value)
        If Obj_GetP50.Count > 0 Then
            'มีชิ้นทรัพย์ที่เป็นที่ดิน
            If Obj_GetP50.Count = 1 Then 'ถ้ามีที่ดิน 1 ชิ้น
                Dim Osubtype As List(Of Cls_SubCollType) = GET_SUBCOLLTYPE(Obj_GetP50.Item(0).MysubColl_ID)
                lblDetail1.Text = Replace(Space(10), " ", "&nbsp;") & Osubtype.Item(0).SubCollType_Name & " เลขที่" & Replace(Space(5), " ", "&nbsp;") & Obj_GetP50.Item(0).Address_No & Replace(Space(3), " ", "&nbsp;") & "ระวาง" & Replace(Space(3), " ", "&nbsp;") & Obj_GetP50.Item(0).Rawang & Replace(Space(3), " ", "&nbsp;") & "เลขที่ดิน" & Replace(Space(3), " ", "&nbsp;") & Obj_GetP50.Item(0).LandNumber
                lblDetail2.Text = Replace(Space(10), " ", "&nbsp;") & "หน้าสำรวจ " & Replace(Space(5), " ", "&nbsp;") & Obj_GetP50.Item(0).Surway & Replace(Space(5), " ", "&nbsp;") & "สารบัญ เล่มที่" & Obj_GetP50.Item(0).DocNo & Replace(Space(5), " ", "&nbsp;") & "หน้า" & Obj_GetP50.Item(0).PageNo
                Dim Obj_Provinceas As List(Of Cls_PROVINCE) = GET_PROVINCE_INFO(Obj_GetP50.Item(0).Province)
                Obligation = Obj_GetP50.Item(0).Obligation
                lblDetail3.Text = Replace(Space(10), " ", "&nbsp;") & "ตำบล" & Replace(Space(5), " ", "&nbsp;") & Obj_GetP50.Item(0).Tumbon & Replace(Space(5), " ", "&nbsp;") & "อำเภอ" & Replace(Space(5), " ", "&nbsp;") & Obj_GetP50.Item(0).Amphur & Replace(Space(5), " ", "&nbsp;") & "จังหวัด" & Replace(Space(5), " ", "&nbsp;") & Obj_Provinceas.Item(0).PROV_NAME & Replace(Space(5), " ", "&nbsp;") & "เนื้อที่" & Replace(Space(5), " ", "&nbsp;") & Obj_GetP50.Item(0).Rai & " ไร่  " & Obj_GetP50.Item(0).Ngan & Replace(Space(5), " ", "&nbsp;") & "งาน " & Obj_GetP50.Item(0).Wah & " วา"
                lblDetail4.Text = Replace(Space(10), " ", "&nbsp;") & "ผู้ถือกรรมสิทธิ์ที่ดิน  " & Replace(Space(5), " ", "&nbsp;") & Obj_GetP50.Item(0).Ownership & Replace(Space(5), " ", "&nbsp;")
                'ตรวจสอบราคาของราคา Price 3 Master ที่จะแสดง
                If CInt(Cnt_P3M) = 0 Then
                    lblPriceWah.Text = Format(Obj_GetP50.Item(0).PriceWah, "#,##0.00")
                    txtLandTotal.Text = Format(Obj_GetP50.Item(0).PriceTotal1, "#,##0.00")
                    txtBuildingPrice.Text = "0.00"
                    txtSubTotal.Text = "0.00"
                    txtGrandTotal.Text = Format(Obj_GetP50.Item(0).PriceTotal1, "#,##0.00")
                Else
                    lblPriceWah.Text = Format(Obj_GetP50.Item(0).PriceWah, "#,##0.00")
                    txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtLandTotal.Text))
                End If

                lblSize.Text = Obj_GetP50.Item(0).Rai & "-" & Obj_GetP50.Item(0).Ngan & "-" & Obj_GetP50.Item(0).Wah
            Else
                'ถ้ามีที่ดินมากกว่า 1 ชิ้น
                Obligation = Obj_GetP50.Item(0).Obligation
                Dim Osubtype As List(Of Cls_SubCollType) = GET_SUBCOLLTYPE(Obj_GetP50.Item(0).MysubColl_ID)
                If Obj_GetP50.Count > 1 And Obj_GetP50.Count < 4 Then
                    Dim DS As DataSet = GET_PRICE3_50_GROUP(HiddenField1.Value, HiddenField2.Value, HiddenField3.Value)
                    lblDetail1.Text = Replace(Space(10), " ", "&nbsp;") & Osubtype.Item(0).SubCollType_Name & " เลขที่" & Replace(Space(5), " ", "&nbsp;") & DS.Tables(0).Rows(0).Item("Address_no") & Replace(Space(3), " ", "&nbsp;") & "ระวาง" & Replace(Space(3), " ", "&nbsp;") & DS.Tables(0).Rows(0).Item("Rawang") & Replace(Space(3), " ", "&nbsp;") & "เลขที่ดิน" & Replace(Space(3), " ", "&nbsp;") & DS.Tables(0).Rows(0).Item("LandNumber")
                    lblDetail2.Text = Replace(Space(10), " ", "&nbsp;") & "หน้าสำรวจ " & Replace(Space(5), " ", "&nbsp;") & DS.Tables(0).Rows(0).Item("Surway")
                Else
                    lblDetail1.Text = Replace(Space(10), " ", "&nbsp;") & Osubtype.Item(0).SubCollType_Name & " เลขที่" & Replace(Space(5), " ", "&nbsp;") & "ตามเอกสารแนบ" & Replace(Space(3), " ", "&nbsp;") & "ระวาง" & Replace(Space(3), " ", "&nbsp;") & "ตามเอกสารแนบ" & Replace(Space(3), " ", "&nbsp;") & "เลขที่ดิน" & Replace(Space(3), " ", "&nbsp;") & "ตามเอกสารแนบ"
                    lblDetail2.Text = Replace(Space(10), " ", "&nbsp;") & "หน้าสำรวจ " & Replace(Space(5), " ", "&nbsp;") & "ตามเอกสารแนบ"
                End If

                Dim Obj_Provinceas As List(Of Cls_PROVINCE) = GET_PROVINCE_INFO(Obj_GetP50.Item(0).Province)
                lblDetail3.Text = Replace(Space(10), " ", "&nbsp;") & "ตำบล" & Replace(Space(5), " ", "&nbsp;") & Obj_GetP50.Item(0).Tumbon & Replace(Space(5), " ", "&nbsp;") & "อำเภอ" & Replace(Space(5), " ", "&nbsp;") & Obj_GetP50.Item(0).Amphur & Replace(Space(5), " ", "&nbsp;") & "จังหวัด" & Replace(Space(5), " ", "&nbsp;") & Obj_Provinceas.Item(0).PROV_NAME
                lblDetail4.Text = Replace(Space(10), " ", "&nbsp;") & "ผู้ถือกรรมสิทธิ์ที่ดิน  " & Replace(Space(5), " ", "&nbsp;") & Obj_GetP50.Item(0).Ownership & Replace(Space(5), " ", "&nbsp;")
                txtLandTotal.Text = Format(SumP3.Tables(0).Rows(0).Item("PriceTotal1"), "#,##0.00")
                If SumP3.Tables(0).Rows(0).Item("TotalWah") <= 100 Then
                    lblSize.Text = "0" & "-" & "0" & "-" & SumP3.Tables(0).Rows(0).Item("TotalWah")
                Else
                    lblSize.Text = SumP3.Tables(0).Rows(0).Item("Rai") & "-" & SumP3.Tables(0).Rows(0).Item("Ngan") & "-" & SumP3.Tables(0).Rows(0).Item("Wah")
                End If
                'lblSize.Text = SumP3.Tables(0).Rows(0).Item("Rai") & "-" & SumP3.Tables(0).Rows(0).Item("Ngan") & "-" & SumP3.Tables(0).Rows(0).Item("Wah")
                lblPriceWah.Text = Obj_GetP50.Item(0).PriceWah  '"0.00"
                txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtLandTotal.Text))
            End If

            'ใช้ข้อมูลด้วยกัน ถึงแม้จะมีที่ดินกี่ชิ้น
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
            lblLandDetail2.Text = Replace(Space(10), " ", "&nbsp;") & "ถนนหน้าหลักประกัน  " & Replace(Space(5), " ", "&nbsp;") & Obj_Road_Forntoff.Item(0).Road_Frontoff_Name & Replace(Space(5), " ", "&nbsp;") & Replace(Space(5), " ", "&nbsp;") & "กว้าง" & Obj_GetP50.Item(0).RoadWidth & Replace(Space(5), " ", "&nbsp;") & " เมตร (รายละเอียดตามรูปแผนที่สังเขป)"
            lblLandDetail3.Text = Replace(Space(10), " ", "&nbsp;") & "สภาพลักษณะรูปที่ดิน  " & Replace(Space(5), " ", "&nbsp;") & Obj_GetP50.Item(0).Binifit_Detail
            'lblLandDetail4.Text = Replace(Space(10), " ", "&nbsp;") & "ขนาดที่ดิน กว้างติดถนน " & Replace(Space(5), " ", "&nbsp;") & Replace(Space(5), " ", "&nbsp;") & Obj_GetP50.Item(0).Land_Closeto_RoadWidth & Replace(Space(5), " ", "&nbsp;") & " เมตร  " & Replace(Space(5), " ", "&nbsp;") & " ลึกซ้าย/ขวา  " & Replace(Space(5), " ", "&nbsp;") & Obj_GetP50.Item(0).DeepWidth & Replace(Space(5), " ", "&nbsp;") & " เมตร  " & Replace(Space(5), " ", "&nbsp;") & " ด้านหลัง  " & Obj_GetP50.Item(0).BehindWidth & " เมตร "
            lblLandDetail4.Text = Replace(Space(10), " ", "&nbsp;") & "ขนาดที่ดิน กว้างติดถนน " & Replace(Space(5), " ", "&nbsp;") & Replace(Space(5), " ", "&nbsp;") & SumP3.Tables(0).Rows(0).Item("Land_Closeto_RoadWidth") & Replace(Space(5), " ", "&nbsp;") & " เมตร  " & Replace(Space(5), " ", "&nbsp;") & " ลึก  " & Replace(Space(5), " ", "&nbsp;") & Obj_GetP50.Item(0).DeepWidth & Replace(Space(5), " ", "&nbsp;") & " เมตร  " & Replace(Space(5), " ", "&nbsp;") & " ด้านหลัง  " & SumP3.Tables(0).Rows(0).Item("BehindWidth") & " เมตร "
            lblLandDetail5.Text = Replace(Space(10), " ", "&nbsp;") & "สภาพและการปรับปรุงระดับของที่ดินกับถนน  " & Replace(Space(5), " ", "&nbsp;") & Obj_Land_State.Item(0).Land_State_Name & Replace(Space(5), " ", "&nbsp;") & Obj_GetP50.Item(0).Land_State_Detail & Replace(Space(5), " ", "&nbsp;") & " ทำเล  " & Replace(Space(5), " ", "&nbsp;") & Obj_Site.Item(0).Site_Name
            lblLandDetail6.Text = Replace(Space(10), " ", "&nbsp;") & "ผังเมืองรวม   ที่ดินอยู่ในเขตพื้นที่สี  " & Replace(Space(5), " ", "&nbsp;") & Obj_AreaColour.Item(0).AreaColour_Name
            lblLandDetail7.Text = Replace(Space(10), " ", "&nbsp;") & "สาธารณูปโภค  " & Replace(Space(5), " ", "&nbsp;") & Obj_Public_Utility.Item(0).Public_Utility_Name & Replace(Space(5), " ", "&nbsp;") & Obj_GetP50.Item(0).Public_Utility_Detail & Replace(Space(5), " ", "&nbsp;") & "แนวโน้มความเจริญ" & Replace(Space(5), " ", "&nbsp;") & Obj_TENDENCY.Item(0).Tendency_Name
            lblLandDetail8.Text = Replace(Space(10), " ", "&nbsp;") & "สภาพการซื้อขาย " & Replace(Space(5), " ", "&nbsp;") & Obj_BuySale_State.Item(0).BuySale_State_Name

            lblSubUnit.Text = Obj_SubUnit.Item(0).SubUnit_Name

        End If
    End Sub

    Private Sub Show_Price3_70_GROUP()
        Dim Obj_GetP70G As DataSet = GET_PRICE3_70_GROUP_V1(HiddenField1.Value, HiddenField2.Value, HiddenField3.Value)
        Dim Cnt As Integer = GET_BUILDING_ITEMS_PRICE2(HiddenField1.Value, HiddenField2.Value)

        If Obj_GetP70G.Tables(0).Rows.Count > 0 Then
            'If Obj_GetP70G.Tables(0).Rows.Count = 1 Then
            If Cnt = 0 Then
                lblLandDetail9.Text = ""
            ElseIf Cnt = 1 Then
                lblDetail4.Text = lblDetail4.Text & "สิ่งปลูกสร้างของ" & Replace(Space(5), " ", "&nbsp;") & Obj_GetP70G.Tables(0).Rows(0).Item("Ownership") & Replace(Space(5), " ", "&nbsp;") & "ภาระผูกพัน" & Replace(Space(5), " ", "&nbsp;") & Obligation
                lblLandDetail9.Text = "สิ่งปลูกสร้างเลขที่  " & Obj_GetP70G.Tables(0).Rows(0).Item("Build_No") & " รวมจำนวน  " & Cnt & " รายการ (ตามรายละเอียดสิ่งปลูกสร้างแนบ)"
            Else
                lblLandDetail9.Text = "สิ่งปลูกสร้างจำนวน  " & Cnt & " รายการ ตามรายละเอียดเอกสารสิ่งปลูกสร้างแนบ "
            End If
            lblBuilding_Detail.Text = "จำนวน  " & Cnt & " รายการ"
            'lblTotal2.Text = Format(CDec(Obj_GetP70G.Tables(0).Rows(0).Item("UnitPrice").ToString), "#,##0.00")
            'lblItem.Text = Obj_GetP70G.Tables(0).Rows(0).Item("Item").ToString()
            Dim P2Master As List(Of Price2_Master) = GET_PRICE2_MASTER(HiddenField1.Value, HiddenField2.Value)
            'ตรวจสอบราคาของราคา Price 3 Master ที่จะแสดง
            If CInt(Cnt_P3M) = 0 Then
                'txtBuildingPrice.Text = String.Format("{0:N2}", ((Obj_GetP70G.Tables(0).Rows(0).Item("Deteriorate"))))
                'txtBuildingPrice.Text = String.Format("{0:N2}", ((Obj_GetP70G.Tables(0).Rows(0).Item("BuildingPrice"))))
                If P2Master.Item(0).Appraisal_Type = 1 Then
                    'วิธีตลาด
                    'txtBuildingPrice.Text = String.Format("{0:N2}", ((Obj_GetP70G.Tables(0).Rows(0).Item("Deteriorate"))))
                    txtBuildingPrice.Text = String.Format("{0:N2}", ((Obj_GetP70G.Tables(0).Rows(0).Item("PriceTotal1"))))
                    txtSubTotal.Text = String.Format("{0:N2}", ((Obj_GetP70G.Tables(0).Rows(0).Item("PriceMarket"))))
                    txtSubTotal.Text = String.Format("{0:N2}", CDec(txtSubTotal.Text))
                    txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtSubTotal.Text))
                Else
                    'วิธีทุน
                    txtBuildingPrice.Text = String.Format("{0:N2}", ((Obj_GetP70G.Tables(0).Rows(0).Item("PriceTotal1"))))
                    txtSubTotal.Text = "0.00"
                    txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtLandTotal.Text) + CDec(txtBuildingPrice.Text))
                    'txtSubTotal.Text = String.Format("{0:N2}", CDec(txtLandTotal.Text) + CDec(txtBuildingPrice.Text)) 'String.Format("{0:N2}", Obj_GetP70G.Tables(0).Rows(0).Item("Deteriorate"))
                End If
                'txtGrandTotal.Text = String.Format("{0:N2}", Round(CDec(txtSubTotal.Text), System.MidpointRounding.AwayFromZero))
                'txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtLandTotal.Text) + CDec(txtBuildingPrice.Text))
            Else

                If P2Master.Item(0).Appraisal_Type = 1 Then
                    'วิธีตลาด
                    'txtBuildingPrice.Text = String.Format("{0:N2}", ((Obj_GetP70G.Tables(0).Rows(0).Item("Deteriorate"))))
                    'txtSubTotal.Text = String.Format("{0:N2}", CDec(txtBuildingPrice.Text))
                    txtBuildingPrice.Text = String.Format("{0:N2}", ((Obj_GetP70G.Tables(0).Rows(0).Item("PriceTotal1"))))
                    'txtBuildingPrice.Text = String.Format("{0:N2}", ((Obj_GetP70G.Tables(0).Rows(0).Item("PriceMarket"))))
                    'txtSubTotal.Text = String.Format("{0:N2}", CDec(Obj_GetP70G.Tables(0).Rows(0).Item("PriceMarket")))
                    'txtGrandTotal.Text = String.Format("{0:N2}", Round(CDec(txtSubTotal.Text), System.MidpointRounding.AwayFromZero))
                    'txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtSubTotal.Text))
                Else
                    'วิธีทุน
                    'txtBuildingPrice.Text = String.Format("{0:N2}", ((Obj_GetP70G.Tables(0).Rows(0).Item("Deteriorate"))))
                    txtBuildingPrice.Text = String.Format("{0:N2}", ((Obj_GetP70G.Tables(0).Rows(0).Item("PriceTotal1"))))
                    'txtSubTotal.Text = String.Format("{0:N2}", CDec(txtLandTotal.Text) + CDec(txtBuildingPrice.Text)) 'String.Format("{0:N2}", Obj_GetP70G.Tables(0).Rows(0).Item("Deteriorate"))
                    txtSubTotal.Text = "0.00"
                    'txtGrandTotal.Text = String.Format("{0:N2}", Round(CDec(txtLandTotal.Text) + CDec(txtBuildingPrice.Text), System.MidpointRounding.AwayFromZero))
                    txtGrandTotal.Text = String.Format("{0:N2}", Round(CDec(txtLandTotal.Text) + CDec(txtBuildingPrice.Text)))
                End If

            End If

        Else

        End If
    End Sub

    Private Sub Show_Price3_70_Group_Parttake()

        Dim Obj_P3_Grp_Partake As DataSet = GET_PRICE3_70_GROUP_PARTAKE(HiddenField1.Value, HiddenField2.Value, HiddenField3.Value)
        If Obj_P3_Grp_Partake.Tables(0).Rows(0).Item("Cnt") > 0 Then

            'lblTotal2.Text = Format(CDec(Obj_P3_Grp_Partake.Tables(0).Rows(0).Item("PartakeUintPrice").ToString + CDec(lblTotal2.Text)), "#,##0.00")
            'ตรวจสอบราคาของราคา Price 3 Master ที่จะแสดง
            If CInt(Cnt_P3M) = 0 Then
                Dim P2Master As List(Of Price2_Master) = GET_PRICE2_MASTER(HiddenField1.Value, HiddenField2.Value)
                If P2Master.Item(0).Appraisal_Type = 1 Then
                    txtBuildingPrice.Text = String.Format("{0:N2}", Round(((CDec(Obj_P3_Grp_Partake.Tables(0).Rows(0).Item("Partake_Price1") + CDec(txtBuildingPrice.Text))) / 1000), System.MidpointRounding.AwayFromZero) * 1000)
                    txtSubTotal.Text = String.Format("{0:N2}", CDec(txtSubTotal.Text))
                    txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtSubTotal.Text))
                Else
                    txtBuildingPrice.Text = String.Format("{0:N2}", Round(((CDec(Obj_P3_Grp_Partake.Tables(0).Rows(0).Item("Partake_Price1") + CDec(txtBuildingPrice.Text))) / 1000), System.MidpointRounding.AwayFromZero) * 1000)
                    txtSubTotal.Text = String.Format("{0:N2}", CDec(txtBuildingPrice.Text) + CDec(txtLandTotal.Text))
                    txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtSubTotal.Text))
                End If

            Else
                txtGrandTotal.Text = String.Format("{0:N2}", Round(CDec(txtSubTotal.Text), System.MidpointRounding.AwayFromZero))
            End If
        Else
            'ไม่มีส่วนควบ

            txtBuildingPrice.Text = String.Format("{0:N2}", Round(CDec(txtBuildingPrice.Text) / 1000, System.MidpointRounding.AwayFromZero) * 1000)
            'txtBuildingPrice.Text = (Round(CDec(txtBuildingPrice.Text) / 1000, System.MidpointRounding.AwayFromZero) * 1000)
            Dim P2Master As List(Of Price2_Master) = GET_PRICE2_MASTER(HiddenField1.Value, HiddenField2.Value)
            If P2Master.Item(0).Appraisal_Type = 1 Then
                txtSubTotal.Text = String.Format("{0:N2}", CDec(txtSubTotal.Text))
                txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtSubTotal.Text))
            Else
                txtSubTotal.Text = String.Format("{0:N2}", CDec(txtLandTotal.Text) + CDec(txtBuildingPrice.Text))
                txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtLandTotal.Text) + CDec(txtBuildingPrice.Text))
            End If

        End If
    End Sub

    Protected Sub ImageSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSave.Click

        'MsgBox("Receive Date" & myDate)
        'MsgBox("Appraisal Date" & myDate2)

        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label) 'หา Control จาก Master Page ที่ control ไม่อยู่ใน  ContentPlaceHolder1 ของ Master Page
        Dim s As String
        Dim cif As Integer = 0
        Dim AID As String = "0"
        Dim Lat As Double
        Dim Lng As Double

            If txtCif.Text <> String.Empty Then
                cif = txtCif.Text
            End If
            If txtAID.Text <> String.Empty Then
                AID = txtAID.Text
            End If

            If txtInform_To.Text = String.Empty Then
                s = "<script language=""javascript"">alert('ไม่มีชื่อเจ้าของเรื่องผู้ส่งประเมิน');</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
                Exit Sub
            End If

            If txtReceive_Date.Text = String.Empty Then
                s = "<script language=""javascript"">alert('ไม่มีวันที่รับเรื่อง');</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
                Exit Sub
            End If

            If txtAppraisal_Date.Text = String.Empty Then
                s = "<script language=""javascript"">alert('ไม่มีวันที่ประเมิน');</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
                Exit Sub
            End If

            'ผฝ.ตป.SME(Lean Admin)
            If CDate(txtAppraisal_Date.Text) < CDate(txtReceive_Date.Text) Then
                s = "<script language=""javascript"">alert('วันที่ประเมินน้อยกว่าวันที่รับเรื่อง');</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
                Exit Sub
            End If

            If ddlApprove1.SelectedValue = 0 Or ddlApprove2.SelectedValue = 0 Or ddlApprove3.SelectedValue = 0 Then
                s = "<script language=""javascript"">alert('คุณเลือกอนุกรรมการไม่ครบ 3 คน');</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
                Exit Sub
            End If
            'ตรวจสอบราคาที่ 2 กับราคาที่ 2 ว่าตรงกันหรือไม่
        'Dim Obj_P2 As DataSet = GET_APPRAISAL_PRICE2(HiddenField1.Value, HiddenField2.Value) 'GET_APPRAISAL_PRICE2
        'Dim Price2 As Decimal = 0.0
        'If Obj_P2.Tables(0).Rows.Count > 0 Then
        '    If Obj_P2.Tables(0).Rows(0).Item("Appraisal_Type") = 1 Then
        '    'Price2 = String.Format("{0:N2}", Obj_P2.Tables(0).Rows(0).Item("PriceMarket"))
        '    'ตรวจสอบว่าราคาที่ให้ไว้ ณ ราคาที่ 2 นั้นเป็นหลักประกันชนิดอะไร
        '    Dim Check_Price_CollType As DataSet = GET_PRICE2_MASTER_NEW(HiddenField1.Value, HiddenField2.Value)
        '    If Check_Price_CollType.Tables(0).Rows(0).Item("Condo") > 0 Then
        '        Price2 = String.Format("{0:N2}", Obj_P2.Tables(0).Rows(0).Item("Price2"))
        '    Else
        '        Price2 = String.Format("{0:N2}", Obj_P2.Tables(0).Rows(0).Item("PriceMarket"))
        '    End If
        '    Else
        '        Price2 = String.Format("{0:N2}", Obj_P2.Tables(0).Rows(0).Item("Price2"))
        '    End If
        'Else
        '    'MsgBox("No Data")
        'End If
        'ตรวจสอบด่วนนะ เพราะ Save แล้วเกิดติด
        'If Price2 <> CDec(txtGrandTotal.Text) Then
        '    s = "<script language=""javascript"">alert('ราคาที่ 2 ไม่เท่ากับราคาที่ 3');</script>"
        '    Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
        '    Exit Sub
        'End If

            Dim Obj_GetP1Master As List(Of ClsPrice1_Master) = GetPrice1_Master(HiddenField1.Value, HiddenField2.Value)
            Dim ReceiveDate As Date = CDate(txtReceive_Date.Text)
            Dim AppraisalDate As Date = CDate(txtAppraisal_Date.Text)
            If Obj_GetP1Master.Count > 0 Then
                Lat = Obj_GetP1Master.Item(0).Lat
                Lng = Obj_GetP1Master.Item(0).Lng
                Dim Obj_P3M As List(Of clsPrice3_Master) = GET_PRICE3_MASTER(HiddenField1.Value, HiddenField3.Value)
            If Obj_P3M.Count = 0 Then  'ยังไม่มีข้อมูลในราคาที่ 3
                If lbluserid.Text = ddlUserAppraisal.SelectedValue Then 'ตรวจสอบก่อนว่าผู้แก้ไขเป็นผู้ประเมินหรือไม่ ถ้าใช่ถึงจะบันทึกได้
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
                    'UPDATE_Status_Appraisal_Request(HiddenField1.Value, HiddenField2.Value, 11)

                    If CDec(txtGrandTotal.Text) >= 10000000 Then  'ตรวจสอบว่าราคาประเมินเกิน 10 ล้านหรือไม่
                        'อนุมัติคนที่ 1
                        AddWait_For_Approve(1, HiddenField1.Value, HiddenField2.Value, txtAID.Text, HiddenField3.Value, ddlApprove1.SelectedValue, txtCif.Text, hdfChkColl.Value, ddlUserAppraisal.SelectedValue, 0, Now(), Now(), Now(), lbluserid.Text, Now())
                        'อนุมัติคนที่ 2
                        AddWait_For_Approve(2, HiddenField1.Value, HiddenField2.Value, txtAID.Text, HiddenField3.Value, ddlApprove2.SelectedValue, txtCif.Text, hdfChkColl.Value, ddlUserAppraisal.SelectedValue, 0, Now(), Now(), Now(), lbluserid.Text, Now())
                        'อนุมัติคนที่ 3
                        AddWait_For_Approve(3, HiddenField1.Value, HiddenField2.Value, txtAID.Text, HiddenField3.Value, ddlApprove3.SelectedValue, txtCif.Text, hdfChkColl.Value, ddlUserAppraisal.SelectedValue, 0, Now(), Now(), Now(), lbluserid.Text, Now())
                    Else
                        'อนุมัติคนที่ 1
                        AddWait_For_Approve(1, HiddenField1.Value, HiddenField2.Value, txtAID.Text, HiddenField3.Value, ddlApprove1.SelectedValue, txtCif.Text, hdfChkColl.Value, ddlUserAppraisal.SelectedValue, 0, Now(), Now(), Now(), lbluserid.Text, Now())
                        'อนุมัติคนที่ 2
                        AddWait_For_Approve(2, HiddenField1.Value, HiddenField2.Value, txtAID.Text, HiddenField3.Value, ddlApprove2.SelectedValue, txtCif.Text, hdfChkColl.Value, ddlUserAppraisal.SelectedValue, 0, Now(), Now(), Now(), lbluserid.Text, Now())
                        'อนุมัติคนที่ 3
                        AddWait_For_Approve(3, HiddenField1.Value, HiddenField2.Value, txtAID.Text, HiddenField3.Value, ddlApprove3.SelectedValue, txtCif.Text, hdfChkColl.Value, ddlUserAppraisal.SelectedValue, 0, Now(), Now(), Now(), lbluserid.Text, Now())
                    End If


                    s = "<script language=""javascript"">alert('บันทึกเสร็จสมบูรณ์');</script>"
                    Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
                Else
                    s = "<script language=""javascript"">alert('คุณไม่ใช่เจ้าหน้าที่ประเมินของเลขคำขอนี้ ไม่สามารถบันทึกได้');</script>"
                    Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
                End If

            Else  'มีข้อมูลแล้วต้องการแก้ไข

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
                'UPDATE_Status_Appraisal_Request(HiddenField1.Value, HiddenField2.Value, 11)

                If lbluserid.Text = ddlUserAppraisal.SelectedValue Then 'ตรวจสอบก่อนว่าผู้แก้ไขเป็นผู้ประเมินหรือไม่ ถ้าใช่ถึงจะแก้ไขอนุกรรมการได้
                    For i = 1 To 3
                        If i = 1 Then
                            'ผู้อนุมัติคนที่1 ไม่สามารถแก้ไขได้
                        ElseIf i = 2 Then
                            'แก้ไขผู้อนุมัติคนที่2 และ 3 
                            UPDATE_WAIT_FOR_APPROVE_COMMITTEE(HiddenField1.Value, HiddenField2.Value, i, txtAID.Text, HiddenField3.Value, ddlApprove2.SelectedValue, txtCif.Text, hdfChkColl.Value, ddlUserAppraisal.SelectedValue, 0, Now(), Now(), Now(), lbluserid.Text, Now())
                        ElseIf i = 3 Then
                            UPDATE_WAIT_FOR_APPROVE_COMMITTEE(HiddenField1.Value, HiddenField2.Value, i, txtAID.Text, HiddenField3.Value, ddlApprove3.SelectedValue, txtCif.Text, hdfChkColl.Value, ddlUserAppraisal.SelectedValue, 0, Now(), Now(), Now(), lbluserid.Text, Now())
                        End If
                    Next
                Else
                    UpdateWait_For_Approve(HiddenField1.Value, HiddenField2.Value, txtAID.Text, HiddenField3.Value, ddlApprove3.SelectedValue, txtCif.Text, hdfChkColl.Value, ddlUserAppraisal.SelectedValue, 0, Now(), Now(), Now(), lbluserid.Text, Now())
                End If

                s = "<script language=""javascript"">alert('บันทึกเสร็จสมบูรณ์');</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "สมบูรณ์", s)
            End If
                'Server.Transfer("Appraisal_Price3_List.aspx")
            Else
                s = "<script language=""javascript"">alert('ไม่มีเลขที่คำขอนี้ หรือ ไม่มีการกำหนด Lat Lng อยู่ในระบบ');</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "ผิดพลาด", s)
            End If
    End Sub

    Protected Sub ImagePrint_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImagePrint.Click
        'Session("ctrl") = Panel1
        'ClientScript.RegisterStartupScript(Me.GetType(), "onclick", "<script language=javascript>window.open('Testprint.aspx','PrintMe','height=768px,width=1024px,scrollbars=1');</script>")
        Dim Obj_P3M As List(Of clsPrice3_Master) = GET_PRICE3_MASTER(HiddenField1.Value, HiddenField3.Value)
        If Obj_P3M.Count > 0 Then
            Context.Items("Req_Id") = HiddenField1.Value
            Context.Items("Temp_AID") = HiddenField3.Value
            Context.Items("Inform_To") = txtInform_To.Text
            Context.Items("AID") = txtAID.Text
            Context.Items("Cif") = txtCif.Text
            Context.Items("Cif_Name") = lblCifName.Text
            Context.Items("Receive_Date") = txtReceive_Date.Text
            Context.Items("Appraisal_Date") = txtAppraisal_Date.Text
            Context.Items("Branch") = ddlBranch.SelectedItem.ToString
            Context.Items("Detail1") = lblDetail1.Text
            Context.Items("Detail2") = lblDetail2.Text
            Context.Items("Detail3") = lblDetail3.Text
            Context.Items("Detail4") = lblDetail4.Text
            Context.Items("Detail5") = lblDetail5.Text
            Context.Items("Label22") = Label22.Text
            Context.Items("lblLandDetail1") = lblLandDetail1.Text
            Context.Items("lblLandDetail2") = lblLandDetail2.Text
            Context.Items("lblLandDetail3") = lblLandDetail3.Text
            Context.Items("lblLandDetail4") = lblLandDetail4.Text
            Context.Items("lblLandDetail5") = lblLandDetail5.Text
            Context.Items("lblLandDetail6") = lblLandDetail6.Text
            Context.Items("lblLandDetail7") = lblLandDetail7.Text
            Context.Items("lblLandDetail8") = lblLandDetail8.Text
            Context.Items("lblLandDetail9") = lblLandDetail9.Text
            Context.Items("lblLandDetail10") = lblLandDetail10.Text()
            Context.Items("lblLandDetail11") = lblLandDetail11.Text()
            Context.Items("Problem") = ddlProblem.SelectedItem.ToString()
            Context.Items("Buy_Sale_Comment") = txtBuy_Sale_Comment.Text
            Context.Items("Appraisal_Type") = ddlAppraisal_Type.SelectedItem.ToString()
            Context.Items("CollName") = lblCollName.Text
            Context.Items("Size") = lblSize.Text
            Context.Items("PriceWah") = lblPriceWah.Text
            Context.Items("Building_Detail") = lblBuilding_Detail.Text
            Context.Items("Subunit") = lblSubUnit.Text
            Context.Items("Subunit1") = lblSubUnit0.Text
            Context.Items("Subunit2") = lblSubUnit1.Text
            Context.Items("Land_Build") = lblLand_Build.Text
            Context.Items("LandTotal") = txtLandTotal.Text  'ราคาที่ดิน
            Context.Items("BuildingPrice") = txtBuildingPrice.Text  'ราคาสิ่งปลูกสร้าง
            Context.Items("SubTotal") = txtSubTotal.Text  'ราคารวม
            Context.Items("Unit_Price_Condo") = lblUnit_Price_Condo.Text
            Context.Items("GrandTotal") = txtGrandTotal.Text  'ราคารวมทั้งหมด
            Context.Items("ThaiBaht") = lblThaiBaht.Text
            Context.Items("Comment") = ddlComment.SelectedItem.ToString()
            Context.Items("Warning") = ddlWarning.SelectedItem.ToString()
            Context.Items("Warning_Detail") = txtWarning_Detail.Text
            Context.Items("UserAppraisal") = ddlUserAppraisal.SelectedItem.ToString()
            Context.Items("Approve1") = ddlApprove1.SelectedItem.ToString()
            Context.Items("Approve2") = ddlApprove2.SelectedItem.ToString()
            Context.Items("Approve3") = ddlApprove3.SelectedItem.ToString()
            Context.Items("Prosition_Approve1") = ddlPos_Approve1.SelectedItem.ToString()
            Context.Items("Prosition_Approve2") = ddlPos_Approve2.SelectedItem.ToString()
            Context.Items("Prosition_Approve3") = ddlPos_Approve3.SelectedItem.ToString()
            Server.Transfer("Print_Price3.aspx")
        Else
            Dim Str As String
            Str = "<script language=""javascript"">alert('คุณไม่สามารถแสดงฟอร์มการพิมพ์ได้หากคุณยังไม่ได้ยืนยันราคาที่ 3');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", Str)
        End If

    End Sub

    Protected Sub ddlAppraisal_Type_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAppraisal_Type.SelectedIndexChanged
        If ddlAppraisal_Type.SelectedValue = 1 Then
            'วิธีตลาด
            If lblCollName.Text = "หลักประกันห้องชุด เลขที่" Then
                'คอนโด
                txtSubTotal.Text = CDec(txtBuildingPrice.Text)
            ElseIf lblCollName.Text = "ที่ดิน เนื้อที่" Then
                Dim Obj_GetP50 As List(Of Price3_50) = GET_PRICE3_CONFORM(HiddenField1.Value, HiddenField2.Value, HiddenField3.Value)
                If Obj_GetP50.Count > 0 Then
                    txtLandTotal.Text = Format(Obj_GetP50.Item(0).PriceTotal1, "#,##0.00")
                    txtBuildingPrice.Text = "0.00"
                    txtSubTotal.Text = String.Format("{0:N2}", Obj_GetP50.Item(0).PriceTotal1)
                    txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtLandTotal.Text))
                End If
            Else
                'ที่ดิน สิ่งปลูกสร้าง
                txtLandTotal.Text = "0.00"
                Dim Obj_GetP70G As DataSet = GET_PRICE3_70_GROUP(HiddenField1.Value, HiddenField2.Value, HiddenField3.Value)
                If Obj_GetP70G.Tables(0).Rows.Count > 0 Then
                    txtSubTotal.Text = String.Format("{0:N2}", Obj_GetP70G.Tables(0).Rows(0).Item("PriceTotal1"))
                    txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtSubTotal.Text))
                Else
                    txtSubTotal.Text = String.Format("{0:N2}", 0)
                    txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtSubTotal.Text))
                End If
            End If
        Else
            'วิธีทุน
            If lblCollName.Text = "หลักประกันห้องชุด เลขที่" Then
                'คอนโด
            Else
                'ที่ดิน สิ่งปลูกสร้าง
                Show_Price3_50()
                Show_Price3_70_GROUP()
                Show_Price3_70_Group_Parttake()
                txtSubTotal.Text = String.Format("{0:N2}", CDec(txtLandTotal.Text) + CDec(txtBuildingPrice.Text))
                txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtSubTotal.Text))
            End If
        End If
    End Sub

    Private Sub Count_Item()
        'นับจำนวนสิ่งปลูกสร้างตาม Req_Id และ Hub_Id
    End Sub

    Protected Sub ddlComment_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlComment.PreRender
        Dim D1 As DropDownList = DirectCast(sender, DropDownList)
        'MsgBox(D1.Items.FindByText(ViewState("Comment")).ToString)
        Try
            If D1.SelectedValue <> 0 Then
            Else
                D1.SelectedIndex = ddlComment.Items.IndexOf(D1.Items.FindByText(ViewState("Comment")))
            End If
        Catch ex As Exception

        End Try


    End Sub

    Protected Sub ImgAttach_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgAttach.Click
        Dim ImgAttach As ImageButton = DirectCast(sender, ImageButton)
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)

        StrPath = Request.ApplicationPath & "/FileUpload_Price3.aspx?Req_Id=" & HiddenField1.Value & "&Hub_Id=" & HiddenField2.Value & "&AID=" & txtAID.Text & "&Temp_AID=" & HiddenField3.Value & "&UserId=" & lbluserid.Text
        S1 = "<script language=""javascript"">window.open('" + StrPath + "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, directories=no, status=yes,height=700px,width=830px');</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType, "แนบไฟล์", S1)
    End Sub

    Sub GET_PRICE2_DATA()
        Dim PRICE2_MASTER_DATA As DataSet = GET_PRICE2_MASTER_NEW(HiddenField1.Value, HiddenField2.Value)
        Dim P2Master As List(Of Price2_Master) = GET_PRICE2_MASTER(HiddenField1.Value, HiddenField2.Value)
        ddlComment.SelectedValue = PRICE2_MASTER_DATA.Tables(0).Rows(0).Item("Comment")
        ddlWarning.SelectedValue = PRICE2_MASTER_DATA.Tables(0).Rows(0).Item("Warning")
        If P2Master.Item(0).Appraisal_Type = 1 Then
            txtLandTotal.Text = String.Format("{0:N2}", PRICE2_MASTER_DATA.Tables(0).Rows(0).Item("Land"))
            'txtBuildingPrice.Text = String.Format("{0:N2}", PRICE2_MASTER_DATA.Tables(0).Rows(0).Item("Building"))
            txtSubTotal.Text = String.Format("{0:N2}", PRICE2_MASTER_DATA.Tables(0).Rows(0).Item("Building"))
            txtGrandTotal.Text = String.Format("{0:N2}", PRICE2_MASTER_DATA.Tables(0).Rows(0).Item("Building"))
        ElseIf P2Master.Item(0).Appraisal_Type = 2 Then
            txtLandTotal.Text = String.Format("{0:N2}", PRICE2_MASTER_DATA.Tables(0).Rows(0).Item("Land"))
            txtBuildingPrice.Text = String.Format("{0:N2}", PRICE2_MASTER_DATA.Tables(0).Rows(0).Item("Building"))
            txtGrandTotal.Text = String.Format("{0:N2}", PRICE2_MASTER_DATA.Tables(0).Rows(0).Item("Land") + PRICE2_MASTER_DATA.Tables(0).Rows(0).Item("Building"))
        End If

    End Sub

End Class
