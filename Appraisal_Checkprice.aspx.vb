
Partial Class Appraisal_Checkprice
    Inherits System.Web.UI.Page
    Dim StrPath As String
    Dim s1 As String = Nothing

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        hdfEmp_Id.Value = lbluserid.Text
    End Sub

    Protected Sub imgEditPosition_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        Dim imgEditPosition As ImageButton = DirectCast(sender, ImageButton)
        Dim Req_Id As Label = imgEditPosition.Parent.FindControl("lblReq_Id")
        Dim Hub_Id As Label = imgEditPosition.Parent.FindControl("lblHub_Id")
        Dim Temp_AID As Label = imgEditPosition.Parent.FindControl("lblTemp_AID")

        StrPath = Request.ApplicationPath & "/CollDetail_Edit_Position_Price3.aspx?Req_Id=" & Req_Id.Text & "&Temp_AID=" & Temp_AID.Text & "&UserId=" & lbluserid.Text
        s1 = "<script language=""javascript"">window.open('" + StrPath + "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, directories=no, status=yes,height=700px,width=830px');</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType, "แก้ไขพิกัด", s1)

    End Sub
End Class
