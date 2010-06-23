Imports Appraisal_Manager
Imports System.Data

Partial Class Print_Price3
    Inherits System.Web.UI.Page

    Dim Cnt_P3M As Object

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            'Dim Obj_P3M As List(Of clsPrice3_Master) = GET_PRICE3_MASTER(hdfReq_Id.Value, hdfTemp_AID.Value)
            'If Obj_P3M.Count > 0 Then
            lblYear.Text = Year(Now)
            lblSubject.Text = Context.Items("Inform_To")
            lblAID.Text = Context.Items("AID")
            lblCif.Text = Context.Items("Cif")
            lblCifName.Text = Context.Items("Cif_Name")
            lbReceive_Date.Text = Context.Items("Receive_Date")
            lbAppraisal_Date.Text = Context.Items("Appraisal_Date")
            lblBranch.Text = Context.Items("Branch")
            lblDetail1.Text = Context.Items("Detail1")
            lblDetail2.Text = Context.Items("Detail2")
            lblDetail3.Text = Context.Items("Detail3")
            lblDetail4.Text = Context.Items("Detail4")
            lblDetail5.Text = Context.Items("Detail5")
            Label22.Text = Context.Items("Label22")
            lblLandDetail1.Text = Context.Items("lblLandDetail1")
            lblLandDetail2.Text = Context.Items("lblLandDetail2")
            lblLandDetail3.Text = Context.Items("lblLandDetail3")
            lblLandDetail4.Text = Context.Items("lblLandDetail4")
            lblLandDetail5.Text = Context.Items("lblLandDetail5")
            lblLandDetail6.Text = Context.Items("lblLandDetail6")
            lblLandDetail7.Text = Context.Items("lblLandDetail7")
            lblLandDetail8.Text = Context.Items("lblLandDetail8")
            lblLandDetail9.Text = Context.Items("lblLandDetail9")
            lblLandDetail10.Text = Context.Items("lblLandDetail10")
            lblLandDetail11.Text = Context.Items("lblLandDetail11")
            lblProblem.Text = Context.Items("Problem")
            txtBuy_Sale_Comment.Text = Context.Items("Buy_Sale_Comment")
            lblAppraisal_Type.Text = Context.Items("Appraisal_Type")
            lblCollName.Text = Context.Items("CollName")
            lblSize.Text = Context.Items("Size")
            lblPriceWah.Text = Context.Items("PriceWah")
            lblBuilding_Detail.Text = Context.Items("Building_Detail")
            lblSubUnit.Text = Context.Items("Subunit")
            lblSubUnit0.Text = Context.Items("Subunit1")
            lblSubUnit1.Text = Context.Items("Subunit2")
            lblLand_Build.Text = Context.Items("Land_Build")
            txtLandTotal.Text = Context.Items("LandTotal")   'ราคาที่ดิน
            txtBuildingPrice.Text = Context.Items("BuildingPrice")   'ราคาสิ่งปลูกสร้าง
            txtSubTotal.Text = Context.Items("SubTotal")   'ราคารวม
            lblUnit_Price_Condo.Text = Context.Items("Unit_Price_Condo")
            txtGrandTotal.Text = Context.Items("GrandTotal") 'ราคารวมทั้งหมด
            lblThaiBaht.Text = Context.Items("ThaiBaht")
            lblComment.Text() = Context.Items("Comment")
            lblWarning.Text = Context.Items("Warning")
            txtWarning_Detail.Text = Context.Items("Warning_Detail")
            lblAppraisal_Name.Text = Context.Items("UserAppraisal")
            lblApprove1.Text = Context.Items("Approve1")
            lblApprove2.Text = Context.Items("Approve2")
            lblApprove3.Text = Context.Items("Approve3")
            lblPos_Approve1.Text = Context.Items("Prosition_Approve1")
            lblPos_Approve2.Text = Context.Items("Prosition_Approve2")
            lblPos_Approve3.Text = Context.Items("Prosition_Approve3")
            'Else

            'End If
        End If

    End Sub

    'Protected Sub ImageButtonReturn_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonReturn.Click
    '    Server.Transfer("Appraisal_Price3_List.aspx")
    'End Sub

    Protected Sub ImageButtonLandAttach_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonLandAttach.Click
        'Context.Items("Hub_Id") = hdfHub_Id.Value
        Context.Items("Req_Id") = LabelReqIdValue.Text
        Context.Items("Cif") = lblCif.Text
        Context.Items("CifName") = lblCifName.Text
        Server.Transfer("LandFileAttach.aspx")

    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        LabelReqIdValue.Text = Context.Items("Req_Id")
        'hdfTemp_AID.Value = Context.Items("Temp_AID")
    End Sub

End Class
