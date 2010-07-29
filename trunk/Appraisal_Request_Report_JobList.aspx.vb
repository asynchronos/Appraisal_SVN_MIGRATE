Imports System.Globalization

Partial Class Appraisal_Request_Report_JobList
    Inherits System.Web.UI.Page
    Dim filterExpression As String = String.Empty
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            'BindDropDown()
            'SetFilter()
        End If

    End Sub

    Protected Sub SetFilter()
        LabelWhereCondition.Text = ""
        filterExpression = " AR.Req_ID <> 0 "
        If TextBoxEmp_Id.Text = String.Empty Then
            filterExpression = filterExpression
        Else
            filterExpression = filterExpression & " AND AR.CREATE_USER = " & "'" & TextBoxEmp_Id.Text & "'"
        End If

        If TextBoxCIF.Text = String.Empty Then
            filterExpression = filterExpression
        Else
            filterExpression = filterExpression & " AND AR.Cif = " & "'" & TextBoxCIF.Text & "'"
        End If

        If DropDownListHub.SelectedValue = 0 Then
            filterExpression = filterExpression
        Else
            filterExpression = filterExpression & " AND AR.Hub_ID = " & DropDownListHub.SelectedValue
        End If

        If DropDownListApptype.SelectedValue = 0 Then
            filterExpression = filterExpression
        Else
            filterExpression = filterExpression & " AND AR.APP_TYPE_ID = " & DropDownListApptype.SelectedValue
        End If

        If TxtCalendar.Text = String.Empty Then
            filterExpression = filterExpression
        Else
            Dim createDate As DateTime = Nothing
            Dim cul As New CultureInfo("th-TH")

            Try
                createDate = DateTime.Parse(TxtCalendar.Text, cul)
                Dim Startdate As String = "CONVERT(datetime,'" + createDate.ToString("dd/MM/yyyy", New CultureInfo("en-US")) + "',103)"
                Dim EndDate As String = "dateadd(day,1,CONVERT(datetime,'" + createDate.ToString("dd/MM/yyyy", New CultureInfo("en-US")) + "',103))"
                filterExpression = filterExpression & " AND AR.Create_Date >= " + Startdate + " AND AR.Create_Date < " + EndDate + ""
            Catch ex As Exception
                createDate = DateTime.Now
                filterExpression = filterExpression & " AND AR.Create_Date = " & createDate
            End Try

        End If
        LabelWhereCondition.Text = filterExpression
        'SqlDataSourceReportList.FilterExpression = LabelWhereCondition.Text 'filterExpression
        'Response.Write("Filter expression in effect is: " & filterExpression)
    End Sub

    Protected Sub ButtonSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSearch.Click
        SetFilter()
    End Sub


    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        SetFilter()
    End Sub

End Class
