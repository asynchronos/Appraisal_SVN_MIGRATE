Option Explicit On
Option Strict On

Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

<XmlRoot(ElementName:="Price1_Master")> _
Public Class Price1_Master
    Private Const CLSNAME As String = "Class Price1_Master"

    Private vReq_Id As Integer
    Private vHub_Id As Integer
    Private vCif As Integer
    Private vCifName As String
    Private vLat As Double
    Private vLng As Double
    Private vPriceWah As Decimal
    Private vPrice As Decimal
    Private vCreate_User As String
    Private vCreate_Date As Date

    'Private _Req_Id As Integer
    'Private _Hub_Id As Integer
    'Private _Cif As Integer
    'Private _CifName As String
    'Private _Lat As Double
    'Private _Lng As Double
    'Private PriceWah As Decimal
    'Private _Price As Decimal
    'Private _Create_User As String
    'Private _Create_Date As Date

    <XmlElement(ElementName:="Req_Id")> _
    Public Property Req_Id() As Integer
        Get
            Return vReq_Id
        End Get
        Set(ByVal Value As Integer)
            vReq_Id = Value
        End Set
    End Property

    <XmlElement(ElementName:="Hub_Id")> _
    Public Property Hub_Id() As Integer
        Get
            Return vHub_Id
        End Get
        Set(ByVal Value As Integer)
            vHub_Id = Value
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

    <XmlElement(ElementName:="CifName")> _
    Public Property CifName() As String
        Get
            Return vCifName
        End Get
        Set(ByVal Value As String)
            vCifName = Value
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

    <XmlElement(ElementName:="Pricewah")> _
    Public Property Pricewah() As Decimal
        Get
            Return vPriceWah
        End Get
        Set(ByVal Value As Decimal)
            vPriceWah = Value
        End Set
    End Property

    <XmlElement(ElementName:="Price")> _
    Public Property Price() As Decimal
        Get
            Return vPrice
        End Get
        Set(ByVal Value As Decimal)
            vPrice = Value
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
