Imports System.Data

Partial Class Appraisal_Step_Follow
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindDropDown()
        End If
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim lblHub As Label = TryCast(Me.Form.FindControl("lblHub_Id"), Label)
        Dim lblUserId As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        Dim USER_LOGIN As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        HiddenHubId.Value = lblHub.Text
        hdfAppraisal_Id.Value = lblUserId.Text
        HdfUSER_LOGIN.Value = USER_LOGIN.Text
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'If (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Cnt_Item")) = "3") Then
            '    'e.Row.BackColor = System.Drawing.Color.Yellow
            'Else
            '    e.Row.BackColor = System.Drawing.Color.Yellow
            'End If
            Dim imgbtnCancel As ImageButton = DirectCast(e.Row.Cells(12).FindControl("imgCancel"), ImageButton)
            If (Session("sGroup_Id") = "1") Then
                imgbtnCancel.Visible = True
                HdfStatus.Value = 99
            ElseIf (Session("sGroup_Id") = "3") Then
                imgbtnCancel.Visible = True
                HdfStatus.Value = 97
            Else
                imgbtnCancel.Visible = False
                HdfStatus.Value = 98
            End If
        End If
    End Sub

    Sub BindDropDown()
        DropDownListOptionSearch.Items.Insert(0, New ListItem("รหัสเลขคำขอประเมิน", "Req_ID"))
        DropDownListOptionSearch.Items.Insert(1, New ListItem("CIF", "CIF"))
        DropDownListOptionSearch.Items.Insert(2, New ListItem("รหัสศูนย์/รหัส HUB", "Hub_ID"))
    End Sub

    Protected Sub ButtonSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSearch.Click
        SetFilter()
    End Sub

    Protected Sub SetFilter()
        Dim filterExpression As String = String.Empty
        If TextBoxSearchValue.Text <> String.Empty Then
            If DropDownListOptionSearch.Items(DropDownListOptionSearch.SelectedIndex).Value = "Req_ID" Then
                filterExpression = "REQ_ID = " & TextBoxSearchValue.Text
            ElseIf DropDownListOptionSearch.Items(DropDownListOptionSearch.SelectedIndex).Value = "CIF" Then
                filterExpression = "CIF LIKE '" & TextBoxSearchValue.Text & "*'"
            ElseIf DropDownListOptionSearch.Items(DropDownListOptionSearch.SelectedIndex).Value = "Hub_ID" Then
                filterExpression = "Hub_ID = " & TextBoxSearchValue.Text
            End If
        Else
            filterExpression = "Hub_ID <> 0"
        End If
        SqlDataSource1.FilterExpression = filterExpression
        'Response.Write("Filter expression in effect is: " & filterExpression)
    End Sub

End Class
