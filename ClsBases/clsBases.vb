Option Explicit On
Imports System.Data
Public Class Principal
    Public DB As SqlClient.SqlConnection
    Private Da As New SqlClient.SqlDataAdapter()

    Private DB_A As OleDb.OleDbConnection
    Private Da_A As New OleDb.OleDbDataAdapter

    Private m_user As String = ""
    Private Ruta As String
    Dim SiempreAbr As Boolean = True
    Private Shared Server As String = "192.168.5.1"
    Dim res As IAsyncResult

    Public Event ErrorEnBases(ByVal ex As Exception, ByVal Donde As String)
    Private v_Access As Boolean


    Public Permiso As Byte

    Public Sub New(ByVal BaseDeDatos As String, Optional ByVal N_Servidor As String = "192.168.5.1")
        Dim b As Boolean
        Do
            Try
                If Server.Length = 0 Then
                    Server = N_Servidor
                End If

                DB = New SqlClient.SqlConnection(String.Format("Data Source={1};Initial Catalog={0};User Id=Nikorasu;Password=Oficina02;", BaseDeDatos, Server))

            Catch ex As Exception
                If MsgBox(String.Format("No se pudo conectar con el sevidor: {0}{1}¿Desea intenar conectar nuevamente?", Server, vbCrLf), MsgBoxStyle.YesNoCancel + MsgBoxStyle.DefaultButton1 + MsgBoxStyle.Exclamation, "Error de conexion") = MsgBoxResult.Yes Then
                    b = True
                Else
                    b = False
                End If
            End Try
        Loop While b = True
    End Sub
    Public Sub New(ByVal BaseDeDatos As String, ByVal Access As Boolean)
        Try
            DB_A = New OleDb.OleDbConnection(String.Format("Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0};Persist Security Info=False;", BaseDeDatos))
            v_Access = Access
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Dispose()
        Try
            DB.Dispose()
        Catch er As Exception
        End Try
    End Sub
    Private Sub LogearRecord(ByVal Usuario As String, ByVal Comando As String, Fecha As Date)
        If Usuario = "" Then
            'Usuario = My.Computer.Name
            Usuario = My.User.Name.ToString
        End If
        Try
            If Not v_Access Then
                AbrirBase()
                Dim cm As New SqlClient.SqlCommand(String.Format("Insert into dblog.dbo.log(Fecha,Usuario,ComandoSql,BaseDeDatos, Fecha_Afectada) values ('{0}','{1}','{2}','{3}', {4})", _
                                                                 Format(Now, "MM/dd/yy H:mm"), Usuario, Comando.Replace("'", ""), DB.Database, Fecha_SQL(Fecha)), DB)
                cm.ExecuteNonQuery()
                cm.Dispose()
                If Not SiempreAbr Then DB.Close()
            End If
        Catch er As Exception
            RaiseEvent ErrorEnBases(er, "EjecutarCadena")
        End Try
    End Sub
#Region " Otros "
    'Private Delegate Sub AgregarFilaThr(ByRef DatTabla As DataTable, ByVal FilaNueva As DataRow, ByVal NombreTabla As String)
    Public Function Fecha_SQL(ByVal d As Date) As String
        Dim s As String
        s = String.Format("'{0}'", d.ToString("MM/dd/yy"))
        Return s
    End Function
#End Region
#Region " Propiedades "
    Public ReadOnly Property Usuario() As String
        Get
            Return m_user
        End Get
    End Property
    Public Property SiempreAbierto() As Boolean
        Get
            Return SiempreAbr
        End Get
        Set(ByVal value As Boolean)
            SiempreAbr = value
        End Set
    End Property
#End Region

#Region " Devolver Datos "
    Private Sub AbrirBase()
        'If v_Access = False Then
        If DB.State = ConnectionState.Closed Then
            Try
                DB.Open()
            Catch er As SqlClient.SqlException

                RaiseEvent ErrorEnBases(er, "AbrirBase - " & Ruta)
            Catch er As Exception
                MsgBox(er.Message, MsgBoxStyle.OkOnly, "AbrirBase " & m_user)
                RaiseEvent ErrorEnBases(er, "AbrirBase - " & Ruta)
            End Try
        End If
        If DB.State = ConnectionState.Executing Then ' se está atorando el sistema
            SyncLock DB 'hasta que no obtiene el control exclusivo.....
                If DB.State = ConnectionState.Closed Then DB.Open() 'no puede abrir la base
            End SyncLock
        End If

    End Sub


    Public Function Datos(ByVal TablaOCadena As String, Optional ByVal Ordenar As String = "") As DataTable
        Dim dt As New DataTable("Datos")
        Dim a As String
        TablaOCadena = TablaOCadena.ToLower
        AbrirBase()

        'If v_Access = False Then
        Dim da As SqlClient.SqlDataAdapter
        If TablaOCadena.LastIndexOfAny(" ") <> -1 AndAlso (TablaOCadena.StartsWith("select") Or TablaOCadena.StartsWith("transform")) Then
            da = New SqlClient.SqlDataAdapter(TablaOCadena, DB)
        Else
            If Ordenar <> "" Then
                a = "select * from " & TablaOCadena & " ORDER BY " & Ordenar
            Else
                a = "select * from " & TablaOCadena
            End If
            da = New SqlClient.SqlDataAdapter(a, DB)
        End If
        Try
            da.SelectCommand.CommandTimeout = 220
            da.Fill(dt)
            da.FillSchema(dt, SchemaType.Mapped)
            Return dt
        Catch er As SqlClient.SqlException
            DB.Close()
            AbrirBase()
        Catch er As System.ArgumentException
            'Beep()
            Return dt
        Catch er As System.Exception
            RaiseEvent ErrorEnBases(er, "Datos - " & Ruta)
            Return dt 'por si necesitas los datos si o si.
            MsgBox(er.Message & " Datos " & m_user)
        Finally
            If Not SiempreAbr Then DB.Close()
        End Try
        'Else
        'If TablaOCadena.LastIndexOfAny(" ") <> -1 AndAlso (TablaOCadena.StartsWith("select") Or TablaOCadena.StartsWith("transform")) Then
        '    Da_A = New OleDb.OleDbDataAdapter(TablaOCadena, DB_A)
        'Else
        '    If Ordenar <> "" Then
        '        a = "select * from " & TablaOCadena & " ORDER BY " & Ordenar
        '    Else
        '        a = "select * from " & TablaOCadena
        '    End If
        '    Da_A = New OleDb.OleDbDataAdapter(a, DB_A)
        'End If
        'Try
        '    Da_A.Fill(dt)
        '    Da_A.FillSchema(dt, SchemaType.Mapped)
        '    Return dt
        'Catch er As System.ArgumentException
        '    'Beep()
        '    Return dt
        'Catch er As System.Exception
        '    RaiseEvent ErrorEnBases(er, "Datos - " & Ruta)
        '    Return dt 'por si necesitas los datos si o si.
        '    MsgBox(er.Message & " Datos " & m_user)
        'Finally
        '    If Not SiempreAbr Then DB.Close()
        'End Try
        'End If
    End Function

    Public Function BuscarDato(ByVal Cadena As String) As String
        AbrirBase()
        If v_Access Then
            Dim cm As New OleDb.OleDbCommand(Cadena, DB_A)
            Dim d As Object = Nothing
            Try
                cm.CommandType = CommandType.Text
                d = cm.ExecuteScalar()
            Catch e As Exception
                RaiseEvent ErrorEnBases(e, "BuscarDato - " & Ruta)
            End Try

            If Not SiempreAbr Then DB_A.Close()
            If d Is Nothing Or d Is DBNull.Value Then d = ""
            Return d
        Else
            Dim cm As New SqlClient.SqlCommand(Cadena, DB)
            Dim d As Object = Nothing
            Try
                cm.CommandType = CommandType.Text
                d = cm.ExecuteScalar()
            Catch e As Exception
                RaiseEvent ErrorEnBases(e, "BuscarDato - " & Ruta)
            End Try

            If Not SiempreAbr Then DB.Close()
            If d Is Nothing Or d Is DBNull.Value Then d = ""
            Return d
        End If
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
    Public Function Existe_Dato(ByVal Tabla As String, ByVal Campo As String, ByVal Dato As String) As Boolean
        Dim s As String = BuscarDato(String.Format("SELECT TOP 1 {0} FROM {1} WHERE {0} = {2}", Campo, Tabla, Dato))
        Return IIf(s.Length, True, False)
    End Function

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

    Public Function SP_SelectDT(ByVal Sp As String, ByVal ParamArray Params() As Object) As DataTable
        Dim dt As New DataTable("Datos")
        Dim da As SqlClient.SqlDataAdapter
        Dim cm As New SqlClient.SqlCommand()

        AbrirBase()

        da = New SqlClient.SqlDataAdapter(Sp, DB)

        Try
            cm.CommandType = CommandType.StoredProcedure
            cm.CommandText = Sp
            cm.Connection = DB

            SqlClient.SqlCommandBuilder.DeriveParameters(cm)
            For i As Integer = 1 To Params.GetUpperBound(0) + 1
                cm.Parameters.Item(i).Value = Params(i - 1)
            Next

            da.SelectCommand = cm
            da.SelectCommand.CommandTimeout = 220
            da.Fill(dt)
            da.FillSchema(dt, SchemaType.Mapped)
            Return dt
        Catch er As System.ArgumentException
            'Beep()
            Return dt
        Catch er As System.Exception
            RaiseEvent ErrorEnBases(er, "Datos - " & Ruta)
            Return dt 'por si necesitas los datos si o si.
            MsgBox(er.Message & " Datos " & m_user)
        Finally
            If Not SiempreAbr Then DB.Close()
        End Try
    End Function
#End Region
#Region " Editar Datos "
    Public Sub EjecutarCadena(ByVal Cadena As String)
        Try
            AbrirBase()
            If Not v_Access Then
                Dim cm As New SqlClient.SqlCommand(Cadena, DB)
                cm.ExecuteNonQuery()
                cm.Dispose()
                'LogearRecord(Usuario, Cadena, Date.Now)
                If Not SiempreAbr Then DB.Close()
            Else
                Dim cm As New OleDb.OleDbCommand(Cadena, DB_A)
                cm.ExecuteNonQuery()
                cm.Dispose()
                'LogearRecord(Usuario, Cadena)
                If Not SiempreAbr Then DB_A.Close()
            End If
        Catch er As Exception
            RaiseEvent ErrorEnBases(er, "EjecutarCadena")
        End Try
    End Sub

    ''' <summary>
    ''' A diferencia del anterior, aca se valida que la fecha no esté cerrada
    ''' </summary>
    ''' <param name="Cadena"></param>
    ''' <param name="FechaIni"></param>
    ''' <param name="FechaFin"></param>
    ''' <remarks></remarks>
    Public Sub EjecutarCadena(ByVal Cadena As String, ByVal FechaIni As Date, ByVal FechaFin As Date, Optional ByVal Tabla As String = "")
        Try
            If Permiso < 3 Then
                Dim s As String = String.Format("SELECT TOP 1 Fecha FROM Semanas WHERE (Cerrado=1) AND (Fecha BETWEEN {0} AND {1})", Fecha_SQL(FechaIni), Fecha_SQL(FechaFin))
                s = BuscarDato(s)
                If s.Length Then
                    RaiseEvent ErrorEnBases(New Exception("La semana que esta intentando editar se encuentra cerrada."), "EjecutarCadena")
                    Exit Sub
                End If
            End If
            AbrirBase()
            Dim cm As New SqlClient.SqlCommand(Cadena, DB)
            cm.ExecuteNonQuery()
            cm.Dispose()
            'LogearRecord(Usuario, Cadena, FechaIni)
            If Not SiempreAbr Then DB.Close()
        Catch er As Exception
            RaiseEvent ErrorEnBases(er, "EjecutarCadena")
        End Try
    End Sub

    Public Sub EjecutarCadena(ByVal Cadena As String, ByVal Fecha As Date)
        Try
            If Permiso < 3 Then
                Dim s As String = String.Format("SELECT TOP 1 Cerrado FROM Semanas WHERE Fecha>={0} ORDER BY Fecha DESC", Fecha_SQL(Fecha))
                s = BuscarDato(s)
                If s = "1" Then
                    MsgBox("La semana que esta intentando editar se encuentra cerrada.")
                    Exit Sub
                End If
            End If
            AbrirBase()
            Dim cm As New SqlClient.SqlCommand(Cadena, DB)
            cm.ExecuteNonQuery()
            cm.Dispose()
            'LogearRecord(Usuario, Cadena, Fecha)
            If Not SiempreAbr Then DB.Close()
        Catch er As Exception
            RaiseEvent ErrorEnBases(er, "EjecutarCadena")
        End Try
    End Sub
    Public Function CheckBase(ByVal Cadena As String) As String
        Try
            AbrirBase()
            Dim cm As New SqlClient.SqlCommand(Cadena, DB)
            cm.ExecuteNonQuery()
            cm.Dispose()
            'LogearRecord(Usuario, Cadena)
            If Not SiempreAbr Then DB.Close()
            Return ""
        Catch er As Exception
            Return er.Message
        End Try
    End Function

    Public Sub Stored_Procedure(ByVal Sp As String, ByVal ParamArray Params() As Object)
        Dim cm As New SqlClient.SqlCommand()
        Dim i As Integer
        Dim cmbuilder As New SqlClient.SqlCommandBuilder(Da)
        AbrirBase()
        cm.CommandType = CommandType.StoredProcedure
        cm.CommandText = Sp
        cm.Connection = DB
        cm.CommandTimeout = 600
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
        'LogearRecord(Usuario, Sp)
    End Sub


#End Region

End Class
