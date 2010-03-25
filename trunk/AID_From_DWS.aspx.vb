Imports System.Data.SqlClient
Imports System.Data.OracleClient
Imports System.Data

Partial Class AID_From_DWS
    Inherits System.Web.UI.Page

    Private Sub GET_AID_BY_CIFNEW(ByVal Cif As String)
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
              & " WHERE (DWHADMIN.CUS_PLED.CIF_NO =" & Cif & ") " _
              & " GROUP BY DWHADMIN.APPRAISAL_MASTER.APPRAISAL_ID"

        Dim cmd As OracleCommand = New OracleCommand(cmdQuery)
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text

        Try
            ' Execute command, create OracleDataReader object
            'ddlAID.Items.Clear()
            Dim reader As OracleDataReader = cmd.ExecuteReader()
            'While (reader.Read())
            '    ' Output Employee Name and Number
            '    ddlAID.Items.Add(reader.Item("APPRAISAL_ID"))
            'End While
            GridViewAID.DataSource = reader
            GridViewAID.DataBind()
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
        If Not Page.IsPostBack Then
            LabelCif.Text = Request.QueryString("Cif")
            GET_AID_BY_CIFNEW(LabelCif.Text)
        End If
    End Sub
End Class
