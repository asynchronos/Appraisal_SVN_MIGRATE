Imports Appraisal_Manager
Imports System.Xml.Serialization
Imports System.Xml
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Partial Class Add_CollType50
    Inherits System.Web.UI.Page
    Dim str As String
    Dim s As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim DS As DataSet
        DS = Appraisal_Manager.Totolsize(Request.QueryString("Q_ID"), Request.QueryString("Temp_Aid"), Request.QueryString("CollType"))
        If DS.Tables(0).Rows.Count > 0 Then
            txtRai.Text = Format(DS.Tables(0).Rows.Item(0).Item("rai"), "#,##0.00")
            txtNgan.Text = Format(DS.Tables(0).Rows.Item(0).Item("ngan"), "#,##0.00")
            txtWah.Text = Format(DS.Tables(0).Rows.Item(0).Item("wah"), "#,##0.00")
        Else
            txtRai.Text = "0.00"
            txtNgan.Text = "0.00"
            txtWah.Text = "0.00"
        End If
    End Sub

    Protected Sub imgBtnSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnSave.Click
        'ใช้สำหรับ ในการเพิ่ม และ แก้ไข การประเมินของหลักประกัน Type 50
        'AddPRICE2_50(CInt(Request.QueryString("Q_ID")), CInt(Request.QueryString("Cif")), CInt(Request.QueryString("Temp_Aid")), CInt(DDLSubCollType.SelectedValue), vbNull, vbNull, vbNull, vbNull, _
        '                                              vbNull, CInt(txtRai.Text), CInt(txtNgan.Text), CInt(txtMeter.Text), _
        '                                              txtRoad.Text, CInt(ddlRoad_Detail.SelectedValue), CDec(txtMeter.Text), CInt(ddlRoad_Forntoff.SelectedValue), CDec(txtRoadWidth.Text), CInt(ddlSite.SelectedValue), CStr(txtSite_Detail.Text), CInt(ddlLand_State.SelectedValue), _
        '                                              txtLand_State_Detail.Text, CInt(ddlPublic_Utility.SelectedValue), txtPublic_Utility_Detail.Text, CInt(ddlBinifit.SelectedValue), _
        '                                              txtBinifit.Text, CInt(ddlTendency.SelectedValue), CInt(ddlBuySale_State.SelectedValue), _
        '                                              CInt(txtPriceWah.Text), CInt(txtTotal.Text), vbNull, Now())

        'เพิ่มกระบวนการบันทึกขั้นตอนการประเมิน
        Appraisal_Manager.INSERT_PROCESSID(Request.QueryString("Q_ID"), 5)

        s = "<script language=""javascript"">alert('บันทึกเสร็จสมบูรณ์ ระบบจะปิดหน้าต่างนี้');  window.close();</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType, "รับเรื่องประเมิน", s)
    End Sub
End Class
