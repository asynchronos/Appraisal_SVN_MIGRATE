Imports Appraisal_Manager
Partial Class FileUpload_Price2
    Inherits System.Web.UI.Page
    Dim Req_Id As String
    Dim Hub_Id As String
    Dim Temp_AID As String
    Dim User_ID As String

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim FileName As String
        Dim s As String
        Dim uploads As HttpFileCollection = HttpContext.Current.Request.Files

        For i = 0 To uploads.Count - 1
            Dim FileToUpload As HttpPostedFile = uploads(i)

            If (FileToUpload.ContentLength = 0) Then
                ' Error Handling
            Else
                FileName = Req_Id & "_" & Hub_Id & "_" & Temp_AID & "_" & System.IO.Path.GetFileName(FileToUpload.FileName)
                Try
                    'FileToUpload.SaveAs("C:\\UploadedUserFiles\\" + FileName)
                    'MsgBox(Server.MapPath("UploadedFiles/") + FileName)
                    FileToUpload.SaveAs(Server.MapPath("UploadedFiles/Pic_Price2/") + FileName)
                    AddAppraisal_Price2_PicturePath(Req_Id, Hub_Id, Temp_AID, FileName, 0, User_ID)
                Catch ex As Exception
                    ' Error Handling
                    s = "<script language=""javascript"">alert('" + ex.Message + "'); </script>"
                    Page.ClientScript.RegisterStartupScript(Me.GetType, "ผลการบันทึก", s)
                End Try
            End If
        Next i
        'Server.Transfer("UploadComplete.aspx")
        s = "<script language=""javascript"">alert('แนบไฟล์เสร็จสมบูรณ์ ระบบจะปิดหน้าต่างนี้');  window.close();</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblReq_Id.Text = Request.QueryString("Req_Id")
        lblHub_Id.Text = Request.QueryString("Hub_Id")
        lblTemp_AID.Text = Request.QueryString("Temp_AID")

        Req_Id = Request.QueryString("Req_Id")
        Hub_Id = Request.QueryString("Hub_Id")
        Temp_AID = Request.QueryString("Temp_AID")
        User_ID = Request.QueryString("User_Id")
        'MsgBox(Req_Id & " " & Hub_Id & " " & Temp_AID)
        Dim UpPath As String
        Dim UpName As String
        'UpPath = "C:\UploadedUserFiles"
        UpPath = Server.MapPath("UploadedFiles/Pic_Price2/")
        UpName = Dir(UpPath, vbDirectory)

    End Sub
End Class
