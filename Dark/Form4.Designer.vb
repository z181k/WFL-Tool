<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form4))
        WebBrowser1 = New WebBrowser()
        PictureBox1 = New PictureBox()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        返回主界面ToolStripMenuItem = New ToolStripMenuItem()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        ContextMenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' WebBrowser1
        ' 
        WebBrowser1.Dock = DockStyle.Fill
        WebBrowser1.Location = New Point(0, 0)
        WebBrowser1.Margin = New Padding(6, 5, 6, 5)
        WebBrowser1.MinimumSize = New Size(37, 35)
        WebBrowser1.Name = "WebBrowser1"
        WebBrowser1.ScrollBarsEnabled = False
        WebBrowser1.Size = New Size(1344, 859)
        WebBrowser1.TabIndex = 0
        WebBrowser1.Url = New Uri("file:///C:/WFLTE.HTML", UriKind.Absolute)
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.White
        PictureBox1.Location = New Point(0, 901)
        PictureBox1.Margin = New Padding(6, 5, 6, 5)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(2, 2)
        PictureBox1.TabIndex = 3
        PictureBox1.TabStop = False
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.ImageScalingSize = New Size(28, 28)
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {返回主界面ToolStripMenuItem})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(169, 38)
        ' 
        ' 返回主界面ToolStripMenuItem
        ' 
        返回主界面ToolStripMenuItem.Name = "返回主界面ToolStripMenuItem"
        返回主界面ToolStripMenuItem.Size = New Size(168, 34)
        返回主界面ToolStripMenuItem.Text = "返回主页"
        ' 
        ' Form4
        ' 
        AutoScaleDimensions = New SizeF(11F, 21F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1344, 859)
        ContextMenuStrip = ContextMenuStrip1
        Controls.Add(PictureBox1)
        Controls.Add(WebBrowser1)
        Font = New Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(6, 5, 6, 5)
        MaximizeBox = False
        MaximumSize = New Size(1368, 923)
        MinimumSize = New Size(1368, 923)
        Name = "Form4"
        StartPosition = FormStartPosition.CenterScreen
        Text = "请把相关文件放到 C:\ 下 - 应用彩蛋"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ContextMenuStrip1.ResumeLayout(False)
        ResumeLayout(False)

    End Sub

    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents 返回主界面ToolStripMenuItem As ToolStripMenuItem
End Class
