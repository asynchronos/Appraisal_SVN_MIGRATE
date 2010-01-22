Imports System.IO
Imports System.Drawing
Imports System.Web.VirtualPathUtility
Imports System.Web.UI.Page
Partial Class Upload_Form_Upload_File_Request_Form
    Inherits System.Web.UI.Page

    Private Message As String

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click, btnSubmit.Click
        Image_progress.Visible = True
        btnSubmit.Enabled = False
        Dim FileName As String
        Dim popupname As String = String.Empty
        Dim uploads As HttpFileCollection = HttpContext.Current.Request.Files

        For i = 0 To uploads.Count - 1
            Dim FileToUpload As HttpPostedFile = uploads(i)

            If (FileToUpload.ContentLength = 0) Then
                ' Error Handling
            Else
                'กำหนดชื่อให้กับไฟล์เป็นชื่อใหม่ก่อนบันทึกลงที่เก็บ
                If CheckFileType(FileToUpload.FileName) = True Then
                    FileName = hdfReq_Id.Value & "_" & hdfHub_Id.Value & "_" & System.IO.Path.GetFileName(FileToUpload.FileName)
                    Try
                        If hdfReq_form.Value = 1 Then
                            FileToUpload.SaveAs(Server.MapPath("../UploadedFiles/Pic_RegID/Pic_Request_Form/") + FileName)
                        ElseIf hdfReq_form.Value = 2 Then
                            FileToUpload.SaveAs(Server.MapPath("../UploadedFiles/Pic_RegID/Pic_Collateral_Map/") + FileName)
                        ElseIf hdfReq_form.Value = 3 Then
                            FileToUpload.SaveAs(Server.MapPath("../UploadedFiles/Pic_RegID/Pic_Document_Imortant/") + FileName)
                        ElseIf hdfReq_form.Value = 4 Then
                            FileToUpload.SaveAs(Server.MapPath("../UploadedFiles/Pic_RegID/Pic_Other/") + FileName)
                        End If
                        'FileToUpload.SaveAs(Server.MapPath("../UploadedFiles/Pic_RegID/") + FileName)
                        Appraisal_Manager.AddAppraisal_Request_PicturePath(hdfReq_Id.Value, hdfHub_Id.Value, FileName, hdfReq_form.Value, 0)
                        Server.Transfer(Page.ResolveUrl("~/Upload_Form/UploadCompleat_Form.aspx"))
                    Catch ex As Exception
                        ' Error Handling
                    End Try
                Else

                    popupname += System.IO.Path.GetFileName(FileToUpload.FileName)
                    Message = "<script>" + "confirm('ไฟล์ชื่อ " & System.IO.Path.GetFileName(FileToUpload.FileName) & " ไม่สามารถ Upload ได้');</script>"
                    Page.ClientScript.RegisterStartupScript(Me.GetType, popupname, Message)

                End If

            End If
        Next i
        Image_progress.Visible = True
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Image_progress.Visible = False
        If Not Page.IsPostBack Then
            hdfReq_Id.Value = Request.QueryString("req_id")
            hdfHub_Id.Value = Request.QueryString("hub_id")
            hdfReq_form.Value = Request.QueryString("req_form")
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
        End If

        btnSubmit.Enabled = True
    End Sub

    Function CheckFileType(ByVal fileName As String) As Boolean

        Dim ext As String = Path.GetExtension(fileName)

        Select Case ext.ToLower()
            Case ".gif"
                Return True
            Case ".png"
                Return True
            Case ".jpg"
                Return True
            Case ".jpeg"
                Return True
            Case ".bmp"
                Return True
            Case ".tiff"
                Return True
            Case ".tif"
                Return True
            Case Else
                Return False
        End Select

    End Function

End Class
