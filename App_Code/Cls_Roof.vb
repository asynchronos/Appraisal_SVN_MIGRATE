Imports Microsoft.VisualBasic

Public Class Cls_Roof
    Private _Roof_ID As Integer
    Private _Roof_Name As String


    Public Sub New( _
     ByVal Roof_ID As Integer, _
     ByVal Roof_Name As String)
        MyBase.New()
        _Roof_ID = Roof_ID
        _Roof_Name = Roof_Name
    End Sub

    Public Property Roof_ID() As Integer
        Get
            Return _Roof_ID
        End Get
        Set(ByVal Value As Integer)
            _Roof_ID = Value
        End Set
    End Property

    Public Property Roof_Name() As String
        Get
            Return _Roof_Name
        End Get
        Set(ByVal Value As String)
            _Roof_Name = Value
        End Set
    End Property
End Class
