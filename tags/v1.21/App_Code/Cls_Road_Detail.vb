Imports Microsoft.VisualBasic

Public Class Cls_Road_Detail

    Private Const CLSNAME As String = "Class Road_Detail"

    Private _Road_Detail_ID As Integer
    Private _Road_Detail_Name As String


    Public Sub New( _
     ByVal Road_Detail_ID As Integer, _
     ByVal Road_Detail_Name As String)
        MyBase.New()
        _Road_Detail_ID = Road_Detail_ID
        _Road_Detail_Name = Road_Detail_Name
    End Sub

    Public Property Road_Detail_ID() As Integer
        Get
            Return _Road_Detail_ID
        End Get
        Set(ByVal Value As Integer)
            _Road_Detail_ID = Value
        End Set
    End Property

    Public Property Road_Detail_Name() As String
        Get
            Return _Road_Detail_Name
        End Get
        Set(ByVal Value As String)
            _Road_Detail_Name = Value
        End Set
    End Property
End Class
