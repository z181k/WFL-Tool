<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form9
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form9))
        Label1 = New Label()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        打开主界面ToolStripMenuItem = New ToolStripMenuItem()
        ToolStripMenuItem1 = New ToolStripSeparator()
        退出程序ToolStripMenuItem = New ToolStripMenuItem()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        LinkLabel1 = New LinkLabel()
        LinkLabel2 = New LinkLabel()
        LinkLabel3 = New LinkLabel()
        LinkLabel4 = New LinkLabel()
        LinkLabel6 = New LinkLabel()
        ContextMenuStrip2 = New ContextMenuStrip(components)
        检查更新ToolStripMenuItem = New ToolStripMenuItem()
        ToolStripMenuItem2 = New ToolStripSeparator()
        应急下载链接ToolStripMenuItem = New ToolStripMenuItem()
        Label5 = New Label()
        LinkLabel7 = New LinkLabel()
        LinkLabel8 = New LinkLabel()
        LinkLabel9 = New LinkLabel()
        LinkLabel5 = New LinkLabel()
        Label6 = New Label()
        PictureBox1 = New PictureBox()
        LinkLabel10 = New LinkLabel()
        FeatureControlLabel1 = New Label()
        ContextMenuStrip1.SuspendLayout()
        ContextMenuStrip2.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.ContextMenuStrip = ContextMenuStrip1
        Label1.Font = New Font("微软雅黑", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        Label1.Location = New Point(45, 206)
        Label1.Margin = New Padding(6, 0, 6, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(176, 46)
        Label1.TabIndex = 1
        Label1.Text = "WFL Tool"
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.ImageScalingSize = New Size(20, 20)
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {打开主界面ToolStripMenuItem, ToolStripMenuItem1, 退出程序ToolStripMenuItem})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(169, 78)
        ' 
        ' 打开主界面ToolStripMenuItem
        ' 
        打开主界面ToolStripMenuItem.Name = "打开主界面ToolStripMenuItem"
        打开主界面ToolStripMenuItem.Size = New Size(168, 34)
        打开主界面ToolStripMenuItem.Text = "打开主页"
        ' 
        ' ToolStripMenuItem1
        ' 
        ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        ToolStripMenuItem1.Size = New Size(165, 6)
        ' 
        ' 退出程序ToolStripMenuItem
        ' 
        退出程序ToolStripMenuItem.Name = "退出程序ToolStripMenuItem"
        退出程序ToolStripMenuItem.Size = New Size(168, 34)
        退出程序ToolStripMenuItem.Text = "退出程序"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.ContextMenuStrip = ContextMenuStrip1
        Label2.Font = New Font("Microsoft YaHei UI Light", 7.714286F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        Label2.ForeColor = SystemColors.ControlDark
        Label2.Location = New Point(54, 250)
        Label2.Margin = New Padding(6, 0, 6, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(159, 24)
        Label2.TabIndex = 2
        Label2.Text = "方便快捷 一点即达"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.ContextMenuStrip = ContextMenuStrip1
        Label3.Font = New Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        Label3.ForeColor = SystemColors.ControlDarkDark
        Label3.Location = New Point(72, 352)
        Label3.Margin = New Padding(6, 0, 6, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(122, 32)
        Label3.TabIndex = 3
        Label3.Text = "版本 16.0"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.ContextMenuStrip = ContextMenuStrip1
        Label4.Font = New Font("微软雅黑", 7.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        Label4.ForeColor = SystemColors.ControlDark
        Label4.Location = New Point(74, 388)
        Label4.Margin = New Padding(6, 0, 6, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(118, 24)
        Label4.TabIndex = 4
        Label4.Text = "Build 9584.1"
        ' 
        ' LinkLabel1
        ' 
        LinkLabel1.ActiveLinkColor = Color.DarkRed
        LinkLabel1.AutoSize = True
        LinkLabel1.Font = New Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        LinkLabel1.LinkBehavior = LinkBehavior.HoverUnderline
        LinkLabel1.LinkColor = Color.FromArgb(CByte(132), CByte(117), CByte(213))
        LinkLabel1.Location = New Point(282, 392)
        LinkLabel1.Margin = New Padding(6, 0, 6, 0)
        LinkLabel1.Name = "LinkLabel1"
        LinkLabel1.Size = New Size(96, 28)
        LinkLabel1.TabIndex = 7
        LinkLabel1.TabStop = True
        LinkLabel1.Text = "更新日志"
        ' 
        ' LinkLabel2
        ' 
        LinkLabel2.ActiveLinkColor = Color.DarkRed
        LinkLabel2.AutoSize = True
        LinkLabel2.Font = New Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        LinkLabel2.LinkBehavior = LinkBehavior.HoverUnderline
        LinkLabel2.LinkColor = Color.FromArgb(CByte(132), CByte(117), CByte(213))
        LinkLabel2.Location = New Point(396, 392)
        LinkLabel2.Margin = New Padding(6, 0, 6, 0)
        LinkLabel2.Name = "LinkLabel2"
        LinkLabel2.Size = New Size(96, 28)
        LinkLabel2.TabIndex = 8
        LinkLabel2.TabStop = True
        LinkLabel2.Text = "版本声明"
        ' 
        ' LinkLabel3
        ' 
        LinkLabel3.ActiveLinkColor = Color.DarkRed
        LinkLabel3.AutoSize = True
        LinkLabel3.Font = New Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        LinkLabel3.LinkBehavior = LinkBehavior.HoverUnderline
        LinkLabel3.LinkColor = Color.FromArgb(CByte(132), CByte(117), CByte(213))
        LinkLabel3.Location = New Point(510, 392)
        LinkLabel3.Margin = New Padding(6, 0, 6, 0)
        LinkLabel3.Name = "LinkLabel3"
        LinkLabel3.Size = New Size(96, 28)
        LinkLabel3.TabIndex = 9
        LinkLabel3.TabStop = True
        LinkLabel3.Text = "系统要求"
        ' 
        ' LinkLabel4
        ' 
        LinkLabel4.ActiveLinkColor = Color.DarkRed
        LinkLabel4.AutoSize = True
        LinkLabel4.Font = New Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        LinkLabel4.LinkBehavior = LinkBehavior.HoverUnderline
        LinkLabel4.LinkColor = Color.FromArgb(CByte(132), CByte(117), CByte(213))
        LinkLabel4.Location = New Point(623, 392)
        LinkLabel4.Margin = New Padding(6, 0, 6, 0)
        LinkLabel4.Name = "LinkLabel4"
        LinkLabel4.Size = New Size(96, 28)
        LinkLabel4.TabIndex = 10
        LinkLabel4.TabStop = True
        LinkLabel4.Text = "联系我们"
        ' 
        ' LinkLabel6
        ' 
        LinkLabel6.ActiveLinkColor = Color.DarkRed
        LinkLabel6.AutoSize = True
        LinkLabel6.ContextMenuStrip = ContextMenuStrip2
        LinkLabel6.Font = New Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        LinkLabel6.LinkBehavior = LinkBehavior.HoverUnderline
        LinkLabel6.LinkColor = Color.FromArgb(CByte(132), CByte(117), CByte(213))
        LinkLabel6.Location = New Point(282, 441)
        LinkLabel6.Margin = New Padding(6, 0, 6, 0)
        LinkLabel6.Name = "LinkLabel6"
        LinkLabel6.Size = New Size(96, 28)
        LinkLabel6.TabIndex = 12
        LinkLabel6.TabStop = True
        LinkLabel6.Text = "检查更新"
        ' 
        ' ContextMenuStrip2
        ' 
        ContextMenuStrip2.ImageScalingSize = New Size(28, 28)
        ContextMenuStrip2.Items.AddRange(New ToolStripItem() {检查更新ToolStripMenuItem, ToolStripMenuItem2, 应急下载链接ToolStripMenuItem})
        ContextMenuStrip2.Name = "ContextMenuStrip2"
        ContextMenuStrip2.Size = New Size(211, 78)
        ' 
        ' 检查更新ToolStripMenuItem
        ' 
        检查更新ToolStripMenuItem.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(134))
        检查更新ToolStripMenuItem.Name = "检查更新ToolStripMenuItem"
        检查更新ToolStripMenuItem.Size = New Size(210, 34)
        检查更新ToolStripMenuItem.Text = "检查更新"
        ' 
        ' ToolStripMenuItem2
        ' 
        ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        ToolStripMenuItem2.Size = New Size(207, 6)
        ' 
        ' 应急下载链接ToolStripMenuItem
        ' 
        应急下载链接ToolStripMenuItem.Name = "应急下载链接ToolStripMenuItem"
        应急下载链接ToolStripMenuItem.Size = New Size(210, 34)
        应急下载链接ToolStripMenuItem.Text = "应急下载链接"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.ContextMenuStrip = ContextMenuStrip1
        Label5.Font = New Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        Label5.Location = New Point(275, 35)
        Label5.Margin = New Padding(6, 0, 6, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(510, 280)
        Label5.TabIndex = 13
        Label5.Text = "WFL Tool 让修改系统变得更加容易，让系统附件更加" & vbCrLf & "易于寻找" & vbCrLf & vbCrLf & "版权所有 © 2021-2026 董博涛 保留所有权利." & vbCrLf & vbCrLf & "本软件是 Apache-2.0 许可证的开源软件" & vbCrLf & "使用本软件源码需同时遵守 WFL Tool 软件许可协议" & vbCrLf & "和 Apache-2.0 许可证" & vbCrLf & vbCrLf & "应用中部分链接为非本团队运营，详见软件许可协议"
        ' 
        ' LinkLabel7
        ' 
        LinkLabel7.ActiveLinkColor = Color.DarkRed
        LinkLabel7.AutoSize = True
        LinkLabel7.Font = New Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        LinkLabel7.LinkBehavior = LinkBehavior.HoverUnderline
        LinkLabel7.LinkColor = Color.FromArgb(CByte(132), CByte(117), CByte(213))
        LinkLabel7.Location = New Point(623, 441)
        LinkLabel7.Margin = New Padding(6, 0, 6, 0)
        LinkLabel7.Name = "LinkLabel7"
        LinkLabel7.Size = New Size(96, 28)
        LinkLabel7.TabIndex = 15
        LinkLabel7.TabStop = True
        LinkLabel7.Text = "更多信息"
        ' 
        ' LinkLabel8
        ' 
        LinkLabel8.AutoSize = True
        LinkLabel8.Font = New Font("微软雅黑", 9F, FontStyle.Italic, GraphicsUnit.Point, CByte(134))
        LinkLabel8.LinkBehavior = LinkBehavior.NeverUnderline
        LinkLabel8.LinkColor = SystemColors.InfoText
        LinkLabel8.Location = New Point(667, 345)
        LinkLabel8.Margin = New Padding(6, 0, 6, 0)
        LinkLabel8.Name = "LinkLabel8"
        LinkLabel8.Size = New Size(133, 28)
        LinkLabel8.TabIndex = 16
        LinkLabel8.TabStop = True
        LinkLabel8.Text = "软件大事记>"
        ' 
        ' LinkLabel9
        ' 
        LinkLabel9.AutoSize = True
        LinkLabel9.Font = New Font("微软雅黑", 9F, FontStyle.Italic, GraphicsUnit.Point, CByte(134))
        LinkLabel9.LinkBehavior = LinkBehavior.NeverUnderline
        LinkLabel9.LinkColor = SystemColors.InfoText
        LinkLabel9.Location = New Point(667, 345)
        LinkLabel9.Margin = New Padding(6, 0, 6, 0)
        LinkLabel9.Name = "LinkLabel9"
        LinkLabel9.Size = New Size(133, 28)
        LinkLabel9.TabIndex = 17
        LinkLabel9.TabStop = True
        LinkLabel9.Text = "<查看信息页"
        LinkLabel9.Visible = False
        ' 
        ' LinkLabel5
        ' 
        LinkLabel5.ActiveLinkColor = Color.DarkRed
        LinkLabel5.AutoSize = True
        LinkLabel5.Font = New Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        LinkLabel5.LinkBehavior = LinkBehavior.HoverUnderline
        LinkLabel5.LinkColor = Color.FromArgb(CByte(132), CByte(117), CByte(213))
        LinkLabel5.Location = New Point(396, 441)
        LinkLabel5.Margin = New Padding(6, 0, 6, 0)
        LinkLabel5.Name = "LinkLabel5"
        LinkLabel5.Size = New Size(96, 28)
        LinkLabel5.TabIndex = 13
        LinkLabel5.TabStop = True
        LinkLabel5.Text = "法律信息"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.ContextMenuStrip = ContextMenuStrip1
        Label6.Font = New Font("Microsoft YaHei UI Light", 7.714286F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        Label6.ForeColor = SystemColors.ControlDark
        Label6.Location = New Point(53, 250)
        Label6.Margin = New Padding(6, 0, 6, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(159, 24)
        Label6.TabIndex = 18
        Label6.Text = "方便快捷 一点即达"
        Label6.Visible = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(75, 90)
        PictureBox1.Margin = New Padding(6, 5, 6, 5)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(117, 112)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' LinkLabel10
        ' 
        LinkLabel10.ActiveLinkColor = Color.DarkRed
        LinkLabel10.AutoSize = True
        LinkLabel10.Font = New Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        LinkLabel10.LinkBehavior = LinkBehavior.HoverUnderline
        LinkLabel10.LinkColor = Color.FromArgb(CByte(132), CByte(117), CByte(213))
        LinkLabel10.Location = New Point(510, 441)
        LinkLabel10.Margin = New Padding(6, 0, 6, 0)
        LinkLabel10.Name = "LinkLabel10"
        LinkLabel10.Size = New Size(96, 28)
        LinkLabel10.TabIndex = 14
        LinkLabel10.TabStop = True
        LinkLabel10.Text = "开源地址"
        ' 
        ' FeatureControlLabel1
        ' 
        FeatureControlLabel1.AutoSize = True
        FeatureControlLabel1.Location = New Point(78, 35)
        FeatureControlLabel1.Name = "FeatureControlLabel1"
        FeatureControlLabel1.Size = New Size(87, 21)
        FeatureControlLabel1.TabIndex = 111
        FeatureControlLabel1.Text = "disable"
        FeatureControlLabel1.Visible = False
        ' 
        ' Form9
        ' 
        AutoScaleDimensions = New SizeF(11F, 21F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSizeMode = AutoSizeMode.GrowAndShrink
        BackColor = SystemColors.Control
        ClientSize = New Size(831, 516)
        ContextMenuStrip = ContextMenuStrip1
        Controls.Add(FeatureControlLabel1)
        Controls.Add(LinkLabel10)
        Controls.Add(Label6)
        Controls.Add(LinkLabel5)
        Controls.Add(LinkLabel9)
        Controls.Add(LinkLabel8)
        Controls.Add(LinkLabel7)
        Controls.Add(Label5)
        Controls.Add(LinkLabel6)
        Controls.Add(LinkLabel4)
        Controls.Add(LinkLabel3)
        Controls.Add(LinkLabel2)
        Controls.Add(LinkLabel1)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(PictureBox1)
        Font = New Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(6, 5, 6, 5)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Form9"
        StartPosition = FormStartPosition.CenterScreen
        Text = "关于 WFL Tool  -  我诞生 5 周年啦！"
        ContextMenuStrip1.ResumeLayout(False)
        ContextMenuStrip2.ResumeLayout(False)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents LinkLabel6 As LinkLabel
    Friend WithEvents Label5 As Label
    Friend WithEvents LinkLabel7 As LinkLabel
    Friend WithEvents LinkLabel8 As LinkLabel
    Friend WithEvents LinkLabel9 As LinkLabel
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents 打开主界面ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents 退出程序ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LinkLabel5 As LinkLabel
    Friend WithEvents Label6 As Label
    Friend WithEvents LinkLabel10 As LinkLabel
    Friend WithEvents FeatureControlLabel1 As Label
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents 检查更新ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents 应急下载链接ToolStripMenuItem As ToolStripMenuItem
End Class
