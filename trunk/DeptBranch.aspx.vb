
Partial Class DeptBranch
    Inherits System.Web.UI.Page

    Private conn As String = ConfigurationManager.ConnectionStrings.Item("AppraisalConn").ToString

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

            SqlDataSource1.ConnectionString = conn
            SqlDataSource1.SelectCommand = sql
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Showdata()
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Showdata()
    End Sub
End Class
