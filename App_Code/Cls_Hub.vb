Imports Microsoft.VisualBasic

Public Class Cls_Hub

    Private Const CLSNAME As String = "Class TB_HUB"

    Private _HUB_ID As Integer
    Private _HUB_NAME As String
    Private _HUB_NAME_E As String


    Public Sub New( _
     ByVal HUB_ID As Integer, _
     ByVal HUB_NAME As String, _
     ByVal HUB_NAME_E As String)
        MyBase.New()
        _HUB_ID = HUB_ID
        _HUB_NAME = HUB_NAME
        _HUB_NAME_E = HUB_NAME_E
    End Sub

    Public Property HUB_ID() As Integer
        Get
            Return _HUB_ID
        End Get
        Set(ByVal Value As Integer)
            _HUB_ID = Value
        End Set
    End Property

    Public Property HUB_NAME() As String
        Get
            Return _HUB_NAME
        End Get
        Set(ByVal Value As String)
            _HUB_NAME = Value
        End Set
    End Property

    Public Property HUB_NAME_E() As String
        Get
            Return _HUB_NAME_E
        End Get
        Set(ByVal Value As String)
            _HUB_NAME_E = Value
        End Set
    End Property

End Class
