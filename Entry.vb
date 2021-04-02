Public Class Entry

    Private Sub Entry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SimpanData()
        oEmployee.Token = CreateToken()
        oEmployee.Name = txtName.Text
        oEmployee.Email = txtEmail.Text
        oEmployee.Designation = txtDesignation.Text
        oEmployee.APILink = "http://localhost/ujicoba/api/create.php"
        oEmployee.Method = "POST"
        oEmployee.Simpan()
        If (oEmployee.InsertData = True) Then
            MessageBox.Show("Data Berhasil Ditambahkan")
        Else
            MessageBox.Show("Data gagal Ditambahkan")
        End If
    End Sub

    Private Sub btnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSimpan.Click
        SimpanData()
    End Sub
End Class