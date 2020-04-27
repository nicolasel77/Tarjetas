Option Explicit On 
Imports System.Data
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
    'Public DB As SqlClient.SqlConnection
    Public DB As SqlClient.SqlConnection
    Private Da As New SqlClient.SqlDataAdapter()
    Private Ruta As String
    Private FechaFormat As String = "'"
    Private Shared Server As String = "192.168.5.10"
    Private m_user As String = ""
    Dim res As IAsyncResult
    Dim SiempreAbr As Boolean = True
    Public Event ErrorEnBases(ByVal ex As Exception, ByVal Donde As String)
#Region "Delegados"
    Private Delegate Sub EscribirThr(ByVal Tabla As String, ByVal Campo As String, ByVal Valor As String, ByVal ID As Long)
    Private Delegate Sub AgregarFilaThr(ByRef DatTabla As DataTable, ByVal FilaNueva As DataRow, ByVal NombreTabla As String)
    Private Delegate Sub AgregarTablaThr(ByVal Tabla As String, ByRef Datos As DataTable)
    Private Delegate Sub BorrarRegistroThr(ByVal Tabla As String, ByVal ID As Int32)
    Private Delegate Sub Stored_ProcThr(ByVal Sp As String, ByVal Params As Object)
#End Region
    '''<summary>
    '''Instancia la clase base indicando la base de datos donde se trabajará, junto con el usuario y password
    '''</summary>
    '''<param name="BaseDeDatos">String que indica el Nombre de la base de datos</param>
    '''<param name="User">String que indica el Login</param>
    '''<param name="Pass">String que indica el Password</param>
    Public Sub New(ByVal BaseDeDatos As String, ByVal User As String, ByVal Pass As String)
        m_user = User
        Try
            DB = New SqlClient.SqlConnection(String.Format("User ID=Nikorasu;Password=Oficina02;Initial Catalog={0};Data Source={1};persist security info=False;", BaseDeDatos, Server))
            EjecutarCadena("Set DateFirst 1")
        Catch ex As Exception
            MsgBox(ex.Message & " New " & User)
        End Try
    End Sub

    Public Sub Dispose()
        Try
            DB.Dispose()
        Catch er As Exception
        End Try
    End Sub
    Public Property SiempreAbierto() As Boolean
        Get
            Return SiempreAbr
        End Get
        Set(ByVal value As Boolean)
            SiempreAbr = value
        End Set
    End Property
    Public Shared Property Servidor() As String
        Get
            Return Server
        End Get
        Set(ByVal Value As String)
            Server = Value
        End Set
    End Property
    Public ReadOnly Property Usuario() As String
        Get
            Return m_user
        End Get
    End Property
#Region " Editar Datos "
    Public Sub AgregarFila(ByRef DatTabla As DataTable, ByVal FilaNueva As DataRow, ByVal NombreTabla As String)
        Dim handler As AgregarFilaThr = AddressOf AdjuntarFila
        res = handler.BeginInvoke(DatTabla, FilaNueva, NombreTabla, Nothing, Nothing)
        handler.EndInvoke(DatTabla, res)
        AdjuntarFila(DatTabla, FilaNueva, NombreTabla)
    End Sub
    Public Sub AdjuntarFila(ByRef DatTabla As DataTable, ByVal FilaNueva As DataRow, ByVal NombreTabla As String)
        Dim cm As New SqlClient.SqlCommand("Select * From " & NombreTabla, DB)
        Dim CmdBuilder As New SqlClient.SqlCommandBuilder(Da)
        cm.CommandType = CommandType.Text
        Da.SelectCommand = cm
        Dim Drow As DataRow
        Drow = DatTabla.NewRow
        Call Copiar_Rows(FilaNueva, Drow)
        DatTabla.Rows.Add(Drow)
        AbrirBase()
        Try
            Da.Update(DatTabla)
        Catch er As SqlClient.SqlException
            RaiseEvent ErrorEnBases(er, "AdjuntarFila")
        Catch e As Exception
            RaiseEvent ErrorEnBases(e, "AdjuntarFila")
        Finally
            If Not SiempreAbr Then DB.Close()
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
        Dim CmdBuilder As New SqlClient.SqlCommandBuilder(Da)
        Dim cm As New SqlClient.SqlCommand("Select * From " & Tabla, DB)
        Dim i As Integer
        Dim dr As DataRow
        Dim TablaDestino As New DataTable()
        Dim Filas As Integer
        cm.CommandType = CommandType.Text
        Da.SelectCommand = cm
        CmdBuilder.RefreshSchema()
        AbrirBase()
        Try
            Da.Fill(TablaDestino)
            Filas = TablaDestino.Rows.Count  'Guardamos aparte la posicion en donde se comienza a escribir
        Catch e As Exception
            RaiseEvent ErrorEnBases(e, "AdjuntarTabla")
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
            RaiseEvent ErrorEnBases(er, "AdjuntarTabla")
        Catch e As Exception
            RaiseEvent ErrorEnBases(e, "AdjuntarTabla")
        Finally
            If Not SiempreAbr Then DB.Close()
        End Try
    End Sub
    Public Sub BorrarRegistro(ByVal Tabla As String, ByVal ID As Int32)
        Dim handler As BorrarRegistroThr = AddressOf BorrarReg
        res = handler.BeginInvoke(Tabla, ID, Nothing, Nothing)
        handler.EndInvoke(res)
    End Sub
    Private Sub BorrarReg(ByVal Tabla As String, ByVal ID As Int32)
        Dim a As String = String.Format("Delete from {0} where ID_{0}={1}", Tabla, ID.ToString)
        Dim cm As New SqlClient.SqlCommand(a, DB)

        AbrirBase()
        cm.ExecuteNonQuery()
        If Not SiempreAbr Then DB.Close()
        cm.Dispose()
    End Sub

    Public Sub EjecutarCadena(ByVal Cadena As String)
        Try
            AbrirBase()
            Dim cm As New SqlClient.SqlCommand(Cadena, DB)
            cm.ExecuteNonQuery()
            cm.Dispose()
            LogearRecord(Usuario, Cadena)
            If Not SiempreAbr Then DB.Close()
        Catch er As Exception
            RaiseEvent ErrorEnBases(er, "EjecutarCadena")
        End Try
    End Sub

    Public Sub CommitTrans()
        DB.BeginTransaction.Commit()
        'w.CommitTrans()
    End Sub
    Public Sub RollBack()
        DB.BeginTransaction.Rollback()
        'w.Rollback()
    End Sub
    Public Sub Stored_Procedure(ByVal Sp As String, ByVal ParamArray Params() As Object)
        Dim cm As New SqlClient.SqlCommand()
        Dim i As Integer
        Dim cmbuilder As New SqlClient.SqlCommandBuilder(Da)
        AbrirBase()
        cm.CommandType = CommandType.StoredProcedure
        cm.CommandText = Sp
        cm.Connection = DB
        SqlClient.SqlCommandBuilder.DeriveParameters(cm)
        For i = 1 To Params.GetUpperBound(0) + 1
            cm.Parameters.Item(i).Value = Params(i - 1)
        Next
        Try
            cm.ExecuteNonQuery()
        Catch e As Exception
            'Stop
            RaiseEvent ErrorEnBases(e, "Stored_Procedure")
        End Try
        If Not SiempreAbr Then DB.Close()
        LogearRecord(Usuario, Sp)
    End Sub
    Public Function SP_Select(ByVal Sp As String, ByVal ParamArray Params() As Object) As SqlClient.SqlDataReader
        Dim i As Integer
        Dim cm As New SqlClient.SqlCommand()
        Dim dt As New DataTable("Datos")
        AbrirBase()
        cm.CommandType = CommandType.StoredProcedure
        cm.CommandText = Sp
        cm.Connection = DB
        SqlClient.SqlCommandBuilder.DeriveParameters(cm)
        For i = 1 To Params.GetUpperBound(0) + 1
            cm.Parameters.Item(i).Value = Params(i - 1)
        Next
        Return cm.ExecuteReader
    End Function

    Public Sub CrearVista(ByVal Cadena As String, ByVal Nombre As String)
        Dim cm As New SqlClient.SqlCommand()
        Dim CmdBuilder As New SqlClient.SqlCommandBuilder(Da)
        cm.CommandText = String.Format("Create View {0} as {1}", Nombre, Cadena)
        cm.CommandType = CommandType.Text
        cm.Connection = DB
        AbrirBase()
        Try
            cm.ExecuteNonQuery()
        Catch e As Exception
            RaiseEvent ErrorEnBases(e, "CrearVista")
        End Try
    End Sub
#End Region
#Region " Devolver Datos "
    Private Sub AbrirBase()
        If DB.State = ConnectionState.Closed Then
            Try
                DB.Open()
            Catch er As OleDb.OleDbException
                RaiseEvent ErrorEnBases(er, "AbrirBase - " & Ruta)
                MsgBox(er.Message & " AbrirBase " & m_user)
            Catch er As Exception
                MsgBox(er.Message & " AbrirBase " & m_user)
                RaiseEvent ErrorEnBases(er, "AbrirBase - " & Ruta)
            End Try
        End If
        If DB.State = ConnectionState.Executing Then ' se está atorando el sistema
            SyncLock DB 'hasta que no obtiene el control exclusivo.....
                If DB.State = ConnectionState.Closed Then DB.Open() 'no puede abrir la base
            End SyncLock
        End If
    End Sub
    '''<summary>
    '''Devuelve un datatable
    '''</summary>
    '''<param name="TablaOCadena">String Sql o Nombre de la tabla a recuperar de la base de datos</param>
    ''' '''<param name="Ordenar">Campo de la consulta por el cual se va a ordenar (ascendentemente sino se aclara)</param>

    Public Function Datos(ByVal TablaOCadena As String, Optional ByVal Ordenar As String = "") As DataTable
        Dim dt As New DataTable("Datos")
        Dim a As String
        Dim da As SqlClient.SqlDataAdapter
        TablaOCadena = TablaOCadena.ToLower
        AbrirBase()
        If Ordenar <> "" Then
            TablaOCadena = TablaOCadena & " ORDER BY " & Ordenar
        End If
        If TablaOCadena.LastIndexOfAny(" ") <> -1 AndAlso (TablaOCadena.StartsWith("select") Or TablaOCadena.StartsWith("transform")) Then
            da = New SqlClient.SqlDataAdapter(TablaOCadena, DB)
        Else
            a = "select * from " & TablaOCadena
            da = New SqlClient.SqlDataAdapter(a, DB)
        End If
        Try
            da.Fill(dt)
            da.FillSchema(dt, SchemaType.Mapped)
            Return dt
        Catch er As System.ArgumentException
            Return dt
        Catch er As System.Exception
            RaiseEvent ErrorEnBases(er, "Datos - " & Ruta)
            'por si necesitas los datos si o si.
            Return dt
            'MsgBox(er.Message & " Datos " & m_user)
        Finally
            If Not SiempreAbr Then DB.Close()
        End Try
    End Function

    Public Function CamposTabla(ByVal Tabla As String) As DataTable
        Dim da As New SqlClient.SqlDataAdapter(String.Format("Select * from {0}", Tabla), DB)
        Dim dt As New DataTable("Campos")

        Try
            AbrirBase()
        Catch er As OleDb.OleDbException
            RaiseEvent ErrorEnBases(er, "CamposTabla")
        End Try
        Try
            da.FillSchema(dt, SchemaType.Mapped)
            Return dt
        Catch er As System.Exception
            RaiseEvent ErrorEnBases(er, "CamposTabla")
        Finally
            If Not SiempreAbr Then DB.Close()
        End Try
    End Function

    Public Function TipoCamposTabla(ByVal Tabla As String) As DataTable
        Dim da As New SqlClient.SqlDataAdapter(String.Format("Select * from {0}", Tabla), DB)
        Dim dt As New DataTable("Campos")

        AbrirBase()
        Try
            da.FillSchema(dt, SchemaType.Mapped)
            Return dt
        Catch er As System.Exception
            RaiseEvent ErrorEnBases(er, "TipoCamposTabla")
        Finally
            If Not SiempreAbr Then DB.Close()
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
        Dim cm As New SqlClient.SqlCommand(Cadena, DB)
        Dim d As Object
        Try
            cm.CommandType = CommandType.Text
            d = cm.ExecuteScalar()
        Catch e As Exception
            RaiseEvent ErrorEnBases(e, "BuscarDato - " & Ruta)
        End Try

        If Not SiempreAbr Then DB.Close()
        If d Is Nothing Or d Is DBNull.Value Then d = ""
        Return d
    End Function

    Public Function BuscarDato(ByVal Tabla As String, ByVal Campo As String, ByVal Valor As String, ByVal Dev As String) As String
        AbrirBase()
        Dim cm As New SqlClient.SqlCommand(String.Format("Select {3} from {0} where {1}='{2}'", Tabla, Campo, Valor, Dev), DB)
        Dim d As Object
        d = cm.ExecuteScalar()
        If Not SiempreAbr Then DB.Close()
        If d Is Nothing Or d Is DBNull.Value Then d = ""
        Return d
    End Function

    Public Function BuscarDato(ByVal Tabla As String, ByVal Campo As String, ByVal Valor As Date, ByVal Dev As String) As String
        AbrirBase()
        Dim cm As New SqlClient.SqlCommand(String.Format("Select {3} from {0} where {1}={4}{2}{4}", Tabla, Campo, Format(Valor, "MM/dd/yy"), Dev, FechaFormat), DB)
        Dim d As Object
        d = cm.ExecuteScalar()
        If Not SiempreAbr Then DB.Close()
        If d Is Nothing Or d Is DBNull.Value Then d = ""
        Return d
    End Function

    Public Function BuscarDato(ByVal Tabla As String, ByVal Campo As String, ByVal Valor As Int32, ByVal Dev As String) As String
        AbrirBase()
        Dim cm As New SqlClient.SqlCommand(String.Format("Select {3} from {0} where {1}={2}", Tabla, Campo, Valor, Dev), DB)
        Dim d As Object
        d = cm.ExecuteScalar()
        If Not SiempreAbr Then DB.Close()
        If d Is Nothing Or d Is DBNull.Value Then d = ""
        Return d
    End Function

    Public Function BuscarDato(ByVal Tabla As String, ByVal Campo As String, ByVal Valor As Boolean, ByVal Dev As String) As String
        AbrirBase()
        Dim a As String
        If Valor Then
            a = String.Format("Select {2} from {0} where {1}=1", Tabla, Campo, Dev)
        Else
            a = String.Format("Select {2} from {0} where {1}=0", Tabla, Campo, Dev)
        End If

        Dim cm As New SqlClient.SqlCommand(a, DB)
        Dim d As Object
        d = cm.ExecuteScalar()
        If Not SiempreAbr Then DB.Close()
        If d Is Nothing Or d Is DBNull.Value Then d = ""
        Return d
    End Function

    Public Function BuscarDato(ByVal Tabla As String, ByVal Campo As String, ByVal Valor As Double, ByVal Dev As String) As String
        AbrirBase()
        Dim a, b As String

        b = CStr(Valor)
        b = b.Replace(",", ".")
        a = String.Format("Select {3} from {0} where {1}={2}", Tabla, Campo, b, Dev)
        Dim cm As New SqlClient.SqlCommand(a, DB)
        Dim d As Object
        d = cm.ExecuteScalar()
        If Not SiempreAbr Then DB.Close()
        If d Is Nothing Or d Is DBNull.Value Then d = ""
        Return d
    End Function

    Public Function UltimoId(ByVal Tabla As String) As Integer
        Dim Max As Object
        Dim cm As New SqlClient.SqlCommand()
        cm.Connection = DB
        cm.CommandType = CommandType.Text
        If CamposTabla(Tabla).Columns("ID_" & Tabla).AutoIncrement Then
            cm.CommandText = String.Format("SELECT Ident_Current('{0}')", Tabla)
        Else
            cm.CommandText = String.Format("SELECT (MAX(ID_{0})) as NRegistro FROM {0}", Tabla)
        End If
        AbrirBase()
        Try
            Max = CInt(cm.ExecuteScalar())
        Catch er As OleDb.OleDbException
            RaiseEvent ErrorEnBases(er, "UltimoId")
        Catch er As Exception
            Max = -1
        End Try
        If Not SiempreAbr Then DB.Close()
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
    Public Function Reader2Table(ByVal reader As SqlClient.SqlDataReader) As DataTable
        Dim i As Int16
        Dim datos As New DataTable
        Dim dt As DataTable
        Dim col As DataColumn
        Dim cad As String
        Dim dr As DataRow
        dt = reader.GetSchemaTable
        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            cad = CStr(dr("ColumnName"))
            col = New DataColumn(cad, System.Type.GetType(dr("DataType").ToString))
            datos.Columns.Add(col)
        Next
        While reader.Read
            dr = datos.NewRow
            For i = 0 To reader.FieldCount - 1
                dr(i) = reader.GetValue(i)
            Next
            datos.Rows.Add(dr)
        End While
        reader.Close()
        Return datos
    End Function
#End Region
    Private Sub LogearRecord(ByVal Usuario As String, ByVal Comando As String)
        If Usuario = "" Then
            Usuario = My.Computer.Name
        End If
        Try
            AbrirBase()
            Dim cm As New SqlClient.SqlCommand(String.Format("Insert into dblog.dbo.log(Fecha,Usuario,ComandoSql,BaseDeDatos) values ('{0}','{1}','{2}','{3}')", Format(Now, "MM/dd/yy H:mm"), Usuario, Comando.Replace("'", ""), Server), DB)
            cm.ExecuteNonQuery()
            cm.Dispose()
            If Not SiempreAbr Then DB.Close()
        Catch er As Exception
            RaiseEvent ErrorEnBases(er, "EjecutarCadena")
        End Try
    End Sub
End Class



