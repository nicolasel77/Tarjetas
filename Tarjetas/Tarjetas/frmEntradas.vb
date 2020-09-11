Public Class frmEntradas

    Private vEstilo As C1.Win.C1FlexGrid.CellStyle
    Private cId As Byte
    Private cSuc As Byte
    Private cFecha As Byte
    Private cTipo As Byte
    Private cImporte As Byte
    Private cAcreditado As Byte

    Private gId As Byte
    Private gSuc As Byte
    Private gFecha As Byte
    Private gTipo As Byte
    Private gImporte As Byte

    Private Fecha As Date

    Private dbG As New clsBases.Principal("dbGastos")

    Private Sub frmEntradas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim s As String
        Dim n() As Integer = {13, 32, 42, 43, 45, 46, 47, 112, 123}

        With grdEntradas
            .TeclasManejadas = n

            s = "SELECT Id, Suc, Fecha, Id_Tipo, Nombre AS Descripcion, Importe, Acreditado FROM vw_EntradasTarjeta WHERE Id=0"

            Dim dt As DataTable = dbG.Datos(s)
            .MostrarDatos(dt, True)

            cId = .ColIndex("Id")
            cSuc = .ColIndex("Suc")
            cFecha = .ColIndex("Fecha")
            cTipo = .ColIndex("Id_Tipo")
            cImporte = .ColIndex("Importe")
            cAcreditado = .ColIndex("Acreditado")

            Formato_Entradas
        End With

        With grdGastos
            .TeclasManejadas = n

            s = "SELECT Id, Suc, Fecha, Tipo, Nombre AS Descripcion, Importe FROM vw_GastosTarjeta WHERE Id=0"

            Dim dt As DataTable = dbG.Datos(s)
            .MostrarDatos(dt, True)

            gId = .ColIndex("Id")
            gSuc = .ColIndex("Suc")
            gFecha = .ColIndex("Fecha")
            gTipo = .ColIndex("Tipo")
            gImporte = .ColIndex("Importe")

            .ColW(0) = 0
            .ColW(gSuc) = 30
            .ColW(gFecha) = 60
            .ColW(gTipo) = 40
            .ColW(gTipo + 1) = 80
            .ColW(gImporte) = 80


            'El estilo para pintar la columna total
            vEstilo = grdGastos.Styles.Add("Importe")
            vEstilo.Font = New Font("Arial", 8, FontStyle.Bold)
            vEstilo.Format = "#,###,###.##"
            vEstilo.DataType = GetType(Double)
            vEstilo.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightBottom
            grdGastos.Columnas(gImporte).Style = vEstilo

        End With
    End Sub

    Private Sub Formato_Entradas()
        With grdEntradas
            .ColW(0) = 0
            .ColW(cSuc) = 30
            .ColW(cFecha) = 60
            .ColW(cTipo) = 40
            .ColW(cTipo + 1) = 80
            .ColW(cImporte) = 80
            .ColW(cAcreditado) = 55


            'El estilo para pintar la columna total
            vEstilo = grdEntradas.Styles.Add("Importe")
            vEstilo.Font = New Font("Arial", 8, FontStyle.Bold)
            vEstilo.Format = "#,###,###.##"
            vEstilo.DataType = GetType(Double)
            vEstilo.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightBottom
            grdEntradas.Columnas(cImporte).Style = vEstilo
        End With
    End Sub

    Private Sub grdEntradas_Editado(f As Short, c As Short, a As Object) Handles grdEntradas.Editado
        With grdEntradas
            Dim vId As Integer = .Texto(f, cId)
            Dim n As String = ""

            Select Case c
                Case cSuc
                    .Texto = a
                    .ActivarCelda(f, cFecha)
                    If vId Then
                        n = String.Format("UPDATE Entradas_Tarjeta SET Suc={0} WHERE Id={1}", a, vId)
                    End If
                Case cFecha
                    .Texto = a
                    If vId Then
                        n = String.Format("UPDATE Entradas_Tarjeta SET Fecha={0} WHERE Id={1}", CDate(a).Fecha_SQL, vId)
                    End If
                    .ActivarCelda(f, cTipo)

                Case cTipo
                    Dim s As String = Nombre_Tipo(a)
                    If s.Length Then
                        .Texto = a
                        .Texto(f, c + 1) = s
                        If vId Then
                            n = String.Format("UPDATE Entradas_Tarjeta SET Id_Tipo={0} WHERE Id={1}", a, vId)
                        End If
                        .ActivarCelda(f, cImporte)
                    Else
                        Beep()
                        .ErrorEnTxt()
                    End If

                Case cImporte
                    If IsDate(.Texto(f, cFecha)) Then
                        If .Texto(f, cSuc) > 0 And .Texto(f, cTipo) > 0 Then
                            .Texto = a

                            If chAuto.Checked Then
                                .Texto(f, cImporte + 1) = True
                            End If
                            Dim vAuto As String = "0"
                            If .Texto(f, cImporte + 1) = True Then vAuto = "1"
                            '*******************
                            'Datos
                            '*******************
                            If vId Then
                                n = String.Format("UPDATE Entradas_Tarjeta SET Importe={0} WHERE Id={1}", FormatearValorAlCornudoDeSql(a), vId)
                            Else
                                n = String.Format("INSERT INTO Entradas_Tarjeta (Suc, Fecha, Id_Tipo, Importe, Acreditado) VALUES ({0}, {1}, {2}, {3}, {4})",
                                                  .Texto(f, cSuc),
                                                  FormatearValorAlCornudoDeSql(.Texto(f, cFecha)),
                                                 .Texto(f, cTipo),
                                                 FormatearValorAlCornudoDeSql(a),
                                                 vAuto)
                            End If
                            '*******************
                            'ON NEW
                            '*******************
                            If f = .Rows - 1 Then
                                .Filas.Add()
                                If rdSuc.Checked Then
                                    .Texto(f + 1, cSuc) = Siguiente_Sucursal(.Texto(f, cSuc))
                                Else
                                    .Texto(f + 1, cSuc) = .Texto(f, cSuc)
                                End If

                                If rdFecha.Checked Then
                                    If dtSemana.Checked Then
                                        Dim vF As Date = .Texto(f, cFecha)

                                        lblNada.Text = $"vF: {vF.ToShortDateString }  *  dt: {dtSemana.Value.Date} * Dif:{DateDiff(DateInterval.Day, dtSemana.Value.Date, vF)}"
                                        If DateDiff(DateInterval.Day, dtSemana.Value, vF) = 5 Then
                                            .Texto(f + 1, cFecha) = dtSemana.Value
                                            .Texto(f + 1, cSuc) = Siguiente_Sucursal(.Texto(f, cSuc))
                                        Else
                                            .Texto(f + 1, cFecha) = CDate(.Texto(f, cFecha)).AddDays(1)
                                        End If
                                    End If
                                Else
                                    .Texto(f + 1, cFecha) = .Texto(f, cFecha)
                                End If

                                If chRepetirTipo.Checked Then
                                    .Texto(f + 1, cTipo) = .Texto(f, cTipo)
                                    .Texto(f + 1, cTipo + 1) = .Texto(f, cTipo + 1)
                                End If
                                If chAuto.Checked Then
                                    .Texto(f + 1, cImporte + 1) = True
                                End If
                            End If
                            If chRepetirTipo.Checked Then
                                .ActivarCelda(f + 1, cImporte)
                            Else
                                .ActivarCelda(f + 1, cTipo)
                            End If

                        Else
                            .ActivarCelda(f + 1, cTipo)
                        End If
                        Dim t As Single = grdEntradas.SumarCol(grdEntradas.ColIndex("Importe"), False)
                        lblSuma.Text = "Suma: " & t
                    Else
                        If .Texto(f, cSuc) > 0 Then
                            .ActivarCelda(f + 1, cSuc)
                        Else
                            .ActivarCelda(f + 1, cTipo)
                        End If
                    End If
                Case cAcreditado
                    .Texto(f, c) = a
                    If vId Then
                        n = String.Format("UPDATE Entradas_Tarjeta SET Acreditado={0} WHERE Id={1}", FormatearValorAlCornudoDeSql(a), vId)
                        .ActivarCelda(f + 1, c)
                    Else
                        Beep()
                        .ActivarCelda(f, cSuc)
                    End If

            End Select
            If n.Length Then
                dbG.EjecutarCadena(n)
                If vId = 0 Then
                    n = dbG.BuscarDato("SELECT MAX(Id) FROM Entradas_Tarjeta")
                    If IsNumeric(n) Then
                        .Texto(f, cId) = CInt(n)
                    End If
                End If
                Saldo_General()
            End If

        End With
    End Sub

    Private Function Siguiente_Sucursal(v As Object) As Int16
        Dim s As String = db.BuscarDato($"SELECT TOP 1 Sucursal FROM dbM.dbo.Sucursales WHERE Tarjeta=1 AND Sucursal>{v} ORDER BY Sucursal")
        If s = "" Then
            s = db.BuscarDato($"SELECT TOP 1 Sucursal FROM dbM.dbo.Sucursales WHERE Tarjeta=1 ORDER BY Sucursal")
        End If
        If s = "" Then
            Return 0
        Else
            Return CInt(s)
        End If
    End Function

    Private Sub grdGastos_Editado(f As Short, c As Short, a As Object) Handles grdGastos.Editado
        With grdGastos
            Dim vId As Integer = .Texto(f, gId)
            Dim n As String = ""

            Select Case c
                Case gSuc
                    .Texto = a
                    .ActivarCelda(f, gFecha)
                    If vId Then
                        n = String.Format("UPDATE Gastos_Tarjeta SET Suc={0} WHERE Id={1}", a, vId)
                    End If
                Case gFecha
                    .Texto = a
                    If vId Then
                        n = String.Format("UPDATE Gastos_Tarjeta SET Fecha={0} WHERE Id={1}", CDate(a).Fecha_SQL, vId)
                    End If
                    .ActivarCelda(f, gTipo)

                Case gTipo
                    Dim s As String = Nombre_TipoGT(a)
                    If s.Length Then
                        .Texto = a
                        .Texto(f, c + 1) = s
                        If vId Then
                            n = String.Format("UPDATE Gastos_Tarjeta SET Tipo={0} WHERE Id={1}", a, vId)
                        End If
                        .ActivarCelda(f, gImporte)
                    Else
                        Beep()
                        .ErrorEnTxt()
                    End If

                Case gImporte
                    If IsDate(.Texto(f, gFecha)) Then
                        If .Texto(f, gSuc) > 0 And .Texto(f, gTipo) > 0 Then
                            .Texto = a
                            '*******************
                            'Datos
                            '*******************
                            If vId Then
                                n = String.Format("UPDATE Gastos_Tarjeta SET Importe={0} WHERE Id={1}", FormatearValorAlCornudoDeSql(a), vId)
                            Else
                                n = String.Format("INSERT INTO Gastos_Tarjeta (Suc, Fecha, Tipo, Importe) VALUES ({0}, {1}, {2}, {3})",
                                                  .Texto(f, gSuc),
                                                  FormatearValorAlCornudoDeSql(.Texto(f, gFecha)),
                                                 .Texto(f, gTipo),
                                                 FormatearValorAlCornudoDeSql(a))
                            End If
                            '*******************
                            'ON NEW
                            '*******************
                            If f = .Rows - 1 Then
                                .Filas.Add()
                                .Texto(f + 1, gSuc) = .Texto(f, gSuc)
                                .Texto(f + 1, gFecha) = .Texto(f, gFecha)

                            End If
                            .ActivarCelda(f + 1, gTipo)
                        Else
                            .ActivarCelda(f + 1, gTipo)
                        End If
                    Else
                        If .Texto(f, gSuc) > 0 Then
                            .ActivarCelda(f + 1, gSuc)
                        Else
                            .ActivarCelda(f + 1, gTipo)
                        End If
                    End If


            End Select
            If n.Length Then
                dbG.EjecutarCadena(n)
                If vId = 0 Then
                    n = dbG.BuscarDato("SELECT MAX(Id) FROM Gastos_Tarjeta")
                    If IsNumeric(n) Then
                        .Texto(f, gId) = CInt(n)
                    End If
                End If
                Saldo_General()
            End If

        End With
    End Sub



    Private Function Nombre_Tipo(ByVal Id As Integer) As String
        Return dbG.BuscarDato("SELECT Nombre FROM Tipo_Cuentas WHERE Id=" & Id)
    End Function
    Private Function Nombre_TipoGT(ByVal Id As Integer) As String
        Return dbG.BuscarDato("SELECT Nombre FROM Tipo_GastosTarjeta WHERE Id=" & Id)
    End Function


    Private Sub mntFecha_DateChanged(sender As Object, e As DateRangeEventArgs) Handles mntFecha.DateChanged
        If mntFecha.SelectionStart.Date <> Fecha Then
            Me.Cursor = Cursors.WaitCursor
            Cargar_Entradas()
            Cargar_Gastos()
            Saldo_General()
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub Saldo_General()
        Dim s As String = dbG.BuscarDato($"SELECT dbo.f_SaldoTarjetasGeneral({Fecha.Fecha_SQL}, 0)")
        lblSaldo.Text = "Saldo General: " & Format(Convert.ToSingle(s), "$ #,###.#")
    End Sub

    Private Sub Cargar_Entradas()
        Fecha = mntFecha.SelectionStart.Date
        Dim s As String, suc As String
        suc = cSucs.DevolverCadena("Suc")
        If suc.Length Then suc = " AND " & suc
        s = $"SELECT Id, Suc, Fecha, Id_Tipo, Nombre AS Descripcion, Importe, Acreditado FROM vw_EntradasTarjeta WHERE Fecha={Fecha.Fecha_SQL}{suc} ORDER BY Id"

        Dim dt As DataTable = dbG.Datos(s)
        grdEntradas.MostrarDatos(dt, True)

        Formato_Entradas()
        grdEntradas.ActivarCelda(grdEntradas.Rows - 1, cSuc)
        Dim t As Single = grdEntradas.SumarCol(grdEntradas.ColIndex("Importe"), False)
        lblSuma.Text = "Suma: " & t
    End Sub
    Private Sub Cargar_Gastos()
        Fecha = mntFecha.SelectionStart.Date
        Dim s As String
        s = $"SELECT Id, Suc, Fecha, Tipo, Nombre AS Descripcion, Importe FROM vw_GastosTarjeta WHERE Fecha<={Fecha.Fecha_SQL} ORDER BY Id"

        Dim dt As DataTable = dbG.Datos(s)
        grdGastos.MostrarDatos(dt, False)
        grdGastos.ActivarCelda(grdGastos.Rows - 1, cSuc)
    End Sub

    Private Sub cmdLimpiar_Click(sender As Object, e As EventArgs) Handles cmdLimpiar.Click
        grdEntradas.Rows = 1
        grdEntradas.Rows = 2
        grdGastos.Rows = 1
        grdGastos.Rows = 2
    End Sub

    Private Sub grdEntradas_KeyUp(sender As Object, e As Short) Handles grdEntradas.KeyUp
        If e = Keys.Delete Then
            If MsgBox("Esta seguro de borrar el registro?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.DefaultButton1, "Borrar") = MsgBoxResult.Yes Then
                With grdEntradas
                    Dim vId As Integer = .Texto(.Row, .ColIndex("Id"))
                    If vId Then
                        db.EjecutarCadena("DELETE FROM Entradas_Tarjeta WHERE Id=" & vId)
                        grdEntradas.BorrarFila()
                    End If
                End With
            End If
        End If
    End Sub
End Class