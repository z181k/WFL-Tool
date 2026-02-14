<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
        ContextMenuStrip1 = New ContextMenuStrip(components)
        返回主界面ToolStripMenuItem = New ToolStripMenuItem()
        PictureBox1 = New PictureBox()
        PictureBox2 = New PictureBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        ContextMenuStrip1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
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
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.White
        PictureBox1.Location = New Point(0, 1127)
        PictureBox1.Margin = New Padding(7)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(2, 3)
        PictureBox1.TabIndex = 2
        PictureBox1.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(52, 67)
        PictureBox2.Margin = New Padding(7)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(138, 138)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 3
        PictureBox2.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("微软雅黑", 24F, FontStyle.Bold, GraphicsUnit.Point, CByte(134))
        Label1.Location = New Point(201, 92)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(534, 75)
        Label1.TabIndex = 4
        Label1.Text = "WFL Tool 5 周年了"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("微软雅黑", 14.14286F, FontStyle.Italic, GraphicsUnit.Point, CByte(134))
        Label2.Location = New Point(56, 288)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(414, 45)
        Label2.TabIndex = 5
        Label2.Text = "感恩回馈：5周年特别活动"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        Label3.Location = New Point(59, 392)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(1252, 168)
        Label3.TabIndex = 6
        Label3.Text = resources.GetString("Label3.Text")
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("微软雅黑 Light", 7.5F)
        Label4.Location = New Point(1125, 12)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(413, 48)
        Label4.TabIndex = 7
        Label4.Text = "以用户模式安装的本软件在有 Edge Webview2 的" & vbCrLf & "Windows 7 - Windows 11 系统上浏览该页体验更佳"
        ' 
        ' Form3
        ' 
        AutoScaleDimensions = New SizeF(13F, 28F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1627, 703)
        ContextMenuStrip = ContextMenuStrip1
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(7)
        MaximizeBox = False
        Name = "Form3"
        StartPosition = FormStartPosition.CenterScreen
        Text = "WFL Tool 五周年"
        ContextMenuStrip1.ResumeLayout(False)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents 返回主界面ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
End Class
