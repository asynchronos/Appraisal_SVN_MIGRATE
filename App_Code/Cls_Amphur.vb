Imports Microsoft.VisualBasic

Public Class Cls_Amphur

    Private _pvcode As Integer
    Private _amcode As Integer
    Private _am_name As String


    Public Sub New( _
     ByVal pvcode As Integer, _
     ByVal amcode As Integer, _
     ByVal am_name As String)
        MyBase.New()
        _pvcode = pvcode
        _amcode = amcode
        _am_name = am_name
    End Sub

    Public Property pvcode() As Integer
        Get
            Return _pvcode
        End Get
        Set(ByVal Value As Integer)
            _pvcode = Value
        End Set
    End Property

    Public Property amcode() As Integer
        Get
            Return _amcode
        End Get
        Set(ByVal Value As Integer)
            _amcode = Value
        End Set
    End Property

    Public Property am_name() As String
        Get
            Return _am_name
        End Get
        Set(ByVal Value As String)
            _am_name = Value
        End Set
    End Property
End Class
