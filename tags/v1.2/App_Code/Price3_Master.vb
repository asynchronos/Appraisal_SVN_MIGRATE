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
    Private vAID As String
    Private vTemp_AID As Integer
    Private vInform_To As String
    Private vCif As Integer
    Private vLat As Double
    Private vLng As Double
    Private vPriceWah As Decimal
    Private vTotalPrice As Decimal
    Private vApproved1 As String
    Private vApproved2 As String
    Private vApproved3 As String
    Private vApproved As Integer
    Private vEnv_Effect As Integer
    Private vEnv_Effect_Detail As String
    Private vAppraisal_Detail As String
    Private vAppraisal_Type_Id As Integer
    Private vComment_ID As Integer
    Private vWarning_ID As Integer
    Private vWarning_Detail As String
    Private vCreate_User As String
    Private vCreate_Date As Date


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
    Public Property AID() As String
        Get
            Return vAID
        End Get
        Set(ByVal Value As String)
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

    <XmlElement(ElementName:="Inform_To")> _
Public Property Inform_To() As String
        Get
            Return vInform_To
        End Get
        Set(ByVal Value As String)
            vInform_To = Value
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
Public Property Approved1() As String
        Get
            Return vApproved1
        End Get
        Set(ByVal Value As String)
            vApproved1 = Value
        End Set
    End Property

    <XmlElement(ElementName:="Approve2")> _
Public Property Approved2() As String
        Get
            Return vApproved2
        End Get
        Set(ByVal Value As String)
            vApproved2 = Value
        End Set
    End Property

    <XmlElement(ElementName:="Approve3")> _
Public Property Approved3() As String
        Get
            Return vApproved3
        End Get
        Set(ByVal Value As String)
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

    <XmlElement(ElementName:="Env_Effect")> _
Public Property Env_Effect() As Integer
        Get
            Return vEnv_Effect
        End Get
        Set(ByVal Value As Integer)
            vEnv_Effect = Value
        End Set
    End Property

    <XmlElement(ElementName:="Env_Effect_Detail")> _
Public Property Env_Effect_Detail() As String
        Get
            Return vEnv_Effect_Detail
        End Get
        Set(ByVal Value As String)
            vEnv_Effect_Detail = Value
        End Set
    End Property

    <XmlElement(ElementName:="Appraisal_Detail")> _
Public Property Appraisal_Detail() As String
        Get
            Return vAppraisal_Detail
        End Get
        Set(ByVal Value As String)
            vAppraisal_Detail = Value
        End Set
    End Property

    <XmlElement(ElementName:="Appraisal_Type_ID")> _
Public Property Appraisal_Type_ID() As Integer
        Get
            Return vAppraisal_Type_Id
        End Get
        Set(ByVal Value As Integer)
            vAppraisal_Type_Id = Value
        End Set
    End Property

    <XmlElement(ElementName:="Comment_ID")> _
Public Property Comment_ID() As Integer
        Get
            Return vComment_ID
        End Get
        Set(ByVal Value As Integer)
            vComment_ID = Value
        End Set
    End Property

    <XmlElement(ElementName:="Warning_ID")> _
Public Property Warning_ID() As Integer
        Get
            Return vWarning_ID
        End Get
        Set(ByVal Value As Integer)
            vWarning_ID = Value
        End Set
    End Property

    <XmlElement(ElementName:="Warning_Detail")> _
Public Property Warning_Detail() As String
        Get
            Return vWarning_Detail
        End Get
        Set(ByVal Value As String)
            vWarning_Detail = Value
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
