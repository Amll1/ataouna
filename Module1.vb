Imports System.Data.SqlClient
Module Module1
    Public conn As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\ammal\OneDrive\سطح المكتب\WindowsApplication18\Database1.mdf;Integrated Security=True;User Instance=True")
    Public da As New SqlDataAdapter("select * from user", conn)
    Public dt As New DataTable
End Module
