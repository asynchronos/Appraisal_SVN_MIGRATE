
Partial Class Appraisal_Price2
    Inherits System.Web.UI.Page
    Dim s As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Session("Hub_Id") = 3
        'Session("Status_Id") = 0

    End Sub

    Protected Sub DDL_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim D1 As DropDownList = DirectCast(sender, DropDownList)
        If Not Page.IsPostBack Then
            D1.DataSource = sdsCollType
            D1.DataTextField = "CollType_Name"
            D1.DataValueField = "CollType_ID"
            D1.DataBind()
        End If
    End Sub

    Protected Sub DDL_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim D1 As DropDownList = DirectCast(sender, DropDownList)
        'LblNotice.Text = D1.SelectedValue
    End Sub

    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
        Dim str As String = ""
        Dim lblAppraisal_Id As Label = TryCast(Me.Form.FindControl("lblUserID"), Label) 'หา Control จาก Master Page ที่ control ไม่อยู่ใน  ContentPlaceHolder1 ของ Master Page
        Dim gvTemp As GridView = DirectCast(sender, GridView)
        Dim Req_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblReq_Id"), Label)
        Dim Hub_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblHub_Id"), Label)
        Dim Cif As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblCif"), Label)
        Dim AID As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblAID"), Label)
        Dim CifName As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("LabelCifName"), Label)

        Dim ddlOperation As DropDownList = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("ddlOperation"), DropDownList)
        Context.Items("Req_Id") = Req_Id.Text
        Context.Items("Hub_Id") = Hub_Id.Text
        Context.Items("Coll_Type") = ddlOperation.SelectedValue
        Context.Items("CollType_Name") = ddlOperation.SelectedItem.Text
        'MsgBox(Context.Items("CollType_Name"))
        'Context.Items("AID") = AID.Text
        Context.Items("Cif") = Cif.Text
        Context.Items("CifName") = CifName.Text
        'Page.Response.Redirect("Modal_Popup.aspx")
        'Server.Transfer("Modal_Popup.aspx")

        If ddlOperation.SelectedValue <> 0 Then
            'Response.Redirect("Appraisal_Price2_New.aspx?Req_Id=" + Trim(Req_Id.Text) + "&Hub_Id=" + Trim(Hub_Id.Text) + "&Cif=" + Trim(Cif.Text) + "&CollType=" + Trim(ddlOperation.SelectedValue) + "&CollType_Name=" + Trim(ddlOperation.SelectedItem.Text))
            Response.Redirect("Apprisal_Price2_Interface.aspx?Req_Id=" + Trim(Req_Id.Text) + "&Hub_Id=" + Trim(Hub_Id.Text) + "&Cif=" + Trim(Cif.Text) + "&CifName=" + Trim(CifName.Text) + "&Appraisal_Id=" + Trim(lblAppraisal_Id.Text) + "&CollType=" + Trim(ddlOperation.SelectedValue) + "&CollType_Name=" + Trim(ddlOperation.SelectedItem.Text))
        Else

        End If


        'If ddlOperation.SelectedValue = 50 Then
        '    Server.Transfer("Appraisal_Price2_Add_By_Colltype.aspx")
        'ElseIf ddlOperation.SelectedValue = 70 Then
        '    Server.Transfer("Appraisal_Price2_Add_By_Colltype70_New.aspx")
        'ElseIf ddlOperation.SelectedValue = 15 Then
        'ElseIf ddlOperation.SelectedValue = 18 Then
        '    Server.Transfer("Appraisal_Price2_Add_By_Colltype18.aspx")
        'End If
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim cph As ContentPlaceHolder = TryCast(Me.Form.FindControl("ContentPlaceHolder1"), ContentPlaceHolder) 'หา Control จาก Master Page ที่ control อยู่ใน  ContentPlaceHolder1
        Dim lblHub As Label = TryCast(Me.Form.FindControl("lblHub_Id"), Label)
        Session("Hub_Id") = lblHub.Text
        Session("Status_Id") = 5
        Dim ReqId As Label = DirectCast(cph.FindControl("lblRequestID"), Label) 'Me.FindControl("lblRequestID")
    End Sub

End Class
