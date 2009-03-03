Imports Microsoft.VisualBasic

Public Class Price3_50_Review
    Private Const CLSNAME As String = "Class PRICE3_50_REVIEW"
    Private _ID As Integer
    Private _Req_Id As Integer
    Private _Hub_Id As Integer
    Private _Temp_AID As Integer
    Private _MysubColl_ID As Integer
    Private _Address_No As String
    Private _Building_Name As String
    Private _Tumbon As String
    Private _Amphur As String
    Private _Province As Integer
    Private _Rai As Integer
    Private _Ngan As Integer
    Private _Wah As Integer
    Private _Road As String
    Private _Road_Detail As Integer
    Private _Road_Access As Decimal
    Private _Road_Frontoff As Integer
    Private _RoadWidth As Decimal
    Private _Sited As Integer
    Private _Site_Detail As String
    Private _Land_State As Integer
    Private _Land_State_Detail As String
    Private _Public_Utility As Integer
    Private _Public_Utility_Detail As String
    Private _Binifit As Integer
    Private _Binifit_Detail As String
    Private _Tendency As Integer
    Private _BuySale_State As Integer
    Private _PriceWah As Decimal
    Private _PriceTotal1 As Decimal
    Private _Rawang As String
    Private _LandNumber As String
    Private _Surway As String
    Private _DocNo As String
    Private _PageNo As String
    Private _Ownership As String
    Private _Obligation As String
    Private _Land_Closeto_RoadWidth As Double
    Private _DeepWidth As Double
    Private _BehindWidth As Double
    Private _AreaColour_No As Integer
    Private _Create_User As String
    Private _Create_Date As Date


    Public Sub New( _
     ByVal Id As Integer, _
     ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
     ByVal Temp_AID As Integer, _
     ByVal MysubColl_ID As Integer, _
     ByVal Address_No As String, _
     ByVal Building_Name As String, _
     ByVal Tumbon As String, _
     ByVal Amphur As String, _
     ByVal Province As Integer, _
     ByVal Rai As Integer, _
     ByVal Ngan As Integer, _
     ByVal Wah As Integer, _
     ByVal Road As String, _
     ByVal Road_Detail As Integer, _
     ByVal Road_Access As Decimal, _
     ByVal Road_Frontoff As Integer, _
     ByVal RoadWidth As Decimal, _
     ByVal Sited As Integer, _
     ByVal Site_Detail As String, _
     ByVal Land_State As Integer, _
     ByVal Land_State_Detail As String, _
     ByVal Public_Utility As Integer, _
     ByVal Public_Utility_Detail As String, _
     ByVal Binifit As Integer, _
     ByVal Binifit_Detail As String, _
     ByVal Tendency As Integer, _
     ByVal BuySale_State As Integer, _
     ByVal PriceWah As Decimal, _
     ByVal PriceTotal1 As Decimal, _
     ByVal Rawang As String, _
     ByVal LandNumber As String, _
     ByVal Surway As String, _
     ByVal DocNo As String, _
     ByVal PageNo As String, _
     ByVal Ownership As String, _
     ByVal Obligation As String, _
     ByVal Land_Closeto_RoadWidth As Double, _
     ByVal DeepWidth As Double, _
     ByVal BehindWidth As Double, _
     ByVal AreaColour_No As Integer, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)
        MyBase.New()
        _ID = Id
        _Req_Id = Req_Id
        _Hub_Id = Hub_Id
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
        _Sited = Sited
        _Site_Detail = Site_Detail
        _Land_State = Land_State
        _Land_State_Detail = Land_State_Detail
        _Public_Utility = Public_Utility
        _Public_Utility_Detail = Public_Utility_Detail
        _Binifit = Binifit
        _Binifit_Detail = Binifit_Detail
        _Tendency = Tendency
        _BuySale_State = BuySale_State
        _PriceWah = PriceWah
        _PriceTotal1 = PriceTotal1
        _Rawang = Rawang
        _LandNumber = LandNumber
        _Surway = Surway
        _DocNo = DocNo
        _PageNo = PageNo
        _Ownership = Ownership
        _Obligation = Obligation
        _Land_Closeto_RoadWidth = Land_Closeto_RoadWidth
        _DeepWidth = DeepWidth
        _BehindWidth = BehindWidth
        _AreaColour_No = AreaColour_No
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

    Public Property Wah() As Integer
        Get
            Return _Wah
        End Get
        Set(ByVal Value As Integer)
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

    Public Property Sited() As Integer
        Get
            Return _Sited
        End Get
        Set(ByVal Value As Integer)
            _Sited = Value
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

    Public Property Rawang() As String
        Get
            Return _Rawang
        End Get
        Set(ByVal Value As String)
            _Rawang = Value
        End Set
    End Property

    Public Property LandNumber() As String
        Get
            Return _LandNumber
        End Get
        Set(ByVal Value As String)
            _LandNumber = Value
        End Set
    End Property

    Public Property Surway() As String
        Get
            Return _Surway
        End Get
        Set(ByVal Value As String)
            _Surway = Value
        End Set
    End Property

    Public Property DocNo() As String
        Get
            Return _DocNo
        End Get
        Set(ByVal Value As String)
            _DocNo = Value
        End Set
    End Property

    Public Property PageNo() As String
        Get
            Return _PageNo
        End Get
        Set(ByVal Value As String)
            _PageNo = Value
        End Set
    End Property

    Public Property Ownership() As String
        Get
            Return _Ownership
        End Get
        Set(ByVal Value As String)
            _Ownership = Value
        End Set
    End Property

    Public Property Obligation() As String
        Get
            Return _Obligation
        End Get
        Set(ByVal Value As String)
            _Obligation = Value
        End Set
    End Property

    Public Property Land_Closeto_RoadWidth() As Double
        Get
            Return _Land_Closeto_RoadWidth
        End Get
        Set(ByVal Value As Double)
            _Land_Closeto_RoadWidth = Value
        End Set
    End Property

    Public Property DeepWidth() As Double
        Get
            Return _DeepWidth
        End Get
        Set(ByVal Value As Double)
            _DeepWidth = Value
        End Set
    End Property

    Public Property BehindWidth() As Double
        Get
            Return _BehindWidth
        End Get
        Set(ByVal Value As Double)
            _BehindWidth = Value
        End Set
    End Property

    Public Property AreaColour_No() As Integer
        Get
            Return _AreaColour_No
        End Get
        Set(ByVal Value As Integer)
            _AreaColour_No = Value
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
