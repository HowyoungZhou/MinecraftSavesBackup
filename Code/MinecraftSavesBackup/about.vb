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
Public Class about
    Private Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" (ByVal hwnd As Int32, ByVal lpOperation As String, ByVal lpFile As String, ByVal lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As Int32) As Long

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub about_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        version_lbl.Text = My.Application.Info.Version.ToString
        copyright_lbl.Text = My.Application.Info.Copyright
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        ShellExecute(Me.Handle.ToInt32, "Open", "https://github.com/HowyoungZhou/MinecraftSavesBackup", "", "", 1)
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        ShellExecute(Me.Handle.ToInt32, "Open", "http://www.gnu.org/licenses/gpl-2.0.html", "", "", 1)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        outstanding_contribution.Show()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        ShellExecute(Me.Handle.ToInt32, "Open", "https://github.com/HowyoungZhou/MinecraftSavesBackup/wiki/Contributing-to-Open-Source", "", "", 1)
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Try
            My.Computer.Network.DownloadFile("http://master.dl.sourceforge.net/project/minecraftsavesbackup/Release/version.ini", AppDomain.CurrentDomain.BaseDirectory & "version.ini", "", "", False, 100000, True, FileIO.UICancelOption.DoNothing)
        Catch ex As Exception
            MsgBox("检测更新失败，请检查您的网络连接！", MsgBoxStyle.Critical, "错误")
        End Try
        Try
            If My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "version.ini") > My.Application.Info.Version.ToString Then
                online_update.newest_version_lbl.Text = "最新版本：" & My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "version.ini")
                online_update.Show()
            Else
                MsgBox("您的版本是最新版！", MsgBoxStyle.Information, "提示")
            End If
        Catch ex As Exception
            MsgBox("无法检测更新,请重试。", MsgBoxStyle.Critical, "错误")
        End Try
    End Sub
End Class