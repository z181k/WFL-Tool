Public Class Form11
    Private Sub 退出程序ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 退出程序ToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub 返回主页ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 返回主页ToolStripMenuItem.Click
        Form1.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        On Error GoTo nexttap
        If MsgBox("是否要清除数据？清除时会同时撤回协议同意。此操作会清除应用所有设置并关闭应用。", 308, "清除数据并关闭程序") = vbYes Then
            Dim CreateWinAppSdkUi As String = "False"
            Dim WinAppSdkUi As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\DBT\WFL Tool", "WinAppSdkUi", Nothing)
            If WinAppSdkUi = "1" Then
                CreateWinAppSdkUi = "True"
            End If
nexttap:
            Shell("reg.exe delete ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /va /f", AppWinStyle.Hide, True, -1)
            Shell("cmd.exe /c rd ""%localappdata%\WFL Tool\EWV2viewer\EWV2viewer.exe.webview2"" /s /q", AppWinStyle.Hide, True, -1)
            If CreateWinAppSdkUi = "True" Then
                Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v WinAppSdkUi /T REG_SZ /d 1 /f", AppWinStyle.Hide, True, -1)
            End If
            End
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v EULA /T REG_SZ /d 无 /f", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v License /T REG_SZ /d 无 /f", AppWinStyle.Hide, True, -1)
        Application.Exit()
    End Sub
End Class