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
Imports Appraisal_Manager

Partial Class Appraisal_Building_List
    Inherits System.Web.UI.Page
    Dim TotalPrice As Decimal = 0.0

    ' === tam create 27/05/2553
    Dim id_his As String = "" ' กำหนดค่า id ตัวเดิมเอาไว้เปรียบเที่ยบกับ id ลำดับถัดไป
    Dim sumSub1 As Double
    Dim sumCostPrice As Double
    Dim sumMarketPrice As Double
    Dim PricePerId As Double

    Dim sumGrand1 As Double
    Dim sumGrandCostPrice As Double
    Dim sumGrandMarketPrice As Double
    Dim sumGrandPricePerId As Double
    Dim GrandTotal As Double

    Dim sumSub2 As Single
    Dim sumGrand2 As Single
    Dim sumSub3 As Single
    Dim sumGrand3 As Single
    Dim sumRow As Double


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            TextBoxReq_Id.Text = Request.QueryString("Req_Id")
            TextBoxHub_Id.Text = Request.QueryString("Hub_id")
            TextBoxCif.Text = Request.QueryString("Cif")
            TextBoxAppraisal_Id.Text = Request.QueryString("Appraisal_Id")
            TextBoxCifName.Text = Request.QueryString("CifName")
            HiddenApprisalType.Value = Request.QueryString("Appraisal_Type")
            HiddenLandPrice.Value = CDec(Request.QueryString("LandPriceValue"))
        End If
    End Sub

    Function GetPrice(ByVal Count As Decimal) As Decimal
        TotalPrice += Count
        'If Request.QueryString("Appraisal_Type") = 1 Then
        '    Return 0
        'Else
        Return Count
        'End If

    End Function

    Function GetTotalPrice() As Decimal
        'If Request.QueryString("Appraisal_Type") = 1 Then
        '    TextBoxBuildingPrice.Text = "0.00"
        '    Return 0
        'Else
        '    TextBoxBuildingPrice.Text = String.Format("{0:N2}", TotalPrice)
        Return TotalPrice
        'End If

    End Function

    Protected Sub GridView_Building_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView_Building.DataBound
        'ทำแถวสุดท้าย ที่แสดง GrandTotal
        Dim oGridView As GridView = DirectCast(sender, GridView)
        Dim newRow = New GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal)
        'Dim cell As New TableCell
        'cell.ColumnSpan = GridView_Building.Columns.Count
        'cell.Width = Unit.Percentage(100)

        newRow.Cells.Add(CreateNewCell("&nbsp"))
        newRow.Cells.Add(CreateNewCell(" SUBTOTAL "))
        newRow.Cells.Add(CreateNewCell(" พื้นที่รวม "))
        newRow.Cells.Add(CreateNewCell(sumSub1.ToString.PadRight(15)))
        newRow.Cells.Add(CreateNewCell(" ราคาทุน "))
        newRow.Cells.Add(CreateNewCell(String.Format("{0:N2}", sumCostPrice)))
        newRow.Cells.Add(CreateNewCell(" ราคาตลาด "))
        newRow.Cells.Add(CreateNewCell(String.Format("{0:N2}", sumMarketPrice)))

        newRow.Cells(2).ColumnSpan = 2
        'newRow.Cells(2).Width = Unit.Pixel(500)

        sumGrand1 += sumSub1
        sumGrandCostPrice += sumCostPrice
        sumGrandMarketPrice += sumMarketPrice
        'sumGrandPricePerId += PricePerId

        'If HiddenApprisalType.Value = 2 Then
        '    sumGrandPricePerId += PricePerId
        '    GrandTotal += sumGrandPricePerId
        '    sumGrandPricePerId = PriceRounded(sumGrandPricePerId)  '------- ส่งราคาไปปัดเศษ
        'Else
        '    sumGrandPricePerId += sumMarketPrice
        '    GrandTotal += sumGrandPricePerId
        'End If

        If HiddenApprisalType.Value = 2 Then
            sumGrandPricePerId = 0
            sumGrandPricePerId += sumCostPrice
            sumGrandPricePerId = PriceRounded(sumGrandPricePerId)  '------- ส่งราคาไปปัดเศษ
            GrandTotal += sumGrandPricePerId
        Else
            sumGrandPricePerId = 0
            sumGrandPricePerId += sumMarketPrice 'sumMarketPrice
            GrandTotal += sumGrandPricePerId
        End If

        newRow.Cells.Add(CreateNewCell("ปัดเศษ "))
        newRow.Cells.Add(CreateNewCell(String.Format("{0:N2}", PriceRounded(PricePerId))))

        'PricePerId += sumCostPrice
        'PricePerId = PriceRounded(PricePerId)

        newRow.ForeColor = Drawing.Color.Blue
        'oGridView.Controls(0).Controls.Add(oGridViewRow)
        If oGridView.Rows.Count = 0 Then
        Else
            oGridView.Controls(0).Controls.Add(newRow)
        End If


        ' สร้าง Grand Total
        Dim gRow = New GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal)
        Dim TextboxGradTotal As New Mytextbox.mytext
        TextboxGradTotal.Width = Unit.Pixel(100)
        TextboxGradTotal.AutoCurrencyFormatOnKeyUp = True
        TextboxGradTotal.EnableTextAlignRight = True
        TextboxGradTotal.AllowUserKey = Mytextbox.mytext.UserKey.num_Numeric
        TextboxGradTotal.Text = String.Format("{0:N2}", sumGrandPricePerId)


        gRow.Cells.Add(CreateNewCell("&nbsp"))
        gRow.Cells.Add(CreateNewCell(" GRAND TOTAL "))
        gRow.Cells.Add(CreateNewCell(sumGrand1.ToString))
        gRow.Cells.Add(CreateNewCell("&nbsp"))
        gRow.Cells.Add(CreateNewCell("&nbsp"))
        gRow.Cells.Add(CreateNewCell("&nbsp"))
        gRow.Cells.Add(CreateNewCell("&nbsp"))
        gRow.Cells.Add(CreateNewCell("&nbsp"))
        gRow.Cells.Add(CreateNewCell(String.Format("{0:N2}", GrandTotal)))
        mytextBuildingGrandTotal.Text = String.Format("{0:N2}", GrandTotal)
        'gRow.Cells.Add(CreateNewCellTextBox(TextboxGradTotal))
        'newRow.Cells(2).Width = Unit.Pixel(500)
        HiddenFieldGrandTotal.Value = String.Format("{0:N2}", CDec(HiddenLandPrice.Value) + CDec(mytextBuildingGrandTotal.Text))
        Dim oCell As New TableCell
        oCell.ColumnSpan = gRow.Cells.Count
        'newRow.Cells.Clear()
        'oCell.Width = Unit.Percentage(100)
        gRow.ForeColor = Drawing.Color.Red
        gRow.Cells.Add(oCell)
        If oGridView.Rows.Count = 0 Then
        Else
            oGridView.Controls(0).Controls.Add(gRow)
            gRow.Cells(1).ColumnSpan = 3
            gRow.Cells(1).HorizontalAlign = HorizontalAlign.Left
        End If



    End Sub

    Protected Sub GridView_Building_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView_Building.RowDataBound
        Dim oGridView As GridView = DirectCast(sender, GridView)
        Dim row As GridViewRow = e.Row
        Dim intRowCount = oGridView.Rows.Count
        If e.Row.RowType = DataControlRowType.DataRow Then

            sumRow += 1  ' --- นับจำนวนแถว
            If e.Row.RowIndex = 0 Then
                id_his = DirectCast(e.Row.DataItem, DataRowView)(5).ToString() 'e.Row.Cells(0).Text
            Else
                If id_his = DirectCast(e.Row.DataItem, DataRowView)(5).ToString() Then ' เก็บค่า id ของแต่ละแถว ถ้าแถวต่อไปซ้ำจะไม่แสดง
                    ' e.Row.Cells(0).ForeColor = Drawing.Color.White
                Else
                    '---- เพิ่มแถว subtotal
                    Dim newRow = New GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal)
                    Dim oCell As New TableCell
                    oCell.ColumnSpan = e.Row.Cells.Count
                    'e.Row.Cells.Clear()
                    'oCell.Width = Unit.Percentage(100)
                    newRow.Cells.Add(CreateNewCell("&nbsp"))
                    newRow.Cells.Add(CreateNewCell(" SUBTOTAL "))
                    newRow.Cells.Add(CreateNewCell(" พื้นที่รวม "))
                    newRow.Cells.Add(CreateNewCell(sumSub1.ToString)) '------ Area
                    newRow.Cells.Add(CreateNewCell(" ราคาทุน "))
                    newRow.Cells.Add(CreateNewCell(String.Format("{0:N2}", sumCostPrice))) '------ ราคาทุน
                    newRow.Cells.Add(CreateNewCell(" ราคาตลาด "))
                    newRow.Cells.Add(CreateNewCell(String.Format("{0:N2}", sumMarketPrice)))

                    newRow.Cells(2).ColumnSpan = 2
                    'newRow.Cells(2).Width = Unit.Pixel(500)

                    sumGrand1 += sumSub1
                    sumGrandCostPrice += sumCostPrice
                    sumGrandMarketPrice += sumMarketPrice

                    If HiddenApprisalType.Value = 2 Then
                        sumGrandPricePerId = 0
                        sumGrandPricePerId += sumCostPrice
                        sumGrandPricePerId = PriceRounded(sumGrandPricePerId)  '------- ส่งราคาไปปัดเศษ
                        GrandTotal += sumGrandPricePerId
                        'newRow.Cells.Add(CreateNewCell("ปัดเศษ "))
                        'newRow.Cells.Add(CreateNewCell(String.Format("{0:N2}", sumGrandPricePerId)))
                    Else
                        sumGrandPricePerId = 0
                        sumGrandPricePerId += sumMarketPrice 'sumMarketPrice
                        GrandTotal += sumGrandPricePerId
                        'newRow.Cells.Add(CreateNewCell("ปัดเศษ "))
                        'newRow.Cells.Add(CreateNewCell(String.Format("{0:N2}", sumGrandPricePerId)))
                    End If

                    newRow.Cells.Add(CreateNewCell("ปัดเศษ "))
                    newRow.Cells.Add(CreateNewCell(String.Format("{0:N2}", sumGrandPricePerId)))

                    sumSub1 = 0
                    sumCostPrice = 0
                    sumMarketPrice = 0
                    PricePerId = 0

                    newRow.ForeColor = Drawing.Color.Blue
                    oGridView.Controls(0).Controls.AddAt(sumRow, newRow)
                    id_his = DirectCast(e.Row.DataItem, DataRowView)(5).ToString()
                    sumRow += 1
                    'MsgBox(newRow.Cells.Count)
                End If
            End If
            sumSub1 += DirectCast(e.Row.DataItem, DataRowView)(8) '---รวมพื้นที่ 
            sumCostPrice += DirectCast(e.Row.DataItem, DataRowView)(19) '---รวมราคาทุน
            sumMarketPrice += DirectCast(e.Row.DataItem, DataRowView)(20) '---รวมราคตลาด

            If HiddenApprisalType.Value = 2 Then
                PricePerId += DirectCast(e.Row.DataItem, DataRowView)(19) '---รวมราคาต่อชิ้นวิธีทุน
            Else
                PricePerId += DirectCast(e.Row.DataItem, DataRowView)(20) '---รวมราคาต่อชิ้นวิธีตลาด
            End If
        End If

    End Sub

    Function CreateNewCell(ByVal text As String) As TableCell

        Dim newCell As New TableCell
        newCell.Text = text
        Return newCell

    End Function

    Function CreateNewCellTextBox(ByVal txtbox As Control) As TableCell

        Dim newCell As New TableCell
        'Dim Textbox As New TextBox

        newCell.Controls.Add(txtbox)
        Return newCell

    End Function

    Function PriceRounded(ByVal Price As Double) As Double
        Dim Priceround As Double
        If HiddenApprisalType.Value = 2 Then
            Priceround = Round((Price / 1000), System.MidpointRounding.AwayFromZero) * 1000
            Return Priceround
        Else
            Priceround = Price
            Return Priceround
        End If
    End Function

End Class
