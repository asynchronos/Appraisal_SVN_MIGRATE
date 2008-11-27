Option Explicit On
Option Strict On

Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

<XmlRoot(ElementName:="Price1_Master")> _
Public Class Price1_Master
    Private Const CLSNAME As String = "Class Price1_Master"

    Private _Req_Id As Integer
    Private _Hub_Id As Integer
    Private _Cif As Integer
    Private _CifName As String
    Private _Lat As Double
    Private _Lng As Double
    Private _Price As Decimal
    Private _Create_User As String
    Private _Create_Date As Date

    <XmlElement(ElementName:="Req_Id")> _
    Public Property Req_Id() As Integer
        Get
            Return _Req_Id
        End Get
        Set(ByVal Value As Integer)
            _Req_Id = Value
        End Set
    End Property

    <XmlElement(ElementName:="Hub_Id")> _
    Public Property Hub_Id() As Integer
        Get
            Return _Hub_Id
        End Get
        Set(ByVal Value As Integer)
            _Hub_Id = Value
        End Set
    End Property

    <XmlElement(ElementName:="Cif")> _
    Public Property Cif() As Integer
        Get
            Return _Cif
        End Get
        Set(ByVal Value As Integer)
            _Cif = Value
        End Set
    End Property

    <XmlElement(ElementName:="CifName")> _
    Public Property CifName() As String
        Get
            Return _CifName
        End Get
        Set(ByVal Value As String)
            _CifName = Value
        End Set
    End Property

    <XmlElement(ElementName:="Lat")> _
    Public Property Lat() As Double
        Get
            Return _Lat
        End Get
        Set(ByVal Value As Double)
            _Lat = Value
        End Set
    End Property

    <XmlElement(ElementName:="Lng")> _
    Public Property Lng() As Double
        Get
            Return _Lng
        End Get
        Set(ByVal Value As Double)
            _Lng = Value
        End Set
    End Property

    <XmlElement(ElementName:="Price")> _
    Public Property Price() As Decimal
        Get
            Return _Price
        End Get
        Set(ByVal Value As Decimal)
            _Price = Value
        End Set
    End Property

    <XmlElement(ElementName:="Create_User")> _
    Public Property Create_User() As String
        Get
            Return _Create_User
        End Get
        Set(ByVal Value As String)
            _Create_User = Value
        End Set
    End Property

    <XmlElement(ElementName:="Create_Date")> _
    Public Property Create_Date() As Date
        Get
            Return _Create_Date
        End Get
        Set(ByVal Value As Date)
            _Create_Date = Value
        End Set
    End Property
End Class
