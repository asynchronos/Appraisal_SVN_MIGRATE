
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim ClassG_his As String
    '======
    Dim sumSubloan As Double
    Dim sumGrandloan As Double
    Dim sumSubPercentclassg As Single
    Dim sumGrandPercentclassg As Single
    Dim sumSubPercentallclassg As Single
    Dim sumRow As Double

    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBound
        '  สร้าง SUB Total
        Dim oGridView As GridView = DirectCast(sender, GridView)
        Dim newRow = New GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal)
        newRow.Cells.Add(CreateNewCell("&nbsp"))
        newRow.Cells.Add(CreateNewCell(" SUBTOTAL "))
        newRow.Cells.Add(CreateNewCell(sumSubloan.ToString))
        sumSubloan = 0
        newRow.ForeColor = Drawing.Color.Blue
        'oGridView.Controls(0).Controls.Add(oGridViewRow)
        oGridView.Controls(0).Controls.Add(newRow)
        ' สร้าง Grand Total
        Dim gRow = New GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal)
        gRow.Cells.Add(CreateNewCell("&nbsp"))
        gRow.Cells.Add(CreateNewCell(" Grand Total "))
        gRow.Cells.Add(CreateNewCell(sumGrandloan.ToString))
        gRow.ForeColor = Drawing.Color.Red
        'oGridView.Controls(0).Controls.Add(oGridViewRow)
        oGridView.Controls(0).Controls.Add(gRow)
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

        Dim oGridView As GridView = DirectCast(sender, GridView)
        Dim intRowCount = oGridView.Rows.Count
        If e.Row.RowType = DataControlRowType.DataRow Then

            ' e.Row.Cells(0).Text = sumRow & ":" & e.Row.Cells(0).Text

            sumRow += 1  ' --- นับจำนวนแถว
            If e.Row.RowIndex = 0 Then

                ClassG_his = e.Row.Cells(0).Text
                'MsgBox(e.Row.Cells(0).Text)
            Else

                If ClassG_his = e.Row.Cells(0).Text Then
                    e.Row.Cells(0).ForeColor = Drawing.Color.White
                Else

                    '---- เพิ่มแถว subtotal

                    Dim newRow = New GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal)
                    newRow.Cells.Add(CreateNewCell("&nbsp"))
                    newRow.Cells.Add(CreateNewCell(" SUBTOTAL "))
                    newRow.Cells.Add(CreateNewCell(sumSubloan.ToString))
                    sumSubloan = 0
                    newRow.ForeColor = Drawing.Color.Blue
                    'oGridView.Controls(0).Controls.Add(oGridViewRow)
                    oGridView.Controls(0).Controls.AddAt(sumRow, newRow)
                    ClassG_his = e.Row.Cells(0).Text
                    sumRow += 1

                End If
            End If
            'MsgBox(e.Row.Cells(2).Text)
            sumSubloan += e.Row.Cells(2).Text
            sumGrandloan += sumSubloan
            e.Row.Cells(2).Text = String.Format("{0:N2}", CDec(e.Row.Cells(2).Text))
        End If

    End Sub

    Function CreateNewCell(ByVal text As String) As TableCell

        Dim newCell As New TableCell
        newCell.Text = text
        Return newCell

    End Function

End Class
