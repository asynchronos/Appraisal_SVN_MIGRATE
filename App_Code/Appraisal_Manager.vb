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


#Region "PRICE2-50"
    Public Shared Sub AddPRICE2_50(ByVal Q_ID As Integer, _
    ByVal Cif As Integer, _
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
                    command.Parameters.Add(New SqlParameter("@Q_ID", Q_ID))
                    command.Parameters.Add(New SqlParameter("@Cif", Cif))
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
                    command.Parameters.Add(New SqlParameter("@PriceWah", PriceWah))
                    command.Parameters.Add(New SqlParameter("@PriceTotal1", PriceTotal1))
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

#Region "PRICE2-70"
    Public Shared Sub AddPRICE2_70(ByVal Q_ID As Integer, _
     ByVal Cif As Integer, _
     ByVal Temp_AID As Integer, _
     ByVal MysubColl_ID As Integer, _
     ByVal Build_No As String, _
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
     ByVal Pic_Path As String, _
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
                    command.Parameters.Add(New SqlParameter("@Q_ID", Q_ID))
                    command.Parameters.Add(New SqlParameter("@Cif", Cif))
                    command.Parameters.Add(New SqlParameter("@Temp_AID", Temp_AID))
                    command.Parameters.Add(New SqlParameter("@MysubColl_ID", MysubColl_ID))
                    command.Parameters.Add(New SqlParameter("@Build_No", Build_No))
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
                    command.Parameters.Add(New SqlParameter("@Pic_Path", Pic_Path))
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

End Class
