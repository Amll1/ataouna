Imports System.Data.SqlClient
Public Class Form12
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand

    Private Sub Form12_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Hide()
        con.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\ammal\OneDrive\سطح المكتب\WindowsApplication18\Database1.mdf;Integrated Security=True;User Instance=True"
        Try

            Dim reader As SqlDataReader
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "Select * From [user] Where IdUser = " & Form6.TextBox1.Text & ""

            con.Open()
            reader = cmd.ExecuteReader

            If (reader.Read()) Then
                TextBox1.Text = reader("IdUser")

            End If
            reader.Close()
        Catch ex As Exception
            'MessageBox.Show("...خطأ أثناء ادراج البيانات في الجدول")
            MsgBox("...خطأ أثناء ادراج البيانات في الجدول ", MsgBoxStyle.Exclamation, Title:="تنبية")
        Finally
            con.Close()
        End Try

        Try

            Dim reader As SqlDataReader
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "Select * From [Donation] Where IdUser = " & Form6.TextBox1.Text & ""

            con.Open()
            reader = cmd.ExecuteReader

            If (reader.Read()) Then
                TextBox2.Text = reader("Region")
                TextBox3.Text = reader("PhonNoDo")
                Label5.Text = "لديك حساب مسبق"
                TextBox1.Enabled = False
                TextBox2.Enabled = False
                TextBox3.Enabled = False
                LinkLabel1.Enabled = True
                Button1.Enabled = False
            End If
            reader.Close()

        Catch ex As Exception
            'MessageBox.Show("...خطأ أثناء ادراج البيانات في الجدول")
            MsgBox("...خطأ أثناء ادراج البيانات في الجدول ", MsgBoxStyle.Exclamation, Title:="تنبية")
        Finally

            con.Close()
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If TextBox2.Text <> "" And TextBox3.Text <> "" Then
                cmd = New SqlCommand
                cmd.Connection = con
                cmd.CommandText = " insert into [Donation] values ('" & Form6.TextBox1.Text & "' ,'" & TextBox2.Text & "' ,'" & TextBox3.Text & "' ) "

                con.Open()
                cmd.ExecuteNonQuery()
                ' MessageBox.Show("تم التسجيل بنجاح")
                MsgBox("تم تسجيل بنجاح", Title:="إشعار")
            Else
                MsgBox("الرجاء ادخال البيانات", Title:="إشعار")
            End If


        Catch ex As Exception
            'MessageBox.Show("... خطأ في التسجيل")
            MsgBox("...خطأ في تسجيل البيانات ", MsgBoxStyle.Exclamation, Title:="تنبية")
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Form13.Show()

    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Close()
        Form6.Show()
        'Me.Hide()

    End Sub
End Class