Public Class Calendario
    Inherits UserControl
    Private v_Base As String = "dbSemanas"
    Private Cadena As String
    Private f1 As Date = Date.Now
    Private SqlMode As Boolean
    Public ident As String = "'"
    Private v_CampoFecha As String = "Fecha"
    Private ArrFechas() As DateTime
    Friend WithEvents lstMeses As ListBox
    Public WithEvents rdAño As RadioButton
    Private dtFechas As DataTable
    Friend WithEvents nuAño As NumericUpDown
    Friend WithEvents lblMostrar As Label
    Friend WithEvents paFechas As Panel
    Friend WithEvents lstAños As ListBox
    Friend WithEvents chAuto As CheckBox
    Friend WithEvents lblRecargarSemanas As Label

    Public Enum TipoOpcionEnum As Byte
        Dia = 0
        Semana = 1
        Mes = 2
        Año = 3
        DesdeHasta = 4
    End Enum
    Public Enum OnlyAlgoEnum As Byte
        Dia = 0
        Semana = 1
        Mes = 2
        Año = 3
        DesdeHasta = 4
        Nada = 5
    End Enum
    Private vOnly As OnlyAlgoEnum = OnlyAlgoEnum.Nada
#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'UserControl1 reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents fraDesdeH As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtFechaH As DateTimePicker
    Friend WithEvents dtFechaD As DateTimePicker
    Friend WithEvents mFecha As MonthCalendar
    Friend WithEvents Fraop As GroupBox
    Public WithEvents opDesdeH As RadioButton
    Public WithEvents opMes As RadioButton
    Public WithEvents opSemana As RadioButton
    Public WithEvents opDia As RadioButton
    Private WithEvents chHabilitar As CheckBox
    Public WithEvents LstFechas As ListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.mFecha = New MonthCalendar()
        Me.LstFechas = New ListBox()
        Me.chHabilitar = New CheckBox()
        Me.fraDesdeH = New GroupBox()
        Me.Label3 = New Label()
        Me.Label2 = New Label()
        Me.dtFechaH = New DateTimePicker()
        Me.dtFechaD = New DateTimePicker()
        Me.lstMeses = New ListBox()
        Me.Fraop = New GroupBox()
        Me.chAuto = New CheckBox()
        Me.opDesdeH = New RadioButton()
        Me.rdAño = New RadioButton()
        Me.opMes = New RadioButton()
        Me.opSemana = New RadioButton()
        Me.opDia = New RadioButton()
        Me.nuAño = New NumericUpDown()
        Me.lblMostrar = New Label()
        Me.paFechas = New Panel()
        Me.lstAños = New ListBox()
        Me.lblRecargarSemanas = New Label()
        Me.fraDesdeH.SuspendLayout()
        Me.Fraop.SuspendLayout()
        CType(Me.nuAño, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.paFechas.SuspendLayout()
        Me.SuspendLayout()
        '
        'mFecha
        '
        Me.mFecha.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.mFecha.FirstDayOfWeek = Day.Monday
        Me.mFecha.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mFecha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.mFecha.Location = New System.Drawing.Point(3, 1)
        Me.mFecha.MaxSelectionCount = 1
        Me.mFecha.MinDate = New Date(2003, 1, 1, 0, 0, 0, 0)
        Me.mFecha.Name = "mFecha"
        Me.mFecha.ShowToday = False
        Me.mFecha.TabIndex = 1
        Me.mFecha.TitleBackColor = System.Drawing.Color.LightSkyBlue
        Me.mFecha.TitleForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'LstFechas
        '
        Me.LstFechas.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.LstFechas.BorderStyle = BorderStyle.None
        Me.LstFechas.ItemHeight = 14
        Me.LstFechas.Location = New System.Drawing.Point(3, 3)
        Me.LstFechas.Name = "LstFechas"
        Me.LstFechas.Size = New System.Drawing.Size(228, 462)
        Me.LstFechas.TabIndex = 16
        '
        'chHabilitar
        '
        Me.chHabilitar.AutoSize = True
        Me.chHabilitar.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chHabilitar.Checked = True
        Me.chHabilitar.CheckState = CheckState.Checked
        Me.chHabilitar.FlatStyle = FlatStyle.Popup
        Me.chHabilitar.ForeColor = System.Drawing.Color.SteelBlue
        Me.chHabilitar.Location = New System.Drawing.Point(0, 0)
        Me.chHabilitar.Name = "chHabilitar"
        Me.chHabilitar.Size = New System.Drawing.Size(54, 18)
        Me.chHabilitar.TabIndex = 11
        Me.chHabilitar.Text = "Fecha"
        Me.chHabilitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'fraDesdeH
        '
        Me.fraDesdeH.Controls.Add(Me.Label3)
        Me.fraDesdeH.Controls.Add(Me.Label2)
        Me.fraDesdeH.Controls.Add(Me.dtFechaH)
        Me.fraDesdeH.Controls.Add(Me.dtFechaD)
        Me.fraDesdeH.Location = New System.Drawing.Point(3, 3)
        Me.fraDesdeH.Name = "fraDesdeH"
        Me.fraDesdeH.Size = New System.Drawing.Size(106, 112)
        Me.fraDesdeH.TabIndex = 10
        Me.fraDesdeH.TabStop = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Hasta"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(10, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Desde"
        '
        'dtFechaH
        '
        Me.dtFechaH.CalendarTitleBackColor = System.Drawing.Color.LightSkyBlue
        Me.dtFechaH.CustomFormat = ""
        Me.dtFechaH.Format = DateTimePickerFormat.Custom
        Me.dtFechaH.Location = New System.Drawing.Point(8, 82)
        Me.dtFechaH.Name = "dtFechaH"
        Me.dtFechaH.Size = New System.Drawing.Size(88, 20)
        Me.dtFechaH.TabIndex = 6
        '
        'dtFechaD
        '
        Me.dtFechaD.CalendarTitleBackColor = System.Drawing.Color.LightSkyBlue
        Me.dtFechaD.CustomFormat = ""
        Me.dtFechaD.Format = DateTimePickerFormat.Custom
        Me.dtFechaD.Location = New System.Drawing.Point(8, 34)
        Me.dtFechaD.Name = "dtFechaD"
        Me.dtFechaD.Size = New System.Drawing.Size(88, 20)
        Me.dtFechaD.TabIndex = 5
        '
        'lstMeses
        '
        Me.lstMeses.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left), AnchorStyles)
        Me.lstMeses.FormattingEnabled = True
        Me.lstMeses.ItemHeight = 14
        Me.lstMeses.Items.AddRange(New Object() {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.lstMeses.Location = New System.Drawing.Point(3, 3)
        Me.lstMeses.Name = "lstMeses"
        Me.lstMeses.Size = New System.Drawing.Size(69, 452)
        Me.lstMeses.TabIndex = 18
        '
        'Fraop
        '
        Me.Fraop.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.Fraop.Controls.Add(Me.chAuto)
        Me.Fraop.Controls.Add(Me.opDesdeH)
        Me.Fraop.Controls.Add(Me.rdAño)
        Me.Fraop.Controls.Add(Me.opMes)
        Me.Fraop.Controls.Add(Me.opSemana)
        Me.Fraop.Controls.Add(Me.opDia)
        Me.Fraop.Location = New System.Drawing.Point(6, 16)
        Me.Fraop.Name = "Fraop"
        Me.Fraop.Size = New System.Drawing.Size(227, 59)
        Me.Fraop.TabIndex = 2
        Me.Fraop.TabStop = False
        Me.Fraop.Visible = False
        '
        'chAuto
        '
        Me.chAuto.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.chAuto.AutoSize = True
        Me.chAuto.Checked = True
        Me.chAuto.CheckState = CheckState.Checked
        Me.chAuto.Location = New System.Drawing.Point(126, 30)
        Me.chAuto.Name = "chAuto"
        Me.chAuto.Size = New System.Drawing.Size(49, 18)
        Me.chAuto.TabIndex = 22
        Me.chAuto.Text = "Auto"
        Me.chAuto.UseVisualStyleBackColor = True
        '
        'opDesdeH
        '
        Me.opDesdeH.FlatStyle = FlatStyle.Flat
        Me.opDesdeH.Location = New System.Drawing.Point(127, 8)
        Me.opDesdeH.Name = "opDesdeH"
        Me.opDesdeH.Size = New System.Drawing.Size(49, 16)
        Me.opDesdeH.TabIndex = 7
        Me.opDesdeH.Text = "D-H"
        '
        'rdAño
        '
        Me.rdAño.FlatStyle = FlatStyle.Flat
        Me.rdAño.Location = New System.Drawing.Point(75, 30)
        Me.rdAño.Name = "rdAño"
        Me.rdAño.Size = New System.Drawing.Size(47, 16)
        Me.rdAño.TabIndex = 6
        Me.rdAño.Text = "Año"
        '
        'opMes
        '
        Me.opMes.FlatStyle = FlatStyle.Flat
        Me.opMes.Location = New System.Drawing.Point(74, 8)
        Me.opMes.Name = "opMes"
        Me.opMes.Size = New System.Drawing.Size(47, 16)
        Me.opMes.TabIndex = 6
        Me.opMes.Text = "Mes"
        '
        'opSemana
        '
        Me.opSemana.Checked = True
        Me.opSemana.FlatStyle = FlatStyle.Flat
        Me.opSemana.Location = New System.Drawing.Point(6, 30)
        Me.opSemana.Name = "opSemana"
        Me.opSemana.Size = New System.Drawing.Size(96, 16)
        Me.opSemana.TabIndex = 5
        Me.opSemana.TabStop = True
        Me.opSemana.Text = "Semana"
        '
        'opDia
        '
        Me.opDia.FlatStyle = FlatStyle.Flat
        Me.opDia.Location = New System.Drawing.Point(8, 8)
        Me.opDia.Name = "opDia"
        Me.opDia.Size = New System.Drawing.Size(96, 16)
        Me.opDia.TabIndex = 4
        Me.opDia.Text = "Dia"
        '
        'nuAño
        '
        Me.nuAño.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.nuAño.Location = New System.Drawing.Point(83, 437)
        Me.nuAño.Maximum = New Decimal(New Integer() {2100, 0, 0, 0})
        Me.nuAño.Minimum = New Decimal(New Integer() {2003, 0, 0, 0})
        Me.nuAño.Name = "nuAño"
        Me.nuAño.Size = New System.Drawing.Size(54, 20)
        Me.nuAño.TabIndex = 21
        Me.nuAño.Value = New Decimal(New Integer() {2008, 0, 0, 0})
        Me.nuAño.Visible = False
        '
        'lblMostrar
        '
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.Cursor = Cursors.Hand
        Me.lblMostrar.Location = New System.Drawing.Point(71, 2)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(19, 14)
        Me.lblMostrar.TabIndex = 22
        Me.lblMostrar.Text = ">>"
        '
        'paFechas
        '
        Me.paFechas.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.paFechas.Controls.Add(Me.nuAño)
        Me.paFechas.Controls.Add(Me.fraDesdeH)
        Me.paFechas.Controls.Add(Me.lstMeses)
        Me.paFechas.Controls.Add(Me.mFecha)
        Me.paFechas.Controls.Add(Me.LstFechas)
        Me.paFechas.Location = New System.Drawing.Point(5, 24)
        Me.paFechas.Name = "paFechas"
        Me.paFechas.Size = New System.Drawing.Size(234, 460)
        Me.paFechas.TabIndex = 23
        '
        'lstAños
        '
        Me.lstAños.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left), AnchorStyles)
        Me.lstAños.FormattingEnabled = True
        Me.lstAños.ItemHeight = 14
        Me.lstAños.Location = New System.Drawing.Point(3, 25)
        Me.lstAños.Name = "lstAños"
        Me.lstAños.Size = New System.Drawing.Size(79, 452)
        Me.lstAños.TabIndex = 25
        '
        'lblRecargarSemanas
        '
        Me.lblRecargarSemanas.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.lblRecargarSemanas.AutoSize = True
        Me.lblRecargarSemanas.Cursor = Cursors.Hand
        Me.lblRecargarSemanas.Location = New System.Drawing.Point(221, 2)
        Me.lblRecargarSemanas.Name = "lblRecargarSemanas"
        Me.lblRecargarSemanas.Size = New System.Drawing.Size(14, 14)
        Me.lblRecargarSemanas.TabIndex = 23
        Me.lblRecargarSemanas.Text = "R"
        '
        'Calendario
        '
        Me.Controls.Add(Me.lblRecargarSemanas)
        Me.Controls.Add(Me.Fraop)
        Me.Controls.Add(Me.lstAños)
        Me.Controls.Add(Me.paFechas)
        Me.Controls.Add(Me.lblMostrar)
        Me.Controls.Add(Me.chHabilitar)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Calendario"
        Me.Size = New System.Drawing.Size(239, 487)
        Me.fraDesdeH.ResumeLayout(False)
        Me.Fraop.ResumeLayout(False)
        Me.Fraop.PerformLayout()
        CType(Me.nuAño, System.ComponentModel.ISupportInitialize).EndInit()
        Me.paFechas.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
#Region "Eventos"
    Public Event CambioSeleccion()
    Public Event ListIndexChanged(ByVal NuevoIndex As Int32)
#End Region
#Region "Funciones"
    Public Function Devolver_Cadena(Optional ByVal Tabla As String = "", Optional ByVal Campo As String = "") As String
        If Campo = "" Then Campo = v_CampoFecha
        If chHabilitar.Checked Then
            Cadena = ""
            If Tabla = "" Then
                If opDia.Checked Then
                    Cadena = String.Format(" {2}={1}{0}{1}", Format(mFecha.SelectionStart.Date, "MM/dd/yy"), ident, Campo)
                End If
                If opSemana.Checked Then
                    With LstFechas
                        If .SelectedIndex >= 0 Then
                            Cadena = String.Format(" ({3} Between {1}{0}{1} and {1}{2}{1})", Format(CDate(.SelectedItem), "MM/dd/yy"), ident, Format(CDate(.SelectedItem).AddDays(6), "MM/dd/yy"), Campo)
                        End If
                    End With
                End If
                If opMes.Checked Then
                    With lstMeses
                        If .SelectedIndex >= 0 Then
                            Cadena = String.Format(" (Datepart(m,{2})={0} and Datepart(yy,{2})={1})", .SelectedIndex + 1, nuAño.Value, Campo)
                        End If
                    End With
                End If
                If rdAño.Checked Then
                    With lstAños
                        If .SelectedIndex >= 0 Then
                            Cadena = String.Format(" (YEAR({1})={0})", .SelectedItem, Campo)
                        End If
                    End With
                End If
                If opDesdeH.Checked Then
                    Cadena = String.Format(" {3}>={2}{0}{2} AND {3}<={2}{1}{2}", Format(dtFechaD.Value.Date, "MM/dd/yy"), Format(dtFechaH.Value.Date, "MM/dd/yy"), ident, Campo)
                End If
                Return Cadena
            Else 'Nos pasa una tabla
                If opDia.Checked Then
                    Cadena = String.Format(" {1}.{3}={2}{0}{2}", Format(mFecha.SelectionStart.Date, "MM/dd/yy"), Tabla, ident, Campo)
                End If
                If opSemana.Checked Then
                    With LstFechas
                        If .SelectedIndex >= 0 Then
                            Cadena = String.Format(" ({3} Between {1}{0}{1} and {1}{2}{1})", Format(CDate(.SelectedItem), "MM/dd/yy"), ident, Format(CDate(.SelectedItem).AddDays(6), "MM/dd/yy"), Campo)
                        End If
                    End With
                    'f1 = DateAdd(DateInterval.Day, CDbl((mFecha.SelectionStart.DayOfWeek - 1) * -1), mFecha.SelectionStart.Date)
                    'Cadena = String.Format(" {1}.Fecha >= {2}{0}{2} and Fecha<= ", Format(f1, "MM/dd/yy"), Tabla, ident)
                    'Cadena &= String.Format("{1}{0}{1}", Format(DateAdd(DateInterval.Day, 6, f1), "MM/dd/yy"), ident)
                End If
                If opMes.Checked Then
                    With lstMeses
                        If .SelectedIndex >= 0 Then
                            Cadena = String.Format(" (Datepart(m,{2})={0} and Datepart(yy,{2})={1})", .SelectedIndex + 1, nuAño.Value, Campo)
                        End If
                    End With
                    'f1 = DateAdd(DateInterval.Day, CDbl((mFecha.SelectionStart.Day - 1) * -1), mFecha.SelectionStart.Date)
                    'Cadena = String.Format(" {1}.Fecha >= {2}{0}{2} And Fecha<= ", Format(f1, "MM/dd/yy"), Tabla, ident)
                    'Cadena &= String.Format("{1}{0}{1}", Format(DateAdd(DateInterval.Day, CDbl((f1.DaysInMonth(f1.Year, f1.Month)) - 1), f1), "MM/dd/yy").ToString, ident)
                End If
                If rdAño.Checked Then
                    With lstAños
                        If .SelectedIndex >= 0 Then
                            Cadena = String.Format(" (YEAR({1})={0})", .SelectedItem, Campo)
                        End If
                    End With
                End If
                If opDesdeH.Checked Then
                    Cadena = String.Format(" {2}.{4}>={3}{0}{3} AND {2}.{4}<={3}{1}{3}", Format(dtFechaD.Value.Date, "MM/dd/yy"), Format(dtFechaH.Value.Date, "MM/dd/yy"), Tabla, ident, Campo)
                End If
                'If opLista.Checked Then
                '    With LstFechas
                '        If .SelectedIndex >= 0 Then
                '            Cadena = String.Format(" {0}.Fecha={2}{1}{2}", Tabla, Format(CDate(.SelectedItem), "MM/dd/yy"), ident)
                '        End If
                '    End With
                'End If
                Return Cadena
            End If
        Else
            Return ""
        End If
    End Function
    Public Function Devolver_Cadena(ByVal Access As Boolean, Optional ByVal Tabla As String = "", Optional ByVal Campo As String = "") As String
        If Campo = "" Then Campo = v_CampoFecha
        If chHabilitar.Checked Then
            Cadena = ""
            If Tabla = "" Then
                If opDia.Checked Then
                    Cadena = String.Format(" {2}={1}{0}{1}", Format(mFecha.SelectionStart.Date, "MM/dd/yy"), "#", Campo)
                End If
                If opSemana.Checked Then
                    With LstFechas
                        If .SelectedIndex >= 0 Then
                            Cadena = String.Format(" ({3} Between {1}{0}{1} and {1}{2}{1})", Format(CDate(.SelectedItem), "MM/dd/yy"), "#", Format(CDate(.SelectedItem).AddDays(6), "MM/dd/yy"), Campo)
                        End If
                    End With
                End If
                If opMes.Checked Then
                    With lstMeses
                        If .SelectedIndex >= 0 Then
                            'Cadena = String.Format(" (Datepart(m,{2})={0} and Datepart(yy,{2})={1})", .SelectedIndex + 1, nuAño.Value, Campo)
                            Cadena = String.Format(" ({3} Between {1}{0}{1} and {1}{2}{1})", Format(ValorActual, "MM/dd/yy"), "#", Format(ValorActualHasta, "MM/dd/yy"), Campo)
                        End If
                    End With
                End If
                If rdAño.Checked Then
                    With lstAños
                        If .SelectedIndex >= 0 Then
                            Cadena = String.Format(" (YEAR({1})={0})", .SelectedItem, Campo)
                        End If
                    End With
                End If
                If opDesdeH.Checked Then
                    Cadena = String.Format(" {3}>={2}{0}{2} AND {3}<={2}{1}{2}", Format(dtFechaD.Value.Date, "MM/dd/yy"), Format(dtFechaH.Value.Date, "MM/dd/yy"), "#", Campo)
                End If
                Return Cadena
            Else 'Nos pasa una tabla
                If opDia.Checked Then
                    Cadena = String.Format(" {1}.{3}={2}{0}{2}", Format(mFecha.SelectionStart.Date, "MM/dd/yy"), Tabla, "#", Campo)
                End If
                If opSemana.Checked Then
                    With LstFechas
                        If .SelectedIndex >= 0 Then
                            Cadena = String.Format(" ({3} Between {1}{0}{1} and {1}{2}{1})", Format(CDate(.SelectedItem), "MM/dd/yy"), "#", Format(CDate(.SelectedItem).AddDays(6), "MM/dd/yy"), Campo)
                        End If
                    End With
                    'f1 = DateAdd(DateInterval.Day, CDbl((mFecha.SelectionStart.DayOfWeek - 1) * -1), mFecha.SelectionStart.Date)
                    'Cadena = String.Format(" {1}.Fecha >= {2}{0}{2} and Fecha<= ", Format(f1, "MM/dd/yy"), Tabla, "#")
                    'Cadena &= String.Format("{1}{0}{1}", Format(DateAdd(DateInterval.Day, 6, f1), "MM/dd/yy"), "#")
                End If
                If opMes.Checked Then
                    With lstMeses
                        If .SelectedIndex >= 0 Then
                            'Cadena = String.Format(" (Datepart(m,{2})={0} and Datepart(yy,{2})={1})", .SelectedIndex + 1, nuAño.Value, Campo)
                            Cadena = String.Format(" ({3} Between {1}{0}{1} and {1}{2}{1})", Format(ValorActual, "MM/dd/yy"), "#", Format(ValorActualHasta, "MM/dd/yy"), Campo)
                        End If
                    End With
                    'f1 = DateAdd(DateInterval.Day, CDbl((mFecha.SelectionStart.Day - 1) * -1), mFecha.SelectionStart.Date)
                    'Cadena = String.Format(" {1}.Fecha >= {2}{0}{2} And Fecha<= ", Format(f1, "MM/dd/yy"), Tabla, "#")
                    'Cadena &= String.Format("{1}{0}{1}", Format(DateAdd(DateInterval.Day, CDbl((f1.DaysInMonth(f1.Year, f1.Month)) - 1), f1), "MM/dd/yy").ToString, "#")
                End If
                If rdAño.Checked Then
                    With lstAños
                        If .SelectedIndex >= 0 Then
                            Cadena = String.Format(" (YEAR({1})={0})", .SelectedItem, Campo)
                        End If
                    End With
                End If
                If opDesdeH.Checked Then
                    Cadena = String.Format(" {2}.{4}>={3}{0}{3} AND {2}.{4}<={3}{1}{3}", Format(dtFechaD.Value.Date, "MM/dd/yy"), Format(dtFechaH.Value.Date, "MM/dd/yy"), Tabla, "#", Campo)
                End If
                'If opLista.Checked Then
                '    With LstFechas
                '        If .SelectedIndex >= 0 Then
                '            Cadena = String.Format(" {0}.Fecha={2}{1}{2}", Tabla, Format(CDate(.SelectedItem), "MM/dd/yy"), "#")
                '        End If
                '    End With
                'End If
                Return Cadena
            End If
        Else
            Return ""
        End If
    End Function

    Public Function ValorActualHasta() As Date
        Dim d As Date = #1/1/2003#
        If opDesdeH.Checked Then
            d = dtFechaH.Value
        Else
            Select Case TipoOpcion
                Case TipoOpcionEnum.Dia
                    d = mFecha.SelectionStart.Date
                Case TipoOpcionEnum.Semana
                    With LstFechas
                        If .SelectedIndex > -1 Then
                            d = CDate(.Text)
                            d = d.AddDays(6)
                        End If
                    End With
                Case TipoOpcionEnum.Mes
                    With lstMeses
                        If .SelectedIndex > -1 Then
                            d = ValorActual.AddMonths(1)
                            d = d.AddDays(-1)
                        End If
                    End With
                Case TipoOpcionEnum.Año
                    With lstAños
                        d = CDate("1/1/" & CInt(.Text) + 1).AddDays(-1)
                    End With
            End Select
        End If
        Return d
    End Function
    Public Function FechaOK(ByVal Fecha As Date) As Boolean
        If Fecha < ValorActual Or Fecha > ValorActualHasta() Then
            FechaOK = False
        Else
            FechaOK = True
        End If
    End Function
#End Region
#Region "Procedimientos"
    Private Sub opDia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opDia.CheckedChanged
        If opDia.Checked Then
            lstAños.Visible = False
            fraDesdeH.Visible = False
            mFecha.Visible = True
            LstFechas.Visible = False
            lstMeses.Visible = False
            nuAño.Visible = False
            mFecha.SelectionStart = f1
        End If
        If lblMostrar.Text = "<<" Then lblMostrar_Click(Nothing, Nothing)
    End Sub
    Private Sub opSemana_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opSemana.CheckedChanged
        If opSemana.Checked Then
            lstAños.Visible = False
            fraDesdeH.Visible = False
            mFecha.Visible = False
            LstFechas.Visible = True
            lstMeses.Visible = False
            nuAño.Visible = False
            With LstFechas
                Dim d As Date
                For i As Int16 = 0 To .Items.Count - 1
                    d = CDate(.Items.Item(i))
                    If d = f1 Then
                        .SetSelected(i, True)
                        Exit For
                    Else
                        If f1 > d Then
                            .SetSelected(i, True)
                            Exit For
                        End If
                    End If
                Next
            End With
        End If
        If lblMostrar.Text = "<<" Then lblMostrar_Click(Nothing, Nothing)
    End Sub
    Private Sub opMes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opMes.CheckedChanged
        If opMes.Checked Then
            fraDesdeH.Visible = False
            mFecha.Visible = False
            LstFechas.Visible = False
            lstMeses.Visible = True
            lstAños.Visible = False
            nuAño.Visible = True
            With lstMeses
                .SetSelected(f1.Month - 1, True)
            End With
            nuAño.Value = f1.Year
        End If
        If lblMostrar.Text = "<<" Then lblMostrar_Click(Nothing, Nothing)
    End Sub
    Private Sub opAño_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdAño.CheckedChanged
        If rdAño.Checked Then
            lstAños.Visible = True
            fraDesdeH.Visible = False
            mFecha.Visible = False
            LstFechas.Visible = False
            lstMeses.Visible = False
            nuAño.Visible = False
            With lstAños
                Dim d As Int16
                For i As Int16 = 0 To .Items.Count - 1
                    d = CInt(.Items.Item(i))
                    If d = f1.Year Then
                        .SetSelected(i, True)
                        Exit For
                    End If
                Next
            End With
        End If
        If lblMostrar.Text = "<<" Then lblMostrar_Click(Nothing, Nothing)
    End Sub
    Private Sub opDesdeH_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opDesdeH.CheckedChanged
        If opDesdeH.Checked Then
            fraDesdeH.Visible = True
            mFecha.Visible = False
            LstFechas.Visible = False
            lstMeses.Visible = False
            lstAños.Visible = False
            nuAño.Visible = False
            dtFechaD.Value = f1
            dtFechaH.Value = f1
        End If
        If lblMostrar.Text = "<<" Then lblMostrar_Click(Nothing, Nothing)
    End Sub

    ''' <summary>
    ''' Activa la siguiente fecha segun la opción seleccionada.
    ''' Menos en Desde-Hasta.
    ''' El valor a incrementar, si no se pone nada se incrementa en uno. Tambien puede ser negativo.
    ''' </summary>
    ''' <param name="valor"></param>
    ''' <remarks></remarks>
    Public Sub SiguienteFecha(Optional ByVal valor As Int16 = 1)
        Select Case TipoOpcion
            Case TipoOpcionEnum.Dia
                mFecha.SelectionStart = mFecha.SelectionStart.AddDays(valor)
            Case TipoOpcionEnum.Semana
                If valor > 0 And LstFechas.Items.Count <> 0 Then
                    If LstFechas.SelectedIndex < LstFechas.Items.Count - 1 Or LstFechas.SelectedIndex = -1 Then
                        LstFechas.SelectedIndex += valor
                    Else
                        LstFechas.SelectedIndex = 0
                    End If
                Else
                    If valor < 0 And LstFechas.Items.Count <> 0 Then
                        If LstFechas.SelectedIndex > 0 Then
                            LstFechas.SelectedIndex += valor
                        Else
                            LstFechas.SelectedIndex = LstFechas.Items.Count - 1
                        End If
                    End If
                End If
            Case TipoOpcionEnum.Mes
                If valor > 0 Then
                    If lstMeses.SelectedIndex < lstMeses.Items.Count - 1 Or lstMeses.SelectedIndex = -1 Then
                        lstMeses.SelectedIndex += valor
                    Else
                        lstMeses.SelectedIndex = 0
                        nuAño.Value += 1
                    End If
                Else
                    If valor < 0 Then
                        If lstMeses.SelectedIndex > 0 Then
                            lstMeses.SelectedIndex += valor
                        Else
                            lstMeses.SelectedIndex = lstMeses.Items.Count - 1
                            nuAño.Value -= 1
                        End If
                    End If
                End If
            Case TipoOpcionEnum.Año
                If valor > 0 Then
                    If lstAños.SelectedIndex < lstAños.Items.Count - 1 Or lstAños.SelectedIndex = -1 Then
                        lstAños.SelectedIndex += valor
                    Else
                        lstAños.SelectedIndex = 0
                    End If
                Else
                    If valor < 0 Then
                        If lstAños.SelectedIndex > 0 Then
                            lstAños.SelectedIndex += valor
                        Else
                            lstAños.SelectedIndex = lstAños.Items.Count - 1
                        End If
                    End If
                End If
        End Select
    End Sub

    Private Sub mFecha_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles mFecha.KeyPress
        Select Case e.KeyChar
            Case "+"
                chHabilitar.Checked = True
                mFecha.SelectionStart = mFecha.SelectionStart.AddDays(1)
                If chAuto.Checked = True Then RaiseEvent CambioSeleccion()
                mFecha.Focus()
            Case "-"
                chHabilitar.Checked = True
                mFecha.SelectionStart = mFecha.SelectionStart.AddDays(-1)
                If chAuto.Checked = True Then RaiseEvent CambioSeleccion()
                mFecha.Focus()
            Case Convert.ToChar(13)
                chHabilitar.Checked = True
                If chAuto.Checked = True Then RaiseEvent CambioSeleccion()
                mFecha.Focus()
        End Select
    End Sub
    Private Sub Inicio(Optional ByVal oBase As String = "")
        Try
            Dim d As clsBases.Principal
            If oBase = "" Then oBase = v_Base
            d = New clsBases.Principal(oBase, "192.168.1.11")

            FechaSeleccionada = mFecha.SelectionStart.Date
            dtFechas = d.Datos("Select Fecha from Semanas Order by Fecha Desc")
            If dtFechas.Rows.Count Then
                f1 = dtFechas.Rows(0).Item(0)
                LstFechas.Items.Clear()
                For Each dr As DataRow In dtFechas.Rows
                    LstFechas.Items.Add(Format(dr.Item(0), "dd/MM/yyy"))
                Next
                lstAños.Items.Clear()
                Dim n As DataTable = d.Datos("Select YEAR(Fecha) from Semanas Group By YEAR(Fecha) Order by YEAR(Fecha) Desc")
                For Each dr As DataRow In n.Rows
                    lstAños.Items.Add(dr.Item(0))
                Next
                nuAño.Value = n.Rows(0).Item(0)
            End If
        Catch er As Exception
            Beep()
        End Try
    End Sub
#End Region
#Region "Propiedades"
    Public Property Base() As String
        Get

        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Public Property ValorActual() As Date
        Get
            Dim d As Date = #1/1/2003#
            If chHabilitar.Checked Then
                If opDia.Checked Then
                    d = mFecha.SelectionStart.Date
                Else
                    If opSemana.Checked Then
                        If LstFechas.SelectedIndex > -1 Then
                            d = CDate(LstFechas.SelectedItem)
                        End If
                    Else
                        If opMes.Checked Then
                            If lstMeses.SelectedIndex > -1 Then
                                d = CDate(String.Format("1/{0}/{1}", lstMeses.SelectedIndex + 1, nuAño.Value))
                            End If
                        Else
                            If rdAño.Checked Then
                                If lstAños.SelectedIndex > -1 Then
                                    d = CDate("1/1/" & lstAños.SelectedItem.ToString)
                                End If
                            Else
                                d = dtFechaD.Value
                            End If
                        End If
                    End If
                End If
            End If
            Return d
        End Get
        Set(ByVal value As Date)
            f1 = value
            Select Case TipoOpcion
                Case TipoOpcionEnum.Dia
                    mFecha.SelectionStart = value
                Case TipoOpcionEnum.Semana
                    With LstFechas
                        Dim d As Date
                        For i As Int16 = 0 To .Items.Count - 1
                            d = CDate(.Items.Item(i))
                            If d = value Then
                                .SetSelected(i, True)
                                Exit For
                            Else
                                If value > d Then
                                    .SetSelected(i, True)
                                    Exit For
                                End If
                            End If
                        Next
                    End With
                Case TipoOpcionEnum.Mes
                    With lstMeses
                        .SetSelected(value.Month - 1, True)
                    End With
                Case TipoOpcionEnum.Año
                    With lstAños
                        Dim d As Int16
                        For i As Int16 = 0 To .Items.Count - 1
                            d = CInt(.Items.Item(i))
                            If d = value.Year Then
                                .SetSelected(i, True)
                                Exit For
                            End If
                        Next
                    End With
            End Select
        End Set
    End Property
    ''' <summary>
    ''' You ever dance with the devil by the pale moonlight? 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CampoFecha() As String
        Get
            Return v_CampoFecha
        End Get
        Set(ByVal value As String)
            If value.Length = 0 Then
                MsgBox("No puede ser una cadena vacia loco.")
            Else
                v_CampoFecha = value
            End If
        End Set
    End Property
    Public Property FechaSeleccionada() As Date
        Get
            Return f1
        End Get
        Set(ByVal Value As Date)
            If Value > #1/1/1900# Then
                mFecha.SetDate(Value)
            End If
            f1 = Value
        End Set
    End Property
    Public ReadOnly Property FechaInicioRango() As Date
        Get
            Dim fec As Date
            If opDia.Checked Then
                Return f1
            End If
            If opSemana.Checked Then
                fec = DateAdd(DateInterval.Day, CDbl((mFecha.SelectionStart.DayOfWeek - 1) * -1), mFecha.SelectionStart.Date)
                Return fec
            End If
            If opMes.Checked Then
                fec = DateAdd(DateInterval.Day, CDbl((mFecha.SelectionStart.Day - 1) * -1), mFecha.SelectionStart.Date)
                Return fec
            End If
        End Get
    End Property

    Public ReadOnly Property FechaListSeleccionada() As DateTime
        Get
            Return LstFechas.SelectedItem
        End Get
    End Property

    Public Property Checked() As Boolean
        Get
            Return chHabilitar.Checked
        End Get
        Set(ByVal value As Boolean)
            chHabilitar.Checked = value
        End Set
    End Property
    Public Property TipoOpcion() As TipoOpcionEnum
        Get
            If opDia.Checked Then
                Return TipoOpcionEnum.Dia
            Else
                If opSemana.Checked Then
                    Return TipoOpcionEnum.Semana
                Else
                    If opMes.Checked Then
                        Return TipoOpcionEnum.Mes
                    Else
                        If rdAño.Checked Then
                            Return TipoOpcionEnum.Año
                        Else
                            Return TipoOpcionEnum.DesdeHasta
                        End If
                    End If
                End If
            End If
        End Get
        Set(ByVal value As TipoOpcionEnum)
            Select Case value
                Case TipoOpcionEnum.Dia
                    opDia.Checked = True
                Case TipoOpcionEnum.Semana
                    opSemana.Checked = True
                Case TipoOpcionEnum.Mes
                    opMes.Checked = True
                Case TipoOpcionEnum.Año
                    rdAño.Checked = True
                Case TipoOpcionEnum.DesdeHasta
                    opDesdeH.Checked = True
            End Select
        End Set
    End Property
    Public Property OnlyAlgo() As OnlyAlgoEnum
        Get
            Return vOnly
        End Get
        Set(ByVal value As OnlyAlgoEnum)
            Select Case value
                Case TipoOpcionEnum.Dia
                    opDia.Checked = True
                    opDia.Enabled = True
                    opSemana.Enabled = False
                    opMes.Enabled = False
                    rdAño.Enabled = False
                    opDesdeH.Enabled = False
                    nuAño.Enabled = False
                    vOnly = OnlyAlgoEnum.Dia
                Case TipoOpcionEnum.Semana
                    opSemana.Checked = True
                    opDia.Enabled = False
                    opSemana.Enabled = True
                    opMes.Enabled = False
                    rdAño.Enabled = False
                    opDesdeH.Enabled = False
                    nuAño.Enabled = False
                    vOnly = OnlyAlgoEnum.Semana
                Case TipoOpcionEnum.Mes
                    opMes.Checked = True
                    opDia.Enabled = False
                    opSemana.Enabled = False
                    opMes.Enabled = True
                    rdAño.Enabled = False
                    nuAño.Enabled = True
                    opDesdeH.Enabled = False
                    vOnly = OnlyAlgoEnum.Mes
                Case TipoOpcionEnum.Año
                    rdAño.Checked = True
                    opDia.Enabled = False
                    opSemana.Enabled = False
                    opMes.Enabled = False
                    rdAño.Enabled = True
                    nuAño.Enabled = False
                    opDesdeH.Enabled = False
                    vOnly = OnlyAlgoEnum.Año
                Case TipoOpcionEnum.DesdeHasta
                    opDesdeH.Checked = True
                    opDia.Enabled = False
                    opSemana.Enabled = False
                    opMes.Enabled = False
                    rdAño.Enabled = False
                    opDesdeH.Enabled = True
                    nuAño.Enabled = False
                    vOnly = OnlyAlgoEnum.DesdeHasta
                Case OnlyAlgoEnum.Nada
                    opDia.Enabled = True
                    opSemana.Enabled = True
                    opMes.Enabled = True
                    rdAño.Enabled = True
                    opDesdeH.Enabled = True
                    nuAño.Enabled = True
                    vOnly = OnlyAlgoEnum.Nada
            End Select
        End Set
    End Property

    Public Property Seleccionar_Primer() As Boolean
        Get
            If LstFechas.SelectedItems.Count Then Return LstFechas.SelectedItems.Count
        End Get
        Set(ByVal value As Boolean)
            If LstFechas.Items.Count Then LstFechas.SetSelected(0, value)
        End Set
    End Property

#End Region
    Private Sub Calendario_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Inicio()
    End Sub
    Private Sub mFecha_DateSelected(ByVal sender As Object, ByVal e As DateRangeEventArgs) Handles mFecha.DateSelected
        f1 = mFecha.SelectionStart.Date
        If chHabilitar.Checked = True Then
            If chAuto.Checked = True Then RaiseEvent CambioSeleccion()
        End If
    End Sub
    Private Sub mFecha_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles mFecha.MouseUp
        Dim a As MonthCalendar.HitTestInfo = mFecha.HitTest(e.X, e.Y)
        If a.HitArea = MonthCalendar.HitArea.NextMonthButton Or a.HitArea = MonthCalendar.HitArea.PrevMonthButton Then
            If chHabilitar.Checked = True Then
                If chAuto.Checked = True Then RaiseEvent CambioSeleccion()
            End If
        End If
    End Sub
    Private Sub LstFechas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstFechas.SelectedIndexChanged, lstMeses.SelectedIndexChanged, lstAños.SelectedIndexChanged
        If sender.name = "lstMeses" Then
            If lstMeses.SelectedIndex > -1 Then
                f1 = CDate(String.Format("{0}/1/{1}", lstMeses.SelectedIndex + 1, nuAño.Value))
            End If
        ElseIf Not sender.name = "lstAños" Then
            If IsDate(sender.Text) Then
                f1 = CDate(sender.Text)
            End If
        End If
        If chHabilitar.Checked Then
            If chAuto.Checked = True Then RaiseEvent CambioSeleccion()
        End If
    End Sub


    Private Sub lblMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMostrar.Click
        If lblMostrar.Text = ">>" Then
            lblMostrar.Text = "<<"
            paFechas.SetBounds(0, 97, Me.Width, Me.Height - 97)
            Fraop.Visible = True
        Else
            lblMostrar.Text = ">>"
            paFechas.SetBounds(0, 19, Me.Width, Me.Height - 19)
            Fraop.Visible = False
        End If
    End Sub

    Private Sub dtFechaH_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtFechaH.ValueChanged, dtFechaD.ValueChanged
        If chHabilitar.Checked Then
            If chAuto.Checked = True Then RaiseEvent CambioSeleccion()
        End If
    End Sub

    Private Sub lblRecargarSemanas_Click(sender As Object, e As EventArgs) Handles lblRecargarSemanas.Click
        Inicio()
    End Sub
End Class
