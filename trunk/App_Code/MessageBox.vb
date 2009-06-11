Imports Microsoft.VisualBasic
Imports System
Imports System.Web.UI.WebControls

Public Class MessageBox
    Public Shared Function MSB_Alert(ByVal strMsg As String) As String
        Dim lbl As New Label
        lbl.Text = "<script language='javascript'>" & Environment.NewLine _
        & "window.alert(" & "'" & strMsg & "'" & ")</script>"
        Return lbl.Text
    End Function

    Public Shared Function MSB_Confirm(ByVal strMsg As String) As String
        Dim lbl As New Label
        lbl.Text = "<script language='javascript'>" & Environment.NewLine _
        & "window.confirm(" & "'" & strMsg & "'" & ")</script>"
        Return lbl.Text
    End Function
End Class
