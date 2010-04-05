Imports System.Data
Imports System.Data.OracleClient
Imports Appraisal_Manager

Partial Class Appraisal_GetData_DWS
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblReq_Id.Text = Context.Items("Req_Id") 'Request.QueryString("Req_Id")
            lblHub_Id.Text = Context.Items("Hub_Id") 'Request.QueryString("Hub_Id")
            lblCif.Text = Context.Items("Cif") 'Request.QueryString("Cif")
            lblAID.Text = Context.Items("AID") 'Request.QueryString("Aid")

            'hdfCif.Value = Request.QueryString("cif")
            If lblCif.Text <> String.Empty And lblAID.Text <> String.Empty Then
                GET_CID_DETAIL(lblCif.Text, lblAID.Text)
            End If
        End If
    End Sub

    Private Sub GET_CID_DETAIL(ByVal CIF As String, ByVal AID_KEY As String)
        ' Create the connection object
        Dim con As OracleConnection = New OracleConnection(ConfigurationManager.ConnectionStrings("EDW_Connectionstring").ConnectionString)
        Dim Sqlstring As String = "SELECT MAX(DWHADMIN.CUS_PLED.CIF_NO) AS CIF, DWHADMIN.APPRAISAL_MASTER.APPRAISAL_ID, DWHADMIN.COLLATERAL_MASTER.COLLATERAL_ID,MAX(DWHADMIN.COLLATERAL_MASTER.COLLATERAL_KEY) COLLATERAL_KEY , " _
                      & " MAX(DWHADMIN.APPRAISAL_MASTER.APPRAISAL_DATE) AS APPRAISAL_DATE,SUM(DWHADMIN.APPRAISAL_MASTER.APPRAISAL_VALUE) APPRAISAL_VALUE" _
                      & " FROM DWHADMIN.APPRAISAL_MASTER INNER JOIN " _
                      & " DWHADMIN.COLLATERAL_APPRAISAL ON " _
                      & " DWHADMIN.APPRAISAL_MASTER.APPRAISAL_KEY = DWHADMIN.COLLATERAL_APPRAISAL.APPRAISAL_KEY INNER JOIN " _
                      & " DWHADMIN.COLLATERAL_PLEDGE ON " _
                      & " DWHADMIN.COLLATERAL_APPRAISAL.COLLATERAL_KEY = DWHADMIN.COLLATERAL_PLEDGE.COLLATERAL_KEY INNER JOIN " _
                      & " DWHADMIN.PLEDGE_MASTER ON DWHADMIN.COLLATERAL_PLEDGE.PLEDGE_KEY = DWHADMIN.PLEDGE_MASTER.PLEDGE_KEY INNER JOIN " _
                      & " DWHADMIN.CUS_PLED ON DWHADMIN.PLEDGE_MASTER.PLEDGE_KEY = DWHADMIN.CUS_PLED.PLEDGE_KEY LEFT OUTER JOIN " _
                      & " DWHADMIN.COLLATERAL_MASTER ON " _
                      & " DWHADMIN.COLLATERAL_PLEDGE.COLLATERAL_KEY = DWHADMIN.COLLATERAL_MASTER.COLLATERAL_KEY " _
                      & " WHERE (DWHADMIN.CUS_PLED.CIF_NO =" & CIF & " AND DWHADMIN.APPRAISAL_MASTER.APPRAISAL_ID =" & lblAID.Text & ")" _
                      & " GROUP BY DWHADMIN.APPRAISAL_MASTER.APPRAISAL_ID, DWHADMIN.COLLATERAL_MASTER.COLLATERAL_ID "

        Dim command As OracleCommand = New OracleCommand(Sqlstring)
        command.Connection = con
        con.Open()
        'Dim reader As OracleDataReader = command.ExecuteReader()
        Dim list As New OracleDataAdapter(command)
        Dim ds As New DataSet
        list.Fill(ds)
        con.Close()
        GridView_CID_DETAIL.DataSource = ds
        GridView_CID_DETAIL.DataBind()
    End Sub

    Protected Sub cb1_Checked(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb1 As CheckBox = sender
        For Each gdi As GridViewRow In GridView_CID_DETAIL.Rows
            If gdi.RowType = DataControlRowType.DataRow Then
                Dim cb2 As CheckBox = gdi.Cells(0).FindControl("cb2")
                cb2.Checked = cb1.Checked
            End If
        Next
    End Sub

    Private Sub GET_CID_DETAIL_BYKEY(ByVal CID_KEY As String, ByVal CID As String, ByVal COLLTYPE As String)
        ' Create the connection object
        Dim con As OracleConnection = New OracleConnection(ConfigurationManager.ConnectionStrings("EDW_Connectionstring").ConnectionString)
        'Dim Sqlstring As String = "SELECT *" _
        '              & " FROM DWHADMIN.COLLATERAL_MASTER" _
        '              & " WHERE (DWHADMIN.COLLATERAL_MASTER.COLLATERAL_KEY =" & CID_KEY & ") "

        Dim Sqlstring As String = "SELECT DWHADMIN.COLLATERAL_MASTER.COLLATERAL_KEY,DWHADMIN.COLLATERAL_MASTER.COLLATERAL_ID," _
                                & " DWHADMIN.COLLATERAL_MASTER.ADDRESS_NO,DWHADMIN.COLLATERAL_MASTER.BUILDING_NAME,DWHADMIN.COLLATERAL_MASTER.SOI,DWHADMIN.COLLATERAL_MASTER.ROAD," _
                                & " DWHADMIN.COLLATERAL_MASTER.DISTRICT,DWHADMIN.COLLATERAL_MASTER.AMPHUR," _
                                & " DWHADMIN.COLLATERAL_MASTER.PROVINCE,DWHADMIN.COLLATERAL_MASTER.PROVINCE_DESC," _
                                & " DWHADMIN.COLLATERAL_MASTER.ASSET_TYPE_DESC_1,DWHADMIN.COLLATERAL_MASTER.ASSET_TYPE_CODE_1," _
                                & " DWHADMIN.COLLATERAL_MASTER.COLLATERAL_REG_NO_1,DWHADMIN.COLLATERAL_MASTER.COLLATERAL_REG_NO_2,DWHADMIN.COLLATERAL_MASTER.COLLATERAL_REG_NO_3," _
                                & " DWHADMIN.COLLATERAL_MASTER.AREA_RAI,DWHADMIN.COLLATERAL_MASTER.AREA_NGAN,DWHADMIN.COLLATERAL_MASTER.AREA_WAH," _
                                & " DWHADMIN.COLLATERAL_MASTER.AREA,PRICE_BY_COLLKEY.APPRAISAL_VALUE_P_UNIT,PRICE_BY_COLLKEY.APPRAISAL_DATE," _
                                & " PRICE_BY_COLLKEY.APPRAISAL_BY_TYPE, PRICE_BY_COLLKEY.APPRAISAL_BY_TYPE_DESC" _
        & " FROM (SELECT DWHADMIN.COLLATERAL_APPRAISAL.COLLATERAL_KEY,DWHADMIN.COLLATERAL_APPRAISAL.APPRAISAL_KEY,DWHADMIN.COLLATERAL_APPRAISAL.APPRAISAL_DATE," _
        & " DWHADMIN.COLLATERAL_APPRAISAL.APPRAISAL_VALUE_P_UNIT,DWHADMIN.COLLATERAL_APPRAISAL.APPRAISAL_BY_TYPE," _
        & " DWHADMIN.COLLATERAL_APPRAISAL.APPRAISAL_BY_TYPE_DESC" _
        & " FROM (SELECT DWHADMIN.COLLATERAL_APPRAISAL.COLLATERAL_KEY,MAX(DWHADMIN.COLLATERAL_APPRAISAL.APPRAISAL_KEY)AS APPRAISAL_KEY," _
        & " MAX(DWHADMIN.COLLATERAL_APPRAISAL.APPRAISAL_DATE) AS APPRAISAL_DATE" _
        & " FROM (DWHADMIN.COLLATERAL_APPRAISAL)" _
        & " WHERE (DWHADMIN.COLLATERAL_APPRAISAL.COLLATERAL_KEY =" & CID_KEY & ")" _
        & " GROUP BY  DWHADMIN.COLLATERAL_APPRAISAL.COLLATERAL_KEY) MAXDATE_BY_COLLKEY INNER JOIN DWHADMIN.COLLATERAL_APPRAISAL " _
        & " ON MAXDATE_BY_COLLKEY.COLLATERAL_KEY = DWHADMIN.COLLATERAL_APPRAISAL.COLLATERAL_KEY " _
        & " AND MAXDATE_BY_COLLKEY.APPRAISAL_DATE = DWHADMIN.COLLATERAL_APPRAISAL.APPRAISAL_DATE) PRICE_BY_COLLKEY INNER JOIN DWHADMIN.COLLATERAL_MASTER" _
        & " ON PRICE_BY_COLLKEY.COLLATERAL_KEY = DWHADMIN.COLLATERAL_MASTER.COLLATERAL_KEY"

        Dim command As OracleCommand = New OracleCommand(Sqlstring)
        command.Connection = con
        con.Open()
        lblRai.Text = "0"
        lblNgan.Text = "0"
        lblWah.Text = "0"
        lblArea.Text = "0"
        Dim rdr As OracleDataReader = command.ExecuteReader(CommandBehavior.CloseConnection)
        If rdr.HasRows Then
            'read the first row
            rdr.Read()
            'extract the details 
            'lblAID.Text = AID
            lblCIDNo.Text = CID
            'MsgBox(lblCIDNo.Text)
            If Not IsDBNull(rdr("Asset_Type_Desc_1")) Then
                lblSubCollType.Text = rdr("Asset_Type_Desc_1")
            Else
                lblSubCollType.Text = ""
            End If
            If Left(COLLTYPE, 3) = "050" Then
                If Not IsDBNull(rdr("Asset_Type_code_1")) Then
                    lblSubCollTypeNo.Text = CInt(rdr("Asset_Type_code_1"))
                Else
                    lblSubCollTypeNo.Text = ""
                End If

                If Not IsDBNull(rdr("Collateral_Reg_No_1")) Then
                    lblChanode.Text = rdr("Collateral_Reg_No_1")
                Else
                    lblChanode.Text = ""
                End If

                If Not IsDBNull(rdr("Area_Rai")) Then
                    lblRai.Text = rdr("Area_Rai")
                Else
                    lblRai.Text = ""
                End If

                If Not IsDBNull(rdr("Area_Ngan")) Then
                    lblNgan.Text = rdr("Area_Ngan")
                Else
                    lblNgan.Text = ""
                End If

                If Not IsDBNull(rdr("Area_Wah")) Then
                    lblWah.Text = rdr("Area_Wah")
                Else
                    lblWah.Text = ""
                End If

                lblArea.Text = rdr("Area_Rai") & "-" & rdr("Area_Ngan") & "-" & rdr("Area_Wah") & " ไร่"

                If CDec(rdr("Area_Rai")) + CDec(rdr("Area_Ngan")) + CDec(rdr("Area_Wah")) > 0 Then
                    lblPerUnit.Text = String.Format("{0:N2}", (rdr("APPRAISAL_VALUE_P_UNIT") / CDec(((rdr("Area_Rai") * 400) + (rdr("Area_Ngan") * 100) + rdr("Area_Wah")))))
                Else
                    lblPerUnit.Text = rdr("APPRAISAL_VALUE_P_UNIT")
                End If

                Dim area As Decimal = 0
                area = CDec(rdr("Area_Rai")) * 400 + CDec(rdr("Area_Ngan")) * 100 + CDec(rdr("Area_Wah"))

                lblTotalPrice.Text = String.Format("{0:N2}", CDec(rdr("APPRAISAL_VALUE_P_UNIT")) * area)
            ElseIf Left(COLLTYPE, 3) = "070" Then
                lblAdd_No.Text = "เลขที่"
                If Not IsDBNull(rdr("Asset_Type_code_1")) Then
                    'บวก 5 เพราะว่าในฐานข้อมูลไม่ได้แยกชนิดของแต่ละประเภทหลักประกัน ถ้าเป็นสิ่งปลูกสร้างเริ่มที่ 6 จึงต้องเอาค่าที่ได้ + 5
                    lblSubCollTypeNo.Text = CInt(rdr("Asset_Type_code_1")) + 5
                Else
                    lblSubCollTypeNo.Text = ""
                End If
                If Not IsDBNull(rdr("Address_no")) Then
                    lblChanode.Text = rdr("Address_no")
                Else
                    lblChanode.Text = ""
                End If
                lblArea.Text = rdr("Area") & "ตรม."
                Dim area As Decimal = 0
                area = CDec(rdr("Area"))
                If area > 0 Then
                    lblPerUnit.Text = String.Format("{0:N2}", (rdr("APPRAISAL_VALUE_P_UNIT") / area))
                Else
                    lblPerUnit.Text = "0.00"
                End If
                lblTotalPrice.Text = String.Format("{0:N2}", rdr("APPRAISAL_VALUE_P_UNIT"))
            ElseIf Left(COLLTYPE, 3) = "180" Then
                lblAdd_No.Text = "เลขที่ "
                If Not IsDBNull(rdr("Asset_Type_code_1")) Then
                    lblSubCollTypeNo.Text = CInt(rdr("Asset_Type_code_1"))
                Else
                    lblSubCollTypeNo.Text = "46"
                    lblSubCollType.Text = "ห้องชุด"
                End If

                If Not IsDBNull(rdr("Collateral_Reg_No_2")) Then
                    lblChanode.Text = rdr("Collateral_Reg_No_2")
                Else
                    lblChanode.Text = ""
                End If

                If Not IsDBNull(rdr("Collateral_Reg_No_2")) Then
                    lblArea.Text = rdr("Area") & "ตรว."
                    If rdr("Area") > 0 Then
                        lblPerUnit.Text = String.Format("{0:N2}", (rdr("APPRAISAL_VALUE_P_UNIT") / CDec(rdr("Area"))))
                    Else
                        lblPerUnit.Text = "0"
                    End If

                Else
                    lblArea.Text = "0"
                End If

                lblTotalPrice.Text = String.Format("{0:N2}", rdr("APPRAISAL_VALUE_P_UNIT"))
            End If

            If Not IsDBNull(rdr("Road")) Then
                lblRoad.Text = rdr("Road")
            Else
                lblRoad.Text = ""
            End If
            lblDistrict.Text = rdr("District")
            lblAmphur.Text = rdr("Amphur")
            lblProvince_Code.Text = rdr("Province")
            lblProvince.Text = rdr("Province_DESC")
        Else
            'display message if no rows found 
            'MsgBox("Not found")
        End If


    End Sub

    Protected Sub GridView_CID_DETAIL_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView_CID_DETAIL.SelectedIndexChanging
        Dim gvTemp As GridView = DirectCast(sender, GridView)
        Dim CID_KEY As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblCollateral_Key"), Label)
        Dim CID As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblCollateral_Id"), Label)
        'Dim COLLTYPE As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblCollateral_Id"), Label)
        'MsgBox(COLLTYPE.Text)
        'COLLTYPE.Text = Left(COLLTYPE.Text, 3)
        'MsgBox(CID_KEY.Text, CID.Text)
        GET_CID_DETAIL_BYKEY(CID_KEY.Text, CID.Text, CID.Text)
    End Sub

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click
        SaveData()
    End Sub

    Protected Sub btnOk0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk0.Click
        SaveData()
    End Sub

    Private Sub SaveData()
        Dim TEMPAID As Integer
        Dim cph As ContentPlaceHolder = TryCast(Me.Form.FindControl("ContentPlaceHolder1"), ContentPlaceHolder)
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label) 'หา Control จาก Master Page ที่ control ไม่อยู่ใน  ContentPlaceHolder1 ของ Master Page
        Dim Gv As GridView = DirectCast(cph.FindControl("GridView_CID_DETAIL"), GridView)
        Dim Gv_Row As GridViewRow
        TEMPAID = GET_TEMP_AID()
        UPDATE_TEMP_AID()
        For Each Gv_Row In Gv.Rows
            Dim chk1 As CheckBox = Gv_Row.FindControl("cb2")
            Dim CollType As Label = DirectCast(Gv_Row.FindControl("lblCollateral_Id"), Label)
            Dim CollKey As Label = DirectCast(Gv_Row.FindControl("lblCollateral_Key"), Label)
            'Dim CID As Label = DirectCast(Gv_Row.FindControl("lblCollateral_Id"), Label)
            Dim CollType1 As String = Left(CollType.Text, 3)
            'MsgBox(Gv_Row.FindControl("lblCollateral_Id").ToString)
            Dim CID As Label = DirectCast(Gv_Row.FindControl("lblCollateral_Id"), Label)
            Dim ID As Integer = 0
            Dim SubCollType As String = ""
            Dim AddNo As String = ""
            Dim BuildingName As String = ""
            Dim Soi As String = ""
            Dim District As String = ""
            Dim Amphur As String = ""
            Dim ProvinceCode As Integer = 0
            Dim Rai As Integer = 0
            Dim Ngan As Integer = 0
            Dim Wah As Integer = 0
            Dim Area As Double = 0
            Dim Floors As String = ""
            Dim Road As String = ""
            Dim RoadDetail As Integer = 0
            Dim RoadAcress As Double = 0
            Dim RoadFornoff As Integer = 0
            Dim RoadWidth As Integer = 0
            Dim Site As Integer = 0
            Dim SiteDetail As String = ""
            Dim LandState As Integer = 0
            Dim LandStateDetail As String = ""
            Dim PublicUtility As Integer = 0
            Dim PublicUtilityDetail As String = ""
            Dim Binifit As Integer = 0
            Dim BinifitDetail As String = ""
            Dim Tendency As Integer = 0
            Dim BuySaleState As Integer = 0
            Dim PriceWah As Double = 0
            Dim PriceMeter As Double = 0
            Dim Total As Double = 0
            Dim Ds As DataSet = GETDATA(CollKey.Text)

            If Ds.Tables(0).Rows.Count > 0 Then
                'MsgBox(Ds.Tables(0).Rows(0).Item("District").ToString())
                If Not IsDBNull(Ds.Tables(0).Rows(0).Item("Asset_Type_code_1")) Then
                    SubCollType = Ds.Tables(0).Rows(0).Item("Asset_Type_code_1")
                Else
                    SubCollType = ""
                End If
                'SubCollType = Ds.Tables(0).Rows(0).Item("Asset_Type_code_1")
                If CollType1 <> "180" Then
                    If Not IsDBNull(Ds.Tables(0).Rows(0).Item("Collateral_Reg_No_1")) Then
                        If CollType1 = "070" Then
                            AddNo = Ds.Tables(0).Rows(0).Item("ADDRESS_NO")
                        Else
                            AddNo = Ds.Tables(0).Rows(0).Item("Collateral_Reg_No_1")
                        End If

                    Else
                        If CollType1 = "070" Then
                            If Not IsDBNull(Ds.Tables(0).Rows(0).Item("ADDRESS_NO")) Then
                                AddNo = Ds.Tables(0).Rows(0).Item("ADDRESS_NO")
                            Else
                                AddNo = String.Empty
                            End If
                        Else
                            AddNo = Ds.Tables(0).Rows(0).Item("Collateral_Reg_No_1")
                        End If
                    End If
                Else
                    If Not IsDBNull(Ds.Tables(0).Rows(0).Item("Collateral_Reg_No_2")) Then
                        AddNo = Ds.Tables(0).Rows(0).Item("Collateral_Reg_No_2")
                    Else
                        AddNo = ""
                    End If
                End If


                District = Ds.Tables(0).Rows(0).Item("District")
                Amphur = Ds.Tables(0).Rows(0).Item("Amphur")
                ProvinceCode = Ds.Tables(0).Rows(0).Item("Province")
                Rai = Ds.Tables(0).Rows(0).Item("Area_Rai")
                Ngan = Ds.Tables(0).Rows(0).Item("Area_Ngan")
                Wah = Ds.Tables(0).Rows(0).Item("Area_Wah")
                Area = Ds.Tables(0).Rows(0).Item("Area")

                If Not IsDBNull(Ds.Tables(0).Rows(0).Item("Building_Name")) Then
                    BuildingName = Ds.Tables(0).Rows(0).Item("Building_Name")
                Else
                    BuildingName = ""
                End If

                If Not IsDBNull(Ds.Tables(0).Rows(0).Item("Soi")) Then
                    Soi = Ds.Tables(0).Rows(0).Item("Soi")
                Else
                    Soi = ""
                End If

                If Not IsDBNull(Ds.Tables(0).Rows(0).Item("Road")) Then
                    Road = Ds.Tables(0).Rows(0).Item("Road")
                Else
                    Road = ""
                End If
                'Road = Ds.Tables(0).Rows(0).Item("Road")
                If Not IsDBNull(Ds.Tables(0).Rows(0).Item("Collateral_Reg_No_3")) Then
                    Floors = Ds.Tables(0).Rows(0).Item("Collateral_Reg_No_3")
                Else
                    Floors = ""
                End If

            End If

            If chk1.Checked = True Then   'ถ้าได้เลือกไว้
                If CollType1 = "050" Then  'ถ้าเป็นที่ดิน
                    ID = GET_ID_18_50_70(50)
                    UPDATE_ID_50()
                    Dim DivValue As Double = 0

                    DivValue = ((Rai) * 400) + ((Ngan) * 100) + (Wah)
                    If DivValue > 0 Then
                        PriceWah = String.Format("{0:N2}", (Ds.Tables(0).Rows(0).Item("APPRAISAL_VALUE_P_UNIT") / DivValue))
                    Else
                        PriceWah = 0
                    End If
                    'ส่งตัวแปรไปที่ Function  AddPRICE3_50 เพื่อทำการเพิ่มหรือแก้ไขข้อมูล

                    Total = String.Format("{0:N2}", Ds.Tables(0).Rows(0).Item("APPRAISAL_VALUE_P_UNIT"))

                    AddPRICE3_50(ID, CInt(lblReq_Id.Text), CInt(lblHub_Id.Text), TEMPAID, lblAID.Text, CID.Text, SubCollType, AddNo, String.Empty, District, Amphur, _
                                ProvinceCode, CInt(Rai), CInt(Ngan), CDec(Wah), _
                                Road, CInt(RoadDetail), CDec(RoadAcress), String.Empty, CInt(RoadFornoff), _
                                CDec(RoadWidth), CInt(Site), CStr(SiteDetail), CInt(LandState), _
                                LandStateDetail, CInt(PublicUtility), PublicUtilityDetail, CInt(Binifit), _
                                BinifitDetail, CInt(Tendency), CInt(BuySaleState), 1, _
                                CDec(PriceWah), CDec(Total), String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, _
                                String.Empty, 0, String.Empty, 0, 1, lbluserid.Text, Now())
                    UPDATE_Status_Appraisal_Request(lblReq_Id.Text, lblHub_Id.Text, 10)
                ElseIf CollType1 = "070" Then 'ถ้าเป็นสิ่งปลูกสร้าง
                    ID = GET_ID_18_50_70(70)
                    UPDATE_ID_70()
                    If SubCollType <> String.Empty Then
                        SubCollType = SubCollType + 5
                    End If
                    'MsgBox("Building")

                    PriceMeter = String.Format("{0:N2}", (Ds.Tables(0).Rows(0).Item("APPRAISAL_VALUE_P_UNIT") / Area))
                    Total = String.Format("{0:N2}", Ds.Tables(0).Rows(0).Item("APPRAISAL_VALUE_P_UNIT"))

                    AddPRICE3_70(ID, CInt(lblReq_Id.Text), CInt(lblHub_Id.Text), TEMPAID, lblAID.Text, CID.Text, _
                    SubCollType, AddNo, District, Amphur, _
                    ProvinceCode, 1, _
                    String.Empty, 0, 0, _
                    0, String.Empty, 0, _
                    String.Empty, String.Empty, 0, _
                    0, 0, String.Empty, String.Empty, String.Empty, String.Empty, Area, 0, _
                    Total, 0, 0, 0, 0, _
                    0, 100, 0, 0, 0, 0, _
                    0, 0, 0, 0, 0, 100, 0, _
                    String.Empty, 1, 0, 1, 1, lbluserid.Text, Now())
                    UPDATE_Status_Appraisal_Request(lblReq_Id.Text, lblHub_Id.Text, 10)

                ElseIf CollType1 = "180" Then 'ถ้าเป็นCondo
                    ID = GET_ID_18_50_70(18)
                    UPDATE_ID_18()
                    PriceMeter = String.Format("{0:N2}", (Ds.Tables(0).Rows(0).Item("APPRAISAL_VALUE_P_UNIT") / Area))
                    Total = String.Format("{0:N2}", Ds.Tables(0).Rows(0).Item("APPRAISAL_VALUE_P_UNIT"))
                    ADD_PRICE3_18(ID, lblReq_Id.Text, lblHub_Id.Text, lblAID.Text, CID.Text, TEMPAID, 46, 0, 0, _
                                  AddNo, Area, 0, BuildingName, Floors, String.Empty, String.Empty, 0, _
                                  District, Amphur, ProvinceCode, Road, CInt(RoadDetail), CDec(RoadAcress), _
                                  CInt(RoadFornoff), CDec(RoadWidth), CInt(Site), CStr(SiteDetail), CInt(PublicUtility), _
                                  PublicUtilityDetail, CInt(Binifit), BinifitDetail, CInt(Tendency), CInt(BuySaleState), _
                                  0, 0, 0, 0, 0, 0, 0, 0, 0, String.Empty, String.Empty, String.Empty, District, Amphur, ProvinceCode, _
                                  0, 0, 0, 0, 0, String.Empty, String.Empty, PriceMeter, Total, lbluserid.Text, Now())
                    UPDATE_Status_Appraisal_Request(lblReq_Id.Text, lblHub_Id.Text, 10)
                Else
                    'MsgBox("Other")
                End If
            End If
        Next


        Response.Redirect("Default.aspx")
        'Response.Redirect("Appraisal_Price2.aspx")

    End Sub

    Private Function GETDATA(ByVal COLLKEY As String) As DataSet
        Dim DsColl As New DataSet

        Dim con As OracleConnection = New OracleConnection(ConfigurationManager.ConnectionStrings("EDW_Connectionstring").ConnectionString)
        'Dim Sqlstring As String = "SELECT *" _
        '              & " FROM DWHADMIN.COLLATERAL_MASTER" _
        '              & " WHERE (DWHADMIN.COLLATERAL_MASTER.COLLATERAL_KEY =" & COLLKEY & ") "

        Dim Sqlstring As String = "SELECT DWHADMIN.COLLATERAL_MASTER.COLLATERAL_KEY,DWHADMIN.COLLATERAL_MASTER.COLLATERAL_ID," _
                                & " DWHADMIN.COLLATERAL_MASTER.ADDRESS_NO,DWHADMIN.COLLATERAL_MASTER.BUILDING_NAME,DWHADMIN.COLLATERAL_MASTER.SOI,DWHADMIN.COLLATERAL_MASTER.ROAD," _
                                & " DWHADMIN.COLLATERAL_MASTER.DISTRICT,DWHADMIN.COLLATERAL_MASTER.AMPHUR," _
                                & " DWHADMIN.COLLATERAL_MASTER.PROVINCE,DWHADMIN.COLLATERAL_MASTER.PROVINCE_DESC," _
                                & " DWHADMIN.COLLATERAL_MASTER.ASSET_TYPE_DESC_1,DWHADMIN.COLLATERAL_MASTER.ASSET_TYPE_CODE_1," _
                                & " DWHADMIN.COLLATERAL_MASTER.COLLATERAL_REG_NO_1,DWHADMIN.COLLATERAL_MASTER.COLLATERAL_REG_NO_2,DWHADMIN.COLLATERAL_MASTER.COLLATERAL_REG_NO_3," _
                                & " DWHADMIN.COLLATERAL_MASTER.AREA_RAI,DWHADMIN.COLLATERAL_MASTER.AREA_NGAN,DWHADMIN.COLLATERAL_MASTER.AREA_WAH," _
                                & " DWHADMIN.COLLATERAL_MASTER.AREA,PRICE_BY_COLLKEY.APPRAISAL_VALUE_P_UNIT,PRICE_BY_COLLKEY.APPRAISAL_DATE," _
                                & " PRICE_BY_COLLKEY.APPRAISAL_BY_TYPE, PRICE_BY_COLLKEY.APPRAISAL_BY_TYPE_DESC" _
        & " FROM (SELECT DWHADMIN.COLLATERAL_APPRAISAL.COLLATERAL_KEY,DWHADMIN.COLLATERAL_APPRAISAL.APPRAISAL_KEY,DWHADMIN.COLLATERAL_APPRAISAL.APPRAISAL_DATE," _
        & " DWHADMIN.COLLATERAL_APPRAISAL.APPRAISAL_VALUE_P_UNIT,DWHADMIN.COLLATERAL_APPRAISAL.APPRAISAL_BY_TYPE," _
        & " DWHADMIN.COLLATERAL_APPRAISAL.APPRAISAL_BY_TYPE_DESC" _
        & " FROM (SELECT DWHADMIN.COLLATERAL_APPRAISAL.COLLATERAL_KEY,MAX(DWHADMIN.COLLATERAL_APPRAISAL.APPRAISAL_KEY)AS APPRAISAL_KEY," _
        & " MAX(DWHADMIN.COLLATERAL_APPRAISAL.APPRAISAL_DATE) AS APPRAISAL_DATE" _
        & " FROM (DWHADMIN.COLLATERAL_APPRAISAL)" _
        & " WHERE (DWHADMIN.COLLATERAL_APPRAISAL.COLLATERAL_KEY =" & COLLKEY & ")" _
        & " GROUP BY  DWHADMIN.COLLATERAL_APPRAISAL.COLLATERAL_KEY) MAXDATE_BY_COLLKEY INNER JOIN DWHADMIN.COLLATERAL_APPRAISAL " _
        & " ON MAXDATE_BY_COLLKEY.COLLATERAL_KEY = DWHADMIN.COLLATERAL_APPRAISAL.COLLATERAL_KEY " _
        & " AND MAXDATE_BY_COLLKEY.APPRAISAL_DATE = DWHADMIN.COLLATERAL_APPRAISAL.APPRAISAL_DATE) PRICE_BY_COLLKEY INNER JOIN DWHADMIN.COLLATERAL_MASTER" _
        & " ON PRICE_BY_COLLKEY.COLLATERAL_KEY = DWHADMIN.COLLATERAL_MASTER.COLLATERAL_KEY"

        Dim command As OracleCommand = New OracleCommand(Sqlstring)
        command.Connection = con
        con.Open()
        'Dim rdr As OracleDataReader = command.ExecuteReader(CommandBehavior.CloseConnection)
        Dim CollAdapter As New OracleDataAdapter(command)
        CollAdapter.Fill(DsColl)
        Return DsColl
    End Function

End Class
