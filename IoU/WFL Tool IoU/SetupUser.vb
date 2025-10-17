Public Class SetupUser
    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Shell("cmd.EXE /c copy pga.bin ""%homedrive%%homepath%\WFL Tool.exe"" /y", AppWinStyle.Hide, True, -1)
        Shell("cmd.EXE /c start explorer.exe /select,""%homedrive%%homepath%\WFL Tool.exe""", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub 为当前用户安装_Click(sender As Object, e As EventArgs) Handles 为当前用户安装.Click
        SetupUserBackground.Show()
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v InstallAdmin /T REG_SZ /d 1 /f", AppWinStyle.Hide, True, -1)
        CreateObject("shell.application").shellexecute("InAdmin.exe", "", "", "runas", 1)        '所有用户
        End
    End Sub

    Private Sub SetupUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CurrentBuild As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild", Nothing)
        If CurrentBuild < 5033 Then         '拒绝在Windows Longhorn重置前版本、WindowsXP及更低版本系统的X64版本上运行
            MsgBox("本软件仅支持 Windows Vista 及以上版本 x64 架构 Windows 系统！")
        End If
    End Sub
End Class
