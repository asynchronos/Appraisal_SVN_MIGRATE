
Partial Class Appraisal_Price3_50_Review
    Inherits System.Web.UI.Page

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Dim S As String = ""
        S += "<script language='javascript'>"
        'S += "window.opener.document.getElementById('" & Request.QueryString("txtAID") & "').value  ='" & AID & "';"
        'S += "window.opener.document.getElementById('" & Request.QueryString("txtCID") & "').value  ='" & CID & "';"
        'S += "window.opener.document.getElementById('" & Request.QueryString("txtSubCollType") & "').value  ='" & CInt(lblSubCollTypeNo.Text) & "';"
        'S += "window.opener.document.getElementById('" & Request.QueryString("txtDistrict") & "').value  ='" & lblAmphur.Text & "';"
        'S += "window.opener.document.getElementById('" & Request.QueryString("txtBuilding_No") & "').value  ='" & lblChanode.Text & "';"
        'S += "window.opener.document.getElementById('" & Request.QueryString("txtAmphur") & "').value  ='" & lblAmphur.Text & "';"
        'S += "window.opener.document.getElementById('" & Request.QueryString("txtProvince") & "').value  ='" & CInt(lblProvince_Code.Text) & "';"
        S += "window.close();"
        S += "</script>"
        Response.Write(S)
    End Sub
End Class
