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

        If Not Page.IsPostBack Then
            txtAID.Text = Context.Items("AID")
            lblCif.Text = Context.Items("Cif")
            hdfHub_Id.Value = Context.Items("Hub_Id")
            hdfReq_Id.Value = Context.Items("Req_Id")
            ddlUserAppraisal.SelectedValue = Context.Items("Appraisal_Id")
            hdfTemp_AID.Value = Context.Items("Temp_AID")
            hdfCollType.Value = Context.Items("CollType")
            cus_class = SV.GetCifInfo(lblCif.Text)(0)
            If cus_class.Cif.ToString <> 0 Then
                lblCifName.Text = cus_class.cifName
            Else
                'ถ้า cif ที่ส่งมาเท่ากับ 0 ให้ Clear ค่า  ในคอนโทรล
                lblCifName.Text = ""
                Dim l As New Label
                'MessageBox("Format Exception: " & ex.Message)
                l.Text = SV.MSb("ค้นหาข้อมูลลูกค้าไม่พบ ")
                Page.Controls.Add(l)
            End If

            'หาหมายเลขโฉนด
            Dim ObjP3_Review As List(Of Price3_50_Review) = GET_PRICE3_50_REVIEW(hdfReq_Id.Value, hdfHub_Id.Value, 0)
            If ObjP3_Review.Count > 0 Then
                hdfTemp_AID.Value = ObjP3_Review.Item(0).Temp_AID
                For i = 0 To ObjP3_Review.Count - 1
                    If i <= 1 Then
                        Dim ObjSubColl As List(Of Cls_SubCollType) = GET_SUBCOLLTYPE(ObjP3_Review.Item(i).MysubColl_ID)
                        lblChanode.Text = lblChanode.Text & ObjSubColl.Item(0).SubCollType_Name & ObjP3_Review.Item(i).Address_No
                        lblChanode.Text += " ตำบล " & ObjP3_Review.Item(0).Tumbon & " อำเภอ " & ObjP3_Review.Item(0).Amphur
                        Province(ObjP3_Review.Item(0).Province)
                        lblChanode.Text += "  จังหวัด " & lblProvinceName.Text
                    Else
                        lblChanode.Text = "ตามเอกสารแนบ"
                        Exit For
                    End If
                Next
            Else
                'แสดงรายละเอียดข้อมูล
                Form_Information()
            End If
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
        Dim ReceiveDate As Date = CDate(txtReceive_Date.Text)
        Dim AppraisalDate As Date = CDate(txtAppraisal_Date.Text)
        Dim Memodate As Date = CDate(txtMemo_Date.Text)
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
        'มีข้อมูลแล้วให้ Update
        If Obj_P3M_Reveiw.Count > 0 And Obj_P3M.Count > 0 Then
            'Update Table Price3_Master
            UPDATE_PRICE3_MASTER(hdfReq_Id.Value, _
                             txtAID.Text, _
                             hdfTemp_AID.Value, _
                             txtInform_To.Text, _
                             lblCif.Text, _
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
                             10, _
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
            MsgBox(RadioButtonList1.SelectedValue)
            UPDATE_PRICE3_MASTER_REVIEW(hdfReq_Id.Value, txtAID.Text, hdfTemp_AID.Value, lblCif.Text, txtBuilding_Age.Text, Memodate, txtSequence.Text, RadioButtonList1.SelectedValue, txtLandDetail.Text, _
                                     RadioButtonList2.SelectedValue, txtObligation.Text, RadioButtonList3.SelectedValue, txtLandAddress.Text, RadioButtonList4.SelectedValue, _
                                     RadioButtonList5.SelectedValue, txtBuilding.Text, txtLast_Appraisal_Detail.Text, lbluserid.Text, Now())
        Else 'ยังไม่มีข้อมูลให้ Insert
            Lat = 0
            Lng = 0
            AddPRICE3_Master(hdfReq_Id.Value, _
                 txtAID.Text, _
                 hdfTemp_AID.Value, _
                 txtInform_To.Text, _
                 lblCif.Text, _
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
                 10, _
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
            ADD_PRICE3_MASTER_REVIEW(hdfReq_Id.Value, txtAID.Text, hdfTemp_AID.Value, lblCif.Text, txtBuilding_Age.Text, Memodate, txtSequence.Text, RadioButtonList1.SelectedValue, txtLandDetail.Text, _
                                     RadioButtonList2.SelectedValue, txtObligation.Text, RadioButtonList3.SelectedValue, txtLandAddress.Text, RadioButtonList4.SelectedValue, _
                                     RadioButtonList5.SelectedValue, txtBuilding.Text, txtLast_Appraisal_Detail.Text, lbluserid.Text, Now())

        End If


        'Server.Transfer("Appraisal_Price3_List.aspx")
        'Else
        's = "<script language=""javascript"">alert('ไม่มีเลขที่คำขอนี้ หรือ ไม่มีการกำหนด Lat Lng อยู่ในระบบ');</script>"
        'Page.ClientScript.RegisterStartupScript(Me.GetType, "ผิดพลาด", s)
        'End If
    End Sub

    Private Sub Form_Information()
        Dim Op3_50r As List(Of Price3_50_Review) = GET_PRICE3_50_REVIEW(hdfReq_Id.Value, hdfHub_Id.Value, 0)
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
            ddlApprove2.SelectedValue = Obj_P3M.Item(0).Approved2
            ddlApprove3.SelectedValue = Obj_P3M.Item(0).Approved3
            ddlAppraisal_Type.SelectedValue = Obj_P3M.Item(0).Appraisal_Type_ID
            txtLandTotal.Text = String.Format("{0:N2}", Obj_P3M.Item(0).TotalPrice)
            txtBuildingPrice.Text = String.Format("{0:N2}", Obj_P3M.Item(0).BuildingPrice)
            txtSubTotal.Text = String.Format("{0:N2}", Obj_P3M.Item(0).Land_Building_Price)
            txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtLandTotal.Text) + CDec(txtBuildingPrice.Text) + CDec(txtSubTotal.Text))

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
                Price3_50_Review(Obj_P3M.Item(0).Appraisal_Type_ID)
                Price3_70_Review(Obj_P3M.Item(0).Appraisal_Type_ID)
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

        Dim Amount As Decimal = Age * (P1 + P2 + P3)
        Return String.Format("{0:N2}", Amount)

    End Function

    Function Get_Amount_Bht(ByVal Price As Decimal, ByVal Age As Decimal, ByVal P1 As Decimal, ByVal P2 As Decimal, ByVal P3 As Decimal) As String

        Dim Amount_Price As Decimal = Price * (((P1 + P2 + P3) * Age) / 100)
        Return String.Format("{0:N2}", Amount_Price)

    End Function

    Function Get_Balance(ByVal Price As Decimal, ByVal Age As Decimal, ByVal P1 As Decimal, ByVal P2 As Decimal, ByVal P3 As Decimal) As String

        Dim Amount_Price As Decimal = Price - (Price * (((P1 + P2 + P3) * Age) / 100))
        total += Amount_Price
        Return String.Format("{0:N2}", Amount_Price)
        MsgBox(total)
    End Function

    Function Get_Total() As String
        'txtBuildingPrice.Text = String.Format("{0:N2}", total)
        txtBuildingPrice.Text = String.Format("{0:N2}", Round(((total) / 1000), 0) * 1000)
        'txtSubTotal.Text = String.Format("{0:N2}", CDec(txtLandTotal.Text) + CDec(txtBuildingPrice.Text))
        'If ddlAppraisal_Type.SelectedValue = 1 Then
        '    txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtSubTotal.Text))
        'Else
        '    txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtLandTotal.Text) + CDec(txtBuildingPrice.Text))
        'End If

        'txtGrandTotal_Round.Text = String.Format("{0:N2}", Round(((CDec(txtLandTotal.Text) + CDec(txtBuildingPrice.Text)) / 1000), 0) * 1000)
        'txtGrandTotal_Round.Text = String.Format("{0:N2}", Round(CDec(txtLandTotal.Text) + CDec(txtBuildingPrice.Text), -3, MidpointRounding.AwayFromZero))



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
            DS = CreateDataset(50, "PRICE3_50_REVIEW")
            If DS.Tables(0).Rows.Item(0).Item("CntID") > 0 Then
                lblPriceWah.Text = "0.00"
                txtLandTotal.Text = "0.00"
                txtSubTotal.Text = String.Format("{0:N2}", DS.Tables(0).Rows.Item(0).Item("PriceTotal1"))
            End If
            DS = CreateDataset(70, "PRICE3_70_REVIEW")
            If DS.Tables(0).Rows.Item(0).Item("CntID") > 0 Then
                'txtBuildingPrice.Text = String.Format("{0:N2}", DS.Tables(0).Rows.Item(0).Item("BuildingPrice"))
                txtSubTotal.Text = String.Format("{0:N2}", DS.Tables(0).Rows.Item(0).Item("PriceTotal1"))
            End If
            txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtSubTotal.Text))
        Else
            'วิธีทุน
            'Dim B_Price As Decimal
            DS = CreateDataset(50, "PRICE3_50_REVIEW")
            If DS.Tables(0).Rows.Item(0).Item("CntID") > 0 Then
                lblPriceWah.Text = Format(DS.Tables(0).Rows.Item(0).Item("PriceTotal1") / DS.Tables(0).Rows.Item(0).Item("Totalwah"), "#,##0.00")
                txtLandTotal.Text = String.Format("{0:N2}", DS.Tables(0).Rows.Item(0).Item("PriceTotal1"))
            End If
            '
            DS = CreateDataset(70, "PRICE3_70_REVIEW")
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
            txtBuilding_Age.Text = Obj_18R.Item(0).Building_Age
            Repeater1.Visible = False
            txtAID.Text = Obj_18R.Item(0).AID
            lblBuySaleState_Name.Text = Obj_BuysaleState.Item(0).BuySale_State_Name
            lblDistrict.Text = Obj_18R.Item(0).Tumbon1
            lblAmphur.Text = Obj_18R.Item(0).Amphur1
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
        DS = CreateDataset(50, "PRICE3_50_REVIEW")
        If DS.Tables(0).Rows.Item(0).Item("CntID") > 0 Then
            hdfTemp_AID.Value = DS.Tables(0).Rows.Item(0).Item("Temp_AID")
            If DS.Tables(0).Rows.Item(0).Item("Rai") = 0 And DS.Tables(0).Rows.Item(0).Item("Ngan") = 0 Then
                lblLandArea.Text = "0" & "-" & "0" & "-" & DS.Tables(0).Rows.Item(0).Item("TotalWah")
                lblSize.Text = "0" & "-" & "0" & "-" & DS.Tables(0).Rows.Item(0).Item("TotalWah")
            Else
                lblLandArea.Text = DS.Tables(0).Rows.Item(0).Item("Rai") & "-" & DS.Tables(0).Rows.Item(0).Item("Ngan") & "-" & DS.Tables(0).Rows.Item(0).Item("Wah")
                lblSize.Text = DS.Tables(0).Rows.Item(0).Item("Rai") & "-" & DS.Tables(0).Rows.Item(0).Item("Ngan") & "-" & DS.Tables(0).Rows.Item(0).Item("Wah")
            End If

            Dim Obj_SubUnit As List(Of Cls_SubUnit) = GET_SubUnit_Info(DS.Tables(0).Rows.Item(0).Item("SubUnit_Id"))
            lblSubUnit.Text = Obj_SubUnit.Item(0).SubUnit_Name
            If Appraisal_Type_ID = 1 Then
                lblPriceWah.Text = "0.00"
            Else
                lblPriceWah.Text = String.Format("{0:N2}", DS.Tables(0).Rows.Item(0).Item("PriceWah"))
            End If

            'lblPriceWah.Text = Format(DS.Tables(0).Rows.Item(0).Item("PriceTotal1") / DS.Tables(0).Rows.Item(0).Item("Totalwah"), "#,##0.00")  'Format(DS.Tables(0).Rows.Item(0).Item("PriceWah"), "#,##0.00") & " บาท"
            'txtLandTotal.Text = Format(DS.Tables(0).Rows.Item(0).Item("PriceTotal1"), "#,##0.00")
            Dim OjbColour As List(Of Cls_Area_Colour) = GET_AREA_COLOUR_INFO(DS.Tables(0).Rows.Item(0).Item("AreaColour_No"))
            lblAreaColour.Text = OjbColour.Item(0).AreaColour_Name
            Dim Obj_BuysaleState As List(Of Cls_Buy_Sale_State) = GET_BUYSALE_STATE_INFO(DS.Tables(0).Rows.Item(0).Item("AreaColour_No"))
            lblBuySaleState_Name.Text = Obj_BuysaleState.Item(0).BuySale_State_Name
        Else
            'DS = CreateDataset(50, "PRICE3_50")
            'lblPriceWah.Text = Format(0, "#,##0.00")
            'txtLandTotal.Text = Format(0, "#,##0.00")
            'Dim Obj_SubUnit As List(Of Cls_SubUnit) = GET_SubUnit_Info(DS.Tables(0).Rows.Item(0).Item("SubUnit_Id"))
            'lblSubUnit.Text = Obj_SubUnit.Item(0).SubUnit_Name
        End If
    End Sub

    Private Sub Price3_70_Review(ByVal Appraisal_Type_ID As Integer)
        Dim DS As DataSet
        'หาเนื้อที่รวมสิ่งปลูกสร้าง
        DS = CreateDataset(70, "PRICE3_70_REVIEW")
        If DS.Tables(0).Rows.Item(0).Item("CntID") > 0 Then
            'If hdfTemp_AID.Value = String.Empty Then
            '    hdfTemp_AID.Value = DS.Tables(0).Rows.Item(0).Item("Temp_AID")
            'End If
            lblBuilding_Detail.Text = "1 รายการ"
            ddlInteriorState.SelectedValue = DS.Tables(0).Rows.Item(0).Item("District")
            If Not IsDBNull(DS.Tables(0).Rows.Item(0).Item("BuildingArea")) Then
                lblDistrict.Text = DS.Tables(0).Rows.Item(0).Item("District")
                lblAmphur.Text = DS.Tables(0).Rows.Item(0).Item("Amphur")
                'Dim Obj_province As List(Of Cls_PROVINCE) = GET_PROVINCE_INFO(DS.Tables(0).Rows.Item(0).Item("Province"))
                'lblProvinceName.Text = Obj_province.Item(0).PROV_NAME
                Province(DS.Tables(0).Rows.Item(0).Item("Province"))
                ddlInteriorState.SelectedValue = DS.Tables(0).Rows.Item(0).Item("Decoration")

            End If
            If Appraisal_Type_ID = 1 Then
                txtSubTotal.Text = String.Format("{0:N2}", DS.Tables(0).Rows.Item(0).Item("PriceTotal1"))
            Else
                txtSubTotal.Text = "0.00"
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
            ddlApprove2.SelectedValue = Obj_P3M.Item(0).Approved2
            ddlApprove3.SelectedValue = Obj_P3M.Item(0).Approved3
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
            'txtLandTotal.Text = Format(DS.Tables(0).Rows.Item(0).Item("PriceTotal1"), "#,##0.00")
            txtGrandTotal.Text = String.Format("{0:N2}", CDec(txtLandTotal.Text) + CDec(txtBuildingPrice.Text))
        Else
            txtSequence.Text = 1
        End If
    End Sub

    Private Sub Province(ByVal Pro_Id As Integer)
        Dim Obj_province As List(Of Cls_PROVINCE) = GET_PROVINCE_INFO(Pro_Id)
        lblProvinceName.Text = Obj_province.Item(0).PROV_NAME
    End Sub
End Class
