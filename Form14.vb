Public Class Form14
    Private Sub 返回更多功能_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles 返回更多功能.LinkClicked
        Form2.Show()
        Close()
    End Sub

    Private Sub 快捷键返回BToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 快捷键返回BToolStripMenuItem.Click
        Form2.Show()
        Close()
    End Sub

    Private Sub Form14_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim EnterpriseNotShow As Integer = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\DBT\WFL Tool", "EnterpriseNotShow", Nothing)
        Dim LegacyMoreUI As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WFL Tool", True).GetValue("LegacyMoreUI", "无")
        If EnterpriseNotShow = 1 Then
            Exit Sub                        '企业自定义屏蔽
        ElseIf LegacyMoreUI = "True" Then
            返回更多功能.Visible = False
            快捷键返回BToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub MSDT弃用说明_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles MSDT弃用说明.LinkClicked
        On Error GoTo legacy
        Dim EDGEWV2 As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Microsoft EdgeWebView", "Version", Nothing)
        If EDGEWV2 = "" Then               '判断EDGE WEBVIEW2是否存在
            GoTo legacy
        End If
        If MsgBox("要在本应用窗口内打开 MSDT 弃用说明吗？这是一个来自 Microsoft 的网页内容", 308, "WFL Tool (x64)") = vbYes Then
            Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v EWV2webpageShow /T REG_SZ /d True /f", AppWinStyle.Hide, True, -1)
            Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v EWV2webpageTitle /T REG_SZ /d ""Microsoft 支持诊断工具 (MSDT) 弃用的说明 - Microsoft 支持"" /f", AppWinStyle.Hide, True, -1)
            Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v EWV2webpageShowIcon /T REG_SZ /d False /f", AppWinStyle.Hide, True, -1)
            Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v EWV2webpageURL /T REG_SZ /d ""https://aka.ms/msdtretire"" /f", AppWinStyle.Hide, True, -1)
            Shell("EWV2viewer\EWV2Viewer.exe", AppWinStyle.NormalFocus, False, -1)   '写入启动参数注册表并且启动ewv2
            Exit Sub
        End If
legacy:
        Shell("cmd.exe /c start https://aka.ms/msdtretire", AppWinStyle.Hide, True, -1)
    End Sub
End Class