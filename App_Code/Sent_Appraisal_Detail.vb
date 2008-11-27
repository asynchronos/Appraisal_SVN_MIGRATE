Imports Microsoft.VisualBasic

Public Class Sent_Appraisal_Detail
    Private _Q_ID As Integer
    Private _Cif As Integer
    Private _Coll_ID As Integer

    Public Sub New( _
        ByVal Q_ID As Integer, _
        ByVal Cif As Integer, _
        ByVal Coll_ID As Integer)

        MyBase.New()
        _Q_ID = Q_ID
        _Cif = Cif
        _Coll_ID = Coll_ID
    End Sub

    Public Property Q_ID() As Integer
        Get
            Return _Q_ID
        End Get
        Set(ByVal Value As Integer)
            _Q_ID = Value
        End Set
    End Property

    Public Property Cif() As Integer
        Get
            Return _cif
        End Get
        Set(ByVal Value As Integer)
            _cif = Value
        End Set
    End Property

    Public Property Coll_ID() As Integer
        Get
            Return _Coll_ID
        End Get
        Set(ByVal Value As Integer)
            _Coll_ID = Value
        End Set
    End Property

End Class
