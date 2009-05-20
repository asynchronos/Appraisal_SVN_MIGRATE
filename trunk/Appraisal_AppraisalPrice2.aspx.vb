Imports Appraisal_Manager
Imports System.Data
Imports System.Data.SqlClient

Partial Class Appraisal_AppraisalPrice2
    Inherits System.Web.UI.Page
    Dim s As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblReq_Id.Text = Request.QueryString("Req_Id")
            lblHub_Id.Text = Request.QueryString("Hub_Id")
            lblHub_Name.Text = Request.QueryString("Hub_Name")
            lblCif.Text = Request.QueryString("Cif")
            lblCifName.Text = Request.QueryString("Cif_Name")
            Dim Obj_P2 As DataSet = GET_APPRAISAL_PRICE2(lblReq_Id.Text, lblHub_Id.Text)
            If Obj_P2.Tables(0).Rows.Count > 0 Then
                lblPrice1.Text = String.Format("{0:N2}", Obj_P2.Tables(0).Rows(0).Item("Price1")) & "บาท"
                lblPrice2.Text = String.Format("{0:N2}", Obj_P2.Tables(0).Rows(0).Item("Price2")) & "บาท"
                ddlUserAppraisal.SelectedValue = Obj_P2.Tables(0).Rows(0).Item("Appraisal_Id")
                ddlSender.SelectedValue = Obj_P2.Tables(0).Rows(0).Item("Sender_Id")
            Else
                'MsgBox("No Data")
            End If
        End If

    End Sub

    Protected Sub ImageCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageCancel.Click
        s = "<script language=""javascript"">window.close();</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType, "กำหนดงานให้เจ้าหน้าที่ประเมิน", s)
    End Sub

    Protected Sub ImageOk_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageOk.Click
        If lblPrice2.Text = String.Empty Then
            s = "<script language=""javascript"">alert('ไม่พบการกำหนดราคาที่ 2 ของเลขคำขอนี้ในระบบ');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)
        Else
            UPDATE_Status_Appraisal_Request(lblReq_Id.Text, lblHub_Id.Text, 7)
            s = "<script language=""javascript"">alert('ยืนยันการกำหนดราคาที่ 2 แล้ว');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)
        End If

    End Sub
End Class
