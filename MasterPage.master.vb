Imports SME_SERVICE
Imports System.Data
Imports System.Data.SqlClient
Imports Appraisal_Manager
Partial Class MasterPage_MasterPage
    Inherits System.Web.UI.MasterPage
    Dim s As String

    Protected Sub form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load
        'If Not Page.IsPostBack Then
        'MsgBox(Session("sEmpId").ToString)
        If Not Session("sEmpId") Is Nothing Then
            Dim Emp_class As Employee_Info
            Dim SV As New SME_SERVICE.Service

            Try
                'MsgBox(Session("sEmpId"))
                Emp_class = SV.GetEmployee_Info(Session("sEmpId"))(0)

                'ถ้า emp_id ที่ส่งมาไม่เท่ากับ 0 ให้ใส่ข้อมูลลูกค้าใส่ในคอนโทรลที่กำหนดให้
                If Emp_class.EmpId.ToString <> String.Empty Then
                    lblUserID.Text = Session("sUserId")
                    lblUserName.Text = Emp_class.EmpName
                    'lblDepartment.Text = Emp_class.EmpDept
                    lblHub_Id.Text = Session("sHub_Id")
                    Dim ObjHub As List(Of Cls_Hub) = GET_Hub_Info(lblHub_Id.Text)
                    lblHubname.Text = ObjHub.Item(0).HUB_NAME
                Else
                    'ถ้า emp_id ที่ส่งมาเท่ากับ 0 ให้ Clear ค่า  ในคอนโทรล
                    Dim l As New Label
                    l.Text = SV.MSb("ระบบค้นหาข้อมูลผู้ใช้งานไม่พบ")
                    Page.Controls.Add(l)

                    lblUserName.Text = ""
                    lblUserName.Text = ""
                    'lblDepartment.Text = ""
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
        Else
            'Server.Transfer("Login.aspx")
            Server.Transfer(Page.ResolveUrl("Index.aspx"))
        End If
        'End If
    End Sub
End Class

