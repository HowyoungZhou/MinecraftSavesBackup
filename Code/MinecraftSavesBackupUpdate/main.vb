Public Class main
    Dim program_path As String
    Private Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" (ByVal hwnd As Int32, ByVal lpOperation As String, ByVal lpFile As String, ByVal lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As Int32) As Long

    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            program_path = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\MinecraftSavesBackup", "ProgramPath", Nothing)
            If program_path = Nothing Then
                MsgBox("无法找到原程序，可能原因为：" & vbCrLf & "1.原程序不存在或原程序出错；" & vbCrLf & "2.原程序版本低于1.1.0.0。" & vbCrLf & "请手动卸载旧程序并下载安装最新版本。", MsgBoxStyle.Critical, "Minecraft存档备份更新程序")
                ShellExecute(Me.Handle.ToInt32, "Open", "http://sourceforge.net/projects/minecraftsavesbackup/files/Release/minecraftsavesbackup_setup.exe/download", "", "", 1)
                End
            Else
                program_path_lbl.Text = program_path
            End If
            If My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "MinecraftSavesBackup.exe") = False Then MsgBox("无法找到新程序，可能原因为：" & vbCrLf & "1.您下载的更新包不完整；" & vbCrLf & "2.解压时出现错误。" & vbCrLf & "请重新下载更新包。", MsgBoxStyle.Critical, "Minecraft存档备份更新程序") : End
            Dim oldfileinfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(program_path)
            Dim oldverison As String = oldfileinfo.ProductVersion
            Dim newfileinfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(AppDomain.CurrentDomain.BaseDirectory & "MinecraftSavesBackup.exe")
            Dim newverison As String = newfileinfo.ProductVersion
            If newverison > oldverison Then
                version_lbl.Text = oldverison & " -> " & newverison
            Else
                If MsgBox("您当前的版本(" & oldverison & ")等于或高于要安装的版本(" & newverison & ")，继续吗？", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Minecraft存档备份更新程序") = MsgBoxResult.Ok Then
                    version_lbl.Text = oldverison & " -> " & newverison
                Else
                    End
                End If
            End If
        Catch ex As Exception
            MsgBox("初始化错误，请重试。", MsgBoxStyle.Critical, "Minecraft存档备份更新程序")
        End Try
    End Sub

    Private Sub cancel_btn_Click(sender As Object, e As EventArgs) Handles cancel_btn.Click
        End
    End Sub

    Private Sub ok_btn_Click(sender As Object, e As EventArgs) Handles ok_btn.Click
        Try
            My.Computer.FileSystem.CopyFile(AppDomain.CurrentDomain.BaseDirectory & "MinecraftSavesBackup.exe", program_path, True)
        Catch ex As Exception
            MsgBox("复制新文件时出错：" & ex.Message, MsgBoxStyle.Critical, "Minecraft存档备份更新程序")
        End Try
        Try
            Shell(program_path, AppWinStyle.NormalFocus)
            End
        Catch ex As Exception
            MsgBox("打开程序时出错：" & ex.Message, MsgBoxStyle.Critical, "Minecraft存档备份更新程序")
        End Try
    End Sub
End Class
