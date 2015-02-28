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
Imports MinecraftSavesBackup.Compression
Imports System.IO
Imports System.Security.Cryptography

Public Class main
    Dim HSXML As New HSXML
    Public found_difference As Boolean = False
    Dim iconcount As Integer = 1
    Dim newupdate As Boolean = False
    Dim input_saves As New input_saves

    Private Sub write_config()
        Try
            If My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml") Then My.Computer.FileSystem.DeleteFile(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
            '------
            If automaticbackup_checkbox.Checked = True Then
                HSXML.Write("AutomaticBackup", "True", AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
                自动备份AToolStripMenuItem.Text = "关闭自动备份(&C)"
            ElseIf automaticbackup_checkbox.Checked = False Then
                HSXML.Write("AutomaticBackup", "False", AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
                自动备份AToolStripMenuItem.Text = "开启自动备份(&S)"
            End If
            '------
            If show_backup_animation_CheckBox.Checked = True Then
                HSXML.Write("ShowBackupAnimation", "True", AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
            ElseIf show_backup_animation_CheckBox.Checked = False Then
                HSXML.Write("ShowBackupAnimation", "False", AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
            End If
            '------
            If atsetintervals_radiobutton.Checked = True And backup_after_start_radiobutton.Checked = False Then
                HSXML.Write("AutomaticBackupType", "AtSetIntervals", AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
            ElseIf atsetintervals_radiobutton.Checked = False And backup_after_start_radiobutton.Checked = True Then
                HSXML.Write("AutomaticBackupType", "BackupAfterStart", AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
            End If
            '------
            HSXML.Write("AutomaticBackupTime", CStr(backup_interval_numericupdown.Value * 60 * 1000), AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
            '------
            If find_difference_radiobutton.Checked = True And always_backup_radiobutton.Checked = False Then
                HSXML.Write("AutomaticBackupCondition", "FindDifference", AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
            ElseIf find_difference_radiobutton.Checked = False And always_backup_radiobutton.Checked = True Then
                HSXML.Write("AutomaticBackupCondition", "AlwaysBackup", AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
            End If
            '------
            If delete_backup_checkbox.Checked = True Then
                HSXML.Write("AutomaticDeleteBackup", "True", AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
            ElseIf delete_backup_checkbox.Checked = False Then
                HSXML.Write("AutomaticDeleteBackup", "False", AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
            End If
            '------
            If maxtotal_radiobutton.Checked = True And largestsize_radiobutton.Checked = False Then
                HSXML.Write("AutomaticDeleteBackupCondition", "MaxBackupTotal", AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
            ElseIf maxtotal_radiobutton.Checked = False And largestsize_radiobutton.Checked = True Then
                HSXML.Write("AutomaticDeleteBackupCondition", "LargestSize", AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
            End If
            '------
            HSXML.Write("MaxBackupTotal", CStr(maxtotal_NumericUpDown.Value), AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
            HSXML.Write("LargestBackupSize", CStr(largest_size_NumericUpDown.Value), AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
            '------
            HSXML.Write("CompressionLevel", CStr(level_TrackBar.Value), AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
            '------
            '使设置生效
            AutomaticBackupTimer.Enabled = HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "AutomaticBackup")
            AutomaticBackupTimer.Interval = Val(HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "AutomaticBackupTime"))
            next_start_lbl.Visible = True
        Catch ex As Exception
            MsgBox("无法写入配置：" & ex.Message, MsgBoxStyle.Critical, "错误")
        End Try
    End Sub

    Private Function GetFolderSize(ByVal Folder As String) As String
        On Error Resume Next
        Dim size As Long
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(Folder, FileIO.SearchOption.SearchAllSubDirectories, "*.*")
            size = size + My.Computer.FileSystem.GetFileInfo(foundFile).Length
        Next
        Dim mbsize As String = CStr(Decimal.Round(CDec(size / 1024 / 1024), 2))
        Return mbsize
    End Function

    Private Sub refresh_info()
        On Error Resume Next
        '列出备份文件夹列表
        Dim dirPath As String = My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini")
        Dim dirs As List(Of String) = New List(Of String)(Directory.EnumerateDirectories(dirPath))
        Dim selectedindex As Integer = backup_lstbox.SelectedIndex
        backup_lstbox.Items.Clear()
        For Each folder In dirs
            backup_lstbox.Items.Add(folder.Substring(folder.LastIndexOf("\") + 1))
        Next
        backup_lstbox.SelectedIndex = selectedindex
        '计算总大小
        backup_size_lbl.Text = "备份总大小：" & GetFolderSize(My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini")) & " MB"
    End Sub

    Private Sub automaticbackup_checkbox_Click(sender As Object, e As EventArgs) Handles automaticbackup_checkbox.Click
        Call write_config()
    End Sub

    Private Sub atsetintervals_radiobutton_Click(sender As Object, e As EventArgs) Handles atsetintervals_radiobutton.Click
        Call write_config()
        backup_interval_numericupdown.Enabled = True
    End Sub

    Private Sub backup_interval_numericupdown_Click(sender As Object, e As EventArgs) Handles backup_interval_numericupdown.Click
        Call write_config()
    End Sub

    Private Sub backup_after_start_radiobutton_Click(sender As Object, e As EventArgs) Handles backup_after_start_radiobutton.Click
        Call write_config()
        backup_interval_numericupdown.Enabled = False
    End Sub

    Private Sub find_difference_radiobutton_Click(sender As Object, e As EventArgs) Handles find_difference_radiobutton.Click
        Call write_config()
    End Sub

    Private Sub always_backup_radiobutton_Click(sender As Object, e As EventArgs) Handles always_backup_radiobutton.Click
        Call write_config()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        On Error Resume Next
        input_saves.Show()
        input_saves.exit_program = False
    End Sub

    Private Sub automaticbackup_checkbox_CheckedChanged(sender As Object, e As EventArgs) Handles automaticbackup_checkbox.CheckedChanged
        If automaticbackup_checkbox.Checked = False Then
            atsetintervals_radiobutton.Enabled = False
            backup_interval_numericupdown.Enabled = False
            backup_after_start_radiobutton.Enabled = False
            find_difference_radiobutton.Enabled = False
            always_backup_radiobutton.Enabled = False
        Else
            atsetintervals_radiobutton.Enabled = True
            backup_interval_numericupdown.Enabled = True
            backup_after_start_radiobutton.Enabled = True
            find_difference_radiobutton.Enabled = True
            always_backup_radiobutton.Enabled = True
        End If
    End Sub

    Private Sub backup_btn_Click(sender As Object, e As EventArgs) Handles backup_btn.Click
        Try
            If HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "ShowBackupAnimation") = True Then backup_animation.Show()
            ProgressBar1.Value = 0
            percent_lbl.Text = "已完成0%"
            state_lbl.Text = "当前状态：正在备份"
            当前状态ToolStripMenuItem.Text = "当前状态：正在备份"
            NotifyIcon1.Text = "Minecraft存档备份 - 正在备份"
            NotifyIcon1.ShowBalloonTip(5000, "Minecraft存档备份", "备份开始。", ToolTipIcon.Info)
            LinkLabel1.Enabled = False
            backup_btn.Enabled = False
            立即备份BToolStripMenuItem.Enabled = False
            backup_btn.Text = "正在执行..."
            NotifyIconTimer.Enabled = True
            backup_BackgroundWorker.RunWorkerAsync()
        Catch ex As Exception
            MsgBox("无法启动备份：" & ex.Message, MsgBoxStyle.Critical, "错误")
            refresh_info()
            ProgressBar1.Value = 100
            percent_lbl.Text = "已完成100%"
            state_lbl.Text = "当前状态：备份出错"
            当前状态ToolStripMenuItem.Text = "当前状态：备份出错"
            LinkLabel1.Enabled = True
            backup_btn.Enabled = True
            立即备份BToolStripMenuItem.Enabled = True
            backup_btn.Text = "立即备份(&B)"
            NotifyIconTimer.Enabled = False
            NotifyIcon1.Icon = My.Resources.icon_16x16
            NotifyIcon1.Text = "Minecraft存档备份"
            backup_animation.Close()
        End Try
    End Sub

    Private Sub backup_BackgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles backup_BackgroundWorker.DoWork
        Try
            '备份过程
            Dim month As String, day As String, hour As String, minute As String, second As String
            If CStr(Now.Month).Length = 1 Then
                month = "0" & Now.Month
            Else
                month = Now.Month
            End If
            '---
            If CStr(Now.Day).Length = 1 Then
                day = "0" & Now.Day
            Else
                day = Now.Day
            End If
            '---
            If CStr(Now.Hour).Length = 1 Then
                hour = "0" & Now.Hour
            Else
                hour = Now.Hour
            End If
            '---
            If CStr(Now.Minute).Length = 1 Then
                minute = "0" & Now.Minute
            Else
                minute = Now.Minute
            End If
            '----
            If CStr(Now.Second).Length = 1 Then
                second = "0" & Now.Second
            Else
                second = Now.Second
            End If
            '----
            Dim datetime As String = Now.Year & month & day & "_" & hour & minute & second
            For i = 1 To HSXML.Count(AppDomain.CurrentDomain.BaseDirectory & "BackupFolder.hsxml") Step 1
                Dim gamename As String = HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "BackupFolder.hsxml", CStr(i)).Replace(My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "savesPath.ini"), Nothing)
                Dim startPath As String = HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "BackupFolder.hsxml", CStr(i))
                Dim backuppath As String = My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini")
                If Strings.Right(backuppath, 1) <> "\" Then
                    backuppath = backuppath & "\" & datetime
                Else
                    backuppath = backuppath & datetime
                End If
                My.Computer.FileSystem.CreateDirectory(backuppath)
                Dim zipPath As String = backuppath & "\" & gamename & ".saves"
                If My.Computer.FileSystem.FileExists(zipPath) Then My.Computer.FileSystem.DeleteFile(zipPath)
                CompressFolder(startPath, zipPath, Val(HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "CompressionLevel")))
                Dim percent As Decimal = i / HSXML.Count(AppDomain.CurrentDomain.BaseDirectory & "BackupFolder.hsxml") * 50
                backup_BackgroundWorker.ReportProgress(Decimal.Round(percent, 0))
            Next
            backup_BackgroundWorker.ReportProgress(Decimal.Round(50, 0))
            '更新MD5
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
                Dim percent As Decimal = i / HSXML.Count(AppDomain.CurrentDomain.BaseDirectory & "BackupFolder.hsxml") * 50 + 50
                backup_BackgroundWorker.ReportProgress(Decimal.Round(percent, 0))
            Next
            backup_BackgroundWorker.ReportProgress(Decimal.Round(100, 0))
        Catch ex As Exception
            NotifyIcon1.ShowBalloonTip(5000, "Minecraft存档备份", "备份时出错：" & ex.Message, ToolTipIcon.Error)
            backup_BackgroundWorker.CancelAsync()
            refresh_info()
            ProgressBar1.Value = 100
            percent_lbl.Text = "已完成100%"
            state_lbl.Text = "当前状态：备份出错"
            当前状态ToolStripMenuItem.Text = "当前状态：备份出错"
            LinkLabel1.Enabled = True
            backup_btn.Enabled = True
            立即备份BToolStripMenuItem.Enabled = True
            backup_btn.Text = "立即备份(&B)"
            NotifyIconTimer.Enabled = False
            NotifyIcon1.Icon = My.Resources.icon_16x16
            NotifyIcon1.Text = "Minecraft存档备份"
            backup_animation.Close()
        End Try
    End Sub

    Private Sub backup_BackgroundWorker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles backup_BackgroundWorker.ProgressChanged
        ProgressBar1.Value = Val(e.ProgressPercentage.ToString)
        percent_lbl.Text = "已完成" & e.ProgressPercentage.ToString & "%"
    End Sub

    Private Sub backup_BackgroundWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backup_BackgroundWorker.RunWorkerCompleted
        On Error Resume Next
        refresh_info()
        ProgressBar1.Value = 100
        percent_lbl.Text = "已完成100%"
        state_lbl.Text = "当前状态：备份完成"
        当前状态ToolStripMenuItem.Text = "当前状态：备份完成"
        LinkLabel1.Enabled = True
        backup_btn.Enabled = True
        立即备份BToolStripMenuItem.Enabled = True
        backup_btn.Text = "立即备份(&B)"
        NotifyIconTimer.Enabled = False
        NotifyIcon1.Icon = My.Resources.icon_16x16
        NotifyIcon1.Text = "Minecraft存档备份"
        NotifyIcon1.ShowBalloonTip(5000, "Minecraft存档备份", "已完成备份。", ToolTipIcon.Info)
        If HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "AutomaticDeleteBackup") = "True" Then
            If HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "AutomaticDeleteBackupCondition") = "MaxBackupTotal" Then
                If backup_lstbox.Items.Count > Val(HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "MaxBackupTotal")) Then
                    Do Until backup_lstbox.Items.Count <= Val(HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "MaxBackupTotal"))
                        backup_lstbox.SelectedIndex = 0
                        Dim backuppath As String
                        If Strings.Right(My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini"), 1) = "\" Then
                            backuppath = My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini") & backup_lstbox.SelectedItem
                        Else
                            backuppath = My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini") & "\" & backup_lstbox.SelectedItem
                        End If
                        If Strings.Right(backuppath, 1) <> "\" Then backuppath = backuppath & "\"
                        If My.Computer.FileSystem.DirectoryExists(backuppath) Then My.Computer.FileSystem.DeleteDirectory(backuppath, FileIO.DeleteDirectoryOption.DeleteAllContents)
                        refresh_info()
                    Loop
                End If
            ElseIf HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "AutomaticDeleteBackupCondition") = "LargestSize" Then
                If Val(GetFolderSize(My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini"))) > Val(HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "LargestBackupSize")) Then
                    Do Until Val(GetFolderSize(My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini"))) <= Val(HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "LargestBackupSize"))
                        backup_lstbox.SelectedIndex = 0
                        Dim backuppath As String
                        If Strings.Right(My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini"), 1) = "\" Then
                            backuppath = My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini") & backup_lstbox.SelectedItem
                        Else
                            backuppath = My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini") & "\" & backup_lstbox.SelectedItem
                        End If
                        If Strings.Right(backuppath, 1) <> "\" Then backuppath = backuppath & "\"
                        If My.Computer.FileSystem.DirectoryExists(backuppath) Then My.Computer.FileSystem.DeleteDirectory(backuppath, FileIO.DeleteDirectoryOption.DeleteAllContents)
                        refresh_info()
                    Loop
                End If
            End If
        End If
        backup_animation.Close()
    End Sub

    Private Sub AutomaticBackupTimer_Tick(sender As Object, e As EventArgs) Handles AutomaticBackupTimer.Tick
        Try
            If HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "AutomaticBackupCondition") = "FindDifference" Then
                '检测不同
                ProgressBar1.Value = 0
                percent_lbl.Text = "已完成0%"
                state_lbl.Text = "当前状态：正在检测文件变动"
                当前状态ToolStripMenuItem.Text = "当前状态：正在检测文件变动"
                LinkLabel1.Enabled = False
                backup_btn.Enabled = False
                立即备份BToolStripMenuItem.Enabled = False
                backup_btn.Text = "正在执行..."
                NotifyIconTimer.Enabled = True
                NotifyIcon1.Text = "Minecraft存档备份 - 正在检测文件变动"
                NotifyIcon1.ShowBalloonTip(5000, "Minecraft存档备份", "开始检测文件变动。", ToolTipIcon.Info)
                found_difference = False
                find_difference_BackgroundWorker.RunWorkerAsync()
            Else
                '立即备份
                If HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "ShowBackupAnimation") = True Then backup_animation.Show()
                ProgressBar1.Value = 0
                percent_lbl.Text = "已完成0%"
                state_lbl.Text = "当前状态：正在备份"
                当前状态ToolStripMenuItem.Text = "当前状态：正在备份"
                LinkLabel1.Enabled = False
                backup_btn.Enabled = False
                立即备份BToolStripMenuItem.Enabled = False
                backup_btn.Text = "正在执行..."
                NotifyIconTimer.Enabled = True
                NotifyIcon1.Text = "Minecraft存档备份 - 正在备份"
                NotifyIcon1.ShowBalloonTip(5000, "Minecraft存档备份", "备份开始。", ToolTipIcon.Info)
                backup_BackgroundWorker.RunWorkerAsync()
            End If
        Catch ex As Exception
            NotifyIcon1.ShowBalloonTip(5000, "Minecraft存档备份", "无法启动自动备份：" & ex.Message, ToolTipIcon.Error)
            refresh_info()
            ProgressBar1.Value = 100
            percent_lbl.Text = "已完成100%"
            state_lbl.Text = "当前状态：备份出错"
            当前状态ToolStripMenuItem.Text = "当前状态：备份出错"
            LinkLabel1.Enabled = True
            backup_btn.Enabled = True
            立即备份BToolStripMenuItem.Enabled = True
            backup_btn.Text = "立即备份(&B)"
            NotifyIconTimer.Enabled = False
            NotifyIcon1.Icon = My.Resources.icon_16x16
            NotifyIcon1.Text = "Minecraft存档备份"
            backup_animation.Close()
        End Try
    End Sub

    Private Sub find_difference_BackgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles find_difference_BackgroundWorker.DoWork
        Try
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
                    If MD5Checkesult <> HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "MD5.hsxml", foundFile) Then found_difference = True
                Next
                find_difference_BackgroundWorker.ReportProgress(i / HSXML.Count(AppDomain.CurrentDomain.BaseDirectory & "BackupFolder.hsxml") * 100)
            Next
        Catch ex As Exception
            NotifyIcon1.ShowBalloonTip(5000, "Minecraft存档备份", "检测文件变动时出错：" & ex.Message, ToolTipIcon.Error)
            find_difference_BackgroundWorker.CancelAsync()
            refresh_info()
            ProgressBar1.Value = 100
            percent_lbl.Text = "已完成100%"
            state_lbl.Text = "当前状态：检测文件变动时出错"
            当前状态ToolStripMenuItem.Text = "当前状态：检测文件变动时出错"
            LinkLabel1.Enabled = True
            backup_btn.Enabled = True
            立即备份BToolStripMenuItem.Enabled = True
            backup_btn.Text = "立即备份(&B)"
            NotifyIconTimer.Enabled = False
            NotifyIcon1.Icon = My.Resources.icon_16x16
            NotifyIcon1.Text = "Minecraft存档备份"
            backup_animation.Close()
        End Try
    End Sub

    Private Sub find_difference_BackgroundWorker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles find_difference_BackgroundWorker.ProgressChanged
        ProgressBar1.Value = Val(e.ProgressPercentage.ToString)
        percent_lbl.Text = "已完成" & e.ProgressPercentage.ToString & "%"
    End Sub

    Private Sub find_difference_BackgroundWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles find_difference_BackgroundWorker.RunWorkerCompleted
        On Error Resume Next
        ProgressBar1.Value = 100
        percent_lbl.Text = "已完成100%"
        LinkLabel1.Enabled = True
        backup_btn.Enabled = True
        立即备份BToolStripMenuItem.Enabled = True
        backup_btn.Text = "立即备份(&B)"
        NotifyIconTimer.Enabled = False
        NotifyIcon1.Icon = My.Resources.icon_16x16
        NotifyIcon1.Text = "Minecraft存档备份"
        NotifyIcon1.ShowBalloonTip(5000, "Minecraft存档备份", "检测文件变动完成。", ToolTipIcon.Info)
        If found_difference = True Then
            state_lbl.Text = "当前状态：文件有变动"
            当前状态ToolStripMenuItem.Text = "当前状态：文件有变动"
            If HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "ShowBackupAnimation") = True Then backup_animation.Show()
            ProgressBar1.Value = 0
            percent_lbl.Text = "已完成0%"
            state_lbl.Text = "当前状态：正在备份"
            当前状态ToolStripMenuItem.Text = "当前状态：正在备份"
            LinkLabel1.Enabled = False
            backup_btn.Enabled = False
            立即备份BToolStripMenuItem.Enabled = False
            backup_btn.Text = "正在执行..."
            NotifyIconTimer.Enabled = True
            NotifyIcon1.Text = "Minecraft存档备份 - 正在备份"
            NotifyIcon1.ShowBalloonTip(5000, "Minecraft存档备份", "备份开始。", ToolTipIcon.Info)
            backup_BackgroundWorker.RunWorkerAsync()
        Else
            state_lbl.Text = "当前状态：文件无变动"
            当前状态ToolStripMenuItem.Text = "当前状态：文件无变动"
        End If
    End Sub

    Private Sub backup_interval_numericupdown_KeyUp(sender As Object, e As KeyEventArgs) Handles backup_interval_numericupdown.KeyUp
        Call write_config()
    End Sub

    Private Sub recovery_btn_Click(sender As Object, e As EventArgs) Handles recovery_btn.Click
        view_backup.Show()
    End Sub

    Private Sub NotifyIconTimer_Tick(sender As Object, e As EventArgs) Handles NotifyIconTimer.Tick
        On Error Resume Next
        Select Case iconcount
            Case 1
                NotifyIcon1.Icon = My.Resources.c1
            Case 2
                NotifyIcon1.Icon = My.Resources.c2
            Case 3
                NotifyIcon1.Icon = My.Resources.c3
            Case 4
                NotifyIcon1.Icon = My.Resources.c4
            Case 5
                NotifyIcon1.Icon = My.Resources.c5
            Case 6
                NotifyIcon1.Icon = My.Resources.c6
            Case 7
                NotifyIcon1.Icon = My.Resources.c7
            Case 8
                NotifyIcon1.Icon = My.Resources.c8
            Case 9
                NotifyIcon1.Icon = My.Resources.c9
            Case 10
                NotifyIcon1.Icon = My.Resources.c10
            Case 11
                NotifyIcon1.Icon = My.Resources.c11
            Case 12
                NotifyIcon1.Icon = My.Resources.c12
            Case 13
                NotifyIcon1.Icon = My.Resources.c13
            Case 14
                NotifyIcon1.Icon = My.Resources.c14
            Case 15
                NotifyIcon1.Icon = My.Resources.c15
            Case 16
                NotifyIcon1.Icon = My.Resources.c16
            Case 17
                NotifyIcon1.Icon = My.Resources.c15
            Case 18
                NotifyIcon1.Icon = My.Resources.c14
            Case 19
                NotifyIcon1.Icon = My.Resources.c13
            Case 20
                NotifyIcon1.Icon = My.Resources.c12
            Case 21
                NotifyIcon1.Icon = My.Resources.c11
            Case 22
                NotifyIcon1.Icon = My.Resources.c10
            Case 23
                NotifyIcon1.Icon = My.Resources.c9
            Case 24
                NotifyIcon1.Icon = My.Resources.c8
            Case 25
                NotifyIcon1.Icon = My.Resources.c7
            Case 26
                NotifyIcon1.Icon = My.Resources.c6
            Case 27
                NotifyIcon1.Icon = My.Resources.c5
            Case 28
                NotifyIcon1.Icon = My.Resources.c4
            Case 29
                NotifyIcon1.Icon = My.Resources.c3
            Case 30
                NotifyIcon1.Icon = My.Resources.c2
        End Select
        iconcount = iconcount + 1
        If iconcount > 30 Then iconcount = 1
    End Sub

    Private Sub main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.Hide()
        NotifyIcon1.ShowBalloonTip(5000, "Minecraft存档备份", "Minecraft存档自动备份已启动，如需显示主窗口，请在此图标上右键并选择""打开主窗体""。", ToolTipIcon.Info)
    End Sub

    Public Sub mainshown()
        Try
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\MinecraftSavesBackup", "ProgramPath", AppDomain.CurrentDomain.BaseDirectory & My.Application.Info.AssemblyName & ".exe")
            If My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "BackupFolder.hsxml") = False Then
                input_saves.Show()
                input_saves.exit_program = True
                Me.Close()
                NotifyIcon1.Visible = False
            ElseIf My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini") = False Then
                input_saves.Show()
                input_saves.exit_program = True
                Me.Close()
                NotifyIcon1.Visible = False
            ElseIf My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "MD5.hsxml") = False Then
                input_saves.Show()
                input_saves.exit_program = True
                Me.Close()
                NotifyIcon1.Visible = False
            ElseIf My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "savesPath.ini") = False Then
                input_saves.Show()
                input_saves.exit_program = True
                Me.Close()
                NotifyIcon1.Visible = False
            ElseIf My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml") = False Then
                HSXML.Write("AutomaticBackup", "True", AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
                HSXML.Write("AutomaticBackupType", "AtSetIntervals", AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
                HSXML.Write("AutomaticBackupTime", "1800000", AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
                HSXML.Write("AutomaticBackupCondition", "FindDifference", AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
                HSXML.Write("AutomaticDeleteBackup", "False", AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
                HSXML.Write("AutomaticDeleteBackupCondition", "MaxBackupTotal", AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
                HSXML.Write("MaxBackupTotal", "20", AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
                HSXML.Write("LargestBackupSize", "50", AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
                HSXML.Write("ShowBackupAnimation", "True", AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
                HSXML.Write("CompressionLevel", "5", AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
                '-----
                NotifyIcon1.Visible = True
                show_backup_animation_CheckBox.Checked = HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "ShowBackupAnimation")
                '加载要备份的存档
                For i = 1 To HSXML.Count(AppDomain.CurrentDomain.BaseDirectory & "BackupFolder.hsxml")
                    saves_lstbox.Items.Add(HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "BackupFolder.hsxml", CStr(i)).Replace(My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "savesPath.ini"), Nothing))
                Next
                '加载备份文件夹地址
                backup_path_lbl.Text = "备份地址：" & My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini")
                '加载设置
                level_TrackBar.Value = Val(HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "CompressionLevel"))
                If HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "AutomaticBackup") = "True" Then
                    automaticbackup_checkbox.Checked = True
                    自动备份AToolStripMenuItem.Text = "关闭自动备份(&C)"
                Else
                    automaticbackup_checkbox.Checked = False
                    自动备份AToolStripMenuItem.Text = "开启自动备份(&S)"
                End If
                AutomaticBackupTimer.Enabled = HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "AutomaticBackup")
                If HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "AutomaticBackup") = "True" Then
                    If HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "AutomaticBackupType") = "AtSetIntervals" Then
                        atsetintervals_radiobutton.Checked = True
                        backup_interval_numericupdown.Enabled = True
                        Me.Hide()
                        NotifyIcon1.ShowBalloonTip(5000, "Minecraft存档备份", "Minecraft存档自动备份已启动，如需显示主窗口，请在此图标上右键并选择""打开主窗体""。", ToolTipIcon.Info)
                    Else
                        backup_after_start_radiobutton.Checked = True
                        backup_interval_numericupdown.Enabled = False
                        AutomaticBackupTimer.Enabled = False
                        If HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "AutomaticBackupCondition") = "FindDifference" Then
                            ProgressBar1.Value = 0
                            percent_lbl.Text = "已完成0%"
                            state_lbl.Text = "当前状态：正在检测文件变动"
                            当前状态ToolStripMenuItem.Text = "当前状态：正在检测文件变动"
                            LinkLabel1.Enabled = False
                            backup_btn.Enabled = False
                            立即备份BToolStripMenuItem.Enabled = False
                            backup_btn.Text = "正在执行..."
                            NotifyIconTimer.Enabled = True
                            NotifyIcon1.Text = "Minecraft存档备份 - 正在检测文件变动"
                            NotifyIcon1.ShowBalloonTip(5000, "Minecraft存档备份", "开始检测文件变动。", ToolTipIcon.Info)
                            found_difference = False
                            find_difference_BackgroundWorker.RunWorkerAsync()
                        Else
                            If HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "ShowBackupAnimation") = True Then backup_animation.Show()
                            ProgressBar1.Value = 0
                            percent_lbl.Text = "已完成0%"
                            state_lbl.Text = "当前状态：正在备份"
                            当前状态ToolStripMenuItem.Text = "当前状态：正在备份"
                            LinkLabel1.Enabled = False
                            backup_btn.Enabled = False
                            立即备份BToolStripMenuItem.Enabled = False
                            backup_btn.Text = "正在执行..."
                            NotifyIconTimer.Enabled = True
                            NotifyIcon1.Text = "Minecraft存档备份 - 正在备份"
                            NotifyIcon1.ShowBalloonTip(5000, "Minecraft存档备份", "备份开始。", ToolTipIcon.Info)
                            backup_BackgroundWorker.RunWorkerAsync()
                        End If
                    End If
                Else
                    state_lbl.Text = "当前状态：等待手动备份"
                    当前状态ToolStripMenuItem.Text = "当前状态：等待手动备份"
                End If
                backup_interval_numericupdown.Value = Val(HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "AutomaticBackupTime")) / 60 / 1000
                AutomaticBackupTimer.Interval = Val(HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "AutomaticBackupTime"))
                If HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "AutomaticBackupCondition") = "FindDifference" Then
                    find_difference_radiobutton.Checked = True
                Else
                    always_backup_radiobutton.Checked = True
                End If
                '-----
                delete_backup_checkbox.Checked = HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "AutomaticDeleteBackup")
                '-----
                If HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "AutomaticDeleteBackupCondition") = "MaxBackupTotal" Then
                    maxtotal_radiobutton.Checked = True
                Else
                    largestsize_radiobutton.Checked = True
                End If
                '-----
                maxtotal_NumericUpDown.Value = Val(HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "MaxBackupTotal"))
                largest_size_NumericUpDown.Value = Val(HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "LargestBackupSize"))
                '-----
                If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", Application.ProductName, Nothing) = Nothing Then
                    autostart_checkbox.Checked = False
                Else
                    autostart_checkbox.Checked = True
                End If
                '-----
                If delete_backup_checkbox.Checked = True Then
                    maxtotal_radiobutton.Enabled = True
                    largestsize_radiobutton.Enabled = True
                    If maxtotal_radiobutton.Checked = True Then
                        maxtotal_NumericUpDown.Enabled = True
                        largest_size_NumericUpDown.Enabled = False
                    Else
                        maxtotal_NumericUpDown.Enabled = False
                        largest_size_NumericUpDown.Enabled = True
                    End If
                Else
                    maxtotal_radiobutton.Enabled = False
                    largestsize_radiobutton.Enabled = False
                    maxtotal_NumericUpDown.Enabled = False
                    largest_size_NumericUpDown.Enabled = False
                End If
                '-----
                If automaticbackup_checkbox.Checked = False Then
                    atsetintervals_radiobutton.Enabled = False
                    backup_interval_numericupdown.Enabled = False
                    backup_after_start_radiobutton.Enabled = False
                    find_difference_radiobutton.Enabled = False
                    always_backup_radiobutton.Enabled = False
                Else
                    atsetintervals_radiobutton.Enabled = True
                    backup_interval_numericupdown.Enabled = True
                    backup_after_start_radiobutton.Enabled = True
                    find_difference_radiobutton.Enabled = True
                    always_backup_radiobutton.Enabled = True
                End If
                '-----
                refresh_info()
            Else
                If HSXML.Verify(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "AutomaticBackup") = False _
                    Or HSXML.Verify(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "AutomaticBackupType") = False _
                    Or HSXML.Verify(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "AutomaticBackupTime") = False _
                    Or HSXML.Verify(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "AutomaticBackupCondition") = False _
                    Or HSXML.Verify(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "AutomaticDeleteBackup") = False _
                    Or HSXML.Verify(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "AutomaticDeleteBackupCondition") = False _
                    Or HSXML.Verify(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "MaxBackupTotal") = False _
                    Or HSXML.Verify(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "LargestBackupSize") = False _
                    Or HSXML.Verify(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "ShowBackupAnimation") = False _
                    Or HSXML.Verify(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "CompressionLevel") = False Then
                    If My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml") Then My.Computer.FileSystem.DeleteFile(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
                    HSXML.Write("AutomaticBackup", "True", AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
                    HSXML.Write("AutomaticBackupType", "AtSetIntervals", AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
                    HSXML.Write("AutomaticBackupTime", "1800000", AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
                    HSXML.Write("AutomaticBackupCondition", "FindDifference", AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
                    HSXML.Write("AutomaticDeleteBackup", "False", AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
                    HSXML.Write("AutomaticDeleteBackupCondition", "MaxBackupTotal", AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
                    HSXML.Write("MaxBackupTotal", "20", AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
                    HSXML.Write("LargestBackupSize", "50", AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
                    HSXML.Write("ShowBackupAnimation", "True", AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
                    HSXML.Write("CompressionLevel", "5", AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml")
                End If
                NotifyIcon1.Visible = True
                show_backup_animation_CheckBox.Checked = HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "ShowBackupAnimation")
                '加载要备份的存档
                saves_lstbox.Items.Clear()
                For i = 1 To HSXML.Count(AppDomain.CurrentDomain.BaseDirectory & "BackupFolder.hsxml")
                    saves_lstbox.Items.Add(HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "BackupFolder.hsxml", CStr(i)).Replace(My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "savesPath.ini"), Nothing))
                Next
                '加载备份文件夹地址
                backup_path_lbl.Text = "备份地址：" & My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini")
                '加载设置
                level_TrackBar.Value = Val(HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "CompressionLevel"))
                If HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "AutomaticBackup") = "True" Then
                    automaticbackup_checkbox.Checked = True
                    自动备份AToolStripMenuItem.Text = "关闭自动备份(&C)"
                Else
                    automaticbackup_checkbox.Checked = False
                    自动备份AToolStripMenuItem.Text = "开启自动备份(&S)"
                End If
                automaticbackup_checkbox.Checked = HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "AutomaticBackup")
                AutomaticBackupTimer.Enabled = HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "AutomaticBackup")
                If HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "AutomaticBackup") = "True" Then
                    If HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "AutomaticBackupType") = "AtSetIntervals" Then
                        atsetintervals_radiobutton.Checked = True
                        backup_interval_numericupdown.Enabled = True
                        Me.Hide()
                        NotifyIcon1.ShowBalloonTip(5000, "Minecraft存档备份", "Minecraft存档自动备份已启动，如需显示主窗口，请在此图标上右键并选择""打开主窗体""。", ToolTipIcon.Info)
                    Else
                        backup_after_start_radiobutton.Checked = True
                        backup_interval_numericupdown.Enabled = False
                        AutomaticBackupTimer.Enabled = False
                        If HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "AutomaticBackupCondition") = "FindDifference" Then
                            ProgressBar1.Value = 0
                            percent_lbl.Text = "已完成0%"
                            state_lbl.Text = "当前状态：正在检测文件变动"
                            当前状态ToolStripMenuItem.Text = "当前状态：正在检测文件变动"
                            LinkLabel1.Enabled = False
                            backup_btn.Enabled = False
                            立即备份BToolStripMenuItem.Enabled = False
                            backup_btn.Text = "正在执行..."
                            NotifyIconTimer.Enabled = True
                            NotifyIcon1.Text = "Minecraft存档备份 - 正在检测文件变动"
                            NotifyIcon1.ShowBalloonTip(5000, "Minecraft存档备份", "开始检测文件变动。", ToolTipIcon.Info)
                            found_difference = False
                            find_difference_BackgroundWorker.RunWorkerAsync()
                        Else
                            If HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "ShowBackupAnimation") = True Then backup_animation.Show()
                            ProgressBar1.Value = 0
                            percent_lbl.Text = "已完成0%"
                            state_lbl.Text = "当前状态：正在备份"
                            当前状态ToolStripMenuItem.Text = "当前状态：正在备份"
                            LinkLabel1.Enabled = False
                            backup_btn.Enabled = False
                            立即备份BToolStripMenuItem.Enabled = False
                            backup_btn.Text = "正在执行..."
                            NotifyIconTimer.Enabled = True
                            NotifyIcon1.Text = "Minecraft存档备份 - 正在备份"
                            NotifyIcon1.ShowBalloonTip(5000, "Minecraft存档备份", "备份开始。", ToolTipIcon.Info)
                            backup_BackgroundWorker.RunWorkerAsync()
                        End If
                    End If
                Else
                    state_lbl.Text = "当前状态：等待手动备份"
                    当前状态ToolStripMenuItem.Text = "当前状态：等待手动备份"
                End If
                backup_interval_numericupdown.Value = Val(HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "AutomaticBackupTime")) / 60 / 1000
                AutomaticBackupTimer.Interval = Val(HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "AutomaticBackupTime"))
                If HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "AutomaticBackupCondition") = "FindDifference" Then
                    find_difference_radiobutton.Checked = True
                Else
                    always_backup_radiobutton.Checked = True
                End If
                '-----
                delete_backup_checkbox.Checked = HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "AutomaticDeleteBackup")
                '-----
                If HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "AutomaticDeleteBackupCondition") = "MaxBackupTotal" Then
                    maxtotal_radiobutton.Checked = True
                Else
                    largestsize_radiobutton.Checked = True
                End If
                '-----
                maxtotal_NumericUpDown.Value = Val(HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "MaxBackupTotal"))
                largest_size_NumericUpDown.Value = Val(HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "LargestBackupSize"))
                '-----
                If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", Application.ProductName, Nothing) = Nothing Then
                    autostart_checkbox.Checked = False
                Else
                    autostart_checkbox.Checked = True
                End If
                '-----
                If delete_backup_checkbox.Checked = True Then
                    maxtotal_radiobutton.Enabled = True
                    largestsize_radiobutton.Enabled = True
                    If maxtotal_radiobutton.Checked = True Then
                        maxtotal_NumericUpDown.Enabled = True
                        largest_size_NumericUpDown.Enabled = False
                    Else
                        maxtotal_NumericUpDown.Enabled = False
                        largest_size_NumericUpDown.Enabled = True
                    End If
                Else
                    maxtotal_radiobutton.Enabled = False
                    largestsize_radiobutton.Enabled = False
                    maxtotal_NumericUpDown.Enabled = False
                    largest_size_NumericUpDown.Enabled = False
                End If
                '-----
                If automaticbackup_checkbox.Checked = False Then
                    atsetintervals_radiobutton.Enabled = False
                    backup_interval_numericupdown.Enabled = False
                    backup_after_start_radiobutton.Enabled = False
                    find_difference_radiobutton.Enabled = False
                    always_backup_radiobutton.Enabled = False
                Else
                    atsetintervals_radiobutton.Enabled = True
                    backup_interval_numericupdown.Enabled = True
                    backup_after_start_radiobutton.Enabled = True
                    find_difference_radiobutton.Enabled = True
                    always_backup_radiobutton.Enabled = True
                End If
                '-----
                refresh_info()
            End If
        Catch ex As Exception
            MsgBox("读取设置错误：" & ex.Message, MsgBoxStyle.Critical, "错误")
        End Try
    End Sub

    Public Sub main_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        mainshown()
        check_update_BackgroundWorker.RunWorkerAsync()
    End Sub

    Private Sub 打开主窗体OToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开主窗体OToolStripMenuItem.Click
        Me.Show()
    End Sub

    Private Sub 退出EToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 退出EToolStripMenuItem.Click
        End
    End Sub

    Private Sub 立即备份BToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 立即备份BToolStripMenuItem.Click
        Try
            If HSXML.Read(AppDomain.CurrentDomain.BaseDirectory & "Config.hsxml", "ShowBackupAnimation") = True Then backup_animation.Show()
            ProgressBar1.Value = 0
            percent_lbl.Text = "已完成0%"
            state_lbl.Text = "当前状态：正在备份"
            当前状态ToolStripMenuItem.Text = "当前状态：正在备份"
            NotifyIcon1.Text = "Minecraft存档备份 - 正在备份"
            NotifyIcon1.ShowBalloonTip(5000, "Minecraft存档备份", "备份开始。", ToolTipIcon.Info)
            LinkLabel1.Enabled = False
            backup_btn.Enabled = False
            立即备份BToolStripMenuItem.Enabled = False
            backup_btn.Text = "正在执行..."
            NotifyIconTimer.Enabled = True
            backup_BackgroundWorker.RunWorkerAsync()
        Catch ex As Exception
            MsgBox("无法启动备份：" & ex.Message, MsgBoxStyle.Critical, "错误")
            refresh_info()
            ProgressBar1.Value = 100
            percent_lbl.Text = "已完成100%"
            state_lbl.Text = "当前状态：备份出错"
            当前状态ToolStripMenuItem.Text = "当前状态：备份出错"
            LinkLabel1.Enabled = True
            backup_btn.Enabled = True
            立即备份BToolStripMenuItem.Enabled = True
            backup_btn.Text = "立即备份(&B)"
            NotifyIconTimer.Enabled = False
            NotifyIcon1.Icon = My.Resources.icon_16x16
            NotifyIcon1.Text = "Minecraft存档备份"
            backup_animation.Close()
        End Try
    End Sub

    Private Sub 查看备份VToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 查看备份VToolStripMenuItem.Click
        view_backup.Show()
    End Sub

    Private Sub exit_btn_Click(sender As Object, e As EventArgs) Handles exit_btn.Click
        manage_config.Show()
    End Sub

    Private Sub about_btn_Click(sender As Object, e As EventArgs) Handles about_btn.Click
        about.Show()
    End Sub

    Private Sub autostart_checkbox_Click(sender As Object, e As EventArgs) Handles autostart_checkbox.Click
        On Error Resume Next
        If autostart_checkbox.Checked = True Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", Application.ProductName, Application.ExecutablePath)
        Else
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", Application.ProductName, "")
        End If
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        On Error Resume Next
        Me.Show()
    End Sub

    Private Sub delete_backup_checkbox_CheckedChanged(sender As Object, e As EventArgs) Handles delete_backup_checkbox.CheckedChanged
        If delete_backup_checkbox.Checked = True Then
            maxtotal_radiobutton.Enabled = True
            largestsize_radiobutton.Enabled = True
            If maxtotal_radiobutton.Checked = True Then
                maxtotal_NumericUpDown.Enabled = True
                largest_size_NumericUpDown.Enabled = False
            Else
                maxtotal_NumericUpDown.Enabled = False
                largest_size_NumericUpDown.Enabled = True
            End If
        Else
            maxtotal_radiobutton.Enabled = False
            largestsize_radiobutton.Enabled = False
            maxtotal_NumericUpDown.Enabled = False
            largest_size_NumericUpDown.Enabled = False
        End If
    End Sub

    Private Sub delete_backup_checkbox_Click(sender As Object, e As EventArgs) Handles delete_backup_checkbox.Click
        Call write_config()
    End Sub

    Private Sub maxtotal_radiobutton_Click(sender As Object, e As EventArgs) Handles maxtotal_radiobutton.Click
        Call write_config()
        maxtotal_NumericUpDown.Enabled = True
        largest_size_NumericUpDown.Enabled = False
    End Sub

    Private Sub largestsize_radiobutton_Click(sender As Object, e As EventArgs) Handles largestsize_radiobutton.Click
        Call write_config()
        maxtotal_NumericUpDown.Enabled = False
        largest_size_NumericUpDown.Enabled = True
    End Sub

    Private Sub maxtotal_NumericUpDown_Click(sender As Object, e As EventArgs) Handles maxtotal_NumericUpDown.Click
        Call write_config()
    End Sub

    Private Sub largest_size_NumericUpDown_Click(sender As Object, e As EventArgs) Handles largest_size_NumericUpDown.Click
        Call write_config()
    End Sub

    Private Sub largest_size_NumericUpDown_KeyUp(sender As Object, e As KeyEventArgs) Handles largest_size_NumericUpDown.KeyUp
        Call write_config()
    End Sub

    Private Sub maxtotal_NumericUpDown_KeyUp(sender As Object, e As KeyEventArgs) Handles maxtotal_NumericUpDown.KeyUp
        Call write_config()
    End Sub

    Private Sub RefreshInfoTimer_Tick(sender As Object, e As EventArgs) Handles RefreshInfoTimer.Tick
        refresh_info()
    End Sub

    Private Sub 自动备份AToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 自动备份AToolStripMenuItem.Click
        On Error Resume Next
        If 自动备份AToolStripMenuItem.Text = "关闭自动备份(&C)" Then
            自动备份AToolStripMenuItem.Text = "开启自动备份(&S)"
            automaticbackup_checkbox.Checked = False
            write_config()
        ElseIf 自动备份AToolStripMenuItem.Text = "开启自动备份(&S)" Then
            自动备份AToolStripMenuItem.Text = "关闭自动备份(&C)"
            automaticbackup_checkbox.Checked = True
            write_config()
        End If
    End Sub

    Private Sub show_backup_animation_CheckBox_Click(sender As Object, e As EventArgs) Handles show_backup_animation_CheckBox.Click
        write_config()
    End Sub

    Private Sub check_update_BackgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles check_update_BackgroundWorker.DoWork
        On Error Resume Next
        My.Computer.Network.DownloadFile("http://master.dl.sourceforge.net/project/minecraftsavesbackup/Release/version.ini", AppDomain.CurrentDomain.BaseDirectory & "version.ini", "", "", False, 100000, True, FileIO.UICancelOption.DoNothing)
        If My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "version.ini") > My.Application.Info.Version.ToString Then
            newupdate = True
        Else
            newupdate = False
        End If
    End Sub

    Private Sub check_update_BackgroundWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles check_update_BackgroundWorker.RunWorkerCompleted
        On Error Resume Next
        If newupdate = True Then
            online_update.newest_version_lbl.Text = "最新版本：" & My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "version.ini")
            online_update.Show()
        End If
    End Sub

    Private Sub level_TrackBar_MouseUp(sender As Object, e As MouseEventArgs) Handles level_TrackBar.MouseUp
        write_config()
    End Sub
End Class
