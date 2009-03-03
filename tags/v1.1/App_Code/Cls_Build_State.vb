Imports Microsoft.VisualBasic

Public Class Cls_Build_State
    Private _Build_State_ID As Integer
    Private _Build_State_Name As String


    Public Sub New( _
     ByVal Build_State_ID As Integer, _
     ByVal Build_State_Name As String)
        MyBase.New()
        _Build_State_ID = Build_State_ID
        _Build_State_Name = Build_State_Name
    End Sub

    Public Property Build_State_ID() As Integer
        Get
            Return _Build_State_ID
        End Get
        Set(ByVal Value As Integer)
            _Build_State_ID = Value
        End Set
    End Property

    Public Property Build_State_Name() As String
        Get
            Return _Build_State_Name
        End Get
        Set(ByVal Value As String)
            _Build_State_Name = Value
        End Set
    End Property
End Class
