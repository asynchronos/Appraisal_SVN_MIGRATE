Imports Microsoft.VisualBasic

Public Class Sent_Appraisal_Master
    Private _Q_ID As Integer
    Private _Cif As Integer
    Private _Create_Date As Date
    Private _Sent_Appraisal_ID As String
    Private _Appraisal_ID As Integer
    Private _Create_User_ID As String
    Private _Status_ID As Integer
    Private _Note As String

    Public Sub New( _
        ByVal Cif As Integer, _
        ByVal Create_Date As Date, _
        ByVal Sent_Appraisal_ID As String, _
        ByVal Appraisal_ID As Integer, _
        ByVal Create_User_ID As String, _
        ByVal Status_ID As Integer, _
        ByVal Note As String)
        MyBase.New()
        _Q_ID = Q_ID
        _Cif = Cif
        _Create_Date = Create_Date
        _Sent_Appraisal_ID = Sent_Appraisal_ID
        _Appraisal_ID = Appraisal_ID
        _Create_User_ID = Create_User_ID
        _Status_ID = Status_ID
        _Note = Note
    End Sub

    Public Property Q_ID() As Integer
        Get
            Return _Q_ID
        End Get
        Set(ByVal Value As Integer)
            _Q_ID = Value
        End Set
    End Property

    Public Property Cif() As Integer
        Get
            Return _cif
        End Get
        Set(ByVal Value As Integer)
            _cif = Value
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

    Public Property Sent_Appraisal_ID() As String
        Get
            Return _Sent_Appraisal_ID
        End Get
        Set(ByVal Value As String)
            _Sent_Appraisal_ID = Value
        End Set
    End Property

    Public Property Appraisal_ID() As Integer
        Get
            Return _Appraisal_ID
        End Get
        Set(ByVal Value As Integer)
            _Appraisal_ID = Value
        End Set
    End Property

    Public Property Create_User_ID() As String
        Get
            Return _Create_User_ID
        End Get
        Set(ByVal Value As String)
            _Create_User_ID = Value
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

    Public Property Note() As Integer
        Get
            Return _Note
        End Get
        Set(ByVal Value As Integer)
            _Note = Value
        End Set
    End Property
End Class
