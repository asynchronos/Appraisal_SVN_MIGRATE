
Partial Class colleteral_Detail
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Session("latTitude") = TextBox1.Text
        Session("longTitude") = TextBox2.Text
        Response.Redirect("MapColleteral.aspx")
    End Sub
End Class
