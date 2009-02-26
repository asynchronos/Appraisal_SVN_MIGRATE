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
                      & " MAX(DWHADMIN.APPRAISAL_MASTER.APPRAISAL_DATE) AS APPRAISAL_DATE" _
                      & " FROM DWHADMIN.APPRAISAL_MASTER INNER JOIN " _
                      & " DWHADMIN.COLLATERAL_APPRAISAL ON " _
                      & " DWHADMIN.APPRAISAL_MASTER.APPRAISAL_KEY = DWHADMIN.COLLATERAL_APPRAISAL.APPRAISAL_KEY INNER JOIN " _
                      & " DWHADMIN.COLLATERAL_PLEDGE ON " _
                      & " DWHADMIN.COLLATERAL_APPRAISAL.COLLATERAL_KEY = DWHADMIN.COLLATERAL_PLEDGE.COLLATERAL_KEY INNER JOIN " _
                      & " DWHADMIN.PLEDGE_MASTER ON DWHADMIN.COLLATERAL_PLEDGE.PLEDGE_KEY = DWHADMIN.PLEDGE_MASTER.PLEDGE_KEY INNER JOIN " _
                      & " DWHADMIN.CUS_PLED ON DWHADMIN.PLEDGE_MASTER.PLEDGE_KEY = DWHADMIN.CUS_PLED.PLEDGE_KEY LEFT OUTER JOIN " _
                      & " DWHADMIN.COLLATERAL_MASTER ON " _
                      & " DWHADMIN.COLLATERAL_PLEDGE.COLLATERAL_KEY = DWHADMIN.COLLATERAL_MASTER.COLLATERAL_KEY " _
                      & " WHERE (DWHADMIN.CUS_PLED.CIF_NO =" & CIF & ")" _
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
        Dim Sqlstring As String = "SELECT *" _
                      & " FROM DWHADMIN.COLLATERAL_MASTER" _
                      & " WHERE (DWHADMIN.COLLATERAL_MASTER.COLLATERAL_KEY =" & CID_KEY & ") "

        Dim command As OracleCommand = New OracleCommand(Sqlstring)
        command.Connection = con
        con.Open()
        Dim rdr As OracleDataReader = command.ExecuteReader(CommandBehavior.CloseConnection)
        If rdr.HasRows Then
            'read the first row
            rdr.Read()
            'extract the details 
            'lblAID.Text = AID
            lblCID.Text = CID

            If Not IsDBNull(rdr("Asset_Type_Desc_1")) Then
                lblSubCollType.Text = rdr("Asset_Type_Desc_1")
            Else
                lblSubCollType.Text = ""
            End If
            If COLLTYPE = "050" Then
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
                lblArea.Text = rdr("Area_Rai") & "-" & rdr("Area_Ngan") & "-" & rdr("Area_Wah") & "ไร่"
            ElseIf COLLTYPE = "070" Then
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
            End If

            If Not IsDBNull(rdr("Road")) Then
                lblRoad.Text = rdr("Road")
            Else
                lblRoad.Text = ""
            End If

            'lblRoad.Text = rdr("Road")
            lblDistrict.Text = rdr("District")
            lblAmphur.Text = rdr("Amphur")
            lblProvince_Code.Text = rdr("Province")
            lblProvince.Text = rdr("Province_DESC")
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
            'lblArea.Text = rdr("Area_Rai") & "-" & rdr("Area_Ngan") & "-" & rdr("Area_Wah")

        Else
            'display message if no rows found 
            MsgBox("Not found")

        End If


    End Sub

    Protected Sub GridView_CID_DETAIL_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView_CID_DETAIL.SelectedIndexChanging
        Dim gvTemp As GridView = DirectCast(sender, GridView)
        Dim CID_KEY As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblCollateral_Key"), Label)
        Dim CID As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblCollateral_Id"), Label)
        Dim COLLTYPE As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblCollateral_Id"), Label)
        COLLTYPE.Text = Left(COLLTYPE.Text, 3)
        'MsgBox(CID_KEY.Text, CID.Text)
        GET_CID_DETAIL_BYKEY(CID_KEY.Text, CID.Text, COLLTYPE.Text)
    End Sub


    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click
        'Dim Gv As GridView = DirectCast(Me.FindControl("Gridview1"), GridView)
        'Dim Gv_Row As GridViewRow

        'For Each Gv_Row In Gv.Rows

        'Next
        SaveData()
    End Sub

    Protected Sub btnOk0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk0.Click
        SaveData()
    End Sub

    Private Sub SaveData() 'ByVal Id As String, _
        '                     ByVal Req_Id As String, _
        '                     ByVal Hub_Id As String, _
        '                     ByVal AID As String, _
        '                     ByVal CID As String, _
        '                     ByVal SubCollType As String, _
        '                     ByVal AddNo As String, _
        '                     ByVal BuildingName As String, _
        '                     ByVal District As String, _
        '                     ByVal Amphur As String, _
        '                     ByVal ProvinceCode As Integer, _
        '                     ByVal Rai As Integer, _
        '                     ByVal Ngan As Integer, _
        '                     ByVal Wah As Integer, _
        '                     ByVal Area As Double, _
        '                     ByVal Road As String, _
        '                     ByVal RoadDetail As Integer, _
        '                     ByVal RoadAcress As Double, _
        '                     ByVal RoadFornoff As Integer, _
        '                     ByVal RoadWidth As Integer, _
        '                     ByVal Site As Integer, _
        '                     ByVal SiteDetail As String, _
        '                     ByVal LandState As Integer, _
        '                     ByVal LandStateDetail As String, _
        '                     ByVal PublicUtility As Integer, _
        '                     ByVal PublicUtilityDetail As String, _
        '                     ByVal Binifit As Integer, _
        '                     ByVal BinifitDetail As String, _
        '                     ByVal Tendency As Integer, _
        '                     ByVal BuySaleState As Integer, _
        '                     ByVal PriceWah As Double, _
        '                     ByVal Total As Double,)
        Dim cph As ContentPlaceHolder = TryCast(Me.Form.FindControl("ContentPlaceHolder1"), ContentPlaceHolder)
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label) 'หา Control จาก Master Page ที่ control ไม่อยู่ใน  ContentPlaceHolder1 ของ Master Page
        Dim Gv As GridView = DirectCast(cph.FindControl("GridView_CID_DETAIL"), GridView)
        Dim Gv_Row As GridViewRow

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
                If IsDBNull(Ds.Tables(0).Rows(0).Item("Collateral_Reg_No_1")) Then
                    AddNo = ""
                Else
                    AddNo = Ds.Tables(0).Rows(0).Item("Collateral_Reg_No_1")
                End If

                District = Ds.Tables(0).Rows(0).Item("District")
                Amphur = Ds.Tables(0).Rows(0).Item("Amphur")
                ProvinceCode = Ds.Tables(0).Rows(0).Item("Province")
                Rai = Ds.Tables(0).Rows(0).Item("Area_Rai")
                Ngan = Ds.Tables(0).Rows(0).Item("Area_Ngan")
                Wah = Ds.Tables(0).Rows(0).Item("Area_Wah")
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
                    AddPRICE2_50(ID, CInt(lblReq_Id.Text), CInt(lblHub_Id.Text), lblAID.Text, CID.Text, 0, SubCollType, AddNo, String.Empty, District, Amphur, _
                                 ProvinceCode, CInt(Rai), CInt(Ngan), CInt(Wah), _
                                 Road, CInt(RoadDetail), CDec(RoadAcress), CInt(RoadFornoff), _
                                 CDec(RoadWidth), CInt(Site), CStr(SiteDetail), CInt(LandState), _
                                 LandStateDetail, CInt(PublicUtility), PublicUtilityDetail, CInt(Binifit), _
                                 BinifitDetail, CInt(Tendency), CInt(BuySaleState), _
                                 CInt(PriceWah), CInt(Total), lbluserid.Text, Now())
                ElseIf CollType1 = "070" Then 'ถ้าเป็นสิ่งปลูกสร้าง
                    If SubCollType <> String.Empty Then
                        SubCollType = SubCollType + 5
                    End If
                    'MsgBox("Building")
                    AddPRICE2_70(ID, CInt(lblReq_Id.Text), CInt(lblHub_Id.Text), lblAID.Text, CID.Text, 0, CInt(SubCollType), AddNo, District, Amphur, _
                                                                          ProvinceCode, 0, 0, 0, 0, _
                                                                          0, "", 0, "", "", CInt(Total), 0, 0, "", "", lbluserid.Text, Now())
                Else
                    MsgBox("Other")
                End If
            End If
        Next



        'Response.Redirect("Appraisal_Price2.aspx")

    End Sub

    Private Function GETDATA(ByVal COLLKEY As String) As DataSet
        Dim DsColl As New DataSet

        Dim con As OracleConnection = New OracleConnection(ConfigurationManager.ConnectionStrings("EDW_Connectionstring").ConnectionString)
        Dim Sqlstring As String = "SELECT *" _
                      & " FROM DWHADMIN.COLLATERAL_MASTER" _
                      & " WHERE (DWHADMIN.COLLATERAL_MASTER.COLLATERAL_KEY =" & COLLKEY & ") "

        Dim command As OracleCommand = New OracleCommand(Sqlstring)
        command.Connection = con
        con.Open()
        'Dim rdr As OracleDataReader = command.ExecuteReader(CommandBehavior.CloseConnection)
        Dim CollAdapter As New OracleDataAdapter(command)
        CollAdapter.Fill(DsColl)
        Return DsColl

        'If rdr.HasRows Then
        '    'read the first row
        '    rdr.Read()
        '    'extract the details 

        '    If Not IsDBNull(rdr("Asset_Type_Desc_1")) Then
        '        lblSubCollType.Text = rdr("Asset_Type_Desc_1")
        '    Else
        '        lblSubCollType.Text = ""
        '    End If
        '    If COLLTYPE = "050" Then
        '        If Not IsDBNull(rdr("Asset_Type_code_1")) Then
        '            lblSubCollTypeNo.Text = CInt(rdr("Asset_Type_code_1"))
        '        Else
        '            lblSubCollTypeNo.Text = ""
        '        End If

        '        If Not IsDBNull(rdr("Collateral_Reg_No_1")) Then
        '            lblChanode.Text = rdr("Collateral_Reg_No_1")
        '        Else
        '            lblChanode.Text = ""
        '        End If
        '        lblArea.Text = rdr("Area_Rai") & "-" & rdr("Area_Ngan") & "-" & rdr("Area_Wah") & "ไร่"
        '    ElseIf COLLTYPE = "070" Then
        '        If Not IsDBNull(rdr("Asset_Type_code_1")) Then
        '            'บวก 5 เพราะว่าในฐานข้อมูลไม่ได้แยกชนิดของแต่ละประเภทหลักประกัน ถ้าเป็นสิ่งปลูกสร้างเริ่มที่ 6 จึงต้องเอาค่าที่ได้ + 5
        '            lblSubCollTypeNo.Text = CInt(rdr("Asset_Type_code_1")) + 5
        '        Else
        '            lblSubCollTypeNo.Text = ""
        '        End If
        '        If Not IsDBNull(rdr("Address_no")) Then
        '            lblChanode.Text = rdr("Address_no")
        '        Else
        '            lblChanode.Text = ""
        '        End If
        '        lblArea.Text = rdr("Area") & "ตรม."
        '    End If


        '    lblRoad.Text = rdr("Road")
        '    lblDistrict.Text = rdr("District")
        '    lblAmphur.Text = rdr("Amphur")
        '    lblProvince_Code.Text = rdr("Province")
        '    lblProvince.Text = rdr("Province_DESC")
        '    If Not IsDBNull(rdr("Area_Rai")) Then
        '        lblRai.Text = rdr("Area_Rai")
        '    Else
        '        lblRai.Text = ""
        '    End If

        '    If Not IsDBNull(rdr("Area_Ngan")) Then
        '        lblNgan.Text = rdr("Area_Ngan")
        '    Else
        '        lblNgan.Text = ""
        '    End If

        '    If Not IsDBNull(rdr("Area_Wah")) Then
        '        lblWah.Text = rdr("Area_Wah")
        '    Else
        '        lblWah.Text = ""
        '    End If
        '    'lblArea.Text = rdr("Area_Rai") & "-" & rdr("Area_Ngan") & "-" & rdr("Area_Wah")

        'Else
        '    'display message if no rows found 
        '    MsgBox("Not found")

        'End If
    End Function

End Class
