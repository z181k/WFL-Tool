Public Class SetupUserModify
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Visible = False
        If CheckBox1.Checked = True And CheckBox1.Enabled = True Then
            SetupUserInstall.Show()
            SetupUserInstall.Text = "更改 WFL Tool (x64) 的安装"
            SetupUserInstall.Label4.Text = "更改安装"
            SetupUserInstall.Label1.Text = "正在更改"
            SetupUserInstall.PB1.Value = 95
            MsgBox("卸载 Edge WebView2 渲染支持组件仅对当前安装的当前版本有效，不会清除该组件的数据，更新或重新安装应用时会自动重新安装该组件。"， vbInformation, "更改 WFL Tool (x64) 的安装")
            Shell("cmd.EXE /c del ""%localappdata%\WFL Tool\EWV2viewer\*.*"" /q", AppWinStyle.Hide, False, -1)
            Shell("cmd.EXE /c rd ""%localappdata%\WFL Tool\EWV2viewer\deverrcodehlp_files"" /s /q", AppWinStyle.Hide, False, -1)
            Shell("cmd.EXE /c rd ""%localappdata%\WFL Tool\EWV2viewer\iwpt_files"" /s /q", AppWinStyle.Hide, False, -1)
            Shell("cmd.EXE /c rd ""%localappdata%\WFL Tool\EWV2viewer\5THcelebrate_files"" /s /q", AppWinStyle.Hide, False, -1)
            Shell("cmd.EXE /c rd ""%localappdata%\WFL Tool\EWV2viewer\runtimes"" /s /q", AppWinStyle.Hide, False, -1)
            Shell("cmd.exe /c reg.exe add ""HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool"" /v EWV2viewerInsatll /T REG_SZ /d False /f", AppWinStyle.Hide, True, -1)
            Shell("cmd.exe /c reg.exe add ""HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool"" /v EstimatedSize /T REG_DWORD /d 123456 /f", AppWinStyle.Hide, True, -1)
        End If
        If CheckBox2.Enabled = True Then
            If CheckBox2.Checked = True Then
                Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v WinAppSdkUi /T REG_SZ /d 0 /f", AppWinStyle.Hide, True, -1)
            Else
                Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v WinAppSdkUi /T REG_SZ /d 1 /f", AppWinStyle.Hide, True, -1)
            End If
        End If
        Application.Exit()
    End Sub

    Private Sub SetupUserModify_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim WinAppSdkUi As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\DBT\WFL Tool", "WinAppSdkUi", Nothing)
        If WinAppSdkUi = "1" Then
            CheckBox2.Enabled = True
        ElseIf WinAppSdkUi = "0" Then
            CheckBox2.Enabled = True
            CheckBox2.Checked = True
        End If
        '
        Dim EWV2viewerInsatll As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool", "EWV2viewerInsatll", Nothing)
        If EWV2viewerInsatll = "True" Then
            CheckBox1.Enabled = True
        ElseIf EWV2viewerInsatll = "False" Then
            CheckBox1.Checked = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub
End Class