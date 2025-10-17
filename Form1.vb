Public Class Form1
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
        If CurrentBuild >= "10240" Then   'Win10/11更新
            Shell("cmd.exe /c start ms-settings:windowsupdate", AppWinStyle.Hide, True, -1)
            Exit Sub
        End If
        Shell("wuapp.exe", AppWinStyle.NormalFocus, False, -1)   'win7/8/vista更新
    End Sub

    Private Sub WindowsDefenderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WindowsDefenderToolStripMenuItem.Click
        Shell("cmd.exe /c start WindowsDefender:5", AppWinStyle.Hide, True, -1) 'win安全中心
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim NForm5 As New Form5()
        NForm5.Show()                '打开附件窗口(关闭式)
        Close()
    End Sub

    Private Sub 更新本程序ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 更新本程序ToolStripMenuItem.Click
        On Error GoTo legacy
        Dim EDGEWV2 As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Microsoft EdgeWebView", "Version", Nothing)
        If EDGEWV2 = "" Then               '判断EDGE WEBVIEW2是否存在
            GoTo legacy
        End If
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v EWV2webpageShow /T REG_SZ /d True /f", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v EWV2webpageTitle /T REG_SZ /d ""更新本程序 - 下载密码: down"" /f", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v EWV2webpageURL /T REG_SZ /d https://dbtpan.lanzouq.com/b0205vf6f /f", AppWinStyle.Hide, True, -1)
        Shell("EWV2viewer\EWV2Viewer.exe", AppWinStyle.NormalFocus, False, -1)   '写入启动参数注册表并且启动ewv2
        Exit Sub
legacy:
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v EWV2webpageShow /T REG_SZ /d 0 /f", AppWinStyle.Hide, True, -1)
        Dim NF4 As New Form4()
        NF4.Show()
        NF4.Text = "更新本程序 - 下载密码: down - 电脑功能启动器"            'EDGE WEBVIEW2不存在或者无法启动ewv2的旧版方案
        NF4.MaximizeBox = True
        NF4.WebBrowser1.Url = New Uri("https://dbtpan.lanzoux.com/b0205vf6f")
        NF4.MaximumSize = New Size(0, 0)
        NF4.MinimumSize = New Size(0, 0)
        NF4.WebBrowser1.ScriptErrorsSuppressed = True
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
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v EWV2webpageShow /T REG_SZ /d True /f", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v EWV2webpageTitle /T REG_SZ /d ""WFL Tool 帮助"" /f", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v EWV2webpageURL /T REG_SZ /d https://kdocs.cn/l/sqxx3d4vumUT /f", AppWinStyle.Hide, True, -1)
        Shell("EWV2viewer\EWV2Viewer.exe", AppWinStyle.NormalFocus, False, -1)   '写入启动参数注册表并且启动ewv2
        Exit Sub
legacy:                           'EDGE WEBVIEW2不存在或者无法启动ewv2的旧版方案
        Shell("cmd.exe /c start https://kdocs.cn/l/sqxx3d4vumUT", AppWinStyle.Hide, True, -1)
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
        Dim CurrentBuild As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild", Nothing)
        If CurrentBuild = "26100" Then   'Win11 24h2/win server 2025更新日志及离线更新包
            Dim InstallationType As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "InstallationType", Nothing)
            If InstallationType = "Client" Then
                Shell("cmd.exe /c start https://support.microsoft.com/zh-cn/topic/windows-11%E7%89%88%E6%9C%AC-24h2-%E6%9B%B4%E6%96%B0%E5%8E%86%E5%8F%B2%E8%AE%B0%E5%BD%95-0929c747-1815-4543-8461-0160d16f15e5", AppWinStyle.Hide, True, -1)
                Exit Sub
            End If
            Shell("cmd.exe /c start https://support.microsoft.com/zh-cn/topic/windows-server-2025-%E6%9B%B4%E6%96%B0%E5%8E%86%E5%8F%B2%E8%AE%B0%E5%BD%95-10f58da7-e57b-4a9d-9c16-9f1dcd72d7d7", AppWinStyle.Hide, True, -1)
            Exit Sub
        ElseIf CurrentBuild >= "21380" Then   'Win11其他版本更新日志及离线更新包
            Shell("cmd.exe /c start https://support.microsoft.com/zh-cn/topic/windows-11%E7%89%88%E6%9C%AC-23h2-%E6%9B%B4%E6%96%B0%E5%8E%86%E5%8F%B2%E8%AE%B0%E5%BD%95-59875222-b990-4bd9-932f-91a5954de434", AppWinStyle.Hide, True, -1)
            Exit Sub
        ElseIf CurrentBuild = "20348" Then       'win server 2022更新日志及离线更新包
            Shell("cmd.exe /c start https://support.microsoft.com/zh-cn/topic/windows-server-2022-%E6%9B%B4%E6%96%B0%E5%8E%86%E5%8F%B2%E8%AE%B0%E5%BD%95-e1caa597-00c5-4ab9-9f3e-8212fe80b2ee", AppWinStyle.Hide, True, -1)
            Exit Sub
        ElseIf CurrentBuild >= "10240" Then  'win10更新日志及离线更新包
            Shell("cmd.exe /c start https://support.microsoft.com/zh-cn/topic/windows-10-%E6%9B%B4%E6%96%B0%E5%8E%86%E5%8F%B2%E8%AE%B0%E5%BD%95-8127c2c6-6edf-4fdf-8b9f-0f7be1ef3562", AppWinStyle.Hide, True, -1)
            Exit Sub
        End If                 '其他版本
        Shell("cmd.exe /c start https://www.catalog.update.microsoft.com/Home.aspx", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click  '内存诊断
        Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
        CreateObject("shell.application").shellexecute(SystemRoot + "\system32\MdSched.exe", "", "", "", 0)
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

    Private Sub 更新有关帮助ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 更新有关帮助ToolStripMenuItem.Click
        Shell("hh.exe http://support.microsoft.com/zh-cn/windows/%E6%9B%B4%E6%96%B0-windows-3c5ae7fc-9fb6-9af1-1984-b5e0412c556a", AppWinStyle.NormalFocus, False, -1)
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

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click   '开机启动文件夹
        Shell("explorer.exe C:\ProgramData\Microsoft\Windows\Start Menu\Programs\StartUp", AppWinStyle.NormalFocus, False, -1)
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
        CreateObject("shell.application").shellexecute(SystemRoot + "\system32\gpedit.msc", "", "", "", 0)        '组策略
    End Sub

    Private Sub 打开Win11IE浏览器ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开Win11IE浏览器ToolStripMenuItem.Click
        Shell("cmd.exe /c start winhlp32.exe", AppWinStyle.Hide, True, -1)            'windows帮助和支持
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
        Dim PROCESSOR_ARCHITECTURE As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Environment", "PROCESSOR_ARCHITECTURE", Nothing)
        If PROCESSOR_ARCHITECTURE = "x86" Then
            GoTo starttask                   '判断兼容性
        End If
        MsgBox("此版本仅为 x86 架构处理器提供, x64 架构请使用 x64 版本,我们没有提供 arm64 架构版本,请关注我们的网站,我们可能会在将来提供基于 arm64 的本软件。", MsgBoxStyle.Critical, "WFL Tool")
        End
starttask:
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
        Dim LegacyMoreUI As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WFL Tool", True).GetValue("LegacyMoreUI", "无")
        If LegacyMoreUI = "True" Then
            Button19.Visible = False
            Button8.Visible = True    '查看更多和附件
            Button10.Visible = False
            Button13.Visible = True
            新版覆盖返回方式ToolStripMenuItem.Text = "新版覆盖加返回键方式"
            旧版ToolStripMenuItem.Text = "旧版弹出窗口方式 (当前)"
        End If
        Dim LegacyHomeUI As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\DBT\WFL Tool", True).GetValue("LegacyHomeUI", "无")
        If LegacyHomeUI = "True" Then
            ToolStripMenuItem3.Text = "欢迎使用"                      '主界面右上角wfltool
            现代当前ToolStripMenuItem.Text = "现代"
            伪旧ToolStripMenuItem.Text = "伪旧 (当前)"
        End If
        Dim TrayIcon As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\DBT\WFL Tool", True).GetValue("TrayIcon", "无")
        If TrayIcon = "True" Then
            Form13.Show()                       '托盘图标
            启动时不打开当前ToolStripMenuItem.Text = "启动时不打开"
            启动时打开ToolStripMenuItem.Text = "启动时打开 (当前)"
        End If
        Dim x86EndSupport As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\DBT\WFL Tool", True).GetValue("x86EndSupport", "无")
        If x86EndSupport = "DoNotShow" Then
            Panel1.Visible = False
        End If
        Dim CurrentBuild As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild", Nothing)
        If CurrentBuild < 5033 Then
            ToolStripMenuItem15.Enabled = False
            所有任务ToolStripMenuItem.Enabled = False
            查看系统位数ToolStripMenuItem.Enabled = False
            Windows1011ToolStripMenuItem.Enabled = False
            Button3.Enabled = False
            Button11.Enabled = False
        ElseIf CurrentBuild < 7600 Then              '检查版本控制系统修改显示
            系统修改ToolStripMenuItem.Enabled = False
        End If
        If CurrentBuild < 18362 Then              '检查版本控制UWP应用显示
            UWP应用ToolStripMenuItem.Enabled = False
        End If
        'MsgBox("此版本仅供内部测试，Alpha 版本未经我们允许不得外泄，属于内部机密，如你意外获得此版本，请立即删除并下载正式版，并可以向我们举报泄露行为")
        'MsgBox("Beta 版本仅用于公测，如你意外获得此版本，请立即删除并下载正式版", 0, "WFL Tool")
        Exit Sub
openreg:
        '辅助打开软件
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v OPEN /T REG_SZ /d x64 /f", AppWinStyle.Hide, True, -1)
        GoTo starttask
    End Sub

    Private Sub Button19_MouseClick(sender As Object, e As MouseEventArgs) Handles Button19.MouseClick
        'If e.Button = MouseButtons.Right Then
        'Dim OF2 As New Form2()
        'OF2.Show()                              ‘废弃的查看更多右键菜单代码
        'Else
        Dim OF2 As New Form2()
        OF2.Show()                               '打开查看更多（关闭式）
        Close()
        'End If
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
            MsgBox("好用请推荐给别人", MsgBoxStyle.Information, "温馨提示")
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
            ToolStripMenuItem3.Text = "WFL Tool  v9.20"                      '判断并且改为wfltool
            现代当前ToolStripMenuItem.Text = "现代 (当前)"
            伪旧ToolStripMenuItem.Text = "伪旧"
            Exit Sub     '结束事件防止执行下面
        End If
wflttext:
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v LegacyHomeUI /T REG_SZ /d True /f", AppWinStyle.Hide, True, -1)
        ToolStripMenuItem3.Text = "欢迎使用  v9.20"
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
        ToolStripMenuItem3.Text = "WFL Tool  v9.20"                   '主界面右上角wfltool
        现代当前ToolStripMenuItem.Text = "现代 (当前)"
        伪旧ToolStripMenuItem.Text = "伪旧"
    End Sub

    Private Sub 伪旧ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 伪旧ToolStripMenuItem.Click
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v LegacyHomeUI /T REG_SZ /d True /f", AppWinStyle.Hide, True, -1)
        ToolStripMenuItem3.Text = "欢迎使用  v9.20"                      '主界面右上角wfltool
        现代当前ToolStripMenuItem.Text = "现代"
        伪旧ToolStripMenuItem.Text = "伪旧 (当前)"
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

    Private Sub 命令提示符x86ToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
        Shell(SystemRoot + "\syswow64\cmd.exe", AppWinStyle.NormalFocus, False, -1)
    End Sub

    Private Sub 命令提示符x86管理员ToolStripMenuItem_Click(sender As Object, e As EventArgs)
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

    Private Sub 注册表编辑器多开x86ToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
        CreateObject("shell.application").shellexecute(SystemRoot + "\syswow64\regedit.exe", "-m", "", "", 1)
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs)
        Form11.Show()
    End Sub

    Private Sub 电池健康ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 电池健康ToolStripMenuItem.Click
        CreateObject("shell.application").shellexecute("cmd.exe", "/c powercfg.exe /batteryreport&start C:\Windows\System32\battery-report.html", "", "runas", 0)
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

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        MsgBox("x86 版本的 WFL Tool 已于 2025/10/17 停止支持，这个版本是在停止当天发布的最后一个版本。很抱歉我们通知的很仓促，但希望您尽快将系统升级至 64 位继续获得支持，或更换您的设备以继续获得支持，获取最新的更新、问题修复和功能。使用停止支持版本所带来的一切后果自负。", "WFL Tool (x86)")
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        MsgBox("使用停止支持版本所带来的一切后果自负。", "WFL Tool (x86)")
        Panel1.Visible = False
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v x86EndSupport /T REG_SZ /d DoNotShow /f", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Panel1.Visible = False
    End Sub
End Class
