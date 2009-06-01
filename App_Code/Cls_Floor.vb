Imports Microsoft.VisualBasic

Public Class Cls_Floor

    Private Const CLSNAME As String = "Class Floor"

    Private _Floor_Id As Integer
    Private _Floor_Name As String


    Public Sub New( _
     ByVal Floor_Id As Integer, _
     ByVal Floor_Name As String)
        MyBase.New()
        _Floor_Id = Floor_Id
        _Floor_Name = Floor_Name
    End Sub

    Public Property Floor_Id() As Integer
        Get
            Return _Floor_Id
        End Get
        Set(ByVal Value As Integer)
            _Floor_Id = Value
        End Set
    End Property

    Public Property Floor_Name() As String
        Get
            Return _Floor_Name
        End Get
        Set(ByVal Value As String)
            _Floor_Name = Value
        End Set
    End Property
End Class

