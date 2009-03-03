Imports Appraisal_Manager
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI
Partial Class Appraisal_Price2_Group
    Inherits System.Web.UI.Page

    Protected Sub cb1_Checked(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb1 As CheckBox = sender
        For Each gdi As GridViewRow In GridView1.Rows
            If gdi.RowType = DataControlRowType.DataRow Then
                Dim cb2 As CheckBox = gdi.Cells(0).FindControl("cb2")
                cb2.Checked = cb1.Checked
            End If
        Next
    End Sub

    Protected Sub ImageSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSave.Click
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        Dim lblHub As Label = TryCast(Me.Form.FindControl("lblHub_Id"), Label)
        Dim Cnt As Integer = 0
        Dim cph As ContentPlaceHolder = TryCast(Me.Form.FindControl("ContentPlaceHolder1"), ContentPlaceHolder)
        Dim GV As GridView = DirectCast(cph.FindControl("GridView1"), GridView)

        'Dim GV As GridView = FindControl("gvPrice2_GroupList")
        Dim s As String
        Dim gvr_master As GridViewRow

        If GV.Rows.Count > 0 Then
            Dim TEMPAID As Integer = Appraisal_Manager.GET_TEMP_AID()
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
                        AddPRICE2_Master(txtTemp_AID.Text, Req_id.Text, Hub_id.Text, Id.Text, Cif.Text, ddlUserAppraisal.SelectedValue, CollType.Text, lbluserid.Text, Now())
                    End If

                Next
                'UPDATE_TEMP_AID()
                s = "<script language=""javascript"">alert('บันทึกเสร็จสมบูรณ์ ระบบจะปิดหน้าต่างนี้'); </script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)
                GridView1.DataBind()
            Else
                'Alert แจ้งเตือนว่ายังไม่ได้เลือกหลักประกันที่ยังไม่ได้จัดกลุ่ม
                s = "<script language=""javascript"">alert('คุณยังไม่ได้เลือกหลักประกันที่จะจัดกลุ่ม');</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
            End If
        Else
            s = "<script language=""javascript"">alert('ไม่พบหลักประกันที่จะจัดกลุ่ม');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
        End If


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

        Context.Items("Id") = Id.Text
        Context.Items("Req_Id") = Req_Id.Text
        Context.Items("Hub_Id") = Hub_Id.Text
        Context.Items("Coll_Type") = CollType.Text
        Context.Items("AID") = ""
        Context.Items("Cif") = Cif.Text

        If Temp_AID.Text = String.Empty Or Temp_AID.Text = "0" Then
            If CollType.Text = 50 Then
                Server.Transfer("Appraisal_Price2_Add_By_Colltype.aspx")
                'Response.Redirect("Appraisal_Price2_Add_By_Colltype.aspx?Req_id=" & Req_Id.Text & "&Hub_Id=" & Hub_Id.Text & "&Coll_Type=" & CollType.Text & "&Id=" & Id.Text & "&Cif=" & Cif.Text)
            ElseIf CollType.Text = 70 Then
                Response.Redirect("Appraisal_Price2_Add_By_Colltype70.aspx?Req_id=" & Req_Id.Text & "&Hub_Id=" & Hub_Id.Text & "&Coll_Type=" & CollType.Text & "&Id=" & Id.Text & "&Cif=" & Cif.Text)
            ElseIf CollType.Text = 15 Then
            ElseIf CollType.Text = 18 Then
                Server.Transfer("Appraisal_Price2_Add_By_Colltype18.aspx")
            End If
        Else
            Dim s As String
            s = "<script language=""javascript"">alert('คุณไม่สามารถแก้ไขข้อมูลได้เพราะมีเลข Temp AID  แล้ว');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)

        End If

    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim lblHub As Label = TryCast(Me.Form.FindControl("lblHub_Id"), Label)
        HiddenHubId.Value = lblHub.Text
    End Sub
End Class
