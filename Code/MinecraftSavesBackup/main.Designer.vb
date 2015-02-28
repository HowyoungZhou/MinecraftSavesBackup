<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(main))
        Me.AutomaticBackupTimer = New System.Windows.Forms.Timer(Me.components)
        Me.backup_BackgroundWorker = New System.ComponentModel.BackgroundWorker()
        Me.automaticbackup_checkbox = New System.Windows.Forms.CheckBox()
        Me.backup_interval_numericupdown = New System.Windows.Forms.NumericUpDown()
        Me.atsetintervals_radiobutton = New System.Windows.Forms.RadioButton()
        Me.backup_after_start_radiobutton = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.find_difference_radiobutton = New System.Windows.Forms.RadioButton()
        Me.always_backup_radiobutton = New System.Windows.Forms.RadioButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.find_difference_BackgroundWorker = New System.ComponentModel.BackgroundWorker()
        Me.backup_path_lbl = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.saves_lstbox = New System.Windows.Forms.ListBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.level_TrackBar = New System.Windows.Forms.TrackBar()
        Me.show_backup_animation_CheckBox = New System.Windows.Forms.CheckBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.largest_size_NumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.maxtotal_NumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.maxtotal_radiobutton = New System.Windows.Forms.RadioButton()
        Me.largestsize_radiobutton = New System.Windows.Forms.RadioButton()
        Me.delete_backup_checkbox = New System.Windows.Forms.CheckBox()
        Me.autostart_checkbox = New System.Windows.Forms.CheckBox()
        Me.next_start_lbl = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.about_btn = New System.Windows.Forms.Button()
        Me.exit_btn = New System.Windows.Forms.Button()
        Me.recovery_btn = New System.Windows.Forms.Button()
        Me.backup_btn = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.percent_lbl = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.state_lbl = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MinecraftToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.当前状态ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.打开主窗体OToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.立即备份BToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.自动备份AToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.查看备份VToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.退出EToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.NotifyIconTimer = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.backup_lstbox = New System.Windows.Forms.ListBox()
        Me.backup_size_lbl = New System.Windows.Forms.Label()
        Me.RefreshInfoTimer = New System.Windows.Forms.Timer(Me.components)
        Me.check_update_BackgroundWorker = New System.ComponentModel.BackgroundWorker()
        CType(Me.backup_interval_numericupdown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.level_TrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        CType(Me.largest_size_NumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.maxtotal_NumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.SuspendLayout()
        '
        'AutomaticBackupTimer
        '
        Me.AutomaticBackupTimer.Interval = 1800000
        '
        'backup_BackgroundWorker
        '
        Me.backup_BackgroundWorker.WorkerReportsProgress = True
        '
        'automaticbackup_checkbox
        '
        Me.automaticbackup_checkbox.AutoSize = True
        Me.automaticbackup_checkbox.Checked = True
        Me.automaticbackup_checkbox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.automaticbackup_checkbox.Location = New System.Drawing.Point(9, 19)
        Me.automaticbackup_checkbox.Name = "automaticbackup_checkbox"
        Me.automaticbackup_checkbox.Size = New System.Drawing.Size(74, 17)
        Me.automaticbackup_checkbox.TabIndex = 3
        Me.automaticbackup_checkbox.Text = "自动备份"
        Me.automaticbackup_checkbox.UseVisualStyleBackColor = True
        '
        'backup_interval_numericupdown
        '
        Me.backup_interval_numericupdown.Location = New System.Drawing.Point(54, 19)
        Me.backup_interval_numericupdown.Maximum = New Decimal(New Integer() {1440, 0, 0, 0})
        Me.backup_interval_numericupdown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.backup_interval_numericupdown.Name = "backup_interval_numericupdown"
        Me.backup_interval_numericupdown.Size = New System.Drawing.Size(51, 20)
        Me.backup_interval_numericupdown.TabIndex = 7
        Me.backup_interval_numericupdown.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'atsetintervals_radiobutton
        '
        Me.atsetintervals_radiobutton.AutoSize = True
        Me.atsetintervals_radiobutton.Checked = True
        Me.atsetintervals_radiobutton.Location = New System.Drawing.Point(6, 19)
        Me.atsetintervals_radiobutton.Name = "atsetintervals_radiobutton"
        Me.atsetintervals_radiobutton.Size = New System.Drawing.Size(49, 17)
        Me.atsetintervals_radiobutton.TabIndex = 4
        Me.atsetintervals_radiobutton.TabStop = True
        Me.atsetintervals_radiobutton.Text = "每隔"
        Me.atsetintervals_radiobutton.UseVisualStyleBackColor = True
        '
        'backup_after_start_radiobutton
        '
        Me.backup_after_start_radiobutton.AutoSize = True
        Me.backup_after_start_radiobutton.Location = New System.Drawing.Point(6, 47)
        Me.backup_after_start_radiobutton.Name = "backup_after_start_radiobutton"
        Me.backup_after_start_radiobutton.Size = New System.Drawing.Size(133, 17)
        Me.backup_after_start_radiobutton.TabIndex = 6
        Me.backup_after_start_radiobutton.Text = "开启软件后自动备份"
        Me.backup_after_start_radiobutton.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(108, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "分钟"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.backup_interval_numericupdown)
        Me.GroupBox4.Controls.Add(Me.atsetintervals_radiobutton)
        Me.GroupBox4.Controls.Add(Me.backup_after_start_radiobutton)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Location = New System.Drawing.Point(9, 42)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(145, 70)
        Me.GroupBox4.TabIndex = 11
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "自动备份时间"
        '
        'find_difference_radiobutton
        '
        Me.find_difference_radiobutton.AutoSize = True
        Me.find_difference_radiobutton.Checked = True
        Me.find_difference_radiobutton.Location = New System.Drawing.Point(6, 19)
        Me.find_difference_radiobutton.Name = "find_difference_radiobutton"
        Me.find_difference_radiobutton.Size = New System.Drawing.Size(97, 17)
        Me.find_difference_radiobutton.TabIndex = 7
        Me.find_difference_radiobutton.TabStop = True
        Me.find_difference_radiobutton.Text = "文件发生变动"
        Me.find_difference_radiobutton.UseVisualStyleBackColor = True
        '
        'always_backup_radiobutton
        '
        Me.always_backup_radiobutton.AutoSize = True
        Me.always_backup_radiobutton.Location = New System.Drawing.Point(6, 47)
        Me.always_backup_radiobutton.Name = "always_backup_radiobutton"
        Me.always_backup_radiobutton.Size = New System.Drawing.Size(73, 17)
        Me.always_backup_radiobutton.TabIndex = 8
        Me.always_backup_radiobutton.Text = "始终备份"
        Me.always_backup_radiobutton.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.find_difference_radiobutton)
        Me.GroupBox5.Controls.Add(Me.always_backup_radiobutton)
        Me.GroupBox5.Location = New System.Drawing.Point(166, 42)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(105, 70)
        Me.GroupBox5.TabIndex = 12
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "自动备份条件"
        '
        'find_difference_BackgroundWorker
        '
        Me.find_difference_BackgroundWorker.WorkerReportsProgress = True
        Me.find_difference_BackgroundWorker.WorkerSupportsCancellation = True
        '
        'backup_path_lbl
        '
        Me.backup_path_lbl.Location = New System.Drawing.Point(3, 108)
        Me.backup_path_lbl.Name = "backup_path_lbl"
        Me.backup_path_lbl.Size = New System.Drawing.Size(253, 30)
        Me.backup_path_lbl.TabIndex = 12
        Me.backup_path_lbl.Text = "备份地址："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "要备份的存档"
        '
        'saves_lstbox
        '
        Me.saves_lstbox.FormattingEnabled = True
        Me.saves_lstbox.Location = New System.Drawing.Point(6, 36)
        Me.saves_lstbox.Name = "saves_lstbox"
        Me.saves_lstbox.Size = New System.Drawing.Size(250, 69)
        Me.saves_lstbox.TabIndex = 11
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(66, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(31, 13)
        Me.LinkLabel1.TabIndex = 9
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "更改"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.level_TrackBar)
        Me.GroupBox2.Controls.Add(Me.show_backup_animation_CheckBox)
        Me.GroupBox2.Controls.Add(Me.GroupBox7)
        Me.GroupBox2.Controls.Add(Me.autostart_checkbox)
        Me.GroupBox2.Controls.Add(Me.next_start_lbl)
        Me.GroupBox2.Controls.Add(Me.GroupBox6)
        Me.GroupBox2.Controls.Add(Me.GroupBox5)
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.automaticbackup_checkbox)
        Me.GroupBox2.Location = New System.Drawing.Point(298, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(280, 424)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "设置"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(219, 406)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "最大压缩"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 406)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "无压缩"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 358)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "压缩等级"
        '
        'level_TrackBar
        '
        Me.level_TrackBar.Location = New System.Drawing.Point(9, 374)
        Me.level_TrackBar.Maximum = 9
        Me.level_TrackBar.Minimum = 1
        Me.level_TrackBar.Name = "level_TrackBar"
        Me.level_TrackBar.Size = New System.Drawing.Size(262, 45)
        Me.level_TrackBar.TabIndex = 18
        Me.level_TrackBar.Value = 5
        '
        'show_backup_animation_CheckBox
        '
        Me.show_backup_animation_CheckBox.AutoSize = True
        Me.show_backup_animation_CheckBox.Checked = True
        Me.show_backup_animation_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.show_backup_animation_CheckBox.Location = New System.Drawing.Point(176, 19)
        Me.show_backup_animation_CheckBox.Name = "show_backup_animation_CheckBox"
        Me.show_backup_animation_CheckBox.Size = New System.Drawing.Size(98, 17)
        Me.show_backup_animation_CheckBox.TabIndex = 17
        Me.show_backup_animation_CheckBox.Text = "显示备份动画"
        Me.show_backup_animation_CheckBox.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.largest_size_NumericUpDown)
        Me.GroupBox7.Controls.Add(Me.Label4)
        Me.GroupBox7.Controls.Add(Me.Label3)
        Me.GroupBox7.Controls.Add(Me.maxtotal_NumericUpDown)
        Me.GroupBox7.Controls.Add(Me.maxtotal_radiobutton)
        Me.GroupBox7.Controls.Add(Me.largestsize_radiobutton)
        Me.GroupBox7.Controls.Add(Me.delete_backup_checkbox)
        Me.GroupBox7.Location = New System.Drawing.Point(9, 118)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(262, 90)
        Me.GroupBox7.TabIndex = 16
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "自动删除备份"
        '
        'largest_size_NumericUpDown
        '
        Me.largest_size_NumericUpDown.Enabled = False
        Me.largest_size_NumericUpDown.Location = New System.Drawing.Point(102, 65)
        Me.largest_size_NumericUpDown.Maximum = New Decimal(New Integer() {1440, 0, 0, 0})
        Me.largest_size_NumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.largest_size_NumericUpDown.Name = "largest_size_NumericUpDown"
        Me.largest_size_NumericUpDown.Size = New System.Drawing.Size(51, 20)
        Me.largest_size_NumericUpDown.TabIndex = 17
        Me.largest_size_NumericUpDown.Value = New Decimal(New Integer() {50, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(159, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "MB"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(159, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(19, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "个"
        '
        'maxtotal_NumericUpDown
        '
        Me.maxtotal_NumericUpDown.Enabled = False
        Me.maxtotal_NumericUpDown.Location = New System.Drawing.Point(102, 42)
        Me.maxtotal_NumericUpDown.Maximum = New Decimal(New Integer() {1440, 0, 0, 0})
        Me.maxtotal_NumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.maxtotal_NumericUpDown.Name = "maxtotal_NumericUpDown"
        Me.maxtotal_NumericUpDown.Size = New System.Drawing.Size(51, 20)
        Me.maxtotal_NumericUpDown.TabIndex = 9
        Me.maxtotal_NumericUpDown.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'maxtotal_radiobutton
        '
        Me.maxtotal_radiobutton.AutoSize = True
        Me.maxtotal_radiobutton.Checked = True
        Me.maxtotal_radiobutton.Enabled = False
        Me.maxtotal_radiobutton.Location = New System.Drawing.Point(6, 42)
        Me.maxtotal_radiobutton.Name = "maxtotal_radiobutton"
        Me.maxtotal_radiobutton.Size = New System.Drawing.Size(97, 17)
        Me.maxtotal_radiobutton.TabIndex = 7
        Me.maxtotal_radiobutton.TabStop = True
        Me.maxtotal_radiobutton.Text = "备份总数最多"
        Me.maxtotal_radiobutton.UseVisualStyleBackColor = True
        '
        'largestsize_radiobutton
        '
        Me.largestsize_radiobutton.AutoSize = True
        Me.largestsize_radiobutton.Enabled = False
        Me.largestsize_radiobutton.Location = New System.Drawing.Point(6, 65)
        Me.largestsize_radiobutton.Name = "largestsize_radiobutton"
        Me.largestsize_radiobutton.Size = New System.Drawing.Size(97, 17)
        Me.largestsize_radiobutton.TabIndex = 8
        Me.largestsize_radiobutton.Text = "总大小不超过"
        Me.largestsize_radiobutton.UseVisualStyleBackColor = True
        '
        'delete_backup_checkbox
        '
        Me.delete_backup_checkbox.AutoSize = True
        Me.delete_backup_checkbox.Location = New System.Drawing.Point(6, 19)
        Me.delete_backup_checkbox.Name = "delete_backup_checkbox"
        Me.delete_backup_checkbox.Size = New System.Drawing.Size(146, 17)
        Me.delete_backup_checkbox.TabIndex = 0
        Me.delete_backup_checkbox.Text = "启用自动删除备份功能"
        Me.delete_backup_checkbox.UseVisualStyleBackColor = True
        '
        'autostart_checkbox
        '
        Me.autostart_checkbox.AutoSize = True
        Me.autostart_checkbox.Location = New System.Drawing.Point(81, 19)
        Me.autostart_checkbox.Name = "autostart_checkbox"
        Me.autostart_checkbox.Size = New System.Drawing.Size(98, 17)
        Me.autostart_checkbox.TabIndex = 15
        Me.autostart_checkbox.Text = "开机自动启动"
        Me.autostart_checkbox.UseVisualStyleBackColor = True
        '
        'next_start_lbl
        '
        Me.next_start_lbl.AutoSize = True
        Me.next_start_lbl.ForeColor = System.Drawing.Color.Gray
        Me.next_start_lbl.Location = New System.Drawing.Point(42, 0)
        Me.next_start_lbl.Name = "next_start_lbl"
        Me.next_start_lbl.Size = New System.Drawing.Size(67, 13)
        Me.next_start_lbl.TabIndex = 14
        Me.next_start_lbl.Text = "配置已生效"
        Me.next_start_lbl.Visible = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.backup_path_lbl)
        Me.GroupBox6.Controls.Add(Me.Label1)
        Me.GroupBox6.Controls.Add(Me.saves_lstbox)
        Me.GroupBox6.Controls.Add(Me.LinkLabel1)
        Me.GroupBox6.Location = New System.Drawing.Point(9, 214)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(262, 141)
        Me.GroupBox6.TabIndex = 13
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "备份设置"
        '
        'about_btn
        '
        Me.about_btn.Location = New System.Drawing.Point(143, 55)
        Me.about_btn.Name = "about_btn"
        Me.about_btn.Size = New System.Drawing.Size(128, 30)
        Me.about_btn.TabIndex = 16
        Me.about_btn.Text = "关于(&A)"
        Me.ToolTip1.SetToolTip(Me.about_btn, "关于软件")
        Me.about_btn.UseVisualStyleBackColor = True
        '
        'exit_btn
        '
        Me.exit_btn.Location = New System.Drawing.Point(9, 55)
        Me.exit_btn.Name = "exit_btn"
        Me.exit_btn.Size = New System.Drawing.Size(128, 30)
        Me.exit_btn.TabIndex = 15
        Me.exit_btn.Text = "管理设置(&M)"
        Me.ToolTip1.SetToolTip(Me.exit_btn, "导入、导出或清除所有设置")
        Me.exit_btn.UseVisualStyleBackColor = True
        '
        'recovery_btn
        '
        Me.recovery_btn.Location = New System.Drawing.Point(143, 19)
        Me.recovery_btn.Name = "recovery_btn"
        Me.recovery_btn.Size = New System.Drawing.Size(128, 30)
        Me.recovery_btn.TabIndex = 14
        Me.recovery_btn.Text = "查看备份(&V)"
        Me.ToolTip1.SetToolTip(Me.recovery_btn, "查看、导入、导出及恢复备份")
        Me.recovery_btn.UseVisualStyleBackColor = True
        '
        'backup_btn
        '
        Me.backup_btn.Location = New System.Drawing.Point(9, 19)
        Me.backup_btn.Name = "backup_btn"
        Me.backup_btn.Size = New System.Drawing.Size(128, 30)
        Me.backup_btn.TabIndex = 13
        Me.backup_btn.Text = "立即备份(&B)"
        Me.ToolTip1.SetToolTip(Me.backup_btn, "立即执行一次备份")
        Me.backup_btn.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.about_btn)
        Me.GroupBox3.Controls.Add(Me.exit_btn)
        Me.GroupBox3.Controls.Add(Me.recovery_btn)
        Me.GroupBox3.Controls.Add(Me.backup_btn)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 338)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(280, 98)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "操作"
        '
        'percent_lbl
        '
        Me.percent_lbl.AutoSize = True
        Me.percent_lbl.Location = New System.Drawing.Point(202, 23)
        Me.percent_lbl.Name = "percent_lbl"
        Me.percent_lbl.Size = New System.Drawing.Size(57, 13)
        Me.percent_lbl.TabIndex = 1
        Me.percent_lbl.Text = "已完成0%"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(9, 40)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(262, 20)
        Me.ProgressBar1.TabIndex = 2
        '
        'state_lbl
        '
        Me.state_lbl.AutoSize = True
        Me.state_lbl.Location = New System.Drawing.Point(6, 23)
        Me.state_lbl.Name = "state_lbl"
        Me.state_lbl.Size = New System.Drawing.Size(145, 13)
        Me.state_lbl.TabIndex = 0
        Me.state_lbl.Text = "当前状态：等待下一次备份"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.percent_lbl)
        Me.GroupBox1.Controls.Add(Me.ProgressBar1)
        Me.GroupBox1.Controls.Add(Me.state_lbl)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 75)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "状态"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Minecraft存档备份"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MinecraftToolStripMenuItem, Me.ToolStripSeparator1, Me.当前状态ToolStripMenuItem, Me.ToolStripSeparator2, Me.打开主窗体OToolStripMenuItem, Me.立即备份BToolStripMenuItem, Me.自动备份AToolStripMenuItem, Me.查看备份VToolStripMenuItem, Me.退出EToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(231, 170)
        '
        'MinecraftToolStripMenuItem
        '
        Me.MinecraftToolStripMenuItem.Enabled = False
        Me.MinecraftToolStripMenuItem.Name = "MinecraftToolStripMenuItem"
        Me.MinecraftToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.MinecraftToolStripMenuItem.Text = "Minecraft存档备份"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(227, 6)
        '
        '当前状态ToolStripMenuItem
        '
        Me.当前状态ToolStripMenuItem.Enabled = False
        Me.当前状态ToolStripMenuItem.Name = "当前状态ToolStripMenuItem"
        Me.当前状态ToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.当前状态ToolStripMenuItem.Text = "当前状态：等待下一次备份"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(227, 6)
        '
        '打开主窗体OToolStripMenuItem
        '
        Me.打开主窗体OToolStripMenuItem.Name = "打开主窗体OToolStripMenuItem"
        Me.打开主窗体OToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.打开主窗体OToolStripMenuItem.Text = "打开主窗体(&O)"
        '
        '立即备份BToolStripMenuItem
        '
        Me.立即备份BToolStripMenuItem.Name = "立即备份BToolStripMenuItem"
        Me.立即备份BToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.立即备份BToolStripMenuItem.Text = "立即备份(&B)"
        '
        '自动备份AToolStripMenuItem
        '
        Me.自动备份AToolStripMenuItem.Name = "自动备份AToolStripMenuItem"
        Me.自动备份AToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.自动备份AToolStripMenuItem.Text = "关闭/开启自动备份(&C)"
        '
        '查看备份VToolStripMenuItem
        '
        Me.查看备份VToolStripMenuItem.Name = "查看备份VToolStripMenuItem"
        Me.查看备份VToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.查看备份VToolStripMenuItem.Text = "查看备份(&V)"
        '
        '退出EToolStripMenuItem
        '
        Me.退出EToolStripMenuItem.Name = "退出EToolStripMenuItem"
        Me.退出EToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.退出EToolStripMenuItem.Text = "退出(&E)"
        '
        'NotifyIconTimer
        '
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.backup_lstbox)
        Me.GroupBox8.Controls.Add(Me.backup_size_lbl)
        Me.GroupBox8.Location = New System.Drawing.Point(12, 93)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(280, 239)
        Me.GroupBox8.TabIndex = 6
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "现有备份"
        '
        'backup_lstbox
        '
        Me.backup_lstbox.FormattingEnabled = True
        Me.backup_lstbox.Location = New System.Drawing.Point(6, 21)
        Me.backup_lstbox.Name = "backup_lstbox"
        Me.backup_lstbox.Size = New System.Drawing.Size(268, 186)
        Me.backup_lstbox.TabIndex = 1
        '
        'backup_size_lbl
        '
        Me.backup_size_lbl.AutoSize = True
        Me.backup_size_lbl.Location = New System.Drawing.Point(3, 216)
        Me.backup_size_lbl.Name = "backup_size_lbl"
        Me.backup_size_lbl.Size = New System.Drawing.Size(98, 13)
        Me.backup_size_lbl.TabIndex = 0
        Me.backup_size_lbl.Text = "备份总大小：0 MB"
        '
        'RefreshInfoTimer
        '
        Me.RefreshInfoTimer.Enabled = True
        Me.RefreshInfoTimer.Interval = 1000
        '
        'check_update_BackgroundWorker
        '
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(590, 448)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Minecraft存档备份"
        CType(Me.backup_interval_numericupdown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.level_TrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.largest_size_NumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.maxtotal_NumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AutomaticBackupTimer As System.Windows.Forms.Timer
    Friend WithEvents backup_BackgroundWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents automaticbackup_checkbox As System.Windows.Forms.CheckBox
    Friend WithEvents backup_interval_numericupdown As System.Windows.Forms.NumericUpDown
    Friend WithEvents atsetintervals_radiobutton As System.Windows.Forms.RadioButton
    Friend WithEvents backup_after_start_radiobutton As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents find_difference_radiobutton As System.Windows.Forms.RadioButton
    Friend WithEvents always_backup_radiobutton As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents find_difference_BackgroundWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents backup_path_lbl As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents saves_lstbox As System.Windows.Forms.ListBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents about_btn As System.Windows.Forms.Button
    Friend WithEvents exit_btn As System.Windows.Forms.Button
    Friend WithEvents recovery_btn As System.Windows.Forms.Button
    Friend WithEvents backup_btn As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents percent_lbl As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents state_lbl As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents next_start_lbl As System.Windows.Forms.Label
    Friend WithEvents NotifyIconTimer As System.Windows.Forms.Timer
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MinecraftToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 打开主窗体OToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 立即备份BToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 查看备份VToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 退出EToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 当前状态ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents autostart_checkbox As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents delete_backup_checkbox As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents largest_size_NumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents maxtotal_NumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents maxtotal_radiobutton As System.Windows.Forms.RadioButton
    Friend WithEvents largestsize_radiobutton As System.Windows.Forms.RadioButton
    Friend WithEvents backup_lstbox As System.Windows.Forms.ListBox
    Friend WithEvents backup_size_lbl As System.Windows.Forms.Label
    Friend WithEvents RefreshInfoTimer As System.Windows.Forms.Timer
    Friend WithEvents 自动备份AToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents show_backup_animation_CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents check_update_BackgroundWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents level_TrackBar As System.Windows.Forms.TrackBar
End Class
