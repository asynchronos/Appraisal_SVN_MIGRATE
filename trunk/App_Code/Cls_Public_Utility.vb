Imports Microsoft.VisualBasic

Public Class Cls_Public_Utility

    Private Const CLSNAME As String = "Class Public_Utility"

    Private _Public_Utility_ID As Integer
    Private _Public_Utility_Name As String


    Public Sub New( _
     ByVal Public_Utility_ID As Integer, _
     ByVal Public_Utility_Name As String)
        MyBase.New()
        _Public_Utility_ID = Public_Utility_ID
        _Public_Utility_Name = Public_Utility_Name
    End Sub

    Public Property Public_Utility_ID() As Integer
        Get
            Return _Public_Utility_ID
        End Get
        Set(ByVal Value As Integer)
            _Public_Utility_ID = Value
        End Set
    End Property

    Public Property Public_Utility_Name() As String
        Get
            Return _Public_Utility_Name
        End Get
        Set(ByVal Value As String)
            _Public_Utility_Name = Value
        End Set
    End Property
End Class
