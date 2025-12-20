<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form8
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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form8))
        Label1 = New Label()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        打开主界面ToolStripMenuItem = New ToolStripMenuItem()
        Button1 = New Button()
        Label3 = New Label()
        LinkLabel6 = New LinkLabel()
        SaveFileDialog1 = New SaveFileDialog()
        Label2 = New Label()
        PictureBox1 = New PictureBox()
        ContextMenuStrip1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Red
        Label1.Font = New Font("微软雅黑", 15F, FontStyle.Bold, GraphicsUnit.Point, CByte(134))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(22, 66)
        Label1.Margin = New Padding(6, 0, 6, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(834, 46)
        Label1.TabIndex = 0
        Label1.Text = "彻底关闭 UAC 会使计算机暴露在风险中，确定继续?"
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.ImageScalingSize = New Size(28, 28)
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {打开主界面ToolStripMenuItem})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(169, 38)
        ' 
        ' 打开主界面ToolStripMenuItem
        ' 
        打开主界面ToolStripMenuItem.Name = "打开主界面ToolStripMenuItem"
        打开主界面ToolStripMenuItem.Size = New Size(168, 34)
        打开主界面ToolStripMenuItem.Text = "打开主页"
        ' 
        ' Button1
        ' 
        Button1.Cursor = Cursors.Hand
        Button1.Font = New Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        Button1.Location = New Point(15, 199)
        Button1.Margin = New Padding(6, 5, 6, 5)
        Button1.Name = "Button1"
        Button1.Size = New Size(763, 66)
        Button1.TabIndex = 1
        Button1.Text = "算了吧"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Red
        Label3.Cursor = Cursors.Hand
        Label3.Font = New Font("宋体", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(134))
        Label3.ForeColor = Color.White
        Label3.Location = New Point(882, 14)
        Label3.Margin = New Padding(6, 0, 6, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(50, 34)
        Label3.TabIndex = 4
        Label3.Text = "×"
        ' 
        ' LinkLabel6
        ' 
        LinkLabel6.AutoSize = True
        LinkLabel6.Cursor = Cursors.AppStarting
        LinkLabel6.Font = New Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        LinkLabel6.LinkBehavior = LinkBehavior.NeverUnderline
        LinkLabel6.LinkColor = Color.DarkGray
        LinkLabel6.Location = New Point(838, 220)
        LinkLabel6.Margin = New Padding(6, 0, 6, 0)
        LinkLabel6.Name = "LinkLabel6"
        LinkLabel6.Size = New Size(54, 28)
        LinkLabel6.TabIndex = 13
        LinkLabel6.TabStop = True
        LinkLabel6.Text = "继续"
        LinkLabel6.VisitedLinkColor = Color.Gray
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Red
        Label2.Font = New Font("微软雅黑", 7.714286F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        Label2.ForeColor = Color.White
        Label2.Location = New Point(33, 133)
        Label2.Margin = New Padding(2, 0, 2, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(638, 24)
        Label2.TabIndex = 14
        Label2.Text = "修改后重启生效，若要重新打开，请选择""更改弹出设置""选项或到控制面板设置"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(0, 0)
        PictureBox1.Margin = New Padding(6, 5, 6, 5)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(946, 182)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 16
        PictureBox1.TabStop = False
        ' 
        ' Form8
        ' 
        AutoScaleDimensions = New SizeF(11F, 21F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSizeMode = AutoSizeMode.GrowAndShrink
        ClientSize = New Size(946, 279)
        ContextMenuStrip = ContextMenuStrip1
        ControlBox = False
        Controls.Add(Label2)
        Controls.Add(LinkLabel6)
        Controls.Add(Label3)
        Controls.Add(Button1)
        Controls.Add(Label1)
        Controls.Add(PictureBox1)
        Font = New Font("新宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        FormBorderStyle = FormBorderStyle.None
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(6, 5, 6, 5)
        Name = "Form8"
        StartPosition = FormStartPosition.CenterScreen
        Text = "警告"
        TransparencyKey = Color.LightGray
        ContextMenuStrip1.ResumeLayout(False)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents LinkLabel6 As LinkLabel
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents 打开主界面ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
