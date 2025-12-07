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
        SuspendLayout()
        ' 
        ' Loadpga
        ' 
        AutoScaleDimensions = New SizeF(13F, 28F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Indigo
        ClientSize = New Size(10, 10)
        ControlBox = False
        FormBorderStyle = FormBorderStyle.None
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Loadpga"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        TransparencyKey = Color.Indigo
        ResumeLayout(False)
    End Sub
End Class
