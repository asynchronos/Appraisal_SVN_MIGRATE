Imports Appraisal_Manager
Partial Class Add_CollType70
    Inherits System.Web.UI.Page

    Protected Sub ImageSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSave.Click
        AddPRICE2_70(CInt(Request.QueryString("Q_ID")), CInt(Request.QueryString("Cif")), CInt(Request.QueryString("Temp_Aid")), CInt(DDLSubCollType.SelectedValue), _
                                                      txtBuild_No.Text, CInt(ddlBuild_Character.SelectedValue), txtFloor.Text, CInt(txtItem.Text), _
                                                      CInt(ddlBuild_Construct.SelectedValue), CInt(ddlRoof.SelectedValue), _
                                                      txtRoof_Detail.Text, CInt(ddlBuild_State.SelectedValue), txtBuild_State_Detail.Text, _
                                                      txtBuilding_Detail.Text, CInt(txtPriceTotal1.Text), _
                                                      CInt(chkDoc1.Checked), CInt(chkDoc2.Checked), txtDoc_Detail.Text, vbNull, String.Empty, Now())
    End Sub
End Class
