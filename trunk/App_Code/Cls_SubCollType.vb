Imports Microsoft.VisualBasic

Public Class Cls_SubCollType
    Private _CollType_ID As Integer
    Private _SubCollType_ID As Integer
    Private _MysubColl_ID As Integer
    Private _SubCollType_Name As String
    Public Sub New( _
     ByVal CollType_ID As Integer, _
     ByVal SubCollType_ID As Integer, _
     ByVal MysubColl_ID As Integer, _
     ByVal SubCollType_Name As String)

        MyBase.New()
        _CollType_ID = CollType_ID
        _SubCollType_ID = SubCollType_ID
        _MysubColl_ID = MysubColl_ID
        _SubCollType_Name = SubCollType_Name

    End Sub

    Public Property CollType_ID() As Integer
        Get
            Return _CollType_ID
        End Get
        Set(ByVal Value As Integer)
            _CollType_ID = Value
        End Set
    End Property
    Public Property SubCollType_ID() As Integer
        Get
            Return _SubCollType_ID
        End Get
        Set(ByVal Value As Integer)
            _SubCollType_ID = Value
        End Set
    End Property

    Public Property MysubColl_ID() As Integer
        Get
            Return _MysubColl_ID
        End Get
        Set(ByVal Value As Integer)
            _MysubColl_ID = Value
        End Set
    End Property

    Public Property SubCollType_Name() As String
        Get
            Return _SubCollType_Name
        End Get
        Set(ByVal Value As String)
            _SubCollType_Name = Value
        End Set
    End Property

End Class
