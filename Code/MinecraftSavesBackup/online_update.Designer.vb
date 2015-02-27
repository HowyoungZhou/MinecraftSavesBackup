<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class online_update
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(online_update))
        Me.now_version_lbl = New System.Windows.Forms.Label()
        Me.newest_version_lbl = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.update_btn = New System.Windows.Forms.Button()
        Me.cancel_btn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'now_version_lbl
        '
        Me.now_version_lbl.AutoSize = True
        Me.now_version_lbl.Location = New System.Drawing.Point(32, 46)
        Me.now_version_lbl.Name = "now_version_lbl"
        Me.now_version_lbl.Size = New System.Drawing.Size(94, 13)
        Me.now_version_lbl.TabIndex = 0
        Me.now_version_lbl.Text = "当前版本：0.0.0.0"
        '
        'newest_version_lbl
        '
        Me.newest_version_lbl.AutoSize = True
        Me.newest_version_lbl.Location = New System.Drawing.Point(147, 46)
        Me.newest_version_lbl.Name = "newest_version_lbl"
        Me.newest_version_lbl.Size = New System.Drawing.Size(94, 13)
        Me.newest_version_lbl.TabIndex = 1
        Me.newest_version_lbl.Text = "最新版本：0.0.0.0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(31, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 19)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "发现新版本！"
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(35, 83)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(364, 143)
        Me.WebBrowser1.TabIndex = 3
        Me.WebBrowser1.Url = New System.Uri("http://master.dl.sourceforge.net/project/minecraftsavesbackup/Release/update_log." & _
        "html", System.UriKind.Absolute)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "更新日志"
        '
        'update_btn
        '
        Me.update_btn.Location = New System.Drawing.Point(300, 243)
        Me.update_btn.Name = "update_btn"
        Me.update_btn.Size = New System.Drawing.Size(99, 29)
        Me.update_btn.TabIndex = 5
        Me.update_btn.Text = "立即更新(&U)"
        Me.update_btn.UseVisualStyleBackColor = True
        '
        'cancel_btn
        '
        Me.cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cancel_btn.Location = New System.Drawing.Point(195, 243)
        Me.cancel_btn.Name = "cancel_btn"
        Me.cancel_btn.Size = New System.Drawing.Size(99, 29)
        Me.cancel_btn.TabIndex = 6
        Me.cancel_btn.Text = "暂不更新(&C)"
        Me.cancel_btn.UseVisualStyleBackColor = True
        '
        'update
        '
        Me.AcceptButton = Me.update_btn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.cancel_btn
        Me.ClientSize = New System.Drawing.Size(436, 284)
        Me.Controls.Add(Me.cancel_btn)
        Me.Controls.Add(Me.update_btn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.newest_version_lbl)
        Me.Controls.Add(Me.now_version_lbl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "update"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "在线升级"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents now_version_lbl As System.Windows.Forms.Label
    Friend WithEvents newest_version_lbl As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents update_btn As System.Windows.Forms.Button
    Friend WithEvents cancel_btn As System.Windows.Forms.Button
End Class
