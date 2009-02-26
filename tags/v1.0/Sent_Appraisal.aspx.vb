Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI
Imports SME_SERVICE
Partial Class Sent_Appraisal
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

    Protected Sub form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load
        'txtCif.Text = "736513"
        lblDate.Text = Date.Now()
        If Not Page.IsPostBack Then
            If txtCif.Text = String.Empty Then

            Else
                btnSeachCif_Click(sender, Nothing)
            End If
        End If
    End Sub

    Protected Sub btnSeachCif_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSeachCif.Click
        Dim cus_class As Customer_Class
        Dim SV As New SME_SERVICE.Service
        'Dim cif As Integer

        cus_class = SV.GetCifInfo(txtCif.Text)(0)
        'ถ้า cif ที่ส่งมาไม่เท่ากับ 0 ให้ใส่ข้อมูลลูกค้าใส่ในคอนโทรลที่กำหนดให้
        If cus_class.Cif.ToString <> 0 Then
            lblCifName.Text = cus_class.cifName
            lblDepartName.Text = cus_class.departName
            SqlDS_Appraisal.DataBind()
        Else
            'ถ้า cif ที่ส่งมาเท่ากับ 0 ให้ Clear ค่า  ในคอนโทรล
            Dim l As New Label
            'MessageBox("Format Exception: " & ex.Message)
            l.Text = SV.MSb("ค้นหาข้อมูลลูกค้าไม่พบ ")
            Page.Controls.Add(l)

            lblCifName.Text = ""
            lblDepartName.Text = ""
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim dg As GridView = FindControl("GridView1")
        Dim gvr_master As GridViewRow

        If txtSent_Appraisal_ID.Text <> String.Empty Then
            For Each gvr_master In dg.Rows
                Dim chk1 As CheckBox = gvr_master.FindControl("cb2")
                Dim lblCollID As Label = gvr_master.FindControl("lblColl_ID")
                'MsgBox(chk1.Checked)
                If chk1.Checked = True Then
                    'เพิ่มข้อมูลการส่งประเมิน
                    Appraisal_Manager.Add_Sent_Appraisal(0, txtCif.Text, Date.Now, txtSent_Appraisal_ID.Text, lblCollID.Text, lblUserID.Text, RadioButtonList1.SelectedValue, "")
                End If
            Next
            'Update Queue
            Appraisal_Manager.Update_Queue()
        Else
        End If


    End Sub

    Protected Sub btnSeachAppraisal_ID_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSeachAppraisal_ID.Click
        Dim Emp_class As Employee_Info
        Dim SV As New SME_SERVICE.Service

        Emp_class = SV.GetEmployee_Info(txtSent_Appraisal_ID.Text)(0)
        'ถ้า emp_id ที่ส่งมาไม่เท่ากับ 0 ให้ใส่ข้อมูลลูกค้าใส่ในคอนโทรลที่กำหนดให้
        If Emp_class.EmpId.ToString <> 0 Then
            lblSentAppraisal_Name.Text = Emp_class.EmpName
        Else
            'ถ้า emp_id ที่ส่งมาเท่ากับ 0 ให้ Clear ค่า  ในคอนโทรล
            Dim l As New Label
            l.Text = SV.MSb("ค้นหาข้อมูลผู้ส่งประเมินลูกค้าไม่พบ ")
            Page.Controls.Add(l)

            lblSentAppraisal_Name.Text = ""

        End If
    End Sub

    Protected Sub Button_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        DirectCast(sender, Button).Visible = True
    End Sub
End Class
