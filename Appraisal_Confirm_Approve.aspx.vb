Imports System
Imports System.Web
Imports System.Web.Services
Imports Appraisal_Manager
Imports System.Security.Cryptography
Imports Cryptography
Imports System.Data

Partial Class Appraisal_Confirm_Approve
    Inherits System.Web.UI.Page

    <System.Web.Script.Services.ScriptMethod()> _
<System.Web.Services.WebMethod()> _
Public Shared Function ConfirmPrice(ByVal ReqId As Integer, ByVal HubId As Integer, ByVal ApproveID As String, ByVal pwd As String) As Boolean
        ' simulate a longer operation ... 
        System.Threading.Thread.Sleep(1000)

        Dim isValid As Boolean = False

        Try
            Try
                Dim passwordHashSHA256 As String = String.Empty
                If ApproveID <> pwd Then   'ตรวจสอบว่า รหัสที่ยืนยันต้องไม่ใช่รหัสพนักงาน
                    passwordHashSHA256 = HashCupute2(pwd, "SHA256")
                    Dim UserAppraisal As DataSet = GET_APPRAISAL_APPROVAL(ApproveID)
                    If passwordHashSHA256.ToString = UserAppraisal.Tables(0).Rows(0).Item("pwd") Then
                        UPDATE_PRICE2_APPROVED(ReqId, HubId, ApproveID)
                        UPDATE_APPROVE_ID_WAIT_FOR_APPROVE(ReqId, HubId, ApproveID)
                        isValid = True
                    Else
                        isValid = False
                    End If
                Else
                    isValid = False
                End If

            Catch ex As Exception
                isValid = False
            End Try
        Catch
            isValid = False
        End Try
        Return isValid

    End Function
End Class
