Imports System.Collections.Generic
Imports System.Globalization
Partial Class _Gmap
Inherits System.Web.UI.Page
'Protected cul As New CultureInfo("th-TH") ' ปี ไทย  
 Protected cul As New CultureInfo("en-US") ' ปี eng 
Protected Sub alert(ByVal str As String)
	 Response.Write("<script language=""javascript"">alert(""" & Str & """)</script>")
End sub 
 Protected Sub BindDropDown
End Sub
Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If Page.IsPostBack = False Then
		ShowGridGmap()
		PreSearch()
		BindDropdown()
		BtnDelete.Attributes.Add("onclick", "return confirm('Do you want to delete this data?');")
	End if 
End Sub
Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
 ' Code check input error. 
	Dim dal As New GmapDAL ' Create object dal
	Dim obj As New Gmap ' Create object 
	obj.COLL_ID = tbCOLL_ID.Text
	obj=dal.getGmapByCOLL_ID(obj)
	tbCOLL_ID.text=obj.COLL_ID
	tbLat.text=obj.Lat
	tbLng.text=obj.Lng
	tbName.text=obj.Name
	tbDetail.text=obj.Detail
	tbPrice1.text=obj.Price1
	tbPrice2.text=obj.Price2
	tbPrice3.text=obj.Price3
	tbPic1.text=obj.Pic1
	tbPic2.text=obj.Pic2
PreUpdate()
End sub
Protected Sub btnSearchVar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchVar.Click
	Dim sqlString As String = "Select * From Gmap"
	If tbSearchValue.Text <> "" Then
		If ddlOperator.SelectedValue = " LIKE "  Or  ddlOperator.SelectedValue = " Not LIKE " Then  '-- "Contains" comparison, e.g.,
			sqlString &= " Where " & ddlFieldValue.SelectedValue & _
			ddlOperator.SelectedValue & "N'%" & Replace(tbSearchValue.Text.Trim, "'", "''") & "%'"
		Else  '-- Numeric comparison, e.g.,
			sqlString &= " Where  " & ddlFieldValue.SelectedValue & _
			ddlOperator.SelectedValue & "'" & Replace(tbSearchValue.Text.Trim, "'", "''") & "'"
		End If
	End If
Dim dal As New GmapDAL
Dim arr As New List(Of Gmap)
arr = dal.getAllGmapBySQL(sqlString)
GridGmap.DataSource = arr
Session("GridGmap") = arr
GridGmap.DataBind()
End Sub
Sub PreAdd()
	btnAdd.Visible = True 
	btnUpdate.Visible = False 
	btnDelete.Visible = False
	ClearText()
	PanelGridGmap.visible=False
	PanelGmap.visible=True
End Sub
Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
 'Code check input error. 
	Dim ErrString As String = CheckErrINput()
	If ErrString <> "" Then
		 alert(ErrString)
		 Exit Sub
	End If
	Dim dal As New GmapDAL ' Create object dal
	Dim obj As New Gmap ' Create object
	obj.COLL_ID=tbCOLL_ID.text
	obj.Lat=tbLat.text
	obj.Lng=tbLng.text
	obj.Name=tbName.text
	obj.Detail=tbDetail.text
	obj.Price1=tbPrice1.text
	obj.Price2=tbPrice2.text
	obj.Price3=tbPrice3.text
	obj.Pic1=tbPic1.text
	obj.Pic2=tbPic2.text
	dal.insertGmap(obj)
		ShowGridGmap() ' Show grid data.
		PreSearch() ' Set to presearch state.
		alert(" Update complete ")
End sub
Protected Sub btnAddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
	 PreAdd() 
End sub 
Sub PreUpdate()
	btnAdd.Visible = False
	btnUpdate.Visible = True
	btnDelete.Visible = True
	PanelGridGmap.visible=False
	PanelGmap.visible=True
End Sub
Sub PreSearch()
	btnAdd.Visible = False
	btnUpdate.Visible = True
	btnDelete.Visible = True
	PanelGridGmap.visible=True
	PanelGmap.visible=False
End Sub
Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
 'Code check input error. 
	Dim ErrString As String = CheckErrINput()
	If ErrString <> "" Then
		 alert(ErrString)
		 Exit sub
	End If
	Dim dal As New GmapDAL ' Create object dal
	Dim obj As New Gmap ' Create object 
	obj.COLL_ID=tbCOLL_ID.text
	obj.Lat=tbLat.text
	obj.Lng=tbLng.text
	obj.Name=tbName.text
	obj.Detail=tbDetail.text
	obj.Price1=tbPrice1.text
	obj.Price2=tbPrice2.text
	obj.Price3=tbPrice3.text
	obj.Pic1=tbPic1.text
	obj.Pic2=tbPic2.text
	dal.updateGmap(obj)
		ShowGridGmap()
		PreSearch()
		alert(" Update complete ")
End sub
Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
	Dim dal As New GmapDAL
	Dim obj As New Gmap
	obj.COLL_ID = tbCOLL_ID.Text
	dal.deleteGmap(obj)
		ShowGridGmap()
		PreSearch()
End sub
Sub ClearText()
tbCOLL_ID.Text = "" 
tbLat.Text = "" 
tbLng.Text = "" 
tbName.Text = "" 
tbDetail.Text = "" 
tbPrice1.Text = "" 
tbPrice2.Text = "" 
tbPrice3.Text = "" 
tbPic1.Text = "" 
tbPic2.Text = "" 
End Sub
Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
	 PreSearch() 
End sub 
 Protected Sub GridGmap_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridGmap.SelectedIndexChanged
	tbCOLL_ID.Text =  HttpUtility.HtmlDecode(GridGmap.Rows(GridGmap.SelectedIndex).Cells(1).Text).Trim
	tbLat.Text =  HttpUtility.HtmlDecode(GridGmap.Rows(GridGmap.SelectedIndex).Cells(2).Text).Trim
	tbLng.Text =  HttpUtility.HtmlDecode(GridGmap.Rows(GridGmap.SelectedIndex).Cells(3).Text).Trim
	tbName.Text =  HttpUtility.HtmlDecode(GridGmap.Rows(GridGmap.SelectedIndex).Cells(4).Text).Trim
	tbDetail.Text =  HttpUtility.HtmlDecode(GridGmap.Rows(GridGmap.SelectedIndex).Cells(5).Text).Trim
	tbPrice1.Text =  HttpUtility.HtmlDecode(GridGmap.Rows(GridGmap.SelectedIndex).Cells(6).Text).Trim
	tbPrice2.Text =  HttpUtility.HtmlDecode(GridGmap.Rows(GridGmap.SelectedIndex).Cells(7).Text).Trim
	tbPrice3.Text =  HttpUtility.HtmlDecode(GridGmap.Rows(GridGmap.SelectedIndex).Cells(8).Text).Trim
	tbPic1.Text =  HttpUtility.HtmlDecode(GridGmap.Rows(GridGmap.SelectedIndex).Cells(9).Text).Trim
	tbPic2.Text =  HttpUtility.HtmlDecode(GridGmap.Rows(GridGmap.SelectedIndex).Cells(10).Text).Trim
	PreUpdate()
End Sub 
Sub ShowGridGmap
	Dim dal As New GmapDAL
	Dim arr As New List(Of Gmap)
	arr = dal.getAllGmap
	GridGmap.DataSource = arr
	Session("GridGmap") = arr
	GridGmap.DataBind()
End Sub
Protected Sub GridGmap_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridGmap.PageIndexChanging
	GridGmap.PageIndex = e.NewPageIndex
	GridGmap.DataSource = Session("GridGmap")
	GridGmap.DataBind()
End Sub
Function CheckErrINput() As String
	 Dim str As String = ""
	if tbCOLL_ID.text = "" then 
		str+="Please input COLL_ID.  \n"
	End if 
	if tbLat.text = "" then 
		str+="Please input Lat. \n"
		Else
		if  IsNumeric(tbLat.Text) = False Then
			str+="Please input Lat with number. \n "
		End if
	End if
	if tbLng.text = "" then 
		str+="Please input Lng. \n"
		Else
		if  IsNumeric(tbLng.Text) = False Then
			str+="Please input Lng with number. \n "
		End if
	End if
	if tbName.text = "" then 
		str+="Please input Name.  \n"
	End if 
	if tbDetail.text = "" then 
		str+="Please input Detail.  \n"
	End if 
	if tbPrice1.text = "" then 
		str+="Please input Price1. \n"
		Else
		if  IsNumeric(tbPrice1.Text) = False Then
			str+="Please input Price1 with number. \n "
		End if
	End if
	if tbPrice2.text = "" then 
		str+="Please input Price2. \n"
		Else
		if  IsNumeric(tbPrice2.Text) = False Then
			str+="Please input Price2 with number. \n "
		End if
	End if
	if tbPrice3.text = "" then 
		str+="Please input Price3. \n"
		Else
		if  IsNumeric(tbPrice3.Text) = False Then
			str+="Please input Price3 with number. \n "
		End if
	End if
	if tbPic1.text = "" then 
		str+="Please input Pic1.  \n"
	End if 
	if tbPic2.text = "" then 
		str+="Please input Pic2.  \n"
	End if 
	if str <> ""  then 
	 str=" Can not save data. \n " & str 
	 end if
	Return str
End Function
End Class
