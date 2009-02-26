Imports Microsoft.VisualBasic
Imports System.Collections.Generic

Public Class Dropdown_Pro
    Private _Name As String
    Private _Valuex As String

    Public ReadOnly Property Name() As String
        Get
            Return _Name
        End Get
    End Property

    Public ReadOnly Property Valuex() As String
        Get
            Return _Valuex
        End Get
    End Property

    Public Sub New(ByVal xname As String, ByVal xvalue As String)
        _Name = xname
        _Valuex = xvalue
    End Sub
End Class
