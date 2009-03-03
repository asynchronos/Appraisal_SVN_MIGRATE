Imports Microsoft.VisualBasic
Public Class CifInfo
    Private _cif As Integer
    Private _cifName As String
    Private _idCard As String
    Private _cifClass As String
    Private _BOTID As Integer
    Private _Busi_Type As Integer
    Private _Busi_Name As String
    Private _departName As String

    Public Sub New( _
     ByVal cif As Integer, _
     ByVal cifName As String, _
     ByVal idCard As String, _
     ByVal cifClass As String, _
     ByVal BOTID As Integer, _
     ByVal Busi_Type As Integer, _
     ByVal Busi_name As String, _
     ByVal departName As String)

        MyBase.New()
        _cif = cif
        _cifName = cifName
        _idCard = idCard
        _cifClass = cifClass
        _BOTID = BOTID
        _Busi_Type = Busi_Type
        _Busi_Name = Busi_name
        _departName = departName
    End Sub

    Public Property Cif() As Integer
        Get
            Return _cif
        End Get
        Set(ByVal Value As Integer)
            _cif = Value
        End Set
    End Property

    Public Property cifName() As String
        Get
            Return _cifName
        End Get
        Set(ByVal Value As String)
            _cifName = Value
        End Set
    End Property

    Public Property idCard() As String
        Get
            Return _idCard
        End Get
        Set(ByVal Value As String)
            _idCard = Value
        End Set
    End Property

    Public Property cifClass() As String
        Get
            Return _cifClass
        End Get
        Set(ByVal Value As String)
            _cifClass = Value
        End Set
    End Property

    Public Property BOTID() As Integer
        Get
            Return _BOTID
        End Get
        Set(ByVal Value As Integer)
            _BOTID = Value
        End Set
    End Property

    Public Property Busi_Type() As Integer
        Get
            Return _Busi_Type
        End Get
        Set(ByVal Value As Integer)
            _Busi_Type = Value
        End Set
    End Property

    Public Property Busi_Name() As String
        Get
            Return _Busi_Name
        End Get
        Set(ByVal Value As String)
            _Busi_Name = Value
        End Set
    End Property

    Public Property departName() As String
        Get
            Return _departName
        End Get
        Set(ByVal Value As String)
            _departName = Value
        End Set
    End Property
End Class

