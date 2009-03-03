Imports Cif_Mgr
Partial Class CifControl
    Inherits System.Web.UI.UserControl

    Protected Sub TxtSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSearch.Click
        'Dim chgint As Integer
        'chgint = CInt(TxtSearch.Text)
        Dim ObjDs As List(Of CifInfo) = GetCifInfo(TxtCif.Text)
        If ObjDs.Count > 0 Then
            'lblCif.Text = ObjDs.Item(0).cifName
            lblId.Text = ObjDs.Item(0).idCard
            lblClass.Text = ObjDs.Item(0).cifClass
            lblBisi_Type.Text = ObjDs.Item(0).Busi_Name
            lblDept_Acc.Text = ObjDs.Item(0).departName
        Else
            'lblCif.Text = String.Empty
            lblId.Text = String.Empty
            lblClass.Text = String.Empty
            lblBisi_Type.Text = String.Empty
            lblDept_Acc.Text = String.Empty
            TxtCif.Text = String.Empty

            'Dim l As New Label
            'MessageBox("Format Exception: " & ex.Message)
            'l.Text = MSb("ค้นหาข้อมูลไม่พบ ")
            'Page.Controls.Add(l)
        End If
    End Sub
End Class
