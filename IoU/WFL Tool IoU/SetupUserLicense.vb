Public Class SetupUserLicense
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        End
    End Sub

    Private Sub SetupUserLicense_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim PROCESSOR_ARCHITECTURE As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Environment", "PROCESSOR_ARCHITECTURE", Nothing)
        If PROCESSOR_ARCHITECTURE = "x86" Then
            GoTo defaultstart                 '判断兼容性
        End If
        MsgBox("此版本仅为 x86 架构处理器提供, x64 架构请使用 x64 版本,我们没有提供 arm64 架构版本,请关注我们的网站,我们可能会在将来提供基于 arm64 的本软件。", MsgBoxStyle.Critical, "WFL Tool")
        End
defaultstart:
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
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SetupUser.Show()
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v EULA /T REG_SZ /d SetupUser /f", AppWinStyle.Hide, True, -1)
        Close()
    End Sub
End Class
