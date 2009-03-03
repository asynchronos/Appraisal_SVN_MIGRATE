Imports Appraisal_Manager
Partial Class FileUpload_Price3
    Inherits System.Web.UI.Page
    Dim StrNotice As String
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim GV As GridView = DirectCast(FindControl("GridView_HubList"), GridView)
        Dim Gvr As GridViewRow
        Dim Chk As Boolean = False
        Dim CntChk As Integer = 0
        Dim FileName As String = ""
        Dim s As String
        Dim uploads As HttpFileCollection = HttpContext.Current.Request.Files

        For Each Gvr In GV.Rows
            'ตรวจสอบว่ามีการเลือก Hub แล้วหรือไม่
            Dim chk1 As CheckBox = Gvr.FindControl("cb2")
            If chk1.Checked = True Then
                Chk = True
                CntChk = CntChk + 1
            End If
        Next

        If Chk = False Then
            StrNotice = "<script language=""javascript"">alert('คุณไม่ได้เลือก Hub ที่จะส่งไฟล์');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", StrNotice)
        Else
            If CntChk <= 3 Then
                'StrNotice = "<script language=""javascript"">alert('คุณเลือก Hub ที่จะส่งไฟล์ น้อยกว่า 3 Hub');</script>"
                'Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", StrNotice)
                For i = 0 To uploads.Count - 1
                    Dim FileToUpload As HttpPostedFile = uploads(i)

                    If (FileToUpload.ContentLength = 0) Then
                        ' Error Handling
                    Else
                        'วนหารหัส Hub
                        For Each Gvr In GV.Rows
                            'ตรวจสอบว่ามีการเลือก Hub แล้วหรือไม่
                            Dim chk1 As CheckBox = Gvr.FindControl("cb2")
                            Dim lblHub_Id As Label = Gvr.FindControl("lblHub_Id")
                            If chk1.Checked = True Then

                                FileName = lblReq_Id.Text & "_" & lblAID.Text & "_" & System.IO.Path.GetFileName(FileToUpload.FileName)
                                Try
                                    'MsgBox(Server.MapPath("UploadedFiles/") + FileName)
                                    AddAppraisal_Price3_PicturePath(lblReq_Id.Text, lblHub_Id.Text, lblAID.Text, lblTemp_AID.Text, FileName, "", 0, lblUserId.Text)
                                    'FileToUpload.SaveAs(Server.MapPath("UploadedFiles/Pic_Price3/") + FileName)
                                Catch ex As Exception
                                    ' Error Handling
                                    s = "<script language=""javascript"">alert('" + ex.Message + "'); </script>"
                                    Page.ClientScript.RegisterStartupScript(Me.GetType, "ผลการบันทึก", s)
                                End Try
                            End If
                        Next
                        FileToUpload.SaveAs(Server.MapPath("UploadedFiles/Pic_Price3/") + FileName)
                    End If
                Next i
            ElseIf CntChk > 3 Then
                StrNotice = "<script language=""javascript"">alert('คุณเลือก Hub ที่จะส่งไฟล์ มากกว่า 3 Hub');</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", StrNotice)
            ElseIf CntChk = 3 Then
                'Save Data
                'วนหาว่ามีไฟล์อะไรที่แนบ

                'For i = 0 To uploads.Count - 1
                '    Dim FileToUpload As HttpPostedFile = uploads(i)

                '    If (FileToUpload.ContentLength = 0) Then
                '        ' Error Handling
                '    Else
                '        'วนหารหัส Hub
                '        For Each Gvr In GV.Rows
                '            'ตรวจสอบว่ามีการเลือก Hub แล้วหรือไม่
                '            Dim chk1 As CheckBox = Gvr.FindControl("cb2")
                '            Dim lblHub_Id As Label = Gvr.FindControl("lblHub_Id")
                '            If chk1.Checked = True Then

                '                FileName = lblReq_Id.Text & "_" & lblHub_Id.Text & "_" & lblAID.Text & "_" & System.IO.Path.GetFileName(FileToUpload.FileName)
                '                Try
                '                    'MsgBox(Server.MapPath("UploadedFiles/") + FileName)
                '                    FileToUpload.SaveAs(Server.MapPath("UploadedFiles/Pic_Price3/") + FileName)
                '                    AddAppraisal_Price3_PicturePath(lblReq_Id.Text, lblHub_Id.Text, lblAID.Text, lblTemp_AID.Text, FileName, "", 0, lblUserId.Text)
                '                Catch ex As Exception
                '                    ' Error Handling
                '                    s = "<script language=""javascript"">alert('" + ex.Message + "'); </script>"
                '                    Page.ClientScript.RegisterStartupScript(Me.GetType, "ผลการบันทึก", s)
                '                End Try
                '            End If
                '        Next
                '    End If
                'Next i
            End If
        End If
        GridView1.DataBind()
    End Sub

    Protected Sub cb1_Checked(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb1 As CheckBox = sender
        For Each gdi As GridViewRow In GridView_HubList.Rows
            If gdi.RowType = DataControlRowType.DataRow Then
                Dim cb2 As CheckBox = gdi.Cells(0).FindControl("cb2")
                cb2.Checked = cb1.Checked
            End If
        Next
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim UpPath As String
        Dim UpName As String
        If Not Page.IsPostBack Then
            lblReq_Id.Text = Request.QueryString("Req_Id")
            'MsgBox(lblReq_Id.Text)
            lblHub_Id.Text = Request.QueryString("Hub_Id")
            'MsgBox(lblHub_Id.Text)
            lblUserId.Text = Request.QueryString("UserId")
            lblAID.Text = Request.QueryString("AID")
            lblTemp_AID.Text = Request.QueryString("Temp_AID")
            'lblCID.Text = Request.QueryString("CID")

            'UpPath = "C:\UploadedUserFiles"
            UpPath = Server.MapPath("UploadedFiles/Pic_Price3/")
            UpName = Dir(UpPath, vbDirectory)
        End If



    End Sub
End Class
