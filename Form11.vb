Public Class Form11
    Private Sub 退出程序ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 退出程序ToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub 返回主页ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 返回主页ToolStripMenuItem.Click
        Form1.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("是否要清除数据？此操作会清除应用所有设置并关闭应用。", 308, "清除数据并关闭程序") = vbYes Then
            Shell("reg.exe delete ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /va /f", AppWinStyle.Hide, True, -1)
            Shell("cmd.exe /c rd ""%localappdata%\WFL Tool\EWV2viewer\EWV2viewer.exe.webview2"" /s /q", AppWinStyle.Hide, True, -1)
            End
        End If
    End Sub
End Class