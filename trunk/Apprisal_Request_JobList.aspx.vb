Imports System.Globalization

Partial Class Apprisal_Request_JobList
    Inherits System.Web.UI.Page

    Protected Sub SqlGridView_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlGridView.Selecting
        Dim createDate As DateTime = Nothing

        Dim cul As New CultureInfo("th-TH")

        Try
            createDate = DateTime.Parse(TxtCalendar.Text, cul)
        Catch ex As Exception
            createDate = DateTime.Now
        End Try

        e.Command.Parameters.Item("@CREATE_DATE").Value = createDate
    End Sub
End Class
