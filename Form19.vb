Imports System.Data.SqlClient
Public Class Form19
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim db1 As New DataClasses1DataContext
    Dim g As New Integer

    Public dt5 As New DataTable
    Sub updategridview()
        If con.State <> ConnectionState.Open Then
            con.Open()

        End If
        cmd = New SqlCommand("select BloodType,HealthStatus ,Region,PhonNoDo from Blood b ,Donation d where d.IdDon=b.IdDon ", con)
        dt5 = New DataTable()
        dt5.Load(cmd.ExecuteReader())
        DataGridView1.DataSource = dt5
        con.Close()
    End Sub
    Private Sub Form19_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\ammal\OneDrive\سطح المكتب\WindowsApplication18\Database1.mdf;Integrated Security=True;User Instance=True"
        Dim show = From d In db1.Donations
                   From b In d.Bloods
                   Select b.BloodType, b.HealthStatus, d.Region, d.PhonNoDo

        DataGridView1.DataSource = show
        updategridview()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Close()
        Form17.Show()
        'Me.Hide()
    End Sub
End Class