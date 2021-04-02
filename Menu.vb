Public Class Menu

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Dim jawab As DialogResult
        jawab = MessageBox.Show("Apakah Anda mau menutup aplikasi ini?", "Konfirmasi", MessageBoxButtons.YesNo)
        If (jawab = vbYes) Then
            End
        Else

        End If
    End Sub

    Private Sub TampilToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TampilToolStripMenuItem.Click
        Form1.ShowDialog()
    End Sub

    Private Sub EntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EntryToolStripMenuItem.Click
        Entry.ShowDialog()
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        Edit.ShowDialog()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Hapus.ShowDialog()
    End Sub
End Class