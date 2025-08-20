Public Class Form8
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub



    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        CreateObject("shell.application").shellexecute("reg.exe", "add HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System /v EnableLUA /T REG_DWORD /d 0 /f", "", "runas", 0)
        'Shell("cmd.exe /c reg.exe add HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System /v EnableLUA /T REG_DWORD /d 0 /f", AppWinStyle.Hide, True, -1)
        Close()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Close()
    End Sub

    Private Sub 打开主界面ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开主界面ToolStripMenuItem.Click
        Form1.Show()
    End Sub
End Class