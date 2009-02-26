
Partial Class Appraisal_Price2_Add_By_Colltype18
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblReq_Id.Text = Context.Items("Req_Id")
            lblHub_Id.Text = Context.Items("Hub_Id")
            hhdfSubCollType.Value = Context.Items("Coll_Type")
            hdfId.Value = Context.Items("Id")
            'ตรวจสอบ ID ว่าเป็นการแก้ไข หรือ กำหนดไอดีใหม่
            If hdfId.Value Is Nothing Then

            Else
            End If
        End If
    End Sub

    Protected Sub txtPriceWah_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPriceWah.TextChanged
        If txtArea.Text = String.Empty Or txtArea.Text = "0" Then
            'Message Error
            txtArea.Text = "0"
            MsgBox("คุณไม่ได้ใส่เนื้อที่ที่จะใช้คำนวน")
            Exit Sub
        Else
            txtCondoPrice.Text = String.Format("{0:N2}", CDec(txtArea.Text) * CDec(txtPriceWah.Text))
        End If
    End Sub

    'Private Sub Cal_PriceTotal()
    '    txtCondoPrice.Text = String.Format("{0:N2}", CDec(txtArea.Text) * CDec(txtPriceWah.Text))
    'End Sub

    Protected Sub txtArea_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtArea.TextChanged
        txtCondoPrice.Text = String.Format("{0:N2}", CDec(txtArea.Text) * CDec(txtPriceWah.Text))
    End Sub
End Class
