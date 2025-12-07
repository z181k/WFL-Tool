<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form11
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form11))
        ContextMenuStrip1 = New ContextMenuStrip(components)
        返回主页ToolStripMenuItem = New ToolStripMenuItem()
        ToolStripMenuItem1 = New ToolStripSeparator()
        退出程序ToolStripMenuItem = New ToolStripMenuItem()
        Button1 = New Button()
        Button2 = New Button()
        GroupBox1 = New GroupBox()
        ContextMenuStrip1.SuspendLayout()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.ImageScalingSize = New Size(28, 28)
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {返回主页ToolStripMenuItem, ToolStripMenuItem1, 退出程序ToolStripMenuItem})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(169, 78)
        ' 
        ' 返回主页ToolStripMenuItem
        ' 
        返回主页ToolStripMenuItem.Name = "返回主页ToolStripMenuItem"
        返回主页ToolStripMenuItem.Size = New Size(168, 34)
        返回主页ToolStripMenuItem.Text = "打开主页"
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
        ' Button1
        ' 
        Button1.Font = New Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        Button1.Location = New Point(9, 32)
        Button1.Margin = New Padding(6, 5, 6, 5)
        Button1.Name = "Button1"
        Button1.Size = New Size(160, 54)
        Button1.TabIndex = 1
        Button1.Text = "清除数据"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        Button2.Location = New Point(181, 32)
        Button2.Margin = New Padding(6, 5, 6, 5)
        Button2.Name = "Button2"
        Button2.Size = New Size(160, 54)
        Button2.TabIndex = 2
        Button2.Text = "取消协议授权"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(Button1)
        GroupBox1.Controls.Add(Button2)
        GroupBox1.Font = New Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        GroupBox1.Location = New Point(12, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(352, 98)
        GroupBox1.TabIndex = 3
        GroupBox1.TabStop = False
        GroupBox1.Text = "清除数据与撤回协议同意"
        ' 
        ' Form11
        ' 
        AutoScaleDimensions = New SizeF(11F, 21F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSizeMode = AutoSizeMode.GrowAndShrink
        ClientSize = New Size(636, 719)
        ContextMenuStrip = ContextMenuStrip1
        Controls.Add(GroupBox1)
        Font = New Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(6, 5, 6, 5)
        MaximizeBox = False
        Name = "Form11"
        StartPosition = FormStartPosition.CenterScreen
        Text = "WFL Tool 选项"
        ContextMenuStrip1.ResumeLayout(False)
        GroupBox1.ResumeLayout(False)
        ResumeLayout(False)

    End Sub

    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents 返回主页ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents 退出程序ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents GroupBox1 As GroupBox
End Class
