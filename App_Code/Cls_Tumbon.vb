Imports Microsoft.VisualBasic

Public Class Cls_Tumbon

    Private _pvcode As Integer
    Private _amcode As Integer
    Private _ttcode As Integer
    Private _tumbon_new2_name As String


    Public Sub New( _
     ByVal pvcode As Integer, _
     ByVal amcode As Integer, _
     ByVal ttcode As Integer, _
     ByVal tumbon_new2_name As String)
        MyBase.New()
        _pvcode = pvcode
        _amcode = amcode
        _ttcode = ttcode
        _tumbon_new2_name = tumbon_new2_name
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

    Public Property ttcode() As Integer
        Get
            Return _ttcode
        End Get
        Set(ByVal Value As Integer)
            _ttcode = Value
        End Set
    End Property

    Public Property tumbon_new2_name() As String
        Get
            Return _tumbon_new2_name
        End Get
        Set(ByVal Value As String)
            _tumbon_new2_name = Value
        End Set
    End Property


End Class

