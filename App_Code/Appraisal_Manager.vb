Imports Microsoft.VisualBasic
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
Imports System.Web.Services


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

    Public Shared Sub AddPRICE2_Master(ByVal Temp_AID As Integer, _
     ByVal Req_Id As Integer, _
     ByVal Hub_Id As Integer, _
     ByVal Id As Integer, _
     ByVal Cif As Integer, _
     ByVal Appraisal_Id As Integer, _
     ByVal CollType As Integer, _
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

#End Region

#Region "PRICE2-50"

    Public Shared Sub AddPRICE2_50(ByVal ID As Integer, _
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
     ByVal Wah As Integer, _
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
                    command.Parameters.Add(New SqlParameter("@Id", ID))
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

    Public Shared Sub UpdatePRICE2_50(ByVal ID As Integer, _
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
     ByVal Wah As Integer, _
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
                                                CInt(reader("Temp_AID")), _
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

#End Region

#Region "PRICE2-70"

    Public Shared Sub AddPRICE2_70(ByVal ID As Integer, _
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
    ByVal AID As Integer, _
    ByVal Temp_AID As Integer, _
    ByVal Inform_To As String, _
    ByVal Cif As Integer, _
    ByVal Lat As Double, _
    ByVal Lng As Double, _
    ByVal Pricewah As Double, _
    ByVal TotalPrice As Double, _
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
                    command.Parameters.Add(New SqlParameter("@Pricewah", Pricewah))
                    command.Parameters.Add(New SqlParameter("@TotalPrice", TotalPrice))
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
                                                CInt(reader("AID")), _
                                                CInt(reader("Temp_AID")), _
                                                CStr(reader("Inform_To")), _
                                                CInt(reader("Cif")), _
                                                CDec(reader("Lat")), _
                                                CDec(reader("Lng")), _
                                                CDec(reader("Pricewah")), _
                                                CDec(reader("TotalPrice")), _
                                                CStr(reader("Approved1")), _
                                                CStr(reader("Approved2")), _
                                                CStr(reader("Approved3")), _
                                                CInt(reader("Approved")), _
                                                CInt(reader("Env_Effect")), _
                                                CStr(reader("Env_Effect_Detail")), _
                                                CStr(reader("Appraisal_Detail")), _
                                                CDec(reader("Appraisal_Type_ID")), _
                                                CInt(reader("Comment_ID")), _
                                                CDec(reader("Warning_ID")), _
                                                CStr(reader("Warning_Detail")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
            End Using
        End Using

    End Function

    Public Shared Sub AddPRICE3_50(ByVal Id As Integer, _
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
     ByVal Wah As Integer, _
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

    Public Shared Sub UpdatePRICE3_50(ByVal Req_Id As Integer, _
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
     ByVal Wah As Integer, _
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
                    command.Parameters.Add(New SqlParameter("@Rawang", Rawang))
                    command.Parameters.Add(New SqlParameter("@LandNumber", LandNumber))
                    command.Parameters.Add(New SqlParameter("@Surway", Surway))
                    command.Parameters.Add(New SqlParameter("@DocNo", DocNo))
                    command.Parameters.Add(New SqlParameter("@PageNo", PageNo))
                    command.Parameters.Add(New SqlParameter("@Ownership", Ownership))
                    command.Parameters.Add(New SqlParameter("@Obligation", Obligation))
                    command.Parameters.Add(New SqlParameter("@Obligation", Obligation))
                    command.Parameters.Add(New SqlParameter("@Land_Closeto_RoadWidth", Land_Closeto_RoadWidth))
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
            End Using
        End Using

    End Function

    Public Shared Sub AddPRICE3_70(ByVal Id As Integer, _
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
                    'MsgBox(ex.Message)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

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
            End Using
        End Using

    End Function

    Public Shared Sub UpdatePRICE3_70(ByVal Req_Id As Integer, _
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
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
            End Using
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
            End Using
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
        End Using

    End Function

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
     ByVal Status_ID As Integer, _
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
                    command.Parameters.Add(New SqlParameter("@Status_ID", Status_ID))
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
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(New SqlParameter("@UserID", sUser))
                command.Parameters.Add(New SqlParameter("@Pwd", sPwd))
                connection.Open()
                Dim list As New Generic.List(Of SystemUser)()
                Using reader As SqlDataReader = command.ExecuteReader()
                    Do While (reader.Read())
                        Dim temp As New SystemUser(CStr(reader("UserId")), _
                                                CStr(reader("Pwd")), _
                                                CInt(reader("Emp_Id")), _
                                                CInt(reader("Hub_Id")), _
                                                CInt(reader("SGroup_Id")), _
                                                CStr(reader("Create_User")), _
                                                CDate(reader("Create_Date")))
                        list.Add(temp)
                    Loop
                End Using

                Return list
            End Using
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
        End Using

    End Function
#End Region
End Class
