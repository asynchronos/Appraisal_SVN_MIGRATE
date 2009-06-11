Option Explicit On
Option Strict On

Imports Microsoft.VisualBasic

Public Class ConvertUtil

    ''' <summary>
    ''' StringValue = ข้อความ
    ''' NumbericValue = จำนวนเต็ม
    ''' DoubleValue = เลขทศนิยม
    ''' DateValue = วันที่
    ''' BooleanValue = ค่า boolean
    ''' TimeValue = เวลา
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
    ''' NumericNoDecimal = จำนวนเต็ม
    ''' FullDate = 'วัน'dddd'ที่' d MMMM gg yyyy
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
    ''' Funtion นี้ใช้สำหรับแปลงข้อมูลที่ได้รับจาก database หรือ Object ใดๆ ที่มีค่า Null
    ''' ให้เป็นค่า Default ของ Type ต่างๆตามที่เราต้องการ
    ''' ไม่เช่นนั้น หากเรานำค่า Null ไปใช้งานจะทำให้เกิด Error ได้
    ''' </summary>
    ''' <param name="Value">Object ที่ต้องการแปลง</param>
    ''' <param name="GetObject">Type ที่ต้องการ</param>
    ''' <returns>ค่า Default ของ Type นั้นๆ</returns>
    ''' <remarks>ค่า Default ของ GetObject คือ StringValue</remarks>
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
    ''' Function นี้ใช้สำหรับ set format ของ object ต่างๆ
    ''' เช่น Format ของวันที่แบบสั้น,ยาว
    ''' Format ของเวลา
    ''' หรือ Format ของเลขทศนิยม
    ''' </summary>
    ''' <param name="Target">Object ที่ต้องการ set format</param>
    ''' <param name="FormatType">รูปแบบของ Format</param>
    ''' <returns>Object ที่ถูกจัด format แล้ว</returns>
    ''' <remarks>ค่า Default ของ FormatType คือ Numeric</remarks>
    Public Shared Function setObjectFormat(ByVal Target As Object, Optional ByVal FormatType As ObjectFormatEnum = ObjectFormatEnum.Numeric) As String

        Select Case FormatType
            Case ObjectFormatEnum.FullDate
                If IsDate(Target) Then
                    Return Format(CDate(Target), "'วัน'dddd'ที่' d MMMM gg yyyy")
                Else
                    Return Format(Date.Now, "'วัน'dddd'ที่' d MMMM gg yyyy")
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
