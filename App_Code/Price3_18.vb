Imports Microsoft.VisualBasic

Public Class Price3_18
    Private _ID As Integer
    Private _Req_Id As Integer
    Private _Hub_Id As Integer
    Private _AID As String
    Private _CID As String
    Private _Temp_AID As Integer
    Private _MysubColl_ID As Integer
    Private _Floors_All As Integer
    Private _Elevator As Integer
    Private _Address_No As String
    Private _Room_Area As Decimal
    Private _Room_Height As Decimal
    Private _Building_Name As String
    Private _Floors As Integer
    Private _Building_No As String
    Private _Building_Reg_No As String
    Private _Building_Age As Decimal
    Private _Tumbon As String
    Private _Amphur As String
    Private _Province As Integer
    Private _Road As String
    Private _Road_Detail As Integer
    Private _Road_Access As Decimal
    Private _Road_Frontoff As Integer
    Private _RoadWidth As Decimal
    Private _Site As Integer
    Private _Site_Detail As String
    Private _Public_Utility As Integer
    Private _Public_Utility_Detail As String
    Private _Binifit As Integer
    Private _Binifit_Detail As String
    Private _Tendency As Integer
    Private _BuySale_State As Integer
    Private _Building_Construc As Integer
    Private _InteriorState_Id As Integer
    Private _Character_Room_Id As Integer
    Private _RoomWidth_BehideSiteWalk As Decimal
    Private _Roomdeep As Decimal
    Private _Backside_Width As Decimal
    Private _SideWalk_Is As Integer
    Private _SideWalk_Width As Decimal
    Private _Partake_Detail As String
    Private _Ownership As String
    Private _Obligation As String
    Private _Other_Detail As String
    Private _Tumbon1 As String
    Private _Amphur1 As String
    Private _Province1 As Integer
    Private _Elevator_Util As Integer
    Private _Parking_Util As Integer
    Private _Pool_Util As Integer
    Private _Fitness_Util As Integer
    Private _Other_Util As Integer
    Private _Other_Util_Detail As String
    Private _Adjust_Condo As String
    Private _Unit_Price As Decimal
    Private _PriceTotal As Decimal
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
     ByVal Floors_All As Integer, _
     ByVal Elevator As Integer, _
     ByVal Address_No As String, _
     ByVal Room_Area As Decimal, _
     ByVal Room_Height As Decimal, _
     ByVal Building_Name As String, _
     ByVal Floors As Integer, _
     ByVal Building_No As String, _
     ByVal Building_Reg_No As String, _
     ByVal Building_Age As Decimal, _
     ByVal Tumbon As String, _
     ByVal Amphur As String, _
     ByVal Province As Integer, _
     ByVal Road As String, _
     ByVal Road_Detail As Integer, _
     ByVal Road_Access As Decimal, _
     ByVal Road_Frontoff As Integer, _
     ByVal RoadWidth As Decimal, _
     ByVal Site As Integer, _
     ByVal Site_Detail As String, _
     ByVal Public_Utility As Integer, _
     ByVal Public_Utility_Detail As String, _
     ByVal Binifit As Integer, _
     ByVal Binifit_Detail As String, _
     ByVal Tendency As Integer, _
     ByVal BuySale_State As Integer, _
     ByVal Building_Construc As Integer, _
     ByVal InteriorState_Id As Integer, _
     ByVal Character_Room_Id As Integer, _
     ByVal RoomWidth_BehideSiteWalk As Decimal, _
     ByVal Roomdeep As Decimal, _
     ByVal Backside_Width As Decimal, _
     ByVal SideWalk_Is As Integer, _
     ByVal SideWalk_Width As Decimal, _
     ByVal Partake_Detail As String, _
     ByVal Ownership As String, _
     ByVal Obligation As String, _
     ByVal Other_Detail As String, _
     ByVal Tumbon1 As String, _
     ByVal Amphur1 As String, _
     ByVal Province1 As Integer, _
     ByVal Elevator_Util As Integer, _
     ByVal Parking_Util As Integer, _
     ByVal Pool_Util As Integer, _
     ByVal Fitness_Util As Integer, _
     ByVal Other_Util As Integer, _
     ByVal Other_Util_Detail As String, _
     ByVal Adjust_Condo As String, _
     ByVal Unit_Price As Decimal, _
     ByVal PriceTotal As Decimal, _
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
        _Floors_All = Floors_All
        _Elevator = Elevator
        _Address_No = Address_No
        _Building_Name = Building_Name
        _Floors = Floors
        _Room_Area = Room_Area
        _Room_Height = Room_Height
        _Building_No = Building_No
        _Building_Reg_No = Building_Reg_No
        _Building_Age = Building_Age
        _Tumbon = Tumbon
        _Amphur = Amphur
        _Province = Province
        _Road = Road
        _Road_Detail = Road_Detail
        _Road_Access = Road_Access
        _Road_Frontoff = Road_Frontoff
        _RoadWidth = RoadWidth
        _Site = Site
        _Site_Detail = Site_Detail
        _Public_Utility = Public_Utility
        _Public_Utility_Detail = Public_Utility_Detail
        _Binifit = Binifit
        _Binifit_Detail = Binifit_Detail
        _Tendency = Tendency
        _BuySale_State = BuySale_State
        _Building_Construc = Building_Construc
        _InteriorState_Id = InteriorState_Id
        _Character_Room_Id = Character_Room_Id
        _RoomWidth_BehideSiteWalk = RoomWidth_BehideSiteWalk
        _Roomdeep = Roomdeep
        _Backside_Width = Backside_Width
        _SideWalk_Is = SideWalk_Is
        _SideWalk_Width = SideWalk_Width
        _Partake_Detail = Partake_Detail
        _Ownership = Ownership
        _Obligation = Obligation
        _Other_Detail = Other_Detail
        _Tumbon1 = Tumbon1
        _Amphur1 = Amphur1
        _Province1 = Province1
        _Elevator_Util = Elevator_Util
        _Parking_Util = Parking_Util
        _Pool_Util = Pool_Util
        _Fitness_Util = Fitness_Util
        _Other_Util = Other_Util
        _Other_Util_Detail = Other_Util_Detail
        _Adjust_Condo = Adjust_Condo
        _Unit_Price = Unit_Price
        _PriceTotal = PriceTotal
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

    Public Property Partake_Detail() As String
        Get
            Return _Partake_Detail
        End Get
        Set(ByVal Value As String)
            _Partake_Detail = Value
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

    Public Property Floors_All() As Integer
        Get
            Return _Floors_All
        End Get
        Set(ByVal Value As Integer)
            _Floors_All = Value
        End Set
    End Property

    Public Property Elevator() As Integer
        Get
            Return _Elevator
        End Get
        Set(ByVal Value As Integer)
            _Elevator = Value
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

    Public Property Room_Area() As Decimal
        Get
            Return _Room_Area
        End Get
        Set(ByVal Value As Decimal)
            _Room_Area = Value
        End Set
    End Property

    Public Property Room_Height() As Decimal
        Get
            Return _Room_Height
        End Get
        Set(ByVal Value As Decimal)
            _Room_Height = Value
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

    Public Property Floors() As Integer
        Get
            Return _Floors
        End Get
        Set(ByVal Value As Integer)
            _Floors = Value
        End Set
    End Property

    Public Property Building_No() As String
        Get
            Return _Building_No
        End Get
        Set(ByVal Value As String)
            _Building_No = Value
        End Set
    End Property

    Public Property Building_Reg_No() As String
        Get
            Return _Building_Reg_No
        End Get
        Set(ByVal Value As String)
            _Building_Reg_No = Value
        End Set
    End Property

    Public Property Building_Age() As Decimal
        Get
            Return _Building_Age
        End Get
        Set(ByVal value As Decimal)
            _Building_Age = value
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

    Public Property Building_Construc() As Integer
        Get
            Return _Building_Construc
        End Get
        Set(ByVal Value As Integer)
            _Building_Construc = Value
        End Set
    End Property

    Public Property InteriorState_Id() As Integer
        Get
            Return _InteriorState_Id
        End Get
        Set(ByVal Value As Integer)
            _InteriorState_Id = Value
        End Set
    End Property

    Public Property Character_Room_Id() As Integer
        Get
            Return _Character_Room_Id
        End Get
        Set(ByVal Value As Integer)
            _Character_Room_Id = Value
        End Set
    End Property

    Public Property RoomWidth_BehideSiteWalk() As Decimal
        Get
            Return _RoomWidth_BehideSiteWalk
        End Get
        Set(ByVal Value As Decimal)
            _RoomWidth_BehideSiteWalk = Value
        End Set
    End Property

    Public Property Roomdeep() As Decimal
        Get
            Return _Roomdeep
        End Get
        Set(ByVal Value As Decimal)
            _Roomdeep = Value
        End Set
    End Property

    Public Property Backside_Width() As Decimal
        Get
            Return _Backside_Width
        End Get
        Set(ByVal Value As Decimal)
            _Backside_Width = Value
        End Set
    End Property

    Public Property SideWalk_Is() As Integer
        Get
            Return _SideWalk_Is
        End Get
        Set(ByVal Value As Integer)
            _SideWalk_Is = Value
        End Set
    End Property

    Public Property SideWalk_Width() As Decimal
        Get
            Return _SideWalk_Width
        End Get
        Set(ByVal Value As Decimal)
            _SideWalk_Width = Value
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

    Public Property Other_Detail() As String
        Get
            Return _Other_Detail
        End Get
        Set(ByVal Value As String)
            _Other_Detail = Value
        End Set
    End Property

    Public Property Tumbon1() As String
        Get
            Return _Tumbon1
        End Get
        Set(ByVal Value As String)
            _Tumbon1 = Value
        End Set
    End Property

    Public Property Amphur1() As String
        Get
            Return _Amphur1
        End Get
        Set(ByVal Value As String)
            _Amphur1 = Value
        End Set
    End Property

    Public Property Province1() As Integer
        Get
            Return _Province1
        End Get
        Set(ByVal Value As Integer)
            _Province1 = Value
        End Set
    End Property

    Public Property Elevator_Util() As Integer
        Get
            Return _Elevator_Util
        End Get
        Set(ByVal Value As Integer)
            _Elevator_Util = Value
        End Set
    End Property

    Public Property Parking_Util() As Integer
        Get
            Return _Parking_Util
        End Get
        Set(ByVal Value As Integer)
            _Parking_Util = Value
        End Set
    End Property

    Public Property Pool_Util() As Integer
        Get
            Return _Pool_Util
        End Get
        Set(ByVal Value As Integer)
            _Pool_Util = Value
        End Set
    End Property

    Public Property Fitness_Util() As Integer
        Get
            Return _Fitness_Util
        End Get
        Set(ByVal Value As Integer)
            _Fitness_Util = Value
        End Set
    End Property

    Public Property Other_Util() As Integer
        Get
            Return _Other_Util
        End Get
        Set(ByVal Value As Integer)
            _Other_Util = Value
        End Set
    End Property

    Public Property Other_Util_Detail() As String
        Get
            Return _Other_Util_Detail
        End Get
        Set(ByVal Value As String)
            _Other_Util_Detail = Value
        End Set
    End Property

    Public Property Adjust_Condo() As String
        Get
            Return _Adjust_Condo
        End Get
        Set(ByVal Value As String)
            _Adjust_Condo = Value
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

    Public Property Unit_Price() As Decimal
        Get
            Return _Unit_Price
        End Get
        Set(ByVal Value As Decimal)
            _Unit_Price = Value
        End Set
    End Property

    Public Property PriceTotal() As Decimal
        Get
            Return _PriceTotal
        End Get
        Set(ByVal Value As Decimal)
            _PriceTotal = Value
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
