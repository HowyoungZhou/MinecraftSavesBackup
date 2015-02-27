<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class input_saves
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(input_saves))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.path_txtbox = New System.Windows.Forms.TextBox()
        Me.browse_btn = New System.Windows.Forms.LinkLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.ok_btn = New System.Windows.Forms.Button()
        Me.cancel_btn = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.found_lstbox = New System.Windows.Forms.CheckedListBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(25, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "指定存档文件夹saves地址"
        '
        'path_txtbox
        '
        Me.path_txtbox.Location = New System.Drawing.Point(29, 68)
        Me.path_txtbox.Name = "path_txtbox"
        Me.path_txtbox.Size = New System.Drawing.Size(329, 20)
        Me.path_txtbox.TabIndex = 1
        '
        'browse_btn
        '
        Me.browse_btn.AutoSize = True
        Me.browse_btn.Location = New System.Drawing.Point(364, 71)
        Me.browse_btn.Name = "browse_btn"
        Me.browse_btn.Size = New System.Drawing.Size(44, 13)
        Me.browse_btn.TabIndex = 2
        Me.browse_btn.TabStop = True
        Me.browse_btn.Text = "浏览(&B)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "选择要备份的游戏存档"
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "指定存档文件夹saves地址："
        Me.FolderBrowserDialog1.SelectedPath = "saves"
        '
        'ok_btn
        '
        Me.ok_btn.Location = New System.Drawing.Point(307, 243)
        Me.ok_btn.Name = "ok_btn"
        Me.ok_btn.Size = New System.Drawing.Size(101, 31)
        Me.ok_btn.TabIndex = 5
        Me.ok_btn.Text = "确定(&O)"
        Me.ok_btn.UseVisualStyleBackColor = True
        '
        'cancel_btn
        '
        Me.cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cancel_btn.Location = New System.Drawing.Point(200, 243)
        Me.cancel_btn.Name = "cancel_btn"
        Me.cancel_btn.Size = New System.Drawing.Size(101, 31)
        Me.cancel_btn.TabIndex = 6
        Me.cancel_btn.Text = "取消(&C)"
        Me.cancel_btn.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(29, 248)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(165, 20)
        Me.ProgressBar1.TabIndex = 7
        Me.ProgressBar1.Visible = False
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(212, 31)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(64, 13)
        Me.LinkLabel1.TabIndex = 8
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "导入设置(&I)"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.DefaultExt = "*.config"
        Me.OpenFileDialog1.FileName = "*.config"
        Me.OpenFileDialog1.Filter = "配置文件(*.config)|*.config"
        Me.OpenFileDialog1.Title = "导入设置"
        '
        'found_lstbox
        '
        Me.found_lstbox.CheckOnClick = True
        Me.found_lstbox.FormattingEnabled = True
        Me.found_lstbox.Location = New System.Drawing.Point(29, 116)
        Me.found_lstbox.Name = "found_lstbox"
        Me.found_lstbox.Size = New System.Drawing.Size(379, 109)
        Me.found_lstbox.TabIndex = 9
        '
        'input_saves
        '
        Me.AcceptButton = Me.ok_btn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.cancel_btn
        Me.ClientSize = New System.Drawing.Size(434, 286)
        Me.Controls.Add(Me.found_lstbox)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.cancel_btn)
        Me.Controls.Add(Me.ok_btn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.browse_btn)
        Me.Controls.Add(Me.path_txtbox)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "input_saves"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "指定saves文件夹地址"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents path_txtbox As System.Windows.Forms.TextBox
    Friend WithEvents browse_btn As System.Windows.Forms.LinkLabel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ok_btn As System.Windows.Forms.Button
    Friend WithEvents cancel_btn As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents found_lstbox As System.Windows.Forms.CheckedListBox
End Class
