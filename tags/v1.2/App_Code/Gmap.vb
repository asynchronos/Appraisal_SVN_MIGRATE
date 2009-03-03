Option Explicit On
Option Strict On

Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

<XmlRoot(ElementName:="Gmap")> _
Public Class Gmap

    Private Const CLSNAME As String = "Class Gmap"

    Private strCOLL_ID As String
    Private dblLat As Double
    Private dblLng As Double
    Private strName As String
    Private strDetail As String
    Private decPrice1 As Decimal
    Private decPrice2 As Decimal
    Private decPrice3 As Decimal
    Private strPic1 As String
    Private strPic2 As String
    <XmlElement(ElementName:="COLL_ID")> _
        Public Property COLL_ID() As String
        Get
            Return strCOLL_ID
        End Get
        Set(ByVal Value As String)
            strCOLL_ID = Value
        End Set
    End Property
    <XmlElement(ElementName:="Lat")> _
    Public Property Lat() As Double
        Get
            Return dblLat
        End Get
        Set(ByVal Value As Double)
            dblLat = Value
        End Set
    End Property
    <XmlElement(ElementName:="Lng")> _
    Public Property Lng() As Double
        Get
            Return dblLng
        End Get
        Set(ByVal Value As Double)
            dblLng = Value
        End Set
    End Property
    <XmlElement(ElementName:="Name")> _
    Public Property Name() As String
        Get
            Return strName
        End Get
        Set(ByVal Value As String)
            strName = Value
        End Set
    End Property
    <XmlElement(ElementName:="Detail")> _
    Public Property Detail() As String
        Get
            Return strDetail
        End Get
        Set(ByVal Value As String)
            strDetail = Value
        End Set
    End Property
    <XmlElement(ElementName:="Price1")> _
    Public Property Price1() As Decimal
        Get
            Return decPrice1
        End Get
        Set(ByVal Value As Decimal)
            decPrice1 = Value
        End Set
    End Property
    <XmlElement(ElementName:="Price2")> _
    Public Property Price2() As Decimal
        Get
            Return decPrice2
        End Get
        Set(ByVal Value As Decimal)
            decPrice2 = Value
        End Set
    End Property
    <XmlElement(ElementName:="Price3")> _
    Public Property Price3() As Decimal
        Get
            Return decPrice3
        End Get
        Set(ByVal Value As Decimal)
            decPrice3 = Value
        End Set
    End Property
    <XmlElement(ElementName:="Pic1")> _
    Public Property Pic1() As String
        Get
            Return strPic1
        End Get
        Set(ByVal Value As String)
            strPic1 = Value
        End Set
    End Property
    <XmlElement(ElementName:="Pic2")> _
    Public Property Pic2() As String
        Get
            Return strPic2
        End Get
        Set(ByVal Value As String)
            strPic2 = Value
        End Set
    End Property



End Class
