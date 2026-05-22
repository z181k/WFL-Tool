<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Loadpga
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Loadpga))
        Beta = New Label()
        Build = New Label()
        Ver = New Label()
        NewUI = New Label()
        SuspendLayout()
        ' 
        ' Beta
        ' 
        Beta.AutoSize = True
        Beta.ForeColor = Color.Lavender
        Beta.Location = New Point(4, 55)
        Beta.Name = "Beta"
        Beta.Size = New Size(37, 28)
        Beta.TabIndex = 0
        Beta.Text = "B1"
        Beta.Visible = False
        ' 
        ' Build
        ' 
        Build.AutoSize = True
        Build.ForeColor = Color.Lavender
        Build.Location = New Point(4, 27)
        Build.Name = "Build"
        Build.Size = New Size(89, 28)
        Build.TabIndex = 1
        Build.Text = "9632.06"
        Build.Visible = False
        ' 
        ' Ver
        ' 
        Ver.AutoSize = True
        Ver.ForeColor = Color.Lavender
        Ver.Location = New Point(5, 4)
        Ver.Name = "Ver"
        Ver.Size = New Size(53, 28)
        Ver.TabIndex = 2
        Ver.Text = "17.1"
        Ver.Visible = False
        ' 
        ' NewUI
        ' 
        NewUI.AutoSize = True
        NewUI.ForeColor = Color.Lavender
        NewUI.Location = New Point(5, 79)
        NewUI.Name = "NewUI"
        NewUI.Size = New Size(82, 28)
        NewUI.TabIndex = 3
        NewUI.Text = "Legacy"
        ' 
        ' Loadpga
        ' 
        AutoScaleDimensions = New SizeF(13F, 28F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Indigo
        ClientSize = New Size(80, 111)
        ControlBox = False
        Controls.Add(NewUI)
        Controls.Add(Ver)
        Controls.Add(Build)
        Controls.Add(Beta)
        FormBorderStyle = FormBorderStyle.None
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Loadpga"
        ShowInTaskbar = False
        TransparencyKey = Color.Indigo
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Beta As Label
    Friend WithEvents Build As Label
    Friend WithEvents Ver As Label
    Friend WithEvents NewUI As Label
End Class
