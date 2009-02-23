
Partial Class Appraisal_For_Wait_Approve
    Inherits System.Web.UI.Page
    Dim StrNotice As String
    Dim StrPath As String
    Dim s1 As String = Nothing

    Protected Sub imgAttach_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim ImgAttach As ImageButton = DirectCast(sender, ImageButton)
        'Dim Method_Type As Label = ImgAttach.Parent.FindControl("lblReq_Type")
        'MsgBox(Method_Type.Text)
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        Dim Req_Id As Label = ImgAttach.Parent.FindControl("lblReq_Id")
        Dim Hub_Id As Label = ImgAttach.Parent.FindControl("lblHub_Id")
        Dim AID As Label = ImgAttach.Parent.FindControl("lblAID")
        Dim Temp_AID As Label = ImgAttach.Parent.FindControl("lblTemp_AID")
        'Dim CID As Label = ImgAttach.Parent.FindControl("lblCID")


        StrPath = Request.ApplicationPath & "/FileUpload_Price3.aspx?Req_Id=" & Req_Id.Text & "&AID=" & AID.Text & "&Temp_AID=" & Temp_AID.Text & "&UserId=" & lbluserid.Text
        s1 = "<script language=""javascript"">window.open('" + StrPath + "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, directories=no, status=yes,height=700px,width=830px');</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType, "แนบไฟล์", s1)
    End Sub

    Protected Sub imgEditData_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim imgEditData As ImageButton = DirectCast(sender, ImageButton)
        Dim Method_Type As Label = imgEditData.Parent.FindControl("lblReq_Type")

        Dim Req_Id As Label = imgEditData.Parent.FindControl("lblReq_Id")
        Dim Hub_Id As Label = imgEditData.Parent.FindControl("lblHub_Id")
        Dim AID As Label = imgEditData.Parent.FindControl("lblAID")
        Dim Cif As Label = imgEditData.Parent.FindControl("lblCif")
        Dim Temp_AID As Label = imgEditData.Parent.FindControl("lblTemp_AID")

        Context.Items("Req_Id") = Req_Id.Text
        Context.Items("Hub_Id") = Hub_Id.Text
        Context.Items("AID") = AID.Text
        Context.Items("Cif") = Cif.Text
        Context.Items("Temp_AID") = Temp_AID.Text

        If Method_Type.Text = "1" Then
            Server.Transfer("Appraisal_Price3_ConForm.aspx")
        Else
            Server.Transfer("Appraisal_Price3_Form_Review.aspx")
        End If
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


        'Dim CollType As String = "050"

        's1 += "window.open('CollDetail_Edit_Position_Price3.aspx"
        's1 += "?Req_Id=" & Req_Id.Text
        's1 += "&Temp_AID=" & Temp_AID.Text
        's1 += "&UserId=" & lbluserid.Text
        'imgEditPosition.Attributes.Add("onclick", s1 & "','pop', 'width=820, height=680');")

    End Sub

    Protected Sub imgApprove_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim imgApprove As ImageButton = DirectCast(sender, ImageButton)
        Dim Approved1 As Label = imgApprove.Parent.FindControl("lblApproved1")
        Dim Approved2 As Label = imgApprove.Parent.FindControl("lblApproved2")
        Dim Approved3 As Label = imgApprove.Parent.FindControl("lblApproved3")
        Dim Lng As Label = imgApprove.Parent.FindControl("lblLng")
        Dim Lat As Label = imgApprove.Parent.FindControl("lblLat")
        If Approved1.Text = String.Empty Or Approved2.Text = String.Empty Or Approved3.Text = String.Empty Then
            StrNotice = "<Script language=""javascript"">alert('อนุกรรมการในการอนุมัติมีไม่ครบ 3 คน');</Script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", StrNotice)
            'Exit Sub
        End If

        If Lng.Text = "0" Or Lat.Text = "0" Then
            StrNotice = "<Script language=""javascript"">alert('คุณไม่ได้กำหนดพิกัด Lat Lng');</Script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", StrNotice)
            'Exit Sub
        End If
    End Sub

End Class
