Imports Microsoft.VisualBasic

Public Class Cls_PROVINCE
    Private Const CLSNAME As String = "Class TB_PROVINCE"

    Private _PROV_CODE As Integer
    Private _PROV_NAME As String
    Private _PROV_NAME_E As String
    Private _ZONE_CODE As String
    Private _AREA_CODE As String


    Public Sub New( _
     ByVal PROV_CODE As Integer, _
     ByVal PROV_NAME As String, _
     ByVal PROV_NAME_E As String, _
     ByVal ZONE_CODE As String, _
     ByVal AREA_CODE As String)
        MyBase.New()
        _PROV_CODE = PROV_CODE
        _PROV_NAME = PROV_NAME
        _PROV_NAME_E = PROV_NAME_E
        _ZONE_CODE = ZONE_CODE
        _AREA_CODE = AREA_CODE
    End Sub

    Public Property PROV_CODE() As Integer
        Get
            Return _PROV_CODE
        End Get
        Set(ByVal Value As Integer)
            _PROV_CODE = Value
        End Set
    End Property

    Public Property PROV_NAME() As String
        Get
            Return _PROV_NAME
        End Get
        Set(ByVal Value As String)
            _PROV_NAME = Value
        End Set
    End Property

    Public Property PROV_NAME_E() As String
        Get
            Return _PROV_NAME_E
        End Get
        Set(ByVal Value As String)
            _PROV_NAME_E = Value
        End Set
    End Property

    Public Property ZONE_CODE() As String
        Get
            Return _ZONE_CODE
        End Get
        Set(ByVal Value As String)
            _ZONE_CODE = Value
        End Set
    End Property

    Public Property AREA_CODE() As String
        Get
            Return _AREA_CODE
        End Get
        Set(ByVal Value As String)
            _AREA_CODE = Value
        End Set
    End Property
End Class
