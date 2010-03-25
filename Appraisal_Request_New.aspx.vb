
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Text
Imports SME_SERVICE
Imports System.Data.SqlClient
Imports Oracle.DataAccess.Client
Imports Appraisal_Manager


Partial Class Appraisal_Request_New
    Inherits System.Web.UI.Page
    Private ds As DataSet
    Private strMessage As String

    Protected Sub ImgBtSearchEmp_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtSearchEmp.Click
        TxtSender.Text = "000000"
        Dim myScript As String
        myScript = "<script>" + "window.open('Search_Employee.aspx?empid=" & TxtSender.ClientID & "&empname=" & TxtAppraisalName.ClientID & "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, directories=no, status=yes,height=550px,width=650px');</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType, "Search", myScript)

    End Sub

    Protected Sub ImgBtFindCif_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtFindCif.Click
        If TxtCif.Text = String.Empty Then
            'Notice Message 
        Else
            Dim cus_class As Customer_Class
            Dim SV As New SME_SERVICE.Service
            'Dim cif As Integer
            Try
                If SV.GetCifInfo(TxtCif.Text)(0) Is Nothing Then

                Else
                    cus_class = SV.GetCifInfo(TxtCif.Text)(0)

                    'ถ้า cif ที่ส่งมาไม่เท่ากับ 0 ให้ใส่ข้อมูลลูกค้าใส่ในคอนโทรลที่กำหนดให้
                    If cus_class.Cif.ToString <> 0 Then
                        'ใช้คำนำหน้าชื่อที่ได้จาก Customer มาหา ID Title
                        ddlTitle.SelectedIndex = ddlTitle.Items.IndexOf(ddlTitle.Items.FindByText(cus_class.Cus_Title))
                        TxtCifName.Text = cus_class.cus_first
                        TxtCifLastName.Text = cus_class.cus_last
                        'Get_AID_BY_CIF()
                        If ddlAppraisal_Method.SelectedValue = 2 Then
                            GET_AID_BY_CIFNEW()
                        End If
                    Else
                        'ถ้า cif ที่ส่งมาเท่ากับ 0 ให้ Clear ค่า  ในคอนโทรล
                        Dim l As New Label
                        'MessageBox("Format Exception: " & ex.Message)
                        l.Text = SV.MSb("ค้นหาข้อมูลลูกค้าไม่พบ ")
                        Page.Controls.Add(l)

                        TxtCifName.Text = ""
                        TxtCifLastName.Text = ""
                    End If
                End If
            Catch ex As Exception
                Beep()
                lblMessage.Text = "ไม่มี รหัสลูกหนี้นี้อยู่บนระบบ"
                TxtCifName.Text = ""
                TxtCifLastName.Text = ""
            End Try
        End If
    End Sub

    Private Sub GET_AID_BY_CIFNEW()
        Dim oradb As String = ConfigurationManager.ConnectionStrings.Item("EDW_Connectionstring").ToString
        Dim conn As New OracleConnection(oradb)
        conn.Open()

        Dim cmdQuery As String = "SELECT MAX(DWHADMIN.CUS_PLED.CIF_NO) AS CIF, DWHADMIN.APPRAISAL_MASTER.APPRAISAL_ID" _
              & " FROM DWHADMIN.APPRAISAL_MASTER INNER JOIN " _
              & " DWHADMIN.COLLATERAL_APPRAISAL ON " _
              & " DWHADMIN.APPRAISAL_MASTER.APPRAISAL_KEY = DWHADMIN.COLLATERAL_APPRAISAL.APPRAISAL_KEY INNER JOIN " _
              & " DWHADMIN.COLLATERAL_PLEDGE ON " _
              & " DWHADMIN.COLLATERAL_APPRAISAL.COLLATERAL_KEY = DWHADMIN.COLLATERAL_PLEDGE.COLLATERAL_KEY INNER JOIN " _
              & " DWHADMIN.PLEDGE_MASTER ON DWHADMIN.COLLATERAL_PLEDGE.PLEDGE_KEY = DWHADMIN.PLEDGE_MASTER.PLEDGE_KEY INNER JOIN " _
              & " DWHADMIN.CUS_PLED ON DWHADMIN.PLEDGE_MASTER.PLEDGE_KEY = DWHADMIN.CUS_PLED.PLEDGE_KEY LEFT OUTER JOIN " _
              & " DWHADMIN.COLLATERAL_MASTER ON " _
              & " DWHADMIN.COLLATERAL_PLEDGE.COLLATERAL_KEY = DWHADMIN.COLLATERAL_MASTER.COLLATERAL_KEY " _
              & " WHERE (DWHADMIN.CUS_PLED.CIF_NO =" & TxtCif.Text & ") " _
              & " GROUP BY DWHADMIN.APPRAISAL_MASTER.APPRAISAL_ID"

        Dim cmd As OracleCommand = New OracleCommand(cmdQuery)
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text

        Try
            ' Execute command, create OracleDataReader object
            ddlAID.Items.Clear()
            Dim reader As OracleDataReader = cmd.ExecuteReader()
            While (reader.Read())
                ' Output Employee Name and Number
                ddlAID.Items.Add(reader.Item("APPRAISAL_ID"))
            End While
            reader.Dispose()
        Catch ex As Exception
            Throw New Exception(ex.Message & " : " & ex.StackTrace)
        Finally

            ' Dispose OracleCommand object
            cmd.Dispose()

            ' Close and Dispose OracleConnection object
            conn.Close()
            conn.Dispose()
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'lblRequestID.Text = "111"
        Dim cph As ContentPlaceHolder = TryCast(Me.Form.FindControl("ContentPlaceHolder1"), ContentPlaceHolder)
        Dim chkbox As CheckBox = DirectCast(cph.FindControl("ChkBoxCopy"), CheckBox)
        chkbox.Attributes.Add("onclick", "return copyDataCif();")
        UpdatePanel1.Visible = False
    End Sub

    Protected Sub bntRequest_ID_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bntRequest_ID.Click
        Page.Validate("1")
        Page.Validate("2")
        Page.Validate("3")
        Page.Validate("4")
        If (Page.IsValid) Then
            If TxtSender.Text = "000000" Then
                'MsgBox("Please find Sender id ")
            Else


                Dim lbluser_create As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
                If ddlAppraisal_Method.SelectedValue = 1 Then
                    'ประเมินใหม่               
                    '******* ออกเลขคำขอประเมิน ****************
                    ds = GET_RequestID()
                    lblRequestID.Text = ds.Tables(0).Rows.Item(0).Item("Req_ID")
                    '***************************************

                    '***************************************** SAVE DATA ****************************************
                    AddAppraisal_Request_Master(lblRequestID.Text, TxtCif.Text, ddlTitle.SelectedValue, TxtCifName.Text, TxtCifLastName.Text, ddlAppraisal_Method.SelectedValue, ddlAID.SelectedValue, 0, TxtSender.Text, TxtAppraisalName.Text, lbluser_create.Text, Now())
                    ADD_APPRAISAL_REQUEST_V2(lblRequestID.Text, ddlHub.SelectedValue, TxtCif.Text, ddlTitle.SelectedValue, _
                                             TxtCifName.Text, TxtCifLastName.Text, TxtCifColl.Text, ddlTitleColl.SelectedValue, _
                                             TxtCifNameColl.Text, TxtCifLastNameColl.Text, ddlAppraisal_Method.SelectedValue, _
                                             0, 0, ddlBranch_Dept.SelectedValue, ddlTumbon.SelectedValue, _
                                             ddlAmphur.SelectedValue, ddlProvince.SelectedValue, 1, "", 1, lbluser_create.Text, Now())
                    '*************************************** END OF SAVE DATA ************************************
                    '                                         TextBoxAmphurCode.Text, TextBoxProvinceCode.Text, ddlAPPLICATION_TYPE.SelectedValue, TextBoxChanode.Text, TextBoxFlag.Text, lbluser_create.Text, Now())
                    '************* Update เลขคำขอประเมิน **********************
                    UPDATE_REQUEST_ID()
                    '******************************************************
                    strMessage = "<script language=""javascript"">alert('คำขอประเมิน บันทึกเสร็จสมบูรณ์ กรุณาแนบไฟล์ด้านล่างเพื่อประกอบการประเมิน');</script>"
                    Page.ClientScript.RegisterStartupScript(Me.GetType, "Message", strMessage)
                    lblMessage.Text = "กรุณาแนบไฟล์ด้านล่างเพื่อประกอบการประเมิน"
                    UpdatePanel1.Visible = True
                    bntRequest_ID.Enabled = False
                Else
                    'ทบทวนประเมิน
                    If ddlAID.SelectedValue = String.Empty Then
                        lblMessage.Text = "ไม่มีเลข AID"
                    Else
                        '******* ออกเลขคำขอประเมิน ****************
                        ds = GET_RequestID()
                        lblRequestID.Text = ds.Tables(0).Rows.Item(0).Item("Req_ID")
                        '***************************************

                        '***************************************** SAVE DATA ****************************************
                        AddAppraisal_Request_Master(lblRequestID.Text, TxtCif.Text, ddlTitle.SelectedValue, TxtCifName.Text, TxtCifLastName.Text, ddlAppraisal_Method.SelectedValue, ddlAID.SelectedValue, 0, TxtSender.Text, TxtAppraisalName.Text, lbluser_create.Text, Now())
                        ADD_APPRAISAL_REQUEST_V2(lblRequestID.Text, ddlHub.SelectedValue, TxtCif.Text, ddlTitle.SelectedValue, _
                                                 TxtCifName.Text, TxtCifLastName.Text, TxtCifColl.Text, ddlTitleColl.SelectedValue, _
                                                 TxtCifNameColl.Text, TxtCifLastNameColl.Text, ddlAppraisal_Method.SelectedValue, _
                                                 0, 0, ddlBranch_Dept.SelectedValue, ddlTumbon.SelectedValue, _
                                                 ddlAmphur.SelectedValue, ddlProvince.SelectedValue, 1, "", 1, lbluser_create.Text, Now())
                        '*************************************** END OF SAVE DATA ************************************

                        '************* Update เลขคำขอประเมิน **********************
                        UPDATE_REQUEST_ID()
                        '******************************************************
                        strMessage = "<script language=""javascript"">alert('คำขอประเมิน บันทึกเสร็จสมบูรณ์ กรุณาแนบไฟล์ด้านล่างเพื่อประกอบการประเมิน');</script>"
                        Page.ClientScript.RegisterStartupScript(Me.GetType, "Message", strMessage)
                        lblMessage.Text = "กรุณาแนบไฟล์ด้านล่างเพื่อประกอบการประเมิน"
                        UpdatePanel1.Visible = True
                        bntRequest_ID.Enabled = False
                    End If
                End If

            End If
        Else
            'MsgBox("Require Some Data")
            lblMessage.Text = ""
        End If
    End Sub

    Private Function GET_RequestID() As DataSet

        'For Print Data Out
        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        MyConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)

        MyDataAdapter = New SqlDataAdapter("GET_REQUEST_ID", MyConnection)
        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
        'MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Q_ID", SqlDbType.Int))
        'MyDataAdapter.SelectCommand.Parameters("@Q_ID").Value = QID

        DS = New DataSet() 'Create a new DataSet to hold the records.
        MyDataAdapter.Fill(DS, "GET_REQUEST_ID") 'Fill the DataSet with the rows returned.
        Return DS

    End Function

    Protected Sub btnFinish_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFinish.Click
        Response.Redirect("Appraisal_Request_New.aspx")
    End Sub

    Protected Sub ImgBtFindCollOwner_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtFindCollOwner.Click
        Dim cus_class As Customer_Class
        Dim SV As New SME_SERVICE.Service
        'Dim cif As Integer
        Try
            If SV.GetCifInfo(TxtCifColl.Text)(0) Is Nothing Then

            Else
                cus_class = SV.GetCifInfo(TxtCifColl.Text)(0)

                'ถ้า cif ที่ส่งมาไม่เท่ากับ 0 ให้ใส่ข้อมูลลูกค้าใส่ในคอนโทรลที่กำหนดให้
                If cus_class.Cif.ToString <> 0 Then
                    'ใช้คำนำหน้าชื่อที่ได้จาก Customer มาหา ID Title
                    ddlTitle.SelectedIndex = ddlTitle.Items.IndexOf(ddlTitle.Items.FindByText(cus_class.Cus_Title))
                    TxtCifNameColl.Text = cus_class.cus_first
                    TxtCifLastNameColl.Text = cus_class.cus_last
                    'Get_AID_BY_CIF()
                    If ddlAppraisal_Method.SelectedValue = 2 Then
                        GET_AID_BY_CIFNEW()
                    End If
                Else
                    'ถ้า cif ที่ส่งมาเท่ากับ 0 ให้ Clear ค่า  ในคอนโทรล
                    Dim l As New Label
                    'MessageBox("Format Exception: " & ex.Message)
                    l.Text = SV.MSb("ค้นหาข้อมูลลูกค้าไม่พบ ")
                    Page.Controls.Add(l)

                    TxtCifNameColl.Text = ""
                    TxtCifLastNameColl.Text = ""
                End If
            End If
        Catch ex As Exception
            Beep()
            lblMessage.Text = "ไม่มี รหัสลูกหนี้นี้อยู่บนระบบ"
            TxtCifName.Text = ""
            TxtCifLastName.Text = ""
        End Try

    End Sub
End Class
