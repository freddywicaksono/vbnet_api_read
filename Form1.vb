﻿Public Class Form1
   
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()

        oEmployee.Token = CreateToken()
        oEmployee.APILink = "http://localhost/ujicoba/api/read.php"
        oEmployee.Method = "POST"
        oEmployee.getAllData(DS, DG, "employee")
        
    End Sub

    

   

End Class
