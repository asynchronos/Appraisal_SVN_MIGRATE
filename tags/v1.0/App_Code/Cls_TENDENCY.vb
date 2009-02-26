Imports Microsoft.VisualBasic

Public Class Cls_TENDENCY

    Private Const CLSNAME As String = "Class Tendency"

    Private _Tendency_ID As Integer
    Private _Tendency_Name As String


    Public Sub New( _
     ByVal Tendency_ID As Integer, _
     ByVal Tendency_Name As String)
        MyBase.New()
        _Tendency_ID = Tendency_ID
        _Tendency_Name = Tendency_Name
    End Sub

    Public Property Tendency_ID() As Integer
        Get
            Return _Tendency_ID
        End Get
        Set(ByVal Value As Integer)
            _Tendency_ID = Value
        End Set
    End Property

    Public Property Tendency_Name() As String
        Get
            Return _Tendency_Name
        End Get
        Set(ByVal Value As String)
            _Tendency_Name = Value
        End Set
    End Property

End Class
