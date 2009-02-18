Option Explicit On
Option Strict On

Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Collections.Generic
Imports Appraisal_Manager

Public Class GmapDAL_NEW
    Private Shared className As String = "GmapDAL_NEW"

    'Public Function getGmapByCOLL_ID(ByVal objGmap As Gmap) As Gmap

    '    'declare connection
    '    Dim conn As SqlConnection = Nothing
    '    'declare result
    '    Dim result As New Gmap()

    '    Try
    '        conn = ConnectionUtil.getSqlConnectionFromWebConfig()
    '        Dim sql As String = "SELECT " _
    '         & "COLL_ID, Lat, Lng, Name, " _
    '         & "Detail, Price1, Price2, Price3, " _
    '         & "Pic1, Pic2 " _
    '         & "FROM Gmap " _
    '         & "WHERE COLL_ID=@COLL_ID " _
    '         & "ORDER BY COLL_ID"

    '        Dim sqlCmd As New SqlCommand(sql, conn)
    '        sqlCmd.Prepare()

    '        sqlCmd.Parameters.AddWithValue("@COLL_ID", objGmap.COLL_ID)

    '        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()

    '        While reader.Read()
    '            result = bindingGmap(reader)
    '        End While

    '        reader.close()
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message & " : " & ex.StackTrace)
    '    Finally
    '        If (conn.State = ConnectionState.Open) Then
    '            conn.Close()
    '        End If
    '        conn = Nothing
    '    End Try

    '    Return result

    'End Function

    Public Function getGmapBy_AID(ByVal objPrice3Master As Price3_Master) As Price3_Master

        'declare connection
        Dim conn As SqlConnection = Nothing
        'declare result
        Dim result As New Price3_Master()

        Try
            conn = ConnectionUtil.getSqlConnectionFromWebConfig()
            Dim sql As String = "SELECT " _
             & "COLL_ID, Lat, Lng, Name, " _
             & "Detail, Price1, Price2, Price3, " _
             & "Pic1, Pic2 " _
             & "FROM Price3_Master " _
             & "WHERE COLL_ID=@COLL_ID " _
             & "ORDER BY COLL_ID"

            Dim sqlCmd As New SqlCommand(sql, conn)
            sqlCmd.Prepare()

            sqlCmd.Parameters.AddWithValue("@AID", objPrice3Master.AID)

            Dim reader As SqlDataReader = sqlCmd.ExecuteReader()

            While reader.Read()
                result = binding_Gmap(reader)
            End While

            reader.Close()
        Catch ex As Exception
            Throw New Exception(ex.Message & " : " & ex.StackTrace)
        Finally
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn = Nothing
        End Try

        Return result

    End Function

    'Public Function getGmapByCOLL_ID(ByVal COLL_ID As String) As Gmap

    '    'declare connection
    '    Dim conn As SqlConnection = Nothing
    '    'declare result
    '    Dim result As New Gmap()

    '    Try
    '        conn = ConnectionUtil.getSqlConnectionFromWebConfig()
    '        Dim sql As String = "SELECT " _
    '         & "COLL_ID, Lat, Lng, Name, " _
    '         & "Detail, Price1, Price2, Price3, " _
    '         & "Pic1, Pic2 " _
    '         & "FROM Gmap " _
    '         & "WHERE COLL_ID=@COLL_ID " _
    '         & "ORDER BY COLL_ID"

    '        Dim sqlCmd As New SqlCommand(sql, conn)
    '        sqlCmd.Prepare()

    '        sqlCmd.Parameters.AddWithValue("@COLL_ID", COLL_ID)

    '        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()

    '        While reader.Read()
    '            result = bindingGmap(reader)
    '        End While

    '        reader.close()
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message & " : " & ex.StackTrace)
    '    Finally
    '        If (conn.State = ConnectionState.Open) Then
    '            conn.Close()
    '        End If
    '        conn = Nothing
    '    End Try

    '    Return result

    'End Function

    Public Function getGmapBy_AID(ByVal AID As String) As Price3_Master

        'declare connection
        Dim conn As SqlConnection = Nothing
        'declare result
        Dim result As New Price3_Master()

        Try
            conn = ConnectionUtil.getSqlConnectionFromWebConfig()
            Dim sql As String = "SELECT " _
                & " Req_Id, " _
                & " AID, " _
                & " Temp_AID, " _
                & " Inform_To, " _
                & " Cif, " _
                & " CifName, " _
                & " Lat, " _
                & " Cif, " _
                & " CifName, " _
                & " Lat, " _
                & " Lng, " _
                & " Pricewah, " _
                & " TotalPrice, " _
                & " Create_User, " _
                & " Create_Date " _
                & "ORDER BY Req_Id" _
             & "FROM Price3_Master " _
             & "WHERE AID=@AID " _
             & "ORDER BY AID"

            Dim sqlCmd As New SqlCommand(sql, conn)
            sqlCmd.Prepare()

            sqlCmd.Parameters.AddWithValue("@AID", AID)

            Dim reader As SqlDataReader = sqlCmd.ExecuteReader()

            While reader.Read()
                result = binding_Gmap(reader)
            End While

            reader.Close()
        Catch ex As Exception
            Throw New Exception(ex.Message & " : " & ex.StackTrace)
        Finally
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn = Nothing
        End Try

        Return result

    End Function

    Public Function getGmapBy_Req_ID(ByVal Req_Id As Integer, ByVal Hub_Id As Integer) As List(Of Price1_Master)

        'declare connection
        Dim conn As SqlConnection = Nothing
        'declare result
        Dim result As New List(Of Price1_Master)

        Try
            conn = ConnectionUtil.getSqlConnectionFromWebConfig()
            Dim sql As String = "SELECT " _
                & " Req_Id, " _
                & " Hub_Id, " _
                & " Cif, " _
                & " isnull(CifName,' ') as CifName, " _
                & " Lat, " _
                & " Lng, " _
                & " isnull(Pricewah,0) as Pricewah, " _
                & " isnull(Price,0) as Price, " _
                & " Create_User, " _
                & " isnull(Create_Date,getdate()) as Create_Date " _
             & "FROM Price1_Master " _
             & "WHERE Req_Id=@Req_Id AND Hub_Id =@Hub_Id " _
             & "ORDER BY Req_Id"

            '        Dim sql As String = "SELECT " _
            '& " Req_Id, " _
            '& " AID, " _
            '& " Temp_AID, " _
            '& " isnull(Inform_To,'') as Inform_To, " _
            '& " isnull(Cif,0) as Cif, " _
            '& " Lat, " _
            '& " Lng, " _
            '& " isnull(Pricewah,0) as Pricewah, " _
            '& " isnull(TotalPrice,0) as TotalPrice, " _
            '& " isnull(Approved1,0) as Approved1, " _
            '& " isnull(Approved2,0) as Approved2, " _
            '& " isnull(Approved3,0) as Approved3, " _
            '& " isnull(Approved,0) as Approved, " _
            '& " isnull(Env_Effect,0) As Env_Effect, " _
            '& " isnull(Env_Effect_Detail,'') As Env_Effect_Detail, " _
            '& " isnull(Appraisal_Detail,'') As Appraisal_Detail, " _
            '& " isnull(Appraisal_Type_Id,0) As Appraisal_Type_Id, " _
            '& " isnull(Comment_ID,0) As Comment_ID, " _
            '& " isnull(Warning_ID,0) As Warning_ID, " _
            '& " isnull(Warning_Detail,'') As Warning_Detail, " _
            '& " Create_User, " _
            '& " isnull(Create_Date,getdate()) as Create_Date " _
            '& " FROM Price3_Master " _
            '& "ORDER BY Req_Id"

            Dim sqlCmd As New SqlCommand(sql, conn)
            sqlCmd.Prepare()

            sqlCmd.Parameters.AddWithValue("@Req_Id", Req_Id)
            sqlCmd.Parameters.AddWithValue("@Hub_Id", Hub_Id)

            Dim reader As SqlDataReader = sqlCmd.ExecuteReader()

            While reader.Read()
                result.Add(binding_Gmap_Price1(reader))
            End While

            reader.Close()
        Catch ex As Exception
            Throw New Exception(ex.Message & " : " & ex.StackTrace)
        Finally
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn = Nothing
        End Try

        Return result

    End Function

    'Public Function getAllGmap() As List(Of Gmap)

    '    'declare connection
    '    Dim conn As SqlConnection = Nothing
    '    'declare result
    '    Dim result As New List(Of Gmap)

    '    Try
    '        conn = ConnectionUtil.getSqlConnectionFromWebConfig()
    '        Dim sql As String = "SELECT " _
    '         & "COLL_ID, Lat, Lng, Name, " _
    '         & "Detail, Price1, Price2, Price3, " _
    '         & "Pic1, Pic2 " _
    '         & "FROM Gmap " _
    '         & "ORDER BY COLL_ID"

    '        Dim sqlCmd As New SqlCommand(sql, conn)
    '        sqlCmd.Prepare()

    '        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()

    '        While reader.Read()
    '            result.Add(bindingGmap(reader))
    '        End While

    '        reader.close()
    '        conn.Close()
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message & " : " & ex.StackTrace)
    '    Finally
    '        If (conn.State = ConnectionState.Open) Then
    '            conn.Close()
    '        End If
    '        conn = Nothing
    '    End Try

    '    Return result

    'End Function

    Public Function getAllGmap_Price3Master() As List(Of Price3_Master)

        'declare connection
        Dim conn As SqlConnection = Nothing
        'declare result
        Dim result As New List(Of Price3_Master)

        Try
            conn = ConnectionUtil.getSqlConnectionFromWebConfig()
            Dim sql As String = "SELECT " _
                & " Req_Id, " _
                & " AID, " _
                & " Temp_AID, " _
                & " isnull(Inform_To,'') as Inform_To, " _
                & " isnull(Cif,0) as Cif, " _
                & " Lat, " _
                & " Lng, " _
                & " isnull(Pricewah,0) as Pricewah, " _
                & " isnull(TotalPrice,0) as TotalPrice, " _
                & " isnull(Approved1,0) as Approved1, " _
                & " isnull(Approved2,0) as Approved2, " _
                & " isnull(Approved3,0) as Approved3, " _
                & " isnull(Approved,0) as Approved, " _
                & " isnull(Env_Effect,0) As Env_Effect, " _
                & " isnull(Env_Effect_Detail,'') As Env_Effect_Detail, " _
                & " isnull(Appraisal_Detail,'') As Appraisal_Detail, " _
                & " isnull(Appraisal_Type_Id,0) As Appraisal_Type_Id, " _
                & " isnull(Comment_ID,0) As Comment_ID, " _
                & " isnull(Warning_ID,0) As Warning_ID, " _
                & " isnull(Warning_Detail,'') As Warning_Detail, " _
                & " Create_User, " _
                & " isnull(Create_Date,getdate()) as Create_Date " _
                & " FROM Price3_Master " _
                & "ORDER BY Req_Id"

            Dim sqlCmd As New SqlCommand(sql, conn)
            sqlCmd.Prepare()

            Dim reader As SqlDataReader = sqlCmd.ExecuteReader()

            While reader.Read()
                result.Add(binding_Gmap(reader))
            End While

            reader.Close()
            conn.Close()
        Catch ex As Exception
            Throw New Exception(ex.Message & " : " & ex.StackTrace)
        Finally
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn = Nothing
        End Try

        Return result

    End Function

    'Public Function getAllGmapBySQL(ByVal sql As String) As List(Of Gmap)

    '    'declare connection
    '    Dim conn As SqlConnection = Nothing
    '    'declare result
    '    Dim result As New List(Of Gmap)

    '    Try
    '        conn = ConnectionUtil.getSqlConnectionFromWebConfig()
    '        Dim sqlCmd As New SqlCommand(sql, conn)
    '        sqlCmd.Prepare()

    '        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()

    '        While reader.Read()
    '            result.Add(bindingGmap(reader))
    '        End While

    '        reader.close()
    '        conn.Close()
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message & " : " & ex.StackTrace)
    '    Finally
    '        If (conn.State = ConnectionState.Open) Then
    '            conn.Close()
    '        End If
    '        conn = Nothing
    '    End Try

    '    Return result

    'End Function

    Public Function getAllGmapBySQL_Price3Master(ByVal sql As String) As List(Of Price3_Master)

        'declare connection
        Dim conn As SqlConnection = Nothing
        'declare result
        Dim result As New List(Of Price3_Master)

        Try
            conn = ConnectionUtil.getSqlConnectionFromWebConfig()
            Dim sqlCmd As New SqlCommand(sql, conn)
            sqlCmd.Prepare()

            Dim reader As SqlDataReader = sqlCmd.ExecuteReader()

            While reader.Read()
                result.Add(binding_Gmap(reader))
            End While

            reader.Close()
            conn.Close()
        Catch ex As Exception
            Throw New Exception(ex.Message & " : " & ex.StackTrace)
        Finally
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn = Nothing
        End Try

        Return result

    End Function

    Public Sub insertPrice1Master(ByVal objPrice1Master As Price1_Master)

        'declare connection
        Dim conn As SqlConnection = Nothing

        Try
            conn = ConnectionUtil.getSqlConnectionFromWebConfig()
            Dim sql As String = "INSERT INTO Price1_Master " _
                & " (Req_Id, Hub_Id, Cif, CifName, Lat, Lng, Pricewah, Price, Create_User, Create_Date) " _
                & " VALUES(@Req_Id, @Hub_Id, @Cif, @CifName, @Lat, @Lng, @Pricewah, @Price, @Create_User, @Create_Date) "
            Dim SqlUpdate As String = "UPDATE Appraisal_Request " _
            & " SET Status_ID = 5 " _
            & " WHERE Req_Id = Req_Id AND Hub_Id = @Hub_Id"

            Dim sqlCmd As New SqlCommand(sql, conn)
            sqlCmd.Prepare()

            sqlCmd.Parameters.AddWithValue("@Req_Id", objPrice1Master.Req_Id)
            sqlCmd.Parameters.AddWithValue("@Hub_Id", objPrice1Master.Hub_Id)
            sqlCmd.Parameters.AddWithValue("@Cif", objPrice1Master.Cif)
            sqlCmd.Parameters.AddWithValue("@CifName", objPrice1Master.CifName)
            sqlCmd.Parameters.AddWithValue("@Lat", objPrice1Master.Lat)
            sqlCmd.Parameters.AddWithValue("@Lng", objPrice1Master.Lng)
            sqlCmd.Parameters.AddWithValue("@Pricewah", objPrice1Master.Pricewah)
            sqlCmd.Parameters.AddWithValue("@Price", objPrice1Master.Price)
            sqlCmd.Parameters.AddWithValue("@Create_User", objPrice1Master.Create_User)
            sqlCmd.Parameters.AddWithValue("@Create_Date", objPrice1Master.Create_Date)

            sqlCmd.ExecuteNonQuery()

            'Dim sqlCmdUpdate As New SqlCommand(SqlUpdate, conn)
            'sqlCmdUpdate.Prepare()

            'sqlCmdUpdate.Parameters.AddWithValue("@Req_Id", objPrice1Master.Req_Id)
            'sqlCmdUpdate.Parameters.AddWithValue("@Hub_Id", objPrice1Master.Hub_Id)
            'sqlCmdUpdate.ExecuteNonQuery()

            UPDATE_Status_Appraisal_Request(objPrice1Master.Req_Id, objPrice1Master.Hub_Id, 5)
        Catch ex As Exception
            Throw New Exception(ex.Message & " : " & ex.StackTrace)
        Finally
            'UPDATE_Status_Appraisal_Request(objPrice1Master.Req_Id, objPrice1Master.Hub_Id, 5)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn = Nothing
        End Try

    End Sub

    'Public Sub updateGmap(ByVal objGmap As Gmap)

    '    'declare connection
    '    Dim conn As SqlConnection = Nothing

    '    Try
    '        conn = ConnectionUtil.getSqlConnectionFromWebConfig()
    '        Dim sql As String = "UPDATE Gmap SET " _
    '            & " Lat=@Lat, " _
    '            & " Lng=@Lng, " _
    '            & " Name=@Name, " _
    '            & " Detail=@Detail, " _
    '            & " Price1=@Price1, " _
    '            & " Price2=@Price2, " _
    '            & " Price3=@Price3, " _
    '            & " Pic1=@Pic1, " _
    '            & " Pic2=@Pic2 " _
    '            & " WHERE COLL_ID=@COLL_ID "

    '        Dim sqlCmd As New SqlCommand(sql, conn)
    '        sqlCmd.Prepare()

    '        sqlCmd.Parameters.AddWithValue("@COLL_ID", objGmap.COLL_ID)
    '        sqlCmd.Parameters.AddWithValue("@Lat", objGmap.Lat)
    '        sqlCmd.Parameters.AddWithValue("@Lng", objGmap.Lng)
    '        sqlCmd.Parameters.AddWithValue("@Name", objGmap.Name)
    '        sqlCmd.Parameters.AddWithValue("@Detail", objGmap.Detail)
    '        sqlCmd.Parameters.AddWithValue("@Price1", objGmap.Price1)
    '        sqlCmd.Parameters.AddWithValue("@Price2", objGmap.Price2)
    '        sqlCmd.Parameters.AddWithValue("@Price3", objGmap.Price3)
    '        sqlCmd.Parameters.AddWithValue("@Pic1", objGmap.Pic1)
    '        sqlCmd.Parameters.AddWithValue("@Pic2", objGmap.Pic2)

    '        sqlCmd.ExecuteNonQuery()
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message & " : " & ex.StackTrace)
    '    Finally
    '        If (conn.State = ConnectionState.Open) Then
    '            conn.Close()
    '        End If
    '        conn = Nothing
    '    End Try

    'End Sub

    Public Sub updatePrice1Master(ByVal objPrice1Master As Price1_Master)

        'declare connection
        Dim conn As SqlConnection = Nothing

        Try
            conn = ConnectionUtil.getSqlConnectionFromWebConfig()
            Dim sql As String = "UPDATE Price1_Master SET " _
                & " Lat=@Lat, " _
                & " Lng=@Lng, " _
                & " Create_User=@Create_User, " _
                & " Create_Date=@Create_Date " _
                & " WHERE Req_Id=@Req_Id AND Hub_Id=@Hub_Id"

            Dim sqlCmd As New SqlCommand(sql, conn)
            sqlCmd.Prepare()

            sqlCmd.Parameters.AddWithValue("@Req_Id", objPrice1Master.Req_Id)
            sqlCmd.Parameters.AddWithValue("@Hub_Id", objPrice1Master.Hub_Id)
            sqlCmd.Parameters.AddWithValue("@Lat", objPrice1Master.Lat)
            sqlCmd.Parameters.AddWithValue("@Lng", objPrice1Master.Lng)
            sqlCmd.Parameters.AddWithValue("@Create_User", objPrice1Master.Create_User)
            sqlCmd.Parameters.AddWithValue("@Create_Date", objPrice1Master.Create_Date)

            sqlCmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message & " : " & ex.StackTrace)
        Finally
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn = Nothing
        End Try

    End Sub

    'Public Sub deleteGmap(ByVal objGmap As Gmap)

    '    'declare connection
    '    Dim conn As SqlConnection = Nothing

    '    Try
    '        conn = ConnectionUtil.getSqlConnectionFromWebConfig()
    '        Dim sql As String = "DELETE FROM Gmap WHERE COLL_ID=@COLL_ID"

    '        Dim sqlCmd As New SqlCommand(sql, conn)
    '        sqlCmd.Prepare()

    '        sqlCmd.Parameters.AddWithValue("@COLL_ID", objGmap.COLL_ID)

    '        sqlCmd.ExecuteNonQuery()
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message & " : " & ex.StackTrace)
    '    Finally
    '        If (conn.State = ConnectionState.Open) Then
    '            conn.Close()
    '        End If
    '        conn = Nothing
    '    End Try

    'End Sub

    Public Sub Delete_Price1Master(ByVal Obj_Price3Master As Price1_Master)
        Dim conn As SqlConnection = Nothing

        Try
            conn = ConnectionUtil.getSqlConnectionFromWebConfig()
            Dim sql As String = "DELETE FROM Price1_Master WHERE Req_Id=@Req_Id AND Hub_Id=@Hub_Id"

            Dim sqlCmd As New SqlCommand(sql, conn)
            sqlCmd.Prepare()

            sqlCmd.Parameters.AddWithValue("@Req_Id", Obj_Price3Master.Req_Id)
            sqlCmd.Parameters.AddWithValue("@Hub_Id", Obj_Price3Master.Hub_id)
            sqlCmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message & " : " & ex.StackTrace)
        Finally
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn = Nothing
        End Try
    End Sub

    'Public Sub deleteGmap(ByVal COLL_ID As String)

    '    'declare connection
    '    Dim conn As SqlConnection = Nothing

    '    Try
    '        conn = ConnectionUtil.getSqlConnectionFromWebConfig()
    '        Dim sql As String = "DELETE FROM Gmap WHERE COLL_ID=@COLL_ID"

    '        Dim sqlCmd As New SqlCommand(sql, conn)
    '        sqlCmd.Prepare()

    '        sqlCmd.Parameters.AddWithValue("@COLL_ID", COLL_ID)

    '        sqlCmd.ExecuteNonQuery()
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message & " : " & ex.StackTrace)
    '    Finally
    '        If (conn.State = ConnectionState.Open) Then
    '            conn.Close()
    '        End If
    '        conn = Nothing
    '    End Try

    'End Sub

    Public Sub Delete_Price1Master(ByVal Req_Id As Integer, ByVal Hub_id As Integer)
        Dim conn As SqlConnection = Nothing

        Try
            conn = ConnectionUtil.getSqlConnectionFromWebConfig()
            Dim sql As String = "DELETE FROM Price1_Master WHERE Req_Id=@Req_Id AND Hub_Id=@Hub_Id"

            Dim sqlCmd As New SqlCommand(sql, conn)
            sqlCmd.Prepare()

            sqlCmd.Parameters.AddWithValue("@Req_Id", Req_Id)
            sqlCmd.Parameters.AddWithValue("@Hub_Id", Hub_id)
            sqlCmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message & " : " & ex.StackTrace)
        Finally
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn = Nothing
        End Try
    End Sub

    'Public Function bindingGmap(ByVal reader As SqlDataReader) As Gmap

    '    Dim objGmap As New Gmap

    '    objGmap.COLL_ID = CType(ConvertUtil.getObjectValue(reader("COLL_ID"), ConvertUtil.ObjectValueEnum.StringValue), String)
    '    objGmap.Lat = CType(ConvertUtil.getObjectValue(reader("Lat"), ConvertUtil.ObjectValueEnum.DoubleValue), Double)
    '    objGmap.Lng = CType(ConvertUtil.getObjectValue(reader("Lng"), ConvertUtil.ObjectValueEnum.DoubleValue), Double)
    '    objGmap.Name = CType(ConvertUtil.getObjectValue(reader("Name"), ConvertUtil.ObjectValueEnum.StringValue), String)
    '    objGmap.Detail = CType(ConvertUtil.getObjectValue(reader("Detail"), ConvertUtil.ObjectValueEnum.StringValue), String)
    '    objGmap.Price1 = CType(ConvertUtil.getObjectValue(reader("Price1"), ConvertUtil.ObjectValueEnum.DoubleValue), Decimal)
    '    objGmap.Price2 = CType(ConvertUtil.getObjectValue(reader("Price2"), ConvertUtil.ObjectValueEnum.DoubleValue), Decimal)
    '    objGmap.Price3 = CType(ConvertUtil.getObjectValue(reader("Price3"), ConvertUtil.ObjectValueEnum.DoubleValue), Decimal)
    '    objGmap.Pic1 = CType(ConvertUtil.getObjectValue(reader("Pic1"), ConvertUtil.ObjectValueEnum.StringValue), String)
    '    objGmap.Pic2 = CType(ConvertUtil.getObjectValue(reader("Pic2"), ConvertUtil.ObjectValueEnum.StringValue), String)

    '    Return objGmap

    'End Function

    Public Function binding_Gmap(ByVal reader As SqlDataReader) As Price3_Master

        Dim objPrice3_Master As New Price3_Master
        objPrice3_Master.Req_Id = CType(ConvertUtil.getObjectValue(reader("Req_Id"), ConvertUtil.ObjectValueEnum.StringValue), Integer)
        objPrice3_Master.AID = CType(ConvertUtil.getObjectValue(reader("AID"), ConvertUtil.ObjectValueEnum.StringValue), String)
        objPrice3_Master.Temp_AID = CType(ConvertUtil.getObjectValue(reader("Temp_AID"), ConvertUtil.ObjectValueEnum.StringValue), Integer)
        'objPrice3_Master. = CType(ConvertUtil.getObjectValue(reader("Cif"), ConvertUtil.ObjectValueEnum.StringValue), Integer)
        objPrice3_Master.Cif = CType(ConvertUtil.getObjectValue(reader("Cif"), ConvertUtil.ObjectValueEnum.StringValue), Integer)
        objPrice3_Master.Lat = CType(ConvertUtil.getObjectValue(reader("Lat"), ConvertUtil.ObjectValueEnum.DoubleValue), Double)
        objPrice3_Master.Lng = CType(ConvertUtil.getObjectValue(reader("Lng"), ConvertUtil.ObjectValueEnum.DoubleValue), Double)
        objPrice3_Master.PriceWah = CType(ConvertUtil.getObjectValue(reader("PriceWah"), ConvertUtil.ObjectValueEnum.DoubleValue), Decimal)
        objPrice3_Master.TotalPrice = CType(ConvertUtil.getObjectValue(reader("TotalPrice"), ConvertUtil.ObjectValueEnum.DoubleValue), Decimal)
        objPrice3_Master.Approved1 = CType(ConvertUtil.getObjectValue(reader("Approved1"), ConvertUtil.ObjectValueEnum.StringValue), String)
        objPrice3_Master.Approved2 = CType(ConvertUtil.getObjectValue(reader("Approved2"), ConvertUtil.ObjectValueEnum.StringValue), String)
        objPrice3_Master.Approved3 = CType(ConvertUtil.getObjectValue(reader("Approved3"), ConvertUtil.ObjectValueEnum.StringValue), String)
        objPrice3_Master.Approved = CType(ConvertUtil.getObjectValue(reader("Approved"), ConvertUtil.ObjectValueEnum.StringValue), Integer)
        objPrice3_Master.Env_Effect = CType(ConvertUtil.getObjectValue(reader("Env_Effect"), ConvertUtil.ObjectValueEnum.StringValue), Integer)
        objPrice3_Master.Env_Effect_Detail = CType(ConvertUtil.getObjectValue(reader("Env_Effect_Detail"), ConvertUtil.ObjectValueEnum.StringValue), String)
        objPrice3_Master.Appraisal_Detail = CType(ConvertUtil.getObjectValue(reader("Appraisal_Detail"), ConvertUtil.ObjectValueEnum.StringValue), String)
        objPrice3_Master.Appraisal_Type_ID = CType(ConvertUtil.getObjectValue(reader("Appraisal_Type_ID"), ConvertUtil.ObjectValueEnum.StringValue), Integer)
        objPrice3_Master.Comment_ID = CType(ConvertUtil.getObjectValue(reader("Comment_ID"), ConvertUtil.ObjectValueEnum.StringValue), Integer)
        objPrice3_Master.Warning_ID = CType(ConvertUtil.getObjectValue(reader("Warning_ID"), ConvertUtil.ObjectValueEnum.StringValue), Integer)
        objPrice3_Master.Warning_Detail = CType(ConvertUtil.getObjectValue(reader("Warning_Detail"), ConvertUtil.ObjectValueEnum.StringValue), String)
        objPrice3_Master.Create_User = CType(ConvertUtil.getObjectValue(reader("Create_User"), ConvertUtil.ObjectValueEnum.StringValue), String)
        objPrice3_Master.Create_Date = CType(ConvertUtil.getObjectValue(reader("Create_Date"), ConvertUtil.ObjectValueEnum.StringValue), Date)

        Return objPrice3_Master
    End Function

    Public Function binding_Gmap_Price1(ByVal reader As SqlDataReader) As Price1_Master

        Dim objPrice1_Master As New Price1_Master
        objPrice1_Master.Req_Id = CType(ConvertUtil.getObjectValue(reader("Req_Id"), ConvertUtil.ObjectValueEnum.StringValue), Integer)
        objPrice1_Master.Hub_Id = CType(ConvertUtil.getObjectValue(reader("Hub_Id"), ConvertUtil.ObjectValueEnum.StringValue), Integer)
        objPrice1_Master.Cif = CType(ConvertUtil.getObjectValue(reader("Cif"), ConvertUtil.ObjectValueEnum.StringValue), Integer)
        objPrice1_Master.CifName = CType(ConvertUtil.getObjectValue(reader("CifName"), ConvertUtil.ObjectValueEnum.StringValue), String)
        objPrice1_Master.Lat = CType(ConvertUtil.getObjectValue(reader("Lat"), ConvertUtil.ObjectValueEnum.DoubleValue), Double)
        objPrice1_Master.Lng = CType(ConvertUtil.getObjectValue(reader("Lng"), ConvertUtil.ObjectValueEnum.DoubleValue), Double)
        objPrice1_Master.Pricewah = CType(ConvertUtil.getObjectValue(reader("PriceWah"), ConvertUtil.ObjectValueEnum.DoubleValue), Decimal)
        objPrice1_Master.Price = CType(ConvertUtil.getObjectValue(reader("Price"), ConvertUtil.ObjectValueEnum.DoubleValue), Decimal)
        objPrice1_Master.Create_User = CType(ConvertUtil.getObjectValue(reader("Create_User"), ConvertUtil.ObjectValueEnum.StringValue), String)
        objPrice1_Master.Create_Date = CType(ConvertUtil.getObjectValue(reader("Create_Date"), ConvertUtil.ObjectValueEnum.StringValue), Date)

        Return objPrice1_Master
    End Function
End Class
