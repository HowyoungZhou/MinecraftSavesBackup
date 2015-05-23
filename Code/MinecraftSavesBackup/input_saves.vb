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
Imports System.IO
Imports System.Security.Cryptography
Imports MinecraftSavesBackup.Compression

Public Class input_saves
    Dim HSXML As New HSXML
    Public exit_program As Boolean = True
    Public error_happened As Boolean = False

    Private Sub browse_btn_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles browse_btn.LinkClicked
        Try
            If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                path_txtbox.Text = FolderBrowserDialog1.SelectedPath
                If path_txtbox.Text.Contains("saves") Then
                    found_lstbox.Items.Clear()
                    Dim dirPath As String = path_txtbox.Text
                    Dim dirs As List(Of String) = New List(Of String)(Directory.EnumerateDirectories(dirPath))
                    For Each folder In dirs
                        found_lstbox.Items.Add(folder.Substring(folder.LastIndexOf("\") + 1))
                    Next
                    If found_lstbox.Items.Count = 0 Then found_lstbox.Items.Clear() : found_lstbox.Items.Add("未找到存档。")
                Else
                    found_lstbox.Items.Clear()
                    found_lstbox.Items.Add("您指定的不是存档文件夹，请重试。")
                End If
            End If
        Catch ex As Exception
            MsgBox("出现错误：" & ex.Message, MsgBoxStyle.Critical, "错误")
        End Try
    End Sub

    Private Sub cancel_btn_Click(sender As Object, e As EventArgs) Handles cancel_btn.Click
        On Error Resume Next
        If exit_program = True Then
            End
        Else
            Me.path_txtbox.Text = Nothing
            Me.found_lstbox.Items.Clear()
            Me.Hide()
        End If
    End Sub

    Private Sub ok_btn_Click(sender As Object, e As EventArgs) Handles ok_btn.Click
        If found_lstbox.CheckedItems.Count = 0 Then
            MsgBox("请选择您要备份的游戏存档。", MsgBoxStyle.Exclamation, "提示")
        ElseIf found_lstbox.Items.Contains("您指定的不是存档文件夹，请重试。") Then
            MsgBox("您指定的不是存档文件夹，请重试。", MsgBoxStyle.Exclamation, "提示")
        Else
            Try
                ok_btn.Enabled = False
                ok_btn.Text = "等待..."
                cancel_btn.Enabled = False
                browse_btn.Enabled = False
                '写savespath文件
                If Strings.Right(path_txtbox.Text, 1) = "\" Then
                    My.Computer.FileSystem.WriteAllText(AppDomain.CurrentDomain.BaseDirectory & "savesPath.ini", path_txtbox.Text, False)
                Else
                    My.Computer.FileSystem.WriteAllText(AppDomain.CurrentDomain.BaseDirectory & "savesPath.ini", path_txtbox.Text & "\", False)
                End If
                '写backupfolder文件
                If My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "BackupFolder.hsxml") Then My.Computer.FileSystem.DeleteFile(AppDomain.CurrentDomain.BaseDirectory & "BackupFolder.hsxml")
                Dim count As Integer = 1
                For i = 0 To found_lstbox.CheckedItems.Count - 1 Step 1
                    Dim text As String = path_txtbox.Text
                    If Strings.Right(text, 1) <> "\" Then
                        text = text & "\" & found_lstbox.CheckedItems.Item(i)
                    Else
                        text = text & found_lstbox.CheckedItems.Item(i)
                    End If
                    HSXML.Write(count, text, AppDomain.CurrentDomain.BaseDirectory & "BackupFolder.hsxml")
                    count = count + 1
                Next
                Me.ProgressBar1.Value = 0
                Me.ProgressBar1.Visible = True
            Catch ex As Exception
                MsgBox("无法写入配置文件：" & ex.Message, "错误")
                Me.ProgressBar1.Value = 100
                Me.ProgressBar1.Visible = False
                ok_btn.Text = "确定(&O)"
                ok_btn.Enabled = True
                cancel_btn.Enabled = True
                browse_btn.Enabled = True
            End Try
            Try
                BackgroundWorker1.RunWorkerAsync()
            Catch ex As Exception
                MsgBox("开始计算并写入MD5时出错：" & ex.Message, "错误")
                Me.ProgressBar1.Value = 100
                Me.ProgressBar1.Visible = False
                ok_btn.Text = "确定(&O)"
                ok_btn.Enabled = True
                cancel_btn.Enabled = True
                browse_btn.Enabled = True
            End Try
        End If
    End Sub

    Private Sub path_txtbox_TextChanged(sender As Object, e As EventArgs) Handles path_txtbox.TextChanged
        On Error Resume Next
        If path_txtbox.Text.Contains("saves") Then
            found_lstbox.Items.Clear()
            Dim dirPath As String = path_txtbox.Text
            Dim dirs As List(Of String) = New List(Of String)(Directory.EnumerateDirectories(dirPath))
            For Each folder In dirs
                found_lstbox.Items.Add(folder.Substring(folder.LastIndexOf("\") + 1))
            Next
            If found_lstbox.Items.Count = 0 Then found_lstbox.Items.Clear() : found_lstbox.Items.Add("未找到存档。")
        Else
            found_lstbox.Items.Clear()
            found_lstbox.Items.Add("您指定的不是存档文件夹，请重试。")
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        '计算MD5
        Try
            If My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "MD5.hsxml") Then My.Computer.FileSystem.DeleteFile(AppDomain.CurrentDomain.BaseDirectory & "MD5.hsxml")
            For i = 1 To HSXML.Count(AppDomain.CurrentDomain.BaseDirectory & "BackupFolder.hsxml")
                For Each foundFile As String In My.Computer.FileSystem.GetFiles(HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "BackupFolder.hsxml", CStr(i)), FileIO.SearchOption.SearchAllSubDirectories, "*.*")
                    Dim MD5Checkesult As String = ""
                    Dim a, c As Integer
                    Dim FS As FileStream = New FileStream(foundFile, FileMode.Open, FileAccess.Read)
                    Dim BR As BinaryReader = New BinaryReader(FS)
                    Dim md5serv As MD5 = MD5CryptoServiceProvider.Create()
                    Dim buffer As Byte() = md5serv.ComputeHash(FS)
                    For Each var As Byte In buffer
                        a = Convert.ToInt32(var)
                        c = a >> 4
                        MD5Checkesult += Hex(c).ToLower
                        c = ((a << 4) And &HFF) >> 4
                        MD5Checkesult += Hex(c).ToLower
                    Next
                    BR.Close()
                    MD5Checkesult = MD5Checkesult.ToUpper
                    HSXML.Write(foundFile, MD5Checkesult, AppDomain.CurrentDomain.BaseDirectory & "MD5.hsxml")
                Next
                BackgroundWorker1.ReportProgress(i / HSXML.Count(AppDomain.CurrentDomain.BaseDirectory & "BackupFolder.hsxml") * 100)
            Next
        Catch ex As Exception
            MsgBox("计算并写入MD5时出错：" & ex.Message, MsgBoxStyle.Critical, "错误")
            error_happened = True
            BackgroundWorker1.CancelAsync()
        End Try
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBar1.Value = Val(e.ProgressPercentage.ToString)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        On Error Resume Next
        If error_happened = False Then
            exit_program = False
            input_backup_path.Show()
            Me.path_txtbox.Text = Nothing
            Me.found_lstbox.Items.Clear()
            Me.Hide()
        End If
        error_happened = False
        Me.ProgressBar1.Value = 100
        Me.ProgressBar1.Visible = False
        ok_btn.Text = "确定(&O)"
        ok_btn.Enabled = True
        cancel_btn.Enabled = True
        browse_btn.Enabled = True
        Exit Sub
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try
            If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim zipPath As String = OpenFileDialog1.FileName
                Dim extractPath As String = AppDomain.CurrentDomain.BaseDirectory
                If My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "BackupFolder.hsxml") Then My.Computer.FileSystem.DeleteFile(AppDomain.CurrentDomain.BaseDirectory & "BackupFolder.hsxml")
                If My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini") Then My.Computer.FileSystem.DeleteFile(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini")
                If My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml") Then My.Computer.FileSystem.DeleteFile(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
                If My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "MD5.hsxml") Then My.Computer.FileSystem.DeleteFile(AppDomain.CurrentDomain.BaseDirectory & "MD5.hsxml")
                If My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "savesPath.ini") Then My.Computer.FileSystem.DeleteFile(AppDomain.CurrentDomain.BaseDirectory & "savesPath.ini")
                DecompressZip(zipPath, extractPath)
                MsgBox("导入设置成功，设置将在下次启动软件后生效，请重启软件。", MsgBoxStyle.Information, "导出成功")
                End
            End If
        Catch ex As Exception
            MsgBox("无法导入设置：" & ex.Message, MsgBoxStyle.Critical, "错误")
        End Try
    End Sub

    Private Sub input_saves_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        If exit_program = True Then End
    End Sub
End Class