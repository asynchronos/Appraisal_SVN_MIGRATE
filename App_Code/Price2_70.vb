Imports Microsoft.VisualBasic

Public Class PRICE2_70

    Private Const CLSNAME As String = "Class PRICE2_70"

    Private _Q_ID As Integer
    Private _Cif As Integer
    Private _Temp_AID As Integer
    Private _MysubColl_ID As Integer
    Private _Build_No As String
    Private _Build_Character As Integer
    Private _Floors As String
    Private _Item As Integer
    Private _Build_Construct As Integer
    Private _Roof As Integer
    Private _Roof_Detail As String
    Private _Build_State As Integer
    Private _Build_State_Detail As String
    Private _Building_Detail As String
    Private _PriceTotal1 As Decimal
    Private _Doc1 As Integer
    Private _Doc2 As Integer
    Private _Doc_Detail As String
    Private _Pic_Path As String
    Private _Create_User As String
    Private _Create_Date As Date


    Public Sub New( _
     ByVal Q_ID As Integer, _
     ByVal Cif As Integer, _
     ByVal Temp_AID As Integer, _
     ByVal MysubColl_ID As Integer, _
     ByVal Build_No As String, _
     ByVal Build_Character As Integer, _
     ByVal Floors As String, _
     ByVal Item As Integer, _
     ByVal Build_Construct As Integer, _
     ByVal Roof As Integer, _
     ByVal Roof_Detail As String, _
     ByVal Build_State As Integer, _
     ByVal Build_State_Detail As String, _
     ByVal Building_Detail As String, _
     ByVal PriceTotal1 As Decimal, _
     ByVal Doc1 As Integer, _
     ByVal Doc2 As Integer, _
     ByVal Doc_Detail As String, _
     ByVal Pic_Path As String, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)
        MyBase.New()
        _Q_ID = Q_ID
        _Cif = Cif
        _Temp_AID = Temp_AID
        _MysubColl_ID = MysubColl_ID
        _Build_No = Build_No
        _Build_Character = Build_Character
        _Floors = Floors
        _Item = Item
        _Build_Construct = Build_Construct
        _Roof = Roof
        _Roof_Detail = Roof_Detail
        _Build_State = Build_State
        _Build_State_Detail = Build_State_Detail
        _Building_Detail = Building_Detail
        _PriceTotal1 = PriceTotal1
        _Doc1 = Doc1
        _Doc2 = Doc2
        _Doc_Detail = Doc_Detail
        _Pic_Path = Pic_Path
        _Create_User = Create_User
        _Create_Date = Create_Date
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
            Return _Cif
        End Get
        Set(ByVal Value As Integer)
            _Cif = Value
        End Set
    End Property

    Public Property Temp_AID() As Integer
        Get
            Return _Temp_AID
        End Get
        Set(ByVal Value As Integer)
            _Temp_AID = Value
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

    Public Property Build_No() As String
        Get
            Return _Build_No
        End Get
        Set(ByVal Value As String)
            _Build_No = Value
        End Set
    End Property

    Public Property Build_Character() As Integer
        Get
            Return _Build_Character
        End Get
        Set(ByVal Value As Integer)
            _Build_Character = Value
        End Set
    End Property

    Public Property Floors() As String
        Get
            Return _Floors
        End Get
        Set(ByVal Value As String)
            _Floors = Value
        End Set
    End Property

    Public Property Pic_Path() As String
        Get
            Return _Pic_Path
        End Get
        Set(ByVal Value As String)
            _Pic_Path = Value
        End Set
    End Property

    Public Property Item() As Integer
        Get
            Return _Item
        End Get
        Set(ByVal Value As Integer)
            _Item = Value
        End Set
    End Property

    Public Property Build_Construct() As Integer
        Get
            Return _Build_Construct
        End Get
        Set(ByVal Value As Integer)
            _Build_Construct = Value
        End Set
    End Property

End Class
