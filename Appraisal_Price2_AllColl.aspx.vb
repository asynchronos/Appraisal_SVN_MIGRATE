Imports Appraisal_Manager
Imports System.Web
Imports System.Web.UI
Imports System
Imports System.Data
Imports System.Data.OracleClient

Partial Class Appraisal_Price2_AllColl
    Inherits System.Web.UI.Page
    Dim str As String
    Dim s As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            lblReq_Id.Text = Context.Items("Req_Id")
            lblHub_Id.Text = Context.Items("Hub_Id")
            lblId.Text = Context.Items("ID")
            txtAID.Text = Context.Items("AID")
            hdfColltype.Value = Context.Items("Coll_Type")
            If txtAID.Text = String.Empty Then
                imSearchAID.Enabled = False
                'imSearchAID.Enabled = True
            Else
                imSearchAID.Enabled = True
            End If

            If Context.Items("Cif") = String.Empty Then
                hdfCif.Value = ""
            Else
                hdfCif.Value = Context.Items("Cif").PadLeft(16, "0")
            End If

            'ตรวจสอบ ID ว่าเป็นการแก้ไข หรือ กำหนดไอดีใหม่
            If lblId.Text Is Nothing Or lblId.Text = String.Empty Then
                Dim Objp1 As List(Of ClsPrice1_Master) = GetPrice1_Master(lblReq_Id.Text, lblHub_Id.Text)
                If Objp1.Count > 0 Then
                    txtPriceWah.Text = Objp1.Item(0).Pricewah
                    txtTotal.Text = String.Format("{0:N2}", Objp1.Item(0).Price)
                Else
                End If
            Else
                Dim Obj_GetP50 As List(Of PRICE2_50) = GET_PRICE2_50(lblId.Text, lblReq_Id.Text, lblHub_Id.Text)
                If Obj_GetP50.Count > 0 Then
                    lblId.Text = Obj_GetP50.Item(0).ID
                    lblReq_Id.Text = Obj_GetP50.Item(0).Req_Id
                    lblHub_Id.Text = Obj_GetP50.Item(0).Hub_Id
                    txtAID.Text = Obj_GetP50.Item(0).AID
                    txtCID.Text = Obj_GetP50.Item(0).CID
                    DDLSubCollType.SelectedValue = Obj_GetP50.Item(0).MysubColl_ID
                    txtChanode.Text = Obj_GetP50.Item(0).Address_No
                    txtRai.Text = Obj_GetP50.Item(0).Rai
                    txtNgan.Text = Obj_GetP50.Item(0).Ngan
                    txtWah.Text = Obj_GetP50.Item(0).Wah
                    txtRoad.Text = Obj_GetP50.Item(0).Road
                    ddlRoad_Detail.SelectedValue = Obj_GetP50.Item(0).Road_Detail
                    txtMeter.Text = Obj_GetP50.Item(0).Road_Access
                    txtTumbon.Text = Obj_GetP50.Item(0).Tumbon
                    txtAmphur.Text = Obj_GetP50.Item(0).Amphur
                    ddlProvince.SelectedValue = Obj_GetP50.Item(0).Province
                    ddlLand_State.SelectedValue = Obj_GetP50.Item(0).Land_State
                    txtLand_State_Detail.Text = Obj_GetP50.Item(0).Land_State_Detail
                    ddlRoad_Forntoff.SelectedValue = Obj_GetP50.Item(0).Road_Frontoff
                    txtRoadWidth.Text = Obj_GetP50.Item(0).RoadWidth
                    ddlSite.Text = Obj_GetP50.Item(0).Site
                    txtSite_Detail.Text = Obj_GetP50.Item(0).Site_Detail
                    ddlPublic_Utility.SelectedValue = Obj_GetP50.Item(0).Public_Utility
                    txtPublic_Utility_Detail.Text = Obj_GetP50.Item(0).Public_Utility_Detail
                    ddlBinifit.SelectedValue = Obj_GetP50.Item(0).Binifit
                    txtBinifit.Text = Obj_GetP50.Item(0).Binifit_Detail
                    ddlTendency.SelectedValue = Obj_GetP50.Item(0).Tendency
                    ddlBuySale_State.SelectedValue = Obj_GetP50.Item(0).BuySale_State
                    txtPriceWah.Text = Obj_GetP50.Item(0).PriceWah
                    txtTotal.Text = String.Format("{0:N2}", Obj_GetP50.Item(0).PriceTotal1)
                    If hdfCif.Value <> String.Empty Then
                        Get_AID_BY_CIF()
                    End If
                Else

                End If
            End If
        Else
            hdfColltype.Value = txt_CollType.Text
        End If


    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Context.Items("Coll_Type") = txt_CollType.Text
    End Sub

    Protected Sub ImageSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSave.Click
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label) 'หา Control จาก Master Page ที่ control ไม่อยู่ใน  ContentPlaceHolder1 ของ Master Page
        Dim Id As Integer
        If lblId.Text = String.Empty Then
            'ส่งค่าไปขอ Id จาก ตาราง ID_50
            Id = GET_ID_18_50_70(50)
            UPDATE_ID_50()
        Else
            Id = lblId.Text
        End If
        If txtRai.Text = 0 And txtNgan.Text = 0 And txtWah.Text = 0 Then
            s = "<script language=""javascript"">alert('ไม่มีพื้นที่ให้คำนวณราคา');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)
        Else
            AddPRICE2_50(Id, CInt(lblReq_Id.Text), CInt(lblHub_Id.Text), txtAID.Text, txtCID.Text, 0, CInt(DDLSubCollType.SelectedValue), txtChanode.Text, String.Empty, txtTumbon.Text, txtAmphur.Text, _
                                                                  ddlProvince.SelectedValue, CInt(txtRai.Text), CInt(txtNgan.Text), CDec(txtWah.Text), _
                                                                  txtRoad.Text, CInt(ddlRoad_Detail.SelectedValue), CDec(txtMeter.Text), CInt(ddlRoad_Forntoff.SelectedValue), _
                                                                  CDec(txtRoadWidth.Text), CInt(ddlSite.SelectedValue), CStr(txtSite_Detail.Text), CInt(ddlLand_State.SelectedValue), _
                                                                  txtLand_State_Detail.Text, CInt(ddlPublic_Utility.SelectedValue), txtPublic_Utility_Detail.Text, CInt(ddlBinifit.SelectedValue), _
                                                                  txtBinifit.Text, CInt(ddlTendency.SelectedValue), CInt(ddlBuySale_State.SelectedValue), _
                                                                  CInt(ddlSubUnit.SelectedValue), CDec(txtPriceWah.Text), CDec(txtTotal.Text), lbluserid.Text, Now())
            If lblId.Text = String.Empty Then
                UPDATE_Status_Appraisal_Request(lblReq_Id.Text, lblHub_Id.Text, 5)
            End If

            Response.Redirect("Appraisal_Price2.aspx")
        End If


        'เพิ่มกระบวนการบันทึกขั้นตอนการประเมิน
        'INSERT_PROCESSID(Request.QueryString("Q_ID"), 5)

        's = "<script language=""javascript"">alert('บันทึกเสร็จสมบูรณ์ ระบบจะปิดหน้าต่างนี้');  window.close();</script>"
        'Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)
    End Sub

    Private Sub Get_AID_BY_CIF()

        ' Create the connection object
        'Dim con As OracleConnection = New OracleConnection()
        Dim con As OracleConnection = New OracleConnection(ConfigurationManager.ConnectionStrings("EDW_Connectionstring").ConnectionString)

        ' Specify the connect string
        'con.ConnectionString = "User Id=cpr214361;Password=newyear2009;Data Source=edw;"
        con.ConnectionString = con.ConnectionString
        ' Open the connection
        Try
            con.Open()
        Catch ex As Exception

        End Try
        Dim cmdQuery As String = "SELECT MAX(DWHADMIN.CUS_PLED.CIF_NO) AS CIF, DWHADMIN.APPRAISAL_MASTER.APPRAISAL_ID, DWHADMIN.COLLATERAL_MASTER.COLLATERAL_ID , " _
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
                      & " WHERE (DWHADMIN.CUS_PLED.CIF_NO =" & hdfCif.Value & ") " _
                      & " GROUP BY DWHADMIN.APPRAISAL_MASTER.APPRAISAL_ID, DWHADMIN.COLLATERAL_MASTER.COLLATERAL_ID "

        ' Create the OracleCommand object
        Dim cmd As OracleCommand = New OracleCommand(cmdQuery)
        cmd.Connection = con
        cmd.CommandType = CommandType.Text

        Try
            ' Execute command, create OracleDataReader object
            Dim reader As OracleDataReader = cmd.ExecuteReader()
            While (reader.Read())
                ' Output Employee Name and Number
                ddlAID.Items.Add(reader.Item("APPRAISAL_ID"))
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            ' Dispose OracleCommand object
            cmd.Dispose()

            ' Close and Dispose OracleConnection object
            con.Close()
            con.Dispose()
        End Try
    End Sub

    Protected Sub txtPriceWah_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPriceWah.TextChanged
        Dim TotalWah As Double = 0
        If txtRai.Text = String.Empty Then
            txtRai.Text = "0"
        End If
        If txtNgan.Text = String.Empty Then
            txtNgan.Text = "0"
        End If
        If txtWah.Text = String.Empty Then
            txtWah.Text = "0"
        End If

        If txtRai.Text = "0" And txtNgan.Text = "0" And txtWah.Text = "0" Then
            s = "<script language=""javascript"">alert('ไม่มีพื้นที่ให้คำนวณราคา');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)
        Else
            TotalWah = (CDec(txtRai.Text) * 400) + (CDec(txtNgan.Text) * 100) + CDec(txtWah.Text)
            txtTotal.Text = TotalWah * CDec(txtPriceWah.Text)
        End If


    End Sub

End Class
