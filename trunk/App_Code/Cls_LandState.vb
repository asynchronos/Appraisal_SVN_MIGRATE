Imports Microsoft.VisualBasic

Public Class Cls_LandState

    Private Const CLSNAME As String = "Class Land_State"

    Private _Land_State_Id As Integer
    Private _Land_State_Name As String


    Public Sub New( _
     ByVal Land_State_Id As Integer, _
     ByVal Land_State_Name As String)
        MyBase.New()
        _Land_State_Id = Land_State_Id
        _Land_State_Name = Land_State_Name
    End Sub

    Public Property Land_State_Id() As Integer
        Get
            Return _Land_State_Id
        End Get
        Set(ByVal Value As Integer)
            _Land_State_Id = Value
        End Set
    End Property

    Public Property Land_State_Name() As String
        Get
            Return _Land_State_Name
        End Get
        Set(ByVal Value As String)
            _Land_State_Name = Value
        End Set
    End Property

End Class
