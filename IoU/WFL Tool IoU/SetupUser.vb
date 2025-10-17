Public Class SetupUser
    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Shell("cmd.EXE /c copy pga.bin ""%homedrive%%homepath%\WFL Tool.exe"" /y", AppWinStyle.Hide, True, -1)
        Shell("cmd.EXE /c start explorer.exe /select,""%homedrive%%homepath%\WFL Tool.exe""", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub 为当前用户安装_Click(sender As Object, e As EventArgs) Handles 为当前用户安装.Click
        SetupUserBackground.Show()
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v InstallAdmin /T REG_SZ /d 1 /f", AppWinStyle.Hide, True, -1)
        CreateObject("shell.application").shellexecute("InAdmin.exe", "", "", "runas", 1)        '所有用户
        End
    End Sub

    Private Sub SetupUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error GoTo 1
        Dim CurrentBuild As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild", Nothing)
        If CurrentBuild < 5033 Then
            为当前用户安装.Enabled = False
            Button1.Enabled = False
        End If
        Exit Sub


1:
        为当前用户安装.Enabled = False
        Button1.Enabled = False
        Label2.Text = "Windows XP 请使用将主程序放到用户文件夹"
    End Sub
End Class
