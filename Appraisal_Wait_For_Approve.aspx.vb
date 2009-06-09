Imports Appraisal_Manager
Imports System.Data
Imports System.Data.SqlClient

Partial Class Appraisal_Wait_For_Approve
    Inherits System.Web.UI.Page
    Dim s As String

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        HdfApprove_Id.Value = lbluserid.Text
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Sub imgPrintPreview_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim ImgBtAdd As ImageButton = DirectCast(sender, ImageButton)
        Dim Req_Id As Label = ImgBtAdd.Parent.FindControl("lblReq_Id")
        Dim Hub_Id As Label = ImgBtAdd.Parent.FindControl("lblHub_Id")
        Dim Temp_AID As Label = ImgBtAdd.Parent.FindControl("lblTemp_AID")
        Dim MethodNo As Label = ImgBtAdd.Parent.FindControl("lblMethodNo")
        Dim Appraisal_Id As Label = ImgBtAdd.Parent.FindControl("lblAppraisal_Id")
        Dim Cif As Label = ImgBtAdd.Parent.FindControl("lblCif")


        Context.Items("Req_Id") = Req_Id.Text
        Context.Items("Hub_Id") = Hub_Id.Text
        Context.Items("Temp_AID") = Temp_AID.Text
        Context.Items("Cif") = Cif.Text
        Context.Items("Appraisal_Id") = Appraisal_Id.Text

        Dim ChkColl As Integer = 0

        Dim Obj_GetP18 As List(Of Price3_18) = GET_PRICE3_18(Req_Id.Text, Hub_Id.Text, Temp_AID.Text)
        If Obj_GetP18.Count > 0 Then
            ChkColl = 18
        Else
            Dim Obj_GetP50 As List(Of Price3_50) = GET_PRICE3_CONFORM(Req_Id.Text, Hub_Id.Text, Temp_AID.Text)
            If Obj_GetP50.Count > 0 Then
                ChkColl = 50
            Else
                ChkColl = 0
                s = "<script language=""javascript"">alert('คุณยังไม่ได้กำหนดรายละเอียดในที่ดิน');</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
            End If
            'มีทรัพย์หลักประกันเป็นที่ดิน หาว่ามีสิ่งปลูกสร้างหรือไม่
            If ChkColl = 50 Then
                Dim Obj_GetP70G As DataSet = GET_PRICE3_70_GROUP(Req_Id.Text, Hub_Id.Text, Temp_AID.Text)
                If Obj_GetP70G.Tables(0).Rows.Count > 0 Then
                    ChkColl = 70
                End If
            Else
            End If

        End If

        Context.Items("ChkColl") = ChkColl
        If ChkColl = 0 Then
            s = "<script language=""javascript"">alert('คุณไม่มีชิ้นทรัพย์ในการประเมิน');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "ข้อความเตือน", s)
        ElseIf ChkColl = 18 Then
            If MethodNo.Text = "1" Then
                Server.Transfer("Appraisal_Price3_Conform_New.aspx")
            ElseIf MethodNo.Text = "2" Then
                Server.Transfer("Appraisal_Price3_Form_Review.aspx")
            End If
        ElseIf ChkColl = 50 Then
            If MethodNo.Text = "1" Then
                Server.Transfer("Appraisal_Price3_Conform_New.aspx")
            ElseIf MethodNo.Text = "2" Then
                Server.Transfer("Appraisal_Price3_Form_Review.aspx")
            End If
        ElseIf ChkColl = 70 Then
            If MethodNo.Text = "1" Then
                Server.Transfer("Appraisal_Price3_Conform_New.aspx")
            ElseIf MethodNo.Text = "2" Then
                Server.Transfer("Appraisal_Price3_Form_Review.aspx")
            End If
        Else
        End If
    End Sub

    Protected Sub imgConfirm_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)

    End Sub
End Class
