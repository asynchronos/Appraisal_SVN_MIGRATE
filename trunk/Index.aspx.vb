﻿Imports Appraisal_Manager
Partial Class Index
    Inherits System.Web.UI.Page
    Dim s As String
    Protected Sub ImageBtLogin_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageBtLogin.Click
        Dim Obj_systemUser As List(Of SystemUser) = GET_SYSTEM_USER(Txtusername.Text, txtPassword.Text)
        Session.Clear()
        If Obj_systemUser.Count > 0 Then
            Session("sUserId") = Trim(Txtusername.Text)
            Session("sPwd") = Trim(txtPassword.Text)
            Session("sEmpId") = Obj_systemUser.Item(0).Emp_Id
            Session("sHub_Id") = Obj_systemUser.Item(0).Hub_Id
            Session("sGroup_Id") = Obj_systemUser.Item(0).SGroup_Id
            Response.Redirect("Default.aspx")
        Else
            s = "<script language=""javascript"">alert('User ID หรือ Password  ไม่ถูกต้อง');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", s)
        End If

    End Sub
End Class
