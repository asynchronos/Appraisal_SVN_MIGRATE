Option Explicit On
Option Strict On

Imports Microsoft.VisualBasic
Imports System.Diagnostics
Imports System
Imports System.Exception

Public Class DisplayErrorUtil
    Private Shared className As String = "DisplayErrorUtil"

    Public Enum SourceTypeEnum
        steFunction
        steSubRoutine
    End Enum

    ''' <summary>
    ''' Sub ���Ӣ�������͡���ʴ���ͤ��� Error ����Դ��������� ����������� �Ҩҡ����˹ Function ���� Sub ���� �������¢�鹵�͡�õ�Ǩ�ͺ������Ф�Ѻ
    ''' </summary>
    ''' <param name="Source">Sub Name or Function Name</param>
    ''' <param name="ClassApp">Class Name</param>
    ''' <param name="ErrorMessage">Error Message</param>
    ''' <param name="SourceType">SourceType �� Sub ���� Function</param>
    ''' <param name="StackTrace">StackTrace of Exception</param>
    ''' <remarks>SourceType ����ö���͡��ҡ SourceTypeEnum �ͧ Class ���</remarks>
    Public Shared Sub DisplayError(ByVal Source As String, ByVal ClassApp As String, ByVal ErrorMessage As String, Optional ByVal SourceType As SourceTypeEnum = SourceTypeEnum.steFunction, Optional ByVal StackTrace As String = "")
        Dim strError As String
        strError = "Error : " & ErrorMessage & vbCrLf
        Select Case SourceType
            Case SourceTypeEnum.steFunction : strError += "Function : " & Source
            Case SourceTypeEnum.steSubRoutine : strError += "Sub Routine : " & Source
        End Select
        strError += vbCrLf & "Error Where : " & ClassApp

        If (StackTrace <> "") Then
            strError += vbCrLf & vbCrLf & "Error StackTrace : " & StackTrace
        End If

        Debug.Print(strError)
        Console.WriteLine(strError)
    End Sub

    ''' <summary>
    ''' ������Ѻ�ʴ� error �� web page
    ''' </summary>
    ''' <param name="page"></param>
    ''' <param name="ex"></param>
    ''' <remarks></remarks>
    Public Shared Sub onPage(ByVal page As System.Web.UI.Page, ByVal ex As Exception)
        onPage(page, ex.Message, ex.StackTrace)
    End Sub

    ''' <summary>
    ''' ������Ѻ�ʴ� error �� web page
    ''' </summary>
    ''' <param name="page"></param>
    ''' <param name="ErrorMessage">error message ����ͧ��è��ʴ���˹�� web</param>
    ''' <param name="ErrorStackTrace">��������´��������ʴ�����ͤ��꡷�� error message</param>
    ''' <remarks></remarks>
    Public Shared Sub onPage(ByVal page As Web.UI.Page, ByVal ErrorMessage As String, ByVal ErrorStackTrace As String)
        Dim result As String = Nothing

        'regis script
        page.ClientScript.RegisterClientScriptBlock(page.GetType, "DisplayErrorScript", DisplayErrorUtil.javascript(), True)

        '<p id="error"><a id="errorHeader" href="javascript:void(0)" onclick="javascript:showHide('myDiv')">Unknown Error</a></p>
        '<div id="myDiv" class="errorDetail" STYLE="position:relative; width:70%; height:40%; visibility: hidden;">{0}</div>

        result = "<p id=error><a id=errorHeader href=javascript:void(0) onclick=" _
                & "javascript:showAlert('myDiv')>" & ErrorMessage & "</a></p>" _
                & vbCrLf & "<div id=myDiv class=errorDetail STYLE='position:absolute; visibility: hidden;'>" & ErrorStackTrace & "</div>"

        page.Response.Write(result)
        Debug.Print(ErrorMessage)
        Debug.Print(ErrorStackTrace)
    End Sub

    Private Shared Function javascript() As String
        Dim result As String = Nothing

        'var ns4 = (document.layers)? true:false;
        'var ie4 = (document.all)? true:false;

        '//function for get element by id
        'function e(id,obj) {
        ' if(!obj)obj=this;
        ' return obj.document.getElementById(id);
        '}
        '//function for get elements by name
        'function arrayE(name,obj){
        ' if(!obj)obj=this;
        ' return document.getElementsByName(name);
        '}
        '//show hide elements object
        'function showHide(divId){
        ' var visibility = null;
        ' if (ns4) {
        '  if((visibility = e(divId).style.visibility) == "show") 
        '   e(divId).style.visibility = "hide";
        '  else if(visibility == "hide" ) 
        '   e(divId).style.visibility = "show";
        ' }else {
        '  if((visibility = e(divId).style.visibility) == "visible") 
        '   e(divId).style.visibility = "hidden";
        '  else if(visibility == "hidden")
        '   e(divId).style.visibility = "visible";
        ' }
        '}

        result = "var ns4 = (document.layers)? true:false;" & vbCrLf _
                & "var ie4 = (document.all)? true:false;" & vbCrLf _
                & "function e(id,obj) {" & vbCrLf _
                & "   if(!obj)obj=this;" & vbCrLf _
                & "   return obj.document.getElementById(id);" & vbCrLf _
                & "}" & vbCrLf _
                & "function showHide(divId){" & vbCrLf _
                & "   var visibility = null;" & vbCrLf _
                & "   if (ns4) {" & vbCrLf _
                & "      if((visibility = e(divId).style.visibility) == 'show')" & vbCrLf _
                & "         e(divId).style.visibility = 'hide';" & vbCrLf _
                & "      else if(visibility == 'hide' )" & vbCrLf _
                & "         e(divId).style.visibility = 'show';" & vbCrLf _
                & "   }else {" & vbCrLf _
                & "      if((visibility = e(divId).style.visibility) == 'visible')" & vbCrLf _
                & "         e(divId).style.visibility = 'hidden';" & vbCrLf _
                & "      else if(visibility == 'hidden')" & vbCrLf _
                & "         e(divId).style.visibility = 'visible';" & vbCrLf _
                & "   }" & vbCrLf _
                & "}" & vbCrLf _
                & "function showAlert(divId){" & vbCrLf _
                & "   alert(e(divId).innerText)" & vbCrLf _
                & "}" & vbCrLf

        Return result
    End Function

End Class
