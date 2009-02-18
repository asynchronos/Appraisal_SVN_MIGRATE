Imports Appraisal_Manager
Partial Class Appraisal_Price3_70_Review_Pastake
    Inherits System.Web.UI.Page
    Dim StrNotice As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblId.Text = Context.Items("Id")
            lblTemp_AID.Text = Context.Items("Temp_AID")
            lblReq_Id.Text = Context.Items("Req_Id")
            lblHub_Id.Text = Context.Items("Hub_Id")
            lblAID.Text = Context.Items("AID")

        End If
    End Sub

    Protected Sub ImageSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSave.Click
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)

        Dim Obj_P3_Partake_Review As List(Of Price3_70_Review_Partake) = GET_PRICE3_70_REVIEW_PARTAKE(lblId.Text, lblReq_Id.Text, lblHub_Id.Text, lblAID.Text, lblTemp_AID.Text, ddlPartaked.SelectedValue)
        If Obj_P3_Partake_Review.Count = 0 Then
            'Insert
            Add_Price3_70_Review_Partake(lblId.Text, lblReq_Id.Text, lblHub_Id.Text, lblTemp_AID.Text, lblAID.Text, ddlPartaked.SelectedValue, _
                                         txtPartakeArea.Text, txtPartakeUnitPrice.Text, txtPartakePrice.Text, txtPartakeAge.Text, _
                                         txtPartakePersent1.Text, txtPartakePersent2.Text, txtPartakePersent3.Text, txtPartakePriceTotalDeteriorate.Text, _
                                         txtPartake_Detail.Text, lbluserid.Text, Now())
            StrNotice = "<script language=""javascript"">alert('บันทึกเสร็จสมบูรณ์');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", StrNotice)
            GridView1.DataBind()
        Else
            'Update
            Update_Price3_70_Review_Partake(lblId.Text, lblReq_Id.Text, lblHub_Id.Text, lblTemp_AID.Text, lblAID.Text, ddlPartaked.SelectedValue, _
                                         txtPartakeArea.Text, txtPartakeUnitPrice.Text, txtPartakePrice.Text, txtPartakeAge.Text, _
                                         txtPartakePersent1.Text, txtPartakePersent2.Text, txtPartakePersent3.Text, txtPartakePriceTotalDeteriorate.Text, _
                                         txtPartake_Detail.Text, lbluserid.Text, Now())
            StrNotice = "<script language=""javascript"">alert('บันทึกเสร็จสมบูรณ์');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", StrNotice)
            GridView1.DataBind()
        End If

    End Sub

    Protected Sub txtPartakeUnitPrice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPartakeUnitPrice.TextChanged
        If txtPartakeUnitPrice.Text = String.Empty Then
            txtPartakeUnitPrice.Text = "0.00"
        End If

        txtPartakePrice.Text = Format(CDec(txtPartakeArea.Text) * CDec(txtPartakeUnitPrice.Text), "#,##0.00")
        btnCal_Click(sender, Nothing)
    End Sub

    Protected Sub txtPartakeAge_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPartakeAge.TextChanged
        'TotalPersent()
        btnCal_Click(sender, Nothing)
    End Sub

    Private Sub Default_Value()
        If txtPartakeArea.Text = String.Empty Then
            txtPartakeArea.Text = "0"
        End If
        If txtPartakeUnitPrice.Text = String.Empty Then
            txtPartakeUnitPrice.Text = "0"
        End If
        If txtPartakeAge.Text = String.Empty Then
            txtPartakeAge.Text = "0"
        End If
        If txtPartakePersent1.Text = String.Empty Then
            txtPartakePersent1.Text = "0"
        End If
        If txtPartakePersent2.Text = String.Empty Then
            txtPartakePersent2.Text = "0"
        End If
        If txtPartakePersent3.Text = String.Empty Then
            txtPartakePersent3.Text = "0"
        End If
    End Sub

    Protected Sub txtPartakePersent1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPartakePersent1.TextChanged
        'TotalPersent()
        btnCal_Click(sender, Nothing)
    End Sub

    Private Sub TotalPersent()
        Default_Value()
        txtPartakePrice.Text = Format(CDec(txtPartakeArea.Text) * CDec(txtPartakeUnitPrice.Text), "#,##0.00")
        txtPartakeTotalDeteriorate.Text = (CDec(txtPartakeAge.Text) * (CDec(txtPartakePersent1.Text) + CDec(txtPartakePersent2.Text) + CDec(txtPartakePersent3.Text)))
        txtPartakePriceTotalDeteriorate.Text = Format(CDec(txtPartakePrice.Text) * (CDec(txtPartakeTotalDeteriorate.Text) / 100), "#,##0.00")
    End Sub

    Protected Sub txtPartakePersent2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPartakePersent2.TextChanged
        'TotalPersent()
        btnCal_Click(sender, Nothing)
    End Sub

    Protected Sub txtPartakePersent3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPartakePersent3.TextChanged
        'TotalPersent()
        btnCal_Click(sender, Nothing)
    End Sub

    Protected Sub txtPartakePrice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPartakePrice.TextChanged
        btnCal_Click(sender, Nothing)
    End Sub

    Protected Sub btnCal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCal.Click
        TotalPersent()
    End Sub

    Protected Sub txtPartakeArea_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPartakeArea.TextChanged
        'txtPartakePrice.Text = Format(CDec(txtPartakeArea.Text) * CDec(txtPartakeUnitPrice.Text), "#,##0.00")
        btnCal_Click(sender, Nothing)
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
        Dim gvTemp As GridView = DirectCast(sender, GridView)
        Dim lblPartake_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblPartake_Id"), Label)
        Dim lblPartakeArea As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblPartakeArea"), Label)
        Dim lblPartakeUintPrice As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblPartakeUintPrice"), Label)
        Dim lblPartakePrice As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblPartakePrice"), Label)
        Dim lblPartakeAge As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblPartakeAge"), Label)
        Dim lblPartakePersent1 As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblPartakePersent1"), Label)
        Dim lblPartakePersent2 As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblPartakePersent2"), Label)
        Dim lblPartakePersent3 As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblPartakePersent3"), Label)
        Dim lblPartakePriceTotalDeteriorate As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblPartakePriceTotalDeteriorate"), Label)
        Dim lblPartakeDetail As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblPartakeDetail"), Label)

        ddlPartaked.SelectedValue = lblPartake_Id.Text
        ddlPartaked.Enabled = False
        txtPartakeArea.Text = lblPartakeArea.Text
        txtPartakeUnitPrice.Text = lblPartakeUintPrice.Text
        txtPartakeAge.Text = lblPartakeAge.Text
        txtPartakePersent1.Text = lblPartakePersent1.Text
        txtPartakePersent2.Text = lblPartakePersent2.Text
        txtPartakePersent3.Text = lblPartakePersent3.Text
        txtPartakePriceTotalDeteriorate.Text = lblPartakePriceTotalDeteriorate.Text
        txtPartake_Detail.Text = lblPartakeDetail.Text
        btnCal_Click(sender, Nothing)
    End Sub

    Protected Sub ImgBtnClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnClose.Click

    End Sub

    Protected Sub ImagePrint_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImagePrint.Click

        ddlPartaked.Enabled = True
        txtPartakeArea.Text = "0"
        txtPartakeUnitPrice.Text = "0"
        txtPartakeAge.Text = "0"
        txtPartakePersent1.Text = "0"
        txtPartakePersent2.Text = "0"
        txtPartakePersent3.Text = "0"
        btnCal_Click(sender, Nothing)
    End Sub
End Class
