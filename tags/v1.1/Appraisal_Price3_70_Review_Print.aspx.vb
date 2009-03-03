Imports Appraisal_Manager
Partial Class Appraisal_Price3_70_Review_Print
    Inherits System.Web.UI.Page

    Dim total As Decimal
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            '********* Data Test **************
            'HiddenField1.Value = 5
            'HiddenField2.Value = 1
            'HiddenField3.Value = 4029

            'HiddenField4.Value = 103
            '**********************************

            Hdf_ID.Value = CInt(Context.Items("ID"))
            HdfReq_Id.Value = CInt(Context.Items("Req_Id"))
            HdfHub_Id.Value = CInt(Context.Items("Hub_Id"))
            HdfTemp_AID.Value = CInt(Context.Items("Temp_AID"))
            HdfUser_ID.Value = CStr(Context.Items("User_ID"))

            Show_Price3_70_Review()
            Show_Price3_70Main()
            Show_Price3_70_Detail()
        End If

    End Sub

    Private Sub Show_Price3_70_Review()
        Dim Obj_GetP70 As List(Of Price3_70_Review) = GET_PRICE3_70_REVIEW(HdfReq_Id.Value, HdfHub_Id.Value, Hdf_ID.Value)
        If Obj_GetP70.Count > 0 Then
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

        End If
    End Sub

    Private Sub Show_Price3_70Main()

        Dim Obj_P3_70 As List(Of Price3_70_Review) = GET_PRICE3_70_REVIEW(Hdf_ID.Value, HdfReq_Id.Value, HdfHub_Id.Value)
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

        Dim Obj_P3_70D As List(Of ClsPrice3_70_Detail) = GET_PRICE3_70_DETAIL_REVIEW(Hdf_ID.Value, HdfReq_Id.Value, HdfHub_Id.Value, HdfTemp_AID.Value, 0)
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
        MsgBox(total)
    End Function

    Function Get_Total() As String
        lblGrandTotal0.Text = String.Format("{0:N2}", total)
        'lblGrantotal.Text = String.Format("{0:N2}", CDec(lblLandTotal.Text) + CDec(lblBuildingPrice.Text))
        'lblGrandTotal0.Text = String.Format("{0:N2}", CDec(lblLandTotal.Text) + CDec(lblBuildingPrice.Text))
        Return String.Format("{0:N2}", total)

    End Function
End Class
