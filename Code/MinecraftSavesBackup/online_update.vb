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
Public Class online_update

    Private Sub update_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        now_version_lbl.Text = "当前版本：" & My.Application.Info.Version.ToString
    End Sub

    Private Sub update_btn_Click(sender As Object, e As EventArgs) Handles update_btn.Click
        Try
            My.Computer.Network.DownloadFile("http://master.dl.sourceforge.net/project/minecraftsavesbackup/Release/minecraftsavesbackup_update.exe", AppDomain.CurrentDomain.BaseDirectory & "minecraftsavesbackup_update.exe", "", "", True, 100000, True, FileIO.UICancelOption.DoNothing)
        Catch ex As Exception
            MsgBox("下载失败，请检查您的网络连接！", MsgBoxStyle.Critical, "错误")
        End Try
        Try
            Shell(AppDomain.CurrentDomain.BaseDirectory & "minecraftsavesbackup_update.exe", AppWinStyle.NormalFocus)
            End
        Catch ex As Exception
            MsgBox("无法启动升级程序,请重试。", MsgBoxStyle.Critical, "错误")
        End Try
    End Sub

    Private Sub cancel_btn_Click(sender As Object, e As EventArgs) Handles cancel_btn.Click
        Me.Close()
    End Sub
End Class