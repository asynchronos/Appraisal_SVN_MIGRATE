
Partial Class Appraisal_Price2_Picture
    Inherits System.Web.UI.Page
    Dim s As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblReq_Id.Text = Request.QueryString("Req_Id")
            lblHub_Id.Text = Request.QueryString("Hub_Id")
            If GridView1.Rows.Count = 0 Then
                'MsgBox("ไม่มีรูปภาพหลักประกัน")
                s = "<script language=""javascript"">alert('ไม่มีรูปภาพหลักประกัน');  window.close();</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "รูปภาพหลักประกัน", s)
            End If
        End If
    End Sub
End Class
