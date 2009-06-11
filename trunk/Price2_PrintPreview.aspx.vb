Option Explicit On
'Option Strict On

Imports Appraisal_Manager
Imports System.Xml.Serialization
Imports System.Xml
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Win32
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Text
Imports SME_SERVICE
Imports ThaiBaht

Partial Class Price2_PrintPreview
    Inherits System.Web.UI.Page
    Private Itemsddl As List(Of Dropdown_Pro)
    Private QID As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim ObjP2_18 As List(Of PRICE2_18) = GET_PRICE2_18_FOR_PRINT(Context.Items("Req_Id"), Context.Items("Hub_Id"))
            If ObjP2_18.Count > 0 Then
                Dim ObjSubColl As List(Of Cls_SubCollType) = GET_SUBCOLLTYPE(ObjP2_18.Item(0).MysubColl_ID)
                lblCollTypeName.Text = ObjSubColl.Item(0).SubCollType_Name
                lblAddno.Text = ObjP2_18.Item(0).Address_No
                lblTumbon.Text = ObjP2_18.Item(0).Tumbon
                lblAmphur.Text = ObjP2_18.Item(0).Amphur
                Dim ObjProvince As List(Of Cls_PROVINCE) = GET_PROVINCE_INFO(ObjP2_18.Item(0).Province)
                lblProvinceName.Text = ObjProvince.Item(0).PROV_NAME
                lblSizeAll.Text = ObjP2_18.Item(0).Room_Area
                'lblSize.Text = ObjP2_18.Item(0).Room_Area
                lblRoad.Text = ObjP2_18.Item(0).Road
                Dim ObjRoadDetail As List(Of Cls_Road_Detail) = GET_ROAD_DETAIL_INFO(ObjP2_18.Item(0).Road_Detail)
                lblRoad_Detail.Text = ObjRoadDetail.Item(0).Road_Detail_Name
                lblMeter.Text = ObjP2_18.Item(0).Road_Access
                'Dim ObjLandState As List(Of Cls_LandState) = GET_LANDSTATE_INFO(ObjP2_18.Item(0).)
                lblLand_State.Text = "-"
                'lblLand_State_Detail.Text = ObjP2_18.Item(0).Land_State_Detail
                Dim ObjRoad_FrontOff As List(Of Cls_RoadFrontOff) = GET_ROADFRONTOFF_INFO(ObjP2_18.Item(0).Road_Frontoff)
                lblRoad_Forntoff.Text = ObjRoad_FrontOff.Item(0).Road_Frontoff_Name
                lblRoadWidth.Text = ObjP2_18.Item(0).RoadWidth
                Dim ObjSite As List(Of Cls_SITE) = GET_SITE_INFO(ObjP2_18.Item(0).Site)
                lblSite.Text = ObjSite.Item(0).Site_Name
                lblSite_Detail.Text = ObjP2_18.Item(0).Site_Detail
                Dim ObjBinifit As List(Of Cls_BINIFIT) = GET_BINIFIT_INFO(ObjP2_18.Item(0).Binifit)
                lblBinifit.Text = ObjBinifit.Item(0).Binifit_Name
                lblBinifit_Detail.Text = ObjP2_18.Item(0).Binifit_Detail
                Dim ObjTendency As List(Of Cls_TENDENCY) = GET_TENDENCY_INFO(ObjP2_18.Item(0).Tendency)
                lblTendency.Text = ObjTendency.Item(0).Tendency_Name
                Dim ObjPublic As List(Of Cls_Public_Utility) = GET_PUBLIC_UTILITY_INFO(ObjP2_18.Item(0).Public_Utility)
                lbllPublic_Utility.Text = ObjPublic.Item(0).Public_Utility_Name
                Dim ObjBuysal As List(Of Cls_Buy_Sale_State) = GET_BUYSALE_STATE_INFO(ObjP2_18.Item(0).BuySale_State)
                lblBuySale_State.Text = ObjBuysal.Item(0).BuySale_State_Name

                'lblPriceWah.Text = String.Format("{0:N2}", ObjP2_18.Item(0).Unit_Price)
                lblPriceItem1.Text = String.Format("{0:N2}", ObjP2_18.Item(0).PriceTotal)
                'lblPriceItem2.Text = String.Format("{0:N2}", ObjP2_18.Item(0).PriceTotal)
                'lblGrandTotal.Text = CDec(lblPriceItem1.Text) + CDec(lblPriceItem2.Text) + CDec(lblTotal1.Text) + CDec(lblTotal2.Text) + CDec(lblTotal3.Text)
            End If
            Dim ObjP2_50 As List(Of PRICE2_50) = GET_PRICE2_50_FOR_PRINT(Context.Items("Req_Id"), Context.Items("Hub_Id"))
            If ObjP2_50.Count > 0 Then
                Dim ObjSubColl As List(Of Cls_SubCollType) = GET_SUBCOLLTYPE(ObjP2_50.Item(0).MysubColl_ID)
                lblCollTypeName.Text = ObjSubColl.Item(0).SubCollType_Name
                lblAddno.Text = ObjP2_50.Item(0).Address_No
                lblTumbon.Text = ObjP2_50.Item(0).Tumbon
                lblAmphur.Text = ObjP2_50.Item(0).Amphur
                Dim ObjProvince As List(Of Cls_PROVINCE) = GET_PROVINCE_INFO(ObjP2_50.Item(0).Province)
                lblProvinceName.Text = ObjProvince.Item(0).PROV_NAME
                lblSizeAll.Text = ObjP2_50.Item(0).Rai & "-" & ObjP2_50.Item(0).Ngan & "-" & ObjP2_50.Item(0).Wah
                lblSize.Text = ObjP2_50.Item(0).Rai & "-" & ObjP2_50.Item(0).Ngan & "-" & ObjP2_50.Item(0).Wah
                lblRoad.Text = ObjP2_50.Item(0).Road
                Dim ObjRoadDetail As List(Of Cls_Road_Detail) = GET_ROAD_DETAIL_INFO(ObjP2_50.Item(0).Road_Detail)
                lblRoad_Detail.Text = ObjRoadDetail.Item(0).Road_Detail_Name
                lblMeter.Text = ObjP2_50.Item(0).Road_Access
                Dim ObjLandState As List(Of Cls_LandState) = GET_LANDSTATE_INFO(ObjP2_50.Item(0).Land_State)
                lblLand_State.Text = ObjLandState.Item(0).Land_State_Name
                lblLand_State_Detail.Text = ObjP2_50.Item(0).Land_State_Detail
                Dim ObjRoad_FrontOff As List(Of Cls_RoadFrontOff) = GET_ROADFRONTOFF_INFO(ObjP2_50.Item(0).Road_Frontoff)
                lblRoad_Forntoff.Text = ObjRoad_FrontOff.Item(0).Road_Frontoff_Name
                lblRoadWidth.Text = ObjP2_50.Item(0).RoadWidth
                Dim ObjSite As List(Of Cls_SITE) = GET_SITE_INFO(ObjP2_50.Item(0).Site)
                lblSite.Text = ObjSite.Item(0).Site_Name
                lblSite_Detail.Text = ObjP2_50.Item(0).Site_Detail
                Dim ObjBinifit As List(Of Cls_BINIFIT) = GET_BINIFIT_INFO(ObjP2_50.Item(0).Binifit)
                lblBinifit.Text = ObjBinifit.Item(0).Binifit_Name
                lblBinifit_Detail.Text = ObjP2_50.Item(0).Binifit_Detail
                Dim ObjTendency As List(Of Cls_TENDENCY) = GET_TENDENCY_INFO(ObjP2_50.Item(0).Tendency)
                lblTendency.Text = ObjTendency.Item(0).Tendency_Name
                Dim ObjPublic As List(Of Cls_Public_Utility) = GET_PUBLIC_UTILITY_INFO(ObjP2_50.Item(0).Public_Utility)
                lbllPublic_Utility.Text = ObjPublic.Item(0).Public_Utility_Name
                Dim ObjBuysal As List(Of Cls_Buy_Sale_State) = GET_BUYSALE_STATE_INFO(ObjP2_50.Item(0).BuySale_State)
                lblBuySale_State.Text = ObjBuysal.Item(0).BuySale_State_Name

                lblPriceWah.Text = String.Format("{0:N2}", ObjP2_50.Item(0).PriceWah)
                lblTotal1.Text = String.Format("{0:N2}", ObjP2_50.Item(0).PriceTotal1)
                lblPriceItem1.Text = String.Format("{0:N2}", ObjP2_50.Item(0).PriceTotal1)
            End If
            Dim ObjP2_70 As List(Of PRICE2_70) = GET_PRICE2_70_FOR_PRINT(Context.Items("Req_Id"), Context.Items("Hub_Id"))
            If ObjP2_70.Count > 0 Then
                Dim ObjBuilding_Cons As List(Of Cls_Build_Construct) = GET_Build_Construct(ObjP2_70.Item(0).Build_Construct)
                lblBuild_Construct.Text = ObjBuilding_Cons.Item(0).Build_Construct_Name
                lblBuild_No.Text = ObjP2_70.Item(0).Build_No
                Dim ObjSubColl70 As List(Of Cls_SubCollType) = GET_SUBCOLLTYPE(ObjP2_70.Item(0).MysubColl_ID)
                lblBuild_Character.Text = ObjSubColl70.Item(0).SubCollType_Name
                Dim ObjRoof As List(Of Cls_Roof) = GET_Roof(ObjP2_70.Item(0).Roof)
                lblRoof.Text = ObjRoof.Item(0).Roof_Name

                lblTotal2.Text = String.Format("{0:N2}", ObjP2_70.Item(0).PriceTotal1)
                chkDoc1.Checked = ObjP2_70.Item(0).Doc1
                chkDoc2.Checked = ObjP2_70.Item(0).Doc2
                lblDocument_Detail.Text = ObjP2_70.Item(0).Doc_Detail
            End If

            Dim ObjP2_Master As List(Of Price2_Master) = GET_PRICE2_MASTER(Context.Items("Req_Id"), Context.Items("Hub_Id"))
            If ObjP2_Master.Count > 0 Then
                lblCif.Text = ObjP2_Master.Item(0).Cif
                Dim cus_class As Customer_Class
                Dim SV As New SME_SERVICE.Service

                cus_class = SV.GetCifInfo(ObjP2_Master.Item(0).Cif)(0)
                'ถ้า cif ที่ส่งมาไม่เท่ากับ 0 ให้ใส่ข้อมูลลูกค้าใส่ในคอนโทรลที่กำหนดให้
                If cus_class.Cif.ToString <> 0 Then
                    lblCifName.Text = cus_class.cifName '& cus_class.cus_first & "  " & cus_class.cus_last
                End If

                Dim Emp As Employee_Info
                Emp = SV.GetEmployee_Info(ObjP2_Master.Item(0).Appraisal_Id)(0)
                If Emp.EmpId > 0 Then
                    lblAppraisalName.Text = Emp.EmpName
                End If
                lblGrandTotal.Text = CDec(lblPriceItem1.Text) + CDec(lblPriceItem2.Text) + CDec(lblTotal1.Text) + CDec(lblTotal2.Text) + CDec(lblTotal3.Text)
                lblThaiBaht.Text = ThaiBahtFun(lblGrandTotal.Text)
            End If
            Session("ctrl") = Panel1
        End If
    End Sub

    Private Function CreateDataset() As DataSet

        'For Print Data Out
        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        MyConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)

        MyDataAdapter = New SqlDataAdapter("GET_PRICE2_PRINT", MyConnection)
        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Q_ID", SqlDbType.Int))
        MyDataAdapter.SelectCommand.Parameters("@Q_ID").Value = QID

        DS = New DataSet() 'Create a new DataSet to hold the records.
        MyDataAdapter.Fill(DS, "GET_PRICE2_PRINT") 'Fill the DataSet with the rows returned.
        Return DS

    End Function

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim ctrl As Control = CType(Session("ctrl"), Control)
        PrintHelper.PrintWebControl(ctrl)
    End Sub
End Class
