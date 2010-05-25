
Partial Class Appraisal_Building_List
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            TextBoxReq_Id.Text = Request.QueryString("Req_Id")
            TextBoxHub_Id.Text = Request.QueryString("Hub_id")
            TextBoxCif.Text = Request.QueryString("Cif")
            TextBoxAppraisal_Id.Text = Request.QueryString("Appraisal_Id")
            TextBoxCifName.Text = Request.QueryString("CifName")
        End If
    End Sub
End Class
