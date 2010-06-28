Imports Appraisal_Manager
Imports System.Data

Partial Class Appraisal_For_Wait_Approve2
    Inherits System.Web.UI.Page
    Dim StrNotice As String
    Dim StrPath As String
    Dim s1 As String = Nothing
    Dim s As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindDropDown()
            LoadData()
        End If
    End Sub

    Sub LoadData()
        If TextBoxOptionSearch.Text = String.Empty Then
            'ยังไม่ได้เลือกการค้นหา
            sdsForApprove.SelectParameters.Clear()
            sdsForApprove.SelectCommand = "GET_PRICE3_MASTER_FOR_APPROVE"
            sdsForApprove.SelectCommandType = SqlDataSourceCommandType.StoredProcedure
            sdsForApprove.SelectParameters.Add("Approved", 0)
            sdsForApprove.SelectParameters.Add("Req_Id", 0)
            sdsForApprove.SelectParameters.Add("Hub_Id", 0)
            sdsForApprove.SelectParameters.Add("Cif", 0)

        Else
            sdsForApprove.SelectParameters.Clear()
            sdsForApprove.SelectCommand = "GET_PRICE3_MASTER_FOR_APPROVE"
            sdsForApprove.SelectCommandType = SqlDataSourceCommandType.StoredProcedure
            If DropDownListOptionSearch.Items(DropDownListOptionSearch.SelectedIndex).Value = "Req_Id" Then
                sdsForApprove.SelectParameters.Add("Approved", 0)
                sdsForApprove.SelectParameters.Add("Req_Id", TextBoxOptionSearch.Text)
                sdsForApprove.SelectParameters.Add("Hub_Id", 0)
                sdsForApprove.SelectParameters.Add("Cif", 0)
            ElseIf DropDownListOptionSearch.Items(DropDownListOptionSearch.SelectedIndex).Value = "Cif" Then
                sdsForApprove.SelectParameters.Add("Approved", 0)
                sdsForApprove.SelectParameters.Add("Req_Id", 0)
                sdsForApprove.SelectParameters.Add("Hub_Id", 0)
                sdsForApprove.SelectParameters.Add("Cif", TextBoxOptionSearch.Text)
            ElseIf DropDownListOptionSearch.Items(DropDownListOptionSearch.SelectedIndex).Value = "Hub_Id" Then
                sdsForApprove.SelectParameters.Add("Approved", 0)
                sdsForApprove.SelectParameters.Add("Req_Id", 0)
                sdsForApprove.SelectParameters.Add("Hub_Id", TextBoxOptionSearch.Text)
                sdsForApprove.SelectParameters.Add("Cif", 0)
            End If
            'GridView1.DataSource = sdsForApprove
            'GridView1.DataBind()
        End If
        GridView1.DataSource = sdsForApprove
        GridView1.DataBind()


    End Sub

    Sub BindDropDown()
        DropDownListOptionSearch.Items.Insert(0, New ListItem("เลขคำขอประเมิน", "Req_Id"))
        DropDownListOptionSearch.Items.Insert(1, New ListItem("CIF", "Cif"))
        DropDownListOptionSearch.Items.Insert(2, New ListItem("HUB ID", "Hub_Id"))
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'MsgBox((Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Cnt_Item"))))
            If (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Cnt_Item")) = "3") Then
                'e.Row.BackColor = System.Drawing.Color.Yellow
            Else
                e.Row.BackColor = System.Drawing.Color.Yellow
            End If
        End If
    End Sub

    Protected Sub ButtonSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSearch.Click
        LoadData()
    End Sub


    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim A1 As String
        Dim i As Integer
        Dim ApprroveID As String
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        A1 = lbluserid.Text
        i = A1.IndexOf("_")
        If i > 0 Then
            ApprroveID = Left(A1, i)
        Else
            ApprroveID = lbluserid.Text
        End If
        HiddenFieldUserLogin.Value = ApprroveID.ToString
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        LoadData()
    End Sub

    Protected Sub imgApprove_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim imgApprove As ImageButton = DirectCast(sender, ImageButton)
        Dim Approved1 As Label = imgApprove.Parent.FindControl("lblApproved1")
        Dim Approved2 As Label = imgApprove.Parent.FindControl("lblApproved2")
        Dim Approved3 As Label = imgApprove.Parent.FindControl("lblApproved3")
        Dim Approved1_Id As HiddenField = imgApprove.Parent.FindControl("hdfApproved1")
        Dim Approved2_Id As HiddenField = imgApprove.Parent.FindControl("hdfApproved2")
        Dim Approved3_Id As HiddenField = imgApprove.Parent.FindControl("hdfApproved3")
        Dim Lng As Label = imgApprove.Parent.FindControl("lblLng")
        Dim Lat As Label = imgApprove.Parent.FindControl("lblLat")
        Dim AID As Label = imgApprove.Parent.FindControl("lblAID")
        Dim Req_Id As Label = imgApprove.Parent.FindControl("lblReq_Id")
        Dim Hub_Id As Label = imgApprove.Parent.FindControl("lblHub_Id")
        Dim Cif As Label = imgApprove.Parent.FindControl("lblCif")
        Dim Temp_AID As Label = imgApprove.Parent.FindControl("lblTemp_AID")
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)


        Dim ObjW4A As Integer = GET_WAIT_FOR_APPROVE_BY_REQ_ID(Req_Id.Text, Hub_Id.Text, Approved1_Id.Value, Approved2_Id.Value, Approved3_Id.Value)
        If ObjW4A = 3 Then
            Try
                If AID.Text = "0" Then
                    StrNotice = "<Script language=""javascript"">alert('คุณยังไม่เลข AID ใส่ข้อมูล AID ก่อนจะทำการอนุมัติ');</Script>"
                    Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", StrNotice)
                Else
                    'Update Field Approved ในตาราง Prive3_Master เป็น ค่า 1 จากเดิมคือค่า 0
                    UPDATE_PRICE3_MASTER_APPROVE(Req_Id.Text, AID.Text, Temp_AID.Text, Cif.Text)
                    UPDATE_Status_Appraisal_Request(Req_Id.Text, Hub_Id.Text, 12)
                    GridView1.DataBind()
                    StrNotice = "<Script language=""javascript"">alert('การอนุมัติเสร็จสมบูรณ์');</Script>"
                    Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", StrNotice)
                End If

            Catch ex As Exception
                StrNotice = "<Script language=""javascript"">alert('ไม่สามารถ Approved ได้ ข้อมูลผิดพลาด');</Script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", StrNotice)
            End Try
        Else
            'StrPath = Request.ApplicationPath & "/ListOfAppraisal_Approve.aspx?Req_Id=" & Req_Id.Text & "&Hub_Id=" & Hub_Id.Text
            's1 = "<script language=""javascript"">window.open('" + StrPath + "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, directories=no, status=yes,height=400px,width=780px');</script>"
            'Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", s1)
            StrNotice = "<Script language=""javascript"">alert('อนุกรรมการเซ็นต์ไม่ครบ 3 คน');</Script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "NoticeCommittee", StrNotice)
        End If

    End Sub
End Class
