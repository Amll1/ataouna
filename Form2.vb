Imports System.Data.SqlClient

Public Class Form2
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Public da1 As New SqlDataAdapter
    Public dt1 As New DataTable
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\ammal\OneDrive\سطح المكتب\WindowsApplication18\Database1.mdf;Integrated Security=True;User Instance=True"
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try
            If ComboBox3.SelectedIndex = 1 Then
                da1 = New SqlDataAdapter("select* from [Doctor] ", conn)
                da1.Fill(dt1)
                If dt1.Rows.Count <= 4 Then
                    MessageBox.Show("تم الاكتفاء من الاطباء المتطوعين شكرا لك")
                End If
            ElseIf ComboBox3.SelectedIndex = 0 Or ComboBox3.SelectedIndex = 2 Then
                If TextBox3.Text.Contains("@") And TextBox4.Text <> "" And TextBox4.Text.Length >= 8 And TextBox2.Text.StartsWith("05") And TextBox2.Text.Length = 10 Then

                    cmd = New SqlCommand
                    cmd.Connection = con
                    cmd.CommandText = " insert into [user] values ('" & TextBox1.Text & "' ,'" & TextBox2.Text & "' ,'" & TextBox3.Text & "' ,'" & TextBox4.Text & "' ,'" & ComboBox1.Text & "' ,'" & ComboBox2.Text & "' ,'" & ComboBox3.Text & "' ) "

                    con.Open()
                    cmd.ExecuteNonQuery()
                    MsgBox("تم تسجيل بياناتك بنجاح", Title:="إشعار")
                    If ComboBox3.SelectedIndex = 1 Then
                        Form3.Show()
                    End If
                Else
                    MessageBox.Show("يجب التاكد من صحه البريد الالكتروني او كلمة المرور او رقم الجوال")
                    ErrorProvider1.SetError(TextBox4, "يجب ان تحتوي كلمة المرور على 8 خانات من الارقام")
                    ErrorProvider1.SetError(TextBox3, "يجب ان يحتوي البريد الالكتروني على (@)")
                    ErrorProvider1.SetError(TextBox2, "يجب التحقق من صحة رقم الجوال")
                End If
            Else
                MsgBox("ادخل نوع الدخول", MsgBoxStyle.Exclamation, Title:="تنبية")
            End If
        Catch ex As Exception
            MsgBox("...خطأ في تسجيل البيانات ", MsgBoxStyle.Exclamation, Title:="تنبية")
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Close()
        Form1.Show()
        'Me.Hide()
    End Sub
End Class