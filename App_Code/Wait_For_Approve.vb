Imports Microsoft.VisualBasic

Public Class Wait_For_Approve

    Private Const CLSNAME As String = "Class Wait_For_Approve"
    Private _Req_Id As Integer
    Private _Hub_Id As Integer
    Private _Seq_Id As Integer
    Private _AID As String
    Private _Temp_AID As Integer
    Private _Approve_Id As String
    Private _Cif As String
    Private _ChkColl As String
    Private _Appraisal_Id As String
    Private _Chk_Approve As Integer
    Private _Save_Date As Date
    Private _Approve_Date As Date
    Private _Update_Date As Date
    Private _Create_User As String
    Private _Create_Date As Date


    Public Sub New( _
     ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
     ByVal Seq_Id As Integer, _
     ByVal AID As String, _
     ByVal Temp_AID As Integer, _
     ByVal Approve_Id As String, _
     ByVal Cif As String, _
     ByVal ChkColl As String, _
     ByVal Appraisal_Id As String, _
     ByVal Chk_Approve As Integer, _
     ByVal Save_Date As Date, _
     ByVal Approve_Date As Date, _
     ByVal Update_Date As Date, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)
        MyBase.New()

        _Req_Id = Req_Id
        _Hub_Id = Hub_Id
        _Seq_Id = Seq_Id
        _AID = AID
        _Temp_AID = Temp_AID
        _Approve_Id = Approve_Id
        _Cif = Cif
        _ChkColl = ChkColl
        _Appraisal_Id = Appraisal_Id
        _Chk_Approve = Chk_Approve
        _Save_Date = Save_Date
        _Approve_Date = Approve_Date
        _Update_Date = Update_Date
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

    Public Property Hub_Id() As Integer
        Get
            Return _Hub_Id
        End Get
        Set(ByVal Value As Integer)
            _Hub_Id = Value
        End Set
    End Property

    Public Property Seq_Id() As Integer
        Get
            Return _Seq_Id
        End Get
        Set(ByVal Value As Integer)
            _Seq_Id = Value
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

    Public Property Approve_Id() As String
        Get
            Return _Approve_Id
        End Get
        Set(ByVal Value As String)
            _Approve_Id = Value
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

    Public Property ChkColl() As String
        Get
            Return _ChkColl
        End Get
        Set(ByVal Value As String)
            _ChkColl = Value
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

    Public Property Chk_Approve() As Integer
        Get
            Return _Chk_Approve
        End Get
        Set(ByVal Value As Integer)
            _Chk_Approve = Value
        End Set
    End Property

    Public Property Save_Date() As Date
        Get
            Return _Save_Date
        End Get
        Set(ByVal Value As Date)
            _Save_Date = Value
        End Set
    End Property

    Public Property Approve_Date() As Date
        Get
            Return _Approve_Date
        End Get
        Set(ByVal Value As Date)
            _Approve_Date = Value
        End Set
    End Property

    Public Property Update_Date() As Date
        Get
            Return _Update_Date
        End Get
        Set(ByVal Value As Date)
            _Update_Date = Value
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
