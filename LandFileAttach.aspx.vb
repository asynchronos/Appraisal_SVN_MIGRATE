
Partial Class LandFileAttach
    Inherits System.Web.UI.Page


    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        LabelReqIdValue.Text = Context.Items("Req_Id")
        LabelCifValue.Text = Context.Items("Cif")
        LabelCifNameValue.Text = Context.Items("CifName")
    End Sub
End Class
