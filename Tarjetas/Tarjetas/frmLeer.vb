Public Class frmLeer
    Private fCarpeta As String = "E:\Tarjetas"

    Private Sub cmdLeer_Click(sender As Object, e As EventArgs) Handles cmdLeer.Click
        'Dim vExcel As Object
        'Dim vLibro As Object

        Dim f As New OpenFileDialog()

        f.InitialDirectory = fCarpeta
        f.ShowDialog()
        Dim s As String = f.FileName
        Dim n As String = s.Substring(s.LastIndexOf("\") + 1)

        If s.Length Then
            'vExcel = CreateObject("Excel.Application")
            'vLibro = vExcel.workbooks.open(s)

            Dim i As Integer = 1
            n = fCarpeta & "\Back\" & n
            Dim ex As String = n.Substring(n.LastIndexOf("."))

            While My.Computer.FileSystem.FileExists(n)
                n = n.Substring(0, n.LastIndexOf("."))
                n &= i & ex
                i += 1
            End While

            My.Computer.FileSystem.CopyFile(s, n)
            'My.Computer.FileSystem.MoveFile(s, n)
            'vExcel.close
            'vExcel = Nothing
            'vLibro = Nothing
        End If

    End Sub
End Class