
Partial Class Appraisal_Review_List_Cid
    Inherits System.Web.UI.Page

    Private Sub Showdata(ByVal Apps_Id As String)
        Try
            Dim sql As String = Nothing

            SqlDataSource1.SelectParameters.Clear()
            sql = "Select  CIF, PLED_ID, APPS_ID, COLL_ID, COLLTYPE, ADDR, [GROUP]AS Gs, BUILDNAME, SOI, ROAD, DISTRICT, AMPHUR, PROV,PROV_NAME, C05, TYPE, CHANODE, LAND," _
                      & "SURVEY, PAGE, BOOK, AREA_RAI, AREA_NGAN, AREA_WAH, C07, BUIL_TYPE, BUIL_FLOOR, BUIL_AREA, C18, ROOM_NO, FLOOR, " _
                      & "ROOM_AREA" _
                      & " FROM View_Appraisal_Review_List_Cid WHERE APPS_ID = " & Apps_Id


            SqlDataSource1.ConnectionString = "Data Source=172.19.54.2;Initial Catalog=Appraisal;User ID=sa;Password=sa0123"
            SqlDataSource1.SelectCommand = sql
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim Apps_Id As String = Request.QueryString("Apps_Id")
            Showdata(Apps_Id)
        End If
    End Sub
End Class
