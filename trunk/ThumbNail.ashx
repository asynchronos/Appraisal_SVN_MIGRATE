<%@ WebHandler Language="VB" Class="ThumbNail" %>

Imports System
Imports System.Web
Imports System.Drawing
Imports System.IO
Public Class ThumbNail : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        'context.Response.ContentType = "text/plain"
        'context.Response.Write("Hello World")
        Dim imageurl As String = context.Request.QueryString("ImURL")
        Dim str As String = context.Server.MapPath("../UploadedFiles/Pic_Price2/") + imageurl
        MsgBox(str)
        Dim bmp As New Bitmap(str)
        Dim img As System.Drawing.Image = bmp.GetThumbnailImage(100, 100, Nothing, IntPtr.Zero)
        Dim ms As New MemoryStream()
        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
        Dim bmpBytes As Byte() = ms.GetBuffer()
        img.Dispose()
        ms.Close()
        
        context.Response.BinaryWrite(bmpBytes)
        context.Response.[End]()
    End Sub
    
    'Public Sub ProcessRequest(ByVal context As HttpContext)
    '    Dim imageurl As String = context.Request.QueryString("ImURL")
    '    Dim str As String = context.Server.MapPath(".") + imageurl
    '    Dim bmp As New Bitmap(str)
    '    Dim img As System.Drawing.Image = bmp.GetThumbnailImage(100, 100, Nothing, IntPtr.Zero)
    '    Dim ms As New MemoryStream()
    '    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
    '    Dim bmpBytes As Byte() = ms.GetBuffer()
    '    img.Dispose()
    '    ms.Close()

    '    context.Response.BinaryWrite(bmpBytes)
    '    context.Response.[End]()
    'End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class