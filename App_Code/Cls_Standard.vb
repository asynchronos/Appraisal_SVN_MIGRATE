Imports Microsoft.VisualBasic

Public Class Cls_Standard
    Private _STANDARD_ID As Integer
    Private _STANDARD_NAME As String
    Private _STANDARD_STATUS As Integer


    Public Sub New( _
     ByVal STANDARD_ID As Integer, _
     ByVal STANDARD_NAME As String, _
     ByVal STANDARD_STATUS As String)
        MyBase.New()
        _STANDARD_ID = STANDARD_ID
        _STANDARD_NAME = STANDARD_NAME
        _STANDARD_STATUS = STANDARD_STATUS
    End Sub

    Public Property STANDARD_ID() As Integer
        Get
            Return _STANDARD_ID
        End Get
        Set(ByVal Value As Integer)
            _STANDARD_ID = Value
        End Set
    End Property

    Public Property STANDARD_NAME() As String
        Get
            Return _STANDARD_NAME
        End Get
        Set(ByVal Value As String)
            _STANDARD_NAME = Value
        End Set
    End Property

    Public Property STANDARD_STATUS() As Integer
        Get
            Return _STANDARD_STATUS
        End Get
        Set(ByVal Value As Integer)
            _STANDARD_STATUS = Value
        End Set
    End Property
End Class
