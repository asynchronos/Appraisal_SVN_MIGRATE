Imports Appraisal_Manager
Imports System.IO
Imports System.Drawing
Imports System.Web.VirtualPathUtility
Imports System.Web.UI.Page

Partial Class FileUpload_Price3
    Inherits System.Web.UI.Page
    Dim StrNotice As String
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        'Dim GV As GridView = DirectCast(FindControl("GridView_HubList"), GridView)
        'Dim Gvr As GridViewRow
        'Dim Chk As Boolean = False
        'Dim CntChk As Integer = 0
        'Dim FileName As String = ""
        'Dim s As String
        'Dim uploads As HttpFileCollection = HttpContext.Current.Request.Files

        'For Each Gvr In GV.Rows
        '    'ตรวจสอบว่ามีการเลือก Hub แล้วหรือไม่
        '    Dim chk1 As CheckBox = Gvr.FindControl("cb2")
        '    If chk1.Checked = True Then
        '        Chk = True
        '        CntChk = CntChk + 1
        '    End If
        'Next

        'If Chk = False Then
        '    StrNotice = "<script language=""javascript"">alert('คุณไม่ได้เลือก Hub ที่จะส่งไฟล์');</script>"
        '    Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", StrNotice)
        'Else
        '    If CntChk <= 3 Then
        '        'StrNotice = "<script language=""javascript"">alert('คุณเลือก Hub ที่จะส่งไฟล์ น้อยกว่า 3 Hub');</script>"
        '        'Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", StrNotice)
        '        For i = 0 To uploads.Count - 1
        '            Dim FileToUpload As HttpPostedFile = uploads(i)

        '            If (FileToUpload.ContentLength = 0) Then
        '                ' Error Handling
        '            Else
        '                'วนหารหัส Hub
        '                For Each Gvr In GV.Rows
        '                    'ตรวจสอบว่ามีการเลือก Hub แล้วหรือไม่
        '                    Dim chk1 As CheckBox = Gvr.FindControl("cb2")
        '                    Dim lblHub_Id As Label = Gvr.FindControl("lblHub_Id")
        '                    If chk1.Checked = True Then

        '                        FileName = lblReq_Id.Text & "_" & lblAID.Text & "_" & System.IO.Path.GetFileName(FileToUpload.FileName)
        '                        Try
        '                            'MsgBox(Server.MapPath("UploadedFiles/") + FileName)
        '                            AddAppraisal_Price3_PicturePath(lblReq_Id.Text, lblHub_Id.Text, lblAID.Text, lblTemp_AID.Text, FileName, "", 0, lblUserId.Text)
        '                            'FileToUpload.SaveAs(Server.MapPath("UploadedFiles/Pic_Price3/") + FileName)
        '                        Catch ex As Exception
        '                            ' Error Handling
        '                            s = "<script language=""javascript"">alert('" + ex.Message + "'); </script>"
        '                            Page.ClientScript.RegisterStartupScript(Me.GetType, "ผลการบันทึก", s)
        '                        End Try
        '                    End If
        '                Next
        '                FileToUpload.SaveAs(Server.MapPath("UploadedFiles/Pic_Price3/") + FileName)
        '            End If
        '        Next i
        '    ElseIf CntChk > 3 Then
        '        StrNotice = "<script language=""javascript"">alert('คุณเลือก Hub ที่จะส่งไฟล์ มากกว่า 3 Hub');</script>"
        '        Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", StrNotice)
        '    ElseIf CntChk = 3 Then

        '    End If
        'End If
        'GridView1.DataBind()

        'กำหนดขนาดไฟล์ภาพที่สามารถส่งได้ใน  Web.Config ด้วยนะ
        Dim uploads As HttpFileCollection = HttpContext.Current.Request.Files
        Dim bmpW As Integer = 800 'New image canvas width
        Dim bmpH As Integer = 600 'New Image canvas height 
        For i = 0 To uploads.Count - 1
            Dim FileToUpload As HttpPostedFile = uploads(i)
            Dim Filename As String = lblReq_Id.Text & "_" & lblHub_Id.Text & "_" & System.IO.Path.GetFileName(FileToUpload.FileName)
            If (CheckFileType(FileToUpload.FileName)) Then
                Dim newWidth As Integer = bmpW
                Dim newHeight As Integer = bmpH
                'Use the uploaded filename without the '.' extension 
                Dim upName As String = Mid(Filename, 1, (InStr(Filename, ".") - 1))
                'Dim filePath As String = "~/Upload/" & upName & ".png"
                Dim filePath As String = "~/UploadedFiles/Pic_Price3/" & upName & ".png"
                'Set the new bitmap resolution to 72 pixels per inch 
                Dim upBmp As Bitmap = Bitmap.FromStream(FileToUpload.InputStream)
                Dim newBmp As Bitmap = Nothing

                'Get the uploaded image width and height 

                Dim upWidth As Integer = upBmp.Width
                Dim upHeight As Integer = upBmp.Height
                Dim newX As Integer = 0
                Dim newY As Integer = 0
                Dim reDuce As Decimal

                'Keep the aspect ratio of image the same if not 4:3 and work out the newX and newY positions 
                'to ensure the image is always in the centre of the canvas vertically and horizontally 

                If upWidth > upHeight Then 'Landscape picture 
                    reDuce = newWidth / upWidth

                    'calculate the width percentage reduction as decimal 
                    newHeight = Int(upHeight * reDuce)
                    newWidth = Int(upWidth * reDuce)

                    'reduce the uploaded image height by the reduce amount 
                    newY = 0 'Int((bmpH - newHeight) / 2)
                    'Position the image centrally down the canvas 
                    newX = 0

                    'Picture will be full width 
                ElseIf upWidth < upHeight Then 'Portrait picture 
                    reDuce = newHeight / upHeight

                    'calculate the height percentage reduction as decimal 
                    'newWidth = Int(upWidth * reDuce)
                    'reduce the uploaded image height by the reduce amount 
                    'newX = Int((bmpW - newWidth) / 2)
                    'Position the image centrally across the canvas 
                    newHeight = Int(upHeight * reDuce)
                    newWidth = Int(upWidth * reDuce)
                    newY = 0
                    newX = 0

                    'Picture will be full hieght 
                ElseIf upWidth = upHeight Then 'square picture 
                    reDuce = newHeight / upHeight

                    'calculate the height percentage reduction as decimal 
                    newWidth = Int(upWidth * reDuce)
                    'reduce the uploaded image height by the reduce amount 
                    newX = Int((bmpW - newWidth) / 2)
                    'Position the image centrally across the canvas 
                    newY = Int((bmpH - newHeight) / 2)

                    'Position the image centrally down the canvas 
                End If

                'Create a new image from the uploaded picture using the Graphics class 
                'Clear the graphic and set the background colour to white 
                'Use Antialias and High Quality Bicubic to maintain a good quality picture
                'Save the new bitmap image using 'Png' picture format and the calculated canvas positioning 
                Dim newGraphic As Graphics = Nothing

                Try
                    newBmp = New Bitmap(newWidth, newHeight, Imaging.PixelFormat.Format24bppRgb)
                    newBmp.SetResolution(72, 72)
                    newGraphic = Graphics.FromImage(newBmp)

                    newGraphic.Clear(Color.White)
                    newGraphic.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                    newGraphic.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                    newGraphic.DrawImage(upBmp, newX, newY, newWidth, newHeight)
                    newBmp.Save(MapPath(filePath), Imaging.ImageFormat.Png)
                    'Appraisal_Manager.AddAppraisal_Request_PicturePath(lblReq_Id.Text, lblHub_Id.Text, upName & ".png", 0)
                    AddAppraisal_Price3_PicturePath(lblReq_Id.Text, lblHub_Id.Text, lblAID.Text, lblTemp_AID.Text, upName & ".png", "", 0, lblUserId.Text)
                    'Show the uploaded resized picture in the image control 
                    'Image1.ImageUrl = filePath
                    'Image1.Visible = True

                Catch ex As Exception
                    MsgBox(ex.ToString)
                Finally
                    upBmp.Dispose()
                    newBmp.Dispose()
                    newGraphic.Dispose()
                End Try
            Else
                MsgBox("Please select a picture with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png.")
            End If
        Next
        GridView1.DataBind()
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

    'Protected Sub cb1_Checked(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim cb1 As CheckBox = sender
    '    For Each gdi As GridViewRow In GridView_HubList.Rows
    '        If gdi.RowType = DataControlRowType.DataRow Then
    '            Dim cb2 As CheckBox = gdi.Cells(0).FindControl("cb2")
    '            cb2.Checked = cb1.Checked
    '        End If
    '    Next
    'End Sub

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
