Imports System.Web
Imports System.Web.Services
Imports System.Data
Imports Appraisal_Manager

Partial Class Appraisal_Assign_Job2Emp
    Inherits System.Web.UI.Page

    Protected Sub cb1_Checked(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb1 As CheckBox = sender
        Dim cnt As Integer = 0
        For Each gdi As GridViewRow In GridView1.Rows
            cnt = cnt + 1
            If gdi.RowType = DataControlRowType.DataRow Then
                Dim cb2 As CheckBox = gdi.Cells(0).FindControl("cb2")
                cb2.Checked = cb1.Checked
                Dim HubId As Label = gdi.Cells(2).FindControl("lblHub_Id")
                HdfHub_Id.Value = HubId.Text
            End If
        Next
    End Sub

    Protected Sub cb2_Checked(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb2 As CheckBox = sender
        If cb2.Checked Then
            For Each gdi As GridViewRow In GridView1.Rows
                Dim HubId As Label = gdi.Cells(2).FindControl("lblHub_Id")
                HdfHub_Id.Value = HubId.Text
            Next

        End If
    End Sub
    'Dim hubId As Label = gdi.Cells(2).FindControl("lblHub_Id")
    '            HdfHub_Id.Value = hubId.Text

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindDropDown()
        End If
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim USER_LOGIN As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        HdfUSER_LOGIN.Value = USER_LOGIN.Text
    End Sub
    Sub BindDropDown()
        DropDownListOptionSearch.Items.Insert(0, New ListItem("รหัสเลขคำขอประเมิน", "Req_ID"))
        DropDownListOptionSearch.Items.Insert(1, New ListItem("CIF", "CIF"))
        DropDownListOptionSearch.Items.Insert(2, New ListItem("รหัสศูนย์/รหัส HUB", "Hub_ID"))
    End Sub

    Protected Sub ButtonSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSearch.Click
        SetFilter()
    End Sub

    Protected Sub SetFilter()
        Dim filterExpression As String = String.Empty
        If TextBoxSearchValue.Text <> String.Empty Then
            If DropDownListOptionSearch.Items(DropDownListOptionSearch.SelectedIndex).Value = "Req_ID" Then
                filterExpression = "REQ_ID = " & TextBoxSearchValue.Text
            ElseIf DropDownListOptionSearch.Items(DropDownListOptionSearch.SelectedIndex).Value = "CIF" Then
                filterExpression = "CIF LIKE '" & TextBoxSearchValue.Text & "*'"
            ElseIf DropDownListOptionSearch.Items(DropDownListOptionSearch.SelectedIndex).Value = "Hub_ID" Then
                filterExpression = "Hub_ID = " & TextBoxSearchValue.Text
            End If
        Else
            filterExpression = "Hub_ID <> 0"
        End If
        SqlDataSource1.FilterExpression = filterExpression
        'Response.Write("Filter expression in effect is: " & filterExpression)
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        SetFilter()
    End Sub

    <System.Web.Script.Services.ScriptMethod()> _
<System.Web.Services.WebMethod()> _
Public Shared Function ValidateSaveData(ByVal ReqId As String, ByVal HubId As String, ByVal Cif As String, ByVal Land As String, ByVal Building As String, ByVal Condo As String, ByVal Appraisal_Type As String, ByVal Comment As String, ByVal Warning As String, ByVal CreateUser As String) As Boolean
        ' simulate a longer operation ... 
        System.Threading.Thread.Sleep(1000)

        Dim isValid As Boolean = False
        Try

            isValid = True
        Catch
            isValid = False
        End Try
        Return isValid
    End Function

    <System.Web.Script.Services.ScriptMethod()> _
<System.Web.Services.WebMethod()> _
Public Shared Function SaveAssignJob(ByVal ReqId As String, ByVal HubId As String, ByVal AppraisalId As String, ByVal UserAssign As String) As Boolean
        Dim isValid As Boolean = False
        Try
            UPDATE_APPRAISAL_ID(ReqId, HubId, 3, AppraisalId, UserAssign)
            isValid = True
        Catch ex As Exception
            isValid = False
        End Try
        Return isValid
    End Function
End Class
