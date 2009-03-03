Imports System.IO
Imports System.Web.UI.WebControls

Partial Class View_Picture_Appraisal
    Inherits System.Web.UI.Page

    Protected Sub form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load
        Dim collid As String
        collid = Request.QueryString("coll_id")
        'collid = "70228565"

        'Dim di As New DirectoryInfo(Server.MapPath("UploadedFiles/Pic_CollID/"))
        Dim path As String = Server.MapPath("UploadedFiles\Pic_CollID\")
        Dim di As New DirectoryInfo(path)
        Dim fi As FileInfo() = di.GetFiles(collid & "*")  ' search pattern เช่น AAA* , BBB*, *.txt, *.jpg เป็นต้น
        If fi.Count > 0 Then
            For Each f As FileInfo In fi
                Dim imgs As New Literal
                Dim xfile As New Image
                Dim L2 As New Literal
                'f.fullname  เอาค่านี้ไปส่งให้ control
                imgs.Text = "<br><img  src='" & "UploadedFiles/Pic_CollID/" & f.Name & "' width=780><br>"

                Panel1.Controls.Add(imgs)
                'L2.Text = f.Name

                'L2.Text = "<a href='\\mailaamc\new_airport\" & f.Name & "'> " & f.Name & " </a>"
                'Panel1.Controls.Add(L2)
            Next
        Else
            lblMessage.Text = "ไฟล์ภาพไม่ได้อัฟโหลดระหว่างการส่งการประเมิน"
        End If

    End Sub
End Class
