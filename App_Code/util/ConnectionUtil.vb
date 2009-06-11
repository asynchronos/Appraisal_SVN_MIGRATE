Option Explicit On
Option Strict On

Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Configuration

Public Class ConnectionUtil

    Public Shared ReadOnly AppraisalConn As String = "AppraisalConn"
    'Public Shared ReadOnly BAY01ConnectionString As String = "Bay_DBConnectionString"
    'Public Shared ReadOnly ton As String = "ton"

    ''' <summary>
    ''' Function ���������Ѻ���ҧ SqlConnection
    ''' </summary>
    ''' <returns>SqlConnection</returns>
    ''' <remarks></remarks>
    Public Shared Function getSqlConnectionFromWebConfig() As SqlConnection
        Dim conn As SqlConnection = Nothing

        conn = New SqlConnection(ConfigurationManager.ConnectionStrings(AppraisalConn).ConnectionString)

        conn.Open()

        Return conn
    End Function

    ''' <summary>
    ''' Function ���������Ѻ���ҧ SqlConnection
    ''' </summary>
    ''' <param name="conStringName">���� connection string ����ͧ��õԴ���� web config</param>
    ''' <returns>SqlConnection</returns>
    ''' <remarks></remarks>
    Public Shared Function getSqlConnectionFromWebConfig(ByVal conStringName As String) As SqlConnection
        Dim conn As SqlConnection = Nothing

        conn = New SqlConnection(ConfigurationManager.ConnectionStrings(conStringName).ConnectionString)
        conn.Open()

        Return conn
    End Function

    ''' <summary>
    ''' Function ���������Ѻ���ҧ SqlConnection �¡���кؤ�� connection string ��ٻẺ
    ''' Data Source=serverName;Initial Catalog=databaseName;Persist Security Info=True;User ID=username;Password=password
    ''' </summary>
    ''' <param name="connectionString">Data Source=serverName;Initial Catalog=databaseName;Persist Security Info=True;User ID=username;Password=password</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getSqlConnection(ByVal connectionString As String) As SqlConnection
        Dim conn As SqlConnection = Nothing

        conn = New SqlConnection(connectionString)
        conn.Open()

        Return conn
    End Function

End Class
