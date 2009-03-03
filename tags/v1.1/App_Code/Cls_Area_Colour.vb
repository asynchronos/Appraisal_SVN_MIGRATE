Imports Microsoft.VisualBasic

Public Class Cls_Area_Colour

    Private Const CLSNAME As String = "Class AreaColour"

    Private _AreaColour_No As Integer
    Private _AreaColour_Name As String


    Public Sub New( _
     ByVal AreaColour_No As Integer, _
     ByVal AreaColour_Name As String)
        MyBase.New()
        _AreaColour_No = AreaColour_No
        _AreaColour_Name = AreaColour_Name
    End Sub

    Public Property AreaColour_No() As Integer
        Get
            Return _AreaColour_No
        End Get
        Set(ByVal Value As Integer)
            _AreaColour_No = Value
        End Set
    End Property

    Public Property AreaColour_Name() As String
        Get
            Return _AreaColour_Name
        End Get
        Set(ByVal Value As String)
            _AreaColour_Name = Value
        End Set
    End Property

End Class
