Imports Appraisal_Manager
Imports System.Data
Imports System.Data.SqlClient

Partial Class Appraisal_AppraisalPrice2New
    Inherits System.Web.UI.Page

    Dim s As String
    Dim StrPath As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'lblReq_Id.Text = Request.QueryString("Req_Id")
            'lblHub_Id.Text = Request.QueryString("Hub_Id")
            'lblHub_Name.Text = Request.QueryString("Hub_Name")
            'lblCif.Text = Request.QueryString("Cif")
            'lblCifName.Text = Request.QueryString("Cif_Name")

            lblReq_Id.Text = Context.Items("Req_Id")
            lblHub_Id.Text = Context.Items("Hub_Id")
            lblHub_Name.Text = Context.Items("Hub_Name")
            lblCif.Text = Context.Items("Cif")
            lblCifName.Text = Context.Items("CifName")

            Dim Obj_P2 As DataSet = GET_APPRAISAL_PRICE2(lblReq_Id.Text, lblHub_Id.Text)
            If Obj_P2.Tables(0).Rows.Count > 0 Then
                lblPrice1.Text = String.Format("{0:N2}", Obj_P2.Tables(0).Rows(0).Item("Price1"))
                If Obj_P2.Tables(0).Rows(0).Item("Appraisal_Type") = 1 Then
                    lblPrice2.Text = String.Format("{0:N2}", Obj_P2.Tables(0).Rows(0).Item("PriceMarket"))
                Else
                    lblPrice2.Text = String.Format("{0:N2}", Obj_P2.Tables(0).Rows(0).Item("Price2"))
                End If
                'ddlUserAppraisal.SelectedValue = Obj_P2.Tables(0).Rows(0).Item("Appraisal_Id")
                'ddlSender.SelectedValue = Obj_P2.Tables(0).Rows(0).Item("Sender_Id")
                lblSender_Name.Text = Obj_P2.Tables(0).Rows(0).Item("Sender_Name")
                lblAppraisal_Name.Text = Obj_P2.Tables(0).Rows(0).Item("AppraisalName")
                txtComment.Text = Obj_P2.Tables(0).Rows(0).Item("Comment")
                txtNote.Text = Obj_P2.Tables(0).Rows(0).Item("Note")
            Else
                'MsgBox("No Data")
            End If
        End If

    End Sub

    Protected Sub ImageCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageCancel.Click
        's = "<script language=""javascript"">window.close();</script>"
        'Page.ClientScript.RegisterStartupScript(Me.GetType, "กำหนดงานให้เจ้าหน้าที่ประเมิน", s)
        Server.Transfer("Appraisal_Assign_Job.aspx")
    End Sub

    Protected Sub ImageOk_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageOk.Click
        If lblPrice2.Text = String.Empty Then
            s = "<script language=""javascript"">alert('ไม่พบการกำหนดราคาที่ 2 ของเลขคำขอนี้ในระบบ');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)
        Else
            UPDATE_PRICE2_MASTER(lblReq_Id.Text, lblHub_Id.Text, lblPrice2.Text, txtNote.Text)
            UPDATE_Status_Appraisal_Request(lblReq_Id.Text, lblHub_Id.Text, rdbAccept.SelectedValue)

            s = "<script language=""javascript"">alert('ยืนยันการกำหนดราคาที่ 2 แล้ว');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)
        End If

        'MsgBox(rdbAccept.SelectedValue)
    End Sub

    Protected Sub ImgLocation_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgLocation.Click
        'Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        'Dim Req_Id As Label = lblReq_Id.Text
        'Dim Hub_Id As Label = imgEditPosition.Parent.FindControl("lblHub_Id")
        'Dim Temp_AID As Label = imgEditPosition.Parent.FindControl("lblTemp_AID")

        StrPath = Request.ApplicationPath & "/CollDetail_Show_Position.aspx?Req_Id=" & lblReq_Id.Text & "&Hub_Id=" & lblHub_Id.Text
        s = "<script language=""javascript"">window.open('" + StrPath + "','window','toolbar=no target=_blank, menubar=no, scrollbars=yes, resizable=no,location=no,directories=no, status=yes height=680px,width=850px');</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType, "แสดงพิกัด", s)
    End Sub

    Protected Sub ImgImformation_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgImformation.Click
        'lblReq_Id.Text = Request.QueryString("Req_Id")
        'lblHub_Id.Text = Request.QueryString("Hub_Id")
        'lblHub_Name.Text = Request.QueryString("Hub_Name")
        'lblCif.Text = Request.QueryString("Cif")
        'lblCifName.Text = Request.QueryString("Cif_Name")

        s = "<script language=""javascript"">window.close('');</script>"
        StrPath = Request.ApplicationPath & "/Appraisal_Price2_Information.aspx?Req_Id=" & lblReq_Id.Text & "&Hub_Id=" & lblHub_Id.Text & "&HubName=" & lblHub_Name.Text & "&Cif=" & lblCif.Text & "&CifName=" & lblCifName.Text
        s = "<script language=""javascript"">window.open('" + StrPath + "','window','toolbar=no target=_blank, menubar=no, scrollbars=yes, resizable=yes,location=no,directories=no, status=yes height=680px,width=850px');</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)
    End Sub
End Class
