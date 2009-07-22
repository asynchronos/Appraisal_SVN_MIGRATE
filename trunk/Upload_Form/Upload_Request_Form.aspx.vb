Imports System.IO
Imports System.Drawing
Imports System.Web.VirtualPathUtility
Imports System.Web.UI.Page
Partial Class Upload_Form_Upload_Request_Form
    Inherits System.Web.UI.Page

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click, btnSubmit.Click
        Dim FileName As String
        Dim uploads As HttpFileCollection = HttpContext.Current.Request.Files
        btnSubmit.Enabled = False
        For i = 0 To uploads.Count - 1
            Dim FileToUpload As HttpPostedFile = uploads(i)

            If (FileToUpload.ContentLength = 0) Then
                ' Error Handling
            Else
                'กำหนดชื่อให้กับไฟล์เป็นชื่อใหม่ก่อนบันทึกลงที่เก็บ
                FileName = hdfReq_Id.Value & "_" & hdfHub_Id.Value & "_" & System.IO.Path.GetFileName(FileToUpload.FileName)
                'Resize Image
                Try
                    'FileToUpload.SaveAs("C:\\UploadedUserFiles\\" + FileName)
                    'MsgBox(Server.MapPath("../UploadedFiles/") + FileName)
                    FileToUpload.SaveAs(Server.MapPath("../UploadedFiles/Pic_RegID/") + FileName)
                    'Appraisal_Manager.AddAppraisal_Request_PicturePath(REGID, HubID, Server.MapPath("../UploadedFiles/Pic_RegID/") + FileName)
                    Appraisal_Manager.AddAppraisal_Request_PicturePath(hdfReq_Id.Value, hdfHub_Id.Value, FileName, 0)
                Catch ex As Exception
                    ' Error Handling
                End Try
            End If
        Next i
        Server.Transfer(Page.ResolveUrl("~/Upload_Form/UploadCompleat_Form.aspx"))
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            hdfReq_Id.Value = Request.QueryString("req_id")
            hdfHub_Id.Value = Request.QueryString("hub_id")
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

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        '*********************** Sample Code Resize *************************
        'กำหนดขนาดไฟล์ภาพที่สามารถส่งได้ใน  Web.Config ด้วยนะ
        Dim uploads As HttpFileCollection = HttpContext.Current.Request.Files
        Dim bmpW As Integer = 800 'New image canvas width
        Dim bmpH As Integer = 600 'New Image canvas height 
        For i = 0 To uploads.Count - 1
            Dim FileToUpload As HttpPostedFile = uploads(i)
            Dim Filename As String = hdfReq_Id.Value & "_" & hdfReq_Id.Value & "_" & System.IO.Path.GetFileName(FileToUpload.FileName)
            If (CheckFileType(FileToUpload.FileName)) Then
                Dim newWidth As Integer = bmpW
                Dim newHeight As Integer = bmpH
                'Use the uploaded filename without the '.' extension 
                Dim upName As String = Mid(Filename, 1, (InStr(Filename, ".") - 1))
                'Dim filePath As String = "~/Upload/" & upName & ".png"
                Dim filePath As String = "~/UploadedFiles/Pic_RegID/" & upName & ".png"
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
                    Appraisal_Manager.AddAppraisal_Request_PicturePath(hdfReq_Id.Value, hdfHub_Id.Value, Filename, 0)
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
        ''***********************************************************************************************************

        Server.Transfer(Page.ResolveUrl("~/Upload_Form/UploadCompleat_Form.aspx"))
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
            Case Else
                Return False
        End Select

    End Function


    'Const bmpW As Integer = 300 'New image canvas width
    'Const bmpH As Integer = 226 'New Image canvas height 
    ''If (FileToUpload.HasFile) Then
    ''    lblError.Text = ""
    ''Else

    ''End If
    'REGID = "R500"
    'HubID = "H200"
    'Dim FileName As String
    'Dim uploads As HttpFileCollection = HttpContext.Current.Request.Files

    'For i = 0 To uploads.Count - 1
    '    Dim FileToUpload As HttpPostedFile = uploads(i)

    '    If (FileToUpload.ContentLength = 0) Then
    '        ' Error Handling
    '    Else
    '        'กำหนดชื่อให้กับไฟล์เป็นชื่อใหม่ก่อนบันทึกลงที่เก็บ
    '        FileName = REGID & "_" & HubID & "_" & System.IO.Path.GetFileName(FileToUpload.FileName)
    '        '******Resize Image********
    '        If (CheckFileType(FileToUpload.FileName)) Then
    '            Dim newWidth As Integer = bmpW
    '            Dim newHeight As Integer = bmpH

    '            'Use the uploaded filename without the '.' extension 

    '            'Dim upName As String = Mid(FileToUpload.FileName, 1, (InStr(FileToUpload.FileName, ".") - 1))
    '            Dim upName As String = Mid(FileName, 1, (InStr(FileName, ".") - 1))
    '            'Dim filePath As String = "~/Upload/" & upName & ".png"
    '            Dim filePath As String = "D:/SME_Programes/Colleteral/Appraisal/UploadedFiles/Pic_RegID/" & upName & ".png"  'Server.MapPath("../UploadedFiles/Pic_RegID/") & upName & ".png"

    '            'Create a new Bitmap using the uploaded picture as a Stream 
    '            'Set the new bitmap resolution to 72 pixels per inch 

    '            Dim upBmp As Bitmap = Bitmap.FromStream(FileToUpload.InputStream)
    '            Dim newBmp As Bitmap = New Bitmap(newWidth, newHeight, Imaging.PixelFormat.Format24bppRgb)
    '            newBmp.SetResolution(72, 72)


    '            'Get the uploaded image width and height 

    '            Dim upWidth As Integer = upBmp.Width
    '            Dim upHeight As Integer = upBmp.Height
    '            Dim newX As Integer = 0
    '            Dim newY As Integer = 0
    '            Dim reDuce As Decimal

    '            'Keep the aspect ratio of image the same if not 4:3 and work out the newX and newY positions 
    '            'to ensure the image is always in the centre of the canvas vertically and horizontally 

    '            If upWidth > upHeight Then 'Landscape picture 
    '                reDuce = newWidth / upWidth

    '                'calculate the width percentage reduction as decimal 
    '                newHeight = Int(upHeight * reDuce)

    '                'reduce the uploaded image height by the reduce amount 
    '                newY = Int((bmpH - newHeight) / 2)

    '                'Position the image centrally down the canvas 
    '                newX = 0

    '                'Picture will be full width 

    '            ElseIf upWidth < upHeight Then 'Portrait picture 
    '                reDuce = newHeight / upHeight

    '                'calculate the height percentage reduction as decimal 
    '                newWidth = Int(upWidth * reDuce)

    '                'reduce the uploaded image height by the reduce amount 
    '                newX = Int((bmpW - newWidth) / 2)

    '                'Position the image centrally across the canvas 
    '                newY = 0

    '                'Picture will be full hieght 

    '            ElseIf upWidth = upHeight Then 'square picture 
    '                reDuce = newHeight / upHeight

    '                'calculate the height percentage reduction as decimal 
    '                newWidth = Int(upWidth * reDuce)

    '                'reduce the uploaded image height by the reduce amount 
    '                newX = Int((bmpW - newWidth) / 2)

    '                'Position the image centrally across the canvas 
    '                newY = Int((bmpH - newHeight) / 2)

    '                'Position the image centrally down the canvas 

    '            End If

    '            'Create a new image from the uploaded picture using the Graphics class 
    '            'Clear the graphic and set the background colour to white 
    '            'Use Antialias and High Quality Bicubic to maintain a good quality picture
    '            'Save the new bitmap image using 'Png' picture format and the calculated canvas positioning 
    '            Dim newGraphic As Graphics = Graphics.FromImage(newBmp)

    '            Try
    '                newGraphic.Clear(Color.White)
    '                newGraphic.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
    '                newGraphic.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
    '                newGraphic.DrawImage(upBmp, newX, newY, newWidth, newHeight)
    '                newBmp.Save(MapPath(filePath), Imaging.ImageFormat.Png)


    '                'Show the uploaded resized picture in the image control 
    '                'Image1.ImageUrl = filePath
    '                'Image1.Visible = True

    '            Catch ex As Exception
    '                MsgBox(ex.ToString)


    '            Finally
    '                upBmp.Dispose()
    '                newBmp.Dispose()
    '                newGraphic.Dispose()
    '            End Try
    '            '**************************

    '            Try
    '                FileToUpload.SaveAs(Server.MapPath("../UploadedFiles/Pic_RegID/") + FileName)
    '                Appraisal_Manager.AddAppraisal_Request_PicturePath(REGID, HubID, FileName, 0)
    '            Catch ex As Exception
    '                ' Error Handling
    '            End Try
    '        End If
    '    End If
    'Next i
End Class
