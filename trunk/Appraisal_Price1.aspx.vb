Imports System.IO
Imports System.Drawing
Imports System.Web.VirtualPathUtility
Imports System.Web.UI.Page

Partial Class Appraisal_Price1
    Inherits System.Web.UI.Page
    Dim s As String
    Protected Sub BtnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnConfirm.Click
        If TxtLat.Text = String.Empty Then
            s = "<script language=""javascript"">alert('คุณไม่ได้ใส่เลข Lat');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
            Exit Sub
        ElseIf TxtLng.Text = String.Empty Then
            s = "<script language=""javascript"">alert('คุณไม่ได้ใส่เลข Lng');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
            Exit Sub
        ElseIf txtPriceWah.Text = String.Empty Then
            s = "<script language=""javascript"">alert('คุณไม่ได้ใส่ราคา ตรว. ละ หรือ ตรม. ละ ');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
            Exit Sub
        ElseIf txtTotal.Text = String.Empty Then
            s = "<script language=""javascript"">alert('คุณไม่ได้ใส่ราคทั้งหมด');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
            Exit Sub
        End If

        'กำหนดขนาดไฟล์ภาพที่สามารถส่งได้ใน  Web.Config ด้วยนะ
        'Dim uploads As HttpFileCollection = HttpContext.Current.Request.Files
        'Dim bmpW As Integer = 800 'New image canvas width
        'Dim bmpH As Integer = 600 'New Image canvas height 
        'For i = 0 To uploads.Count - 1
        '    Dim FileToUpload As HttpPostedFile = uploads(i)
        '    Dim Filename As String = "Map_" & lblReq_Id.Text & "_" & lblHub_Id.Text & "_" & System.IO.Path.GetFileName(FileToUpload.FileName)
        '    If (CheckFileType(FileToUpload.FileName)) Then
        '        Dim newWidth As Integer = bmpW
        '        Dim newHeight As Integer = bmpH
        '        'Use the uploaded filename without the '.' extension 
        '        Dim upName As String = Mid(Filename, 1, (InStr(Filename, ".") - 1))
        '        'Dim filePath As String = "~/Upload/" & upName & ".png"
        '        Dim filePath As String = "~/UploadedFiles/Pic_RegID/" & upName & ".png"
        '        'Set the new bitmap resolution to 72 pixels per inch 
        '        Dim upBmp As Bitmap = Bitmap.FromStream(FileToUpload.InputStream)
        '        Dim newBmp As Bitmap = Nothing


        '        'Get the uploaded image width and height 

        '        Dim upWidth As Integer = upBmp.Width
        '        Dim upHeight As Integer = upBmp.Height
        '        Dim newX As Integer = 0
        '        Dim newY As Integer = 0
        '        Dim reDuce As Decimal

        '        'Keep the aspect ratio of image the same if not 4:3 and work out the newX and newY positions 
        '        'to ensure the image is always in the centre of the canvas vertically and horizontally 

        '        If upWidth > upHeight Then 'Landscape picture 
        '            reDuce = newWidth / upWidth

        '            'calculate the width percentage reduction as decimal 
        '            newHeight = Int(upHeight * reDuce)
        '            newWidth = Int(upWidth * reDuce)


        '            'reduce the uploaded image height by the reduce amount 
        '            newY = 0 'Int((bmpH - newHeight) / 2)
        '            'Position the image centrally down the canvas 
        '            newX = 0

        '            'Picture will be full width 
        '        ElseIf upWidth < upHeight Then 'Portrait picture 
        '            reDuce = newHeight / upHeight

        '            'calculate the height percentage reduction as decimal 
        '            'newWidth = Int(upWidth * reDuce)
        '            'reduce the uploaded image height by the reduce amount 
        '            'newX = Int((bmpW - newWidth) / 2)
        '            'Position the image centrally across the canvas 
        '            newHeight = Int(upHeight * reDuce)
        '            newWidth = Int(upWidth * reDuce)
        '            newY = 0
        '            newX = 0

        '            'Picture will be full hieght 
        '        ElseIf upWidth = upHeight Then 'square picture 
        '            reDuce = newHeight / upHeight

        '            'calculate the height percentage reduction as decimal 
        '            newWidth = Int(upWidth * reDuce)
        '            'reduce the uploaded image height by the reduce amount 
        '            newX = Int((bmpW - newWidth) / 2)
        '            'Position the image centrally across the canvas 
        '            newY = Int((bmpH - newHeight) / 2)

        '            'Position the image centrally down the canvas 
        '        End If

        '        'Create a new image from the uploaded picture using the Graphics class 
        '        'Clear the graphic and set the background colour to white 
        '        'Use Antialias and High Quality Bicubic to maintain a good quality picture
        '        'Save the new bitmap image using 'Png' picture format and the calculated canvas positioning 
        '        Dim newGraphic As Graphics = Nothing

        '        Try
        '            newBmp = New Bitmap(newWidth, newHeight, Imaging.PixelFormat.Format24bppRgb)
        '            newBmp.SetResolution(72, 72)
        '            newGraphic = Graphics.FromImage(newBmp)

        '            newGraphic.Clear(Color.White)
        '            newGraphic.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        '            newGraphic.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        '            newGraphic.DrawImage(upBmp, newX, newY, newWidth, newHeight)
        '            newBmp.Save(MapPath(filePath), Imaging.ImageFormat.Png)
        '            Appraisal_Manager.AddAppraisal_Request_PicturePath(lblReq_Id.Text, lblHub_Id.Text, Filename, 0)
        '            'Show the uploaded resized picture in the image control 
        '            'Image1.ImageUrl = filePath
        '            'Image1.Visible = True

        '        Catch ex As Exception
        '            MsgBox(ex.ToString)
        '        Finally
        '            upBmp.Dispose()
        '            newBmp.Dispose()
        '            newGraphic.Dispose()
        '        End Try
        '    Else
        '        MsgBox("Please select a picture with a file format extension of either Bmp, Jpg, Jpeg, Gif, Tiff or Png.")
        '    End If
        'Next
        '***********************************************************************************************************

        Dim dal As New GmapDAL_NEW
        Dim obj As New Price1_Master
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        obj.Req_Id = CInt(lblReq_Id.Text)
        obj.Hub_Id = CInt(lblHub_Id.Text)
        obj.Cif = CInt(lblCif.Text)
        obj.CifName = ""
        obj.Lat = CDec(TxtLat.Text)
        obj.Lng = CDec(TxtLng.Text)
        obj.Pricewah = CDec(txtPriceWah.Text)
        obj.Price = CDec(txtTotal.Text)
        obj.Create_User = lbluserid.Text
        obj.Create_Date = Now()
        dal.insertPrice1Master(obj)
        s = "<script language=""javascript"">alert('บันทึกการกำหนดราคาที่ 1 เสร็จสมบูรณ์');</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
        Server.Transfer(Page.ResolveUrl("Appraisal_Price2.aspx"))
        'Server.Transfer(Page.ResolveUrl("~/Upload_Form/UploadCompleat_Form.aspx"))
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblReq_Id.Text = Context.Items("Req_Id")
            lblHub_Id.Text = Context.Items("Hub_Id")
            lblCif.Text = Context.Items("Cif")
            '---------ใช้กับหน้าที่เป็น Google Map-----------------
            'lblHub_Id.Text = Request.QueryString("req_id")
            'lblHub_Id.Text = Request.QueryString("hub_id")
            '-----------------------------------------------
            'MsgBox(REGID & "  " & HubID)
            Dim UpPath As String
            Dim UpName As String
            'UpPath = "C:\UploadedUserFiles"
            UpPath = Server.MapPath("UploadedFiles/Pic_RegID/")
            UpName = Dir(UpPath, vbDirectory)
        End If

        'btnSubmit.Enabled = True
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

End Class
