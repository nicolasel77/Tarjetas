<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sucursales
    Inherits UserControl

    'UserControl1 overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lstTipo = New System.Windows.Forms.ListBox()
        Me.lstSucursales = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lstSucsClientes = New System.Windows.Forms.ListBox()
        Me.tiTiempo = New System.Windows.Forms.Timer(Me.components)
        Me.lstSupervisores = New System.Windows.Forms.ListBox()
        Me.cmdTodas = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'lstTipo
        '
        Me.lstTipo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstTipo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstTipo.FormattingEnabled = True
        Me.lstTipo.ItemHeight = 14
        Me.lstTipo.Items.AddRange(New Object() {"Todas"})
        Me.lstTipo.Location = New System.Drawing.Point(404, 19)
        Me.lstTipo.Name = "lstTipo"
        Me.lstTipo.Size = New System.Drawing.Size(70, 84)
        Me.lstTipo.TabIndex = 2
        '
        'lstSucursales
        '
        Me.lstSucursales.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstSucursales.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstSucursales.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstSucursales.FormattingEnabled = True
        Me.lstSucursales.ItemHeight = 15
        Me.lstSucursales.Location = New System.Drawing.Point(6, 19)
        Me.lstSucursales.Name = "lstSucursales"
        Me.lstSucursales.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstSucursales.Size = New System.Drawing.Size(392, 465)
        Me.lstSucursales.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Sucursales"
        '
        'lstSucsClientes
        '
        Me.lstSucsClientes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstSucsClientes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstSucsClientes.FormattingEnabled = True
        Me.lstSucsClientes.ItemHeight = 14
        Me.lstSucsClientes.Items.AddRange(New Object() {"Todas", "Sucursales", "Clientes"})
        Me.lstSucsClientes.Location = New System.Drawing.Point(404, 109)
        Me.lstSucsClientes.Name = "lstSucsClientes"
        Me.lstSucsClientes.Size = New System.Drawing.Size(70, 42)
        Me.lstSucsClientes.TabIndex = 2
        '
        'tiTiempo
        '
        Me.tiTiempo.Interval = 500
        '
        'lstSupervisores
        '
        Me.lstSupervisores.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstSupervisores.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstSupervisores.FormattingEnabled = True
        Me.lstSupervisores.ItemHeight = 14
        Me.lstSupervisores.Items.AddRange(New Object() {"Todas", "Edy", "Enrique"})
        Me.lstSupervisores.Location = New System.Drawing.Point(404, 157)
        Me.lstSupervisores.Name = "lstSupervisores"
        Me.lstSupervisores.Size = New System.Drawing.Size(70, 56)
        Me.lstSupervisores.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.lstSupervisores, "Click: filtra" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Doble Click: filtra y selecciona")
        '
        'cmdTodas
        '
        Me.cmdTodas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdTodas.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdTodas.Location = New System.Drawing.Point(404, 462)
        Me.cmdTodas.Name = "cmdTodas"
        Me.cmdTodas.Size = New System.Drawing.Size(70, 22)
        Me.cmdTodas.TabIndex = 1
        Me.cmdTodas.Text = "Todas"
        Me.cmdTodas.UseVisualStyleBackColor = True
        '
        'Sucursales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdTodas)
        Me.Controls.Add(Me.lstSucursales)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lstSupervisores)
        Me.Controls.Add(Me.lstSucsClientes)
        Me.Controls.Add(Me.lstTipo)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Sucursales"
        Me.Size = New System.Drawing.Size(477, 489)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstTipo As ListBox
    Friend WithEvents lstSucursales As ListBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lstSucsClientes As ListBox
    Friend WithEvents tiTiempo As Timer
    Friend WithEvents lstSupervisores As ListBox
    Friend WithEvents cmdTodas As Button
    Friend WithEvents ToolTip1 As ToolTip
End Class
