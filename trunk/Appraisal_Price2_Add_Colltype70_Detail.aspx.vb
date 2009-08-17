Imports Appraisal_Manager
Partial Class Appraisal_Price2_Add_Colltype70_Detail
    Inherits System.Web.UI.Page

    Dim s As String
    Dim lblMessage As Label

    Protected Sub ImageSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSave.Click
        If LblDescription.Text = "SAVE" Then  'Save Data
            If txtBuilding_Struc.Text = String.Empty Or txtBuildFloor.Text = String.Empty Then
                Exit Sub
            End If
            Dim ObjP3_Detail As List(Of Cls_Price2_70_Detail) = GET_PRICE2_70_DETAIL(HiddenField4.Value, HiddenField1.Value, HiddenField2.Value, HiddenField3.Value, txtBuildFloor.Text)
            'ตรวจสอบว่ามีการให้ข้อมูลของชั้นดังกล่าวแล้วหรือไม่
            If ObjP3_Detail.Count = 0 Then  'ถ้ายังไม่มี
                ADD_PRICE2_70_DETAIL(HiddenField4.Value, HiddenField1.Value, HiddenField2.Value, HiddenField3.Value, CStr(txtBuildFloor.Text), txtBuilding_Struc.Text, _
                                    chkConcrete.Checked, chkGranite.Checked, chkParquet.Checked, chkCeramic.Checked, chkWood.Checked, ChkOther.Checked, txtOtherFloor.Text, _
                                    ChkBrickWall.Checked, CheckBlockbrickWall.Checked, ChkWoodWall.Checked, ChkOtherWall.Checked, txtOtherWall.Text, HiddenField5.Value, Now())
                GridView1.DataBind()
            Else  'ถ้ามีแล้วแจ้งเตือน
                s = "<script language=""javascript"">alert('มีข้อมูลของรายละเอียดชั้นดังกล่าวแล้ว');</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "แจ้งเตือน", s)
            End If


        Else  'Update data
            UPDATE_PRICE2_70_DETAIL(HiddenField4.Value, HiddenField1.Value, HiddenField2.Value, HiddenField3.Value, CStr(txtBuildFloor.Text), txtBuilding_Struc.Text, _
                                chkConcrete.Checked, chkGranite.Checked, chkParquet.Checked, chkCeramic.Checked, chkWood.Checked, ChkOther.Checked, txtOtherFloor.Text, _
                                ChkBrickWall.Checked, CheckBlockbrickWall.Checked, ChkWoodWall.Checked, ChkOtherWall.Checked, txtOtherWall.Text, HiddenField5.Value, Now())
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            HiddenField1.Value = CInt(Context.Items("Req_Id"))
            HiddenField2.Value = CInt(Context.Items("Hub_Id"))
            HiddenField3.Value = CInt(Context.Items("Temp_AID"))
            HiddenField4.Value = CInt(Context.Items("ID"))
            HiddenField5.Value = CStr(Context.Items("User_ID"))
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim row As GridViewRow = GridView1.SelectedRow
        Dim L1 As Label = DirectCast(row.FindControl("lblFloors"), Label)

        Dim Obj_P2_70D As List(Of Cls_Price2_70_Detail) = GET_PRICE2_70_DETAIL(HiddenField4.Value, HiddenField1.Value, HiddenField2.Value, HiddenField3.Value, L1.Text)
        If Obj_P2_70D.Count > 0 Then
            txtBuilding_Struc.Text = Obj_P2_70D.Item(0).Main_Construction
            txtBuildFloor.Text = Obj_P2_70D.Item(0).Floor
            chkConcrete.Checked = Obj_P2_70D.Item(0).Concrete
            chkGranite.Checked = Obj_P2_70D.Item(0).Granite
            chkParquet.Checked = Obj_P2_70D.Item(0).Parquet
            chkCeramic.Checked = Obj_P2_70D.Item(0).Ceramic
            chkWood.Checked = Obj_P2_70D.Item(0).Wood
            ChkOther.Checked = Obj_P2_70D.Item(0).Other
            txtOtherFloor.Text = Obj_P2_70D.Item(0).Other_Detail
            ChkBrickWall.Checked = Obj_P2_70D.Item(0).BrickWall
            CheckBlockbrickWall.Checked = Obj_P2_70D.Item(0).BlockBrickWall
            ChkWoodWall.Checked = Obj_P2_70D.Item(0).WoodWall
            ChkOtherWall.Checked = Obj_P2_70D.Item(0).OtherWall
            txtOtherWall.Text = Obj_P2_70D.Item(0).OtherWall_Detail
            LblDescription.Text = "Update"
        End If


    End Sub

    Protected Sub btnConfOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfOK.Click
        ImageSave_Click(ImageSave, Nothing)
        LblDescription.Text = "SAVE"
        txtBuilding_Struc.Text = ""
        txtBuildFloor.Text = ""
        chkConcrete.Checked = False
        chkGranite.Checked = False
        chkParquet.Checked = False
        chkCeramic.Checked = False
        chkWood.Checked = False
        ChkOther.Checked = False
        txtOtherFloor.Text = ""
        ChkBrickWall.Checked = False
        CheckBlockbrickWall.Checked = False
        ChkWoodWall.Checked = False
        ChkOtherWall.Checked = False
        txtOtherWall.Text = ""
        GridView1.DataBind()
    End Sub

    Protected Sub btnConfCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfCancel.Click
        ImageSave_Click(ImageSave, Nothing)
        'Response.Redirect("Appraisal_Price2_List.aspx")
        Context.Items("Req_Id") = HiddenField1.Value
        Context.Items("Hub_Id") = HiddenField2.Value
        Context.Items("Temp_AID") = HiddenField3.Value
        Context.Items("ID") = HiddenField4.Value
        Context.Items("Coll_Type") = "70"
        Server.Transfer("Appraisal_Price2_Add_Colltype70.aspx")
    End Sub

    Protected Sub ImgBack_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBack.Click
        Context.Items("Req_Id") = HiddenField1.Value
        Context.Items("Hub_Id") = HiddenField2.Value
        Context.Items("Temp_AID") = HiddenField3.Value
        Context.Items("ID") = HiddenField4.Value
        Context.Items("Coll_Type") = "70"
        Server.Transfer("Appraisal_Price2_Add_By_Colltype70_New.aspx")  'Appraisal_Price2_Add_By_Colltype70_New
    End Sub
End Class
