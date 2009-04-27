
Partial Class Appraisal_Assign_Job
    Inherits System.Web.UI.Page


    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim cph As ContentPlaceHolder = TryCast(Me.Form.FindControl("ContentPlaceHolder1"), ContentPlaceHolder) 'หา Control จาก Master Page ที่ control อยู่ใน  ContentPlaceHolder1
        Dim lblHub As Label = TryCast(Me.Form.FindControl("lblHub_Id"), Label)
        Session("Hub_Id") = lblHub.Text
        Dim ReqId As Label = DirectCast(cph.FindControl("lblRequestID"), Label) 'Me.FindControl("lblRequestID")
    End Sub

    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
        Dim gvTemp As GridView = DirectCast(sender, GridView)
        Dim Req_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblReq_id"), Label)
        'MsgBox(Req_Id.Text)
        Dim myScript As String
        myScript = "<script>" + "window.open('Appraisal_Assign_Update_Job.aspx?Req_Id=" + Req_Id.Text + "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, directories=no, status=yes,height=350px,width=400px');</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType, "กำหนดงานให้เจ้าหน้าที่ประเมิน", myScript)
    End Sub
End Class
