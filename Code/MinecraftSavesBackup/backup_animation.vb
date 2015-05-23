'------------------------------------------------------------
'Copyright © 2015 HowyoungZhou
'------------------------------------------------------------
'You may copy and distribute verbatim copies of the Program's
'source code as you receive it, in any medium, provided that
'you conspicuously and appropriately publish on each copy an
'appropriate copyright notice and disclaimer of warranty.
'------------------------------------------------------------
'您可以对所收受的本程序源代码，无论以何种媒介，复制与发布其完
'整的复制物，然而您必须符合以下要件：以显著及适当的方式在每一
'份复制物上发布适当的著作权标示及无担保声明。
'------------------------------------------------------------
Public Class backup_animation
    Dim piccount As Integer = 2
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If piccount = 1 Then
            PictureBox1.Image = My.Resources.ch1
        ElseIf piccount = 2 Then
            PictureBox1.Image = My.Resources.ch2
        End If
        piccount = piccount + 1
        If piccount > 2 Then piccount = 1
    End Sub

    Private Sub backup_animation_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Top = 64
        Me.Left = My.Computer.Screen.WorkingArea.Size.Width - 64 - 50
    End Sub
End Class