<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEntradas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEntradas))
        Me.grdEntradas = New Grilla2.SpeedGrilla()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.SuspendLayout()
        '
        'grdEntradas
        '
        Me.grdEntradas.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None
        Me.grdEntradas.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn
        Me.grdEntradas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.grdEntradas.Location = New System.Drawing.Point(12, 12)
        Me.grdEntradas.MenuActivado = False
        Me.grdEntradas.Name = "grdEntradas"
        Me.grdEntradas.PieDePagina = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & "Page {0} of {1}"
        Me.grdEntradas.PintarFilaSel = True
        Me.grdEntradas.Redraw = True
        Me.grdEntradas.Row = 0
        Me.grdEntradas.Rows = 50
        Me.grdEntradas.Size = New System.Drawing.Size(413, 622)
        Me.grdEntradas.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 648)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1366, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'frmEntradas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1366, 670)
        Me.ControlBox = False
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.grdEntradas)
        Me.Name = "frmEntradas"
        Me.Text = "Entradas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grdEntradas As Grilla2.SpeedGrilla
    Friend WithEvents StatusStrip1 As StatusStrip
End Class
