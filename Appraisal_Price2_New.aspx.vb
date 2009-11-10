Imports System
Imports System.Web
Imports System.Web.Services
Imports System.Threading
Imports System.Net
Imports System.Data
Imports System.Collections
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Math
Imports System.Linq
Imports Ravs.Factory.JSON
Imports Appraisal_Manager

Partial Class Appraisal_Price2_New
    Inherits System.Web.UI.Page
    Dim s As String
    Dim dt, dt_building, dt_condo As DataTable
    Dim gvUniqueID As String = String.Empty
    Dim ClassG_his As String
    '======
    Dim sumSubloan, condoSubTotal As Double
    Dim sumGrandloan, sumGrandcondo As Double
    Dim sumSubPercentclassg As Single
    Dim sumRow As Double
    Dim EmpId As String
    Dim Approve_Id As Label

    Private Sub check_Value_RadioButton()
        Dim cph As ContentPlaceHolder = TryCast(Me.Form.FindControl("ContentPlaceHolder1"), ContentPlaceHolder)
        Dim chk_string As String = ""
        Dim rdo1 As RadioButtonList = DirectCast(cph.FindControl("rdbAppraisal_Type"), RadioButtonList)
        'MsgBox(rdo1.Items.ToString)
        For Each li As ListItem In rdo1.Items
            If li.Selected = True Then
                chk_string = li.Text
            Else
                chk_string = chk_string & ""
            End If
        Next

        If chk_string = "" Then

            lit_Status.Text = "คุณไม่ได้เลือกวิธีการให้ราคา"
        ElseIf chk_string = "วิธีตลาด" Then
            lit_Status.Text = ""
            txtLand.Text = "0.00"
        Else
            'ต้องตรวจสอบว่ามีการให้รายละเอียดสิ่งปลูกสร้างหรือยัง
            lit_Status.Text = ""
        End If
    End Sub

    'Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
    '    If rdbAppraisal_Type.SelectedValue = 1 Then
    '        MsgBox(dt.Rows.Count)
    '        MsgBox(dt_building.Rows.Count)
    '    Else
    '    End If
    '    MsgBox("Save")
    'End Sub

    <System.Web.Script.Services.ScriptMethod()> _
    <System.Web.Services.WebMethod()> _
Public Shared Function ValidateCreditCard(ByVal creditCardNumber As String) As Boolean
        ' simulate a longer operation ... 
        System.Threading.Thread.Sleep(3000)

        Dim isValid As Boolean = False
        Try
            ' According to http://www.beachnet.com/~hstiles/cardtype.html, Visa card numbers must be 
            ' either 13 or 16 digits in length and the first number must be a 4 ... 
            If (creditCardNumber.Length = 11 OrElse creditCardNumber.Length = 13 OrElse creditCardNumber.Length = 16) AndAlso creditCardNumber(0) = "4"c Then
                Dim total As Integer = 0
                ' Double the value of alternate digits of the 
                ' primary account number beginning with the second digit from the right 
                For i As Integer = creditCardNumber.Length - 1 To 0 Step -1
                    Dim currentNumber As Integer = Convert.ToInt32(creditCardNumber(i).ToString())
                    If (i - creditCardNumber.Length) Mod 2 = 0 Then
                        ' Add the individual digits comprising the products obtained in 
                        Dim doubledValue As String = (currentNumber * 2).ToString()

                        For j As Integer = 0 To doubledValue.Length - 1
                            total += Convert.ToInt32(doubledValue(j).ToString())
                        Next
                    Else
                        ' just add the number to the running total 
                        total += currentNumber
                    End If
                Next

                isValid = (total Mod 10 = 0)
            End If
        Catch
        End Try

        Return isValid
    End Function

    <System.Web.Script.Services.ScriptMethod()> _
<System.Web.Services.WebMethod()> _
Public Shared Function ValidateSaveData(ByVal ReqId As String, ByVal HubId As String, ByVal Cif As String, ByVal Land As String, ByVal Building As String, ByVal Condo As String, ByVal CreateUser As String) As Boolean
        ' simulate a longer operation ... 
        System.Threading.Thread.Sleep(2000)

        Dim isValid As Boolean = False
        Dim TEMPAID As Integer
        Try

            TEMPAID = Appraisal_Manager.GET_TEMP_AID()
            UPDATE_TEMP_AID()
            ADD_PRICE2_MASTER_NEW(ReqId, HubId, Cif, TEMPAID, CDec(Land), CDec(Building), CDec(Condo), 0, 0, 0, 0, 0, "", CreateUser, "", CreateUser, Now())
            UPDATE_PRICE2_70_DETAIL_AND_PARTAKE_NEW(ReqId, HubId, TEMPAID)
            isValid = True
        Catch
            isValid = False
        End Try

        Return isValid
    End Function

    <System.Web.Script.Services.ScriptMethod()> _
<System.Web.Services.WebMethod()> _
Public Shared Function ValidateSaveLand(ByVal ReqId As String, _
                                        ByVal HubId As String, _
                                        ByVal SubCollType As String, _
                                        ByVal Chanode As String, _
                                        ByVal ProvinceCode As String, _
                                        ByVal Rai As String, _
                                        ByVal Ngan As String, _
                                        ByVal Wah As String, _
                                        ByVal SubUnit As String, _
                                        ByVal Unit_Price As String, _
                                        ByVal LandPrice As String, _
                                        ByVal CreateUser As String) As Boolean
        ' simulate a longer operation ... 
        System.Threading.Thread.Sleep(2000)

        Dim isValid As Boolean = False
        Try
            Dim ID As Integer
            'ส่งค่าไปขอ Id จาก ตาราง ID_50
            ID = GET_ID_18_50_70(50)
            UPDATE_ID_50()
            DELETE_PRICE2_50_BY_REQ_ID(ReqId, HubId)
            AddPRICE2_50(ID, CInt(ReqId), CInt(HubId), "", "", 0, CInt(SubCollType), Chanode, String.Empty, String.Empty, String.Empty, _
                         ProvinceCode, CInt(Rai), CInt(Ngan), CDec(Wah), String.Empty, 0, 0, 0, 0, 0, 0, 0, String.Empty, 0, String.Empty, 0, _
                         String.Empty, 0, 0, SubUnit, CDec(Unit_Price), CDec(LandPrice), CreateUser, Now())
            isValid = True
        Catch
            isValid = False
        End Try

        Return isValid
    End Function

    <System.Web.Script.Services.ScriptMethod()> _
<System.Web.Services.WebMethod()> _
Public Shared Function ValidateSaveDataBuilding(ByVal ReqId As String, _
ByVal HubId As String, _
ByVal SubCollType As String, _
ByVal Build_No As String, _
ByVal ProvinceCode As String, _
ByVal Chanode As String, _
ByVal Area As String, _
ByVal Unit_Price As String, _
ByVal Value_Price As String, _
ByVal Age As String, _
ByVal Persent1 As String, _
ByVal Persent2 As String, _
ByVal Persent3 As String, _
ByVal Deteriorate As String, _
ByVal Percent_Finish As String, _
ByVal Finish_Price As String, _
ByVal LandPrice As String, _
ByVal CreateUser As String) As Boolean
        ' simulate a longer operation ... 
        System.Threading.Thread.Sleep(2000)

        Dim isValid As Boolean = False
        Try
            Dim Cnt_Verify_Address As List(Of Price2_70_New) = GET_PRICE2_70_NEW_VERIFY_UPDATE(ReqId, HubId, Build_No)
            If SubCollType <= 45 Or SubCollType = 50 Then
                'สิ่งปลูกสร้าง
                If Cnt_Verify_Address.Count = 0 Then
                    Dim ID As Integer = GET_ID_18_50_70("70")
                    UPDATE_ID_70()
                    ADD_PRICE2_70_NEW(ID, ReqId, HubId, 0, _
                        SubCollType, Build_No, String.Empty, String.Empty, _
                        ProvinceCode, 0, String.Empty, 0, 0, 0, String.Empty, 0, _
                        String.Empty, String.Empty, 0, _
                        0, 0, String.Empty, String.Empty, Chanode, String.Empty, Area, CDec(Unit_Price), _
                        CDec(Value_Price), Age, CDec(Persent1), CDec(Persent2), CDec(Persent3), _
                        CDec(Deteriorate), CInt(Percent_Finish), CDec(Finish_Price), 0, 0, 0, _
                        0, 0, 0, 0, 0, 0, 0, _
                        String.Empty, 0, 0, CreateUser, Now())
                Else
                    'Update ข้อมูลเฉพาะสิ่งปลูกสร้างถ้าหากมีการเพิ่มส่วนต่อเติมก่อน
                    UPDATE_PRICE2_70_NEW_BUILDING(ReqId, HubId, 0, _
                        SubCollType, Build_No, String.Empty, String.Empty, _
                        ProvinceCode, 0, String.Empty, 0, 0, 0, String.Empty, 0, _
                        String.Empty, String.Empty, 0, _
                        0, 0, String.Empty, String.Empty, Chanode, String.Empty, Area, CDec(Unit_Price), _
                        CDec(Value_Price), Age, CDec(Persent1), CDec(Persent2), CDec(Persent3), _
                        CDec(Deteriorate), CInt(Percent_Finish), CDec(Finish_Price), CreateUser, Now())
                End If
            ElseIf SubCollType = 53 Then
                'ต่อเติม
                If Cnt_Verify_Address.Count = 0 Then
                    Dim ID As Integer = GET_ID_18_50_70("70")
                    UPDATE_ID_70()
                    ADD_PRICE2_70_NEW(ID, ReqId, HubId, 0, _
                        SubCollType, Build_No, String.Empty, String.Empty, _
                        ProvinceCode, 0, String.Empty, 0, 0, 0, String.Empty, 0, _
                        String.Empty, String.Empty, 0, _
                        0, 0, String.Empty, String.Empty, Chanode, String.Empty, 0, 0, _
                        0, 0, 0, 0, 0, _
                        0, 0, 0, Area, CDec(Unit_Price), CDec(Value_Price), _
                        Age, CDec(Persent1), CDec(Persent2), CDec(Persent3), CDec(Deteriorate), CInt(Percent_Finish), CDec(Finish_Price), _
                        String.Empty, 0, 0, CreateUser, Now())
                Else
                    'Update ข้อมูลเฉพาะส่วนต่อเติม
                    UPDATE_PRICE2_70_NEW_BUILDING_PLUS(ReqId, HubId, Build_No, Area, CDec(Unit_Price), CDec(Value_Price), _
                        Age, CDec(Persent1), CDec(Persent2), CDec(Persent3), CDec(Deteriorate), CInt(Percent_Finish), CDec(Finish_Price), _
                        CreateUser, Now())
                End If
            ElseIf SubCollType >= 54 And SubCollType <= 61 Then
                'ส่วนควบ
                'ตรวจเช็คว่ามีส่วนควบ ที่มีเลขคำขอ เลข Hub และ เลขที่บ้าน ที่ส่งมาแล้วในตารางแล้วหรือไม่ 

                Dim Price2_70 As List(Of Price2_70_New) = GET_PRICE2_70_NEW_VERIFY_UPDATE(ReqId, HubId, Build_No)
                Dim ID_Building As Integer
                If Price2_70.Count > 0 Then 'หาเลข Id ของสิ่งปลูกสร้างที่มีเลขคำขอ เลข Hub และ เลขที่บ้าน ตรงกัน
                    ID_Building = Price2_70.Item(0).ID
                    Dim Obj_P2_70_Partake As List(Of Price2_70_Partake) = GET_PRICE2_70_PARTAKE_CHECK(ReqId, HubId, Build_No, SubCollType)
                    If Obj_P2_70_Partake.Count = 0 Then  'ถ้าไม่มี
                        ADD_PRICE2_70_PARTAKE(ID_Building, ReqId, HubId, 0, "", SubCollType, Build_No, _
                                 Area, CDec(Unit_Price), CDec(Value_Price), Age, _
                                 CDec(Persent1), CDec(Persent2), CDec(Persent3), CDec(Deteriorate), _
                                 CInt(Percent_Finish), CDec(Value_Price) * (CInt(Percent_Finish) / 100), String.Empty, CreateUser, Now())
                    Else 'ถ้ามี
                        'Dim ID_Building As String = Obj_P2_70_Partake.Item(0).Id
                        Dim TEMP_AID As String = Obj_P2_70_Partake.Item(0).Temp_AID

                        UPDATE_PRICE2_70_PARTAKE(ID_Building, ReqId, HubId, TEMP_AID, "", SubCollType, Build_No, _
                                 Area, CDec(Unit_Price), CDec(Value_Price), Age, _
                                 CDec(Persent1), CDec(Persent2), CDec(Persent3), CDec(Deteriorate), _
                                 CInt(Percent_Finish), CDec(Value_Price) * (CInt(Percent_Finish) / 100), String.Empty, CreateUser, Now())
                    End If
                Else
                    'ID_Building = 0
                End If


            End If

            isValid = True
        Catch
            isValid = False
        End Try

        Return isValid
    End Function

    <System.Web.Script.Services.ScriptMethod()> _
<System.Web.Services.WebMethod()> _
Public Shared Function ValidateSaveDataCondo(ByVal ReqId As String, _
                                             ByVal HubId As String, _
                                             ByVal Reqister_Number As String, _
                                             ByVal Building_No As String, _
                                             ByVal Room_No As String, _
                                             ByVal Building_Name As String, _
                                             ByVal Province_Code As String, _
                                             ByVal Area As String, _
                                             ByVal Unit_Price As String, _
                                             ByVal Condo_Price As String, _
                                             ByVal CreateUser As String) As Boolean
        ' simulate a longer operation ... 
        System.Threading.Thread.Sleep(2000)

        Dim isValid As Boolean = False
        Try
            Dim ID As Integer = GET_ID_18_50_70("18")
            UPDATE_ID_18()
            ADD_PRICE2_18(ID, ReqId, HubId, String.Empty, String.Empty, 0, 46, 0, 0, _
               Room_No, Area, 0, Building_Name, String.Empty, Building_No, Reqister_Number, _
              0, String.Empty, Province_Code, String.Empty, 0, 0, _
              0, 0, 0, String.Empty, 0, String.Empty, 0, String.Empty, 0, 0, _
              0, 0, 0, 0, 0, 0, 0, 0, Unit_Price, Condo_Price, CreateUser, Now())
            UPDATE_Status_Appraisal_Request(ReqId, HubId, 5)
            isValid = True
        Catch
            isValid = False
        End Try

        Return isValid
    End Function

    <System.Web.Script.Services.ScriptMethod()> _
<System.Web.Services.WebMethod()> _
Public Shared Function Cancel() As Boolean
        ' simulate a longer operation ... 
        System.Threading.Thread.Sleep(1000)

        Dim isValid As Boolean = False
        'Try
        '    'Call Save Data
        '    isValid = True
        'Catch
        'End Try

        Return isValid
    End Function

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender

        lblReq_Id.Text = Request.QueryString("Req_Id")
        lblHub_Id.Text = Request.QueryString("Hub_Id")
        lblCif.Text = Request.QueryString("Cif")
        Approve_Id = TryCast(Me.Form.FindControl("lblUserID"), Label)
        lblApprove_Id.Text = Approve_Id.Text

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Request.QueryString("CollType") = 50 Then
                txtBuilding.Enabled = False
                btn_Building.Enabled = False
                txtCondo.Enabled = False
                btn_Condo.Enabled = False
                If (Session("land") Is Nothing) Then
                    dt = New DataTable
                    dt.Columns.Add(New DataColumn("Req_Id"))
                    dt.Columns.Add(New DataColumn("Hub_Id"))
                    dt.Columns.Add(New DataColumn("Colltype_Id"))
                    dt.Columns.Add(New DataColumn("Colltype_Name"))
                    dt.Columns.Add(New DataColumn("ProvinceCode"))
                    dt.Columns.Add(New DataColumn("ProvinceName"))
                    dt.Columns.Add(New DataColumn("Chanode"))
                    dt.Columns.Add(New DataColumn("Rai"))
                    dt.Columns.Add(New DataColumn("Ngan"))
                    dt.Columns.Add(New DataColumn("Wah"))
                    dt.Columns.Add(New DataColumn("SubUnit"))
                    dt.Columns.Add(New DataColumn("SubUnit_Name"))
                    dt.Columns.Add(New DataColumn("Unitprice"))
                    dt.Columns.Add(New DataColumn("Total"))
                    Me.Session("land") = dt
                Else
                    dt = Session("land")
                    dt.Clear()
                End If

            ElseIf Request.QueryString("CollType") = 70 Then
                txtCondo.Enabled = False
                btn_Condo.Enabled = False
                If (Session("land") Is Nothing) Then
                    dt = New DataTable
                    dt.Columns.Add(New DataColumn("Req_Id"))
                    dt.Columns.Add(New DataColumn("Hub_Id"))
                    dt.Columns.Add(New DataColumn("Colltype_Id"))
                    dt.Columns.Add(New DataColumn("Colltype_Name"))
                    dt.Columns.Add(New DataColumn("ProvinceCode"))
                    dt.Columns.Add(New DataColumn("ProvinceName"))
                    dt.Columns.Add(New DataColumn("Chanode"))
                    dt.Columns.Add(New DataColumn("Rai"))
                    dt.Columns.Add(New DataColumn("Ngan"))
                    dt.Columns.Add(New DataColumn("Wah"))
                    dt.Columns.Add(New DataColumn("SubUnit"))
                    dt.Columns.Add(New DataColumn("SubUnit_Name"))
                    dt.Columns.Add(New DataColumn("Unitprice"))
                    dt.Columns.Add(New DataColumn("Total"))
                    Me.Session("land") = dt

                Else
                    dt = Session("land")
                    dt.Clear()
                End If

                If (Session("building") Is Nothing) Then
                    dt_building = New DataTable
                    'dt_building.Columns.Add(New DataColumn("Req_Id"))
                    'dt_building.Columns.Add(New DataColumn("Hub_Id"))
                    dt_building.Columns.Add(New DataColumn("Colltype_Id"))
                    dt_building.Columns.Add(New DataColumn("Colltype_Name"))
                    dt_building.Columns.Add(New DataColumn("Chanode"))
                    dt_building.Columns.Add(New DataColumn("Build_No"))
                    dt_building.Columns.Add(New DataColumn("Area"))
                    dt_building.Columns.Add(New DataColumn("Unit_Price"))
                    dt_building.Columns.Add(New DataColumn("Value_Price"))
                    dt_building.Columns.Add(New DataColumn("Percent_Finish"))
                    dt_building.Columns.Add(New DataColumn("Finish_Price"))
                    dt_building.Columns.Add(New DataColumn("Age"))
                    dt_building.Columns.Add(New DataColumn("Percent1"))
                    dt_building.Columns.Add(New DataColumn("Percent2"))
                    dt_building.Columns.Add(New DataColumn("Percent3"))
                    dt_building.Columns.Add(New DataColumn("Total_Percent"))
                    dt_building.Columns.Add(New DataColumn("Deteriorate"))
                    dt_building.Columns.Add(New DataColumn("Total_Building"))
                    Me.Session("building") = dt_building
                Else
                    dt_building = Session("building")
                    dt_building.Clear()
                End If
            ElseIf Request.QueryString("CollType") = 18 Then
                txtLand.Enabled = False
                btn_Land.Enabled = False
                txtBuilding.Enabled = False
                btn_Building.Enabled = False
                If (Session("Condo") Is Nothing) Then
                    dt_condo = New DataTable
                    dt_condo.Columns.Add(New DataColumn("Register_No"))
                    dt_condo.Columns.Add(New DataColumn("Building_Number"))
                    dt_condo.Columns.Add(New DataColumn("AddressNo"))
                    dt_condo.Columns.Add(New DataColumn("BuildingName"))
                    dt_condo.Columns.Add(New DataColumn("ProvinceCode"))
                    dt_condo.Columns.Add(New DataColumn("ProvinceName"))
                    dt_condo.Columns.Add(New DataColumn("Condo_Area"))
                    dt_condo.Columns.Add(New DataColumn("UnitPrice"))
                    dt_condo.Columns.Add(New DataColumn("CondoPrice"))
                    Me.Session("Condo") = dt_condo
                Else
                    dt_condo = Session("Condo")
                    dt_condo.Clear()
                End If
            End If
        Else
            dt = Session("land")
            dt_building = Session("building")
            dt_condo = Session("Condo")
        End If


        'dt.Clear()
        'dt_building.Clear()
        'dt_condo.Clear()


    End Sub

    Protected Sub btn_ADD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ADD.Click

        Dim dr As DataRow = dt.NewRow()
        dr("Req_Id") = lblReq_Id.Text
        dr("Hub_Id") = lblHub_Id.Text
        dr("Colltype_Id") = DDLSubCollTypeLand.SelectedValue
        dr("Colltype_Name") = DDLSubCollTypeLand.SelectedItem
        dr("ProvinceCode") = ddlProvince.SelectedValue
        dr("ProvinceName") = ddlProvince.SelectedItem
        dr("Chanode") = txtChanode.Text
        dr("Rai") = txtRai.Text
        dr("Ngan") = txtNgan.Text
        dr("Wah") = txtWah.Text
        dr("SubUnit") = ddlSubUnit.SelectedValue
        dr("SubUnit_Name") = ddlSubUnit.SelectedItem
        dr("Unitprice") = txtPriceWah.Text
        dr("Total") = txtTotal0.Text
        dt.Rows.Add(dr)
        Dim Object_JSON_Class As JSON_Class = New JSON_Class()
        JSON_DataTable_Land.Value = Object_JSON_Class.JSON_DataTable(dt)
        GridView_Land.DataSource = dt
        GridView_Land.DataBind()

        Dim cph As ContentPlaceHolder = TryCast(Me.Form.FindControl("ContentPlaceHolder1"), ContentPlaceHolder)
        Dim dg As GridView = DirectCast(cph.FindControl("GridView_Land"), GridView) 'FindControl("GridView_Land")
        lblLandRow.Text = dg.Rows.Count
        Dim gvr_master As GridViewRow
        Dim LandTotal As Double
        For Each gvr_master In dg.Rows
            Dim Item As Label = gvr_master.FindControl("lblItem")
            Dim LandPrice As Label = gvr_master.FindControl("lblTotal")
            LandTotal = LandTotal + CDec(LandPrice.Text)
        Next
        txtLandTotal.Text = String.Format("{0:N2}", LandTotal)
        txtLand.Text = String.Format("{0:N2}", txtLandTotal.Text)
        GrandTotal()
        btn_Land_ModalPopupExtender.Show()
    End Sub

    Protected Sub btnMove_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cph As ContentPlaceHolder = TryCast(Me.Form.FindControl("ContentPlaceHolder1"), ContentPlaceHolder)
        Dim ImgBtmove As Button = DirectCast(sender, Button)
        Dim dg As GridView = DirectCast(cph.FindControl("GridView_Land"), GridView) 'FindControl("GridView_Land")
        Dim gvr_master As GridViewRow

        For Each gvr_master In dg.Rows
            Dim chk1 As CheckBox = gvr_master.FindControl("cb2")
            Dim Item As Label = gvr_master.FindControl("lblItem")
            Dim btn As Button = gvr_master.FindControl("btnMove")
            If chk1.Checked = True Then
                Try
                    dt.Rows.RemoveAt(gvr_master.DataItemIndex)
                    dt.AcceptChanges()
                    Dim Object_JSON_Class As JSON_Class = New JSON_Class()
                    JSON_DataTable_Land.Value = Object_JSON_Class.JSON_DataTable(dt)
                Catch ex As Exception
                    s = "<Script language=""javascript"">alert('ที่ดินเอาออกได้ที่ละแปลง');</Script>"
                    Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", s)
                End Try
            End If
            GridView_Land.DataSource = dt
            GridView_Land.DataBind()
        Next

        Dim LandTotal As Double = 0.0
        lblLandRow.Text = dg.Rows.Count
        For Each gvr_master In dg.Rows
            Dim LandPrice As Label = gvr_master.FindControl("lblTotal")
            LandTotal = LandTotal + CDec(LandPrice.Text)
        Next
        txtLandTotal.Text = String.Format("{0:N2}", LandTotal)
        txtLand.Text = String.Format("{0:N2}", txtLandTotal.Text)
        GrandTotal()
        btn_Land_ModalPopupExtender.Show()
    End Sub


    Protected Sub btn_Add_Building_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Add_Building.Click

        Dim dr As DataRow = dt_building.NewRow()
        dr("Colltype_Id") = DDLSubCollType.SelectedValue
        dr("Colltype_Name") = DDLSubCollType.SelectedItem
        dr("Chanode") = txtChanodeNo.Text
        dr("Build_No") = txtBuild_No.Text
        dr("Area") = txtBuildingArea.Text
        dr("Unit_Price") = String.Format("{0:N2}", txtBuildingUnitPrice.Text)
        dr("Value_Price") = String.Format("{0:N2}", txtBuildingPrice.Text)
        dr("Percent_Finish") = txtFinishPercent.Text
        dr("Finish_Price") = String.Format("{0:N2}", txtPriceNotFinish.Text)
        dr("Age") = txtBuildingAge.Text
        dr("Percent1") = txtBuildingPersent1.Text
        dr("Percent2") = txtBuildingPersent2.Text
        dr("Percent3") = txtBuildingPersent3.Text
        dr("Total_Percent") = String.Format("{0:N2}", txtBuildingTotalDeteriorate.Text)
        dr("Deteriorate") = String.Format("{0:N2}", txtBuildingPriceTotalDeteriorate.Text)
        dr("Total_Building") = String.Format("{0:N2}", (CDec(txtPriceNotFinish.Text) - CDec(txtBuildingPriceTotalDeteriorate.Text)))
        dt_building.Rows.Add(dr)

        Dim Object_JSON_Class As JSON_Class = New JSON_Class()
        JSON_DataTable_Building.Value = Object_JSON_Class.JSON_DataTable(dt_building)

        GridView_Building.DataSource = dt_building
        GridView_Building.DataBind()

        Dim cph As ContentPlaceHolder = TryCast(Me.Form.FindControl("ContentPlaceHolder1"), ContentPlaceHolder)
        Dim dg As GridView = DirectCast(cph.FindControl("GridView_Building"), GridView)
        lblBuildingRow.Text = dg.Rows.Count
        Dim gvr_master As GridViewRow
        Dim BuildingTotalPrice As Double
        For Each gvr_master In dg.Rows

            Dim BuildingPrice As Label = gvr_master.FindControl("lblTotal_Building")
            BuildingTotalPrice = String.Format("{0:N2}", (BuildingTotalPrice + CDec(BuildingPrice.Text)))

        Next
        'txtBuildingTotal_Price.Text = String.Format("{0:N2}", CDec(BuildingTotalPrice))
        'txtBuildingTotal_Price1.Text = String.Format("{0:N2}", Round((BuildingTotalPrice / 1000), System.MidpointRounding.AwayFromZero) * 1000)
        'txtBuilding.Text = String.Format("{0:N2}", txtBuildingTotal_Price1.Text)
        txtBuilding.Text = String.Format("{0:N2}", CDec(txtBuildingTotal_Price1.Text))
        GrandTotal()
        btn_Building_ModalPopupExtender.Show()

    End Sub

    Protected Sub btnMove_Building_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cph As ContentPlaceHolder = TryCast(Me.Form.FindControl("ContentPlaceHolder1"), ContentPlaceHolder)
        Dim ImgBtmove As Button = DirectCast(sender, Button)
        Dim dg As GridView = DirectCast(cph.FindControl("GridView_Building"), GridView) 'FindControl("GridView_Building")
        Dim gvr_master As GridViewRow

        For Each gvr_master In dg.Rows
            Dim chk1 As CheckBox = gvr_master.FindControl("cb_building")
            'Dim Item As Label = gvr_master.FindControl("lblItem")
            Dim btn As Button = gvr_master.FindControl("btnMove_Building")
            If chk1.Checked = True Then
                Try
                    dt_building.Rows.RemoveAt(gvr_master.DataItemIndex)
                Catch ex As Exception
                    s = "<Script language=""javascript"">alert('ที่สิ่งปลูกสร้างออกได้ที่ละ 1 สิ่งปลูกสร้าง');</Script>"
                    Page.ClientScript.RegisterStartupScript(Me.GetType, "Notice", s)
                End Try
            End If
            GridView_Building.DataSource = dt_building
            GridView_Building.DataBind()
        Next

        Dim BuildingTotalPrice As Double = 0.0
        For Each gvr_master In dg.Rows
            Dim BuilidngPrice As Label = gvr_master.FindControl("lblTotal_Building")
            BuildingTotalPrice = BuildingTotalPrice + CDec(BuilidngPrice.Text)
        Next
        'txtBuildingTotal_Price.Text = String.Format("{0:N2}", BuildingTotal)
        'txtBuilding.Text = String.Format("{0:N2}", txtBuildingTotal_Price.Text)
        'txtBuildingTotal_Price.Text = String.Format("{0:N2}", BuildingTotalPrice)
        txtBuildingTotal_Price1.Text = String.Format("{0:N2}", Round((BuildingTotalPrice / 1000), System.MidpointRounding.AwayFromZero) * 1000)
        txtBuilding.Text = String.Format("{0:N2}", txtBuildingTotal_Price1.Text)
        GrandTotal()
        btn_Building_ModalPopupExtender.Show()
    End Sub

    Protected Sub cb1_Checked(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb1 As CheckBox = sender
        For Each gdi As GridViewRow In GridView_Land.Rows
            If gdi.RowType = DataControlRowType.DataRow Then
                Dim cb2 As CheckBox = gdi.Cells(0).FindControl("cb2")
                cb2.Checked = cb1.Checked
            End If
        Next
    End Sub

    Protected Sub cb_Building_Checked(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb1 As CheckBox = sender
        For Each gdi As GridViewRow In GridView_Land.Rows
            If gdi.RowType = DataControlRowType.DataRow Then
                Dim cb2 As CheckBox = gdi.Cells(0).FindControl("cb_building")
                cb2.Checked = cb1.Checked
            End If
        Next
    End Sub

    Function CreateNewCell(ByVal text As String) As TableCell
        Dim newCell As New TableCell
        newCell.Text = text
        Return newCell
    End Function

    'Protected Sub GridView_Building_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView_Building.RowCommand
    '    If e.CommandName = "MoveRow" Then
    '        Dim gvTemp As GridView = DirectCast(sender, GridView)
    '        gvUniqueID = gvTemp.UniqueID
    '        MsgBox(gvTemp.DataItemIndex)
    '        'Dim lblcollid As Label = DirectCast(gvTemp.Rows.Item(0).FindControl("lblcoll_id"), Label)
    '        'Response.Redirect("View_Picture_Appraisal.aspx")
    '    End If
    'End Sub

    Protected Sub GridView_Building_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView_Building.DataBound
        'Dim cph As ContentPlaceHolder = TryCast(Me.Form.FindControl("ContentPlaceHolder1"), ContentPlaceHolder)
        'Dim dg As GridView = DirectCast(cph.FindControl("GridView_Building"), GridView) 'FindControl("GridView_Building")
        '  สร้าง SUB Total
        Dim oGridView As GridView = DirectCast(sender, GridView) 'DirectCast(cph.FindControl("GridView_Building"), GridView)
        Dim newRow = New GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal)

        'Dim gvTemp As GridView = DirectCast(sender, GridView)
        'Dim item As Integer = gvTemp.Rows.Count

        'เกิดขึ้น ณ Row สุดท้าย
        If oGridView.Rows.Count <> 0 Then
            newRow.Cells.Add(CreateNewCell("&nbsp"))
            newRow.Cells.Add(CreateNewCell(" SUBTOTAL "))
            newRow.Cells.Add(CreateNewCell(String.Format("{0:N2}", sumSubloan)))
            newRow.Cells.Add(CreateNewCell("&nbsp"))
            newRow.Cells.Add(CreateNewCell(" ยอดปัดเศษ "))
            newRow.Cells.Add(CreateNewCell(String.Format("{0:N2}", Round((sumSubloan / 1000), System.MidpointRounding.AwayFromZero) * 1000)))
            sumGrandloan += CDec(Round((sumSubloan / 1000), System.MidpointRounding.AwayFromZero) * 1000)
            'ยอดรวมของ Grand Total แต่ละเลขที่ชิ้นทรัพย์ ที่ไม่ใช่ชิ้นทรัพย์ชิ้นสุดท้าย ยกเว้นชิ้นทรัพย์ชิ้นเดียว
            txtBuildingTotal_Price1.Text = String.Format("{0:N2}", sumGrandloan)
            sumSubloan = 0
            newRow.ForeColor = Drawing.Color.Blue
            oGridView.Controls(0).Controls.Add(newRow)
            'MsgBox(sumGrandloan)
            ' สร้าง Grand Total
            'Dim gRow = New GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal)
            'gRow.Cells.Add(CreateNewCell("&nbsp"))
            'gRow.Cells.Add(CreateNewCell(" Grand Total "))
            'gRow.Cells.Add(CreateNewCell(sumGrandloan))
            'gRow.ForeColor = Drawing.Color.Red
            ''oGridView.Controls(0).Controls.Add(oGridViewRow)
            'oGridView.Controls(0).Controls.Add(gRow)
        Else
            txtBuildingTotal_Price1.Text = "0.00"
        End If
    End Sub

    Protected Sub GridView_Building_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView_Building.RowDataBound
        Dim row As GridViewRow = e.Row
        Dim strSort As String = String.Empty
        Dim oGridView As GridView = DirectCast(sender, GridView)

        If e.Row.RowType = DataControlRowType.DataRow Then
            sumRow += 1  ' --- นับจำนวนแถว
            If e.Row.RowIndex = 0 Then
                ClassG_his = DirectCast(e.Row.DataItem, DataRowView)(3).ToString() 'e.Row.Cells(0).Text
            Else
                'If ClassG_his = e.Row.Cells(3).Text Then
                If ClassG_his = DirectCast(e.Row.DataItem, DataRowView)(3).ToString() Then
                    e.Row.Cells(0).ForeColor = Drawing.Color.White
                Else
                    '---- เพิ่มแถว subtotal
                    Dim newRow = New GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal)
                    newRow.Cells.Add(CreateNewCell("&nbsp"))
                    newRow.Cells.Add(CreateNewCell(" SUBTOTAL "))
                    newRow.Cells.Add(CreateNewCell(String.Format("{0:N2}", sumSubloan)))
                    newRow.Cells.Add(CreateNewCell("&nbsp"))
                    newRow.Cells.Add(CreateNewCell(" ยอดปัดเศษ "))
                    newRow.Cells.Add(CreateNewCell(String.Format("{0:N2}", Round((sumSubloan / 1000), System.MidpointRounding.AwayFromZero) * 1000)))
                    'ยอดรวมของ Grand Total แต่ละเลขที่ชิ้นทรัพย์ ของเลขที่ชิ้นทรัพย์ชิ้นสุดท้าย
                    sumGrandloan += CDec(Round((sumSubloan / 1000), System.MidpointRounding.AwayFromZero) * 1000)
                    sumSubloan = 0
                    newRow.ForeColor = Drawing.Color.Blue
                    'oGridView.Controls(0).Controls.Add(oGridViewRow)
                    oGridView.Controls(0).Controls.AddAt(sumRow, newRow)
                    ClassG_his = DirectCast(e.Row.DataItem, DataRowView)(3).ToString() 'e.Row.Cells(0).Text
                    sumRow += 1
                End If
            End If
            sumSubloan += String.Format("{0:N2}", DirectCast(e.Row.DataItem, DataRowView)(15)) 'e.Row.Cells(2).Text                    
            txtBuildingTotal_Price1.Text = String.Format("{0:N2}", CDec(txtBuildingTotal_Price1.Text) + sumGrandloan)
            GrandTotal()
        End If
    End Sub

    Protected Sub GridView_Building_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView_Building.RowDeleting
        'MsgBox(e.RowIndex)
        Dim gvTemp As GridView = DirectCast(sender, GridView)
        Dim item As Integer = gvTemp.Rows.Count - 1
        'MsgBox(item)
        If e.RowIndex = item Then
            'MsgBox("Equeal")
            dt_building.Rows.RemoveAt(e.RowIndex)
            btn_Building_ModalPopupExtender.Show()
            GridView_Building.DataSource = dt_building
            GridView_Building.DataBind()
            dt_building.AcceptChanges()
            Dim Object_JSON_Class As JSON_Class = New JSON_Class()
            JSON_DataTable_Building.Value = Object_JSON_Class.JSON_DataTable(dt_building)
            lblBuildingRow.Text = gvTemp.Rows.Count
        Else
            dt_building.Rows.RemoveAt(e.RowIndex)
            btn_Building_ModalPopupExtender.Show()
            GridView_Building.DataSource = dt_building
            GridView_Building.DataBind()
            dt_building.AcceptChanges()
            Dim Object_JSON_Class As JSON_Class = New JSON_Class()
            JSON_DataTable_Building.Value = Object_JSON_Class.JSON_DataTable(dt_building)
            lblBuildingRow.Text = gvTemp.Rows.Count
        End If
        txtBuilding.Text = String.Format("{0:N2}", CDec(txtBuildingTotal_Price1.Text))
        GrandTotal()
    End Sub

    Private Sub GrandTotal()
        txtTotal.Text = String.Format("{0:N2}", CDec(txtLand.Text) + CDec(txtBuilding.Text) + CDec(txtCondo.Text))
    End Sub

    'Protected Sub btnMove_row_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim cph As ContentPlaceHolder = TryCast(Me.Form.FindControl("ContentPlaceHolder1"), ContentPlaceHolder)
    '    'Dim ImgBtmove As Button = DirectCast(sender, Button)
    '    Dim dg As GridView = DirectCast(cph.FindControl("GridView_Building"), GridView) 'FindControl("GridView_Building")
    '    Dim gvr_master As GridViewRow
    '    MsgBox(dg.Rows.Count)
    '    For Each gvr_master In dg.Rows
    '        MsgBox(gvr_master.DataItemIndex)
    '    Next
    'End Sub

    Protected Sub btn_Add_Condo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Add_Condo.Click

        Dim dr As DataRow = dt_condo.NewRow()
        dr("Register_No") = txtRegister_No.Text
        dr("Building_Number") = txtBuild_Number.Text
        dr("AddressNo") = txtAddressNo.Text
        dr("BuildingName") = txtBuildingName.Text
        dr("ProvinceCode") = ddlProvinceCondo.SelectedValue
        dr("ProvinceName") = ddlProvinceCondo.SelectedItem
        dr("Condo_Area") = txtArea.Text
        dr("UnitPrice") = txtUnitPrice.Text
        dr("CondoPrice") = txtCondoPrice.Text
        dt_condo.Rows.Add(dr)

        Dim Object_JSON_Class As JSON_Class = New JSON_Class()
        JSON_DataTable_Condo.Value = Object_JSON_Class.JSON_DataTable(dt_condo)

        GridView_Condo.DataSource = dt_condo
        GridView_Condo.DataBind()

        Dim cph As ContentPlaceHolder = TryCast(Me.Form.FindControl("ContentPlaceHolder1"), ContentPlaceHolder)
        Dim dg As GridView = DirectCast(cph.FindControl("GridView_Condo"), GridView) 'FindControl("GridView_Condo")
        lblCondoRow.Text = dg.Rows.Count

        txtCondo.Text = String.Format("{0:N2}", txtCondoTotal_Price.Text)
        GrandTotal()
        btn_Condo_ModalPopupExtender.Show()
    End Sub

    Protected Sub GridView_Condo_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView_Condo.DataBound
        Dim oGridView As GridView = DirectCast(sender, GridView) 'DirectCast(cph.FindControl("GridView_Building"), GridView)
        Dim newRow = New GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal)
        If oGridView.Rows.Count <> 0 Then
            sumGrandcondo += condoSubTotal
            'ยอดรวมของ Grand Total แต่ละเลขที่ชิ้นทรัพย์ ที่ไม่ใช่ชิ้นทรัพย์ชิ้นสุดท้าย ยกเว้นชิ้นทรัพย์ชิ้นเดียว
            txtCondoTotal_Price.Text = String.Format("{0:N2}", sumGrandcondo)
            condoSubTotal = 0
        Else
            txtCondoTotal_Price.Text = "0.00"
        End If
    End Sub

    Protected Sub GridView_Condo_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView_Condo.RowDataBound
        Dim row As GridViewRow = e.Row
        Dim strSort As String = String.Empty
        Dim oGridView As GridView = DirectCast(sender, GridView)

        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.RowIndex = 0 Then
                ClassG_his = DirectCast(e.Row.DataItem, DataRowView)(3).ToString() 'e.Row.Cells(0).Text
            Else
                'If ClassG_his = e.Row.Cells(3).Text Then
                If ClassG_his = DirectCast(e.Row.DataItem, DataRowView)(2).ToString() Then
                    e.Row.Cells(0).ForeColor = Drawing.Color.White
                Else
                    '---- เพิ่มแถว subtotal
                    'ยอดรวมของ Grand Total แต่ละเลขที่ชิ้นทรัพย์ ของเลขที่ชิ้นทรัพย์ชิ้นสุดท้าย
                    sumGrandcondo += condoSubTotal
                    condoSubTotal = 0
                    ClassG_his = DirectCast(e.Row.DataItem, DataRowView)(2).ToString() 'e.Row.Cells(0).Text
                    sumRow += 1
                End If
            End If
            condoSubTotal += String.Format("{0:N2}", DirectCast(e.Row.DataItem, DataRowView)(8))
            txtCondoTotal_Price.Text = String.Format("{0:N2}", CDec(txtCondoTotal_Price.Text) + condoSubTotal)
            GrandTotal()
        End If

    End Sub

    Protected Sub GridView_Condo_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView_Condo.RowDeleting
        Dim gvTemp As GridView = DirectCast(sender, GridView)
        Dim item As Integer = gvTemp.Rows.Count - 1
        'MsgBox(item)
        If e.RowIndex = item Then
            'MsgBox("Equeal")
            dt_condo.Rows.RemoveAt(e.RowIndex)
            dt_condo.AcceptChanges()
            Dim Object_JSON_Class As JSON_Class = New JSON_Class()
            JSON_DataTable_Condo.Value = Object_JSON_Class.JSON_DataTable(dt_condo)
            GridView_Condo.DataSource = dt_condo
            GridView_Condo.DataBind()
            btn_Condo_ModalPopupExtender.Show()
        Else
            dt_condo.Rows.RemoveAt(e.RowIndex)
            GridView_Condo.DataSource = dt_condo
            dt_condo.AcceptChanges()
            Dim Object_JSON_Class As JSON_Class = New JSON_Class()
            JSON_DataTable_Condo.Value = Object_JSON_Class.JSON_DataTable(dt_condo)
            GridView_Condo.DataBind()
            btn_Condo_ModalPopupExtender.Show()
        End If
        lblCondoRow.Text = dt_condo.Rows.Count
        txtCondo.Text = String.Format("{0:N2}", txtCondoTotal_Price.Text)
        GrandTotal()
    End Sub

End Class
