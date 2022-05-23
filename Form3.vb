Imports System.Data.SqlClient
'Imports System.Linq
'Imports System.Text
'Imports System.Threading.Tasks
'Imports System.Windows.Forms
'Imports System.Configuration
Public Class Form3
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\ammal\OneDrive\سطح المكتب\WindowsApplication18\Database1.mdf;Integrated Security=True;User Instance=True"
        Try
            Dim reader As SqlDataReader

            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "Select * From [user] Where PhoneNo = " & Form2.TextBox2.Text & "and Password = " & Form2.TextBox4.Text & ""

            con.Open()
            reader = cmd.ExecuteReader

            If (reader.Read()) Then
                Label4.Text = reader("IdUser")

            Else
                Label4.Text = ""
                MessageBox.Show(" phoneno " & Form2.TextBox2.Text & " not found")

            End If
            reader.Close()
        Catch ex As Exception
            'MessageBox.Show("...خطأ أثناء إدراج البيانات في الجدول")
            MsgBox("...خطأ أثناء إدراج البيانات في الجدول", MsgBoxStyle.Exclamation, Title:="تنبية")
        Finally
            con.Close()
        End Try

    End Sub

   


    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try

            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "insert into [Doctor] values('" & Label4.Text & "','" & ComboBox1.Text & "')"
            con.Open()
            cmd.ExecuteNonQuery()
            MsgBox("تمت الإضافة بنجاح", Title:="إشعار")
            Me.Hide()
            Form1.Show()

        Catch ex As Exception
            MsgBox("...خطأ في الإضافة ", MsgBoxStyle.Exclamation, Title:="تنبية")
            'MsgBox("خطأ في الإضافة")
        Finally
            con.Close()
        End Try

    End Sub

End Class