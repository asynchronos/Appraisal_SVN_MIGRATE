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

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim lblHub As Label = TryCast(Me.Form.FindControl("lblHub_Id"), Label)
        If lblHub.Text = "0" Then
        Else
            DropDownList1.SelectedValue = lblHub.Text
        End If

    End Sub
End Class
