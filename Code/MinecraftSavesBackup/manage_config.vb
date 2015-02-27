'------------------------------------------------------------
'Copyright © 2015 Howyoung.
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
Imports System.IO.Compression

Public Class manage_config

    Private Sub io_config_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "BackupFolder.hsxml") = False Then
            MsgBox("配置文件(BackupFolder.hsxml)丢失，请重新配置！", MsgBoxStyle.Exclamation, "提示")
            input_saves.Show()
            Me.Close()
        ElseIf My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini") = False Then
            MsgBox("配置文件(BackupPath.ini)丢失，请重新配置！", MsgBoxStyle.Exclamation, "提示")
            input_saves.Show()
            Me.Close()
        ElseIf My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "MD5.hsxml") = False Then
            MsgBox("配置文件(MD5.hsxml)丢失，请重新配置！", MsgBoxStyle.Exclamation, "提示")
            input_saves.Show()
            Me.Close()
        ElseIf My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "savesPath.ini") = False Then
            MsgBox("配置文件(savesPath.ini)丢失，请重新配置！", MsgBoxStyle.Exclamation, "提示")
            input_saves.Show()
            Me.Close()
        End If
    End Sub

    Private Sub out_btn_Click(sender As Object, e As EventArgs) Handles out_btn.Click
        Try
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                If My.Computer.FileSystem.DirectoryExists("ConfigTemp") Then My.Computer.FileSystem.DeleteDirectory("ConfigTemp", FileIO.DeleteDirectoryOption.DeleteAllContents)
                My.Computer.FileSystem.CreateDirectory("ConfigTemp")
                My.Computer.FileSystem.CopyFile(AppDomain.CurrentDomain.BaseDirectory & "BackupFolder.hsxml", AppDomain.CurrentDomain.BaseDirectory & "ConfigTemp\BackupFolder.hsxml")
                My.Computer.FileSystem.CopyFile(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini", AppDomain.CurrentDomain.BaseDirectory & "ConfigTemp\BackupPath.ini")
                My.Computer.FileSystem.CopyFile(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", AppDomain.CurrentDomain.BaseDirectory & "ConfigTemp\Config.hsxml")
                My.Computer.FileSystem.CopyFile(AppDomain.CurrentDomain.BaseDirectory & "MD5.hsxml", AppDomain.CurrentDomain.BaseDirectory & "ConfigTemp\MD5.hsxml")
                My.Computer.FileSystem.CopyFile(AppDomain.CurrentDomain.BaseDirectory & "savesPath.ini", AppDomain.CurrentDomain.BaseDirectory & "ConfigTemp\savesPath.ini")
                Dim startPath As String = "ConfigTemp"
                Dim zipPath As String = SaveFileDialog1.FileName
                ZipFile.CreateFromDirectory(startPath, zipPath)
                If My.Computer.FileSystem.DirectoryExists("ConfigTemp") Then My.Computer.FileSystem.DeleteDirectory("ConfigTemp", FileIO.DeleteDirectoryOption.DeleteAllContents)
                MsgBox("导出设置成功。", MsgBoxStyle.Information, "导出成功")
            End If
        Catch ex As Exception
            MsgBox("无法导出设置：" & ex.Message, MsgBoxStyle.Critical, "错误")
        End Try
    End Sub

    Private Sub in_btn_Click(sender As Object, e As EventArgs) Handles in_btn.Click
        Try
            If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim zipPath As String = OpenFileDialog1.FileName
                Dim extractPath As String = AppDomain.CurrentDomain.BaseDirectory
                If My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "BackupFolder.hsxml") Then My.Computer.FileSystem.DeleteFile(AppDomain.CurrentDomain.BaseDirectory & "BackupFolder.hsxml")
                If My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini") Then My.Computer.FileSystem.DeleteFile(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini")
                If My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml") Then My.Computer.FileSystem.DeleteFile(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
                If My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "MD5.hsxml") Then My.Computer.FileSystem.DeleteFile(AppDomain.CurrentDomain.BaseDirectory & "MD5.hsxml")
                If My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "savesPath.ini") Then My.Computer.FileSystem.DeleteFile(AppDomain.CurrentDomain.BaseDirectory & "savesPath.ini")
                ZipFile.ExtractToDirectory(zipPath, extractPath)
                MsgBox("导入设置成功，设置将在下次启动软件后生效。", MsgBoxStyle.Information, "导出成功")
            End If
        Catch ex As Exception
            MsgBox("无法导入设置：" & ex.Message, MsgBoxStyle.Critical, "错误")
        End Try
    End Sub

    Private Sub clean_settings_btn_Click(sender As Object, e As EventArgs) Handles clean_settings_btn.Click
        If MsgBox("您确定要清除所有设置吗？", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "确认") = MsgBoxResult.Ok Then
            Try
                If My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "BackupFolder.hsxml") Then My.Computer.FileSystem.DeleteFile(AppDomain.CurrentDomain.BaseDirectory & "BackupFolder.hsxml")
                If My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini") Then My.Computer.FileSystem.DeleteFile(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini")
                If My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml") Then My.Computer.FileSystem.DeleteFile(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
                If My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "MD5.hsxml") Then My.Computer.FileSystem.DeleteFile(AppDomain.CurrentDomain.BaseDirectory & "MD5.hsxml")
                If My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "savesPath.ini") Then My.Computer.FileSystem.DeleteFile(AppDomain.CurrentDomain.BaseDirectory & "savesPath.ini")
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", Application.ProductName, "")
                MsgBox("已清除所有设置，请重新启动软件。", MsgBoxStyle.Information, "清除成功")
                Me.Close()
                End
            Catch ex As Exception
                MsgBox("无法清除设置：" & ex.Message, MsgBoxStyle.Critical, "错误")
            End Try
        End If
    End Sub
End Class