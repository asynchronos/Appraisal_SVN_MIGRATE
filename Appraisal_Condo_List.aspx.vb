
Partial Class Appraisal_Condo_List
    Inherits System.Web.UI.Page
    Dim TotalPrice As Decimal = 0.0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            TextBoxReq_Id.Text = Request.QueryString("Req_Id")
            TextBoxHub_Id.Text = Request.QueryString("Hub_id")
            TextBoxCif.Text = Request.QueryString("Cif")
            TextBoxAppraisal_Id.Text = Request.QueryString("Appraisal_Id")
            TextBoxCifName.Text = Request.QueryString("CifName")
            HiddenApprisalType.Value = Request.QueryString("Appraisal_Type")
            HiddenLandPrice.Value = CDec(Request.QueryString("LandPriceValue"))
        End If
    End Sub
    Function GetPrice(ByVal Count As Decimal) As Decimal
        TotalPrice += Count
        'If Request.QueryString("Appraisal_Type") = 1 Then
        '    Return 0
        'Else
        Return Count
        'End If

    End Function

    Function GetTotalPrice() As Decimal
        'If Request.QueryString("Appraisal_Type") = 1 Then
        '    Return 0
        'Else
        Return TotalPrice
        'End If

    End Function
End Class
