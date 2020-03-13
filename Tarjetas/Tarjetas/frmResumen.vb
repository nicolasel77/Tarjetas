Public Class frmResumen
    Private db As New clsBases.Principal("dbGastos")

    Private Sub Cargar()
        Entradas()
        Gastos()
        Salidas()
        Resumen()
    End Sub

    Private Sub Salidas()
        Dim dt As DataTable = db.Datos($"SELECT * FROM vw_SalidasTarjeta WHERE Fecha BETWEEN {cFecha.ValorActual.Fecha_SQL} AND {cFecha.ValorActualHasta.Fecha_SQL} ORDER BY Fecha, Tipo")
        With grdSaldias
            .MostrarDatos(dt, True)
            .SumarCol(.ColIndex("Importe"), True)
            .Columnas(.ColIndex("Importe")).Format = "#,###.#"
            .AutosizeAll()
            .ColW(0) = 0
        End With
    End Sub

    Private Sub Resumen()
        Dim dt As DataTable = db.SP_SelectDT("sp_ResumenTarjetas", cFecha.ValorActualHasta, 0)
        With grdSaldos
            .MostrarDatos(dt, True)
            .SumarCol(.ColIndex("Saldo"), True)
            For i As Integer = 1 To .Cols - 1
                .Columnas(i).Format = "#,###.#"
            Next
            .AutosizeAll()
        End With

    End Sub

    Private Sub Entradas()
        Dim f1 As Date = cFecha.ValorActual
        Dim f2 As Date = cFecha.ValorActualHasta

        Dim s As String = "SELECT {0} FROM vw_EntradasTarjeta WHERE Fecha BETWEEN {1} AND {2} {3} {4}"
        Dim Campos As String = "", groupby As String = "", acreditado As String = " AND Acreditado=1"

        If chAcreditado.Checked = False Then acreditado = ""

        If chAgrupar.Checked = True Then
            If chSuc.Checked Then
                Campos = "Suc"
                groupby = "Suc"
            End If
            If chFecha.Checked Then
                Unir(Campos, "Fecha", ",")
            End If
            If chTipo.Checked Then
                Unir(Campos, "Id_Tipo, Nombre", ",")
            End If

            groupby = "GROUP BY " & Campos
            Unir(Campos, "SUM(Importe) AS Total", ", ")

            s = String.Format(s, Campos, f1.Fecha_SQL, f2.Fecha_SQL, acreditado, groupby)
        Else
            Campos = "*"
            s = String.Format(s & "ORDER BY Id", Campos, f1.Fecha_SQL, f2.Fecha_SQL, acreditado, "")
        End If

        Dim dt As DataTable = db.Datos(s)

        With grdEntradas
            .MostrarDatos(dt, True, True)
            .Columnas(.Cols - 1).Format = "#,###.#"
            .SumarCol(.ColIndex("Total"))
            .SumarCol(.ColIndex("Importe"))
            .AutosizeAll()
            .ColW(.ColIndex("Nombre")) = 80

        End With

    End Sub
    Private Sub Gastos()
        Dim f1 As Date = cFecha.ValorActual
        Dim f2 As Date = cFecha.ValorActualHasta

        Dim s As String = "SELECT {0} FROM vw_GastosTarjeta WHERE Fecha BETWEEN {1} AND {2} {3}"
        Dim Campos As String = "", groupby As String = ""

        If chGAgrupar.Checked = True Then
            If chGSuc.Checked Then
                Campos = "Suc"
                groupby = "Suc"
            End If
            If chGFecha.Checked Then
                Unir(Campos, "Fecha", ",")
            End If
            If chGTipo.Checked Then
                Unir(Campos, "Tipo, Nombre", ",")
            End If

            groupby = "GROUP BY " & Campos
            Unir(Campos, "SUM(Importe) AS Total", ", ")

            s = String.Format(s, Campos, f1.Fecha_SQL, f2.Fecha_SQL, groupby)
        Else
            Campos = "*"
            s = String.Format(s, Campos, f1.Fecha_SQL, f2.Fecha_SQL, "")
        End If

        Dim dt As DataTable = db.Datos(s)

        With grdGastos
            .MostrarDatos(dt, True, True)
            .Columnas(.Cols - 1).Format = "#,###.#"
            .SumarCol(.ColIndex("Total"))
            .SumarCol(.ColIndex("Importe"))
            .AutosizeAll()
            .ColW(.ColIndex("Nombre")) = 80

        End With

    End Sub

    Private Sub cmdCargar_Click(sender As Object, e As EventArgs) Handles cmdCargar.Click
        Cargar()
    End Sub

    Private Sub chAgrupar_CheckedChanged(sender As Object, e As EventArgs) Handles chAgrupar.CheckedChanged
        chSuc.Enabled = chAgrupar.Checked
        chFecha.Enabled = chAgrupar.Checked
        chTipo.Enabled = chAgrupar.Checked
        Entradas()
    End Sub
    Private Sub chAgruparGastos_CheckedChanged(sender As Object, e As EventArgs) Handles chGAgrupar.CheckedChanged
        chGSuc.Enabled = chGAgrupar.Checked
        chGFecha.Enabled = chGAgrupar.Checked
        chGTipo.Enabled = chGAgrupar.Checked
        Gastos()
    End Sub

    Private Sub chAcreditado_CheckedChanged(sender As Object, e As EventArgs) Handles chAcreditado.CheckedChanged, chFecha.CheckedChanged, chSuc.CheckedChanged, chTipo.CheckedChanged
        Entradas()
    End Sub
    Private Sub chGastos_CheckedChanged(sender As Object, e As EventArgs) Handles chGFecha.CheckedChanged, chGSuc.CheckedChanged, chGTipo.CheckedChanged
        Gastos()
    End Sub

    Private Sub cFecha_CambioSeleccion() Handles cFecha.CambioSeleccion
        Cargar()
    End Sub

End Class