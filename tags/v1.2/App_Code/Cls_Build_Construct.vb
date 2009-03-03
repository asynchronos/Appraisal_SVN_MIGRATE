Imports Microsoft.VisualBasic

Public Class Cls_Build_Construct
    Private _Build_Construct_ID As Integer
    Private _Build_Construct_Name As String


    Public Sub New( _
     ByVal Build_Construct_ID As Integer, _
     ByVal Build_Construct_Name As String)
        MyBase.New()
        _Build_Construct_ID = Build_Construct_ID
        _Build_Construct_Name = Build_Construct_Name
    End Sub

    Public Property Build_Construct_ID() As Integer
        Get
            Return _Build_Construct_ID
        End Get
        Set(ByVal Value As Integer)
            _Build_Construct_ID = Value
        End Set
    End Property

    Public Property Build_Construct_Name() As String
        Get
            Return _Build_Construct_Name
        End Get
        Set(ByVal Value As String)
            _Build_Construct_Name = Value
        End Set
    End Property
End Class
