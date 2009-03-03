Imports Microsoft.VisualBasic

Public Class Price3_70_Partake
    Private _Id As Integer
    Private _Req_Id As Integer
    Private _Hub_Id As Integer
    Private _Temp_AID As Integer
    Private _AID As String
    Private _Partake_Id As Integer
    Private _Building_No As String
    Private _PartakeArea As Double
    Private _PartakeUintPrice As Double
    Private _PartakePrice As Double
    Private _PartakeAge As Integer
    Private _PartakePersent1 As Decimal
    Private _PartakePersent2 As Decimal
    Private _PartakePersent3 As Decimal
    Private _PartakePriceTotalDeteriorate As Decimal
    Private _PartakeDetail As String
    Private _Create_User As String
    Private _Create_Date As Date


    Public Sub New( _
     ByVal Id As Integer, _
     ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
     ByVal Temp_AID As Integer, _
     ByVal AID As String, _
     ByVal Partake_Id As Integer, _
     ByVal Building_No As String, _
     ByVal PartakeArea As Double, _
     ByVal PartakeUintPrice As Double, _
     ByVal PartakePrice As Double, _
     ByVal PartakeAge As Integer, _
     ByVal PartakePersent1 As Decimal, _
     ByVal PartakePersent2 As Decimal, _
     ByVal PartakePersent3 As Decimal, _
     ByVal PartakePriceTotalDeteriorate As Decimal, _
     ByVal PartakeDetail As String, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)
        MyBase.New()
        _Id = Id
        _Req_Id = Req_Id
        _Hub_Id = Hub_Id
        _Temp_AID = Temp_AID
        _AID = AID
        _Partake_Id = Partake_Id
        _Building_No = Building_No
        _PartakeArea = PartakeArea
        _PartakeUintPrice = PartakeUintPrice
        _PartakePrice = PartakePrice
        _PartakeAge = PartakeAge
        _PartakePersent1 = PartakePersent1
        _PartakePersent2 = PartakePersent2
        _PartakePersent3 = PartakePersent3
        _PartakePriceTotalDeteriorate = PartakePriceTotalDeteriorate
        _PartakeDetail = PartakeDetail
        _Create_User = Create_User
        _Create_Date = Create_Date
    End Sub

    Public Property Id() As Integer
        Get
            Return _Id
        End Get
        Set(ByVal Value As Integer)
            _Id = Value
        End Set
    End Property

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

    Public Property Temp_AID() As Integer
        Get
            Return _Temp_AID
        End Get
        Set(ByVal Value As Integer)
            _Temp_AID = Value
        End Set
    End Property

    Public Property Partake_Id() As Integer
        Get
            Return _Partake_Id
        End Get
        Set(ByVal Value As Integer)
            _Partake_Id = Value
        End Set
    End Property

    Public Property Building_No() As String
        Get
            Return _Building_No
        End Get
        Set(ByVal Value As String)
            _Building_No = Value
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

    Public Property PartakeArea() As Double
        Get
            Return _PartakeArea
        End Get
        Set(ByVal Value As Double)
            _PartakeArea = Value
        End Set
    End Property

    Public Property PartakeUintPrice() As Double
        Get
            Return _PartakeUintPrice
        End Get
        Set(ByVal Value As Double)
            _PartakeUintPrice = Value
        End Set
    End Property

    Public Property PartakePrice() As Double
        Get
            Return _PartakePrice
        End Get
        Set(ByVal Value As Double)
            _PartakePrice = Value
        End Set
    End Property

    Public Property PartakeAge() As Integer
        Get
            Return _PartakeAge
        End Get
        Set(ByVal Value As Integer)
            _PartakeAge = Value
        End Set
    End Property

    Public Property PartakePersent1() As Decimal
        Get
            Return _PartakePersent1
        End Get
        Set(ByVal Value As Decimal)
            _PartakePersent1 = Value
        End Set
    End Property

    Public Property PartakePersent2() As Decimal
        Get
            Return _PartakePersent2
        End Get
        Set(ByVal Value As Decimal)
            _PartakePersent2 = Value
        End Set
    End Property

    Public Property PartakePersent3() As Decimal
        Get
            Return _PartakePersent3
        End Get
        Set(ByVal Value As Decimal)
            _PartakePersent3 = Value
        End Set
    End Property

    Public Property PartakePriceTotalDeteriorate() As Decimal
        Get
            Return _PartakePriceTotalDeteriorate
        End Get
        Set(ByVal Value As Decimal)
            _PartakePriceTotalDeteriorate = Value
        End Set
    End Property

    Public Property PartakeDetail() As String
        Get
            Return _PartakeDetail
        End Get
        Set(ByVal Value As String)
            _PartakeDetail = Value
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
