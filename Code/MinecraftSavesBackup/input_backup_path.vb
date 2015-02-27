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
Imports System.IO
Imports System.IO.Compression

Public Class input_backup_path
    Dim HSXML As New HSXML
    Dim return_input_saves As Boolean = True

    Private Sub browse_btn_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles browse_btn.LinkClicked
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            path_txtbox.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub ok_btn_Click(sender As Object, e As EventArgs) Handles ok_btn.Click
        If path_txtbox.Text = Nothing Then
            MsgBox("您没有指定备份文件夹地址。", MsgBoxStyle.Exclamation, "提示")
        Else
            Try
                My.Computer.FileSystem.WriteAllText(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini", path_txtbox.Text, False)
                '加载备份文件夹地址
                main.backup_path_lbl.Text = "备份地址：" & My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory & "BackupPath.ini")
            Catch ex As Exception
                MsgBox("写入配置文件时出现错误：" & ex.Message, MsgBoxStyle.Critical, "错误")
            End Try
            Try
                return_input_saves = False
                If MsgBox("配置完成，要立即执行一次备份吗？", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "提示") = MsgBoxResult.Yes Then
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
                    Else
                        '备份过程
                        ProgressBar1.Visible = True
                        ProgressBar1.Value = 0
                        ok_btn.Enabled = False
                        ok_btn.Text = "等待..."
                        BackgroundWorker1.RunWorkerAsync()
                        '------
                    End If
                Else
                    Call main.mainshown()
                    main.Show()
                    Me.Close()
                End If
            Catch ex As Exception
                MsgBox("无法启动自动备份：" & ex.Message, MsgBoxStyle.Critical, "错误")
            End Try
        End If
    End Sub

    Private Sub cancel_btn_Click(sender As Object, e As EventArgs) Handles cancel_btn.Click
        input_saves.Show()
        Me.Close()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
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
                ZipFile.CreateFromDirectory(startPath, zipPath)
                BackgroundWorker1.ReportProgress(i / HSXML.Count(AppDomain.CurrentDomain.BaseDirectory & "BackupFolder.hsxml") * 100)
            Next
        Catch ex As Exception
            MsgBox("备份时出错：" & ex.Message, MsgBoxStyle.Critical, "错误")
            BackgroundWorker1.CancelAsync()
        End Try
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBar1.Value = Val(e.ProgressPercentage.ToString)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        On Error Resume Next
        ProgressBar1.Value = 100
        ProgressBar1.Visible = False
        ok_btn.Enabled = True
        ok_btn.Text = "确定(&O)"
        MsgBox("备份已完成。", MsgBoxStyle.Information, "提示")
        Call main.mainshown()
        main.Show()
        Me.Close()
    End Sub

    Private Sub input_backup_path_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If return_input_saves = True Then input_saves.Show()
    End Sub
End Class