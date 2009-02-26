Imports Microsoft.VisualBasic


Public Class Price2_ShortForm

    Private Const CLSNAME As String = "Class Price2_ShortForm"

    Private _Q_ID As Integer
    Private _Cif As Integer
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
    Private _Road_Access As Double
    Private _Road_Frontoff As Integer
    Private _RoadWidth As Double
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
    Private _Build_No As String
    Private _Build_Character As Integer
    Private _Floors As String
    Private _Item As Integer
    Private _Build_Construct As Integer
    Private _Roof As Integer
    Private _Roof_Detail As String
    Private _Build_State As Integer
    Private _Build_State_Detail As String
    Private _PriceItem1 As Decimal
    Private _PriceItem2 As Decimal
    Private _Sizing As String
    Private _PriceWah As Decimal
    Private _PriceTotal1 As Decimal
    Private _Building_Detail As String
    Private _PriceTotal2 As Decimal
    Private _PriceTotal3 As Decimal
    Private _GrandTotal As Decimal
    Private _Doc1 As Integer
    Private _Doc2 As Integer
    Private _Doc_Detail As String
    Private _UserAppraisal As Integer
    Private _BossAppraisal As Integer
    Private _Create_User As String
    Private _Create_Date As Date


    Public Sub New( _
     ByVal Q_ID As Integer, _
     ByVal Cif As Integer, _
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
     ByVal Road_Access As Double, _
     ByVal Road_Frontoff As Integer, _
     ByVal RoadWidth As Double, _
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
     ByVal Build_No As String, _
     ByVal Build_Character As Integer, _
     ByVal Floors As String, _
     ByVal Item As Integer, _
     ByVal Build_Construct As Integer, _
     ByVal Roof As Integer, _
     ByVal Roof_Detail As String, _
     ByVal Build_State As Integer, _
     ByVal Build_State_Detail As String, _
     ByVal PriceItem1 As Decimal, _
     ByVal PriceItem2 As Decimal, _
     ByVal Sizing As String, _
     ByVal PriceWah As Decimal, _
     ByVal PriceTotal1 As Decimal, _
     ByVal Building_Detail As String, _
     ByVal PriceTotal2 As Decimal, _
     ByVal PriceTotal3 As Decimal, _
     ByVal GrandTotal As Decimal, _
     ByVal Doc1 As Integer, _
     ByVal Doc2 As Integer, _
     ByVal Doc_Detail As String, _
     ByVal UserAppraisal As Integer, _
     ByVal BossAppraisal As Integer, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)
        MyBase.New()
        _Q_ID = Q_ID
        _Cif = Cif
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
        _Build_No = Build_No
        _Build_Character = Build_Character
        _Floors = Floors
        _Item = Item
        _Build_Construct = Build_Construct
        _Roof = Roof
        _Roof_Detail = Roof_Detail
        _Build_State = Build_State
        _Build_State_Detail = Build_State_Detail
        _PriceItem1 = PriceItem1
        _PriceItem2 = PriceItem2
        _Sizing = Sizing
        _PriceWah = PriceWah
        _PriceTotal1 = PriceTotal1
        _Building_Detail = Building_Detail
        _PriceTotal2 = PriceTotal2
        _PriceTotal3 = PriceTotal3
        _GrandTotal = GrandTotal
        _Doc1 = Doc1
        _Doc2 = Doc2
        _Doc_Detail = Doc_Detail
        _UserAppraisal = UserAppraisal
        _BossAppraisal = BossAppraisal
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

    Public Property Road_Access() As Double
        Get
            Return _Road_Access
        End Get
        Set(ByVal Value As Double)
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

    Public Property RoadWidth() As Double
        Get
            Return _RoadWidth
        End Get
        Set(ByVal Value As Double)
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

    Public Property PriceItem1() As Decimal
        Get
            Return _PriceItem1
        End Get
        Set(ByVal Value As Decimal)
            _PriceItem1 = Value
        End Set
    End Property

    Public Property PriceItem2() As Decimal
        Get
            Return _PriceItem2
        End Get
        Set(ByVal Value As Decimal)
            _PriceItem2 = Value
        End Set
    End Property

    Public Property Sizing() As String
        Get
            Return _Sizing
        End Get
        Set(ByVal Value As String)
            _Sizing = Value
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

    Public Property Building_Detail() As String
        Get
            Return _Building_Detail
        End Get
        Set(ByVal Value As String)
            _Building_Detail = Value
        End Set
    End Property

    Public Property PriceTotal2() As Decimal
        Get
            Return _PriceTotal2
        End Get
        Set(ByVal Value As Decimal)
            _PriceTotal2 = Value
        End Set
    End Property

    Public Property PriceTotal3() As Decimal
        Get
            Return _PriceTotal3
        End Get
        Set(ByVal Value As Decimal)
            _PriceTotal3 = Value
        End Set
    End Property

    Public Property GrandTotal() As Decimal
        Get
            Return _GrandTotal
        End Get
        Set(ByVal Value As Decimal)
            _GrandTotal = Value
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

    Public Property UserAppraisal() As Integer
        Get
            Return _UserAppraisal
        End Get
        Set(ByVal Value As Integer)
            _UserAppraisal = Value
        End Set
    End Property

    Public Property BossAppraisal() As Integer
        Get
            Return _BossAppraisal
        End Get
        Set(ByVal Value As Integer)
            _BossAppraisal = Value
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
