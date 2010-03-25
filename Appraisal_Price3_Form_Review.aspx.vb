Imports SME_SERVICE
Imports Appraisal_Manager
Imports System.Data
Imports System.Data.SqlClient
Imports System.Math
Imports ThaiBaht

Partial Class Appraisal_Price3_Form_Review
    Inherits System.Web.UI.Page
    Dim s As String
    Dim total As Decimal

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cus_class As Customer_Class
        Dim SV As New SME_SERVICE.Service
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        If Not Page.IsPostBack Then
            'ตรวจสอบว่าเคยมีข้อมูลอยู่แล้วในระบบหรือไม่ตรวจสอบจาก AID ถ้าตรวจพบแสดงว่ามีการประเมินอยู่ ถ้าไม่พบแสดงว่ายังไม่มีข้อมูลอยู่
            'ถ้าพบแจ้งให้ทราบว่าเคยประเมินแล้ว ต้องการนำข้อมูลเดิมมาเลยหรือไม่
            'Dim P3_MASTER As List(Of clsPrice3_Master) = GET_PRICE3_BY_AID(hdfAID.Value)
            'If P3_MASTER.Count > 0 Then

            'Else
            'End If



            txtAID.Text = Context.Items("AID")
            lblCif.Text = Context.Items("Cif")
            hdfHub_Id.Value = Context.Items("Hub_Id")
            hdfReq_Id.Value = Context.Items("Req_Id")
            ddlUserAppraisal.SelectedValue = Context.Items("Appraisal_Id")
            'ddlUserAppraisal.SelectedValue = Context.Items("Appraisal_Id")
            hdfTemp_AID.Value = Context.Items("Temp_AID")
            hdfCollType.Value = Context.Items("CollType")
            Show_Price3_50_Find_Chanode(hdfReq_Id.Value, hdfHub_Id.Value, hdfTemp_AID.Value)
            cus_class = SV.GetCifInfo(lblCif.Text)(0)
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

            If ar.Count > 0 Then
                ddlBranch.SelectedValue = ar.Item(0).Branch_Id
            End If
            'หาหมายเลขโฉนด
            'Dim ObjP3_Review As List(Of Price3_50_Review) = GET_PRICE3_50_REVIEW(hdfReq_Id.Value, hdfHub_Id.Value, 0)
            Dim ObjP3_Review As List(Of Price3_50) = GET_PRICE3_CONFORM(hdfReq_Id.Value, hdfHub_Id.Value, hdfTemp_AID.Value)
            If ObjP3_Review.Count > 0 Then
                hdfTemp_AID.Value = ObjP3_Review.Item(0).Temp_AID
                lblSize.Text = ObjP3_Review.Item(0).Rai & "-" & ObjP3_Review.Item(0).Ngan & "-" & ObjP3_Review.Item(0).Wah
                lblLandArea.Text = ObjP3_Review.Item(0).Rai & "-" & ObjP3_Review.Item(0).Ngan & "-" & ObjP3_Review.Item(0).Wah
                For i = 0 To ObjP3_Review.Count - 1
                    If i <= 1 Then
                        Dim ObjSubColl As List(Of Cls_SubCollType) = GET_SUBCOLLTYPE(ObjP3_Review.Item(i).MysubColl_ID)
                        lblChanode.Text = lblChanode.Text & ObjSubColl.Item(0).SubCollType_Name & ObjP3_Review.Item(i).Address_No
                        lblChanode.Text += " ตำบล " & ObjP3_Review.Item(0).Tumbon & " อำเภอ " & ObjP3_Review.Item(0).Amphur
                        Province(ObjP3_Review.Item(0).Province)
                        lblChanode.Text += "  จังหวัด " & lblProvinceName.Text
                    Else
                        lblChanode.Text = "ตามเอกสารแนบ"
                        txtDistrict.Text = ObjP3_Review.Item(0).Tumbon
                        txtAmphur.Text = ObjP3_Review.Item(0).Amphur
                        lblProvinceName.Text = lblProvinceName.Text
                        Exit For
                    End If
                Next

                Form_Information()
            Else
                'แสดงรายละเอียดข้อมูล
                Form_Information()
            End If



            Dim s1 As String = Nothing
            s1 += "window.open('CollDetail_Edit_Position_Price3.aspx"
            s1 += "?Req_Id=" & hdfReq_Id.Value
            s1 += "&Hub_Id=" & hdfHub_Id.Value
            s1 += "&UserId=" & lbluserid.Text
            s1 += "&Temp_AID=" & hdfTemp_AID.Value
            ImageEditPosition.Attributes.Add("onclick", s1 & "','showMap', 'width=820, height=780');")
        End If


    End Sub

    Protected Sub btnChangeLand_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangeLand.Click
        If RadioButtonList1.SelectedValue = 1 Or RadioButtonList2.SelectedValue = 1 Or RadioButtonList3.SelectedValue = 1 Or RadioButtonList4.SelectedValue = 1 Then

            Context.Items("Req_Id") = hdfReq_Id.Value
            Context.Items("Hub_Id") = hdfHub_Id.Value
            Context.Items("CollType") = 50
            Context.Items("Cif") = lblCif.Text
            Context.Items("CifName") = lblCifName.Text
            Context.Items("AID") = txtAID.Text
            Server.Transfer("Appraisal_Price3_Review_Coll_List.aspx")
        Else
            s = "<script language=""javascript"">alert('คุณไม่ได้เลือกเปลี่ยนแปลงคุณสมบัติที่ดิน');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", s)
        End If

    End Sub

    Protected Sub btnChangeBuilding_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangeBuilding.Click
        If RadioButtonList5.SelectedValue = 1 Then
            If hdfCollType.Value = "18" Then
                Context.Items("CollType") = 18
            Else
                Context.Items("CollType") = 70
            End If
            Context.Items("Req_Id") = hdfReq_Id.Value
            Context.Items("Hub_Id") = hdfHub_Id.Value
            Context.Items("Cif") = lblCif.Text
            Context.Items("CifName") = lblCifName.Text
            Context.Items("AID") = txtAID.Text
            Server.Transfer("Appraisal_Price3_Review_Coll_List.aspx")
        Else
            s = "<script language=""javascript"">alert('คุณไม่ได้เลือกเปลี่ยนแปลงสิ่งปลูกสร้าง');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", s)
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

    Protected Sub ImageSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSave.Click
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label) 'หา Control จาก Master Page ที่ control ไม่อยู่ใน  ContentPlaceHolder1 ของ Master Page

        'Dim s As String
        Dim cif As Integer = 0
        Dim AID As Integer = 0
        Dim Lat As Double
        Dim Lng As Double
        If lblCif.Text <> String.Empty Then
            cif = lblCif.Text
        End If
        If txtAID.Text <> String.Empty Then
            AID = txtAID.Text
        End If
        If txtMemo_Date.Text = String.Empty Then
            s = "<script language=""javascript"">alert('คุณไม่ได้ใส่วันที่ลงบันทึก');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "ผิดพลาด", s)
            Exit Sub
        End If
        If txtReceive_Date.Text = String.Empty Then
            s = "<script language=""javascript"">alert('คุณไม่ได้ใส่วันที่วันที่รับเรื่อง');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "ผิดพลาด", s)
            Exit Sub
        End If
        If txtAppraisal_Date.Text = String.Empty Then
            s = "<script language=""javascript"">alert('คุณไม่ได้ใส่วันที่ประเมิน');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "ผิดพลาด", s)
            Exit Sub
        End If

        'ตรวจสอบว่ามีการส่งประเมินใหม่หรือทบทวนประเมิน
        'Dim Obj_GetP1Master As List(Of ClsPrice1_Master) = GetPrice1_Master(HiddenField1.Value, HiddenField2.Value)
        'If Obj_GetP1Master.Count > 0 Then
        '    Lat = Obj_GetP1Master.Item(0).Lat
        '    Lng = Obj_GetP1Master.Item(0).Lng

        'ตรวจสอบการบันทึกข้อมูลว่ามีอยู่แล้วหรือไม่
        Dim Obj_P3M_Reveiw As List(Of Price3_Master_Review) = GET_PRICE3_MASTER_REVIEW(lblCif.Text, txtAID.Text, hdfReq_Id.Value)
        Dim Obj_P3M As List(Of clsPrice3_Master) = GET_PRICE3_MASTER(hdfReq_Id.Value, hdfTemp_AID.Value)
        Dim ReceiveDate As Date = CDate(txtReceive_Date.Text)
        Dim AppraisalDate As Date = CDate(txtAppraisal_Date.Text)
        Dim Memodate As Date = CDate(txtMemo_Date.Text)
        'มีข้อมูลแล้วให้ Update
        If Obj_P3M_Reveiw.Count > 0 And Obj_P3M.Count > 0 Then
            'Update Table Price3_Master
            Dim Pricewha As String = ""
            If lblPriceWah.Text = "ตามเอกสารแนบ" Then
                Pricewha = "0.00"
            Else
                Pricewha = lblPriceWah.Text
            End If
            UPDATE_PRICE3_MASTER(hdfReq_Id.Value, _
                             txtAID.Text, _
                             hdfTemp_AID.Value, _
                             txtInform_To.Text, _
                             lblCif.Text, _
                             Obj_P3M.Item(0).Lat, _
                             Obj_P3M.Item(0).Lng, _
                             AppraisalDate, _
                             ReceiveDate, _
                             CDec(Pricewha), _
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

            'Update Table Price3_Master_Review
            'MsgBox(RadioButtonList1.SelectedValue)
            UPDATE_PRICE3_MASTER_REVIEW(hdfReq_Id.Value, txtAID.Text, hdfTemp_AID.Value, lblCif.Text, txtDistrict.Text, txtAmphur.Text, txtBuilding_Age.Text, Memodate, txtSequence.Text, RadioButtonList1.SelectedValue, txtLandDetail.Text, _
                                     RadioButtonList2.SelectedValue, txtObligation.Text, RadioButtonList3.SelectedValue, txtLandAddress.Text, RadioButtonList4.SelectedValue, _
                                     RadioButtonList5.SelectedValue, txtBuilding.Text, txtLast_Appraisal_Detail.Text, txtBuildingStartDate.Text, lbluserid.Text, Now())

            If lbluserid.Text = ddlUserAppraisal.SelectedValue Then 'ตรวจสอบก่อนว่าผู้แก้ไขเป็นผู้ประเมินหรือไม่ ถ้าใช่ถึงจะแก้ไขอนุกรรมการได้
                For i = 1 To 3
                    If i = 1 Then
                        'ผู้อนุมัติคนที่1 ไม่สามารถแก้ไขได้
                    ElseIf i = 2 Then
                        'แก้ไขผู้อนุมัติคนที่2 และ 3 
                        UPDATE_WAIT_FOR_APPROVE_COMMITTEE(hdfReq_Id.Value, hdfHub_Id.Value, i, txtAID.Text, hdfTemp_AID.Value, ddlApprove2.SelectedValue, lblCif.Text, hdfCollType.Value, ddlUserAppraisal.SelectedValue, 0, Now(), Now(), Now(), lbluserid.Text, Now())
                    ElseIf i = 3 Then
                        UPDATE_WAIT_FOR_APPROVE_COMMITTEE(hdfReq_Id.Value, hdfHub_Id.Value, i, txtAID.Text, hdfTemp_AID.Value, ddlApprove3.SelectedValue, lblCif.Text, hdfCollType.Value, ddlUserAppraisal.SelectedValue, 0, Now(), Now(), Now(), lbluserid.Text, Now())
                    End If
                Next
            Else
                UpdateWait_For_Approve(hdfReq_Id.Value, hdfHub_Id.Value, txtAID.Text, hdfTemp_AID.Value, ddlApprove3.SelectedValue, lblCif.Text, hdfCollType.Value, ddlUserAppraisal.SelectedValue, 0, Now(), Now(), Now(), lbluserid.Text, Now())
            End If

            s = "<script language=""javascript"">alert('บันทึกเสร็จสมบูรณ์');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
        Else 'ยังไม่มีข้อมูลให้ Insert
            Dim wah As Decimal
            Lat = 0
            Lng = 0
            If lblPriceWah.Text = "ตามเอกสารแนบ" Then
                wah = 0
            End If
            AddPRICE3_Master(hdfReq_Id.Value, _
                 txtAID.Text, _
                 hdfTemp_AID.Value, _
                 txtInform_To.Text, _
                 lblCif.Text, _
                 Lat, _
                 Lng, _
                 AppraisalDate, _
                 ReceiveDate, _
                 CDec(wah), _
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
            ADD_PRICE3_MASTER_REVIEW(hdfReq_Id.Value, txtAID.Text, hdfTemp_AID.Value, lblCif.Text, txtDistrict.Text, txtAmphur.Text, txtBuilding_Age.Text, Memodate, txtSequence.Text, RadioButtonList1.SelectedValue, txtLandDetail.Text, _
                                     RadioButtonList2.SelectedValue, txtObligation.Text, RadioButtonList3.SelectedValue, txtLandAddress.Text, RadioButtonList4.SelectedValue, _
                                     RadioButtonList5.SelectedValue, txtBuilding.Text, txtLast_Appraisal_Detail.Text, txtBuildingStartDate.Text, lbluserid.Text, Now())

            If CDec(txtGrandTotal.Text) >= 10000000 Then  'ตรวจสอบว่าราคาประเมินเกิน 20 ล้านหรือไม่
                'อนุมัติคนที่ 1
                AddWait_For_Approve(1, hdfReq_Id.Value, hdfHub_Id.Value, txtAID.Text, hdfTemp_AID.Value, ddlApprove1.SelectedValue, lblCif.Text, hdfCollType.Value, ddlUserAppraisal.SelectedValue, 0, Now(), Now(), Now(), lbluserid.Text, Now())
            Else
                'อนุมัติคนที่ 1
                AddWait_For_Approve(1, hdfReq_Id.Value, hdfHub_Id.Value, txtAID.Text, hdfTemp_AID.Value, ddlApprove1.SelectedValue, lblCif.Text, hdfCollType.Value, ddlUserAppraisal.SelectedValue, 1, Now(), Now(), Now(), lbluserid.Text, Now())
            End If

            'อนุมัติคนที่ 2
            AddWait_For_Approve(2, hdfReq_Id.Value, hdfHub_Id.Value, txtAID.Text, hdfTemp_AID.Value, ddlApprove2.SelectedValue, lblCif.Text, hdfCollType.Value, ddlUserAppraisal.SelectedValue, 0, Now(), Now(), Now(), lbluserid.Text, Now())
            'อนุมัติคนที่ 3
            AddWait_For_Approve(3, hdfReq_Id.Value, hdfHub_Id.Value, txtAID.Text, hdfTemp_AID.Value, ddlApprove3.SelectedValue, lblCif.Text, hdfCollType.Value, ddlUserAppraisal.SelectedValue, 0, Now(), Now(), Now(), lbluserid.Text, Now())

            s = "<script language=""javascript"">alert('บันทึกเสร็จสมบูรณ์');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
        End If

    End Sub

    Private Sub Form_Information()
        Dim Op3_50r As List(Of Price3_50) = GET_PRICE3_CONFORM(hdfReq_Id.Value, hdfHub_Id.Value, hdfTemp_AID.Value)
        If Op3_50r.Count > 0 Then
            hdfTemp_AID.Value = Op3_50r.Item(0).Temp_AID
        End If


        Dim Obj_P3M As List(Of clsPrice3_Master) = GET_PRICE3_MASTER(hdfReq_Id.Value, hdfTemp_AID.Value)
        If Obj_P3M.Count > 0 Then
            'มีใน Price3 Mater
            txtInform_To.Text = Obj_P3M.Item(0).Inform_To
            txtReceive_Date.Text = Obj_P3M.Item(0).Receive_Date
            txtAppraisal_Date.Text = Obj_P3M.Item(0).Appraisal_Date
            ddlBranch.SelectedValue = Obj_P3M.Item(0).Req_Dept
            ddlUserAppraisal.SelectedValue = Obj_P3M.Item(0).Appraisal_ID
            ddlProblem.SelectedValue = Obj_P3M.Item(0).Env_Effect
            txtProblem_Detail.Text = Obj_P3M.Item(0).Env_Effect_Detail
            txtBuy_Sale_Comment.Text = Obj_P3M.Item(0).Appraisal_Detail
            ddlComment.SelectedValue = Obj_P3M.Item(0).Comment_ID
            ddlWarning.SelectedValue = Obj_P3M.Item(0).Warning_ID
            txtWarning_Detail.Text = Obj_P3M.Item(0).Warning_Detail
            ddlApprove1.SelectedValue = Obj_P3M.Item(0).Approved1
            ddlPos_Approve1.SelectedValue = Obj_P3M.Item(0).Position_Approved1
            ddlApprove2.SelectedValue = Obj_P3M.Item(0).Approved2
            ddlPos_Approve2.SelectedValue = Obj_P3M.Item(0).Position_Approved2
            ddlApprove3.SelectedValue = Obj_P3M.Item(0).Approved3
            ddlPos_Approve3.SelectedValue = Obj_P3M.Item(0).Position_Approved3
            ddlAppraisal_Type.SelectedValue = Obj_P3M.Item(0).Appraisal_Type_ID
            txtLandTotal.Text = String.Format("{0:N2}", Obj_P3M.Item(0).TotalPrice)
            txtBuildingPrice.Text = String.Format("{0:N2}", Obj_P3M.Item(0).BuildingPrice)
            txtSubTotal.Text = String.Format("{0:N2}", Obj_P3M.Item(0).Land_Building_Price)
            'MsgBox(Obj_P3M.Item(0).Appraisal_Type_ID)
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
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If RadioButtonList1.SelectedValue = 1 Then
            txtLandDetail.Enabled = True
        Else
            txtLandDetail.Enabled = False
        End If
    End Sub

    Protected Sub RadioButtonList2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList2.SelectedIndexChanged
        If RadioButtonList2.SelectedValue = 1 Then
            txtObligation.Enabled = True
        Else
            txtObligation.Enabled = False
        End If
    End Sub

    Protected Sub RadioButtonList3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList3.SelectedIndexChanged
        If RadioButtonList3.SelectedValue = 1 Then
            txtLandAddress.Enabled = True
        Else
            txtLandAddress.Enabled = False
        End If
    End Sub

    Protected Sub RadioButtonList5_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList5.SelectedIndexChanged
        If RadioButtonList5.SelectedValue = 1 Then
            txtBuilding.Enabled = True
        Else
            txtBuilding.Enabled = False
        End If
    End Sub

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

    Protected Sub ddlAppraisal_Type_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAppraisal_Type.SelectedIndexChanged
        Dim DS As DataSet

        If ddlAppraisal_Type.SelectedValue = 1 Then
            'วิธีตลาด
            DS = CreateDataset(50, "PRICE3_50")
            If DS.Tables(0).Rows.Item(0).Item("CntID") > 0 Then
                lblPriceWah.Text = "0.00"
                txtLandTotal.Text = "0.00"
                txtSubTotal.Text = String.Format("{0:N2}", DS.Tables(0).Rows.Item(0).Item("PriceTotal1"))
            End If
            DS = CreateDataset(70, "PRICE3_70")
            If DS.Tables(0).Rows.Item(0).Item("CntID") > 0 Then
                'txtBuildingPrice.Text = String.Format("{0:N2}", DS.Tables(0).Rows.Item(0).Item("BuildingPrice"))
                txtSubTotal.Text = String.Format("{0:N2}", DS.Tables(0).Rows.Item(0).Item("PriceTotal1"))
            End If
            txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtSubTotal.Text))
        Else
            'วิธีทุน
            'Dim B_Price As Decimal
            DS = CreateDataset(50, "PRICE3_50")
            If DS.Tables(0).Rows.Item(0).Item("CntID") > 0 Then
                lblPriceWah.Text = Format(DS.Tables(0).Rows.Item(0).Item("PriceTotal1") / DS.Tables(0).Rows.Item(0).Item("Totalwah"), "#,##0.00")
                txtLandTotal.Text = String.Format("{0:N2}", DS.Tables(0).Rows.Item(0).Item("PriceTotal1"))
            End If
            '
            DS = CreateDataset(70, "PRICE3_70")
            If DS.Tables(0).Rows.Item(0).Item("CntID") > 0 Then
                'B_Price = DS.Tables(0).Rows.Item(0).Item("BuildingPrice") - (DS.Tables(0).Rows.Item(0).Item("BuildingPrice") * (DS.Tables(0).Rows.Item(0).Item("BuildingPriceTotalDeteriorate") / 100))

                ' txtBuildingPrice.Text = String.Format("{0:N2}", B_Price)
                txtSubTotal.Text = "0.00"
                txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtLandTotal.Text) + CDec(txtBuildingPrice.Text))
            End If
        End If
        lblThaiBaht.Text = ThaiBahtFun(txtGrandTotal.Text)
    End Sub

    Private Sub Price3_18_Review()
        Dim Obj_18R As List(Of Price3_18_Review) = GET_PRICE3_18_REVIEW_GROUP(hdfReq_Id.Value, hdfHub_Id.Value, hdfTemp_AID.Value)
        Label6.Text = "หลักประกันห้องชุด"
        Label80.Text = "หลักประกันห้องชุด"
        Label9.Text = "ที่ตั้งและสภาพห้องชุด"
        lblCollName.Text = "ห้องชุด"
        Label53.Text = "เลขที่"
        Label48.Text = "ห้องชุด เลขที่"
        Label56.Text = "ห้องชุด เลขที่"

        If Obj_18R.Count = 1 Then
            Dim Obj_BuysaleState As List(Of Cls_Buy_Sale_State) = GET_BUYSALE_STATE_INFO(Obj_18R.Item(0).BuySale_State)
            Dim Obj_Province As List(Of Cls_PROVINCE) = GET_PROVINCE_INFO(Obj_18R.Item(0).Province1)

            'txtMemo_Date.Text = ""
            'txtReceive_Date.Text = ""
            lblChanode.Text = ""
            Dim ObjSubColl As List(Of Cls_SubCollType) = GET_SUBCOLLTYPE(Obj_18R.Item(0).MysubColl_ID)
            lblChanode.Text = lblChanode.Text & ObjSubColl.Item(0).SubCollType_Name & Obj_18R.Item(0).Address_No
            lblChanode.Text += " ตำบล " & Obj_18R.Item(0).Tumbon & " อำเภอ " & Obj_18R.Item(0).Amphur
            Province(Obj_18R.Item(0).Province)
            lblChanode.Text += "  จังหวัด " & lblProvinceName.Text
            lblLandArea.Text = Obj_18R.Item(0).Room_Area
            txtBuilding_Age.Text = Obj_18R.Item(0).Building_Age
            Repeater1.Visible = False
            txtAID.Text = Obj_18R.Item(0).AID
            lblBuySaleState_Name.Text = Obj_BuysaleState.Item(0).BuySale_State_Name
            txtDistrict.Text = Obj_18R.Item(0).Tumbon1
            txtAmphur.Text = Obj_18R.Item(0).Amphur1
            lblProvinceName.Text = Obj_Province.Item(0).PROV_NAME
            ddlInteriorState.SelectedValue = Obj_18R.Item(0).InteriorState_Id
            lblSize.Text = Replace(Space(10), " ", "&nbsp;") & Obj_18R.Item(0).Address_No & Replace(Space(5), " ", "&nbsp;") & "เนื้อที่" & Replace(Space(5), " ", "&nbsp;") & Obj_18R.Item(0).Room_Area & Replace(Space(5), " ", "&nbsp;") & "ตรม."
            lblPriceWah.Text = String.Format("{0:N2}", Obj_18R.Item(0).Unit_Price)
            txtLandTotal.Text = String.Format("{0:N2}", Obj_18R.Item(0).PriceTotal)
            txtSubTotal.Text = String.Format("{0:N2}", 0)
            txtGrandTotal.Text = String.Format("{0:N2}", Obj_18R.Item(0).PriceTotal)
        Else
            lblCollName.Text = "ตามเอกสารแนบ"
            Label53.Text = ""
        End If
        'MsgBox("CollType 18")
    End Sub

    Private Sub Price3_50_Review(ByVal Appraisal_Type_ID As Integer)
        Dim DS As DataSet
        'DS = CreateDataset(50, "PRICE3_50_REVIEW")
        DS = CreateDataset(50, "PRICE3_50")
        If DS.Tables(0).Rows.Item(0).Item("CntID") > 0 Then
            hdfTemp_AID.Value = DS.Tables(0).Rows.Item(0).Item("Temp_AID")
            If DS.Tables(0).Rows.Item(0).Item("Rai") = 0 And DS.Tables(0).Rows.Item(0).Item("Ngan") = 0 Then
                'lblLandArea.Text = "0" & "-" & "0" & "-" & DS.Tables(0).Rows.Item(0).Item("TotalWah")
                'lblSize.Text = "0" & "-" & "0" & "-" & DS.Tables(0).Rows.Item(0).Item("TotalWah")
            Else
                'lblLandArea.Text = DS.Tables(0).Rows.Item(0).Item("Rai") & "-" & DS.Tables(0).Rows.Item(0).Item("Ngan") & "-" & DS.Tables(0).Rows.Item(0).Item("Wah")
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
            ddlInteriorState.SelectedValue = DS.Tables(0).Rows.Item(0).Item("District")
            If Not IsDBNull(DS.Tables(0).Rows.Item(0).Item("BuildingArea")) Then
                txtDistrict.Text = DS.Tables(0).Rows.Item(0).Item("District")
                txtAmphur.Text = DS.Tables(0).Rows.Item(0).Item("Amphur")
                'Dim Obj_province As List(Of Cls_PROVINCE) = GET_PROVINCE_INFO(DS.Tables(0).Rows.Item(0).Item("Province"))
                'lblProvinceName.Text = Obj_province.Item(0).PROV_NAME
                Province(DS.Tables(0).Rows.Item(0).Item("Province"))
                ddlInteriorState.SelectedValue = DS.Tables(0).Rows.Item(0).Item("Decoration")
                ddlStandard.SelectedValue = DS.Tables(0).Rows(0).Item("Standard_Id")
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
            txtInform_To.Text = Obj_P3M.Item(0).Inform_To
            txtReceive_Date.Text = Obj_P3M.Item(0).Receive_Date
            txtAppraisal_Date.Text = Obj_P3M.Item(0).Appraisal_Date
            ddlBranch.SelectedValue = Obj_P3M.Item(0).Req_Dept
            ddlUserAppraisal.SelectedValue = Obj_P3M.Item(0).Appraisal_ID
            ddlProblem.SelectedValue = Obj_P3M.Item(0).Env_Effect
            txtProblem_Detail.Text = Obj_P3M.Item(0).Env_Effect_Detail
            txtBuy_Sale_Comment.Text = Obj_P3M.Item(0).Appraisal_Detail
            ddlComment.SelectedValue = Obj_P3M.Item(0).Comment_ID
            ddlWarning.SelectedValue = Obj_P3M.Item(0).Warning_ID
            txtWarning_Detail.Text = Obj_P3M.Item(0).Warning_Detail
            ddlApprove1.SelectedValue = Obj_P3M.Item(0).Approved1
            ddlPos_Approve1.SelectedValue = Obj_P3M.Item(0).Position_Approved1
            ddlApprove2.SelectedValue = Obj_P3M.Item(0).Approved2
            ddlPos_Approve2.SelectedValue = Obj_P3M.Item(0).Position_Approved2
            ddlApprove3.SelectedValue = Obj_P3M.Item(0).Approved3
            ddlPos_Approve3.SelectedValue = Obj_P3M.Item(0).Position_Approved3
            ddlAppraisal_Type.SelectedValue = Obj_P3M.Item(0).Appraisal_Type_ID
            If Obj_P3M.Item(0).Appraisal_Type_ID = 1 Then
                txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtSubTotal.Text))
            Else
                txtSubTotal.Text = "0.00"
                txtBuildingPrice.Text = String.Format("{0:N2}", Obj_P3M.Item(0).BuildingPrice)
                txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtLandTotal.Text) + CDec(txtBuildingPrice.Text))
            End If
        Else
            txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtSubTotal.Text))
        End If
    End Sub

    Private Sub Price3_Master_Review(ByVal ChkApprove As Integer)
        'หา PRICE3_MASTER_REVIEW หากมีจะดึงข้อมูลเดิมมาให้
        'Dim Obj_P3M As List(Of clsPrice3_Master) = GET_PRICE3_MASTER(hdfReq_Id.Value, hdfTemp_AID.Value)
        Dim Obj_P3M_Reveiw As List(Of Price3_Master_Review) = GET_PRICE3_MASTER_REVIEW(lblCif.Text, txtAID.Text, hdfReq_Id.Value)
        If Obj_P3M_Reveiw.Count > 0 Then
            hdfCollType.Value = Left(Obj_P3M_Reveiw.Item(0).AID, 2)
            txtBuilding_Age.Text = Obj_P3M_Reveiw.Item(0).Building_Age
            txtMemo_Date.Text = Obj_P3M_Reveiw.Item(0).Memo_Date
            If ChkApprove > 0 Then
                txtSequence.Text = Obj_P3M_Reveiw.Item(0).Sequence + 1
            Else
                txtSequence.Text = Obj_P3M_Reveiw.Item(0).Sequence
            End If

            RadioButtonList1.SelectedValue = Obj_P3M_Reveiw.Item(0).Land_Chg
            If Obj_P3M_Reveiw.Item(0).Land_Chg = 0 Then
                txtLandDetail.Enabled = False
            Else
                txtLandDetail.Enabled = True
            End If

            txtLandDetail.Text = Obj_P3M_Reveiw.Item(0).Land_Chg_Detail
            RadioButtonList2.SelectedValue = Obj_P3M_Reveiw.Item(0).Obligation_Chg
            If Obj_P3M_Reveiw.Item(0).Obligation_Chg = 0 Then
                txtObligation.Enabled = False
            Else
                txtObligation.Enabled = True
            End If
            txtObligation.Text = Obj_P3M_Reveiw.Item(0).Obligation_Chg_Detail
            RadioButtonList3.SelectedValue = Obj_P3M_Reveiw.Item(0).Site_Chg
            If Obj_P3M_Reveiw.Item(0).Site_Chg = 0 Then
                txtLandAddress.Enabled = False
            Else
                txtLandAddress.Enabled = True
            End If
            txtLandAddress.Text = Obj_P3M_Reveiw.Item(0).Site_Chg_Detail
            RadioButtonList4.SelectedValue = Obj_P3M_Reveiw.Item(0).Progress_Chg
            RadioButtonList5.SelectedValue = Obj_P3M_Reveiw.Item(0).Building_Chg
            If Obj_P3M_Reveiw.Item(0).Building_Chg = 0 Then
                txtBuilding.Enabled = False
            Else
                txtBuilding.Enabled = True
            End If
            txtBuilding.Text = Obj_P3M_Reveiw.Item(0).Building_Chg_Detail
            txtLast_Appraisal_Detail.Text = Obj_P3M_Reveiw.Item(0).Appraisal_Last_Detail
            txtBuildingStartDate.Text = Obj_P3M_Reveiw.Item(0).BuildingStartDate
        Else
            txtSequence.Text = 1
        End If
    End Sub

    Private Sub Province(ByVal Pro_Id As Integer)
        Dim Obj_province As List(Of Cls_PROVINCE) = GET_PROVINCE_INFO(Pro_Id)
        lblProvinceName.Text = Obj_province.Item(0).PROV_NAME
    End Sub

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
            'Dim DS_Building As DataSet = GET_PRICE3_BUILDING_BY_ID(hdfReq_Id.Value)
            'Price_Building = DS_Building.Tables(0).Rows(0).Item("PriceTotal")
            txtBuildingPrice.Text = String.Format("{0:N2}", Price_Building)
            'If Price_Land = 0 Then
            '    Sub_Total = DS_Building.Tables(0).Rows(0).Item("PriceMarket")
            '    txtSubTotal.Text = String.Format("{0:N2}", Sub_Total)
            'Else
            Sub_Total = Price_Land + Price_Building
            txtSubTotal.Text = String.Format("{0:N2}", Sub_Total)
            'End If


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

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        lbluserid.Text = lbluserid.Text
    End Sub

    'Protected Sub ImageEditPosition_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageEditPosition.Click
    '    Dim Obj_P3M As List(Of clsPrice3_Master) = GET_PRICE3_MASTER(hdfReq_Id.Value, hdfTemp_AID.Value)
    '    If Obj_P3M.Count = 0 Then
    '        s = "<script language=""javascript"">alert('คุณต้องบันทึกข้อมูลก่อนทำการกำหนดพิกัดหลักประกัน');</script>"
    '        Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
    '    Else
    '        Dim s1 As String = Nothing
    '        s1 += "window.open('CollDetail_Edit_Position_Price3.aspx"
    '        s1 += "?Req_Id=" & hdfReq_Id.Value
    '        s1 += "&Hub_Id=" & hdfHub_Id.Value
    '        s1 += "&Temp_AID=" & hdfTemp_AID.Value
    '        ImageEditPosition.Attributes.Add("onclick", s1 & "','showMap', 'width=820, height=680');")
    '    End If
    'End Sub

    Private Sub Show_Price3_50_Find_Chanode(ByVal Req_id As Integer, ByVal Hub_id As Integer, ByVal Temp_AID As Integer)
        Dim Get_Cnt_70 As DataSet = GET_PRICE3_70_COUNT(Req_id, Hub_id, Temp_AID) 'GET_PRICE3_50_FIND_CHANODE(Req_id, Hub_id, Temp_AID)
        If Get_Cnt_70.Tables(0).Rows.Count > 0 Then
            hdfCollType.Value = "70"
            'MsgBox(hdfCollType.Value)
            lblBuilding_Detail.Text = Get_Cnt_70.Tables(0).Rows.Item(0).Item("Cnt_Building") & " รายการ"
        End If
    End Sub

    Protected Sub ImageButtonPrintPreview_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonPrintPreview.Click
        Dim Obj_P3M As List(Of clsPrice3_Master) = GET_PRICE3_MASTER(hdfReq_Id.Value, hdfTemp_AID.Value)
        If Obj_P3M.Count > 0 Then
            Context.Items("Req_Id") = hdfReq_Id.Value
            Context.Items("Hub_Id") = hdfHub_Id.Value
            Context.Items("UserId") = lblUserId.Text
            Context.Items("Temp_AID") = hdfTemp_AID.Value
            Context.Items("Cif") = lblCif.Text
            Server.Transfer("PrintPreviewPrice3Review.aspx")
        Else
            s = "<script language=""javascript"">alert('คุณต้องบันทึกข้อมูลก่อนทำการพิมพ์รายละเอียดแบบฟอร์ม');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือนการพิมพ์", s)
        End If
    End Sub
End Class
