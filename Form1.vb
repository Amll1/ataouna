Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form2.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form5.Show()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        MsgBox(" من نحنُ؟                                                      " & vbCrLf & vbCrLf & "برنامج يهدف إلى خدمة المتضررين من جائحة كورونا " & vbCrLf & "وبعض الأسر الغير قادرةعلى الذهاب لتلقي العلاج وشراء الإحتياجات " & vbCrLf & " الأساسية وبرنامجنا هذا يهدف إلى مساعدةوتحسين حال هذه الأسر من خلال تقديم" & vbCrLf & "خدمات لتوفير الإحتياجات الأساسية من ملابس وأكل وأجهزه وكتب وغيرها" & vbCrLf & "كما أنه يوجد في برنامجنا بعض المنصات والتطبيقات التي يمكنك التطوع بها" & vbCrLf & vbCrLf & " ورسالتنا هي التطوع في خدمة وطننا عطاء وبناء لمجتمعنا                    ", MsgBoxStyle.MsgBoxRight, Title:="عطاؤنا")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Form27.Show()
    End Sub
End Class
