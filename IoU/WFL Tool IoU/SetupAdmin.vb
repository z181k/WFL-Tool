Public Class SetupAdmin
    Private Sub SetupAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error GoTo Errorchk
        Dim InstallAdmin As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\DBT\WFL Tool", True).GetValue("InstallAdmin", "无")
        If InstallAdmin = "1" Then
            Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v InstallAdmin /T REG_SZ /d 0 /f", AppWinStyle.Hide, True, -1)
            Timer2.Start()
            SetupUserInstall.Show()
            SetupUserInstall.Text = "WFL Tool (x64) 安装程序"
            SetupUserInstall.Label4.Text = "安装程序"
            SetupUserInstall.Label1.Text = "正在安装"
            SetupUserInstall.PB1.Value = 0
            Exit Sub     '结束事件防止执行下面
        End If
Errorchk:
        MsgBox("请执行 Setup.exe 以进行安装。", MsgBoxStyle.Critical, "WFL Tool 安装程序")
        End
    End Sub


    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Timer2.Stop()
        Shell("cmd.EXE /c md ""%programfiles%\WFL Tool""", AppWinStyle.Hide, True, -1)
        SetupUserInstall.PB1.Value = 20
        Shell("cmd.EXE /c copy pga.bin ""%programfiles%\WFL Tool\WFL Tool.exe"" /y", AppWinStyle.Hide, True, -1)
        Shell("cmd.EXE /c copy aiu.bin ""%programfiles%\WFL Tool\uninstall.exe"" /y", AppWinStyle.Hide, True, -1)
        Shell("cmd.exe /c reg.exe delete ""HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool"" /f", AppWinStyle.Hide, True, -1)
        '上面那条是删除build8320的安装信息
        Shell("cmd.EXE /c copy adl.bin ""%programdata%\Microsoft\Windows\Start Menu\Programs\WFL Tool.lnk"" /y", AppWinStyle.Hide, True, -1)
        SetupUserInstall.PB1.Value = 40
        Shell("cmd.exe /c reg.exe add ""HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtoolA"" /v PaintDesktopVersion /T REG_DWORD /d 1 /f", AppWinStyle.Hide, True, -1)
        Shell("cmd.exe /c reg.exe add ""HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtoolA"" /v DisplayIcon /T REG_SZ /d ""%programfiles%\WFL Tool\WFL Tool.exe"" /f", AppWinStyle.Hide, True, -1)
        Shell("cmd.exe /c reg.exe add ""HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtoolA"" /v DisplayName /T REG_SZ /d ""WFL Tool (x64) Admin"" /f", AppWinStyle.Hide, True, -1)
        Shell("cmd.exe /c reg.exe add ""HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtoolA"" /v DisplayVersion /T REG_SZ /d 12.0.8416.1 /f", AppWinStyle.Hide, True, -1)
        SetupUserInstall.PB1.Value = 60
        Shell("cmd.exe /c reg.exe add ""HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtoolA"" /v HelpLink /T REG_SZ /d ""https://kdocs.cn/l/sqxx3d4vumUT"" /f", AppWinStyle.Hide, True, -1)
        Shell("cmd.exe /c reg.exe add ""HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtoolA"" /v UninstallString /T REG_SZ /d ""%programfiles%\WFL Tool\Uninstall.exe"" /f", AppWinStyle.Hide, True, -1)
        Shell("cmd.exe /c reg.exe add ""HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtoolA"" /v NoModify /T REG_DWORD /d 1 /f", AppWinStyle.Hide, True, -1)
        Shell("cmd.exe /c reg.exe add ""HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtoolA"" /v NoRepair /T REG_DWORD /d 1 /f", AppWinStyle.Hide, True, -1)
        SetupUserInstall.PB1.Value = 80
        Shell("cmd.exe /c reg.exe add ""HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtoolA"" /v EstimatedSize /T REG_DWORD /d 6451 /f", AppWinStyle.Hide, True, -1)
        Shell("cmd.exe /c reg.exe add ""HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtoolA"" /v Publisher /T REG_SZ /d ""(c) 2021-2025 董博涛"" /f", AppWinStyle.Hide, True, -1)
        Shell("cmd.exe /c reg.exe add ""HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtoolA"" /v InstallLocation /T REG_SZ /d ""%programfiles%\WFL Tool"" /f", AppWinStyle.Hide, True, -1)
        Shell("cmd.EXE /c copy adl.bin ""%homedrive%\users\public\desktop\WFL Tool.lnk"" /y", AppWinStyle.Hide, True, -1)
        SetupUserInstall.PB1.Value = 100
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v EWV2webpageShow /T REG_SZ /d 4 /f", AppWinStyle.Hide, True, -1)
        SetupUserInstall.Label1.Text = "安装完成"
        SetupUserInstall.ControlBox = True
        SetupUserInstall.Button1.Text = "关闭"
        SetupUserInstall.Button1.Enabled = True
        Dim EAI As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\DBT\WFL Tool", "EnterpriseAutoInstall", Nothing)
        If EAI = "1" Then
            Application.Exit()       '检查企业自动化安装
        End If
    End Sub
End Class