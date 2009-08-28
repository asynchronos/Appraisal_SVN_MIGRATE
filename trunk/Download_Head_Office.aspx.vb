
Partial Class Download_Head_Office
    Inherits System.Web.UI.Page

    Protected Sub ImageMannual1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageMannual1.Click
        Response.Redirect("~/headOffice/คู่มือ Appraisal (สำหรับ Admin).pdf")
    End Sub
    Protected Sub ImageMannual2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageMannual2.Click
        Response.Redirect("~/headOffice/Appraisal User Manual.pdf")
    End Sub
    Protected Sub ImageMannual3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageMannual3.Click
        Response.Redirect("~/headOffice/คู่มือ Appraisal (สำหรับหัวหน้าHub).pdf")
    End Sub

End Class
