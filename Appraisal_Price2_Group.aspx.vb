Imports Appraisal_Manager
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI
Partial Class Appraisal_Price2_Group
    Inherits System.Web.UI.Page
    Dim s As String
#Region "Variables"
    Dim gvUniqueID As String = String.Empty
    Dim gvNewPageIndex As Integer = 0
    Dim gvEditIndex As Integer = -1
    Dim gvSortExpr As String = String.Empty
#End Region

    Protected Sub cb1_Checked(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb1 As CheckBox = sender
        For Each gdi As GridViewRow In GridView1.Rows
            If gdi.RowType = DataControlRowType.DataRow Then
                Dim cb2 As CheckBox = gdi.Cells(0).FindControl("cb2")
                cb2.Checked = cb1.Checked
            End If
        Next
    End Sub

    Protected Sub cb2_Checked(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb2 As CheckBox = sender

        If cb2.Checked Then
            Dim Appraisal_Id As Label = cb2.Parent.Parent.FindControl("lblAppraisal_Id")
            Dim Req_Id As Label = cb2.Parent.Parent.FindControl("lblReq_Id")
            ddlUserAppraisal.SelectedValue = Appraisal_Id.Text
            HiddenReq_No.Value = Req_Id.Text
            Dim Temp_Aid As Label = cb2.Parent.Parent.FindControl("lblTemp_AID")
            If Trim(Temp_Aid.Text) <> "0" Or Trim(Temp_Aid.Text) = String.Empty Then
                cb2.Checked = False
                s = "<script language=""javascript"">alert('คุณกำหนดกลุ่มประเมินแล้ว'); </script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "กำหนดกลุ่มประเมิน", s)
            End If
        Else
            HiddenReq_No.Value = Nothing
        End If
    End Sub

    Protected Sub ImageSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSave.Click
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        Dim lblHub As Label = TryCast(Me.Form.FindControl("lblHub_Id"), Label)
        Dim Cnt As Integer = 0
        Dim cph As ContentPlaceHolder = TryCast(Me.Form.FindControl("ContentPlaceHolder1"), ContentPlaceHolder)
        Dim GV As GridView = DirectCast(cph.FindControl("GridView1"), GridView)
        Dim TEMPAID As Integer
        'Dim GV As GridView = FindControl("gvPrice2_GroupList")
        Dim gvr_master As GridViewRow

        If ddlUserAppraisal.SelectedValue = "" Then
            s = "<script language=""javascript"">alert('คุณไม่ได้เลือกผู้ประเมิน'); </script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)
            Exit Sub
        End If

        If ddlUserAppraisal.SelectedValue = 0 Or CStr(ddlUserAppraisal.SelectedValue) = String.Empty Then
            s = "<script language=""javascript"">alert('คุณไม่ได้เลือกผู้ประเมิน'); </script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)
            Exit Sub
        End If

        If rdbAppraisal_Type.SelectedValue = 0 Then
            s = "<script language=""javascript"">alert('คุณไม่ได้เลือกวิธีการให้ราคา'); </script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "ให้ความคิดเห็น", s)
            Exit Sub
        End If
        'If txtComment.Text = String.Empty Then
        '    s = "<script language=""javascript"">alert('คุณไม่ได้ใส่ Comment ของการให้ราคาที่ 2'); </script>"
        '    Page.ClientScript.RegisterStartupScript(Me.GetType, "ให้ความคิดเห็น", s)
        '    Exit Sub
        'End If

        If GV.Rows.Count > 0 Then
            If txtTemp_AID.Text = String.Empty Then
                TEMPAID = Appraisal_Manager.GET_TEMP_AID()
                UPDATE_TEMP_AID()
                For Each gvr_master In GV.Rows
                    Dim chk2 As CheckBox = gvr_master.FindControl("cb2")
                    If chk2.Checked = True Then
                        Cnt = Cnt + 1
                    End If
                Next

                If Cnt > 0 Then
                    txtTemp_AID.Text = Str(TEMPAID)
                    'วนลูปเพื่อหาข้อมูลที่ Check จัดให้กลุ่ม
                    For Each gvr_master In GV.Rows

                        Dim chk2 As CheckBox = gvr_master.FindControl("cb2")
                        Dim Req_id As Label = gvr_master.FindControl("lblReq_Id")
                        Dim Hub_id As Label = gvr_master.FindControl("lblHub_Id")
                        Dim Cif As Label = gvr_master.FindControl("lblCif")
                        If Cif.Text = String.Empty Then
                            Cif.Text = "0"
                        Else

                        End If

                        Dim Id As Label = gvr_master.FindControl("lblID")
                        Dim CollType As Label = gvr_master.FindControl("lblCollType")

                        If chk2.Checked = True Then
                            'ส่งค่าไป Insert และท ำการ Update สถานะการประเมิน
                            AddPRICE2_Master(txtTemp_AID.Text, Req_id.Text, Hub_id.Text, Id.Text, Cif.Text, ddlUserAppraisal.SelectedValue, CollType.Text, ddlComment.SelectedItem.Text, String.Empty, 0, rdbAppraisal_Type.SelectedValue, txtNote.Text, lbluserid.Text, Now())
                            UPDATE_PRICE2_70_DETAIL_AND_PARTAKE(Id.Text, Req_id.Text, Hub_id.Text, txtTemp_AID.Text)
                        End If

                    Next

                    s = "<script language=""javascript"">alert('บันทึกเสร็จสมบูรณ์'); </script>"
                    Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)
                    GridView1.DataBind()
                Else
                    'Alert แจ้งเตือนว่ายังไม่ได้เลือกหลักประกันที่ยังไม่ได้จัดกลุ่ม
                    s = "<script language=""javascript"">alert('คุณยังไม่ได้เลือกหลักประกันที่จะจัดกลุ่ม');</script>"
                    Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
                End If
            Else
                TEMPAID = CInt(txtTemp_AID.Text)
                For Each gvr_master In GV.Rows
                    Dim chk2 As CheckBox = gvr_master.FindControl("cb2")
                    Dim Req_id As Label = gvr_master.FindControl("lblReq_Id")
                    Dim Hub_id As Label = gvr_master.FindControl("lblHub_Id")
                    Dim Cif As Label = gvr_master.FindControl("lblCif")
                    If Cif.Text = String.Empty Then
                        Cif.Text = "0"
                    Else

                    End If

                    Dim Id As Label = gvr_master.FindControl("lblID")
                    Dim CollType As Label = gvr_master.FindControl("lblCollType")

                    If chk2.Checked = True Then
                        UPDATE_PRICE2_18_50_70(TEMPAID, Req_id.Text, Hub_id.Text, Id.Text, CollType.Text)
                    End If
                Next
                s = "<script language=""javascript"">alert('บันทึกเสร็จสมบูรณ์'); </script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)
                GridView1.DataBind()
            End If

        Else
            s = "<script language=""javascript"">alert('ไม่พบหลักประกันที่จะจัดกลุ่ม');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
        End If


    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            If DirectCast(e.Row.DataItem, DataRowView)("Temp_AID").ToString() = String.Empty Then
                e.Row.Visible = False
            Else
                Dim Expl As String = String.Empty
                Dim Req_ID As Object = DirectCast(e.Row.DataItem, DataRowView)("Req_Id").ToString()
                Dim Hub_ID As Object = DirectCast(e.Row.DataItem, DataRowView)("Hub_Id").ToString()
                Dim ID As Object = DirectCast(e.Row.DataItem, DataRowView)("ID").ToString()
                Dim Address_No As Object = DirectCast(e.Row.DataItem, DataRowView)("Address_No").ToString()
                Dim CifName As Object = DirectCast(e.Row.DataItem, DataRowView)("CifName").ToString()
                Expl = "เลขคำขอที่ " & Req_ID & " Hub เลขที่ " & Hub_ID & "" & " หลักประกันเลขที่ " & Address_No & " ของลูกค้าราย " & CifName
                'MsgBox(DirectCast(e.Row.DataItem, DataRowView)("ID").ToString())
                If e.Row.RowState <> DataControlRowState.Edit Then
                    ' check for RowState 
                    If e.Row.RowType = DataControlRowType.DataRow Then
                        'check for RowType 
                        'Dim id As String = e.Row.Cells(0).Text
                        ' Get the id to be deleted 
                        Dim Ib As ImageButton = DirectCast(e.Row.Cells(11).FindControl("ImgDelete"), ImageButton)
                        'Dim Ib As Object = DirectCast(e.Row.DataItem, DataRowView)("ImgDelete")
                        'access the LinkButton from the TemplateField using FindControl method 
                        If Ib IsNot Nothing Then
                            Ib.Attributes.Add("onclick", "return ConfirmOnDelete('" & Expl & "');")
                            'attach the JavaScript function 
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Protected Sub GridView1_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles GridView1.RowDeleted
        'Check if there is any exception while deleting 
        If e.Exception IsNot Nothing Then
            ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" & e.Exception.Message.ToString().Replace("'", "") & "');</script>")
            e.ExceptionHandled = True
        End If
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim gvTemp As GridView = DirectCast(sender, GridView)
        gvUniqueID = gvTemp.UniqueID

        'Get the value 
        Dim Req_Id As Label = DirectCast(gvTemp.Rows.Item(e.RowIndex).FindControl("lblReq_Id"), Label)
        Dim Hub_Id As Label = DirectCast(gvTemp.Rows.Item(e.RowIndex).FindControl("lblHub_Id"), Label)
        Dim ID As Label = DirectCast(gvTemp.Rows.Item(e.RowIndex).FindControl("lblID"), Label)
        Dim lblColl_type As Label = DirectCast(gvTemp.Rows.Item(e.RowIndex).FindControl("lblColltype"), Label)
        'MsgBox(Hid_ID.Value.ToString)

        'Prepare the Update Command of the DataSource control 
        Try
            If lblColl_type.Text = 50 Then
                DELETE_PRICE2_50(ID.Text, Req_Id.Text, Hub_Id.Text)
            ElseIf lblColl_type.Text = 70 Then
                DELETE_PRICE2_70(ID.Text, Req_Id.Text, Hub_Id.Text)
            ElseIf lblColl_type.Text = 18 Then
                DELETE_PRICE2_18(ID.Text, Req_Id.Text, Hub_Id.Text)
            End If
            'คำสั่งเมื่อ Delete เสร็จ
            'ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Appraisal deleted successfully');</script>")
            GridView1.DataBind()
        Catch
        End Try
    End Sub

    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
        Dim str As String = ""
        Dim gvTemp As GridView = DirectCast(sender, GridView)
        Dim Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblID"), Label)
        Dim Req_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblReq_Id"), Label)
        Dim Hub_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblHub_Id"), Label)
        Dim Temp_AID As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblTemp_AID"), Label)
        Dim Cif As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblCif"), Label)
        Dim CollType As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblCollType"), Label)

        Context.Items("ID") = Id.Text
        Context.Items("Req_Id") = Req_Id.Text
        Context.Items("Hub_Id") = Hub_Id.Text
        Context.Items("Coll_Type") = CollType.Text
        Context.Items("AID") = ""
        Context.Items("Temp_AID") = Temp_AID.Text
        Context.Items("Cif") = Cif.Text

        'If Temp_AID.Text = String.Empty Or Temp_AID.Text = "0" Then
        If CollType.Text = 50 Then
            Server.Transfer("Appraisal_Price2_Add_By_Colltype.aspx")
            'Response.Redirect("Appraisal_Price2_Add_By_Colltype.aspx?Req_id=" & Req_Id.Text & "&Hub_Id=" & Hub_Id.Text & "&Coll_Type=" & CollType.Text & "&Id=" & Id.Text & "&Cif=" & Cif.Text)
        ElseIf CollType.Text = 70 Then
            'Response.Redirect("Appraisal_Price2_Add_By_Colltype70_New.aspx?Req_id=" & Req_Id.Text & "&Hub_Id=" & Hub_Id.Text & "&Coll_Type=" & CollType.Text & "&Id=" & Id.Text & "&Cif=" & Cif.Text)
            Server.Transfer("Appraisal_Price2_Add_By_Colltype70_New.aspx")
        ElseIf CollType.Text = 15 Then
        ElseIf CollType.Text = 18 Then
            Server.Transfer("Appraisal_Price2_Add_By_Colltype18.aspx")
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            txtTemp_AID.Text = Context.Items("Temp_AID")
            ddlUserAppraisal.SelectedValue = Context.Items("Appraisal_Id")
        End If
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim lblHub As Label = TryCast(Me.Form.FindControl("lblHub_Id"), Label)
        HiddenHubId.Value = lblHub.Text
    End Sub

    Protected Sub ImgBtnAttachment_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnAttachment.Click
        Dim ImgBtAdd As ImageButton = DirectCast(sender, ImageButton)
        Dim lblTemp_AID As New Label
        If ImgBtAdd.Parent.FindControl("lblTemp_AID") Is Nothing Then
            lblTemp_AID.Text = 0
        Else
            lblTemp_AID = DirectCast(ImgBtAdd.Parent.FindControl("lblTemp_AID"), Label)
        End If

        Dim lblCollType_Id As Label = ImgBtAdd.Parent.FindControl("lblColltype")
        Dim lblUser_Id As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        Dim str As String
        If IsNothing(lblTemp_AID.Text) Then
            lblTemp_AID.Text = "0"
        End If

        If HiddenReq_No.Value <> Nothing Then
            str = "FileUpload_Price2.aspx?Req_Id=" & HiddenReq_No.Value & "&Hub_Id=" & HiddenHubId.Value & "&Temp_AID=" & lblTemp_AID.Text & "&User_Id=" & lblUser_Id.Text
            s = "<script language=""javascript"">window.open('" + str + "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, copyhistory=no, directories=no, status=yes,height=350px,width=550px');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "จัดกลุ่ม", s)
        Else
            s = "<script language=""javascript"">alert('คุณยังไม่ได้เลือกชิ้นทรัพย์'); </script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "ผลการบันทึก", s)
        End If


    End Sub

    Protected Sub ImgAddFile_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim ImgBtAdd As ImageButton = DirectCast(sender, ImageButton)
        Dim lblTemp_AID As New Label
        If ImgBtAdd.Parent.FindControl("lblTemp_AID") Is Nothing Then
            lblTemp_AID.Text = 0
        Else
            lblTemp_AID = DirectCast(ImgBtAdd.Parent.FindControl("lblTemp_AID"), Label)
        End If

        Dim lblCollType_Id As Label = ImgBtAdd.Parent.FindControl("lblColltype")
        Dim lblUser_Id As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        Dim hdfReq_Id As Label = ImgBtAdd.Parent.FindControl("lblReq_Id")

        Dim str As String
        If IsNothing(lblTemp_AID.Text) Then
            lblTemp_AID.Text = "0"
        End If

        If hdfReq_Id.Text <> Nothing Then
            str = "FileUpload_Price2.aspx?Req_Id=" & hdfReq_Id.Text & "&Hub_Id=" & HiddenHubId.Value & "&Temp_AID=" & lblTemp_AID.Text & "&User_Id=" & lblUser_Id.Text
            s = "<script language=""javascript"">window.open('" + str + "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, copyhistory=no, directories=no, status=yes,height=350px,width=550px');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "จัดกลุ่ม", s)
        Else
            s = "<script language=""javascript"">alert('คุณยังไม่ได้เลือกชิ้นทรัพย์'); </script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "ผลการบันทึก", s)
        End If

    End Sub

    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    MsgBox(rdbAppraisal_Type.SelectedValue)
    'End Sub
End Class
