Imports Microsoft.VisualBasic

Public Class Appraisal_Request_PicturePath
    Private Const CLSNAME As String = "Class Appraisal_Request_PicturePath"

    Private _Req_ID As Integer
    Private _Hub_ID As Integer
    Private _Picture_Path As String
    Private _Done As Integer


    Public Sub New( _
     ByVal Req_ID As Integer, _
     ByVal Hub_ID As Integer, _
     ByVal Picture_Path As String, _
     ByVal Done As Integer)
        MyBase.New()
        _Req_ID = Req_ID
        _Hub_ID = Hub_ID
        _Picture_Path = Picture_Path
        _Done = Done
    End Sub

    Public Property Req_ID() As Integer
        Get
            Return _Req_ID
        End Get
        Set(ByVal Value As Integer)
            _Req_ID = Value
        End Set
    End Property

    Public Property Hub_ID() As Integer
        Get
            Return _Hub_ID
        End Get
        Set(ByVal Value As Integer)
            _Hub_ID = Value
        End Set
    End Property

    Public Property Picture_Path() As String
        Get
            Return _Picture_Path
        End Get
        Set(ByVal Value As String)
            _Picture_Path = Value
        End Set
    End Property

    Public Property Done() As Integer
        Get
            Return _Done
        End Get
        Set(ByVal Value As Integer)
            _Done = Value
        End Set
    End Property
End Class
