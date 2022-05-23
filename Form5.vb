Imports System.Data.SqlClient
Public Class Form5
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim reader As SqlDataReader
    Dim id1 As Integer = 1
    Dim id2 As Integer = 3
    Dim id3 As Integer = 5
    Dim id4 As Integer = 7
    Dim u1 As Integer = 3
    Dim u2 As Integer = 4
    Dim u3 As Integer = 5
    Dim u4 As Integer = 7

 
    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\ammal\OneDrive\سطح المكتب\WindowsApplication18\Database1.mdf;Integrated Security=True;User Instance=True"
    End Sub


    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            da = New SqlDataAdapter("select* from [user] where PhoneNo ='" & TextBox1.Text & "'and Password='" & TextBox2.Text & "'and EnterType='" & ComboBox1.Text & "'", conn)
            da.Fill(dt)
        Catch ex As Exception

        End Try

        If dt.Rows.Count > 0 And ComboBox1.SelectedIndex = 0 Then
            Form6.Show()

            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "Select* From [user] Where PhoneNo = " & TextBox1.Text & "and Password = " & TextBox2.Text & ""
            con.Open()
            reader = cmd.ExecuteReader


            If (reader.Read()) Then
                Form6.TextBox1.Text = reader("IdUser")
                Form6.TextBox2.Text = reader("Name")
                Form6.TextBox3.Text = reader("Email")
                Form6.TextBox4.Text = reader("Sex")
                Form6.TextBox5.Text = reader("EnterType")

            Else
                TextBox2.Text = ""
                MessageBox.Show("phone no " & TextBox1.Text & " not found")

            End If
            reader.Close()
            con.Close()

        ElseIf dt.Rows.Count > 0 And ComboBox1.SelectedIndex = 1 Then
            Form4.Show()

            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "Select* From [user] Where PhoneNo = " & TextBox1.Text & "and Password = " & TextBox2.Text & ""
            con.Open()
            reader = cmd.ExecuteReader

            If (reader.Read()) Then

                Form4.TextBox1.Text = reader("IdUser")
                Form4.TextBox2.Text = reader("Name")
                Form4.TextBox3.Text = reader("Email")
                Form4.TextBox4.Text = reader("Sex")
                Form4.TextBox5.Text = reader("EnterType")

            Else
                TextBox2.Text = ""
                MessageBox.Show("phone no " & TextBox1.Text & " not found")

            End If
            reader.Close()
            con.Close()

            If Form4.TextBox1.Text = u1 Then
                cmd = New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "Select * From [Doctor] Where IdD = " & id1 & ""
                con.Open()
                reader = cmd.ExecuteReader
            ElseIf Form4.TextBox1.Text = u2 Then
                cmd = New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "Select * From [Doctor] Where IdD = " & id2 & ""

                con.Open()
                reader = cmd.ExecuteReader
            ElseIf Form4.TextBox1.Text = u3 Then
                cmd = New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "Select * From [Doctor] Where IdD = " & id3 & ""

                con.Open()
                reader = cmd.ExecuteReader
            ElseIf Form4.TextBox1.Text = u4 Then

                cmd = New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "Select * From [Doctor] Where IdD = " & id4 & ""
                con.Open()
                reader = cmd.ExecuteReader
            End If

            If (reader.Read()) Then
                Form4.TextBox6.Text = reader("Major")

            End If
            reader.Close()
            con.Close()


        ElseIf dt.Rows.Count > 0 And ComboBox1.SelectedIndex = 2 Then
            Form7.Show()

            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "Select* From [user] Where PhoneNo = " & TextBox1.Text & "and Password = " & TextBox2.Text & ""
            con.Open()
            reader = cmd.ExecuteReader

            If (reader.Read()) Then
                Form7.TextBox1.Text = reader("IdUser")
                Form7.TextBox2.Text = reader("Name")
                Form7.TextBox3.Text = reader("Email")
                Form7.TextBox4.Text = reader("Sex")
                Form7.TextBox5.Text = reader("EnterType")

            Else
                TextBox2.Text = ""
                MessageBox.Show("phone no " & TextBox1.Text & " not found")

            End If
        End If
        Try
            reader.Close()
        Catch ex As Exception
            MsgBox("...الرجاء التحقق من صحة البيانات", MsgBoxStyle.Exclamation, Title:="تنبية")
        Finally
            con.Close()
        End Try
        dt.Clear()
    End Sub

End Class