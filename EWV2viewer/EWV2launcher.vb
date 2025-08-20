Public Class EWV2launcher
    Private Sub EWV2launcher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '下方代码为根据注册表信息调整网页界面内容代码
        On Error GoTo errmsg
        Dim license As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WFL Tool", True).GetValue("license", "无")
        If license = "无" Then
            On Error GoTo no3info1
            Shell("EWV2info", AppWinStyle.Hide, True, -1)
            End
no3info1:
            MsgBox("您未接受我们的软件许可协议，所以该功能暂不能使用，请谅解。", MsgBoxStyle.Exclamation, "WFL Tool")
            End
        End If
        Dim EWV2webpageShow As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WFL Tool", True).GetValue("EWV2webpageShow", "nothing")
        If EWV2webpageShow = "True" Then
            EWV2webpage.Show()
            Close()
            Exit Sub
        End If
errmsg:
        On Error GoTo no3info2
        Shell("EWV2info", AppWinStyle.Hide, True, -1)
        End
no3info2:
        MsgBox("非常抱歉，出了一点小问题，请重试。", MsgBoxStyle.Critical, "WFL Tool WebPageView")
        Close()
    End Sub

    Private Sub EWV2launcher_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Me.Visible = False
    End Sub
End Class