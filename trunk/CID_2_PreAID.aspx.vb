Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI

Partial Class CID_2_PreAID
    Inherits System.Web.UI.Page
    Dim Appraisal_id As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not Page.IsPostBack Then
        '    Appraisal_id = DropDownList1.SelectedValue
        'End If

    End Sub

    Protected Sub cb1_Checked(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb1 As CheckBox = sender
        For Each gdi As GridViewRow In GridView1.Rows
            If gdi.RowType = DataControlRowType.DataRow Then
                Dim cb2 As CheckBox = gdi.Cells(0).FindControl("cb2")
                cb2.Checked = cb1.Checked
            End If
        Next
    End Sub

    Protected Sub btnSaveGroup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveGroup.Click
        Dim GV As GridView = FindControl("GridView1")
        Dim cnt As Integer = 0
        Dim s As String
        Dim gvr_master As GridViewRow

        If DropDownList1.SelectedValue <> 0 Then
            'Get Temp_AID No.
            Dim TEMPAID As Integer = Appraisal_Manager.GET_TEMP_AID()
            lblTempAID.Text = Str(TEMPAID)
            'MsgBox(lblTempAID.Text & " " & DropDownList1.SelectedValue)

            'Save Data that Checked Checkbox in Gridview
            For Each gvr_master In GV.Rows
                Dim chk2 As CheckBox = gvr_master.FindControl("cb2")
                Dim lblQ_ID As Label = gvr_master.FindControl("lblQ_ID")
                Dim lblColl_ID As Label = gvr_master.FindControl("lblColl_ID")

                If chk2.Checked = True Then
                    Appraisal_Manager.UPDATE_PRE_AID(lblQ_ID.Text, lblColl_ID.Text, lblTempAID.Text, DropDownList1.SelectedValue)
                    cnt = cnt + 1
                End If
            Next

            'ตรวจสอบว่ามีการเช็คข้อมูลหรือไม่
            If cnt > 0 Then 'ถ้ามี
                Appraisal_Manager.UPDATE_TEMP_AID()
                Appraisal_Manager.INSERT_PROCESSID(Request.QueryString("Q_ID"), 4)
                Appraisal_Manager.UPDATE_STATUS_AT_MASTER(Request.QueryString("Q_ID"), 4)
                s = "<script language=""javascript"">alert('บันทึกเสร็จสมบูรณ์ ระบบจะปิดหน้าต่างนี้');  window.close();</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)
            Else 'ถ้าไม่มี
                s = "<script language=""javascript"">alert('คุณยังไม่ได้เลือก COLL ID กรุณาเลือก COLL ID ก่อนกดบันทึก');</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
            End If
        Else
            s = "<script language=""javascript"">alert('คุณยังไม่ได้เลือกผู้ประเมิน');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
        End If


    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim GV As GridView = FindControl("GridView1")
        Dim gvr_master As GridViewRow
        For Each gvr_master In GV.Rows

        Next
    End Sub
End Class
