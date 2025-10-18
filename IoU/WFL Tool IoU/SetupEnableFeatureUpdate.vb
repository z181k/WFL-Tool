Public Class SetupEnableFeatureUpdate
    Private Sub SetupEnableFeatureUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error GoTo v121a
        Dim v121 As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool", True).GetValue("DisplayVersion", "无")
        If v121 = "12.1.9024.3" Then
            Button1.Enabled = True
        End If
v121a:
        On Error GoTo end1
        Dim v121a As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\WFLtoolA", "DisplayVersion", Nothing)
        If v121a = "12.1.9024.3" Then
            Button2.Enabled = True
        End If
end1:
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CreateObject("shell.application").shellexecute("reg.exe", "add ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\WFLtoolA"" /v DisplayVersion /T REG_SZ /d 12.2.9024.3 /f", "", "runas", 0)
        CreateObject("shell.application").shellexecute("reg.exe", "add ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\WFLtoolA"" /v v122a /T REG_SZ /d True /f", "", "runas", 0)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool"" /v DisplayVersion /T REG_SZ /d 12.2.9024.3 /f", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool"" /v v122 /T REG_SZ /d ture /f", AppWinStyle.Hide, True, -1)     'true拼写错误，为兼容保留
    End Sub
End Class