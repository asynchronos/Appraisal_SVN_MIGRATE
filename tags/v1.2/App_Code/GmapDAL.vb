Option Explicit On
Option Strict On

Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Collections.Generic

Public Class GmapDAL

	Private Shared className As String = "GmapDAL"

	Public Function getGmapByCOLL_ID(ByVal objGmap As Gmap) As Gmap

		'declare connection
		Dim conn As SqlConnection = Nothing
		'declare result
		Dim result As New Gmap()

		Try
			conn = ConnectionUtil.getSqlConnectionFromWebConfig()
			Dim sql As String = "SELECT " _
				& "COLL_ID, Lat, Lng, Name, " _
				& "Detail, Price1, Price2, Price3, " _
				& "Pic1, Pic2 " _
				& "FROM Gmap " _
				& "WHERE COLL_ID=@COLL_ID " _
				& "ORDER BY COLL_ID"

			Dim sqlCmd As New SqlCommand(sql, conn)
			sqlCmd.Prepare()

			sqlCmd.Parameters.AddWithValue("@COLL_ID", objGmap.COLL_ID)

			Dim reader As SqlDataReader = sqlCmd.ExecuteReader()

			While reader.Read()
				result = bindingGmap(reader)
			End While

			reader.close()
		Catch ex As Exception
			Throw New Exception(ex.Message & " : " & ex.StackTrace)
		Finally
			If (conn.State = ConnectionState.Open) Then
				conn.Close()
			End IF
			conn = Nothing
		End Try

		Return result

	End Function

	Public Function getGmapByCOLL_ID(ByVal COLL_ID As String) As Gmap

		'declare connection
		Dim conn As SqlConnection = Nothing
		'declare result
		Dim result As New Gmap()

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

			sqlCmd.Parameters.AddWithValue("@COLL_ID", COLL_ID)

			Dim reader As SqlDataReader = sqlCmd.ExecuteReader()

			While reader.Read()
				result = bindingGmap(reader)
			End While

			reader.close()
		Catch ex As Exception
			Throw New Exception(ex.Message & " : " & ex.StackTrace)
		Finally
			If (conn.State = ConnectionState.Open) Then
				conn.Close()
			End IF
			conn = Nothing
		End Try

		Return result

	End Function

	Public Function getAllGmap() As List (Of Gmap)

		'declare connection
		Dim conn As SqlConnection = Nothing
		'declare result
		Dim result As New List(Of Gmap)

		Try
			conn = ConnectionUtil.getSqlConnectionFromWebConfig()
            Dim sql As String = "SELECT " _
             & "COLL_ID, Lat, Lng, Name, " _
             & "Detail, Price1, Price2, Price3, " _
             & "Pic1, Pic2 " _
             & "FROM Price3_Master " _
             & "ORDER BY COLL_ID"

			Dim sqlCmd As New SqlCommand(sql, conn)
			sqlCmd.Prepare()

			Dim reader As SqlDataReader = sqlCmd.ExecuteReader()

			While reader.Read()
				result.Add(bindingGmap(reader))
			End While

			reader.close()
			conn.Close()
		Catch ex As Exception
			Throw New Exception(ex.Message & " : " & ex.StackTrace)
		Finally
			If (conn.State = ConnectionState.Open) Then
				conn.Close()
			End IF
			conn = Nothing
		End Try

		Return result

	End Function

	Public Function getAllGmapBySQL(ByVal sql AS String) As List (Of Gmap)

		'declare connection
		Dim conn As SqlConnection = Nothing
		'declare result
		Dim result As New List(Of Gmap)

		Try
			conn = ConnectionUtil.getSqlConnectionFromWebConfig()
			Dim sqlCmd As New SqlCommand(sql, conn)
			sqlCmd.Prepare()

			Dim reader As SqlDataReader = sqlCmd.ExecuteReader()

			While reader.Read()
				result.Add(bindingGmap(reader))
			End While

			reader.close()
			conn.Close()
		Catch ex As Exception
			Throw New Exception(ex.Message & " : " & ex.StackTrace)
		Finally
			If (conn.State = ConnectionState.Open) Then
				conn.Close()
			End IF
			conn = Nothing
		End Try

		Return result

	End Function

	Public Sub insertGmap(ByVal objGmap As Gmap)

		'declare connection
		Dim conn As SqlConnection = Nothing

		Try
			conn = ConnectionUtil.getSqlConnectionFromWebConfig()
			Dim sql As String = "INSERT INTO Gmap " _
							& " (COLL_ID, Lat, Lng, Name, Detail, Price1, Price2, Price3, Pic1, Pic2) " _
							& " VALUES(@COLL_ID, @Lat, @Lng, @Name, @Detail, @Price1, @Price2, @Price3, @Pic1, @Pic2) "

			Dim sqlCmd As New SqlCommand(sql, conn)
			sqlCmd.Prepare()

			sqlCmd.Parameters.AddWithValue("@COLL_ID", objGmap.COLL_ID)
			sqlCmd.Parameters.AddWithValue("@Lat", objGmap.Lat)
			sqlCmd.Parameters.AddWithValue("@Lng", objGmap.Lng)
			sqlCmd.Parameters.AddWithValue("@Name", objGmap.Name)
            sqlCmd.Parameters.AddWithValue("@Detail", objGmap.Detail)
            sqlCmd.Parameters.AddWithValue("@Price1", objGmap.Price1)
            sqlCmd.Parameters.AddWithValue("@Price2", objGmap.Price2)
            sqlCmd.Parameters.AddWithValue("@Price3", objGmap.Price3)
            sqlCmd.Parameters.AddWithValue("@Pic1", objGmap.Pic1)
            sqlCmd.Parameters.AddWithValue("@Pic2", objGmap.Pic2)

			sqlCmd.ExecuteNonQuery()
		Catch ex As Exception
			Throw New Exception(ex.Message & " : " & ex.StackTrace)
		Finally
			If (conn.State = ConnectionState.Open) Then
				conn.Close()
			End IF
			conn = Nothing
		End Try

	End Sub

	Public Sub updateGmap(ByVal objGmap As Gmap)

		'declare connection
		Dim conn As SqlConnection = Nothing

		Try
			conn = ConnectionUtil.getSqlConnectionFromWebConfig()
			Dim sql As String = "UPDATE Gmap SET " _
							& " Lat=@Lat, " _
							& " Lng=@Lng, " _
							& " Name=@Name, " _
							& " Detail=@Detail, " _
							& " Price1=@Price1, " _
							& " Price2=@Price2, " _
							& " Price3=@Price3, " _
							& " Pic1=@Pic1, " _
							& " Pic2=@Pic2 " _
							& " WHERE COLL_ID=@COLL_ID "

			Dim sqlCmd As New SqlCommand(sql, conn)
			sqlCmd.Prepare()

			sqlCmd.Parameters.AddWithValue("@COLL_ID", objGmap.COLL_ID)
			sqlCmd.Parameters.AddWithValue("@Lat", objGmap.Lat)
			sqlCmd.Parameters.AddWithValue("@Lng", objGmap.Lng)
			sqlCmd.Parameters.AddWithValue("@Name", objGmap.Name)
			sqlCmd.Parameters.AddWithValue("@Detail", objGmap.Detail)
			sqlCmd.Parameters.AddWithValue("@Price1", objGmap.Price1)
			sqlCmd.Parameters.AddWithValue("@Price2", objGmap.Price2)
			sqlCmd.Parameters.AddWithValue("@Price3", objGmap.Price3)
			sqlCmd.Parameters.AddWithValue("@Pic1", objGmap.Pic1)
			sqlCmd.Parameters.AddWithValue("@Pic2", objGmap.Pic2)

			sqlCmd.ExecuteNonQuery()
		Catch ex As Exception
			Throw New Exception(ex.Message & " : " & ex.StackTrace)
		Finally
			If (conn.State = ConnectionState.Open) Then
				conn.Close()
			End IF
			conn = Nothing
		End Try

	End Sub

	Public Sub deleteGmap(ByVal objGmap As Gmap)

		'declare connection
		Dim conn As SqlConnection = Nothing

		Try
			conn = ConnectionUtil.getSqlConnectionFromWebConfig()
			Dim sql As String = "DELETE FROM Gmap WHERE COLL_ID=@COLL_ID"

			Dim sqlCmd As New SqlCommand(sql, conn)
			sqlCmd.Prepare()

			sqlCmd.Parameters.AddWithValue("@COLL_ID", objGmap.COLL_ID)

			sqlCmd.ExecuteNonQuery()
		Catch ex As Exception
			Throw New Exception(ex.Message & " : " & ex.StackTrace)
		Finally
			If (conn.State = ConnectionState.Open) Then
				conn.Close()
			End IF
			conn = Nothing
		End Try

	End Sub

	Public Sub deleteGmap(ByVal COLL_ID As String)

		'declare connection
		Dim conn As SqlConnection = Nothing

		Try
			conn = ConnectionUtil.getSqlConnectionFromWebConfig()
			Dim sql As String = "DELETE FROM Gmap WHERE COLL_ID=@COLL_ID"

			Dim sqlCmd As New SqlCommand(sql, conn)
			sqlCmd.Prepare()

			sqlCmd.Parameters.AddWithValue("@COLL_ID", COLL_ID)

			sqlCmd.ExecuteNonQuery()
		Catch ex As Exception
			Throw New Exception(ex.Message & " : " & ex.StackTrace)
		Finally
			If (conn.State = ConnectionState.Open) Then
				conn.Close()
			End IF
			conn = Nothing
		End Try

	End Sub

	Public Function bindingGmap(ByVal reader as SqlDataReader) As Gmap

		Dim objGmap As New Gmap

		objGmap.COLL_ID = CType(ConvertUtil.getObjectValue(reader("COLL_ID"), ConvertUtil.ObjectValueEnum.StringValue), String)
		objGmap.Lat = CType(ConvertUtil.getObjectValue(reader("Lat"), ConvertUtil.ObjectValueEnum.DoubleValue), Double)
		objGmap.Lng = CType(ConvertUtil.getObjectValue(reader("Lng"), ConvertUtil.ObjectValueEnum.DoubleValue), Double)
		objGmap.Name = CType(ConvertUtil.getObjectValue(reader("Name"), ConvertUtil.ObjectValueEnum.StringValue), String)
		objGmap.Detail = CType(ConvertUtil.getObjectValue(reader("Detail"), ConvertUtil.ObjectValueEnum.StringValue), String)
		objGmap.Price1 = CType(ConvertUtil.getObjectValue(reader("Price1"), ConvertUtil.ObjectValueEnum.DoubleValue), Decimal)
		objGmap.Price2 = CType(ConvertUtil.getObjectValue(reader("Price2"), ConvertUtil.ObjectValueEnum.DoubleValue), Decimal)
		objGmap.Price3 = CType(ConvertUtil.getObjectValue(reader("Price3"), ConvertUtil.ObjectValueEnum.DoubleValue), Decimal)
		objGmap.Pic1 = CType(ConvertUtil.getObjectValue(reader("Pic1"), ConvertUtil.ObjectValueEnum.StringValue), String)
		objGmap.Pic2 = CType(ConvertUtil.getObjectValue(reader("Pic2"), ConvertUtil.ObjectValueEnum.StringValue), String)

		Return objGmap

	End Function

    

End Class
