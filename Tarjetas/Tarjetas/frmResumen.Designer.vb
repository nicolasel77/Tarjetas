<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResumen
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmResumen))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grdGastos = New Grilla2.SpeedGrilla()
        Me.grdEntradas = New Grilla2.SpeedGrilla()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.lstTiposE = New System.Windows.Forms.ListBox()
        Me.chAcreditado = New System.Windows.Forms.CheckBox()
        Me.chGAgrupar = New System.Windows.Forms.CheckBox()
        Me.chGTipo = New System.Windows.Forms.CheckBox()
        Me.chAgrupar = New System.Windows.Forms.CheckBox()
        Me.chGFecha = New System.Windows.Forms.CheckBox()
        Me.chTipo = New System.Windows.Forms.CheckBox()
        Me.chGSuc = New System.Windows.Forms.CheckBox()
        Me.chFecha = New System.Windows.Forms.CheckBox()
        Me.chSuc = New System.Windows.Forms.CheckBox()
        Me.grdSaldos = New Grilla2.SpeedGrilla()
        Me.grdSaldias = New Grilla2.SpeedGrilla()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmdCargar = New System.Windows.Forms.Button()
        Me.cFecha = New Calendario.Calendario()
        Me.Sucs = New Sucursales.Sucursales()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(535, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(363, 23)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Gastos"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(352, 23)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Entradas"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.grdGastos.Location = New System.Drawing.Point(535, 26)
        Me.grdGastos.MenuActivado = False
        Me.grdGastos.Name = "grdGastos"
        Me.grdGastos.PieDePagina = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & "Page {0} of {1}"
        Me.grdGastos.PintarFilaSel = True
        Me.grdGastos.Redraw = True
        Me.grdGastos.Row = 0
        Me.grdGastos.Rows = 50
        Me.grdGastos.Size = New System.Drawing.Size(363, 391)
        Me.grdGastos.TabIndex = 6
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
        Me.grdEntradas.Location = New System.Drawing.Point(3, 26)
        Me.grdEntradas.MenuActivado = False
        Me.grdEntradas.Name = "grdEntradas"
        Me.grdEntradas.PieDePagina = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & "Page {0} of {1}"
        Me.grdEntradas.PintarFilaSel = True
        Me.grdEntradas.Redraw = True
        Me.grdEntradas.Row = 0
        Me.grdEntradas.Rows = 50
        Me.grdEntradas.Size = New System.Drawing.Size(409, 391)
        Me.grdEntradas.TabIndex = 5
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(12, 12)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Sucs)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmdCargar)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cFecha)
        Me.SplitContainer1.Size = New System.Drawing.Size(1276, 724)
        Me.SplitContainer1.SplitterDistance = 1011
        Me.SplitContainer1.TabIndex = 12
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.lstTiposE)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chAcreditado)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chGAgrupar)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chGTipo)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chAgrupar)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chGFecha)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chTipo)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chGSuc)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chFecha)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chSuc)
        Me.SplitContainer2.Panel1.Controls.Add(Me.grdEntradas)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.grdGastos)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.grdSaldos)
        Me.SplitContainer2.Panel2.Controls.Add(Me.grdSaldias)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label5)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer2.Size = New System.Drawing.Size(1011, 724)
        Me.SplitContainer2.SplitterDistance = 420
        Me.SplitContainer2.TabIndex = 0
        '
        'lstTiposE
        '
        Me.lstTiposE.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstTiposE.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstTiposE.FormattingEnabled = True
        Me.lstTiposE.Location = New System.Drawing.Point(418, 171)
        Me.lstTiposE.Name = "lstTiposE"
        Me.lstTiposE.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstTiposE.Size = New System.Drawing.Size(111, 234)
        Me.lstTiposE.TabIndex = 13
        '
        'chAcreditado
        '
        Me.chAcreditado.AutoSize = True
        Me.chAcreditado.Checked = True
        Me.chAcreditado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chAcreditado.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chAcreditado.Location = New System.Drawing.Point(425, 146)
        Me.chAcreditado.Name = "chAcreditado"
        Me.chAcreditado.Size = New System.Drawing.Size(104, 17)
        Me.chAcreditado.TabIndex = 12
        Me.chAcreditado.Text = "Solo Acreditados"
        Me.chAcreditado.UseVisualStyleBackColor = True
        '
        'chGAgrupar
        '
        Me.chGAgrupar.AutoSize = True
        Me.chGAgrupar.Checked = True
        Me.chGAgrupar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chGAgrupar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chGAgrupar.Location = New System.Drawing.Point(904, 26)
        Me.chGAgrupar.Name = "chGAgrupar"
        Me.chGAgrupar.Size = New System.Drawing.Size(61, 17)
        Me.chGAgrupar.TabIndex = 12
        Me.chGAgrupar.Text = "Agrupar"
        Me.chGAgrupar.UseVisualStyleBackColor = True
        '
        'chGTipo
        '
        Me.chGTipo.AutoSize = True
        Me.chGTipo.Checked = True
        Me.chGTipo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chGTipo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chGTipo.Location = New System.Drawing.Point(912, 95)
        Me.chGTipo.Name = "chGTipo"
        Me.chGTipo.Size = New System.Drawing.Size(45, 17)
        Me.chGTipo.TabIndex = 12
        Me.chGTipo.Text = "Tipo"
        Me.chGTipo.UseVisualStyleBackColor = True
        '
        'chAgrupar
        '
        Me.chAgrupar.AutoSize = True
        Me.chAgrupar.Checked = True
        Me.chAgrupar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chAgrupar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chAgrupar.Location = New System.Drawing.Point(425, 26)
        Me.chAgrupar.Name = "chAgrupar"
        Me.chAgrupar.Size = New System.Drawing.Size(61, 17)
        Me.chAgrupar.TabIndex = 12
        Me.chAgrupar.Text = "Agrupar"
        Me.chAgrupar.UseVisualStyleBackColor = True
        '
        'chGFecha
        '
        Me.chGFecha.AutoSize = True
        Me.chGFecha.Checked = True
        Me.chGFecha.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chGFecha.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chGFecha.Location = New System.Drawing.Point(912, 72)
        Me.chGFecha.Name = "chGFecha"
        Me.chGFecha.Size = New System.Drawing.Size(54, 17)
        Me.chGFecha.TabIndex = 12
        Me.chGFecha.Text = "Fecha"
        Me.chGFecha.UseVisualStyleBackColor = True
        '
        'chTipo
        '
        Me.chTipo.AutoSize = True
        Me.chTipo.Checked = True
        Me.chTipo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chTipo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chTipo.Location = New System.Drawing.Point(433, 95)
        Me.chTipo.Name = "chTipo"
        Me.chTipo.Size = New System.Drawing.Size(45, 17)
        Me.chTipo.TabIndex = 12
        Me.chTipo.Text = "Tipo"
        Me.chTipo.UseVisualStyleBackColor = True
        '
        'chGSuc
        '
        Me.chGSuc.AutoSize = True
        Me.chGSuc.Checked = True
        Me.chGSuc.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chGSuc.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chGSuc.Location = New System.Drawing.Point(912, 49)
        Me.chGSuc.Name = "chGSuc"
        Me.chGSuc.Size = New System.Drawing.Size(43, 17)
        Me.chGSuc.TabIndex = 12
        Me.chGSuc.Text = "Suc"
        Me.chGSuc.UseVisualStyleBackColor = True
        '
        'chFecha
        '
        Me.chFecha.AutoSize = True
        Me.chFecha.Checked = True
        Me.chFecha.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chFecha.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chFecha.Location = New System.Drawing.Point(433, 72)
        Me.chFecha.Name = "chFecha"
        Me.chFecha.Size = New System.Drawing.Size(54, 17)
        Me.chFecha.TabIndex = 12
        Me.chFecha.Text = "Fecha"
        Me.chFecha.UseVisualStyleBackColor = True
        '
        'chSuc
        '
        Me.chSuc.AutoSize = True
        Me.chSuc.Checked = True
        Me.chSuc.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chSuc.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chSuc.Location = New System.Drawing.Point(433, 49)
        Me.chSuc.Name = "chSuc"
        Me.chSuc.Size = New System.Drawing.Size(43, 17)
        Me.chSuc.TabIndex = 12
        Me.chSuc.Text = "Suc"
        Me.chSuc.UseVisualStyleBackColor = True
        '
        'grdSaldos
        '
        Me.grdSaldos.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None
        Me.grdSaldos.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn
        Me.grdSaldos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdSaldos.AutoResize = False
        Me.grdSaldos.bColor = System.Drawing.SystemColors.Window
        Me.grdSaldos.bColorSel = System.Drawing.SystemColors.Highlight
        Me.grdSaldos.bFColor = System.Drawing.SystemColors.WindowText
        Me.grdSaldos.bFColorSel = System.Drawing.SystemColors.HighlightText
        Me.grdSaldos.Col = 0
        Me.grdSaldos.Cols = 10
        Me.grdSaldos.DataMember = ""
        Me.grdSaldos.DataSource = Nothing
        Me.grdSaldos.EnableEdicion = True
        Me.grdSaldos.Encabezado = ""
        Me.grdSaldos.fColor = System.Drawing.SystemColors.Control
        Me.grdSaldos.FixCols = 0
        Me.grdSaldos.FixRows = 0
        Me.grdSaldos.FuenteEncabezado = Nothing
        Me.grdSaldos.FuentePieDePagina = Nothing
        Me.grdSaldos.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.grdSaldos.Location = New System.Drawing.Point(679, 31)
        Me.grdSaldos.MenuActivado = False
        Me.grdSaldos.Name = "grdSaldos"
        Me.grdSaldos.PieDePagina = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & "Page {0} of {1}"
        Me.grdSaldos.PintarFilaSel = True
        Me.grdSaldos.Redraw = True
        Me.grdSaldos.Row = 0
        Me.grdSaldos.Rows = 50
        Me.grdSaldos.Size = New System.Drawing.Size(329, 269)
        Me.grdSaldos.TabIndex = 5
        '
        'grdSaldias
        '
        Me.grdSaldias.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None
        Me.grdSaldias.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn
        Me.grdSaldias.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdSaldias.AutoResize = False
        Me.grdSaldias.bColor = System.Drawing.SystemColors.Window
        Me.grdSaldias.bColorSel = System.Drawing.SystemColors.Highlight
        Me.grdSaldias.bFColor = System.Drawing.SystemColors.WindowText
        Me.grdSaldias.bFColorSel = System.Drawing.SystemColors.HighlightText
        Me.grdSaldias.Col = 0
        Me.grdSaldias.Cols = 10
        Me.grdSaldias.DataMember = ""
        Me.grdSaldias.DataSource = Nothing
        Me.grdSaldias.EnableEdicion = True
        Me.grdSaldias.Encabezado = ""
        Me.grdSaldias.fColor = System.Drawing.SystemColors.Control
        Me.grdSaldias.FixCols = 0
        Me.grdSaldias.FixRows = 0
        Me.grdSaldias.FuenteEncabezado = Nothing
        Me.grdSaldias.FuentePieDePagina = Nothing
        Me.grdSaldias.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.grdSaldias.Location = New System.Drawing.Point(3, 31)
        Me.grdSaldias.MenuActivado = False
        Me.grdSaldias.Name = "grdSaldias"
        Me.grdSaldias.PieDePagina = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & "Page {0} of {1}"
        Me.grdSaldias.PintarFilaSel = True
        Me.grdSaldias.Redraw = True
        Me.grdSaldias.Row = 0
        Me.grdSaldias.Rows = 50
        Me.grdSaldias.Size = New System.Drawing.Size(653, 269)
        Me.grdSaldias.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(679, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(329, 23)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Saldos"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(653, 23)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Salidas"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdCargar
        '
        Me.cmdCargar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCargar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdCargar.Location = New System.Drawing.Point(7, 678)
        Me.cmdCargar.Name = "cmdCargar"
        Me.cmdCargar.Size = New System.Drawing.Size(249, 41)
        Me.cmdCargar.TabIndex = 10
        Me.cmdCargar.Text = "Cargar"
        Me.cmdCargar.UseVisualStyleBackColor = True
        '
        'cFecha
        '
        Me.cFecha.Base = Nothing
        Me.cFecha.CampoFecha = "Fecha"
        Me.cFecha.Checked = True
        Me.cFecha.FechaSeleccionada = New Date(2020, 5, 25, 0, 0, 0, 0)
        Me.cFecha.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cFecha.Location = New System.Drawing.Point(7, 0)
        Me.cFecha.Name = "cFecha"
        Me.cFecha.OnlyAlgo = Calendario.Calendario.OnlyAlgoEnum.Nada
        Me.cFecha.Seleccionar_Primer = False
        Me.cFecha.Size = New System.Drawing.Size(239, 266)
        Me.cFecha.TabIndex = 9
        Me.cFecha.TipoOpcion = Calendario.Calendario.TipoOpcionEnum.Semana
        Me.cFecha.ValorActual = New Date(2003, 1, 1, 0, 0, 0, 0)
        '
        'Sucs
        '
        Me.Sucs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Sucs.Filtro_Tabla = ""
        Me.Sucs.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sucs.Location = New System.Drawing.Point(7, 272)
        Me.Sucs.Name = "Sucs"
        Me.Sucs.Size = New System.Drawing.Size(249, 400)
        Me.Sucs.TabIndex = 11
        Me.Sucs.Titulo = "Sucursales"
        '
        'frmResumen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1300, 748)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmResumen"
        Me.Text = "Resumen"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents grdGastos As Grilla2.SpeedGrilla
    Friend WithEvents grdEntradas As Grilla2.SpeedGrilla
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents grdSaldos As Grilla2.SpeedGrilla
    Friend WithEvents grdSaldias As Grilla2.SpeedGrilla
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cFecha As Calendario.Calendario
    Friend WithEvents cmdCargar As Button
    Friend WithEvents chAgrupar As CheckBox
    Friend WithEvents chTipo As CheckBox
    Friend WithEvents chFecha As CheckBox
    Friend WithEvents chSuc As CheckBox
    Friend WithEvents chAcreditado As CheckBox
    Friend WithEvents chGAgrupar As CheckBox
    Friend WithEvents chGTipo As CheckBox
    Friend WithEvents chGFecha As CheckBox
    Friend WithEvents chGSuc As CheckBox
    Friend WithEvents lstTiposE As ListBox
    Friend WithEvents Sucs As Sucursales.Sucursales
End Class
