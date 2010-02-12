Imports Microsoft.VisualBasic

Public Class Price3_70
    Private Const CLSNAME As String = "Class PRICE3_70"
    Private _ID As Integer
    Private _Req_Id As Integer
    Private _Hub_Id As Integer
    Private _Temp_AID As Integer
    Private _AID As String
    Private _CID As String
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
    Private _Put_On_Chanode As String
    Private _OwnerShip As String
    Private _BuildingArea As Double
    Private _BuildingUintPrice As Double
    Private _BuildingPrice As Decimal
    Private _BuildingAge As Integer
    Private _BuildingPersent1 As Decimal
    Private _BuildingPersent2 As Decimal
    Private _BuildingPersent3 As Decimal
    Private _BuildingPriceTotalDeteriorate As Decimal
    Private _BuildingPercentFinish As Integer
    Private _BuildingPriceFinish As Decimal
    Private _BuildAddArea As Double
    Private _BuildAddUintPrice As Double
    Private _BuildAddPrice As Double
    Private _BuildAddAge As Integer
    Private _BuildAddPersent1 As Decimal
    Private _BuildAddPersent2 As Decimal
    Private _BuildAddPersent3 As Decimal
    Private _BuildAddPriceTotalDeteriorate As Decimal
    Private _BuildAddPercentFinish As Integer
    Private _BuildAddPriceFinish As Decimal
    Private _BuildingDetail As String
    Private _Decoration As Integer
    Private _Standard_Id As Integer
    Private _RoofStructure_Id As Integer
    Private _RoofState_Id As Integer
    Private _Create_User As String
    Private _Create_Date As Date


    Public Sub New( _
     ByVal ID As Integer, _
     ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
     ByVal Temp_AID As Integer, _
     ByVal AID As String, _
     ByVal CID As String, _
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
     ByVal Put_On_Chanode As String, _
     ByVal OwnerShip As String, _
     ByVal BuildingArea As Double, _
     ByVal BuildingUintPrice As Double, _
     ByVal BuildingPrice As Double, _
     ByVal BuildingAge As Integer, _
     ByVal BuildingPersent1 As Decimal, _
     ByVal BuildingPersent2 As Decimal, _
     ByVal BuildingPersent3 As Decimal, _
     ByVal BuildingPriceTotalDeteriorate As Decimal, _
     ByVal BuildingPercentFinish As Integer, _
     ByVal BuildingPriceFinish As Decimal, _
     ByVal BuildAddArea As Double, _
     ByVal BuildAddUintPrice As Double, _
     ByVal BuildAddPrice As Double, _
     ByVal BuildAddAge As Integer, _
     ByVal BuildAddPersent1 As Decimal, _
     ByVal BuildAddPersent2 As Decimal, _
     ByVal BuildAddPersent3 As Decimal, _
     ByVal BuildAddPriceTotalDeteriorate As Decimal, _
     ByVal BuildAddPercentFinish As Integer, _
     ByVal BuildAddPriceFinish As Decimal, _
     ByVal BuildingDetail As String, _
     ByVal Decoration As Integer, _
     ByVal Standard_Id As Integer, _
     ByVal RoofStructure_Id As Integer, _
     ByVal RoofState_Id As Integer, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)
        MyBase.New()
        _ID = ID
        _Req_Id = Req_Id
        _Hub_Id = Hub_Id
        _Temp_AID = Temp_AID
        _AID = AID
        _CID = CID
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
        _Put_On_Chanode = Put_On_Chanode
        _OwnerShip = OwnerShip
        _BuildingArea = BuildingArea
        _BuildingUintPrice = BuildingUintPrice
        _BuildingPrice = BuildingPrice
        _BuildingAge = BuildingAge
        _BuildingPersent1 = BuildingPersent1
        _BuildingPersent2 = BuildingPersent2
        _BuildingPersent3 = BuildingPersent3
        _BuildingPriceTotalDeteriorate = BuildingPriceTotalDeteriorate
        _BuildAddUintPrice = BuildAddUintPrice
        _BuildingPercentFinish = BuildingPercentFinish
        _BuildingPriceFinish = BuildingPriceFinish
        _BuildAddPrice = BuildAddPrice
        _BuildAddArea = BuildAddArea
        _BuildAddAge = BuildAddAge
        _BuildAddPersent1 = BuildAddPersent1
        _BuildAddPersent2 = BuildAddPersent2
        _BuildAddPersent3 = BuildAddPersent3
        _BuildAddPriceTotalDeteriorate = BuildAddPriceTotalDeteriorate
        _BuildAddPercentFinish = BuildAddPercentFinish
        _BuildAddPriceFinish = BuildAddPriceFinish
        _BuildingDetail = BuildingDetail
        _Decoration = Decoration
        _Standard_Id = Standard_Id
        _RoofStructure_Id = RoofStructure_Id
        _RoofState_Id = RoofState_Id
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

    Public Property Put_On_Chanode() As String
        Get
            Return _Put_On_Chanode
        End Get
        Set(ByVal Value As String)
            _Put_On_Chanode = Value
        End Set
    End Property

    Public Property Ownership() As String
        Get
            Return _OwnerShip
        End Get
        Set(ByVal Value As String)
            _OwnerShip = Value
        End Set
    End Property

    Public Property BuildingArea() As Double
        Get
            Return _BuildingArea
        End Get
        Set(ByVal Value As Double)
            _BuildingArea = Value
        End Set
    End Property

    Public Property BuildingUintPrice() As Double
        Get
            Return _BuildingUintPrice
        End Get
        Set(ByVal Value As Double)
            _BuildingUintPrice = Value
        End Set
    End Property

    Public Property BuildingPrice() As Double
        Get
            Return _BuildingPrice
        End Get
        Set(ByVal Value As Double)
            _BuildingPrice = Value
        End Set
    End Property

    Public Property BuildingAge() As Integer
        Get
            Return _BuildingAge
        End Get
        Set(ByVal Value As Integer)
            _BuildingAge = Value
        End Set
    End Property

    Public Property BuildingPersent1() As Decimal
        Get
            Return _BuildingPersent1
        End Get
        Set(ByVal Value As Decimal)
            _BuildingPersent1 = Value
        End Set
    End Property

    Public Property BuildingPersent2() As Decimal
        Get
            Return _BuildingPersent2
        End Get
        Set(ByVal Value As Decimal)
            _BuildingPersent2 = Value
        End Set
    End Property

    Public Property BuildingPersent3() As Decimal
        Get
            Return _BuildingPersent3
        End Get
        Set(ByVal Value As Decimal)
            _BuildingPersent3 = Value
        End Set
    End Property

    Public Property BuildingPriceTotalDeteriorate() As Decimal
        Get
            Return _BuildingPriceTotalDeteriorate
        End Get
        Set(ByVal Value As Decimal)
            _BuildingPriceTotalDeteriorate = Value
        End Set
    End Property

    Public Property BuildingPercentFinish() As Integer
        Get
            Return _BuildingPercentFinish
        End Get
        Set(ByVal Value As Integer)
            _BuildingPercentFinish = Value
        End Set
    End Property

    Public Property BuildingPriceFinish() As Decimal
        Get
            Return _BuildingPriceFinish
        End Get
        Set(ByVal Value As Decimal)
            _BuildingPriceFinish = Value
        End Set
    End Property

    Public Property BuildAddArea() As Double
        Get
            Return _BuildAddArea
        End Get
        Set(ByVal Value As Double)
            _BuildAddArea = Value
        End Set
    End Property

    Public Property BuildAddUintPrice() As Double
        Get
            Return _BuildAddUintPrice
        End Get
        Set(ByVal Value As Double)
            _BuildAddUintPrice = Value
        End Set
    End Property

    Public Property BuildAddPrice() As Double
        Get
            Return _BuildAddPrice
        End Get
        Set(ByVal Value As Double)
            _BuildAddPrice = Value
        End Set
    End Property

    Public Property BuildAddAge() As Integer
        Get
            Return _BuildAddAge
        End Get
        Set(ByVal Value As Integer)
            _BuildAddAge = Value
        End Set
    End Property

    Public Property BuildAddPersent1() As Decimal
        Get
            Return _BuildAddPersent1
        End Get
        Set(ByVal Value As Decimal)
            _BuildAddPersent1 = Value
        End Set
    End Property

    Public Property BuildAddPersent2() As Decimal
        Get
            Return _BuildAddPersent2
        End Get
        Set(ByVal Value As Decimal)
            _BuildAddPersent2 = Value
        End Set
    End Property

    Public Property BuildAddPersent3() As Decimal
        Get
            Return _BuildAddPersent3
        End Get
        Set(ByVal Value As Decimal)
            _BuildAddPersent3 = Value
        End Set
    End Property

    Public Property BuildAddPriceTotalDeteriorate() As Decimal
        Get
            Return _BuildAddPriceTotalDeteriorate
        End Get
        Set(ByVal Value As Decimal)
            _BuildAddPriceTotalDeteriorate = Value
        End Set
    End Property

    Public Property BuildAddPercentFinish() As Integer
        Get
            Return _BuildAddPercentFinish
        End Get
        Set(ByVal Value As Integer)
            _BuildAddPercentFinish = Value
        End Set
    End Property

    Public Property BuildAddPriceFinish() As Decimal
        Get
            Return _BuildAddPriceFinish
        End Get
        Set(ByVal Value As Decimal)
            _BuildAddPriceFinish = Value
        End Set
    End Property

    Public Property BuildingDetail() As String
        Get
            Return _BuildingDetail
        End Get
        Set(ByVal Value As String)
            _BuildingDetail = Value
        End Set
    End Property

    Public Property Decoration() As Integer
        Get
            Return _Decoration
        End Get
        Set(ByVal Value As Integer)
            _Decoration = Value
        End Set
    End Property

    Public Property Standard_Id() As Integer
        Get
            Return _Standard_Id
        End Get
        Set(ByVal Value As Integer)
            _Standard_Id = Value
        End Set
    End Property

    Public Property RoofStructure_Id() As Integer
        Get
            Return _RoofStructure_Id
        End Get
        Set(ByVal Value As Integer)
            _RoofStructure_Id = Value
        End Set
    End Property

    Public Property RoofState_Id() As Integer
        Get
            Return _RoofState_Id
        End Get
        Set(ByVal Value As Integer)
            _RoofState_Id = Value
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
