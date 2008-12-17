Option Explicit On
Option Strict On

Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

<XmlRoot(ElementName:="Price3_Master")> _
Public Class Price3_Master
    Private Const CLSNAME As String = "Class Price3_Master"
    Private vReq_Id As Integer
    Private vAID As Integer
    Private vTemp_AID As Integer
    Private vCif As Integer
    Private vLat As Double
    Private vLng As Double
    Private vPriceWah As Decimal
    Private vTotalPrice As Decimal
    Private vApproved1 As Integer
    Private vApproved2 As Integer
    Private vApproved3 As Integer
    Private vApproved As Integer
    Private vCreate_User As String
    Private vCreate_Date As Date

    'Private _Req_Id As Integer
    'Private _AID As Integer
    'Private _Temp_AID As Integer
    'Private _Cif As Integer
    'Private _Lat As Double
    'Private _Lng As Double
    'Private _PriceWah As Decimal
    'Private _TotalPrice As Decimal
    'Private _Approved1 As Integer
    'Private _Approved2 As Integer
    'Private _Approved3 As Integer
    'Private _Approved As Integer
    'Private _Create_User As String
    'Private _Create_Date As Date


    'Public Sub New( _
    ' ByVal Req_Id As Integer, _
    ' ByVal AID As Integer, _
    ' ByVal Temp_AID As Integer, _
    ' ByVal Cif As Integer, _
    ' ByVal Lat As Double, _
    ' ByVal Lng As Double, _
    ' ByVal PriceWah As Decimal, _
    ' ByVal TotalPrice As Decimal, _
    ' ByVal Approved1 As Integer, _
    ' ByVal Approved2 As Integer, _
    ' ByVal Approved3 As Integer, _
    ' ByVal Approved As Integer, _
    ' ByVal Create_User As String, _
    ' ByVal Create_Date As Date)
    '    MyBase.New()
    '    _Req_Id = Req_Id
    '    _AID = AID
    '    _Temp_AID = Temp_AID
    '    _Cif = Cif
    '    _Lat = Lat
    '    _Lng = Lng
    '    _PriceWah = PriceWah
    '    _TotalPrice = TotalPrice
    '    _Approved1 = Approved1
    '    _Approved2 = Approved2
    '    _Approved3 = Approved3
    '    _Approved = Approved
    '    _Create_User = Create_User
    '    _Create_Date = Create_Date
    'End Sub

    <XmlElement(ElementName:="Req_Id")> _
    Public Property Req_Id() As Integer
        Get
            Return vReq_Id
        End Get
        Set(ByVal Value As Integer)
            vReq_Id = Value
        End Set
    End Property

    <XmlElement(ElementName:="AID")> _
    Public Property AID() As Integer
        Get
            Return vAID
        End Get
        Set(ByVal Value As Integer)
            vAID = Value
        End Set
    End Property

    <XmlElement(ElementName:="Temp_AID")> _
    Public Property Temp_AID() As Integer
        Get
            Return vTemp_AID
        End Get
        Set(ByVal Value As Integer)
            vTemp_AID = Value
        End Set
    End Property

    <XmlElement(ElementName:="Cif")> _
    Public Property Cif() As Integer
        Get
            Return vCif
        End Get
        Set(ByVal Value As Integer)
            vCif = Value
        End Set
    End Property

    <XmlElement(ElementName:="Lat")> _
    Public Property Lat() As Double
        Get
            Return vLat
        End Get
        Set(ByVal Value As Double)
            vLat = Value
        End Set
    End Property

    <XmlElement(ElementName:="Lng")> _
    Public Property Lng() As Double
        Get
            Return vLng
        End Get
        Set(ByVal Value As Double)
            vLng = Value
        End Set
    End Property

    <XmlElement(ElementName:="PriceWah")> _
    Public Property PriceWah() As Decimal
        Get
            Return vPriceWah
        End Get
        Set(ByVal Value As Decimal)
            vPriceWah = Value
        End Set
    End Property

    <XmlElement(ElementName:="TotalPrice")> _
    Public Property TotalPrice() As Decimal
        Get
            Return vTotalPrice
        End Get
        Set(ByVal Value As Decimal)
            vTotalPrice = Value
        End Set
    End Property

    <XmlElement(ElementName:="Approve1")> _
Public Property Approved1() As Integer
        Get
            Return vApproved1
        End Get
        Set(ByVal Value As Integer)
            vApproved1 = Value
        End Set
    End Property

    <XmlElement(ElementName:="Approve2")> _
Public Property Approved2() As Integer
        Get
            Return vApproved2
        End Get
        Set(ByVal Value As Integer)
            vApproved2 = Value
        End Set
    End Property

    <XmlElement(ElementName:="Approve3")> _
Public Property Approved3() As Integer
        Get
            Return vApproved3
        End Get
        Set(ByVal Value As Integer)
            vApproved3 = Value
        End Set
    End Property

    <XmlElement(ElementName:="Approved")> _
Public Property Approved() As Integer
        Get
            Return vApproved
        End Get
        Set(ByVal Value As Integer)
            vApproved = Value
        End Set
    End Property

    <XmlElement(ElementName:="Create_User")> _
    Public Property Create_User() As String
        Get
            Return vCreate_User
        End Get
        Set(ByVal Value As String)
            vCreate_User = Value
        End Set
    End Property

    <XmlElement(ElementName:="Create_Date")> _
    Public Property Create_Date() As Date
        Get
            Return vCreate_Date
        End Get
        Set(ByVal Value As Date)
            vCreate_Date = Value
        End Set
    End Property

End Class
