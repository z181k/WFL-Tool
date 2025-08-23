Public Class SetupUserBackground
    Private Sub UninstAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer2.Start()
        SetupUserInstall.Show()
        SetupUserInstall.Text = "WFL Tool (x64) 安装程序"
        SetupUserInstall.Label4.Text = "安装程序"
        SetupUserInstall.Label1.Text = "正在安装"
        SetupUserInstall.PB1.Value = 0
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        End
    End Sub

    Private Sub UninstAdmin_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Me.Visible = False
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Timer2.Stop()
        Shell("cmd.EXE /c md ""%localappdata%\WFL Tool""", AppWinStyle.Hide, True, -1)
        Shell("cmd.EXE /c copy pga.bin ""%localappdata%\WFL Tool\WFL Tool.exe"" /y", AppWinStyle.Hide, True, -1)
        SetupUserInstall.PB1.Value = 10
        Shell("cmd.EXE /c Xcopy.EXE EWV2viewer ""%localappdata%\WFL Tool\EWV2viewer\"" /Y", AppWinStyle.Hide, True, -1)
        Shell("cmd.EXE /c md ""%localappdata%\WFL Tool\EWV2viewer\runtimes\win-x64\native""", AppWinStyle.Hide, True, -1)
        SetupUserInstall.PB1.Value = 20
        Shell("cmd.EXE /c copy 3RDparty\wv2l.bin ""%localappdata%\WFL Tool\EWV2viewer\runtimes\win-x64\native\WebView2Loader.dll"" /y", AppWinStyle.Hide, True, -1)
        Shell("cmd.EXE /c copy uiu.bin ""%localappdata%\WFL Tool\uninstall.exe"" /y", AppWinStyle.Hide, True, -1)
        SetupUserInstall.PB1.Value = 30
        Shell("cmd.EXE /c copy 3RDparty\pri.bin ""%localappdata%\WFL Tool\resources.pri"" /y", AppWinStyle.Hide, True, -1)
        Shell("cmd.EXE /c copy 3RDparty\arb.bin ""%localappdata%\WFL Tool\Microsoft.WindowsAppRuntime.Bootstrap.dll"" /y", AppWinStyle.Hide, True, -1)
        SetupUserInstall.PB1.Value = 40
        Shell("cmd.EXE /c copy 3RDparty\amb.bin ""%localappdata%\WFL Tool\Microsoft.Windows.ApplicationModel.Background.UniversalBGTask.dll"" /y", AppWinStyle.Hide, True, -1)
        Shell("cmd.EXE /c copy 3RDparty\mbp.bin ""%localappdata%\WFL Tool\MessageBox.exe"" /y", AppWinStyle.Hide, True, -1)
        Shell("cmd.EXE /c copy udl.bin ""%userprofile%\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\WFL Tool.lnk"" /y", AppWinStyle.Hide, True, -1)
        SetupUserInstall.PB1.Value = 50
        Dim CurrentBuild As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild", Nothing)
        If CurrentBuild >= 17763 Then              '检查版本配置WinAppSdk项目
            Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v WinAppSdkUi /T REG_SZ /d 5 /f", AppWinStyle.Hide, True, -1)
            CreateObject("shell.application").shellexecute("3RDparty\wari17x64.exe", "", "", "", 0)
        End If
        SetupUserInstall.PB1.Value = 60
        Shell("cmd.exe /c reg.exe add ""HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool"" /v PaintDesktopVersion /T REG_DWORD /d 1 /f", AppWinStyle.Hide, True, -1)
        Shell("cmd.exe /c reg.exe add ""HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool"" /v DisplayIcon /T REG_SZ /d ""%localappdata%\WFL Tool\WFL Tool.exe"" /f", AppWinStyle.Hide, True, -1)
        Shell("cmd.exe /c reg.exe add ""HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool"" /v DisplayName /T REG_SZ /d ""WFL Tool (x64) User"" /f", AppWinStyle.Hide, True, -1)
        SetupUserInstall.PB1.Value = 70
        Shell("cmd.exe /c reg.exe add ""HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool"" /v DisplayVersion /T REG_SZ /d 12.0.8416.1 /f", AppWinStyle.Hide, True, -1)
        Shell("cmd.exe /c reg.exe add ""HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool"" /v HelpLink /T REG_SZ /d ""https://kdocs.cn/l/sqxx3d4vumUT"" /f", AppWinStyle.Hide, True, -1)
        Shell("cmd.exe /c reg.exe add ""HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool"" /v UninstallString /T REG_SZ /d ""%localappdata%\WFL Tool\Uninstall.exe"" /f", AppWinStyle.Hide, True, -1)
        SetupUserInstall.PB1.Value = 80
        Shell("cmd.exe /c reg.exe add ""HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool"" /v NoModify /T REG_DWORD /d 1 /f", AppWinStyle.Hide, True, -1)
        Shell("cmd.exe /c reg.exe add ""HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool"" /v NoRepair /T REG_DWORD /d 1 /f", AppWinStyle.Hide, True, -1)
        Shell("cmd.exe /c reg.exe add ""HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool"" /v EstimatedSize /T REG_DWORD /d 26316 /f", AppWinStyle.Hide, True, -1)
        SetupUserInstall.PB1.Value = 90
        Shell("cmd.exe /c reg.exe add ""HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool"" /v Publisher /T REG_SZ /d ""(c) 2021-2025 董博涛"" /f", AppWinStyle.Hide, True, -1)
        Shell("cmd.exe /c reg.exe add ""HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool"" /v InstallLocation /T REG_SZ /d ""%localappdata%\WFL Tool"" /f", AppWinStyle.Hide, True, -1)
        Dim dpf As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", True).GetValue("Desktop", "%homedrive%%homepath%\desktop")
        Shell("cmd.EXE /c copy udl.bin """ + dpf + "\WFL Tool.lnk"" /y", AppWinStyle.Hide, True, -1)
        SetupUserInstall.PB1.Value = 100
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v EWV2webpageShow /T REG_SZ /d 4 /f", AppWinStyle.Hide, True, -1)
        SetupUserInstall.Label1.Text = "安装完成"
        SetupUserInstall.ControlBox = True
        SetupUserInstall.Button1.Text = "关闭"
        SetupUserInstall.Button1.Enabled = True
        Dim EAI As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\DBT\WFL Tool", "EnterpriseAutoInstall", Nothing)
        If EAI = "2" Then
            Timer1.Start()
            'Timer1.Enabled = True                  '检查企业自动化安装
            SetupUserInstall.Button1.Text = "3 秒后自动关闭"
        End If
    End Sub
End Class