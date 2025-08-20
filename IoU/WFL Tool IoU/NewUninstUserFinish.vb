Public Class NewUninstUserFinish


    Private Sub NewUninstUserFinish_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        On Error GoTo exit1
        '用户模式卸载清除数据
        Dim Uninst As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\DBT\WFL Tool", True).GetValue("Uninst", "false")
        If Uninst = "True" Then
            Shell("reg.exe delete ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /f", AppWinStyle.Hide, True, -1)
            Shell("cmd.EXE /c rd ""%localappdata%\WFL Tool\EWV2viewer"" /s /q", AppWinStyle.Hide, False, -1)
            Shell("cmd.EXE /c timeout.exe /t 2 &rd ""%localappdata%\WFL Tool"" /s /q", AppWinStyle.Hide, False, -1)
            Exit Sub
        End If
        '管理员模式卸载清除数据
        Dim UninstA As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\DBT\WFL Tool", True).GetValue("UninstA", "false")
        If UninstA = "1" Then
            Shell("reg.exe delete ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /f", AppWinStyle.Hide, True, -1)
            Shell("cmd.EXE /c timeout.exe /t 2 &rd ""%programfiles%\WFL Tool"" /s /q", AppWinStyle.Hide, False, -1)
            Exit Sub
        End If
        '管理员模式卸载不清除数据
        If UninstA = "0" Then
            Shell("cmd.exe /c reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v UninstA /T REG_SZ /d 2 /f", AppWinStyle.Hide, True, -1)
            Shell("cmd.EXE /c timeout.exe /t 2 &rd ""%programfiles%\WFL Tool"" /s /q", AppWinStyle.Hide, False, -1)
            Exit Sub
        End If
        '用户模式卸载不清除数据
        Shell("cmd.EXE /c timeout.exe /t 2 &DEL ""%localappdata%\WFL Tool\uninstall.exe""", AppWinStyle.Hide, False, -1)
exit1:
        Shell("cmd.EXE /c timeout.exe /t 2 &DEL ""%localappdata%\WFL Tool\uninstall.exe""", AppWinStyle.Hide, False, -1)
    End Sub

    Private Sub NewUninstUserFinish_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Me.Visible = False
    End Sub
End Class