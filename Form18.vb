Imports System.Data.SqlClient
Public Class Form18
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim db1 As New DataClasses1DataContext
    Public dt4 As New DataTable
    Sub updategridview()
        If con.State <> ConnectionState.Open Then
            con.Open()

        End If
        cmd = New SqlCommand("select NumeOfProduct,Description,Found,Region,PhonNoDo from OtherDonation o ,Donation d where d.IdDon = o.IdDon ", con)
        dt4 = New DataTable()
        dt4.Load(cmd.ExecuteReader())
        DataGridView1.DataSource = dt4
        con.Close()
    End Sub
    Private Sub Form18_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\ammal\OneDrive\سطح المكتب\WindowsApplication18\Database1.mdf;Integrated Security=True;User Instance=True"
        Dim show = From d In db1.Donations
                   From o In d.OtherDonations
                   Select o.NumeOfProduct, o.Description, o.Found, d.Region, d.PhonNoDo

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