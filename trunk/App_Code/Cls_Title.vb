Imports Microsoft.VisualBasic

Public Class Cls_Title

    Private Const CLSNAME As String = "Class TB_TITLE"

    Private _TITLE_CODE As Integer
    Private _TITLE_NAME As String
    Private _TITLE_NAME_E As String


    Public Sub New( _
     ByVal TITLE_CODE As Integer, _
     ByVal TITLE_NAME As String, _
     ByVal TITLE_NAME_E As String)
        MyBase.New()
        _TITLE_CODE = TITLE_CODE
        _TITLE_NAME = TITLE_NAME
        _TITLE_NAME_E = TITLE_NAME_E
    End Sub

    Public Property TITLE_CODE() As Integer
        Get
            Return _TITLE_CODE
        End Get
        Set(ByVal Value As Integer)
            _TITLE_CODE = Value
        End Set
    End Property

    Public Property TITLE_NAME() As String
        Get
            Return _TITLE_NAME
        End Get
        Set(ByVal Value As String)
            _TITLE_NAME = Value
        End Set
    End Property

    Public Property TITLE_NAME_E() As String
        Get
            Return _TITLE_NAME_E
        End Get
        Set(ByVal Value As String)
            _TITLE_NAME_E = Value
        End Set
    End Property
End Class
