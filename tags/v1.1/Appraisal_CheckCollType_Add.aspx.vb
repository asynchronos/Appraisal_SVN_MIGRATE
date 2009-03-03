
Partial Class Appraisal_CheckCollType_Add
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblReq_Id.Text = Context.Items("Req_Id") 'Request.QueryString("Req_Id")
            lblHub_Id.Text = Context.Items("Hub_Id") 'Request.QueryString("Hub_Id")
            lblCif.Text = Context.Items("Cif") 'Request.QueryString("Cif")
            lblAID.Text = Context.Items("AID") 'Request.QueryString("Aid")
        End If

    End Sub

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Select Case ddlCollType.SelectedValue
            Case "15"
                'showAll()
            Case "18"
                LinkToAppraisal_Price3_18()
            Case "50"
                LinkToAppraisal_Price3_50()
            Case "60"

            Case "70"
                LinkToAppraisal_Price3_70()
        End Select
    End Sub

    Private Sub LinkToAppraisal_Price3_18()

    End Sub

    Private Sub LinkToAppraisal_Price3_50()
        Context.Items("Req_Id") = lblReq_Id.Text
        Context.Items("Hub_Id") = lblHub_Id.Text
        Context.Items("Cif") = lblCif.Text
        Context.Items("AID") = lblAID.Text
        Context.Items("Temp_AID") = ""
        Context.Items("ID") = ""
        Context.Items("Coll_Type") = ""
        Context.Items("SpecialAdd") = "เพิ่มกรณีพิเศษ"
        'Server.Transfer("Appraisal_Price3_Add_Colltype50.aspx")
        Server.Transfer("Appraisal_Price2_Add_By_Colltype.aspx")

        'Dim str, s As String
        'str = "Appraisal_CheckCollType_Add.aspx?Req_Id=" & lblReq_Id.Text & "&Hub_Id=" & lblHub_Id.Text & "&Aid=" & "" & "&Cif=" & lblCif.Text
        's = "<script language=""javascript"">window.close('" + str + "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, copyhistory=no, directories=no, status=yes,height=250px,width=350px');</script>"
        'Page.ClientScript.RegisterStartupScript(Me.GetType, "จัดกลุ่ม", s)



    End Sub

    Private Sub LinkToAppraisal_Price3_70()

    End Sub
End Class
