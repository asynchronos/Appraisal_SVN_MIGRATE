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

Partial Class Price2_PrintPreview
    Inherits System.Web.UI.Page
    Private Itemsddl As List(Of Dropdown_Pro)
    Private QID As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            QID = Request.QueryString("Q_ID")
            lblYears.Text = Format(Now(), "dd/MM/yyyy")
            Dim ds As DataSet
            Dim count As Integer
            ds = CreateDataset()
            'MsgBox(ds.Tables(0).Rows.Count)
            count = ds.Tables(0).Rows.Count
            lblCif.Text = ds.Tables(0).Rows.Item(0).Item("cif")
            lblCifName.Text = ds.Tables(0).Rows.Item(0).Item("cifname")
            lblCollTypeName.Text = ds.Tables(0).Rows.Item(0).Item("SubCollType_Name")
            lblBranchname.Text = ds.Tables(0).Rows.Item(0).Item("DepartName")
            lblAddno.Text = ds.Tables(0).Rows.Item(0).Item("Address_No")
            lblTumbon.Text = ds.Tables(0).Rows.Item(0).Item("tumbon")
            lblAmphur.Text = ds.Tables(0).Rows.Item(0).Item("Amphur")
            lblPrivinceName.Text = ds.Tables(0).Rows.Item(0).Item("Prov_Name")
            lblSizeAll.Text = ds.Tables(0).Rows.Item(0).Item("size")
            lblRoad.Text = ds.Tables(0).Rows.Item(0).Item("road")
            lblRoad_Detail.Text = ds.Tables(0).Rows.Item(0).Item("road_Detail_Name")
            lblMeter.Text = ds.Tables(0).Rows.Item(0).Item("Road_Access")
            lblLand_State.Text = ds.Tables(0).Rows.Item(0).Item("Land_State_Name")
            lblLand_State_Detail.Text = ds.Tables(0).Rows.Item(0).Item("Land_State_Detail")
            lblRoad_Forntoff.Text = ds.Tables(0).Rows.Item(0).Item("Road_Frontoff_Name")
            lblRoadWidth.Text = ds.Tables(0).Rows.Item(0).Item("Roadwidth")
            lblSite.Text = ds.Tables(0).Rows.Item(0).Item("Site_Name")
            lblSite_Detail.Text = ds.Tables(0).Rows.Item(0).Item("Site_Detail")
            lbllPublic_Utility.Text = ds.Tables(0).Rows.Item(0).Item("Public_Utility_Name")
            lbllPublic_Utility_Detail.Text = ds.Tables(0).Rows.Item(0).Item("Public_Utility_Detail")
            lblBinifit.Text = ds.Tables(0).Rows.Item(0).Item("binifit_Name")
            lblBinifit_Detail.Text = ds.Tables(0).Rows.Item(0).Item("binifit_Detail")
            lblTendency.Text = ds.Tables(0).Rows.Item(0).Item("Tendency_Name")
            lblBuySale_State.Text = ds.Tables(0).Rows.Item(0).Item("BuySale_State_Name")
            lblBuild_No.Text = ds.Tables(0).Rows.Item(0).Item("Build_No")
            lblBuild_Character.Text = ds.Tables(0).Rows.Item(0).Item("Build_Character_Name")
            lblBuild_Floor.Text = ds.Tables(0).Rows.Item(0).Item("Floors")
            lblItem.Text = ds.Tables(0).Rows.Item(0).Item("Item")
            lblBuild_Construct.Text = ds.Tables(0).Rows.Item(0).Item("Build_Construct_Name")
            lblRoof.Text = ds.Tables(0).Rows.Item(0).Item("Roof_Name")
            lblDetail_Other.Text = ds.Tables(0).Rows.Item(0).Item("Roof_Detail")
            lblBuild_State.Text = ds.Tables(0).Rows.Item(0).Item("Build_State_Name")
            lblPriceItem1.Text = ds.Tables(0).Rows.Item(0).Item("PriceItem1")
            lblPriceItem2.Text = ds.Tables(0).Rows.Item(0).Item("PriceItem2")
            lblSize.Text = ds.Tables(0).Rows.Item(0).Item("sizing")
            lblPriceWah.Text = ds.Tables(0).Rows.Item(0).Item("PriceWah")
            lblTotal1.Text = ds.Tables(0).Rows.Item(0).Item("PriceTotal1")
            lblBuilding_Detail.Text = (ds.Tables(0).Rows.Item(0).Item("Building_Detail"))
            lblTotal2.Text = (ds.Tables(0).Rows.Item(0).Item("PriceTotal2"))
            lblLand_Build.Text = (ds.Tables(0).Rows.Item(0).Item("Building_Detail"))
            lblTotal3.Text = (ds.Tables(0).Rows.Item(0).Item("PriceTotal3"))
            lblGrandTotal.Text = (ds.Tables(0).Rows.Item(0).Item("GrandTotal"))
            lblAppraisalName.Text = (ds.Tables(0).Rows.Item(0).Item("AppraisalName"))
            chkDoc1.Checked = (ds.Tables(0).Rows.Item(0).Item("Doc1"))
            chkDoc2.Checked = (ds.Tables(0).Rows.Item(0).Item("Doc2"))
            lblDocument_Detail.Text = (ds.Tables(0).Rows.Item(0).Item("Doc_Detail"))
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
