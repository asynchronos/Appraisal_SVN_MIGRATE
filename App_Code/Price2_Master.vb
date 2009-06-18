Imports Microsoft.VisualBasic

Public Class Price2_Master

    Private Const CLSNAME As String = "Class PRICE2_Master"

    Private _Temp_AID As Integer
    Private _Req_Id As Integer
    Private _Hub_Id As Integer
    Private _Cif As Integer
    Private _Appraisal_Id As Integer
    Private _Comment As String
    Private _Approve2_Id As String
    Private _Price As Decimal
    Private _Create_User As String
    Private _Create_Date As Date


    Public Sub New( _
     ByVal Temp_AID As Integer, _
     ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
     ByVal Cif As Integer, _
     ByVal Appraisal_Id As Integer, _
     ByVal Comment As String, _
     ByVal Approve2_Id As String, _
     ByVal Price As Decimal, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)

        MyBase.New()
        _Temp_AID = Temp_AID
        _Req_Id = Req_Id
        _Hub_Id = Hub_Id
        _Cif = Cif
        _Appraisal_Id = Appraisal_Id
        _Comment = Comment
        _Approve2_Id = Approve2_Id
        _Price = Price
        _Create_User = Create_User
        _Create_Date = Create_Date
    End Sub

    Public Property Temp_AID() As Integer
        Get
            Return _Temp_AID
        End Get
        Set(ByVal Value As Integer)
            _Temp_AID = Value
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

    Public Property Cif() As Integer
        Get
            Return _Cif
        End Get
        Set(ByVal Value As Integer)
            _Cif = Value
        End Set
    End Property

    Public Property Appraisal_Id() As Integer
        Get
            Return _Appraisal_Id
        End Get
        Set(ByVal Value As Integer)
            _Appraisal_Id = Value
        End Set
    End Property

    Public Property Comment() As String
        Get
            Return _Comment
        End Get
        Set(ByVal Value As String)
            _Comment = Value
        End Set
    End Property

    Public Property Approve2_Id() As String
        Get
            Return _Approve2_Id
        End Get
        Set(ByVal Value As String)
            _Approve2_Id = Value
        End Set
    End Property

    Public Property Price() As String
        Get
            Return _Price
        End Get
        Set(ByVal Value As String)
            _Price = Value
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
