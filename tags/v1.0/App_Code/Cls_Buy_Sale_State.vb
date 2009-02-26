Imports Microsoft.VisualBasic

Public Class Cls_Buy_Sale_State

    Private Const CLSNAME As String = "Class BuySale_State"

    Private _BuySale_State_ID As Integer
    Private _BuySale_State_Name As String


    Public Sub New( _
     ByVal BuySale_State_ID As Integer, _
     ByVal BuySale_State_Name As String)
        MyBase.New()
        _BuySale_State_ID = BuySale_State_ID
        _BuySale_State_Name = BuySale_State_Name
    End Sub

    Public Property BuySale_State_ID() As Integer
        Get
            Return _BuySale_State_ID
        End Get
        Set(ByVal Value As Integer)
            _BuySale_State_ID = Value
        End Set
    End Property

    Public Property BuySale_State_Name() As String
        Get
            Return _BuySale_State_Name
        End Get
        Set(ByVal Value As String)
            _BuySale_State_Name = Value
        End Set
    End Property

End Class
