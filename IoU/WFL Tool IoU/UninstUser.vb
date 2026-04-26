Imports System.ComponentModel
Imports System.Reflection.Emit
Imports System.Threading.Tasks

Public Class UninstUser

    Private Async Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim setupUserI As New SetupUserInstall
        Dim StartPoint As New System.Drawing.Point
        StartPoint.X = Me.Location.X
        StartPoint.Y = Me.Location.Y
        setupUserI.Location = StartPoint
        setupUserI.Show()
        Me.Hide()
        setupUserI.Text = "WFL Tool (x64) 卸载程序"
        setupUserI.Label4.Text = "卸载程序"
        setupUserI.Label1.Text = "正在卸载"
        setupUserI.PB1.Value = 0
        Await Task.Run(Sub()
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
                           '下面是终止正在运行的wfltooldark相关代码
                           Dim TargetName2 As String = "WFLToolDark" '存储进程名为文本型，注：进程名不加扩展名
                           Dim TargetKill2() As Process = Process.GetProcessesByName(TargetName2) '从进程名获取进程
                           Dim TargetPath2 As String '存储进程路径为文本型
                           If TargetKill2.Length > 1 Then '判断进程名的数量，如果同名进程数量在2个以上，用For循环关闭进程。
                               For i = 0 To TargetKill2.Length - 1
                                   TargetPath2 = TargetKill2(i).MainModule.FileName
                                   TargetKill2(i).Kill()
                               Next
                           ElseIf TargetKill2.Length = 1 Then '判断进程名的数量，如果只有一个，就不用For循环
                               TargetKill2(0).Kill()
                           End If
                       End Sub)
        setupUserI.PB1.Value = 20
        '-------------分割线--------------
        Await Task.Run(Sub()
                           Shell("cmd.EXE /c del ""%localappdata%\WFL Tool\WFL Tool.exe""", AppWinStyle.Hide, True, -1)
                           Shell("cmd.EXE /c del ""%localappdata%\WFL Tool\EWV2viewer\*.*"" /q", AppWinStyle.Hide, False, -1)
                           Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v WinAppSdkUi /T REG_SZ /d 0 /f", AppWinStyle.Hide, True, -1)
                           Shell("cmd.EXE /c del ""%localappdata%\WFL Tool\MessageBox.exe""", AppWinStyle.Hide, True, -1)
                       End Sub)
        setupUserI.PB1.Value = 40
        Await Task.Run(Sub()
                           Shell("cmd.EXE /c rd ""%localappdata%\WFL Tool\EWV2viewer\deverrcodehlp_files"" /s /q", AppWinStyle.Hide, False, -1)
                           Shell("cmd.EXE /c rd ""%localappdata%\WFL Tool\EWV2viewer\5THcelebrate_files"" /s /q", AppWinStyle.Hide, False, -1)
                           Shell("cmd.EXE /c del ""%localappdata%\WFL Tool\Microsoft.Windows.ApplicationModel.Background.UniversalBGTask.dll""", AppWinStyle.Hide, True, -1)
                           Shell("cmd.EXE /c del ""%localappdata%\WFL Tool\Microsoft.WindowsAppRuntime.Bootstrap.dll""", AppWinStyle.Hide, True, -1)
                           Shell("cmd.EXE /c del ""%localappdata%\WFL Tool\resources.pri""", AppWinStyle.Hide, True, -1)
                       End Sub)
        setupUserI.PB1.Value = 60
        Await Task.Run(Sub()
                           Shell("cmd.EXE /c del ""%userprofile%\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\WFL Tool.lnk""", AppWinStyle.Hide, True, -1)
                           Dim dpfu As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", True).GetValue("Desktop", "%homedrive%%homepath%\desktop")
                           Shell("cmd.EXE /c del """ + dpfu + "\WFL Tool.lnk""", AppWinStyle.Hide, True, -1)
                           Shell("cmd.EXE /c rd ""%localappdata%\WFL Tool\EWV2viewer\runtimes"" /s /q", AppWinStyle.Hide, False, -1)
                           Shell("cmd.EXE /c del ""%localappdata%\WFL Tool\DBTModernSetupUI-Modify.exe""", AppWinStyle.Hide, True, -1)
                           Shell("cmd.EXE /c del ""%localappdata%\WFL Tool\WFLToolDark.exe""", AppWinStyle.Hide, True, -1)
                       End Sub)
        setupUserI.PB1.Value = 80
        Await Task.Run(Sub()
                           Shell("cmd.exe /c reg.exe delete ""HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool"" /f", AppWinStyle.Hide, True, -1)
                           If CheckBox1.Checked = True Then
                               Shell("reg.exe delete ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /f", AppWinStyle.Hide, True, -1)
                               Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v Uninst /T REG_SZ /d True /f", AppWinStyle.Hide, True, -1)
                           End If
                       End Sub)
        setupUserI.PB1.Value = 100
        NewUninstUserFinish.Show()
        setupUserI.Label1.Text = "卸载完成"
        setupUserI.Button1.Text = "关闭"
        setupUserI.Button1.Enabled = True
        setupUserI.ControlBox = True
    End Sub

    Private Sub UninstUser_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub

    Private Sub UninstUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '低分辨率设备兼容代码
        PictureBox2.Height = PictureBox2.Width
        Dim ScreenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        If ScreenHeight < 1080 Then
            Label7.Location = Label7.Location - New Size(3, 0)
        End If
    End Sub
End Class