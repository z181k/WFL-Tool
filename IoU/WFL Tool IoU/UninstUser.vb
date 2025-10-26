Imports System.ComponentModel

Public Class UninstUser
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SetupUserInstall.Show()
        Me.Hide()
        SetupUserInstall.Text = "WFL Tool (x64) 卸载程序"
        SetupUserInstall.Label4.Text = "卸载程序"
        SetupUserInstall.Label1.Text = "正在卸载"
        Shell("reg.exe delete ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /f", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v Uninst /T REG_SZ /d True /f", AppWinStyle.Hide, True, -1)
        Timer1.Start()
        SetupUserInstall.PB1.Value = 0
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Button1.Visible = True
            Button2.Visible = False
        Else
            Button2.Visible = True
            Button1.Visible = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SetupUserInstall.Show()
        Me.Hide()
        SetupUserInstall.Text = "WFL Tool (x64) 卸载程序"
        SetupUserInstall.Label4.Text = "卸载程序"
        SetupUserInstall.Label1.Text = "正在卸载"
        Timer1.Start()
        SetupUserInstall.PB1.Value = 0
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        '下面是终止正在运行的wfltool相关代码
        Dim TargetName As String = "WFL Tool" '存储进程名为文本型，注：进程名不加扩展名
        Dim TargetKill() As Process = Process.GetProcessesByName(TargetName) '从进程名获取进程
        Dim TargetPath As String '存储进程路径为文本型
        If TargetKill.Length > 1 Then '判断进程名的数量，如果同名进程数量在2个以上，用For循环关闭进程。
            For i = 0 To TargetKill.Length - 1
                TargetPath = TargetKill(i).MainModule.FileName
                TargetKill(i).Kill()
            Next
        ElseIf TargetKill.Length = 1 Then '判断进程名的数量，如果只有一个，就不用For循环
            TargetKill(0).Kill()
        End If
        '-------------分割线--------------
        Shell("cmd.EXE /c del ""%localappdata%\WFL Tool\WFL Tool.exe""", AppWinStyle.Hide, True, -1)
        Shell("cmd.EXE /c del ""%localappdata%\WFL Tool\EWV2viewer\*.*"" /s /q", AppWinStyle.Hide, False, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v WinAppSdkUi /T REG_SZ /d 0 /f", AppWinStyle.Hide, True, -1)
        SetupUserInstall.PB1.Value = 25
        Shell("cmd.EXE /c del ""%localappdata%\WFL Tool\MessageBox.exe""", AppWinStyle.Hide, True, -1)
        Shell("cmd.EXE /c del ""%localappdata%\WFL Tool\Microsoft.Windows.ApplicationModel.Background.UniversalBGTask.dll""", AppWinStyle.Hide, True, -1)
        Shell("cmd.EXE /c del ""%localappdata%\WFL Tool\Microsoft.WindowsAppRuntime.Bootstrap.dll""", AppWinStyle.Hide, True, -1)
        Shell("cmd.EXE /c del ""%localappdata%\WFL Tool\resources.pri""", AppWinStyle.Hide, True, -1)
        SetupUserInstall.PB1.Value = 50
        Shell("cmd.EXE /c del ""%userprofile%\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\WFL Tool.lnk""", AppWinStyle.Hide, True, -1)
        Dim dpfu As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", True).GetValue("Desktop", "%homedrive%%homepath%\desktop")
        Shell("cmd.EXE /c del """ + dpfu + "\WFL Tool.lnk""", AppWinStyle.Hide, True, -1)
        SetupUserInstall.PB1.Value = 75
        Shell("cmd.EXE /c timeout.exe /t 2 &rd ""%localappdata%\WFL Tool\EWV2viewer\runtimes"" /s /q", AppWinStyle.Hide, False, -1)
        Shell("cmd.exe /c reg.exe delete ""HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool"" /f", AppWinStyle.Hide, True, -1)
        SetupUserInstall.PB1.Value = 100
        NewUninstUserFinish.Show()
        SetupUserInstall.Label1.Text = "卸载完成"
        SetupUserInstall.Button1.Text = "关闭"
        SetupUserInstall.Button1.Enabled = True
        SetupUserInstall.ControlBox = True
        SetupUserInstall.Text = "WFL Tool (x64) 卸载程序"
    End Sub

    Private Sub UninstUser_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub
End Class