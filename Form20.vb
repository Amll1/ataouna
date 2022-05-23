Imports System.Data.SqlClient
Public Class Form20
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim db1 As New DataClasses1DataContext
    Public dt6 As New DataTable
    Sub updategridview()
        If con.State <> ConnectionState.Open Then
            con.Open()

        End If
        cmd = New SqlCommand("select Address,TypeOfNeed,Region,PhonNoDo from Mosque m,Donation d where d.IdDon=m.IdDon ", con)
        dt6 = New DataTable()
        dt6.Load(cmd.ExecuteReader())
        DataGridView1.DataSource = dt6
        con.Close()

    End Sub
    Private Sub Form20_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\ammal\OneDrive\سطح المكتب\WindowsApplication18\Database1.mdf;Integrated Security=True;User Instance=True"
        Dim show = From d In db1.Donations
                   From m In d.Mosques
                   Select m.Address, m.TypeOfNeed, d.Region, d.PhonNoDo

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