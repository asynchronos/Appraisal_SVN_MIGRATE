Imports Microsoft.VisualBasic

Public Class Appraisal_Request_Master
    Private Const CLSNAME As String = "Class Appraisal_Request"

    Private _Req_ID As Integer
    Private _Cif As String
    Private _Title As Integer
    Private _Name As String
    Private _Lastname As String
    Private _Req_Type As Integer
    Private _AID As String
    Private _Status_ID As Integer
    Private _Sender_ID As String
    Private _Sender_Name As Integer
    Private _Create_User As String
    Private _Create_Date As Date


    Public Sub New( _
     ByVal Req_ID As Integer, _
     ByVal Cif As String, _
     ByVal Title As Integer, _
     ByVal Name As String, _
     ByVal Lastname As String, _
     ByVal Req_Type As Integer, _
     ByVal AID As String, _
     ByVal Status_ID As Integer, _
     ByVal Sender_ID As String, _
     ByVal Sender_Name As Integer, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)
        MyBase.New()
        _Req_ID = Req_ID
        _Cif = Cif
        _Title = Title
        _Name = Name
        _Lastname = Lastname
        _Req_Type = Req_Type
        _AID = AID
        _Status_ID = Status_ID
        _Sender_ID = Sender_ID
        _Sender_Name = Sender_Name
        _Create_User = Create_User
        _Create_Date = Create_Date
    End Sub

    Public Property Req_ID() As Integer
        Get
            Return _Req_ID
        End Get
        Set(ByVal Value As Integer)
            _Req_ID = Value
        End Set
    End Property

    Public Property Cif() As String
        Get
            Return _Cif
        End Get
        Set(ByVal Value As String)
            _Cif = Value
        End Set
    End Property

    Public Property Title() As Integer
        Get
            Return _Title
        End Get
        Set(ByVal Value As Integer)
            _Title = Value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal Value As String)
            _Name = Value
        End Set
    End Property

    Public Property Lastname() As String
        Get
            Return _Lastname
        End Get
        Set(ByVal Value As String)
            _Lastname = Value
        End Set
    End Property

    Public Property Req_Type() As Integer
        Get
            Return _Req_Type
        End Get
        Set(ByVal Value As Integer)
            _Req_Type = Value
        End Set
    End Property

    Public Property AID() As String
        Get
            Return _AID
        End Get
        Set(ByVal Value As String)
            _AID = Value
        End Set
    End Property

    Public Property Status_ID() As Integer
        Get
            Return _Status_ID
        End Get
        Set(ByVal Value As Integer)
            _Status_ID = Value
        End Set
    End Property

    Public Property Sender_ID() As String
        Get
            Return _Sender_ID
        End Get
        Set(ByVal Value As String)
            _Sender_ID = Value
        End Set
    End Property

    Public Property Sender_Name() As String
        Get
            Return _Sender_Name
        End Get
        Set(ByVal Value As String)
            _Sender_Name = Value
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
