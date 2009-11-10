Imports System.IO
Imports System.Drawing
Imports System.Web.VirtualPathUtility
Imports System.Web.UI.Page
Imports Appraisal_Manager

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

        Dim Obj_Req_Id As List(Of Appraisal_Request) = GET_APPRAISAL_REQUEST(lblReq_Id.Text)  ' ตรวจสอบว่ามีการกำหนดผู้ประเมินแล้วหรือไม่
        If Obj_Req_Id.Item(0).Appraisal_Id = String.Empty Then
            s = "<script language=""javascript"">alert('ยังไม่ได้กำหนดผู้ประเมินราคา');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
            'Server.Transfer(Page.ResolveUrl("Appraisal_Price2.aspx"))
            's = "<script>" + "window.open('Appraisal_Assign_Update_Job.aspx?Req_Id=" + Trim(lblReq_Id.Text) + "&Hub_Id=" + Trim(lblHub_Id.Text) + "&Status_Id=" + Trim(4) + "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, directories=no, status=yes,height=450px,width=450px');</script>"
            'Page.ClientScript.RegisterStartupScript(Me.GetType, "กำหนดงานให้เจ้าหน้าที่ประเมิน", s)
        Else
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
        End If

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
