Imports Microsoft.VisualBasic

Public Class Class_Branch
    Private Const CLSNAME As String = "Class TB_Branch"

    Private _BRANCH_ID As Integer
    Private _BRANCH_NAME As String



    Public Sub New( _
     ByVal BRANCH_ID As Integer, _
     ByVal BRANCH_NAME As String)
        MyBase.New()
        _BRANCH_ID = BRANCH_ID
        _BRANCH_NAME = BRANCH_NAME

    End Sub

    Public Property BRANCH_ID() As Integer
        Get
            Return _BRANCH_ID
        End Get
        Set(ByVal Value As Integer)
            _BRANCH_ID = Value
        End Set
    End Property

    Public Property BRANCH_NAME() As String
        Get
            Return _BRANCH_NAME
        End Get
        Set(ByVal Value As String)
            _BRANCH_NAME = Value
        End Set
    End Property

End Class
