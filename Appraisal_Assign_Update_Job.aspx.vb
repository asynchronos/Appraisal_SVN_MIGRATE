
Partial Class Appraisal_Assign_Update_Job
    Inherits System.Web.UI.Page

    Dim s As String
    Protected Sub DetailsView1_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DetailsViewUpdatedEventArgs) Handles DetailsView1.ItemUpdated

        'Response.Redirect("Appraisal_Assign_Job.aspx")
        s = "<script language=""javascript"">alert('บันทึกเสร็จสมบูรณ์ ระบบจะปิดหน้าต่างนี้');  window.close();</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType, "กำหนดงานให้เจ้าหน้าที่ประเมิน", s)
    End Sub

    Protected Sub DetailsView1_ItemUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DetailsViewUpdateEventArgs) Handles DetailsView1.ItemUpdating

    End Sub

    Protected Sub DetailsView1_ModeChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DetailsViewModeEventArgs) Handles DetailsView1.ModeChanging
        If (e.CancelingEdit = True) Then
            'Response.Redirect("Appraisal_Assign_Job.aspx")
            s = "<script language=""javascript"">alert('ยกเลิกการกำหนดราคาประเมิน 2');  window.close();</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "กำหนดงานให้เจ้าหน้าที่ประเมิน", s)
        End If
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        HdfHubId.Value = Request.QueryString("Hub_Id")
        HdfStatus.Value = Request.QueryString("Status_Id")
        'MsgBox(Request.QueryString("Status_Id"))
    End Sub
End Class
