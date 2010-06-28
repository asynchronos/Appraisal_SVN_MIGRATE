
Partial Class Appraisal_Assign_Job2Emp
    Inherits System.Web.UI.Page

    Protected Sub cb1_Checked(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb1 As CheckBox = sender
        Dim cnt As Integer = 0
        For Each gdi As GridViewRow In GridView1.Rows
            cnt = cnt + 1
            If gdi.RowType = DataControlRowType.DataRow Then
                Dim cb2 As CheckBox = gdi.Cells(0).FindControl("cb2")
                cb2.Checked = cb1.Checked
            End If
        Next
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindDropDown()
        End If
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim USER_LOGIN As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        HdfUSER_LOGIN.Value = USER_LOGIN.Text
    End Sub
    Sub BindDropDown()
        DropDownListOptionSearch.Items.Insert(0, New ListItem("รหัสเลขคำขอประเมิน", "EMP_ID"))
        DropDownListOptionSearch.Items.Insert(1, New ListItem("CIF", "CIF"))
        DropDownListOptionSearch.Items.Insert(2, New ListItem("รหัสศูนย์/รหัส HUB", "Hub_ID"))
    End Sub
End Class
