﻿
Partial Class Appraisal_Review_List_New
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Showdata()
        End If
    End Sub

    Protected Sub GridView_Review_List_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView_Review_List.PageIndexChanging
        Showdata()
    End Sub

    'Protected Sub GridView_Review_List_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView_Review_List.SelectedIndexChanged

    '    Dim EMP_ID As String = HttpUtility.HtmlDecode(GridView_Review_List.Rows(GridView_Review_List.SelectedIndex).Cells(1).Text).Trim
    '    Dim EMP_NAME As String = HttpUtility.HtmlDecode(GridView_Review_List.Rows(GridView_Review_List.SelectedIndex).Cells(2).Text & GridView_Review_List.Rows(GridView1.SelectedIndex).Cells(3).Text & " " & GridView1.Rows(GridView1.SelectedIndex).Cells(4).Text).Trim
    '    Dim S As String = "<script language='javascript'>"
    '    'S += "alert(window.opener.location);"
    '    S += "window.opener.document.getElementById('" & Request.QueryString("empid") & "').value  ='" & EMP_ID & "';"
    '    S += "window.opener.document.getElementById('" & Request.QueryString("empname") & "').value  ='" & EMP_NAME & "';"
    '    S += "window.close();</script>"
    '    'Page.ClientScript.RegisterStartupScript(Me.GetType, "test", S, True)

    '    Response.Write(S)

    '    's = "<script language=""javascript"">window.close();</script>"
    'End Sub

    Private Sub Showdata()
        Try
            Dim sql As String = Nothing

            'If TextBox1.Text = "" Then
            '    sql = "Select   * from EMPLOYEE01"
            'Else
            SqlDataSource1.SelectParameters.Clear()
            sql = "Select APPS_ID, CIF, Cifname, Class, COLLVAL, VALDATE, NoticeDate, ReviewDate FROM Appraisal_Review_List WHERE Review_Check =0"
            'SqlDataSource1.SelectParameters.Add("SearchValue", "%" & TextBox1.Text & "%")

            'End If

            SqlDataSource1.ConnectionString = "Data Source=172.19.54.2;Initial Catalog=Appraisal;User ID=sa;Password=sa0123"
            SqlDataSource1.SelectCommand = sql
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cb1_Checked(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb1 As CheckBox = sender
        For Each gdi As GridViewRow In GridView_Review_List.Rows
            If gdi.RowType = DataControlRowType.DataRow Then
                Dim cb2 As CheckBox = gdi.Cells(0).FindControl("cb2")
                cb2.Checked = cb1.Checked
            End If
        Next
    End Sub

    Protected Sub imgCid_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim ImgCid As ImageButton = DirectCast(sender, ImageButton)
        Dim Apps_Id As Label = ImgCid.Parent.FindControl("lblAPPS_ID")
        'Dim Hub_Id As Label = ImgCid.Parent.FindControl("lblHub_id")
        'Dim Status_Id As HiddenField = ImgCid.Parent.FindControl("hdfStatus_Id")
        'MsgBox(Req_Id.Text)
        Dim myScript As String
        myScript = "<script>" + "window.open('Appraisal_Review_List_Cid.aspx?Apps_Id=" + Trim(Apps_Id.Text) + "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, directories=no, status=yes,height=580px,width=880px');</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType, "ชิ้นทรัพย์หลักประกัน", myScript)
    End Sub
End Class
