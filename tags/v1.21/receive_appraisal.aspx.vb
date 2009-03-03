Imports Appraisal_Manager
Partial Class receive_appraisal
    Inherits System.Web.UI.Page
    Private ReceiveDate As Date
    Private qid As Integer
    Private selectdate As Date
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If selectdate <> Calendar1.SelectedDate Then
            'MsgBox(Calendar1.SelectedDate)
            If Calendar1.SelectedDate < CDate(Request.QueryString("receive_date")) Then
                lblMessage.Text = ("รับเรื่องหลังวันส่งประเมินไม่ได้")
            Else
                lblMessage.Text = ""
                'Do Something
                UPDATE_RECEIVE_DATE(CInt(Request.QueryString("Qid")), Calendar1.SelectedDate)
                'Dim s As String = "<script language=""javascript"">if (confirm('บันทึกวันที่รับเรื่องเสร็จสมบูรณ์ คุณต้องการปิดหน้าต่างนี้หรือไม่')) {window.close();}</script>"
                Dim s As String = "<script language=""javascript"">alert('บันทึกวันที่รับเรื่องเสร็จสมบูรณ์ ระบบจะปิดหน้าต่างนี้');  window.close();</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)
            End If
        Else
            lblMessage.Text = ("คุณยังไม่ได้เลือกวันที่รับเรื่อง")
        End If

    End Sub

    Protected Sub form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load
        If Not Page.IsPostBack Then
            ReceiveDate = CDate(Request.QueryString("receive_date"))
            qid = CInt(Request.QueryString("Qid"))
            selectdate = Calendar1.SelectedDate
        End If

    End Sub
End Class
