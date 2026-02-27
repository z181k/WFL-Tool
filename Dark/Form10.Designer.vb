<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form10
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form10))
        ContextMenuStrip1 = New ContextMenuStrip(components)
        打开主界面ToolStripMenuItem = New ToolStripMenuItem()
        Label1 = New Label()
        GroupBox1 = New GroupBox()
        GroupBox2 = New GroupBox()
        Button5 = New Button()
        Button11 = New Button()
        Button12 = New Button()
        GroupBox4 = New GroupBox()
        Button10 = New Button()
        Button7 = New Button()
        Button9 = New Button()
        Button8 = New Button()
        Button6 = New Button()
        GroupBox3 = New GroupBox()
        TextBox1 = New TextBox()
        Label3 = New Label()
        Button3 = New Button()
        Button4 = New Button()
        Button2 = New Button()
        Button1 = New Button()
        ContextMenuStrip1.SuspendLayout()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        GroupBox4.SuspendLayout()
        GroupBox3.SuspendLayout()
        SuspendLayout()
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.ImageScalingSize = New Size(28, 28)
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {打开主界面ToolStripMenuItem})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(196, 38)
        ' 
        ' 打开主界面ToolStripMenuItem
        ' 
        打开主界面ToolStripMenuItem.Name = "打开主界面ToolStripMenuItem"
        打开主界面ToolStripMenuItem.Size = New Size(195, 34)
        打开主界面ToolStripMenuItem.Text = "打开 主界面"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(612, 112)
        Label1.TabIndex = 1
        Label1.Text = "使用须知：使用 Windows 密钥管理服务(KMS)激活的 Windows" & vbCrLf & "和 Office 每 180 天需要重新激活一次。我们没有内置 KMS 服务" & vbCrLf & "器地址，请自行准备，使用官方地址激活的是正版，我们只是给" & vbCrLf & "KMS 做了个 UI ，方便使用"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(GroupBox2)
        GroupBox1.Controls.Add(Button12)
        GroupBox1.Controls.Add(GroupBox4)
        GroupBox1.Controls.Add(GroupBox3)
        GroupBox1.Controls.Add(Button2)
        GroupBox1.Controls.Add(Button1)
        GroupBox1.Font = New Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        GroupBox1.Location = New Point(15, 124)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(627, 597)
        GroupBox1.TabIndex = 1
        GroupBox1.TabStop = False
        GroupBox1.Text = "Windows"
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(Button5)
        GroupBox2.Controls.Add(Button11)
        GroupBox2.Location = New Point(353, 34)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(258, 140)
        GroupBox2.TabIndex = 5
        GroupBox2.TabStop = False
        GroupBox2.Text = "取消激活"
        ' 
        ' Button5
        ' 
        Button5.Location = New Point(16, 32)
        Button5.Name = "Button5"
        Button5.Size = New Size(230, 48)
        Button5.TabIndex = 6
        Button5.Text = "卸载密钥"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' Button11
        ' 
        Button11.Location = New Point(16, 85)
        Button11.Name = "Button11"
        Button11.Size = New Size(230, 46)
        Button11.TabIndex = 7
        Button11.Text = "重置激活"
        Button11.UseVisualStyleBackColor = True
        ' 
        ' Button12
        ' 
        Button12.Location = New Point(213, 34)
        Button12.Name = "Button12"
        Button12.Size = New Size(113, 140)
        Button12.TabIndex = 4
        Button12.Text = "电话" & vbCrLf & "激活"
        Button12.UseVisualStyleBackColor = True
        ' 
        ' GroupBox4
        ' 
        GroupBox4.Controls.Add(Button10)
        GroupBox4.Controls.Add(Button7)
        GroupBox4.Controls.Add(Button9)
        GroupBox4.Controls.Add(Button8)
        GroupBox4.Controls.Add(Button6)
        GroupBox4.Location = New Point(6, 464)
        GroupBox4.Name = "GroupBox4"
        GroupBox4.Size = New Size(615, 119)
        GroupBox4.TabIndex = 12
        GroupBox4.TabStop = False
        GroupBox4.Text = "切换 Windows 10/11 版本并安装相关 KMS 密钥"
        ' 
        ' Button10
        ' 
        Button10.Location = New Point(502, 34)
        Button10.Name = "Button10"
        Button10.Size = New Size(107, 79)
        Button10.TabIndex = 17
        Button10.Text = "企业"
        Button10.UseVisualStyleBackColor = True
        ' 
        ' Button7
        ' 
        Button7.Location = New Point(94, 34)
        Button7.Name = "Button7"
        Button7.Size = New Size(140, 79)
        Button7.TabIndex = 14
        Button7.Text = "专业教育"
        Button7.UseVisualStyleBackColor = True
        ' 
        ' Button9
        ' 
        Button9.Location = New Point(400, 34)
        Button9.Name = "Button9"
        Button9.Size = New Size(96, 79)
        Button9.TabIndex = 16
        Button9.Text = "教育"
        Button9.UseVisualStyleBackColor = True
        ' 
        ' Button8
        ' 
        Button8.Location = New Point(240, 34)
        Button8.Name = "Button8"
        Button8.Size = New Size(154, 79)
        Button8.TabIndex = 15
        Button8.Text = "专业工作站"
        Button8.UseVisualStyleBackColor = True
        ' 
        ' Button6
        ' 
        Button6.Location = New Point(6, 34)
        Button6.Name = "Button6"
        Button6.Size = New Size(82, 79)
        Button6.TabIndex = 13
        Button6.Text = "专业"
        Button6.UseVisualStyleBackColor = True
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Controls.Add(TextBox1)
        GroupBox3.Controls.Add(Label3)
        GroupBox3.Controls.Add(Button3)
        GroupBox3.Controls.Add(Button4)
        GroupBox3.Location = New Point(6, 192)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(615, 255)
        GroupBox3.TabIndex = 8
        GroupBox3.TabStop = False
        GroupBox3.Text = "安装密钥/设置KMS 地址"
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        TextBox1.Location = New Point(8, 128)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(597, 40)
        TextBox1.TabIndex = 9
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(3, 31)
        Label3.Name = "Label3"
        Label3.Size = New Size(577, 84)
        Label3.TabIndex = 0
        Label3.Text = """安装密钥""功能和""设定/更改 KMS 地址""功能需要在这里先输" & vbCrLf & "入需要应用的信息后再点击相关按钮" & vbCrLf & "注意：(IPv6 地址必须以""""[计算机名]:端口""""的格式指定)"
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(8, 177)
        Button3.Name = "Button3"
        Button3.Size = New Size(333, 67)
        Button3.TabIndex = 10
        Button3.Text = "设定/更改 KMS 地址"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Location = New Point(347, 177)
        Button4.Name = "Button4"
        Button4.Size = New Size(258, 67)
        Button4.TabIndex = 11
        Button4.Text = "安装密钥"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(6, 107)
        Button2.Name = "Button2"
        Button2.Size = New Size(201, 67)
        Button2.TabIndex = 3
        Button2.Text = "激活"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(6, 34)
        Button1.Name = "Button1"
        Button1.Size = New Size(201, 67)
        Button1.TabIndex = 2
        Button1.Text = "查看状态"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Form10
        ' 
        AutoScaleDimensions = New SizeF(11F, 21F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSizeMode = AutoSizeMode.GrowAndShrink
        BackColor = SystemColors.Control
        ClientSize = New Size(654, 739)
        ContextMenuStrip = ContextMenuStrip1
        Controls.Add(GroupBox1)
        Controls.Add(Label1)
        Font = New Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Form10"
        ShowIcon = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "Windows 密钥管理服务激活 UI - WFL Tool"
        ContextMenuStrip1.ResumeLayout(False)
        GroupBox1.ResumeLayout(False)
        GroupBox2.ResumeLayout(False)
        GroupBox4.ResumeLayout(False)
        GroupBox3.ResumeLayout(False)
        GroupBox3.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents 打开主界面ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Button10 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button11 As Button
    Friend WithEvents Button12 As Button
    Friend WithEvents GroupBox2 As GroupBox
End Class
