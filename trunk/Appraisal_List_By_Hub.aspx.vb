
Partial Class Appraisal_List_By_Hub
    Inherits System.Web.UI.Page
    Dim s As String = ""

#Region "Variables"
    Dim gvUniqueID As String = String.Empty
    Dim gvNewPageIndex As Integer = 0
    Dim gvEditIndex As Integer = -1
    Dim gvSortExpr As String = String.Empty
#End Region

    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
        Dim str As String = ""
        Dim gvTemp As GridView = DirectCast(sender, GridView)
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label) 'หา Control จาก Master Page ที่ control ไม่อยู่ใน  ContentPlaceHolder1
        Dim Req_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblReq_id"), Label)
        Dim Hub_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblHub_id"), Label)
        Dim Cif As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblCif"), Label)
        Dim AppraisalId As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblAppraisalId"), Label)
        If Cif.Text <> String.Empty Then

        Else
            Cif.Text = "0"
        End If
        Dim status As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("LabelStatus_Name"), Label)
        Dim createDate As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("LabelCreate_Date"), Label)

        gvUniqueID = gvTemp.UniqueID

        'MsgBox(gvTemp.SelectedRow.FindControl("ddlOperation"))
        Dim ddlOperation As DropDownList = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("ddlOperation"), DropDownList)

        If AppraisalId.Text = lbluserid.Text Then
            'หากขอสิทธิได้จาก Google Map ได้ ให้ใช้โค็ดด้านล่างนี้
            str = Request.ApplicationPath & "/colldetail_new.aspx?Req_Id=" & Req_Id.Text & "&Hub_Id=" & Hub_Id.Text & "&User_Id=" & lbluserid.Text & "&cif=" & Cif.Text
            s = "<script language=""javascript"">window.open('" + str + "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=no, directories=no, status=yes,height=750px,width=830px');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)
        Else
            s = "<script language=""javascript"">alert('คุณไม่สามารถให้ราคาที่ 1 ได้ เนื่องจากไม่ใช่ผู้ประเมินราคา');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือนไม่มีสิทธิ", s)
        End If



        'Context.Items("Req_Id") = Req_Id.Text
        'Context.Items("Hub_Id") = Hub_Id.Text
        'Context.Items("Cif") = Cif.Text
        ''Server.Transfer("Appraisal_Price1.aspx")
        'Server.Transfer("Appraisal_Price1_Test.aspx")
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim cph As ContentPlaceHolder = TryCast(Me.Form.FindControl("ContentPlaceHolder1"), ContentPlaceHolder) 'หา Control จาก Master Page ที่ control อยู่ใน  ContentPlaceHolder1
        Dim lblHub As Label = TryCast(Me.Form.FindControl("lblHub_Id"), Label)
        Session("Hub_Id") = lblHub.Text
        'Session("Status_Id") = 4
        Dim ReqId As Label = DirectCast(cph.FindControl("lblRequestID"), Label) 'Me.FindControl("lblRequestID")
        SetFilter()
    End Sub

    Protected Sub imgSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Server.Transfer("Appraisal_Dynamic_Search.aspx")
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        SetFilter()
    End Sub

    Protected Sub SetFilter()
        Dim lblAppraisal_Id As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        Dim filterExpression As String = String.Empty
        If RadioButtonList1.SelectedValue = 0 Then
            filterExpression = "Appraisal_Id = " & lblAppraisal_Id.Text
        ElseIf RadioButtonList1.SelectedValue = 1 Then
            filterExpression = "Appraisal_Id <> " & 0
        End If

        SqlDataSource1.FilterExpression = filterExpression
    End Sub

End Class
