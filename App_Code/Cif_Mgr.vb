Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Collections
Imports System.Collections.Generic
Imports System.Configuration

Public Class Cif_Mgr
    Public Shared Function GetCifInfo(ByVal Cif As String) As Generic.List(Of CifInfo)
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("BAYConn").ConnectionString)
            Using command As New SqlCommand("GET_CIFINFO", connection)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(New SqlParameter("@Cif", Cif))
                connection.Open()
                Dim list As New Generic.List(Of CifInfo)()
                Using reader As SqlDataReader = command.ExecuteReader()
                    Do While (reader.Read())
                        'Get field in Store Procedure
                        Dim temp As New CifInfo(CStr(reader("cif")), _
                                                CStr(reader("cifName")), _
                                                CStr(reader("idCard")), _
                                                CStr(reader("cifClass")), _
                                                CInt(reader("botid")), _
                                                CInt(reader("Busi_Type")), _
                                                CStr(reader("Busi_Name")), _
                                                CStr(reader("departName")))
                        list.Add(temp)
                    Loop
                End Using
                Return list
            End Using
        End Using
    End Function

    Public Function GetCifInfoNew(ByVal Cif As Integer) As Generic.List(Of Class_Customer)
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("BAYConn").ConnectionString)

            Try
                Using command As New SqlCommand("GET_CIFINFO", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.CommandTimeout = 60
                    command.Parameters.Add(New SqlParameter("@Cif", Cif))
                    connection.Open()
                    Dim list As New Generic.List(Of Class_Customer)()
                    Using reader As SqlDataReader = command.ExecuteReader()
                        Do While (reader.Read())
                            'Get field in Store Procedure
                            Dim temp As New Class_Customer(CInt(reader("cif")), _
                                                    CStr(reader("Cus_Title")), _
                                                    CStr(reader("cifName")), _
                                                    CStr(reader("idCard")), _
                                                    CStr(reader("cifClass")), _
                                                    CInt(reader("botid")), _
                                                    CInt(reader("Busi_Type")), _
                                                    CStr(reader("Busi_Name")), _
                                                    CStr(reader("departName")), _
                                                    CStr(reader("cus_first")), _
                                                    CStr(reader("cus_last")))
                            list.Add(temp)
                        Loop
                    End Using
                    Return list
                End Using
            Catch ex As Exception
                Throw New Exception(ex.Message & " : " & ex.StackTrace)
            Finally
                connection.Close()
            End Try
        End Using

        Return Nothing
    End Function
End Class

