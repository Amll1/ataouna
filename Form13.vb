Imports System.Data.SqlClient
Public Class Form13
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim db1 As New DataClasses1DataContext
    Sub updategridview()
        If con.State <> ConnectionState.Open Then
            con.Open()

        End If
        cmd = New SqlCommand("select IdBlood,BloodType,HealthStatus,Region,PhonNoDo from Blood b ,Donation d where d.IdDon=b.IdDon and d.IdDon=" & TextBox1.Text, con)
        dt = New DataTable()
        dt.Load(cmd.ExecuteReader())
        DataGridView1.DataSource = dt
        con.Close()
    End Sub
    Sub updategridview1()
        If con.State <> ConnectionState.Open Then
            con.Open()

        End If
        cmd = New SqlCommand("select IdO,NumeOfProduct,Description,Found,Region ,PhonNoDo from OtherDonation o ,Donation d where d.IdDon=o.IdDon and d.IdDon=" & TextBox1.Text, con)
        dt = New DataTable()
        dt.Load(cmd.ExecuteReader())
        DataGridView2.DataSource = dt
        con.Close()

    End Sub
    Sub updategridview2()
        If con.State <> ConnectionState.Open Then
            con.Open()

        End If
        cmd = New SqlCommand("select IdM,Address,TypeOfNeed,Region,PhonNoDo from Mosque m,Donation d where d.IdDon=m.IdDon and d.IdDon=" & TextBox1.Text, con)
        dt = New DataTable()
        dt.Load(cmd.ExecuteReader())
        DataGridView3.DataSource = dt
        con.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form14.Show()
    End Sub

    Private Sub Form13_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Hide()
        con.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\ammal\OneDrive\سطح المكتب\WindowsApplication18\Database1.mdf;Integrated Security=True;User Instance=True"

        Try

            Dim reader As SqlDataReader
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "Select IdDon From [Donation] Where IdUser = " & Form12.TextBox1.Text & ""

            con.Open()
            reader = cmd.ExecuteReader

            If (reader.Read()) Then
                TextBox1.Text = reader("IdDon")

            End If
            reader.Close()
        Catch ex As Exception
            'MessageBox.Show("...خطأ أثناء ادراج البيانات في الجدول")
            MsgBox("...خطأ أثناء ادراج البيانات في الجدول ", MsgBoxStyle.Exclamation, Title:="تنبية")
        Finally
            con.Close()
        End Try

        'updategridview()
        'updategridview1()
        'Dim show = From d In db1.Donations
        '           From b In d.Bloods
        '           Where d.IdDon = TextBox1.Text
        '           Select b.IdBlood, b.BloodType, b.HealthStatus, d.PhonNoDo
        'DataGridView1.DataSource = show


        'Dim show1 = From d In db1.Donations
        '           From o In d.OtherDonations
        '           Where d.IdDon = TextBox1.Text
        '           Select o.IdO, o.NumeOfProduct, o.Description, o.Found, d.PhonNoDo
        'DataGridView2.DataSource = show1


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form15.Show()
    End Sub

    
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim show = From d In db1.Donations
                 From b In d.Bloods
                 Where d.IdDon = TextBox1.Text
                 Select b.IdBlood, b.BloodType, b.HealthStatus, d.Region, d.PhonNoDo
        DataGridView1.DataSource = show
        updategridview()
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim show1 = From d In db1.Donations
           From o In d.OtherDonations
           Where d.IdDon = TextBox1.Text
           Select o.IdO, o.NumeOfProduct, o.Description, o.Found, d.Region, d.PhonNoDo
        DataGridView2.DataSource = show1
        updategridview1()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Form16.Show()

    End Sub

    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim show = From d In db1.Donations
                 From m In d.Mosques
                 Where d.IdDon = TextBox1.Text
                 Select m.IdM, m.Address, m.TypeOfNeed, d.Region, d.PhonNoDo

        DataGridView3.DataSource = show
        updategridview2()
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Close()
        Form6.Show()
        'Me.Hide()

    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub
End Class