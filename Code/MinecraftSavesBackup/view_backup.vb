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
Imports MinecraftSavesBackup.Compression
Imports System.Security.Cryptography

Public Class view_backup
    Dim HSXML As New HSXML
    Dim errorhappend As Boolean = False

    Private Function GetFolderSize(ByVal Folder As String) As String
        On Error Resume Next
        Dim size As Long
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(Folder, FileIO.SearchOption.SearchAllSubDirectories, "*.*")
            size = size + My.Computer.FileSystem.GetFileInfo(foundFile).Length
        Next
        Dim mbsize As String = CStr(Decimal.Round(CDec(size / 1024 / 1024), 2)) & " MB"
        Return mbsize
    End Function

    Private Sub RefreshInfo()
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
        backup_size_lbl.Text = "备份总大小：" & GetFolderSize(My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini"))
        '检测并锁定按钮
        If backup_lstbox.Items.Count = 0 Then
            recovery_btn.Enabled = False
            delete_btn.Enabled = False
            out_btn.Enabled = False
            backup_info_lbl.Text = "创建时间:(选择一个备份)" & vbCrLf & "备份大小:(选择一个备份)" & vbCrLf & "备份地址:(选择一个备份)"
        End If
    End Sub

    Private Sub view_backup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "BackupFolder.hsxml") = False Then
            MsgBox("配置文件(BackupFolder.hsxml)丢失，请重新配置！", MsgBoxStyle.Exclamation, "提示")
            input_saves.Show()
            Me.Close()
            Exit Sub
        ElseIf My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini") = False Then
            MsgBox("配置文件(BackupPath.ini)丢失，请重新配置！", MsgBoxStyle.Exclamation, "提示")
            input_saves.Show()
            Me.Close()
            Exit Sub
        ElseIf My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "MD5.hsxml") = False Then
            MsgBox("配置文件(MD5.hsxml)丢失，请重新配置！", MsgBoxStyle.Exclamation, "提示")
            input_saves.Show()
            Me.Close()
            Exit Sub
        ElseIf My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "savesPath.ini") = False Then
            MsgBox("配置文件(savesPath.ini)丢失，请重新配置！", MsgBoxStyle.Exclamation, "提示")
            input_saves.Show()
            Me.Close()
            Exit Sub
        Else
            RefreshInfo()
        End If
    End Sub

    Private Sub backup_lstbox_Click(sender As Object, e As EventArgs) Handles backup_lstbox.Click
        On Error Resume Next
        If backup_lstbox.SelectedItem <> Nothing Then
            Dim backuppath As String
            recovery_btn.Enabled = True
            delete_btn.Enabled = True
            out_btn.Enabled = True
            If Strings.Right(My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini"), 1) = "\" Then
                backuppath = My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini") & backup_lstbox.SelectedItem
            Else
                backuppath = My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini") & "\" & backup_lstbox.SelectedItem
            End If
            If Strings.Right(backuppath, 1) <> "\" Then backuppath = backuppath & "\"
            backup_info_lbl.Text = "创建时间:" & My.Computer.FileSystem.GetDirectoryInfo(backuppath).CreationTime & vbCrLf & "备份大小:" & GetFolderSize(backuppath) & vbCrLf & "备份地址:" & backuppath
            saves_lstbox.Items.Clear()
            For Each foundFile As String In My.Computer.FileSystem.GetFiles(backuppath, FileIO.SearchOption.SearchAllSubDirectories, "*.*")
                saves_lstbox.Items.Add(foundFile.Replace(backuppath, Nothing))
            Next
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        RefreshInfo()
    End Sub

    Private Sub delete_btn_Click(sender As Object, e As EventArgs) Handles delete_btn.Click
        If MsgBox("您确定要删除备份吗？", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "确认") = MsgBoxResult.Ok Then
            Try
                Dim backuppath As String
                If Strings.Right(My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini"), 1) = "\" Then
                    backuppath = My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini") & backup_lstbox.SelectedItem
                Else
                    backuppath = My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini") & "\" & backup_lstbox.SelectedItem
                End If
                If Strings.Right(backuppath, 1) <> "\" Then backuppath = backuppath & "\"
                If My.Computer.FileSystem.DirectoryExists(backuppath) Then My.Computer.FileSystem.DeleteDirectory(backuppath, FileIO.DeleteDirectoryOption.DeleteAllContents)
                '更新信息
                backup_lstbox.SelectedIndex = 0
                RefreshInfo()
                If Strings.Right(My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini"), 1) = "\" Then
                    backuppath = My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini") & backup_lstbox.SelectedItem
                Else
                    backuppath = My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini") & "\" & backup_lstbox.SelectedItem
                End If
                If Strings.Right(backuppath, 1) <> "\" Then backuppath = backuppath & "\"
                backup_info_lbl.Text = "创建时间:" & My.Computer.FileSystem.GetDirectoryInfo(backuppath).CreationTime & vbCrLf & "备份大小:" & GetFolderSize(backuppath) & vbCrLf & "备份地址:" & backuppath
                saves_lstbox.Items.Clear()
                For Each foundFile As String In My.Computer.FileSystem.GetFiles(backuppath, FileIO.SearchOption.SearchAllSubDirectories, "*.*")
                    saves_lstbox.Items.Add(foundFile.Replace(backuppath, Nothing))
                Next
            Catch ex As Exception
                MsgBox("删除备份时出现错误：" & ex.Message, MsgBoxStyle.Critical, "错误")
            End Try
        End If
    End Sub

    Private Sub recovery_btn_Click(sender As Object, e As EventArgs) Handles recovery_btn.Click
        Try
            If saves_lstbox.CheckedItems.Count = 0 Then
                MsgBox("请选择您要恢复的游戏存档。", MsgBoxStyle.Exclamation, "提示")
            Else
                recovery_btn.Enabled = False
                recovery_btn.Text = "正在恢复(0%)"
                For i = 0 To saves_lstbox.CheckedItems.Count - 1
                    Dim backuppath As String
                    If Strings.Right(My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini"), 1) = "\" Then
                        backuppath = My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini") & backup_lstbox.SelectedItem
                    Else
                        backuppath = My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini") & "\" & backup_lstbox.SelectedItem
                    End If
                    If Strings.Right(backuppath, 1) <> "\" Then backuppath = backuppath & "\"
                    Dim zipPath As String = backuppath & saves_lstbox.CheckedItems.Item(i)
                    Dim savespath As String = My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "savesPath.ini")
                    If Strings.Right(savespath, 1) <> "\" Then savespath = savespath & "\"
                    Dim extractPath As String = savespath & CStr(saves_lstbox.CheckedItems.Item(i)).Replace(".saves", Nothing)
                    If My.Computer.FileSystem.DirectoryExists(extractPath) Then My.Computer.FileSystem.DeleteDirectory(extractPath, FileIO.DeleteDirectoryOption.DeleteAllContents)
                    My.Computer.FileSystem.CreateDirectory(extractPath)
                    DecompressZip(zipPath, extractPath)
                    Dim percent As Decimal = i + 1 / saves_lstbox.CheckedItems.Count * 100
                    recovery_btn.Text = "正在恢复(" & CStr(percent) & "%)"
                Next
                recovery_btn.Text = "正在恢复(50%)"
                errorhappend = False
                BackgroundWorker1.RunWorkerAsync()
            End If
        Catch ex As Exception
            MsgBox("无法恢复存档：" & ex.Message, MsgBoxStyle.Critical, "错误")
            recovery_btn.Enabled = True
            recovery_btn.Text = "恢复选定的存档(&R)"
        End Try
    End Sub

    Private Sub out_btn_Click(sender As Object, e As EventArgs) Handles out_btn.Click
        Try
            SaveFileDialog1.FileName = backup_lstbox.SelectedItem & ".backup"
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim backuppath As String
                If Strings.Right(My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini"), 1) = "\" Then
                    backuppath = My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini") & backup_lstbox.SelectedItem
                Else
                    backuppath = My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini") & "\" & backup_lstbox.SelectedItem
                End If
                Dim startPath As String = backuppath
                Dim zipPath As String = SaveFileDialog1.FileName
                CompressFolder(startPath, zipPath, 1)
                MsgBox("成功导出备份。", MsgBoxStyle.Information, "提示")
            End If
        Catch ex As Exception
            MsgBox("导出备份时出现错误：" & ex.Message, MsgBoxStyle.Critical, "错误")
        End Try
    End Sub

    Private Sub in_btn_Click(sender As Object, e As EventArgs) Handles in_btn.Click
        Try
            If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim zipPath As String = OpenFileDialog1.FileName
                Dim backuppath As String
                If Strings.Right(My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini"), 1) = "\" Then
                    backuppath = My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini") & OpenFileDialog1.SafeFileName.Replace(".backup", Nothing)
                Else
                    backuppath = My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini") & "\" & OpenFileDialog1.SafeFileName.Replace(".backup", Nothing)
                End If
                DecompressZip(zipPath, backuppath)
                RefreshInfo()
                MsgBox("成功导入备份。", MsgBoxStyle.Information, "提示")
            End If
        Catch ex As Exception
            MsgBox("导入备份时出现错误：" & ex.Message, MsgBoxStyle.Critical, "错误")
        End Try
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
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
                Dim percent As Decimal = i / HSXML.Count(AppDomain.CurrentDomain.BaseDirectory & "BackupFolder.hsxml") * 50 + 50
                BackgroundWorker1.ReportProgress(Decimal.Round(percent, 0))
            Next
            BackgroundWorker1.ReportProgress(Decimal.Round(100, 0))
        Catch ex As Exception
            MsgBox("恢复存档时出现错误：" & ex.Message, MsgBoxStyle.Critical, "错误")
            BackgroundWorker1.CancelAsync()
            errorhappend = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        recovery_btn.Text = "正在恢复(" & e.ProgressPercentage.ToString & "%)"
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        recovery_btn.Enabled = True
        recovery_btn.Text = "恢复选定的存档(&R)"
        If errorhappend = False Then MsgBox("已完成恢复。", MsgBoxStyle.Information, "提示")
    End Sub
End Class