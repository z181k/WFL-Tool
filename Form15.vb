Public Class Form15
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        On Error GoTo legacy
        Dim WinAppSdkUi As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\DBT\WFL Tool", "WinAppSdkUi", Nothing)
        If WinAppSdkUi = "1" Then              'WinAppSdk弹窗
            Dim InstallLocation As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool", "InstallLocation", Nothing)
            Shell(InstallLocation + "\MessageBox.exe ""将文件或快捷方式拖入打开的文件夹即可。"" ""添加开机启动项目"" 0 64 0", AppWinStyle.NormalFocus, True, -1)
        Else              '旧版弹窗
legacy:
            MsgBox("将文件或快捷方式拖入打开的文件夹即可。", 0, "添加开机启动项目")
        End If
        Shell("explorer.exe C:\ProgramData\Microsoft\Windows\Start Menu\Programs\StartUp", AppWinStyle.NormalFocus, False, -1)
        Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim CurrentBuild As Integer = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild", Nothing)
        If CurrentBuild < 9200 Then         'Windows7及更低版本打开msconfig
            MsgBox("请在打开的窗口选择启动选项卡。")
            Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
            CreateObject("shell.application").shellexecute(SystemRoot + "\system32\msconfig.exe", "", "", "", 1)
        ElseIf CurrentBuild >= 22621 Then    'win11打开设置app的该页
            Shell("cmd.exe /c start ms-settings:startupapps", AppWinStyle.Hide, False, -1)
        Else                                'win8-10打开任务管理器启动选项卡
            Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
            CreateObject("shell.application").shellexecute(SystemRoot + "\system32\taskmgr.exe", "/Startup", "", "", 1)
        End If
        Close()
    End Sub

    Private Sub 在设置app中查看该项ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 在设置app中查看该项ToolStripMenuItem.Click
        'win11右键-在设置打开
        Shell("cmd.exe /c start ms-settings:startupapps", AppWinStyle.Hide, False, -1)
        Close()
    End Sub

    Private Sub 在任务管理器中查看该项ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 在任务管理器中查看该项ToolStripMenuItem.Click
        'win11右键-在任务管理器打开
        Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
        CreateObject("shell.application").shellexecute(SystemRoot + "\system32\taskmgr.exe", "/Startup", "", "", 1)
        Close()
    End Sub

    Private Sub Form15_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CurrentBuild As Integer = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild", Nothing)
        If CurrentBuild >= 22621 Then         'win11的右键菜单
            Button2.ContextMenuStrip = ContextMenuStrip1
        End If
    End Sub
End Class