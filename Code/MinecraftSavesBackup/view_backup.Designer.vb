<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class view_backup
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(view_backup))
        Me.backup_lstbox = New System.Windows.Forms.ListBox()
        Me.backup_size_lbl = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.recovery_btn = New System.Windows.Forms.Button()
        Me.delete_btn = New System.Windows.Forms.Button()
        Me.out_btn = New System.Windows.Forms.Button()
        Me.in_btn = New System.Windows.Forms.Button()
        Me.backup_info_lbl = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.saves_lstbox = New System.Windows.Forms.CheckedListBox()
        Me.SuspendLayout()
        '
        'backup_lstbox
        '
        Me.backup_lstbox.FormattingEnabled = True
        Me.backup_lstbox.Location = New System.Drawing.Point(12, 25)
        Me.backup_lstbox.Name = "backup_lstbox"
        Me.backup_lstbox.Size = New System.Drawing.Size(175, 199)
        Me.backup_lstbox.TabIndex = 0
        '
        'backup_size_lbl
        '
        Me.backup_size_lbl.AutoSize = True
        Me.backup_size_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.backup_size_lbl.Location = New System.Drawing.Point(10, 228)
        Me.backup_size_lbl.Name = "backup_size_lbl"
        Me.backup_size_lbl.Size = New System.Drawing.Size(77, 12)
        Me.backup_size_lbl.TabIndex = 6
        Me.backup_size_lbl.Text = "备份总大小：0 MB"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "现有备份"
        '
        'recovery_btn
        '
        Me.recovery_btn.Enabled = False
        Me.recovery_btn.Location = New System.Drawing.Point(12, 282)
        Me.recovery_btn.Name = "recovery_btn"
        Me.recovery_btn.Size = New System.Drawing.Size(175, 32)
        Me.recovery_btn.TabIndex = 1
        Me.recovery_btn.Text = "恢复选定的存档(&R)"
        Me.recovery_btn.UseVisualStyleBackColor = True
        '
        'delete_btn
        '
        Me.delete_btn.Enabled = False
        Me.delete_btn.Location = New System.Drawing.Point(193, 282)
        Me.delete_btn.Name = "delete_btn"
        Me.delete_btn.Size = New System.Drawing.Size(175, 32)
        Me.delete_btn.TabIndex = 2
        Me.delete_btn.Text = "删除备份(&D)"
        Me.delete_btn.UseVisualStyleBackColor = True
        '
        'out_btn
        '
        Me.out_btn.Enabled = False
        Me.out_btn.Location = New System.Drawing.Point(12, 320)
        Me.out_btn.Name = "out_btn"
        Me.out_btn.Size = New System.Drawing.Size(175, 32)
        Me.out_btn.TabIndex = 3
        Me.out_btn.Text = "导出备份(&O)"
        Me.out_btn.UseVisualStyleBackColor = True
        '
        'in_btn
        '
        Me.in_btn.Location = New System.Drawing.Point(193, 320)
        Me.in_btn.Name = "in_btn"
        Me.in_btn.Size = New System.Drawing.Size(175, 32)
        Me.in_btn.TabIndex = 4
        Me.in_btn.Text = "导入备份(&I)"
        Me.in_btn.UseVisualStyleBackColor = True
        '
        'backup_info_lbl
        '
        Me.backup_info_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.backup_info_lbl.Location = New System.Drawing.Point(10, 240)
        Me.backup_info_lbl.Name = "backup_info_lbl"
        Me.backup_info_lbl.Size = New System.Drawing.Size(357, 40)
        Me.backup_info_lbl.TabIndex = 7
        Me.backup_info_lbl.Text = "创建时间:(选择一个备份)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "备份大小:(选择一个备份)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "备份地址:(选择一个备份)"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(190, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "包含的存档"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "*.backup"
        Me.SaveFileDialog1.FileName = "datatime.backup"
        Me.SaveFileDialog1.Filter = "备份文件(*.backup)|*.backup"
        Me.SaveFileDialog1.Title = "保存备份文件"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.DefaultExt = "*.backup"
        Me.OpenFileDialog1.FileName = "*.backup"
        Me.OpenFileDialog1.Filter = "备份文件(*.backup)|*.backup"
        Me.OpenFileDialog1.Title = "打开备份文件"
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'saves_lstbox
        '
        Me.saves_lstbox.CheckOnClick = True
        Me.saves_lstbox.FormattingEnabled = True
        Me.saves_lstbox.Location = New System.Drawing.Point(193, 25)
        Me.saves_lstbox.Name = "saves_lstbox"
        Me.saves_lstbox.Size = New System.Drawing.Size(175, 199)
        Me.saves_lstbox.TabIndex = 10
        '
        'view_backup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(381, 364)
        Me.Controls.Add(Me.saves_lstbox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.backup_info_lbl)
        Me.Controls.Add(Me.in_btn)
        Me.Controls.Add(Me.out_btn)
        Me.Controls.Add(Me.delete_btn)
        Me.Controls.Add(Me.recovery_btn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.backup_size_lbl)
        Me.Controls.Add(Me.backup_lstbox)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "view_backup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "查看备份"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents backup_lstbox As System.Windows.Forms.ListBox
    Friend WithEvents backup_size_lbl As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents recovery_btn As System.Windows.Forms.Button
    Friend WithEvents delete_btn As System.Windows.Forms.Button
    Friend WithEvents out_btn As System.Windows.Forms.Button
    Friend WithEvents in_btn As System.Windows.Forms.Button
    Friend WithEvents backup_info_lbl As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents saves_lstbox As System.Windows.Forms.CheckedListBox
End Class
