<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEntradas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEntradas))
        Me.grdEntradas = New Grilla2.SpeedGrilla()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblSaldo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblSuma = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblNada = New System.Windows.Forms.ToolStripStatusLabel()
        Me.grdGastos = New Grilla2.SpeedGrilla()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.mntFecha = New System.Windows.Forms.MonthCalendar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rdNada = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rdFecha = New System.Windows.Forms.RadioButton()
        Me.rdSuc = New System.Windows.Forms.RadioButton()
        Me.chAuto = New System.Windows.Forms.CheckBox()
        Me.chRepetirTipo = New System.Windows.Forms.CheckBox()
        Me.cSucs = New Sucursales.Sucursales()
        Me.cmdLimpiar = New System.Windows.Forms.Button()
        Me.dtSemana = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdEntradas
        '
        Me.grdEntradas.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None
        Me.grdEntradas.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn
        Me.grdEntradas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grdEntradas.AutoResize = False
        Me.grdEntradas.bColor = System.Drawing.SystemColors.Window
        Me.grdEntradas.bColorSel = System.Drawing.SystemColors.Highlight
        Me.grdEntradas.bFColor = System.Drawing.SystemColors.WindowText
        Me.grdEntradas.bFColorSel = System.Drawing.SystemColors.HighlightText
        Me.grdEntradas.Col = 0
        Me.grdEntradas.Cols = 10
        Me.grdEntradas.DataMember = ""
        Me.grdEntradas.DataSource = Nothing
        Me.grdEntradas.EnableEdicion = True
        Me.grdEntradas.Encabezado = ""
        Me.grdEntradas.fColor = System.Drawing.SystemColors.Control
        Me.grdEntradas.FixCols = 0
        Me.grdEntradas.FixRows = 0
        Me.grdEntradas.FuenteEncabezado = Nothing
        Me.grdEntradas.FuentePieDePagina = Nothing
        Me.grdEntradas.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.grdEntradas.Location = New System.Drawing.Point(12, 32)
        Me.grdEntradas.MenuActivado = False
        Me.grdEntradas.Name = "grdEntradas"
        Me.grdEntradas.PieDePagina = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & "Page {0} of {1}"
        Me.grdEntradas.PintarFilaSel = True
        Me.grdEntradas.Redraw = True
        Me.grdEntradas.Row = 0
        Me.grdEntradas.Rows = 50
        Me.grdEntradas.Size = New System.Drawing.Size(409, 562)
        Me.grdEntradas.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblSaldo, Me.lblSuma, Me.lblNada})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 608)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1272, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblSaldo
        '
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(36, 17)
        Me.lblSaldo.Text = "Saldo"
        '
        'lblSuma
        '
        Me.lblSuma.Name = "lblSuma"
        Me.lblSuma.Size = New System.Drawing.Size(37, 17)
        Me.lblSuma.Text = "Suma"
        '
        'lblNada
        '
        Me.lblNada.Name = "lblNada"
        Me.lblNada.Size = New System.Drawing.Size(0, 17)
        '
        'grdGastos
        '
        Me.grdGastos.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None
        Me.grdGastos.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn
        Me.grdGastos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grdGastos.AutoResize = False
        Me.grdGastos.bColor = System.Drawing.SystemColors.Window
        Me.grdGastos.bColorSel = System.Drawing.SystemColors.Highlight
        Me.grdGastos.bFColor = System.Drawing.SystemColors.WindowText
        Me.grdGastos.bFColorSel = System.Drawing.SystemColors.HighlightText
        Me.grdGastos.Col = 0
        Me.grdGastos.Cols = 10
        Me.grdGastos.DataMember = ""
        Me.grdGastos.DataSource = Nothing
        Me.grdGastos.EnableEdicion = True
        Me.grdGastos.Encabezado = ""
        Me.grdGastos.fColor = System.Drawing.SystemColors.Control
        Me.grdGastos.FixCols = 0
        Me.grdGastos.FixRows = 0
        Me.grdGastos.FuenteEncabezado = Nothing
        Me.grdGastos.FuentePieDePagina = Nothing
        Me.grdGastos.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.grdGastos.Location = New System.Drawing.Point(438, 32)
        Me.grdGastos.MenuActivado = False
        Me.grdGastos.Name = "grdGastos"
        Me.grdGastos.PieDePagina = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & "Page {0} of {1}"
        Me.grdGastos.PintarFilaSel = True
        Me.grdGastos.Redraw = True
        Me.grdGastos.Row = 0
        Me.grdGastos.Rows = 50
        Me.grdGastos.Size = New System.Drawing.Size(405, 562)
        Me.grdGastos.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(409, 23)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Entradas"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(438, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(404, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Gastos"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'mntFecha
        '
        Me.mntFecha.Location = New System.Drawing.Point(855, 32)
        Me.mntFecha.MaxSelectionCount = 1
        Me.mntFecha.Name = "mntFecha"
        Me.mntFecha.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(855, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(192, 23)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Fecha"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rdNada
        '
        Me.rdNada.AutoSize = True
        Me.rdNada.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rdNada.Location = New System.Drawing.Point(859, 219)
        Me.rdNada.Name = "rdNada"
        Me.rdNada.Size = New System.Drawing.Size(50, 17)
        Me.rdNada.TabIndex = 5
        Me.rdNada.Text = "Nada"
        Me.rdNada.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(856, 203)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Incrementar:"
        '
        'rdFecha
        '
        Me.rdFecha.AutoSize = True
        Me.rdFecha.Checked = True
        Me.rdFecha.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rdFecha.Location = New System.Drawing.Point(859, 242)
        Me.rdFecha.Name = "rdFecha"
        Me.rdFecha.Size = New System.Drawing.Size(54, 17)
        Me.rdFecha.TabIndex = 5
        Me.rdFecha.TabStop = True
        Me.rdFecha.Text = "Fecha"
        Me.rdFecha.UseVisualStyleBackColor = True
        '
        'rdSuc
        '
        Me.rdSuc.AutoSize = True
        Me.rdSuc.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rdSuc.Location = New System.Drawing.Point(859, 265)
        Me.rdSuc.Name = "rdSuc"
        Me.rdSuc.Size = New System.Drawing.Size(65, 17)
        Me.rdSuc.TabIndex = 5
        Me.rdSuc.Text = "Sucursal"
        Me.rdSuc.UseVisualStyleBackColor = True
        '
        'chAuto
        '
        Me.chAuto.AutoSize = True
        Me.chAuto.Checked = True
        Me.chAuto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chAuto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chAuto.Location = New System.Drawing.Point(859, 329)
        Me.chAuto.Name = "chAuto"
        Me.chAuto.Size = New System.Drawing.Size(74, 17)
        Me.chAuto.TabIndex = 7
        Me.chAuto.Text = "Autorizado"
        Me.chAuto.UseVisualStyleBackColor = True
        '
        'chRepetirTipo
        '
        Me.chRepetirTipo.AutoSize = True
        Me.chRepetirTipo.Checked = True
        Me.chRepetirTipo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chRepetirTipo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chRepetirTipo.Location = New System.Drawing.Point(859, 306)
        Me.chRepetirTipo.Name = "chRepetirTipo"
        Me.chRepetirTipo.Size = New System.Drawing.Size(82, 17)
        Me.chRepetirTipo.TabIndex = 8
        Me.chRepetirTipo.Text = "Repetir Tipo"
        Me.chRepetirTipo.UseVisualStyleBackColor = True
        '
        'cSucs
        '
        Me.cSucs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cSucs.Filtro_Tabla = ""
        Me.cSucs.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cSucs.Location = New System.Drawing.Point(1062, 6)
        Me.cSucs.Name = "cSucs"
        Me.cSucs.Size = New System.Drawing.Size(210, 588)
        Me.cSucs.TabIndex = 9
        Me.cSucs.Titulo = "Sucursales"
        '
        'cmdLimpiar
        '
        Me.cmdLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdLimpiar.Location = New System.Drawing.Point(855, 571)
        Me.cmdLimpiar.Name = "cmdLimpiar"
        Me.cmdLimpiar.Size = New System.Drawing.Size(75, 23)
        Me.cmdLimpiar.TabIndex = 10
        Me.cmdLimpiar.Text = "Limpiar"
        Me.cmdLimpiar.UseVisualStyleBackColor = True
        '
        'dtSemana
        '
        Me.dtSemana.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtSemana.Location = New System.Drawing.Point(933, 352)
        Me.dtSemana.Name = "dtSemana"
        Me.dtSemana.ShowCheckBox = True
        Me.dtSemana.Size = New System.Drawing.Size(123, 20)
        Me.dtSemana.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(852, 358)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Cargar semana:"
        '
        'frmEntradas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1272, 630)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dtSemana)
        Me.Controls.Add(Me.cmdLimpiar)
        Me.Controls.Add(Me.cSucs)
        Me.Controls.Add(Me.chRepetirTipo)
        Me.Controls.Add(Me.chAuto)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.rdSuc)
        Me.Controls.Add(Me.rdFecha)
        Me.Controls.Add(Me.rdNada)
        Me.Controls.Add(Me.mntFecha)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grdGastos)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.grdEntradas)
        Me.Name = "frmEntradas"
        Me.Text = "Entradas - Gastos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grdEntradas As Grilla2.SpeedGrilla
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents grdGastos As Grilla2.SpeedGrilla
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents mntFecha As MonthCalendar
    Friend WithEvents Label3 As Label
    Friend WithEvents rdNada As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents rdFecha As RadioButton
    Friend WithEvents rdSuc As RadioButton
    Friend WithEvents chAuto As CheckBox
    Friend WithEvents chRepetirTipo As CheckBox
    Friend WithEvents cSucs As Sucursales.Sucursales
    Friend WithEvents lblSaldo As ToolStripStatusLabel
    Friend WithEvents lblSuma As ToolStripStatusLabel
    Friend WithEvents cmdLimpiar As Button
    Friend WithEvents dtSemana As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents lblNada As ToolStripStatusLabel
End Class
