Imports System.Data.SqlClient
Public Class Form23
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim db1 As New DataClasses1DataContext
    Dim m As String = "منصة"
    Private Sub Form23_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=c:\users\ammal\onedrive\المستندات\visual studio 2010\Projects\WindowsApplication18\WindowsApplication18\Database1.mdf;Integrated Security=True;User Instance=True"
        Dim show = From P In db1.PlatForms
                   Where P.Classification = m
                   Select P.IdPlat, P.PlatFormName, P.Classification, P.Region, P.Description, P.Links



        DataGridView2.DataSource = show
    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        TextBox1.Text = DataGridView2.CurrentRow.Cells(0).Value
        TextBox1.Enabled = False
        TextBox2.Text = DataGridView2.CurrentRow.Cells(1).Value
        TextBox2.Enabled = False
        TextBox3.Text = DataGridView2.CurrentRow.Cells(2).Value
        TextBox3.Enabled = False
        TextBox4.Text = DataGridView2.CurrentRow.Cells(3).Value
        TextBox4.Enabled = False
        TextBox5.Text = DataGridView2.CurrentRow.Cells(4).Value
        TextBox5.Enabled = False
        TextBox6.Text = DataGridView2.CurrentRow.Cells(5).Value
        TextBox6.Enabled = False

        LinkLabel1.Text = TextBox6.Text
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start(TextBox6.Text)
    End Sub
End Class