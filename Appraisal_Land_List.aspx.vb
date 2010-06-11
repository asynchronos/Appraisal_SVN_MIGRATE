Imports Appraisal_Manager
Imports AjaxControlToolkit

Partial Class Appraisal_Land_List
    Inherits System.Web.UI.Page
    Dim TotalPrice As Decimal = 0.0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            TextBoxReq_Id.Text = Request.QueryString("Req_Id")
            TextBoxHub_Id.Text = Request.QueryString("Hub_id")
            TextBoxCif.Text = Request.QueryString("Cif")
            TextBoxAppraisal_Id.Text = Request.QueryString("Appraisal_Id")
            TextBoxCifName.Text = Request.QueryString("CifName")
        End If

    End Sub

    'Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        Dim Ib As ImageButton = DirectCast(e.Row.Cells(10).FindControl("imgDetail"), ImageButton)
    '        Dim ID As Label = DirectCast(e.Row.Cells(0).FindControl("LabelID"), Label)
    '        Dim Temp_AID As Label = DirectCast(e.Row.Cells(1).FindControl("LabelTemp_AID"), Label)

    '        Ib.Attributes.Add("onclick", "return changeEditLandIframeSrc('" & ID.Text & ", " & Temp_AID.Text & "');")
    '        ModalPopupExtenderLandEdit.Show()

    '    End If

    'End Sub

    Protected Sub imgDetail_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim imgEditLand As ImageButton = DirectCast(sender, ImageButton)
        Dim ID As Label = imgEditLand.Parent.FindControl("LabelID")
        Dim Temp_AID As Label = imgEditLand.Parent.FindControl("LabelTemp_AID")
        Dim PopupModal As ModalPopupExtender = Me.FindControl("ModalPopupExtenderLandEdit")
        'MsgBox(PopupModal.BehaviorID)
        Response.Redirect("Appraisal_Land.aspx?Req_Id=" & TextBoxReq_Id.Text & "&Hub_Id=" & TextBoxHub_Id.Text & "&Cif=" & TextBoxCif.Text & "&CifName=" & TextBoxCifName.Text & "&Appraisal_Id=" & TextBoxAppraisal_Id.Text & "&ID=" & ID.Text & "&Temp_AID=" & Temp_AID.Text & "&PopupModal=" & PopupModal.BehaviorID)
        'ModalPopupExtenderLandEdit.Show()
    End Sub


    Function GetPrice(ByVal Count As Decimal) As Decimal
        TotalPrice += Count
        If Request.QueryString("Appraisal_Type") = 1 Then
            Return 0
        Else
            Return Count
        End If

    End Function

    Function GetTotalPrice() As Decimal
        If Request.QueryString("Appraisal_Type") = 1 Then
            Return 0
        Else
            Return TotalPrice
        End If

    End Function
End Class
