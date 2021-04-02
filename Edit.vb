Public Class Edit

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

    Private Sub UpdateData()
        oEmployee.Token = CreateToken()
        oEmployee.ID = txtID.Text
        oEmployee.Name = txtName.Text
        oEmployee.Email = txtEmail.Text
        oEmployee.Designation = txtDesignation.Text
        oEmployee.APILink = "http://localhost/ujicoba/api/update.php"
        oEmployee.Method = "POST"
        oEmployee.UpdateRecord(txtID.Text)
        If (oEmployee.UpdateData = True) Then
            MessageBox.Show("Data Berhasil Diperbarui")
        Else
            MessageBox.Show("Data gagal Diperbarui")
        End If
    End Sub

    Private Sub ProsesUpdateData()
        If (txtID.Text <> "" And txtName.Text <> "") Then
            If (oEmployee.RecordFound = True) Then

                UpdateData()
            Else
                MessageBox.Show("Data ID harus ditemukan dahulu sebelum data bisa diupdate")
            End If

        Else
            MessageBox.Show("Data ID dan Name tidak boleh kosong")
        End If
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        ProsesUpdateData()
    End Sub

  
End Class