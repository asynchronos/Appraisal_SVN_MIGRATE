
Partial Class Appraisal_List_By_Hub
    Inherits System.Web.UI.Page
    Dim s As String = ""

#Region "Variables"
    Dim gvUniqueID As String = String.Empty
    Dim gvNewPageIndex As Integer = 0
    Dim gvEditIndex As Integer = -1
    Dim gvSortExpr As String = String.Empty
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("Hub_Id") = 2

    End Sub

    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
        Dim str As String = ""
        Dim gvTemp As GridView = DirectCast(sender, GridView)
        Dim Req_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblReq_id"), Label)
        Dim Cif As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblCif"), Label)
        Dim status As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("LabelStatus_Name"), Label)
        Dim createDate As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("LabelCreate_Date"), Label)

        gvUniqueID = gvTemp.UniqueID

        'MsgBox(gvTemp.SelectedRow.FindControl("ddlOperation"))
        Dim ddlOperation As DropDownList = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("ddlOperation"), DropDownList)

        str = Request.ApplicationPath & "/colldetail.aspx?Req_Id=" & Req_Id.Text
        s = "<script language=""javascript"">window.open('" + str + "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, directories=no, status=yes,height=700px,width=900px');</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)

        'If ddlOperation.SelectedValue = 0 Then  'กำหนดวันรับเรื่องการประเมิน
        '    If Trim(status.Text) <> "รับเรื่องการประเมิน" Then
        '        str = Request.ApplicationPath & "/receive_appraisal.aspx?Qid=" & Qid.Text & "&receive_date=" & createDate.Text
        '        s = "<script language=""javascript"">window.open('" + str + "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, directories=no, status=yes,height=260px,width=220px');</script>"
        '        Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)
        '    Else
        '        s = "<script language=""javascript"">alert('คุณได้กำหนดวันรับเรื่องการประเมินแล้ว');</script>"
        '        Page.ClientScript.RegisterStartupScript(Me.GetType, "จัดกลุ่ม", s)
        '    End If

        'ElseIf ddlOperation.SelectedValue = 1 Then  'กำหนดกลุ่ม Coll ID
        '    'Dim status As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("LabelStatus_Name"), Label)

        '    If Trim(status.Text) = "รับเรื่องการประเมิน" Then
        '        str = Request.ApplicationPath & "/CID_2_PreAID.aspx?Qid=" & Qid.Text
        '        s = "<script language=""javascript"">window.open('" + str + "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, directories=no, status=yes,height=400px,width=650px');</script>"
        '        Page.ClientScript.RegisterStartupScript(Me.GetType, "จัดกลุ่ม", s)
        '    Else
        '        s = "<script language=""javascript"">alert('คุณยังไม่ได้กำหนดวันรับเรื่อง ให้ดำเนินการกำหนดวันรับเรื่องก่อน');</script>"
        '        Page.ClientScript.RegisterStartupScript(Me.GetType, "จัดกลุ่ม", s)
        '    End If

        'ElseIf ddlOperation.SelectedValue = 2 Then
        '    Response.Redirect("colldetail.aspx")
        'ElseIf ddlOperation.SelectedValue = 3 Then
        '    'Response.Redirect("Price2.aspx?Qid=" & Qid.Text & "&Cif=" & Cif.Text)
        '    Response.Redirect("Define_SecondPrice.aspx?Qid=" & Qid.Text & "&Cif=" & Cif.Text)
        'Else
        '    Response.Redirect("Price3.aspx?Qid=" & Qid.Text & "&Cif=" & Cif.Text)
        'End If

    End Sub
End Class
