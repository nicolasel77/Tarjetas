Public Class Sucursales
#Region " Variables Locales"
    Private db As clsBases.Principal

    Private DevPropio As Boolean
    Private DevEmpresa As Boolean
    Private DevTipo As Boolean

    Private Seleccion_Temp() As Integer

    Public Event CambioSeleccion()
    Public Shadows Event DoubleClick()

    Private v_Filtro As String = ""

    Private Enum Filtro_Default As Byte
        Unico = 0
        Simple = 1
        Multi = 2

    End Enum
    Private v_FiltroDefaul As Filtro_Default = Filtro_Default.Multi

    Private dtS As DataTable

    'Variable para saber si la seleccion es sucursal o cliente
    Private v_Propio As Boolean

    Private AhoraNo As Boolean
#End Region

#Region " Procedimientos privados "
    Public Sub New()
        db = New clsBases.Principal("dbM", "192.168.1.11")
        ' This call is required by the Windows Form Designer.
        InitializeComponent()


        Dim dt As DataTable = db.Datos("Select * FRom Tipo_Sucs ID_TipoSucs order by ID_TipoSucs")
        With lstTipo
            If Not dt Is Nothing Then
                For i As Int16 = 0 To dt.Rows.Count - 1
                    .Items.Add(String.Format("{0}. {1}", dt.Rows(i).Item("ID_TipoSucs"), dt.Rows(i).Item("Descripcion")))
                Next
            End If
        End With

        dt = db.Datos("Select * FRom Supervisores order by ID_Supervisor")
        With lstSupervisores
            .Items.Clear()
            .Items.Add("Todos")
            If Not dt Is Nothing Then
                For i As Int16 = 0 To dt.Rows.Count - 1
                    .Items.Add(String.Format("{0}. {1}", dt.Rows(i).Item(0), dt.Rows(i).Item(1)))
                Next
            End If
        End With

        CargarDatos()
    End Sub

    Public Sub CargarDatos()
        If AhoraNo = False Then
            With lstSucursales
                .Items.Clear()
                Try
                    dtS = db.Datos(Cadena)
                    If Not dtS Is Nothing Then
                        For i As Int16 = 0 To dtS.Rows.Count - 1
                            .Items.Add(String.Format("{0}. {1}", dtS.Rows(i).Item(0), dtS.Rows(i).Item(1)))
                        Next
                    End If
                Catch ex As Exception
                    MsgBox("Hubo un error mientras se leian los datos.")
                End Try
            End With
        End If
    End Sub

#End Region

#Region " Funciones privadas "
    ''' <summary>
    ''' Solo para trabajar internamente
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Cadena() As String
        Dim s As String = "", f As String = ""

        With lstTipo
            If .SelectedIndex > 0 Then
                f = String.Format("Tipo={0}", lstTipo.Codigo_Seleccionado)
            End If
        End With

        With lstSupervisores
            If .SelectedIndex > 0 Then
                Unir(f, String.Format("Supervisor={0}", .Codigo_Seleccionado))
            End If
        End With

        With lstSucsClientes
            If .SelectedIndex > 0 Then
                If .SelectedIndex = 1 Then
                    s = "Propio=1"
                Else
                    s = "Propio=0"
                End If
            End If
            If s.Length Then Unir(f, s)
        End With

        Unir(f, v_Filtro)

        If f.Length Then f = " WHERE " & f
        f = String.Format("SELECT * FROM Varios.dbo.vw_Sucursales {0} ORDER BY Sucursal", f)
        Return f

    End Function


#End Region

#Region " Controles "
    Private Sub lstTipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstTipo.SelectedIndexChanged, lstSucsClientes.SelectedIndexChanged, lstSupervisores.SelectedIndexChanged
        CargarDatos()
    End Sub

    Private Sub cmdTodas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdTodas.Click
        With lstSucursales
            Seleccion_Temp = Nothing
            For i As Int16 = 0 To .Items.Count - 1
                If .GetSelected(i) Then .SetSelected(i, False)
            Next
            RaiseEvent CambioSeleccion()
        End With

    End Sub

    Private Sub lstSucursales_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstSucursales.DoubleClick
        RaiseEvent DoubleClick()
    End Sub

    Private Sub lstSucursales_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles lstSucursales.KeyUp
        If e.KeyCode = Keys.Add Then
            e.Handled = True
            Siguiente()
            RaiseEvent CambioSeleccion()
        ElseIf e.KeyCode = Keys.Subtract Then
            e.Handled = True
            Anterior()
            RaiseEvent CambioSeleccion()
        End If
    End Sub

    Private Sub lstSucursales_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles lstSucursales.MouseUp
        Select Case e.Button
            Case MouseButtons.Middle
                cmdTodas.PerformClick()
            Case MouseButtons.Right
                With lstSucursales
                    For i As Int16 = 0 To .Items.Count - 1
                        .SetSelected(i, Not .GetSelected(i))
                    Next
                    RaiseEvent CambioSeleccion()
                End With
        End Select
    End Sub

    Private Sub lstSucursales_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstSucursales.SelectedIndexChanged
        If AhoraNo = False Then
            tiTiempo.Stop()
        tiTiempo.Start()
            With lstSucursales
                If .SelectedItems.Count = 1 Then
                    Dim s As String = "select Propio  from Sucursales where Sucursal=" & Me.ValorActual
                    s = db.BuscarDato(s)
                    If s = "" Then s = "0"
                    v_Propio = CBool(s)
                End If
            End With
        End If
    End Sub

    Private Sub tiTiempo_Tick(sender As Object, e As EventArgs) Handles tiTiempo.Tick
        RaiseEvent CambioSeleccion()
        tiTiempo.Stop()
    End Sub

    Private Sub cmdReload_Click(sender As Object, e As EventArgs)
        CargarDatos()
    End Sub

    Private Sub rdSelMulti_CheckedChanged(sender As Object, e As EventArgs)
        lstSucursales.SelectionMode = SelectionMode.MultiExtended
    End Sub

    Private Sub rdSelSimple_CheckedChanged(sender As Object, e As EventArgs)
        lstSucursales.SelectionMode = SelectionMode.MultiSimple
    End Sub

    Private Sub rdSelUnica_CheckedChanged(sender As Object, e As EventArgs)
        lstSucursales.SelectionMode = SelectionMode.One
    End Sub

    Private Sub chVisibles_CheckedChanged(sender As Object, e As EventArgs)
        v_Filtro = ""
        CargarDatos()
    End Sub

#End Region

#Region " Propiedades públicas "
    Public Property Filtro_Tabla() As String
        Get
            Return v_Filtro
        End Get
        Set(ByVal value As String)
            v_Filtro = value
            If Seleccion_Temp Is Nothing Then
                ReDim Seleccion_Temp(0)
            End If
            If lstSucursales.SelectedItems.Count > 0 Then
                If lstSucursales.SelectedItems.Count >= Seleccion_Temp.Length Then
                    ReDim Seleccion_Temp(lstSucursales.SelectedItems.Count)
                    For i As Integer = 0 To lstSucursales.SelectedItems.Count - 1
                        Seleccion_Temp(i) = lstSucursales.SelectedItems.Item(i).ToString.Codigo_Seleccionado
                    Next
                End If
            End If
            CargarDatos()
            Try
                If Not Seleccion_Temp Is Nothing Then
                    For i As Integer = 0 To Seleccion_Temp.Length - 1
                        Seleccionar(Seleccion_Temp(i))
                    Next
                End If
            Catch er As Exception
            End Try
        End Set
    End Property

    Public Property Titulo() As String
        Get
            Return Label2.Text
        End Get
        Set(ByVal value As String)
            Label2.Text = value
        End Set
    End Property

    Public ReadOnly Property Seleccion() As ListBox.SelectedObjectCollection
        Get
            Return lstSucursales.SelectedItems
        End Get
    End Property

    Public ReadOnly Property Propio() As Boolean
        Get
            Return v_Propio
        End Get
    End Property

    Public ReadOnly Property DevolverCadena(ByVal Campo As String) As String
        Get
            Dim s As String = ""
            With lstSucursales
                If .SelectedItems.Count > 0 Then
                    For Each a As String In .SelectedItems
                        s.Unir(a.Codigo_Seleccionado, ",")
                    Next
                    s = String.Format("{0} IN ({1}) ", Campo, s)
                End If

            End With
            Return s
        End Get
    End Property

#End Region

#Region " Procedimientos públicos "
    Public Sub LimpiarLista()
        lstSucursales.SelectedIndex = -1
    End Sub

    Public Sub Siguiente()
        With lstSucursales
            If .SelectedItems.Count = 0 Then
                .SetSelected(0, True)
            Else
                For i As Int16 = .Items.Count - 1 To 0 Step -1
                    If .GetSelected(i) Then
                        .SetSelected(i, False)
                        If i = .Items.Count - 1 Then
                            .SetSelected(0, True)
                        Else
                            .SetSelected(i + 1, True)
                        End If
                        Exit For
                    End If
                Next
                RaiseEvent CambioSeleccion()
            End If
        End With
    End Sub

    Public Sub Anterior()
        With lstSucursales
            If .SelectedItems.Count = 0 Then
                .SetSelected(.Items.Count - 1, True)
            Else
                For i As Int16 = 0 To .Items.Count - 1
                    If .GetSelected(i) Then
                        .SetSelected(i, False)
                        If i = 0 Then
                            .SetSelected(.Items.Count - 1, True)
                        Else
                            .SetSelected(i - 1, True)
                        End If
                        Exit For
                    End If
                Next
                RaiseEvent CambioSeleccion()
            End If
        End With
    End Sub

    Public Sub Seleccionar(ByVal Suc As Integer)
        With lstSucursales
            If Suc <> 0 Then
                For i As Integer = 0 To .Items.Count - 1
                    If Suc = .Items(i).ToString.Codigo_Seleccionado Then
                        .SetSelected(i, True)
                        Exit Sub
                    End If
                Next
            End If
        End With
    End Sub

#End Region

#Region " Funciones públicas "
    Public Function ValorActual() As Int16
        With lstSucursales
            If .SelectedItems.Count = 1 Then
                Dim s As String = .SelectedItem.ToString
                Return CInt(s.Substring(0, s.IndexOf(".")))
            End If
        End With
    End Function

    Private Sub lstSupervisores_DoubleClick(sender As Object, e As EventArgs) Handles lstSupervisores.DoubleClick
        AhoraNo = True
        With lstSucursales
            If lstSupervisores.SelectedIndex > 0 Then
                For i As Integer = 0 To .Items.Count - 1
                    .SetSelected(i, True)
                Next
            Else
                lstSupervisores.SelectedIndex = -1
            End If
        End With
        AhoraNo = False
        RaiseEvent CambioSeleccion()
    End Sub





#End Region

End Class