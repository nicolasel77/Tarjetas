Public Class frmEntradas

    Private vEstilo As C1.Win.C1FlexGrid.CellStyle
    Private cId As Byte
    Private cSuc As Byte
    Private cFecha As Byte
    Private cTipo As Byte
    Private cImporte As Byte
    Private cAcreditado As Byte


    Private dbG As New clsBases.Principal("dbGastos")

    Private Sub frmEntradas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With grdEntradas
            Dim n() As Integer = {13, 32, 42, 43, 45, 47, 112, 123}
            .TeclasManejadas = n

            Dim s As String
            s = "SELECT Id, Suc, Fecha, Id_Tipo, Nombre AS Descripcion, Importe, Acreditado FROM vw_EntradasTarjeta WHERE Id=0"

            Dim dt As DataTable = dbG.Datos(s)
            .MostrarDatos(dt, True)

            cId = .ColIndex("Id")
            cSuc = .ColIndex("Suc")
            cFecha = .ColIndex("Fecha")
            cTipo = .ColIndex("Id_Tipo")
            cImporte = .ColIndex("Importe")
            cAcreditado = .ColIndex("Acreditado")

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
            vEstilo.Format = "#,###,###.#"
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
                    If IsDate(.Texto(f, 0)) Then
                        If .Texto(f, cProv) > 0 And .Texto(f, cSuc) > 0 And .Texto(f, cProd) > 0 Then
                            .Texto = a
                            .Texto(f, c + 1) = .Texto(f, cCompra) * .Texto(f, cKilos)
                            .Texto(f, c + 2) = .Texto(f, cVenta) * .Texto(f, cKilos)
                            '*******************
                            'Datos
                            '*******************
                            If vId Then
                                n = String.Format("UPDATE Venta SET Kilos={0} WHERE Id={1}", FormatearValorAlCornudoDeSql(a), vId)
                            Else
                                n = String.Format("INSERT INTO Venta (Fecha, CodProov, CodSuc, Nombre, CodProd, Tip, CostoCompra, CostoVenta, Kilos) VALUES ({0}, {1}, {2}, '{3}', {4}, '{5}', {6}, {7}, {8})",
                                                 FormatearValorAlCornudoDeSql(.Texto(f, 0)),
                                                 .Texto(f, cProv),
                                                 .Texto(f, cSuc),
                                                 .Texto(f, cSuc + 1),
                                                 .Texto(f, cProd),
                                                 .Texto(f, cProd + 1),
                                                 FormatearValorAlCornudoDeSql(.Texto(f, cCompra)),
                                                 FormatearValorAlCornudoDeSql(.Texto(f, cVenta)),
                                                 FormatearValorAlCornudoDeSql(a))
                            End If
                            '*******************
                            'ON NEW
                            '*******************
                            If f = .Rows - 1 Then
                                .Filas.Add()
                                If rdFecha.Checked Then
                                    .Texto(f + 1, 0) = DateAdd(DateInterval.Day, 1, .Texto(f, 0))
                                Else
                                    .Texto(f + 1, 0) = .Texto(f, 0)
                                End If
                                If rdProv.Checked Then
                                    Dim pr As Integer = .Texto(f, cProv)
                                    Dim ns As String = Proxima_Proveedor(pr)
                                    Dim pp As Single = Costo_Proveedor(.Texto(f, 0), pr, .Texto(f, cProd))
                                    .Texto(f + 1, cProv) = pr
                                    .Texto(f + 1, cCompra) = pp
                                Else
                                    .Texto(f + 1, cProv) = .Texto(f, cProv)
                                    .Texto(f + 1, cCompra) = .Texto(f, cCompra)
                                End If
                                If rdSuc.Checked Then
                                    Dim pr As Integer = .Texto(f, cSuc)
                                    Dim ns As String = Proxima_Sucursal(pr)
                                    Dim pp As Single = Costo_Sucursal(.Texto(f, 0), pr, .Texto(f, cProd))
                                    .Texto(f + 1, cSuc) = pr
                                    .Texto(f + 1, cSuc + 1) = ns
                                    .Texto(f + 1, cVenta) = pp
                                Else
                                    .Texto(f + 1, cSuc) = .Texto(f, cSuc)
                                    .Texto(f + 1, cSuc + 1) = .Texto(f, cSuc + 1)
                                    .Texto(f + 1, cVenta) = .Texto(f, cVenta)
                                End If
                                If rdProd.Checked Then
                                    Dim pr As Integer = .Texto(f, cProd)
                                    Dim ns As String = Proximo_Producto(pr)

                                    .Texto(f + 1, cProd) = pr
                                    .Texto(f + 1, cProd + 1) = ns

                                    Dim pp As Single
                                    pp = Costo_Proveedor(.Texto(f, 0), .Texto(f, cProv), pr)
                                    .Texto(f + 1, cCompra) = pp
                                    pp = Costo_Sucursal(.Texto(f, 0), .Texto(f, cSuc), pr)
                                    .Texto(f + 1, cVenta) = pp
                                Else
                                    .Texto(f + 1, cProd) = .Texto(f, cProd)
                                    .Texto(f + 1, cProd + 1) = .Texto(f, cProd + 1)
                                End If
                            End If
                            .ActivarCelda(f + 1, cKilos)
                        End If
                    End If
                    End If
            End Select
            If n.Length Then
                dbM.EjecutarCadena(n, fn, fn)
                If vId = 0 Then
                    n = dbM.BuscarDato("SELECT MAX(Id) FROM Venta")
                    If IsNumeric(n) Then
                        .Texto(f, cId) = CInt(n)
                    End If
                End If
            End If
            Totales()
            End If
        End With
    End Sub


    Private Function Nombre_Tipo(ByVal Id As Integer) As String
        Return = dbG.BuscarDato("SELECT Nombre FROM Tipo_Cuentas WHERE Id=" & Id)
    End Function
End Class