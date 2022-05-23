Imports System.Data.SqlClient
Public Class Form4
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim id1 As Integer = 1
    Dim id2 As Integer = 3
    Dim id3 As Integer = 5
    Dim id4 As Integer = 7
  
    Sub cleartextboxes()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Hide()
        con.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\ammal\OneDrive\سطح المكتب\WindowsApplication18\Database1.mdf;Integrated Security=True;User Instance=True"

    End Sub


    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form8.Show()
    End Sub

    


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
        Form5.Close()
        Form1.Show()
    End Sub
End Class