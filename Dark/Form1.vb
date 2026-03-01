Imports System.ComponentModel
Imports System.Runtime.InteropServices

Public Class Form1
    Dim asc As AutoSizeFormClass = New AutoSizeFormClass()
    Dim SizeChangeFlg As Boolean = False '首次加载窗体会误触发SizeChange,容易报错

    Private Sub Form1_sizechange(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.SizeChanged
        If SizeChangeFlg Then
            asc.ControlAutoSize(Me)
        End If
        'Button5.Text = Me.Width & ":" & Me.Height '利用控件名称显示的窗体大小，可删
    End Sub


    '-----------------------------------------------------------------------------------------------------------------------------------------
    '=========================================================================================================================================
    '—————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————


    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Shell("cmd.exe", AppWinStyle.NormalFocus, False, -1)       '命令提示符
    End Sub

    Private Sub MSDN我告诉你ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MSDN我告诉你ToolStripMenuItem.Click
        Shell("cmd.exe /c start https://msdn.itellyou.cn/", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub 相册ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 相册ToolStripMenuItem.Click
        Shell("cmd.exe /c start ms-photos:5", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub 关于AToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 关于AToolStripMenuItem.Click
        Form9.Show()
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
        CreateObject("shell.application").shellexecute(SystemRoot + "\regedit.exe", "-m", "", "", 1)    '注册表编辑器
    End Sub

    Private Sub 切换用户ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 切换用户ToolStripMenuItem.Click
        Shell("rundll32.exe user32.dll,LockWorkStation", AppWinStyle.NormalFocus, False, -1)
    End Sub

    Private Sub 关机ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 关机ToolStripMenuItem.Click
        Shell("shutdown.exe -s -t 1", AppWinStyle.Hide, True, -1)
        End
    End Sub

    Private Sub 进入WinREToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 进入WinREToolStripMenuItem.Click
        Shell("shutdown.exe /r /o /T 1", AppWinStyle.Hide, True, -1)
        End
    End Sub

    Private Sub Windows1011ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Windows1011ToolStripMenuItem.Click
        Dim CurrentBuild As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild", Nothing)
        If CurrentBuild >= 10240 Then   'Win10/11更新
            Shell("cmd.exe /c start ms-settings:windowsupdate", AppWinStyle.Hide, True, -1)
        Else
            Shell("wuapp.exe", AppWinStyle.NormalFocus, False, -1)   'win7/8/vista更新
        End If
    End Sub

    Private Sub WindowsDefenderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WindowsDefenderToolStripMenuItem.Click
        Shell("cmd.exe /c start WindowsDefender:5", AppWinStyle.Hide, True, -1) 'win安全中心
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim NForm5 As New Form5()
        NForm5.Show()                '打开附件窗口(关闭式)
        Close()
    End Sub

    Private Sub 功能说明帮助ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 功能说明帮助ToolStripMenuItem.Click
        On Error GoTo legacy
        Dim WinAppSdkUi As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\DBT\WFL Tool", "WinAppSdkUi", Nothing)
        If WinAppSdkUi = "1" Then              'WinAppSdk弹窗
            Dim InstallLocation As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool", "InstallLocation", Nothing)
            Shell(InstallLocation + "\MessageBox.exe ""这里的功能可能会对计算机造成损坏，请谨慎使用！"" ""高级功能"" 0 48 0", AppWinStyle.NormalFocus, False, -1)
        Else              '旧版弹窗
legacy:
            MsgBox("这里的功能可能会对计算机造成损坏，请谨慎使用！", MsgBoxStyle.OkOnly, "高级功能")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click                     '关闭explorer
        On Error GoTo legacy
        Dim WinAppSdkUi As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\DBT\WFL Tool", "WinAppSdkUi", Nothing)
        If WinAppSdkUi = "1" Then              'WinAppSdk弹窗
            Dim InstallLocation As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool", "InstallLocation", Nothing)
            Shell(InstallLocation + "\MessageBox.exe ""请保存数据，所有打开的文件夹将关闭(包括文件复制)。"" ""Microsoft Windows"" 0 0 0", AppWinStyle.NormalFocus, True, -1)
        Else              '旧版弹窗
legacy:
            MsgBox("请保存数据，所有打开的文件夹将关闭(包括文件复制)。", MsgBoxStyle.OkOnly, "Microsoft Windows")
        End If
        Shell("taskkill.exe /im explorer.exe /f", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Shell("winver.exe", AppWinStyle.NormalFocus, False, -1)     'windows版本
    End Sub

    Private Sub 官网下载ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 官网下载ToolStripMenuItem.Click
        Shell("cmd.exe /c start https://www.microsoft.com/zh-cn/software-download/", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub 恢复ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles 恢复ToolStripMenuItem1.Click '控制面板
        Shell("reg.exe add HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer /v NoControlPanel /T REG_DWORD /d 0 /f", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub 恢复ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 恢复ToolStripMenuItem.Click '命令提示符
        Shell("reg.exe add HKEY_CURRENT_USER\Software\Policies\Microsoft\Windows\System /v DisableCMD /T REG_DWORD /d 0 /f", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub 恢复ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles 恢复ToolStripMenuItem2.Click '任务管理器
        Shell("reg.exe add HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer /v DisableTaskmgr /T REG_DWORD /d 0 /f", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Shell("cmd.exe /c start %windir%\explorer.exe", AppWinStyle.Hide, True, -1)     '打开资源管理器
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click     '回收站
        Shell("explorer.exe shell:::{645FF040-5081-101B-9F08-00AA002F954E}", AppWinStyle.NormalFocus, False, -1)
    End Sub

    Private Sub 获取帮助GToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 获取帮助GToolStripMenuItem.Click
        On Error GoTo legacy
        Dim EDGEWV2 As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Microsoft EdgeWebView", "Version", Nothing)
        If EDGEWV2 = "" Then               '判断EDGE WEBVIEW2是否存在
            GoTo legacy
        End If
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v EWV2webpageClean /T REG_SZ /d True /f", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v EWV2webpageShow /T REG_SZ /d True /f", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v EWV2webpageTitle /T REG_SZ /d ""WFL Tool 帮助"" /f", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v EWV2webpageURL /T REG_SZ /d https://kdocs.cn/l/sqxx3d4vumUT /f", AppWinStyle.Hide, True, -1)
        Shell("EWV2viewer\EWV2Viewer.exe", AppWinStyle.NormalFocus, False, -1)   '写入启动参数注册表并且启动ewv2
        Exit Sub
legacy:                           'EDGE WEBVIEW2不存在或者无法启动ewv2的旧版方案
        Shell("cmd.exe /c start https://kdocs.cn/l/sqxx3d4vumUT", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v EWV2webpageClean /T REG_SZ /d False /f", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click         '此电脑
        Shell("explorer.exe shell:::{20D04FE0-3AEA-1069-A2D8-08002B30309D}", AppWinStyle.NormalFocus, False, -1)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
        CreateObject("shell.application").shellexecute(SystemRoot + "\system32\compmgmt.msc", "/s", "", "", 0)  '计算机管理
    End Sub


    Private Sub 禁用ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles 禁用ToolStripMenuItem1.Click '控制面板
        Shell("reg.exe add HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer /v NoControlPanel /T REG_DWORD /d 1 /f", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub 禁用ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 禁用ToolStripMenuItem.Click '命令提示符
        Shell("reg.exe add HKEY_CURRENT_USER\Software\Policies\Microsoft\Windows\System /v DisableCMD /T REG_DWORD /d 1 /f", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub 禁用ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles 禁用ToolStripMenuItem2.Click '任务管理器
        Shell("reg.exe add HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer /v DisableTaskmgr /T REG_DWORD /d 1 /f", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Shell("control.exe", AppWinStyle.NormalFocus, False, -1)                         '打开控制面板
    End Sub

    Private Sub 离线更新下载ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 离线更新下载ToolStripMenuItem.Click
        Dim InstallationType As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "InstallationType", Nothing)
        Dim CurrentBuild As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild", Nothing)
        If CurrentBuild > 26100 Then   '兼容未来版本的Win11和win server更新日志及离线更新包
            If InstallationType = "Client" Then
                Shell("cmd.exe /c start https://support.microsoft.com/topic/253c73cd-cab1-4bfd-94dc-76c452273fc9", AppWinStyle.Hide, True, -1)
            Else
                '没有新的win server链接，拿server2025的顶一下，毕竟server 2022/v23h2/2025都被放在了一起，估计新版本也在一起
                Shell("cmd.exe /c start https://support.microsoft.com/topic/10f58da7-e57b-4a9d-9c16-9f1dcd72d7d7", AppWinStyle.Hide, True, -1)
            End If
        ElseIf CurrentBuild = 26100 Then   'Win11 24h2/win server 2025更新日志及离线更新包
            If InstallationType = "Client" Then
                Shell("cmd.exe /c start https://support.microsoft.com/topic/0929c747-1815-4543-8461-0160d16f15e5", AppWinStyle.Hide, True, -1)
            Else
                Shell("cmd.exe /c start https://support.microsoft.com/topic/10f58da7-e57b-4a9d-9c16-9f1dcd72d7d7", AppWinStyle.Hide, True, -1)
            End If
        ElseIf CurrentBuild = 25398 Then  'win server v23h2更新日志及离线更新包
            Shell("cmd.exe /c start https://support.microsoft.com/topic/68c851ff-825a-4dbc-857b-51c5aa0ab248", AppWinStyle.Hide, True, -1)
        ElseIf CurrentBuild >= 21380 Then   'Win11其他版本更新日志及离线更新包
            Shell("cmd.exe /c start https://support.microsoft.com/topic/59875222-b990-4bd9-932f-91a5954de434", AppWinStyle.Hide, True, -1)
        ElseIf CurrentBuild = 20348 Then       'win server 2022更新日志及离线更新包
            Shell("cmd.exe /c start https://support.microsoft.com/topic/e1caa597-00c5-4ab9-9f3e-8212fe80b2ee", AppWinStyle.Hide, True, -1)
        Else
            'win10及Server2016/2019更新日志及离线更新包
            '还有些版本也有更新日志页，但.net10版的此应用人为不兼容它们了，所以不列出，旧框架版本中是有的
            Shell("cmd.exe /c start https://support.microsoft.com/topic/8127c2c6-6edf-4fdf-8b9f-0f7be1ef3562", AppWinStyle.Hide, True, -1)
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click  '内存诊断
        Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
        CreateObject("shell.application").shellexecute(SystemRoot + "\system32\MdSched.exe", "", "", "", 1)
    End Sub

    Private Sub 设置ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 设置ToolStripMenuItem.Click
        Shell("cmd.exe /c start ms-settings:5", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub 所有任务ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 所有任务ToolStripMenuItem.Click
        Shell("explorer.exe shell:::{ED7BA470-8E54-465E-825C-99712043E01C}", AppWinStyle.NormalFocus, False, -1)
    End Sub

    Private Sub 退出XToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 退出XToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click     '网络
        Shell("explorer.exe shell:::{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}", AppWinStyle.NormalFocus, False, -1)
    End Sub

    Private Sub 查看系统位数ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 查看系统位数ToolStripMenuItem.Click
        'MsgBox("在弹出窗口中找到系统类型，后面就是系统和cpu位数。x86 是 x86 平台的 32 位，x64 (全称 x86_64 或 AMD 64)是 x86 平台的 64 位。注：x86 既代表了 x86 CPU 架构集，也代表了 x86 CPU 架构集中的 32 位架构", MsgBoxStyle.OkOnly, "系统位数与架构")
        Shell("explorer.exe shell:::{BB06C0E4-D293-4F75-8A90-CB05B6477EEE}", AppWinStyle.NormalFocus, False, -1)
    End Sub

    Private Sub 相机ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 相机ToolStripMenuItem.Click
        Shell("cmd.exe /c start Microsoft.windows.camera:5", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub 修复Win1011开始菜单卡死ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 修复Win1011开始菜单卡死ToolStripMenuItem.Click
        Dim TargetName As String = "StartMenuExperienceHost" '存储进程名为文本型，注：进程名不加扩展名
        Dim TargetKill() As Process = Process.GetProcessesByName(TargetName) '从进程名获取进程
        Dim TargetPath As String '存储进程路径为文本型
        If TargetKill.Length > 1 Then '判断进程名的数量，如果同名进程数量在2个以上，用For循环关闭进程。
            For i = 0 To TargetKill.Length - 1
                TargetPath = TargetKill(i).MainModule.FileName
                TargetKill(i).Kill()
            Next
            'ElseIf TargetKill.Length = 0 Then '判断进程名的数量，没有发现进程直接弹窗。不需要的，可直接删掉该If子句
            'MsgBox("没有发现那个该死的进程！")
            'Exit Sub
        ElseIf TargetKill.Length = 1 Then '判断进程名的数量，如果只有一个，就不用For循环
            TargetKill(0).Kill()
        End If
        'Me.Dispose(1) '关闭自身进程
        'Application.Exit()
    End Sub

    Private Sub 重启ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 重启ToolStripMenuItem.Click
        Shell("shutdown.exe -r -t 1", AppWinStyle.Hide, True, -1)
        End
    End Sub

    Private Sub 注销ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 注销ToolStripMenuItem.Click
        Shell("shutdown.exe -L", AppWinStyle.Hide, True, -1)
        End
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click   '自解压创建程序
        Shell("cmd.exe /c start %windir%\System32\iexpress.exe", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click   '开机启动
        Form15.Show()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
        CreateObject("shell.application").shellexecute(SystemRoot + "\system32\gpedit.msc", "", "", "", 0)        '组策略
    End Sub

    Private Sub 打开helpcenterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开helpcenterToolStripMenuItem.Click
        On Error GoTo legacy
        Dim EDGEWV2 As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Microsoft EdgeWebView", "Version", Nothing)
        If EDGEWV2 = "" Then               '判断EDGE WEBVIEW2是否存在
            GoTo legacy
        End If
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v EWV2webpageClean /T REG_SZ /d True /f", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v EWV2webpageShow /T REG_SZ /d True /f", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v EWV2webpageTitle /T REG_SZ /d ""Windows 帮助与学习 - Microsoft 帮助与支持中心"" /f", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v EWV2webpageShowIcon /T REG_SZ /d False /f", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v EWV2webpageURL /T REG_SZ /d ""https://support.microsoft.com/windows"" /f", AppWinStyle.Hide, True, -1)
        Shell("EWV2viewer\EWV2Viewer.exe", AppWinStyle.NormalFocus, False, -1)   '写入启动参数注册表并且启动ewv2
        Exit Sub
legacy:
        'EDGE WEBVIEW2不存在或者无法启动ewv2的旧版方案
        Shell("cmd.exe /c start helppane.exe -home", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v EWV2webpageClean /T REG_SZ /d False /f", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub 系统修改ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 系统修改ToolStripMenuItem.Click
        Form7.Show()
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        CreateObject("InternetExplorer.Application").Visible = True            '打开ie
    End Sub

    Private Sub 休眠ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 休眠ToolStripMenuItem.Click
        Shell("Shutdown.exe /h", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub 分钟后ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 分钟后ToolStripMenuItem.Click
        Shell("shutdown.exe -s -t 60", AppWinStyle.Hide, True, -1)           '一分钟后自动关机
    End Sub

    Private Sub 分钟后ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles 分钟后ToolStripMenuItem1.Click
        Shell("shutdown.exe -s -t 300", AppWinStyle.Hide, True, -1)           '5分钟后自动关机
    End Sub

    Private Sub 分钟后ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles 分钟后ToolStripMenuItem2.Click
        Shell("shutdown.exe -s -t 600", AppWinStyle.Hide, True, -1)           '10分钟后自动关机
    End Sub

    Private Sub 分钟后ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles 分钟后ToolStripMenuItem3.Click
        Shell("shutdown.exe -s -t 1200", AppWinStyle.Hide, True, -1)           '20分钟后自动关机
    End Sub

    Private Sub 分钟后ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles 分钟后ToolStripMenuItem4.Click
        Shell("shutdown.exe -s -t 1800", AppWinStyle.Hide, True, -1)           '30分钟后自动关机
    End Sub

    Private Sub 小时后ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 小时后ToolStripMenuItem.Click
        Shell("shutdown.exe -s -t 3600", AppWinStyle.Hide, True, -1)           '一小时后自动关机
    End Sub

    Private Sub 小时后ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles 小时后ToolStripMenuItem1.Click
        Shell("shutdown.exe -s -t 7200", AppWinStyle.Hide, True, -1)           '2小时后自动关机
    End Sub

    Private Sub 小时后ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles 小时后ToolStripMenuItem2.Click
        Shell("shutdown.exe -s -t 18000", AppWinStyle.Hide, True, -1)           '5小时后自动关机
    End Sub

    Private Sub 小时后ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles 小时后ToolStripMenuItem3.Click
        Shell("shutdown.exe -s -t 43200", AppWinStyle.Hide, True, -1)           '12小时后自动关机
    End Sub

    Private Sub 天后ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 天后ToolStripMenuItem.Click
        Shell("shutdown.exe -s -t 86400", AppWinStyle.Hide, True, -1)           '一天后自动关机
    End Sub

    Private Sub 取消定时关机ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 取消定时关机ToolStripMenuItem.Click
        Shell("shutdown.exe -a", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub ToolStripMenuItem14_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem14.Click
        Shell("shutdown.exe -s -t 172800", AppWinStyle.Hide, True, -1)       '2天后自动关机
    End Sub

    Private Sub 高级自定义ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 高级自定义ToolStripMenuItem.Click
        Shell("cmd.exe /c shutdown.exe -i", AppWinStyle.Hide, False, -1)   '自动关机高级选项
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error GoTo openreg       '防止注册表不存在
starttask:
        Dim CurrentBuild As Integer = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild", Nothing)
        '
        ToolStripMenuItem3.Text = "WFL Tool" + VerLabel.Text  '主界面右上角wfltool - 现代
        '读取设置并调整界面（注册表读取）
        Dim License As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\DBT\WFL Tool", True).GetValue("EULA", "无")
        If License = "无" Then                                                                       '以前是License键值，不是EULA
            Dim frm As New Form12
            'frm.StartPosition = FormStartPosition.Manual '这个很重要，必须设置为Manual，Location才能有用
            'Dim StartPoint As New System.Drawing.Point
            'StartPoint.X = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width - frm.Width
            'StartPoint.Y = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height - frm.Height
            'frm.Location = StartPoint
            frm.Show()
            Close()                             '确认阅读协议
        End If
        '启动时显示指定界面
        Dim ShowSpecifyPage As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\DBT\WFL Tool", "ShowSpecifyPage", Nothing)
        If ShowSpecifyPage = "More" Then
            Form2.Show()
            Form2.打开主页ToolStripMenuItem.Enabled = False
            Form2.返回主界面.Visible = False                     '显示更多
            Form2.快捷键返回BToolStripMenuItem.Enabled = False
            Close()
        ElseIf ShowSpecifyPage = "Accessories" Then
            Form5.Show()
            Form5.打开主页ToolStripMenuItem.Enabled = False
            Form5.返回主界面.Visible = False                     '附件
            Form5.快捷键返回BToolStripMenuItem.Enabled = False
            Close()
        ElseIf ShowSpecifyPage = "SystemModifications" Then
            Form7.Show()
            Form7.返回主界面ToolStripMenuItem.Visible = False    '系统修改
            Form7.ToolStripMenuItem1.Visible = False
            Close()
        ElseIf ShowSpecifyPage = "ActiveTool" Then
            Form10.Show()
            Form10.打开主界面ToolStripMenuItem.Enabled = False   '激活工具
            Close()
        End If
        '
        If CurrentBuild < 18362 Then              '检查版本控制UWP应用和电池健康显示
            UWP应用ToolStripMenuItem.Enabled = False
            电池健康ToolStripMenuItem.Enabled = False
        End If
        If CurrentBuild < 19041 Then
            '检查版本控制主题显示
            主题与版本ToolStripMenuItem.Enabled = False
        End If
        If CurrentBuild < 22000 Then
            '检查版本控制Win11IE名字和自动切换颜色
            Button20.Text = "启动没有任何起始页的 Internet Explorer 浏览器"
            自动ToolStripMenuItem.Enabled = False
        End If
        '
        asc.ControllInitializeSize(Me) '记录控件初始位置&大小
        SizeChangeFlg = True '允许触发SizeChange
        'Size = New Size(900, 550) '调整窗口大小
        '
        '测试版提示文字
        'Panel1.Show()
        'Label1.Text = "这是 WFL Tool 公测版本 (Beta),有问题及时反馈"
        'Label1.Text = "新版本,新征程！WFL Tool 团队祝大家 2026 春节快乐！"
        'Me.Text = "WFL Tool - Alpha 版 - 仅供内部测试,内部机密"
        'LinkLabel2.Visible = False     '不再显示
        'LinkLabel3.Visible = False      '关闭
        'Label1.Text = "Alpha 版本,不得外泄,如你意外获得,请立即删除,立即向我们举报"
        '
        'beta不显示横幅
        'Dim Beta As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\DBT\WFL Tool", True).GetValue("Preview", "无")
        'If Beta = "9504.1" Then
        '    Panel1.Visible = False
        '    Me.Text = "WFL Tool - Beta 版 - 仅用于公测"
        'End If
        '
        '主题菜单文本显示
        Dim NColor As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\DBT\WFL Tool", "NColor", Nothing)
        If NColor = "White" Then
            亮色ToolStripMenuItem.Text = "亮色 (当前)"
            自动ToolStripMenuItem.Text = "跟随系统"
        ElseIf NColor = "Dark" Then
            暗色ToolStripMenuItem.Text = "暗色 (当前)"
            自动ToolStripMenuItem.Text = "跟随系统"
        Else
            If CurrentBuild < 22000 Then
                亮色ToolStripMenuItem.Text = "亮色 (当前)"
                自动ToolStripMenuItem.Text = "跟随系统"
            End If
        End If
        Dim EnterpriseNotShow As Integer = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\DBT\WFL Tool", "EnterpriseNotShow", Nothing)
        If EnterpriseNotShow = 1 Then
            ToolStripMenuItem18.Visible = False
            ToolStripMenuItem19.Visible = False
            ToolStripMenuItem6.Visible = False
            Exit Sub                        '企业自定义屏蔽
        End If
        Dim LegacyMoreUI As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WFL Tool", True).GetValue("LegacyMoreUI", "无")
        If LegacyMoreUI = "True" Then
            Button19.Visible = False
            Button8.Visible = True    '查看更多和附件
            Button10.Visible = False
            Button13.Visible = True
            新版覆盖返回方式ToolStripMenuItem.Text = "新版覆盖加返回键方式"
            旧版ToolStripMenuItem.Text = "旧版弹出窗口方式 (当前)"
        End If
        Dim TrayIcon As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\DBT\WFL Tool", True).GetValue("TrayIcon", "无")
        If TrayIcon = "True" Then
            Form13.Show()                       '托盘图标
            启动时不打开当前ToolStripMenuItem.Text = "启动时不打开"
            启动时打开ToolStripMenuItem.Text = "启动时打开 (当前)"
        End If
        '此处标两个引号的是在Windows 7及以下系统存在严重问题的功能可控启用模块代码
        ''Dim v122 As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool", True).GetValue("v122", "无")
        ''If v122 = "ture" Then
        ''   FeatureControlLabel1.Text = "enable"    '启用v12.2的功能 - user
        ''End If
        ''Dim v122a As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\WFLtoolA", "v122a", Nothing)
        ''If v122a = "True" Then
        ''   FeatureControlLabel1.Text = "enable"    '启用v12.2的功能 - admin
        ''End If
        If FeatureControlLabel1.Text = "enable" Then    '判断相关功能是否可以使用
            查看更多内部功能ToolStripMenuItem.Visible = True
            ''VerLabel.Text = "  v12.2"
            Dim cctButton As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\DBT\WFL Tool", True).GetValue("cctButton", "无")
            If cctButton = "1" Then
                计算机管理当前ToolStripMenuItem.Text = "计算机管理"           '查看更多内部功能 - admin cmd
                命令提示符管理员ToolStripMenuItem1.Text = "管理员命令提示符 (当前)"
            ElseIf cctButton = "2" Then
                计算机管理当前ToolStripMenuItem.Text = "计算机管理"           '查看更多内部功能 - taskmger x86
                任务管理器x86ToolStripMenuItem.Text = "任务管理器 x86 (当前)"
            End If
        End If
        Dim LegacyHomeUI As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\DBT\WFL Tool", True).GetValue("LegacyHomeUI", "无")
        If LegacyHomeUI = "True" Then
            ToolStripMenuItem3.Text = "欢迎使用" + VerLabel.Text
            现代当前ToolStripMenuItem.Text = "现代"           '主界面右上角wfltool - 欢迎使用
            伪旧ToolStripMenuItem.Text = "伪旧 (当前)"
        ElseIf LegacyHomeUI = "OnlyVersion" Then
            ToolStripMenuItem3.Text = VerLabel.Text
            现代当前ToolStripMenuItem.Text = "现代"           '主界面右上角wfltool - 仅版本号
            仅版本号ToolStripMenuItem.Text = "仅版本号 (当前)"
        ElseIf LegacyHomeUI = "OnlyAppName" Then
            ToolStripMenuItem3.Text = "WFL Tool"
            现代当前ToolStripMenuItem.Text = "现代"           '主界面右上角wfltool - 仅软件名
            仅软件名ToolStripMenuItem.Text = "仅软件名 (当前)"
        End If
        '分离的调用:winupdate
        Timer1.Start()
        '低分辨率设备兼容代码
        PictureBox2.Height = PictureBox2.Width
        '
        Exit Sub
openreg:
        '辅助打开软件
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v OPEN /T REG_SZ /d x64 /f", AppWinStyle.Hide, True, -1)
        GoTo starttask
        Exit Sub
    End Sub

    Private Sub 打开窗口不关闭原窗口ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开窗口不关闭原窗口MoreToolStripMenuItem.Click
        Dim OF2 As New Form2()
        OF2.Show()                             '查看更多右键菜单1
    End Sub

    Private Sub 打开窗口不关闭原窗口附件ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开窗口不关闭原窗口附件ToolStripMenuItem.Click
        Form5.Show()              '附件右键菜单1
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click   '主页应用图标点击
        On Error GoTo legacy
        Dim WinAppSdkUi As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\DBT\WFL Tool", "WinAppSdkUi", Nothing)
        If WinAppSdkUi = "1" Then              'WinAppSdk弹窗
            Dim InstallLocation As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool", "InstallLocation", Nothing)
            Shell(InstallLocation + "\MessageBox.exe ""好用请推荐给别人"" ""温馨提示"" 0 64 0", AppWinStyle.NormalFocus, False, -1)
        Else              '旧版弹窗
legacy:
            MsgBox("好用请推荐给别人", 0, "温馨提示")
        End If
    End Sub

    Private Sub ToolStripMenuItem15_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem15.Click
        Form10.Show()        '打开密钥管理服务界面
    End Sub

    Private Sub ToolStripMenuItem17_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem17.Click
        Dim pwstdntime As String
        pwstdntime = InputBox("输入要在几秒后关机", "自动关机自定义")                             '自动关机自定义
        CreateObject("shell.application").shellexecute("shutdown.EXE", "/s /t " + pwstdntime, "", "", 0)
    End Sub

    Private Sub 旧版ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 旧版ToolStripMenuItem.Click
        '旧版弹出窗口方式
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v LegacyMoreUI /T REG_SZ /d True /f", AppWinStyle.Hide, True, -1)
        '执行操作
        Button19.Visible = False
        Button8.Visible = True
        Button10.Visible = False
        Button13.Visible = True
        新版覆盖返回方式ToolStripMenuItem.Text = "新版覆盖加返回键方式"
        旧版ToolStripMenuItem.Text = "旧版弹出窗口方式 (当前)"
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click  '主页版本点击
        On Error GoTo wflttext      '防止没有相关注册表项
        Dim LegacyHomeUI As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\DBT\WFL Tool", True).GetValue("LegacyHomeUI", "无")
        If LegacyHomeUI = "True" Then
            Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v LegacyHomeUI /T REG_SZ /d 5 /f", AppWinStyle.Hide, True, -1)
            ToolStripMenuItem3.Text = "WFL Tool" + VerLabel.Text                       '判断并且改为wfltool
            现代当前ToolStripMenuItem.Text = "现代 (当前)"
            伪旧ToolStripMenuItem.Text = "伪旧"
            Exit Sub     '结束事件防止执行下面
        End If
wflttext:
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v LegacyHomeUI /T REG_SZ /d True /f", AppWinStyle.Hide, True, -1)
        ToolStripMenuItem3.Text = "欢迎使用" + VerLabel.Text
        现代当前ToolStripMenuItem.Text = "现代"              '例外：改为欢迎使用
        伪旧ToolStripMenuItem.Text = "伪旧 (当前)"
        'Label1.Font = New Font("新宋体", 12, FontStyle.Bold, Font.Style.Italic)   ’废弃的字体代码
    End Sub

    Private Sub 新版覆盖返回方式ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 新版覆盖返回方式ToolStripMenuItem.Click
        '旧版弹出窗口方式
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v LegacyMoreUI /T REG_SZ /d 5 /f", AppWinStyle.Hide, True, -1)
        '执行操作
        Button8.Visible = False
        Button19.Visible = True
        Button13.Visible = False
        Button10.Visible = True
        新版覆盖返回方式ToolStripMenuItem.Text = "新版覆盖加返回键方式 (当前)"
        旧版ToolStripMenuItem.Text = "旧版弹出窗口方式"
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim NForm5 As New Form5()
        NForm5.Show()                '打开附件窗口（不关式）
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim OF2 As New Form2()
        OF2.Show()                               '打开查看更多（不关式）
    End Sub

    Private Sub 现代当前ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 现代当前ToolStripMenuItem.Click
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v LegacyHomeUI /T REG_SZ /d 5 /f", AppWinStyle.Hide, True, -1)
        ToolStripMenuItem3.Text = "WFL Tool" + VerLabel.Text                    '主界面右上角wfltool
        现代当前ToolStripMenuItem.Text = "现代 (当前)"
        伪旧ToolStripMenuItem.Text = "伪旧"
    End Sub

    Private Sub 伪旧ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 伪旧ToolStripMenuItem.Click
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v LegacyHomeUI /T REG_SZ /d True /f", AppWinStyle.Hide, True, -1)
        ToolStripMenuItem3.Text = "欢迎使用" + VerLabel.Text                       '主界面右上角wfltool
        现代当前ToolStripMenuItem.Text = "现代"
        伪旧ToolStripMenuItem.Text = "伪旧 (当前)"
        仅版本号ToolStripMenuItem.Text = "仅版本号"
        仅软件名ToolStripMenuItem.Text = "仅软件名"
    End Sub

    Private Sub 所有应用ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 所有应用ToolStripMenuItem.Click
        Shell("cmd.exe /c start shell:::{4234D49B-0245-4DF3-B780-3893943456E1}", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub 临时打开ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 临时打开ToolStripMenuItem.Click
        Form13.Show()   '临时打开托盘图标
    End Sub

    Private Sub 启动时打开ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 启动时打开ToolStripMenuItem.Click
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v TrayIcon /T REG_SZ /d True /f", AppWinStyle.Hide, True, -1)
        启动时不打开当前ToolStripMenuItem.Text = "启动时不打开"
        启动时打开ToolStripMenuItem.Text = "启动时打开 (当前,重启应用生效)"
        On Error GoTo legacy
        Dim WinAppSdkUi As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\DBT\WFL Tool", "WinAppSdkUi", Nothing)
        If WinAppSdkUi = "1" Then              'WinAppSdk弹窗
            Dim InstallLocation As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool", "InstallLocation", Nothing)
            Shell(InstallLocation + "\MessageBox.exe ""设置重启应用生效，但你可以手动临时打开/关闭托盘图标"" ""通知区域图标"" 0 64 0", AppWinStyle.NormalFocus, False, -1)
        Else              '旧版弹窗
legacy:
            MsgBox("设置重启应用生效，但你可以手动临时打开/关闭托盘图标", 0, "通知区域图标")
        End If
    End Sub

    Private Sub 启动时不打开当前ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 启动时不打开当前ToolStripMenuItem.Click
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v TrayIcon /T REG_SZ /d 3 /f", AppWinStyle.Hide, True, -1)
        启动时不打开当前ToolStripMenuItem.Text = "启动时不打开 (当前,重启应用生效)"
        启动时打开ToolStripMenuItem.Text = "启动时打开"
        On Error GoTo legacy
        Dim WinAppSdkUi As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\DBT\WFL Tool", "WinAppSdkUi", Nothing)
        If WinAppSdkUi = "1" Then              'WinAppSdk弹窗
            Dim InstallLocation As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool", "InstallLocation", Nothing)
            Shell(InstallLocation + "\MessageBox.exe ""设置重启应用生效，但你可以手动临时打开/关闭托盘图标"" ""通知区域图标"" 0 64 0", AppWinStyle.NormalFocus, False, -1)
        Else              '旧版弹窗
legacy:
            MsgBox("设置重启应用生效，但你可以手动临时打开/关闭托盘图标", 0, "通知区域图标")
        End If
    End Sub

    Private Sub 命令提示符管理员ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 命令提示符管理员ToolStripMenuItem.Click
        CreateObject("shell.application").shellexecute("cmd.exe", "", "", "runas", 1)
    End Sub

    Private Sub 命令提示符ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 命令提示符ToolStripMenuItem.Click
        CreateObject("shell.application").shellexecute("cmd.exe", "", "", "", 1)
    End Sub

    Private Sub 命令提示符x86ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 命令提示符x86ToolStripMenuItem.Click
        Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
        Shell(SystemRoot + "\syswow64\cmd.exe", AppWinStyle.NormalFocus, False, -1)
    End Sub

    Private Sub 命令提示符x86管理员ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 命令提示符x86管理员ToolStripMenuItem.Click
        Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
        CreateObject("shell.application").shellexecute(SystemRoot + "\syswow64\cmd.exe", "goto :Admin", "", "runas", 1)
    End Sub

    Private Sub 发送反馈邮箱ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 发送反馈邮箱ToolStripMenuItem.Click
        Shell("cmd.exe /c start mailto:z181k@139.com?subject=WFL+Tool+(x64)+%E5%8F%8D%E9%A6%88%E9%82%AE%E4%BB%B6+(%E8%AF%B7%E5%8B%BF%E6%9B%B4%E6%94%B9%E4%B8%BB%E9%A2%98))", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub 时钟app_Click(sender As Object, e As EventArgs) Handles 时钟app.Click
        Shell("cmd.exe /c start ms-clock:1", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub 媒体播放器_Click(sender As Object, e As EventArgs) Handles 媒体播放器.Click
        Shell("cmd.exe /c start MsWindowsMusic:1", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub 微软商店_Click(sender As Object, e As EventArgs) Handles 微软商店.Click
        Shell("cmd.exe /c start ms-windows-store://home", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub UWP资源管理器_Click(sender As Object, e As EventArgs) Handles UWP资源管理器.Click
        Shell("cmd.exe /c start explorer.exe shell:AppsFolder\c5e2524a-ea46-4f67-841f-6a9465d9d515_cw5n1h2txyewy!App", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub 清除数据并退出程序ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 清除数据并退出程序ToolStripMenuItem.Click
        Form11.Show()
    End Sub

    Private Sub UUPDump不忘初心ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UUPDump不忘初心ToolStripMenuItem.Click
        Shell("cmd.exe /c start https://www.uupdump.cn/", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub 注册表编辑器多开ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 注册表编辑器多开ToolStripMenuItem.Click
        Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
        CreateObject("shell.application").shellexecute(SystemRoot + "\regedit.exe", "-m", "", "", 1)
    End Sub

    Private Sub 注册表编辑器不多开ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 注册表编辑器不多开ToolStripMenuItem.Click
        Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
        CreateObject("shell.application").shellexecute(SystemRoot + "\regedit.exe", "", "", "", 1)
    End Sub

    Private Sub 注册表编辑器多开x86ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 注册表编辑器多开x86ToolStripMenuItem.Click
        Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
        CreateObject("shell.application").shellexecute(SystemRoot + "\syswow64\regedit.exe", "-m", "", "", 1)
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        Form11.Show()
    End Sub

    Private Sub 电池健康ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 电池健康ToolStripMenuItem.Click
        Shell("cmd /c powercfg.exe /batteryreport /OUTPUT ""%Temp%\batteryreport_formWFLt.html""", AppWinStyle.Hide, True, -1)
        '上面是生成电池使用时间报告，下面是加载电池使用时间报告
        Shell("cmd.exe /c ""%Temp%\batteryreport_formWFLt.html""", AppWinStyle.Hide, False, -1)
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        On Error GoTo legacy        '重启explorer
        Dim WinAppSdkUi As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\DBT\WFL Tool", "WinAppSdkUi", Nothing)
        If WinAppSdkUi = "1" Then              'WinAppSdk弹窗
            Dim InstallLocation As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool", "InstallLocation", Nothing)
            Shell(InstallLocation + "\MessageBox.exe ""请保存数据，所有打开的文件夹将关闭(包括文件复制)。"" ""Microsoft Windows"" 0 0 0", AppWinStyle.NormalFocus, True, -1)
        Else              '旧版弹窗
legacy:
            MsgBox("请保存数据，所有打开的文件夹将关闭(包括文件复制)。", MsgBoxStyle.OkOnly, "Microsoft Windows")
        End If
        Shell("taskkill.exe /im explorer.exe /f", AppWinStyle.Hide, True, -1)
        Shell("cmd.exe /c start %windir%\explorer.exe", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub 仅软件名ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 仅软件名ToolStripMenuItem.Click
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v LegacyHomeUI /T REG_SZ /d OnlyAppName /f", AppWinStyle.Hide, True, -1)
        ToolStripMenuItem3.Text = "WFL Tool"                       '主界面右上角wfltool
        现代当前ToolStripMenuItem.Text = "现代"
        伪旧ToolStripMenuItem.Text = "伪旧"
        仅版本号ToolStripMenuItem.Text = "仅版本号"
        仅软件名ToolStripMenuItem.Text = "仅软件名 (当前)"
    End Sub

    Private Sub 仅版本号ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 仅版本号ToolStripMenuItem.Click
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v LegacyHomeUI /T REG_SZ /d OnlyVersion /f", AppWinStyle.Hide, True, -1)
        ToolStripMenuItem3.Text = VerLabel.Text                       '主界面右上角wfltool
        现代当前ToolStripMenuItem.Text = "现代"
        伪旧ToolStripMenuItem.Text = "伪旧"
        仅版本号ToolStripMenuItem.Text = "仅版本号 (当前)"
        仅软件名ToolStripMenuItem.Text = "仅软件名"
    End Sub

    Private Sub 计算机管理当前ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 计算机管理当前ToolStripMenuItem.Click
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v cctButton /T REG_SZ /d 0 /f", AppWinStyle.Hide, True, -1)
        计算机管理当前ToolStripMenuItem.Text = "计算机管理 (当前)"
        任务管理器x86ToolStripMenuItem.Text = "任务管理器 x86"           '查看更多内部功能
        命令提示符管理员ToolStripMenuItem1.Text = "管理员命令提示符"
    End Sub

    Private Sub 命令提示符管理员ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles 命令提示符管理员ToolStripMenuItem1.Click
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v cctButton /T REG_SZ /d 1 /f", AppWinStyle.Hide, True, -1)
        计算机管理当前ToolStripMenuItem.Text = "计算机管理"
        任务管理器x86ToolStripMenuItem.Text = "任务管理器 x86"           '查看更多内部功能
        命令提示符管理员ToolStripMenuItem1.Text = "管理员命令提示符 (当前)"
    End Sub

    Private Sub 任务管理器x86ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 任务管理器x86ToolStripMenuItem.Click
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v cctButton /T REG_SZ /d 2 /f", AppWinStyle.Hide, True, -1)
        计算机管理当前ToolStripMenuItem.Text = "计算机管理"
        任务管理器x86ToolStripMenuItem.Text = "任务管理器 x86 (当前)"           '查看更多内部功能
        命令提示符管理员ToolStripMenuItem1.Text = "管理员命令提示符"
    End Sub

    Private Sub WFLTool5周年ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WFLTool5周年ToolStripMenuItem.Click
        Form3.Show()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Panel1.Visible = False
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Panel1.Visible = False
        'Me.Text = "WFL Tool - Beta 版 - 仅用于公测"
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v Preview /T REG_SZ /d 9504.2 /f", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub 设备管理器错误代码帮助helpmenu_Click(sender As Object, e As EventArgs) Handles 设备管理器错误代码帮助helpmenu.Click
        On Error GoTo legacy
        Dim InstallLocation As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool", "InstallLocation", Nothing)
        Dim EDGEWV2 As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Microsoft EdgeWebView", "Version", Nothing)
        If EDGEWV2 = "" Then               '判断EDGE WEBVIEW2是否存在
            GoTo legacy
        End If
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v EWV2webpageClean /T REG_SZ /d True /f", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v EWV2webpageTitle /T REG_SZ /d ""Windows 设备管理器 中的错误代码 - Microsoft 支持"" /f", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v EWV2webpageShowIcon /T REG_SZ /d False /f", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v EWV2webpageURL /T REG_SZ /d """ + InstallLocation + "\EWV2viewer\deverrcodehlp.html"" /f", AppWinStyle.Hide, True, -1)
        Shell("EWV2viewer\EWV2Viewer.exe", AppWinStyle.NormalFocus, False, -1)   '写入启动参数注册表并且启动ewv2
        Exit Sub
legacy:
        Shell("cmd.exe /c start https://go.microsoft.com/fwlink/?LinkID=2004354", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v EWV2webpageClean /T REG_SZ /d False /f", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub 关于设备管理器错误代码的帮助ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 关于设备管理器错误代码的帮助ToolStripMenuItem.Click
        On Error GoTo legacy
        Dim InstallLocation As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool", "InstallLocation", Nothing)
        Dim EDGEWV2 As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Microsoft EdgeWebView", "Version", Nothing)
        If EDGEWV2 = "" Then               '判断EDGE WEBVIEW2是否存在
            GoTo legacy
        End If
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebpageViewer"" /v EWV2webpageClean /T REG_SZ /d True /f", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebpageViewer"" /v EWV2webpageTitle /T REG_SZ /d ""Windows 中""""设备管理器""""中的错误代码 - Microsoft 支持"" /f", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebpageViewer"" /v EWV2webpageShowIcon /T REG_SZ /d False /f", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebpageViewer"" /v EWV2webpageURL /T REG_SZ /d """ + InstallLocation + "\EWV2viewer\deverrcodehlp.html"" /f", AppWinStyle.Hide, True, -1)
        Shell("EWV2viewer\EWV2Viewer.exe", AppWinStyle.NormalFocus, False, -1)   '写入启动参数注册表并且启动ewv2
        Exit Sub
legacy:
        Shell("cmd.exe /c start https://go.microsoft.com/fwlink/?LinkID=2004354", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v EWV2webpageClean /T REG_SZ /d False /f", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub 暗色ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 暗色ToolStripMenuItem.Click
        Application.SetColorMode(SystemColorMode.Dark)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v NColor /T REG_SZ /d Dark /f", AppWinStyle.Hide, True, -1)
        Loadpga.Show()
        Close()
    End Sub

    Private Sub 亮色ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 亮色ToolStripMenuItem.Click
        Application.SetColorMode(SystemColorMode.Classic)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v NColor /T REG_SZ /d White /f", AppWinStyle.Hide, True, -1)
        Loadpga.Show()
        Close()
        '下面是之前浅色会跳到旧net fx4.8框架的代码
        'Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v Napp /T REG_SZ /d False /f", AppWinStyle.Hide, True, -1)
        'Shell("WFL Tool.exe", AppWinStyle.NormalFocus, False, -1)
        'Application.Exit()
        'Exit Sub
    End Sub

    Private Sub 自动切换ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 自动ToolStripMenuItem.Click
        Application.SetColorMode(SystemColorMode.System)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v NColor /T REG_SZ /d Auto /f", AppWinStyle.Hide, True, -1)
        Loadpga.Show()
        Close()
    End Sub

    Private Sub ToolStripMenuItem25_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem25.Click
        OpenFileDialog1.ShowDialog()    '启动文件浏览
    End Sub

    Private Sub ToolStripMenuItem30_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem30.Click
        On Error GoTo legacy
        Dim InstallLocation As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool", "InstallLocation", Nothing)
        Dim EDGEWV2 As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Microsoft EdgeWebView", "Version", Nothing)
        If EDGEWV2 = "" Then               '判断EDGE WEBVIEW2是否存在
            GoTo legacy
        End If
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebpageViewer"" /v EWV2webpageClean /T REG_SZ /d True /f", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebpageViewer"" /v EWV2webpageTitle /T REG_SZ /d ""沉浸式网页预览工具 - WFL Tool WebPageViewer"" /f", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebpageViewer"" /v EWV2webpageURL /T REG_SZ /d """ + InstallLocation + "\EWV2viewer\iwpt.html"" /f", AppWinStyle.Hide, True, -1)
        Shell("EWV2viewer\EWV2Viewer.exe", AppWinStyle.NormalFocus, False, -1)   '写入启动参数注册表并且启动ewv2
        Exit Sub
legacy:                           'EDGE WEBVIEW2不存在或者无法启动ewv2的旧版方案
        On Error GoTo legacy2
        Dim WinAppSdkUi As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\DBT\WFL Tool", "WinAppSdkUi", Nothing)
        If WinAppSdkUi = "1" Then              'WinAppSdk弹窗
            Shell(InstallLocation + "\MessageBox.exe ""使用该功能需先在你的电脑上以用户模式安装 WFL Tool 并安装有以管理员身份安装的的 Edge Webview2"" ""WFL Tool"" 0 64 0", AppWinStyle.NormalFocus, False, -1)
        Else              '旧版弹窗
legacy2:
            MsgBox("使用该功能需先在你的电脑上以用户模式安装 WFL Tool 并安装有以管理员身份安装的的 Edge Webview2", MsgBoxStyle.Information, "WFL Tool")
        End If
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v EWV2webpageClean /T REG_SZ /d False /f", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub 运行ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 运行ToolStripMenuItem.Click
        '调用运行函数
        RunFileDialog.ShowRunDialog(Me, "", "运行  -  WFL Tool", "WFL Tool 将根据你所输入的名称,为你打开相应的程序、文件夹、文档、Internet 资源以及 Intranet 资源。")
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        '——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————
        '该部分代码代码存在 DeepSeek 生成内容
        '——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————
        ' 遍历所有打开的窗体
        For Each form As Form In Application.OpenForms
            ' 检查是否为Form13实例
            If TypeOf form Is Form13 Then
                Form13.NotifyIcon1.ShowBalloonTip(5000, "WFL Tool 未完全退出", "你配置了在通知区域显示图标，关闭主界面时不会退出 WFL Tool，如需退出，请在通知区域图标上操作。", ToolTipIcon.Info)
                Exit For
            End If
        Next
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Form2.Show()                               '打开查看更多（关闭式）
        Close()
    End Sub

    Private Sub 下载新版本WFLToolTSMI_Click(sender As Object, e As EventArgs) Handles 下载新版本WFLToolTSMI.Click
        On Error GoTo legacy
        Dim EDGEWV2 As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Microsoft EdgeWebView", "Version", Nothing)
        If EDGEWV2 = "" Then               '判断EDGE WEBVIEW2是否存在
            GoTo legacy
        End If
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v EWV2webpageClean /T REG_SZ /d True /f", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v EWV2webpageShow /T REG_SZ /d True /f", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v EWV2webpageTitle /T REG_SZ /d ""下载新版本 WFL Tool - 请手动下载完整最新版安装包 - WFL Tool 下载中心  (无法访问请到关于页面右击检查更新链接选择应急链接重试)"" /f", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v EWV2webpageURL /T REG_SZ /d https://medbt-my.sharepoint.cn/:f:/g/personal/dbtob_medbt_partner_onmschina_cn/IgBdYnImsH-5RIqkDkx3h2pCAZaJ_8KKWMkn7g9S3mbt5tM?e=EaTFxL /f", AppWinStyle.Hide, True, -1)      'onedrive链接，方便下载
        Shell("EWV2viewer\EWV2Viewer.exe", AppWinStyle.NormalFocus, False, -1)   '写入启动参数注册表并且启动ewv2
        Exit Sub
legacy:
        Dim NF4 As New Form4()
        NF4.Show()
        NF4.Text = "下载新版本 WFL Tool - 无法访问请到关于页面右击检查更新链接选择应急链接重试 - WFL Tool"                 'EDGE WEBVIEW2不存在或者无法启动ewv2的旧版方案
        NF4.MaximizeBox = True
        NF4.WebBrowser1.Url = New Uri("https://z181k.lanzoui.com/s/WFL-Tool")            '使用了方便分发的定制链接，vip到期就失效
        NF4.MaximumSize = New Size(0, 0)
        NF4.MinimumSize = New Size(0, 0)
        NF4.WebBrowser1.ScriptErrorsSuppressed = True
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v EWV2webpageClean /T REG_SZ /d False /f", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub 禁用Win自动更新ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 禁用Win自动更新ToolStripMenuItem.Click
        CreateObject("shell.application").shellexecute("reg.exe", "add HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU /v AUOptions /T REG_DWORD /d 0 /f", "", "runas", 0)
        CreateObject("shell.application").shellexecute("reg.exe", "add HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU /v NoAutoUpdate /T REG_DWORD /d 1 /f", "", "runas", 0)
        Timer1.Start()
    End Sub

    Private Sub 开启Win自动更新ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 开启Win自动更新ToolStripMenuItem.Click
        CreateObject("shell.application").shellexecute("reg.exe", "delete HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU /v AUOptions /f", "", "runas", 0)
        CreateObject("shell.application").shellexecute("reg.exe", "delete HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU /v NoAutoUpdate /f", "", "runas", 0)
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        '检查注册表Windows自动更新设置
        Timer1.Stop()
        On Error GoTo ntc
        Dim WinNoAutoUpdate As Integer = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU", "NoAutoUpdate", Nothing)
        If WinNoAutoUpdate = 1 Then
            开启Win自动更新ToolStripMenuItem.Text = "开启自动更新"
            禁用Win自动更新ToolStripMenuItem.Text = "禁用自动更新 (当前)"
        Else
ntc:
            开启Win自动更新ToolStripMenuItem.Text = "开启自动更新 (当前)"
            禁用Win自动更新ToolStripMenuItem.Text = "禁用自动更新"
        End If
    End Sub
End Class



'——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————
'==================================================================================================================================================================================================
'——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————


Partial Class AutoSizeFormClass
    Public Structure ControlRect
        Public Name As String '控件名称其实没必要，只是调试时用，可删
        Public Left As Integer
        Public Top As Integer
        Public Width As Integer
        Public Height As Integer
    End Structure

    Public OldCtrl As List(Of ControlRect) = New List(Of ControlRect)()
    Dim CtrlNo As Integer = 0
    Public Sub ControllInitializeSize(ByVal mForm As Control)
        Dim Cr As ControlRect
        Cr.Name = mForm.Name
        Cr.Left = mForm.Left
        Cr.Top = mForm.Top
        Cr.Width = mForm.Width
        Cr.Height = mForm.Height
        OldCtrl.Add(Cr)
        AddControl(mForm)
    End Sub
    Private Sub AddControl(ByVal Ctl As Control)
        For Each c As Control In Ctl.Controls
            Dim ObjCtrl As ControlRect
            ObjCtrl.Name = c.Name
            ObjCtrl.Left = c.Left
            ObjCtrl.Top = c.Top
            ObjCtrl.Width = c.Width
            ObjCtrl.Height = c.Height
            OldCtrl.Add(ObjCtrl)
            If c.Controls.Count > 0 Then
                AddControl(c)
            End If
        Next
    End Sub
    Public Sub ControlAutoSize(ByVal mForm As Control)
        If CtrlNo = 0 Then
            Dim Cr As ControlRect
            Cr.Name = mForm.Name
            Cr.Left = 0
            Cr.Top = 0
            Cr.Width = mForm.PreferredSize.Width
            Cr.Height = mForm.PreferredSize.Height
            OldCtrl.Add(Cr)
            AddControl(mForm)
        End If
        Dim WScale As Single
        WScale = CSng(mForm.Width) / CSng(OldCtrl(0).Width)
        'HelpEWV2.Button3.Text = WScale '利用控件名称显示的窗体大小，可删
        Dim HScale As Single
        HScale = CSng(mForm.Height) / CSng(OldCtrl(0).Height)
        'HelpEWV2.Button4.Text = WScale '利用控件名称显示的窗体大小，可删
        CtrlNo = 1
        AutoScaleControl(mForm, WScale, HScale)

    End Sub
    Private Sub AutoScaleControl(ByVal ctl As Control, ByVal wScale As Single, ByVal hScale As Single)
        Dim ctrLeft0, ctrTop0, ctrWidth0, ctrHeight0 As Integer

        For Each c As Control In ctl.Controls
            ctrLeft0 = OldCtrl(CtrlNo).Left
            ctrTop0 = OldCtrl(CtrlNo).Top
            ctrWidth0 = OldCtrl(CtrlNo).Width
            ctrHeight0 = OldCtrl(CtrlNo).Height

            c.Left = CInt(ctrLeft0 * wScale)
            c.Top = CInt(ctrTop0 * hScale)
            c.Width = CInt(ctrWidth0 * wScale)
            c.Height = CInt(ctrHeight0 * hScale)
            CtrlNo += 1
            If c.Controls.Count > 0 Then
                AutoScaleControl(c, wScale, hScale)
            End If
            '以下代码用于实现表格内各单元格按比例缩放，其实没什么必要，因为DataGridView本身有很好的适应能力
            '任何缩放状态下都可以保证数值显示正常，反而更好，如果行列按窗体缩放比例小到看不清值，有些适得其反
            '（纯属从个人习惯出发的见解）
            'If ctl.GetType.Name Like ("DataGridView") Then
            '    Dim Dgv As DataGridView
            '    Dgv = ctl
            '    Cursor.Current = Cursors.WaitCursor
            '    Dim widths As Integer = 0
            '    For i As Integer = 0 To Dgv.Columns.Count
            '        If i > 0 Then
            '            Dgv.AutoResizeColumn(i - 1, DataGridViewAutoSizeColumnMode.AllCells)
            '            'widths += Dgv.Columns(i - 1).Width
            '        End If
            '    Next
            '    If widths >= Dgv.Size.Width Then
            '        Dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            '    Else
            '        Dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            '    End If
            '    Cursor.Current = Cursors.Default
            'End If
        Next

    End Sub
End Class



'——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————
'==================================================================================================================================================================================================
'——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————


'下面是调用位于shell32.dll的运行函数
'该部分代码代码由 DeepSeek 生成，是 AIGC 内容

Public Class RunFileDialog
    ' ============================================
    ' Windows API 常量声明
    ' ============================================
    Public Class RunFileDlgFlags
        Public Const RFF_NOBROWSE As UInteger = &H1           ' 移除"浏览"按钮
        Public Const RFF_NODEFAULT As UInteger = &H2          ' 没有默认项
        Public Const RFF_CALCDIRECTORY As UInteger = &H4      ' 基于lpstrDirectory计算目录
        Public Const RFF_NOLABEL As UInteger = &H8            ' 移除"打开"标签
        Public Const RFF_NOSEPARATEMEM As UInteger = &H20     ' 不单独记忆
    End Class

    ' ============================================
    ' 方法1：使用序号直接声明（最推荐）
    ' ============================================

    ''' <summary>
    ''' 直接声明 RunFileDlg 函数（序号61）
    ''' </summary>
    <DllImport("shell32.dll", EntryPoint:="#61", CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.StdCall)>
    Private Shared Sub RunFileDlg_Ordinal(
        ByVal hwndOwner As IntPtr,
        ByVal hIcon As IntPtr,
        <MarshalAs(UnmanagedType.LPWStr)> ByVal lpstrDirectory As String,
        <MarshalAs(UnmanagedType.LPWStr)> ByVal lpstrTitle As String,
        <MarshalAs(UnmanagedType.LPWStr)> ByVal lpstrDescription As String,
        ByVal uFlags As UInteger
    )
    End Sub

    ''' <summary>
    ''' 方法1：最简单的调用方式
    ''' </summary>
    Public Shared Sub ShowRunDialogSimple()
        Try
            ' 显示标准的运行对话框
            RunFileDlg_Ordinal(
                IntPtr.Zero,                                    ' hwndOwner: 无父窗口
                IntPtr.Zero,                                    ' hIcon: 使用默认图标
                Nothing,                                        ' lpstrDirectory: 默认目录
                "运行",                                          ' lpstrTitle: 对话框标题
                "输入程序、文件夹、文档或 Internet 资源名称，我们将为您打开它。", ' lpstrDescription: 描述文本
                0                                               ' uFlags: 默认选项
            )
        Catch ex As Exception
            MessageBox.Show("无法显示运行对话框: " & ex.Message, "错误",
                           MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' 方法1扩展：使用更多参数
    ''' </summary>
    Public Shared Sub ShowRunDialogAdvanced(ByVal parentWindow As IWin32Window,
                                           ByVal defaultDirectory As String,
                                           ByVal flags As UInteger)
        Dim hwnd As IntPtr = IntPtr.Zero
        If parentWindow IsNot Nothing Then
            hwnd = parentWindow.Handle
        End If

        RunFileDlg_Ordinal(
            hwnd,
            IntPtr.Zero,
            defaultDirectory,
            "运行程序",
            "请输入要运行的程序名称:",
            flags
        )
    End Sub
    ''' <summary>
    ''' 显示运行对话框（推荐使用）
    ''' </summary>
    ''' <param name="owner">父窗口（可选）</param>
    ''' <param name="defaultDirectory">默认目录（可选）</param>
    ''' <param name="title">对话框标题（可选）</param>
    ''' <param name="description">描述文本（可选）</param>
    ''' <param name="showBrowseButton">是否显示浏览按钮</param>
    Public Shared Sub ShowRunDialog(
        Optional ByVal owner As IWin32Window = Nothing,
        Optional ByVal defaultDirectory As String = Nothing,
        Optional ByVal title As String = "运行",
        Optional ByVal description As String = "输入程序、文件夹、文档或 Internet 资源名称，我们将为您打开它。",
        Optional ByVal showBrowseButton As Boolean = True
    )
        Dim hwnd As IntPtr = IntPtr.Zero
        If owner IsNot Nothing Then
            hwnd = owner.Handle
        End If

        Dim flags As UInteger = 0
        If Not showBrowseButton Then
            flags = flags Or RunFileDlgFlags.RFF_NOBROWSE
        End If

        Try
            RunFileDlg_Ordinal(hwnd, IntPtr.Zero, defaultDirectory, title, description, flags)
        Catch ex As Exception
            ' 备选方案
            'ShowRunDialogViaRundll32()
        End Try
    End Sub
End Class
