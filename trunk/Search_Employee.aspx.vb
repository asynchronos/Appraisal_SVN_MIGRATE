
Partial Class project_Search_Employee
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindDropDown()
            Showdata()
        End If
    End Sub
    Sub BindDropDown()

        DropDownList1.Items.Insert(0, New ListItem("รหัสพนักงาน", "EMP_ID"))
        DropDownList1.Items.Insert(1, New ListItem("คำนำหน้าชื่อ", "TITLE_NAME"))
        DropDownList1.Items.Insert(2, New ListItem("ชื่อ", "EMPNAME"))
        DropDownList1.Items.Insert(3, New ListItem("นามสกุล", "EMPSURNAME"))
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Showdata()
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Showdata()
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

        Dim EMP_ID As String = HttpUtility.HtmlDecode(GridView1.Rows(GridView1.SelectedIndex).Cells(1).Text).Trim
        Dim EMP_NAME As String = HttpUtility.HtmlDecode(GridView1.Rows(GridView1.SelectedIndex).Cells(2).Text & GridView1.Rows(GridView1.SelectedIndex).Cells(3).Text & " " & GridView1.Rows(GridView1.SelectedIndex).Cells(4).Text).Trim
        Dim S As String = "<script language='javascript'>"
        'S += "alert(window.opener.location);"
        S += "window.opener.document.getElementById('" & Request.QueryString("empid") & "').value  ='" & EMP_ID & "';"
        S += "window.opener.document.getElementById('" & Request.QueryString("empname") & "').value  ='" & EMP_NAME & "';"
        S += "window.close();</script>"
        'Page.ClientScript.RegisterStartupScript(Me.GetType, "test", S, True)

        Response.Write(S)

        's = "<script language=""javascript"">window.close();</script>"
    End Sub

    Private Sub Showdata()
        Try
            Dim sql As String = Nothing

            If TextBox1.Text = "" Then
                sql = "Select   * from EMPLOYEE01"
            Else
                SqlDataSource1.SelectParameters.Clear()
                sql = "Select  EMP_ID,TITLE_NAME,EMPNAME,EMPSURNAME FROM EMPLOYEE01 WHERE " & DropDownList1.Items(DropDownList1.SelectedIndex).Value & " Like @SearchValue"
                'sql = "Select  EMP_ID,TITLE_NAME,EMPNAME,EMPSURNAME FROM EMPLOYEE01 WHERE EMPNAME Like @SearchValue"
                SqlDataSource1.SelectParameters.Add("SearchValue", "%" & TextBox1.Text & "%")

            End If

            SqlDataSource1.ConnectionString = "Data Source=172.19.54.2;Initial Catalog=Bay01;User ID=sa;Password=sa0123"
            SqlDataSource1.SelectCommand = sql
        Catch ex As Exception

        End Try
    End Sub
End Class
