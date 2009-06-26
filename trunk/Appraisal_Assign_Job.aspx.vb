
Partial Class Appraisal_Assign_Job
    Inherits System.Web.UI.Page

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    If Not Page.IsPostBack Then
    '        If Session("Appraisal_Id_Search") = Nothing Then
    '        Else
    '            ddlAppraisal_User.SelectedValue = Session("Appraisal_Id_Search")
    '        End If
    '    Else
    '        Session("Appraisal_Id_Search") = ddlAppraisal_User.SelectedValue
    '    End If
    'End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim cph As ContentPlaceHolder = TryCast(Me.Form.FindControl("ContentPlaceHolder1"), ContentPlaceHolder) 'หา Control จาก Master Page ที่ control อยู่ใน  ContentPlaceHolder1
        Dim lblHub As Label = TryCast(Me.Form.FindControl("lblHub_Id"), Label)
        HdfHub_Id.Value = lblHub.Text
        'MsgBox(HdfHub_Id.Value)
        'Session("Hub_Id") = lblHub.Text
        Dim ReqId As Label = DirectCast(cph.FindControl("lblRequestID"), Label) 'Me.FindControl("lblRequestID")
    End Sub

    'Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
    '    Dim gvTemp As GridView = DirectCast(sender, GridView)
    '    Dim Req_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblReq_id"), Label)
    '    Dim Hub_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblHub_id"), Label)
    '    Dim Status_Id As HiddenField = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("hdfStatus_Id"), HiddenField)
    '    'MsgBox(Req_Id.Text)
    '    Dim myScript As String
    '    myScript = "<script>" + "window.open('Appraisal_Assign_Update_Job.aspx?Req_Id=" + Trim(Req_Id.Text) + "&Hub_Id=" + Trim(Hub_Id.Text) + "&Status_Id=" + Trim(Status_Id.Value) + "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, directories=no, status=yes,height=350px,width=450px');</script>"
    '    Page.ClientScript.RegisterStartupScript(Me.GetType, "กำหนดงานให้เจ้าหน้าที่ประเมิน", myScript)
    'End Sub

    Protected Sub imgPrint2View_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        'ให้ราคา
        'MsgBox("รายละเอียดการให้ราคาหลักประกัน")

        Dim ImgEdit As ImageButton = DirectCast(sender, ImageButton)
        Dim Req_Id As Label = ImgEdit.Parent.FindControl("lblReq_id")
        Dim Hub_Id As Label = ImgEdit.Parent.FindControl("lblHub_Id")
        Dim Hub_Name As Label = ImgEdit.Parent.FindControl("lblHub_Name")
        Dim Cif As Label = ImgEdit.Parent.FindControl("lblCif")
        Dim CifName As Label = ImgEdit.Parent.FindControl("lblCifName")
        Dim Status_Id As HiddenField = ImgEdit.Parent.FindControl("hdfStatus_Id")
        Dim myScript As String
        If Status_Id.Value < 6 Then
            myScript = "<script language=""javascript"">alert('กำหนดราคายังไม่เรียบร้อย'); </script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "ผลการบันทึก", myScript)
        Else
            myScript = "<script>" + "window.open('Appraisal_AppraisalPrice2.aspx?Req_Id=" + Trim(Req_Id.Text) + "&Hub_Id=" + Trim(Hub_Id.Text) + "&Hub_Name=" + Trim(Hub_Name.Text) + "&Cif=" + Trim(Cif.Text) + "&Cif_Name=" + Trim(CifName.Text) + "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, directories=no, status=yes,height=500px,width=800px');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "กำหนดงานให้เจ้าหน้าที่ประเมิน", myScript)
            'myScript = "<script>" + "window.open('Appraisal_Assign_Update_Job.aspx?Req_Id=" + Trim(Req_Id.Text) + "&Hub_Id=" + Trim(Hub_Id.Text) + "&Status_Id=" + Trim(Status_Id.Value) + "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, directories=no, status=yes,height=350px,width=450px');</script>"
            'Page.ClientScript.RegisterStartupScript(Me.GetType, "กำหนดงานให้เจ้าหน้าที่ประเมิน", myScript)
        End If

    End Sub

    Protected Sub imgEdit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim myScript As String
        Dim ImgEdit As ImageButton = DirectCast(sender, ImageButton)
        Dim Req_Id As Label = ImgEdit.Parent.FindControl("lblReq_id")
        Dim Hub_Id As Label = ImgEdit.Parent.FindControl("lblHub_id")
        Dim Status_Id As HiddenField = ImgEdit.Parent.FindControl("hdfStatus_Id")
        'MsgBox(Req_Id.Text)
        'If Status_Id.Value < 6 Then
        '    myScript = "<script language=""javascript"">alert('กำหนดราคายังไม่เรียบร้อย'); </script>"
        '    Page.ClientScript.RegisterStartupScript(Me.GetType, "ผลการบันทึก", myScript)
        'Else
        myScript = "<script>" + "window.open('Appraisal_Assign_Update_Job.aspx?Req_Id=" + Trim(Req_Id.Text) + "&Hub_Id=" + Trim(Hub_Id.Text) + "&Status_Id=" + Trim(Status_Id.Value) + "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, directories=no, status=yes,height=350px,width=450px');</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType, "กำหนดงานให้เจ้าหน้าที่ประเมิน", myScript)
        'End If

    End Sub

    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBound
        lblMessage.Text = GridView1.Rows.Count
    End Sub
End Class
