
Partial Class Appraisal_Price3_Review_Coll_List
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            hdfReq_Id.Value = Context.Items("Req_Id")
            hdfHub_ID.Value = Context.Items("Hub_Id")
            hdfCollType.Value = Context.Items("CollType")
            hdfAID.Value = Context.Items("AID")
        End If

    End Sub

    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging

        Dim gvTemp As GridView = DirectCast(sender, GridView)
        Dim Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblID"), Label)
        Dim Req_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblReq_Id"), Label)
        Dim Hub_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblHub_Id"), Label)
        Dim CollType As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblCollType_Id"), Label)
        Dim Cif As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblCif"), Label)
        Context.Items("Id") = Id.Text
        Context.Items("Req_Id") = Req_Id.Text
        Context.Items("Hub_Id") = Hub_Id.Text
        Context.Items("Coll_Type") = CollType.Text
        Context.Items("Cif") = Cif.Text
        Context.Items("AID") = hdfAID.Value
        If CollType.Text = "50" Then
            Server.Transfer("Appraisal_Price3_50_Review_Edit.Aspx")
        ElseIf CollType.Text = "70" Then
            Server.Transfer("Appraisal_Price3_70_Review_Edit.Aspx")
        ElseIf CollType.Text = "18" Then
            Server.Transfer("Appraisal_Price3_18_Review_Edit.Aspx")
        End If


    End Sub
End Class
