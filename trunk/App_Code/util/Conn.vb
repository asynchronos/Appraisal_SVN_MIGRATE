Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Xml.Serialization
Imports System.Xml
Imports System.Configuration
Imports System.Collections

Public Class Conn
    'Private strConn As String = "Server=TAM\SQLEXPRESS;database=Northwind;uid=sa;password=sa;"
    ' กำหนด string connnection ทุกครั้งที่เปลี่ยนแปลง db
    '  Private strConn As String = "Server=tna17224;database=bay01;uid=sa;password=sa0123;"
    Public Shared strConn As String = ConfigurationManager.ConnectionStrings("Bay_DBConnectionString").ConnectionString
    Public Function getDataset(ByVal strSQL As String, _
                  Optional ByVal DataSetName As String = "Dataset1", _
                  Optional ByVal TableName As String = "Table1") As DataSet
        ' ฟังชั่นสร้าง datataset โดยส่ง sql statement
        ' strSQL คือ  sql statement ใด ๆ 

        Using DA As New SqlDataAdapter(strSQL, strConn)
            Using DS As New DataSet(DataSetName)
                DA.Fill(DS, TableName)
                Return DS
            End Using
        End Using
    End Function

    Public Function getDataTable(ByVal strSQL As String, _
                  Optional ByVal TableName As String = "Table1") As DataTable
        ' ฟังชั่นสร้าง datatable โดยส่ง sql statement
        ' strSQL คือ  sql statement ใด ๆ 
        Using DS As DataSet = Me.getDataset(strSQL, TableName)
            Using DT As DataTable = DS.Tables(TableName)
                Return DT
            End Using
        End Using
    End Function

    Public Function getDataTablePara(ByVal strSQL As String, _
                  ByVal parameterText As String, _
                  Optional ByVal parameterType As SqlDbType = SqlDbType.VarChar, _
                  Optional ByVal DataSetName As String = "Dataset1", _
                  Optional ByVal TableName As String = "Table1") As DataTable
        ' ฟังชั่นนี้ทำหน้าที่สร้าง datatable จาก sqlcommand โดยสามารส่ง  sqlparameter มาด้วย
        ' strSQL คือ  sql statement ใด ๆ 
        ' parameterText = parameter ใน sql เช่น  select * from TB_EMPLOYEE where EMPNAME like @para1+'%'
        ' เหมาะในการค้นหาข้อมูล string

        Using DA As New SqlDataAdapter(strSQL, strConn)
            Dim cmd As SqlCommand = DA.SelectCommand
            cmd.Parameters.Add("@para1", parameterType).Value = parameterText
            Dim ds As New DataSet(DataSetName)
            DA.Fill(ds, TableName)
            Dim DT As DataTable = ds.Tables(TableName)
            Return DT
        End Using
    End Function

    Public Function saveSqlCommand(ByVal strSQL As String) As SqlCommand
        Dim con As New SqlConnection(strConn)
        Dim cmd As New SqlCommand(strSQL, con)
        con.Open()
        Return cmd
    End Function


    ''' <summary>
    ''' Function นี้ใช้สำหรับสร้าง SqlConnection
    ''' </summary>
    ''' <returns>SqlConnection</returns>
    ''' <remarks></remarks>
    Public Shared Function getSqlConnectionFromWebConfig() As SqlConnection
        Dim conn As SqlConnection = Nothing

        conn = New SqlConnection(ConfigurationManager.ConnectionStrings("Bay_DBConnectionString").ConnectionString)
        conn.Open()

        Return conn
    End Function

    Public Function GetArrayListOrderBy(ByVal SqlStatement As String, ByVal ColumnOrder As String) As ArrayList


        'Dim i As Integer
        Dim MyConnection As New SqlConnection(strConn)
        MyConnection.Open()
        Dim MyCommand As New SqlCommand(SqlStatement, MyConnection)
        Dim dr As SqlDataReader = MyCommand.ExecuteReader(CommandBehavior.CloseConnection)
        Dim al As New ArrayList

        While dr.Read()
            Dim values(dr.FieldCount) As Object
            dr.GetValues(values)
            al.Add(values)
        End While

        Return al
    End Function


End Class




