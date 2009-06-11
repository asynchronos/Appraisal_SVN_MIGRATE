Option Explicit On
Option Strict On

Imports Microsoft.VisualBasic

Public Class ConvertUtil

    ''' <summary>
    ''' StringValue = ��ͤ���
    ''' NumbericValue = �ӹǹ���
    ''' DoubleValue = �Ţ�ȹ���
    ''' DateValue = �ѹ���
    ''' BooleanValue = ��� boolean
    ''' TimeValue = ����
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum ObjectValueEnum
        StringValue
        NumbericValue
        DoubleValue
        DateValue
        BooleanValue
        TimeValue
    End Enum

    ''' <summary>
    ''' Numeric = #,###0.00
    ''' NumericNoDecimal = �ӹǹ���
    ''' FullDate = '�ѹ'dddd'���' d MMMM gg yyyy
    ''' LongDate = dd-MMMM-yyyy
    ''' ShortDate = dd-MMM-yy
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum ObjectFormatEnum
        Numeric
        NumericNoDecimal
        FullDate
        LongDate
        ShortDate
    End Enum

    ''' <summary>
    ''' Funtion ���������Ѻ�ŧ�����ŷ�����Ѻ�ҡ database ���� Object �� ����դ�� Null
    ''' ����繤�� Default �ͧ Type ��ҧ��������ҵ�ͧ���
    ''' ����蹹�� �ҡ��ҹӤ�� Null ���ҹ�з�����Դ Error ��
    ''' </summary>
    ''' <param name="Value">Object ����ͧ����ŧ</param>
    ''' <param name="GetObject">Type ����ͧ���</param>
    ''' <returns>��� Default �ͧ Type ����</returns>
    ''' <remarks>��� Default �ͧ GetObject ��� StringValue</remarks>
    Public Shared Function getObjectValue(ByVal Value As Object, Optional ByVal GetObject As ObjectValueEnum = ObjectValueEnum.StringValue) As Object

        Select Case GetObject
            Case ObjectValueEnum.BooleanValue
                If Value Is Nothing Or IsDBNull(Value) Then Return False
                Return CBool(Value)
            Case ObjectValueEnum.DateValue
                If Value Is Nothing Or IsDBNull(Value) Then Return Date.Now
                If IsDate(Value) Then
                    Return CDate(Value)
                Else
                    Return Date.Now
                End If
            Case ObjectValueEnum.NumbericValue
                If Value Is Nothing Or IsDBNull(Value) Then Return 0
                If IsNumeric(Value) Then
                    Return CInt(Value)
                Else
                    Return 0
                End If
            Case ObjectValueEnum.DoubleValue
                If Value Is Nothing Or IsDBNull(Value) Then Return 0
                If IsNumeric(Value) Then
                    Return CDbl(Value)
                Else
                    Return 0
                End If
            Case ObjectValueEnum.StringValue
                If Value Is Nothing Or IsDBNull(Value) Then Return String.Empty
                Return CStr(Value)
            Case ObjectValueEnum.TimeValue
                ' Dim dt As DateTime
                If Value Is Nothing Or IsDBNull(Value) Then Return Date.Now
                Return CDate(Value)
        End Select
        Return ""
    End Function

    ''' <summary>
    ''' Function ���������Ѻ set format �ͧ object ��ҧ�
    ''' �� Format �ͧ�ѹ���Ẻ���,���
    ''' Format �ͧ����
    ''' ���� Format �ͧ�Ţ�ȹ���
    ''' </summary>
    ''' <param name="Target">Object ����ͧ��� set format</param>
    ''' <param name="FormatType">�ٻẺ�ͧ Format</param>
    ''' <returns>Object ���١�Ѵ format ����</returns>
    ''' <remarks>��� Default �ͧ FormatType ��� Numeric</remarks>
    Public Shared Function setObjectFormat(ByVal Target As Object, Optional ByVal FormatType As ObjectFormatEnum = ObjectFormatEnum.Numeric) As String

        Select Case FormatType
            Case ObjectFormatEnum.FullDate
                If IsDate(Target) Then
                    Return Format(CDate(Target), "'�ѹ'dddd'���' d MMMM gg yyyy")
                Else
                    Return Format(Date.Now, "'�ѹ'dddd'���' d MMMM gg yyyy")
                End If
            Case ObjectFormatEnum.LongDate
                If IsDate(Target) Then
                    Return Format(CDate(Target), "dd-MMMM-yyyy")
                Else
                    Return Format(Date.Now, "dd-MMMM-yyyy")
                End If
            Case ObjectFormatEnum.Numeric
                If IsNumeric(Target) Then
                    Return Format(CDbl(Target), "#,###0.00")
                Else
                    Return Format(0, "#,###0.00")
                End If
            Case ObjectFormatEnum.NumericNoDecimal
                If IsNumeric(Target) Then
                    Return CStr(Target)
                Else
                    Return CStr(0)
                End If
            Case ObjectFormatEnum.ShortDate
                If IsDate(Target) Then
                    Return Format(CDate(Target), "dd-MMM-yy")
                Else
                    Return Format(Date.Now, "dd-MMM-yy")
                End If
        End Select

        Return Format(0, "#,###0.00")
    End Function

End Class
