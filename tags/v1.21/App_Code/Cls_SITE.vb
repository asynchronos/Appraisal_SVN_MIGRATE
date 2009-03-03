Imports Microsoft.VisualBasic

Public Class Cls_SITE
    Private Const CLSNAME As String = "Class Site"

    Private _Site_ID As Integer
    Private _Site_Name As String


    Public Sub New( _
     ByVal Site_ID As Integer, _
     ByVal Site_Name As String)
        MyBase.New()
        _Site_ID = Site_ID
        _Site_Name = Site_Name
    End Sub

    Public Property Site_ID() As Integer
        Get
            Return _Site_ID
        End Get
        Set(ByVal Value As Integer)
            _Site_ID = Value
        End Set
    End Property

    Public Property Site_Name() As String
        Get
            Return _Site_Name
        End Get
        Set(ByVal Value As String)
            _Site_Name = Value
        End Set
    End Property
End Class
