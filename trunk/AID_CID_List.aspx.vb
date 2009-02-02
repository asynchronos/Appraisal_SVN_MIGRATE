Imports Appraisal_Manager
Imports System.Web
Imports System.Web.UI
Imports System
Imports System.Data
Imports System.Data.OracleClient
Imports System.Net


Partial Class AID_CID_List
    Inherits System.Web.UI.Page
    Dim CollType As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            hdfCif.Value = Request.QueryString("cif")
            If hdfCif.Value <> String.Empty Then
                CollType = Request.QueryString("CollType")
                Get_AID_CID(CollType)
            End If
        End If
    End Sub

    Private Sub Get_AID_CID(ByVal CollType As String)
        ' Create the connection object
        'Dim Colltype As String = "050"
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
                      & " WHERE (DWHADMIN.CUS_PLED.CIF_NO =" & hdfCif.Value & " AND SUBSTR(DWHADMIN.COLLATERAL_MASTER.COLLATERAL_ID,1,3)=" & CollType & ")" _
                      & " GROUP BY DWHADMIN.APPRAISAL_MASTER.APPRAISAL_ID, DWHADMIN.COLLATERAL_MASTER.COLLATERAL_ID "

        Dim command As OracleCommand = New OracleCommand(Sqlstring)
        command.Connection = con
        con.Open()
        'Dim reader As OracleDataReader = command.ExecuteReader()
        Dim list As New OracleDataAdapter(command)
        Dim ds As New DataSet
        list.Fill(ds)

        GridView1.DataSource = ds
        GridView1.DataBind()
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        'MsgBox(GridView1.SelectedDataKey.Values(0) & " " & GridView1.SelectedDataKey.Values(1) & " " & GridView1.SelectedDataKey.Values(2))
        GET_CID_DETAIL(GridView1.SelectedDataKey.Values(3))
        GET_CID_DETAIL_BYKEY(GridView1.SelectedDataKey.Values(3), GridView1.SelectedDataKey.Values(1), GridView1.SelectedDataKey.Values(2))
    End Sub

    Private Sub GET_CID_DETAIL(ByVal CID_KEY As String)
        ' Create the connection object
        Dim con As OracleConnection = New OracleConnection(ConfigurationManager.ConnectionStrings("EDW_Connectionstring").ConnectionString)
        Dim Sqlstring As String = "SELECT *" _
                      & " FROM DWHADMIN.COLLATERAL_MASTER" _
                      & " WHERE (DWHADMIN.COLLATERAL_MASTER.COLLATERAL_KEY =" & CID_KEY & ") "

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

    Private Sub GET_CID_DETAIL_BYKEY(ByVal CID_KEY As String, ByVal AID As String, ByVal CID As String)
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
            lblAID.Text = AID
            lblCID.Text = CID
            If Not IsDBNull(rdr("Asset_Type_Desc_1")) Then
                lblSubCollType.Text = rdr("Asset_Type_Desc_1")
            Else
                lblSubCollType.Text = ""
            End If
            If Request.QueryString("CollType") = "050" Then
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
            ElseIf Request.QueryString("CollType") = "070" Then
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
            End If


            lblRoad.Text = rdr("Road")
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
        Else
            'display message if no rows found 
            MsgBox("Not found")

        End If


    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sAlert As String
        If lblAID.Text = String.Empty Or lblCID.Text = String.Empty Then
            sAlert = "<script language=""javascript"">alert('โปรดเลือกหลักประกันก่อน');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", sAlert)
            Exit Sub
        Else
            'ส่งค่ากลับไปยังหน้าที่เปิด
            Dim AID As String = lblAID.Text
            Dim CID As String = lblCID.Text
            Dim S As String = ""

            If Request.QueryString("CollType") = "050" Then
                S += "<script language='javascript'>"
                S += "window.opener.document.getElementById('" & Request.QueryString("txtAID") & "').value  ='" & AID & "';"
                S += "window.opener.document.getElementById('" & Request.QueryString("txtCID") & "').value  ='" & CID & "';"
                S += "window.opener.document.getElementById('" & Request.QueryString("txtSubCollType") & "').value  ='" & lblSubCollTypeNo.Text & "';"
                S += "window.opener.document.getElementById('" & Request.QueryString("txtChanode") & "').value  ='" & lblChanode.Text & "';"
                S += "window.opener.document.getElementById('" & Request.QueryString("txtDistrict") & "').value  ='" & lblAmphur.Text & "';"
                S += "window.opener.document.getElementById('" & Request.QueryString("txtAmphur") & "').value  ='" & lblAmphur.Text & "';"
                S += "window.opener.document.getElementById('" & Request.QueryString("txtProvince") & "').value  ='" & CInt(lblProvince_Code.Text) & "';"
                S += "window.opener.document.getElementById('" & Request.QueryString("txtRoad") & "').value  ='" & lblRoad.Text & "';"
                S += "window.opener.document.getElementById('" & Request.QueryString("txtRai") & "').value  ='" & lblRai.Text & "';"
                S += "window.opener.document.getElementById('" & Request.QueryString("txtNgan") & "').value  ='" & lblNgan.Text & "';"
                S += "window.opener.document.getElementById('" & Request.QueryString("txtWah") & "').value  ='" & lblWah.Text & "';"
                S += "window.close();"
                S += "</script>"
                'Page.ClientScript.RegisterStartupScript(Me.GetType, "test", S, True)
            ElseIf Request.QueryString("CollType") = "070" Then
                S += "<script language='javascript'>"
                S += "window.opener.document.getElementById('" & Request.QueryString("txtAID") & "').value  ='" & AID & "';"
                S += "window.opener.document.getElementById('" & Request.QueryString("txtCID") & "').value  ='" & CID & "';"
                S += "window.opener.document.getElementById('" & Request.QueryString("txtSubCollType") & "').value  ='" & CInt(lblSubCollTypeNo.Text) & "';"
                S += "window.opener.document.getElementById('" & Request.QueryString("txtDistrict") & "').value  ='" & lblAmphur.Text & "';"
                S += "window.opener.document.getElementById('" & Request.QueryString("txtBuilding_No") & "').value  ='" & lblChanode.Text & "';"
                S += "window.opener.document.getElementById('" & Request.QueryString("txtAmphur") & "').value  ='" & lblAmphur.Text & "';"
                S += "window.opener.document.getElementById('" & Request.QueryString("txtProvince") & "').value  ='" & CInt(lblProvince_Code.Text) & "';"
                S += "window.close();"
                S += "</script>"
            End If


            Response.Write(S)
        End If


    End Sub
End Class
