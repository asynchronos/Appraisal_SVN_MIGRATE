Imports System.Math

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
        Return Count
    End Function

    Function GetTotalPrice() As Decimal
        TotalPrice = Round(TotalPrice / 1000, System.MidpointRounding.AwayFromZero) * 1000
        Return TotalPrice
    End Function
End Class
