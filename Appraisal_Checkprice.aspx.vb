
Partial Class Appraisal_Checkprice
    Inherits System.Web.UI.Page
    Dim StrPath As String
    Dim s1 As String = Nothing

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindDropDown()
        End If

    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        hdfEmp_Id.Value = lbluserid.Text
    End Sub

    Protected Sub imgEditPosition_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label)
        Dim imgEditPosition As ImageButton = DirectCast(sender, ImageButton)
        Dim Req_Id As Label = imgEditPosition.Parent.FindControl("lblReq_Id")
        Dim Hub_Id As Label = imgEditPosition.Parent.FindControl("lblHub_Id")
        Dim Temp_AID As Label = imgEditPosition.Parent.FindControl("lblTemp_AID")

        StrPath = Request.ApplicationPath & "/CollDetail_Show_Position.aspx?Req_Id=" & Req_Id.Text & "&Hub_Id=" & Hub_Id.Text
        s1 = "<script language=""javascript"">window.open('" + StrPath + "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, directories=no, status=yes height=680px,width=850px');</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType, "แสดงพิกัด", s1)

    End Sub

    Protected Sub imgCollPic_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)

        Dim imgEditPosition As ImageButton = DirectCast(sender, ImageButton)
        Dim Req_Id As Label = imgEditPosition.Parent.FindControl("lblReq_Id")
        Dim Hub_Id As Label = imgEditPosition.Parent.FindControl("lblHub_Id")
        Dim Temp_AID As Label = imgEditPosition.Parent.FindControl("lblTemp_AID")

        StrPath = Request.ApplicationPath & "/Appraisal_Price2_Picture.aspx?Req_Id=" & Req_Id.Text & "&Hub_Id=" & Hub_Id.Text
        s1 = "<script language=""javascript"">window.open('" + StrPath + "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, directories=no, status=yes height=680px,width=850px');</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType, "รูปภาพหลักประกัน", s1)
    End Sub

    Sub BindDropDown()
        'รายการใน DropDownList
        DropDownListOption.Items.Insert(0, New ListItem("เลือกเงื่อนไขการค้นหา", ""))
        DropDownListOption.Items.Insert(1, New ListItem("CIF", "CIF"))
        DropDownListOption.Items.Insert(2, New ListItem("REQ ID(เลขคำขอประเมิน)", "Req_Id"))
        DropDownListOption.Items.Insert(3, New ListItem("รหัสศูนย์ประเมินราคา", "Hub_Id"))
    End Sub

    Protected Sub ButtonSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSearch.Click
        SetFilter()
    End Sub

    Sub SetFilter()
        Dim filterExpression As String = String.Empty
        If TextBoxSearch.Text <> String.Empty Then
            If DropDownListOption.Items(DropDownListOption.SelectedIndex).Value = "CIF" Then
                filterExpression = "CIF = " & TextBoxSearch.Text
            ElseIf DropDownListOption.Items(DropDownListOption.SelectedIndex).Value = "Req_Id" Then
                filterExpression = "Req_Id = " & TextBoxSearch.Text
            ElseIf DropDownListOption.Items(DropDownListOption.SelectedIndex).Value = "Hub_Id" Then
                filterExpression = "Hub_Id = " & TextBoxSearch.Text
            End If
        Else
            filterExpression = "Hub_ID <> 0"
        End If
        sdsCheckprice.FilterExpression = filterExpression

    End Sub
End Class
