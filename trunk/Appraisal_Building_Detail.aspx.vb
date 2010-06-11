Imports Appraisal_Manager

Partial Class Appraisal_Building_Detail
    Inherits System.Web.UI.Page
    Dim s As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            HiddenField1.Value = Request.QueryString("Req_Id")
            HiddenField2.Value = Request.QueryString("Hub_Id")
            HiddenField3.Value = Request.QueryString("Temp_AID")
            HiddenField4.Value = Request.QueryString("Id")
            lblId.Text = Request.QueryString("Id")
            If Request.QueryString("Id") = String.Empty Then
                ImageSave.Enabled = False
            End If
        End If
    End Sub

    Protected Sub ImageSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSave.Click
        If LblDescription.Text = "SAVE" Then  'Save Data
            If txtBuilding_Struc.Text = String.Empty Or txtBuildFloor.Text = String.Empty Then
                Exit Sub
            End If
            Dim ObjP3_Detail As List(Of ClsPrice3_70_Detail) = GET_PRICE3_70_DETAIL(HiddenField4.Value, HiddenField1.Value, HiddenField2.Value, HiddenField3.Value, txtBuildFloor.Text)
            'ตรวจสอบว่ามีการให้ข้อมูลของชั้นดังกล่าวแล้วหรือไม่
            If ObjP3_Detail.Count = 0 Then  'ถ้ายังไม่มี
                ADD_PRICE2_PRICE3_70_DETAIL(HiddenField4.Value, HiddenField1.Value, HiddenField2.Value, HiddenField3.Value, txtBuildFloor.Text, txtBuilding_Struc.Text, _
                                    chkConcrete.Checked, chkGranite.Checked, chkParquet.Checked, chkCeramic.Checked, chkWood.Checked, ChkOther.Checked, txtOtherFloor.Text, _
                                    ChkBrickWall.Checked, CheckBlockbrickWall.Checked, ChkWoodWall.Checked, ChkOtherWall.Checked, txtOtherWall.Text, HiddenField5.Value, Now())
                GridView1.DataBind()
            Else  'ถ้ามีแล้วแจ้งเตือน
                s = "<script language=""javascript"">alert('มีข้อมูลของรายละเอียดชั้นดังกล่าวแล้ว');</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "แจ้งเตือน", s)
            End If

        Else  'Update data
            UPDATE_PRICE2_PRICE3_70_DETAIL(HiddenField4.Value, HiddenField1.Value, HiddenField2.Value, HiddenField3.Value, txtBuildFloor.Text, txtBuilding_Struc.Text, _
                                chkConcrete.Checked, chkGranite.Checked, chkParquet.Checked, chkCeramic.Checked, chkWood.Checked, ChkOther.Checked, txtOtherFloor.Text, _
                                ChkBrickWall.Checked, CheckBlockbrickWall.Checked, ChkWoodWall.Checked, ChkOtherWall.Checked, txtOtherWall.Text, HiddenField5.Value, Now())
            GridView1.DataBind()
        End If
    End Sub
End Class
