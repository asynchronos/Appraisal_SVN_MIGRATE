Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Data.SqlClient
Imports System.IO
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Globalization.CultureInfo
Imports Appraisal_Manager

Partial Class Appraisal_Price3_List
    Inherits System.Web.UI.Page
    Dim s As String = ""


#Region "Variables"
    Dim gvUniqueID As String = String.Empty
    Dim gvNewPageIndex As Integer = 0
    Dim gvEditIndex As Integer = -1
    Dim gvSortExpr As String = String.Empty
#End Region

    Private Property gvSortDir() As String
        Get
            Return IIf(TryCast(ViewState("SortDirection"), String) Is Nothing, "ASC", TryCast(ViewState("SortDirection"), String))
        End Get
        Set(ByVal value As String)
            ViewState("SortDirection") = value
        End Set
    End Property

    'This procedure returns the Sort Direction
    Private Function GetSortDirection() As String
        Select Case gvSortDir
            Case "ASC"
                gvSortDir = "DESC"
                Exit Select
            Case "DESC"
                gvSortDir = "ASC"
                Exit Select
        End Select
        Return gvSortDir
    End Function

    Private Function ChildDataSource(ByVal strTemp_AID As Integer, ByVal strSort As String) As SqlDataSource
        Dim strQRY As String = ""
        Dim dsTemp As New SqlDataSource

        Dim conn As String = "server=172.19.54.2;Database=Appraisal;User ID=sa;Password=sa0123"
        dsTemp.ConnectionString = conn
        strQRY = "SELECT ID, Req_Id, Cif, CIFNAME, Hub_Id, HUB_NAME, Temp_AID, CollType_ID, MysubColl_ID, SubCollType_Name, Address_No, Tumbon, Amphur, Province,PROV_NAME FROM View_Appraisal_Price3_ListDetail WHERE Temp_AID = " & strTemp_AID & ""
        'strQRY = "SELECT Q_ID,Cif,Coll_id FROM Sent_Appraisal_Detail WHERE Q_ID = " & strQueueId & "" + strSort
        dsTemp.SelectCommand = strQRY
        Return dsTemp
    End Function

#Region "GridView1 Event Handlers"

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        'Dim ImgBtAdd As ImageButton = DirectCast(sender, ImageButton)
        'Dim gvTemp As GridView = DirectCast(sender, GridView)
        'Dim Req_Id As Label = gvTemp.Parent.FindControl("lblReq_Id")
        'Dim Hub_Id As Label = gvTemp.Parent.FindControl("lblHub_Id")
        'Dim Temp_AID As Label = gvTemp.Parent.FindControl("lblTemp_AID")
        'Dim CollType_Id As Label = gvTemp.Parent.FindControl("lblColltype")



        'gvUniqueID = gvTemp.UniqueID
        ''Dim lblTemp_AID As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblTemp_AID"), Label)
        'Dim lblTemp_AID As String = gvTemp.DataKeys(0).Value.ToString()
        'If e.CommandName = "Add" Then
        '    Try

        '    Catch ex As Exception
        '        ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" & ex.Message.ToString().Replace("'", "") & "');</script>")
        '    End Try
        'ElseIf e.CommandName = "View" Then
        '    Try

        '        'Context.Items("Temp_AID") = lblTemp_AID  'กำหนดเพื่อส่งค่าให้กับฟอร์มที่จะส่งค่าได้ด้านล่าง

        '        Context.Items("Req_Id") = Req_Id
        '        Context.Items("Hub_Id") = Hub_Id
        '        Context.Items("Temp_AID") = Temp_AID
        '        Context.Items("CollType_Id") = CollType_Id
        '        Server.Transfer("Appraisal_Price3_Conform.aspx")
        '    Catch ex As Exception
        '        ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" & ex.Message.ToString().Replace("'", "") & "');</script>")
        '    End Try
        'Else
        'End If


    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        Dim row As GridViewRow = e.Row
        Dim strSort As String = String.Empty

        ' Make sure we aren't in header/footer rows 
        If row.DataItem Is Nothing Then
            Return
        End If

        'Find Child GridView control 
        Dim gv As New GridView()
        gv = DirectCast(row.FindControl("GridView2"), GridView)

        'Check if any additional conditions (Paging, Sorting, Editing, etc) to be applied on child GridView 
        If gv.UniqueID = gvUniqueID Then
            gv.PageIndex = gvNewPageIndex
            gv.EditIndex = gvEditIndex
            'Check if Sorting used 
            If gvSortExpr <> String.Empty Then
                GetSortDirection()
                strSort = " ORDER BY " + String.Format("{0} {1}", gvSortExpr, gvSortDir)
            End If
            'Expand the Child grid 
            ClientScript.RegisterStartupScript([GetType](), "Expand", "<SCRIPT LANGUAGE='javascript'>expandcollapse('div" + DirectCast(e.Row.DataItem, DataRowView)("Temp_AID").ToString() + "','one');</script>")
        End If

        'Prepare the query for Child GridView by passing the Customer ID of the parent row 
        gv.DataSource = ChildDataSource(DirectCast(e.Row.DataItem, DataRowView)("Temp_AID"), strSort)
        'gv.DataSource = GET_PRICE3_DETAIL_LIST(DirectCast(e.Row.DataItem, DataRowView)("Temp_AID").ToString())
        gv.DataBind()

    End Sub


#End Region

#Region "GridView2 Event Handlers"
    Protected Sub GridView2_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Dim gvTemp As GridView = DirectCast(sender, GridView)
        gvUniqueID = gvTemp.UniqueID
        gvNewPageIndex = e.NewPageIndex
        GridView1.DataBind()
    End Sub

    Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then

            If DirectCast(e.Row.DataItem, DataRowView)("Temp_AID").ToString() = String.Empty Then
                e.Row.Visible = False
            End If
        End If

    End Sub

    Protected Sub GridView2_Sorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs)
        Dim gvTemp As GridView = DirectCast(sender, GridView)
        gvUniqueID = gvTemp.UniqueID
        gvSortExpr = e.SortExpression
        GridView1.DataBind()
    End Sub

    Protected Sub GridView2_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        If e.CommandName = "ViewPicture" Then
            Dim gvTemp As GridView = DirectCast(sender, GridView)
            gvUniqueID = gvTemp.UniqueID
            Dim lblcollid As Label = DirectCast(gvTemp.Rows.Item(0).FindControl("lblcoll_id"), Label)
            Response.Redirect("View_Picture_Appraisal.aspx")
        End If
    End Sub

    Protected Sub GridView2_SelectedIndexChanging(ByVal sender As Object, ByVal e As GridViewSelectEventArgs)
        'Dim str As String = ""
        Dim gvTemp As GridView = DirectCast(sender, GridView)
        Dim Req_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblReq_Id"), Label)
        Dim Hub_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblHub_Id"), Label)
        Dim lblTemp_AID As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblTemp_AID"), Label)
        Dim lblCollType_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblColltype"), Label)
        Dim Hid_ID As HiddenField = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("H_ID"), HiddenField)
        Dim lblColl_type As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblColltype"), Label)
        'Dim lblMethodNo As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).Parent.Parent.Parent.FindControl("lblMethodNo"), Label)
        'Dim lblMethodName As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).Parent.Parent.Parent.FindControl("lblMethodName"), Label)


        Context.Items("Req_Id") = Req_Id.Text
        Context.Items("Hub_Id") = Hub_Id.Text
        Context.Items("Temp_AID") = lblTemp_AID.Text
        Context.Items("ID") = Hid_ID.Value
        Context.Items("Coll_Type") = lblColl_type.Text
        'Context.Items("MethodNo") = lblMethodNo.Text
        'Context.Items("MethodName") = lblMethodName.Text
        Context.Items("SpecialAdd") = "เพิ่มกรณีปกติ"
        If lblColl_type.Text = 50 Then
            'Response.Redirect("Appraisal_Price3_Add_Colltype50.aspx?Req_id=" & Req_Id.Text & "&Hub_Id=" & Hub_Id.Text & "&Coll_Type=" & lblColl_type.Text & "&Temp_AID=" & lblTemp_AID.Text & "&ID=" & Hid_ID.Value)
            Server.Transfer("Appraisal_Price3_Add_Colltype50.aspx")
        ElseIf lblColl_type.Text = 70 Then
            'Response.Redirect("Appraisal_Price3_Add_Colltype70.aspx?Req_id=" & Req_Id.Text & "&Hub_Id=" & Hub_Id.Text & "&Coll_Type=" & lblColl_type.Text & "&Temp_AID=" & lblTemp_AID.Text & "&ID=" & Hid_ID.Value)
            Server.Transfer("Appraisal_Price3_Add_Colltype70.aspx")
        ElseIf lblColl_type.Text = 15 Then

        ElseIf lblColl_type.Text = 18 Then
            Server.Transfer("Appraisal_Price3_18.aspx")
        End If

        'MsgBox("Select Index Changing")
    End Sub
#End Region

    Protected Sub imgPrintPreview_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim ImgBtAdd As ImageButton = DirectCast(sender, ImageButton)
        Dim Req_Id As Label = ImgBtAdd.Parent.FindControl("lblReq_Id")
        Dim Hub_Id As Label = ImgBtAdd.Parent.FindControl("lblHub_Id")
        Dim Temp_AID As Label = ImgBtAdd.Parent.FindControl("lblTemp_AID")
        'Dim CollType_Id As Label = ImgBtAdd.Parent.FindControl("lblColltype")
        Context.Items("Req_Id") = Req_Id.Text
        Context.Items("Hub_Id") = Hub_Id.Text
        Context.Items("Temp_AID") = Temp_AID.Text
        'Context.Items("CollType_Id") = CollType_Id.Text

        Server.Transfer("Appraisal_Price3_Conform.aspx")
    End Sub

    Protected Sub imgaddplus_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim ImgBtAdd As ImageButton = DirectCast(sender, ImageButton)
        Dim Req_Id As Label = ImgBtAdd.Parent.FindControl("lblReq_Id")
        Dim Hub_Id As Label = ImgBtAdd.Parent.FindControl("lblHub_Id")
        Dim lblTemp_AID As Label = ImgBtAdd.Parent.FindControl("lblTemp_AID")
        Dim lblCollType_Id As Label = ImgBtAdd.Parent.FindControl("lblColltype")
        Dim lblUser_Id As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        'Context.Items("Req_Id") = Req_Id
        'Context.Items("Hub_Id") = Hub_Id
        'Context.Items("Temp_AID") = lblTemp_AID
        'Context.Items("CollType_Id") = lblCollType_Id
        Dim str As String
        'str = "Server.Transfer" & ("FileUpload_Price2.aspx")

        str = "FileUpload_Price2.aspx?Req_Id=" & Req_Id.Text & "&Hub_Id=" & Hub_Id.Text & "&Temp_AID=" & lblTemp_AID.Text & "&User_Id=" & lblUser_Id.Text
        s = "<script language=""javascript"">window.open('" + str + "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, copyhistory=no, directories=no, status=yes,height=350px,width=550px');</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType, "จัดกลุ่ม", s)

        'Server.Transfer("FileUpload_Price2.aspx")

        'MsgBox("Add Data " & lblTemp_AID.Text)
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim lblHub_Id As Label = TryCast(Me.Form.FindControl("lblHub_Id"), Label)
        hhfHub_Id.Value = lblHub_Id.Text
    End Sub

End Class
