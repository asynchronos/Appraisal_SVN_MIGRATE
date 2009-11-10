
Partial Class LongDoMap
    Inherits System.Web.UI.Page

    Protected Sub BtnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        'Dim EMP_ID As String = HttpUtility.HtmlDecode(GridView1.Rows(GridView1.SelectedIndex).Cells(1).Text).Trim
        'Dim EMP_NAME As String = HttpUtility.HtmlDecode(GridView1.Rows(GridView1.SelectedIndex).Cells(2).Text & GridView1.Rows(GridView1.SelectedIndex).Cells(3).Text & " " & GridView1.Rows(GridView1.SelectedIndex).Cells(4).Text).Trim
        Dim lat As String = TxtLat.Text
        Dim lng As String = TxtLng.Text
        Dim S As String = "<script language='javascript'>"
        'S += "alert(window.opener.location);"
        S += "window.opener.document.getElementById('" & Request.QueryString("lat") & "').value  ='" & lat & "';"
        S += "window.opener.document.getElementById('" & Request.QueryString("lng") & "').value  ='" & lng & "';"
        S += "window.close();</script>"
        'Page.ClientScript.RegisterStartupScript(Me.GetType, "Longdo", S, True)

        Response.Write(S)
        'ScriptManager.RegisterStartupScript(Page, GetType(), "MyScript", alert(" + DateTime.Now.Millisecond + ");", true);
    End Sub
End Class
