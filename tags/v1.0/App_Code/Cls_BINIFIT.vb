Imports Microsoft.VisualBasic

Public Class Cls_BINIFIT

    Private Const CLSNAME As String = "Class Binifit"

    Private _Binifit_ID As Integer
    Private _Binifit_Name As String


    Public Sub New( _
     ByVal Binifit_ID As Integer, _
     ByVal Binifit_Name As String)
        MyBase.New()
        _Binifit_ID = Binifit_ID
        _Binifit_Name = Binifit_Name
    End Sub

    Public Property Binifit_ID() As Integer
        Get
            Return _Binifit_ID
        End Get
        Set(ByVal Value As Integer)
            _Binifit_ID = Value
        End Set
    End Property

    Public Property Binifit_Name() As String
        Get
            Return _Binifit_Name
        End Get
        Set(ByVal Value As String)
            _Binifit_Name = Value
        End Set
    End Property
End Class
