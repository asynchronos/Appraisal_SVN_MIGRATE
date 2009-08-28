Imports System.Data
Imports System.Data.SqlClient

Partial Class Longdo_Data
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim ExtData As New ExtDataStore
        'Dim sql As String = "EMPLOYEE_Get_Employee_By_EmpId"
        Dim sql As String = "GET_LONGDO_LAT_LNG"   'Get Data From Strore Procedure 'GET_LONGDO_LAT_LNG'
        Dim Param1 As New SqlParameter
        'Param1.ParameterName = "EMP_ID"
        'Param1.Value = Request("EMP_ID")
        Response.ClearHeaders()
        '        Response.Write(ExtData.GetExtStoreFromSQL(sql, CommandType.StoredProcedure, ExtDataStore.ExtDataType.Xml, Param1))
        Response.Write(ExtData.GetExtStoreFromSQL(sql, CommandType.StoredProcedure, ExtDataStore.ExtDataType.Json, Param1))
    End Sub
End Class
