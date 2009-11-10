Imports System.Data
Imports System.IO
Imports System.Collections.Generic
Imports System.Xml
Imports System.Xml.Serialization
Imports Appraisal_Manager

Partial Class Price3DB
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        'If Not Page.IsPostBack Then
        'Dim a, b As Integer
        'a = Request.QueryString("Req_Id")
        'b = Request.QueryString("Hub_Id")
        'MsgBox(a)
        'MsgBox(b)
        'End If

        'If Not Page.IsPostBack Then
        Select Case Request("action")
            Case "1"
                showAll()
            Case "2"
                showMark()
            Case "3"
                insertMark()
            Case "4"
                updateMark()
            Case "5"
                ShowMarkByReq_Id()
            Case "6"
                ShowMark_Price3_ByReq_Id()
            Case "7"
                updateMark_Price3()
            Case "8"
                showMarkPrice1()
        End Select
        ' End If

    End Sub
    Public Function FormatXMLToHTML(ByVal sXML As String) As String
        sXML = sXML.Replace("<", "<").Replace(">", ">").Replace(vbNewLine, "<br />")
        Return sXML
    End Function

    Private Sub showMark()

        Dim oStrW As New StringWriter()
        Dim sXML As String
        Dim dalmap As New GmapDAL_NEW
        Dim lmap As New Price3_Master
        lmap = dalmap.getGmapBy_AID(Request("AID"))
        Dim oXS As XmlSerializer = New XmlSerializer(lmap.GetType)
        'Dim oXS As XmlSerializer = New XmlSerializer(TypeOf(lmap))
        'Serialize object into an XML string
        oXS.Serialize(oStrW, lmap)
        sXML = oStrW.ToString()
        oStrW.Close()
        Response.Write(sXML)
        Response.End()
    End Sub

    Private Sub showAll()
        Dim oStrW As New StringWriter()
        Dim sXML As String
        Dim dalmap As New GmapDAL_NEW
        Dim lmap As New List(Of Price3_Master)
        lmap = dalmap.getAllGmap_Price3Master
        Dim oXS As XmlSerializer = New XmlSerializer(lmap.GetType)
        'Dim oXS As XmlSerializer = New XmlSerializer(TypeOf(lmap))
        'Serialize object into an XML string
        oXS.Serialize(oStrW, lmap)
        sXML = oStrW.ToString()
        oStrW.Close()
        Response.Clear()
        Response.Expires = -1
        Response.CacheControl = "no-cache"
        Response.ContentType = "text/xml"
        Response.Write(sXML)
        Response.End()
    End Sub

    Private Sub insertMark()
        Dim dal As New GmapDAL_NEW
        Dim obj As New Price1_Master

        obj.Req_Id = CInt(Request("Req_Id"))
        obj.Hub_Id = CInt(Request("Hub_Id"))
        obj.Cif = CInt(Request("Cif"))
        obj.CifName = ""
        obj.Lat = CDec(Request("lat"))
        obj.Lng = CDec(Request("lng"))
        obj.Pricewah = CDec(Request("Pricewah"))
        obj.Price = CDec(Request("Price"))
        obj.Create_User = Request("userid")
        obj.Create_Date = Now()
        dal.insertPrice1Master(obj)

        'MsgBox(Request("Req_Id") & "  " & Request("Hub_Id"))
        'UPDATE_Status_Appraisal_Request(Request("Req_Id"), Request("Hub_Id"), 5)
        'Response.Redirect("Appraisal_List_By_Hub.aspx")
    End Sub

    Private Sub updateMark()
        Dim dal As New GmapDAL_NEW
        Dim obj As New Price1_Master
        obj.Req_Id = Request("Req_Id")
        obj.Hub_Id = Request("Hub_Id")
        obj.Lat = Request("lat")
        obj.Lng = Request("lng")
        'MsgBox(Session("sEmpId"))
        If Session("sEmpId") Is Nothing Then
            Session("sEmpId") = "Admin"
        End If
        obj.Create_User = Session("sEmpId")
        obj.Create_Date = Now()
        dal.updatePrice1Master(obj)
    End Sub

    Private Sub updateMark_Price3()
        Dim dal As New GmapDAL_NEW
        Dim obj As New Price3_Master
        obj.Req_Id = Request("req_id")
        obj.Temp_AID = Request("temp_aid")
        obj.Lat = Request("lat")
        obj.Lng = Request("lng")
        'MsgBox(Session("sEmpId"))
        'If Session("sEmpId") Is Nothing Then
        '    Session("sEmpId") = "Admin"
        'End If
        'obj.Create_User = Request("userid")
        obj.Create_Date = Now()
        dal.updatePrice3Master(obj)
    End Sub

    Private Sub ShowMark_Price3_ByReq_Id()
        Dim oStrW As New StringWriter()
        Dim sXML As String
        Dim dalmap As New GmapDAL_NEW
        Dim lmap As New List(Of Price3_Master)

        lmap = dalmap.getGmapBy_Price3_Req_ID(Request("Req_Id"), Request("Temp_AID"))

        Dim oXS As XmlSerializer = New XmlSerializer(lmap.GetType)
        oXS.Serialize(oStrW, lmap)
        sXML = oStrW.ToString()
        oStrW.Close()
        Response.Clear()
        Response.Expires = -1
        Response.CacheControl = "no-cache"
        Response.ContentType = "text/xml"
        Response.Write(sXML)
        Response.End()
    End Sub

    Private Sub ShowMarkByReq_Id()
        Dim oStrW As New StringWriter()
        Dim sXML As String
        Dim dalmap As New GmapDAL_NEW
        Dim lmap As New List(Of Price1_Master)

        lmap = dalmap.getGmapBy_Req_ID(Request("Req_Id"), Request("Hub_Id"))

        Dim oXS As XmlSerializer = New XmlSerializer(lmap.GetType)
        oXS.Serialize(oStrW, lmap)
        sXML = oStrW.ToString()
        oStrW.Close()
        Response.Clear()
        Response.Expires = -1
        Response.CacheControl = "no-cache"
        Response.ContentType = "text/xml"
        Response.Write(sXML)
        Response.End()
    End Sub

    Private Sub showMarkPrice1()
        Dim oStrW As New StringWriter()
        Dim sXML As String
        Dim dalmap As New GmapDAL_NEW
        'Dim lmap As New Price1_Master
        Dim lmap As New List(Of Price1_Master)
        lmap = dalmap.getGmapBy_Req_ID(Int(Request("Req_Id")), Int(Request("Hub_Id")))
        Dim oXS As XmlSerializer = New XmlSerializer(lmap.GetType)
        'Dim oXS As XmlSerializer = New XmlSerializer(TypeOf(lmap))
        'Serialize object into an XML string
        oXS.Serialize(oStrW, lmap)
        sXML = oStrW.ToString()
        oStrW.Close()
        Response.Write(sXML)
        Response.End()
    End Sub
End Class
