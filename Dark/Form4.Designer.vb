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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form4))
        WebBrowser1 = New WebBrowser()
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
        ' Form4
        ' 
        AutoScaleDimensions = New SizeF(11F, 21F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1344, 859)
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
        ResumeLayout(False)

    End Sub

    Friend WithEvents WebBrowser1 As WebBrowser
End Class
