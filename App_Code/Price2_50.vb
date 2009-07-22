Imports Microsoft.VisualBasic

Public Class PRICE2_50

    Private Const CLSNAME As String = "Class PRICE2_50"
    Private _ID As Integer
    Private _Req_Id As Integer
    Private _Hub_Id As Integer
    Private _AID As String
    Private _CID As String
    Private _Temp_AID As Integer
    Private _MysubColl_ID As Integer
    Private _Address_No As String
    Private _Building_Name As String
    Private _Tumbon As String
    Private _Amphur As String
    Private _Province As Integer
    Private _Rai As Integer
    Private _Ngan As Integer
    Private _Wah As Decimal
    Private _Road As String
    Private _Road_Detail As Integer
    Private _Road_Access As Decimal
    Private _Road_Frontoff As Integer
    Private _RoadWidth As Decimal
    Private _Site As Integer
    Private _Site_Detail As String
    Private _Land_State As Integer
    Private _Land_State_Detail As String
    Private _Public_Utility As Integer
    Private _Public_Utility_Detail As String
    Private _Binifit As Integer
    Private _Binifit_Detail As String
    Private _Tendency As Integer
    Private _BuySale_State As Integer
    Private _SubUnit As Integer
    Private _PriceWah As Decimal
    Private _PriceTotal1 As Decimal
    Private _Create_User As String
    Private _Create_Date As Date


    Public Sub New( _
     ByVal ID As Integer, _
     ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
     ByVal AID As String, _
     ByVal CID As String, _
     ByVal Temp_AID As Integer, _
     ByVal MysubColl_ID As Integer, _
     ByVal Address_No As String, _
     ByVal Building_Name As String, _
     ByVal Tumbon As String, _
     ByVal Amphur As String, _
     ByVal Province As Integer, _
     ByVal Rai As Integer, _
     ByVal Ngan As Integer, _
     ByVal Wah As Decimal, _
     ByVal Road As String, _
     ByVal Road_Detail As Integer, _
     ByVal Road_Access As Decimal, _
     ByVal Road_Frontoff As Integer, _
     ByVal RoadWidth As Decimal, _
     ByVal Site As Integer, _
     ByVal Site_Detail As String, _
     ByVal Land_State As Integer, _
     ByVal Land_State_Detail As String, _
     ByVal Public_Utility As Integer, _
     ByVal Public_Utility_Detail As String, _
     ByVal Binifit As Integer, _
     ByVal Binifit_Detail As String, _
     ByVal Tendency As Integer, _
     ByVal BuySale_State As Integer, _
     ByVal SubUnit As Integer, _
     ByVal PriceWah As Decimal, _
     ByVal PriceTotal1 As Decimal, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)
        MyBase.New()
        _ID = ID
        _Req_Id = Req_Id
        _Hub_Id = Hub_Id
        _AID = AID
        _CID = CID
        _Temp_AID = Temp_AID
        _MysubColl_ID = MysubColl_ID
        _Address_No = Address_No
        _Building_Name = Building_Name
        _Tumbon = Tumbon
        _Amphur = Amphur
        _Province = Province
        _Rai = Rai
        _Ngan = Ngan
        _Wah = Wah
        _Road = Road
        _Road_Detail = Road_Detail
        _Road_Access = Road_Access
        _Road_Frontoff = Road_Frontoff
        _RoadWidth = RoadWidth
        _Site = Site
        _Site_Detail = Site_Detail
        _Land_State = Land_State
        _Land_State_Detail = Land_State_Detail
        _Public_Utility = Public_Utility
        _Public_Utility_Detail = Public_Utility_Detail
        _Binifit = Binifit
        _Binifit_Detail = Binifit_Detail
        _Tendency = Tendency
        _BuySale_State = BuySale_State
        _SubUnit = SubUnit
        _PriceWah = PriceWah
        _PriceTotal1 = PriceTotal1
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

    Public Property AID() As String
        Get
            Return _AID
        End Get
        Set(ByVal Value As String)
            _AID = Value
        End Set
    End Property

    Public Property CID() As String
        Get
            Return _CID
        End Get
        Set(ByVal Value As String)
            _CID = Value
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

    Public Property Address_No() As String
        Get
            Return _Address_No
        End Get
        Set(ByVal Value As String)
            _Address_No = Value
        End Set
    End Property

    Public Property Building_Name() As String
        Get
            Return _Building_Name
        End Get
        Set(ByVal Value As String)
            _Building_Name = Value
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

    Public Property Rai() As Integer
        Get
            Return _Rai
        End Get
        Set(ByVal Value As Integer)
            _Rai = Value
        End Set
    End Property

    Public Property Ngan() As Integer
        Get
            Return _Ngan
        End Get
        Set(ByVal Value As Integer)
            _Ngan = Value
        End Set
    End Property

    Public Property Wah() As Decimal
        Get
            Return _Wah
        End Get
        Set(ByVal Value As Decimal)
            _Wah = Value
        End Set
    End Property

    Public Property Road() As String
        Get
            Return _Road
        End Get
        Set(ByVal Value As String)
            _Road = Value
        End Set
    End Property

    Public Property Road_Detail() As Integer
        Get
            Return _Road_Detail
        End Get
        Set(ByVal Value As Integer)
            _Road_Detail = Value
        End Set
    End Property

    Public Property Road_Access() As Decimal
        Get
            Return _Road_Access
        End Get
        Set(ByVal Value As Decimal)
            _Road_Access = Value
        End Set
    End Property

    Public Property Road_Frontoff() As Integer
        Get
            Return _Road_Frontoff
        End Get
        Set(ByVal Value As Integer)
            _Road_Frontoff = Value
        End Set
    End Property

    Public Property RoadWidth() As Decimal
        Get
            Return _RoadWidth
        End Get
        Set(ByVal Value As Decimal)
            _RoadWidth = Value
        End Set
    End Property

    Public Property Site() As Integer
        Get
            Return _Site
        End Get
        Set(ByVal Value As Integer)
            _Site = Value
        End Set
    End Property

    Public Property Site_Detail() As String
        Get
            Return _Site_Detail
        End Get
        Set(ByVal Value As String)
            _Site_Detail = Value
        End Set
    End Property

    Public Property Land_State() As Integer
        Get
            Return _Land_State
        End Get
        Set(ByVal Value As Integer)
            _Land_State = Value
        End Set
    End Property

    Public Property Land_State_Detail() As String
        Get
            Return _Land_State_Detail
        End Get
        Set(ByVal Value As String)
            _Land_State_Detail = Value
        End Set
    End Property

    Public Property Public_Utility() As Integer
        Get
            Return _Public_Utility
        End Get
        Set(ByVal Value As Integer)
            _Public_Utility = Value
        End Set
    End Property

    Public Property Public_Utility_Detail() As String
        Get
            Return _Public_Utility_Detail
        End Get
        Set(ByVal Value As String)
            _Public_Utility_Detail = Value
        End Set
    End Property

    Public Property Binifit() As Integer
        Get
            Return _Binifit
        End Get
        Set(ByVal Value As Integer)
            _Binifit = Value
        End Set
    End Property

    Public Property Binifit_Detail() As String
        Get
            Return _Binifit_Detail
        End Get
        Set(ByVal Value As String)
            _Binifit_Detail = Value
        End Set
    End Property

    Public Property Tendency() As Integer
        Get
            Return _Tendency
        End Get
        Set(ByVal Value As Integer)
            _Tendency = Value
        End Set
    End Property

    Public Property BuySale_State() As Integer
        Get
            Return _BuySale_State
        End Get
        Set(ByVal Value As Integer)
            _BuySale_State = Value
        End Set
    End Property

    Public Property SubUnit() As Integer
        Get
            Return _SubUnit
        End Get
        Set(ByVal Value As Integer)
            _SubUnit = Value
        End Set
    End Property

    Public Property PriceWah() As Decimal
        Get
            Return _PriceWah
        End Get
        Set(ByVal Value As Decimal)
            _PriceWah = Value
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
