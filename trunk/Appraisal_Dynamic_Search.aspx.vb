Imports System.Data
Imports System.Data.OracleClient
Partial Class Appraisal_Dynamic_Search
    Inherits System.Web.UI.Page

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim StrSQLCertiria As String = ""
        Dim Procode As String
        If Len(ddlProvince.SelectedValue) = 1 Then
            Procode = "0" & ddlProvince.SelectedValue.ToString
        Else
            Procode = ddlProvince.SelectedValue.ToString
        End If
        StrSQLCertiria = "Where E.PROVINCE ='" & Procode & "'"
        If txtAmphur.Text <> String.Empty Then
            StrSQLCertiria += " AND Amphur Like " & "'%" & txtAmphur.Text & "%'"
        Else
        End If
        If txtDistrict.Text <> String.Empty Then
            StrSQLCertiria += " AND District Like " & "'%" & txtDistrict.Text & "%'"
        Else
        End If
        If txtRoad.Text <> String.Empty Then
            StrSQLCertiria += " AND Road Like " & "'%" & txtRoad.Text & "%'"
        Else
        End If
        If ddlCollType.SelectedValue <> 0 Then
            StrSQLCertiria += " AND E.ASSET_TYPE_DESC_1 LIKE '%" & Trim(ddlCollType.SelectedItem.Text) & "%'"
        End If

        If txtPrice.Text <> String.Empty Then
            StrSQLCertiria += " AND B.APPRAISAL_VALUE >= " & txtPrice.Text
        Else
        End If
        'lblSql.Text = StrSQLCertiria

        Dim con As OracleConnection = New OracleConnection(ConfigurationManager.ConnectionStrings("EDW_Connectionstring").ConnectionString)

        Dim Sqlstring As String = "SELECT A.APPRAISAL_ID,MAX(SUBSTR(A.APPRAISAL_ID,1,3))COLL_TYPE,MAX(E.ASSET_TYPE_DESC_1)COLLNAME,MAX(A.APPRAISAL_DATE)APPRAISAL_DATE," _
        & " MAX(B.APPRAISAL_VALUE)APPRAISAL_VALUE,MAX(B.APPRAISAL_KEY)APPRAISAL_KEY,MAX(E.SOI)SOI,MAX(E.ROAD)ROAD,MAX(E.DISTRICT)DISTRICT," _
        & " MAX(E.AMPHUR)AMPHUR,MAX(E.PROVINCE)PROVINCE,MAX(E.PROVINCE_DESC)PROVINCE_DESC " _
        & " FROM (SELECT DWHADMIN.APPRAISAL_MASTER.APPRAISAL_ID," _
        & "       MAX(DWHADMIN.APPRAISAL_MASTER.APPRAISAL_DATE)APPRAISAL_DATE " _
        & "       FROM DWHADMIN.APPRAISAL_MASTER " _
        & "       GROUP BY DWHADMIN.APPRAISAL_MASTER.APPRAISAL_ID) A INNER JOIN " _
        & "       DWHADMIN.APPRAISAL_MASTER B ON A.APPRAISAL_ID = B.APPRAISAL_ID AND A.APPRAISAL_DATE= B.APPRAISAL_DATE INNER JOIN " _
        & "       DWHADMIN.COLLATERAL_APPRAISAL C ON B.APPRAISAL_KEY = C.APPRAISAL_KEY INNER JOIN " _
        & "       DWHADMIN.COLLATERAL_FACT D ON C.COLLATERAL_KEY = D.COLLATERAL_KEY INNER JOIN " _
        & "       DWHADMIN.COLLATERAL_MASTER E ON D.COLLATERAL_KEY = E.COLLATERAL_KEY " & StrSQLCertiria & " GROUP BY A.APPRAISAL_ID"

        Dim command As OracleCommand = New OracleCommand(Sqlstring)
        command.Connection = con
        con.Open()
        Dim list As New OracleDataAdapter(command)
        Dim ds As New DataSet
        list.Fill(ds)
        con.Close()
        GridView_CollAll.DataSource = ds
        GridView_CollAll.DataBind()

    End Sub

    '    SELECT A.*,B.APPRAISAL_VALUE,B.APPRAISAL_KEY,C.COLLATERAL_KEY,D.COLLATERAL_STATUS,E.COLLATERAL_ID,E.ROAD,E.DISTRICT,
    '       E.AMPHUR,E.PROVINCE_DESC
    'FROM (SELECT DWHADMIN.APPRAISAL_MASTER.APPRAISAL_ID,
    '       MAX(DWHADMIN.APPRAISAL_MASTER.APPRAISAL_DATE)APPRAISAL_DATE
    '       FROM DWHADMIN.APPRAISAL_MASTER     
    '       GROUP BY DWHADMIN.APPRAISAL_MASTER.APPRAISAL_ID) A INNER JOIN 
    '       DWHADMIN.APPRAISAL_MASTER B ON A.APPRAISAL_ID = B.APPRAISAL_ID AND A.APPRAISAL_DATE= B.APPRAISAL_DATE INNER JOIN 
    '       DWHADMIN.COLLATERAL_APPRAISAL C ON B.APPRAISAL_KEY = C.APPRAISAL_KEY INNER JOIN 
    '       DWHADMIN.COLLATERAL_FACT D ON C.COLLATERAL_KEY = D.COLLATERAL_KEY INNER JOIN
    '       DWHADMIN.COLLATERAL_MASTER E ON D.COLLATERAL_KEY = E.COLLATERAL_KEY
    'WHERE B.APPRAISAL_KEY ='105384'   

    'SELECT A.APPRAISAL_ID,MAX(SUBSTR(A.APPRAISAL_ID,1,3))COLL_TYPE,MAX(E.ASSET_TYPE_DESC_1)COLLNAME,MAX(A.APPRAISAL_DATE)APPRAISAL_DATE,
    '       MAX(B.APPRAISAL_VALUE)APPRAISAL_VALUE,MAX(B.APPRAISAL_KEY),MAX(E.SOI)SOI,MAX(E.ROAD)ROAD,MAX(E.DISTRICT)DISTRICT,
    '       MAX(E.AMPHUR)AMPHUR,MAX(E.PROVINCE_DESC)PROVINCE_DESC
    'FROM (SELECT DWHADMIN.APPRAISAL_MASTER.APPRAISAL_ID,
    '       MAX(DWHADMIN.APPRAISAL_MASTER.APPRAISAL_DATE)APPRAISAL_DATE
    '       FROM DWHADMIN.APPRAISAL_MASTER     
    '       GROUP BY DWHADMIN.APPRAISAL_MASTER.APPRAISAL_ID) A INNER JOIN 
    '       DWHADMIN.APPRAISAL_MASTER B ON A.APPRAISAL_ID = B.APPRAISAL_ID AND A.APPRAISAL_DATE= B.APPRAISAL_DATE INNER JOIN 
    '       DWHADMIN.COLLATERAL_APPRAISAL C ON B.APPRAISAL_KEY = C.APPRAISAL_KEY INNER JOIN 
    '       DWHADMIN.COLLATERAL_FACT D ON C.COLLATERAL_KEY = D.COLLATERAL_KEY INNER JOIN
    '       DWHADMIN.COLLATERAL_MASTER E ON D.COLLATERAL_KEY = E.COLLATERAL_KEY
    'WHERE B.APPRAISAL_KEY ='105384'
    'GROUP BY A.APPRAISAL_ID 

    '    SELECT A.APPRAISAL_ID,
    '       MAX(SUBSTR(A.APPRAISAL_ID,1,3)) COLL_TYPE,
    '       MAX(E.ASSET_TYPE_DESC_1) COLLNAME,
    '       MAX(A.APPRAISAL_DATE) APPRAISAL_DATE, 
    '       MAX(B.APPRAISAL_VALUE) APPRAISAL_VALUE,
    '       MAX(B.APPRAISAL_KEY) APPRAISAL_KEY,
    '       MAX(E.SOI) SOI,
    '       MAX(E.ROAD)ROAD,
    '       MAX(E.DISTRICT) DISTRICT, 
    '       MAX(E.AMPHUR) AMPHUR,
    '       MAX(E.AMPHUR)AMPHUR,MAX(E.PROVINCE)PROVINCE,
    '       MAX(E.PROVINCE_DESC) PROVINCE_NAME
    'FROM (SELECT DWHADMIN.APPRAISAL_MASTER.APPRAISAL_ID,MAX(DWHADMIN.APPRAISAL_MASTER.APPRAISAL_DATE)APPRAISAL_DATE
    '      FROM DWHADMIN.APPRAISAL_MASTER 
    '      GROUP BY DWHADMIN.APPRAISAL_MASTER.APPRAISAL_ID) A INNER JOIN        
    'DWHADMIN.APPRAISAL_MASTER B ON A.APPRAISAL_ID = B.APPRAISAL_ID AND A.APPRAISAL_DATE= B.APPRAISAL_DATE INNER JOIN
    'DWHADMIN.COLLATERAL_APPRAISAL C ON B.APPRAISAL_KEY = C.APPRAISAL_KEY INNER JOIN
    'DWHADMIN.COLLATERAL_FACT D ON C.COLLATERAL_KEY = D.COLLATERAL_KEY INNER JOIN
    'DWHADMIN.COLLATERAL_MASTER E ON D.COLLATERAL_KEY = E.COLLATERAL_KEY 
    'WHERE E.PROVINCE = 59 AND E.ASSET_TYPE_DESC_1= 'โฉนด'
    'GROUP BY A.APPRAISAL_ID

    '    SELECT Distinct(Collateral_type)
    'FROM DWHADMIN.COLLATERAL_MASTER

    'SELECT * --Distinct(Collateral_type)
    'FROM DWHADMIN.COLLATERAL_MASTER
    'WHERE COLLATERAL_TYPE ='สิ่งปลูกสร้าง'
    '--WHERE ASSET_TYPE_CODE_1 = '050'
    'ORDER BY Collateral_type
End Class
