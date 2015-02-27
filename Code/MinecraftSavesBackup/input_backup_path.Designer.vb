<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class input_backup_path
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意:  以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(input_backup_path))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.browse_btn = New System.Windows.Forms.LinkLabel()
        Me.path_txtbox = New System.Windows.Forms.TextBox()
        Me.cancel_btn = New System.Windows.Forms.Button()
        Me.ok_btn = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(25, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(154, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "指定备份文件夹地址"
        '
        'browse_btn
        '
        Me.browse_btn.AutoSize = True
        Me.browse_btn.Location = New System.Drawing.Point(364, 136)
        Me.browse_btn.Name = "browse_btn"
        Me.browse_btn.Size = New System.Drawing.Size(44, 13)
        Me.browse_btn.TabIndex = 4
        Me.browse_btn.TabStop = True
        Me.browse_btn.Text = "浏览(&B)"
        '
        'path_txtbox
        '
        Me.path_txtbox.Location = New System.Drawing.Point(29, 133)
        Me.path_txtbox.Name = "path_txtbox"
        Me.path_txtbox.Size = New System.Drawing.Size(329, 20)
        Me.path_txtbox.TabIndex = 3
        '
        'cancel_btn
        '
        Me.cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cancel_btn.Location = New System.Drawing.Point(200, 243)
        Me.cancel_btn.Name = "cancel_btn"
        Me.cancel_btn.Size = New System.Drawing.Size(101, 31)
        Me.cancel_btn.TabIndex = 8
        Me.cancel_btn.Text = "返回(&R)"
        Me.cancel_btn.UseVisualStyleBackColor = True
        '
        'ok_btn
        '
        Me.ok_btn.Location = New System.Drawing.Point(307, 243)
        Me.ok_btn.Name = "ok_btn"
        Me.ok_btn.Size = New System.Drawing.Size(101, 31)
        Me.ok_btn.TabIndex = 7
        Me.ok_btn.Text = "确定(&O)"
        Me.ok_btn.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(27, 156)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(191, 12)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "请注意，备份文件夹内不得有其他文件/文件夹。"
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "指定备份文件夹地址："
        Me.FolderBrowserDialog1.SelectedPath = "saves_backup"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(29, 248)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(165, 20)
        Me.ProgressBar1.TabIndex = 10
        Me.ProgressBar1.Visible = False
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'input_backup_path
        '
        Me.AcceptButton = Me.ok_btn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.cancel_btn
        Me.ClientSize = New System.Drawing.Size(434, 286)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cancel_btn)
        Me.Controls.Add(Me.ok_btn)
        Me.Controls.Add(Me.browse_btn)
        Me.Controls.Add(Me.path_txtbox)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "input_backup_path"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "指定备份文件夹地址"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents browse_btn As System.Windows.Forms.LinkLabel
    Friend WithEvents path_txtbox As System.Windows.Forms.TextBox
    Friend WithEvents cancel_btn As System.Windows.Forms.Button
    Friend WithEvents ok_btn As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
