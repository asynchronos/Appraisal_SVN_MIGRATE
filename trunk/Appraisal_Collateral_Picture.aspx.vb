
Partial Class Appraisal_Collateral_Picture
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            sdsPictureList_Price1.SelectParameters.Clear()
            sdsPictureList_Price1.SelectCommand = "GET_APPRAISAL_PRICE1_PICTUREPATH"
            sdsPictureList_Price1.SelectCommandType = SqlDataSourceCommandType.StoredProcedure
            sdsPictureList_Price1.SelectParameters.Add("Req_Id", Request.QueryString("Req_Id"))


            lvShowPicture_P1.DataSource = sdsPictureList_Price1

            lvShowPicture_P1.DataBind()
        End If
    End Sub

    Protected Sub sdsPictureList_Price1_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceStatusEventArgs) Handles sdsPictureList_Price1.Selected
        If e.AffectedRows = 0 Then
            LabelMessage.Visible = True
            LabelMessage.Text = "ไม่มีรูปภาพหลักประกัน"
        Else
            LabelMessage.Visible = False
        End If
    End Sub
End Class
