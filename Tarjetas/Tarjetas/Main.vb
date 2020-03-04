Public Class frmMain
    Private frEntradas As New frmEntradas

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        frEntradas.MdiParent = Me

    End Sub


    Private Sub EntradasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EntradasToolStripMenuItem.Click
        frEntradas.WindowState = FormWindowState.Minimized
        frEntradas.Show()
        frEntradas.WindowState = FormWindowState.Maximized
    End Sub


End Class
