Imports SME_SERVICE
Imports System.Data
Imports System.Data.SqlClient
Imports Appraisal_Manager

Partial Class Appraisal_Register
    Inherits System.Web.UI.Page
    Dim s As String

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Dim Emp_class As Employee_Info
        Dim SV As New SME_SERVICE.Service
        Try
            'MsgBox(Session("sEmpId"))
            Emp_class = SV.GetEmployee_Info(txtEmp_Id.Text)(0)
            'ถ้า emp_id ที่ส่งมาไม่เท่ากับ 0 ให้ใส่ข้อมูลลูกค้าใส่ในคอนโทรลที่กำหนดให้
            If Emp_class.EmpId.ToString <> 0 Then
                lblEmpName.Text = Emp_class.EmpName
            Else
                'ถ้า emp_id ที่ส่งมาเท่ากับ 0 ให้ Clear ค่า  ในคอนโทรล
                lblEmpName.Text = ""
                s = "<script language=""javascript"">alert('User ID หรือ Password  ไม่ถูกต้อง');</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", s)
            End If
            s = "<script language=""javascript"">alert('User ID หรือ Password  ไม่ถูกต้อง');</script>"
        Catch ex1 As SqlException
            's = (ex1.ErrorCode)
            's = "<script language=""javascript"">alert('User ID หรือ Password  ไม่ถูกต้อง');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", s)
        Catch ex2 As DatabaseNotEnabledForNotificationException
            's = (ex2.InnerException3)
            Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", s)
        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", s)
        End Try
    End Sub
End Class
