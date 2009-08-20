Imports Appraisal_Manager
Imports System.Xml.Serialization
Imports System.Xml
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Oracle.DataAccess.Client
Imports Microsoft.Win32
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Text
Imports System.Web.UI
Imports System.Web.UI.WebControls.WebParts
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Globalization.CultureInfo
Imports SME_SERVICE
Partial Class Appraisal_Form_Appraisal_FormRequest
    Inherits System.Web.UI.Page
    Dim s, StrNotice As String
#Region "Variables"
    Dim gvUniqueID As String = String.Empty
    Dim gvNewPageIndex As Integer = 0
    Dim gvEditIndex As Integer = -1
    Dim gvSortExpr As String = String.Empty
#End Region

    Private Property gvSortDir() As String
        Get
            Return IIf(TryCast(ViewState("SortDirection"), String) Is Nothing, "ASC", TryCast(ViewState("SortDirection"), String))
        End Get
        Set(ByVal value As String)
            ViewState("SortDirection") = value
        End Set
    End Property

    'This procedure returns the Sort Direction
    Private Function GetSortDirection() As String
        Select Case gvSortDir
            Case "ASC"
                gvSortDir = "DESC"
                Exit Select
            Case "DESC"
                gvSortDir = "ASC"
                Exit Select
        End Select
        Return gvSortDir
    End Function

    Private Function ChildDataSource(ByVal strRegId As Integer, ByVal strSort As String) As SqlDataSource
        Dim strQRY As String = ""
        Dim dsTemp As New SqlDataSource
        Dim conn As String = "server=172.19.54.2;Database=Appraisal;User ID=sa;Password=sa0123"

        dsTemp.ConnectionString = conn

        strQRY = "SELECT dbo.Appraisal_Request_Master.Req_ID, dbo.Appraisal_Request.Hub_ID, dbo.TB_HUB.HUB_NAME" _
                 & " FROM dbo.Appraisal_Request_Master INNER JOIN" _
                 & " dbo.Appraisal_Request ON dbo.Appraisal_Request_Master.Req_ID = dbo.Appraisal_Request.Req_ID INNER JOIN" _
                 & " dbo.TB_HUB ON dbo.Appraisal_Request.Hub_ID = dbo.TB_HUB.HUB_ID WHERE dbo.Appraisal_Request_Master.Req_ID = " & strRegId & ""
        dsTemp.SelectCommand = strQRY
        Return dsTemp
    End Function

#Region "GridView1 Event Handlers"
    'Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
    '    Dim row As GridViewRow = e.Row
    '    Dim strSort As String = String.Empty

    '    ' Make sure we aren't in header/footer rows 
    '    If row.DataItem Is Nothing Then
    '        Return
    '    End If

    '    'Find Child GridView control 
    '    Dim gv As New GridView()
    '    gv = DirectCast(row.FindControl("GridView2"), GridView)

    '    'Check if any additional conditions (Paging, Sorting, Editing, etc) to be applied on child GridView 
    '    If gv.UniqueID = gvUniqueID Then
    '        gv.PageIndex = gvNewPageIndex
    '        gv.EditIndex = gvEditIndex
    '        'Check if Sorting used 
    '        If gvSortExpr <> String.Empty Then
    '            GetSortDirection()
    '            strSort = " ORDER BY " + String.Format("{0} {1}", gvSortExpr, gvSortDir)
    '        End If
    '        'Expand the Child grid 
    '        ClientScript.RegisterStartupScript([GetType](), "Expand", "<SCRIPT LANGUAGE='javascript'>expandcollapse('div" + DirectCast(e.Row.DataItem, DataRowView)("Q_ID").ToString() + "','one');</script>")
    '    End If

    '    'Prepare the query for Child GridView by passing the Customer ID of the parent row 
    '    gv.DataSource = ChildDataSource(DirectCast(e.Row.DataItem, DataRowView)("Req_Id").ToString(), strSort)
    '    gv.DataBind()
    'End Sub
#End Region

#Region "GridView2 Event Handlers"
    Protected Sub GridView2_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Dim gvTemp As GridView = DirectCast(sender, GridView)
        gvUniqueID = gvTemp.UniqueID
        gvNewPageIndex = e.NewPageIndex
        'GridView1.DataBind()
    End Sub

    Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then

            If DirectCast(e.Row.DataItem, DataRowView)("Req_ID").ToString() = String.Empty Then
                e.Row.Visible = False
            End If
        End If

    End Sub

    Protected Sub GridView2_Sorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs)
        Dim gvTemp As GridView = DirectCast(sender, GridView)
        gvUniqueID = gvTemp.UniqueID
        gvSortExpr = e.SortExpression
        'GridView1.DataBind()
    End Sub

#End Region

    'Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
    '    If RadioButtonList1.SelectedValue = "1" Then
    '        lblMessage.Text = "Cif ไม่จำเป็นต้องใส่ หากไม่ทราบ"
    '    Else
    '        lblMessage.Text = "Cif จำเป็นต้องใส่ ทุกครั้ง"
    '    End If
    'End Sub

    Protected Sub cb1_Checked(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb1 As CheckBox = sender
        For Each gdi As GridViewRow In GridView_HubList.Rows
            If gdi.RowType = DataControlRowType.DataRow Then
                Dim cb2 As CheckBox = gdi.Cells(0).FindControl("cb2")
                cb2.Checked = cb1.Checked
            End If
        Next
    End Sub

    Protected Sub Button_Load(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim cph As ContentPlaceHolder = TryCast(Me.Form.FindControl("ContentPlaceHolder1"), ContentPlaceHolder) 'หา Control จาก Master Page ที่ control อยู่ใน  ContentPlaceHolder1
        Dim B1 As Button = DirectCast(sender, Button)
        Dim chkbox As CheckBox = B1.Parent.FindControl("cb2")
        'Dim lblHub As Label = B1.Parent.FindControl("lblHUB_ID")
        Dim lblHub As Label = TryCast(Me.Form.FindControl("lblHub_Id"), Label)
        Dim ReqId As Label = DirectCast(cph.FindControl("lblRequestID"), Label) 'Me.FindControl("lblRequestID")

        Dim S1 As String = Nothing
        S1 = "link_url('" + Page.ResolveUrl("~/Upload_Form/Upload_Request_Form.aspx") + "','popup',500,300,'" + chkbox.ClientID + "','" + ReqId.ClientID + "','" + lblHub.ClientID + "'); return false;"
        B1.Attributes.Add("onclick", S1)


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

    Protected Sub imgBtnSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnSave.Click
        'Code Save

        Dim cph As ContentPlaceHolder = TryCast(Me.Form.FindControl("ContentPlaceHolder1"), ContentPlaceHolder)
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label) 'หา Control จาก Master Page ที่ control ไม่อยู่ใน  ContentPlaceHolder1
        Dim lblHub_id As Label = TryCast(Me.Form.FindControl("lblHub_Id"), Label)
        If TxtSender.Text = "" Then
            s = "<script language=""javascript"">alert('คุณไม่มีรหัสผู้ให้ประเมิน กรุณากรอกรหัสผู้ให้ประเมินก่อน');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", s)
            Exit Sub
        End If
        If TxtAppraisalName.Text = "" Then
            s = "<script language=""javascript"">alert('คุณไม่มีชื่อผู้ให้ประเมิน กรุณากรอกชื่อผู้ให้ประเมินก่อน');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", s)
            Exit Sub
        End If


        If ddlAppraisal_Method.SelectedValue = 1 Then
        Else
            If TxtCif.Text = "" Then
                s = "<script language=""javascript"">alert('คุณไม่มีรหัสลูกหนี้ กรุณากรอกรหัสลูกหนี้ก่อน');</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", s)
                Exit Sub
            End If
            If ddlAID.SelectedValue = String.Empty Then
                s = "<script language=""javascript"">alert('คุณไม่มีรหัส AID กรุณากรอกรหัส AID ก่อน');</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", s)
                Exit Sub
            End If
        End If

        If lblRequestID.Text <> String.Empty Then
            Dim dg As GridView = DirectCast(cph.FindControl("GridView_HubList"), GridView) 'FindControl("GridView_HubList")
            Dim gvr_master As GridViewRow
            Appraisal_Manager.AddAppraisal_Request_Master(lblRequestID.Text, TxtCif.Text, ddlTitle.SelectedValue, TxtCifName.Text, TxtCifLastName.Text, ddlAppraisal_Method.SelectedValue, ddlAID.SelectedValue, 0, TxtSender.Text, TxtAppraisalName.Text, lbluserid.Text, Now)

            For Each gvr_master In dg.Rows
                Dim chk1 As CheckBox = gvr_master.FindControl("cb2")
                Dim lblHubID As Label = gvr_master.FindControl("lblHUB_ID")
                If chk1.Checked = True Then
                    AddAppraisal_Request(lblRequestID.Text, lblHubID.Text, TxtCif.Text, ddlTitle.SelectedValue, TxtCifName.Text, TxtCifLastName.Text, ddlAppraisal_Method.SelectedValue, 0, String.Empty, lbluserid.Text, Now)
                End If
            Next
            StrNotice = "<Script language=""javascript"">alert('บันทึกการส่งประเมินเสร็จสมบูรณ์');</Script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", StrNotice)
            Dim btnRequestId As Button = DirectCast(cph.FindControl("bntRequest_ID"), Button)
            btnRequestId.Enabled = True
            Dim imgBtnSave As ImageButton = DirectCast(cph.FindControl("imgBtnSave"), ImageButton)
            imgBtnSave.Enabled = False
        Else
            lblMessage.Text = "ยังไม่มีเลขที่คำขอประเมิน"
        End If
        'GridView1.DataBind()

        'กำหนดให้ไปเพิ่มหลักประกันในกรณีเป็นการทบทวนการประเมิน
        If ddlAppraisal_Method.SelectedValue >= 2 Then
            Dim dg As GridView = DirectCast(cph.FindControl("GridView_HubList"), GridView) 'FindControl("GridView_HubList")
            Dim gvr_master As GridViewRow
            Dim HubId As String = ""
            For Each gvr_master In dg.Rows
                Dim chk1 As CheckBox = gvr_master.FindControl("cb2")
                Dim lblHubID As Label = gvr_master.FindControl("lblHUB_ID")

                If chk1.Checked = True Then
                    HubId = lblHubID.Text
                End If
            Next
            Context.Items("Req_Id") = lblRequestID.Text  'Request.QueryString("Req_Id")
            Context.Items("Hub_Id") = HubId 'Request.QueryString("Hub_Id")
            Context.Items("Cif") = TxtCif.Text  'Request.QueryString("Cif")
            Context.Items("AID") = ddlAID.SelectedValue   'Request.QueryString("Aid")

            'ถ้าหากมีการประเมินแล้วในระบบให้ไปหาข้อมูลจากในระบบตาม AID นั้นในราคาที่ 3 และดูจากเลขคำขอประเมินล่าสุด
            'ถ้าหากยังไม่มีข้อมูลการประเมินให้ไปดึงข้อมูลจาก Data warehouse
            Dim Obj_P3M As List(Of clsPrice3_Master) = GET_PRICE3_MASTER(lblRequestID.Text, HubId)
            'หา PRICE3_MASTER หากมีจะดึงข้อมูลเดิมมาให้
            If Obj_P3M.Count > 0 Then
                'หน้าแสดงรายการประเมินในระบบที่เคยประเมินแล้ว
            Else
                Server.Transfer("Appraisal_GetData_DWS.aspx")
            End If

        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If lblRequestID.Text = String.Empty Or lblRequestID.Text = "" Then
                lblMessage.Text = "คุณยังไม่มีเลขคำขอประเมิน"
                GridView_HubList.Enabled = False
            Else
                lblMessage.Text = ""
            End If
        End If

    End Sub

    Protected Sub bntRequest_ID_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bntRequest_ID.Click
        Dim cph As ContentPlaceHolder = TryCast(Me.Form.FindControl("ContentPlaceHolder1"), ContentPlaceHolder)
        Dim ds As DataSet
        If TxtCifName.Text = String.Empty And TxtCifLastName.Text = String.Empty Then
            s = "<script language=""javascript"">alert('คุณไม่ได้ใส่ชื่อ และ สกุล ลูกค้าประเมิน');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)
        ElseIf TxtSender.Text = String.Empty Or TxtAppraisalName.Text = String.Empty Then
            s = "<script language=""javascript"">alert('คุณไม่มีชื่อผู้ให้ประเมิน กรุณากรอกชื่อผู้ให้ประเมินก่อน');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", s)
        Else
        ds = GET_RequestID()
        If ds.Tables(0).Rows.Count > 0 Then
            lblRequestID.Text = ds.Tables(0).Rows.Item(0).Item("Req_ID")
            Dim btnRequestId As Button = DirectCast(cph.FindControl("bntRequest_ID"), Button)
            btnRequestId.Enabled = False
        Else
            'lblRequestID.Text = ""
        End If

        If lblRequestID.Text = String.Empty Or lblRequestID.Text = "" Then
            lblMessage.Text = "คุณยังไม่มีเลขคำขอประเมิน"
            GridView_HubList.Enabled = False
        Else
            GridView_HubList.Enabled = True
            lblMessage.Text = ""
            UPDATE_REQUEST_ID()
            'imgBtnSave.Enabled = True
            Dim imgBtnSave As ImageButton = DirectCast(cph.FindControl("imgBtnSave"), ImageButton)
            imgBtnSave.Enabled = True
        End If
        End If

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

    Private Sub Get_AID_BY_CIF()

        ' Create the connection object
        Dim con As OracleConnection = New OracleConnection()

        ' Specify the connect string
        con.ConnectionString = "User Id=cpr214361;Password=newyear2009;Data Source=edw;"
        ' Open the connection

        con.Open()

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
            's = "<script language=""javascript"">alert('มีข้อผิดพลาด ค้นหาไม่พบ');</script>"
            'Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", s)
            'MsgBox(ex.Message)
            Throw New Exception(ex.Message & " : " & ex.StackTrace)
        Finally

            ' Dispose OracleCommand object
            cmd.Dispose()

            ' Close and Dispose OracleConnection object
            con.Close()
            con.Dispose()
        End Try
    End Sub

    Private Sub GET_AID_BY_CIFNEW()
        'Dim oradb As String = "Data Source=(DESCRIPTION=" _
        '    + "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.32.52)(PORT=1521)))" _
        '    + "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=edw)));" _
        '    + "User Id=cpr214361;Password=newyear2009;"
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

    'Protected Sub ImgBtFindEmp_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtFindEmp.Click
    '    Dim Emp_class As Employee_Info
    '    Dim SV As New SME_SERVICE.Service

    '    If TxtSender.Text = String.Empty Then
    '        s = "<script language=""javascript"">alert('คุณยังไม่ใส่รหัสผู้ขอให้ประเมิน');</script>"
    '        Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)
    '    Else
    '        Emp_class = SV.GetEmployee_Info(TxtSender.Text)(0)
    '        If Emp_class.EmpId.ToString <> 0 Then
    '            TxtAppraisalName.Text = Emp_class.EmpName
    '        Else
    '            s = "<script language=""javascript"">alert('ไม่พบรหัสผู้ขอให้ประเมินบนฐานข้อมูล');</script>"
    '            Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)
    '            TxtSender.Text = String.Empty
    '            TxtAppraisalName.Text = String.Empty
    '        End If
    '    End If

    'End Sub

    Protected Sub ImgBtSearchEmp_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtSearchEmp.Click
        Dim myScript As String
        myScript = "<script>" + "window.open('Search_Employee.aspx?empid=" & TxtSender.ClientID & "&empname=" & TxtAppraisalName.ClientID & "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, directories=no, status=yes,height=550px,width=650px');</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType, "Search", myScript)
    End Sub
End Class

