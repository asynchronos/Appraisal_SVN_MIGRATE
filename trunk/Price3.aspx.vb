Option Explicit On
Option Strict On

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

Partial Class Price3
    Inherits System.Web.UI.Page
    Dim Price3 As Price2_ShortForm
    Dim count As Integer
    Dim DS As DataSet

    Protected Sub form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load
        If Not Page.IsPostBack Then
            '**************For Use*******
            'lblQueueID.Text = Request.QueryString("Qid")
            'lblCif.Text = Request.QueryString("Cif")
            '*********************************************

            '**************For TEST*******
            lblQueueID.Text = "1"
            lblCif.Text = "18"
            '*********************************************

            'Price3 = Appraisal_Manager.GetPrice2(CInt(lblQueueID.Text))(0)
            DS = CreateDataset()
            If DS.Tables(0).Rows.Count > 0 Then
                lblCif.Text = DS.Tables(0).Rows.Item(0).Item("cif").ToString
                lblCifName.Text = DS.Tables(0).Rows.Item(0).Item("cifname").ToString
                'lblCollTypeName.Text = DS.Tables(0).Rows.Item(0).Item("SubCollType_Name")
                'lblBranchname.Text = DS.Tables(0).Rows.Item(0).Item("DepartName")
                lblChanode_No.Text = DS.Tables(0).Rows.Item(0).Item("Address_No").ToString
                lblTumbon.Text = DS.Tables(0).Rows.Item(0).Item("tumbon").ToString
                lblAmphur.Text = DS.Tables(0).Rows.Item(0).Item("Amphur").ToString
                lblProvince.Text = DS.Tables(0).Rows.Item(0).Item("Prov_Name").ToString
                lblRai.Text = DS.Tables(0).Rows.Item(0).Item("rai").ToString
                lblNgan.Text = DS.Tables(0).Rows.Item(0).Item("Ngan").ToString
                lblWah.Text = DS.Tables(0).Rows.Item(0).Item("wah").ToString
                lblRoad.Text = DS.Tables(0).Rows.Item(0).Item("road").ToString
                lblRoadAccess_Detail.Text = DS.Tables(0).Rows.Item(0).Item("road_Detail_Name").ToString
                lblMeter_Access.Text = DS.Tables(0).Rows.Item(0).Item("Road_Access").ToString
                lblRoadState.Text = DS.Tables(0).Rows.Item(0).Item("Road_Frontoff_Name").ToString
                lblLandState.Text = DS.Tables(0).Rows.Item(0).Item("Land_State_Name").ToString
                lblLandState_Detail.Text = DS.Tables(0).Rows.Item(0).Item("Land_State_Detail").ToString
                lblLandState_Detail.Text = DS.Tables(0).Rows.Item(0).Item("Land_State_Detail").ToString
                lblSiteName.Text = Trim(DS.Tables(0).Rows.Item(0).Item("Site_Name").ToString)
                lblBenifitName.Text = DS.Tables(0).Rows.Item(0).Item("binifit_Name").ToString
                lblTendency_Name.Text = DS.Tables(0).Rows.Item(0).Item("Tendency_Name").ToString
                lblBuySale_StateName.Text = Trim(DS.Tables(0).Rows.Item(0).Item("BuySale_State_Name").ToString)
                lblBuilding_No.Text = Trim(DS.Tables(0).Rows.Item(0).Item("Build_No").ToString)
                lblItem.Text = Trim(DS.Tables(0).Rows.Item(0).Item("item").ToString)
                lblSize.Text = DS.Tables(0).Rows.Item(0).Item("sizing").ToString
                lblPriceWah.Text = DS.Tables(0).Rows.Item(0).Item("PriceWah").ToString
                txtPriceWah.Text = Trim(Format((CDec(DS.Tables(0).Rows.Item(0).Item("PriceWah").ToString)), "#,##0.00").ToString)
                lblTotal1.Text = Trim(Format((CDec(DS.Tables(0).Rows.Item(0).Item("Pricetotal1").ToString)), "#,##0.00").ToString)
                txtTotal1.Text = Trim(Format((CDec(DS.Tables(0).Rows.Item(0).Item("Pricetotal1").ToString)), "#,##0.00").ToString)
                txtTotal2.Text = Trim(Format((CDec(DS.Tables(0).Rows.Item(0).Item("Pricetotal2").ToString)), "#,##0.00").ToString)
                txtTotal3.Text = Trim(Format((CDec(DS.Tables(0).Rows.Item(0).Item("Pricetotal3").ToString)), "#,##0.00").ToString)
                txtGrandTotal.Text = Trim(Format((CDec((DS.Tables(0).Rows.Item(0).Item("GrandTotal").ToString).ToString)), "#,##0.00").ToString)
                lblAppraisalName.Text = Trim(DS.Tables(0).Rows.Item(0).Item("AppraisalName").ToString)

                'lblRoadState.Text = DS.Tables(0).Rows.Item(0).Item("Land_State").ToString
                'lblRoadState.Text = DS.Tables(0).Rows.Item(0).Item("Land_State_Name").ToString
                'lblRoad_Forntoff.Text = DS.Tables(0).Rows.Item(0).Item("Road_Frontoff_Name")
                'lblRoadWidth.Text = DS.Tables(0).Rows.Item(0).Item("Roadwidth")
                'lblSite.Text = DS.Tables(0).Rows.Item(0).Item("Site_Name")
                'lblSite_Detail.Text = DS.Tables(0).Rows.Item(0).Item("Site_Detail")
                'lbllPublic_Utility.Text = DS.Tables(0).Rows.Item(0).Item("Public_Utility_Name")
                'lbllPublic_Utility_Detail.Text = DS.Tables(0).Rows.Item(0).Item("Public_Utility_Detail")

                'lblBinifit_Detail.Text = DS.Tables(0).Rows.Item(0).Item("binifit_Detail")

                'lblBuySale_State.Text = DS.Tables(0).Rows.Item(0).Item("BuySale_State_Name")
                'lblBuild_No.Text = DS.Tables(0).Rows.Item(0).Item("Build_No")
                'lblBuild_Character.Text = DS.Tables(0).Rows.Item(0).Item("Build_Character_Name")
                'lblBuild_Floor.Text = DS.Tables(0).Rows.Item(0).Item("Floors")
                'lblItem.Text = DS.Tables(0).Rows.Item(0).Item("Item")
                'lblBuild_Construct.Text = DS.Tables(0).Rows.Item(0).Item("Build_Construct_Name")
                'lblRoof.Text = DS.Tables(0).Rows.Item(0).Item("Roof_Name")
                'lblDetail_Other.Text = DS.Tables(0).Rows.Item(0).Item("Roof_Detail")
                'lblBuild_State.Text = DS.Tables(0).Rows.Item(0).Item("Build_State_Name")
                'lblPriceItem1.Text = DS.Tables(0).Rows.Item(0).Item("PriceItem1")
                'lblPriceItem2.Text = DS.Tables(0).Rows.Item(0).Item("PriceItem2")
                'lblSize.Text = DS.Tables(0).Rows.Item(0).Item("sizing")
                '
                'lblTotal1.Text = DS.Tables(0).Rows.Item(0).Item("PriceTotal1")
                'lblBuilding_Detail.Text = (DS.Tables(0).Rows.Item(0).Item("Building_Detail"))
                'lblTotal2.Text = (DS.Tables(0).Rows.Item(0).Item("PriceTotal2"))
                'lblLand_Build.Text = (DS.Tables(0).Rows.Item(0).Item("Building_Detail"))
                'lblTotal3.Text = (DS.Tables(0).Rows.Item(0).Item("PriceTotal3"))
                'lblGrandTotal.Text = (DS.Tables(0).Rows.Item(0).Item("GrandTotal"))
                'lblAppraisalName.Text = (DS.Tables(0).Rows.Item(0).Item("AppraisalName"))
                'chkDoc1.Checked = (DS.Tables(0).Rows.Item(0).Item("Doc1"))
                'chkDoc2.Checked = (DS.Tables(0).Rows.Item(0).Item("Doc2"))
                'lblDocument_Detail.Text = (DS.Tables(0).Rows.Item(0).Item("Doc_Detail"))
            Else
                'Do something each redirect to main page
                MsgBox("คุณยังไม่ได้กำหนดราคาหลักประกัน ราคาที่ 2")
            End If

            'If (IsDBNull(Price3.Q_ID)) Or (Price3.Q_ID = 0) Then
            '    Session("Mode") = "ADD"
            'Else
            '    Session("Mode") = "Edit"

            'End If
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
        MyDataAdapter.SelectCommand.Parameters("@Q_ID").Value = lblQueueID.Text

        DS = New DataSet() 'Create a new DataSet to hold the records.
        MyDataAdapter.Fill(DS, "GET_PRICE2_PRINT") 'Fill the DataSet with the rows returned.
        Return DS

    End Function

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        MsgBox(lblCif.Text & "  " & lblCifName.Text & " อาชีพ " & txtOccupation.Text)
    End Sub
End Class
