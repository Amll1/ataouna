Imports System.Data.SqlClient
Public Class Form9
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim db As New DataClasses1DataContext
    Dim id1 As Integer = 1
    Dim id2 As Integer = 5
    Dim id3 As Integer = 7
    Dim id4 As Integer = 3
  
    Private Sub Form9_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\ammal\OneDrive\سطح المكتب\WindowsApplication18\Database1.mdf;Integrated Security=True;User Instance=True"
       
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            cmd = New SqlCommand
            cmd.Connection = con
            If ComboBox1.SelectedIndex = 0 And TextBox2.Text <> "" Then
                cmd.CommandText = " insert into [Con1] values ('" & Form6.TextBox1.Text & "' ,'" & id1 & "' ,'" & TextBox2.Text & "' ,'" & DBNull.Value & " ') "
                con.Open()
                cmd.ExecuteNonQuery()
                ' MessageBox.Show("تمت الإضافة بنجاح")
                MsgBox("تمت الإضافة بنجاح", Title:="إشعار")

            ElseIf ComboBox1.SelectedIndex = 1 And TextBox2.Text <> "" Then
                cmd.CommandText = " insert into [Con1] values ('" & Form6.TextBox1.Text & "' ,'" & id2 & "' ,'" & TextBox2.Text & "' ,'" & DBNull.Value & " ') "
                con.Open()
                cmd.ExecuteNonQuery()
                'MessageBox.Show("تمت الإضافة بنجاح")
                MsgBox("تمت الإضافة بنجاح", Title:="إشعار")

            ElseIf ComboBox1.SelectedIndex = 2 And TextBox2.Text <> "" Then
                cmd.CommandText = " insert into [Con1] values ('" & Form6.TextBox1.Text & "' ,'" & id3 & "' ,'" & TextBox2.Text & "' ,'" & DBNull.Value & " ') "
                con.Open()
                cmd.ExecuteNonQuery()
                'MessageBox.Show("تمت الإضافة بنجاح")
                MsgBox("تمت الإضافة بنجاح", Title:="إشعار")

            ElseIf ComboBox1.SelectedIndex = 3 And TextBox2.Text <> "" Then
                cmd.CommandText = " insert into [Con1] values ('" & Form6.TextBox1.Text & "' ,'" & id4 & "' ,'" & TextBox2.Text & "' ,'" & DBNull.Value & " ') "
                con.Open()
                cmd.ExecuteNonQuery()
                'MessageBox.Show("تمت الإضافة بنجاح")
                MsgBox("تمت الإضافة بنجاح", Title:="إشعار")
            Else
                MsgBox("الرجاء اضافة سؤال", Title:="إشعار")
            End If

        Catch ex As Exception
            MsgBox("عذرا لم تتم الإضافة بنجاح ", Title:="إشعار")
        Finally
            con.Close()
        End Try
    End Sub

    
  


    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Form10.Show()
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Close()
        Form6.Show()
        'Me.Hide()

    End Sub
End Class