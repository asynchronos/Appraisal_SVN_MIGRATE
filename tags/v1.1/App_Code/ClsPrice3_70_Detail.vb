Imports Microsoft.VisualBasic

Public Class ClsPrice3_70_Detail

    Private Const CLSNAME As String = "Class PRICE3_70_DETAIL"

    Private _Id As Integer
    Private _Req_Id As Integer
    Private _Hub_Id As Integer
    Private _Temp_AID As Integer
    Private _Floor As String
    Private _Main_Construction As String
    Private _Concrete As Integer
    Private _Granite As Integer
    Private _Parquet As Integer
    Private _Ceramic As Integer
    Private _Wood As Integer
    Private _Other As Integer
    Private _Other_Detail As String
    Private _BrickWall As Integer
    Private _BlockBrickWall As Integer
    Private _WoodWall As Integer
    Private _OtherWall As Integer
    Private _OtherWall_Detail As String
    Private _Create_User As String
    Private _Create_Date As Date


    Public Sub New( _
     ByVal Id As Integer, _
     ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
     ByVal Temp_AID As Integer, _
     ByVal Floor As String, _
     ByVal Main_Construction As String, _
     ByVal Concrete As Integer, _
     ByVal Granite As Integer, _
     ByVal Parquet As Integer, _
     ByVal Ceramic As Integer, _
     ByVal Wood As Integer, _
     ByVal Other As Integer, _
     ByVal Other_Detail As String, _
     ByVal BrickWall As Integer, _
     ByVal BlockBrickWall As Integer, _
     ByVal WoodWall As Integer, _
     ByVal OtherWall As Integer, _
     ByVal OtherWall_Detail As String, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)
        MyBase.New()
        _Id = Id
        _Req_Id = Req_Id
        _Hub_Id = Hub_Id
        _Temp_AID = Temp_AID
        _Floor = Floor
        _Main_Construction = Main_Construction
        _Concrete = Concrete
        _Granite = Granite
        _Parquet = Parquet
        _Ceramic = Ceramic
        _Wood = Wood
        _Other = Other
        _Other_Detail = Other_Detail
        _BrickWall = BrickWall
        _BlockBrickWall = BlockBrickWall
        _WoodWall = WoodWall
        _OtherWall = OtherWall
        _OtherWall_Detail = OtherWall_Detail
        _Create_User = Create_User
        _Create_Date = Create_Date
    End Sub

    Public Property Id() As Integer
        Get
            Return _Id
        End Get
        Set(ByVal Value As Integer)
            _Id = Value
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

    Public Property Floor() As String
        Get
            Return _Floor
        End Get
        Set(ByVal Value As String)
            _Floor = Value
        End Set
    End Property

    Public Property Main_Construction() As String
        Get
            Return _Main_Construction
        End Get
        Set(ByVal Value As String)
            _Main_Construction = Value
        End Set
    End Property

    Public Property Concrete() As Integer
        Get
            Return _Concrete
        End Get
        Set(ByVal Value As Integer)
            _Concrete = Value
        End Set
    End Property

    Public Property Granite() As Integer
        Get
            Return _Granite
        End Get
        Set(ByVal Value As Integer)
            _Granite = Value
        End Set
    End Property

    Public Property Parquet() As Integer
        Get
            Return _Parquet
        End Get
        Set(ByVal Value As Integer)
            _Parquet = Value
        End Set
    End Property

    Public Property Ceramic() As Integer
        Get
            Return _Ceramic
        End Get
        Set(ByVal Value As Integer)
            _Ceramic = Value
        End Set
    End Property

    Public Property Wood() As Integer
        Get
            Return _Wood
        End Get
        Set(ByVal Value As Integer)
            _Wood = Value
        End Set
    End Property

    Public Property Other() As Integer
        Get
            Return _Other
        End Get
        Set(ByVal Value As Integer)
            _Other = Value
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

    Public Property BrickWall() As Integer
        Get
            Return _BrickWall
        End Get
        Set(ByVal Value As Integer)
            _BrickWall = Value
        End Set
    End Property

    Public Property BlockBrickWall() As Integer
        Get
            Return _BlockBrickWall
        End Get
        Set(ByVal Value As Integer)
            _BlockBrickWall = Value
        End Set
    End Property

    Public Property WoodWall() As Integer
        Get
            Return _WoodWall
        End Get
        Set(ByVal Value As Integer)
            _WoodWall = Value
        End Set
    End Property

    Public Property OtherWall() As Integer
        Get
            Return _OtherWall
        End Get
        Set(ByVal Value As Integer)
            _OtherWall = Value
        End Set
    End Property

    Public Property OtherWall_Detail() As String
        Get
            Return _OtherWall_Detail
        End Get
        Set(ByVal Value As String)
            _OtherWall_Detail = Value
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
