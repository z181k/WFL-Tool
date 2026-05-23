Imports System.Threading.Tasks

Public Class SetupAdmin
    Private Async Sub SetupAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim InstallAdmin As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\DBT\WFL Tool", True).GetValue("InstallAdmin", "无")
            Dim args As String() = Environment.GetCommandLineArgs()
            Dim conline1 As String = If(args.Length >= 2, args(1), "")
            Dim conline2 As String = If(args.Length >= 3, args(2), "")
            Dim NLX As Double = conline1
            Dim NLY As Double = conline2
            If Not String.IsNullOrEmpty(conline1) Then
                If conline1 <> "" And conline1 <> "" Then
                    Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v InstallAdmin /T REG_SZ /d 0 /f", AppWinStyle.Hide, True, -1)
                    Dim setupUserI As New SetupUserInstall
                    Dim StartPoint As New System.Drawing.Point
                    StartPoint.X = NLX
                    StartPoint.Y = NLY
                    setupUserI.Location = StartPoint
                    setupUserI.Show()
                    setupUserI.Text = "WFL Tool (x64) 安装程序"
                    setupUserI.Label4.Text = "安装程序"
                    setupUserI.Label1.Text = "正在安装"
                    setupUserI.PB1.Value = 0
                    Await Task.Run(Sub()
                                       Shell("cmd.EXE /c md ""%programfiles%\WFL Tool""", AppWinStyle.Hide, True, -1)
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
                                   End Sub)
                    '-------------分割线--------------
                    setupUserI.PB1.Value = 20
                    Await Task.Run(Sub()
                                       Shell("cmd.EXE /c copy DotNet10Pga\npga.bin ""%programfiles%\WFL Tool\WFL Tool.exe"" /y", AppWinStyle.Hide, True, -1)
                                       Shell("cmd.EXE /c copy aiu.bin ""%programfiles%\WFL Tool\uninstall.exe"" /y", AppWinStyle.Hide, True, -1)
                                       Shell("cmd.exe /c reg.exe delete ""HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool"" /f", AppWinStyle.Hide, True, -1)
                                       '上面那条是删除build8320的安装信息
                                       Shell("cmd.EXE /c copy adl.bin ""%programdata%\Microsoft\Windows\Start Menu\Programs\WFL Tool.lnk"" /y", AppWinStyle.Hide, True, -1)
                                   End Sub)
                    setupUserI.PB1.Value = 40
                    Await Task.Run(Sub()
                                       Shell("cmd.exe /c reg.exe add ""HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtoolA"" /v PaintDesktopVersion /T REG_DWORD /d 1 /f", AppWinStyle.Hide, True, -1)
                                       Shell("cmd.exe /c reg.exe add ""HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtoolA"" /v DisplayIcon /T REG_SZ /d ""%programfiles%\WFL Tool\WFL Tool.exe"" /f", AppWinStyle.Hide, True, -1)
                                       Shell("cmd.exe /c reg.exe add ""HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtoolA"" /v DisplayName /T REG_SZ /d ""WFL Tool (x64) Admin"" /f", AppWinStyle.Hide, True, -1)
                                       Shell("cmd.exe /c reg.exe add ""HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtoolA"" /v DisplayVersion /T REG_SZ /d 17.1.9632.07 /f", AppWinStyle.Hide, True, -1)
                                   End Sub)
                    setupUserI.PB1.Value = 60
                    Await Task.Run(Sub()
                                       Shell("cmd.exe /c reg.exe add ""HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtoolA"" /v HelpLink /T REG_SZ /d ""https://kdocs.cn/l/sqxx3d4vumUT"" /f", AppWinStyle.Hide, True, -1)
                                       Shell("cmd.exe /c reg.exe add ""HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtoolA"" /v UninstallString /T REG_SZ /d ""%programfiles%\WFL Tool\Uninstall.exe"" /f", AppWinStyle.Hide, True, -1)
                                       Shell("cmd.exe /c reg.exe add ""HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtoolA"" /v NoModify /T REG_DWORD /d 1 /f", AppWinStyle.Hide, True, -1)
                                       Shell("cmd.exe /c reg.exe add ""HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtoolA"" /v NoRepair /T REG_DWORD /d 1 /f", AppWinStyle.Hide, True, -1)
                                   End Sub)
                    setupUserI.PB1.Value = 80
                    Await Task.Run(Sub()
                                       Shell("cmd.exe /c reg.exe add ""HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtoolA"" /v EstimatedSize /T REG_DWORD /d 115066 /f", AppWinStyle.Hide, True, -1)
                                       Shell("cmd.exe /c reg.exe add ""HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtoolA"" /v Publisher /T REG_SZ /d ""(c) 2021-2026 董博涛"" /f", AppWinStyle.Hide, True, -1)
                                       Shell("cmd.exe /c reg.exe add ""HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtoolA"" /v InstallLocation /T REG_SZ /d ""%programfiles%\WFL Tool"" /f", AppWinStyle.Hide, True, -1)
                                       Shell("cmd.EXE /c copy adl.bin ""%homedrive%\users\public\desktop\WFL Tool.lnk"" /y", AppWinStyle.Hide, True, -1)
                                   End Sub)
                    setupUserI.PB1.Value = 100
                    Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v EWV2webpageShow /T REG_SZ /d 4 /f", AppWinStyle.Hide, True, -1)
                    setupUserI.Label1.Text = "安装完成"
                    setupUserI.ControlBox = True
                    setupUserI.Button1.Text = "关闭"
                    setupUserI.Button1.Enabled = True
                    Dim EAI As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\DBT\WFL Tool", "EnterpriseAutoInstall", Nothing)
                    If EAI = "1" Then
                        Application.Exit()       '检查企业自动化安装
                    End If
                    Shell("cmd.EXE /k del * /F /S /Q&exit", AppWinStyle.Hide, False, -1)
                    Exit Sub     '结束事件防止执行下面
                End If
            End If
        Catch ex As Exception
            MsgBox("请执行 Setup.exe 以进行安装。", MsgBoxStyle.Critical, "WFL Tool 安装程序")
        End Try
        End
    End Sub

    Private Sub SetupAdmin_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Me.Visible = False
    End Sub
End Class