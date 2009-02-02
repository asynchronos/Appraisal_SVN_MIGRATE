Imports Appraisal_Manager
Imports System.Web
Imports System.Web.UI

Partial Class Appraisal_Price2_Add_By_Colltype70
    Inherits System.Web.UI.Page

    Protected Sub ImageSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSave.Click
        'Insert Data
        Dim lblHub As Label = TryCast(Me.Form.FindControl("lblHub_Id"), Label)
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label) 'หา Control จาก Master Page ที่ control ไม่อยู่ใน  ContentPlaceHolder1
        Dim Id As Integer
        If lblId.Text = String.Empty Then
            Id = "0"
        Else
            Id = lblId.Text
        End If

        AddPRICE2_70(Id, CInt(lblReq_Id.Text), CInt(lblHub_Id.Text), txtAID.Text, txtCID.Text, 0, _
                        CInt(DDLSubCollType.SelectedValue), txtBuild_No.Text, txtTumbon.Text, txtAmphur.Text, _
                        ddlProvince.SelectedValue, ddlBuild_Character.SelectedValue, _
                        txtFloor.Text, txtItem.Text, ddlBuild_Construct.SelectedValue, _
                        ddlRoof.SelectedValue, txtRoof_Detail.Text, ddlBuild_State.SelectedValue, _
                        txtBuild_State_Detail.Text, txtBuilding_Detail.Text, txtPriceTotal1.Text, _
                        chkDoc1.Checked, chkDoc2.Checked, txtDoc_Detail.Text, String.Empty, lbluserid.Text, Now())
        Response.Redirect("Appraisal_Price2.aspx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblReq_Id.Text = Request.QueryString("Req_Id")
            lblHub_Id.Text = Request.QueryString("Hub_Id")
            lblId.Text = Request.QueryString("Id")
            hdfCif.Value = Request.QueryString("Cif").PadLeft(16, "0")
            If Request.QueryString("Id") Is Nothing Then
                'Do Someting
            Else
                Dim Obj_Price_70 As List(Of PRICE2_70) = GET_PRICE2_70(lblId.Text, lblReq_Id.Text, lblHub_Id.Text)
                If Obj_Price_70.Count > 0 Then
                    lblId.Text = Obj_Price_70.Item(0).ID
                    lblReq_Id.Text = Obj_Price_70.Item(0).Req_Id
                    lblHub_Id.Text = Obj_Price_70.Item(0).Hub_Id
                    txtAID.Text = Obj_Price_70.Item(0).AID
                    txtCID.Text = Obj_Price_70.Item(0).CID
                    DDLSubCollType.SelectedValue = Obj_Price_70.Item(0).MysubColl_ID
                    txtBuild_No.Text = Obj_Price_70.Item(0).Build_No
                    txtTumbon.Text = Obj_Price_70.Item(0).Tumbon
                    txtAmphur.Text = Obj_Price_70.Item(0).Amphur
                    ddlProvince.SelectedValue = Obj_Price_70.Item(0).Province
                    ddlBuild_Character.SelectedValue = Obj_Price_70.Item(0).Build_Character
                    txtFloor.Text = Obj_Price_70.Item(0).Floors
                    txtItem.Text = Obj_Price_70.Item(0).Item
                    ddlBuild_Construct.SelectedValue = Obj_Price_70.Item(0).Build_Construct
                    ddlRoof.SelectedValue = Obj_Price_70.Item(0).Roof
                    txtRoof_Detail.Text = Obj_Price_70.Item(0).Roof_Detail
                    ddlBuild_State.SelectedValue = Obj_Price_70.Item(0).Build_State
                    txtBuild_State_Detail.Text = Obj_Price_70.Item(0).Build_State_Detail
                    txtBuilding_Detail.Text = Obj_Price_70.Item(0).Building_Detail
                    txtPriceTotal1.Text = Obj_Price_70.Item(0).PriceTotal1
                    chkDoc1.Checked = Obj_Price_70.Item(0).Doc1
                    chkDoc2.Checked = Obj_Price_70.Item(0).Doc2
                    txtDoc_Detail.Text = Obj_Price_70.Item(0).Doc_Detail
                End If
            End If
        End If
        Dim CollType As String = "070"
        Dim s1 As String = Nothing
        s1 += "window.open('AID_CID_List.aspx"
        s1 += "?cif=" & hdfCif.Value
        s1 += "&CollType=" & CollType
        s1 += "&txtAID=" & txtAID.ClientID
        s1 += "&txtCID=" & txtCID.ClientID
        s1 += "&txtSubCollType=" & DDLSubCollType.ClientID
        s1 += "&txtBuilding_No=" & txtBuild_No.ClientID
        s1 += "&txtDistrict=" & txtTumbon.ClientID
        s1 += "&txtAmphur=" & txtAmphur.ClientID
        s1 += "&txtProvince=" & ddlProvince.ClientID
        imSearchAID.Attributes.Add("onclick", s1 & "','pop', 'width=800, height=500');")
        txtAID.Attributes.Add("onfocus", "this.blur();")  ' set textbox to readonly 
        txtCID.Attributes.Add("onfocus", "this.blur();")  ' set textbox to readonly 
    End Sub

End Class
