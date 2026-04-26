Public Class SetupUser
    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Shell("cmd.EXE /c copy DotNet10Pga\npga.bin ""%homedrive%%homepath%\WFL Tool.exe"" /y", AppWinStyle.Hide, True, -1)
        Shell("cmd.EXE /c start explorer.exe /select,""%homedrive%%homepath%\WFL Tool.exe""", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub 为当前用户安装_Click(sender As Object, e As EventArgs) Handles 为当前用户安装.Click
        Dim setupUserB As New SetupUserBackground
        Dim StartPoint As New System.Drawing.Point
        StartPoint.X = Me.Location.X
        StartPoint.Y = Me.Location.Y
        setupUserB.Location = StartPoint
        setupUserB.Show()
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Me.Visible = False
        Dim LX As String = Me.Location.X
        Dim LY As String = Me.Location.Y
        CreateObject("shell.application").shellexecute("InAdmin.exe", LX + " " + LY, "", "runas", 1)        '所有用户
        Application.Exit()
    End Sub

    Private Sub SetupUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CurrentBuild As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild", Nothing)
        If CurrentBuild < 5033 Then         '拒绝在Windows Longhorn重置前版本、WindowsXP及更低版本系统的X64版本上运行
            MsgBox("本软件仅支持 Windows Vista 及以上版本 x64 架构 Windows 系统！")
        End If
        '低分辨率设备兼容代码
        PictureBox2.Height = PictureBox2.Width
        Dim ScreenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        If ScreenHeight < 1080 Then
            Label7.Location = Label7.Location - New Size(3, 0)
        End If
    End Sub
End Class
