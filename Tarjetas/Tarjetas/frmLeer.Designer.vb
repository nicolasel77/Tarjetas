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
        Me.grdDatos.Size = New System.Drawing.Size(663, 636)
        Me.grdDatos.TabIndex = 0
        '
        'cmdLeer
        '
        Me.cmdLeer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdLeer.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdLeer.Location = New System.Drawing.Point(690, 12)
        Me.cmdLeer.Name = "cmdLeer"
        Me.cmdLeer.Size = New System.Drawing.Size(121, 23)
        Me.cmdLeer.TabIndex = 1
        Me.cmdLeer.Text = "Cargar Archivo"
        Me.cmdLeer.UseVisualStyleBackColor = True
        '
        'frmLeer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1215, 660)
        Me.Controls.Add(Me.cmdLeer)
        Me.Controls.Add(Me.grdDatos)
        Me.Name = "frmLeer"
        Me.Text = "Leer Excel"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grdDatos As Grilla2.SpeedGrilla
    Friend WithEvents cmdLeer As Button
End Class
