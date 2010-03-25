
Partial Class Employees
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindDropDown()
            Showdata()
        End If
    End Sub

    Sub BindDropDown()
        DropDownList1.Items.Insert(0, New ListItem("ชื่อ", "EMPNAME"))
        DropDownList1.Items.Insert(1, New ListItem("นามสกุล", "EMPSURNAME"))
        DropDownList1.Items.Insert(2, New ListItem("รหัสพนักงาน", "EMP_ID"))
    End Sub

    Private Sub Showdata()
        Try
            Dim sql As String = Nothing

            If TextBox1.Text = "" Then
                sql = "Select   * from EMPLOYEE01"
            Else
                SqlDataSource1.SelectParameters.Clear()
                sql = "Select  EMP_ID,TITLE_NAME,EMPNAME,EMPSURNAME FROM EMPLOYEE01 WHERE " & DropDownList1.Items(DropDownList1.SelectedIndex).Value & " Like @SearchValue"
                SqlDataSource1.SelectParameters.Add("SearchValue", "%" & TextBox1.Text & "%")

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
