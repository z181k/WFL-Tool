Public Class EWV2launcher
    Private Sub EWV2launcher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim PROCESSOR_ARCHITECTURE As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Environment", "PROCESSOR_ARCHITECTURE", Nothing)
        If PROCESSOR_ARCHITECTURE = "AMD64" Then
            GoTo defaultstart                   '判断兼容性
        End If
        MsgBox("此版本仅为 x64 架构处理器提供，我们没有提供 arm64 基于架构的版本，请关注我们的网站，我们可能会在将来提供基于 arm64 的 WFL Tool。", MsgBoxStyle.Critical, "WFL Tool")
        End
defaultstart:
        '下方代码为根据注册表信息调整网页界面内容代码
        On Error GoTo no3info2
        Dim license As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WFL Tool", True).GetValue("EULA", "无")
        If license = "无" Then
            MsgBox("您未接受我们的软件许可协议，所以该功能暂不能使用，请谅解。", MsgBoxStyle.Exclamation, "WFL Tool")
            Application.Exit()
        End If
        Dim EWV2webpageShow As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WFL Tool", True).GetValue("EWV2webpageShow", "nothing")
        If EWV2webpageShow = "True" Then
            EWV2webpage.Show()
            Close()
            Exit Sub
        End If
no3info2:
        MsgBox("非常抱歉，出了一点小问题，请重试。", MsgBoxStyle.Critical, "WFL Tool WebPageView")
        Close()
    End Sub

    Private Sub EWV2launcher_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Me.Visible = False
    End Sub
End Class