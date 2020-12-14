Public Class frmLeer
    Private fCarpeta As String = "E:\Tarjetas"
    Private dt As DataTable = db.Datos("SELECT * FROM Entradas_Tarjeta WHERE ID=-1")

    Private Sub frmLeer_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim s As String = db.BuscarDato("SELECT TOP 1 Valor FROM Varios.dbo.Varios WHERE Dato='fCarpeta'")
        If s.Length = 0 Then
            db.EjecutarCadena($"INSERT INTO Varios.dbo.Varios (Dato, Valor) VALUES ('fCarpeta', '{fCarpeta}')")
        Else
            fCarpeta = s
        End If

        cmdCarpeta.Text = "Carpeta: " & fCarpeta
        Llenar_List(lstTipo, "dbGastos.dbo.Tipo_Cuentas")

        grdDatos.MostrarDatos(dt, True)
        grdDatos.AutosizeAll()
        grdDatos.ColW(0) = 0

        grdCuentas.MostrarDatos(db.Datos("SELECT * FROM vw_SucCuentas ORDER BY Suc, Tipo"), True, False)
        grdCuentas.AutosizeAll()

        Dim n() As Integer = {13, 32, 42, 43, 45, 46, 47, 112, 123}
        grdCuentas.TeclasManejadas = n
    End Sub
    Private Sub cmdLeer_Click(sender As Object, e As EventArgs) Handles cmdLeer.Click
        Dim f As New OpenFileDialog()

        f.InitialDirectory = fCarpeta
        f.ShowDialog()
        Dim s As String = f.FileName

        If s.Length Then
            lblArchivo.Text = s
            Dim n As String = s.Substring(s.LastIndexOf("\") + 1)
            n = n.Substring(0, n.LastIndexOf(" "))
            s = db.BuscarDato("SELECT Nombre FROM Sucursales WHERE Sucursal=" & n)
            lblSucursal.Text = s

            If lstTipo.SelectedIndex > -1 Then cmdEscribir.PerformClick()
        End If

    End Sub

    Private Sub Mover_Archivo()
        Dim s As String = lblArchivo.Text
        Dim n As String = s.Substring(s.LastIndexOf("\") + 1)
        Dim i As Integer = 1
        n = fCarpeta & "\Back\" & n

        If n.LastIndexOf(".") > -1 Then
            Dim ex As String = n.Substring(n.LastIndexOf("."))

            While My.Computer.FileSystem.FileExists(n)
                n = n.Substring(0, n.LastIndexOf("."))
                n &= i & ex
                i += 1
            End While
            cmdGuardado.Text = "Guardado: " & n
            lblArchivo.Text = ""

            My.Computer.FileSystem.MoveFile(s, n)
        End If

    End Sub

    Private Sub cmdEscribir_Click(sender As Object, e As EventArgs) Handles cmdEscribir.Click
        Escribir()
    End Sub

    Private Sub Escribir(Optional Tipo As String = "")
        Me.Cursor = Cursors.WaitCursor
        lblTotal.Text = ""
        If lblArchivo.Text.Length Then
            If lstTipo.SelectedIndex > -1 Or Tipo.Length > 0 Then
                Dim s As String = lblArchivo.Text
                Dim Suc As String = s.Substring(s.LastIndexOf("\") + 1)
                Suc = Suc.Substring(0, Suc.LastIndexOf(" "))

                Dim xApp As Object
                Dim xLibros As Object
                Dim xLibro As Object
                xApp = CreateObject("excel.application")
                xLibros = xApp.Workbooks
                xLibros.Open(s)
                xLibro = xApp.ActiveWorkbook

                xApp.Workbooks.Open(s)
                xApp.Worksheets.Item(1).Activate()


                Dim vFecha As String
                Dim vLote As String
                Dim vComprobante As String
                Dim vTarjeta As String

                Dim vTipo As Integer = lstTipo.Text.Codigo_Seleccionado
                Dim vImporte As String
                Dim vPago As String

                If Tipo.Length Then vTipo = Tipo

                dt.Rows.Clear()
                For i As Integer = 2 To 500000
                    Dim nn As String = xApp.Range("A" & i).text
                    If nn = "" Then Exit For

                    nn = nn.Substring(nn.IndexOf(";") + 1)

                    vLote = nn.Substring(0, nn.IndexOf(";"))
                    nn = nn.Substring(nn.IndexOf(";") + 1)

                    vPago = nn.Substring(0, nn.IndexOf(";"))
                    nn = nn.Substring(nn.IndexOf(";") + 1)

                    nn = nn.Substring(nn.IndexOf(";") + 1)


                    vFecha = nn.Substring(0, nn.IndexOf(";"))
                    nn = nn.Substring(nn.IndexOf(";") + 1)

                    vComprobante = nn.Substring(0, nn.IndexOf(";"))
                    nn = nn.Substring(nn.IndexOf(";") + 1)

                    vTarjeta = nn.Substring(0, nn.IndexOf(";"))
                    nn = nn.Substring(nn.IndexOf(";") + 1)

                    nn = nn.Substring(nn.IndexOf(";") + 1)

                    vImporte = nn.Replace(".", ",")

                    Dim dr As DataRow = dt.NewRow

                    If IsNumeric(vLote) Then dr.Item("Lote") = CInt(vLote)
                    If IsDate(vPago) Then dr.Item("Fecha_Pago") = CDate(vPago)
                    If IsNumeric(vImporte) Then dr.Item("Importe") = CDbl(vImporte)
                    If IsDate(vFecha) Then dr.Item("Fecha") = CDate(vFecha)
                    If IsNumeric(vComprobante) Then dr.Item("Comprobante") = CInt(vComprobante)
                    If IsNumeric(vTarjeta) Then dr.Item("Tarjeta") = CInt(vTarjeta)

                    dr.Item("Id_Tipo") = vTipo
                    dr.Item("Suc") = CInt(Suc)
                    dr.Item("Acreditado") = True

                    dt.Rows.Add(dr)
                Next

                grdDatos.MostrarDatos(dt, True, False)
                grdDatos.AutosizeAll()
                grdDatos.ColW(0) = 0
                Dim t As Double = grdDatos.SumarCol(grdDatos.ColIndex("Importe"), False)
                lblTotal.Text = "Total: " & t.ToString("C1")

                xApp.Quit()
                xLibro = Nothing
                xLibros = Nothing
                xApp = Nothing

                Application.DoEvents()
                If chAuto.Checked Then cmdGuardar.PerformClick()
            Else
                MsgBox("Debe seleccionar el tipo de tarjeta.")
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Me.Cursor = Cursors.WaitCursor
        Dim vBorrar As String = "DELETE FROM Entradas_Tarjeta WHERE [Fecha]={0} AND [Importe]={1} AND [Suc]={2} AND Lote={3} AND Comprobante={4} AND Tarjeta={5}"
        Dim vAgregar As String = "INSERT INTO Entradas_Tarjeta ([Fecha], [Id_Tipo], [Importe], [Acreditado], [Suc], [Fecha_Pago], Lote, Comprobante, Tarjeta) VALUES({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8})"
        With grdDatos
            Dim s As String
            For i As Integer = 1 To .Rows - 1

                s = String.Format(vBorrar, FormatearValorAlCornudoDeSql(.Texto(i, .ColIndex("Fecha"))) _
                    , FormatearValorAlCornudoDeSql(.Texto(i, .ColIndex("Importe"))) _
                    , .Texto(i, .ColIndex("Suc")) _
                    , .Texto(i, .ColIndex("Lote")) _
                    , .Texto(i, .ColIndex("Comprobante")) _
                    , .Texto(i, .ColIndex("Tarjeta")))

                db.EjecutarCadena(s)

                s = String.Format(vAgregar, FormatearValorAlCornudoDeSql(.Texto(i, .ColIndex("Fecha"))) _
                    , .Texto(i, .ColIndex("Id_Tipo")) _
                    , FormatearValorAlCornudoDeSql(.Texto(i, .ColIndex("Importe"))) _
                    , FormatearValorAlCornudoDeSql(.Texto(i, .ColIndex("Acreditado"))) _
                    , .Texto(i, .ColIndex("Suc")) _
                    , FormatearValorAlCornudoDeSql(.Texto(i, .ColIndex("Fecha_Pago"))) _
                    , .Texto(i, .ColIndex("Lote")) _
                    , .Texto(i, .ColIndex("Comprobante")) _
                    , .Texto(i, .ColIndex("Tarjeta")))

                db.EjecutarCadena(s)
            Next
            .Rows = 1

            lblSucursal.Text = ""
            lblTotal.Text = ""
        End With
        Mover_Archivo()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub lstTipo_DoubleClick(sender As Object, e As EventArgs) Handles lstTipo.DoubleClick
        cmdLeer.PerformClick()
    End Sub

    Private Sub chAuto_CheckedChanged(sender As Object, e As EventArgs) Handles chAuto.CheckedChanged
        tiAuto.Enabled = chAuto.Checked
    End Sub

    Private Sub tiAuto_Tick(sender As Object, e As EventArgs) Handles tiAuto.Tick
        Dim f = My.Computer.FileSystem.GetFiles(fCarpeta, FileIO.SearchOption.SearchTopLevelOnly, "*.csv")

        For Each s As String In My.Computer.FileSystem.GetFiles(fCarpeta, FileIO.SearchOption.SearchTopLevelOnly, "*.csv")
            lblArchivo.Text = s
            Dim n As String = s.Substring(s.LastIndexOf("\") + 1)

            Dim t As String = s.Substring(s.LastIndexOf(" ") + 1)
            t = t.Substring(0, t.IndexOf("."))

            n = n.Substring(0, n.LastIndexOf(" "))

            s = db.BuscarDato("SELECT Nombre FROM Sucursales WHERE Sucursal=" & n)
            lblSucursal.Text = s

            Escribir(t)
        Next
    End Sub

    Private Sub cmdCarpeta_Click(sender As Object, e As EventArgs) Handles cmdCarpeta.Click
        Dim fc As New FolderBrowserDialog

        If fc.ShowDialog = DialogResult.OK Then
            fCarpeta = fc.SelectedPath
            cmdCarpeta.Text = "Carpeta: " & fCarpeta
            db.EjecutarCadena("DELETE FROM Varios.dbo.Varios WHERE Dato LIKE 'fCarpeta'")
            db.EjecutarCadena($"INSERT INTO Varios.dbo.Varios (Dato, Valor) VALUES ('fCarpeta', '{fCarpeta}')")
        End If


    End Sub

    Private Sub grdCuentas_KeyUp(sender As Object, e As Short) Handles grdCuentas.KeyUp
        If e = Keys.Delete Then
            grdCuentas.BorrarFila()
        End If
    End Sub
End Class