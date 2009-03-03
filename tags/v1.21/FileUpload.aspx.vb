
Partial Class FileUpload
    Inherits System.Web.UI.Page
    Dim CollID As String
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim FileName As String

        Dim uploads As HttpFileCollection = HttpContext.Current.Request.Files

        For i = 0 To uploads.Count - 1
            Dim FileToUpload As HttpPostedFile = uploads(i)

            If (FileToUpload.ContentLength = 0) Then
                ' Error Handling
            Else
                FileName = CollID & "_" & System.IO.Path.GetFileName(FileToUpload.FileName)
                Try
                    'FileToUpload.SaveAs("C:\\UploadedUserFiles\\" + FileName)
                    'MsgBox(Server.MapPath("UploadedFiles/") + FileName)
                    FileToUpload.SaveAs(Server.MapPath("UploadedFiles/Pic_CollID/") + FileName)
                Catch ex As Exception
                    ' Error Handling
                End Try
            End If
        Next i
        Server.Transfer("UploadComplete.aspx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        CollID = Request.QueryString("coll_id")
        'MsgBox(CollID)
        Dim UpPath As String
        Dim UpName As String
        'UpPath = "C:\UploadedUserFiles"
        UpPath = Server.MapPath("UploadedFiles/Pic_CollID/")
        UpName = Dir(UpPath, vbDirectory)
        'If UpName = "" Then
        '    'MkDir("C:\UploadedUserFiles\")
        '    MkDir(Server.MapPath("UploadedUserFiles/"))
        'End If

    End Sub
End Class
