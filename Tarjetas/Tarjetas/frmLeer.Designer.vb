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
        Me.SuspendLayout()
        '
        'grdDatos
        '
        Me.grdDatos.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None
        Me.grdDatos.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn
        Me.grdDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.grdDatos.Size = New System.Drawing.Size(756, 650)
        Me.grdDatos.TabIndex = 0
        '
        'cmdLeer
        '
        Me.cmdLeer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.lstTipo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstTipo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstTipo.FormattingEnabled = True
        Me.lstTipo.Location = New System.Drawing.Point(783, 99)
        Me.lstTipo.Name = "lstTipo"
        Me.lstTipo.Size = New System.Drawing.Size(120, 169)
        Me.lstTipo.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(780, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Tipo"
        '
        'lblArchivo
        '
        Me.lblArchivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblArchivo.AutoSize = True
        Me.lblArchivo.Location = New System.Drawing.Point(910, 17)
        Me.lblArchivo.Name = "lblArchivo"
        Me.lblArchivo.Size = New System.Drawing.Size(0, 13)
        Me.lblArchivo.TabIndex = 4
        '
        'cmdEscribir
        '
        Me.cmdEscribir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.cmdGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.lblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(780, 271)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(0, 13)
        Me.lblTotal.TabIndex = 3
        '
        'lblSucursal
        '
        Me.lblSucursal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.Location = New System.Drawing.Point(780, 38)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(48, 13)
        Me.lblSucursal.TabIndex = 3
        Me.lblSucursal.Text = "Sucursal"
        '
        'frmLeer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1308, 674)
        Me.Controls.Add(Me.lblArchivo)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblSucursal)
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
End Class
