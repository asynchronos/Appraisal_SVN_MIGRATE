Imports System.Data
Imports System.Data.SqlClient

Partial Class Employees
    Inherits System.Web.UI.Page

    Private conn As String = ConfigurationManager.ConnectionStrings.Item("BAYConn").ToString

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
