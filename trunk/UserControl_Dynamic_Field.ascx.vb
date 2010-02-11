Imports System.Web.UI.WebControls

Partial Class UserControl_Dynamic_Field
    Inherits System.Web.UI.UserControl

    'Declare the event that we want to raise (we'll handle this in the parent page)
    Public Event RemoveUserControl As EventHandler


    Protected Friend Sub btnRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        'Raise this event so the parent page can handle it
        RaiseEvent RemoveUserControl(sender, e)
    End Sub

End Class
