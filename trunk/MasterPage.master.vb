Imports SME_SERVICE

Partial Class MasterPage_MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load
        'If Not Page.IsPostBack Then
        'MsgBox(Session("sEmpId"))
        If Session("sEmpId") <> Nothing Then
            Dim Emp_class As Employee_Info
            Dim SV As New SME_SERVICE.Service

            Emp_class = SV.GetEmployee_Info(Session("sEmpId"))(0)
            'ถ้า emp_id ที่ส่งมาไม่เท่ากับ 0 ให้ใส่ข้อมูลลูกค้าใส่ในคอนโทรลที่กำหนดให้
            If Emp_class.EmpId.ToString <> 0 Then
                lblUserID.Text = Session("sEmpId")
                lblUserName.Text = Emp_class.EmpName
                lblPostion.Text = Emp_class.EmpDept
                lblHub_Id.Text = Session("sHub_Id")

            Else
                'ถ้า emp_id ที่ส่งมาเท่ากับ 0 ให้ Clear ค่า  ในคอนโทรล
                Dim l As New Label
                l.Text = SV.MSb("ระบบค้นหาข้อมูลผู้ใช้งานไม่พบ")
                Page.Controls.Add(l)

                lblUserName.Text = ""
                lblUserName.Text = ""
                lblPostion.Text = ""
            End If
        End If
        'End If
    End Sub
End Class

