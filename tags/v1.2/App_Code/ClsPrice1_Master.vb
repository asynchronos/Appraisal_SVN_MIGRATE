Imports Microsoft.VisualBasic

Public Class ClsPrice1_Master

    Private Const CLSNAME As String = "Class Price1_Master"

    Private _Req_Id As Integer
    Private _Hub_Id As Integer
    Private _Cif As Integer
    Private _CifName As String
    Private _Lat As Double
    Private _Lng As Double
    Private _Pricewah As Decimal
    Private _Price As Decimal
    Private _Create_User As String
    Private _Create_Date As Date


    Public Sub New( _
     ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
     ByVal Cif As Integer, _
     ByVal CifName As String, _
     ByVal Lat As Double, _
     ByVal Lng As Double, _
     ByVal Pricewah As Decimal, _
     ByVal Price As Decimal, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)
        MyBase.New()
        _Req_Id = Req_Id
        _Hub_Id = Hub_Id
        _Cif = Cif
        _CifName = CifName
        _Lat = Lat
        _Lng = Lng
        _Pricewah = Pricewah
        _Price = Price
        _Create_User = Create_User
        _Create_Date = Create_Date
    End Sub

    Public Property Req_Id() As Integer
        Get
            Return _Req_Id
        End Get
        Set(ByVal Value As Integer)
            _Req_Id = Value
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

    Public Property Cif() As Integer
        Get
            Return _Cif
        End Get
        Set(ByVal Value As Integer)
            _Cif = Value
        End Set
    End Property

    Public Property CifName() As String
        Get
            Return _CifName
        End Get
        Set(ByVal Value As String)
            _CifName = Value
        End Set
    End Property

    Public Property Lat() As Double
        Get
            Return _Lat
        End Get
        Set(ByVal Value As Double)
            _Lat = Value
        End Set
    End Property

    Public Property Lng() As Double
        Get
            Return _Lng
        End Get
        Set(ByVal Value As Double)
            _Lng = Value
        End Set
    End Property

    Public Property Pricewah() As Decimal
        Get
            Return _Pricewah
        End Get
        Set(ByVal Value As Decimal)
            _Pricewah = Value
        End Set
    End Property

    Public Property Price() As Decimal
        Get
            Return _Price
        End Get
        Set(ByVal Value As Decimal)
            _Price = Value
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
