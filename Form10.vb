Imports System.Data.SqlClient
Public Class Form10
    Dim db As New DataClasses1DataContext
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Public dt9 As New DataTable
    Sub updategridview()
        If con.State <> ConnectionState.Open Then
            con.Open()

        End If
        cmd = New SqlCommand("select Major, Question,Answer from Doctor d ,Con1 c where d.IdD = c.IdD ", con)
        dt9 = New DataTable()
        dt9.Load(cmd.ExecuteReader())
        DataGridView1.DataSource = dt9
        con.Close()

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    If TextBox1.Text <> "" Then
            Dim show = From d In db.Doctors
                  From c In d.Con1s
                  Where c.Question <> " " And c.Answer <> " " And d.Major = TextBox1.Text
                  Select d.Major, c.Question, c.Answer

            DataGridView1.DataSource = show
            updategridview()
        Else
            ' MessageBox.Show("لم يتم إدخال إسم التخصص")
            MsgBox("...لم يتم إدخال إسم التخصص ", MsgBoxStyle.Exclamation, Title:="تنبية")
        End If

    End Sub

    Private Sub Form10_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\ammal\OneDrive\سطح المكتب\WindowsApplication18\Database1.mdf;Integrated Security=True;User Instance=True"
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Close()
        'Form9.Show()
        'Me.Hide()

    End Sub
End Class