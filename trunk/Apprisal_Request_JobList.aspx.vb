Imports System.Globalization

Partial Class Apprisal_Request_JobList
    Inherits System.Web.UI.Page

    '*********User Control ในการ Export ต้องเพิ่ม Code EnableEventValidation="false" ในหน้า HTML ด้วยถึงจะใช้ได้**********

    Protected Sub SqlGridView_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlGridView.Selecting
        Dim createDate As DateTime = Nothing

        Dim cul As New CultureInfo("th-TH")

        Try
            createDate = DateTime.Parse(TxtCalendar.Text, cul)
        Catch ex As Exception
            createDate = DateTime.Now
        End Try

        e.Command.Parameters.Item("@CREATE_DATE").Value = createDate
        'e.Command.Parameters.Item("@APP_TYPE_ID").Value = DropDownList2.SelectedValue
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim lblHub As Label = TryCast(Me.Form.FindControl("lblHub_Id"), Label)
        'Dim lblApptype_id As Integer = DropDownList2.SelectedValue

        If lblHub.Text = "0" Then
        Else
            DropDownList1.SelectedValue = lblHub.Text
        End If

    End Sub


    Sub BindDropDown()
        'รายการใน DropDownList
        DropDownListSearch.Items.Insert(0, New ListItem("", ""))
        DropDownListSearch.Items.Insert(1, New ListItem("CIF", "CIF"))
        DropDownListSearch.Items.Insert(2, New ListItem("รหัสพนักงาน", "Create_User"))
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindDropDown()
        End If
    End Sub
    Protected Sub SetFilter()
        Dim filterExpression As String = String.Empty
        If TxtSearch.Text <> String.Empty Then
            If DropDownListSearch.Items(DropDownListSearch.SelectedIndex).Value = "CIF" Then
                filterExpression = "CIF = " & TxtSearch.Text
            ElseIf DropDownListSearch.Items(DropDownListSearch.SelectedIndex).Value = "Create_User" Then
                filterExpression = "Create_User = " & TxtSearch.Text
            End If
        Else
            'filterExpression = "Hub_ID <> 0"
        End If
        SqlGridView.FilterExpression = filterExpression
        'Response.Write("Filter expression in effect is: " & filterExpression)
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        SetFilter()
    End Sub
End Class
