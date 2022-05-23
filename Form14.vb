Imports System.Data.SqlClient
Public Class Form14
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim db1 As New DataClasses1DataContext
    Public dt1 As New DataTable
    Sub updategridview()
        If con.State <> ConnectionState.Open Then
            con.Open()

        End If
        cmd = New SqlCommand("select IdO,NumeOfProduct,Description,Found,Region,PhonNoDo from OtherDonation o ,Donation d where d.IdDon = o.IdDon and d.IdDon =" & Form13.TextBox1.Text, con)
        dt1 = New DataTable()
        dt1.Load(cmd.ExecuteReader())
        DataGridView1.DataSource = dt1
        con.Close()

    End Sub
    Sub cleartextboxes()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""

    End Sub
   
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
       Try
            If TextBox2.Text <> "" And TextBox3.Text <> "" And TextBox4.Text <> "" Then
                cmd = New SqlCommand
                cmd.Connection = con
                cmd.CommandText = " insert into [OtherDonation] values ('" & Form13.TextBox1.Text & "' ,'" & TextBox2.Text & "' ,'" & TextBox3.Text & "' ,'" & TextBox4.Text & "' ) "

                con.Open()
                cmd.ExecuteNonQuery()
                'MessageBox.Show("تم الإدخال بنجاح")
                MsgBox("تم الادخال بنجاح . شكرا لكم", Title:="إشعار")
                updategridview()
                cleartextboxes()
            Else
                MsgBox("لم يتم ادخال صنف  ", MsgBoxStyle.Exclamation, Title:="تنبية")
            End If
        Catch ex As Exception
            'MessageBox.Show("...خطأ في الإدخال")
            MsgBox("...خطأ في تسجيل البيانات ", MsgBoxStyle.Exclamation, Title:="تنبية")
        Finally
            con.Close()
        End Try



    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value
        TextBox1.Enabled = False
        TextBox2.Text = DataGridView1.CurrentRow.Cells(1).Value
        TextBox2.Enabled = False
        TextBox3.Text = DataGridView1.CurrentRow.Cells(2).Value
        TextBox3.Enabled = False
        TextBox4.Text = DataGridView1.CurrentRow.Cells(3).Value


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If TextBox2.Text <> "" And TextBox3.Text <> "" And TextBox4.Text <> "" Then
                cmd = New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "Update [OtherDonation] SET Found = '" & TextBox4.Text & "' where IdO ='" & TextBox1.Text & "'"
                con.Open()
                cmd.ExecuteNonQuery()
                'MessageBox.Show("تم تحديث البيانات بنجاح")
                MsgBox("تم تحديث البيانات بنجاح", Title:="إشعار")
                updategridview()
                cleartextboxes()
                TextBox2.Enabled = True
                TextBox3.Enabled = True
            Else
                MsgBox("لم يتم تحديد صنف ", MsgBoxStyle.Exclamation, Title:="تنبية")
            End If
        Catch ex As Exception
            ' MessageBox.Show("... خطأ في تحديث البيانات")
            MsgBox("...خطأ في تحديث البيانات ", MsgBoxStyle.Exclamation, Title:="تنبية")
        Finally
            con.Close()

        End Try
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Close()
        Form13.Show()
        'Me.Hide()

    End Sub

    Private Sub Form14_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Hide()
        con.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\ammal\OneDrive\سطح المكتب\WindowsApplication18\Database1.mdf;Integrated Security=True;User Instance=True"

        Dim show = From d In db1.Donations
                      From o In d.OtherDonations
                      Where d.IdDon = Form13.TextBox1.Text
                      Select o.IdO, o.NumeOfProduct, o.Description, o.Found, d.Region, d.PhonNoDo

        DataGridView1.DataSource = show
        updategridview()
    End Sub
End Class