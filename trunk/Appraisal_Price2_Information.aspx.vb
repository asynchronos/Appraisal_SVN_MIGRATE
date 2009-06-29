
Partial Class Appraisal_Price2_Information
    Inherits System.Web.UI.Page


    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        lblReq_Id.Text = Request.QueryString("Req_Id")
        lblHub_Id.Text = Request.QueryString("Hub_Id")
        lblHub_Name.Text = Request.QueryString("HubName")
        'MsgBox(lblHubName.Text)
        lblCif.Text = Request.QueryString("Cif")
        'MsgBox(lblCif.Text)
        lblCifName.Text = Request.QueryString("CifName")
        'MsgBox(lblCifName.Text)
    End Sub
End Class
