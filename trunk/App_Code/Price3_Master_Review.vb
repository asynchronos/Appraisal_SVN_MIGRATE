Imports Microsoft.VisualBasic

Public Class Price3_Master_Review
    Private _Req_Id As Integer
    Private _AID As Integer
    Private _Temp_AID As Integer
    Private _Cif As Integer
    Private _District As String
    Private _Amphur As String
    Private _Building_Age As Decimal
    Private _Memo_Date As Date
    Private _Sequence As Integer
    Private _Land_Chg As Integer
    Private _Land_Chg_Detail As String
    Private _Obligation_Chg As Integer
    Private _Obligation_Chg_Detail As String
    Private _Site_Chg As Integer
    Private _Site_Chg_Detail As String
    Private _Progress_Chg As Integer
    Private _Building_Chg As Integer
    Private _Building_Chg_Detail As String
    Private _Appraisal_Last_Detail As String
    Private _Create_User As String
    Private _Create_Date As Date


    Public Sub New( _
     ByVal Req_Id As Integer, _
     ByVal AID As Integer, _
     ByVal Temp_AID As Integer, _
     ByVal Cif As Integer, _
     ByVal District As String, _
     ByVal Amphur As String, _
     ByVal Building_Age As Decimal, _
     ByVal Memo_Date As Date, _
     ByVal Sequence As Integer, _
     ByVal Land_Chg As Integer, _
     ByVal Land_Chg_Detail As String, _
     ByVal Obligation_Chg As Integer, _
     ByVal Obligation_Chg_Detail As String, _
     ByVal Site_Chg As Integer, _
     ByVal Site_Chg_Detail As String, _
     ByVal Progress_Chg As Integer, _
     ByVal Building_Chg As Integer, _
     ByVal Building_Chg_Detail As String, _
     ByVal Appraisal_Last_Detail As String, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)
        MyBase.New()
        _Req_Id = Req_Id
        _AID = AID
        _Temp_AID = Temp_AID
        _Cif = Cif
        _District = District
        _Amphur = Amphur
        _Building_Age = Building_Age
        _Memo_Date = Memo_Date
        _Sequence = Sequence
        _Land_Chg = Land_Chg
        _Land_Chg_Detail = Land_Chg_Detail
        _Obligation_Chg = Obligation_Chg
        _Obligation_Chg_Detail = Obligation_Chg_Detail
        _Site_Chg = Site_Chg
        _Site_Chg_Detail = Site_Chg_Detail
        _Progress_Chg = Progress_Chg
        _Building_Chg = Building_Chg
        _Building_Chg_Detail = Building_Chg_Detail
        _Appraisal_Last_Detail = Appraisal_Last_Detail
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

    Public Property AID() As Integer
        Get
            Return _AID
        End Get
        Set(ByVal Value As Integer)
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

    Public Property Building_Age() As Decimal
        Get
            Return _Building_Age
        End Get
        Set(ByVal Value As Decimal)
            _Building_Age = Value
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

    Public Property District() As String
        Get
            Return _District
        End Get
        Set(ByVal Value As String)
            _District = Value
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

    Public Property Memo_Date() As Date
        Get
            Return _Memo_Date
        End Get
        Set(ByVal Value As Date)
            _Memo_Date = Value
        End Set
    End Property

    Public Property Sequence() As Integer
        Get
            Return _Sequence
        End Get
        Set(ByVal Value As Integer)
            _Sequence = Value
        End Set
    End Property

    Public Property Land_Chg() As Integer
        Get
            Return _Land_Chg
        End Get
        Set(ByVal Value As Integer)
            _Land_Chg = Value
        End Set
    End Property

    Public Property Land_Chg_Detail() As String
        Get
            Return _Land_Chg_Detail
        End Get
        Set(ByVal Value As String)
            _Land_Chg_Detail = Value
        End Set
    End Property

    Public Property Obligation_Chg() As Integer
        Get
            Return _Obligation_Chg
        End Get
        Set(ByVal Value As Integer)
            _Obligation_Chg = Value
        End Set
    End Property

    Public Property Obligation_Chg_Detail() As String
        Get
            Return _Obligation_Chg_Detail
        End Get
        Set(ByVal Value As String)
            _Obligation_Chg_Detail = Value
        End Set
    End Property

    Public Property Site_Chg() As Integer
        Get
            Return _Site_Chg
        End Get
        Set(ByVal Value As Integer)
            _Site_Chg = Value
        End Set
    End Property

    Public Property Site_Chg_Detail() As String
        Get
            Return _Site_Chg_Detail
        End Get
        Set(ByVal Value As String)
            _Site_Chg_Detail = Value
        End Set
    End Property

    Public Property Progress_Chg() As Integer
        Get
            Return _Progress_Chg
        End Get
        Set(ByVal Value As Integer)
            _Progress_Chg = Value
        End Set
    End Property

    Public Property Building_Chg() As Integer
        Get
            Return _Building_Chg
        End Get
        Set(ByVal Value As Integer)
            _Building_Chg = Value
        End Set
    End Property

    Public Property Building_Chg_Detail() As String
        Get
            Return _Building_Chg_Detail
        End Get
        Set(ByVal Value As String)
            _Building_Chg_Detail = Value
        End Set
    End Property

    Public Property Appraisal_Last_Detail() As String
        Get
            Return _Appraisal_Last_Detail
        End Get
        Set(ByVal Value As String)
            _Appraisal_Last_Detail = Value
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
