Imports System.Data
Imports System.IO
Imports System.Collections.Generic
Imports System.Xml
Imports System.Xml.Serialization

Partial Class Price3DB
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Select Case Request("action")
            Case "1"
                showAll()
            Case "2"
                showMark()
            Case "3"
                insertMark()
            Case "4"
                updateMark()
        End Select
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
        'Response.Redirect("Appraisal_List_By_Hub.aspx")
    End Sub

    Private Sub updateMark()
        Dim dal As New GmapDAL_NEW
        Dim obj As New Price1_Master
        obj.Req_Id = Request("Req_Id")
        obj.Hub_Id = Request("Hub_Id")
        obj.Cif = Request("Cif")
        obj.CifName = Request("CifName")
        obj.Lat = Request("lat")
        obj.Lng = Request("lng")
        obj.Pricewah = Request("Pricewah")
        obj.Price = Request("Price")
        obj.Create_User = Session("sEmpId")
        obj.Create_Date = Now()
        dal.updatePrice1Master(obj)
    End Sub
End Class
