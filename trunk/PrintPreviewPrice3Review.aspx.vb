Imports SME_SERVICE
Imports Appraisal_Manager
Imports System.Data
Imports System.Data.SqlClient
Imports System.Math
Imports ThaiBaht

Partial Class PrintPreviewPrice3Review
    Inherits System.Web.UI.Page
    Dim s As String
    Dim total As Decimal

    Function Get_Amount(ByVal Age As Decimal, ByVal P1 As Decimal, ByVal P2 As Decimal, ByVal P3 As Decimal) As String

        Dim Amount As Decimal = (Age * P1) - P2 + P3
        Return String.Format("{0:N2}", Amount)

    End Function

    Function Get_Amount_Bht(ByVal Price As Decimal, ByVal Age As Decimal, ByVal P1 As Decimal, ByVal P2 As Decimal, ByVal P3 As Decimal) As String

        Dim Amount_Price As Decimal = Price * (((P1 * Age) - P2 + P3) / 100)
        Return String.Format("{0:N2}", Amount_Price)

    End Function

    Function Get_Balance(ByVal Price As Decimal, ByVal Age As Decimal, ByVal P1 As Decimal, ByVal P2 As Decimal, ByVal P3 As Decimal) As String

        Dim Amount_Price As Decimal = Price - (Price * (((P1 * Age) - P2 + P3) / 100))
        total += Amount_Price
        Return String.Format("{0:N2}", Amount_Price)
        'MsgBox(total)
    End Function

    Function Get_Total() As String
        'txtBuildingPrice.Text = String.Format("{0:N2}", total)
        txtBuildingPrice.Text = String.Format("{0:N2}", Round(((total) / 1000), 0) * 1000)

        'txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtLandTotal.Text) + CDec(txtBuildingPrice.Text))
        Return String.Format("{0:N2}", total)

    End Function

    Function Get_RoundTotal() As String
        'txtGrandTotal_Round.Text = String.Format("{0:N2}", Round(((total) / 1000), 0) * 1000)
        'ตรวจสอบว่ามีาส่งปลูกสร้างมากกว่า 1 ชิ้นหรือไม่
        Dim P370_Re As List(Of Price3_70_Review) = GET_PRICE3_70_REVIEW_BY_REQ_ID(hdfReq_Id.Value, hdfHub_Id.Value)
        If P370_Re.Count > 1 Then
            Repeater1.Visible = False
            lblMessage.Visible = True
        Else
            Repeater1.Visible = True
            lblMessage.Visible = False
        End If
        Return String.Format("{0:N2}", Round(((total) / 1000), 0) * 1000)
    End Function

    Protected Sub ImageButtonReturn_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonReturn.Click
        Server.Transfer("Appraisal_Price3_List_AID.aspx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cus_class As Customer_Class
        Dim SV As New SME_SERVICE.Service
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        RadioButtonList1.Enabled = False
        RadioButtonList2.Enabled = False
        RadioButtonList3.Enabled = False
        RadioButtonList4.Enabled = False
        RadioButtonList5.Enabled = False
        If Not Page.IsPostBack Then

            LabelAIDValue.Text = Context.Items("AID")
            LabelCif.Text = Context.Items("Cif")
            hdfHub_Id.Value = Context.Items("Hub_Id")
            hdfReq_Id.Value = Context.Items("Req_Id")

            'ddlUserAppraisal.SelectedValue = Context.Items("Appraisal_Id")
            'lbluserid.Text = Context.Items("Appraisal_Id")
            hdfTemp_AID.Value = Context.Items("Temp_AID")
            hdfCollType.Value = Context.Items("CollType")
            Show_Price3_50_Find_Chanode(hdfReq_Id.Value, hdfHub_Id.Value, hdfTemp_AID.Value)
            cus_class = SV.GetCifInfo(LabelCif.Text)(0)
            If cus_class.Cif.ToString <> 0 Then
                lblCifName.Text = (cus_class.cifName)
            Else
                'ถ้า cif ที่ส่งมาเท่ากับ 0 ให้ Clear ค่า  ในคอนโทรล
                lblCifName.Text = ""
                Dim l As New Label
                'MessageBox("Format Exception: " & ex.Message)
                l.Text = SV.MSb("ค้นหาข้อมูลลูกค้าไม่พบ ")
                Page.Controls.Add(l)
            End If
            Dim ar As List(Of Appraisal_Request_v2) = GET_APPRAISAL_REQUEST_V2(hdfReq_Id.Value)

            'If ar.Count > 0 Then
            '    ddlBranch.SelectedValue = ar.Item(0).Branch_Id
            'End If
            'หาหมายเลขโฉนด
            'Dim ObjP3_Review As List(Of Price3_50_Review) = GET_PRICE3_50_REVIEW(hdfReq_Id.Value, hdfHub_Id.Value, 0)
            Dim ObjP3_Review As List(Of Price3_50) = GET_PRICE3_CONFORM(hdfReq_Id.Value, hdfHub_Id.Value, hdfTemp_AID.Value)
            If ObjP3_Review.Count > 0 Then
                hdfTemp_AID.Value = ObjP3_Review.Item(0).Temp_AID
                Dim SumP3 As DataSet = GET_SUM_PRICE3_50(hdfReq_Id.Value, hdfHub_Id.Value, hdfTemp_AID.Value)
                lblSize.Text = SumP3.Tables(0).Rows(0).Item("Rai") & "-" & SumP3.Tables(0).Rows(0).Item("Ngan") & "-" & SumP3.Tables(0).Rows(0).Item("Wah")
                LabelSizeTotalValue.Text = SumP3.Tables(0).Rows(0).Item("Rai") & "-" & SumP3.Tables(0).Rows(0).Item("Ngan") & "-" & SumP3.Tables(0).Rows(0).Item("Wah")
                For i = 0 To ObjP3_Review.Count - 1
                    If i <= 1 Then
                        Dim ObjSubColl As List(Of Cls_SubCollType) = GET_SUBCOLLTYPE(ObjP3_Review.Item(i).MysubColl_ID)
                        lblChanode.Text = lblChanode.Text & ObjSubColl.Item(0).SubCollType_Name & ObjP3_Review.Item(i).Address_No
                        lblChanode.Text += " ตำบล " & ObjP3_Review.Item(0).Tumbon & " อำเภอ " & ObjP3_Review.Item(0).Amphur
                        Province(ObjP3_Review.Item(0).Province)
                        lblChanode.Text += "  จังหวัด " & LabelProvinceName.Text
                    Else
                        lblChanode.Text = "ตามเอกสารแนบ"
                        LableAddress1.Text = "ตำบล/แขวง " & ObjP3_Review.Item(0).Tumbon & " อำเภอ/เขต " & ObjP3_Review.Item(0).Amphur & "จังหวัด " & LabelProvinceName.Text
                        Exit For
                    End If
                Next

                Form_Information()
            Else
                'แสดงรายละเอียดข้อมูล
                Form_Information()
            End If
        End If
    End Sub

    Private Sub Province(ByVal Pro_Id As Integer)
        Dim Obj_province As List(Of Cls_PROVINCE) = GET_PROVINCE_INFO(Pro_Id)
        LabelProvinceName.Text = Obj_province.Item(0).PROV_NAME
    End Sub

    Private Sub Branch_Info(ByVal Branch_Id As Integer)
        Dim Obj_Branch As List(Of Class_Branch) = GET_BRANCH_BY_KEY(Branch_Id)
        LabelBranchValue.Text = Trim(Obj_Branch.Item(0).BRANCH_NAME)
    End Sub

    Private Sub Show_Price3_50_Find_Chanode(ByVal Req_id As Integer, ByVal Hub_id As Integer, ByVal Temp_AID As Integer)
        Dim Get_Cnt_70 As DataSet = GET_PRICE3_70_COUNT(Req_id, Hub_id, Temp_AID)
        If Get_Cnt_70.Tables(0).Rows.Count > 0 Then
            hdfCollType.Value = "70"
            'MsgBox(hdfCollType.Value)
            lblBuilding_Detail.Text = Get_Cnt_70.Tables(0).Rows.Item(0).Item("Cnt_Building") & " รายการ"
        End If
    End Sub

    Private Sub Form_Information()
        Dim cus_class As Customer_Class
        Dim Emp_class As Employee_Info
        Dim SV As New SME_SERVICE.Service
        Dim DSProblem As DataSet
        Dim DSComment As DataSet
        Dim DSWarning As DataSet
        Dim DSAppraisalType As DataSet
        Dim DSPosition As DataSet
        Dim Op3_50r As List(Of Price3_50) = GET_PRICE3_CONFORM(hdfReq_Id.Value, hdfHub_Id.Value, hdfTemp_AID.Value)
        If Op3_50r.Count > 0 Then
            hdfTemp_AID.Value = Op3_50r.Item(0).Temp_AID
        End If


        Dim Obj_P3M As List(Of clsPrice3_Master) = GET_PRICE3_MASTER(hdfReq_Id.Value, hdfTemp_AID.Value)
        If Obj_P3M.Count > 0 Then
            'มีใน Price3 Mater
            LabelInform_To.Text = Obj_P3M.Item(0).Inform_To
            LabelAIDValue.Text = Obj_P3M.Item(0).AID
            LabelReceive_DateValue.Text = Obj_P3M.Item(0).Receive_Date
            LabelAppraisalDateValue.Text = Obj_P3M.Item(0).Appraisal_Date
            Branch_Info(Obj_P3M.Item(0).Req_Dept)
            cus_class = SV.GetCifInfo(LabelCif.Text)(0)
            If cus_class.Cif.ToString <> 0 Then
                lblCifName.Text = (cus_class.cifName)
            Else
            End If
            Emp_class = SV.GetEmployee_Info(Obj_P3M.Item(0).Appraisal_ID)(0)
            lblAppraisal_Name.Text = Emp_class.EmpName  'Obj_P3M.Item(0).Appraisal_ID
            DSProblem = GET_PROBLEM_INFO(Obj_P3M.Item(0).Env_Effect)
            LabelProblem.Text = DSProblem.Tables(0).Rows(0).Item("Problem_Name")
            LabelProblemDetail.Text = Obj_P3M.Item(0).Env_Effect_Detail
            txtBuy_Sale_Comment.Text = Obj_P3M.Item(0).Appraisal_Detail
            DSComment = GET_COMMENT_INFO(Obj_P3M.Item(0).Comment_ID)
            LabelCommentValue.Text = DSComment.Tables(0).Rows(0).Item("Comment_Name") 'Obj_P3M.Item(0).Comment_ID
            DSWarning = GET_WARNING_INFO(Obj_P3M.Item(0).Warning_ID)
            LabelWarningValue.Text = DSWarning.Tables(0).Rows(0).Item("Warning_Name") 'Obj_P3M.Item(0).Warning_ID
            txtWarning_Detail.Text = Obj_P3M.Item(0).Warning_Detail
            Emp_class = SV.GetEmployee_Info(Obj_P3M.Item(0).Approved1)(0)
            lblApprove1.Text = "(" & Emp_class.EmpName & ")" 'Obj_P3M.Item(0).Approved1
            Emp_class = SV.GetEmployee_Info(Obj_P3M.Item(0).Approved2)(0)
            lblApprove2.Text = "(" & Emp_class.EmpName & ")"  ' Obj_P3M.Item(0).Approved2
            Emp_class = SV.GetEmployee_Info(Obj_P3M.Item(0).Approved3)(0)
            lblApprove3.Text = "(" & Emp_class.EmpName & ")" 'Obj_P3M.Item(0).Approved3
            'ddlAppraisal_Type.SelectedValue = Obj_P3M.Item(0).Appraisal_Type_ID
            DSAppraisalType = GET_APPRAISAL_TYPE_INFO(Obj_P3M.Item(0).Appraisal_Type_ID)
            LabelAppraisalTypeName.Text = DSAppraisalType.Tables(0).Rows(0).Item("App_Type_Name")
            txtLandTotal.Text = String.Format("{0:N2}", Obj_P3M.Item(0).TotalPrice)
            txtBuildingPrice.Text = String.Format("{0:N2}", Obj_P3M.Item(0).BuildingPrice)
            txtSubTotal.Text = String.Format("{0:N2}", Obj_P3M.Item(0).Land_Building_Price)
            DSPosition = GET_POSITION_INFO(Obj_P3M.Item(0).Position_Approved1)
            lblPos_Approve1.Text = DSPosition.Tables(0).Rows(0).Item("Position_Name")
            DSPosition = GET_POSITION_INFO(Obj_P3M.Item(0).Position_Approved2)
            lblPos_Approve2.Text = DSPosition.Tables(0).Rows(0).Item("Position_Name")
            DSPosition = GET_POSITION_INFO(Obj_P3M.Item(0).Position_Approved3)
            lblPos_Approve3.Text = DSPosition.Tables(0).Rows(0).Item("Position_Name")
            If Obj_P3M.Item(0).Appraisal_Type_ID = 1 Then
                'วิธีตลาด
                txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtSubTotal.Text))
            Else
                'วิธีทุน
                txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtLandTotal.Text) + CDec(txtBuildingPrice.Text))
            End If

            Price3_Master_Review(Obj_P3M.Item(0).Approved)
            If hdfCollType.Value = "18" Then
                Price3_18_Review()
            Else
                Price3_50_Review(Obj_P3M.Item(0).Appraisal_Type_ID)
                Price3_70_Review(Obj_P3M.Item(0).Appraisal_Type_ID)
            End If

        Else
            'หากยังไม่มีใน Price3 Mater
            If hdfCollType.Value = "18" Then
                Price3_Master()
                Price3_18_Review()
            ElseIf hdfCollType.Value = "" Then
            Else
                'ตรวจเช็คก่อนว่ามีใน Review
                Price3_50_Review(2)
                Price3_70_Review(2)
                GetPricing(hdfCollType.Value)
            End If

        End If
        lblThaiBaht.Text = ThaiBahtFun(txtGrandTotal.Text)
        lblThaiBaht.Text = "(" & lblThaiBaht.Text & ")"
    End Sub

    Private Sub Price3_Master_Review(ByVal ChkApprove As Integer)
        'หา PRICE3_MASTER_REVIEW หากมีจะดึงข้อมูลเดิมมาให้
        'Dim Obj_P3M As List(Of clsPrice3_Master) = GET_PRICE3_MASTER(hdfReq_Id.Value, hdfTemp_AID.Value)
        Dim Obj_P3M_Reveiw As List(Of Price3_Master_Review) = GET_PRICE3_MASTER_REVIEW(LabelCif.Text, LabelAIDValue.Text, hdfReq_Id.Value)
        If Obj_P3M_Reveiw.Count > 0 Then
            hdfCollType.Value = Left(Obj_P3M_Reveiw.Item(0).AID, 2)
            LabelBuildingAge.Text = Obj_P3M_Reveiw.Item(0).Building_Age
            LabelMemoDate.Text = Obj_P3M_Reveiw.Item(0).Memo_Date
            If ChkApprove > 0 Then
                LabelSeqValue.Text = Obj_P3M_Reveiw.Item(0).Sequence + 1
            Else
                LabelSeqValue.Text = Obj_P3M_Reveiw.Item(0).Sequence
            End If

            RadioButtonList1.SelectedValue = Obj_P3M_Reveiw.Item(0).Land_Chg

            LabelLandDetail.Text = Obj_P3M_Reveiw.Item(0).Land_Chg_Detail
            RadioButtonList2.SelectedValue = Obj_P3M_Reveiw.Item(0).Obligation_Chg

            LabelObligation.Text = Obj_P3M_Reveiw.Item(0).Obligation_Chg_Detail
            RadioButtonList3.SelectedValue = Obj_P3M_Reveiw.Item(0).Site_Chg

            LabelLandAddress.Text = Obj_P3M_Reveiw.Item(0).Site_Chg_Detail
            RadioButtonList4.SelectedValue = Obj_P3M_Reveiw.Item(0).Progress_Chg
            RadioButtonList5.SelectedValue = Obj_P3M_Reveiw.Item(0).Building_Chg
            LabelBuilding.Text = Obj_P3M_Reveiw.Item(0).Building_Chg_Detail
            LabelLast_Appraisal_Detail.Text = Obj_P3M_Reveiw.Item(0).Appraisal_Last_Detail
            LabelBuildingStartDate.Text = Obj_P3M_Reveiw.Item(0).BuildingStartDate
        Else
            LabelSeqValue.Text = 1
        End If
    End Sub

    Private Sub Price3_18_Review()
        Dim Obj_18R As List(Of Price3_18_Review) = GET_PRICE3_18_REVIEW_GROUP(hdfReq_Id.Value, hdfHub_Id.Value, hdfTemp_AID.Value)
        LabelLand.Text = "หลักประกันห้องชุด"
        Label80.Text = "หลักประกันห้องชุด"
        Label9.Text = "ที่ตั้งและสภาพห้องชุด"
        lblCollName.Text = "ห้องชุด"
        Label53.Text = "เลขที่"
        Label48.Text = "ห้องชุด เลขที่"
        Label56.Text = "ห้องชุด เลขที่"

        If Obj_18R.Count = 1 Then
            Dim Obj_BuysaleState As List(Of Cls_Buy_Sale_State) = GET_BUYSALE_STATE_INFO(Obj_18R.Item(0).BuySale_State)
            Dim Obj_Province As List(Of Cls_PROVINCE) = GET_PROVINCE_INFO(Obj_18R.Item(0).Province1)

            lblChanode.Text = ""
            Dim ObjSubColl As List(Of Cls_SubCollType) = GET_SUBCOLLTYPE(Obj_18R.Item(0).MysubColl_ID)
            lblChanode.Text = lblChanode.Text & ObjSubColl.Item(0).SubCollType_Name & Obj_18R.Item(0).Address_No
            lblChanode.Text += " ตำบล " & Obj_18R.Item(0).Tumbon & " อำเภอ " & Obj_18R.Item(0).Amphur
            Province(Obj_18R.Item(0).Province)
            lblChanode.Text += "  จังหวัด " & LabelProvinceName.Text
            LabelSizeTotalValue.Text = Obj_18R.Item(0).Room_Area
            LabelBuildingAge.Text = Obj_18R.Item(0).Building_Age
            Repeater1.Visible = False
            LabelAID.Text = Obj_18R.Item(0).AID
            lblBuySaleState_Name.Text = Obj_BuysaleState.Item(0).BuySale_State_Name
            '        txtDistrict.Text = Obj_18R.Item(0).Tumbon1
            '        txtAmphur.Text = Obj_18R.Item(0).Amphur1
            '        lblProvinceName.Text = Obj_Province.Item(0).PROV_NAME
            LableAddress1.Text = "ตำบล/แขวง " & Obj_18R.Item(0).Tumbon1 & " อำเภอ/เขต " & Obj_18R.Item(0).Amphur1 & "จังหวัด " & LabelProvinceName.Text
            Dim dec As List(Of Cls_Interior) = GET_INTERIOR_INFO(Obj_18R.Item(0).InteriorState_Id)
            LabelDecoration.Text = dec.Item(0).InteriorState_Name
            '        ddlInteriorState.SelectedValue = Obj_18R.Item(0).InteriorState_Id
            lblSize.Text = Replace(Space(10), " ", "&nbsp;") & Obj_18R.Item(0).Address_No & Replace(Space(5), " ", "&nbsp;") & "เนื้อที่" & Replace(Space(5), " ", "&nbsp;") & Obj_18R.Item(0).Room_Area & Replace(Space(5), " ", "&nbsp;") & "ตรม."
            lblPriceWah.Text = String.Format("{0:N2}", Obj_18R.Item(0).Unit_Price)
            txtLandTotal.Text = String.Format("{0:N2}", Obj_18R.Item(0).PriceTotal)
            txtSubTotal.Text = String.Format("{0:N2}", 0)
            txtGrandTotal.Text = String.Format("{0:N2}", Obj_18R.Item(0).PriceTotal)
        Else
            lblCollName.Text = "ตามเอกสารแนบ"
            Label53.Text = ""
        End If
        '    'MsgBox("CollType 18")
    End Sub

    Private Sub Price3_50_Review(ByVal Appraisal_Type_ID As Integer)
        Dim DS As DataSet
        'DS = CreateDataset(50, "PRICE3_50_REVIEW")
        DS = CreateDataset(50, "PRICE3_50")
        If DS.Tables(0).Rows.Item(0).Item("CntID") > 0 Then
            hdfTemp_AID.Value = DS.Tables(0).Rows.Item(0).Item("Temp_AID")
            If DS.Tables(0).Rows.Item(0).Item("Rai") = 0 And DS.Tables(0).Rows.Item(0).Item("Ngan") = 0 Then
                'LabelSizeTotalValue.Text = "0" & "-" & "0" & "-" & DS.Tables(0).Rows.Item(0).Item("TotalWah")
                'lblSize.Text = "0" & "-" & "0" & "-" & DS.Tables(0).Rows.Item(0).Item("TotalWah")
            Else
                'LabelSizeTotalValue.Text = DS.Tables(0).Rows.Item(0).Item("Rai") & "-" & DS.Tables(0).Rows.Item(0).Item("Ngan") & "-" & DS.Tables(0).Rows.Item(0).Item("Wah")
                'lblSize.Text = DS.Tables(0).Rows.Item(0).Item("Rai") & "-" & DS.Tables(0).Rows.Item(0).Item("Ngan") & "-" & DS.Tables(0).Rows.Item(0).Item("Wah")
            End If

            Dim Obj_SubUnit As List(Of Cls_SubUnit) = GET_SubUnit_Info(DS.Tables(0).Rows.Item(0).Item("SubUnit_Id"))
            lblSubUnit.Text = Obj_SubUnit.Item(0).SubUnit_Name
            If Appraisal_Type_ID = 1 Then
                lblPriceWah.Text = "0.00"
            Else
                If DS.Tables(0).Rows.Item(0).Item("CntID") = 1 Then
                    lblPriceWah.Text = String.Format("{0:N2}", DS.Tables(0).Rows.Item(0).Item("PriceWah"))
                Else
                    lblPriceWah.Text = "ตามเอกสารแนบ"
                End If

                txtLandTotal.Text = Format(DS.Tables(0).Rows.Item(0).Item("PriceTotal1"), "#,##0.00")

            End If

            'lblPriceWah.Text = Format(DS.Tables(0).Rows.Item(0).Item("PriceTotal1") / DS.Tables(0).Rows.Item(0).Item("Totalwah"), "#,##0.00")  'Format(DS.Tables(0).Rows.Item(0).Item("PriceWah"), "#,##0.00") & " บาท"
            'txtLandTotal.Text = Format(DS.Tables(0).Rows.Item(0).Item("PriceTotal1"), "#,##0.00")
            Dim OjbColour As List(Of Cls_Area_Colour) = GET_AREA_COLOUR_INFO(DS.Tables(0).Rows.Item(0).Item("AreaColour_No"))
            lblAreaColour.Text = OjbColour.Item(0).AreaColour_Name
            Dim Obj_BuysaleState As List(Of Cls_Buy_Sale_State) = GET_BUYSALE_STATE_INFO(DS.Tables(0).Rows.Item(0).Item("AreaColour_No"))
            'lblBuySaleState_Name.Text = Obj_BuysaleState.Item(0).BuySale_State_Name
        Else

        End If
    End Sub

    Private Sub Price3_70_Review(ByVal Appraisal_Type_ID As Integer)
        Dim DS As DataSet
        'หาเนื้อที่รวมสิ่งปลูกสร้าง
        'DS = CreateDataset(70, "PRICE3_70_REVIEW")
        DS = CreateDataset(70, "PRICE3_70")
        If DS.Tables(0).Rows.Item(0).Item("CntID") > 0 Then
            LabelDecoration.Text = DS.Tables(0).Rows.Item(0).Item("Decoration")
            If Not IsDBNull(DS.Tables(0).Rows.Item(0).Item("BuildingArea")) Then
                'txtDistrict.Text = DS.Tables(0).Rows.Item(0).Item("District")
                'txtAmphur.Text = DS.Tables(0).Rows.Item(0).Item("Amphur")
                'Dim Obj_province As List(Of Cls_PROVINCE) = GET_PROVINCE_INFO(DS.Tables(0).Rows.Item(0).Item("Province"))
                'lblProvinceName.Text = Obj_province.Item(0).PROV_NAME
                'Province(DS.Tables(0).Rows.Item(0).Item("Province"))
                LableAddress1.Text = "ตำบล/แขวง " & DS.Tables(0).Rows.Item(0).Item("District") & " อำเภอ/เขต " & DS.Tables(0).Rows.Item(0).Item("Amphur") & " จังหวัด " & LabelProvinceName.Text
                'LabelDecoration.Text = DS.Tables(0).Rows.Item(0).Item("Decoration")
                Dim decor As List(Of Cls_Interior) = GET_INTERIOR_INFO(DS.Tables(0).Rows.Item(0).Item("Decoration"))
                LabelDecoration.Text = decor.Item(0).InteriorState_Name
                Dim Std As List(Of Cls_Standard) = GET_STANDARD_INFO_BY_ID(DS.Tables(0).Rows.Item(0).Item("Standard_Id"))
                LabelStrandardValue.Text = Std.Item(0).STANDARD_NAME
            End If
            If Appraisal_Type_ID = 1 Then
                txtSubTotal.Text = String.Format("{0:N2}", DS.Tables(0).Rows.Item(0).Item("PriceTotal1"))
            Else
                'รวมราคาที่ดิน+สิ่งปลูกสร้าง

                Dim P3_70 As DataSet = GET_PRICE3_70_GROUP(hdfReq_Id.Value, hdfHub_Id.Value, hdfTemp_AID.Value)
                'MsgBox(Get_Total())
                'txtBuildingPrice.Text = P3_70.Tables(0).Rows(0).Item("BuildingPrice")
                txtSubTotal.Text = "0.00" 'String.Format("{0:N2}", CDec(txtLandTotal.Text) + CDec(txtBuildingPrice.Text))
                txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtLandTotal.Text) + CDec(txtBuildingPrice.Text))
            End If
        Else
            'รวมราคาที่ดินอย่างเดียว
            If Appraisal_Type_ID = 1 Then
                txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtLandTotal.Text))
            Else
                'รวมราคาที่ดิน+สิ่งปลูกสร้าง
                txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtLandTotal.Text))
            End If

        End If
    End Sub

    Private Sub Price3_Master()
        Dim Obj_P3M As List(Of clsPrice3_Master) = GET_PRICE3_MASTER(hdfReq_Id.Value, hdfTemp_AID.Value)
        'หา PRICE3_MASTER หากมีจะดึงข้อมูลเดิมมาให้
        If Obj_P3M.Count > 0 Then
            LabelInform_To.Text = Obj_P3M.Item(0).Inform_To
            LabelReceive_Date.Text = Obj_P3M.Item(0).Receive_Date
            LabelAppraisalDateValue.Text = Obj_P3M.Item(0).Appraisal_Date
            lblPos_Approve1.Text = Obj_P3M.Item(0).Position_Approved1
            lblPos_Approve2.Text = Obj_P3M.Item(0).Position_Approved2
            lblPos_Approve3.Text = Obj_P3M.Item(0).Position_Approved3
            '        ddlBranch.SelectedValue = Obj_P3M.Item(0).Req_Dept
            '        ddlUserAppraisal.SelectedValue = Obj_P3M.Item(0).Appraisal_ID
            '        ddlProblem.SelectedValue = Obj_P3M.Item(0).Env_Effect
            '        txtProblem_Detail.Text = Obj_P3M.Item(0).Env_Effect_Detail
            '        txtBuy_Sale_Comment.Text = Obj_P3M.Item(0).Appraisal_Detail
            '        ddlComment.SelectedValue = Obj_P3M.Item(0).Comment_ID
            '        ddlWarning.SelectedValue = Obj_P3M.Item(0).Warning_ID
            '        txtWarning_Detail.Text = Obj_P3M.Item(0).Warning_Detail
            '        ddlApprove1.SelectedValue = Obj_P3M.Item(0).Approved1
            '        ddlApprove2.SelectedValue = Obj_P3M.Item(0).Approved2
            '        ddlApprove3.SelectedValue = Obj_P3M.Item(0).Approved3
            '        ddlAppraisal_Type.SelectedValue = Obj_P3M.Item(0).Appraisal_Type_ID
            '        If Obj_P3M.Item(0).Appraisal_Type_ID = 1 Then
            '            txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtSubTotal.Text))
            '        Else
            '            txtSubTotal.Text = "0.00"
            '            txtBuildingPrice.Text = String.Format("{0:N2}", Obj_P3M.Item(0).BuildingPrice)
            '            txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtLandTotal.Text) + CDec(txtBuildingPrice.Text))
            '        End If
        Else
            '        txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtSubTotal.Text))
        End If
    End Sub

    Private Function CreateDataset(ByVal CollType As Integer, ByVal TableName As String) As DataSet

        'For Print Data Out
        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        MyConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)

        MyDataAdapter = New SqlDataAdapter("GET_TOTAL_COLLTYPE", MyConnection)
        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@CollType", SqlDbType.Int))
        MyDataAdapter.SelectCommand.Parameters("@CollType").Value = CollType
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Req_Id", SqlDbType.Int))
        MyDataAdapter.SelectCommand.Parameters("@Req_Id").Value = hdfReq_Id.Value
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Hub_Id", SqlDbType.Int))
        MyDataAdapter.SelectCommand.Parameters("@Hub_Id").Value = hdfHub_Id.Value
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@TableName", SqlDbType.Text))
        MyDataAdapter.SelectCommand.Parameters("@TableName").Value = TableName

        DS = New DataSet() 'Create a new DataSet to hold the records.
        MyDataAdapter.Fill(DS, "GET_TOTAL_COLLTYPE") 'Fill the DataSet with the rows returned.
        Return DS

    End Function

    Private Sub GetPricing(ByVal CollType As String)
        Dim Price_Condo As Double = 0.0
        Dim Price_Land As Double = 0.0
        Dim Price_Building As Double = 0.0
        Dim Sub_Total As Double = 0.0
        Dim Grand_Total As Double = 0.0
        txtLandTotal.Text = "0.00"
        txtBuildingPrice.Text = "0.00"
        txtSubTotal.Text = "0.00"
        txtGrandTotal.Text = "0.00"

        'ดึงข้อมูลการให้ราคาที่ 3

        If CollType = "18" Then

        ElseIf CollType = "50" Then
            Dim DS_Land As DataSet = GET_PRICE3_LAND_BY_ID(hdfReq_Id.Value)
            Price_Land = DS_Land.Tables(0).Rows(0).Item("PriceTotal")
            txtLandTotal.Text = String.Format("{0:N2}", Price_Land)
            txtBuildingPrice.Text = String.Format("{0:N2}", Price_Building)
            Sub_Total = Price_Land + Price_Building
            txtSubTotal.Text = String.Format("{0:N2}", Sub_Total)
            txtGrandTotal.Text = String.Format("{0:N2}", Sub_Total)
        ElseIf CollType = "70" Then
            Dim DS_Land As DataSet = GET_PRICE3_LAND_BY_ID(hdfReq_Id.Value)
            Price_Land = DS_Land.Tables(0).Rows(0).Item("PriceTotal")
            txtLandTotal.Text = String.Format("{0:N2}", Price_Land)
            Dim DS_Building As DataSet = GET_PRICE3_BUILDING_BY_ID(hdfReq_Id.Value)
            If DS_Building.Tables(0).Rows.Count = 0 Then
                Price_Building = 0
                txtBuildingPrice.Text = 0
            Else
                Price_Building = DS_Building.Tables(0).Rows(0).Item("PriceTotal")
                txtBuildingPrice.Text = String.Format("{0:N2}", Price_Building)
            End If


            If Price_Land = 0 Then
                Sub_Total = DS_Building.Tables(0).Rows(0).Item("PriceMarket")
                txtSubTotal.Text = String.Format("{0:N2}", Sub_Total)
            Else
                Sub_Total = Price_Land + Price_Building
                txtSubTotal.Text = String.Format("{0:N2}", Sub_Total)
            End If


            txtGrandTotal.Text = String.Format("{0:N2}", Sub_Total)
        End If
    End Sub

    Protected Sub ImageButtonLandAttach_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonLandAttach.Click
        'Context.Items("Hub_Id") = hdfHub_Id.Value
        Context.Items("Req_Id") = hdfReq_Id.Value
        Context.Items("Cif") = LabelCif.Text
        Context.Items("CifName") = lblCifName.Text
        Server.Transfer("LandFileAttach.aspx")

    End Sub

    'Protected Sub ImageButtonPrint_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonPrint.Click
    '    Session("ctrl") = PanelPrint
    '    'ClientScript.RegisterStartupScript(Me.GetType(), "onclick", "<script language=javascript>window.open('Testprint.aspx','PrintMe','scrollbars=1');</script>")
    '    'ClientScript.RegisterStartupScript(Me.GetType(), "onclick", "<script language=javascript>window.open('Testprint.aspx','PrintMe','height=768px,width=1024px,scrollbars=1,resizable=yes');</script>")
    'End Sub

    'Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
    '    Session("ctrl") = PanelPrint
    'End Sub


End Class
