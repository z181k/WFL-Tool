<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form15
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form15))
        Button1 = New Button()
        Button2 = New Button()
        Label1 = New Label()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        在设置app中查看该项ToolStripMenuItem = New ToolStripMenuItem()
        在任务管理器中查看该项ToolStripMenuItem = New ToolStripMenuItem()
        ContextMenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        Button1.Location = New Point(27, 79)
        Button1.Name = "Button1"
        Button1.Size = New Size(326, 59)
        Button1.TabIndex = 0
        Button1.Text = "添加开机启动项目"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        Button2.Location = New Point(27, 155)
        Button2.Name = "Button2"
        Button2.Size = New Size(326, 59)
        Button2.TabIndex = 1
        Button2.Text = "开启/关闭开机启动项目"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        Label1.Location = New Point(32, 31)
        Label1.Name = "Label1"
        Label1.Size = New Size(243, 28)
        Label1.TabIndex = 2
        Label1.Text = "选择你想要设置的项目："
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.ImageScalingSize = New Size(28, 28)
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {在设置app中查看该项ToolStripMenuItem, 在任务管理器中查看该项ToolStripMenuItem})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(328, 72)
        ' 
        ' 在设置app中查看该项ToolStripMenuItem
        ' 
        在设置app中查看该项ToolStripMenuItem.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(134))
        在设置app中查看该项ToolStripMenuItem.Name = "在设置app中查看该项ToolStripMenuItem"
        在设置app中查看该项ToolStripMenuItem.Size = New Size(327, 34)
        在设置app中查看该项ToolStripMenuItem.Text = "在 设置 应用中查看该项"
        ' 
        ' 在任务管理器中查看该项ToolStripMenuItem
        ' 
        在任务管理器中查看该项ToolStripMenuItem.Name = "在任务管理器中查看该项ToolStripMenuItem"
        在任务管理器中查看该项ToolStripMenuItem.Size = New Size(327, 34)
        在任务管理器中查看该项ToolStripMenuItem.Text = "在 任务管理器 中查看该项"
        ' 
        ' Form15
        ' 
        AutoScaleDimensions = New SizeF(11F, 21F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSizeMode = AutoSizeMode.GrowAndShrink
        ClientSize = New Size(382, 242)
        Controls.Add(Label1)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Font = New Font("新宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Form15"
        StartPosition = FormStartPosition.CenterScreen
        Text = "设置开机启动项目"
        ContextMenuStrip1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents 在设置app中查看该项ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 在任务管理器中查看该项ToolStripMenuItem As ToolStripMenuItem
End Class
