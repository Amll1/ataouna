Public Class Form25 'form22

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ComboBox1.SelectedIndex = 0 Then
            Form24.Show()
            'form21
        ElseIf ComboBox1.SelectedIndex = 1 Then
            Form26.Show()
            'form23
        Else
            MsgBox("لم يتم تحديد الجهه", MsgBoxStyle.Exclamation, Title:="تنبية")
        End If
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click

        Me.Hide()
    End Sub

    Private Sub Form25_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class