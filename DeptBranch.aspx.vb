
Partial Class DeptBranch
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindDropDown()
            Showdata()
        End If
    End Sub

    Sub BindDropDown()
        DropDownList1.Items.Insert(0, New ListItem("รหัสสาขา", "Id_DepTran"))
        DropDownList1.Items.Insert(1, New ListItem("ชื่อสาขา", "DepTranT"))
    End Sub

    Private Sub Showdata()
        Try
            Dim sql As String = Nothing

            If TextBox1.Text = "" Then
                sql = "Select Flag, Id_DepTran, DepTranT FROM VIEW_DEPTBRANCH"
            Else
                SqlDataSource1.SelectParameters.Clear()
                If DropDownList1.SelectedIndex = 0 Then
                    sql = "Select  Flag, Id_DepTran, DepTranT FROM VIEW_DEPTBRANCH WHERE " & DropDownList1.Items(DropDownList1.SelectedIndex).Value & " Like @SearchValue"
                    SqlDataSource1.SelectParameters.Add("SearchValue", TextBox1.Text & "%")
                Else
                    sql = "Select  Flag, Id_DepTran, DepTranT FROM VIEW_DEPTBRANCH WHERE " & DropDownList1.Items(DropDownList1.SelectedIndex).Value & " Like @SearchValue"
                    SqlDataSource1.SelectParameters.Add("SearchValue", "%" & TextBox1.Text & "%")
                End If


            End If

            SqlDataSource1.ConnectionString = "Data Source=172.19.54.2;Initial Catalog=Bay01;User ID=Appraisal;Password=sa0123"
            SqlDataSource1.SelectCommand = sql
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Showdata()
    End Sub
End Class
