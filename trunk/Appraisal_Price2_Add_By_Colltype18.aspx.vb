
Partial Class Appraisal_Price2_Add_By_Colltype18
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblReq_Id.Text = CType(Context.Items("Req_Id"), Label).Text
            lblHub_Id.Text = CType(Context.Items("Hub_Id"), Label).Text
            hhdfSubCollType.Value = CStr(Context.Items("Coll_Type"))
            hdfId.Value = CStr(Context.Items("Id"))
            'ตรวจสอบ ID ว่าเป็นการแก้ไข หรือ กำหนดไอดีใหม่
            If hdfId.Value Is Nothing Then

            Else
            End If
        End If
    End Sub

    Protected Sub ImageSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSave.Click

    End Sub
End Class
