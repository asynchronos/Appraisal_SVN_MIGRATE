Imports Appraisal_Manager
Imports System.Xml.Serialization
Imports System.Xml
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Win32

Partial Class Define_SecondPrice
    Inherits System.Web.UI.Page
    Dim SV As New SME_SERVICE.Service
    Dim P2 As Price2_ShortForm
    Dim str As String
    Dim s As String
    Dim tempaid As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblQueueID.Text = Request.QueryString("Qid")
            lblCif.Text = Request.QueryString("Cif")
            SearchCif()

            'Dim DS As DataSet
            'DS = CreateDataset()

        End If
        'tempaid = ddlGroup_TempAID.SelectedValue
    End Sub

    Private Sub SearchCif()
        Dim obj As SME_SERVICE.Customer_Class
        If lblCif.Text <> String.Empty Then
            obj = SV.GetCifInfo(CInt(lblCif.Text))(0)
            lblCifName.Text = obj.cifName
            lblDepartName.Text = obj.departName
        End If

    End Sub

    'Protected Sub ImgBtFind_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtFind.Click
    '    Dim s1 As String
    '    str = Request.ApplicationPath & "/View_Group_Temp_AID.aspx?Temp_Aid=" & ddlGroup_TempAID.SelectedValue & "&Q_ID=" & lblQueueID.Text
    '    s1 = "<script>" _
    '            & "function PopupCenter() {" _
    '            & "var left = (screen.width/2)-(650/2);" _
    '            & "var top = (screen.height/2)-(400/2);" _
    '            & "var targetWin = window.open ('" + str + "','window', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width='+w+', height='+h+', top='+top+', left='+left);" _
    '                & "}" _
    '        & "</script>"

    '    '<a href="javascript:void(0);" onclick="PopupCenter('http://www.nigraphic.com', 'myPop1',400,400);">CLICK TO OPEN POPUP</a>

    '    'Dim w As String = "650px"
    '    'Dim h As String = "400px"
    '    'Dim left As String = "(screen.width/2)-(650/2);"
    '    'Dim top As String = "(screen.height/2)-(400/2);"

    '    'str = Request.ApplicationPath & "/View_Group_Temp_AID.aspx?Temp_Aid=" & ddlGroup_TempAID.SelectedValue & "&Q_ID=" & lblQueueID.Text

    '    s = "<script language=""javascript"">window.open('" + str + "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, directories=no, status=yes,height=400px,width=650px');</script>"

    '    Page.ClientScript.RegisterStartupScript(Me.GetType, "จัดกลุ่ม", s)
    'End Sub

    'Private Function CreateDataset() As DataSet

    '    'For Print Data Out
    '    Dim DS As DataSet
    '    Dim MyConnection As SqlConnection
    '    Dim MyDataAdapter As SqlDataAdapter

    '    MyConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)

    '    MyDataAdapter = New SqlDataAdapter("GET_TOTAL_COLLTYPE", MyConnection)
    '    MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
    '    MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Q_ID", SqlDbType.Int))
    '    MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@PreAID", SqlDbType.Int))
    '    MyDataAdapter.SelectCommand.Parameters("@Q_ID").Value = lblQueueID.Text
    '    MyDataAdapter.SelectCommand.Parameters("@PreAID").Value = ddlGroup_TempAID.SelectedValue

    '    DS = New DataSet() 'Create a new DataSet to hold the records.
    '    MyDataAdapter.Fill(DS, "GET_TOTAL_COLLTYPE") 'Fill the DataSet with the rows returned.
    '    Return DS

    'End Function

    'Protected Sub ddlGroup_TempAID_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlGroup_TempAID.DataBound
    '    Dim DS As DataSet
    '    DS = CreateDataset()
    '    If DS.Tables(0).Rows.Count > 0 Then
    '        For i = 1 To DS.Tables(0).Rows.Count
    '            If DS.Tables(0).Rows.Item(0).Item("CollType") = 5 Then
    '                'txtRai.Text = DS.Tables(0).Rows.Item(0).Item("rai")
    '                'txtNgan.Text = DS.Tables(0).Rows.Item(0).Item("ngan")
    '                'txtWah.Text = DS.Tables(0).Rows.Item(0).Item("wah")
    '            ElseIf DS.Tables(0).Rows.Item(0).Item("CollType") = 7 Then

    '            ElseIf DS.Tables(0).Rows.Item(0).Item("CollType") = 6 Then
    '            End If
    '        Next
    '    End If
    'End Sub

    'Protected Sub ddlGroup_TempAID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlGroup_TempAID.SelectedIndexChanged
    '    Dim DS As DataSet
    '    DS = CreateDataset()
    '    If DS.Tables(0).Rows.Count > 0 Then
    '        For i = 1 To DS.Tables(0).Rows.Count
    '            If DS.Tables(0).Rows.Item(0).Item("CollType") = 5 Then
    '                'txtRai.Text = DS.Tables(0).Rows.Item(0).Item("rai")
    '                'txtNgan.Text = DS.Tables(0).Rows.Item(0).Item("ngan")
    '                'txtWah.Text = DS.Tables(0).Rows.Item(0).Item("wah")
    '            ElseIf DS.Tables(0).Rows.Item(0).Item("CollType") = 7 Then

    '            ElseIf DS.Tables(0).Rows.Item(0).Item("CollType") = 6 Then
    '            End If
    '        Next
    '    End If
    'End Sub

    Protected Sub DDLRoad_Detail_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim D1 As DropDownList = DirectCast(sender, DropDownList)
        If Not Page.IsPostBack Then
            D1.DataSource = SDSRoad_Detail

            'MsgBox(D1.DataTextField)
            D1.DataTextField = "Road_Detail_Name"
            D1.DataValueField = "Road_Detail_ID"
            D1.DataBind()
        End If
    End Sub

    Protected Sub ImgBtFind0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtFind0.Click
        If DDLCollType.SelectedValue = String.Empty Or ddlGroup_TempAID.SelectedValue = String.Empty Then
            lblMessage.Text = "คุณไม่สามารถกำหนดราคาหลักประกันราคาที่ 2 ได้"
        Else
            lblMessage.Text = ""
            If DDLCollType.SelectedValue = "50" Then
                str = Request.ApplicationPath & "/Add_CollType50.aspx?Temp_Aid=" & ddlGroup_TempAID.SelectedValue & "&Q_ID=" & lblQueueID.Text & "&CollType=" & DDLCollType.SelectedValue & "&Cif=" & lblCif.Text
            ElseIf DDLCollType.SelectedValue = "60" Then
            ElseIf DDLCollType.SelectedValue = "70" Then
                str = Request.ApplicationPath & "/Add_CollType70.aspx?Temp_Aid=" & ddlGroup_TempAID.SelectedValue & "&Q_ID=" & lblQueueID.Text & "&CollType=" & DDLCollType.SelectedValue & "&Cif=" & lblCif.Text
            ElseIf DDLCollType.SelectedValue = "80" Then
            ElseIf DDLCollType.SelectedValue = "90" Then
            ElseIf DDLCollType.SelectedValue = "12" Then
            ElseIf DDLCollType.SelectedValue = "15 Then" Then
            ElseIf DDLCollType.SelectedValue = "18" Then
            End If

            s = "<script language=""javascript"">window.open('" + str + "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, copyhistory=no, directories=no, status=yes,height=550px,width=1100px');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "จัดกลุ่ม", s)
        End If

    End Sub
End Class
