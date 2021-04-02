Public Class Hapus

    

    Private Sub txtID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtID.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            If (txtID.Text <> "") Then
                oEmployee.Token = CreateToken()
                oEmployee.APILink = "http://localhost/ujicoba/api/single_read.php"
                oEmployee.Method = "POST"

                oEmployee.CariEmployee(txtID.Text)
                If (oEmployee.RecordFound = True) Then
                    TampilkanEmployee()
                Else
                    MessageBox.Show("Data tidak ditemukan")
                End If
            End If
        End If
    End Sub

    Private Sub TampilkanEmployee()
        txtName.Text = oEmployee.Name
        txtEmail.Text = oEmployee.Email
        txtDesignation.Text = oEmployee.Designation
    End Sub

    Private Sub DeleteData()
        oEmployee.Token = CreateToken()
        oEmployee.ID = txtID.Text

        oEmployee.APILink = "http://localhost/ujicoba/api/delete.php"
        oEmployee.Method = "POST"
        oEmployee.DeleteRecord(txtID.Text)
        If (oEmployee.DeleteData = True) Then
            MessageBox.Show("Data Berhasil Dihapus")
        Else
            MessageBox.Show("Data gagal Dihapus")
        End If
    End Sub

    Private Sub ProsesDeleteData()
        Dim jawab As DialogResult
        If (txtID.Text <> "" And txtName.Text <> "") Then
            If (oEmployee.RecordFound = True) Then
                jawab = MessageBox.Show("Apakah data ini akan dihapus?", "Konfirmasi", MessageBoxButtons.YesNo)
                If (jawab = vbYes) Then
                    DeleteData()
                Else
                    MessageBox.Show("Data batal dihapus")
                End If

            Else
                MessageBox.Show("Data ID harus ditemukan dahulu sebelum data bisa dihapus")
            End If

        Else
            MessageBox.Show("Data ID dan Name tidak boleh kosong")
        End If
    End Sub

    Private Sub btnHapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHapus.Click
        ProsesDeleteData()
    End Sub
End Class