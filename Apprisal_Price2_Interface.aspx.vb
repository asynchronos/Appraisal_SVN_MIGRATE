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
Imports Appraisal_Manager


Partial Class Apprisal_Price2_Interface
    Inherits System.Web.UI.Page
    Dim StringMessage As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            TextBoxLand.Text = "0.00"
            If Request.QueryString("CollType") = "50" Then
                pLand.Visible = True
                pBuilding.Visible = False
                pCondo.Visible = False
            ElseIf Request.QueryString("CollType") = "70" Then
                pLand.Visible = True
                pBuilding.Visible = True
                pCondo.Visible = False
            ElseIf Request.QueryString("CollType") = "18" Then
                pLand.Visible = False
                pBuilding.Visible = False
                pCondo.Visible = True
            End If

        End If
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        TextBoxReq_Id.Text = Request.QueryString("Req_Id")
        TextBoxHub_Id.Text = Request.QueryString("Hub_id")
        TextBoxCif.Text = Request.QueryString("Cif")
        TextBoxCifName.Text = Request.QueryString("CifName")
        TextBoxAppraisal_Id.Text = Request.QueryString("Appraisal_Id")
        HiddenFieldCollType.Value = Request.QueryString("CollType")
        PRICE2_MASTER_DATA()
    End Sub

    'Protected Sub ImageButtonSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonSave.Click

    '    Dim TEMPAID As Integer = 0
    '    Dim isValid As Boolean = False
    '    mdlPopup.Show()
    '    System.Threading.Thread.Sleep(2000)

    '    'TEMPAID = Appraisal_Manager.GET_TEMP_AID()
    '    'UPDATE_TEMP_AID()

    '    'ADD_PRICE2_MASTER_NEW(TextBoxReq_Id.Text, TextBoxHub_Id.Text, TextBoxCif.Text, TEMPAID, CDec(TextBoxLand.Text), CDec(TextBoxBuilding.Text), _
    '    '                      CDec(TextBoxCondo.Text), 0, 0, 0, ddlComment.SelectedValue, ddlWarning.SelectedValue, "", TextBoxAppraisal_Id.Text, "", rdbAppraisal_Type.SelectedValue, TextBoxAppraisal_Id.Text, Now())
    '    'UPDATE_PRICE2_70_DETAIL_AND_PARTAKE_NEW(TextBoxReq_Id.Text, TextBoxHub_Id.Text, TEMPAID)

    '    mdlPopup.Hide()
    'End Sub

    <System.Web.Script.Services.ScriptMethod()> _
<System.Web.Services.WebMethod()> _
Public Shared Function SavePrice2_Master(ByVal ReqId As String, ByVal HubId As String, ByVal Cif As String, ByVal Land As String, ByVal Building As String, ByVal Condo As String, ByVal Appraisal_Type As String, ByVal Comment As String, ByVal Warning As String, ByVal CreateUser As String, ByVal Note As String) As String
        ' simulate a longer operation ... 
        System.Threading.Thread.Sleep(1000)

        Dim isValid As String = String.Empty
        Dim TEMPAID As Integer
        Try
            Dim Itm As Integer = GET_COUNT_PRICE2_MASTER_NEW(ReqId, HubId)
            If Itm = 0 Then
                TEMPAID = Appraisal_Manager.GET_TEMP_AID()
                UPDATE_TEMP_AID()

                ADD_PRICE2_MASTER_AND_TEMP_AID(ReqId, HubId, Cif, TEMPAID, CDec(Land), CDec(Building), CDec(Condo), 0, 0, 0, Comment, Warning, Note.ToString, CreateUser, "", Appraisal_Type, CreateUser, Now())

                'UPDATE_PRICE2_70_DETAIL_AND_PARTAKE_NEW(ReqId, HubId, TEMPAID)
                'isValid = True
                isValid = isValid & "{"
                isValid = isValid & " 'isValid': 'True', "
                isValid = isValid & " 'Temp_AID': '" & TEMPAID.ToString & "'"
                isValid = isValid & "}"
            Else
                Dim PRICE2_MASTER_DATA As DataSet = GET_PRICE2_MASTER_NEW(ReqId, HubId)
                If PRICE2_MASTER_DATA.Tables(0).Rows.Count > 0 Then
                    TEMPAID = PRICE2_MASTER_DATA.Tables(0).Rows(0).Item("Temp_AID")
                End If
                UPDATE_PRICE2_MASTER_AND_TEMP_AID(ReqId, HubId, Cif, TEMPAID, CDec(Land), CDec(Building), CDec(Condo), 0, 0, 0, Comment, Warning, Note, CreateUser, "", Appraisal_Type, CreateUser, Now())

                'isValid = True

                isValid = isValid & "{"
                isValid = isValid & " 'isValid': 'True', "
                isValid = isValid & " 'Temp_AID': '" & TEMPAID.ToString & "'"
                isValid = isValid & "}"
            End If
        Catch
            'isValid = False
            isValid = isValid & "{"
            isValid = isValid & " 'isValid': 'True', "
            isValid = isValid & " 'Temp_AID': '" & "" & "'"
            isValid = isValid & "}"
        End Try
        Return isValid
    End Function

    Protected Sub ImageButtonFullForm_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonFullForm.Click
        Dim Price2Master As DataSet = GET_PRICE2_MASTER_NEW(TextBoxReq_Id.Text, TextBoxHub_Id.Text)
        If Price2Master.Tables(0).Rows.Count = 0 Then
            StringMessage = "<script language=""javascript"">alert('คุณต้องบันทึกรายละเอียดการให้ราคาก่อนออกรายงานการประเมิน'); </script>"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "รายงานการประเมิน", StringMessage)
        Else
            PRICE2_MASTER_DATA()
            'ออกรายงานการประเมิน
            Context.Items("Req_Id") = TextBoxReq_Id.Text
            Context.Items("Hub_Id") = TextBoxHub_Id.Text
            Context.Items("Temp_AID") = TextBoxTemp_AID.Text
            Context.Items("Cif") = TextBoxCif.Text
            Context.Items("Appraisal_Id") = TextBoxAppraisal_Id.Text
            Context.Items("ChkColl") = Request.QueryString("CollType")
            Server.Transfer("Appraisal_Price3_Conform_New.aspx")
        End If
    End Sub

    Sub PRICE2_MASTER_DATA()
        Dim PRICE2_MASTER_DATA As DataSet = GET_PRICE2_MASTER_NEW(TextBoxReq_Id.Text, TextBoxHub_Id.Text)
        If PRICE2_MASTER_DATA.Tables(0).Rows.Count > 0 Then
            rdbAppraisal_Type.SelectedValue = PRICE2_MASTER_DATA.Tables(0).Rows(0).Item("Appraisal_Type")
            TextBoxTemp_AID.Text = PRICE2_MASTER_DATA.Tables(0).Rows(0).Item("Temp_AID")
            TextBoxLand.Text = String.Format("{0:N2}", PRICE2_MASTER_DATA.Tables(0).Rows(0).Item("Land"))
            TextBoxBuilding.Text = String.Format("{0:N2}", PRICE2_MASTER_DATA.Tables(0).Rows(0).Item("Building"))
            TextBoxCondo.Text = String.Format("{0:N2}", PRICE2_MASTER_DATA.Tables(0).Rows(0).Item("Condo"))
            TextBoxGrandTotal.Text = String.Format("{0:N2}", PRICE2_MASTER_DATA.Tables(0).Rows(0).Item("Land") + PRICE2_MASTER_DATA.Tables(0).Rows(0).Item("Building") + PRICE2_MASTER_DATA.Tables(0).Rows(0).Item("Condo"))
            ddlComment.SelectedValue = PRICE2_MASTER_DATA.Tables(0).Rows(0).Item("Comment")
            ddlWarning.SelectedValue = PRICE2_MASTER_DATA.Tables(0).Rows(0).Item("Warning")
            TextBoxNote.Text = PRICE2_MASTER_DATA.Tables(0).Rows(0).Item("Note")
        End If
    End Sub

End Class
