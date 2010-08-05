Imports System
Imports System.Text
Imports System.Security.Cryptography
Imports System.Web
Imports System.Web.Services
Imports Cryptography
Imports System.Data
Imports Appraisal_Manager

Partial Class Appraisal_Create_Password_Approval
    Inherits System.Web.UI.Page

    <System.Web.Script.Services.ScriptMethod()> _
<System.Web.Services.WebMethod()> _
Public Shared Function ConfirmPrice(ByVal ReqId As Integer, ByVal HubId As Integer, ByVal AppraisalId As String) As Boolean
        ' simulate a longer operation ... 
        System.Threading.Thread.Sleep(1000)

        Dim isValid As Boolean = False

        Try
            Try
                'UPDATE_PRICE2_APPROVED(ReqId, HubId, AppraisalId)
                'UPDATE_APPROVE_ID_WAIT_FOR_APPROVE(ReqId, HubId, AppraisalId)
                'Dim passwordHashMD5 As String
                'passwordHashMD5 = ComputeHash(password, "MD5", Nothing)
                isValid = True
            Catch ex As Exception
                isValid = False
            End Try
        Catch
            isValid = False
        End Try
        Return isValid

    End Function

    <System.Web.Script.Services.ScriptMethod()> _
<System.Web.Services.WebMethod()> _
Public Shared Function CheckOldPassword(ByVal EmpId As String, ByVal OldPassword As String) As String
        ' simulate a longer operation ... 
        System.Threading.Thread.Sleep(1000)

        Dim isValid As String = String.Empty
        Dim DS As DataSet
        Try
            Try
                Dim passwordHashMD5 As String
                Dim passwordHashMD5FromDB As String
                passwordHashMD5 = ComputeHash(OldPassword, "MD5", Nothing)

                'ส่งรหัสพนักงานไป Check ว่าเคยตั้งรหัสผ่านหรือไม่
                DS = GET_APPRAISAL_APPROVAL(EmpId)
                If Len(DS.Tables(0).Rows(0).Item("Pwd")) = 0 Then
                    'ถ้าไม่เคยตั้งรหัส กำหนดให้ passwordHashMD5 เป็นค่าว่าง
                    passwordHashMD5FromDB = "1"
                Else
                    passwordHashMD5FromDB = DS.Tables(0).Rows(0).Item("Pwd")
                    'ถ้าเคยให้เข้ารหัส เพื่อนำไปตรวจสอบว่าเป็นรหัสเดียวกันหรือไม่
                    If passwordHashMD5 <> passwordHashMD5FromDB Then
                        passwordHashMD5FromDB = "2"
                    Else
                        passwordHashMD5FromDB = "3"
                    End If
                End If
                isValid = passwordHashMD5FromDB
            Catch ex As Exception
                'Error
                isValid = "0"
            End Try
        Catch
            'Error
            isValid = "0"
        End Try

        '  0 =  Error
        '  1 =  ยังไม่เคยตั้งรหัสผ่าน
        '  2 =  รหัสผ่านที่กรอก ไม่ตรงกับรหัสผ่านที่อยู่บนฐานข้อมูล
        '  3 =  รหัสผ่านที่กรอก ตรงกับรหัสผ่านที่อยู่บนฐานข้อมูล
        Return isValid

    End Function

    <System.Web.Script.Services.ScriptMethod()> _
<System.Web.Services.WebMethod()> _
Public Shared Function Test(ByVal EmpId As String, ByVal OldPassword As String) As String
        'Dim isValid As String = String.Empty
        'Dim passwordHashMD5 As String
        'passwordHashMD5 = ComputeHash(OldPassword, "MD5", Nothing)
        Dim hashAlgorithm As String = "MD5"
        Dim md5Hasher As New MD5CryptoServiceProvider
        'Dim hashedByted As Byte()
        Dim encoder As New UTF8Encoding
        'Dim hashValue As String
        'hashValue = Convert.ToBase64String(md5Hasher.ComputeHash(encoder.GetBytes(OldPassword)))

        Dim saltBytes As Byte()
        Dim saltSize As Integer
        saltSize = 8

        ' Allocate a byte array, which will hold the salt.
        saltBytes = New Byte(saltSize - 1) {}

        Dim hash As HashAlgorithm

        ' Make sure hashing algorithm name is specified.
        If (hashAlgorithm Is Nothing) Then
            hashAlgorithm = ""
        End If

        ' Initialize appropriate hashing algorithm class.
        Select Case HashAlgorithm.ToUpper()

            Case "SHA1"
                hash = New SHA1Managed()

            Case "SHA256"
                hash = New SHA256Managed()

            Case "SHA384"
                hash = New SHA384Managed()

            Case "SHA512"
                hash = New SHA512Managed()

            Case Else
                hash = New MD5CryptoServiceProvider()

        End Select

        ' Compute hash value of our plain text with appended salt.
        Dim hashBytes As Byte()
        hashBytes = hash.ComputeHash(encoder.GetBytes(OldPassword))

        ' Create array which will hold hash and original salt bytes.
        Dim hashWithSaltBytes() As Byte = _
                                   New Byte(hashBytes.Length + _
                                            saltBytes.Length - 1) {}

        ' Copy hash bytes into resulting array.
        For I = 0 To hashBytes.Length - 1
            hashWithSaltBytes(I) = hashBytes(I)
        Next I

        ' Append salt bytes to the result.
        For I = 0 To saltBytes.Length - 1
            hashWithSaltBytes(hashBytes.Length + I) = I
        Next I

        ' Convert result into a base64-encoded string.
        Dim hashValue As String
        hashValue = Convert.ToBase64String(hashWithSaltBytes)

        Return hashValue

    End Function

    <System.Web.Script.Services.ScriptMethod()> _
<System.Web.Services.WebMethod()> _
    Public Shared Function Test2(ByVal EmpId As String, ByVal OldPassword As String) As String
        'Public Shared Function Test2() As String
        Dim passwordHashMD5 As String = String.Empty
        'Dim UserAppraisal As DataSet = GET_APPRAISAL_APPROVAL_LIST()
        'Dim EmpId As String = String.Empty
        'Dim OldPassword As String = String.Empty
        'Dim i As Integer
        'For i = 0 To UserAppraisal.Tables(0).Rows.Count - 1
        '    EmpId = UserAppraisal.Tables(0).Rows(i).Item("Appraisal_Id")
        '    OldPassword = UserAppraisal.Tables(0).Rows(i).Item("Appraisal_Id")
        'passwordHashMD5 = HashCupute2(OldPassword, "SHA256")
        '    'MsgBox(passwordHashMD5)
        '    UPDATE_APPRAISAL_APPROVAL_LIST(EmpId, passwordHashMD5)
        'Next
        'MsgBox("Success")

        passwordHashMD5 = HashCupute2(OldPassword, "SHA256")
        Return passwordHashMD5
    End Function

    <System.Web.Script.Services.ScriptMethod()> _
<System.Web.Services.WebMethod()> _
Public Shared Function EncriptAllPassword() As String
        Dim md5Hasher As New MD5CryptoServiceProvider
        Dim encoder As New UTF8Encoding()

        Dim passwordHashMD5 As String
        'Dim hashedBytes As Byte()
        Dim UserAppraisal As DataSet = GET_APPRAISAL_APPROVAL_LIST()
        Dim EmpId As String = String.Empty
        Dim OldPassword As String = String.Empty
        Dim i As Integer
        For i = 0 To UserAppraisal.Tables(0).Rows.Count - 1
            EmpId = UserAppraisal.Tables(0).Rows(i).Item("Appraisal_Id")
            OldPassword = UserAppraisal.Tables(0).Rows(i).Item("Appraisal_Id")
            'hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(OldPassword))
            passwordHashMD5 = HashCupute2(OldPassword, "SHA256")
            'MsgBox(passwordHashMD5)
            UPDATE_APPRAISAL_APPROVAL_LIST(EmpId, passwordHashMD5)
        Next
        MsgBox("Success")
        Return OldPassword
    End Function

    <System.Web.Script.Services.ScriptMethod()> _
<System.Web.Services.WebMethod()> _
Public Shared Function stepChangPassword(ByVal EmpId As String, ByVal OldPassword As String, ByVal newPassword As String, ByVal confirmPassword As String) As String
        Dim md5Hasher As New MD5CryptoServiceProvider
        Dim encoder As New UTF8Encoding()
        Dim result As String = String.Empty
        Dim passwordHashSHA256 As String = String.Empty
        Dim newPasswordHash As String = String.Empty
        'Dim checkOldPass As DataSet
        Dim UserAppraisal As DataSet = GET_APPRAISAL_APPROVAL(EmpId)
        'Dim i As Integer
        'For i = 0 To UserAppraisal.Tables(0).Rows.Count - 1
        'EmpId = UserAppraisal.Tables(0).Rows(i).Item("Appraisal_Id")
        'OldPassword = UserAppraisal.Tables(0).Rows(i).Item("Appraisal_Id")
        passwordHashSHA256 = HashCupute2(OldPassword, "SHA256")
        'UPDATE_APPRAISAL_APPROVAL_LIST(EmpId, passwordHashMD5)
        'Next


        Try
            'checkOldPass = GET_APPRAISAL_APPROVAL(EmpId)
            If passwordHashSHA256.ToString = UserAppraisal.Tables(0).Rows(0).Item("pwd") Then
                'ถ้ารหัสผ่านเดิม ตรงกับ รหัสผ่านที่ต้องการเปลี่ยนที่กรอกในช่อง Old Password
                If newPassword <> EmpId Then
                    'ถ้ารหัสผ่านใหม่ไม่ใช่รหัสพนักงาน
                    If newPassword = confirmPassword Then
                        newPasswordHash = HashCupute2(newPassword, "SHA256")
                        Try
                            UPDATE_APPRAISAL_APPROVAL_LIST(EmpId, newPasswordHash)
                            result = "0"
                        Catch ex As Exception
                            result = "4"
                        End Try

                    Else
                        'รหัสผ่านใหม่ กับรหัส Confirm Password ไม่ตรงกัน
                        result = "3"
                    End If
                Else
                    'ถ้ารหัสผ่านใหม่ตรงกับรหัสพนักงาน ระบบจะไม่ยอม
                    result = "2"
                End If
            Else
                'ถ้ารหัสผ่านเดิม ไม่ตรงกับ รหัสผ่านที่ต้องการเปลี่ยนที่กรอกในช่อง Old Password
                result = "1"
            End If
        Catch ex As Exception

        End Try


        Return result
    End Function

    Sub Encryption()
        'Dim password As String    ' original password
        'Dim wrongPassword As String    ' wrong password

        'password = "myP@5sw0rd"
        'wrongPassword = "password"

        'Dim passwordHashMD5 As String
        'Dim passwordHashSha1 As String
        'Dim passwordHashSha256 As String
        'Dim passwordHashSha384 As String
        'Dim passwordHashSha512 As String

        'passwordHashMD5 = _
        '       SimpleHash.ComputeHash(password, "MD5", Nothing)
        'passwordHashSha1 = _
        '       SimpleHash.ComputeHash(password, "SHA1", Nothing)
        'passwordHashSha256 = _
        '       SimpleHash.ComputeHash(password, "SHA256", Nothing)
        'passwordHashSha384 = _
        '       SimpleHash.ComputeHash(password, "SHA384", Nothing)
        'passwordHashSha512 = _
        '       SimpleHash.ComputeHash(password, "SHA512", Nothing)

        'Console.WriteLine("COMPUTING HASH VALUES")
        'Console.WriteLine("")
        'Console.WriteLine("MD5   : {0}", passwordHashMD5)
        'Console.WriteLine("SHA1  : {0}", passwordHashSha1)
        'Console.WriteLine("SHA256: {0}", passwordHashSha256)
        'Console.WriteLine("SHA384: {0}", passwordHashSha384)
        'Console.WriteLine("SHA512: {0}", passwordHashSha512)
        'Console.WriteLine("")

        'Console.WriteLine("COMPARING PASSWORD HASHES")
        'Console.WriteLine("")
        'Console.WriteLine("MD5    (good): {0}", _
        '                    SimpleHash.VerifyHash( _
        '                    password, "MD5", _
        '                    passwordHashMD5).ToString())
        'Console.WriteLine("MD5    (bad) : {0}", _
        '                    SimpleHash.VerifyHash( _
        '                    wrongPassword, "MD5", _
        '                    passwordHashMD5).ToString())
        'Console.WriteLine("SHA1   (good): {0}", _
        '                    SimpleHash.VerifyHash( _
        '                    password, "SHA1", _
        '                    passwordHashSha1).ToString())
        'Console.WriteLine("SHA1   (bad) : {0}", _
        '                    SimpleHash.VerifyHash( _
        '                    wrongPassword, "SHA1", _
        '                    passwordHashSha1).ToString())
        'Console.WriteLine("SHA256 (good): {0}", _
        '                    SimpleHash.VerifyHash( _
        '                    password, "SHA256", _
        '                    passwordHashSha256).ToString())
        'Console.WriteLine("SHA256 (bad) : {0}", _
        '                    SimpleHash.VerifyHash( _
        '                    wrongPassword, "SHA256", _
        '                    passwordHashSha256).ToString())
        'Console.WriteLine("SHA384 (good): {0}", _
        '                    SimpleHash.VerifyHash( _
        '                    password, "SHA384", _
        '                    passwordHashSha384).ToString())
        'Console.WriteLine("SHA384 (bad) : {0}", _
        '                    SimpleHash.VerifyHash( _
        '                    wrongPassword, "SHA384", _
        '                    passwordHashSha384).ToString())
        'Console.WriteLine("SHA512 (good): {0}", _
        '                    SimpleHash.VerifyHash( _
        '                    password, "SHA512", _
        '                    passwordHashSha512).ToString())
        'Console.WriteLine("SHA512 (bad) : {0}", _
        '                    SimpleHash.VerifyHash( _
        '                    wrongPassword, "SHA512", _
        '                    passwordHashSha512).ToString())
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("sGroup_Id") = "1" Then
                TextBoxId.Text = ""
                'Dim ApproveName As DataSet = GET_APPRAISAL_APPROVAL(TextBoxId.Text)
                TextBoxName.Text = ""
            Else
                TextBoxId.Text = Request.QueryString("Approve_Id")
                Dim ApproveName As DataSet = GET_APPRAISAL_APPROVAL(TextBoxId.Text)
                TextBoxName.Text = ApproveName.Tables(0).Rows(0).Item("UserAppraisal")
            End If

        End If
    End Sub


    Protected Sub form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load
        ButtonResetPwd.Visible = False
        If Session("sGroup_Id") = "1" Then
            ButtonResetPwd.Visible = True
        End If
    End Sub

    Protected Sub ButtonResetPwd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonResetPwd.Click
        Dim passwordHashSHA256 As String = String.Empty
        Dim UserAppraisal As DataSet = GET_APPRAISAL_APPROVAL(TextBoxId.Text)
        passwordHashSHA256 = HashCupute2(TextBoxId.Text, "SHA256")
        Try
            UPDATE_APPRAISAL_APPROVAL_LIST(TextBoxId.Text, passwordHashSHA256)
        Catch ex As Exception

        End Try

        'Dim i As Integer
        'For i = 0 To UserAppraisal.Tables(0).Rows.Count - 1
        '    EmpId = UserAppraisal.Tables(0).Rows(i).Item("Appraisal_Id")
        '    OldPassword = UserAppraisal.Tables(0).Rows(i).Item("Appraisal_Id")
        '    passwordHashSHA256 = HashCupute2(OldPassword, "SHA256")
        '    'UPDATE_APPRAISAL_APPROVAL_LIST(EmpId, passwordHashMD5)
        'Next
    End Sub
End Class
