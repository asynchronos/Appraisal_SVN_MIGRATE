Imports Microsoft.VisualBasic

Public Class Cls_RoadFrontOff

    Private Const CLSNAME As String = "Class Road_Frontoff"

    Private _Road_Frontoff_ID As Integer
    Private _Road_Frontoff_Name As String


    Public Sub New( _
     ByVal Road_Frontoff_ID As Integer, _
     ByVal Road_Frontoff_Name As String)
        MyBase.New()
        _Road_Frontoff_ID = Road_Frontoff_ID
        _Road_Frontoff_Name = Road_Frontoff_Name
    End Sub

    Public Property Road_Frontoff_ID() As Integer
        Get
            Return _Road_Frontoff_ID
        End Get
        Set(ByVal Value As Integer)
            _Road_Frontoff_ID = Value
        End Set
    End Property

    Public Property Road_Frontoff_Name() As String
        Get
            Return _Road_Frontoff_Name
        End Get
        Set(ByVal Value As String)
            _Road_Frontoff_Name = Value
        End Set
    End Property
End Class
