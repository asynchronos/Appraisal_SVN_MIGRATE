Imports Appraisal_Manager
Imports System.Math
Partial Class Appraisal_Price3_Print_CollType70_New
    Inherits System.Web.UI.Page
    Dim total As Decimal
    Dim total1 As Decimal
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            '********* Data Test **************
            'HiddenField1.Value = 5
            'HiddenField2.Value = 1
            'HiddenField3.Value = 4029
            'HiddenField4.Value = 103
            '**********************************

            HiddenField1.Value = CInt(Context.Items("ID"))
            HiddenField2.Value = CInt(Context.Items("Req_Id"))
            HiddenField3.Value = CInt(Context.Items("Hub_Id"))
            HiddenField4.Value = CInt(Context.Items("Temp_AID"))
            HiddenField5.Value = CStr(Context.Items("User_ID"))
            'แสดงออกเป็นฟอร์มจากราคาที่ 3 (เดิมใช้อยู่)
            Show_Price3_70()
            Show_Price3_70_Detail()

            'Show_Price2_70_NEW()
            'Show_Price2_70_NEW_Detail()
        End If

    End Sub

    Private Sub Show_Price2_70_NEW()
        Dim Obj_GetP70 As List(Of Price2_70_New) = GET_PRICE2_70_NEW(HiddenField1.Value, HiddenField2.Value, HiddenField3.Value)
        If Obj_GetP70.Count > 0 Then
            Dim Obj_AR As List(Of Appraisal_Request) = GET_APPRAISAL_REQUEST(HiddenField2.Value)
            If Obj_AR.Count > 0 Then
                lblCif.Text = Obj_AR.Item(0).Cif
                Dim Obj_Title As List(Of Cls_Title) = GET_TITLE_INFO(Obj_AR.Item(0).Title)
                If Obj_Title.Count > 0 Then
                    lblCifName.Text = Obj_Title.Item(0).TITLE_NAME & Obj_AR.Item(0).Name & "  " & Obj_AR.Item(0).Lastname
                Else
                    lblCifName.Text = "คุณ" & Obj_AR.Item(0).Name & "  " & Obj_AR.Item(0).Lastname
                End If
            Else
            End If
            lblAddressNo.Text = Obj_GetP70.Item(0).Build_No
            lbChanodeNo.Text = Obj_GetP70.Item(0).Put_On_Chanode
            If Obj_GetP70.Item(0).MysubColl_ID = 6 Or Obj_GetP70.Item(0).MysubColl_ID = 7 Then
                CheckBox3.Checked = True

            ElseIf Obj_GetP70.Item(0).MysubColl_ID = 8 Then
                CheckBox2.Checked = True

            ElseIf Obj_GetP70.Item(0).MysubColl_ID = 9 Then
                CheckBox1.Checked = True

            Else
                CheckBox4.Checked = True
            End If
            lblTumbon.Text = Obj_GetP70.Item(0).Tumbon
            lblAmphur.Text = Obj_GetP70.Item(0).Amphur
            Dim obj_Province As List(Of Cls_PROVINCE) = GET_PROVINCE_INFO(Obj_GetP70.Item(0).Province)
            lblProvinceName.Text = obj_Province.Item(0).PROV_NAME

            Literal1.Text = Obj_GetP70.Item(0).BuildingDetail
            'lblArea.Text = Obj_P3_70.Item(0).BuildingArea
            If CheckBox1.Checked = True Then
                lblFloors1.Text = Obj_GetP70.Item(0).Floors
                'lblBuildingFloors.Text = CheckBox1.Text & " " & lblFloors1.Text
            ElseIf CheckBox2.Checked = True Then
                lblFloors0.Text = Obj_GetP70.Item(0).Floors
                'lblBuildingFloors.Text = CheckBox2.Text & " " & lblFloors0.Text
            ElseIf CheckBox3.Checked = True Then
                lblFloors.Text = Obj_GetP70.Item(0).Floors
                'lblBuildingFloors.Text = CheckBox3.Text & " " & lblFloors.Text
            ElseIf CheckBox4.Checked = True Then

            End If

            CheckBox5.Checked = False
            CheckBox6.Checked = False
            CheckBox7.Checked = False
            Select Case Obj_GetP70.Item(0).Decoration
                Case "1"
                    CheckBox5.Checked = True
                Case "2"
                    CheckBox6.Checked = True
                Case "3"
                    CheckBox7.Checked = True
            End Select
            lblItems.Text = Obj_GetP70.Count

        End If
    End Sub

    Private Sub Show_Price2_70_NEW_Detail()

        Dim Obj_P3_70D As List(Of Cls_Price2_70_Detail) = GET_PRICE2_70_DETAIL(HiddenField1.Value, HiddenField2.Value, HiddenField3.Value, HiddenField4.Value, 0)
        If Obj_P3_70D.Count > 0 Then
            lblBuilding_Struc.Text = Obj_P3_70D.Item(0).Main_Construction
        End If

    End Sub

    Private Sub Show_Price3_70()
        Dim Obj_GetP70 As List(Of Price3_70) = GET_PRICE3_70(HiddenField1.Value, HiddenField2.Value, HiddenField3.Value, HiddenField4.Value)
        If Obj_GetP70.Count > 0 Then
            Dim Obj_AR As List(Of Appraisal_Request) = GET_APPRAISAL_REQUEST(HiddenField2.Value)
            If Obj_AR.Count > 0 Then
                lblCif.Text = Obj_AR.Item(0).Cif
                Dim Obj_Title As List(Of Cls_Title) = GET_TITLE_INFO(Obj_AR.Item(0).Title)
                If Obj_Title.Count > 0 Then
                    lblCifName.Text = Obj_Title.Item(0).TITLE_NAME & Obj_AR.Item(0).Name & "  " & Obj_AR.Item(0).Lastname
                Else
                    lblCifName.Text = "คุณ" & Obj_AR.Item(0).Name & "  " & Obj_AR.Item(0).Lastname
                End If
            Else
            End If
            lblAddressNo.Text = Obj_GetP70.Item(0).Build_No
            lbChanodeNo.Text = Obj_GetP70.Item(0).Put_On_Chanode
            If Obj_GetP70.Item(0).MysubColl_ID = 6 Or Obj_GetP70.Item(0).MysubColl_ID = 7 Then
                CheckBox3.Checked = True

            ElseIf Obj_GetP70.Item(0).MysubColl_ID = 8 Then
                CheckBox2.Checked = True

            ElseIf Obj_GetP70.Item(0).MysubColl_ID = 9 Then
                CheckBox1.Checked = True

            Else
                CheckBox4.Checked = True
            End If
            lblTumbon.Text = Obj_GetP70.Item(0).Tumbon
            lblAmphur.Text = Obj_GetP70.Item(0).Amphur
            Dim obj_Province As List(Of Cls_PROVINCE) = GET_PROVINCE_INFO(Obj_GetP70.Item(0).Province)
            lblProvinceName.Text = obj_Province.Item(0).PROV_NAME

            Literal1.Text = Obj_GetP70.Item(0).BuildingDetail
            'lblArea.Text = Obj_P3_70.Item(0).BuildingArea
            If CheckBox1.Checked = True Then
                lblFloors1.Text = Obj_GetP70.Item(0).Floors
                'lblBuildingFloors.Text = CheckBox1.Text & " " & lblFloors1.Text
            ElseIf CheckBox2.Checked = True Then
                lblFloors0.Text = Obj_GetP70.Item(0).Floors
                'lblBuildingFloors.Text = CheckBox2.Text & " " & lblFloors0.Text
            ElseIf CheckBox3.Checked = True Then
                lblFloors.Text = Obj_GetP70.Item(0).Floors
                'lblBuildingFloors.Text = CheckBox3.Text & " " & lblFloors.Text
            ElseIf CheckBox4.Checked = True Then

            End If

            CheckBox5.Checked = False
            CheckBox6.Checked = False
            CheckBox7.Checked = False
            Select Case Obj_GetP70.Item(0).Decoration
                Case "1"
                    CheckBox5.Checked = True
                Case "2"
                    CheckBox6.Checked = True
                Case "3"
                    CheckBox7.Checked = True
            End Select
            lblItems.Text = Obj_GetP70.Count

        End If
    End Sub

    Private Sub Show_Price3_70Main()

        Dim Obj_P3_70 As List(Of Price3_70) = GET_PRICE3_70(HiddenField1.Value, HiddenField2.Value, HiddenField3.Value, HiddenField4.Value)
        If Obj_P3_70.Count > 0 Then
            Literal1.Text = Obj_P3_70.Item(0).BuildingDetail
            'lblArea.Text = Obj_P3_70.Item(0).BuildingArea
            If CheckBox1.Checked = True Then
                lblFloors1.Text = Obj_P3_70.Item(0).Floors
                'lblBuildingFloors.Text = CheckBox1.Text & " " & lblFloors1.Text
            ElseIf CheckBox2.Checked = True Then
                lblFloors0.Text = Obj_P3_70.Item(0).Floors
                'lblBuildingFloors.Text = CheckBox2.Text & " " & lblFloors0.Text
            ElseIf CheckBox3.Checked = True Then
                lblFloors.Text = Obj_P3_70.Item(0).Floors
                'lblBuildingFloors.Text = CheckBox3.Text & " " & lblFloors.Text
            ElseIf CheckBox4.Checked = True Then

            End If
            lblItems.Text = Obj_P3_70.Count
        End If

    End Sub

    Private Sub Show_Price3_70_Detail()

        Dim Obj_P3_70D As List(Of ClsPrice3_70_Detail) = GET_PRICE3_70_DETAIL(HiddenField1.Value, HiddenField2.Value, HiddenField3.Value, HiddenField4.Value, 0)
        If Obj_P3_70D.Count > 0 Then
            lblBuilding_Struc.Text = Obj_P3_70D.Item(0).Main_Construction
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
        'MsgBox(total)
    End Function

    Function Get_Balance1(ByVal Price As Decimal, ByVal Age As Decimal, ByVal P1 As Decimal, ByVal P2 As Decimal, ByVal P3 As Decimal) As String
        'ราคาปัจจุบัน
        Dim Amount_Price As Decimal = Price - (Price * (((P1 + P2 + P3) * Age) / 100))
        total1 += Amount_Price
        Return String.Format("{0:N2}", Amount_Price)
        'MsgBox(total)
    End Function

    Function Get_Total() As String
        lblGrandTotal0.Text = String.Format("{0:N2}", Round(((total) / 1000), 0) * 1000)
        Return String.Format("{0:N2}", total)
    End Function

    Function Get_Total1() As String
        lblGrandTotal0.Text = String.Format("{0:N2}", Round(((total1) / 1000), 0) * 1000)
        Return String.Format("{0:N2}", total1)
    End Function
End Class
