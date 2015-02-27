<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class manage_config
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(manage_config))
        Me.config_lstbox = New System.Windows.Forms.ListBox()
        Me.out_btn = New System.Windows.Forms.Button()
        Me.in_btn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.clean_settings_btn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'config_lstbox
        '
        Me.config_lstbox.FormattingEnabled = True
        Me.config_lstbox.Items.AddRange(New Object() {"BackupFolder.hsxml", "BackupPath.ini", "Config.hsxml", "MD5.hsxml", "savesPath.ini"})
        Me.config_lstbox.Location = New System.Drawing.Point(12, 25)
        Me.config_lstbox.Name = "config_lstbox"
        Me.config_lstbox.Size = New System.Drawing.Size(222, 82)
        Me.config_lstbox.TabIndex = 0
        '
        'out_btn
        '
        Me.out_btn.Location = New System.Drawing.Point(126, 113)
        Me.out_btn.Name = "out_btn"
        Me.out_btn.Size = New System.Drawing.Size(108, 28)
        Me.out_btn.TabIndex = 1
        Me.out_btn.Text = "导出(&O)"
        Me.out_btn.UseVisualStyleBackColor = True
        '
        'in_btn
        '
        Me.in_btn.Location = New System.Drawing.Point(12, 113)
        Me.in_btn.Name = "in_btn"
        Me.in_btn.Size = New System.Drawing.Size(108, 28)
        Me.in_btn.TabIndex = 2
        Me.in_btn.Text = "导入(&I)"
        Me.in_btn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "配置文件"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.DefaultExt = "*.config"
        Me.OpenFileDialog1.FileName = "*.config"
        Me.OpenFileDialog1.Filter = "配置文件(*.config)|*.config"
        Me.OpenFileDialog1.Title = "导入设置"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "*.config"
        Me.SaveFileDialog1.FileName = "*.config"
        Me.SaveFileDialog1.Filter = "配置文件(*.config)|*.config"
        Me.SaveFileDialog1.Title = "导出设置"
        '
        'clean_settings_btn
        '
        Me.clean_settings_btn.Location = New System.Drawing.Point(12, 147)
        Me.clean_settings_btn.Name = "clean_settings_btn"
        Me.clean_settings_btn.Size = New System.Drawing.Size(222, 28)
        Me.clean_settings_btn.TabIndex = 4
        Me.clean_settings_btn.Text = "清除所有设置(&C)"
        Me.clean_settings_btn.UseVisualStyleBackColor = True
        '
        'manage_config
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(246, 184)
        Me.Controls.Add(Me.clean_settings_btn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.in_btn)
        Me.Controls.Add(Me.out_btn)
        Me.Controls.Add(Me.config_lstbox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "manage_config"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "导入/导出设置"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents config_lstbox As System.Windows.Forms.ListBox
    Friend WithEvents out_btn As System.Windows.Forms.Button
    Friend WithEvents in_btn As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents clean_settings_btn As System.Windows.Forms.Button
End Class
