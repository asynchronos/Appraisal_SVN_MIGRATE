Imports Appraisal_Manager

Partial Class ChangePass
    Inherits System.Web.UI.Page

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim lblEmpId As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        Dim lblEmpName As Label = TryCast(Me.Form.FindControl("lblUserName"), Label)
        lblEmp_Id.Text = lblEmpId.Text
        lblEmp_Name.Text = lblEmpName.Text
    End Sub

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        'Dim ObjSys_User As SystemUser = GET_SYSTEM_USER(lblEmp_Id.Text,
        If txtNewPassword.Text = txtConfirmNewPassword.Text Then
            UPDATE_PASSWORD(lblEmp_Id.Text, txtNewPassword.Text)
            ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>confirm('ยืนยันรหัสผ่านเรียบร้อย ระบบจะกลับสู่หน้า Login');</script>")
            Response.Redirect("Index.aspx")
        End If


    End Sub
End Class
