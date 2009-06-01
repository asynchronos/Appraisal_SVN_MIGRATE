Imports Microsoft.VisualBasic

Public Class Cls_SubUnit

    Private _SubUnit_Id As Integer
    Private _SubUnit_Name As String


    Public Sub New( _
     ByVal SubUnit_Id As Integer, _
     ByVal SubUnit_Name As String)
        MyBase.New()
        _SubUnit_Id = SubUnit_Id
        _SubUnit_Name = SubUnit_Name
    End Sub

    Public Property SubUnit_Id() As Integer
        Get
            Return _SubUnit_Id
        End Get
        Set(ByVal Value As Integer)
            _SubUnit_Id = Value
        End Set
    End Property

    Public Property SubUnit_Name() As String
        Get
            Return _SubUnit_Name
        End Get
        Set(ByVal Value As String)
            _SubUnit_Name = Value
        End Set
    End Property

End Class
