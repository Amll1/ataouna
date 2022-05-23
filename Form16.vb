Imports System.Data.SqlClient
Public Class Form16
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim db1 As New DataClasses1DataContext
    Public dt3 As New DataTable
    Sub updategridview()
        If con.State <> ConnectionState.Open Then
            con.Open()

        End If
        cmd = New SqlCommand("select IdM,Address,TypeOfNeed,Region,PhonNoDo from Mosque m,Donation d where d.IdDon=m.IdDon and d.IdDon =" & Form13.TextBox1.Text, con)
        dt3 = New DataTable()
        dt3.Load(cmd.ExecuteReader())
        DataGridView1.DataSource = dt3
        con.Close()

    End Sub
    Sub cleartextboxes()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""


    End Sub
    Private Sub Form16_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Hide()
        con.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\ammal\OneDrive\سطح المكتب\WindowsApplication18\Database1.mdf;Integrated Security=True;User Instance=True"
        Dim show = From d In db1.Donations
                  From m In d.Mosques
                  Where d.IdDon = Form13.TextBox1.Text
                  Select m.IdM, m.Address, m.TypeOfNeed, d.Region, d.PhonNoDo

        DataGridView1.DataSource = show
        updategridview()


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If TextBox2.Text <> "" And TextBox3.Text <> "" Then
                cmd = New SqlCommand
                cmd.Connection = con
                cmd.CommandText = " insert into [Mosque] values ('" & Form13.TextBox1.Text & "' ,'" & TextBox2.Text & "' ,'" & TextBox3.Text & "' ) "

                con.Open()
                cmd.ExecuteNonQuery()
                'MessageBox.Show("تم الإدخال بنجاح")
                MsgBox("تم الادخال بنجاح . شكرا لكم", Title:="إشعار")
                updategridview()
                cleartextboxes()
            Else
                MsgBox("لم يتم ادخال البيانات  ", MsgBoxStyle.Exclamation, Title:="تنبية")
            End If
        Catch ex As Exception
            'MessageBox.Show("...خطأ في الإدخال")
            MsgBox("...خطأ في الإدخال ", MsgBoxStyle.Exclamation, Title:="تنبية")
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value
        ' TextBox1.Enabled = False
        TextBox2.Text = DataGridView1.CurrentRow.Cells(1).Value
        TextBox2.Enabled = False
        TextBox3.Text = DataGridView1.CurrentRow.Cells(2).Value
        TextBox3.Enabled = False

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If TextBox2.Text <> "" And TextBox3.Text <> "" Then
                cmd = New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "DELETE FROM [Mosque] WHERE IdM = " & TextBox1.Text

                con.Open()
                cmd.ExecuteNonQuery()
                'MessageBox.Show("تم الحذف بنجاح")
                MsgBox("تم الحذف بنجاح", Title:="إشعار")
                updategridview()
                cleartextboxes()
                TextBox2.Enabled = True
                TextBox3.Enabled = True
            Else
                MsgBox("لم يتم التحديد  ", MsgBoxStyle.Exclamation, Title:="تنبية")
            End If
        Catch ex As Exception
            'MessageBox.Show("...خطأ في حذف البيانات")
            MsgBox("...خطأ في حذف البيانات ", MsgBoxStyle.Exclamation, Title:="تنبية")
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Close()
        Form13.Show()
        'Me.Hide()

    End Sub
End Class