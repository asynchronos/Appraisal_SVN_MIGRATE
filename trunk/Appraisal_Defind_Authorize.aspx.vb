Imports Appraisal_Manager
Partial Class Appraisal_Defind_Authorize
    Inherits System.Web.UI.Page

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim lblHubid As Label = TryCast(Me.Form.FindControl("lblHub_Id"), Label)
        hdfHub_Id.Value = lblHubid.Text
    End Sub

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Dim Ath As Integer
        'MsgBox(ddlAppraisal.SelectedValue)
        Select Case ddlAuthorize.SelectedValue
            Case "1"
                'เทียบเท่าหัวหน้า Hub
                Ath = 3
            Case "2"
                'เทียบเท่ารองหัวหน้า Hub
                Ath = 4
            Case "3"
                'เทียบเท่าผู้ประเมิน
                Ath = 4
            Case "4"
                'เทียบเท่าAdmin Hub
                Ath = 6
        End Select
        'MsgBox(Ath)
        'เปลี่ยนสิทธิ์การทำงานโดยส่ง Parameter 2 ตัว คือ รหัสผู้จะให้สิทธิ์ใหม่  กับ กลุ่มผู้ใช้สิทธิ์
        UPDATE_AUTHORIZE_SYSTEM_USER(ddlAppraisal.SelectedValue, Ath)
    End Sub

End Class
