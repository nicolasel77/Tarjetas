Public Class frmBase
    Inherits System.Windows.Forms.Form

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents lblInf As System.Windows.Forms.Label
    Friend WithEvents Sistema As System.Windows.Forms.Panel
    Friend WithEvents mnuSistema As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuSalir As System.Windows.Forms.MenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
    Friend WithEvents lblLineaAbajo As System.Windows.Forms.Label
    Friend WithEvents lblLateral As System.Windows.Forms.Label
    Friend WithEvents lkMenuP As System.Windows.Forms.LinkLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.lblInf = New System.Windows.Forms.Label()
        Me.Sistema = New System.Windows.Forms.Panel()
        Me.lkMenuP = New System.Windows.Forms.LinkLabel()
        Me.mnuSistema = New System.Windows.Forms.ContextMenu()
        Me.mnuSalir = New System.Windows.Forms.MenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblLineaAbajo = New System.Windows.Forms.Label()
        Me.lblLateral = New System.Windows.Forms.Label()
        Me.Sistema.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(96, 24)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(696, 24)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInf
        '
        Me.lblInf.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblInf.Location = New System.Drawing.Point(0, 542)
        Me.lblInf.Name = "lblInf"
        Me.lblInf.Size = New System.Drawing.Size(792, 24)
        Me.lblInf.TabIndex = 0
        Me.lblInf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Sistema
        '
        Me.Sistema.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Sistema.Controls.AddRange(New System.Windows.Forms.Control() {Me.lkMenuP})
        Me.Sistema.Dock = System.Windows.Forms.DockStyle.Top
        Me.Sistema.Name = "Sistema"
        Me.Sistema.Size = New System.Drawing.Size(792, 24)
        Me.Sistema.TabIndex = 1
        '
        'lkMenuP
        '
        Me.lkMenuP.ContextMenu = Me.mnuSistema
        Me.lkMenuP.LinkColor = System.Drawing.Color.DimGray
        Me.lkMenuP.Location = New System.Drawing.Point(8, 8)
        Me.lkMenuP.Name = "lkMenuP"
        Me.lkMenuP.Size = New System.Drawing.Size(48, 10)
        Me.lkMenuP.TabIndex = 0
        Me.lkMenuP.TabStop = True
        Me.lkMenuP.Text = "Sistema"
        Me.lkMenuP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'mnuSistema
        '
        Me.mnuSistema.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuSalir})
        '
        'mnuSalir
        '
        Me.mnuSalir.Index = 0
        Me.mnuSalir.Text = "Salir"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdSalir, Me.Label1})
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(96, 518)
        Me.Panel1.TabIndex = 2
        '
        'cmdSalir
        '
        Me.cmdSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdSalir.Location = New System.Drawing.Point(8, 496)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(80, 16)
        Me.cmdSalir.TabIndex = 2
        Me.cmdSalir.Text = "Salir"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SkyBlue
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 8)
        Me.Label1.TabIndex = 0
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLineaAbajo
        '
        Me.lblLineaAbajo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblLineaAbajo.Location = New System.Drawing.Point(0, 536)
        Me.lblLineaAbajo.Name = "lblLineaAbajo"
        Me.lblLineaAbajo.Size = New System.Drawing.Size(792, 8)
        Me.lblLineaAbajo.TabIndex = 1
        Me.lblLineaAbajo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLateral
        '
        Me.lblLateral.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblLateral.Location = New System.Drawing.Point(784, 48)
        Me.lblLateral.Name = "lblLateral"
        Me.lblLateral.Size = New System.Drawing.Size(8, 488)
        Me.lblLateral.TabIndex = 1
        Me.lblLateral.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmBase
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSkyBlue
        Me.ClientSize = New System.Drawing.Size(792, 566)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblLineaAbajo, Me.lblTitulo, Me.Panel1, Me.Sistema, Me.lblInf, Me.lblLateral})
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmBase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Sistema.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private vEstado As Boolean = True
    Public ReadOnly Property Estado() As Boolean
        Get
            Return vEstado
        End Get
    End Property

    Private Sub lblTitulo_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles lblTitulo.Paint, lblInf.Paint
        Dim b As New Drawing2D.LinearGradientBrush(ClientRectangle, Color.LightSkyBlue, Color.White, Drawing.Drawing2D.LinearGradientMode.Horizontal)
        Dim c As New Drawing2D.LinearGradientBrush(ClientRectangle, Color.White, Color.LightSkyBlue, Drawing.Drawing2D.LinearGradientMode.Horizontal)
        With e.Graphics
            If CType(sender.name, String) = "lblTitulo" Then
                .FillRectangle(b, ClientRectangle)
            Else
                .FillRectangle(c, ClientRectangle)
            End If
        End With
    End Sub

    Private Sub lkMenuP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lkMenuP.LinkClicked
        With lkMenuP
            .ContextMenu.Show(lkMenuP, New Point(.Left - 10, .Top + 7.5))
        End With
    End Sub

    Private Sub frmBase_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        'Agregar todo el código para acomodar los controles
        lblTitulo.Width = Me.Width - 96
        cmdSalir.Top = Me.Height - 112
        lblLineaAbajo.Width = Me.Width
        lblLineaAbajo.Top = Me.Height - 64
        lblLateral.Height = Me.Height - 110
        lblLateral.Left = Me.Width - 16
    End Sub

    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        mnuSalir_Click(cmdSalir, Nothing)
    End Sub

    Private Sub mnuSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub

    Private Sub frmBase_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        vEstado = False
    End Sub
End Class
