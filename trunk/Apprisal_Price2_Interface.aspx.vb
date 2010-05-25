
Partial Class Apprisal_Price2_Interface
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Request.QueryString("CollType") = "50" Then
                pLand.Visible = True
                pBuilding.Visible = False
                pCondo.Visible = False
            ElseIf Request.QueryString("CollType") = "70" Then
                pLand.Visible = True
                pBuilding.Visible = True
                pCondo.Visible = False
            ElseIf Request.QueryString("CollType") = "18" Then
                pLand.Visible = False
                pBuilding.Visible = False
                pCondo.Visible = True
            End If
            'TextBoxLand.Text = "0"
            'TextBoxGrandTotal.Text = Format(CDec(TextBoxLand.Text) + CDec(TextBoxBuilding.Text) + CDec(TextBoxCondo.Text), "#,##0.00")
        End If

    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        TextBoxReq_Id.Text = Request.QueryString("Req_Id")
        TextBoxHub_Id.Text = Request.QueryString("Hub_id")
        TextBoxCif.Text = Request.QueryString("Cif")
        TextBoxCifName.Text = Request.QueryString("CifName")
        TextBoxAppraisal_Id.Text = Request.QueryString("Appraisal_Id")
    End Sub
End Class
