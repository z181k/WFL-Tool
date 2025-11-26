<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form14
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

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form14))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.快捷键返回BToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MSDT弃用说明 = New System.Windows.Forms.LinkLabel()
        Me.返回更多功能 = New System.Windows.Forms.LinkLabel()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(220, -5)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(189, 49)
        Me.Panel1.TabIndex = 113
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Font = New System.Drawing.Font("Microsoft YaHei UI", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.MenuStrip1.GripMargin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(28, 28)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.快捷键返回BToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(237, -5)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(11, 4, 0, 4)
        Me.MenuStrip1.Size = New System.Drawing.Size(107, 29)
        Me.MenuStrip1.TabIndex = 112
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '快捷键返回BToolStripMenuItem
        '
        Me.快捷键返回BToolStripMenuItem.Font = New System.Drawing.Font("Microsoft YaHei UI", 5.0!)
        Me.快捷键返回BToolStripMenuItem.Name = "快捷键返回BToolStripMenuItem"
        Me.快捷键返回BToolStripMenuItem.Size = New System.Drawing.Size(94, 21)
        Me.快捷键返回BToolStripMenuItem.Text = "快捷键返回&B"
        '
        'MSDT弃用说明
        '
        Me.MSDT弃用说明.ActiveLinkColor = System.Drawing.Color.DarkRed
        Me.MSDT弃用说明.AutoSize = True
        Me.MSDT弃用说明.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.MSDT弃用说明.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.MSDT弃用说明.LinkColor = System.Drawing.Color.Red
        Me.MSDT弃用说明.Location = New System.Drawing.Point(425, 7)
        Me.MSDT弃用说明.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.MSDT弃用说明.Name = "MSDT弃用说明"
        Me.MSDT弃用说明.Size = New System.Drawing.Size(566, 28)
        Me.MSDT弃用说明.TabIndex = 111
        Me.MSDT弃用说明.TabStop = True
        Me.MSDT弃用说明.Text = "MSDT 工具已弃用，请尽量不用这里的功能，点击了解更多"
        '
        '返回更多功能
        '
        Me.返回更多功能.ActiveLinkColor = System.Drawing.Color.DimGray
        Me.返回更多功能.AutoSize = True
        Me.返回更多功能.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.返回更多功能.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.返回更多功能.LinkColor = System.Drawing.SystemColors.InfoText
        Me.返回更多功能.Location = New System.Drawing.Point(22, 7)
        Me.返回更多功能.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.返回更多功能.Name = "返回更多功能"
        Me.返回更多功能.Size = New System.Drawing.Size(192, 28)
        Me.返回更多功能.TabIndex = 110
        Me.返回更多功能.TabStop = True
        Me.返回更多功能.Text = "◀ 返回更多功能 (B)"
        '
        'Form14
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1019, 509)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.MSDT弃用说明)
        Me.Controls.Add(Me.返回更多功能)
        Me.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form14"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MSDT 疑难解答 - WFL Tool (x64)"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 快捷键返回BToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MSDT弃用说明 As LinkLabel
    Friend WithEvents 返回更多功能 As LinkLabel
End Class
