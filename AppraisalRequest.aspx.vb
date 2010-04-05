Imports Appraisal_Manager
Imports SME_SERVICE
Imports System.Data
Imports System.Data.SqlClient

Partial Class AppraisalRequest
    Inherits System.Web.UI.Page
    Private ds As DataSet
    Private strMessage As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cph As ContentPlaceHolder = TryCast(Me.Form.FindControl("ContentPlaceHolder1"), ContentPlaceHolder)
        Dim chkbox As CheckBox = DirectCast(cph.FindControl("ChkBoxCopy"), CheckBox)
        chkbox.Attributes.Add("onclick", "return copyDataCif();")
        UpdatePanel1.Visible = False
    End Sub

    Protected Sub bntRequest_ID_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bntRequest_ID.Click
        Page.Validate("1")
        Page.Validate("2")
        Page.Validate("3")
        Page.Validate("4")
        If (Page.IsValid) Then
            Dim lbluser_create As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
            If ddlAppraisal_Method.SelectedValue = 1 Then
                'ประเมินใหม่               
                '******* ออกเลขคำขอประเมิน ****************
                ds = GET_RequestID()
                lblRequestID.Text = ds.Tables(0).Rows.Item(0).Item("Req_ID")
                '***************************************

                '***************************************** SAVE DATA ****************************************
                AddAppraisal_Request_Master(lblRequestID.Text, TxtCif.Text, ddlTitle.SelectedValue, TxtCifName.Text, TxtCifLastName.Text, ddlAppraisal_Method.SelectedValue, TextBoxAID.Text, 0, TxtSender.Text, TxtSenderName.Text, lbluser_create.Text, Now())
                ADD_APPRAISAL_REQUEST_V2(lblRequestID.Text, TextBoxHubCode.Text, TxtCif.Text, ddlTitle.SelectedValue, _
                                         TxtCifName.Text, TxtCifLastName.Text, TxtCifColl.Text, ddlTitleColl.SelectedValue, _
                                         TxtCifNameColl.Text, TxtCifLastNameColl.Text, ddlAppraisal_Method.SelectedValue, _
                                         0, 0, TextBoxDepartmentCode.Text, TextBoxTambonCode.Text, _
                                         TextBoxAmphurCode.Text, TextBoxProvinceCode.Text, ddlAPPLICATION_TYPE.SelectedValue, TextBoxChanode.Text, TextBoxFlag.Text, lbluser_create.Text, Now())
                '*************************************** END OF SAVE DATA ************************************

                '************* Update เลขคำขอประเมิน **********************
                UPDATE_REQUEST_ID()
                '******************************************************
                strMessage = "<script language=""javascript"">alert('คำขอประเมิน บันทึกเสร็จสมบูรณ์ กรุณาแนบไฟล์ด้านล่างเพื่อประกอบการประเมิน');</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "Message", strMessage)
                lblMessage.Text = "กรุณาแนบไฟล์ด้านล่างเพื่อประกอบการประเมิน"
                UpdatePanel1.Visible = True
                bntRequest_ID.Enabled = False
            Else
                'ทบทวนประเมิน
                If TextBoxAID.Text = String.Empty Then
                    lblMessage.Text = "ไม่มีเลข AID"
                Else
                    '******* ออกเลขคำขอประเมิน ****************
                    ds = GET_RequestID()
                    lblRequestID.Text = ds.Tables(0).Rows.Item(0).Item("Req_ID")
                    '***************************************

                    '***************************************** SAVE DATA ****************************************
                    AddAppraisal_Request_Master(lblRequestID.Text, TxtCif.Text, ddlTitle.SelectedValue, TxtCifName.Text, TxtCifLastName.Text, ddlAppraisal_Method.SelectedValue, TextBoxAID.Text, 0, TxtSender.Text, TxtSenderName.Text, lbluser_create.Text, Now())
                    ADD_APPRAISAL_REQUEST_V2(lblRequestID.Text, TextBoxHubCode.Text, TxtCif.Text, ddlTitle.SelectedValue, _
                                             TxtCifName.Text, TxtCifLastName.Text, TxtCifColl.Text, ddlTitleColl.SelectedValue, _
                                             TxtCifNameColl.Text, TxtCifLastNameColl.Text, ddlAppraisal_Method.SelectedValue, _
                                             0, 0, TextBoxDepartmentCode.Text, TextBoxTambonCode.Text, _
                                         TextBoxAmphurCode.Text, TextBoxProvinceCode.Text, ddlAPPLICATION_TYPE.SelectedValue, TextBoxChanode.Text, TextBoxFlag.Text, lbluser_create.Text, Now())
                    '*************************************** END OF SAVE DATA ************************************

                    '************* Update เลขคำขอประเมิน **********************
                    UPDATE_REQUEST_ID()
                    '******************************************************
                    strMessage = "<script language=""javascript"">alert('คำขอประเมิน บันทึกเสร็จสมบูรณ์ กรุณาแนบไฟล์ด้านล่างเพื่อประกอบการประเมิน');</script>"
                    Page.ClientScript.RegisterStartupScript(Me.GetType, "Message", strMessage)
                    lblMessage.Text = "กรุณาแนบไฟล์ด้านล่างเพื่อประกอบการประเมิน"
                    UpdatePanel1.Visible = True
                    bntRequest_ID.Enabled = False
                End If
            End If
        End If
    End Sub

    Private Function GET_RequestID() As DataSet

        'For Print Data Out
        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        MyConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)

        MyDataAdapter = New SqlDataAdapter("GET_REQUEST_ID", MyConnection)
        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
        'MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Q_ID", SqlDbType.Int))
        'MyDataAdapter.SelectCommand.Parameters("@Q_ID").Value = QID

        DS = New DataSet() 'Create a new DataSet to hold the records.
        MyDataAdapter.Fill(DS, "GET_REQUEST_ID") 'Fill the DataSet with the rows returned.
        Return DS

    End Function

    Protected Sub btnFinish_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFinish.Click
        Response.Redirect("Appraisal_Request_New.aspx")
    End Sub

    Protected Sub btnJobList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJobList.Click
        Server.Transfer("Apprisal_Request_JobList.aspx")
    End Sub
End Class
