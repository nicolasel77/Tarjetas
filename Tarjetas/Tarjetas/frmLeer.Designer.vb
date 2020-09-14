<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLeer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLeer))
        Me.grdDatos = New Grilla2.SpeedGrilla()
        Me.cmdLeer = New System.Windows.Forms.Button()
        Me.lstTipo = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblArchivo = New System.Windows.Forms.Label()
        Me.cmdEscribir = New System.Windows.Forms.Button()
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblSucursal = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grdCuentas = New Grilla2.SpeedGrilla()
        Me.SuspendLayout()
        '
        'grdDatos
        '
        Me.grdDatos.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None
        Me.grdDatos.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn
        Me.grdDatos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grdDatos.AutoResize = False
        Me.grdDatos.bColor = System.Drawing.SystemColors.Window
        Me.grdDatos.bColorSel = System.Drawing.SystemColors.Highlight
        Me.grdDatos.bFColor = System.Drawing.SystemColors.WindowText
        Me.grdDatos.bFColorSel = System.Drawing.SystemColors.HighlightText
        Me.grdDatos.Col = 0
        Me.grdDatos.Cols = 10
        Me.grdDatos.DataMember = ""
        Me.grdDatos.DataSource = Nothing
        Me.grdDatos.EnableEdicion = True
        Me.grdDatos.Encabezado = ""
        Me.grdDatos.fColor = System.Drawing.SystemColors.Control
        Me.grdDatos.FixCols = 0
        Me.grdDatos.FixRows = 0
        Me.grdDatos.FuenteEncabezado = Nothing
        Me.grdDatos.FuentePieDePagina = Nothing
        Me.grdDatos.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.grdDatos.Location = New System.Drawing.Point(12, 12)
        Me.grdDatos.MenuActivado = False
        Me.grdDatos.Name = "grdDatos"
        Me.grdDatos.PieDePagina = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & "Page {0} of {1}"
        Me.grdDatos.PintarFilaSel = True
        Me.grdDatos.Redraw = True
        Me.grdDatos.Row = 0
        Me.grdDatos.Rows = 50
        Me.grdDatos.Size = New System.Drawing.Size(756, 635)
        Me.grdDatos.TabIndex = 0
        '
        'cmdLeer
        '
        Me.cmdLeer.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdLeer.Location = New System.Drawing.Point(783, 12)
        Me.cmdLeer.Name = "cmdLeer"
        Me.cmdLeer.Size = New System.Drawing.Size(121, 23)
        Me.cmdLeer.TabIndex = 1
        Me.cmdLeer.Text = "Cargar Archivo"
        Me.cmdLeer.UseVisualStyleBackColor = True
        '
        'lstTipo
        '
        Me.lstTipo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstTipo.FormattingEnabled = True
        Me.lstTipo.ItemHeight = 20
        Me.lstTipo.Location = New System.Drawing.Point(783, 99)
        Me.lstTipo.Name = "lstTipo"
        Me.lstTipo.Size = New System.Drawing.Size(166, 160)
        Me.lstTipo.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(780, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Tipo"
        '
        'lblArchivo
        '
        Me.lblArchivo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblArchivo.AutoSize = True
        Me.lblArchivo.Location = New System.Drawing.Point(910, 17)
        Me.lblArchivo.Name = "lblArchivo"
        Me.lblArchivo.Size = New System.Drawing.Size(0, 13)
        Me.lblArchivo.TabIndex = 4
        '
        'cmdEscribir
        '
        Me.cmdEscribir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdEscribir.Location = New System.Drawing.Point(783, 54)
        Me.cmdEscribir.Name = "cmdEscribir"
        Me.cmdEscribir.Size = New System.Drawing.Size(121, 23)
        Me.cmdEscribir.TabIndex = 1
        Me.cmdEscribir.Text = "Leer"
        Me.cmdEscribir.UseVisualStyleBackColor = True
        '
        'cmdGuardar
        '
        Me.cmdGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGuardar.Location = New System.Drawing.Point(783, 290)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(121, 23)
        Me.cmdGuardar.TabIndex = 1
        Me.cmdGuardar.Text = "Guardar"
        Me.cmdGuardar.UseVisualStyleBackColor = True
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(781, 274)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(0, 13)
        Me.lblTotal.TabIndex = 3
        '
        'lblSucursal
        '
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.Location = New System.Drawing.Point(780, 38)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(48, 13)
        Me.lblSucursal.TabIndex = 3
        Me.lblSucursal.Text = "Sucursal"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(781, 349)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Cuentas"
        '
        'grdCuentas
        '
        Me.grdCuentas.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None
        Me.grdCuentas.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn
        Me.grdCuentas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdCuentas.AutoResize = False
        Me.grdCuentas.bColor = System.Drawing.SystemColors.Window
        Me.grdCuentas.bColorSel = System.Drawing.SystemColors.Highlight
        Me.grdCuentas.bFColor = System.Drawing.SystemColors.WindowText
        Me.grdCuentas.bFColorSel = System.Drawing.SystemColors.HighlightText
        Me.grdCuentas.Col = 0
        Me.grdCuentas.Cols = 10
        Me.grdCuentas.DataMember = ""
        Me.grdCuentas.DataSource = Nothing
        Me.grdCuentas.EnableEdicion = True
        Me.grdCuentas.Encabezado = ""
        Me.grdCuentas.fColor = System.Drawing.SystemColors.Control
        Me.grdCuentas.FixCols = 0
        Me.grdCuentas.FixRows = 0
        Me.grdCuentas.FuenteEncabezado = Nothing
        Me.grdCuentas.FuentePieDePagina = Nothing
        Me.grdCuentas.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.grdCuentas.Location = New System.Drawing.Point(783, 369)
        Me.grdCuentas.MenuActivado = False
        Me.grdCuentas.Name = "grdCuentas"
        Me.grdCuentas.PieDePagina = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & "Page {0} of {1}"
        Me.grdCuentas.PintarFilaSel = True
        Me.grdCuentas.Redraw = True
        Me.grdCuentas.Row = 0
        Me.grdCuentas.Rows = 50
        Me.grdCuentas.Size = New System.Drawing.Size(458, 277)
        Me.grdCuentas.TabIndex = 5
        '
        'frmLeer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1253, 659)
        Me.Controls.Add(Me.grdCuentas)
        Me.Controls.Add(Me.lblArchivo)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblSucursal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdGuardar)
        Me.Controls.Add(Me.cmdEscribir)
        Me.Controls.Add(Me.lstTipo)
        Me.Controls.Add(Me.cmdLeer)
        Me.Controls.Add(Me.grdDatos)
        Me.Name = "frmLeer"
        Me.Text = "Leer Excel"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grdDatos As Grilla2.SpeedGrilla
    Friend WithEvents cmdLeer As Button
    Friend WithEvents lstTipo As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblArchivo As Label
    Friend WithEvents cmdEscribir As Button
    Friend WithEvents cmdGuardar As Button
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblSucursal As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents grdCuentas As Grilla2.SpeedGrilla
End Class
