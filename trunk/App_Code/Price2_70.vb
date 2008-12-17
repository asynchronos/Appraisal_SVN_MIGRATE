Imports Microsoft.VisualBasic

Public Class PRICE2_70


    Private Const CLSNAME As String = "Class PRICE2_70"

    Private _ID As Integer
    Private _Req_Id As Integer
    Private _Hub_Id As Integer
    Private _Temp_AID As Integer
    Private _MysubColl_ID As Integer
    Private _Build_No As String
    Private _Tumbon As String
    Private _Amphur As String
    Private _Province As Integer
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
    Private _Pic_path As String
    Private _Create_User As String
    Private _Create_Date As Date


    Public Sub New( _
     ByVal ID As Integer, _
     ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
     ByVal Temp_AID As Integer, _
     ByVal MysubColl_ID As Integer, _
     ByVal Build_No As String, _
     ByVal Tumbon As String, _
     ByVal Amphur As String, _
     ByVal Province As Integer, _
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
     ByVal Pic_path As String, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)
        MyBase.New()
        _ID = ID
        _Req_Id = Req_Id
        _Hub_Id = Hub_Id
        _Temp_AID = Temp_AID
        _MysubColl_ID = MysubColl_ID
        _Build_No = Build_No
        _Tumbon = Tumbon
        _Amphur = Amphur
        _Province = Province
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
        _Pic_path = Pic_path
        _Create_User = Create_User
        _Create_Date = Create_Date
    End Sub

    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal Value As Integer)
            _ID = Value
        End Set
    End Property

    Public Property Req_Id() As Integer
        Get
            Return _Req_Id
        End Get
        Set(ByVal Value As Integer)
            _Req_Id = Value
        End Set
    End Property

    Public Property Hub_Id() As Integer
        Get
            Return _Hub_Id
        End Get
        Set(ByVal Value As Integer)
            _Hub_Id = Value
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

    Public Property Tumbon() As String
        Get
            Return _Tumbon
        End Get
        Set(ByVal Value As String)
            _Tumbon = Value
        End Set
    End Property

    Public Property Amphur() As String
        Get
            Return _Amphur
        End Get
        Set(ByVal Value As String)
            _Amphur = Value
        End Set
    End Property

    Public Property Province() As Integer
        Get
            Return _Province
        End Get
        Set(ByVal Value As Integer)
            _Province = Value
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

    Public Property Roof() As Integer
        Get
            Return _Roof
        End Get
        Set(ByVal Value As Integer)
            _Roof = Value
        End Set
    End Property

    Public Property Roof_Detail() As String
        Get
            Return _Roof_Detail
        End Get
        Set(ByVal Value As String)
            _Roof_Detail = Value
        End Set
    End Property

    Public Property Build_State() As Integer
        Get
            Return _Build_State
        End Get
        Set(ByVal Value As Integer)
            _Build_State = Value
        End Set
    End Property

    Public Property Build_State_Detail() As String
        Get
            Return _Build_State_Detail
        End Get
        Set(ByVal Value As String)
            _Build_State_Detail = Value
        End Set
    End Property

    Public Property Building_Detail() As String
        Get
            Return _Building_Detail
        End Get
        Set(ByVal Value As String)
            _Building_Detail = Value
        End Set
    End Property

    Public Property PriceTotal1() As Decimal
        Get
            Return _PriceTotal1
        End Get
        Set(ByVal Value As Decimal)
            _PriceTotal1 = Value
        End Set
    End Property

    Public Property Doc1() As Integer
        Get
            Return _Doc1
        End Get
        Set(ByVal Value As Integer)
            _Doc1 = Value
        End Set
    End Property

    Public Property Doc2() As Integer
        Get
            Return _Doc2
        End Get
        Set(ByVal Value As Integer)
            _Doc2 = Value
        End Set
    End Property

    Public Property Doc_Detail() As String
        Get
            Return _Doc_Detail
        End Get
        Set(ByVal Value As String)
            _Doc_Detail = Value
        End Set
    End Property

    Public Property Pic_path() As String
        Get
            Return _Pic_path
        End Get
        Set(ByVal Value As String)
            _Pic_path = Value
        End Set
    End Property

    Public Property Create_User() As String
        Get
            Return _Create_User
        End Get
        Set(ByVal Value As String)
            _Create_User = Value
        End Set
    End Property

    Public Property Create_Date() As Date
        Get
            Return _Create_Date
        End Get
        Set(ByVal Value As Date)
            _Create_Date = Value
        End Set
    End Property

End Class
