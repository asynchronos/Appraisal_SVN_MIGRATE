Imports Microsoft.VisualBasic

Public Class Appraisal_Price3_PicturePath

    Private _Req_ID As Integer
    Private _Hub_ID As Integer
    Private _AID As String
    Private _Picture_Path As String
    Private _Temp_AID As Integer
    Private _CID As String
    Private _done As Integer
    Private _Create_User As String
    Private _Create_Date As Date


    Public Sub New( _
     ByVal Req_ID As Integer, _
     ByVal Hub_ID As Integer, _
     ByVal AID As String, _
     ByVal Picture_Path As String, _
     ByVal Temp_AID As Integer, _
     ByVal CID As String, _
     ByVal done As Integer, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)
        MyBase.New()
        _Req_ID = Req_ID
        _Hub_ID = Hub_ID
        _AID = AID
        _Picture_Path = Picture_Path
        _Temp_AID = Temp_AID
        _CID = CID
        _done = done
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

    Public Property Hub_ID() As Integer
        Get
            Return _Hub_ID
        End Get
        Set(ByVal Value As Integer)
            _Hub_ID = Value
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

    Public Property Picture_Path() As String
        Get
            Return _Picture_Path
        End Get
        Set(ByVal Value As String)
            _Picture_Path = Value
        End Set
    End Property

    Public Property Temp_AID() As Integer
        Get
            Return _Temp_AID
        End Get
        Set(ByVal Value As Integer)
            _Temp_AID = Value
        End Set
    End Property

    Public Property CID() As String
        Get
            Return _CID
        End Get
        Set(ByVal Value As String)
            _CID = Value
        End Set
    End Property

    Public Property done() As Integer
        Get
            Return _done
        End Get
        Set(ByVal Value As Integer)
            _done = Value
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
