Imports Appraisal_Manager
Imports System.Web
Imports System.Web.UI

Partial Class Appraisal_Price2_Add_By_Colltype
    Inherits System.Web.UI.Page
    Dim str As String
    Dim s As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblReq_Id.Text = Request.QueryString("Req_Id")
            lblHub_Id.Text = Request.QueryString("Hub_Id")
            lblId.Text = Request.QueryString("Id")
            'ตรวจสอบ ID ว่าเป็นการแก้ไข หรือ กำหนดไอดีใหม่
            If Request.QueryString("Id") Is Nothing Then
            Else
                Dim Obj_GetP50 As List(Of PRICE2_50) = GET_PRICE2_50(lblId.Text, lblReq_Id.Text, lblHub_Id.Text)
                If Obj_GetP50.Count > 0 Then
                    lblId.Text = Obj_GetP50.Item(0).Id
                    lblReq_Id.Text = Obj_GetP50.Item(0).Req_Id
                    lblHub_Id.Text = Obj_GetP50.Item(0).Hub_Id
                    DDLSubCollType.SelectedValue = Obj_GetP50.Item(0).MysubColl_ID
                    txtChanode.Text = Obj_GetP50.Item(0).Address_No
                    txtRai.Text = Obj_GetP50.Item(0).Rai
                    txtNgan.Text = Obj_GetP50.Item(0).Ngan
                    txtWah.Text = Obj_GetP50.Item(0).Wah
                    txtRoad.Text = Obj_GetP50.Item(0).Road
                    ddlRoad_Detail.SelectedValue = Obj_GetP50.Item(0).Road_Detail
                    txtMeter.Text = Obj_GetP50.Item(0).Road_Access
                    txtTumbon.Text = Obj_GetP50.Item(0).Tumbon
                    txtAmphur.Text = Obj_GetP50.Item(0).Amphur
                    ddlProvince.SelectedValue = Obj_GetP50.Item(0).Province
                    ddlLand_State.SelectedValue = Obj_GetP50.Item(0).Land_State
                    txtLand_State_Detail.Text = Obj_GetP50.Item(0).Land_State_Detail
                    ddlRoad_Forntoff.SelectedValue = Obj_GetP50.Item(0).Road_Frontoff
                    txtRoadWidth.Text = Obj_GetP50.Item(0).RoadWidth
                    ddlSite.Text = Obj_GetP50.Item(0).Site
                    txtSite_Detail.Text = Obj_GetP50.Item(0).Site_Detail
                    ddlPublic_Utility.SelectedValue = Obj_GetP50.Item(0).Public_Utility
                    txtPublic_Utility_Detail.Text = Obj_GetP50.Item(0).Public_Utility_Detail
                    ddlBinifit.SelectedValue = Obj_GetP50.Item(0).Binifit
                    txtBinifit.Text = Obj_GetP50.Item(0).Binifit_Detail
                    ddlTendency.SelectedValue = Obj_GetP50.Item(0).Tendency
                    ddlBuySale_State.SelectedValue = Obj_GetP50.Item(0).BuySale_State
                    txtPriceWah.Text = Obj_GetP50.Item(0).PriceWah
                    txtTotal.Text = Obj_GetP50.Item(0).PriceTotal1
                Else

                End If

            End If
        End If
    End Sub

    Protected Sub ImageSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSave.Click
        Dim lbluserid As Label = TryCast(Me.Form.FindControl("lblUserID"), Label) 'หา Control จาก Master Page ที่ control ไม่อยู่ใน  ContentPlaceHolder1 ของ Master Page
        Dim Id As Integer
        If lblId.Text = String.Empty Then
            Id = "0"
        Else
            Id = lblId.Text
        End If
        AddPRICE2_50(Id, CInt(lblReq_Id.Text), CInt(lblHub_Id.Text), 0, CInt(DDLSubCollType.SelectedValue), txtChanode.Text, String.Empty, txtTumbon.Text, txtAmphur.Text, _
                                                              ddlProvince.SelectedValue, CInt(txtRai.Text), CInt(txtNgan.Text), CInt(txtWah.Text), _
                                                              txtRoad.Text, CInt(ddlRoad_Detail.SelectedValue), CDec(txtMeter.Text), CInt(ddlRoad_Forntoff.SelectedValue), _
                                                              CDec(txtRoadWidth.Text), CInt(ddlSite.SelectedValue), CStr(txtSite_Detail.Text), CInt(ddlLand_State.SelectedValue), _
                                                              txtLand_State_Detail.Text, CInt(ddlPublic_Utility.SelectedValue), txtPublic_Utility_Detail.Text, CInt(ddlBinifit.SelectedValue), _
                                                              txtBinifit.Text, CInt(ddlTendency.SelectedValue), CInt(ddlBuySale_State.SelectedValue), _
                                                              CInt(txtPriceWah.Text), CInt(txtTotal.Text), lbluserid.Text, Now())

        Response.Redirect("Appraisal_Price2.aspx")

        'เพิ่มกระบวนการบันทึกขั้นตอนการประเมิน
        'INSERT_PROCESSID(Request.QueryString("Q_ID"), 5)

        's = "<script language=""javascript"">alert('บันทึกเสร็จสมบูรณ์ ระบบจะปิดหน้าต่างนี้');  window.close();</script>"
        'Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)
    End Sub
End Class
