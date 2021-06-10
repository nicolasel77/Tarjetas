Option Explicit On 
Imports System.Threading
Public Class Principal
    Public Structure Producto
        Dim Cod As Int16
        Dim Nombre As String
        Dim Tipo As Int16
        Dim Ver As Boolean
        Dim Imp As Boolean
    End Structure
	'Nicolas ******
	'miércoles, 22 de septiembre de 2004
    'Descripción:
    '      Clase principal donde se maneja TODO lo 
    'correspondiente a datos. Esta clase debe ser abstracta,
    'es decir, las clases que usen los métodos o funciones
    'de esta clase no deben interferir en el manejo de las conecciones.
    'Por ej: la base de datos solo es visible dentro de esta clase.
    Private DB As OleDb.OleDbConnection
    Private Da As New OleDb.OleDbDataAdapter()
    Private Ruta As String
    Private FechaFormat As String = "#"
    Private Server As String = "Euro"
    Dim res As IAsyncResult
#Region "Delegados"
    Delegate Sub EscribirThr(ByVal Tabla As String, ByVal Campo As String, ByVal Valor As String, ByVal ID As Long)
    Delegate Sub AgregarFilaThr(ByRef DatTabla As DataTable, ByVal FilaNueva As DataRow, ByVal NombreTabla As String)
    Delegate Sub AgregarTablaThr(ByVal Tabla As String, ByRef Datos As DataTable)
    Delegate Sub BorrarRegistroThr(ByVal Tabla As String, ByVal ID As Int32)
    Delegate Sub Stored_ProcThr(ByVal Sp As String, ByVal Params As Object)
#End Region

    Public Sub New(ByVal Tabla As String, Optional ByVal ModoSql2000 As Boolean = False)
        Try
            DB = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Tabla)
            'DB = New OleDb.OleDbConnection("User ID=root; Password=ñrootlinux; Host=localhost; Port=5432; Database=dbPrueba;Pooling=true; Min Pool Size=0; Max Pool Size=100; Connection Lifetime=0")
        Catch e As System.Exception
            MsgBox("No se ha podido conectar con la base de datos.", MsgBoxStyle.Critical)
        End Try
        Path = Tabla
        If ModoSql2000 = True Then 
            DB = New OleDb.OleDbConnection(String.Format("Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=True;Initial Catalog={0};Data Source={1};Use Procedure for Prepare=1;Auto Translate=True;Packet Size=4096;Use Encryption for Data=False;Tag with column collation when possible=False", Ruta, Server))
        FechaFormat = "'"
        End if
    End Sub
    Public Sub Dispose()
        Try
            DB.Dispose()
        Catch er As Exception
        End Try
    End Sub

    Public Event ErrorAlEscribir(ByVal er As System.Exception, ByVal Ds As String)
    Public Event ErrorAlLeer(ByVal er As System.Exception, ByVal Ds As String)
    Public Event ErrorAlEjecutar(ByVal er As System.Exception, ByVal Ds As String)

    Public Property Path() As String
        Get
            Path = Ruta
        End Get
        Set(ByVal Value As String)
            Ruta = Value
        End Set
    End Property
    Public Property Servidor() As String
        Get
            Return Server
        End Get
        Set(ByVal Value As String)
            Server = Value
        End Set
    End Property

#Region " Editar Datos "
    'Nicolas *****
    'jueves, 23 de septiembre de 2004
    'Descripción:
    '      EscribirDatos toma el valor correspondiente, según el tipo de 
    'dato ingresado, le dá el formato correcto para que lo interprete
    'SQL (ej: los string necesitan estar entre comillas simples) y luego
    'llama al procedimiento escribir.
    Public Sub EscribirDatos(ByVal Tabla As String, ByVal Campo As String, ByVal Valor As Int32, ByVal ID As Long)
        Dim handler As EscribirThr = AddressOf Escribir
        res = handler.BeginInvoke(Tabla, Campo, Valor.ToString, ID, Nothing, Nothing)
        handler.EndInvoke(res)
    End Sub

    Public Sub EscribirDatos(ByVal Tabla As String, ByVal Campo As String, ByVal Valor As Int64, ByVal ID As Long)
        Dim handler As EscribirThr = AddressOf Escribir
        res = handler.BeginInvoke(Tabla, Campo, Valor.ToString, ID, Nothing, Nothing)
        handler.EndInvoke(res)
    End Sub

    Public Sub EscribirDatos(ByVal Tabla As String, ByVal Campo As String, ByVal Valor As Date, ByVal ID As Long)
        Dim a As String = String.Format("{1}{0}{1}", Format(Valor, "MM/dd/yy"), FechaFormat)
        Dim handler As EscribirThr = AddressOf Escribir
        If ID Then
            res = handler.BeginInvoke(Tabla, Campo, a, ID, Nothing, Nothing)
        Else
            res = handler.BeginInvoke(Tabla, Campo, Valor, ID, Nothing, Nothing)
        End If
        handler.EndInvoke(res)
    End Sub

    Public Sub EscribirDatos(ByVal Tabla As String, ByVal Campo As String, ByVal Valor As String, ByVal ID As Long)
        Dim a As String = String.Format("'{0}'", Valor)
        Dim handler As EscribirThr = AddressOf Escribir
        If ID = 0 Then
            a = Valor
        End If
        res = handler.BeginInvoke(Tabla, Campo, a, ID, Nothing, Nothing)
        handler.EndInvoke(res)
    End Sub

    Public Sub EscribirDatos(ByVal Tabla As String, ByVal Campo As String, ByVal Valor As Single, ByVal ID As Long)
        Dim a As String = Valor.ToString.Replace(",", ".")
        Dim handler As EscribirThr = AddressOf Escribir
        res = handler.BeginInvoke(Tabla, Campo, a, ID, Nothing, Nothing)
        handler.EndInvoke(res)
    End Sub

    Public Sub EscribirDatos(ByVal Tabla As String, ByVal Campo As String, ByVal Valor As Double, ByVal ID As Long)
        Dim a As String = Valor.ToString.Replace(",", ".")
        Dim handler As EscribirThr = AddressOf Escribir
        res = handler.BeginInvoke(Tabla, Campo, a, ID, Nothing, Nothing)
        handler.EndInvoke(res)
    End Sub

    Public Sub EscribirDatos(ByVal Tabla As String, ByVal Campo As String, ByVal Valor As Boolean, ByVal ID As Long)
        Dim handler As EscribirThr = AddressOf Escribir
        If Valor Then
            res = handler.BeginInvoke(Tabla, Campo, "True", ID, Nothing, Nothing)
        Else
            res = handler.BeginInvoke(Tabla, Campo, "False", ID, Nothing, Nothing)
        End If
        handler.EndInvoke(res)
    End Sub

    Private Sub Escribir(ByVal Tabla As String, ByVal Campo As String, ByVal Valor As String, ByVal ID As Long)
        Dim i As Int16
        If ID Then
            AbrirBase()
            'UPDATE Empleados
            'SET    DNI=@DNI, Nombre=@Nombre, Apellidos=@Apellidos
            'WHERE  IdEmpleado=@Original_IdEmpleado AND DNI=@Original_DNI AND
            '		Nombre=@Original_Nombre AND Apellidos=@Original_Apellidos
            'Dim a As String = "UPDATE Productos SET ID=@ID, Nombre=@Nombre, Tipo=@Tipo, Ver=@Ver, Imprimir=@Imprimir"

            'SqlDataAdapter Adapter = new
            'SqlDataAdapter("SELECT * FROM Empleados", Connection);
            'SqlCommandBuilder CommandBuilder = new SqlCommandBuilder(Adapter);
            'Adapter.UpdateCommand = CommandBuilder.GetUpdateCommand();
            'Adapter.InsertCommand = CommandBuilder.GetInsertCommand();
            'Adapter.DeleteCommand = CommandBuilder.GetDeleteCommand();

            Dim a As String = String.Format("Update {0} set {1}={2} WHERE ID_{0}={3}", Tabla, Campo, Valor, ID)
            Try
                Dim cm As New OleDb.OleDbCommand(a, DB)
                cm.CommandType = CommandType.Text
                i = cm.ExecuteNonQuery()
            Catch e As OleDb.OleDbException
                MsgBox(e.Message, MsgBoxStyle.Critical, "Escribir")
            Catch e As Exception
                MsgBox(e.Message, MsgBoxStyle.Critical, "Escribir")
            Finally
                DB.Close()
            End Try
        End If
    End Sub

    Public Sub AgregarFila(ByRef DatTabla As DataTable, ByVal FilaNueva As DataRow, ByVal NombreTabla As String)
        Dim handler As AgregarFilaThr = AddressOf AdjuntarFila
        res = handler.BeginInvoke(DatTabla, FilaNueva, NombreTabla, Nothing, Nothing)
        handler.EndInvoke(DatTabla, res)
    End Sub
    Private Sub AdjuntarFila(ByRef DatTabla As DataTable, ByVal FilaNueva As DataRow, ByVal NombreTabla As String)
        Dim cm As New OleDb.OleDbCommand(NombreTabla, DB)
        Dim CmdBuilder As New OleDb.OleDbCommandBuilder(Da)
        cm.CommandType = CommandType.TableDirect
        Da.SelectCommand = cm
        Dim Drow As DataRow
        Drow = DatTabla.NewRow
        Call Copiar_Rows(FilaNueva, Drow)
        DatTabla.Rows.Add(Drow)

        AbrirBase()
        Try
            Da.Update(DatTabla)
        Catch er As OleDb.OleDbException
            MsgBox(er.Message)
        Catch e As Exception
            MsgBox(e.Message)
            'RaiseEvent ErrorAlEscribir(e, String.Format("{0} {1} {2} {3}", Tabla, Campo, Valor, ID.ToString))
        Finally
            DB.Close()
        End Try
    End Sub

    Public Sub Copiar_Rows(ByVal RwOrigen As DataRow, ByRef RwDestino As DataRow)
        Dim i As Integer
        For i = 0 To RwOrigen.ItemArray.GetUpperBound(0)
            RwDestino.Item(i) = RwOrigen.Item(i)
        Next i
    End Sub

    Public Sub AgregarTabla(ByVal Tabla As String, ByRef Datos As DataTable)
        Dim handler As AgregarTablaThr = AddressOf AdjuntarTabla
        res = handler.BeginInvoke(Tabla, Datos, Nothing, Nothing)
        handler.EndInvoke(Datos, res)
    End Sub
    Private Sub AdjuntarTabla(ByVal Tabla As String, ByRef Datos As DataTable)
        Dim CmdBuilder As New OleDb.OleDbCommandBuilder(Da)
        Dim cm As New OleDb.OleDbCommand(Tabla, DB)
        Dim i As Integer
        Dim dr As DataRow
        Dim TablaDestino As New DataTable()
        Dim Filas As Integer
        cm.CommandType = CommandType.TableDirect
        Da.SelectCommand = cm
        CmdBuilder.RefreshSchema()
        AbrirBase()
        Try
            Da.Fill(TablaDestino)
            Filas = TablaDestino.Rows.Count  'Guardamos aparte la posicion en donde se comienza a escribir
        Catch e As Exception
            MsgBox(e.Message)
        End Try

        For i = 0 To Datos.Rows.Count - 1
            dr = TablaDestino.NewRow
            TablaDestino.Rows.Add(dr)
        Next

        For i = 0 To Datos.Rows.Count - 1
            Call Copiar_Rows(Datos.Rows(i), TablaDestino.Rows(Filas + i))
        Next
        Try
            Da.Update(TablaDestino)
        Catch er As OleDb.OleDbException
            MsgBox(er.Message)
        Catch e As Exception
            MsgBox(e.Message)
            'RaiseEvent ErrorAlEscribir(e, String.Format("{0} {1} {2} {3}", Tabla, Campo, Valor, ID.ToString))
        Finally
            DB.Close()
        End Try
    End Sub
    Public Sub BorrarRegistro(ByVal Tabla As String, ByVal ID As Int32)
        Dim handler As BorrarRegistroThr = AddressOf BorrarReg
        res = handler.BeginInvoke(Tabla, ID, Nothing, Nothing)
        handler.EndInvoke(res)
    End Sub
    Private Sub BorrarReg(ByVal Tabla As String, ByVal ID As Int32)
        Dim a As String = String.Format("Delete * from {0} where ID_{0}={1}", Tabla, ID.ToString)
        Dim cm As New OleDb.OleDbCommand(a, DB)

        AbrirBase()
        cm.ExecuteNonQuery()
        DB.Close()
        cm.Dispose()
    End Sub

    Public Sub EjecutarCadena(ByVal Cadena As String)
        Try
            AbrirBase()
            Dim cm As New OleDb.OleDbCommand(Cadena, DB)
            cm.ExecuteNonQuery()
            cm.Dispose()
            DB.Close()
            'dbSeg.Execute(Cadena)
        Catch er As Exception
            RaiseEvent ErrorAlEjecutar(er, "No se pudo realizar la acción.")
            MsgBox(er.Message)
        End Try
    End Sub

    Public Sub BeginTrans()
        DB.BeginTransaction.Begin()
        'w.BeginTrans()
    End Sub
    Public Sub CommitTrans()
        DB.BeginTransaction.Commit()
        'w.CommitTrans()
    End Sub
    Public Sub RollBack()
        DB.BeginTransaction.Rollback()
        'w.Rollback()
    End Sub
    Public Sub Stored_Proc(ByVal Sp As String, ByVal Params As Object)
        Dim handler As Stored_ProcThr = AddressOf Stored_Procedure
        res = handler.BeginInvoke(Sp, Params, Nothing, Nothing)
        handler.EndInvoke(res)
    End Sub
    Public Sub Stored_Procedure(ByVal Sp As String, ByVal Params As Object)
        Dim cm As New OleDb.OleDbCommand()
        Dim i As Integer
        cm.CommandType = CommandType.StoredProcedure
        cm.CommandText = Sp
        cm.Connection = DB
        For i = 0 To Params.GetUpperBound(0)
            cm.Parameters.Add(cm.CreateParameter)
            cm.Parameters.Item(i).Value = Params(i)
        Next
        AbrirBase()
        Try
            cm.ExecuteNonQuery()
        Catch e As Exception
            Stop
        End Try
        DB.Close()
    End Sub
    Public Function SP_Select(ByVal Sp As String, ByVal params As Object) As DataTable
        Dim i As Integer
        Dim cm As New OleDb.OleDbCommand()
        Dim da As OleDb.OleDbDataAdapter
        Dim dt As New DataTable("Datos")
        cm.CommandType = CommandType.StoredProcedure
        cm.CommandText = Sp
        cm.Connection = DB
        For i = 0 To params.GetUpperBound(0)
            cm.Parameters.Add(cm.CreateParameter)
            cm.Parameters.Item(i) = Preparar_Parametros(params(i))
        Next
        AbrirBase()
        da = New OleDb.OleDbDataAdapter(cm)
        Try
            da.Fill(dt)
            da.FillSchema(dt, SchemaType.Mapped)
            Return dt
        Catch er As System.Exception
            MsgBox(er.Message)
        Finally
            DB.Close()
        End Try
    End Function
    Private Function Preparar_Parametros(ByVal Pars As Object) As OleDb.OleDbParameter
        Dim Temp As New OleDb.OleDbParameter()
        Temp.Value = Pars
        Select Case Pars.GetType.ToString
            Case "System.String"
                Temp.OleDbType = Data.OleDb.OleDbType.Char
                Temp.Size = 50
            Case "System.Date"
                Temp.OleDbType = Data.OleDb.OleDbType.Date
                Temp.Size = 8
            Case "System.Single", "System.Double"
                Temp.OleDbType = Data.OleDb.OleDbType.Currency
                Temp.Size = 8
            Case "System.Int16", "System.Int32"
                Temp.OleDbType = Data.OleDb.OleDbType.Integer
                Temp.Scale = 8
        End Select
        Preparar_Parametros = Temp
    End Function
    Public Sub CrearVista(ByVal Cadena As String, ByVal Nombre As String)
        Dim cm As New OleDb.OleDbCommand()
        Dim CmdBuilder As New OleDb.OleDbCommandBuilder(Da)
        cm.CommandText = String.Format("Create View {0} as {1}", Nombre, Cadena)
        cm.CommandType = CommandType.Text
        cm.Connection = DB
        AbrirBase()
        Try
            cm.ExecuteNonQuery()
        Catch e As Exception
            Stop
        End Try
    End Sub
#End Region
#Region " Devolver Datos "
    Private Sub AbrirBase()
        If DB.State = ConnectionState.Closed Then
            Try
                DB.Open()
            Catch er As OleDb.OleDbException
                MsgBox(er.Message)
            Catch er As Exception
                MsgBox(er.Message)
            End Try
        End If
    End Sub

    Public Function Datos(ByVal TablaOCadena As String, Optional ByVal Ordenar As String = "") As DataTable
        Dim dt As New DataTable("Datos")
        Dim a As String
        Dim da As OleDb.OleDbDataAdapter
        TablaOCadena = TablaOCadena.ToLower
        AbrirBase()
        If Ordenar <> "" Then
            TablaOCadena = TablaOCadena & " ORDER BY " & Ordenar
        End If
        If TablaOCadena.LastIndexOfAny(" ") <> -1 AndAlso (TablaOCadena.StartsWith("select") Or TablaOCadena.StartsWith("transform")) Then
            da = New OleDb.OleDbDataAdapter(TablaOCadena, DB)
        Else
            a = "select * from " & TablaOCadena
            da = New OleDb.OleDbDataAdapter(a, DB)
        End If
        Try
            da.Fill(dt)
            da.FillSchema(dt, SchemaType.Mapped)
            Return dt
        Catch er As System.Exception
            MsgBox(er.Message)
        Finally
            DB.Close()
        End Try
    End Function

    Public Function CamposTabla(ByVal Tabla As String) As DataTable
        Dim rs As DataTable
        Dim da As New OleDb.OleDbDataAdapter(String.Format("Select * from {0}", Tabla), DB)
        Dim dt As New DataTable("Campos")

        Try
            AbrirBase()
        Catch er As OleDb.OleDbException
            MsgBox(er.Message)
        End Try
        Try
            da.FillSchema(dt, SchemaType.Mapped)
            Return dt
        Catch er As System.Exception
            MsgBox("Se ha producido un error mientras se intentaba abrir la tabla: " & Tabla, MsgBoxStyle.Critical)
        Finally
            DB.Close()
        End Try
    End Function

    Public Function TipoCamposTabla(ByVal Tabla As String) As DataTable
        Dim rs As DataTable
        Dim da As New OleDb.OleDbDataAdapter(String.Format("Select * from {0}", Tabla), DB)
        Dim dt As New DataTable("Campos")

        AbrirBase()
        Try
            da.FillSchema(dt, SchemaType.Mapped)
            Return dt
        Catch er As System.Exception
            MsgBox("Se ha producido un error mientras se intentaba abrir la tabla: " & Tabla, MsgBoxStyle.Critical)
        Finally
            DB.Close()
        End Try
    End Function

    'Public Function vTipoCampos(ByVal Tabla As String) As DataTable
    '    Dim da As New OleDb.OleDbDataAdapter("Select * from " & Tabla, DB), ls As New DataTable("TipoCampos")

    '    Try
    '        AbrirBase()
    '        da.FillSchema(ls, SchemaType.Mapped)
    '        Return ls
    '    Catch e As System.Exception
    '        MsgBox("Se ha producido un error mientras se intentaba abrir la tabla: " & Tabla, MsgBoxStyle.Critical)
    '    Finally
    '        DB.Close()
    '    End Try
    'End Function

    Public Function BuscarDato(ByVal Cadena As String) As String
        AbrirBase()
        Dim cm As New OleDb.OleDbCommand(Cadena, DB)
        Dim d As Object
        Try
            cm.CommandType = CommandType.Text
            d = cm.ExecuteScalar()
        Catch e As OleDb.OleDbException
            MsgBox(e.Message)
        End Try

        DB.Close()
        If d Is Nothing Or d Is DBNull.Value Then d = ""
        Return d
    End Function

    Public Function BuscarDato(ByVal Tabla As String, ByVal Campo As String, ByVal Valor As String, ByVal Dev As String) As String
        AbrirBase()
        Dim cm As New OleDb.OleDbCommand(String.Format("Select {3} from {0} where {1}='{2}'", Tabla, Campo, Valor, Dev), DB)
        Dim d As Object
        d = cm.ExecuteScalar()
        DB.Close()
        If d Is Nothing Or d Is DBNull.Value Then d = ""
        Return d
    End Function

    Public Function BuscarDato(ByVal Tabla As String, ByVal Campo As String, ByVal Valor As Date, ByVal Dev As String) As String
        AbrirBase()
        Dim cm As New OleDb.OleDbCommand(String.Format("Select {3} from {0} where {1}={4}{2}{4}", Tabla, Campo, Format(Valor, "MM/dd/yy"), Dev, FechaFormat), DB)
        Dim d As Object
        d = cm.ExecuteScalar()
        DB.Close()
        If d Is Nothing Or d Is DBNull.Value Then d = ""
        Return d
    End Function

    Public Function BuscarDato(ByVal Tabla As String, ByVal Campo As String, ByVal Valor As Int32, ByVal Dev As String) As String
        AbrirBase()
        Dim cm As New OleDb.OleDbCommand(String.Format("Select {3} from {0} where {1}={2}", Tabla, Campo, Valor, Dev), DB)
        Dim d As Object
        d = cm.ExecuteScalar()
        DB.Close()
        If d Is Nothing Or d Is DBNull.Value Then d = ""
        Return d
    End Function

    Public Function BuscarDato(ByVal Tabla As String, ByVal Campo As String, ByVal Valor As Boolean, ByVal Dev As String) As String
        AbrirBase()
        Dim a As String
        If Valor Then
            a = String.Format("Select {2} from {0} where {1}=True", Tabla, Campo, Dev)
        Else
            a = String.Format("Select {2} from {0} where {1}=False", Tabla, Campo, Dev)
        End If

        Dim cm As New OleDb.OleDbCommand(a, DB)
        Dim d As Object
        d = cm.ExecuteScalar()
        DB.Close()
        If d Is Nothing Or d Is DBNull.Value Then d = ""
        Return d
    End Function

    Public Function BuscarDato(ByVal Tabla As String, ByVal Campo As String, ByVal Valor As Double, ByVal Dev As String) As String
        AbrirBase()
        Dim a, b As String

        b = CStr(Valor)
        b = b.Replace(",", ".")
        a = String.Format("Select {3} from {0} where {1}={2}", Tabla, Campo, b, Dev)
        Dim cm As New OleDb.OleDbCommand(a, DB)
        Dim d As Object
        d = cm.ExecuteScalar()
        DB.Close()
        If d Is Nothing Or d Is DBNull.Value Then d = ""
        Return d
    End Function

    Public Function UltimoId(ByVal Tabla As String) As Integer
        Dim Max As Object
        Dim cm As New OleDb.OleDbCommand()
        cm.Connection = DB
        cm.CommandType = CommandType.Text
        cm.CommandText = String.Format("SELECT (MAX(ID_{0})+1) as NRegistro FROM {0}", Tabla)
        AbrirBase()
        Try
            Max = CInt(cm.ExecuteScalar())
        Catch er As OleDb.OleDbException
            MsgBox(er.Message)
        Catch er As Exception
            Max = -1
        End Try
        DB.Close()
        UltimoId = Max
    End Function
    Public Function OrdenarTabla(ByVal Tabla As DataTable, ByVal Orden As String, Optional ByVal Filtro As String = "") As DataTable
        Dim Filas As DataRow()
        Dim dtTemp As New DataTable()
        Dim dr As DataRow
        Dim i As Int32
        Dim j As Int32
        Filas = Tabla.Select(Filtro, Orden)
        dtTemp = Tabla.Copy
        dtTemp.Rows.Clear()
        For i = 0 To Filas.GetUpperBound(0)
            dr = dtTemp.NewRow
            For j = 0 To Filas(i).ItemArray.GetUpperBound(0)
                dr(j) = Filas(i).Item(j)
            Next
            dtTemp.Rows.Add(dr)
        Next
        Return dtTemp
    End Function
#End Region
End Class



