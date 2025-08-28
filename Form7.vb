Public Class Form7
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox1.Text = "此功能使用前请先到注册表编辑器修改 HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Control Panel\Settings\Network 的权限"
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Form6.Show()
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Shell("reg.exe add HKCU\Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32 /f /ve", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Shell("reg.exe delete HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Taskband /v MaxThumbSizePx /f", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        Shell("reg.exe add HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Taskband /v MaxThumbSizePx /T REG_DWORD /d 0x12c /f", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        CreateObject("shell.application").shellexecute("reg.exe", "add ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\MTCUVC"" /v EnableMtcUvc /T REG_DWORD /d 1 /f", "", "runas", 0)
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        CreateObject("shell.application").shellexecute("reg.exe", "add ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\MTCUVC"" /v EnableMtcUvc /T REG_DWORD /d 0 /f", "", "runas", 0)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        CreateObject("shell.application").shellexecute("reg.exe", "add ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Control Panel\Settings\Network"" /v ReplaceVan /T REG_DWORD /d 2 /f", "", "runas", 0)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        CreateObject("shell.application").shellexecute("reg.exe", "add ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Control Panel\Settings\Network"" /v ReplaceVan /T REG_DWORD /d 1 /f", "", "runas", 0)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        CreateObject("shell.application").shellexecute("reg.exe", "add ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Control Panel\Settings\Network"" /v ReplaceVan /T REG_DWORD /d 0 /f", "", "runas", 0)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Shell("reg.exe add HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes /v ThemeChangesMousePointers /T REG_DWORD /d 0 /f", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Shell("reg.exe add HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes /v ThemeChangesMousePointers /T REG_DWORD /d 1 /f", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Shell("reg.exe add HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\Explorer /v EnableLegacyBalloonNotifications /T REG_DWORD /d 0 /f", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Shell("reg.exe add HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\Explorer /v EnableLegacyBalloonNotifications /T REG_DWORD /d 1 /f", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Shell("reg.exe add HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Taskband /v MaxThumbSizePx /T REG_DWORD /d 86 /f", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        Shell("UserAccountControlSettings.exe", AppWinStyle.NormalFocus, False, -1)
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Dim OF8 As New Form8()
        OF8.Show()
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        CreateObject("shell.application").shellexecute("reg.exe", "add HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System /v VerboseStatus /T REG_DWORD /d 0 /f", "", "runas", 0)
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        CreateObject("shell.application").shellexecute("reg.exe", "add HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System /v VerboseStatus /T REG_DWORD /d 1 /f", "", "runas", 0)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        CreateObject("shell.application").shellexecute("reg.exe", "add HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\ImmersiveShell /v UseWin32BatteryFlyout /T REG_DWORD /d 1 /f", "", "runas", 0)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CreateObject("shell.application").shellexecute("reg.exe", "add HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\ImmersiveShell /v UseWin32BatteryFlyout /T REG_DWORD /d 0 /f", "", "runas", 0)
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        CreateObject("shell.application").shellexecute("reg.exe", "add HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\FlightedFeatures /v ImmersiveContextMenu /T REG_DWORD /d 0 /f", "", "runas", 0)
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        CreateObject("shell.application").shellexecute("reg.exe", "add HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\FlightedFeatures /v ImmersiveContextMenu /T REG_DWORD /d 1 /f", "", "runas", 0)
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Shell("reg.exe add ""HKEY_CURRENT_USER\Control Panel\Desktop"" /v PaintDesktopVersion /T REG_DWORD /d 0 /f", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        Shell("reg.exe add ""HKEY_CURRENT_USER\Control Panel\Desktop"" /v PaintDesktopVersion /T REG_DWORD /d 1 /f", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        Shell("reg.exe delete ""HKCU\Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}"" /f", AppWinStyle.Hide, True, -1)
    End Sub


    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        CreateObject("shell.application").shellexecute("reg.exe", "add ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\PasswordLess\Device"" /v DevicePasswordLessBuildVersion /T REG_DWORD /d 0 /f", "", "runas", 0)
        CreateObject("shell.application").shellexecute("reg.exe", "add ""HKEY_LOCAL_MACHINE\SOFTWARE\wow6432node\Microsoft\Windows NT\CurrentVersion\PasswordLess\Device"" /v DevicePasswordLessBuildVersion /T REG_DWORD /d 0 /f", "", "runas", 0)
    End Sub

    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
        Shell("reg.exe add HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Taskband /v MaxThumbSizePx /T REG_DWORD /d 1 /f", AppWinStyle.Hide, True, -1)
    End Sub



    Private Sub Button30_Click(sender As Object, e As EventArgs) Handles Button30.Click
        CreateObject("shell.application").shellexecute("cmd.exe", "/c reg.exe add ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows Photo Viewer\Capabilities\FileAssociations"" /v .png /T REG_SZ /d PhotoViewer.FileAssoc.Tiff /f&reg.exe add ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows Photo Viewer\Capabilities\FileAssociations"" /v .ico /T REG_SZ /d PhotoViewer.FileAssoc.Tiff /f&reg.exe add ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows Photo Viewer\Capabilities\FileAssociations"" /v .dib /T REG_SZ /d PhotoViewer.FileAssoc.Tiff /f&reg.exe add ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows Photo Viewer\Capabilities\FileAssociations"" /v .bmp /T REG_SZ /d PhotoViewer.FileAssoc.Tiff /f&reg.exe add ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows Photo Viewer\Capabilities\FileAssociations"" /v .jfif /T REG_SZ /d PhotoViewer.FileAssoc.Tiff /f&reg.exe add ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows Photo Viewer\Capabilities\FileAssociations"" /v .jpe /T REG_SZ /d PhotoViewer.FileAssoc.Tiff /f&reg.exe add ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows Photo Viewer\Capabilities\FileAssociations"" /v .jpeg /T REG_SZ /d PhotoViewer.FileAssoc.Tiff /f&reg.exe add ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows Photo Viewer\Capabilities\FileAssociations"" /v .jpg /T REG_SZ /d PhotoViewer.FileAssoc.Tiff /f", "", "runas", 0)
        '下方是右键菜单增加管理员获取所有权 (系统没有此设置，这是个人添加的)功能废弃代码
        'CreateObject("shell.application").shellexecute("reg.exe", "add HKEY_CLASSES_ROOT\*\shell\runas /T REG_SZ /d ""Take Ownership"" /f", "", "runas", 0)
        'CreateObject("shell.application").shellexecute("reg.exe", "add HKEY_CLASSES_ROOT\*\shell\runas /v NoWorkingDirectory /T REG_SZ /f", "", "runas", 0)
        'CreateObject("shell.application").shellexecute("reg.exe", "add HKEY_CLASSES_ROOT\*\shell\runas\command /v IsolatedCommand /T REG_SZ /d ""cmd.exe /c takeown /f """"%1"""" && icacls """"%1"""" /grant administrators:F"" /f", "", "runas", 0)
        'CreateObject("shell.application").shellexecute("reg.exe", "add HKEY_CLASSES_ROOT\*\shell\runas\command /T REG_SZ /d ""cmd.exe /c takeown /f """"%1"""" && icacls """"%1"""" /grant administrators:F"" /f", "", "runas", 0)
        '上方文件，下方文件夹
        'CreateObject("shell.application").shellexecute("reg.exe", "add HKEY_CLASSES_ROOT\Directory\shell\runas /T REG_SZ /d ""Take Ownership"" /f", "", "runas", 0)
        'CreateObject("shell.application").shellexecute("reg.exe", "add HKEY_CLASSES_ROOT\Directory\shell\runas /v NoWorkingDirectory /T REG_SZ /f", "", "runas", 0)
        'CreateObject("shell.application").shellexecute("reg.exe", "add HKEY_CLASSES_ROOT\Directory\shell\runas\command /v IsolatedCommand /T REG_SZ /d ""cmd.exe /c takeown /f """"%1"""" /r /d y && icacls """"%1"""" /grant administrators:F /t"" /f", "", "runas", 0)
        'CreateObject("shell.application").shellexecute("reg.exe", "add HKEY_CLASSES_ROOT\Directory\shell\runas\command /T REG_SZ /d ""cmd.exe /c takeown /f """"%1"""" /r /d y && icacls """"%1"""" /grant administrators:F /t"" /f", "", "runas", 0)
    End Sub

    Private Sub 返回主界面ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 返回主界面ToolStripMenuItem.Click
        Form1.Show()
    End Sub

    Private Sub 退出程序ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 退出程序ToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub Button34_Click(sender As Object, e As EventArgs) Handles Button34.Click
        MsgBox("请保存数据，所有打开的文件夹将关闭(包括文件复制)。", MsgBoxStyle.OkOnly, "Microsoft Windows")
        Shell("taskkill.exe /im explorer.exe /f", AppWinStyle.Hide, True, -1)
        Shell("cmd.exe /c start %windir%\explorer.exe", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button33_Click(sender As Object, e As EventArgs) Handles Button33.Click
        Shell("cmd.exe /c start shell:::{05d7b0f4-2121-4eff-bf6b-ed3f69b894d9}", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        Shell("cmd.exe /c start shell:::{ED834ED6-4B5A-4bfe-8F11-A626DCB6A921}", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button31_Click(sender As Object, e As EventArgs) Handles Button31.Click
        Shell("cmd.exe /c start shell:::{ED834ED6-4B5A-4bfe-8F11-A626DCB6A921}\pageColorization", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button32_Click(sender As Object, e As EventArgs) Handles Button32.Click
        Shell("cmd.exe /c start shell:::{ED834ED6-4B5A-4bfe-8F11-A626DCB6A921}\pageWallpaper", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        Dim CurrentBuild As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild", Nothing)
        If CurrentBuild < 19041 Then              '检查版本控制netplwiz显示
            GroupBox13.Enabled = False
        End If
        '下面采用14393这个版本作为保底，再之前的win10版本功能缺失过多，故屏蔽
        If CurrentBuild < 14393 Then
            GroupBox6.Enabled = False             '检查版本控制Windows 10 音量控制界面样式显示
            GroupBox16.Enabled = False             '检查版本控制Windows 10 及以上版本控制面板隐藏项目显示
            GroupBox3.Enabled = False             '检查版本控制WWindows 10 电池界面样式显示
            GroupBox2.Enabled = False             '检查版本控制WWindows 10 通知显示
            GroupBox5.Enabled = False             '检查版本控制Win10 网络面板显示
            Button16.Enabled = False            '检查版本控制Windows 10 任务栏透明度设置教程显示
        End If
        '下面是win11隐藏win10专属功能
        If CurrentBuild > 21390 Then
            GroupBox6.Enabled = False              '检查版本控制Windows 10 音量控制界面样式显示
            GroupBox3.Enabled = False            '检查版本控制WWindows 10 电池界面样式显示
            GroupBox2.Enabled = False             '检查版本控制WWindows 10 通知显示
            GroupBox5.Enabled = False            '检查版本控制Win10 网络面板显示
            Button16.Enabled = False            '检查版本控制Windows 10 任务栏透明度设置教程显示
        End If
        If CurrentBuild >= 22621 Then              '检查版本控制旧版任务栏图标选项显示(由于win11 21h2 支持所以不屏蔽win11 21h2)
            'Button33.Enabled = False          '暂时不屏蔽
        End If
        '分界线
        If CurrentBuild < 10240 Then              '检查版本控制Windows 10 桌面上下文菜单显示(小于win10部分)
            GroupBox7.Enabled = False
        ElseIf CurrentBuild >= "18362" Then              '检查版本控制Windows 10 桌面上下文菜单显示(大于win10 1903部分)
            GroupBox7.Enabled = False
        End If
        If CurrentBuild < 22000 Then
            Button25.Enabled = False              '检查版本控制Windows 11 explorer xaml菜单显示
            Button15.Enabled = False              '检查版本控制Windows 11 explorer win32菜单显示
        End If
    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        CreateObject("shell.application").shellexecute("reg.exe", "add ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\PasswordLess\Device"" /v DevicePasswordLessBuildVersion /T REG_DWORD /d 2 /f", "", "runas", 0)
        CreateObject("shell.application").shellexecute("reg.exe", "add ""HKEY_LOCAL_MACHINE\SOFTWARE\wow6432node\Microsoft\Windows NT\CurrentVersion\PasswordLess\Device"" /v DevicePasswordLessBuildVersion /T REG_DWORD /d 2 /f", "", "runas", 0)
    End Sub
End Class