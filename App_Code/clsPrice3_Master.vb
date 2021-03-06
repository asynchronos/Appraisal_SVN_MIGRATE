Imports Microsoft.VisualBasic

Public Class clsPrice3_Master

    Private Const CLSNAME As String = "Class Price3_Master"

    Private _Req_Id As Integer
    Private _AID As String
    Private _Temp_AID As Integer
    Private _Inform_To As String
    Private _Cif As Integer
    Private _Lat As Double
    Private _Lng As Double
    Private _Appraisal_Date As Date
    Private _Receive_Date As Date
    Private _PriceWah As Decimal
    Private _TotalPrice As Decimal
    Private _BuildingPrice As Decimal
    Private _Land_Building_Price As Decimal
    Private _Approved1 As String
    Private _Position_Approved1 As Integer
    Private _Approved2 As String
    Private _Position_Approved2 As Integer
    Private _Approved3 As String
    Private _Position_Approved3 As Integer
    Private _Approved As Integer
    Private _Env_Effect As Integer
    Private _Env_Effect_Detail As String
    Private _Appraisal_Detail As String
    Private _Appraisal_Type_ID As Integer
    Private _Comment_ID As Integer
    Private _Warning_ID As Integer
    Private _Warning_Detail As String
    Private _Req_Dept As Integer
    Private _Appraisal_ID As String
    Private _Create_User As String
    Private _Create_Date As Date


    Public Sub New( _
     ByVal Req_Id As Integer, _
     ByVal AID As String, _
     ByVal Temp_AID As Integer, _
     ByVal Inform_To As String, _
     ByVal Cif As Integer, _
     ByVal Lat As Double, _
     ByVal Lng As Double, _
     ByVal Appraisal_Date As Date, _
     ByVal Receive_Date As Date, _
     ByVal PriceWah As Decimal, _
     ByVal TotalPrice As Decimal, _
     ByVal BuildingPrice As Decimal, _
     ByVal Land_Building_Price As Decimal, _
     ByVal Approved1 As String, _
     ByVal Position_Approved1 As Integer, _
     ByVal Approved2 As String, _
     ByVal Position_Approved2 As Integer, _
     ByVal Approved3 As String, _
     ByVal Position_Approved3 As Integer, _
     ByVal Approved As Integer, _
     ByVal Env_Effect As Integer, _
     ByVal Env_Effect_Detail As String, _
     ByVal Appraisal_Detail As String, _
     ByVal Appraisal_Type_ID As Integer, _
     ByVal Comment_ID As Integer, _
     ByVal Warning_ID As Integer, _
     ByVal Warning_Detail As String, _
     ByVal Req_Dept As Integer, _
     ByVal Appraisal_ID As String, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)
        MyBase.New()
        _Req_Id = Req_Id
        _AID = AID
        _Temp_AID = Temp_AID
        _Inform_To = Inform_To
        _Cif = Cif
        _Lat = Lat
        _Lng = Lng
        _Appraisal_Date = Appraisal_Date
        _Receive_Date = Receive_Date
        _PriceWah = PriceWah
        _BuildingPrice = BuildingPrice
        _Land_Building_Price = Land_Building_Price
        _TotalPrice = TotalPrice
        _Approved1 = Approved1
        _Position_Approved1 = Position_Approved1
        _Approved2 = Approved2
        _Position_Approved2 = Position_Approved2
        _Approved3 = Approved3
        _Position_Approved3 = Position_Approved3
        _Approved = Approved
        _Env_Effect = Env_Effect
        _Env_Effect_Detail = Env_Effect_Detail
        _Appraisal_Detail = Appraisal_Detail
        _Appraisal_Type_ID = Appraisal_Type_ID
        _Comment_ID = Comment_ID
        _Warning_ID = Warning_ID
        _Warning_Detail = Warning_Detail
        _Req_Dept = Req_Dept
        _Appraisal_ID = Appraisal_ID
        _Create_User = Create_User
        _Create_Date = Create_Date
    End Sub

    Public Property Req_Id() As Integer
        Get
            Return _Req_Id
        End Get
        Set(ByVal Value As Integer)
            _Req_Id = Value
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

    Public Property Temp_AID() As Integer
        Get
            Return _Temp_AID
        End Get
        Set(ByVal Value As Integer)
            _Temp_AID = Value
        End Set
    End Property

    Public Property Inform_To() As String
        Get
            Return _Inform_To
        End Get
        Set(ByVal Value As String)
            _Inform_To = Value
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

    Public Property Lat() As Double
        Get
            Return _Lat
        End Get
        Set(ByVal Value As Double)
            _Lat = Value
        End Set
    End Property

    Public Property Lng() As Double
        Get
            Return _Lng
        End Get
        Set(ByVal Value As Double)
            _Lng = Value
        End Set
    End Property

    Public Property Appraisal_Date() As Date
        Get
            Return _Appraisal_Date
        End Get
        Set(ByVal Value As Date)
            _Appraisal_Date = Value
        End Set
    End Property

    Public Property Receive_Date() As Date
        Get
            Return _Receive_Date
        End Get
        Set(ByVal Value As Date)
            _Receive_Date = Value
        End Set
    End Property

    Public Property BuildingPrice() As Decimal
        Get
            Return _BuildingPrice
        End Get
        Set(ByVal Value As Decimal)
            _BuildingPrice = Value
        End Set
    End Property

    Public Property Land_Building_Price() As Decimal
        Get
            Return _Land_Building_Price
        End Get
        Set(ByVal Value As Decimal)
            _Land_Building_Price = Value
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

    Public Property TotalPrice() As Decimal
        Get
            Return _TotalPrice
        End Get
        Set(ByVal Value As Decimal)
            _TotalPrice = Value
        End Set
    End Property

    Public Property Approved1() As String
        Get
            Return _Approved1
        End Get
        Set(ByVal Value As String)
            _Approved1 = Value
        End Set
    End Property

    Public Property Position_Approved1() As Integer
        Get
            Return _Position_Approved1
        End Get
        Set(ByVal Value As Integer)
            _Position_Approved1 = Value
        End Set
    End Property

    Public Property Approved2() As String
        Get
            Return _Approved2
        End Get
        Set(ByVal Value As String)
            _Approved2 = Value
        End Set
    End Property

    Public Property Position_Approved2() As Integer
        Get
            Return _Position_Approved2
        End Get
        Set(ByVal Value As Integer)
            _Position_Approved2 = Value
        End Set
    End Property

    Public Property Approved3() As String
        Get
            Return _Approved3
        End Get
        Set(ByVal Value As String)
            _Approved3 = Value
        End Set
    End Property

    Public Property Position_Approved3() As Integer
        Get
            Return _Position_Approved3
        End Get
        Set(ByVal Value As Integer)
            _Position_Approved3 = Value
        End Set
    End Property

    Public Property Approved() As Integer
        Get
            Return _Approved
        End Get
        Set(ByVal Value As Integer)
            _Approved = Value
        End Set
    End Property

    Public Property Env_Effect() As Integer
        Get
            Return _Env_Effect
        End Get
        Set(ByVal Value As Integer)
            _Env_Effect = Value
        End Set
    End Property

    Public Property Env_Effect_Detail() As String
        Get
            Return _Env_Effect_Detail
        End Get
        Set(ByVal Value As String)
            _Env_Effect_Detail = Value
        End Set
    End Property

    Public Property Appraisal_Detail() As String
        Get
            Return _Appraisal_Detail
        End Get
        Set(ByVal Value As String)
            _Appraisal_Detail = Value
        End Set
    End Property

    Public Property Appraisal_Type_ID() As Integer
        Get
            Return _Appraisal_Type_ID
        End Get
        Set(ByVal Value As Integer)
            _Appraisal_Type_ID = Value
        End Set
    End Property

    Public Property Comment_ID() As Integer
        Get
            Return _Comment_ID
        End Get
        Set(ByVal Value As Integer)
            _Comment_ID = Value
        End Set
    End Property

    Public Property Warning_ID() As Integer
        Get
            Return _Warning_ID
        End Get
        Set(ByVal Value As Integer)
            _Warning_ID = Value
        End Set
    End Property

    Public Property Warning_Detail() As String
        Get
            Return _Warning_Detail
        End Get
        Set(ByVal Value As String)
            _Warning_Detail = Value
        End Set
    End Property

    Public Property Req_Dept() As Integer
        Get
            Return _Req_Dept
        End Get
        Set(ByVal Value As Integer)
            _Req_Dept = Value
        End Set
    End Property

    Public Property Appraisal_ID() As String
        Get
            Return _Appraisal_ID
        End Get
        Set(ByVal Value As String)
            _Appraisal_ID = Value
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
