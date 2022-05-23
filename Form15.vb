﻿Imports System.Data.SqlClient
Public Class Form15
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim db1 As New DataClasses1DataContext
    Public dt2 As New DataTable
    Sub updategridview()
        If con.State <> ConnectionState.Open Then
            con.Open()

        End If
        cmd = New SqlCommand("select  IdBlood,BloodType,HealthStatus ,Region,PhonNoDo from Blood b ,Donation d where d.IdDon=b.IdDon and d.IdDon =" & Form13.TextBox1.Text, con)
        dt2 = New DataTable()
        dt2.Load(cmd.ExecuteReader())
        DataGridView1.DataSource = dt2
        con.Close()

    End Sub
    Sub cleartextboxes()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""


    End Sub
    Private Sub Form15_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Hide()
        con.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\ammal\OneDrive\سطح المكتب\WindowsApplication18\Database1.mdf;Integrated Security=True;User Instance=True"

        Dim show = From d In db1.Donations
                    From b In d.Bloods
                    Where d.IdDon = Form13.TextBox1.Text
                    Select b.IdBlood, b.BloodType, b.HealthStatus, d.Region, d.PhonNoDo
        DataGridView1.DataSource = show
        updategridview()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If TextBox2.Text <> "" And TextBox3.Text <> "" Then
                cmd = New SqlCommand
                cmd.Connection = con
                cmd.CommandText = " insert into [Blood] values ('" & Form13.TextBox1.Text & "' ,'" & TextBox2.Text & "' ,'" & TextBox3.Text & "' ) "

                con.Open()
                cmd.ExecuteNonQuery()
                'MessageBox.Show("تم الإدخال بنجاح")
                MsgBox("تم الادخال بنجاح . شكرا لكم", Title:="إشعار")
                updategridview()
                cleartextboxes()
            Else
                MsgBox("لم يتم ادخال البيانات ", MsgBoxStyle.Exclamation, Title:="تنبية")
            End If
        Catch ex As Exception
            'MessageBox.Show("...خطأ في الإدخال")
            MsgBox("...خطأ في الإدخال ", MsgBoxStyle.Exclamation, Title:="تنبية")
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If TextBox2.Text <> "" And TextBox3.Text <> "" Then
                cmd = New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "DELETE FROM [Blood] WHERE IdBlood = " & TextBox1.Text

                con.Open()
                cmd.ExecuteNonQuery()
                'MessageBox.Show("تم الحذف بنجاح")
                MsgBox("تم الحذف بنجاح", Title:="إشعار")
                updategridview()
                cleartextboxes()
                TextBox2.Enabled = True
                TextBox3.Enabled = True
            Else
                MsgBox("لم يتم التحديد ", MsgBoxStyle.Exclamation, Title:="تنبية")
            End If
        Catch ex As Exception
            'MessageBox.Show("...خطأ في حذف البيانات ")
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

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value
        'TextBox1.Enabled = False
        TextBox2.Text = DataGridView1.CurrentRow.Cells(1).Value
        TextBox2.Enabled = False
        TextBox3.Text = DataGridView1.CurrentRow.Cells(2).Value
        TextBox3.Enabled = False
    End Sub
End Class