Option Explicit On
'Option Strict On

Imports Appraisal_Manager
Imports System.Xml.Serialization
Imports System.Xml
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Win32

Partial Class Price2
    Inherits System.Web.UI.Page
    Dim SV As New SME_SERVICE.Service
    Dim P2 As Price2_ShortForm
    Private Itemsddl As List(Of Dropdown_Pro)

    Private Sub SearchCif()
        Dim obj As SME_SERVICE.Customer_Class
        If txtCif.Text <> String.Empty Then
            obj = SV.GetCifInfo(CInt(txtCif.Text))(0)
            lblCifName.Text = obj.cifName
            lblDepartName.Text = obj.departName
        End If
    End Sub

    'Private Sub InitLand_State()
    '    'Frontoff = New List(Of Dropdown_Pro)
    '    Itemsddl = New List(Of Dropdown_Pro)()
    '    Itemsddl.Add(New Dropdown_Pro("", "0"))
    '    Itemsddl.Add(New Dropdown_Pro("ถมแล้ว", "1"))
    '    Itemsddl.Add(New Dropdown_Pro("ยังไม่ถม", "2"))
    '    Itemsddl.Add(New Dropdown_Pro("ที่นา/ที่สวน/ที่ไร่", "3"))
    '    Itemsddl.Add(New Dropdown_Pro("ที่รกร้าง", "4"))
    '    Itemsddl.Add(New Dropdown_Pro("อื่น ๆ", "5"))

    '    ddlLand_State.DataSource = Itemsddl
    '    ddlLand_State.DataTextField = "Name"
    '    ddlLand_State.DataValueField = "Valuex"
    '    ddlLand_State.DataBind()
    'End Sub

    'Private Sub InitFrontoff()
    '    Itemsddl = New List(Of Dropdown_Pro)()
    '    Itemsddl.Add(New Dropdown_Pro("", "0"))
    '    Itemsddl.Add(New Dropdown_Pro("คอนกรีต", "1"))
    '    Itemsddl.Add(New Dropdown_Pro("ลาดยาง", "2"))
    '    Itemsddl.Add(New Dropdown_Pro("ลูกรัง", "3"))
    '    Itemsddl.Add(New Dropdown_Pro("หินคลุก", "4"))
    '    Itemsddl.Add(New Dropdown_Pro("ดิน", "5"))

    '    ddlRoad_Forntoff.DataSource = Itemsddl
    '    ddlRoad_Forntoff.DataTextField = "Name"
    '    ddlRoad_Forntoff.DataValueField = "Valuex"
    '    ddlRoad_Forntoff.DataBind()
    'End Sub

    'Private Sub InitSite()
    '    Itemsddl = New List(Of Dropdown_Pro)()
    '    Itemsddl.Add(New Dropdown_Pro("", "0"))
    '    Itemsddl.Add(New Dropdown_Pro("ย่านพักอาศัย", "1"))
    '    Itemsddl.Add(New Dropdown_Pro("ย่านการค้า", "2"))
    '    Itemsddl.Add(New Dropdown_Pro("ย่านอุตสาหกรรม", "3"))
    '    Itemsddl.Add(New Dropdown_Pro("อื่น ๆ", "4"))

    '    ddlSite.DataSource = Itemsddl
    '    ddlSite.DataTextField = "Name"
    '    ddlSite.DataValueField = "Valuex"
    '    ddlSite.DataBind()
    'End Sub

    'Private Sub InitPublic_Utility()
    '    Itemsddl = New List(Of Dropdown_Pro)()
    '    Itemsddl.Add(New Dropdown_Pro("", "0"))
    '    Itemsddl.Add(New Dropdown_Pro("ไฟฟ้า/น้ำประปา/น้ำบาดาล/ท่อระบายน้ำ", "1"))
    '    Itemsddl.Add(New Dropdown_Pro("อื่น ๆ", "2"))

    '    ddlPublic_Utility.DataSource = Itemsddl
    '    ddlPublic_Utility.DataTextField = "Name"
    '    ddlPublic_Utility.DataValueField = "Valuex"
    '    ddlPublic_Utility.DataBind()
    'End Sub

    'Private Sub InitBinifit()
    '    Itemsddl = New List(Of Dropdown_Pro)()
    '    Itemsddl.Add(New Dropdown_Pro("", "0"))
    '    Itemsddl.Add(New Dropdown_Pro("ที่อยู่อาศัย", "1"))
    '    Itemsddl.Add(New Dropdown_Pro("สำนักงาน", "2"))
    '    Itemsddl.Add(New Dropdown_Pro("ปล่อยว่าง/ร้าง", "3"))
    '    Itemsddl.Add(New Dropdown_Pro("ที่รกร้าง", "4"))
    '    Itemsddl.Add(New Dropdown_Pro("อื่น ๆ", "5"))

    '    ddlBinifit.DataSource = Itemsddl
    '    ddlBinifit.DataTextField = "Name"
    '    ddlBinifit.DataValueField = "Valuex"
    '    ddlBinifit.DataBind()
    'End Sub

    'Private Sub InitTendency()
    '    Itemsddl = New List(Of Dropdown_Pro)()
    '    Itemsddl.Add(New Dropdown_Pro("", "0"))
    '    Itemsddl.Add(New Dropdown_Pro("ดีขึ้น", "1"))
    '    Itemsddl.Add(New Dropdown_Pro("คงตัว", "2"))
    '    Itemsddl.Add(New Dropdown_Pro("ลดลง", "3"))

    '    ddlTendency.DataSource = Itemsddl
    '    ddlTendency.DataTextField = "Name"
    '    ddlTendency.DataValueField = "Valuex"
    '    ddlTendency.DataBind()
    'End Sub

    'Private Sub InitBuySale_State()
    '    Itemsddl = New List(Of Dropdown_Pro)()
    '    Itemsddl.Add(New Dropdown_Pro("", "0"))
    '    Itemsddl.Add(New Dropdown_Pro("คล่องตัวดี", "1"))
    '    Itemsddl.Add(New Dropdown_Pro("ปานกลาง", "2"))
    '    Itemsddl.Add(New Dropdown_Pro("ไม่คล่องตัว", "3"))


    '    ddlBuySale_State.DataSource = Itemsddl
    '    ddlBuySale_State.DataTextField = "Name"
    '    ddlBuySale_State.DataValueField = "Valuex"
    '    ddlBuySale_State.DataBind()
    'End Sub

    'Private Sub InitBuild_Character()
    '    Itemsddl = New List(Of Dropdown_Pro)()
    '    Itemsddl.Add(New Dropdown_Pro("", "0"))
    '    Itemsddl.Add(New Dropdown_Pro("บ้านเดี่ยว", "1"))
    '    Itemsddl.Add(New Dropdown_Pro("ทาวเฮาส์", "2"))
    '    Itemsddl.Add(New Dropdown_Pro("อื่น ๆ", "3"))

    '    ddlBuild_Character.DataSource = Itemsddl
    '    ddlBuild_Character.DataTextField = "Name"
    '    ddlBuild_Character.DataValueField = "Valuex"
    '    ddlBuild_Character.DataBind()
    'End Sub

    'Private Sub InitBuild_Construct()
    '    Itemsddl = New List(Of Dropdown_Pro)()
    '    Itemsddl.Add(New Dropdown_Pro("", "0"))
    '    Itemsddl.Add(New Dropdown_Pro("ตึก", "1"))
    '    Itemsddl.Add(New Dropdown_Pro("ครึ่งตึกครึ่งไม้", "2"))
    '    Itemsddl.Add(New Dropdown_Pro("ไม้", "3"))
    '    Itemsddl.Add(New Dropdown_Pro("อื่น ๆ", "4"))

    '    ddlBuild_Construct.DataSource = Itemsddl
    '    ddlBuild_Construct.DataTextField = "Name"
    '    ddlBuild_Construct.DataValueField = "Valuex"
    '    ddlBuild_Construct.DataBind()
    'End Sub

    'Private Sub InitRoof()
    '    Itemsddl = New List(Of Dropdown_Pro)()
    '    Itemsddl.Add(New Dropdown_Pro("", "0"))
    '    Itemsddl.Add(New Dropdown_Pro("กระเบื้องโมเนียร์", "1"))
    '    Itemsddl.Add(New Dropdown_Pro("กระเบี้องลอนคู่", "2"))
    '    Itemsddl.Add(New Dropdown_Pro("สังกะสี", "3"))
    '    Itemsddl.Add(New Dropdown_Pro("อื่น ๆ", "4"))

    '    ddlRoof.DataSource = Itemsddl
    '    ddlRoof.DataTextField = "Name"
    '    ddlRoof.DataValueField = "Valuex"
    '    ddlRoof.DataBind()
    'End Sub

    'Private Sub InitBuild_State()
    '    Itemsddl = New List(Of Dropdown_Pro)()
    '    Itemsddl.Add(New Dropdown_Pro("", "0"))
    '    Itemsddl.Add(New Dropdown_Pro("ดีมาก", "1"))
    '    Itemsddl.Add(New Dropdown_Pro("ดี", "2"))
    '    Itemsddl.Add(New Dropdown_Pro("ปานกลาง", "3"))
    '    Itemsddl.Add(New Dropdown_Pro("เก่า/ทรุดโทรม", "4"))
    '    Itemsddl.Add(New Dropdown_Pro("อื่น ๆ", "5"))

    '    ddlBuild_State.DataSource = Itemsddl
    '    ddlBuild_State.DataTextField = "Name"
    '    ddlBuild_State.DataValueField = "Valuex"
    '    ddlBuild_State.DataBind()
    'End Sub

    'Private Sub InitDocument()
    '    Itemsddl = New List(Of Dropdown_Pro)()
    '    Itemsddl.Add(New Dropdown_Pro("", "0"))
    '    Itemsddl.Add(New Dropdown_Pro("ใบอนุญาติปลูกสร้าง", "1"))
    '    Itemsddl.Add(New Dropdown_Pro("เรื่องทางภาระจำยอม", "2"))
    '    Itemsddl.Add(New Dropdown_Pro("อื่น ๆ", "3"))

    '    ddlDocument.DataSource = Itemsddl
    '    ddlDocument.DataTextField = "Name"
    '    ddlDocument.DataValueField = "Valuex"
    '    ddlDocument.DataBind()
    'End Sub

    'Private Sub InitRoad_Detail()
    '    Itemsddl = New List(Of Dropdown_Pro)()
    '    Itemsddl.Add(New Dropdown_Pro("", "0"))
    '    Itemsddl.Add(New Dropdown_Pro("ติดถนนเมน", "1"))
    '    Itemsddl.Add(New Dropdown_Pro("แยกซอย", "2"))
    '    Itemsddl.Add(New Dropdown_Pro("อื่น ๆ", "3"))

    '    ddlRoad_Detail.DataSource = Itemsddl
    '    ddlRoad_Detail.DataTextField = "Name"
    '    ddlRoad_Detail.DataValueField = "Valuex"
    '    ddlRoad_Detail.DataBind()
    'End Sub

    Protected Sub form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load

        If Not Page.IsPostBack Then
            'InitLand_State()
            'InitFrontoff()
            'InitSite()
            'InitBinifit()
            'InitBuild_Character()
            'InitBuild_Construct()
            'InitBuild_State()
            'InitBuySale_State()
            'InitDocument()
            'InitPublic_Utility()
            'InitRoad_Detail()
            'InitRoof()
            'InitTendency()

            lblQueueID.Text = Request.QueryString("Qid")
            txtCif.Text = Request.QueryString("Cif")
            SearchCif()
            P2 = Appraisal_Manager.GetPrice2(CInt(lblQueueID.Text))(0)
            If (IsDBNull(P2.Q_ID)) Or (P2.Q_ID = 0) Then
                Session("Mode") = "ADD"
                Label2.Visible = True
                txtBuilding_Name.Visible = True

            Else
                Session("Mode") = "Edit"
                DropDownList1.SelectedValue = P2.MysubColl_ID.ToString
                txtAddno.Text = P2.Address_No
                txtTumbon.Text = P2.Tumbon
                TxtAmphur.Text = P2.Amphur
                ddlProvince.SelectedValue = P2.Province.ToString
                txtRai.Text = P2.Rai.ToString
                txtNgan.Text = P2.Ngan.ToString
                txtSquaremeter.Text = P2.Wah.ToString
                txtRoad.Text = P2.Road
                ddlRoad_Detail.SelectedValue = P2.Road_Detail.ToString
                txtMeter.Text = P2.Road_Access.ToString
                txtRoof_Detail.Text = P2.Roof_Detail
                ddlRoad_Forntoff.SelectedValue = P2.Road_Frontoff.ToString
                txtRoadWidth.Text = P2.RoadWidth.ToString
                ddlSite.SelectedValue = P2.Site.ToString
                txtSite_Detail.Text = P2.Site_Detail
                ddlLand_State.SelectedValue = P2.Land_State.ToString
                txtLand_State_Detail.Text = Trim(P2.Land_State_Detail)
                ddlPublic_Utility.SelectedValue = P2.Public_Utility.ToString
                txtPublic_Utility_Detail.Text = Trim(P2.Public_Utility_Detail)
                ddlBinifit.SelectedValue = P2.Binifit.ToString
                ddlTendency.SelectedValue = P2.Tendency.ToString
                txtBinifit.Text = Trim(P2.Binifit_Detail)
                ddlBuySale_State.SelectedValue = P2.BuySale_State.ToString
                txtBuild_No.Text = P2.Build_No.ToString
                ddlBuild_Character.SelectedValue = P2.Build_Character.ToString
                txtFloor.Text = Trim(P2.Floors)
                txtItem.Text = P2.Item.ToString
                ddlBuild_Construct.SelectedValue = P2.Build_Construct.ToString
                ddlRoof.SelectedValue = P2.Roof.ToString
                txtRoof_Detail.Text = P2.Roof_Detail
                ddlBuild_State.SelectedValue = P2.Build_State.ToString
                txtBuild_State_Detail.Text = Trim(P2.Build_State_Detail)
                txtPriceItem1.Text = P2.PriceItem1.ToString
                txtPriceItem2.Text = P2.PriceItem2.ToString
                txtSize.Text = txtRai.Text & "-" & txtNgan.Text & "-" & txtSquaremeter.Text
                txtPriceWah.Text = CStr(Format(CDbl(P2.PriceWah.ToString), "#,##0.00"))
                'txtTotal1.Text = P2.PriceTotal1.ToString
                txtTotal1.Text = CStr(Format((CDbl(txtRai.Text) * 400) + (CDbl(txtNgan.Text) * 100) + (CDbl(txtSquaremeter.Text)) * CDbl(txtPriceWah.Text), "#,##0.00"))
                txtBuilding_Detail.Text = P2.Building_Detail
                txtTotal2.Text = P2.PriceTotal2.ToString
                txtTotal3.Text = P2.PriceTotal3.ToString
                txtGrandTotal.Text = P2.GrandTotal.ToString
                chkDoc1.Checked = CBool(P2.Doc1)
                chkDoc2.Checked = CBool(P2.Doc2)
                txtDoc_Detail.Text = P2.Doc_Detail
                ddlUserAppraisal.SelectedValue = P2.UserAppraisal.ToString
                ddlBossAppraisal.SelectedValue = P2.BossAppraisal.ToString
            End If
        End If
    End Sub

    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        'Dim l As String = Session("Mode").ToString
        Try
            If Session("Mode") Is "ADD" Then
                Appraisal_Manager.AddPrice2_ShortForm(CInt(lblQueueID.Text), CInt(txtCif.Text), CInt(DropDownList1.SelectedValue), txtAddno.Text, txtBuilding_Name.Text, txtTumbon.Text, TxtAmphur.Text, _
                                                      CInt(ddlProvince.SelectedValue), CInt(txtRai.Text), CInt(txtNgan.Text), CInt(txtSquaremeter.Text), _
                                                      txtRoad.Text, CInt(ddlRoad_Detail.SelectedValue), CDec(txtMeter.Text), CInt(ddlRoad_Forntoff.SelectedValue), CDec(txtRoadWidth.Text), CInt(ddlSite.SelectedValue), CStr(txtSite_Detail.Text), CInt(ddlLand_State.SelectedValue), _
                                                      txtLand_State_Detail.Text, CInt(ddlPublic_Utility.SelectedValue), txtPublic_Utility_Detail.Text, CInt(ddlBinifit.SelectedValue), _
                                                      txtBinifit.Text, CInt(ddlTendency.SelectedValue), CInt(ddlBuySale_State.SelectedValue), _
                                                      txtBuild_No.Text, CInt(ddlBuild_Character.SelectedValue), txtFloor.Text, CInt(txtItem.Text), CInt(ddlBuild_Construct.SelectedValue), CInt(ddlRoof.SelectedValue), _
                                                      txtRoof_Detail.Text, CInt(ddlBuild_State.SelectedValue), txtBuild_State_Detail.Text, CInt(txtPriceItem1.Text), _
                                                      CInt(txtPriceItem2.Text), Trim(txtSize.Text), CInt(txtPriceWah.Text), CInt(txtTotal1.Text), txtBuilding_Detail.Text, CInt(txtTotal2.Text), _
                                                      CInt(txtTotal3.Text), CInt(txtGrandTotal.Text), CInt(chkDoc1.Checked), CInt(chkDoc2.Checked), txtDoc_Detail.Text, CInt(ddlUserAppraisal.SelectedValue), CInt(ddlBossAppraisal.SelectedValue), lblUserID.Text, Now())

            ElseIf Session("Mode") Is "Edit" Then
                UpdatePrice2_ShortForm(CInt(lblQueueID.Text), CInt(txtCif.Text), CInt(DropDownList1.SelectedValue), txtAddno.Text, txtBuilding_Name.Text, txtTumbon.Text, TxtAmphur.Text, _
                                                      CInt(ddlProvince.SelectedValue), CInt(txtRai.Text), CInt(txtNgan.Text), CInt(txtSquaremeter.Text), _
                                                      txtRoad.Text, CInt(ddlRoad_Detail.SelectedValue), CDec(txtMeter.Text), CInt(ddlRoad_Forntoff.SelectedValue), CDec(txtRoadWidth.Text), CInt(ddlSite.SelectedValue), CStr(txtSite_Detail.Text), CInt(ddlLand_State.SelectedValue), _
                                                      txtLand_State_Detail.Text, CInt(ddlPublic_Utility.SelectedValue), txtPublic_Utility_Detail.Text, CInt(ddlBinifit.SelectedValue), _
                                                      txtBinifit.Text, CInt(ddlTendency.SelectedValue), CInt(ddlBuySale_State.SelectedValue), _
                                                      txtBuild_No.Text, CInt(ddlBuild_Character.SelectedValue), txtFloor.Text, CInt(txtItem.Text), CInt(ddlBuild_Construct.SelectedValue), CInt(ddlRoof.SelectedValue), _
                                                      txtRoof_Detail.Text, CInt(ddlBuild_State.SelectedValue), txtBuild_State_Detail.Text, CInt(txtPriceItem1.Text), _
                                                      CInt(txtPriceItem2.Text), Trim(txtSize.Text), CInt(txtPriceWah.Text), CInt(txtTotal1.Text), txtBuilding_Detail.Text, CInt(txtTotal2.Text), _
                                                      CInt(txtTotal3.Text), CInt(txtGrandTotal.Text), CInt(chkDoc1.Checked), CInt(chkDoc2.Checked), txtDoc_Detail.Text, CInt(ddlUserAppraisal.SelectedValue), CInt(ddlBossAppraisal.SelectedValue), lblUserID.Text, Now())
            End If

            '*******Create XML File *********************************************
            'Dim xmlDoc As StreamWriter = New StreamWriter(Server.MapPath("UploadedFiles/XML/" & lblQueueID.Text & ".xml"), False)
            'CreateDataset()
            'Dim ds As DataSet
            'ds = CreateDataset()
            'ds.WriteXml(xmlDoc, XmlWriteMode.WriteSchema)
            'lnkXml.NavigateUrl = ("UploadedFiles/XML/" & lblQueueID.Text & ".xml")
            '************************************************************************

            '*******Print From***********
            Dim str As String

            str = Request.ApplicationPath & "/Price2_PrintPreview.aspx?Q_ID=" & lblQueueID.Text
            Dim s As String = "<script language=""javascript"">window.open('" + str + "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, directories=no, status=yes,height=768px,width=1024px');</script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "printpopup", s)

        Catch ex As SqlException
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function CreateDataset() As DataSet

        'For Print Data Out
        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        MyConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("AppraisalConn").ConnectionString)

        MyDataAdapter = New SqlDataAdapter("GET_PRICE2", MyConnection)
        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Q_ID", SqlDbType.Int))
        MyDataAdapter.SelectCommand.Parameters("@Q_ID").Value = CInt(lblQueueID.Text)

        DS = New DataSet() 'Create a new DataSet to hold the records.
        MyDataAdapter.Fill(DS, "GET_PRICE2") 'Fill the DataSet with the rows returned.
        Return DS

    End Function


    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    Dim pageKey As RegistryKey = Registry.CurrentUser.OpenSubKey("software\microsoft\internet explorer\pagesetup", True)

    'End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim str As String
        'str = Request.ApplicationPath & "/Price2_PrintPreview.aspx?Q_ID=" & lblQueueID.Text
        'Dim s As String = "<script language=""javascript"">window.open('" + str + "','window','toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, directories=no, status=yes,height=768px,width=1024px');</script>"
        'Page.ClientScript.RegisterStartupScript(Me.GetType, "printpopup", s)

        'Session("ctrl") = Panel1
        'ClientScript.RegisterStartupScript(Me.GetType(), "onclick", "<script language=javascript>window.open('Testprint.aspx','PrintMe','height=300px,width=300px,scrollbars=1');</script>")
    End Sub

    'Protected Sub DropDownList1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.PreRender
    '    If Session("Mode") Is "ADD" Then
    '    Else
    '        If CInt(DropDownList1.SelectedValue) <= 4 Then
    '            Label2.Visible = False
    '            txtBuilding_Name.Visible = False
    '        Else
    '            Label2.Visible = True
    '            txtBuilding_Name.Visible = True
    '        End If
    '    End If

    'End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        If CInt(DropDownList1.SelectedValue) <= 4 Then
            Label2.Visible = False
            txtBuilding_Name.Visible = False
        Else
            Label2.Visible = True
            txtBuilding_Name.Visible = True
        End If
    End Sub

    'Protected Sub txtRai_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRai.TextChanged
    '    'txtSize.Text = txtRai.Text & "-" & txtNgan.Text & "-" & txtSquaremeter.Text
    '    txtSite_Detail.Text = CType(sender.parent.parent.FindControl("txtRai"), TextBox).Text & "-" & CType(sender.parent.parent.FindControl("txtNgan"), TextBox).Text & "-" & CType(sender.parent.parent.FindControl("txtSquaremeter"), TextBox).Text
    'End Sub

    'Protected Sub txtNgan_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNgan.TextChanged
    '    'txtSize.Text = txtRai.Text & "-" & txtNgan.Text & "-" & txtSquaremeter.Text
    '    txtSite_Detail.Text = CType(sender.parent.parent.FindControl("txtRai"), TextBox).Text & "-" & CType(sender.parent.parent.FindControl("txtNgan"), TextBox).Text & "-" & CType(sender.parent.parent.FindControl("txtSquaremeter"), TextBox).Text
    'End Sub

    'Protected Sub txtSquaremeter_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSquaremeter.TextChanged
    '    'txtSize.Text = txtRai.Text & "-" & txtNgan.Text & "-" & txtSquaremeter.Text
    '    txtSite_Detail.Text = CType(sender.parent.parent.FindControl("txtRai"), TextBox).Text & "-" & CType(sender.parent.parent.FindControl("txtNgan"), TextBox).Text & "-" & CType(sender.parent.parent.FindControl("txtSquaremeter"), TextBox).Text
    'End Sub

    'Protected Sub txtPriceWah_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPriceWah.TextChanged
    '    'txtTotal1.Text = ((CDec(txtRai.Text) * 400 + CDec(txtNgan.Text) * 100 + CDec(txtSquaremeter.Text)) * CDec(txtPriceWah.Text)).ToString
    '    txtTotal1.Text = (CDec(CType(sender.parent.parent.FindControl("txtRai"), TextBox).Text) * 400) + (CDec(CType(sender.parent.parent.FindControl("txtNgan"), TextBox).Text) * 100) + (CDec(CType(sender.parent.parent.FindControl("txtPriceWah"), TextBox).Text))
    'End Sub
End Class
