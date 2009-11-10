Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports EeekSoft.Web
Partial Class Test_TestMasterPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '//Create popup window and popup win anchor control
        Dim popupWin As PopupWin = New PopupWin()
        Dim popupAnchor As PopupWinAnchor = New PopupWinAnchor()
        Dim Str As String = "</br> งาน รอ Assign  : "

        '// Add controls to page
        PlaceHolder.Controls.Add(popupAnchor)
        PlaceHolder.Controls.Add(popupWin)

        '// Set anchor properties
        popupAnchor.PopupToShow = popupWin.ClientID
        popupAnchor.LinkedControl = "reopen"
        popupAnchor.HandledEvent = "onmouseover"


        '// Set popup win properties
        popupWin.ActionType = EeekSoft.Web.PopupAction.MessageWindow
        popupWin.Title = "แสดงงานคงค้าง"
        popupWin.Message = "</br> งาน รอ Assign  : " & 1 & " รายการ </br> งานกำหนดราคาที่ 1 :" & 5 & " รายการ </br>" & "งานกำหนดราคาที่ 2 : " & 3 & " รายการ "  '"<i>Message</i> displayed in popup"
        popupWin.Text = "</br> งาน รอ Assign  : " & 1 & " รายการ </br> งานกำหนดราคาที่ 1 :" & 5 & " รายการ </br>" & "งานกำหนดราคาที่ 2 : " & 3 & " รายการ "
        popupWin.HideAfter = 6000

        '// Show popup
        popupWin.Visible = True
        popupWin.AutoShow = False
    End Sub
End Class
