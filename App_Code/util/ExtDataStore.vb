Option Explicit On
Option Strict On

Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class ExtDataStore
    Public Enum ExtDataType
        Json
        Xml
    End Enum
    Public Shared Function GetXmlFromDataTable(ByVal dt As DataTable) As String
        Dim writer As System.IO.StringWriter = New System.IO.StringWriter()
        dt.WriteXml(writer)
        Return (writer.ToString())
    End Function
    Public Shared Function GetJsonFromDataTable(ByVal dt As DataTable) As String

        Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
        Dim rows As New List(Of Dictionary(Of String, Object))
        Dim row As Dictionary(Of String, Object)

        For Each dr As DataRow In dt.Rows
            row = New Dictionary(Of String, Object)
            For Each col As DataColumn In dt.Columns
                row.Add(col.ColumnName, dr(col))
            Next
            rows.Add(row)
        Next
        Return serializer.Serialize(rows)
    End Function
    Public Function GetJsonFromSQL(ByVal sql As String, ByVal CommandType As System.Data.CommandType, _
                                    Optional ByVal param1 As SqlParameter = Nothing, _
                                    Optional ByVal param2 As SqlParameter = Nothing, _
                                    Optional ByVal param3 As SqlParameter = Nothing, _
                                     Optional ByVal param4 As SqlParameter = Nothing) As String

        Dim ds1 As New DataSet
        Dim conn As New SqlConnection
        conn = ConnectionUtil.getSqlConnectionFromWebConfig

        Dim command As SqlCommand = New SqlCommand()
        command.Connection = conn
        command.CommandType = CommandType
        command.CommandText = sql
        If Not param1 Is Nothing Then command.Parameters.Add(param1)
        If Not param2 Is Nothing Then command.Parameters.Add(param2)
        If Not param3 Is Nothing Then command.Parameters.Add(param3)
        If Not param4 Is Nothing Then command.Parameters.Add(param4)

        Dim da1 As SqlDataAdapter = New SqlDataAdapter(command)
        da1.Fill(ds1, "Table")
        conn.Close()
        Return GetJsonFromDataTable(ds1.Tables("Table"))

    End Function
    Public Function GetExtStoreFromSQL(ByVal sql As String, ByVal CommandType As System.Data.CommandType, ByVal ExtType As ExtDataType, _
                                    Optional ByVal param1 As SqlParameter = Nothing, _
                                    Optional ByVal param2 As SqlParameter = Nothing, _
                                    Optional ByVal param3 As SqlParameter = Nothing, _
                                    Optional ByVal param4 As SqlParameter = Nothing _
                                     ) As String

        Dim ds1 As New DataSet
        Dim conn As New SqlConnection
        conn = ConnectionUtil.getSqlConnectionFromWebConfig

        Dim command As SqlCommand = New SqlCommand()
        command.Connection = conn
        command.CommandType = CommandType
        command.CommandText = sql

        'If Not param1 Is Nothing Then command.Parameters.Add(param1)
        'If Not param2 Is Nothing Then command.Parameters.Add(param2)
        'If Not param3 Is Nothing Then command.Parameters.Add(param3)
        'If Not param4 Is Nothing Then command.Parameters.Add(param4)

        Dim da1 As SqlDataAdapter = New SqlDataAdapter(command)
        da1.Fill(ds1, "Table")
        conn.Close()
        If extType = ExtDataType.Json Then
            Return GetJsonFromDataTable(ds1.Tables("Table"))
        Else
            Return GetXmlFromDataTable(ds1.Tables("Table"))
        End If

    End Function


End Class
