Imports System.Runtime.CompilerServices
Module Formulas
    Public Function FormatearValorAlCornudoDeSql(ByVal Valor As Object) As String
        Dim a As String = ""
        If Not Valor Is Nothing Then
            Select Case Valor.GetType.ToString
                Case "System.String"
                    a = String.Format("'{0}'", Valor.ToString)
                Case "System.Short", "System.Integer", "System.Int16", "System.Int32", "System.Int64"
                    a = Valor.ToString
                Case "System.Single", "System.Double", "System.Decimal"
                    a = Valor.ToString.Replace(",", ".")
                Case "System.Boolean"
                    If Valor = True Then
                        a = "1"
                    Else
                        a = "0"
                    End If
                Case "System.DateTime"
                    a = String.Format("'{0}'", Format(Valor, "MM/dd/yy"))
                Case Else
                    MsgBox("No esta incorporado el Type:" & Valor.GetType.ToString, MsgBoxStyle.Exclamation)
            End Select
        End If
        Return a
    End Function
End Module
Module E_ListBox
    ''' <summary>
    ''' Devuelve el código seleccionado en una lista con formato Codigo. Descripcion
    ''' ej: 23. Camara
    ''' </summary>
    ''' <param name="lst"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> _
    Public Function Codigo_Seleccionado(ByVal lst As ListBox) As Integer
        Dim i As Integer
        Try
            If lst.SelectedIndex <> -1 Then
                If lst.Text.IndexOf(".") Then
                    Dim s As String = lst.Text.Substring(0, lst.Text.IndexOf("."))
                    If IsNumeric(s) Then i = CInt(s)
                End If
            End If
        Catch er As Exception
            i = 0
        End Try
        Return i
    End Function
End Module

Module MonthsFecha
    ''' <summary>
    ''' Devuelve el valor de la fecha seleccionada en un Monthcalendar
    ''' </summary>
    ''' <param name="c"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> _
    Public Function Fecha(ByVal c As MonthCalendar) As Date
        Return c.SelectionRange.Start.Date
    End Function
End Module

Module E_ListBox2
    ''' <summary>
    ''' Devuelve el nombre seleccionado en una lista con formato Codigo. Descripcion
    ''' ej: 23. Camara
    ''' </summary>
    ''' <param name="lst"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> _
    Public Function Nombre_Seleccionado(ByVal lst As ListBox) As String
        Dim s As String = ""
        If lst.SelectedIndex <> -1 Then
            If lst.Text.IndexOf(".") Then
                s = lst.Text.Substring(lst.Text.IndexOf(".") + 2)
            Else
                s = lst.Text
            End If
        End If
        Return s
    End Function
End Module

Module LstBoxes
    ''' <summary>
    ''' Activa el siguiente elemento
    ''' </summary>
    <Extension()> _
    Public Sub Siguiente(ByVal s As ListBox)
        If s.Items.Count <> 0 Then
            Dim i As Integer = s.SelectedIndex
            If i = -1 Then
                s.SelectedIndex = 0
            Else
                If i = s.Items.Count - 1 Then
                    s.SelectedIndex = 0
                Else
                    s.SelectedIndex = i + 1
                End If
            End If
        End If
    End Sub
End Module

Module LstBoxes_2
    ''' <summary>
    ''' Activa el anterior elemento
    ''' </summary>
    <Extension()> _
    Public Sub Anterior(ByVal s As ListBox)
        If s.Items.Count <> 0 Then
            Dim i As Integer = s.SelectedIndex
            If i = -1 Then
                s.SelectedIndex = s.Items.Count - 1
            Else
                If i = 0 Then
                    s.SelectedIndex = s.Items.Count - 1
                Else
                    s.SelectedIndex = i - 1
                End If
            End If
        End If
    End Sub
End Module

Module Strings
    ''' <summary>
    ''' Devuelve el código seleccionado en un string con formato Codigo. Descripcion
    ''' ej: 23. Camara
    ''' </summary>
    ''' <param name="s"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> _
    Public Function Codigo_Seleccionado(ByVal s As String) As Integer
        Dim i As Integer
        If s.IndexOf(".") > -1 Then
            Try
                Dim n As String = s.Substring(0, s.IndexOf("."))
                If IsNumeric(n) Then i = CInt(n)
            Catch ex As Exception
            End Try
        End If
        Return i
    End Function
End Module

Module Strings2
    ''' <summary>
    ''' Devuelve el código seleccionado en un string con formato Codigo. Descripcion
    ''' ej: 23. Camara
    ''' </summary>
    ''' <param name="s"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> _
    Public Function Nombre_Seleccionado(ByVal s As String) As String
        Dim n As String = ""
        If s.IndexOf(".") > -1 Then
            Try
                n = s.Substring(s.IndexOf(".") + 1)
            Catch ex As Exception
            End Try
        End If
        Return n
    End Function
End Module


Module Dates
    ''' <summary>
    ''' Transforma el valor Date a fecha con formato 'MM/dd/yy'
    ''' </summary>
    ''' <param name="d">Fecha a formatear</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> _
    Public Function Fecha_SQL(ByVal d As Date) As String
        Dim s As String
        s = String.Format("'{0}'", d.ToString("MM/dd/yy"))
        Return s
    End Function
End Module

'Module MonthsFecha2
'    ''' <summary>
'    ''' Devuelve el valor de la fecha seleccionada en un Monthcalendar
'    ''' </summary>
'    ''' <param name="c"></param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    <Extension()> _
'    Public Function Fecha(ByVal c As MonthCalendar) As Date
'        Return c.SelectionRange.Start.Date
'    End Function
'End Module

Module Concatenar_String
    ''' <summary>
    ''' Concatena dos strings con un nexo opcional
    ''' </summary>
    ''' <param name="a"></param>
    ''' <param name="b">Cadena a pegar</param>
    ''' <param name="c">Nexo opcional. Default = " AND "</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> _
    Public Sub Unir(ByRef a As String, ByVal b As String, Optional ByVal c As String = " AND ")
        Dim s As String = a
        If Not a Is Nothing Then
            If a.Length > 0 Then
                If b.Length Then
                    s = String.Format("{0} {1} {2}", a, c, b)
                End If
            Else
                If b.Length Then
                    s = b
                End If
            End If
        End If
        a = s
    End Sub
End Module

Module Concatenar_String_Funcion
    Public Function UnirStrings(ByRef a As String, ByVal b As String, Optional ByVal c As String = " AND ") As String
        Dim s As String = a
        If a Is Nothing Then
            a = ""
        End If

        If a.Length > 0 Then
            If b.Length Then
                s = String.Format("{0} {1} {2}", a, c, b)
            End If
        Else
            If b.Length Then
                s = b
            End If
        End If
        Return s
    End Function
End Module

Module Convertir_Char2Int
    ''' <summary>
    ''' Concatena dos strings con un nexo opcional
    ''' </summary>
    ''' <param name="a"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> _
    Public Function CharToInt(ByVal a As  KeyPressEventArgs) As Integer
        Dim n As Integer
        n = Asc(a.KeyChar)
        Return n
    End Function
End Module