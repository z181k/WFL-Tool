Public Class SetupUserLicense
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        End
    End Sub

    Private Sub SetupUserLicense_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim PROCESSOR_ARCHITECTURE As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Environment", "PROCESSOR_ARCHITECTURE", Nothing)
        If PROCESSOR_ARCHITECTURE <> "AMD64" Then
            MsgBox("此版本仅为 x64 架构处理器提供，我们没有提供 arm64 基于架构的版本，请关注我们的网站，我们可能会在将来提供基于 arm64 的 WFL Tool。", MsgBoxStyle.Critical, "WFL Tool")
            End
            '判断架构兼容性
        End If
        Dim CurrentBuild As Integer = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild", Nothing)
        If CurrentBuild < 10240 Then              '检查版本控制应用启动
            MsgBox("WFL Tool 仅支持 Windows 10 及以上版本 x64 架构 Windows 系统，请升级你的操作系统。", 0, "WFL Tool")
            End
            '拒绝在比Windows 8.1更低版本系统的X64版本上运行
        End If

        On Error GoTo jump               '企业自动化安装
        Dim EAI As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\DBT\WFL Tool", "EnterpriseAutoInstall", Nothing)
        If EAI = "1" Then
            Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v InstallAdmin /T REG_SZ /d 1 /f", AppWinStyle.Hide, True, -1)
            CreateObject("shell.application").shellexecute("InAdmin.exe", "", "", "runas", 0)
            Close()               '企业自动化安装：所有用户
        End If
        If EAI = "2" Then
            SetupUserBackground.Show()
            Close()               '企业自动化安装：当前用户
        End If
jump:
        '低分辨率设备兼容代码
        PictureBox2.Height = PictureBox2.Width
        Dim ScreenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        If ScreenHeight < 1080 Then
            Label7.Location = Label7.Location - New Size(3, 0)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SetupUser.Show()
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v EULA /T REG_SZ /d SetupUser /f", AppWinStyle.Hide, True, -1)
        Close()
    End Sub
End Class
