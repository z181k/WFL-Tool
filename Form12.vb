Public Class Form12
    Private Sub Form12_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim OldLicense As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\DBT\WFL Tool", True).GetValue("License", "无")
        If OldLicense = "5" Then
            Me.Text = "软件许可协议  -  请注意！协议已更新  -  WFL Tool"
        ElseIf OldLicense = "SetupUser" Then
            Me.Text = "软件许可协议  -  请注意！协议已更新  -  WFL Tool"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v EULA /T REG_SZ /d 5 /f", AppWinStyle.Hide, True, -1)
        Dim OldLicense As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\DBT\WFL Tool", True).GetValue("License", "无")
        If OldLicense = "5" Then
            Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v License /T REG_SZ /d newEULA /f", AppWinStyle.Hide, True, -1)
        ElseIf OldLicense = "SetupUser" Then
            Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v License /T REG_SZ /d newEULA /f", AppWinStyle.Hide, True, -1)
        End If
        Form1.Show()
        Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form11.Show()
    End Sub
End Class