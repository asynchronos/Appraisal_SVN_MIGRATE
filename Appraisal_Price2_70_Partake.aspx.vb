Imports Appraisal_Manager
Partial Class Appraisal_Price2_70_Partake
    Inherits System.Web.UI.Page
    Dim s As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblId.Text = Context.Items("Id")
            lblReq_Id.Text = Context.Items("Req_Id")
            lblHub_Id.Text = Context.Items("Hub_Id")
            lblTemp_AID.Text = Context.Items("Temp_AID")
            txtBuilding_No.Text = Context.Items("Building_No")
            hdfCif.Value = Context.Items("Cif")
        End If
    End Sub

    Protected Sub ImageSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSave.Click
        'Dim StrNotice As String
        If txtPartakePrice.Text = "0.00" Or txtPartakePrice.Text = String.Empty Then
            lblMessage.Text = "ข้อมูลไม่ครบถ้วน"
            'StrNotice = "<script language=""javascript"">alert('ข้อมูลไม่ครบถ้วน');</script>"
            'Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", StrNotice)
            Exit Sub
        End If

        'If txtPartakePriceTotalDeteriorate.Text = "0.00" Or txtPartakePriceTotalDeteriorate.Text = String.Empty Then
        '    lblMessage.Text = "ข้อมูลไม่ครบถ้วน"
        '    Exit Sub
        'End If

        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        Dim Obj_P2_70_Partake As List(Of Price2_70_Partake) = GET_PRICE2_70_PARTAKE(lblId.Text, lblReq_Id.Text, lblHub_Id.Text, lblTemp_AID.Text, ddlPartaked.SelectedValue)
        If Obj_P2_70_Partake.Count = 0 Then
            ADD_PRICE2_70_PARTAKE(lblId.Text, lblReq_Id.Text, lblHub_Id.Text, lblTemp_AID.Text, "", ddlPartaked.SelectedValue, txtBuilding_No.Text, _
                                         txtPartakeArea.Text, txtPartakeUnitPrice.Text, txtPartakePrice.Text, txtPartakeAge.Text, _
                                         txtPartakePersent1.Text, txtPartakePersent2.Text, txtPartakePersent3.Text, txtPartakePriceTotalDeteriorate.Text, _
                                         txtFinishPercent.Text, txtPriceNotFinish.Text, txtPartake_Detail.Text, lbluserid.Text, Now())
            lblMessage.Text = "บันทึกเสร็จสมบูรณ์"
            GridView1.DataBind()
        Else
            'Update
            UPDATE_PRICE2_70_PARTAKE(lblId.Text, lblReq_Id.Text, lblHub_Id.Text, lblTemp_AID.Text, "", ddlPartaked.SelectedValue, txtBuilding_No.Text, _
                                         txtPartakeArea.Text, txtPartakeUnitPrice.Text, txtPartakePrice.Text, txtPartakeAge.Text, _
                                         txtPartakePersent1.Text, txtPartakePersent2.Text, txtPartakePersent3.Text, txtPartakePriceTotalDeteriorate.Text, _
                                         txtFinishPercent.Text, txtPriceNotFinish.Text, txtPartake_Detail.Text, lbluserid.Text, Now())
            lblMessage.Text = "บันทึกเสร็จสมบูรณ์"
            GridView1.DataBind()
            ImagePrint_Click(sender, Nothing)
        End If
    End Sub

    Protected Sub txtPartakeUnitPrice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPartakeUnitPrice.TextChanged
        If txtPartakeUnitPrice.Text = String.Empty Then
            txtPartakeUnitPrice.Text = "0.00"
        End If

        txtPartakePrice.Text = Format(CDec(txtPartakeArea.Text) * CDec(txtPartakeUnitPrice.Text), "#,##0.00")
        btnCal_Click(sender, Nothing)
        CalPartakeNotFinish()
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
        txtPartakeTotalDeteriorate.Text = ((CDec(txtPartakeAge.Text) * CDec(txtPartakePersent1.Text)) - CDec(txtPartakePersent2.Text) + CDec(txtPartakePersent3.Text))
        'txtPartakePriceTotalDeteriorate.Text = Format(CDec(txtPartakePrice.Text) * (CDec(txtPartakeTotalDeteriorate.Text) / 100), "#,##0.00")
        txtPartakePriceTotalDeteriorate.Text = Format(CDec(txtPriceNotFinish.Text) * (CDec(txtPartakeTotalDeteriorate.Text) / 100), "#,##0.00")
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
        'TotalPersent()
    End Sub

    Protected Sub txtPartakeArea_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPartakeArea.TextChanged
        'txtPartakePrice.Text = Format(CDec(txtPartakeArea.Text) * CDec(txtPartakeUnitPrice.Text), "#,##0.00")
        btnCal_Click(sender, Nothing)
        CalPartakeNotFinish()
    End Sub

    Protected Sub GridView1_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles GridView1.RowDeleted
        If e.Exception IsNot Nothing Then
            ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" & e.Exception.Message.ToString().Replace("'", "") & "');</script>")
            e.ExceptionHandled = True
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
        Dim gvTemp As GridView = DirectCast(sender, GridView)
        Dim lblPartake_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblPartake_Id"), Label)
        Dim lblPercentFinish As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblPercentFinish"), Label)
        Dim lblPartakeArea As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblPartakeArea"), Label)
        Dim lblPartakeUintPrice As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblPartakeUintPrice"), Label)
        lblPartakeUintPrice.Text = CDec(lblPartakeUintPrice.Text)
        Dim lblPartakePrice As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblPartakePrice"), Label)
        Dim lblPartakeAge As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblPartakeAge"), Label)
        Dim lblPartakePersent1 As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblPartakePersent1"), Label)
        Dim lblPartakePersent2 As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblPartakePersent2"), Label)
        Dim lblPartakePersent3 As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblPartakePersent3"), Label)
        Dim lblPartakePriceTotalDeteriorate As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblPartakePriceTotalDeteriorate"), Label)
        Dim lblPartakeDetail As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblPartakeDetail"), Label)

        ddlPartaked.SelectedValue = lblPartake_Id.Text
        ddlPartaked.Enabled = False
        txtFinishPercent.Text = Format(CDec(lblPercentFinish.Text), "#,000")
        txtPartakeArea.Text = lblPartakeArea.Text
        txtPartakeUnitPrice.Text = CDec(lblPartakeUintPrice.Text)
        txtPartakePrice.Text = Format(CDec(lblPartakeUintPrice.Text) * CDec(txtPartakeArea.Text), "#,##0.00")
        txtPartakeAge.Text = lblPartakeAge.Text
        txtPartakePersent1.Text = lblPartakePersent1.Text
        txtPartakePersent2.Text = lblPartakePersent2.Text
        txtPartakePersent3.Text = lblPartakePersent3.Text
        txtPartakePriceTotalDeteriorate.Text = lblPartakePriceTotalDeteriorate.Text
        txtPartake_Detail.Text = lblPartakeDetail.Text

        btnCal_Click(sender, Nothing)
        CalPartakeNotFinish()
        CalPartakeDeteriorate()
    End Sub

    Protected Sub ImagePrint_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImagePrint.Click
        lblMessage.Text = ""
        ddlPartaked.Enabled = True
        txtPartakeArea.Text = "0"
        txtPartakeUnitPrice.Text = "0"
        txtPartakeAge.Text = "0"
        txtPartakePersent1.Text = "0"
        txtPartakePersent2.Text = "0"
        txtPartakePersent3.Text = "0"
        btnCal_Click(sender, Nothing)
    End Sub

    Protected Sub txtFinishPercent_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFinishPercent.TextChanged
        CalPartakeNotFinish()
        CalPartakeDeteriorate()
    End Sub

    Private Sub CalPartakeNotFinish()
        If CDec(txtPartakePrice.Text) >= 0 Then
            If CDec(txtFinishPercent.Text) <= 100 Then
                txtPriceNotFinish.Text = String.Format("{0:N2}", CDec(txtPartakePrice.Text) * ((CInt(txtFinishPercent.Text) / 100)))
            Else
                s = "<script language=""javascript"">alert('เปอร์เซ็นต์ส่วนควบสร้างเสร็จมีค่ามากกว่า 100 %');</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", s)
            End If
        Else
            txtPriceNotFinish.Text = "0.00"
        End If

    End Sub

    Private Sub CalPartakeDeteriorate()
        If txtPartakeAge.Text = String.Empty Or txtPartakePersent1.Text = String.Empty Or txtPartakePersent2.Text = String.Empty Or txtPartakePersent3.Text = String.Empty Then
            Exit Sub
        Else
            txtPartakeTotalDeteriorate.Text = (CInt(txtPartakeAge.Text) * CDec(txtPartakePersent1.Text)) - CDec(txtPartakePersent2.Text) + CDec(txtPartakePersent3.Text)
            txtPartakePriceTotalDeteriorate.Text = String.Format("{0:N2}", (CDec(txtPriceNotFinish.Text) * CDec(txtPartakeTotalDeteriorate.Text)) / 100)
        End If
    End Sub

    Protected Sub ImgBtnClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnClose.Click
        Context.Items("Coll_Type") = "70"
        Context.Items("Req_Id") = lblReq_Id.Text
        Context.Items("Hub_Id") = lblHub_Id.Text
        Context.Items("Temp_AID") = lblTemp_AID.Text
        Context.Items("ID") = lblId.Text
        Context.Items("Cif") = hdfCif.Value
        Server.Transfer("Appraisal_Price2_Add_By_Colltype70_New.aspx")
    End Sub

End Class
