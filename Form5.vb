Public Class Form5
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click '记事本
        Shell("cmd.exe /c start notepad.exe", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click '画图
        Shell("cmd.exe /c start mspaint.exe", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click '计算器
        Shell("calc.exe", AppWinStyle.NormalFocus, False, -1)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click '造字
        Shell("cmd.exe /c start eudcedit.exe", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click '电话
        Shell("C:\WINDOWS\System32\dialer.exe", AppWinStyle.NormalFocus, False, -1)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click '写字板
        Shell("cmd.exe /c start write.exe", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click 'wmpl
        Shell("cmd.exe /c start wmplayer.exe", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click '截图工具
        Shell("cmd.exe /c start snippingtool.exe", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click '音量合成器
        Shell("cmd.exe /c start sndvol.exe", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click '远程桌面
        Shell("cmd.exe /c start mstsc.exe", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click '字符映射表
        Shell("cmd.exe /c start charmap.exe", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Shell("cmd.exe /c start OptionalFeatures.exe", AppWinStyle.Hide, True, -1) 'windows功能
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click '更多辅助功能
        Shell("cmd.exe /c start explorer.exe %userprofile%\appdata\roaming\Microsoft\Windows\Start Menu\Programs\Accessibility", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click 'conhost
        Shell("cmd.exe /c start conhost.exe", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click '移动中心
        Shell("cmd.exe /c start mblctr.exe", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click '扫描传真
        Shell("cmd.exe /c start WFS.exe", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click '屏幕键盘
        Shell("cmd.exe /c start osk.exe", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click '放大镜
        Shell("cmd.exe /c start magnify.exe", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub 返回主界面_LinkClicked(sender As Object, e As EventArgs) Handles 返回主界面.LinkClicked
        Form1.Show()
        Close()
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '读取设置
        Dim LegacyMoreUI As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WFL Tool", True).GetValue("LegacyMoreUI", "无")
        If LegacyMoreUI = "True" Then
            Me.ContextMenuStrip = ContextMenuStrip2
            返回主界面.Visible = False
            返回没有关闭窗口就行.Visible = True
        End If
        Dim CurrentBuild As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild", Nothing)
        If CurrentBuild < "22621" Then              '检查版本控制WIN11conhost显示
            Button12.Enabled = False
        ElseIf CurrentBuild > "26020" Then
            Button6.Enabled = False              '检查版本控制写字板显示
        End If
    End Sub

    Private Sub 打开主页ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开主页ToolStripMenuItem.Click
        Form1.Show()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Shell("cmd.exe /c start ms-settings:optionalfeatures", AppWinStyle.Hide, True, -1)
    End Sub
    Private Sub 快捷键返回BToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 快捷键返回BToolStripMenuItem.Click
        Form1.Show()
        Close()
    End Sub
End Class