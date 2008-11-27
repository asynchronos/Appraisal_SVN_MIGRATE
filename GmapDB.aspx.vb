Imports System.Data
Imports System.IO
Imports System.Collections.Generic
Imports System.Xml
Imports System.Xml.Serialization


Partial Class GmapDB
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Select Request("action")
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
        Dim dalmap As New GmapDAL
        Dim lmap As New Gmap
        lmap = dalmap.getGmapByCOLL_ID(Request("cid"))
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
        Dim dalmap As New GmapDAL
        Dim lmap As New List(Of Gmap)
        lmap = dalmap.getAllGmap
        Dim oXS As XmlSerializer = New XmlSerializer(lmap.GetType)
        'Dim oXS As XmlSerializer = New XmlSerializer(TypeOf(lmap))
        'Serialize object into an XML string
        oXS.Serialize(oStrW, lmap)
        sXML = oStrW.ToString()
        oStrW.Close()
        Response.Clear()
        Response.Expires=-1
        Response.CacheControl = "no-cache"
        Response.ContentType = "text/xml"
        Response.Write(sXML)
        Response.End()
    End Sub

    Private Sub insertMark()
        Dim dal As New GmapDAL
        Dim obj As New Gmap
        obj.COLL_ID = Request("cid")
        obj.Name = Request("name")
        obj.Lat = Request("lat")
        obj.Lng = Request("lng")
        obj.Detail = Request("name")
        obj.Price1 = Request("price")
        obj.Price2 = 0
        obj.Price3 = 0
        obj.Pic1 = ""
        obj.Pic2 = ""
        dal.insertGmap(obj)
    End Sub

    Private Sub updateMark()
        Dim dal As New GmapDAL
        Dim obj As New Gmap
        obj.COLL_ID = Request("cid")
        obj.Name = Request("name")
        obj.Lat = Request("lat")
        obj.Lng = Request("lng")
        obj.Detail = Request("name")
        obj.Price1 = Request("price")
        obj.Price2 = 0
        obj.Price3 = 0
        obj.Pic1 = ""
        obj.Pic2 = ""
        dal.updateGmap(obj)
    End Sub

End Class
