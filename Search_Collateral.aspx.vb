Imports System.Data

Partial Class Search_Collateral
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddAndRemoveDynamicControls()
    End Sub

    Private Sub AddAndRemoveDynamicControls()
        'Determine which control fired the postback event.  

        Dim c As Control = GetPostBackControl(Page)

        If Not IsNothing(c) Then
            'If the add button was clicked, increase the count to let the page know we want
            'to display an additional user control
            If c.ID.ToString = "btnAdd" Then
                ltlCount.Text = Convert.ToInt16(ltlCount.Text) + 1
            End If
        End If

        'Be sure everything in the placeholder control is cleared out
        ph1.Controls.Clear()

        Dim ControlID As Integer = 0

        'Since these are dynamic user controls, re-add them every time the page loads.
        For i As Integer = 0 To (Convert.ToInt16(ltlCount.Text) - 1)
            Dim DynamicUserControl As UserControl_Dynamic_Field = LoadControl("UserControl_Dynamic_Field.ascx")


            'If this particular control id has been deleted from the page, DO NOT use it again.  If we do, it will
            'pick up the viewstate data from the old item that had this control id, instead of generating
            'a completely new control.  Instead, increment the control id so we're guaranteed to get a "new"
            'control that doesn't have any lingering information in the viewstate.            
            While InDeletedList("uc" & ControlID) = True
                ControlID += 1
            End While

            'Note that if the item has not been deleted from the page, we DO want it to use the same control id
            'as it used before, so it will automatically maintain the viewstate information of the user control
            'for us.
            DynamicUserControl.ID = "uc" & ControlID

            'Add an event handler to this control to raise an event when the delete button is clicked
            'on the user control
            AddHandler DynamicUserControl.RemoveUserControl, AddressOf Me.HandleRemoveUserControl

            'Finally, add the user control to the panel
            ph1.Controls.Add(DynamicUserControl)

            'Increment the control id for the next round through the loop
            ControlID += 1
        Next
    End Sub

    Private Function InDeletedList(ByVal ControlID As String) As Boolean
        'Determine if the passed in user control id has been stored in the list of controls that
        'were previously deleted off the page
        Dim DeletedList() As String = ltlRemoved.Text.Split("|")
        For i As Integer = 0 To DeletedList.GetLength(0) - 1
            If ControlID.ToLower = DeletedList(i).ToLower Then
                Return True
            End If
        Next
        Return False
    End Function

    Sub HandleRemoveUserControl(ByVal sender As Object, ByVal e As EventArgs)
        'This handles delete event fired from the user control

        'Get the user control that fired this event, and remove it
        Dim DynamicUserControl As UserControl_Dynamic_Field = sender.parent
        ph1.Controls.Remove(sender.parent)

        'Keep a pipe delimited list of which user controls were removed.  This will increase the 
        'viewstate size if the user keeps removing dynamic controls, but under normal use
        'this is such a small increase in size that it shouldn't be an issue.
        ltlRemoved.Text &= DynamicUserControl.ID & "|"

        'Also, now that we've removed a user control decrement the count of total user controls on the page
        ltlCount.Text = Convert.ToInt16(ltlCount.Text) - 1
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        'Handled in page load
    End Sub

    Protected Sub btnDisplayValues_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplayValues.Click
        'ltlValues.Text = ""
        'Dim where_condition As String = ""
        'Dim Where_String As String = ""
        'Dim str As String = ""
        'Dim Cnt As Integer = 1

        'For Each c As Control In ph1.Controls
        '    'Find the specific user control that we added to this placeholder, and then get the selected values
        '    'for the dropdownlist, checkbox, and textbox and print them to the screen.
        '    If c.GetType.Name.ToLower = "usercontrol_dynamic_field_ascx" Then
        '        Dim uc As UserControl = CType(c, UserControl)
        '        Dim tbx1 As TextBox = uc.FindControl("txtOption")
        '        Dim ddl1 As DropDownList = uc.FindControl("ddl1")

        '        Dim sb As New System.Text.StringBuilder
        '        If ddl1.SelectedValue = "เลขคำขอประเมิน" Then
        '            where_condition = "Appraisal_Request.Req_Id"
        '        ElseIf ddl1.SelectedValue = "AID" Then
        '            where_condition = "Price3_Master.AID"
        '        ElseIf ddl1.SelectedValue = "CIF" Then
        '            where_condition = "Appraisal_Request.cif"
        '        ElseIf ddl1.SelectedValue = "ตำบล/แขวง" Then
        '            where_condition = "Tumbon"
        '        ElseIf ddl1.SelectedValue = "อำเภอ/เขต" Then
        '            where_condition = "Amphur"
        '        ElseIf ddl1.SelectedValue = "จังหวัด" Then
        '            where_condition = "Prov_Name"
        '        End If

        '        If Cnt = 1 Then
        '            If where_condition = "Tumbon" Or where_condition = "Amphur" Or where_condition = "Prov_Name" Then
        '                sb.Append(where_condition & " Like " & "'" & tbx1.Text & "%'")
        '            Else
        '                sb.Append(where_condition & " = " & tbx1.Text)
        '            End If
        '        Else
        '            If where_condition = "Tumbon" Or where_condition = "Amphur" Or where_condition = "Prov_Name" Then
        '                sb.Append(" AND " & where_condition & " Like " & "'" & tbx1.Text & "%'")
        '            Else
        '                sb.Append(" AND " & where_condition & " = " & tbx1.Text)
        '            End If
        '        End If

        '        'sb.Append("<hr />")
        '        'ltlValues.Text &= sb.ToString

        '        str &= sb.ToString
        '        Cnt += 1
        '    End If
        'Next
        'If str = String.Empty Then
        '    'Message Notice
        '    ltlValues.Text = "เลือกเงื่อนไขการค้นหาก่อน"
        '    lblWhere.Text = "Appraisal_Request.Req_Id = 0"
        '    GridView1.DataBind()
        'Else
        '    'ltlValues.Text = ltlValues.Text
        '    lblWhere.Text = str
        '    GridView1.DataBind()
        'End If
        Condition_Search()
    End Sub

    'Find the control that caused the postback.
    'I got this code from http://www.ryanfarley.com/blog/archive/2005/03/11/1886.aspx

    Public Function GetPostBackControl(ByVal page As Page) As Control
        Dim control As Control = Nothing

        Dim ctrlname As String = page.Request.Params.[Get]("__EVENTTARGET")
        If Not IsNothing(ctrlname) And ctrlname <> String.Empty Then
            control = page.FindControl(ctrlname)
        Else
            For Each ctl As String In page.Request.Form
                Dim c As Control = page.FindControl(ctl)
                If TypeOf c Is System.Web.UI.WebControls.Button Then
                    control = c
                    Exit For
                End If
            Next
        End If
        Return control
    End Function

    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As GridViewSelectEventArgs)
        Dim gvTemp As GridView = DirectCast(sender, GridView)
        Dim Req_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblReq_Id"), Label)
        Dim Status_Id As HiddenField = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("HiddenStatus_Id"), HiddenField)
        'Dim Hub_Id As Label = DirectCast(gvTemp.Rows.Item(e.NewSelectedIndex).FindControl("lblHub_id"), Label)

        lblReqId.Text = Req_Id.Text
        up1.Update()
        If CInt(Status_Id.Value) >= 97 Then
            mdlPopup.Hide()
        Else
            mdlPopup.Show()
        End If

    End Sub

    Protected Sub imgLocation_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        'CommandName="Select"
        'onclick="imgLocation_Click" 
        'Dim gvTemp As GridView = DirectCast(sender, GridView)
        Dim imgLocation As Button = DirectCast(sender, Button)
        'Dim Req_Id As Label = imgLocation.Parent.FindControl("lblReq_Id")

        'lblReqId.Text = Req_Id.Text
        imgLocation.Attributes.Add("onclick", "return loadMark_Location_By_Condition(" & lblWhere.Text & ");")
        up1.Update()
        mdlPopup.Show()
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If CInt(DirectCast(e.Row.DataItem, DataRowView)("Status_Id").ToString()) >= 97 Then
                'MsgBox(CInt(DirectCast(e.Row.DataItem, DataRowView)("Status_Id").ToString()))
                Dim StatusName As Label = DirectCast(e.Row.Cells(3).FindControl("lblStatus_Name"), Label)
                Dim Ib As ImageButton = DirectCast(e.Row.Cells(11).FindControl("imgLocation"), ImageButton)
                Ib.Attributes.Add("onclick", "return alertMessage('" & StatusName.Text & "');")
            Else
                If DirectCast(e.Row.DataItem, DataRowView)("Req_Id").ToString() = String.Empty Then
                    'e.Row.Visible = False
                Else
                    '
                    Dim Req_ID As Object = DirectCast(e.Row.DataItem, DataRowView)("Req_Id").ToString()
                    Dim Ib As ImageButton = DirectCast(e.Row.Cells(11).FindControl("imgLocation"), ImageButton)
                    Ib.Attributes.Add("onclick", "return loadMark_Location('" & Req_ID & "');")

                End If
            End If

        End If

    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        Condition_Search()
    End Sub

    Protected Sub btnMapLocationAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMapLocationAll.Click

        up1.Update()
        mdlPopup.Show()

    End Sub

    Private Sub Condition_Search()
        ltlValues.Text = ""
        Dim where_condition As String = ""
        Dim Where_String As String = ""
        Dim str As String = ""

        Dim Cnt As Integer = 1
        btnMapLocationAll.Enabled = True
        For Each c As Control In ph1.Controls
            'Find the specific user control that we added to this placeholder, and then get the selected values
            'for the dropdownlist, checkbox, and textbox and print them to the screen.
            If c.GetType.Name.ToLower = "usercontrol_dynamic_field_ascx" Then
                Dim uc As UserControl = CType(c, UserControl)
                Dim tbx1 As TextBox = uc.FindControl("txtOption")
                Dim ddl1 As DropDownList = uc.FindControl("ddl1")

                Dim sb As New System.Text.StringBuilder
                If ddl1.SelectedValue = "เลขคำขอประเมิน" Then
                    where_condition = "Appraisal_Request.Req_Id"
                ElseIf ddl1.SelectedValue = "AID" Then
                    where_condition = "Price3_Master.AID"
                ElseIf ddl1.SelectedValue = "CIF" Then
                    where_condition = "Appraisal_Request.cif"
                ElseIf ddl1.SelectedValue = "ตำบล/แขวง" Then
                    where_condition = "View_Address_Groupby_Req_Id.Tumbon"
                ElseIf ddl1.SelectedValue = "อำเภอ/เขต" Then
                    where_condition = "View_Address_Groupby_Req_Id.Amphur"
                ElseIf ddl1.SelectedValue = "จังหวัด" Then
                    where_condition = "Prov_Name"
                End If

                If Cnt = 1 Then
                    If where_condition = "View_Address_Groupby_Req_Id.Tumbon" Or where_condition = "View_Address_Groupby_Req_Id.Amphur" Or where_condition = "Prov_Name" Then
                        sb.Append(where_condition & " Like " & "\'" & tbx1.Text & "%\'")
                    Else
                        sb.Append(where_condition & " = " & tbx1.Text)
                    End If
                Else
                    If where_condition = "View_Address_Groupby_Req_Id.Tumbon" Or where_condition = "View_Address_Groupby_Req_Id.Amphur" Or where_condition = "Prov_Name" Then
                        sb.Append(" AND " & where_condition & " Like " & "\'" & tbx1.Text & "%\'")
                    Else
                        sb.Append(" AND " & where_condition & " = " & tbx1.Text)
                    End If
                End If

                'sb.Append("<hr />")
                'ltlValues.Text &= sb.ToString
                str &= sb.ToString
                Cnt += 1
            End If
        Next
        If str = String.Empty Then
            'Message Notice
            ltlValues.Text = "เลือกเงื่อนไขการค้นหาก่อน"
        Else
            'ltlValues.Text = str
            lblWhere.Text = str
            'lblWhere2.Text = str
            If RadioButtonList1.SelectedValue = 0 Then
                lblWhere.Text = str
            ElseIf RadioButtonList1.SelectedValue = 1 Then
                lblWhere.Text += " AND CollType = " & "50"
            ElseIf RadioButtonList1.SelectedValue = 2 Then
                lblWhere.Text += " AND CollType = " & "70"
            ElseIf RadioButtonList1.SelectedValue = 3 Then
                lblWhere.Text += " AND CollType = " & "18"
            Else
                lblWhere.Text = str
            End If

            'เลือกช่วงราคาหลักประกัน
            If ddlPrice_Length.SelectedValue = 0 Then
                lblWhere.Text = lblWhere.Text
            ElseIf ddlPrice_Length.SelectedValue = 1 Then
                lblWhere.Text += " AND Price3_Master.Land_Building_Price Between " & "0" & " AND " & "500000"
            ElseIf ddlPrice_Length.SelectedValue = 2 Then
                lblWhere.Text += " AND Price3_Master.Land_Building_Price Between " & "500001" & " AND " & "1000000"
            ElseIf ddlPrice_Length.SelectedValue = 3 Then
                lblWhere.Text += " AND Price3_Master.Land_Building_Price Between " & "1000001" & " And " & "3000000"
            ElseIf ddlPrice_Length.SelectedValue = 4 Then
                lblWhere.Text += " AND Price3_Master.Land_Building_Price Between " & "3000001" & " And " & "5000000"
            ElseIf ddlPrice_Length.SelectedValue = 5 Then
                lblWhere.Text += " AND Price3_Master.Land_Building_Price Between " & "5000001" & " AND " & "10000000"
            ElseIf ddlPrice_Length.SelectedValue = 6 Then
                lblWhere.Text += " AND Price3_Master.Land_Building_Price > " & "10000000"
            End If
            lblWhere2.Text = ""
            lblWhere2.Text = lblWhere.Text.Replace("\"c, "")  'เปลี่ยนค่า "\" เป็นค่าว่าง

            Try
                GridView1.DataBind()
                Session("Condition") = lblWhere2.Text
                btnMapLocationAll.Attributes.Add("onclick", "return loadMark_Location_By_Condition('" & lblWhere.Text & "');")
            Catch ex As Exception
                Throw New Exception(ex.Message & " : " & ex.StackTrace)
            End Try

        End If
    End Sub

    Protected Sub ddlPrice_Length_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPrice_Length.SelectedIndexChanged
        Condition_Search()
    End Sub

End Class
