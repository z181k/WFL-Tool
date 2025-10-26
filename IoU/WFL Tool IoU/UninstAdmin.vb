Public Class UninstAdmin
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Button1.Visible = True
            Button2.Visible = False
            MsgBox("注意：如果有多个用户，仅能删除当前用户的数据。", MsgBoxStyle.Exclamation, "WFL Tool 卸载程序")
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
        Shell("cmd.exe /c reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v UninstA /T REG_SZ /d 0 /f", AppWinStyle.Hide, True, -1)
        Timer1.Start()
        SetupUserInstall.PB1.Value = 25
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SetupUserInstall.Show()
        Me.Hide()
        SetupUserInstall.Text = "WFL Tool (x64) 卸载程序"
        SetupUserInstall.Label4.Text = "卸载程序"
        SetupUserInstall.Label1.Text = "正在卸载"
        Shell("reg.exe delete ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /f", AppWinStyle.Hide, True, -1)
        Shell("cmd.exe /c reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v UninstA /T REG_SZ /d 1 /f", AppWinStyle.Hide, True, -1)
        Timer1.Start()
        SetupUserInstall.PB1.Value = 25
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
        Shell("cmd.EXE /c del ""%programfiles%\WFL Tool\WFL Tool.exe""", AppWinStyle.Hide, True, -1)
        SetupUserInstall.PB1.Value = 50
        Shell("cmd.EXE /c del ""%programdata%\Microsoft\Windows\Start Menu\Programs\WFL Tool.lnk""", AppWinStyle.Hide, True, -1)
        Dim dpfu As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", True).GetValue("Desktop", "%homedrive%%homepath%\desktop")
        Shell("cmd.EXE /c del ""%homedrive%\users\public\desktop\WFL Tool.lnk""", AppWinStyle.Hide, True, -1)
        SetupUserInstall.PB1.Value = 75
        Shell("cmd.exe /c reg.exe delete ""HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtoolA"" /f", AppWinStyle.Hide, True, -1)
        SetupUserInstall.PB1.Value = 100
        NewUninstUserFinish.Show()
        SetupUserInstall.Label1.Text = "卸载完成"
        SetupUserInstall.Button1.Text = "关闭"
        SetupUserInstall.Button1.Enabled = True
        SetupUserInstall.ControlBox = True
        SetupUserInstall.Text = "WFL Tool (x64) 卸载程序"
    End Sub
End Class