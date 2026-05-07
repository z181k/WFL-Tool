<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form16
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
        TextBox1 = New TextBox()
        Button1 = New Button()
        Panel1 = New Panel()
        Label1 = New Label()
        Label3 = New Label()
        Button3 = New Button()
        Button2 = New Button()
        Timer1 = New Timer(components)
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' TextBox1
        ' 
        TextBox1.AcceptsReturn = True
        TextBox1.AcceptsTab = True
        TextBox1.BackColor = SystemColors.HighlightText
        TextBox1.BorderStyle = BorderStyle.None
        TextBox1.Font = New Font("Microsoft YaHei UI", 10F)
        TextBox1.Location = New Point(39, 119)
        TextBox1.Margin = New Padding(3, 2, 3, 2)
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.ReadOnly = True
        TextBox1.ScrollBars = ScrollBars.Vertical
        TextBox1.Size = New Size(677, 300)
        TextBox1.TabIndex = 0
        TextBox1.TabStop = False
        TextBox1.Text = "文本"
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Microsoft YaHei UI", 9.5F)
        Button1.Location = New Point(457, 477)
        Button1.Margin = New Padding(3, 2, 3, 2)
        Button1.Name = "Button1"
        Button1.Size = New Size(271, 56)
        Button1.TabIndex = 1
        Button1.Text = "确定"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.HighlightText
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(TextBox1)
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(760, 456)
        Panel1.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Microsoft YaHei UI Light", 18.5F)
        Label1.Location = New Point(32, 25)
        Label1.Name = "Label1"
        Label1.Size = New Size(113, 57)
        Label1.TabIndex = 6
        Label1.Text = "标题"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = SystemColors.HighlightText
        Label3.Font = New Font("宋体", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(134))
        Label3.ForeColor = SystemColors.ControlText
        Label3.Location = New Point(690, 13)
        Label3.Margin = New Padding(6, 0, 6, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(50, 34)
        Label3.TabIndex = 5
        Label3.Text = "×"
        ' 
        ' Button3
        ' 
        Button3.Font = New Font("Microsoft YaHei UI", 9.5F)
        Button3.Location = New Point(503, 477)
        Button3.Margin = New Padding(3, 2, 3, 2)
        Button3.Name = "Button3"
        Button3.Size = New Size(225, 56)
        Button3.TabIndex = 6
        Button3.Text = "不再提示"
        Button3.UseVisualStyleBackColor = True
        Button3.Visible = False
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Microsoft YaHei UI", 9.5F)
        Button2.Location = New Point(253, 477)
        Button2.Margin = New Padding(3, 2, 3, 2)
        Button2.Name = "Button2"
        Button2.Size = New Size(225, 56)
        Button2.TabIndex = 5
        Button2.Text = "继续关闭"
        Button2.UseVisualStyleBackColor = True
        Button2.Visible = False
        ' 
        ' Timer1
        ' 
        Timer1.Interval = 1
        ' 
        ' Form16
        ' 
        AcceptButton = Button1
        AutoScaleDimensions = New SizeF(11F, 21F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSizeMode = AutoSizeMode.GrowAndShrink
        CancelButton = Button1
        ClientSize = New Size(754, 553)
        ControlBox = False
        Controls.Add(Button2)
        Controls.Add(Panel1)
        Controls.Add(Button3)
        Controls.Add(Button1)
        Font = New Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        Margin = New Padding(3, 2, 3, 2)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Form16"
        ShowIcon = False
        StartPosition = FormStartPosition.CenterScreen
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Timer1 As Timer
End Class
