Imports Microsoft.VisualBasic

Public Class Appraisal_Request_v2

    Private _Req_ID As Integer
    Private _Hub_ID As Integer
    Private _Cif As String
    Private _Title As Integer
    Private _Name As String
    Private _Lastname As String
    Private _CifColl As String
    Private _TitleColl As Integer
    Private _NameColl As String
    Private _LastnameColl As String
    Private _Req_Type As Integer
    Private _Status_ID As Integer
    Private _Appraisal_Id As String
    Private _Branch_Id As Integer
    Private _Tumbon As Integer
    Private _Amphur As Integer
    Private _Province As Integer
    Private _APP_TYPE_ID As Integer
    Private _CollOfNumber As String
    Private _Flag As Integer
    Private _Create_User As String
    Private _Create_Date As Date


    Public Sub New( _
     ByVal Req_ID As Integer, _
     ByVal Hub_ID As Integer, _
     ByVal Cif As String, _
     ByVal Title As Integer, _
     ByVal Name As String, _
     ByVal Lastname As String, _
     ByVal CifColl As String, _
     ByVal TitleColl As Integer, _
     ByVal NameColl As String, _
     ByVal LastnameColl As String, _
     ByVal Req_Type As Integer, _
     ByVal Status_ID As Integer, _
     ByVal Appraisal_Id As String, _
     ByVal Branch_Id As Integer, _
     ByVal Tumbon As Integer, _
     ByVal Amphur As Integer, _
     ByVal Province As Integer, _
     ByVal APP_TYPE_ID As Integer, _
     ByVal CollOfNumber As String, _
     ByVal Flag As Integer, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)
        MyBase.New()
        _Req_ID = Req_ID
        _Hub_ID = Hub_ID
        _Cif = Cif
        _Title = Title
        _Name = Name
        _Lastname = Lastname
        _CifColl = CifColl
        _TitleColl = TitleColl
        _NameColl = NameColl
        _LastnameColl = LastnameColl
        _Req_Type = Req_Type
        _Status_ID = Status_ID
        _Appraisal_Id = Appraisal_Id
        _Branch_Id = Branch_Id
        _Tumbon = Tumbon
        _Amphur = Amphur
        _Province = Province
        _APP_TYPE_ID = APP_TYPE_ID
        _CollOfNumber = CollOfNumber
        _Flag = Flag
        _Create_User = Create_User
        _Create_Date = Create_Date
    End Sub

    Public Property Req_ID() As Integer
        Get
            Return _Req_ID
        End Get
        Set(ByVal Value As Integer)
            _Req_ID = Value
        End Set
    End Property

    Public Property Hub_ID() As Integer
        Get
            Return _Hub_ID
        End Get
        Set(ByVal Value As Integer)
            _Hub_ID = Value
        End Set
    End Property

    Public Property Cif() As String
        Get
            Return _Cif
        End Get
        Set(ByVal Value As String)
            _Cif = Value
        End Set
    End Property

    Public Property Title() As Integer
        Get
            Return _Title
        End Get
        Set(ByVal Value As Integer)
            _Title = Value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal Value As String)
            _Name = Value
        End Set
    End Property

    Public Property Lastname() As String
        Get
            Return _Lastname
        End Get
        Set(ByVal Value As String)
            _Lastname = Value
        End Set
    End Property

    Public Property Cifcoll() As String
        Get
            Return _CifColl
        End Get
        Set(ByVal Value As String)
            _CifColl = Value
        End Set
    End Property

    Public Property Titlecoll() As Integer
        Get
            Return _TitleColl
        End Get
        Set(ByVal Value As Integer)
            _TitleColl = Value
        End Set
    End Property

    Public Property Namecoll() As String
        Get
            Return _NameColl
        End Get
        Set(ByVal Value As String)
            _NameColl = Value
        End Set
    End Property

    Public Property Lastnamecoll() As String
        Get
            Return _LastnameColl
        End Get
        Set(ByVal Value As String)
            _LastnameColl = Value
        End Set
    End Property

    Public Property Req_Type() As Integer
        Get
            Return _Req_Type
        End Get
        Set(ByVal Value As Integer)
            _Req_Type = Value
        End Set
    End Property

    Public Property Status_ID() As Integer
        Get
            Return _Status_ID
        End Get
        Set(ByVal Value As Integer)
            _Status_ID = Value
        End Set
    End Property

    Public Property Appraisal_Id() As String
        Get
            Return _Appraisal_Id
        End Get
        Set(ByVal Value As String)
            _Appraisal_Id = Value
        End Set
    End Property

    Public Property Tumbon() As Integer
        Get
            Return _Tumbon
        End Get
        Set(ByVal Value As Integer)
            _Tumbon = Value
        End Set
    End Property

    Public Property Amphur() As Integer
        Get
            Return _Amphur
        End Get
        Set(ByVal Value As Integer)
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

    Public Property Branch_Id() As String
        Get
            Return _Branch_Id
        End Get
        Set(ByVal Value As String)
            _Branch_Id = Value
        End Set
    End Property

    Public Property APP_TYPE_ID() As Integer
        Get
            Return _APP_TYPE_ID
        End Get
        Set(ByVal Value As Integer)
            _APP_TYPE_ID = Value
        End Set
    End Property

    Public Property CollOfNumber() As String
        Get
            Return _CollOfNumber
        End Get
        Set(ByVal Value As String)
            _CollOfNumber = Value
        End Set
    End Property

    Public Property Flag() As Integer
        Get
            Return _Flag
        End Get
        Set(ByVal Value As Integer)
            _Flag = Value
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
