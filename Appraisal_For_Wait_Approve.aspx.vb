Imports Appraisal_Manager
Imports System.Data

Partial Class Appraisal_For_Wait_Approve
    Inherits System.Web.UI.Page
    Dim StrNotice As String
    Dim StrPath As String
    Dim s1 As String = Nothing
    Dim s As String = ""

    Protected Sub imgAttach_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim ImgAttach As ImageButton = DirectCast(sender, ImageButton)
        'Dim Method_Type As Label = ImgAttach.Parent.FindControl("lblReq_Type")
        'MsgBox(Method_Type.Text)
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        Dim Req_Id As Label = ImgAttach.Parent.FindControl("lblReq_Id")
        Dim Hub_Id As Label = ImgAttach.Parent.FindControl("lblHub_Id")
        Dim AID As Label = ImgAttach.Parent.FindControl("lblAID")
        Dim Temp_AID As Label = ImgAttach.Parent.FindControl("lblTemp_AID")
        'Dim CID As Label = ImgAttach.Parent.FindControl("lblCID")


        StrPath = Request.ApplicationPath & "/FileUpload_Price3.aspx?Req_Id=" & Req_Id.Text & "&Hub_Id=" & Hub_Id.Text & "&AID=" & AID.Text & "&Temp_AID=" & Temp_AID.Text & "&UserId=" & lbluserid.Text
        s1 = "<script language=""javascript"">window.open('" + StrPath + "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, directories=no, status=yes,height=700px,width=830px');</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType, "แนบไฟล์", s1)
    End Sub

    Protected Sub imgEditData_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim imgEditData As ImageButton = DirectCast(sender, ImageButton)
        Dim Method_Type As Label = imgEditData.Parent.FindControl("lblReq_Type")

        Dim Req_Id As Label = imgEditData.Parent.FindControl("lblReq_Id")
        Dim Hub_Id As Label = imgEditData.Parent.FindControl("lblHub_Id")
        Dim AID As Label = imgEditData.Parent.FindControl("lblAID")
        Dim Cif As Label = imgEditData.Parent.FindControl("lblCif")
        Dim Temp_AID As Label = imgEditData.Parent.FindControl("lblTemp_AID")
        Dim Appraisal_Id As Label = imgEditData.Parent.FindControl("lblAppraisal_Id")

        Context.Items("Req_Id") = Req_Id.Text
        Context.Items("Hub_Id") = Hub_Id.Text
        Context.Items("AID") = AID.Text
        Context.Items("Cif") = Cif.Text
        Context.Items("Temp_AID") = Temp_AID.Text
        Context.Items("Appraisal_Id") = Appraisal_Id.Text

        'If Method_Type.Text = "1" Then
        '    Server.Transfer("Appraisal_Price3_ConForm_New.aspx")
        'Else
        '    Server.Transfer("Appraisal_Price3_Form_Review.aspx")
        'End If

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
            If Method_Type.Text = "1" Then
                Server.Transfer("Appraisal_Price3_Conform_New.aspx")
            ElseIf Method_Type.Text = "2" Then
                Server.Transfer("Appraisal_Price3_Form_Review.aspx")
            End If
        ElseIf ChkColl = 50 Then
            If Method_Type.Text = "1" Then
                Server.Transfer("Appraisal_Price3_Conform_New.aspx")
            ElseIf Method_Type.Text = "2" Then
                Server.Transfer("Appraisal_Price3_Form_Review.aspx")
            End If
        ElseIf ChkColl = 70 Then
            If Method_Type.Text = "1" Then
                Server.Transfer("Appraisal_Price3_Conform_New.aspx")
            ElseIf Method_Type.Text = "2" Then
                Server.Transfer("Appraisal_Price3_Form_Review.aspx")
            End If
        Else
        End If
    End Sub

    Protected Sub imgEditPosition_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        Dim imgEditPosition As ImageButton = DirectCast(sender, ImageButton)
        Dim Req_Id As Label = imgEditPosition.Parent.FindControl("lblReq_Id")
        Dim Hub_Id As Label = imgEditPosition.Parent.FindControl("lblHub_Id")
        Dim Temp_AID As Label = imgEditPosition.Parent.FindControl("lblTemp_AID")

        StrPath = Request.ApplicationPath & "/CollDetail_Edit_Position_Price3.aspx?Req_Id=" & Req_Id.Text & "&Temp_AID=" & Temp_AID.Text & "&UserId=" & lbluserid.Text
        s1 = "<script language=""javascript"">window.open('" + StrPath + "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, directories=no, status=yes,height=700px,width=830px');</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType, "แก้ไขพิกัด", s1)


        'Dim CollType As String = "050"

        's1 += "window.open('CollDetail_Edit_Position_Price3.aspx"
        's1 += "?Req_Id=" & Req_Id.Text
        's1 += "&Temp_AID=" & Temp_AID.Text
        's1 += "&UserId=" & lbluserid.Text
        'imgEditPosition.Attributes.Add("onclick", s1 & "','pop', 'width=820, height=680');")

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

        If Approved1.Text = String.Empty Or Approved2.Text = String.Empty Or Approved3.Text = String.Empty Then
            StrNotice = "<Script language=""javascript"">alert('อนุกรรมการในการอนุมัติมีไม่ครบ 3 คน');</Script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", StrNotice)
            'Exit Sub
        End If

        If Lng.Text = "0" Or Lat.Text = "0" Then
            StrNotice = "<Script language=""javascript"">alert('คุณไม่ได้กำหนดพิกัด Lat Lng');</Script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", StrNotice)
            'Exit Sub
        End If

        If AID.Text = "0" Then
            StrNotice = "<Script language=""javascript"">alert('คุณยังไม่เลข AID ใส่ข้อมูล AID ก่อนจะทำการอนุมัติ');</Script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", StrNotice)
        Else
            'ตรวจสอบว่าอนุกรรมการที่กำหนดไว้ ได้อนุมัติแล้วหรือไม่
            Dim ObjW4A As Integer = GET_WAIT_FOR_APPROVE_BY_REQ_ID(Req_Id.Text, Hub_Id.Text, Approved1_Id.Value, Approved2_Id.Value, Approved3_Id.Value)
            'Dim ObjW4A As List(Of Wait_For_Approve) = GET_WAIT_FOR_APPROVE_BY_REQ_ID(Req_Id.Text, Hub_Id.Text, Approved3_Id.Value)
            If ObjW4A = 3 Then
                Try
                    UPDATE_PRICE3_MASTER_APPROVE(Req_Id.Text, AID.Text, Temp_AID.Text, Cif.Text)
                    UPDATE_Status_Appraisal_Request(Req_Id.Text, Hub_Id.Text, 12)
                    GridView1.DataBind()
                    StrNotice = "<Script language=""javascript"">alert('การอนุมัติเสร็จสมบูรณ์');</Script>"
                    Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", StrNotice)
                Catch ex As Exception
                    StrNotice = "<Script language=""javascript"">alert('ไม่สามารถ Approved ได้ ข้อมูลผิดพลาด');</Script>"
                    Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", StrNotice)
                End Try
            Else
                StrNotice = "<Script language=""javascript"">alert('อนุกรรมการยังอนุมัติไม่ครบ 3 คน');</Script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", StrNotice)
            End If



        End If


    End Sub

End Class
