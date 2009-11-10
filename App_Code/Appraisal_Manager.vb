Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Collections
Imports System.Collections.Generic
Imports System.Xml.Serialization
Imports System.Xml
Imports System.Web
Imports System.Web.UI.HtmlControls
Imports System.Web.Services
Imports System.Configuration


Public Class Appraisal_Manager

    Public Shared Sub Add_Sent_Appraisal(ByVal Q_ID As Integer, _
                                    ByVal Cif As Integer, _
                                    ByVal Create_Date As Date, _
                                    ByVal Sent_Appraisal_ID As String, _
                                    ByVal Appraisal_ID As Integer, _
                                    ByVal Create_User_ID As String, _
                                    ByVal Status_ID As Integer, _
                                    ByVal Note As String)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("ADD_SENT_APPROISAL", connection)

                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@q_id", Q_ID))
                    command.Parameters.Add(New SqlParameter("@cif", Cif))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.Parameters.Add(New SqlParameter("@Sent_Appraisal_ID", Sent_Appraisal_ID))
                    command.Parameters.Add(New SqlParameter("@Appraisal_ID", Appraisal_ID))
                    command.Parameters.Add(New SqlParameter("@Create_User_ID", Create_User_ID))
                    command.Parameters.Add(New SqlParameter("@Status_ID", Status_ID))
                    command.Parameters.Add(New SqlParameter("@Note", Note))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    Dim msg As String
                    Dim title As String
                    Dim style As MsgBoxStyle
                    Dim response1 As MsgBoxResult
                    myTrans.Rollback()
                    'msg = "การบันทึกผิดพลาด"   ' Define message.
                    msg = ex.Message
                    style = MsgBoxStyle.DefaultButton2 Or _
                       MsgBoxStyle.Critical Or MsgBoxStyle.YesNo
                    title = "ผลการบันทึก"   ' Define title.
                    ' Display message.
                    response1 = MsgBox(msg, style, title)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub Update_Queue()

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_QUEUE", connection)

                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    Dim msg As String
                    Dim title As String
                    Dim style As MsgBoxStyle
                    Dim response1 As MsgBoxResult
                    myTrans.Rollback()
                    'msg = "การบันทึกผิดพลาด"   ' Define message.
                    msg = ex.Message
                    style = MsgBoxStyle.DefaultButton2 Or _
                       MsgBoxStyle.Critical Or MsgBoxStyle.YesNo
                    title = "ผลการบันทึก"   ' Define title.
                    ' Display message.
                    response1 = MsgBox(msg, style, title)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub UPDATE_RECEIVE_DATE(ByVal Q_ID As Integer, _
    ByVal RECEIVE_DATE As Date)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_RECEIVE_DATE", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Q_ID", Q_ID))
                    command.Parameters.Add(New SqlParameter("@RECEIVE_DATE", RECEIVE_DATE))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    Dim msg As String
                    Dim title As String
                    Dim style As MsgBoxStyle
                    Dim response1 As MsgBoxResult
                    'msg = "การบันทึกผิดพลาด"   ' Define message.
                    msg = ex.Message
                    style = MsgBoxStyle.DefaultButton2 Or _
                       MsgBoxStyle.Critical Or MsgBoxStyle.YesNo
                    title = "ผลการบันทึก"   ' Define title.
                    ' Display message.
                    response1 = MsgBox(msg, style, title)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Function GET_TEMP_AID() As Integer
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_TEMP_AID", connection)

                command.CommandType = CommandType.StoredProcedure
                connection.Open()
                Dim list As New Integer
                Using reader As SqlDataReader = command.ExecuteReader()
                    Do While (reader.Read())
                        Dim temp As Integer = (reader("TEMP_AID_NO"))
                        list = (temp)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using
    End Function

    Public Shared Sub UPDATE_TEMP_AID()

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_TEMP_AID", connection)

                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    Dim msg As String
                    Dim title As String
                    Dim style As MsgBoxStyle
                    Dim response1 As MsgBoxResult
                    myTrans.Rollback()
                    'msg = "การบันทึกผิดพลาด"   ' Define message.
                    msg = ex.Message
                    style = MsgBoxStyle.DefaultButton2 Or _
                       MsgBoxStyle.Critical Or MsgBoxStyle.YesNo
                    title = "ผลการบันทึก"   ' Define title.
                    ' Display message.
                    response1 = MsgBox(msg, style, title)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub UPDATE_STATUS_AT_MASTER(ByVal Q_ID As Integer, _
    ByVal STATUS_ID As Integer)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_STATUS_AT_MASTER", connection)

                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Q_ID", Q_ID))
                    command.Parameters.Add(New SqlParameter("@STATUS_ID", STATUS_ID))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    Dim msg As String
                    Dim title As String
                    Dim style As MsgBoxStyle
                    Dim response1 As MsgBoxResult
                    myTrans.Rollback()
                    'msg = "การบันทึกผิดพลาด"   ' Define message.
                    msg = ex.Message
                    style = MsgBoxStyle.DefaultButton2 Or _
                       MsgBoxStyle.Critical Or MsgBoxStyle.YesNo
                    title = "ผลการบันทึก"   ' Define title.
                    ' Display message.
                    response1 = MsgBox(msg, style, title)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub UPDATE_PRE_AID(ByVal Q_ID As Integer, _
    ByVal COLL_ID As Integer, _
    ByVal TEMP_AID As Integer, _
    ByVal APPRAISAL_ID As Integer)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_PRE_AID", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Q_ID", Q_ID))
                    command.Parameters.Add(New SqlParameter("@COLL_ID", COLL_ID))
                    command.Parameters.Add(New SqlParameter("@PRE_AID", TEMP_AID))
                    command.Parameters.Add(New SqlParameter("@APPRAISAL_ID", APPRAISAL_ID))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    Dim msg As String
                    Dim title As String
                    Dim style As MsgBoxStyle
                    Dim response1 As MsgBoxResult
                    'msg = "การบันทึกผิดพลาด"   ' Define message.
                    msg = ex.Message
                    style = MsgBoxStyle.DefaultButton2 Or _
                       MsgBoxStyle.Critical Or MsgBoxStyle.YesNo
                    title = "ผลการบันทึก"   ' Define title.
                    ' Display message.
                    response1 = MsgBox(msg, style, title)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub



#Region "PRICE1"
    Public Shared Function GetPrice1_Master(ByVal Req_Id As Integer, ByVal Hub_Id As Integer) As Generic.List(Of ClsPrice1_Master)
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE1_MASTER", connection)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                connection.Open()
                Dim list As New Generic.List(Of ClsPrice1_Master)
                Using reader As SqlDataReader = command.ExecuteReader()
                    Do While (reader.Read())
                        'Get field in Store Procedure
                        Dim temp As New ClsPrice1_Master(CInt(reader("Req_Id")), _
                                                      CInt(reader("Hub_Id")), _
                                                        CInt(reader("cif")), _
                                                        CStr(reader("CifName")), _
                                                        CStr(reader("Lat")), _
                                                        CStr(reader("Lng")), _
                                                        CStr(reader("Pricewah")), _
                                                        CStr(reader("Price")), _
                                                        CStr(reader("Create_User")), _
                                                        CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                'If list.Count > 0 Then
                Return list
                'Else
                '    Dim temp As New ClsPrice1_Master(0, 0, 0, "", "", "", "", "", "", Date.Now)
                '    list.Add(temp)
                '    Return list
                'End If
            End Using
            connection.Close()
        End Using
    End Function
#End Region

#Region "PRICE2"

    Public Shared Sub AddPrice2_ShortForm(ByVal Q_ID As Integer, _
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
     ByVal Road_Access As Decimal, _
     ByVal Road_Frontoff As Integer, _
     ByVal Roadwidth As Decimal, _
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
     ByVal UserAppraisal_ID As Integer, _
     ByVal BossAppraisal_ID As Integer, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("AddPrice2_ShortForm", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Q_ID", Q_ID))
                    command.Parameters.Add(New SqlParameter("@Cif", Cif))
                    command.Parameters.Add(New SqlParameter("@MysubColl_ID", MysubColl_ID))
                    command.Parameters.Add(New SqlParameter("@Address_No", Address_No))
                    command.Parameters.Add(New SqlParameter("@Building_Name", Building_Name))
                    command.Parameters.Add(New SqlParameter("@Tumbon", Tumbon))
                    command.Parameters.Add(New SqlParameter("@Amphur", Amphur))
                    command.Parameters.Add(New SqlParameter("@Province", Province))
                    command.Parameters.Add(New SqlParameter("@Rai", Rai))
                    command.Parameters.Add(New SqlParameter("@Ngan", Ngan))
                    command.Parameters.Add(New SqlParameter("@Wah", Wah))
                    command.Parameters.Add(New SqlParameter("@Road", Road))
                    command.Parameters.Add(New SqlParameter("@Road_Detail", Road_Detail))
                    command.Parameters.Add(New SqlParameter("@Road_Access", Road_Access))
                    command.Parameters.Add(New SqlParameter("@Road_Frontoff", Road_Frontoff))
                    command.Parameters.Add(New SqlParameter("@Roadwidth", Roadwidth))
                    command.Parameters.Add(New SqlParameter("@Site", Site))
                    command.Parameters.Add(New SqlParameter("@Site_Detail", Site_Detail))
                    command.Parameters.Add(New SqlParameter("@Land_State", Land_State))
                    command.Parameters.Add(New SqlParameter("@Land_State_Detail", Land_State_Detail))
                    command.Parameters.Add(New SqlParameter("@Public_Utility", Public_Utility))
                    command.Parameters.Add(New SqlParameter("@Public_Utility_Detail", Public_Utility_Detail))
                    command.Parameters.Add(New SqlParameter("@Binifit", Binifit))
                    command.Parameters.Add(New SqlParameter("@Binifit_Detail", Binifit_Detail))
                    command.Parameters.Add(New SqlParameter("@Tendency", Tendency))
                    command.Parameters.Add(New SqlParameter("@BuySale_State", BuySale_State))
                    command.Parameters.Add(New SqlParameter("@Build_No", Build_No))
                    command.Parameters.Add(New SqlParameter("@Build_Character", Build_Character))
                    command.Parameters.Add(New SqlParameter("@Floors", Floors))
                    command.Parameters.Add(New SqlParameter("@Item", Item))
                    command.Parameters.Add(New SqlParameter("@Build_Construct", Build_Construct))
                    command.Parameters.Add(New SqlParameter("@Roof", Roof))
                    command.Parameters.Add(New SqlParameter("@Roof_Detail", Roof_Detail))
                    command.Parameters.Add(New SqlParameter("@Build_State", Build_State))
                    command.Parameters.Add(New SqlParameter("@Build_State_Detail", Build_State_Detail))
                    command.Parameters.Add(New SqlParameter("@PriceItem1", PriceItem1))
                    command.Parameters.Add(New SqlParameter("@PriceItem2", PriceItem2))
                    command.Parameters.Add(New SqlParameter("@Sizing", Sizing))
                    command.Parameters.Add(New SqlParameter("@PriceWah", PriceWah))
                    command.Parameters.Add(New SqlParameter("@PriceTotal1", PriceTotal1))
                    command.Parameters.Add(New SqlParameter("@Building_Detail", Building_Detail))
                    command.Parameters.Add(New SqlParameter("@PriceTotal2", PriceTotal2))
                    command.Parameters.Add(New SqlParameter("@PriceTotal3", PriceTotal3))
                    command.Parameters.Add(New SqlParameter("@GrandTotal", GrandTotal))
                    command.Parameters.Add(New SqlParameter("@Doc1", Doc1))
                    command.Parameters.Add(New SqlParameter("@Doc2", Doc2))
                    command.Parameters.Add(New SqlParameter("@Doc_Detail", Doc_Detail))
                    command.Parameters.Add(New SqlParameter("@UserAppraisal_ID", UserAppraisal_ID))
                    command.Parameters.Add(New SqlParameter("@BossAppraisal_ID", BossAppraisal_ID))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    Dim msg As String
                    Dim title As String
                    Dim style As MsgBoxStyle
                    Dim response1 As MsgBoxResult
                    'msg = "การบันทึกผิดพลาด"   ' Define message.
                    msg = ex.Message
                    style = MsgBoxStyle.DefaultButton2 Or _
                       MsgBoxStyle.Critical Or MsgBoxStyle.YesNo
                    title = "ผลการบันทึก"   ' Define title.
                    ' Display message.
                    response1 = MsgBox(msg, style, title)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub UpdatePrice2_ShortForm(ByVal Q_ID As Integer, _
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
     ByVal Road_Access As Decimal, _
     ByVal Road_Frontoff As Integer, _
     ByVal Roadwidth As Decimal, _
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
     ByVal UserAppraisal_ID As Integer, _
     ByVal BossAppraisal_ID As Integer, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_PRICE2", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Q_ID", Q_ID))
                    command.Parameters.Add(New SqlParameter("@Cif", Cif))
                    command.Parameters.Add(New SqlParameter("@MysubColl_ID", MysubColl_ID))
                    command.Parameters.Add(New SqlParameter("@Address_No", Address_No))
                    command.Parameters.Add(New SqlParameter("@Building_Name", Building_Name))
                    command.Parameters.Add(New SqlParameter("@Tumbon", Tumbon))
                    command.Parameters.Add(New SqlParameter("@Amphur", Amphur))
                    command.Parameters.Add(New SqlParameter("@Province", Province))
                    command.Parameters.Add(New SqlParameter("@Rai", Rai))
                    command.Parameters.Add(New SqlParameter("@Ngan", Ngan))
                    command.Parameters.Add(New SqlParameter("@Wah", Wah))
                    command.Parameters.Add(New SqlParameter("@Road", Road))
                    command.Parameters.Add(New SqlParameter("@Road_Detail", Road_Detail))
                    command.Parameters.Add(New SqlParameter("@Road_Access", Road_Access))
                    command.Parameters.Add(New SqlParameter("@Road_Frontoff", Road_Frontoff))
                    command.Parameters.Add(New SqlParameter("@Roadwidth", Roadwidth))
                    command.Parameters.Add(New SqlParameter("@Site", Site))
                    command.Parameters.Add(New SqlParameter("@Site_Detail", Site_Detail))
                    command.Parameters.Add(New SqlParameter("@Land_State", Land_State))
                    command.Parameters.Add(New SqlParameter("@Land_State_Detail", Land_State_Detail))
                    command.Parameters.Add(New SqlParameter("@Public_Utility", Public_Utility))
                    command.Parameters.Add(New SqlParameter("@Public_Utility_Detail", Public_Utility_Detail))
                    command.Parameters.Add(New SqlParameter("@Binifit", Binifit))
                    command.Parameters.Add(New SqlParameter("@Binifit_Detail", Binifit_Detail))
                    command.Parameters.Add(New SqlParameter("@Tendency", Tendency))
                    command.Parameters.Add(New SqlParameter("@BuySale_State", BuySale_State))
                    command.Parameters.Add(New SqlParameter("@Build_No", Build_No))
                    command.Parameters.Add(New SqlParameter("@Build_Character", Build_Character))
                    command.Parameters.Add(New SqlParameter("@Floors", Floors))
                    command.Parameters.Add(New SqlParameter("@Item", Item))
                    command.Parameters.Add(New SqlParameter("@Build_Construct", Build_Construct))
                    command.Parameters.Add(New SqlParameter("@Roof", Roof))
                    command.Parameters.Add(New SqlParameter("@Roof_Detail", Roof_Detail))
                    command.Parameters.Add(New SqlParameter("@Build_State", Build_State))
                    command.Parameters.Add(New SqlParameter("@Build_State_Detail", Build_State_Detail))
                    command.Parameters.Add(New SqlParameter("@PriceItem1", PriceItem1))
                    command.Parameters.Add(New SqlParameter("@PriceItem2", PriceItem2))
                    command.Parameters.Add(New SqlParameter("@Sizing", Sizing))
                    command.Parameters.Add(New SqlParameter("@PriceWah", PriceWah))
                    command.Parameters.Add(New SqlParameter("@PriceTotal1", PriceTotal1))
                    command.Parameters.Add(New SqlParameter("@Building_Detail", Building_Detail))
                    command.Parameters.Add(New SqlParameter("@PriceTotal2", PriceTotal2))
                    command.Parameters.Add(New SqlParameter("@PriceTotal3", PriceTotal3))
                    command.Parameters.Add(New SqlParameter("@GrandTotal", GrandTotal))
                    command.Parameters.Add(New SqlParameter("@Doc1", Doc1))
                    command.Parameters.Add(New SqlParameter("@Doc2", Doc2))
                    command.Parameters.Add(New SqlParameter("@Doc_Detail", Doc_Detail))
                    command.Parameters.Add(New SqlParameter("@UserAppraisal_ID", UserAppraisal_ID))
                    command.Parameters.Add(New SqlParameter("@BossAppraisal_ID", BossAppraisal_ID))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    Dim msg As String
                    Dim title As String
                    Dim style As MsgBoxStyle
                    Dim response1 As MsgBoxResult
                    'msg = "การบันทึกผิดพลาด"   ' Define message.
                    msg = ex.Message
                    style = MsgBoxStyle.DefaultButton2 Or _
                       MsgBoxStyle.Critical Or MsgBoxStyle.YesNo
                    title = "ผลการบันทึก"   ' Define title.
                    ' Display message.
                    response1 = MsgBox(msg, style, title)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Function GetPrice2(ByVal Q_ID As Integer) As Generic.List(Of Price2_ShortForm)
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE2", connection)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(New SqlParameter("@Q_ID", Q_ID))
                connection.Open()
                Dim list As New Generic.List(Of Price2_ShortForm)()
                Using reader As SqlDataReader = command.ExecuteReader()
                    Do While (reader.Read())
                        'Get field in Store Procedure
                        Dim temp As New Price2_ShortForm(CInt(reader("Q_ID")), _
                                                        CInt(reader("cif")), _
                                                        CInt(reader("MysubColl_ID")), _
                                                        CStr(reader("Address_No")), _
                                                        CStr(reader("Building_Name")), _
                                                        CStr(reader("Tumbon")), _
                                                        CStr(reader("Amphur")), _
                                                        CInt(reader("Province")), _
                                                        CInt(reader("Rai")), _
                                                        CInt(reader("Ngan")), _
                                                        CInt(reader("Wah")), _
                                                        CStr(reader("Road")), _
                                                        CInt(reader("Road_Detail")), _
                                                        CDec(reader("Road_Access")), _
                                                        CInt(reader("Road_Frontoff")), _
                                                        CDec(reader("RoadWidth")), _
                                                        CInt(reader("Site")), _
                                                        CStr(reader("Site_Detail")), _
                                                        CInt(reader("Land_State")), _
                                                        CStr(reader("Land_State_Detail")), _
                                                        CInt(reader("Public_Utility")), _
                                                        CStr(reader("Public_Utility_Detail")), _
                                                        CInt(reader("Binifit")), _
                                                        CStr(reader("Binifit_Detail")), _
                                                        CInt(reader("Tendency")), _
                                                        CInt(reader("BuySale_State")), _
                                                        CStr(reader("Build_No")), _
                                                        CInt(reader("Build_Character")), _
                                                        CStr(reader("Floors")), _
                                                        CInt(reader("Item")), _
                                                        CInt(reader("Build_Construct")), _
                                                        CInt(reader("Roof")), _
                                                        CStr(reader("Roof_Detail")), _
                                                        CInt(reader("Build_State")), _
                                                        CStr(reader("Build_State_Detail")), _
                                                        CDec(reader("PriceItem1")), _
                                                        CDec(reader("PriceItem2")), _
                                                        CStr(reader("Sizing")), _
                                                        CDec(reader("PriceWah")), _
                                                        CDec(reader("PriceTotal1")), _
                                                        CStr(reader("Building_Detail")), _
                                                        CDec(reader("PriceTotal2")), _
                                                        CDec(reader("PriceTotal3")), _
                                                        CDec(reader("GrandTotal")), _
                                                        CInt(reader("Doc1")), _
                                                        CInt(reader("Doc2")), _
                                                        CStr(reader("Doc_Detail")), _
                                                        CInt(reader("UserAppraisal_ID")), _
                                                        CInt(reader("BossAppraisal_ID")), _
                                                        CStr(reader("Create_User")), _
                                                        CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                If list.Count > 0 Then
                    Return list
                Else
                    Dim temp As New Price2_ShortForm(0, 0, 0, "", "", "", "", 0, 0, 0, 0, "", 0, 0, 0, 0, 0, "", 0, _
                                                        "", 0, "", 0, "", 0, 0, 0, 0, "", 0, 0, 0, _
                                                        "", 0, "", 0, 0, "", 0, 0, "", 0, 0, 0, 0, 0, "", 0, 0, _
                                                        "", Date.Now)
                    list.Add(temp)
                    Return list
                End If
                connection.Close()
            End Using
        End Using
    End Function

    Public Shared Sub DeletePrice2_ShortForm(ByVal Q_ID As Integer)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("DELETE_PRICE2", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Q_ID", Q_ID))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    Dim msg As String
                    Dim title As String
                    Dim style As MsgBoxStyle
                    Dim response1 As MsgBoxResult
                    'msg = "การบันทึกผิดพลาด"   ' Define message.
                    msg = ex.Message
                    style = MsgBoxStyle.DefaultButton2 Or _
                       MsgBoxStyle.Critical Or MsgBoxStyle.YesNo
                    title = "ผลการบันทึก"   ' Define title.
                    ' Display message.
                    response1 = MsgBox(msg, style, title)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

#End Region

#Region "PRICE2-MASTER"

    Public Shared Sub ADD_PRICE2_MASTER_NEW(ByVal Req_Id As Integer, _
 ByVal Hub_Id As Integer, _
 ByVal Cif As String, _
 ByVal Temp_AID As Integer, _
 ByVal Land As Decimal, _
 ByVal Building As Decimal, _
 ByVal Condo As Decimal, _
 ByVal Machine As Decimal, _
 ByVal Leasehold As Decimal, _
 ByVal Ship As Decimal, _
 ByVal Comment As String, _
 ByVal Warning As String, _
 ByVal Note As String, _
 ByVal Appraisal_Id As String, _
 ByVal Approve_Id As String, _
 ByVal Create_User As String, _
 ByVal Create_Date As Date)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("ADD_PRICE2_MASTER_NEW", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Cif", Cif))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@Land", Land))
                    command.Parameters.Add(New SqlParameter("@Building", Building))
                    command.Parameters.Add(New SqlParameter("@Condo", Condo))
                    command.Parameters.Add(New SqlParameter("@Machine", Machine))
                    command.Parameters.Add(New SqlParameter("@Leasehold", Leasehold))
                    command.Parameters.Add(New SqlParameter("@Ship", Ship))
                    command.Parameters.Add(New SqlParameter("@Comment", Comment))
                    command.Parameters.Add(New SqlParameter("@Warning", Warning))
                    command.Parameters.Add(New SqlParameter("@Note", Note))
                    command.Parameters.Add(New SqlParameter("@Appraisal_Id", Appraisal_Id))
                    command.Parameters.Add(New SqlParameter("@Approve_Id", Approve_Id))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    Throw New Exception(ex.Message & " : " & ex.StackTrace)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub AddPRICE2_Master(ByVal Temp_AID As Integer, _
     ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
     ByVal Id As Integer, _
     ByVal Cif As Integer, _
     ByVal Appraisal_Id As String, _
     ByVal CollType As Integer, _
     ByVal Comment As String, _
     ByVal Approve2_Id As String, _
     ByVal Price As Decimal, _
     ByVal Appraisal_Type As Integer, _
     ByVal Note As String, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("AddPRICE2_Master", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Id", Id))
                    command.Parameters.Add(New SqlParameter("@Cif", Cif))
                    command.Parameters.Add(New SqlParameter("@Appraisal_Id", Appraisal_Id))
                    command.Parameters.Add(New SqlParameter("@CollType", CollType))
                    command.Parameters.Add(New SqlParameter("@Comment", Comment))
                    command.Parameters.Add(New SqlParameter("@Approve2_Id", Approve2_Id))
                    command.Parameters.Add(New SqlParameter("@Price", Price))
                    command.Parameters.Add(New SqlParameter("@Appraisal_Type", Appraisal_Type))
                    command.Parameters.Add(New SqlParameter("@Note", Note))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    Throw New Exception(ex.Message & " : " & ex.StackTrace)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub UPDATE_PRICE2_18_50_70(ByVal Temp_AID As Integer, ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
     ByVal Id As Integer, _
     ByVal CollType As Integer)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_PRICE2_18_50_70", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Id", Id))
                    command.Parameters.Add(New SqlParameter("@CollType", CollType))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    'MsgBox(ex.Message)
                    Throw New Exception(ex.Message & " : " & ex.StackTrace)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Function GET_PRICE2_MASTER(ByVal Req_Id As Integer, ByVal Hub_Id As Integer) As Generic.List(Of Price2_Master)
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE2_MASTER", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                connection.Open()
                Dim list As New Generic.List(Of Price2_Master)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Price2_Master(CInt(reader("Temp_AID")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CInt(reader("Cif")), _
                                                CStr(reader("Appraisal_Id")), _
                                                CStr(reader("Comment")), _
                                                CStr(reader("Approve2_Id")), _
                                                CDec(reader("Price")), _
                                                CInt(reader("Appraisal_Type")), _
                                                CStr(reader("Note")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using
    End Function

    Public Shared Sub UPDATE_PRICE2_MASTER(ByVal Req_Id As Integer, ByVal Hub_Id As Integer, ByVal Price As Decimal, ByVal Note As String, ByVal Approve2_Id As String)
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_PRICE2_MASTER", connection)

                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Price", Price))
                    command.Parameters.Add(New SqlParameter("@Note", Note))
                    command.Parameters.Add(New SqlParameter("@Approve2_Id", Approve2_Id))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

#End Region

#Region "PRICE2-18"

    Public Shared Sub ADD_PRICE2_18(ByVal ID As Integer, _
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
     ByVal Unit_Price As Decimal, _
     ByVal PriceTotal As Decimal, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("ADD_PRICE2_18", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@ID", ID))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@AID", AID))
                    command.Parameters.Add(New SqlParameter("@CID", CID))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@MysubColl_ID", MysubColl_ID))
                    command.Parameters.Add(New SqlParameter("@Floors_All", Floors_All))
                    command.Parameters.Add(New SqlParameter("@Elevator", Elevator))
                    command.Parameters.Add(New SqlParameter("@Address_No", Address_No))
                    command.Parameters.Add(New SqlParameter("@Room_Area", Room_Area))
                    command.Parameters.Add(New SqlParameter("@Room_Height", Room_Height))
                    command.Parameters.Add(New SqlParameter("@Building_Name", Building_Name))
                    command.Parameters.Add(New SqlParameter("@Floors", Floors))
                    command.Parameters.Add(New SqlParameter("@Building_No", Building_No))
                    command.Parameters.Add(New SqlParameter("@Building_Reg_No", Building_Reg_No))
                    command.Parameters.Add(New SqlParameter("@Tumbon", Tumbon))
                    command.Parameters.Add(New SqlParameter("@Amphur", Amphur))
                    command.Parameters.Add(New SqlParameter("@Province", Province))
                    command.Parameters.Add(New SqlParameter("@Road", Road))
                    command.Parameters.Add(New SqlParameter("@Road_Detail", Road_Detail))
                    command.Parameters.Add(New SqlParameter("@Road_Access", Road_Access))
                    command.Parameters.Add(New SqlParameter("@Road_Frontoff", Road_Frontoff))
                    command.Parameters.Add(New SqlParameter("@RoadWidth", RoadWidth))
                    command.Parameters.Add(New SqlParameter("@Site", Site))
                    command.Parameters.Add(New SqlParameter("@Site_Detail", Site_Detail))
                    command.Parameters.Add(New SqlParameter("@Public_Utility", Public_Utility))
                    command.Parameters.Add(New SqlParameter("@Public_Utility_Detail", Public_Utility_Detail))
                    command.Parameters.Add(New SqlParameter("@Binifit", Binifit))
                    command.Parameters.Add(New SqlParameter("@Binifit_Detail", Binifit_Detail))
                    command.Parameters.Add(New SqlParameter("@Tendency", Tendency))
                    command.Parameters.Add(New SqlParameter("@BuySale_State", BuySale_State))
                    command.Parameters.Add(New SqlParameter("@Building_Construc", Building_Construc))
                    command.Parameters.Add(New SqlParameter("@InteriorState_Id", InteriorState_Id))
                    command.Parameters.Add(New SqlParameter("@Character_Room_Id", Character_Room_Id))
                    command.Parameters.Add(New SqlParameter("@RoomWidth_BehideSiteWalk", RoomWidth_BehideSiteWalk))
                    command.Parameters.Add(New SqlParameter("@Roomdeep", Roomdeep))
                    command.Parameters.Add(New SqlParameter("@Backside_Width", Backside_Width))
                    command.Parameters.Add(New SqlParameter("@SideWalk_Is", SideWalk_Is))
                    command.Parameters.Add(New SqlParameter("@SideWalk_Width", SideWalk_Width))
                    command.Parameters.Add(New SqlParameter("@Unit_Price", Unit_Price))
                    command.Parameters.Add(New SqlParameter("@PriceTotal", PriceTotal))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    Throw New Exception(ex.Message & " : " & ex.StackTrace)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub UPDATE_PRICE2_18(ByVal ID As Integer, _
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
     ByVal Unit_Price As Decimal, _
     ByVal PriceTotal As Decimal, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_PRICE2_18", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@ID", ID))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@AID", AID))
                    command.Parameters.Add(New SqlParameter("@CID", CID))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@MysubColl_ID", MysubColl_ID))
                    command.Parameters.Add(New SqlParameter("@Floors_All", Floors_All))
                    command.Parameters.Add(New SqlParameter("@Elevator", Elevator))
                    command.Parameters.Add(New SqlParameter("@Address_No", Address_No))
                    command.Parameters.Add(New SqlParameter("@Room_Area", Room_Area))
                    command.Parameters.Add(New SqlParameter("@Room_Height", Room_Height))
                    command.Parameters.Add(New SqlParameter("@Building_Name", Building_Name))
                    command.Parameters.Add(New SqlParameter("@Floors", Floors))
                    command.Parameters.Add(New SqlParameter("@Building_No", Building_No))
                    command.Parameters.Add(New SqlParameter("@Building_Reg_No", Building_Reg_No))
                    command.Parameters.Add(New SqlParameter("@Tumbon", Tumbon))
                    command.Parameters.Add(New SqlParameter("@Amphur", Amphur))
                    command.Parameters.Add(New SqlParameter("@Province", Province))
                    command.Parameters.Add(New SqlParameter("@Road", Road))
                    command.Parameters.Add(New SqlParameter("@Road_Detail", Road_Detail))
                    command.Parameters.Add(New SqlParameter("@Road_Access", Road_Access))
                    command.Parameters.Add(New SqlParameter("@Road_Frontoff", Road_Frontoff))
                    command.Parameters.Add(New SqlParameter("@RoadWidth", RoadWidth))
                    command.Parameters.Add(New SqlParameter("@Site", Site))
                    command.Parameters.Add(New SqlParameter("@Site_Detail", Site_Detail))
                    command.Parameters.Add(New SqlParameter("@Public_Utility", Public_Utility))
                    command.Parameters.Add(New SqlParameter("@Public_Utility_Detail", Public_Utility_Detail))
                    command.Parameters.Add(New SqlParameter("@Binifit", Binifit))
                    command.Parameters.Add(New SqlParameter("@Binifit_Detail", Binifit_Detail))
                    command.Parameters.Add(New SqlParameter("@Tendency", Tendency))
                    command.Parameters.Add(New SqlParameter("@BuySale_State", BuySale_State))
                    command.Parameters.Add(New SqlParameter("@Building_Construc", Building_Construc))
                    command.Parameters.Add(New SqlParameter("@InteriorState_Id", InteriorState_Id))
                    command.Parameters.Add(New SqlParameter("@Character_Room_Id", Character_Room_Id))
                    command.Parameters.Add(New SqlParameter("@RoomWidth_BehideSiteWalk", RoomWidth_BehideSiteWalk))
                    command.Parameters.Add(New SqlParameter("@Roomdeep", Roomdeep))
                    command.Parameters.Add(New SqlParameter("@Backside_Width", Backside_Width))
                    command.Parameters.Add(New SqlParameter("@SideWalk_Is", SideWalk_Is))
                    command.Parameters.Add(New SqlParameter("@SideWalk_Width", SideWalk_Width))
                    command.Parameters.Add(New SqlParameter("@Unit_Price", Unit_Price))
                    command.Parameters.Add(New SqlParameter("@PriceTotal", PriceTotal))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    Throw New Exception(ex.Message & " : " & ex.StackTrace)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Function GET_PRICE2_18(ByVal ID As Integer, ByVal Req_Id As Integer, ByVal Hub_Id As Integer) As Generic.List(Of PRICE2_18)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE2_18", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@ID", ID))
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                connection.Open()
                Dim list As New Generic.List(Of PRICE2_18)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New PRICE2_18(CInt(reader("ID")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CStr(reader("AID")), _
                                                CStr(reader("CID")), _
                                                CInt(reader("Temp_AID")), _
                                                CInt(reader("MysubColl_ID")), _
                                                CInt(reader("Floors_All")), _
                                                CInt(reader("Elevator")), _
                                                CStr(reader("Address_No")), _
                                                CDec(reader("Room_Area")), _
                                                CDec(reader("Room_Height")), _
                                                CStr(reader("Building_Name")), _
                                                CInt(reader("Floors")), _
                                                CStr(reader("Building_No")), _
                                                CStr(reader("Building_Reg_No")), _
                                                CStr(reader("Tumbon")), _
                                                CStr(reader("Amphur")), _
                                                CInt(reader("Province")), _
                                                CStr(reader("Road")), _
                                                CInt(reader("Road_Detail")), _
                                                CDec(reader("Road_Access")), _
                                                CInt(reader("Road_Frontoff")), _
                                                CDec(reader("Roadwidth")), _
                                                CInt(reader("Sited")), _
                                                CStr(reader("Site_Detail")), _
                                                CInt(reader("Public_Utility")), _
                                                CStr(reader("Public_Utility_Detail")), _
                                                CInt(reader("Binifit")), _
                                                CStr(reader("Binifit_Detail")), _
                                                CInt(reader("Tendency")), _
                                                CInt(reader("BuySale_State")), _
                                                CInt(reader("Building_Construc")), _
                                                CInt(reader("InteriorState_Id")), _
                                                CInt(reader("Character_Room_Id")), _
                                                CDec(reader("RoomWidth_BehideSiteWalk")), _
                                                CDec(reader("Roomdeep")), _
                                                CDec(reader("Backside_Width")), _
                                                CInt(reader("SideWalk_Is")), _
                                                CDec(reader("SideWalk_Width")), _
                                                CDec(reader("Unit_Price")), _
                                                CDec(reader("PriceTotal")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using

    End Function

    Public Shared Function GET_PRICE2_18_FIND_ADDRESSNO(ByVal Building_Reg_No As String, ByVal Building_No As String, ByVal Address_No As String) As Generic.List(Of PRICE2_18)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE3_18_FIND_ADDRESSNO", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@Building_Reg_No", Building_Reg_No))
                command.Parameters.Add(New SqlParameter("@Building_No", Building_No))
                command.Parameters.Add(New SqlParameter("@Address_No", Address_No))
                connection.Open()
                Dim list As New Generic.List(Of PRICE2_18)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New PRICE2_18(CInt(reader("ID")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CStr(reader("AID")), _
                                                CStr(reader("CID")), _
                                                CInt(reader("Temp_AID")), _
                                                CInt(reader("MysubColl_ID")), _
                                                CInt(reader("Floors_All")), _
                                                CInt(reader("Elevator")), _
                                                CStr(reader("Address_No")), _
                                                CDec(reader("Room_Area")), _
                                                CDec(reader("Room_Height")), _
                                                CStr(reader("Building_Name")), _
                                                CInt(reader("Floors")), _
                                                CStr(reader("Building_No")), _
                                                CStr(reader("Building_Reg_No")), _
                                                CStr(reader("Tumbon")), _
                                                CStr(reader("Amphur")), _
                                                CInt(reader("Province")), _
                                                CStr(reader("Road")), _
                                                CInt(reader("Road_Detail")), _
                                                CDec(reader("Road_Access")), _
                                                CInt(reader("Road_Frontoff")), _
                                                CDec(reader("Roadwidth")), _
                                                CInt(reader("Site")), _
                                                CStr(reader("Site_Detail")), _
                                                CInt(reader("Public_Utility")), _
                                                CStr(reader("Public_Utility_Detail")), _
                                                CInt(reader("Binifit")), _
                                                CStr(reader("Binifit_Detail")), _
                                                CInt(reader("Tendency")), _
                                                CInt(reader("BuySale_State")), _
                                                CInt(reader("Building_Construc")), _
                                                CInt(reader("InteriorState_Id")), _
                                                CInt(reader("Character_Room_Id")), _
                                                CDec(reader("RoomWidth_BehideSiteWalk")), _
                                                CDec(reader("Roomdeep")), _
                                                CDec(reader("Backside_Width")), _
                                                CInt(reader("SideWalk_Is")), _
                                                CDec(reader("SideWalk_Width")), _
                                                CDec(reader("Unit_Price")), _
                                                CDec(reader("PriceTotal")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                        'MsgBox(temp.Elevator_Util)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using

    End Function

    Public Shared Function GET_PRICE2_18_FOR_PRINT(ByVal Req_Id As Integer, ByVal Hub_Id As Integer) As Generic.List(Of PRICE2_18)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE2_18_FOR_PRINT", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                connection.Open()
                Dim list As New Generic.List(Of PRICE2_18)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New PRICE2_18(CInt(reader("ID")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CStr(reader("AID")), _
                                                CStr(reader("CID")), _
                                                CInt(reader("Temp_AID")), _
                                                CInt(reader("MysubColl_ID")), _
                                                CInt(reader("Floors_All")), _
                                                CInt(reader("Elevator")), _
                                                CStr(reader("Address_No")), _
                                                CDec(reader("Room_Area")), _
                                                CDec(reader("Room_Height")), _
                                                CStr(reader("Building_Name")), _
                                                CInt(reader("Floors")), _
                                                CStr(reader("Building_No")), _
                                                CStr(reader("Building_Reg_No")), _
                                                CStr(reader("Tumbon")), _
                                                CStr(reader("Amphur")), _
                                                CInt(reader("Province")), _
                                                CStr(reader("Road")), _
                                                CInt(reader("Road_Detail")), _
                                                CDec(reader("Road_Access")), _
                                                CInt(reader("Road_Frontoff")), _
                                                CDec(reader("Roadwidth")), _
                                                CInt(reader("Sited")), _
                                                CStr(reader("Site_Detail")), _
                                                CInt(reader("Public_Utility")), _
                                                CStr(reader("Public_Utility_Detail")), _
                                                CInt(reader("Binifit")), _
                                                CStr(reader("Binifit_Detail")), _
                                                CInt(reader("Tendency")), _
                                                CInt(reader("BuySale_State")), _
                                                CInt(reader("Building_Construc")), _
                                                CInt(reader("InteriorState_Id")), _
                                                CInt(reader("Character_Room_Id")), _
                                                CDec(reader("RoomWidth_BehideSiteWalk")), _
                                                CDec(reader("Roomdeep")), _
                                                CDec(reader("Backside_Width")), _
                                                CInt(reader("SideWalk_Is")), _
                                                CDec(reader("SideWalk_Width")), _
                                                CDec(reader("Unit_Price")), _
                                                CDec(reader("PriceTotal")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
            End Using
        End Using

    End Function

    Public Shared Sub DELETE_PRICE2_18(ByVal Id As String, _
ByVal Req_Id As Integer, _
ByVal Hub_Id As Integer)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("DELETE_PRICE2_18", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Id", Id))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

#End Region

#Region "PRICE2-50"

    Public Shared Sub AddPRICE2_50(ByVal ID As Integer, _
     ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
     ByVal AID As String, _
     ByVal CID As String, _
     ByVal Temp_AID As Integer, _
     ByVal MysubColl_ID As Integer, _
     ByVal Address_No As String, _
     ByVal Building_Name As String, _
     ByVal Tumbon As String, _
     ByVal Amphur As String, _
     ByVal Province As Integer, _
     ByVal Rai As Integer, _
     ByVal Ngan As Integer, _
     ByVal Wah As Decimal, _
     ByVal Road As String, _
     ByVal Road_Detail As Integer, _
     ByVal Road_Access As Decimal, _
     ByVal Road_Frontoff As Integer, _
     ByVal RoadWidth As Decimal, _
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
     ByVal SubUnit_Id As Integer, _
     ByVal PriceWah As Decimal, _
     ByVal PriceTotal1 As Decimal, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)

        Dim msg As String
        Dim title As String
        Dim style As MsgBoxStyle
        Dim response1 As MsgBoxResult

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("AddPRICE2_50", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Id", ID))  'ID เกิดจากเลข Running จากระบบเอง
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@AID", AID))
                    command.Parameters.Add(New SqlParameter("@CID", CID))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@MysubColl_ID", MysubColl_ID))
                    command.Parameters.Add(New SqlParameter("@Address_No", Address_No))
                    command.Parameters.Add(New SqlParameter("@Building_Name", Building_Name))
                    command.Parameters.Add(New SqlParameter("@Tumbon", Tumbon))
                    command.Parameters.Add(New SqlParameter("@Amphur", Amphur))
                    command.Parameters.Add(New SqlParameter("@Province", Province))
                    command.Parameters.Add(New SqlParameter("@Rai", Rai))
                    command.Parameters.Add(New SqlParameter("@Ngan", Ngan))
                    command.Parameters.Add(New SqlParameter("@Wah", Wah))
                    command.Parameters.Add(New SqlParameter("@Road", Road))
                    command.Parameters.Add(New SqlParameter("@Road_Detail", Road_Detail))
                    command.Parameters.Add(New SqlParameter("@Road_Access", Road_Access))
                    command.Parameters.Add(New SqlParameter("@Road_Frontoff", Road_Frontoff))
                    command.Parameters.Add(New SqlParameter("@RoadWidth", RoadWidth))
                    command.Parameters.Add(New SqlParameter("@Sited", Site))
                    command.Parameters.Add(New SqlParameter("@Site_Detail", Site_Detail))
                    command.Parameters.Add(New SqlParameter("@Land_State", Land_State))
                    command.Parameters.Add(New SqlParameter("@Land_State_Detail", Land_State_Detail))
                    command.Parameters.Add(New SqlParameter("@Public_Utility", Public_Utility))
                    command.Parameters.Add(New SqlParameter("@Public_Utility_Detail", Public_Utility_Detail))
                    command.Parameters.Add(New SqlParameter("@Binifit", Binifit))
                    command.Parameters.Add(New SqlParameter("@Binifit_Detail", Binifit_Detail))
                    command.Parameters.Add(New SqlParameter("@Tendency", Tendency))
                    command.Parameters.Add(New SqlParameter("@BuySale_State", BuySale_State))
                    command.Parameters.Add(New SqlParameter("@SubUnit_Id", SubUnit_Id))
                    command.Parameters.Add(New SqlParameter("@PriceWah", PriceWah))
                    command.Parameters.Add(New SqlParameter("@PriceTotal1", PriceTotal1))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As SqlException
                    myTrans.Rollback()
                    'msg = "การบันทึกผิดพลาด"   ' Define message.
                    msg = ex.Message
                    style = MsgBoxStyle.DefaultButton2 Or _
                       MsgBoxStyle.Critical Or MsgBoxStyle.YesNo
                    title = "ผลการบันทึก"   ' Define title.
                    ' Display message.
                    response1 = MsgBox(msg, style, title)
                Catch ex As Exception
                    myTrans.Rollback()

                    msg = ex.Message
                    style = MsgBoxStyle.DefaultButton2 Or _
                       MsgBoxStyle.Critical Or MsgBoxStyle.YesNo
                    title = "ผลการบันทึก"   ' Define title.
                    ' Display message.
                    response1 = MsgBox(msg, style, title)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub UpdatePRICE2_50(ByVal ID As Integer, _
     ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
     ByVal AID As String, _
     ByVal CID As String, _
     ByVal Temp_AID As Integer, _
     ByVal MysubColl_ID As Integer, _
     ByVal Address_No As String, _
     ByVal Building_Name As String, _
     ByVal Tumbon As String, _
     ByVal Amphur As String, _
     ByVal Province As Integer, _
     ByVal Rai As Integer, _
     ByVal Ngan As Integer, _
     ByVal Wah As Decimal, _
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
     ByVal Create_User As String, _
     ByVal Create_Date As Date)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("AddPRICE2_50", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@ID", ID))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@AID", AID))
                    command.Parameters.Add(New SqlParameter("@CID", CID))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@MysubColl_ID", MysubColl_ID))
                    command.Parameters.Add(New SqlParameter("@Address_No", Address_No))
                    command.Parameters.Add(New SqlParameter("@Building_Name", Building_Name))
                    command.Parameters.Add(New SqlParameter("@Tumbon", Tumbon))
                    command.Parameters.Add(New SqlParameter("@Amphur", Amphur))
                    command.Parameters.Add(New SqlParameter("@Province", Province))
                    command.Parameters.Add(New SqlParameter("@Rai", Rai))
                    command.Parameters.Add(New SqlParameter("@Ngan", Ngan))
                    command.Parameters.Add(New SqlParameter("@Wah", Wah))
                    command.Parameters.Add(New SqlParameter("@Road", Road))
                    command.Parameters.Add(New SqlParameter("@Road_Detail", Road_Detail))
                    command.Parameters.Add(New SqlParameter("@Road_Access", Road_Access))
                    command.Parameters.Add(New SqlParameter("@Road_Frontoff", Road_Frontoff))
                    command.Parameters.Add(New SqlParameter("@RoadWidth", RoadWidth))
                    command.Parameters.Add(New SqlParameter("@Sited", Sited))
                    command.Parameters.Add(New SqlParameter("@Site_Detail", Site_Detail))
                    command.Parameters.Add(New SqlParameter("@Land_State", Land_State))
                    command.Parameters.Add(New SqlParameter("@Land_State_Detail", Land_State_Detail))
                    command.Parameters.Add(New SqlParameter("@Public_Utility", Public_Utility))
                    command.Parameters.Add(New SqlParameter("@Public_Utility_Detail", Public_Utility_Detail))
                    command.Parameters.Add(New SqlParameter("@Binifit", Binifit))
                    command.Parameters.Add(New SqlParameter("@Binifit_Detail", Binifit_Detail))
                    command.Parameters.Add(New SqlParameter("@Tendency", Tendency))
                    command.Parameters.Add(New SqlParameter("@BuySale_State", BuySale_State))
                    command.Parameters.Add(New SqlParameter("@PriceWah", PriceWah))
                    command.Parameters.Add(New SqlParameter("@PriceTotal1", PriceTotal1))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As SqlException
                    myTrans.Rollback()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Function GET_PRICE2_50(ByVal ID As Integer, ByVal Req_Id As Integer, ByVal Hub_Id As Integer) As Generic.List(Of PRICE2_50)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE2_50", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@ID", ID))
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                'MsgBox(ID & "  " & Req_Id & "  " & Hub_Id)
                connection.Open()
                Dim list As New Generic.List(Of PRICE2_50)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New PRICE2_50(CInt(reader("ID")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CStr(reader("AID")), _
                                                CStr(reader("CID")), _
                                                CInt(reader("Temp_AID")), _
                                                CInt(reader("MysubColl_ID")), _
                                                CStr(reader("Address_No")), _
                                                CStr(reader("Building_Name")), _
                                                CStr(reader("Tumbon")), _
                                                CStr(reader("Amphur")), _
                                                CInt(reader("Province")), _
                                                CInt(reader("Rai")), _
                                                CInt(reader("Ngan")), _
                                                CDec(reader("Wah")), _
                                                CStr(reader("Road")), _
                                                CInt(reader("Road_Detail")), _
                                                CDec(reader("Road_Access")), _
                                                CInt(reader("Road_Frontoff")), _
                                                CDec(reader("Roadwidth")), _
                                                CInt(reader("Sited")), _
                                                CStr(reader("Site_Detail")), _
                                                CInt(reader("Land_State")), _
                                                CStr(reader("Land_State_Detail")), _
                                                CInt(reader("Public_Utility")), _
                                                CStr(reader("Public_Utility_Detail")), _
                                                CInt(reader("Binifit")), _
                                                CStr(reader("Binifit_Detail")), _
                                                CInt(reader("Tendency")), _
                                                CInt(reader("BuySale_State")), _
                                                CInt(reader("SubUnit_Id")), _
                                                CDec(reader("PriceWah")), _
                                                CDec(reader("PriceTotal1")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using

    End Function

    Public Shared Function GET_PRICE2_50_FOR_PRINT(ByVal Req_Id As Integer, ByVal Hub_Id As Integer) As Generic.List(Of PRICE2_50)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE2_50_FOR_PRINT", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                'MsgBox(ID & "  " & Req_Id & "  " & Hub_Id)
                connection.Open()
                Dim list As New Generic.List(Of PRICE2_50)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New PRICE2_50(CInt(reader("ID")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CStr(reader("AID")), _
                                                CStr(reader("CID")), _
                                                CInt(reader("Temp_AID")), _
                                                CInt(reader("MysubColl_ID")), _
                                                CStr(reader("Address_No")), _
                                                CStr(reader("Building_Name")), _
                                                CStr(reader("Tumbon")), _
                                                CStr(reader("Amphur")), _
                                                CInt(reader("Province")), _
                                                CInt(reader("Rai")), _
                                                CInt(reader("Ngan")), _
                                                CDec(reader("Wah")), _
                                                CStr(reader("Road")), _
                                                CInt(reader("Road_Detail")), _
                                                CDec(reader("Road_Access")), _
                                                CInt(reader("Road_Frontoff")), _
                                                CDec(reader("Roadwidth")), _
                                                CInt(reader("Sited")), _
                                                CStr(reader("Site_Detail")), _
                                                CInt(reader("Land_State")), _
                                                CStr(reader("Land_State_Detail")), _
                                                CInt(reader("Public_Utility")), _
                                                CStr(reader("Public_Utility_Detail")), _
                                                CInt(reader("Binifit")), _
                                                CStr(reader("Binifit_Detail")), _
                                                CInt(reader("Tendency")), _
                                                CInt(reader("BuySale_State")), _
                                                CInt(reader("SubUnit_Id")), _
                                                CDec(reader("PriceWah")), _
                                                CDec(reader("PriceTotal1")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
            End Using
        End Using

    End Function

    Public Shared Function GET_PRICE2_50_CHANODE(ByVal Chanode_No As String, ByVal Province_Id As String) As Generic.List(Of PRICE2_50)
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE2_50_CHANODE", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@Chanode_No", Chanode_No))
                command.Parameters.Add(New SqlParameter("@Province_Id", Province_Id))
                connection.Open()
                Dim list As New Generic.List(Of PRICE2_50)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New PRICE2_50(CInt(reader("ID")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CStr(reader("AID")), _
                                                CStr(reader("CID")), _
                                                CInt(reader("Temp_AID")), _
                                                CInt(reader("MysubColl_ID")), _
                                                CStr(reader("Address_No")), _
                                                CStr(reader("Building_Name")), _
                                                CStr(reader("Tumbon")), _
                                                CStr(reader("Amphur")), _
                                                CInt(reader("Province")), _
                                                CInt(reader("Rai")), _
                                                CInt(reader("Ngan")), _
                                                CDec(reader("Wah")), _
                                                CStr(reader("Road")), _
                                                CInt(reader("Road_Detail")), _
                                                CDec(reader("Road_Access")), _
                                                CInt(reader("Road_Frontoff")), _
                                                CDec(reader("Roadwidth")), _
                                                CInt(reader("Sited")), _
                                                CStr(reader("Site_Detail")), _
                                                CInt(reader("Land_State")), _
                                                CStr(reader("Land_State_Detail")), _
                                                CInt(reader("Public_Utility")), _
                                                CStr(reader("Public_Utility_Detail")), _
                                                CInt(reader("Binifit")), _
                                                CStr(reader("Binifit_Detail")), _
                                                CInt(reader("Tendency")), _
                                                CInt(reader("BuySale_State")), _
                                                CInt(reader("SubUnit_Id")), _
                                                CDec(reader("PriceWah")), _
                                                CDec(reader("PriceTotal1")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using

    End Function

    Public Shared Sub DELETE_PRICE2_50(ByVal Id As String, _
ByVal Req_Id As Integer, _
ByVal Hub_Id As Integer)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("DELETE_PRICE2_50", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Id", Id))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub DELETE_PRICE2_50_BY_REQ_ID(ByVal Req_Id As Integer, ByVal Hub_Id As Integer)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("DELETE_PRICE2_50_BY_REQ_ID", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

#End Region

#Region "PRICE2-70"

    Public Shared Sub AddPRICE2_70(ByVal ID As Integer, _
     ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
     ByVal AID As String, _
     ByVal CID As String, _
     ByVal Temp_AID As Integer, _
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
     ByVal Create_User As String, _
     ByVal Create_Date As Date)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("AddPRICE2_70", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@ID", ID))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@AID", AID))
                    command.Parameters.Add(New SqlParameter("@CID", CID))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@MysubColl_ID", MysubColl_ID))
                    command.Parameters.Add(New SqlParameter("@Build_No", Build_No))
                    command.Parameters.Add(New SqlParameter("@Tumbon", Tumbon))
                    command.Parameters.Add(New SqlParameter("@Amphur", Amphur))
                    command.Parameters.Add(New SqlParameter("@Province", Province))
                    command.Parameters.Add(New SqlParameter("@Build_Character", Build_Character))
                    command.Parameters.Add(New SqlParameter("@Floors", Floors))
                    command.Parameters.Add(New SqlParameter("@Item", Item))
                    command.Parameters.Add(New SqlParameter("@Build_Construct", Build_Construct))
                    command.Parameters.Add(New SqlParameter("@Roof", Roof))
                    command.Parameters.Add(New SqlParameter("@Roof_Detail", Roof_Detail))
                    command.Parameters.Add(New SqlParameter("@Build_State", Build_State))
                    command.Parameters.Add(New SqlParameter("@Build_State_Detail", Build_State_Detail))
                    command.Parameters.Add(New SqlParameter("@Building_Detail", Building_Detail))
                    command.Parameters.Add(New SqlParameter("@PriceTotal1", PriceTotal1))
                    command.Parameters.Add(New SqlParameter("@Doc1", Doc1))
                    command.Parameters.Add(New SqlParameter("@Doc2", Doc2))
                    command.Parameters.Add(New SqlParameter("@Doc_Detail", Doc_Detail))
                    command.Parameters.Add(New SqlParameter("@Pic_path", Pic_path))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub UpdatePRICE2_70(ByVal ID As Integer, _
     ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
     ByVal AID As String, _
     ByVal CID As String, _
     ByVal Temp_AID As Integer, _
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
     ByVal Create_User As String, _
     ByVal Create_Date As Date)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UpdatePRICE2_70", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@ID", ID))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@AID", AID))
                    command.Parameters.Add(New SqlParameter("@CID", CID))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@MysubColl_ID", MysubColl_ID))
                    command.Parameters.Add(New SqlParameter("@Build_No", Build_No))
                    command.Parameters.Add(New SqlParameter("@Tumbon", Tumbon))
                    command.Parameters.Add(New SqlParameter("@Amphur", Amphur))
                    command.Parameters.Add(New SqlParameter("@Province", Province))
                    command.Parameters.Add(New SqlParameter("@Build_Character", Build_Character))
                    command.Parameters.Add(New SqlParameter("@Floors", Floors))
                    command.Parameters.Add(New SqlParameter("@Item", Item))
                    command.Parameters.Add(New SqlParameter("@Build_Construct", Build_Construct))
                    command.Parameters.Add(New SqlParameter("@Roof", Roof))
                    command.Parameters.Add(New SqlParameter("@Roof_Detail", Roof_Detail))
                    command.Parameters.Add(New SqlParameter("@Build_State", Build_State))
                    command.Parameters.Add(New SqlParameter("@Build_State_Detail", Build_State_Detail))
                    command.Parameters.Add(New SqlParameter("@Building_Detail", Building_Detail))
                    command.Parameters.Add(New SqlParameter("@PriceTotal1", PriceTotal1))
                    command.Parameters.Add(New SqlParameter("@Doc1", Doc1))
                    command.Parameters.Add(New SqlParameter("@Doc2", Doc2))
                    command.Parameters.Add(New SqlParameter("@Doc_Detail", Doc_Detail))
                    command.Parameters.Add(New SqlParameter("@Pic_path", Pic_path))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Function GET_PRICE2_70(ByVal ID As Integer, ByVal Req_Id As Integer, ByVal Hub_Id As Integer) As Generic.List(Of PRICE2_70)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE2_70", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@ID", ID))
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                'MsgBox(ID & "  " & Req_Id & "  " & Hub_Id)
                connection.Open()
                Dim list As New Generic.List(Of PRICE2_70)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New PRICE2_70(CInt(reader("ID")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CStr(reader("AID")), _
                                                CStr(reader("CID")), _
                                                CInt(reader("Temp_AID")), _
                                                CInt(reader("MysubColl_ID")), _
                                                CStr(reader("Build_No")), _
                                                CStr(reader("Tumbon")), _
                                                CStr(reader("Amphur")), _
                                                CInt(reader("Province")), _
                                                CInt(reader("Build_Character")), _
                                                CStr(reader("Floors")), _
                                                CInt(reader("Item")), _
                                                CInt(reader("Build_Construct")), _
                                                CInt(reader("Roof")), _
                                                CStr(reader("Roof_Detail")), _
                                                CInt(reader("Build_State")), _
                                                CStr(reader("Build_State_Detail")), _
                                                CStr(reader("Building_Detail")), _
                                                CDec(reader("PriceTotal1")), _
                                                CInt(reader("Doc1")), _
                                                CInt(reader("Doc2")), _
                                                CStr(reader("Doc_Detail")), _
                                                CStr(reader("Pic_path")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using

    End Function

    Public Shared Function GET_PRICE2_70_FOR_PRINT(ByVal Req_Id As Integer, ByVal Hub_Id As Integer) As Generic.List(Of PRICE2_70)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE2_70_FOR_PRINT", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                'MsgBox(ID & "  " & Req_Id & "  " & Hub_Id)
                connection.Open()
                Dim list As New Generic.List(Of PRICE2_70)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New PRICE2_70(CInt(reader("ID")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CStr(reader("AID")), _
                                                CStr(reader("CID")), _
                                                CInt(reader("Temp_AID")), _
                                                CInt(reader("MysubColl_ID")), _
                                                CStr(reader("Build_No")), _
                                                CStr(reader("Tumbon")), _
                                                CStr(reader("Amphur")), _
                                                CInt(reader("Province")), _
                                                CInt(reader("Build_Character")), _
                                                CStr(reader("Floors")), _
                                                CInt(reader("Item")), _
                                                CInt(reader("Build_Construct")), _
                                                CInt(reader("Roof")), _
                                                CStr(reader("Roof_Detail")), _
                                                CInt(reader("Build_State")), _
                                                CStr(reader("Build_State_Detail")), _
                                                CStr(reader("Building_Detail")), _
                                                CDec(reader("PriceTotal1")), _
                                                CInt(reader("Doc1")), _
                                                CInt(reader("Doc2")), _
                                                CStr(reader("Doc_Detail")), _
                                                CStr(reader("Pic_path")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using

    End Function

    Public Shared Sub DELETE_PRICE2_70(ByVal Id As String, _
 ByVal Req_Id As Integer, _
 ByVal Hub_Id As Integer)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("DELETE_PRICE2_70", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Id", Id))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub ADD_PRICE2_70_NEW(ByVal Id As Integer, _
 ByVal Req_Id As Integer, _
 ByVal Hub_Id As Integer, _
 ByVal Temp_AID As Integer, _
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
 ByVal Ownership As String, _
 ByVal BuildingArea As Double, _
 ByVal BuildingUintPrice As Double, _
 ByVal BuildingPrice As Decimal, _
 ByVal BuildingAge As Integer, _
 ByVal BuildingPersent1 As Decimal, _
 ByVal BuildingPersent2 As Decimal, _
 ByVal BuildingPersent3 As Decimal, _
 ByVal BuildingPriceTotalDeteriorate As Decimal, _
 ByVal BuildingPercentFinish As Integer, _
 ByVal BuildingPriceFinish As Decimal, _
 ByVal BuildAddArea As Decimal, _
 ByVal BuildAddUintPrice As Decimal, _
 ByVal BuildAddPrice As Decimal, _
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
 ByVal Create_User As String, _
 ByVal Create_Date As Date)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("ADD_PRICE2_70_NEW", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Id", Id))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@MysubColl_ID", MysubColl_ID))
                    command.Parameters.Add(New SqlParameter("@Build_No", Build_No))
                    command.Parameters.Add(New SqlParameter("@Tumbon", Tumbon))
                    command.Parameters.Add(New SqlParameter("@Amphur", Amphur))
                    command.Parameters.Add(New SqlParameter("@Province", Province))
                    command.Parameters.Add(New SqlParameter("@Build_Character", Build_Character))
                    command.Parameters.Add(New SqlParameter("@Floors", Floors))
                    command.Parameters.Add(New SqlParameter("@Item", Item))
                    command.Parameters.Add(New SqlParameter("@Build_Construct", Build_Construct))
                    command.Parameters.Add(New SqlParameter("@Roof", Roof))
                    command.Parameters.Add(New SqlParameter("@Roof_Detail", Roof_Detail))
                    command.Parameters.Add(New SqlParameter("@Build_State", Build_State))
                    command.Parameters.Add(New SqlParameter("@Build_State_Detail", Build_State_Detail))
                    command.Parameters.Add(New SqlParameter("@Building_Detail", Building_Detail))
                    command.Parameters.Add(New SqlParameter("@PriceTotal1", PriceTotal1))
                    command.Parameters.Add(New SqlParameter("@Doc1", Doc1))
                    command.Parameters.Add(New SqlParameter("@Doc2", Doc2))
                    command.Parameters.Add(New SqlParameter("@Doc_Detail", Doc_Detail))
                    command.Parameters.Add(New SqlParameter("@Pic_path", Pic_path))
                    command.Parameters.Add(New SqlParameter("@Put_On_Chanode", Put_On_Chanode))
                    command.Parameters.Add(New SqlParameter("@Ownership", Ownership))
                    command.Parameters.Add(New SqlParameter("@BuildingArea", BuildingArea))
                    command.Parameters.Add(New SqlParameter("@BuildingUintPrice", BuildingUintPrice))
                    command.Parameters.Add(New SqlParameter("@BuildingPrice", BuildingPrice))
                    command.Parameters.Add(New SqlParameter("@BuildingAge", BuildingAge))
                    command.Parameters.Add(New SqlParameter("@BuildingPersent1", BuildingPersent1))
                    command.Parameters.Add(New SqlParameter("@BuildingPersent2", BuildingPersent2))
                    command.Parameters.Add(New SqlParameter("@BuildingPersent3", BuildingPersent3))
                    command.Parameters.Add(New SqlParameter("@BuildingPriceTotalDeteriorate", BuildingPriceTotalDeteriorate))
                    command.Parameters.Add(New SqlParameter("@BuildingPercentFinish", BuildingPercentFinish))
                    command.Parameters.Add(New SqlParameter("@BuildingPriceFinish", BuildingPriceFinish))
                    command.Parameters.Add(New SqlParameter("@BuildAddArea", BuildAddArea))
                    command.Parameters.Add(New SqlParameter("@BuildAddUintPrice", BuildAddUintPrice))
                    command.Parameters.Add(New SqlParameter("@BuildAddPrice", BuildAddPrice))
                    command.Parameters.Add(New SqlParameter("@BuildAddAge", BuildAddAge))
                    command.Parameters.Add(New SqlParameter("@BuildAddPersent1", BuildAddPersent1))
                    command.Parameters.Add(New SqlParameter("@BuildAddPersent2", BuildAddPersent2))
                    command.Parameters.Add(New SqlParameter("@BuildAddPersent3", BuildAddPersent3))
                    command.Parameters.Add(New SqlParameter("@BuildAddPriceTotalDeteriorate", BuildAddPriceTotalDeteriorate))
                    command.Parameters.Add(New SqlParameter("@BuildAddPercentFinish", BuildAddPercentFinish))
                    command.Parameters.Add(New SqlParameter("@BuildAddPriceFinish", BuildAddPriceFinish))
                    command.Parameters.Add(New SqlParameter("@BuildingDetail", BuildingDetail))
                    command.Parameters.Add(New SqlParameter("@Decoration", Decoration))
                    command.Parameters.Add(New SqlParameter("@Standard_Id", Standard_Id))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    Throw New Exception(ex.Message & " : " & ex.StackTrace)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub UPDATE_PRICE2_70_NEW(ByVal Id As Integer, _
     ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
     ByVal Temp_AID As Integer, _
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
     ByVal Ownership As String, _
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
     ByVal Create_User As String, _
     ByVal Create_Date As Date)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_PRICE2_70_NEW", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Id", Id))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@MysubColl_ID", MysubColl_ID))
                    command.Parameters.Add(New SqlParameter("@Build_No", Build_No))
                    command.Parameters.Add(New SqlParameter("@Tumbon", Tumbon))
                    command.Parameters.Add(New SqlParameter("@Amphur", Amphur))
                    command.Parameters.Add(New SqlParameter("@Province", Province))
                    command.Parameters.Add(New SqlParameter("@Build_Character", Build_Character))
                    command.Parameters.Add(New SqlParameter("@Floors", Floors))
                    command.Parameters.Add(New SqlParameter("@Item", Item))
                    command.Parameters.Add(New SqlParameter("@Build_Construct", Build_Construct))
                    command.Parameters.Add(New SqlParameter("@Roof", Roof))
                    command.Parameters.Add(New SqlParameter("@Roof_Detail", Roof_Detail))
                    command.Parameters.Add(New SqlParameter("@Build_State", Build_State))
                    command.Parameters.Add(New SqlParameter("@Build_State_Detail", Build_State_Detail))
                    command.Parameters.Add(New SqlParameter("@Building_Detail", Building_Detail))
                    command.Parameters.Add(New SqlParameter("@PriceTotal1", PriceTotal1))
                    command.Parameters.Add(New SqlParameter("@Doc1", Doc1))
                    command.Parameters.Add(New SqlParameter("@Doc2", Doc2))
                    command.Parameters.Add(New SqlParameter("@Doc_Detail", Doc_Detail))
                    command.Parameters.Add(New SqlParameter("@Pic_path", Pic_path))
                    command.Parameters.Add(New SqlParameter("@Put_On_Chanode", Put_On_Chanode))
                    command.Parameters.Add(New SqlParameter("@Ownership", Ownership))
                    command.Parameters.Add(New SqlParameter("@BuildingArea", BuildingArea))
                    command.Parameters.Add(New SqlParameter("@BuildingUintPrice", BuildingUintPrice))
                    command.Parameters.Add(New SqlParameter("@BuildingPrice", BuildingPrice))
                    command.Parameters.Add(New SqlParameter("@BuildingAge", BuildingAge))
                    command.Parameters.Add(New SqlParameter("@BuildingPersent1", BuildingPersent1))
                    command.Parameters.Add(New SqlParameter("@BuildingPersent2", BuildingPersent2))
                    command.Parameters.Add(New SqlParameter("@BuildingPersent3", BuildingPersent3))
                    command.Parameters.Add(New SqlParameter("@BuildingPriceTotalDeteriorate", BuildingPriceTotalDeteriorate))
                    command.Parameters.Add(New SqlParameter("@BuildingPercentFinish", BuildingPercentFinish))
                    command.Parameters.Add(New SqlParameter("@BuildingPriceFinish", BuildingPriceFinish))
                    command.Parameters.Add(New SqlParameter("@BuildAddArea", BuildAddArea))
                    command.Parameters.Add(New SqlParameter("@BuildAddUintPrice", BuildAddUintPrice))
                    command.Parameters.Add(New SqlParameter("@BuildAddPrice", BuildAddPrice))
                    command.Parameters.Add(New SqlParameter("@BuildAddAge", BuildAddAge))
                    command.Parameters.Add(New SqlParameter("@BuildAddPersent1", BuildAddPersent1))
                    command.Parameters.Add(New SqlParameter("@BuildAddPersent2", BuildAddPersent2))
                    command.Parameters.Add(New SqlParameter("@BuildAddPersent3", BuildAddPersent3))
                    command.Parameters.Add(New SqlParameter("@BuildAddPriceTotalDeteriorate", BuildAddPriceTotalDeteriorate))
                    command.Parameters.Add(New SqlParameter("@BuildAddPercentFinish", BuildAddPercentFinish))
                    command.Parameters.Add(New SqlParameter("@BuildAddPriceFinish", BuildAddPriceFinish))
                    command.Parameters.Add(New SqlParameter("@BuildingDetail", BuildingDetail))
                    command.Parameters.Add(New SqlParameter("@Decoration", Decoration))
                    command.Parameters.Add(New SqlParameter("@Standard_Id", Standard_Id))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub UPDATE_PRICE2_70_NEW_BUILDING(ByVal Req_Id As Integer, _
 ByVal Hub_Id As Integer, _
 ByVal Temp_AID As Integer, _
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
 ByVal Ownership As String, _
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
 ByVal Create_User As String, _
 ByVal Create_Date As Date)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_PRICE2_70_NEW_BUILDING", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@MysubColl_ID", MysubColl_ID))
                    command.Parameters.Add(New SqlParameter("@Build_No", Build_No))
                    command.Parameters.Add(New SqlParameter("@Tumbon", Tumbon))
                    command.Parameters.Add(New SqlParameter("@Amphur", Amphur))
                    command.Parameters.Add(New SqlParameter("@Province", Province))
                    command.Parameters.Add(New SqlParameter("@Build_Character", Build_Character))
                    command.Parameters.Add(New SqlParameter("@Floors", Floors))
                    command.Parameters.Add(New SqlParameter("@Item", Item))
                    command.Parameters.Add(New SqlParameter("@Build_Construct", Build_Construct))
                    command.Parameters.Add(New SqlParameter("@Roof", Roof))
                    command.Parameters.Add(New SqlParameter("@Roof_Detail", Roof_Detail))
                    command.Parameters.Add(New SqlParameter("@Build_State", Build_State))
                    command.Parameters.Add(New SqlParameter("@Build_State_Detail", Build_State_Detail))
                    command.Parameters.Add(New SqlParameter("@Building_Detail", Building_Detail))
                    command.Parameters.Add(New SqlParameter("@PriceTotal1", PriceTotal1))
                    command.Parameters.Add(New SqlParameter("@Doc1", Doc1))
                    command.Parameters.Add(New SqlParameter("@Doc2", Doc2))
                    command.Parameters.Add(New SqlParameter("@Doc_Detail", Doc_Detail))
                    command.Parameters.Add(New SqlParameter("@Pic_path", Pic_path))
                    command.Parameters.Add(New SqlParameter("@Put_On_Chanode", Put_On_Chanode))
                    command.Parameters.Add(New SqlParameter("@Ownership", Ownership))
                    command.Parameters.Add(New SqlParameter("@BuildingArea", BuildingArea))
                    command.Parameters.Add(New SqlParameter("@BuildingUintPrice", BuildingUintPrice))
                    command.Parameters.Add(New SqlParameter("@BuildingPrice", BuildingPrice))
                    command.Parameters.Add(New SqlParameter("@BuildingAge", BuildingAge))
                    command.Parameters.Add(New SqlParameter("@BuildingPersent1", BuildingPersent1))
                    command.Parameters.Add(New SqlParameter("@BuildingPersent2", BuildingPersent2))
                    command.Parameters.Add(New SqlParameter("@BuildingPersent3", BuildingPersent3))
                    command.Parameters.Add(New SqlParameter("@BuildingPriceTotalDeteriorate", BuildingPriceTotalDeteriorate))
                    command.Parameters.Add(New SqlParameter("@BuildingPercentFinish", BuildingPercentFinish))
                    command.Parameters.Add(New SqlParameter("@BuildingPriceFinish", BuildingPriceFinish))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub UPDATE_PRICE2_70_NEW_BUILDING_PLUS(ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
     ByVal Building_No As String, _
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
     ByVal Create_User As String, _
     ByVal Create_Date As Date)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_PRICE2_70_NEW_BUILDING_PLUS", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Building_No", Building_No))
                    command.Parameters.Add(New SqlParameter("@BuildAddArea", BuildAddArea))
                    command.Parameters.Add(New SqlParameter("@BuildAddUintPrice", BuildAddUintPrice))
                    command.Parameters.Add(New SqlParameter("@BuildAddPrice", BuildAddPrice))
                    command.Parameters.Add(New SqlParameter("@BuildAddAge", BuildAddAge))
                    command.Parameters.Add(New SqlParameter("@BuildAddPersent1", BuildAddPersent1))
                    command.Parameters.Add(New SqlParameter("@BuildAddPersent2", BuildAddPersent2))
                    command.Parameters.Add(New SqlParameter("@BuildAddPersent3", BuildAddPersent3))
                    command.Parameters.Add(New SqlParameter("@BuildAddPriceTotalDeteriorate", BuildAddPriceTotalDeteriorate))
                    command.Parameters.Add(New SqlParameter("@BuildAddPercentFinish", BuildAddPercentFinish))
                    command.Parameters.Add(New SqlParameter("@BuildAddPriceFinish", BuildAddPriceFinish))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Function GET_PRICE2_70_NEW(ByVal ID As Integer, ByVal Req_Id As Integer, ByVal Hub_Id As Integer) As Generic.List(Of Price2_70_New)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE2_70_NEW", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@ID", ID))
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                connection.Open()
                Dim list As New Generic.List(Of Price2_70_New)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Price2_70_New(CInt(reader("ID")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CInt(reader("Temp_AID")), _
                                                CInt(reader("MysubColl_ID")), _
                                                CStr(reader("Build_No")), _
                                                CStr(reader("Tumbon")), _
                                                CStr(reader("Amphur")), _
                                                CInt(reader("Province")), _
                                                CInt(reader("Build_Character")), _
                                                CStr(reader("Floors")), _
                                                CInt(reader("Item")), _
                                                CInt(reader("Build_Construct")), _
                                                CInt(reader("Roof")), _
                                                CStr(reader("Roof_Detail")), _
                                                CInt(reader("Build_State")), _
                                                CStr(reader("Build_State_Detail")), _
                                                CStr(reader("Building_Detail")), _
                                                CDec(reader("PriceTotal1")), _
                                                CInt(reader("Doc1")), _
                                                CInt(reader("Doc2")), _
                                                CStr(reader("Doc_Detail")), _
                                                CStr(reader("Pic_path")), _
                                                CStr(reader("Put_On_Chanode")), _
                                                CStr(reader("Ownership")), _
                                                CDec(reader("BuildingArea")), _
                                                CDec(reader("BuildingUintPrice")), _
                                                CDec(reader("BuildingPrice")), _
                                                CInt(reader("BuildingAge")), _
                                                CDec(reader("BuildingPersent1")), _
                                                CDec(reader("BuildingPersent2")), _
                                                CDec(reader("BuildingPersent3")), _
                                                CDec(reader("BuildingPriceTotalDeteriorate")), _
                                                CInt(reader("BuildingPercentFinish")), _
                                                CDec(reader("BuildingPriceFinish")), _
                                                CDec(reader("BuildAddArea")), _
                                                CDec(reader("BuildAddUintPrice")), _
                                                CDec(reader("BuildAddPrice")), _
                                                CDec(reader("BuildAddAge")), _
                                                CDec(reader("BuildAddPersent1")), _
                                                CDec(reader("BuildAddPersent2")), _
                                                CDec(reader("BuildAddPersent3")), _
                                                CDec(reader("BuildAddPriceTotalDeteriorate")), _
                                                CInt(reader("BuildAddPercentFinish")), _
                                                CDec(reader("BuildAddPriceFinish")), _
                                                CStr(reader("BuildingDetail")), _
                                                CInt(reader("Decoration")), _
                                                CInt(reader("Standard_Id")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using

    End Function

    Public Shared Function GET_PRICE2_70_NEW_VERIFY_UPDATE(ByVal Req_Id As Integer, ByVal Hub_Id As Integer, ByVal Address_No As String) As Generic.List(Of Price2_70_New)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE2_70_NEW_VERIFY_UPDATE", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                command.Parameters.Add(New SqlParameter("@Address_No", Address_No))
                connection.Open()
                Dim list As New Generic.List(Of Price2_70_New)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Price2_70_New(CInt(reader("ID")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CInt(reader("Temp_AID")), _
                                                CInt(reader("MysubColl_ID")), _
                                                CStr(reader("Build_No")), _
                                                CStr(reader("Tumbon")), _
                                                CStr(reader("Amphur")), _
                                                CInt(reader("Province")), _
                                                CInt(reader("Build_Character")), _
                                                CStr(reader("Floors")), _
                                                CInt(reader("Item")), _
                                                CInt(reader("Build_Construct")), _
                                                CInt(reader("Roof")), _
                                                CStr(reader("Roof_Detail")), _
                                                CInt(reader("Build_State")), _
                                                CStr(reader("Build_State_Detail")), _
                                                CStr(reader("Building_Detail")), _
                                                CDec(reader("PriceTotal1")), _
                                                CInt(reader("Doc1")), _
                                                CInt(reader("Doc2")), _
                                                CStr(reader("Doc_Detail")), _
                                                CStr(reader("Pic_path")), _
                                                CStr(reader("Put_On_Chanode")), _
                                                CStr(reader("Ownership")), _
                                                CDec(reader("BuildingArea")), _
                                                CDec(reader("BuildingUintPrice")), _
                                                CDec(reader("BuildingPrice")), _
                                                CInt(reader("BuildingAge")), _
                                                CDec(reader("BuildingPersent1")), _
                                                CDec(reader("BuildingPersent2")), _
                                                CDec(reader("BuildingPersent3")), _
                                                CDec(reader("BuildingPriceTotalDeteriorate")), _
                                                CInt(reader("BuildingPercentFinish")), _
                                                CDec(reader("BuildingPriceFinish")), _
                                                CDec(reader("BuildAddArea")), _
                                                CDec(reader("BuildAddUintPrice")), _
                                                CDec(reader("BuildAddPrice")), _
                                                CDec(reader("BuildAddAge")), _
                                                CDec(reader("BuildAddPersent1")), _
                                                CDec(reader("BuildAddPersent2")), _
                                                CDec(reader("BuildAddPersent3")), _
                                                CDec(reader("BuildAddPriceTotalDeteriorate")), _
                                                CInt(reader("BuildAddPercentFinish")), _
                                                CDec(reader("BuildAddPriceFinish")), _
                                                CStr(reader("BuildingDetail")), _
                                                CInt(reader("Decoration")), _
                                                CInt(reader("Standard_Id")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using

    End Function

    Public Shared Function GET_PRICE2_70_NEW_TEMP_AID(ByVal ID As Integer, ByVal Req_Id As Integer, ByVal Hub_Id As Integer, ByVal Temp_AID As Integer) As Generic.List(Of Price2_70_New)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE2_70_NEW_TEMP_AID", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@ID", ID))
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                connection.Open()
                Dim list As New Generic.List(Of Price2_70_New)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Price2_70_New(CInt(reader("ID")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CInt(reader("Temp_AID")), _
                                                CInt(reader("MysubColl_ID")), _
                                                CStr(reader("Build_No")), _
                                                CStr(reader("Tumbon")), _
                                                CStr(reader("Amphur")), _
                                                CInt(reader("Province")), _
                                                CInt(reader("Build_Character")), _
                                                CStr(reader("Floors")), _
                                                CInt(reader("Item")), _
                                                CInt(reader("Build_Construct")), _
                                                CInt(reader("Roof")), _
                                                CStr(reader("Roof_Detail")), _
                                                CInt(reader("Build_State")), _
                                                CStr(reader("Build_State_Detail")), _
                                                CStr(reader("Building_Detail")), _
                                                CDec(reader("PriceTotal1")), _
                                                CInt(reader("Doc1")), _
                                                CInt(reader("Doc2")), _
                                                CStr(reader("Doc_Detail")), _
                                                CStr(reader("Pic_path")), _
                                                CStr(reader("Put_On_Chanode")), _
                                                CStr(reader("Ownership")), _
                                                CDec(reader("BuildingArea")), _
                                                CDec(reader("BuildingUintPrice")), _
                                                CDec(reader("BuildingPrice")), _
                                                CInt(reader("BuildingAge")), _
                                                CDec(reader("BuildingPersent1")), _
                                                CDec(reader("BuildingPersent2")), _
                                                CDec(reader("BuildingPersent3")), _
                                                CDec(reader("BuildingPriceTotalDeteriorate")), _
                                                CInt(reader("BuildingPercentFinish")), _
                                                CDec(reader("BuildingPriceFinish")), _
                                                CDec(reader("BuildAddArea")), _
                                                CDec(reader("BuildAddUintPrice")), _
                                                CDec(reader("BuildAddPrice")), _
                                                CDec(reader("BuildAddAge")), _
                                                CDec(reader("BuildAddPersent1")), _
                                                CDec(reader("BuildAddPersent2")), _
                                                CDec(reader("BuildAddPersent3")), _
                                                CDec(reader("BuildAddPriceTotalDeteriorate")), _
                                                CInt(reader("BuildAddPercentFinish")), _
                                                CDec(reader("BuildAddPriceFinish")), _
                                                CStr(reader("BuildingDetail")), _
                                                CInt(reader("Decoration")), _
                                                CInt(reader("Standard_Id")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using

    End Function

    Public Shared Function GET_PRICE2_70_NEW_BY_REQID_HUBID(ByVal Req_Id As Integer, ByVal Hub_Id As Integer, ByVal Temp_AID As Integer) As Generic.List(Of Price2_70_New)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE2_70_NEW_BY_REQID_HUBID", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                connection.Open()
                Dim list As New Generic.List(Of Price2_70_New)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Price2_70_New(CInt(reader("ID")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CInt(reader("Temp_AID")), _
                                                CInt(reader("MysubColl_ID")), _
                                                CStr(reader("Build_No")), _
                                                CStr(reader("Tumbon")), _
                                                CStr(reader("Amphur")), _
                                                CInt(reader("Province")), _
                                                CInt(reader("Build_Character")), _
                                                CStr(reader("Floors")), _
                                                CInt(reader("Item")), _
                                                CInt(reader("Build_Construct")), _
                                                CInt(reader("Roof")), _
                                                CStr(reader("Roof_Detail")), _
                                                CInt(reader("Build_State")), _
                                                CStr(reader("Build_State_Detail")), _
                                                CStr(reader("Building_Detail")), _
                                                CDec(reader("PriceTotal1")), _
                                                CInt(reader("Doc1")), _
                                                CInt(reader("Doc2")), _
                                                CStr(reader("Doc_Detail")), _
                                                CStr(reader("Pic_path")), _
                                                CStr(reader("Put_On_Chanode")), _
                                                CStr(reader("Ownership")), _
                                                CDec(reader("BuildingArea")), _
                                                CDec(reader("BuildingUintPrice")), _
                                                CDec(reader("BuildingPrice")), _
                                                CInt(reader("BuildingAge")), _
                                                CDec(reader("BuildingPersent1")), _
                                                CDec(reader("BuildingPersent2")), _
                                                CDec(reader("BuildingPersent3")), _
                                                CDec(reader("BuildingPriceTotalDeteriorate")), _
                                                CInt(reader("BuildingPercentFinish")), _
                                                CDec(reader("BuildingPriceFinish")), _
                                                CDec(reader("BuildAddArea")), _
                                                CDec(reader("BuildAddUintPrice")), _
                                                CDec(reader("BuildAddPrice")), _
                                                CDec(reader("BuildAddAge")), _
                                                CDec(reader("BuildAddPersent1")), _
                                                CDec(reader("BuildAddPersent2")), _
                                                CDec(reader("BuildAddPersent3")), _
                                                CDec(reader("BuildAddPriceTotalDeteriorate")), _
                                                CInt(reader("BuildAddPercentFinish")), _
                                                CDec(reader("BuildAddPriceFinish")), _
                                                CStr(reader("BuildingDetail")), _
                                                CInt(reader("Decoration")), _
                                                CInt(reader("Standard_Id")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using

    End Function

    Public Shared Sub ADD_PRICE2_70_DETAIL(ByVal Id As Integer, _
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

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("ADD_PRICE2_70_DETAIL", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Id", Id))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@Floors", Floor))
                    command.Parameters.Add(New SqlParameter("@Main_Construction", Main_Construction))
                    command.Parameters.Add(New SqlParameter("@Concrete", Concrete))
                    command.Parameters.Add(New SqlParameter("@Granite", Granite))
                    command.Parameters.Add(New SqlParameter("@Parquet", Parquet))
                    command.Parameters.Add(New SqlParameter("@Ceramic", Ceramic))
                    command.Parameters.Add(New SqlParameter("@Wood", Wood))
                    command.Parameters.Add(New SqlParameter("@Other", Other))
                    command.Parameters.Add(New SqlParameter("@Other_Detail", Other_Detail))
                    command.Parameters.Add(New SqlParameter("@BrickWall", BrickWall))
                    command.Parameters.Add(New SqlParameter("@BlockBrickWall", BlockBrickWall))
                    command.Parameters.Add(New SqlParameter("@WoodWall", WoodWall))
                    command.Parameters.Add(New SqlParameter("@OtherWall", OtherWall))
                    command.Parameters.Add(New SqlParameter("@OtherWall_Detail", OtherWall_Detail))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub UPDATE_PRICE2_70_DETAIL(ByVal Id As String, _
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

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_PRICE2_70_DETAIL", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Id", Id))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@Floors", Floor))
                    command.Parameters.Add(New SqlParameter("@Main_Construction", Main_Construction))
                    command.Parameters.Add(New SqlParameter("@Concrete", Concrete))
                    command.Parameters.Add(New SqlParameter("@Granite", Granite))
                    command.Parameters.Add(New SqlParameter("@Parquet", Parquet))
                    command.Parameters.Add(New SqlParameter("@Ceramic", Ceramic))
                    command.Parameters.Add(New SqlParameter("@Wood", Wood))
                    command.Parameters.Add(New SqlParameter("@Other", Other))
                    command.Parameters.Add(New SqlParameter("@Other_Detail", Other_Detail))
                    command.Parameters.Add(New SqlParameter("@BrickWall", BrickWall))
                    command.Parameters.Add(New SqlParameter("@BlockBrickWall", BlockBrickWall))
                    command.Parameters.Add(New SqlParameter("@WoodWall", WoodWall))
                    command.Parameters.Add(New SqlParameter("@OtherWall", OtherWall))
                    command.Parameters.Add(New SqlParameter("@OtherWall_Detail", OtherWall_Detail))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    Dim msg As String
                    Dim title As String
                    Dim style As MsgBoxStyle
                    Dim response1 As MsgBoxResult
                    'msg = "การบันทึกผิดพลาด"   ' Define message.
                    msg = ex.Message
                    style = MsgBoxStyle.DefaultButton2 Or _
                       MsgBoxStyle.Critical Or MsgBoxStyle.YesNo
                    title = "ผลการบันทึก"   ' Define title.
                    ' Display message.
                    response1 = MsgBox(msg, style, title)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Function GET_PRICE2_70_DETAIL(ByVal ID As Integer, ByVal Req_Id As Integer, ByVal Hub_Id As Integer, ByVal Temp_AID As Integer, ByVal Floors As String) As Generic.List(Of Cls_Price2_70_Detail)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE2_70_DETAIL_BYID", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@ID", ID))
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                command.Parameters.Add(New SqlParameter("@Floors", Floors))
                connection.Open()
                Dim list As New Generic.List(Of Cls_Price2_70_Detail)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Cls_Price2_70_Detail(CInt(reader("Id")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CInt(reader("Temp_AID")), _
                                                CStr(reader("Floors")), _
                                                CStr(reader("Main_Construction")), _
                                                CInt(reader("Concrete")), _
                                                CInt(reader("Granite")), _
                                                CInt(reader("Parquet")), _
                                                CInt(reader("Ceramic")), _
                                                CInt(reader("Wood")), _
                                                CInt(reader("Other")), _
                                                CStr(reader("Other_Detail")), _
                                                CInt(reader("BrickWall")), _
                                                CInt(reader("BlockBrickWall")), _
                                                CInt(reader("WoodWall")), _
                                                CInt(reader("OtherWall")), _
                                                CStr(reader("OtherWall_Detail")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using

    End Function

    Public Shared Sub ADD_PRICE2_70_PARTAKE(ByVal Id As Integer, _
     ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
     ByVal Temp_AID As Integer, _
     ByVal AID As String, _
     ByVal Partake_Id As Integer, _
     ByVal Building_No As String, _
     ByVal PartakeArea As Double, _
     ByVal PartakeUintPrice As Double, _
     ByVal PartakePrice As Double, _
     ByVal PartakeAge As Integer, _
     ByVal PartakePersent1 As Decimal, _
     ByVal PartakePersent2 As Decimal, _
     ByVal PartakePersent3 As Decimal, _
     ByVal PartakePriceTotalDeteriorate As Decimal, _
     ByVal PercentFinish As Integer, _
     ByVal PriceFinish As Decimal, _
     ByVal PartakeDetail As String, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("ADD_PRICE2_70_PARTAKE", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Id", Id))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@AID", AID))
                    command.Parameters.Add(New SqlParameter("@Partake_Id", Partake_Id))
                    command.Parameters.Add(New SqlParameter("@Building_No", Building_No))
                    command.Parameters.Add(New SqlParameter("@PartakeArea", PartakeArea))
                    command.Parameters.Add(New SqlParameter("@PartakeUintPrice", PartakeUintPrice))
                    command.Parameters.Add(New SqlParameter("@PartakePrice", PartakePrice))
                    command.Parameters.Add(New SqlParameter("@PartakeAge", PartakeAge))
                    command.Parameters.Add(New SqlParameter("@PartakePersent1", PartakePersent1))
                    command.Parameters.Add(New SqlParameter("@PartakePersent2", PartakePersent2))
                    command.Parameters.Add(New SqlParameter("@PartakePersent3", PartakePersent3))
                    command.Parameters.Add(New SqlParameter("@PartakePriceTotalDeteriorate", PartakePriceTotalDeteriorate))
                    command.Parameters.Add(New SqlParameter("@PercentFinish", PercentFinish))
                    command.Parameters.Add(New SqlParameter("@PriceFinish", PriceFinish))
                    command.Parameters.Add(New SqlParameter("@PartakeDetail", PartakeDetail))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    'command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    'MsgBox(ex.Message)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub UPDATE_PRICE2_70_PARTAKE(ByVal Id As Integer, _
     ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
     ByVal Temp_AID As Integer, _
     ByVal AID As String, _
     ByVal Partake_Id As Integer, _
     ByVal Building_No As String, _
     ByVal PartakeArea As Double, _
     ByVal PartakeUintPrice As Double, _
     ByVal PartakePrice As Double, _
     ByVal PartakeAge As Integer, _
     ByVal PartakePersent1 As Decimal, _
     ByVal PartakePersent2 As Decimal, _
     ByVal PartakePersent3 As Decimal, _
     ByVal PartakePriceTotalDeteriorate As Decimal, _
     ByVal PercentFinish As Integer, _
     ByVal PriceFinish As Decimal, _
     ByVal PartakeDetail As String, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_PRICE2_70_PARTAKE", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Id", Id))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@AID", AID))
                    command.Parameters.Add(New SqlParameter("@Partake_Id", Partake_Id))
                    command.Parameters.Add(New SqlParameter("@Building_No", Building_No))
                    command.Parameters.Add(New SqlParameter("@PartakeArea", PartakeArea))
                    command.Parameters.Add(New SqlParameter("@PartakeUintPrice", PartakeUintPrice))
                    command.Parameters.Add(New SqlParameter("@PartakePrice", PartakePrice))
                    command.Parameters.Add(New SqlParameter("@PartakeAge", PartakeAge))
                    command.Parameters.Add(New SqlParameter("@PartakePersent1", PartakePersent1))
                    command.Parameters.Add(New SqlParameter("@PartakePersent2", PartakePersent2))
                    command.Parameters.Add(New SqlParameter("@PartakePersent3", PartakePersent3))
                    command.Parameters.Add(New SqlParameter("@PartakePriceTotalDeteriorate", PartakePriceTotalDeteriorate))
                    command.Parameters.Add(New SqlParameter("@PercentFinish", PercentFinish))
                    command.Parameters.Add(New SqlParameter("@PriceFinish", PriceFinish))
                    command.Parameters.Add(New SqlParameter("@PartakeDetail", PartakeDetail))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    'command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    'MsgBox(ex.Message)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Function GET_PRICE2_70_PARTAKE(ByVal ID As Integer, ByVal REQ_ID As Integer, ByVal Hub_Id As Integer, ByVal TEMP_AID As Integer, ByVal Partake_Id As Integer) As Generic.List(Of Price2_70_Partake)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE2_70_PARTAKE_PK", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@ID", ID))
                command.Parameters.Add(New SqlParameter("@REQ_ID", REQ_ID))
                command.Parameters.Add(New SqlParameter("@HUB_ID", Hub_Id))
                command.Parameters.Add(New SqlParameter("@TEMP_AID", TEMP_AID))
                command.Parameters.Add(New SqlParameter("@PARTAKE_ID", Partake_Id))
                connection.Open()
                Dim list As New Generic.List(Of Price2_70_Partake)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Price2_70_Partake(CInt(reader("Id")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CInt(reader("Temp_AID")), _
                                                CStr(reader("AID")), _
                                                CInt(reader("Partake_Id")), _
                                                CStr(reader("Building_No")), _
                                                CDec(reader("PartakeArea")), _
                                                CDec(reader("PartakeUintPrice")), _
                                                CDec(reader("PartakePrice")), _
                                                CDec(reader("PartakeAge")), _
                                                CDec(reader("PartakePersent1")), _
                                                CDec(reader("PartakePersent2")), _
                                                CDec(reader("PartakePersent3")), _
                                                CDec(reader("PartakePriceTotalDeteriorate")), _
                                                CInt(reader("PercentFinish")), _
                                                CDec(reader("PriceFinish")), _
                                                CStr(reader("PartakeDetail")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using

    End Function

    Public Shared Function GET_PRICE2_70_PARTAKE_CHECK(ByVal REQ_ID As Integer, ByVal Hub_Id As Integer, ByVal Building_No As String, ByVal Partake_Id As Integer) As Generic.List(Of Price2_70_Partake)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE2_70_PARTAKE_CHECK", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@REQ_ID", REQ_ID))
                command.Parameters.Add(New SqlParameter("@HUB_ID", Hub_Id))
                command.Parameters.Add(New SqlParameter("@Building_No", Building_No))
                command.Parameters.Add(New SqlParameter("@PARTAKE_ID", Partake_Id))
                connection.Open()
                Dim list As New Generic.List(Of Price2_70_Partake)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Price2_70_Partake(CInt(reader("Id")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CInt(reader("Temp_AID")), _
                                                CStr(reader("AID")), _
                                                CInt(reader("Partake_Id")), _
                                                CStr(reader("Building_No")), _
                                                CDec(reader("PartakeArea")), _
                                                CDec(reader("PartakeUintPrice")), _
                                                CDec(reader("PartakePrice")), _
                                                CDec(reader("PartakeAge")), _
                                                CDec(reader("PartakePersent1")), _
                                                CDec(reader("PartakePersent2")), _
                                                CDec(reader("PartakePersent3")), _
                                                CDec(reader("PartakePriceTotalDeteriorate")), _
                                                CInt(reader("PercentFinish")), _
                                                CDec(reader("PriceFinish")), _
                                                CStr(reader("PartakeDetail")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using

    End Function

    Public Shared Function GET_PRICE2_70_GROUP_PARTAKE(ByVal Req_Id As Integer, ByVal Hub_Id As Integer, ByVal Temp_AID As Integer) As DataSet
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE2_70_PARTAKE_GROUP", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                connection.Open()
                Dim list As New SqlDataAdapter(command)
                'Using reader As SqlDataAdapter = command.ExecuteNonQuery()
                Dim ds As New DataSet
                list.Fill(ds)
                Return ds
                connection.Close()
            End Using
        End Using

    End Function

    Public Shared Function GET_BUILDING_ITEMS_PRICE2(ByVal Req_Id As Integer, ByVal Hub_Id As Integer) As Integer
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_BUILDING_ITEMS_PRICE2", connection)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                connection.Open()
                Dim list As New Integer
                Using reader As SqlDataReader = command.ExecuteReader()
                    Do While (reader.Read())
                        Dim temp As Integer = (reader("ITEMS"))
                        list = (temp)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using
    End Function

    Public Shared Function GET_BUILDING_ITEMS_PRICE3(ByVal Req_Id As Integer, ByVal Hub_Id As Integer) As Integer
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_BUILDING_ITEMS_PRICE3", connection)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                connection.Open()
                Dim list As New Integer
                Using reader As SqlDataReader = command.ExecuteReader()
                    Do While (reader.Read())
                        Dim temp As Integer = (reader("ITEMS"))
                        list = (temp)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using
    End Function

    Public Shared Sub UPDATE_PRICE2_70_DETAIL_AND_PARTAKE(ByVal Id As Integer, _
     ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
     ByVal Temp_AID As Integer)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_PRICE2_70_DETAIL_AND_PARTAKE", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Id", Id))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    'MsgBox(ex.Message)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub UPDATE_PRICE2_70_DETAIL_AND_PARTAKE_NEW(ByVal Req_Id As Integer, _
 ByVal Hub_Id As Integer, _
 ByVal Temp_AID As Integer)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_PRICE2_70_DETAIL_AND_PARTAKE_NEW", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    'MsgBox(ex.Message)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Function GET_PRICE2_70_NEW_CHANODE(ByVal Put_On_Chanode As String) As Generic.List(Of Price2_70_New)
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE2_70_NEW_CHANODE", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@Put_On_Chanode", Put_On_Chanode))
                connection.Open()
                Dim list As New Generic.List(Of Price2_70_New)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Price2_70_New(CInt(reader("ID")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CInt(reader("Temp_AID")), _
                                                CInt(reader("MysubColl_ID")), _
                                                CStr(reader("Build_No")), _
                                                CStr(reader("Tumbon")), _
                                                CStr(reader("Amphur")), _
                                                CInt(reader("Province")), _
                                                CInt(reader("Build_Character")), _
                                                CStr(reader("Floors")), _
                                                CInt(reader("Item")), _
                                                CInt(reader("Build_Construct")), _
                                                CInt(reader("Roof")), _
                                                CStr(reader("Roof_Detail")), _
                                                CInt(reader("Build_State")), _
                                                CStr(reader("Build_State_Detail")), _
                                                CStr(reader("Building_Detail")), _
                                                CDec(reader("PriceTotal1")), _
                                                CInt(reader("Doc1")), _
                                                CInt(reader("Doc2")), _
                                                CStr(reader("Doc_Detail")), _
                                                CStr(reader("Pic_path")), _
                                                CStr(reader("Put_On_Chanode")), _
                                                CStr(reader("Ownership")), _
                                                CDec(reader("BuildingArea")), _
                                                CDec(reader("BuildingUintPrice")), _
                                                CDec(reader("BuildingPrice")), _
                                                CInt(reader("BuildingAge")), _
                                                CDec(reader("BuildingPersent1")), _
                                                CDec(reader("BuildingPersent2")), _
                                                CDec(reader("BuildingPersent3")), _
                                                CDec(reader("BuildingPriceTotalDeteriorate")), _
                                                CInt(reader("BuildingPercentFinish")), _
                                                CDec(reader("BuildingPriceFinish")), _
                                                CDec(reader("BuildAddArea")), _
                                                CDec(reader("BuildAddUintPrice")), _
                                                CDec(reader("BuildAddPrice")), _
                                                CDec(reader("BuildAddAge")), _
                                                CDec(reader("BuildAddPersent1")), _
                                                CDec(reader("BuildAddPersent2")), _
                                                CDec(reader("BuildAddPersent3")), _
                                                CDec(reader("BuildAddPriceTotalDeteriorate")), _
                                                CInt(reader("BuildAddPercentFinish")), _
                                                CDec(reader("BuildAddPriceFinish")), _
                                                CStr(reader("BuildingDetail")), _
                                                CInt(reader("Decoration")), _
                                                CInt(reader("Standard_Id")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using

    End Function
#End Region

#Region "PRICE3"

    Public Shared Function CHECK_BEFORE_ADD_PRICE3(ByVal Req_Id As Integer, ByVal Temp_AID As Integer, ByVal Hub_Id As Integer, ByVal CollType_Id As Integer, ByVal Id As Integer) As Integer

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("CHECK_BEFORE_ADD_PRICE3", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                command.Parameters.Add(New SqlParameter("@CollType_Id", CollType_Id))
                command.Parameters.Add(New SqlParameter("@ID", Id))
                'MsgBox(ID & "  " & Req_Id & "  " & Hub_Id)
                connection.Open()
                Dim list As New Integer
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As Integer = (reader("qty"))
                        list = (temp)
                    Loop
                End Using
                Return list
            End Using
        End Using

    End Function

    Public Shared Sub AddPRICE3_Master(ByVal Req_Id As Integer, _
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
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("AddPRICE3_Master", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@AID", AID))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@Inform_To", Inform_To))
                    command.Parameters.Add(New SqlParameter("@Cif", Cif))
                    command.Parameters.Add(New SqlParameter("@Lat", Lat))
                    command.Parameters.Add(New SqlParameter("@Lng", Lng))
                    command.Parameters.Add(New SqlParameter("@Appraisal_Date", Appraisal_Date))
                    command.Parameters.Add(New SqlParameter("@Receive_Date", Receive_Date))
                    command.Parameters.Add(New SqlParameter("@PriceWah", PriceWah))
                    command.Parameters.Add(New SqlParameter("@TotalPrice", TotalPrice))
                    command.Parameters.Add(New SqlParameter("@BuildingPrice", BuildingPrice))
                    command.Parameters.Add(New SqlParameter("@Land_Building_Price", Land_Building_Price))
                    command.Parameters.Add(New SqlParameter("@Approved1", Approved1))
                    command.Parameters.Add(New SqlParameter("@Position_Approved1", Position_Approved1))
                    command.Parameters.Add(New SqlParameter("@Approved2", Approved2))
                    command.Parameters.Add(New SqlParameter("@Position_Approved2", Position_Approved2))
                    command.Parameters.Add(New SqlParameter("@Approved3", Approved3))
                    command.Parameters.Add(New SqlParameter("@Position_Approved3", Position_Approved3))
                    command.Parameters.Add(New SqlParameter("@Approved", Approved))
                    command.Parameters.Add(New SqlParameter("@Env_Effect", Env_Effect))
                    command.Parameters.Add(New SqlParameter("@Env_Effect_Detail", Env_Effect_Detail))
                    command.Parameters.Add(New SqlParameter("@Appraisal_Detail", Appraisal_Detail))
                    command.Parameters.Add(New SqlParameter("@Appraisal_Type_ID", Appraisal_Type_ID))
                    command.Parameters.Add(New SqlParameter("@Comment_ID", Comment_ID))
                    command.Parameters.Add(New SqlParameter("@Warning_ID", Warning_ID))
                    command.Parameters.Add(New SqlParameter("@Warning_Detail", Warning_Detail))
                    command.Parameters.Add(New SqlParameter("@Req_Dept", Req_Dept))
                    command.Parameters.Add(New SqlParameter("@Appraisal_ID", Appraisal_ID))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    Dim msg As String
                    Dim title As String
                    Dim style As MsgBoxStyle
                    Dim response1 As MsgBoxResult
                    'msg = "การบันทึกผิดพลาด"   ' Define message.
                    msg = ex.Message
                    style = MsgBoxStyle.DefaultButton2 Or _
                       MsgBoxStyle.Critical Or MsgBoxStyle.YesNo
                    title = "ผลการบันทึก"   ' Define title.
                    ' Display message.
                    response1 = MsgBox(msg, style, title)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub UPDATE_PRICE3_MASTER(ByVal Req_Id As Integer, _
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
  ByVal Approved2 As String, _
  ByVal Approved3 As String, _
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
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_PRICE3_MASTER", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@AID", AID))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@Inform_To", Inform_To))
                    command.Parameters.Add(New SqlParameter("@Cif", Cif))
                    command.Parameters.Add(New SqlParameter("@Lat", Lat))
                    command.Parameters.Add(New SqlParameter("@Lng", Lng))
                    command.Parameters.Add(New SqlParameter("@Appraisal_Date", Appraisal_Date))
                    command.Parameters.Add(New SqlParameter("@Receive_Date", Receive_Date))
                    command.Parameters.Add(New SqlParameter("@PriceWah", PriceWah))
                    command.Parameters.Add(New SqlParameter("@TotalPrice", TotalPrice))
                    command.Parameters.Add(New SqlParameter("@BuildingPrice", BuildingPrice))
                    command.Parameters.Add(New SqlParameter("@Land_Building_Price", Land_Building_Price))
                    command.Parameters.Add(New SqlParameter("@Approved1", Approved1))
                    command.Parameters.Add(New SqlParameter("@Approved2", Approved2))
                    command.Parameters.Add(New SqlParameter("@Approved3", Approved3))
                    command.Parameters.Add(New SqlParameter("@Approved", Approved))
                    command.Parameters.Add(New SqlParameter("@Env_Effect", Env_Effect))
                    command.Parameters.Add(New SqlParameter("@Env_Effect_Detail", Env_Effect_Detail))
                    command.Parameters.Add(New SqlParameter("@Appraisal_Detail", Appraisal_Detail))
                    command.Parameters.Add(New SqlParameter("@Appraisal_Type_ID", Appraisal_Type_ID))
                    command.Parameters.Add(New SqlParameter("@Comment_ID", Comment_ID))
                    command.Parameters.Add(New SqlParameter("@Warning_ID", Warning_ID))
                    command.Parameters.Add(New SqlParameter("@Warning_Detail", Warning_Detail))
                    command.Parameters.Add(New SqlParameter("@Req_Dept", Req_Dept))
                    command.Parameters.Add(New SqlParameter("@Appraisal_ID", Appraisal_ID))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    Dim msg As String
                    Dim title As String
                    Dim style As MsgBoxStyle
                    Dim response1 As MsgBoxResult
                    'msg = "การบันทึกผิดพลาด"   ' Define message.
                    msg = ex.Message
                    style = MsgBoxStyle.DefaultButton2 Or _
                       MsgBoxStyle.Critical Or MsgBoxStyle.YesNo
                    title = "ผลการบันทึก"   ' Define title.
                    ' Display message.
                    response1 = MsgBox(msg, style, title)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub UPDATE_PRICE3_MASTER_APPROVE(ByVal Req_Id As Integer, _
ByVal AID As String, _
ByVal Temp_AID As Integer, _
ByVal Cif As Integer)
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_PRICE3_MASTER_APPROVE", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@AID", AID))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@Cif", Cif))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    Dim msg As String
                    Dim title As String
                    Dim style As MsgBoxStyle
                    Dim response1 As MsgBoxResult
                    'msg = "การบันทึกผิดพลาด"   ' Define message.
                    msg = ex.Message
                    style = MsgBoxStyle.DefaultButton2 Or _
                       MsgBoxStyle.Critical Or MsgBoxStyle.YesNo
                    title = "ผลการบันทึก"   ' Define title.
                    ' Display message.
                    response1 = MsgBox(msg, style, title)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Function GET_PRICE3_MASTER(ByVal Req_Id As Integer, ByVal Temp_AID As Integer) As Generic.List(Of clsPrice3_Master)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE3_MASTER", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                connection.Open()
                Dim list As New Generic.List(Of clsPrice3_Master)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New clsPrice3_Master(CInt(reader("Req_Id")), _
                                                CStr(reader("AID")), _
                                                CInt(reader("Temp_AID")), _
                                                CStr(reader("Inform_To")), _
                                                CInt(reader("Cif")), _
                                                CDec(reader("Lat")), _
                                                CDec(reader("Lng")), _
                                                CDate(reader("Appraisal_Date")), _
                                                CDate(reader("Receive_Date")), _
                                                CDec(reader("Pricewah")), _
                                                CDec(reader("TotalPrice")), _
                                                CDec(reader("BuildingPrice")), _
                                                CDec(reader("Land_Building_Price")), _
                                                CStr(reader("Approved1")), _
                                                CInt(reader("Position_Approved1")), _
                                                CStr(reader("Approved2")), _
                                                CInt(reader("Position_Approved2")), _
                                                CStr(reader("Approved3")), _
                                                CInt(reader("Position_Approved3")), _
                                                CInt(reader("Approved")), _
                                                CInt(reader("Env_Effect")), _
                                                CStr(reader("Env_Effect_Detail")), _
                                                CStr(reader("Appraisal_Detail")), _
                                                CDec(reader("Appraisal_Type_ID")), _
                                                CInt(reader("Comment_ID")), _
                                                CDec(reader("Warning_ID")), _
                                                CStr(reader("Warning_Detail")), _
                                                CInt(reader("Req_Dept")), _
                                                CStr(reader("Appraisal_ID")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using

    End Function

    Public Shared Function GET_PRICE3_BY_AID(ByVal AID As String) As Generic.List(Of clsPrice3_Master)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE3_BY_AID", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@AID", AID))
                connection.Open()
                Dim list As New Generic.List(Of clsPrice3_Master)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New clsPrice3_Master(CInt(reader("Req_Id")), _
                                                CStr(reader("AID")), _
                                                CInt(reader("Temp_AID")), _
                                                CStr(reader("Inform_To")), _
                                                CInt(reader("Cif")), _
                                                CDec(reader("Lat")), _
                                                CDec(reader("Lng")), _
                                                CDate(reader("Appraisal_Date")), _
                                                CDate(reader("Receive_Date")), _
                                                CDec(reader("Pricewah")), _
                                                CDec(reader("TotalPrice")), _
                                                CDec(reader("BuildingPrice")), _
                                                CDec(reader("Land_Building_Price")), _
                                                CStr(reader("Approved1")), _
                                                CInt(reader("Position_Approved1")), _
                                                CStr(reader("Approved2")), _
                                                CInt(reader("Position_Approved2")), _
                                                CStr(reader("Approved3")), _
                                                CInt(reader("Position_Approved3")), _
                                                CInt(reader("Approved")), _
                                                CInt(reader("Env_Effect")), _
                                                CStr(reader("Env_Effect_Detail")), _
                                                CStr(reader("Appraisal_Detail")), _
                                                CDec(reader("Appraisal_Type_ID")), _
                                                CInt(reader("Comment_ID")), _
                                                CDec(reader("Warning_ID")), _
                                                CStr(reader("Warning_Detail")), _
                                                CInt(reader("Req_Dept")), _
                                                CStr(reader("Appraisal_ID")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using

    End Function

    Public Shared Sub ADD_PRICE3_18(ByVal ID As Integer, _
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

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("ADD_PRICE3_18", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@ID", ID))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@AID", AID))
                    command.Parameters.Add(New SqlParameter("@CID", CID))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@MysubColl_ID", MysubColl_ID))
                    command.Parameters.Add(New SqlParameter("@Floors_All", Floors_All))
                    command.Parameters.Add(New SqlParameter("@Elevator", Elevator))
                    command.Parameters.Add(New SqlParameter("@Address_No", Address_No))
                    command.Parameters.Add(New SqlParameter("@Room_Area", Room_Area))
                    command.Parameters.Add(New SqlParameter("@Room_Height", Room_Height))
                    command.Parameters.Add(New SqlParameter("@Building_Name", Building_Name))
                    command.Parameters.Add(New SqlParameter("@Floors", Floors))
                    command.Parameters.Add(New SqlParameter("@Building_No", Building_No))
                    command.Parameters.Add(New SqlParameter("@Building_Reg_No", Building_Reg_No))
                    command.Parameters.Add(New SqlParameter("@Building_Age", Building_Age))
                    command.Parameters.Add(New SqlParameter("@Tumbon", Tumbon))
                    command.Parameters.Add(New SqlParameter("@Amphur", Amphur))
                    command.Parameters.Add(New SqlParameter("@Province", Province))
                    command.Parameters.Add(New SqlParameter("@Road", Road))
                    command.Parameters.Add(New SqlParameter("@Road_Detail", Road_Detail))
                    command.Parameters.Add(New SqlParameter("@Road_Access", Road_Access))
                    command.Parameters.Add(New SqlParameter("@Road_Frontoff", Road_Frontoff))
                    command.Parameters.Add(New SqlParameter("@RoadWidth", RoadWidth))
                    command.Parameters.Add(New SqlParameter("@Site", Site))
                    command.Parameters.Add(New SqlParameter("@Site_Detail", Site_Detail))
                    command.Parameters.Add(New SqlParameter("@Public_Utility", Public_Utility))
                    command.Parameters.Add(New SqlParameter("@Public_Utility_Detail", Public_Utility_Detail))
                    command.Parameters.Add(New SqlParameter("@Binifit", Binifit))
                    command.Parameters.Add(New SqlParameter("@Binifit_Detail", Binifit_Detail))
                    command.Parameters.Add(New SqlParameter("@Tendency", Tendency))
                    command.Parameters.Add(New SqlParameter("@BuySale_State", BuySale_State))
                    command.Parameters.Add(New SqlParameter("@Building_Construc", Building_Construc))
                    command.Parameters.Add(New SqlParameter("@InteriorState_Id", InteriorState_Id))
                    command.Parameters.Add(New SqlParameter("@Character_Room_Id", Character_Room_Id))
                    command.Parameters.Add(New SqlParameter("@RoomWidth_BehideSiteWalk", RoomWidth_BehideSiteWalk))
                    command.Parameters.Add(New SqlParameter("@Roomdeep", Roomdeep))
                    command.Parameters.Add(New SqlParameter("@Backside_Width", Backside_Width))
                    command.Parameters.Add(New SqlParameter("@SideWalk_Is", SideWalk_Is))
                    command.Parameters.Add(New SqlParameter("@SideWalk_Width", SideWalk_Width))
                    command.Parameters.Add(New SqlParameter("@Partake_Detail", Partake_Detail))
                    command.Parameters.Add(New SqlParameter("@Ownership", Ownership))
                    command.Parameters.Add(New SqlParameter("@Obligation", Obligation))
                    command.Parameters.Add(New SqlParameter("@Other_Detail", Other_Detail))
                    command.Parameters.Add(New SqlParameter("@Tumbon1", Tumbon1))
                    command.Parameters.Add(New SqlParameter("@Amphur1", Amphur1))
                    command.Parameters.Add(New SqlParameter("@Province1", Province1))
                    command.Parameters.Add(New SqlParameter("@Elevator_Util", Elevator_Util))
                    command.Parameters.Add(New SqlParameter("@Parking_Util", Parking_Util))
                    command.Parameters.Add(New SqlParameter("@Pool_Util", Pool_Util))
                    command.Parameters.Add(New SqlParameter("@Fitness_Util", Fitness_Util))
                    command.Parameters.Add(New SqlParameter("@Other_Util", Other_Util))
                    command.Parameters.Add(New SqlParameter("@Other_Util_Detail", Other_Util_Detail))
                    command.Parameters.Add(New SqlParameter("@Adjust_Condo", Adjust_Condo))
                    command.Parameters.Add(New SqlParameter("@Unit_Price", Unit_Price))
                    command.Parameters.Add(New SqlParameter("@PriceTotal", PriceTotal))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    'MsgBox(ex.Message)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub UPDATE_PRICE3_18(ByVal ID As Integer, _
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

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_PRICE3_18", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@ID", ID))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@AID", AID))
                    command.Parameters.Add(New SqlParameter("@CID", CID))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@MysubColl_ID", MysubColl_ID))
                    command.Parameters.Add(New SqlParameter("@Floors_All", Floors_All))
                    command.Parameters.Add(New SqlParameter("@Elevator", Elevator))
                    command.Parameters.Add(New SqlParameter("@Address_No", Address_No))
                    command.Parameters.Add(New SqlParameter("@Room_Area", Room_Area))
                    command.Parameters.Add(New SqlParameter("@Room_Height", Room_Height))
                    command.Parameters.Add(New SqlParameter("@Building_Name", Building_Name))
                    command.Parameters.Add(New SqlParameter("@Floors", Floors))
                    command.Parameters.Add(New SqlParameter("@Building_No", Building_No))
                    command.Parameters.Add(New SqlParameter("@Building_Reg_No", Building_Reg_No))
                    command.Parameters.Add(New SqlParameter("@Building_Age", Building_Age))
                    command.Parameters.Add(New SqlParameter("@Tumbon", Tumbon))
                    command.Parameters.Add(New SqlParameter("@Amphur", Amphur))
                    command.Parameters.Add(New SqlParameter("@Province", Province))
                    command.Parameters.Add(New SqlParameter("@Road", Road))
                    command.Parameters.Add(New SqlParameter("@Road_Detail", Road_Detail))
                    command.Parameters.Add(New SqlParameter("@Road_Access", Road_Access))
                    command.Parameters.Add(New SqlParameter("@Road_Frontoff", Road_Frontoff))
                    command.Parameters.Add(New SqlParameter("@RoadWidth", RoadWidth))
                    command.Parameters.Add(New SqlParameter("@Site", Site))
                    command.Parameters.Add(New SqlParameter("@Site_Detail", Site_Detail))
                    command.Parameters.Add(New SqlParameter("@Public_Utility", Public_Utility))
                    command.Parameters.Add(New SqlParameter("@Public_Utility_Detail", Public_Utility_Detail))
                    command.Parameters.Add(New SqlParameter("@Binifit", Binifit))
                    command.Parameters.Add(New SqlParameter("@Binifit_Detail", Binifit_Detail))
                    command.Parameters.Add(New SqlParameter("@Tendency", Tendency))
                    command.Parameters.Add(New SqlParameter("@BuySale_State", BuySale_State))
                    command.Parameters.Add(New SqlParameter("@Building_Construc", Building_Construc))
                    command.Parameters.Add(New SqlParameter("@InteriorState_Id", InteriorState_Id))
                    command.Parameters.Add(New SqlParameter("@Character_Room_Id", Character_Room_Id))
                    command.Parameters.Add(New SqlParameter("@RoomWidth_BehideSiteWalk", RoomWidth_BehideSiteWalk))
                    command.Parameters.Add(New SqlParameter("@Roomdeep", Roomdeep))
                    command.Parameters.Add(New SqlParameter("@Backside_Width", Backside_Width))
                    command.Parameters.Add(New SqlParameter("@SideWalk_Is", SideWalk_Is))
                    command.Parameters.Add(New SqlParameter("@SideWalk_Width", SideWalk_Width))
                    command.Parameters.Add(New SqlParameter("@Partake_Detail", Partake_Detail))
                    command.Parameters.Add(New SqlParameter("@Ownership", Ownership))
                    command.Parameters.Add(New SqlParameter("@Obligation", Obligation))
                    command.Parameters.Add(New SqlParameter("@Other_Detail", Other_Detail))
                    command.Parameters.Add(New SqlParameter("@Tumbon1", Tumbon1))
                    command.Parameters.Add(New SqlParameter("@Amphur1", Amphur1))
                    command.Parameters.Add(New SqlParameter("@Province1", Province1))
                    command.Parameters.Add(New SqlParameter("@Elevator_Util", Elevator_Util))
                    command.Parameters.Add(New SqlParameter("@Parking_Util", Parking_Util))
                    command.Parameters.Add(New SqlParameter("@Pool_Util", Pool_Util))
                    command.Parameters.Add(New SqlParameter("@Fitness_Util", Fitness_Util))
                    command.Parameters.Add(New SqlParameter("@Other_Util", Other_Util))
                    command.Parameters.Add(New SqlParameter("@Other_Util_Detail", Other_Util_Detail))
                    command.Parameters.Add(New SqlParameter("@Adjust_Condo", Adjust_Condo))
                    command.Parameters.Add(New SqlParameter("@Unit_Price", Unit_Price))
                    command.Parameters.Add(New SqlParameter("@PriceTotal", PriceTotal))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    MsgBox(ex.Message)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Function GET_PRICE3_18(ByVal Req_Id As Integer, ByVal Hub_Id As Integer, ByVal Temp_AID As Integer) As Generic.List(Of Price3_18)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE3_18_GROUP", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                connection.Open()
                Dim list As New Generic.List(Of Price3_18)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Price3_18(CInt(reader("ID")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CStr(reader("AID")), _
                                                CStr(reader("CID")), _
                                                CInt(reader("Temp_AID")), _
                                                CInt(reader("MysubColl_ID")), _
                                                CInt(reader("Floors_All")), _
                                                CInt(reader("Elevator")), _
                                                CStr(reader("Address_No")), _
                                                CDec(reader("Room_Area")), _
                                                CDec(reader("Room_Height")), _
                                                CStr(reader("Building_Name")), _
                                                CInt(reader("Floors")), _
                                                CStr(reader("Building_No")), _
                                                CStr(reader("Building_Reg_No")), _
                                                CDec(reader("Building_Age")), _
                                                CStr(reader("Tumbon")), _
                                                CStr(reader("Amphur")), _
                                                CInt(reader("Province")), _
                                                CStr(reader("Road")), _
                                                CInt(reader("Road_Detail")), _
                                                CDec(reader("Road_Access")), _
                                                CInt(reader("Road_Frontoff")), _
                                                CDec(reader("Roadwidth")), _
                                                CInt(reader("Sited")), _
                                                CStr(reader("Site_Detail")), _
                                                CInt(reader("Public_Utility")), _
                                                CStr(reader("Public_Utility_Detail")), _
                                                CInt(reader("Binifit")), _
                                                CStr(reader("Binifit_Detail")), _
                                                CInt(reader("Tendency")), _
                                                CInt(reader("BuySale_State")), _
                                                CInt(reader("Building_Construc")), _
                                                CInt(reader("InteriorState_Id")), _
                                                CInt(reader("Character_Room_Id")), _
                                                CDec(reader("RoomWidth_BehideSiteWalk")), _
                                                CDec(reader("Roomdeep")), _
                                                CDec(reader("Backside_Width")), _
                                                CInt(reader("SideWalk_Is")), _
                                                CDec(reader("SideWalk_Width")), _
                                                CStr(reader("Partake_Detail")), _
                                                CStr(reader("Ownership")), _
                                                CStr(reader("Obligation")), _
                                                CStr(reader("Other_Detail")), _
                                                CStr(reader("Tumbon1")), _
                                                CStr(reader("Amphur1")), _
                                                CInt(reader("Province1")), _
                                                CInt(reader("Elevator_Util")), _
                                                CInt(reader("Parking_Util")), _
                                                CInt(reader("Pool_Util")), _
                                                CInt(reader("Fitness_Util")), _
                                                CInt(reader("Other_Util")), _
                                                CStr(reader("Other_Util_Detail")), _
                                                CStr(reader("Adjust_Condo")), _
                                                CDec(reader("Unit_Price")), _
                                                CDec(reader("PriceTotal")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using

    End Function

    Public Shared Function GET_PRICE3_18BY_ID(ByVal ID As Integer, ByVal Req_Id As Integer, ByVal Hub_Id As Integer) As Generic.List(Of Price3_18)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE3_18", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@ID", ID))
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                connection.Open()
                Dim list As New Generic.List(Of Price3_18)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Price3_18(CInt(reader("ID")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CStr(reader("AID")), _
                                                CStr(reader("CID")), _
                                                CInt(reader("Temp_AID")), _
                                                CInt(reader("MysubColl_ID")), _
                                                CInt(reader("Floors_All")), _
                                                CInt(reader("Elevator")), _
                                                CStr(reader("Address_No")), _
                                                CDec(reader("Room_Area")), _
                                                CDec(reader("Room_Height")), _
                                                CStr(reader("Building_Name")), _
                                                CInt(reader("Floors")), _
                                                CStr(reader("Building_No")), _
                                                CStr(reader("Building_Reg_No")), _
                                                CDec(reader("Building_Age")), _
                                                CStr(reader("Tumbon")), _
                                                CStr(reader("Amphur")), _
                                                CInt(reader("Province")), _
                                                CStr(reader("Road")), _
                                                CInt(reader("Road_Detail")), _
                                                CDec(reader("Road_Access")), _
                                                CInt(reader("Road_Frontoff")), _
                                                CDec(reader("Roadwidth")), _
                                                CInt(reader("Sited")), _
                                                CStr(reader("Site_Detail")), _
                                                CInt(reader("Public_Utility")), _
                                                CStr(reader("Public_Utility_Detail")), _
                                                CInt(reader("Binifit")), _
                                                CStr(reader("Binifit_Detail")), _
                                                CInt(reader("Tendency")), _
                                                CInt(reader("BuySale_State")), _
                                                CInt(reader("Building_Construc")), _
                                                CInt(reader("InteriorState_Id")), _
                                                CInt(reader("Character_Room_Id")), _
                                                CDec(reader("RoomWidth_BehideSiteWalk")), _
                                                CDec(reader("Roomdeep")), _
                                                CDec(reader("Backside_Width")), _
                                                CInt(reader("SideWalk_Is")), _
                                                CDec(reader("SideWalk_Width")), _
                                                CStr(reader("Partake_Detail")), _
                                                CStr(reader("Ownership")), _
                                                CStr(reader("Obligation")), _
                                                CStr(reader("Other_Detail")), _
                                                CStr(reader("Tumbon1")), _
                                                CStr(reader("Amphur1")), _
                                                CInt(reader("Province1")), _
                                                CInt(reader("Elevator_Util")), _
                                                CInt(reader("Parking_Util")), _
                                                CInt(reader("Pool_Util")), _
                                                CInt(reader("Fitness_Util")), _
                                                CInt(reader("Other_Util")), _
                                                CStr(reader("Other_Util_Detail")), _
                                                CStr(reader("Adjust_Condo")), _
                                                CDec(reader("Unit_Price")), _
                                                CDec(reader("PriceTotal")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        'MsgBox(reader("Elevator_Util"))
                        list.Add(temp)
                        'MsgBox(temp.Elevator_Util)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using

    End Function

    Public Shared Function GET_PRICE3_18_FIND_ADDRESSNO(ByVal Building_Reg_No As String, ByVal Building_No As String, ByVal Address_No As String) As Generic.List(Of Price3_18)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE3_18_FIND_ADDRESSNO", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@Building_Reg_No", Building_Reg_No))
                command.Parameters.Add(New SqlParameter("@Building_N", Building_No))
                command.Parameters.Add(New SqlParameter("@Address_No", Address_No))
                connection.Open()
                Dim list As New Generic.List(Of Price3_18)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Price3_18(CInt(reader("ID")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CStr(reader("AID")), _
                                                CStr(reader("CID")), _
                                                CInt(reader("Temp_AID")), _
                                                CInt(reader("MysubColl_ID")), _
                                                CInt(reader("Floors_All")), _
                                                CInt(reader("Elevator")), _
                                                CStr(reader("Address_No")), _
                                                CDec(reader("Room_Area")), _
                                                CDec(reader("Room_Height")), _
                                                CStr(reader("Building_Name")), _
                                                CInt(reader("Floors")), _
                                                CStr(reader("Building_No")), _
                                                CStr(reader("Building_Reg_No")), _
                                                CDec(reader("Building_Age")), _
                                                CStr(reader("Tumbon")), _
                                                CStr(reader("Amphur")), _
                                                CInt(reader("Province")), _
                                                CStr(reader("Road")), _
                                                CInt(reader("Road_Detail")), _
                                                CDec(reader("Road_Access")), _
                                                CInt(reader("Road_Frontoff")), _
                                                CDec(reader("Roadwidth")), _
                                                CInt(reader("Sited")), _
                                                CStr(reader("Site_Detail")), _
                                                CInt(reader("Public_Utility")), _
                                                CStr(reader("Public_Utility_Detail")), _
                                                CInt(reader("Binifit")), _
                                                CStr(reader("Binifit_Detail")), _
                                                CInt(reader("Tendency")), _
                                                CInt(reader("BuySale_State")), _
                                                CInt(reader("Building_Construc")), _
                                                CInt(reader("InteriorState_Id")), _
                                                CInt(reader("Character_Room_Id")), _
                                                CDec(reader("RoomWidth_BehideSiteWalk")), _
                                                CDec(reader("Roomdeep")), _
                                                CDec(reader("Backside_Width")), _
                                                CInt(reader("SideWalk_Is")), _
                                                CDec(reader("SideWalk_Width")), _
                                                CStr(reader("Partake_Detail")), _
                                                CStr(reader("Ownership")), _
                                                CStr(reader("Obligation")), _
                                                CStr(reader("Other_Detail")), _
                                                CStr(reader("Tumbon1")), _
                                                CStr(reader("Amphur1")), _
                                                CInt(reader("Province1")), _
                                                CInt(reader("Elevator_Util")), _
                                                CInt(reader("Parking_Util")), _
                                                CInt(reader("Pool_Util")), _
                                                CInt(reader("Fitness_Util")), _
                                                CInt(reader("Other_Util")), _
                                                CStr(reader("Other_Util_Detail")), _
                                                CStr(reader("Adjust_Condo")), _
                                                CDec(reader("Unit_Price")), _
                                                CDec(reader("PriceTotal")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        'MsgBox(reader("Elevator_Util"))
                        list.Add(temp)
                        'MsgBox(temp.Elevator_Util)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using

    End Function

    Public Shared Sub DELETE_PRICE3_18(ByVal Id As String, _
     ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
     ByVal Temp_AID As Integer)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("DELETE_PRICE3_18", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Id", Id))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub AddPRICE3_50(ByVal Id As Integer, _
     ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
     ByVal Temp_AID As Integer, _
     ByVal AID As String, _
     ByVal CID As String, _
     ByVal MysubColl_ID As Integer, _
     ByVal Address_No As String, _
     ByVal Building_Name As String, _
     ByVal Tumbon As String, _
     ByVal Amphur As String, _
     ByVal Province As Integer, _
     ByVal Rai As Integer, _
     ByVal Ngan As Integer, _
     ByVal Wah As Decimal, _
     ByVal Road As String, _
     ByVal Road_Detail As Integer, _
     ByVal Road_Access As Decimal, _
     ByVal Soi As String, _
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
     ByVal SubUnit_Id As Integer, _
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
     ByVal DeepWidth As String, _
     ByVal BehindWidth As Double, _
     ByVal AreaColour_No As Integer, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("AddPRICE3_50", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@ID", Id))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@AID", AID))
                    command.Parameters.Add(New SqlParameter("@CID", CID))
                    command.Parameters.Add(New SqlParameter("@MysubColl_ID", MysubColl_ID))
                    command.Parameters.Add(New SqlParameter("@Address_No", Address_No))
                    command.Parameters.Add(New SqlParameter("@Building_Name", Building_Name))
                    command.Parameters.Add(New SqlParameter("@Tumbon", Tumbon))
                    command.Parameters.Add(New SqlParameter("@Amphur", Amphur))
                    command.Parameters.Add(New SqlParameter("@Province", Province))
                    command.Parameters.Add(New SqlParameter("@Rai", Rai))
                    command.Parameters.Add(New SqlParameter("@Ngan", Ngan))
                    command.Parameters.Add(New SqlParameter("@Wah", Wah))
                    command.Parameters.Add(New SqlParameter("@Road", Road))
                    command.Parameters.Add(New SqlParameter("@Road_Detail", Road_Detail))
                    command.Parameters.Add(New SqlParameter("@Road_Access", Road_Access))
                    command.Parameters.Add(New SqlParameter("@Soi", Soi))
                    command.Parameters.Add(New SqlParameter("@Road_Frontoff", Road_Frontoff))
                    command.Parameters.Add(New SqlParameter("@RoadWidth", RoadWidth))
                    command.Parameters.Add(New SqlParameter("@Sited", Sited))
                    command.Parameters.Add(New SqlParameter("@Site_Detail", Site_Detail))
                    command.Parameters.Add(New SqlParameter("@Land_State", Land_State))
                    command.Parameters.Add(New SqlParameter("@Land_State_Detail", Land_State_Detail))
                    command.Parameters.Add(New SqlParameter("@Public_Utility", Public_Utility))
                    command.Parameters.Add(New SqlParameter("@Public_Utility_Detail", Public_Utility_Detail))
                    command.Parameters.Add(New SqlParameter("@Binifit", Binifit))
                    command.Parameters.Add(New SqlParameter("@Binifit_Detail", Binifit_Detail))
                    command.Parameters.Add(New SqlParameter("@Tendency", Tendency))
                    command.Parameters.Add(New SqlParameter("@BuySale_State", BuySale_State))
                    command.Parameters.Add(New SqlParameter("@SubUnit_Id", SubUnit_Id))
                    command.Parameters.Add(New SqlParameter("@PriceWah", PriceWah))
                    command.Parameters.Add(New SqlParameter("@PriceTotal1", PriceTotal1))
                    command.Parameters.Add(New SqlParameter("@Rawang", Rawang))
                    command.Parameters.Add(New SqlParameter("@LandNumber", LandNumber))
                    command.Parameters.Add(New SqlParameter("@Surway", Surway))
                    command.Parameters.Add(New SqlParameter("@DocNo", DocNo))
                    command.Parameters.Add(New SqlParameter("@PageNo", PageNo))
                    command.Parameters.Add(New SqlParameter("@Ownership", Ownership))
                    command.Parameters.Add(New SqlParameter("@Obligation", Obligation))
                    command.Parameters.Add(New SqlParameter("@Land_Closeto_RoadWidth", Land_Closeto_RoadWidth))
                    command.Parameters.Add(New SqlParameter("@DeepWidth", DeepWidth))
                    command.Parameters.Add(New SqlParameter("@BehindWidth", BehindWidth))
                    command.Parameters.Add(New SqlParameter("@AreaColour_No", AreaColour_No))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    Throw New Exception(ex.Message & " : " & ex.StackTrace)
                    'MsgBox(ex.Message)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub UpdatePRICE3_50(ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
     ByVal Temp_AID As Integer, _
     ByVal AID As String, _
     ByVal CID As String, _
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
     ByVal Soi As String, _
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
     ByVal SubUnit_Id As Integer, _
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
     ByVal DeepWidth As String, _
     ByVal BehindWidth As Double, _
     ByVal AreaColour_No As Integer, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UpdatePRICE3_50", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@AID", AID))
                    command.Parameters.Add(New SqlParameter("@CID", CID))
                    command.Parameters.Add(New SqlParameter("@MysubColl_ID", MysubColl_ID))
                    command.Parameters.Add(New SqlParameter("@Address_No", Address_No))
                    command.Parameters.Add(New SqlParameter("@Building_Name", Building_Name))
                    command.Parameters.Add(New SqlParameter("@Tumbon", Tumbon))
                    command.Parameters.Add(New SqlParameter("@Amphur", Amphur))
                    command.Parameters.Add(New SqlParameter("@Province", Province))
                    command.Parameters.Add(New SqlParameter("@Rai", Rai))
                    command.Parameters.Add(New SqlParameter("@Ngan", Ngan))
                    command.Parameters.Add(New SqlParameter("@Wah", Wah))
                    command.Parameters.Add(New SqlParameter("@Road", Road))
                    command.Parameters.Add(New SqlParameter("@Road_Detail", Road_Detail))
                    command.Parameters.Add(New SqlParameter("@Road_Access", Road_Access))
                    command.Parameters.Add(New SqlParameter("@Soi", Soi))
                    command.Parameters.Add(New SqlParameter("@Road_Frontoff", Road_Frontoff))
                    command.Parameters.Add(New SqlParameter("@RoadWidth", RoadWidth))
                    command.Parameters.Add(New SqlParameter("@Sited", Sited))
                    command.Parameters.Add(New SqlParameter("@Site_Detail", Site_Detail))
                    command.Parameters.Add(New SqlParameter("@Land_State", Land_State))
                    command.Parameters.Add(New SqlParameter("@Land_State_Detail", Land_State_Detail))
                    command.Parameters.Add(New SqlParameter("@Public_Utility", Public_Utility))
                    command.Parameters.Add(New SqlParameter("@Public_Utility_Detail", Public_Utility_Detail))
                    command.Parameters.Add(New SqlParameter("@Binifit", Binifit))
                    command.Parameters.Add(New SqlParameter("@Binifit_Detail", Binifit_Detail))
                    command.Parameters.Add(New SqlParameter("@Tendency", Tendency))
                    command.Parameters.Add(New SqlParameter("@BuySale_State", BuySale_State))
                    command.Parameters.Add(New SqlParameter("@SubUnit_Id", SubUnit_Id))
                    command.Parameters.Add(New SqlParameter("@PriceWah", PriceWah))
                    command.Parameters.Add(New SqlParameter("@PriceTotal1", PriceTotal1))
                    command.Parameters.Add(New SqlParameter("@Rawang", Rawang))
                    command.Parameters.Add(New SqlParameter("@LandNumber", LandNumber))
                    command.Parameters.Add(New SqlParameter("@Surway", Surway))
                    command.Parameters.Add(New SqlParameter("@DocNo", DocNo))
                    command.Parameters.Add(New SqlParameter("@PageNo", PageNo))
                    command.Parameters.Add(New SqlParameter("@Ownership", Ownership))
                    command.Parameters.Add(New SqlParameter("@Obligation", Obligation))
                    command.Parameters.Add(New SqlParameter("@Land_Closeto_RoadWidth", Land_Closeto_RoadWidth))
                    command.Parameters.Add(New SqlParameter("@DeepWidth", DeepWidth))
                    command.Parameters.Add(New SqlParameter("@BehindWidth", BehindWidth))
                    command.Parameters.Add(New SqlParameter("@AreaColour_No", AreaColour_No))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Function GET_PRICE3_50(ByVal ID As Integer, ByVal Req_Id As Integer, ByVal Hub_Id As Integer, ByVal Temp_AID As Integer) As Generic.List(Of Price3_50)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE3_50", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@ID", ID))
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                connection.Open()
                Dim list As New Generic.List(Of Price3_50)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Price3_50(CInt(reader("ID")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CInt(reader("Temp_AID")), _
                                                CStr(reader("AID")), _
                                                CStr(reader("CID")), _
                                                CInt(reader("MysubColl_ID")), _
                                                CStr(reader("Address_No")), _
                                                CStr(reader("Building_Name")), _
                                                CStr(reader("Tumbon")), _
                                                CStr(reader("Amphur")), _
                                                CInt(reader("Province")), _
                                                CInt(reader("Rai")), _
                                                CInt(reader("Ngan")), _
                                                CDec(reader("Wah")), _
                                                CStr(reader("Road")), _
                                                CInt(reader("Road_Detail")), _
                                                CDec(reader("Road_Access")), _
                                                CStr(reader("Soi")), _
                                                CInt(reader("Road_Frontoff")), _
                                                CDec(reader("Roadwidth")), _
                                                CInt(reader("Sited")), _
                                                CStr(reader("Site_Detail")), _
                                                CInt(reader("Land_State")), _
                                                CStr(reader("Land_State_Detail")), _
                                                CInt(reader("Public_Utility")), _
                                                CStr(reader("Public_Utility_Detail")), _
                                                CInt(reader("Binifit")), _
                                                CStr(reader("Binifit_Detail")), _
                                                CInt(reader("Tendency")), _
                                                CInt(reader("BuySale_State")), _
                                                CInt(reader("SubUnit_Id")), _
                                                CDec(reader("PriceWah")), _
                                                CDec(reader("PriceTotal1")), _
                                                CStr(reader("Rawang")), _
                                                CStr(reader("LandNumber")), _
                                                CStr(reader("Surway")), _
                                                CStr(reader("DocNo")), _
                                                CStr(reader("PageNo")), _
                                                CStr(reader("Ownership")), _
                                                CStr(reader("Obligation")), _
                                                CDec(reader("Land_Closeto_RoadWidth")), _
                                                CStr(reader("DeepWidth")), _
                                                CDec(reader("BehindWidth")), _
                                                CInt(reader("AreaColour_No")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
            End Using
        End Using

    End Function

    Public Shared Function GET_PRICE3_50_FIND_CHANODE(ByVal Req_Id As Integer, ByVal Hub_Id As Integer, ByVal Temp_AID As Integer) As Generic.List(Of Price3_50)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE3_50_FIND_CHANODE", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                connection.Open()
                Dim list As New Generic.List(Of Price3_50)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Price3_50(CInt(reader("ID")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CInt(reader("Temp_AID")), _
                                                CStr(reader("AID")), _
                                                CStr(reader("CID")), _
                                                CInt(reader("MysubColl_ID")), _
                                                CStr(reader("Address_No")), _
                                                CStr(reader("Building_Name")), _
                                                CStr(reader("Tumbon")), _
                                                CStr(reader("Amphur")), _
                                                CInt(reader("Province")), _
                                                CInt(reader("Rai")), _
                                                CInt(reader("Ngan")), _
                                                CDec(reader("Wah")), _
                                                CStr(reader("Road")), _
                                                CInt(reader("Road_Detail")), _
                                                CDec(reader("Road_Access")), _
                                                CStr(reader("Soi")), _
                                                CInt(reader("Road_Frontoff")), _
                                                CDec(reader("Roadwidth")), _
                                                CInt(reader("Sited")), _
                                                CStr(reader("Site_Detail")), _
                                                CInt(reader("Land_State")), _
                                                CStr(reader("Land_State_Detail")), _
                                                CInt(reader("Public_Utility")), _
                                                CStr(reader("Public_Utility_Detail")), _
                                                CInt(reader("Binifit")), _
                                                CStr(reader("Binifit_Detail")), _
                                                CInt(reader("Tendency")), _
                                                CInt(reader("BuySale_State")), _
                                                CInt(reader("SubUnit_Id")), _
                                                CDec(reader("PriceWah")), _
                                                CDec(reader("PriceTotal1")), _
                                                CStr(reader("Rawang")), _
                                                CStr(reader("LandNumber")), _
                                                CStr(reader("Surway")), _
                                                CStr(reader("DocNo")), _
                                                CStr(reader("PageNo")), _
                                                CStr(reader("Ownership")), _
                                                CStr(reader("Obligation")), _
                                                CDec(reader("Land_Closeto_RoadWidth")), _
                                                CStr(reader("DeepWidth")), _
                                                CDec(reader("BehindWidth")), _
                                                CInt(reader("AreaColour_No")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
            End Using
        End Using

    End Function

    Public Shared Function GET_PRICE3_50_CHANODE(ByVal Chanode_No As String, ByVal Province_Id As String) As Generic.List(Of Price3_50)
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE3_50_CHANODE", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@Chanode_No", Chanode_No))
                command.Parameters.Add(New SqlParameter("@Province_Id", Province_Id))
                connection.Open()
                Dim list As New Generic.List(Of Price3_50)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Price3_50(CInt(reader("ID")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CInt(reader("Temp_AID")), _
                                                CStr(reader("AID")), _
                                                CStr(reader("CID")), _
                                                CInt(reader("MysubColl_ID")), _
                                                CStr(reader("Address_No")), _
                                                CStr(reader("Building_Name")), _
                                                CStr(reader("Tumbon")), _
                                                CStr(reader("Amphur")), _
                                                CInt(reader("Province")), _
                                                CInt(reader("Rai")), _
                                                CInt(reader("Ngan")), _
                                                CDec(reader("Wah")), _
                                                CStr(reader("Road")), _
                                                CInt(reader("Road_Detail")), _
                                                CDec(reader("Road_Access")), _
                                                CStr(reader("Soi")), _
                                                CInt(reader("Road_Frontoff")), _
                                                CDec(reader("Roadwidth")), _
                                                CInt(reader("Sited")), _
                                                CStr(reader("Site_Detail")), _
                                                CInt(reader("Land_State")), _
                                                CStr(reader("Land_State_Detail")), _
                                                CInt(reader("Public_Utility")), _
                                                CStr(reader("Public_Utility_Detail")), _
                                                CInt(reader("Binifit")), _
                                                CStr(reader("Binifit_Detail")), _
                                                CInt(reader("Tendency")), _
                                                CInt(reader("BuySale_State")), _
                                                CInt(reader("SubUnit_Id")), _
                                                CDec(reader("PriceWah")), _
                                                CDec(reader("PriceTotal1")), _
                                                CStr(reader("Rawang")), _
                                                CStr(reader("LandNumber")), _
                                                CStr(reader("Surway")), _
                                                CStr(reader("DocNo")), _
                                                CStr(reader("PageNo")), _
                                                CStr(reader("Ownership")), _
                                                CStr(reader("Obligation")), _
                                                CDec(reader("Land_Closeto_RoadWidth")), _
                                                CStr(reader("DeepWidth")), _
                                                CDec(reader("BehindWidth")), _
                                                CInt(reader("AreaColour_No")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using

    End Function

    Public Shared Function GET_PRICE3_LAND_BY_ID(ByVal Req_Id As Integer) As DataSet
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE3_LAND_BY_ID", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                connection.Open()
                Dim list As New SqlDataAdapter(command)
                'Using reader As SqlDataAdapter = command.ExecuteNonQuery()
                Dim ds As New DataSet
                list.Fill(ds)
                Return ds
                connection.Close()
            End Using
        End Using

    End Function

    Public Shared Function GET_PRICE3_BUILDING_BY_ID(ByVal Req_Id As Integer) As DataSet
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE3_BUILDING_BY_ID", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                connection.Open()
                Dim list As New SqlDataAdapter(command)
                'Using reader As SqlDataAdapter = command.ExecuteNonQuery()
                Dim ds As New DataSet
                list.Fill(ds)
                Return ds
                connection.Close()
            End Using
        End Using

    End Function

    Public Shared Sub DELETE_PRICE3_50(ByVal Id As String, _
     ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
     ByVal Temp_AID As Integer)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("DELETE_PRICE3_50", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Id", Id))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub AddPRICE3_70(ByVal Id As Integer, _
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
     ByVal Ownership As String, _
     ByVal BuildingArea As Double, _
     ByVal BuildingUintPrice As Double, _
     ByVal BuildingPrice As Decimal, _
     ByVal BuildingAge As Integer, _
     ByVal BuildingPersent1 As Decimal, _
     ByVal BuildingPersent2 As Decimal, _
     ByVal BuildingPersent3 As Decimal, _
     ByVal BuildingPriceTotalDeteriorate As Decimal, _
     ByVal BuildingPercentFinish As Integer, _
     ByVal BuildingPriceFinish As Decimal, _
     ByVal BuildAddArea As Decimal, _
     ByVal BuildAddUintPrice As Decimal, _
     ByVal BuildAddPrice As Decimal, _
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
     ByVal Create_User As String, _
     ByVal Create_Date As Date)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("AddPRICE3_70", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Id", Id))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@AID", AID))
                    command.Parameters.Add(New SqlParameter("@CID", CID))
                    command.Parameters.Add(New SqlParameter("@MysubColl_ID", MysubColl_ID))
                    command.Parameters.Add(New SqlParameter("@Build_No", Build_No))
                    command.Parameters.Add(New SqlParameter("@Tumbon", Tumbon))
                    command.Parameters.Add(New SqlParameter("@Amphur", Amphur))
                    command.Parameters.Add(New SqlParameter("@Province", Province))
                    command.Parameters.Add(New SqlParameter("@Build_Character", Build_Character))
                    command.Parameters.Add(New SqlParameter("@Floors", Floors))
                    command.Parameters.Add(New SqlParameter("@Item", Item))
                    command.Parameters.Add(New SqlParameter("@Build_Construct", Build_Construct))
                    command.Parameters.Add(New SqlParameter("@Roof", Roof))
                    command.Parameters.Add(New SqlParameter("@Roof_Detail", Roof_Detail))
                    command.Parameters.Add(New SqlParameter("@Build_State", Build_State))
                    command.Parameters.Add(New SqlParameter("@Build_State_Detail", Build_State_Detail))
                    command.Parameters.Add(New SqlParameter("@Building_Detail", Building_Detail))
                    command.Parameters.Add(New SqlParameter("@PriceTotal1", PriceTotal1))
                    command.Parameters.Add(New SqlParameter("@Doc1", Doc1))
                    command.Parameters.Add(New SqlParameter("@Doc2", Doc2))
                    command.Parameters.Add(New SqlParameter("@Doc_Detail", Doc_Detail))
                    command.Parameters.Add(New SqlParameter("@Pic_path", Pic_path))
                    command.Parameters.Add(New SqlParameter("@Put_On_Chanode", Put_On_Chanode))
                    command.Parameters.Add(New SqlParameter("@Ownership", Ownership))
                    command.Parameters.Add(New SqlParameter("@BuildingArea", BuildingArea))
                    command.Parameters.Add(New SqlParameter("@BuildingUintPrice", BuildingUintPrice))
                    command.Parameters.Add(New SqlParameter("@BuildingPrice", BuildingPrice))
                    command.Parameters.Add(New SqlParameter("@BuildingAge", BuildingAge))
                    command.Parameters.Add(New SqlParameter("@BuildingPersent1", BuildingPersent1))
                    command.Parameters.Add(New SqlParameter("@BuildingPersent2", BuildingPersent2))
                    command.Parameters.Add(New SqlParameter("@BuildingPersent3", BuildingPersent3))
                    command.Parameters.Add(New SqlParameter("@BuildingPriceTotalDeteriorate", BuildingPriceTotalDeteriorate))
                    command.Parameters.Add(New SqlParameter("@BuildingPercentFinish", BuildingPercentFinish))
                    command.Parameters.Add(New SqlParameter("@BuildingPriceFinish", BuildingPriceFinish))
                    command.Parameters.Add(New SqlParameter("@BuildAddArea", BuildAddArea))
                    command.Parameters.Add(New SqlParameter("@BuildAddUintPrice", BuildAddUintPrice))
                    command.Parameters.Add(New SqlParameter("@BuildAddPrice", BuildAddPrice))
                    command.Parameters.Add(New SqlParameter("@BuildAddAge", BuildAddAge))
                    command.Parameters.Add(New SqlParameter("@BuildAddPersent1", BuildAddPersent1))
                    command.Parameters.Add(New SqlParameter("@BuildAddPersent2", BuildAddPersent2))
                    command.Parameters.Add(New SqlParameter("@BuildAddPersent3", BuildAddPersent3))
                    command.Parameters.Add(New SqlParameter("@BuildAddPriceTotalDeteriorate", BuildAddPriceTotalDeteriorate))
                    command.Parameters.Add(New SqlParameter("@BuildAddPercentFinish", BuildAddPercentFinish))
                    command.Parameters.Add(New SqlParameter("@BuildAddPriceFinish", BuildAddPriceFinish))
                    command.Parameters.Add(New SqlParameter("@BuildingDetail", BuildingDetail))
                    command.Parameters.Add(New SqlParameter("@Decoration", Decoration))
                    command.Parameters.Add(New SqlParameter("@Standard_Id", Standard_Id))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    Throw New Exception(ex.Message & " : " & ex.StackTrace)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Function GET_PRICE3_70_ADDRESS(ByVal Put_On_Chanode As String, ByVal Building_No As String, ByVal Province As Integer) As Generic.List(Of Price3_70)
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE3_70_ADDRESS", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@Put_On_Chanode", Put_On_Chanode))
                command.Parameters.Add(New SqlParameter("@Building_No", Building_No))
                command.Parameters.Add(New SqlParameter("@Province", Province))
                connection.Open()
                Dim list As New Generic.List(Of Price3_70)()
                Using reader As SqlDataReader = command.ExecuteReader()
                    Do While (reader.Read())
                        Dim temp As New Price3_70(CInt(reader("ID")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CInt(reader("Temp_AID")), _
                                                CStr(reader("AID")), _
                                                CStr(reader("CID")), _
                                                CInt(reader("MysubColl_ID")), _
                                                CStr(reader("Build_No")), _
                                                CStr(reader("Tumbon")), _
                                                CStr(reader("Amphur")), _
                                                CInt(reader("Province")), _
                                                CInt(reader("Build_Character")), _
                                                CStr(reader("Floors")), _
                                                CInt(reader("Item")), _
                                                CInt(reader("Build_Construct")), _
                                                CInt(reader("Roof")), _
                                                CStr(reader("Roof_Detail")), _
                                                CInt(reader("Build_State")), _
                                                CStr(reader("Build_State_Detail")), _
                                                CStr(reader("Building_Detail")), _
                                                CDec(reader("PriceTotal1")), _
                                                CInt(reader("Doc1")), _
                                                CInt(reader("Doc2")), _
                                                CStr(reader("Doc_Detail")), _
                                                CStr(reader("Pic_path")), _
                                                CStr(reader("Put_On_Chanode")), _
                                                CStr(reader("Ownership")), _
                                                CDec(reader("BuildingArea")), _
                                                CDec(reader("BuildingUintPrice")), _
                                                CDec(reader("BuildingPrice")), _
                                                CInt(reader("BuildingAge")), _
                                                CDec(reader("BuildingPersent1")), _
                                                CDec(reader("BuildingPersent2")), _
                                                CDec(reader("BuildingPersent3")), _
                                                CDec(reader("BuildingPriceTotalDeteriorate")), _
                                                CInt(reader("BuildingPercentFinish")), _
                                                CDec(reader("BuildingPriceFinish")), _
                                                CDec(reader("BuildAddArea")), _
                                                CDec(reader("BuildAddUintPrice")), _
                                                CDec(reader("BuildAddPrice")), _
                                                CDec(reader("BuildAddAge")), _
                                                CDec(reader("BuildAddPersent1")), _
                                                CDec(reader("BuildAddPersent2")), _
                                                CDec(reader("BuildAddPersent3")), _
                                                CDec(reader("BuildAddPriceTotalDeteriorate")), _
                                                CInt(reader("BuildAddPercentFinish")), _
                                                CDec(reader("BuildAddPriceFinish")), _
                                                CStr(reader("BuildingDetail")), _
                                                CInt(reader("Decoration")), _
                                                CInt(reader("Standard_Id")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using

    End Function

    Public Shared Sub AddPRICE3_70_DETAIL(ByVal Id As Integer, _
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

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("AddPRICE3_70_DETAIL", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Id", Id))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@Floors", Floor))
                    command.Parameters.Add(New SqlParameter("@Main_Construction", Main_Construction))
                    command.Parameters.Add(New SqlParameter("@Concrete", Concrete))
                    command.Parameters.Add(New SqlParameter("@Granite", Granite))
                    command.Parameters.Add(New SqlParameter("@Parquet", Parquet))
                    command.Parameters.Add(New SqlParameter("@Ceramic", Ceramic))
                    command.Parameters.Add(New SqlParameter("@Wood", Wood))
                    command.Parameters.Add(New SqlParameter("@Other", Other))
                    command.Parameters.Add(New SqlParameter("@Other_Detail", Other_Detail))
                    command.Parameters.Add(New SqlParameter("@BrickWall", BrickWall))
                    command.Parameters.Add(New SqlParameter("@BlockBrickWall", BlockBrickWall))
                    command.Parameters.Add(New SqlParameter("@WoodWall", WoodWall))
                    command.Parameters.Add(New SqlParameter("@OtherWall", OtherWall))
                    command.Parameters.Add(New SqlParameter("@OtherWall_Detail", OtherWall_Detail))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub UpdatePRICE3_70_DETAIL(ByVal Id As String, _
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

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_PRICE3_70_DETAIL", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Id", Id))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@Floors", Floor))
                    command.Parameters.Add(New SqlParameter("@Main_Construction", Main_Construction))
                    command.Parameters.Add(New SqlParameter("@Concrete", Concrete))
                    command.Parameters.Add(New SqlParameter("@Granite", Granite))
                    command.Parameters.Add(New SqlParameter("@Parquet", Parquet))
                    command.Parameters.Add(New SqlParameter("@Ceramic", Ceramic))
                    command.Parameters.Add(New SqlParameter("@Wood", Wood))
                    command.Parameters.Add(New SqlParameter("@Other", Other))
                    command.Parameters.Add(New SqlParameter("@Other_Detail", Other_Detail))
                    command.Parameters.Add(New SqlParameter("@BrickWall", BrickWall))
                    command.Parameters.Add(New SqlParameter("@BlockBrickWall", BlockBrickWall))
                    command.Parameters.Add(New SqlParameter("@WoodWall", WoodWall))
                    command.Parameters.Add(New SqlParameter("@OtherWall", OtherWall))
                    command.Parameters.Add(New SqlParameter("@OtherWall_Detail", OtherWall_Detail))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    Dim msg As String
                    Dim title As String
                    Dim style As MsgBoxStyle
                    Dim response1 As MsgBoxResult
                    'msg = "การบันทึกผิดพลาด"   ' Define message.
                    msg = ex.Message
                    style = MsgBoxStyle.DefaultButton2 Or _
                       MsgBoxStyle.Critical Or MsgBoxStyle.YesNo
                    title = "ผลการบันทึก"   ' Define title.
                    ' Display message.
                    response1 = MsgBox(msg, style, title)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub DeletePRICE3_70_DETAIL(ByVal Id As String, _
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

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UpdatePRICE3_70_DETAIL", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Id", Id))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@Floors", Floor))
                    command.Parameters.Add(New SqlParameter("@Main_Construction", Main_Construction))
                    command.Parameters.Add(New SqlParameter("@Concrete", Concrete))
                    command.Parameters.Add(New SqlParameter("@Granite", Granite))
                    command.Parameters.Add(New SqlParameter("@Parquet", Parquet))
                    command.Parameters.Add(New SqlParameter("@Ceramic", Ceramic))
                    command.Parameters.Add(New SqlParameter("@Wood", Wood))
                    command.Parameters.Add(New SqlParameter("@Other", Other))
                    command.Parameters.Add(New SqlParameter("@Other_Detail", Other_Detail))
                    command.Parameters.Add(New SqlParameter("@BrickWall", BrickWall))
                    command.Parameters.Add(New SqlParameter("@BlockBrickWall", BlockBrickWall))
                    command.Parameters.Add(New SqlParameter("@WoodWall", WoodWall))
                    command.Parameters.Add(New SqlParameter("@OtherWall", OtherWall))
                    command.Parameters.Add(New SqlParameter("@OtherWall_Detail", OtherWall_Detail))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Function GET_PRICE3_70_DETAIL(ByVal ID As Integer, ByVal Req_Id As Integer, ByVal Hub_Id As Integer, ByVal Temp_AID As Integer, ByVal Floors As String) As Generic.List(Of ClsPrice3_70_Detail)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE3_70_DETAIL_BYID", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@ID", ID))
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                command.Parameters.Add(New SqlParameter("@Floors", Floors))
                connection.Open()
                Dim list As New Generic.List(Of ClsPrice3_70_Detail)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New ClsPrice3_70_Detail(CInt(reader("Id")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CInt(reader("Temp_AID")), _
                                                CStr(reader("Floors")), _
                                                CStr(reader("Main_Construction")), _
                                                CInt(reader("Concrete")), _
                                                CInt(reader("Granite")), _
                                                CInt(reader("Parquet")), _
                                                CInt(reader("Ceramic")), _
                                                CInt(reader("Wood")), _
                                                CInt(reader("Other")), _
                                                CStr(reader("Other_Detail")), _
                                                CInt(reader("BrickWall")), _
                                                CInt(reader("BlockBrickWall")), _
                                                CInt(reader("WoodWall")), _
                                                CInt(reader("OtherWall")), _
                                                CStr(reader("OtherWall_Detail")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using

    End Function

    Public Shared Sub UpdatePRICE3_70(ByVal Req_Id As Integer, _
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
     ByVal Ownership As String, _
     ByVal BuildingArea As Double, _
     ByVal BuildingUintPrice As Double, _
     ByVal BuildingPrice As Double, _
     ByVal BuildingAge As Integer, _
     ByVal BuildingPersent1 As Decimal, _
     ByVal BuildingPersent2 As Decimal, _
     ByVal BuildingPersent3 As Decimal, _
     ByVal BuildingPriceTotalDeteriorate As Decimal, _
     ByVal BuildAddArea As Double, _
     ByVal BuildAddUintPrice As Double, _
     ByVal BuildAddPrice As Double, _
     ByVal BuildAddAge As Integer, _
     ByVal BuildAddPersent1 As Decimal, _
     ByVal BuildAddPersent2 As Decimal, _
     ByVal BuildAddPersent3 As Decimal, _
     ByVal BuildAddPriceTotalDeteriorate As Decimal, _
     ByVal BuildingDetail As String, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UpdatePRICE3_70", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@MysubColl_ID", MysubColl_ID))
                    command.Parameters.Add(New SqlParameter("@Build_No", Build_No))
                    command.Parameters.Add(New SqlParameter("@Tumbon", Tumbon))
                    command.Parameters.Add(New SqlParameter("@Amphur", Amphur))
                    command.Parameters.Add(New SqlParameter("@Province", Province))
                    command.Parameters.Add(New SqlParameter("@Build_Character", Build_Character))
                    command.Parameters.Add(New SqlParameter("@Floors", Floors))
                    command.Parameters.Add(New SqlParameter("@Item", Item))
                    command.Parameters.Add(New SqlParameter("@Build_Construct", Build_Construct))
                    command.Parameters.Add(New SqlParameter("@Roof", Roof))
                    command.Parameters.Add(New SqlParameter("@Roof_Detail", Roof_Detail))
                    command.Parameters.Add(New SqlParameter("@Build_State", Build_State))
                    command.Parameters.Add(New SqlParameter("@Build_State_Detail", Build_State_Detail))
                    command.Parameters.Add(New SqlParameter("@Building_Detail", Building_Detail))
                    command.Parameters.Add(New SqlParameter("@PriceTotal1", PriceTotal1))
                    command.Parameters.Add(New SqlParameter("@Doc1", Doc1))
                    command.Parameters.Add(New SqlParameter("@Doc2", Doc2))
                    command.Parameters.Add(New SqlParameter("@Doc_Detail", Doc_Detail))
                    command.Parameters.Add(New SqlParameter("@Pic_path", Pic_path))
                    command.Parameters.Add(New SqlParameter("@Put_On_Chanode", Put_On_Chanode))
                    command.Parameters.Add(New SqlParameter("@Ownership", Ownership))
                    command.Parameters.Add(New SqlParameter("@BuildingArea", BuildingArea))
                    command.Parameters.Add(New SqlParameter("@BuildingUintPrice", BuildingUintPrice))
                    command.Parameters.Add(New SqlParameter("@BuildingPrice", BuildingPrice))
                    command.Parameters.Add(New SqlParameter("@BuildingAge", BuildingAge))
                    command.Parameters.Add(New SqlParameter("@BuildingPersent1", BuildingPersent1))
                    command.Parameters.Add(New SqlParameter("@BuildingPersent2", BuildingPersent2))
                    command.Parameters.Add(New SqlParameter("@BuildingPersent3", BuildingPersent3))
                    command.Parameters.Add(New SqlParameter("@BuildingPriceTotalDeteriorate", BuildingPriceTotalDeteriorate))
                    command.Parameters.Add(New SqlParameter("@BuildAddArea", BuildAddArea))
                    command.Parameters.Add(New SqlParameter("@BuildAddUintPrice", BuildAddUintPrice))
                    command.Parameters.Add(New SqlParameter("@BuildAddPrice", BuildAddPrice))
                    command.Parameters.Add(New SqlParameter("@BuildAddAge", BuildAddAge))
                    command.Parameters.Add(New SqlParameter("@BuildAddPersent1", BuildAddPersent1))
                    command.Parameters.Add(New SqlParameter("@BuildAddPersent2", BuildAddPersent2))
                    command.Parameters.Add(New SqlParameter("@BuildAddPersent3", BuildAddPersent3))
                    command.Parameters.Add(New SqlParameter("@BuildAddPriceTotalDeteriorate", BuildAddPriceTotalDeteriorate))
                    command.Parameters.Add(New SqlParameter("@BuildingDetail", BuildingDetail))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Function GET_PRICE3_70(ByVal ID As Integer, ByVal Req_Id As Integer, ByVal Hub_Id As Integer, ByVal Temp_AID As Integer) As Generic.List(Of Price3_70)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE3_70", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@ID", ID))
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                connection.Open()
                Dim list As New Generic.List(Of Price3_70)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Price3_70(CInt(reader("ID")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CInt(reader("Temp_AID")), _
                                                CStr(reader("AID")), _
                                                CStr(reader("CID")), _
                                                CInt(reader("MysubColl_ID")), _
                                                CStr(reader("Build_No")), _
                                                CStr(reader("Tumbon")), _
                                                CStr(reader("Amphur")), _
                                                CInt(reader("Province")), _
                                                CInt(reader("Build_Character")), _
                                                CStr(reader("Floors")), _
                                                CInt(reader("Item")), _
                                                CInt(reader("Build_Construct")), _
                                                CInt(reader("Roof")), _
                                                CStr(reader("Roof_Detail")), _
                                                CInt(reader("Build_State")), _
                                                CStr(reader("Build_State_Detail")), _
                                                CStr(reader("Building_Detail")), _
                                                CDec(reader("PriceTotal1")), _
                                                CInt(reader("Doc1")), _
                                                CInt(reader("Doc2")), _
                                                CStr(reader("Doc_Detail")), _
                                                CStr(reader("Pic_path")), _
                                                CStr(reader("Put_On_Chanode")), _
                                                CStr(reader("Ownership")), _
                                                CDec(reader("BuildingArea")), _
                                                CDec(reader("BuildingUintPrice")), _
                                                CDec(reader("BuildingPrice")), _
                                                CInt(reader("BuildingAge")), _
                                                CDec(reader("BuildingPersent1")), _
                                                CDec(reader("BuildingPersent2")), _
                                                CDec(reader("BuildingPersent3")), _
                                                CDec(reader("BuildingPriceTotalDeteriorate")), _
                                                CInt(reader("BuildingPercentFinish")), _
                                                CDec(reader("BuildingPriceFinish")), _
                                                CDec(reader("BuildAddArea")), _
                                                CDec(reader("BuildAddUintPrice")), _
                                                CDec(reader("BuildAddPrice")), _
                                                CDec(reader("BuildAddAge")), _
                                                CDec(reader("BuildAddPersent1")), _
                                                CDec(reader("BuildAddPersent2")), _
                                                CDec(reader("BuildAddPersent3")), _
                                                CDec(reader("BuildAddPriceTotalDeteriorate")), _
                                                CInt(reader("BuildAddPercentFinish")), _
                                                CDec(reader("BuildAddPriceFinish")), _
                                                CStr(reader("BuildingDetail")), _
                                                CInt(reader("Decoration")), _
                                                CInt(reader("Standard_Id")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using

    End Function

    Public Shared Sub DELETE_PRICE3_70(ByVal Id As String, _
 ByVal Req_Id As Integer, _
 ByVal Hub_Id As Integer, _
 ByVal Temp_AID As Integer)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("DELETE_PRICE3_70", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Id", Id))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub ADD_PRICE3_70_PARTAKE(ByVal Id As Integer, _
     ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
     ByVal Temp_AID As Integer, _
     ByVal AID As String, _
     ByVal Partake_Id As Integer, _
     ByVal Building_No As String, _
     ByVal PartakeArea As Double, _
     ByVal PartakeUintPrice As Double, _
     ByVal PartakePrice As Double, _
     ByVal PartakeAge As Integer, _
     ByVal PartakePersent1 As Decimal, _
     ByVal PartakePersent2 As Decimal, _
     ByVal PartakePersent3 As Decimal, _
     ByVal PartakePriceTotalDeteriorate As Decimal, _
     ByVal PercentFinish As Integer, _
     ByVal PriceFinish As Decimal, _
     ByVal PartakeDetail As String, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("ADD_PRICE3_70_PARTAKE", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Id", Id))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@AID", AID))
                    command.Parameters.Add(New SqlParameter("@Partake_Id", Partake_Id))
                    command.Parameters.Add(New SqlParameter("@Building_No", Building_No))
                    command.Parameters.Add(New SqlParameter("@PartakeArea", PartakeArea))
                    command.Parameters.Add(New SqlParameter("@PartakeUintPrice", PartakeUintPrice))
                    command.Parameters.Add(New SqlParameter("@PartakePrice", PartakePrice))
                    command.Parameters.Add(New SqlParameter("@PartakeAge", PartakeAge))
                    command.Parameters.Add(New SqlParameter("@PartakePersent1", PartakePersent1))
                    command.Parameters.Add(New SqlParameter("@PartakePersent2", PartakePersent2))
                    command.Parameters.Add(New SqlParameter("@PartakePersent3", PartakePersent3))
                    command.Parameters.Add(New SqlParameter("@PartakePriceTotalDeteriorate", PartakePriceTotalDeteriorate))
                    command.Parameters.Add(New SqlParameter("@PercentFinish", PercentFinish))
                    command.Parameters.Add(New SqlParameter("@PriceFinish", PriceFinish))
                    command.Parameters.Add(New SqlParameter("@PartakeDetail", PartakeDetail))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    'command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    MsgBox(ex.Message)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub UPDATE_PRICE3_70_PARTAKE(ByVal Id As Integer, _
     ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
     ByVal Temp_AID As Integer, _
     ByVal AID As String, _
     ByVal Partake_Id As Integer, _
     ByVal Building_No As String, _
     ByVal PartakeArea As Double, _
     ByVal PartakeUintPrice As Double, _
     ByVal PartakePrice As Double, _
     ByVal PartakeAge As Integer, _
     ByVal PartakePersent1 As Decimal, _
     ByVal PartakePersent2 As Decimal, _
     ByVal PartakePersent3 As Decimal, _
     ByVal PartakePriceTotalDeteriorate As Decimal, _
     ByVal PercentFinish As Integer, _
     ByVal PriceFinish As Decimal, _
     ByVal PartakeDetail As String, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("Update_Price3_70_Partake", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Id", Id))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@AID", AID))
                    command.Parameters.Add(New SqlParameter("@Partake_Id", Partake_Id))
                    command.Parameters.Add(New SqlParameter("@Building_No", Building_No))
                    command.Parameters.Add(New SqlParameter("@PartakeArea", PartakeArea))
                    command.Parameters.Add(New SqlParameter("@PartakeUintPrice", PartakeUintPrice))
                    command.Parameters.Add(New SqlParameter("@PartakePrice", PartakePrice))
                    command.Parameters.Add(New SqlParameter("@PartakeAge", PartakeAge))
                    command.Parameters.Add(New SqlParameter("@PartakePersent1", PartakePersent1))
                    command.Parameters.Add(New SqlParameter("@PartakePersent2", PartakePersent2))
                    command.Parameters.Add(New SqlParameter("@PartakePersent3", PartakePersent3))
                    command.Parameters.Add(New SqlParameter("@PartakePriceTotalDeteriorate", PartakePriceTotalDeteriorate))
                    command.Parameters.Add(New SqlParameter("@PercentFinish", PercentFinish))
                    command.Parameters.Add(New SqlParameter("@PriceFinish", PriceFinish))
                    command.Parameters.Add(New SqlParameter("@PartakeDetail", PartakeDetail))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    'command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    MsgBox(ex.Message)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Function GET_PRICE3_70_PARTAKE(ByVal ID As Integer, ByVal REQ_ID As Integer, ByVal Hub_Id As Integer, ByVal TEMP_AID As Integer, ByVal Partake_Id As Integer) As Generic.List(Of Price3_70_Partake)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE3_70_PARTAKE_PK", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@ID", ID))
                command.Parameters.Add(New SqlParameter("@REQ_ID", REQ_ID))
                command.Parameters.Add(New SqlParameter("@HUB_ID", Hub_Id))
                command.Parameters.Add(New SqlParameter("@TEMP_AID", TEMP_AID))
                command.Parameters.Add(New SqlParameter("@PARTAKE_ID", Partake_Id))
                connection.Open()
                Dim list As New Generic.List(Of Price3_70_Partake)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Price3_70_Partake(CInt(reader("Id")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CInt(reader("Temp_AID")), _
                                                CStr(reader("AID")), _
                                                CInt(reader("Partake_Id")), _
                                                CStr(reader("Building_No")), _
                                                CDec(reader("PartakeArea")), _
                                                CDec(reader("PartakeUintPrice")), _
                                                CDec(reader("PartakePrice")), _
                                                CDec(reader("PartakeAge")), _
                                                CDec(reader("PartakePersent1")), _
                                                CDec(reader("PartakePersent2")), _
                                                CDec(reader("PartakePersent3")), _
                                                CDec(reader("PartakePriceTotalDeteriorate")), _
                                                CInt(reader("PercentFinish")), _
                                                CDec(reader("PriceFinish")), _
                                                CStr(reader("PartakeDetail")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
            End Using
            connection.Close()
        End Using

    End Function

    Public Shared Function GET_PRICE3_70_GROUP_PARTAKE(ByVal Req_Id As Integer, ByVal Hub_Id As Integer, ByVal Temp_AID As Integer) As DataSet
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE3_70_PARTAKE_GROUP", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                connection.Open()
                Dim list As New SqlDataAdapter(command)
                'Using reader As SqlDataAdapter = command.ExecuteNonQuery()
                Dim ds As New DataSet
                list.Fill(ds)
                Return ds

            End Using
            connection.Close()
        End Using

    End Function

    Public Shared Function GET_PRICE3_CONFORM(ByVal Req_Id As Integer, ByVal Hub_Id As Integer, ByVal Temp_AID As Integer) As Generic.List(Of Price3_50)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE3_CONFORM", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                connection.Open()
                Dim list As New Generic.List(Of Price3_50)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Price3_50(CInt(reader("ID")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CInt(reader("Temp_AID")), _
                                                CStr(reader("AID")), _
                                                CStr(reader("CID")), _
                                                CInt(reader("MysubColl_ID")), _
                                                CStr(reader("Address_No")), _
                                                CStr(reader("Building_Name")), _
                                                CStr(reader("Tumbon")), _
                                                CStr(reader("Amphur")), _
                                                CInt(reader("Province")), _
                                                CInt(reader("Rai")), _
                                                CInt(reader("Ngan")), _
                                                CDec(reader("Wah")), _
                                                CStr(reader("Road")), _
                                                CInt(reader("Road_Detail")), _
                                                CDec(reader("Road_Access")), _
                                                CStr(reader("Soi")), _
                                                CInt(reader("Road_Frontoff")), _
                                                CDec(reader("Roadwidth")), _
                                                CInt(reader("Sited")), _
                                                CStr(reader("Site_Detail")), _
                                                CInt(reader("Land_State")), _
                                                CStr(reader("Land_State_Detail")), _
                                                CInt(reader("Public_Utility")), _
                                                CStr(reader("Public_Utility_Detail")), _
                                                CInt(reader("Binifit")), _
                                                CStr(reader("Binifit_Detail")), _
                                                CInt(reader("Tendency")), _
                                                CInt(reader("BuySale_State")), _
                                                CInt(reader("SubUnit_Id")), _
                                                CDec(reader("PriceWah")), _
                                                CDec(reader("PriceTotal1")), _
                                                CStr(reader("Rawang")), _
                                                CStr(reader("LandNumber")), _
                                                CStr(reader("Surway")), _
                                                CStr(reader("DocNo")), _
                                                CStr(reader("PageNo")), _
                                                CStr(reader("Ownership")), _
                                                CStr(reader("Obligation")), _
                                                CDec(reader("Land_Closeto_RoadWidth")), _
                                                CStr(reader("DeepWidth")), _
                                                CDec(reader("BehindWidth")), _
                                                CInt(reader("AreaColour_No")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
            End Using
            connection.Close()
        End Using

    End Function

    Public Shared Function GET_PRICE3_50_GROUP(ByVal Req_Id As Integer, ByVal Hub_Id As Integer, ByVal Temp_AID As Integer) As DataSet
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE3_50_GROUP", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                connection.Open()
                Dim list As New SqlDataAdapter(command)
                'Using reader As SqlDataAdapter = command.ExecuteNonQuery()
                Dim ds As New DataSet
                list.Fill(ds)
                Return ds
            End Using
            connection.Close()
        End Using

    End Function

    Public Shared Function GET_SUM_PRICE3_50(ByVal Req_Id As Integer, ByVal Hub_Id As Integer, ByVal Temp_AID As Integer) As DataSet
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_SUM_PRICE3_50", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                connection.Open()
                Dim list As New SqlDataAdapter(command)
                'Using reader As SqlDataAdapter = command.ExecuteNonQuery()
                Dim ds As New DataSet
                list.Fill(ds)
                Return ds
            End Using
            connection.Close()
        End Using

    End Function

    Public Shared Function GET_PRICE3_70_GROUP(ByVal Req_Id As Integer, ByVal Hub_Id As Integer, ByVal Temp_AID As Integer) As DataSet
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE3_70_GROUP", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                connection.Open()
                Dim list As New SqlDataAdapter(command)
                'Using reader As SqlDataAdapter = command.ExecuteNonQuery()
                Dim ds As New DataSet
                list.Fill(ds)
                Return ds
            End Using
            connection.Close()
        End Using

    End Function

    Public Shared Function GET_PRICE3_70_COUNT(ByVal Req_Id As Integer, ByVal Hub_Id As Integer, ByVal Temp_AID As Integer) As DataSet
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE3_70_COUNT", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                connection.Open()
                Dim list As New SqlDataAdapter(command)
                'Using reader As SqlDataAdapter = command.ExecuteNonQuery()
                Dim ds As New DataSet
                list.Fill(ds)
                Return ds
            End Using
            connection.Close()
        End Using

    End Function

    Public Shared Sub ADD_PRICE3_REVIEW_ALL_TYPE(ByVal Id As Integer, _
     ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
     ByVal Temp_AID As Integer, _
     ByVal MysubColl_ID As Integer, _
     ByVal Create_User As String)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("Add_Appraisal_Data_Review", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@ID", Id))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@MysubColl_ID", MysubColl_ID))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    'MsgBox(ex.Message)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Function GET_PRICE3_50_REVIEW(ByVal Req_Id As Integer, ByVal Hub_Id As Integer, ByVal ID As Integer) As Generic.List(Of Price3_50)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE3_50", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                command.Parameters.Add(New SqlParameter("@ID", ID))
                connection.Open()
                Dim list As New Generic.List(Of Price3_50)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Price3_50(CInt(reader("ID")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CInt(reader("Temp_AID")), _
                                                CStr(reader("AID")), _
                                                CStr(reader("CID")), _
                                                CInt(reader("MysubColl_ID")), _
                                                CStr(reader("Address_No")), _
                                                CStr(reader("Building_Name")), _
                                                CStr(reader("Tumbon")), _
                                                CStr(reader("Amphur")), _
                                                CInt(reader("Province")), _
                                                CInt(reader("Rai")), _
                                                CInt(reader("Ngan")), _
                                                CDec(reader("Wah")), _
                                                CStr(reader("Road")), _
                                                CInt(reader("Road_Detail")), _
                                                CDec(reader("Road_Access")), _
                                                CStr(reader("Soi")), _
                                                CInt(reader("Road_Frontoff")), _
                                                CDec(reader("Roadwidth")), _
                                                CInt(reader("Sited")), _
                                                CStr(reader("Site_Detail")), _
                                                CInt(reader("Land_State")), _
                                                CStr(reader("Land_State_Detail")), _
                                                CInt(reader("Public_Utility")), _
                                                CStr(reader("Public_Utility_Detail")), _
                                                CInt(reader("Binifit")), _
                                                CStr(reader("Binifit_Detail")), _
                                                CInt(reader("Tendency")), _
                                                CInt(reader("BuySale_State")), _
                                                CInt(reader("SubUnit_Id")), _
                                                CDec(reader("PriceWah")), _
                                                CDec(reader("PriceTotal1")), _
                                                CStr(reader("Rawang")), _
                                                CStr(reader("LandNumber")), _
                                                CStr(reader("Surway")), _
                                                CStr(reader("DocNo")), _
                                                CStr(reader("PageNo")), _
                                                CStr(reader("Ownership")), _
                                                CStr(reader("Obligation")), _
                                                CDec(reader("Land_Closeto_RoadWidth")), _
                                                CDec(reader("DeepWidth")), _
                                                CDec(reader("BehindWidth")), _
                                                CInt(reader("AreaColour_No")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using

    End Function

    Public Shared Function GET_PRICE3_70_REVIEW(ByVal Req_Id As Integer, ByVal Hub_Id As Integer, ByVal ID As Integer) As Generic.List(Of Price3_70_Review)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE3_70_REVIEW", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                command.Parameters.Add(New SqlParameter("@ID", ID))
                connection.Open()
                Dim list As New Generic.List(Of Price3_70_Review)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Price3_70_Review(CInt(reader("ID")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CInt(reader("Temp_AID")), _
                                                CInt(reader("MysubColl_ID")), _
                                                CStr(reader("Build_No")), _
                                                CStr(reader("Tumbon")), _
                                                CStr(reader("Amphur")), _
                                                CInt(reader("Province")), _
                                                CInt(reader("Build_Character")), _
                                                CStr(reader("Floors")), _
                                                CInt(reader("Item")), _
                                                CInt(reader("Build_Construct")), _
                                                CInt(reader("Roof")), _
                                                CStr(reader("Roof_Detail")), _
                                                CInt(reader("Build_State")), _
                                                CStr(reader("Build_State_Detail")), _
                                                CStr(reader("Building_Detail")), _
                                                CDec(reader("PriceTotal1")), _
                                                CInt(reader("Doc1")), _
                                                CInt(reader("Doc2")), _
                                                CStr(reader("Doc_Detail")), _
                                                CStr(reader("Pic_path")), _
                                                CStr(reader("Put_On_Chanode")), _
                                                CStr(reader("Ownership")), _
                                                CDec(reader("BuildingArea")), _
                                                CDec(reader("BuildingUintPrice")), _
                                                CDec(reader("BuildingPrice")), _
                                                CInt(reader("BuildingAge")), _
                                                CDec(reader("BuildingPersent1")), _
                                                CDec(reader("BuildingPersent2")), _
                                                CDec(reader("BuildingPersent3")), _
                                                CDec(reader("BuildingPriceTotalDeteriorate")), _
                                                CDec(reader("BuildAddArea")), _
                                                CDec(reader("BuildAddUintPrice")), _
                                                CDec(reader("BuildAddPrice")), _
                                                CDec(reader("BuildAddAge")), _
                                                CDec(reader("BuildAddPersent1")), _
                                                CDec(reader("BuildAddPersent2")), _
                                                CDec(reader("BuildAddPersent3")), _
                                                CDec(reader("BuildAddPriceTotalDeteriorate")), _
                                                CStr(reader("BuildingDetail")), _
                                                CInt(reader("Decoration")), _
                                                CInt(reader("Standard_Id")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using

    End Function

    Public Shared Function GET_PRICE3_70_REVIEW_BY_REQ_ID(ByVal Req_Id As Integer, ByVal Hub_Id As Integer) As Generic.List(Of Price3_70_Review)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE3_70_REVIEW_BY_REQ_ID", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                connection.Open()
                Dim list As New Generic.List(Of Price3_70_Review)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Price3_70_Review(CInt(reader("ID")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CInt(reader("Temp_AID")), _
                                                CInt(reader("MysubColl_ID")), _
                                                CStr(reader("Build_No")), _
                                                CStr(reader("Tumbon")), _
                                                CStr(reader("Amphur")), _
                                                CInt(reader("Province")), _
                                                CInt(reader("Build_Character")), _
                                                CStr(reader("Floors")), _
                                                CInt(reader("Item")), _
                                                CInt(reader("Build_Construct")), _
                                                CInt(reader("Roof")), _
                                                CStr(reader("Roof_Detail")), _
                                                CInt(reader("Build_State")), _
                                                CStr(reader("Build_State_Detail")), _
                                                CStr(reader("Building_Detail")), _
                                                CDec(reader("PriceTotal1")), _
                                                CInt(reader("Doc1")), _
                                                CInt(reader("Doc2")), _
                                                CStr(reader("Doc_Detail")), _
                                                CStr(reader("Pic_path")), _
                                                CStr(reader("Put_On_Chanode")), _
                                                CStr(reader("Ownership")), _
                                                CDec(reader("BuildingArea")), _
                                                CDec(reader("BuildingUintPrice")), _
                                                CDec(reader("BuildingPrice")), _
                                                CInt(reader("BuildingAge")), _
                                                CDec(reader("BuildingPersent1")), _
                                                CDec(reader("BuildingPersent2")), _
                                                CDec(reader("BuildingPersent3")), _
                                                CDec(reader("BuildingPriceTotalDeteriorate")), _
                                                CDec(reader("BuildAddArea")), _
                                                CDec(reader("BuildAddUintPrice")), _
                                                CDec(reader("BuildAddPrice")), _
                                                CDec(reader("BuildAddAge")), _
                                                CDec(reader("BuildAddPersent1")), _
                                                CDec(reader("BuildAddPersent2")), _
                                                CDec(reader("BuildAddPersent3")), _
                                                CDec(reader("BuildAddPriceTotalDeteriorate")), _
                                                CStr(reader("BuildingDetail")), _
                                                CInt(reader("Decoration")), _
                                                CInt(reader("Standard_Id")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using

    End Function

    Public Shared Sub UPDATE_PRICE3_50_REVIEW(ByVal Id As Integer, _
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
     ByVal Wah As Decimal, _
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
     ByVal SubUnit_Id As Integer, _
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

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_PRICE3_50_REVIEW", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@ID", Id))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@MysubColl_ID", MysubColl_ID))
                    command.Parameters.Add(New SqlParameter("@Address_No", Address_No))
                    command.Parameters.Add(New SqlParameter("@Building_Name", Building_Name))
                    command.Parameters.Add(New SqlParameter("@Tumbon", Tumbon))
                    command.Parameters.Add(New SqlParameter("@Amphur", Amphur))
                    command.Parameters.Add(New SqlParameter("@Province", Province))
                    command.Parameters.Add(New SqlParameter("@Rai", Rai))
                    command.Parameters.Add(New SqlParameter("@Ngan", Ngan))
                    command.Parameters.Add(New SqlParameter("@Wah", Wah))
                    command.Parameters.Add(New SqlParameter("@Road", Road))
                    command.Parameters.Add(New SqlParameter("@Road_Detail", Road_Detail))
                    command.Parameters.Add(New SqlParameter("@Road_Access", Road_Access))
                    command.Parameters.Add(New SqlParameter("@Road_Frontoff", Road_Frontoff))
                    command.Parameters.Add(New SqlParameter("@RoadWidth", RoadWidth))
                    command.Parameters.Add(New SqlParameter("@Sited", Sited))
                    command.Parameters.Add(New SqlParameter("@Site_Detail", Site_Detail))
                    command.Parameters.Add(New SqlParameter("@Land_State", Land_State))
                    command.Parameters.Add(New SqlParameter("@Land_State_Detail", Land_State_Detail))
                    command.Parameters.Add(New SqlParameter("@Public_Utility", Public_Utility))
                    command.Parameters.Add(New SqlParameter("@Public_Utility_Detail", Public_Utility_Detail))
                    command.Parameters.Add(New SqlParameter("@Binifit", Binifit))
                    command.Parameters.Add(New SqlParameter("@Binifit_Detail", Binifit_Detail))
                    command.Parameters.Add(New SqlParameter("@Tendency", Tendency))
                    command.Parameters.Add(New SqlParameter("@BuySale_State", BuySale_State))
                    command.Parameters.Add(New SqlParameter("@SubUnit_Id", SubUnit_Id))
                    command.Parameters.Add(New SqlParameter("@PriceWah", PriceWah))
                    command.Parameters.Add(New SqlParameter("@PriceTotal1", PriceTotal1))
                    command.Parameters.Add(New SqlParameter("@Rawang", Rawang))
                    command.Parameters.Add(New SqlParameter("@LandNumber", LandNumber))
                    command.Parameters.Add(New SqlParameter("@Surway", Surway))
                    command.Parameters.Add(New SqlParameter("@DocNo", DocNo))
                    command.Parameters.Add(New SqlParameter("@PageNo", PageNo))
                    command.Parameters.Add(New SqlParameter("@Ownership", Ownership))
                    command.Parameters.Add(New SqlParameter("@Obligation", Obligation))
                    command.Parameters.Add(New SqlParameter("@Land_Closeto_RoadWidth", Land_Closeto_RoadWidth))
                    command.Parameters.Add(New SqlParameter("@DeepWidth", DeepWidth))
                    command.Parameters.Add(New SqlParameter("@BehindWidth", BehindWidth))
                    command.Parameters.Add(New SqlParameter("@AreaColour_No", AreaColour_No))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    MsgBox(ex.Message)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub UPDATE_PRICE3_70_REVIEW(ByVal ID As Integer, ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
     ByVal Temp_AID As Integer, _
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
     ByVal Ownership As String, _
     ByVal BuildingArea As Double, _
     ByVal BuildingUintPrice As Double, _
     ByVal BuildingPrice As Double, _
     ByVal BuildingAge As Integer, _
     ByVal BuildingPersent1 As Decimal, _
     ByVal BuildingPersent2 As Decimal, _
     ByVal BuildingPersent3 As Decimal, _
     ByVal BuildingPriceTotalDeteriorate As Decimal, _
     ByVal BuildAddArea As Double, _
     ByVal BuildAddUintPrice As Double, _
     ByVal BuildAddPrice As Double, _
     ByVal BuildAddAge As Integer, _
     ByVal BuildAddPersent1 As Decimal, _
     ByVal BuildAddPersent2 As Decimal, _
     ByVal BuildAddPersent3 As Decimal, _
     ByVal BuildAddPriceTotalDeteriorate As Decimal, _
     ByVal BuildingDetail As String, _
     ByVal Decoration As Integer, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_PRICE3_70_REVIEW", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Id", ID))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@MysubColl_ID", MysubColl_ID))
                    command.Parameters.Add(New SqlParameter("@Build_No", Build_No))
                    command.Parameters.Add(New SqlParameter("@Tumbon", Tumbon))
                    command.Parameters.Add(New SqlParameter("@Amphur", Amphur))
                    command.Parameters.Add(New SqlParameter("@Province", Province))
                    command.Parameters.Add(New SqlParameter("@Build_Character", Build_Character))
                    command.Parameters.Add(New SqlParameter("@Floors", Floors))
                    command.Parameters.Add(New SqlParameter("@Item", Item))
                    command.Parameters.Add(New SqlParameter("@Build_Construct", Build_Construct))
                    command.Parameters.Add(New SqlParameter("@Roof", Roof))
                    command.Parameters.Add(New SqlParameter("@Roof_Detail", Roof_Detail))
                    command.Parameters.Add(New SqlParameter("@Build_State", Build_State))
                    command.Parameters.Add(New SqlParameter("@Build_State_Detail", Build_State_Detail))
                    command.Parameters.Add(New SqlParameter("@Building_Detail", Building_Detail))
                    command.Parameters.Add(New SqlParameter("@PriceTotal1", PriceTotal1))
                    command.Parameters.Add(New SqlParameter("@Doc1", Doc1))
                    command.Parameters.Add(New SqlParameter("@Doc2", Doc2))
                    command.Parameters.Add(New SqlParameter("@Doc_Detail", Doc_Detail))
                    command.Parameters.Add(New SqlParameter("@Pic_path", Pic_path))
                    command.Parameters.Add(New SqlParameter("@Put_On_Chanode", Put_On_Chanode))
                    command.Parameters.Add(New SqlParameter("@Ownership", Ownership))
                    command.Parameters.Add(New SqlParameter("@BuildingArea", BuildingArea))
                    command.Parameters.Add(New SqlParameter("@BuildingUintPrice", BuildingUintPrice))
                    command.Parameters.Add(New SqlParameter("@BuildingPrice", BuildingPrice))
                    command.Parameters.Add(New SqlParameter("@BuildingAge", BuildingAge))
                    command.Parameters.Add(New SqlParameter("@BuildingPersent1", BuildingPersent1))
                    command.Parameters.Add(New SqlParameter("@BuildingPersent2", BuildingPersent2))
                    command.Parameters.Add(New SqlParameter("@BuildingPersent3", BuildingPersent3))
                    command.Parameters.Add(New SqlParameter("@BuildingPriceTotalDeteriorate", BuildingPriceTotalDeteriorate))
                    command.Parameters.Add(New SqlParameter("@BuildAddArea", BuildAddArea))
                    command.Parameters.Add(New SqlParameter("@BuildAddUintPrice", BuildAddUintPrice))
                    command.Parameters.Add(New SqlParameter("@BuildAddPrice", BuildAddPrice))
                    command.Parameters.Add(New SqlParameter("@BuildAddAge", BuildAddAge))
                    command.Parameters.Add(New SqlParameter("@BuildAddPersent1", BuildAddPersent1))
                    command.Parameters.Add(New SqlParameter("@BuildAddPersent2", BuildAddPersent2))
                    command.Parameters.Add(New SqlParameter("@BuildAddPersent3", BuildAddPersent3))
                    command.Parameters.Add(New SqlParameter("@BuildAddPriceTotalDeteriorate", BuildAddPriceTotalDeteriorate))
                    command.Parameters.Add(New SqlParameter("@BuildingDetail", BuildingDetail))
                    command.Parameters.Add(New SqlParameter("@Decoration", Decoration))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    MsgBox(ex.Message)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub ADD_PRICE3_MASTER_REVIEW(ByVal Req_Id As Integer, _
  ByVal AID As String, _
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

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("ADD_PRICE3_MASTER_REVIEW", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@AID", AID))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@Cif", Cif))
                    command.Parameters.Add(New SqlParameter("@District", District))
                    command.Parameters.Add(New SqlParameter("@Amphur", Amphur))
                    command.Parameters.Add(New SqlParameter("@Building_Age", Building_Age))
                    command.Parameters.Add(New SqlParameter("@Memo_Date", Memo_Date))
                    command.Parameters.Add(New SqlParameter("@Sequence", Sequence))
                    command.Parameters.Add(New SqlParameter("@Land_Chg", Land_Chg))
                    command.Parameters.Add(New SqlParameter("@Land_Chg_Detail", Land_Chg_Detail))
                    command.Parameters.Add(New SqlParameter("@Obligation_Chg", Obligation_Chg))
                    command.Parameters.Add(New SqlParameter("@Obligation_Chg_Detail", Obligation_Chg_Detail))
                    command.Parameters.Add(New SqlParameter("@Site_Chg", Site_Chg))
                    command.Parameters.Add(New SqlParameter("@Site_Chg_Detail", Site_Chg_Detail))
                    command.Parameters.Add(New SqlParameter("@Progress_Chg", Progress_Chg))
                    command.Parameters.Add(New SqlParameter("@Building_Chg", Building_Chg))
                    command.Parameters.Add(New SqlParameter("@Building_Chg_Detail", Building_Chg_Detail))
                    command.Parameters.Add(New SqlParameter("@Appraisal_Last_Detail", Appraisal_Last_Detail))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    MsgBox(ex.Message)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub UPDATE_PRICE3_MASTER_REVIEW(ByVal Req_Id As Integer, _
  ByVal AID As String, _
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

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_PRICE3_MASTER_REVIEW", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@AID", AID))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@Cif", Cif))
                    command.Parameters.Add(New SqlParameter("@District", District))
                    command.Parameters.Add(New SqlParameter("@Amphur", Amphur))
                    command.Parameters.Add(New SqlParameter("@Building_Age", Building_Age))
                    command.Parameters.Add(New SqlParameter("@Memo_Date", Memo_Date))
                    command.Parameters.Add(New SqlParameter("@Sequence", Sequence))
                    command.Parameters.Add(New SqlParameter("@Land_Chg", Land_Chg))
                    command.Parameters.Add(New SqlParameter("@Land_Chg_Detail", Land_Chg_Detail))
                    command.Parameters.Add(New SqlParameter("@Obligation_Chg", Obligation_Chg))
                    command.Parameters.Add(New SqlParameter("@Obligation_Chg_Detail", Obligation_Chg_Detail))
                    command.Parameters.Add(New SqlParameter("@Site_Chg", Site_Chg))
                    command.Parameters.Add(New SqlParameter("@Site_Chg_Detail", Site_Chg_Detail))
                    command.Parameters.Add(New SqlParameter("@Progress_Chg", Progress_Chg))
                    command.Parameters.Add(New SqlParameter("@Building_Chg", Building_Chg))
                    command.Parameters.Add(New SqlParameter("@Building_Chg_Detail", Building_Chg_Detail))
                    command.Parameters.Add(New SqlParameter("@Appraisal_Last_Detail", Appraisal_Last_Detail))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    'command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    'MsgBox(ex.Message)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Function GET_PRICE3_MASTER_REVIEW(ByVal CIF As Integer, ByVal AID As String, ByVal REQ_ID As Integer) As Generic.List(Of Price3_Master_Review)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE3_MASTER_REVIEW", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@CIF", CIF))
                command.Parameters.Add(New SqlParameter("@AID", AID))
                command.Parameters.Add(New SqlParameter("@REQ_ID", REQ_ID))
                connection.Open()
                Dim list As New Generic.List(Of Price3_Master_Review)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Price3_Master_Review(CInt(reader("Req_Id")), _
                                                CStr(reader("AID")), _
                                                CInt(reader("Temp_AID")), _
                                                CInt(reader("Cif")), _
                                                CStr(reader("District")), _
                                                CStr(reader("Amphur")), _
                                                CDec(reader("Building_Age")), _
                                                CDate(reader("Memo_Date")), _
                                                CInt(reader("Sequence")), _
                                                CInt(reader("Land_Chg")), _
                                                CStr(reader("Land_Chg_Detail")), _
                                                CInt(reader("Obligation_Chg")), _
                                                CStr(reader("Obligation_Chg_Detail")), _
                                                CInt(reader("Site_Chg")), _
                                                CStr(reader("Site_Chg_Detail")), _
                                                CInt(reader("Progress_Chg")), _
                                                CInt(reader("Building_Chg")), _
                                                CStr(reader("Building_Chg_Detail")), _
                                                CStr(reader("Appraisal_Last_Detail")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
            End Using
            connection.Close()
        End Using

    End Function

    Public Shared Sub Add_Price3_70_Review_Partake(ByVal Id As Integer, _
     ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
     ByVal Temp_AID As Integer, _
     ByVal AID As String, _
     ByVal Partake_Id As Integer, _
     ByVal Building_No As String, _
     ByVal PartakeArea As Double, _
     ByVal PartakeUintPrice As Double, _
     ByVal PartakePrice As Double, _
     ByVal PartakeAge As Integer, _
     ByVal PartakePersent1 As Decimal, _
     ByVal PartakePersent2 As Decimal, _
     ByVal PartakePersent3 As Decimal, _
     ByVal PartakePriceTotalDeteriorate As Decimal, _
     ByVal PartakeDetail As String, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("ADD_PRICE3_70_REVIEW_PARTAKE", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Id", Id))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@AID", AID))
                    command.Parameters.Add(New SqlParameter("@Partake_Id", Partake_Id))
                    command.Parameters.Add(New SqlParameter("@Building_No", Building_No))
                    command.Parameters.Add(New SqlParameter("@PartakeArea", PartakeArea))
                    command.Parameters.Add(New SqlParameter("@PartakeUintPrice", PartakeUintPrice))
                    command.Parameters.Add(New SqlParameter("@PartakePrice", PartakePrice))
                    command.Parameters.Add(New SqlParameter("@PartakeAge", PartakeAge))
                    command.Parameters.Add(New SqlParameter("@PartakePersent1", PartakePersent1))
                    command.Parameters.Add(New SqlParameter("@PartakePersent2", PartakePersent2))
                    command.Parameters.Add(New SqlParameter("@PartakePersent3", PartakePersent3))
                    command.Parameters.Add(New SqlParameter("@PartakePriceTotalDeteriorate", PartakePriceTotalDeteriorate))
                    command.Parameters.Add(New SqlParameter("@PartakeDetail", PartakeDetail))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    'command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    MsgBox(ex.Message)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub Update_Price3_70_Review_Partake(ByVal Id As Integer, _
     ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
     ByVal Temp_AID As Integer, _
     ByVal AID As String, _
     ByVal Partake_Id As Integer, _
     ByVal PartakeArea As Double, _
     ByVal PartakeUintPrice As Double, _
     ByVal PartakePrice As Double, _
     ByVal PartakeAge As Integer, _
     ByVal PartakePersent1 As Decimal, _
     ByVal PartakePersent2 As Decimal, _
     ByVal PartakePersent3 As Decimal, _
     ByVal PartakePriceTotalDeteriorate As Decimal, _
     ByVal PartakeDetail As String, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("Update_Price3_70_Review_Partake", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Id", Id))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@AID", AID))
                    command.Parameters.Add(New SqlParameter("@Partake_Id", Partake_Id))
                    command.Parameters.Add(New SqlParameter("@PartakeArea", PartakeArea))
                    command.Parameters.Add(New SqlParameter("@PartakeUintPrice", PartakeUintPrice))
                    command.Parameters.Add(New SqlParameter("@PartakePrice", PartakePrice))
                    command.Parameters.Add(New SqlParameter("@PartakeAge", PartakeAge))
                    command.Parameters.Add(New SqlParameter("@PartakePersent1", PartakePersent1))
                    command.Parameters.Add(New SqlParameter("@PartakePersent2", PartakePersent2))
                    command.Parameters.Add(New SqlParameter("@PartakePersent3", PartakePersent3))
                    command.Parameters.Add(New SqlParameter("@PartakePriceTotalDeteriorate", PartakePriceTotalDeteriorate))
                    command.Parameters.Add(New SqlParameter("@PartakeDetail", PartakeDetail))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    'command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    MsgBox(ex.Message)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Function GET_PRICE3_70_REVIEW_PARTAKE(ByVal ID As Integer, ByVal REQ_ID As Integer, ByVal Hub_Id As Integer, ByVal AID As String, ByVal TEMP_AID As Integer, ByVal Partake_Id As Integer) As Generic.List(Of Price3_70_Review_Partake)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE3_70_REVIEW_PARTAKE_PK", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@ID", ID))
                command.Parameters.Add(New SqlParameter("@REQ_ID", REQ_ID))
                command.Parameters.Add(New SqlParameter("@HUB_ID", Hub_Id))
                command.Parameters.Add(New SqlParameter("@AID", AID))
                command.Parameters.Add(New SqlParameter("@TEMP_AID", TEMP_AID))
                command.Parameters.Add(New SqlParameter("@PARTAKE_ID", Partake_Id))
                connection.Open()
                Dim list As New Generic.List(Of Price3_70_Review_Partake)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Price3_70_Review_Partake(CInt(reader("Id")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CInt(reader("Temp_AID")), _
                                                CStr(reader("AID")), _
                                                CInt(reader("Partake_Id")), _
                                                CStr(reader("Building_No")), _
                                                CDec(reader("PartakeArea")), _
                                                CDec(reader("PartakeUintPrice")), _
                                                CDec(reader("PartakePrice")), _
                                                CDec(reader("PartakeAge")), _
                                                CDec(reader("PartakePersent1")), _
                                                CDec(reader("PartakePersent2")), _
                                                CDec(reader("PartakePersent3")), _
                                                CDec(reader("PartakePriceTotalDeteriorate")), _
                                                CStr(reader("PartakeDetail")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using

    End Function

    Public Shared Function GET_PRICE3_70_REVIEW_PARTAKE_SUM(ByVal REQ_ID As Integer, ByVal Hub_Id As Integer, ByVal AID As String, ByVal TEMP_AID As Integer) As Generic.List(Of Price3_70_Review_Partake)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE3_70_REVIEW_PARTAKE_SUM", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@REQ_ID", REQ_ID))
                command.Parameters.Add(New SqlParameter("@HUB_ID", Hub_Id))
                command.Parameters.Add(New SqlParameter("@AID", AID))
                command.Parameters.Add(New SqlParameter("@TEMP_AID", TEMP_AID))
                connection.Open()
                Dim list As New Generic.List(Of Price3_70_Review_Partake)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Price3_70_Review_Partake(CInt(reader("Id")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CInt(reader("Temp_AID")), _
                                                CStr(reader("AID")), _
                                                CInt(reader("Partake_Id")), _
                                                CStr(reader("Building_No")), _
                                                CDec(reader("PartakeArea")), _
                                                CDec(reader("PartakeUintPrice")), _
                                                CDec(reader("PartakePrice")), _
                                                CDec(reader("PartakeAge")), _
                                                CDec(reader("PartakePersent1")), _
                                                CDec(reader("PartakePersent2")), _
                                                CDec(reader("PartakePersent3")), _
                                                CDec(reader("PartakePriceTotalDeteriorate")), _
                                                CStr(reader("PartakeDetail")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using

    End Function

    Public Shared Sub ADD_PRICE3_70_DETAIL_REVIEW(ByVal Id As Integer, _
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

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("ADD_PRICE3_70_DETAIL_REVIEW", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Id", Id))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@Floors", Floor))
                    command.Parameters.Add(New SqlParameter("@Main_Construction", Main_Construction))
                    command.Parameters.Add(New SqlParameter("@Concrete", Concrete))
                    command.Parameters.Add(New SqlParameter("@Granite", Granite))
                    command.Parameters.Add(New SqlParameter("@Parquet", Parquet))
                    command.Parameters.Add(New SqlParameter("@Ceramic", Ceramic))
                    command.Parameters.Add(New SqlParameter("@Wood", Wood))
                    command.Parameters.Add(New SqlParameter("@Other", Other))
                    command.Parameters.Add(New SqlParameter("@Other_Detail", Other_Detail))
                    command.Parameters.Add(New SqlParameter("@BrickWall", BrickWall))
                    command.Parameters.Add(New SqlParameter("@BlockBrickWall", BlockBrickWall))
                    command.Parameters.Add(New SqlParameter("@WoodWall", WoodWall))
                    command.Parameters.Add(New SqlParameter("@OtherWall", OtherWall))
                    command.Parameters.Add(New SqlParameter("@OtherWall_Detail", OtherWall_Detail))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub UPDATE_PRICE3_70_DETAIL_REVIEW(ByVal Id As String, _
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

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_PRICE3_70_DETAIL_REVIEW", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Id", Id))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@Floors", Floor))
                    command.Parameters.Add(New SqlParameter("@Main_Construction", Main_Construction))
                    command.Parameters.Add(New SqlParameter("@Concrete", Concrete))
                    command.Parameters.Add(New SqlParameter("@Granite", Granite))
                    command.Parameters.Add(New SqlParameter("@Parquet", Parquet))
                    command.Parameters.Add(New SqlParameter("@Ceramic", Ceramic))
                    command.Parameters.Add(New SqlParameter("@Wood", Wood))
                    command.Parameters.Add(New SqlParameter("@Other", Other))
                    command.Parameters.Add(New SqlParameter("@Other_Detail", Other_Detail))
                    command.Parameters.Add(New SqlParameter("@BrickWall", BrickWall))
                    command.Parameters.Add(New SqlParameter("@BlockBrickWall", BlockBrickWall))
                    command.Parameters.Add(New SqlParameter("@WoodWall", WoodWall))
                    command.Parameters.Add(New SqlParameter("@OtherWall", OtherWall))
                    command.Parameters.Add(New SqlParameter("@OtherWall_Detail", OtherWall_Detail))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    Dim msg As String
                    Dim title As String
                    Dim style As MsgBoxStyle
                    Dim response1 As MsgBoxResult
                    'msg = "การบันทึกผิดพลาด"   ' Define message.
                    msg = ex.Message
                    style = MsgBoxStyle.DefaultButton2 Or _
                       MsgBoxStyle.Critical Or MsgBoxStyle.YesNo
                    title = "ผลการบันทึก"   ' Define title.
                    ' Display message.
                    response1 = MsgBox(msg, style, title)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub DELETE_PRICE3_70_DETAIL_REVIEW(ByVal Id As String, _
     ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
     ByVal Temp_AID As Integer, _
     ByVal Floor As String)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("DELETE_PRICE3_70_DETAIL_REVIEW", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Id", Id))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@Floors", Floor))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Function GET_PRICE3_70_DETAIL_REVIEW(ByVal ID As Integer, ByVal Req_Id As Integer, ByVal Hub_Id As Integer, ByVal Temp_AID As Integer, ByVal Floors As String) As Generic.List(Of ClsPrice3_70_Detail)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE3_70_DETAIL_REVIEW_BYID", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@ID", ID))
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                command.Parameters.Add(New SqlParameter("@Floors", Floors))
                connection.Open()
                Dim list As New Generic.List(Of ClsPrice3_70_Detail)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New ClsPrice3_70_Detail(CInt(reader("Id")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CInt(reader("Temp_AID")), _
                                                CStr(reader("Floors")), _
                                                CStr(reader("Main_Construction")), _
                                                CInt(reader("Concrete")), _
                                                CInt(reader("Granite")), _
                                                CInt(reader("Parquet")), _
                                                CInt(reader("Ceramic")), _
                                                CInt(reader("Wood")), _
                                                CInt(reader("Other")), _
                                                CStr(reader("Other_Detail")), _
                                                CInt(reader("BrickWall")), _
                                                CInt(reader("BlockBrickWall")), _
                                                CInt(reader("WoodWall")), _
                                                CInt(reader("OtherWall")), _
                                                CStr(reader("OtherWall_Detail")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using

    End Function

    Public Shared Function GET_PRICE3_18_REVIEW_BYID(ByVal ID As Integer, ByVal Req_Id As Integer, ByVal Hub_Id As Integer) As Generic.List(Of Price3_18_Review)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE3_18_REVIEW_BY_ID", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@ID", ID))
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                connection.Open()
                Dim list As New Generic.List(Of Price3_18_Review)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Price3_18_Review(CInt(reader("ID")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CStr(reader("AID")), _
                                                CStr(reader("CID")), _
                                                CInt(reader("Temp_AID")), _
                                                CInt(reader("MysubColl_ID")), _
                                                CInt(reader("Floors_All")), _
                                                CInt(reader("Elevator")), _
                                                CStr(reader("Address_No")), _
                                                CDec(reader("Room_Area")), _
                                                CDec(reader("Room_Height")), _
                                                CStr(reader("Building_Name")), _
                                                CInt(reader("Floors")), _
                                                CStr(reader("Building_No")), _
                                                CStr(reader("Building_Reg_No")), _
                                                CDec(reader("Building_Age")), _
                                                CStr(reader("Tumbon")), _
                                                CStr(reader("Amphur")), _
                                                CInt(reader("Province")), _
                                                CStr(reader("Road")), _
                                                CInt(reader("Road_Detail")), _
                                                CDec(reader("Road_Access")), _
                                                CInt(reader("Road_Frontoff")), _
                                                CDec(reader("Roadwidth")), _
                                                CInt(reader("Sited")), _
                                                CStr(reader("Site_Detail")), _
                                                CInt(reader("Public_Utility")), _
                                                CStr(reader("Public_Utility_Detail")), _
                                                CInt(reader("Binifit")), _
                                                CStr(reader("Binifit_Detail")), _
                                                CInt(reader("Tendency")), _
                                                CInt(reader("BuySale_State")), _
                                                CInt(reader("Building_Construc")), _
                                                CInt(reader("InteriorState_Id")), _
                                                CInt(reader("Character_Room_Id")), _
                                                CDec(reader("RoomWidth_BehideSiteWalk")), _
                                                CDec(reader("Roomdeep")), _
                                                CDec(reader("Backside_Width")), _
                                                CInt(reader("SideWalk_Is")), _
                                                CDec(reader("SideWalk_Width")), _
                                                CStr(reader("Partake_Detail")), _
                                                CStr(reader("Ownership")), _
                                                CStr(reader("Obligation")), _
                                                CStr(reader("Other_Detail")), _
                                                CStr(reader("Tumbon1")), _
                                                CStr(reader("Amphur1")), _
                                                CInt(reader("Province1")), _
                                                CInt(reader("Elevator_Util")), _
                                                CInt(reader("Parking_Util")), _
                                                CInt(reader("Pool_Util")), _
                                                CInt(reader("Fitness_Util")), _
                                                CInt(reader("Other_Util")), _
                                                CStr(reader("Other_Util_Detail")), _
                                                CStr(reader("Adjust_Condo")), _
                                                CDec(reader("Unit_Price")), _
                                                CDec(reader("PriceTotal")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        'MsgBox(reader("Elevator_Util"))
                        list.Add(temp)
                        'MsgBox(temp.Elevator_Util)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using

    End Function

    Public Shared Function GET_PRICE3_18_REVIEW_GROUP(ByVal Req_Id As Integer, ByVal Hub_Id As Integer, ByVal Temp_AID As Integer) As Generic.List(Of Price3_18_Review)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE3_18_REVIEW_GROUP", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                connection.Open()
                Dim list As New Generic.List(Of Price3_18_Review)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Price3_18_Review(CInt(reader("ID")), _
                                                CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CStr(reader("AID")), _
                                                CStr(reader("CID")), _
                                                CInt(reader("Temp_AID")), _
                                                CInt(reader("MysubColl_ID")), _
                                                CInt(reader("Floors_All")), _
                                                CInt(reader("Elevator")), _
                                                CStr(reader("Address_No")), _
                                                CDec(reader("Room_Area")), _
                                                CDec(reader("Room_Height")), _
                                                CStr(reader("Building_Name")), _
                                                CInt(reader("Floors")), _
                                                CStr(reader("Building_No")), _
                                                CStr(reader("Building_Reg_No")), _
                                                CDec(reader("Building_Age")), _
                                                CStr(reader("Tumbon")), _
                                                CStr(reader("Amphur")), _
                                                CInt(reader("Province")), _
                                                CStr(reader("Road")), _
                                                CInt(reader("Road_Detail")), _
                                                CDec(reader("Road_Access")), _
                                                CInt(reader("Road_Frontoff")), _
                                                CDec(reader("Roadwidth")), _
                                                CInt(reader("Sited")), _
                                                CStr(reader("Site_Detail")), _
                                                CInt(reader("Public_Utility")), _
                                                CStr(reader("Public_Utility_Detail")), _
                                                CInt(reader("Binifit")), _
                                                CStr(reader("Binifit_Detail")), _
                                                CInt(reader("Tendency")), _
                                                CInt(reader("BuySale_State")), _
                                                CInt(reader("Building_Construc")), _
                                                CInt(reader("InteriorState_Id")), _
                                                CInt(reader("Character_Room_Id")), _
                                                CDec(reader("RoomWidth_BehideSiteWalk")), _
                                                CDec(reader("Roomdeep")), _
                                                CDec(reader("Backside_Width")), _
                                                CInt(reader("SideWalk_Is")), _
                                                CDec(reader("SideWalk_Width")), _
                                                CStr(reader("Partake_Detail")), _
                                                CStr(reader("Ownership")), _
                                                CStr(reader("Obligation")), _
                                                CStr(reader("Other_Detail")), _
                                                CStr(reader("Tumbon1")), _
                                                CStr(reader("Amphur1")), _
                                                CInt(reader("Province1")), _
                                                CInt(reader("Elevator_Util")), _
                                                CInt(reader("Parking_Util")), _
                                                CInt(reader("Pool_Util")), _
                                                CInt(reader("Fitness_Util")), _
                                                CInt(reader("Other_Util")), _
                                                CStr(reader("Other_Util_Detail")), _
                                                CStr(reader("Adjust_Condo")), _
                                                CDec(reader("Unit_Price")), _
                                                CDec(reader("PriceTotal")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using

    End Function

    Public Shared Sub UPDATE_PRICE3_18_REVIEW(ByVal ID As Integer, _
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

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_PRICE3_18_REVIEW", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@ID", ID))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@AID", AID))
                    command.Parameters.Add(New SqlParameter("@CID", CID))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@MysubColl_ID", MysubColl_ID))
                    command.Parameters.Add(New SqlParameter("@Floors_All", Floors_All))
                    command.Parameters.Add(New SqlParameter("@Elevator", Elevator))
                    command.Parameters.Add(New SqlParameter("@Address_No", Address_No))
                    command.Parameters.Add(New SqlParameter("@Room_Area", Room_Area))
                    command.Parameters.Add(New SqlParameter("@Room_Height", Room_Height))
                    command.Parameters.Add(New SqlParameter("@Building_Name", Building_Name))
                    command.Parameters.Add(New SqlParameter("@Floors", Floors))
                    command.Parameters.Add(New SqlParameter("@Building_No", Building_No))
                    command.Parameters.Add(New SqlParameter("@Building_Reg_No", Building_Reg_No))
                    command.Parameters.Add(New SqlParameter("@Building_Age", Building_Age))
                    command.Parameters.Add(New SqlParameter("@Tumbon", Tumbon))
                    command.Parameters.Add(New SqlParameter("@Amphur", Amphur))
                    command.Parameters.Add(New SqlParameter("@Province", Province))
                    command.Parameters.Add(New SqlParameter("@Road", Road))
                    command.Parameters.Add(New SqlParameter("@Road_Detail", Road_Detail))
                    command.Parameters.Add(New SqlParameter("@Road_Access", Road_Access))
                    command.Parameters.Add(New SqlParameter("@Road_Frontoff", Road_Frontoff))
                    command.Parameters.Add(New SqlParameter("@RoadWidth", RoadWidth))
                    command.Parameters.Add(New SqlParameter("@Site", Site))
                    command.Parameters.Add(New SqlParameter("@Site_Detail", Site_Detail))
                    command.Parameters.Add(New SqlParameter("@Public_Utility", Public_Utility))
                    command.Parameters.Add(New SqlParameter("@Public_Utility_Detail", Public_Utility_Detail))
                    command.Parameters.Add(New SqlParameter("@Binifit", Binifit))
                    command.Parameters.Add(New SqlParameter("@Binifit_Detail", Binifit_Detail))
                    command.Parameters.Add(New SqlParameter("@Tendency", Tendency))
                    command.Parameters.Add(New SqlParameter("@BuySale_State", BuySale_State))
                    command.Parameters.Add(New SqlParameter("@Building_Construc", Building_Construc))
                    command.Parameters.Add(New SqlParameter("@InteriorState_Id", InteriorState_Id))
                    command.Parameters.Add(New SqlParameter("@Character_Room_Id", Character_Room_Id))
                    command.Parameters.Add(New SqlParameter("@RoomWidth_BehideSiteWalk", RoomWidth_BehideSiteWalk))
                    command.Parameters.Add(New SqlParameter("@Roomdeep", Roomdeep))
                    command.Parameters.Add(New SqlParameter("@Backside_Width", Backside_Width))
                    command.Parameters.Add(New SqlParameter("@SideWalk_Is", SideWalk_Is))
                    command.Parameters.Add(New SqlParameter("@SideWalk_Width", SideWalk_Width))
                    command.Parameters.Add(New SqlParameter("@Partake_Detail", Partake_Detail))
                    command.Parameters.Add(New SqlParameter("@Ownership", Ownership))
                    command.Parameters.Add(New SqlParameter("@Obligation", Obligation))
                    command.Parameters.Add(New SqlParameter("@Other_Detail", Other_Detail))
                    command.Parameters.Add(New SqlParameter("@Tumbon1", Tumbon1))
                    command.Parameters.Add(New SqlParameter("@Amphur1", Amphur1))
                    command.Parameters.Add(New SqlParameter("@Province1", Province1))
                    command.Parameters.Add(New SqlParameter("@Elevator_Util", Elevator_Util))
                    command.Parameters.Add(New SqlParameter("@Parking_Util", Parking_Util))
                    command.Parameters.Add(New SqlParameter("@Pool_Util", Pool_Util))
                    command.Parameters.Add(New SqlParameter("@Fitness_Util", Fitness_Util))
                    command.Parameters.Add(New SqlParameter("@Other_Util", Other_Util))
                    command.Parameters.Add(New SqlParameter("@Other_Util_Detail", Other_Util_Detail))
                    command.Parameters.Add(New SqlParameter("@Adjust_Condo", Adjust_Condo))
                    command.Parameters.Add(New SqlParameter("@Unit_Price", Unit_Price))
                    command.Parameters.Add(New SqlParameter("@PriceTotal", PriceTotal))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub ADD_PRICE3_70_DETAIL_AND_PARTAKE(ByVal Req_Id As Integer, _
    ByVal Hub_Id As Integer, _
    ByVal ID As String, _
    ByVal Temp_AID As Integer, _
    ByVal Create_User As String)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("ADD_PRICE3_70_DETAIL_AND_PARTAKE", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@ID", ID))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub ADD_PRICE3_DETAIL_AND_PARTAKE(ByVal Req_Id As Integer, _
    ByVal Hub_Id As Integer, _
    ByVal Temp_AID As Integer)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("ADD_PRICE3_DETAIL_AND_PARTAKE", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub
#End Region

#Region "Process Operation"
    Public Shared Sub INSERT_PROCESSID(ByVal Q_ID As Integer, _
    ByVal PROCESS_ID As Integer)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("ADD_PROCESS_TRANSECTION", connection)

                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Q_ID", Q_ID))
                    command.Parameters.Add(New SqlParameter("@PROCESS_ID", PROCESS_ID))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    Dim msg As String
                    Dim title As String
                    Dim style As MsgBoxStyle
                    Dim response1 As MsgBoxResult
                    myTrans.Rollback()
                    'msg = "การบันทึกผิดพลาด"   ' Define message.
                    msg = ex.Message
                    style = MsgBoxStyle.DefaultButton2 Or _
                       MsgBoxStyle.Critical Or MsgBoxStyle.YesNo
                    title = "ผลการบันทึก"   ' Define title.
                    ' Display message.
                    response1 = MsgBox(msg, style, title)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub
#End Region

#Region "REQUEST ID"
    Public Shared Sub UPDATE_REQUEST_ID()
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_REQUEST_ID", connection)

                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    Dim msg As String
                    Dim title As String
                    Dim style As MsgBoxStyle
                    Dim response1 As MsgBoxResult
                    myTrans.Rollback()
                    'msg = "การบันทึกผิดพลาด"   ' Define message.
                    msg = ex.Message
                    style = MsgBoxStyle.DefaultButton2 Or _
                       MsgBoxStyle.Critical Or MsgBoxStyle.YesNo
                    title = "ผลการบันทึก"   ' Define title.
                    ' Display message.
                    response1 = MsgBox(msg, style, title)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub AddAppraisal_Request(ByVal Req_ID As Integer, _
     ByVal Hub_ID As Integer, _
     ByVal Cif As String, _
     ByVal Title As Integer, _
     ByVal Name As String, _
     ByVal Lastname As String, _
     ByVal Req_Type As Integer, _
     ByVal Status_ID As Integer, _
     ByVal Appraisal_Id As String, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("AddAppraisal_Request", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Req_ID", Req_ID))
                    command.Parameters.Add(New SqlParameter("@Hub_ID", Hub_ID))
                    command.Parameters.Add(New SqlParameter("@Cif", Cif))
                    command.Parameters.Add(New SqlParameter("@Title", Title))
                    command.Parameters.Add(New SqlParameter("@Name", Name))
                    command.Parameters.Add(New SqlParameter("@Lastname", Lastname))
                    command.Parameters.Add(New SqlParameter("@Req_Type", Req_Type))
                    command.Parameters.Add(New SqlParameter("@Status_ID", Status_ID))
                    command.Parameters.Add(New SqlParameter("@Appraisal_Id", Appraisal_Id))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub AddAppraisal_Request_Master(ByVal Req_ID As Integer, _
     ByVal Cif As String, _
     ByVal Title As Integer, _
     ByVal Name As String, _
     ByVal Lastname As String, _
     ByVal Req_Type As Integer, _
     ByVal AID As String, _
     ByVal Status_ID As Integer, _
     ByVal Sender_ID As String, _
     ByVal Sender_Name As String, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("AddAppraisal_Request_MASTER", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Req_ID", Req_ID))
                    command.Parameters.Add(New SqlParameter("@Cif", Cif))
                    command.Parameters.Add(New SqlParameter("@Title", Title))
                    command.Parameters.Add(New SqlParameter("@Name", Name))
                    command.Parameters.Add(New SqlParameter("@Lastname", Lastname))
                    command.Parameters.Add(New SqlParameter("@Req_Type", Req_Type))
                    command.Parameters.Add(New SqlParameter("@AID", AID))
                    command.Parameters.Add(New SqlParameter("@Status_ID", Status_ID))
                    command.Parameters.Add(New SqlParameter("@Sender_ID", Sender_ID))
                    command.Parameters.Add(New SqlParameter("@Sender_Name", Sender_Name))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    MsgBox(ex.Message)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub UPDATE_Status_Appraisal_Request(ByVal Req_Id As Integer, ByVal Hub_Id As Integer, ByVal Status_Id As Integer)
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_STATUS_APPRAISAL_REQUEST", connection)

                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Status_Id", Status_Id))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    Dim msg As String
                    Dim title As String
                    Dim style As MsgBoxStyle
                    Dim response1 As MsgBoxResult
                    myTrans.Rollback()
                    'msg = "การบันทึกผิดพลาด"   ' Define message.
                    msg = ex.Message
                    style = MsgBoxStyle.DefaultButton2 Or _
                       MsgBoxStyle.Critical Or MsgBoxStyle.YesNo
                    title = "ผลการบันทึก"   ' Define title.
                    ' Display message.
                    response1 = MsgBox(msg, style, title)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Function GET_APPRAISAL_REQUEST(ByVal Req_Id As Integer) As Generic.List(Of Appraisal_Request)
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_APPRAISAL_REQUEST", connection)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                connection.Open()
                Dim list As New Generic.List(Of Appraisal_Request)()
                Using reader As SqlDataReader = command.ExecuteReader()
                    Do While (reader.Read())
                        Dim temp As New Appraisal_Request(CInt(reader("Req_ID")), _
                                                CInt(reader("Hub_Id")), _
                                                CStr(reader("Cif")), _
                                                CInt(reader("Title")), _
                                                CStr(reader("Name")), _
                                                CStr(reader("LastName")), _
                                                CInt(reader("Req_Type")), _
                                                CInt(reader("Status_Id")), _
                                                CStr(reader("Appraisal_Id")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
            End Using
            connection.Close()
        End Using
    End Function
#End Region

#Region "Id 18 50 70"

    Public Shared Function GET_ID_18_50_70(ByVal COLL_TYPE As String) As Integer
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_ID_18_50_70", connection)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(New SqlParameter("@COLL_TYPE", COLL_TYPE))
                connection.Open()
                Dim list As New Integer
                Using reader As SqlDataReader = command.ExecuteReader()
                    Do While (reader.Read())
                        Dim temp As Integer = (reader("Id_No"))
                        list = (temp)
                    Loop
                End Using
                Return list

            End Using
            connection.Close()
        End Using
    End Function

    Public Shared Sub UPDATE_REVIEW_STATUS(ByVal APPS_ID As Integer)
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_REVIEW_STATUS", connection)

                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@APPS_ID", APPS_ID))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception

                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub UPDATE_ID_18()
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_ID_18", connection)

                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception

                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub UPDATE_ID_50()
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_ID_50", connection)

                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception

                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub UPDATE_ID_70()
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_ID_70", connection)

                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception

                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

#End Region

#Region "WAIT FOR APPROVE"

    Public Shared Sub AddWait_For_Approve(ByVal Seq_Id As Integer, _
     ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
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

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("ADD_WAIT_FOR_APPROVE", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Seq_Id", Seq_Id))
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@AID", AID))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@Approve_Id", Approve_Id))
                    command.Parameters.Add(New SqlParameter("@Cif", Cif))
                    command.Parameters.Add(New SqlParameter("@ChkColl", ChkColl))
                    command.Parameters.Add(New SqlParameter("@Appraisal_Id", Appraisal_Id))
                    command.Parameters.Add(New SqlParameter("@Chk_Approve", Chk_Approve))
                    command.Parameters.Add(New SqlParameter("@Save_Date", Save_Date))
                    command.Parameters.Add(New SqlParameter("@Approve_Date", DBNull.Value))
                    command.Parameters.Add(New SqlParameter("@Update_Date", DBNull.Value))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub UpdateWait_For_Approve(ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
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

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_WAIT_FOR_APPROVE", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@AID", AID))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@Approve_Id", Approve_Id))
                    command.Parameters.Add(New SqlParameter("@Cif", Cif))
                    command.Parameters.Add(New SqlParameter("@ChkColl", ChkColl))
                    command.Parameters.Add(New SqlParameter("@Appraisal_Id", Appraisal_Id))
                    command.Parameters.Add(New SqlParameter("@Chk_Approve", Chk_Approve))
                    command.Parameters.Add(New SqlParameter("@Save_Date", Save_Date))
                    command.Parameters.Add(New SqlParameter("@Approve_Date", Approve_Date))
                    command.Parameters.Add(New SqlParameter("@Update_Date", Update_Date))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub UPDATE_WAIT_FOR_APPROVE_COMMITTEE(ByVal Req_Id As Integer, _
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

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_WAIT_FOR_APPROVE_COMMITTEE", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Seq_Id", Seq_Id))
                    command.Parameters.Add(New SqlParameter("@AID", AID))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@Approve_Id", Approve_Id))
                    command.Parameters.Add(New SqlParameter("@Cif", Cif))
                    command.Parameters.Add(New SqlParameter("@ChkColl", ChkColl))
                    command.Parameters.Add(New SqlParameter("@Appraisal_Id", Appraisal_Id))
                    command.Parameters.Add(New SqlParameter("@Chk_Approve", Chk_Approve))
                    command.Parameters.Add(New SqlParameter("@Save_Date", Save_Date))
                    command.Parameters.Add(New SqlParameter("@Approve_Date", Approve_Date))
                    command.Parameters.Add(New SqlParameter("@Update_Date", Update_Date))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub DeleteWait_For_Approve(ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
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

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UpdateWait_For_Approve", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@AID", AID))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@Approve_Id", Approve_Id))
                    command.Parameters.Add(New SqlParameter("@Cif", Cif))
                    command.Parameters.Add(New SqlParameter("@ChkColl", ChkColl))
                    command.Parameters.Add(New SqlParameter("@Appraisal_Id", Appraisal_Id))
                    command.Parameters.Add(New SqlParameter("@Chk_Approve", Chk_Approve))
                    command.Parameters.Add(New SqlParameter("@Save_Date", Save_Date))
                    command.Parameters.Add(New SqlParameter("@Approve_Date", Approve_Date))
                    command.Parameters.Add(New SqlParameter("@Update_Date", Update_Date))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Function GET_WAIT_FOR_APPROVE(ByVal Approve_Id As String) As Generic.List(Of Wait_For_Approve)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_WAIT_FOR_APPROVE", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60

                'command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                'command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                'command.Parameters.Add(New SqlParameter("@AID", AID))
                'command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                command.Parameters.Add(New SqlParameter("@Approve_Id", Approve_Id))
                connection.Open()
                Dim list As New Generic.List(Of Wait_For_Approve)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Wait_For_Approve(CInt(reader("Req_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CInt(reader("Seq_Id")), _
                                                CStr(reader("AID")), _
                                                CInt(reader("Temp_AID")), _
                                                CStr(reader("Approve_Id")), _
                                                CStr(reader("Cif")), _
                                                CStr(reader("ChkColl")), _
                                                CStr(reader("Appraisal_Id")), _
                                                CInt(reader("Chk_Approve")), _
                                                CDate(reader("Save_Date")), _
                                                CDate(reader("Approve_Date")), _
                                                CDate(reader("Update_Date")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list

            End Using
            connection.Close()
        End Using

    End Function

    Public Shared Function GET_WAIT_FOR_APPROVE_BY_REQ_ID(ByVal Req_Id As String, ByVal Hub_Id As String, ByVal Approve_Id1 As String, ByVal Approve_Id2 As String, ByVal Approve_Id3 As String) As Integer

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_WAIT_FOR_APPROVE_BY_REQ_ID", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60

                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                command.Parameters.Add(New SqlParameter("@Approve_Id1", Approve_Id1))
                command.Parameters.Add(New SqlParameter("@Approve_Id2", Approve_Id2))
                command.Parameters.Add(New SqlParameter("@Approve_Id3", Approve_Id3))
                'command.Parameters.Add(New SqlParameter("@AID", AID))
                'command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                connection.Open()
                Dim list As New Integer
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As Integer = (CInt(reader("Cnt")))
                        list = (temp)
                    Loop
                End Using
                Return list

            End Using
            connection.Close()
        End Using

    End Function
#End Region

#Region "REQUEST ID_PICTURE PATH"


    Public Shared Sub AddAppraisal_Request_PicturePath(ByVal Req_ID As Integer, _
    ByVal Hub_ID As Integer, _
    ByVal Picture_Path As String, _
    ByVal Done As Integer)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("AddAppraisal_Request_PicturePath", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Req_ID", Req_ID))
                    command.Parameters.Add(New SqlParameter("@Hub_ID", Hub_ID))
                    command.Parameters.Add(New SqlParameter("@Picture_Path", Picture_Path))
                    command.Parameters.Add(New SqlParameter("@Done", Done))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub DeleteAppraisal_Request_PicturePath(ByVal Req_ID As Integer, _
    ByVal Hub_ID As Integer)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("DeleteAppraisal_Request_PicturePath", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Req_ID", Req_ID))
                    command.Parameters.Add(New SqlParameter("@Hub_ID", Hub_ID))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    Dim msg As String
                    Dim title As String
                    Dim style As MsgBoxStyle
                    Dim response1 As MsgBoxResult
                    'msg = "การบันทึกผิดพลาด"   ' Define message.
                    msg = ex.Message
                    style = MsgBoxStyle.DefaultButton2 Or _
                       MsgBoxStyle.Critical Or MsgBoxStyle.YesNo
                    title = "ผลการบันทึก"   ' Define title.
                    ' Display message.
                    response1 = MsgBox(msg, style, title)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub AddAppraisal_Price2_PicturePath(ByVal Req_ID As Integer, _
    ByVal Hub_ID As Integer, _
    ByVal Temp_AID As Integer, _
    ByVal Picture_Path As String, _
    ByVal Done As Integer, _
    ByVal User_ID As String)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("AddAppraisal_Price2_PicturePath", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Req_ID", Req_ID))
                    command.Parameters.Add(New SqlParameter("@Hub_ID", Hub_ID))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@Picture_Path", Picture_Path))
                    command.Parameters.Add(New SqlParameter("@Done", Done))
                    command.Parameters.Add(New SqlParameter("@Create_User", User_ID))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub AddAppraisal_Price3_PicturePath(ByVal Req_ID As Integer, _
     ByVal Hub_ID As Integer, _
     ByVal AID As String, _
     ByVal Temp_AID As String, _
     ByVal Picture_Path As String, _
     ByVal CID As String, _
     ByVal done As Integer, _
     ByVal Create_User As String)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("AddAppraisal_Price3_PicturePath", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Req_ID", Req_ID))
                    command.Parameters.Add(New SqlParameter("@Hub_ID", Hub_ID))
                    command.Parameters.Add(New SqlParameter("@AID", AID))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@Picture_Path", Picture_Path))
                    command.Parameters.Add(New SqlParameter("@CID", CID))
                    command.Parameters.Add(New SqlParameter("@done", done))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    MsgBox(ex.Message)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub UpdateAppraisal_Price3_PicturePath(ByVal Req_ID As Integer, _
     ByVal Hub_ID As Integer, _
     ByVal AID As String, _
     ByVal Picture_Path As String, _
     ByVal Temp_AID As Integer, _
     ByVal CID As String, _
     ByVal done As Integer, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("Update_Appraisal_Price3_PicturePath", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Req_ID", Req_ID))
                    command.Parameters.Add(New SqlParameter("@Hub_ID", Hub_ID))
                    command.Parameters.Add(New SqlParameter("@AID", AID))
                    command.Parameters.Add(New SqlParameter("@Picture_Path", Picture_Path))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@CID", CID))
                    command.Parameters.Add(New SqlParameter("@done", done))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub DeleteAppraisal_Price3_PicturePath(ByVal Req_ID As Integer, _
     ByVal Hub_ID As Integer, _
     ByVal AID As String, _
     ByVal Picture_Path As String, _
     ByVal Temp_AID As Integer, _
     ByVal CID As String, _
     ByVal done As Integer, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UpdateAppraisal_Price3_PicturePath", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Req_ID", Req_ID))
                    command.Parameters.Add(New SqlParameter("@Hub_ID", Hub_ID))
                    command.Parameters.Add(New SqlParameter("@AID", AID))
                    command.Parameters.Add(New SqlParameter("@Picture_Path", Picture_Path))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@CID", CID))
                    command.Parameters.Add(New SqlParameter("@done", done))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub


#End Region

#Region "Total Size"
    Public Shared Function Totolsize(ByVal Qid As Integer, ByVal TempAID As Integer, ByVal CollType As Integer) As DataSet

        'For Print Data Out
        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        MyConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)

        MyDataAdapter = New SqlDataAdapter("GET_TOTAL_COLLTYPE", MyConnection)
        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Q_ID", SqlDbType.Int))
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@PreAID", SqlDbType.Int))
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@CollType", SqlDbType.Int))
        MyDataAdapter.SelectCommand.Parameters("@Q_ID").Value = Qid
        MyDataAdapter.SelectCommand.Parameters("@PreAID").Value = TempAID
        MyDataAdapter.SelectCommand.Parameters("@CollType").Value = CollType
        DS = New DataSet() 'Create a new DataSet to hold the records.
        MyDataAdapter.Fill(DS, "GET_TOTAL_COLLTYPE") 'Fill the DataSet with the rows returned.
        Return DS
    End Function
#End Region

#Region "SYSTEM USER"

    Public Shared Function GET_SYSTEM_USER(ByVal sUser As String, ByVal sPwd As String) As Generic.List(Of SystemUser)
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_SYSTEM_USER", connection)
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@UserID", sUser))
                    command.Parameters.Add(New SqlParameter("@Pwd", sPwd))
                    connection.Open()
                    Dim list As New Generic.List(Of SystemUser)()
                    Using reader As SqlDataReader = command.ExecuteReader()
                        Do While (reader.Read())
                            Dim temp As New SystemUser(CStr(reader("UserId")), _
                                                    CStr(reader("Pwd")), _
                                                    CStr(reader("Emp_Id")), _
                                                    CInt(reader("Hub_Id")), _
                                                    CInt(reader("SGroup_Id")), _
                                                    CStr(reader("Create_User")), _
                                                    CDate(reader("Create_Date")))
                            list.Add(temp)
                        Loop
                        reader.Close()
                    End Using

                    Return list

                Catch ex As Exception
                    Throw New Exception(ex.Message & " : " & ex.StackTrace)
                Finally
                    connection.Close()
                End Try
            End Using
            Return Nothing
        End Using
    End Function

    Public Shared Sub AddTb_SystemUser(ByVal User_Id As String, _
     ByVal Pwd As String, _
     ByVal Emp_Id As Integer, _
     ByVal Hub_Id As Integer, _
     ByVal Create_User As String, _
     ByVal Create_Date As Date)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("Add_SystemUser", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@UserID", User_Id))
                    command.Parameters.Add(New SqlParameter("@Pwd", Pwd))
                    command.Parameters.Add(New SqlParameter("@Emp_Id", Emp_Id))
                    command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                    command.Parameters.Add(New SqlParameter("@Create_User", Create_User))
                    command.Parameters.Add(New SqlParameter("@Create_Date", Create_Date))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub UPDATE_PASSWORD(ByVal Emp_Id As String, _
     ByVal Pwd As String)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_PASSWORD", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Emp_Id", Emp_Id))
                    command.Parameters.Add(New SqlParameter("@Pwd", Pwd))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub UPDATE_AUTHORIZE_SYSTEM_USER(ByVal Emp_Id As String, _
     ByVal SGroup_Id As Integer)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("UPDATE_AUTHORIZE_SYSTEM_USER", connection)
                connection.Open()
                command.Connection = connection
                Dim myTrans As SqlTransaction
                myTrans = connection.BeginTransaction()
                command.Transaction = myTrans
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@Emp_Id", Emp_Id))
                    command.Parameters.Add(New SqlParameter("@SGroup_Id", SGroup_Id))
                    command.ExecuteNonQuery()
                    myTrans.Commit()
                Catch ex As Exception
                    myTrans.Rollback()
                    'MsgBox(ex.Message)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub
#End Region

#Region "PROVINCE"
    Public Shared Function GET_PROVINCE_INFO(ByVal PROV_CODE As Integer) As Generic.List(Of Cls_PROVINCE)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PROVINCE_INFO", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60

                command.Parameters.Add(New SqlParameter("@PROV_CODE", PROV_CODE))
                connection.Open()
                Dim list As New Generic.List(Of Cls_PROVINCE)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Cls_PROVINCE(CInt(reader("PROV_CODE")), _
                                                CStr(reader("PROV_NAME")), _
                                                CStr(reader("PROV_NAME_E")), _
                                                CStr(reader("ZONE_CODE")), _
                                                CStr(reader("AREA_CODE")))
                        list.Add(temp)
                    Loop
                End Using
                Return list

            End Using
            connection.Close()
        End Using

    End Function
#End Region

#Region "Other Info"
    Public Shared Function GET_SITE_INFO(ByVal SITE_ID As Integer) As Generic.List(Of Cls_SITE)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_SITE_INFO", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60

                command.Parameters.Add(New SqlParameter("@Site_ID", SITE_ID))
                connection.Open()
                Dim list As New Generic.List(Of Cls_SITE)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Cls_SITE(CInt(reader("Site_ID")), _
                                                CStr(reader("Site_Name")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
            End Using
            connection.Close()
        End Using

    End Function

    Public Shared Function GET_AREA_COLOUR_INFO(ByVal AreaColour_No As Integer) As Generic.List(Of Cls_Area_Colour)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_AREA_COLOUR_INFO", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60

                command.Parameters.Add(New SqlParameter("@AreaColour_No", AreaColour_No))
                connection.Open()
                Dim list As New Generic.List(Of Cls_Area_Colour)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Cls_Area_Colour(CInt(reader("AreaColour_No")), _
                                                CStr(reader("AreaColour_Name")))
                        list.Add(temp)
                    Loop
                End Using
                Return list

            End Using
            connection.Close()
        End Using

    End Function

    Public Shared Function GET_TENDENCY_INFO(ByVal TENDENCY_ID As Integer) As Generic.List(Of Cls_TENDENCY)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_TENDENCY_INFO", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60

                command.Parameters.Add(New SqlParameter("@TENDENCY_ID", TENDENCY_ID))
                connection.Open()
                Dim list As New Generic.List(Of Cls_TENDENCY)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Cls_TENDENCY(CInt(reader("TENDENCY_ID")), _
                                                CStr(reader("TENDENCY_NAME")))
                        list.Add(temp)
                    Loop
                End Using
                Return list

            End Using
            connection.Close()
        End Using

    End Function

    Public Shared Function GET_BINIFIT_INFO(ByVal BINIFIT_ID As Integer) As Generic.List(Of Cls_BINIFIT)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_BINIFIT_INFO", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60

                command.Parameters.Add(New SqlParameter("@BINIFIT_ID", BINIFIT_ID))
                connection.Open()
                Dim list As New Generic.List(Of Cls_BINIFIT)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Cls_BINIFIT(CInt(reader("BINIFIT_ID")), _
                                                CStr(reader("BINIFIT_NAME")))
                        list.Add(temp)
                    Loop
                End Using
                Return list

            End Using
            connection.Close()
        End Using

    End Function

    Public Shared Function GET_PUBLIC_UTILITY_INFO(ByVal PUBLIC_UTILITY_ID As Integer) As Generic.List(Of Cls_Public_Utility)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PUBLIC_UTILITY_INFO", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60

                command.Parameters.Add(New SqlParameter("@PUBLIC_UTILITY_ID", PUBLIC_UTILITY_ID))
                connection.Open()
                Dim list As New Generic.List(Of Cls_Public_Utility)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Cls_Public_Utility(CInt(reader("PUBLIC_UTILITY_ID")), _
                                                CStr(reader("PUBLIC_UTILITY_NAME")))
                        list.Add(temp)
                    Loop
                End Using
                Return list

            End Using
            connection.Close()
        End Using

    End Function

    Public Shared Function GET_LANDSTATE_INFO(ByVal LAND_STATE_ID As Integer) As Generic.List(Of Cls_LandState)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_LANDSTATE_INFO", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60

                command.Parameters.Add(New SqlParameter("@LAND_STATE_ID", LAND_STATE_ID))
                connection.Open()
                Dim list As New Generic.List(Of Cls_LandState)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Cls_LandState(CInt(reader("LAND_STATE_ID")), _
                                                CStr(reader("LAND_STATE_NAME")))
                        list.Add(temp)
                    Loop
                End Using
                Return list

            End Using
            connection.Close()
        End Using

    End Function

    Public Shared Function GET_ROAD_DETAIL_INFO(ByVal LAND_STATE_ID As Integer) As Generic.List(Of Cls_Road_Detail)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_ROAD_DETAIL_INFO", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60

                command.Parameters.Add(New SqlParameter("@ROAD_DETAIL_ID", LAND_STATE_ID))
                connection.Open()
                Dim list As New Generic.List(Of Cls_Road_Detail)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Cls_Road_Detail(CInt(reader("ROAD_DETAIL_ID")), _
                                                CStr(reader("ROAD_DETAIL_NAME")))
                        list.Add(temp)
                    Loop
                End Using
                Return list

            End Using
            connection.Close()
        End Using

    End Function

    Public Shared Function GET_BUYSALE_STATE_INFO(ByVal LAND_STATE_ID As Integer) As Generic.List(Of Cls_Buy_Sale_State)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_BUYSALE_STATE_INFO", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60

                command.Parameters.Add(New SqlParameter("@BUYSALE_STATE_ID", LAND_STATE_ID))
                connection.Open()
                Dim list As New Generic.List(Of Cls_Buy_Sale_State)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Cls_Buy_Sale_State(CInt(reader("BUYSALE_STATE_ID")), _
                                                CStr(reader("BUYSALE_STATE_NAME")))
                        list.Add(temp)
                    Loop
                End Using
                Return list

            End Using
            connection.Close()
        End Using

    End Function

    Public Shared Function GET_ROADFRONTOFF_INFO(ByVal Road_Frontoff_ID As Integer) As Generic.List(Of Cls_RoadFrontOff)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_ROAD_FRONTOFF_INFO", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60

                command.Parameters.Add(New SqlParameter("@Road_Frontoff_ID", Road_Frontoff_ID))
                connection.Open()
                Dim list As New Generic.List(Of Cls_RoadFrontOff)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Cls_RoadFrontOff(CInt(reader("Road_Frontoff_ID")), _
                                                CStr(reader("Road_Frontoff_Name")))
                        list.Add(temp)
                    Loop
                End Using
                Return list

            End Using
            connection.Close()
        End Using

    End Function

    Public Shared Function GET_SUBCOLLTYPE(ByVal SUBCOLLTYPE_ID As Integer) As Generic.List(Of Cls_SubCollType)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_SUBCOLLTYPE_INFO", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60

                command.Parameters.Add(New SqlParameter("@SUBCOLLTYPE_ID", SUBCOLLTYPE_ID))
                connection.Open()
                Dim list As New Generic.List(Of Cls_SubCollType)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Cls_SubCollType(CInt(reader("CollType_ID")), _
                                                CInt(reader("SubCollType_ID")), _
                                                CInt(reader("MysubColl_ID")), _
                                                CStr(reader("SubCollType_Name")))
                        list.Add(temp)
                    Loop
                End Using
                Return list

            End Using
            connection.Close()
        End Using

    End Function

    Public Shared Function GET_Build_Construct(ByVal Build_Construct_ID As Integer) As Generic.List(Of Cls_Build_Construct)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_Build_Construct_INFO", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60

                command.Parameters.Add(New SqlParameter("@Build_Construct_ID", Build_Construct_ID))
                connection.Open()
                Dim list As New Generic.List(Of Cls_Build_Construct)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Cls_Build_Construct(CInt(reader("Build_Construct_ID")), _
                                                       CStr(reader("Build_Construct_Name")))
                        list.Add(temp)
                    Loop
                End Using
                Return list

            End Using
            connection.Close()
        End Using

    End Function

    Public Shared Function GET_Roof(ByVal Roof_ID As Integer) As Generic.List(Of Cls_Roof)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_Roof_INFO", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60

                command.Parameters.Add(New SqlParameter("@Roof_ID", Roof_ID))
                connection.Open()
                Dim list As New Generic.List(Of Cls_Roof)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Cls_Roof(CInt(reader("Roof_ID")), _
                                                       CStr(reader("Roof_Name")))
                        list.Add(temp)
                    Loop
                End Using
                Return list

            End Using
            connection.Close()
        End Using

    End Function

    Public Shared Function GET_Build_State(ByVal Build_State_ID As Integer) As Generic.List(Of Cls_Build_State)

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_Build_State_INFO", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60

                command.Parameters.Add(New SqlParameter("@Build_State_ID", Build_State_ID))
                connection.Open()
                Dim list As New Generic.List(Of Cls_Build_State)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Cls_Build_State(CInt(reader("Build_State_ID")), _
                                                       CStr(reader("Build_State_Name")))
                        list.Add(temp)
                    Loop
                End Using
                Return list

            End Using
            connection.Close()
        End Using

    End Function

    Public Shared Function GET_Hub_Info(ByVal HUB_ID As Integer) As Generic.List(Of Cls_Hub)
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_HUB_INFO", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60

                command.Parameters.Add(New SqlParameter("@HUB_ID", HUB_ID))
                connection.Open()
                Dim list As New Generic.List(Of Cls_Hub)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Cls_Hub(CInt(reader("HUB_ID")), _
                                                CStr(reader("HUB_NAME")), _
                                                CStr(reader("HUB_NAME_E")))
                        list.Add(temp)
                    Loop
                End Using
                Return list

            End Using
            connection.Close()
        End Using

    End Function

    Public Shared Function GET_SubUnit_Info(ByVal SubUnit_Id As Integer) As Generic.List(Of Cls_SubUnit)
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_SUBUNIT_INFO", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60

                command.Parameters.Add(New SqlParameter("@SubUnit_Id", SubUnit_Id))
                connection.Open()
                Dim list As New Generic.List(Of Cls_SubUnit)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Cls_SubUnit(CInt(reader("SubUnit_Id")), _
                                                CStr(reader("SubUnit_Name")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using
    End Function

    Public Shared Function GET_FLOOR_INFO(ByVal Floor_Id As Integer) As Generic.List(Of Cls_Floor)
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_FLOOR_INFO", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60

                command.Parameters.Add(New SqlParameter("@Floor_Id", Floor_Id))
                connection.Open()
                Dim list As New Generic.List(Of Cls_Floor)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Cls_Floor(CInt(reader("Floor_Id")), _
                                                CStr(reader("Floor_Name")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
            End Using
            connection.Close()
        End Using
    End Function

    Public Shared Function GET_INTERIOR_INFO(ByVal InteriorState_Id As Integer) As Generic.List(Of Cls_Interior)
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_INTERIOR_INFO", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60

                command.Parameters.Add(New SqlParameter("@InteriorState_Id", InteriorState_Id))
                connection.Open()
                Dim list As New Generic.List(Of Cls_Interior)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Cls_Interior(CInt(reader("InteriorState_Id")), _
                                                CStr(reader("InteriorState_Name")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
                connection.Close()
            End Using
        End Using
    End Function

    Public Shared Function GET_APPRAISAL_PRICE2(ByVal Req_Id As Integer, ByVal Hub_Id As Integer) As DataSet
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_PRICE_BEFORE_APPROVE", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60
                command.Parameters.Add(New SqlParameter("@Req_Id", Req_Id))
                command.Parameters.Add(New SqlParameter("@Hub_Id", Hub_Id))
                connection.Open()
                Dim list As New SqlDataAdapter(command)
                'Using reader As SqlDataAdapter = command.ExecuteNonQuery()
                Dim ds As New DataSet
                list.Fill(ds)
                Return ds
            End Using
            connection.Close()
        End Using

    End Function

    Public Shared Function GET_TITLE_INFO(ByVal TITLE_CODE As Integer) As Generic.List(Of Cls_Title)
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_TITLE", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60

                command.Parameters.Add(New SqlParameter("@TITLE_CODE", TITLE_CODE))
                connection.Open()
                Dim list As New Generic.List(Of Cls_Title)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Cls_Title(CInt(reader("TITLE_CODE")), _
                                                  CStr(reader("TITLE_NAME")), _
                                                CStr(reader("TITLE_NAME_E")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
            End Using
            connection.Close()
        End Using
    End Function

    Public Shared Function GET_STANDARD_INFO(ByVal STANDARD_ID As Integer) As Generic.List(Of Cls_Standard)
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_STANDARD_INFO", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60

                command.Parameters.Add(New SqlParameter("@Standard_Id", STANDARD_ID))
                connection.Open()
                Dim list As New Generic.List(Of Cls_Standard)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Cls_Standard(CInt(reader("STANDARD_ID")), _
                                                  CStr(reader("STANDARD_NAME")), _
                                                CStr(reader("STANDARD_STATUS")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
            End Using
            connection.Close()
        End Using
    End Function

    Public Shared Function GET_STANDARD_INFO_BY_ID(ByVal STANDARD_ID As Integer) As Generic.List(Of Cls_Standard)
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)
            Using command As New SqlCommand("GET_STANDARD_INFO_BY_ID", connection)
                command.CommandType = CommandType.StoredProcedure
                command.CommandTimeout = 60

                command.Parameters.Add(New SqlParameter("@Standard_Id", STANDARD_ID))
                connection.Open()
                Dim list As New Generic.List(Of Cls_Standard)()
                Using reader As SqlDataReader = command.ExecuteReader()

                    Do While (reader.Read())
                        Dim temp As New Cls_Standard(CInt(reader("STANDARD_ID")), _
                                                  CStr(reader("STANDARD_NAME")), _
                                                CStr(reader("STANDARD_STATUS")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
            End Using
            connection.Close()
        End Using
    End Function
#End Region



End Class
