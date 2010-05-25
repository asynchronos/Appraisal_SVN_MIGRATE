
Partial Class Appraisal_Building_Detail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            HiddenField1.Value = Request.QueryString("Req_Id")
            HiddenField2.Value = Request.QueryString("Hub_Id")
            HiddenField3.Value = Request.QueryString("Temp_AID")
            HiddenField4.Value = Request.QueryString("Id")
            lblId.Text = Request.QueryString("Id")
            If Request.QueryString("Id") = String.Empty Then
                ImageSave.Enabled = False
            End If
        End If
    End Sub

    Protected Sub ImageSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSave.Click

    End Sub
End Class
