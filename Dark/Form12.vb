Imports System.Reflection.Emit

Public Class Form12
    Private Sub Form12_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim OldLicense As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\DBT\WFL Tool", True).GetValue("License", "无")
        If OldLicense = "5" Or OldLicense = "SetupUser" Then
            Me.Text = "软件许可协议  -  请注意！协议已更新  -  WFL Tool"
        End If
        '低分辨率设备兼容代码
        Dim ScreenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        If ScreenHeight < 1080 Then
            If Me.Height < 493 Then
                Me.Height = 493
            ElseIf Me.Height < 630 And Me.Height > 540 Then
                Me.Height = 614
            End If
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