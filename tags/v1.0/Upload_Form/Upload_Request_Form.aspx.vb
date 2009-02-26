
Partial Class Upload_Form_Upload_Request_Form
    Inherits System.Web.UI.Page
    Dim REGID, HubID As String
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim FileName As String

        Dim uploads As HttpFileCollection = HttpContext.Current.Request.Files

        For i = 0 To uploads.Count - 1
            Dim FileToUpload As HttpPostedFile = uploads(i)

            If (FileToUpload.ContentLength = 0) Then
                ' Error Handling
            Else
                'กำหนดชื่อให้กับไฟล์เป็นชื่อใหม่ก่อนบันทึกลงที่เก็บ
                FileName = REGID & "_" & HubID & "_" & System.IO.Path.GetFileName(FileToUpload.FileName)
                Try
                    'FileToUpload.SaveAs("C:\\UploadedUserFiles\\" + FileName)
                    'MsgBox(Server.MapPath("../UploadedFiles/") + FileName)
                    FileToUpload.SaveAs(Server.MapPath("../UploadedFiles/Pic_RegID/") + FileName)
                    'Appraisal_Manager.AddAppraisal_Request_PicturePath(REGID, HubID, Server.MapPath("../UploadedFiles/Pic_RegID/") + FileName)
                    Appraisal_Manager.AddAppraisal_Request_PicturePath(REGID, HubID, FileName, 0)
                Catch ex As Exception
                    ' Error Handling
                End Try
            End If
        Next i
        Server.Transfer(Page.ResolveUrl("~/Upload_Form/UploadCompleat_Form.aspx"))
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        REGID = Request.QueryString("req_id")
        HubID = Request.QueryString("hub_id")
        'MsgBox(REGID & "  " & HubID)
        Dim UpPath As String
        Dim UpName As String
        'UpPath = "C:\UploadedUserFiles"
        UpPath = Server.MapPath("UploadedFiles/Pic_RegID/")
        UpName = Dir(UpPath, vbDirectory)
        'If UpName = "" Then
        '    'MkDir("C:\UploadedUserFiles\")
        '    MkDir(Server.MapPath("UploadedUserFiles/"))
        'End If

    End Sub
End Class
