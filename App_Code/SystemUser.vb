Imports Microsoft.VisualBasic

Public Class SystemUser
    Private Const CLSNAME As String = "Class Tb_SystemUser"

    Private _UserID As String
    Private _Pwd As String
    Private _Emp_Id As String
    Private _Hub_Id As Integer
    Private _SGroup_Id As Integer
    Private _Create_User As String
    Private _Create_Date As Date


    Public Sub New( _
     ByVal UserID As String, _
     ByVal Pwd As String, _
     ByVal Emp_Id As String, _
     ByVal Hub_Id As Integer, _
     ByVal SGroup_Id As Integer, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)
        MyBase.New()
        _UserID = User_Id
        _Pwd = Pwd
        _Emp_Id = Emp_Id
        _Hub_Id = Hub_Id
        _SGroup_Id = SGroup_Id
        _Create_User = Create_User
        _Create_Date = Create_Date
    End Sub

    Public Property User_Id() As String
        Get
            Return _UserID
        End Get
        Set(ByVal Value As String)
            _UserID = Value
        End Set
    End Property

    Public Property Pwd() As String
        Get
            Return _Pwd
        End Get
        Set(ByVal Value As String)
            _Pwd = Value
        End Set
    End Property

    Public Property Emp_Id() As String
        Get
            Return _Emp_Id
        End Get
        Set(ByVal Value As String)
            _Emp_Id = Value
        End Set
    End Property

    Public Property Hub_Id() As Integer
        Get
            Return _Hub_Id
        End Get
        Set(ByVal Value As Integer)
            _Hub_Id = Value
        End Set
    End Property

    Public Property SGroup_Id() As Integer
        Get
            Return _SGroup_Id
        End Get
        Set(ByVal Value As Integer)
            _SGroup_Id = Value
        End Set
    End Property

    Public Property Create_User() As String
        Get
            Return _Create_User
        End Get
        Set(ByVal Value As String)
            _Create_User = Value
        End Set
    End Property

    Public Property Create_Date() As Date
        Get
            Return _Create_Date
        End Get
        Set(ByVal Value As Date)
            _Create_Date = Value
        End Set
    End Property
End Class
