Imports Microsoft.VisualBasic

Public Class Cls_Interior

    Private Const CLSNAME As String = "Class Interior_State"

    Private _InteriorState_Id As Integer
    Private _InteriorState_Name As String


    Public Sub New( _
     ByVal InteriorState_Id As Integer, _
     ByVal InteriorState_Name As String)
        MyBase.New()
        _InteriorState_Id = InteriorState_Id
        _InteriorState_Name = InteriorState_Name
    End Sub

    Public Property InteriorState_Id() As Integer
        Get
            Return _InteriorState_Id
        End Get
        Set(ByVal Value As Integer)
            _InteriorState_Id = Value
        End Set
    End Property

    Public Property InteriorState_Name() As String
        Get
            Return _InteriorState_Name
        End Get
        Set(ByVal Value As String)
            _InteriorState_Name = Value
        End Set
    End Property

End Class
