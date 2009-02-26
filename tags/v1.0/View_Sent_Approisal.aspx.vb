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

Partial Class View_Sent_Approisal
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

    Private Function ChildDataSource(ByVal strQueueId As Integer, ByVal strSort As String) As SqlDataSource
        'Session("Mode") = "Edit"
        'Dim culture As CultureInfo = New CultureInfo("th-TH", True)
        'Dim culture2 As CultureInfo = New CultureInfo("en-US", True)
        'Dim d1 As Date = DateTime.Parse(Session("Assessyear"), culture, DateTimeStyles.NoCurrentDateDefault)

        Dim strQRY As String = ""
        Dim dsTemp As New SqlDataSource
        Dim conn As String = "server=172.19.54.2;Database=Appraisal;User ID=sa;Password=sa0123"

        dsTemp.ConnectionString = conn
        strQRY = "Select D.Q_ID,D.coll_id,isnull(cd.detail1,'-') Detail1,cd.Prov_Name,isnull(cd.detail2,'-')Detail2 From Sent_Appraisal_Detail D INNER JOIN Sent_Appraisal_Master M ON  D.Q_ID = M.Q_ID INNER JOIN Bay01.dbo.COLL_ID_DISTINCT CD ON d.coll_Id = Cd.Coll_ID WHERE D.Q_ID = " & strQueueId & " AND M.Cif = CD.CIF "
        'strQRY = "SELECT Q_ID,Cif,Coll_id FROM Sent_Appraisal_Detail WHERE Q_ID = " & strQueueId & "" + strSort
        dsTemp.SelectCommand = strQRY
        Return dsTemp
    End Function

#Region "GridView1 Event Handlers"

    'Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
    '    ''MsgBox(sender.GetType)
    '    Dim gvTemp As GridView = DirectCast(sender, GridView)
    '    Dim Qid As Label = DirectCast(gvTemp.Rows.Item(gvTemp.SelectedRow.RowIndex).FindControl("lblQid"), Label)
    '    Dim Cif As Label = DirectCast(gvTemp.Rows.Item(gvTemp.SelectedRow.RowIndex).FindControl("lblCif"), Label)
    '    If e.CommandName = "operation" Then
    '        gvUniqueID = gvTemp.UniqueID
    '        Dim ddlOperation As DropDownList = DirectCast(gvTemp.Rows.Item(gvTemp.SelectedRow.RowIndex).FindControl("ddlOperation"), DropDownList)
    '        If ddlOperation.SelectedValue = 1 Then
    '            Response.Redirect("colldetail.aspx")
    '        ElseIf ddlOperation.SelectedValue = 2 Then
    '            Response.Redirect("Price2.aspx?Qid=" & Qid.Text & "&Cif=" & Cif.Text)
    '        Else
    '            Response.Redirect("Price3.aspx")
    '        End If
    '    End If


    'End Sub

    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
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
            ClientScript.RegisterStartupScript([GetType](), "Expand", "<SCRIPT LANGUAGE='javascript'>expandcollapse('div" + DirectCast(e.Row.DataItem, DataRowView)("Q_ID").ToString() + "','one');</script>")
        End If

        'Prepare the query for Child GridView by passing the Customer ID of the parent row 
        gv.DataSource = ChildDataSource(DirectCast(e.Row.DataItem, DataRowView)("Q_ID").ToString(), strSort)
        gv.DataBind()

        'ในกรณีเมื่อ Client  Click ที่ Checkbox จะเข้าไปทำงาน Javascript ที่ ฝั่ง Html ใน Function ชื่อ checkScore
        'gv.Attributes.Add("onclick", "checkScore(this," + DirectCast(e.Row.DataItem, DataRowView)("Question_Answer").ToString() + ")")

    End Sub

    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
        Dim str As String = ""
        Dim gvTemp As GridView = DirectCast(sender, GridView)
        Dim Qid As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblQid"), Label)
        Dim Cif As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblCif"), Label)
        Dim status As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("LabelStatus_Name"), Label)
        Dim createDate As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("LabelCreate_Date"), Label)

        gvUniqueID = gvTemp.UniqueID

        'MsgBox(gvTemp.SelectedRow.FindControl("ddlOperation"))
        Dim ddlOperation As DropDownList = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("ddlOperation"), DropDownList)

        If ddlOperation.SelectedValue = 0 Then  'กำหนดวันรับเรื่องการประเมิน
            If Trim(status.Text) <> "รับเรื่องการประเมิน" Then
                str = Request.ApplicationPath & "/receive_appraisal.aspx?Qid=" & Qid.Text & "&receive_date=" & createDate.Text
                s = "<script language=""javascript"">window.open('" + str + "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, directories=no, status=yes,height=260px,width=220px');</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)
            Else
                s = "<script language=""javascript"">alert('คุณได้กำหนดวันรับเรื่องการประเมินแล้ว');</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "จัดกลุ่ม", s)
            End If

        ElseIf ddlOperation.SelectedValue = 1 Then  'กำหนดกลุ่ม Coll ID
            'Dim status As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("LabelStatus_Name"), Label)

            If Trim(status.Text) = "รับเรื่องการประเมิน" Then
                str = Request.ApplicationPath & "/CID_2_PreAID.aspx?Qid=" & Qid.Text
                s = "<script language=""javascript"">window.open('" + str + "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, directories=no, status=yes,height=400px,width=650px');</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "จัดกลุ่ม", s)
            Else
                s = "<script language=""javascript"">alert('คุณยังไม่ได้กำหนดวันรับเรื่อง ให้ดำเนินการกำหนดวันรับเรื่องก่อน');</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "จัดกลุ่ม", s)
            End If

        ElseIf ddlOperation.SelectedValue = 2 Then
            Response.Redirect("colldetail.aspx")
        ElseIf ddlOperation.SelectedValue = 3 Then
            'Response.Redirect("Price2.aspx?Qid=" & Qid.Text & "&Cif=" & Cif.Text)
            Response.Redirect("Define_SecondPrice.aspx?Qid=" & Qid.Text & "&Cif=" & Cif.Text)
        Else
            Response.Redirect("Price3.aspx?Qid=" & Qid.Text & "&Cif=" & Cif.Text)
        End If
        'End If
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

            If DirectCast(e.Row.DataItem, DataRowView)("Q_ID").ToString() = String.Empty Then
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


    Protected Sub GridView2_RowCreated(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        'If e.Row.RowType = DataControlRowType.DataRow Then
        '    Dim lblcoll_id As Label = CType(e.Row.FindControl("lblcoll_id"), Label)
        '    Dim lblDetail1 As Label = CType(e.Row.FindControl("lblDetail1"), Label)
        '    Dim lblProv_Name As Label = CType(e.Row.FindControl("lblProv_Name"), Label)
        '    Dim lblDetail2 As Label = CType(e.Row.FindControl("lblDetail2"), Label)
        '    'Dim imgbtn1 As ImageButton

        '    lblcoll_id.Text = DataBinder.Eval(e.Row.DataItem, "Coll_id").ToString
        '    lblDetail1.Text = DataBinder.Eval(e.Row.DataItem, "Detail1").ToString
        '    lblProv_Name.Text = DataBinder.Eval(e.Row.DataItem, "Prov_Name").ToString
        '    lblDetail2.Text = DataBinder.Eval(e.Row.DataItem, "Detail2").ToString

        'End If
    End Sub

#End Region

    Protected Sub DDL_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim D1 As DropDownList = DirectCast(sender, DropDownList)
        If Not Page.IsPostBack Then
            D1.Items.Add(New ListItem("รับเรื่องการประเมิน", 0))
            D1.Items.Add(New ListItem("กำหนดกลุ่ม COLL ID", 1))
            For i = 2 To 4
                'D1.Items.Add("ให้ราคาประเมินหลักประกันครั้งที่ " & i)
                D1.Items.Add(New ListItem("ให้ราคาประเมินหลักประกันครั้งที่ " & i - 1, i))
            Next
        End If
    End Sub

    'Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
    '    Dim gvTemp As GridView = DirectCast(sender, GridView)
    '    Dim Qid As Label = DirectCast(gvTemp.Rows.Item(gvTemp.SelectedRow.RowIndex).FindControl("lblQid"), Label)
    '    Dim Cif As Label = DirectCast(gvTemp.Rows.Item(gvTemp.SelectedRow.RowIndex).FindControl("lblCif"), Label)
    '    'If e.CommandName = "operation" Then
    '    gvUniqueID = gvTemp.UniqueID
    '    'MsgBox(gvTemp.SelectedRow.FindControl("ddlOperation"))
    '    Dim ddlOperation As DropDownList = DirectCast(gvTemp.Rows.Item(gvTemp.SelectedRow.RowIndex).FindControl("ddlOperation"), DropDownList)
    '    'Dim ddloperation As DropDownList = DirectCast(GridView1.RowsDirectCast(gvTemp.Rows.Item(8).FindControl("ddlOperation"), DropDownList))
    '    If ddlOperation.SelectedValue = 1 Then
    '        Response.Redirect("colldetail.aspx")
    '    ElseIf ddlOperation.SelectedValue = 2 Then
    '        Response.Redirect("Price2.aspx?Qid=" & Qid.Text & "&Cif=" & Cif.Text)
    '    Else
    '        Response.Redirect("Price3.aspx")
    '    End If
    '    'End If
    'End Sub

End Class
