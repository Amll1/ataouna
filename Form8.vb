Imports System.Data.SqlClient

Public Class Form8
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim d As New DataClasses1DataContext
    Dim reader As SqlDataReader
    Dim id1 As Integer = 1
    Dim id2 As Integer = 3
    Dim id3 As Integer = 5
    Dim id4 As Integer = 7
    Dim var As String
    Public dt7 As New DataTable
    Sub updategridview()
        If con.State <> ConnectionState.Open Then
            con.Open()
        End If
        cmd = New SqlCommand("select Question,Answer from Con1 where IdD=" & Label1.Text, con)
        dt7 = New DataTable()
        dt7.Load(cmd.ExecuteReader())
        DataGridView1.DataSource = dt7
        con.Close()
    End Sub
    Private Sub Form8_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Hide()
        con.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\ammal\OneDrive\سطح المكتب\WindowsApplication18\Database1.mdf;Integrated Security=True;User Instance=True"
        Try


            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "Select IdD From [Doctor] Where IdUser = " & Form4.TextBox1.Text & ""

            con.Open()
            reader = cmd.ExecuteReader

            If (reader.Read()) Then
                Label1.Text = reader("IdD")

            End If
            reader.Close()
        Catch ex As Exception
            ' MessageBox.Show("...خطأ أثناء ادراج البيانات في الجدول")
            MsgBox("...خطأ أثناء ادراج البيانات في الجدول ", MsgBoxStyle.Exclamation, Title:="تنبية")
        Finally
            con.Close()
        End Try
        Try



            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "Select* From [Doctor] Where IdUser= " & Form4.TextBox1.Text & ""
            con.Open()
            reader = cmd.ExecuteReader


            If (reader.Read()) Then
                TextBox1.Text = reader("Major")

            End If
            reader.Close()

        Catch ex As Exception
            'MessageBox.Show("...خطأ أثناء ادراج البيانات في الجدول")
            MsgBox("...خطأ أثناء ادراج البيانات في الجدول ", MsgBoxStyle.Exclamation, Title:="تنبية")
        Finally
            con.Close()
        End Try
        dt.Clear()
        If Label1.Text = id1 Then



            cmd.CommandText = "Select Question,IdUser From [Con1] Where IdD = " & id1 & ""
            da.SelectCommand = cmd
            da.Fill(dt)
            Dim row As DataRow = dt.NewRow
            'row(0) = 0
            ' row(1) = "dd"
            dt.Rows.InsertAt(row, 50)
            ComboBox1.DataSource = dt
            ComboBox1.DisplayMember = "Question"
            ComboBox1.ValueMember = "IdUser"

        ElseIf Label1.Text = id2 Then
            cmd.CommandText = "Select Question,IdUser From [Con1] Where IdD = " & id2 & ""
            da.SelectCommand = cmd
            da.Fill(dt)
            Dim row As DataRow = dt.NewRow
            'row(0) = 0
            'row(1) = "dd"
            dt.Rows.InsertAt(row, 50)
            ComboBox1.DataSource = dt
            ComboBox1.DisplayMember = "Question"
            ComboBox1.ValueMember = "IdUser"
        ElseIf Label1.Text = id3 Then
            cmd.CommandText = "Select Question,IdUser From [Con1] Where IdD = " & id3 & ""
            da.SelectCommand = cmd
            da.Fill(dt)
            Dim row As DataRow = dt.NewRow
            'row(0) = 0
            'row(1) = "dd"
            dt.Rows.InsertAt(row, 50)
            ComboBox1.DataSource = dt
            ComboBox1.DisplayMember = "Question"
            ComboBox1.ValueMember = "IdUser"
        Else
            cmd.CommandText = "Select Question,IdUser From [Con1] Where IdD = " & id4 & ""
            da.SelectCommand = cmd
            da.Fill(dt)
            Dim row As DataRow = dt.NewRow
            'row(0) = 0
            'row(1) = "dd"
            dt.Rows.InsertAt(row, 50)
            ComboBox1.DataSource = dt
            ComboBox1.DisplayMember = "Question"
            ComboBox1.ValueMember = "IdUser"
        End If




    End Sub


    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Label1.Text = id1 And TextBox2.Text <> "" Then

            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "Update [Con1] SET Answer= '" & TextBox2.Text & "' WHERE IdD ='" & id1 & "'and Question = '" & ComboBox1.Text & "'"
            con.Open()
            cmd.ExecuteNonQuery()
            MsgBox("تمت الإضافة بنجاح", Title:="إشعار")

        ElseIf Label1.Text = id2 And TextBox2.Text <> "" Then
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "Update [Con1] SET Answer= '" & TextBox2.Text & "' WHERE IdD ='" & id2 & "'and Question = '" & ComboBox1.Text & "'"
            con.Open()
            cmd.ExecuteNonQuery()
            MsgBox("تمت الإضافة بنجاح", Title:="إشعار")

        ElseIf Label1.Text = id3 And TextBox2.Text <> "" Then
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "Update [Con1] SET Answer= '" & TextBox2.Text & "' WHERE IdD ='" & id3 & "'and Question = '" & ComboBox1.Text & "'"
            con.Open()
            cmd.ExecuteNonQuery()
            MsgBox("تمت الإضافة بنجاح", Title:="إشعار")

        ElseIf Label1.Text = id4 And TextBox2.Text <> "" Then
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "Update [Con1] SET Answer= '" & TextBox2.Text & "' WHERE IdD ='" & id4 & "'and Question = '" & ComboBox1.Text & "'"
            con.Open()
            cmd.ExecuteNonQuery()
            MsgBox("تمت الإضافة بنجاح", Title:="إشعار")
        Else
            MsgBox("من فضلك ادخل اجابة", Title:="إشعار")
        End If

        Dim show = From f In d.Con1s
                  Where f.IdD = Label1.Text
                  Select f.Question, f.Answer
        DataGridView1.DataSource = show
        updategridview()
        con.Close()

    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Close()
        Form4.Show()
        'Me.Hide()

    End Sub
End Class