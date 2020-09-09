Public Class frmMain
    Private frEntradas As New frmEntradas
    Private frResumen As New frmResumen
    Private frLeer As New frmLeer

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        frEntradas.MdiParent = Me
        frResumen.MdiParent = Me
        frLeer.MdiParent = Me
    End Sub


    Private Sub EntradasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EntradasToolStripMenuItem.Click
        frEntradas.WindowState = FormWindowState.Minimized
        frEntradas.Show()
        frEntradas.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ResumenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResumenToolStripMenuItem.Click
        frResumen.WindowState = FormWindowState.Minimized
        frResumen.Show()
        frResumen.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub LeerDatosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LeerDatosToolStripMenuItem.Click
        frLeer.WindowState = FormWindowState.Minimized
        frLeer.Show()
        frLeer.WindowState = FormWindowState.Maximized
    End Sub
End Class
