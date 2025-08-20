Public Class Form9


    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        'MsgBox("测试版不提供更新日志", 0, "WFL Tool")
        MsgBox("RTM 版本(8320.1):" & vbCrLf & "新功能：" & vbCrLf & "1.启动注册表编辑器时默认多开并增加右键菜单" & vbCrLf & "2.""下载 Windows""增加 UUP" & vbCrLf & "3.主界面右上角相关字样可以单击切换样式" & vbCrLf & "4.安装了 Edge Webview 2 的设备上在线内容会用其渲染" & vbCrLf & "5.安装界面换新，欢迎体验" & vbCrLf & "修复：" & vbCrLf & "1.修复关闭 UAC 功能的一些问题" & vbCrLf & "2.修复开启 UAC 时打开注册表编辑器 UAC 默认最小化问题" & vbCrLf & "" & vbCrLf & "修补版本(8320.5):" & vbCrLf & "新功能：" & vbCrLf & "对于不支持一些功能的系统那些功能将屏蔽 (Windows build 22621 和 22000 为支持本软件所有功能的版本)" & vbCrLf & "修复：" & vbCrLf & "修复没有安装 Edge Webview2 仍然会尝试用其渲染问题", 0, "当前版本更新日志")
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        MsgBox("本应用提供 x64 版本。x64 版本对最近两年内发布的两个较新大版本(比如版本 8.17)提供支持(最新的大版本提供含修补和其他更新在内的全部支持，低一级的大版本仅提供除更新之外的其他支持)，若两年内没有发布或只发布了一个新版本，则只对最新版本提供支持，和两年内的最新大版本支持策略一样。我们提供 x86 版本。注意：从 Windows 11 开始，Microsoft 不再提供 x86 版本的 Windows。", MsgBoxStyle.OkOnly, "版本声明")
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        MsgBox("x64 版本：最低支持 Windows Vista SP2，并且安装了相关运行库 (Windows 8 及以上系统自带运行库)，系统架构必须为 x64，Vista 系统存在部分功能无法使用情况" & vbCrLf & "注：只有 Windows NT 10.0 ( Win 10 和 Win 11 ) 才可以使用进入 WinRE 和 UWP 应用功能。", MsgBoxStyle.OkOnly, "系统要求")
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        MsgBox("邮箱: z181k@139.com" & vbCrLf & "" & vbCrLf & "注：原来的 18734477184@139.com 现在只外发邮件，不接收邮件" & vbCrLf & "可以使用发送反馈按钮直接跳转到邮箱" & vbCrLf & "注意删除发送反馈的主题", MsgBoxStyle.OkOnly, "联系我们")
    End Sub

    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked '检查更新
        On Error GoTo legacy
        Dim EDGEWV2 As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Microsoft EdgeWebView", "Version", Nothing)
        If EDGEWV2 = "" Then               '判断EDGE WEBVIEW2是否存在
            GoTo legacy
        End If
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v EWV2webpageShow /T REG_SZ /d True /f", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v EWV2webpageTitle /T REG_SZ /d ""更新本程序 - 下载密码: down - WFL Tool"" /f", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v EWV2webpageURL /T REG_SZ /d https://dbtpan.lanzouo.com/b0205vf6f /f", AppWinStyle.Hide, True, -1)
        Shell("EWV2viewer\EWV2Viewer.exe", AppWinStyle.NormalFocus, False, -1)   '写入启动参数注册表并且启动ewv2
        Exit Sub
legacy:
        Dim NF4 As New Form4()
        NF4.Show()
        NF4.Text = "检查更新 - 下载密码: down - WFL Tool"                 'EDGE WEBVIEW2不存在或者无法启动ewv2的旧版方案
        NF4.MaximizeBox = True
        NF4.WebBrowser1.Url = New Uri("https://dbtpan.lanzoui.com/b0205vf6f")
        NF4.MaximumSize = New Size(0, 0)
        NF4.MinimumSize = New Size(0, 0)
        NF4.WebBrowser1.ScriptErrorsSuppressed = True
    End Sub

    Private Sub LinkLabel7_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked
        MsgBox("全名: WFL Tool (x64)         版本类别: 安装版" & vbCrLf & "分支: RTM64.Tree2-Main3.Milestone2" & vbCrLf & "编译日期：2025/8/20", MsgBoxStyle.OkOnly, "更多信息")
    End Sub

    Private Sub LinkLabel8_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel8.LinkClicked
        Label5.Text = "本软件大事记：" & vbCrLf & "2021/5/9 发布第一个版本(V2.0.0)" & vbCrLf & "2022/7/7 发布第一个64位版本(V7.0.0.0)" & vbCrLf & "2023/1/10 (更新日期) 基于.NET Framework 4.5.2" & vbCrLf & "重构 x64 版本" & vbCrLf & "2022/12/6 (更新日期:2023/01/22) x64 版本源码丢" & vbCrLf & "失，应用重写" & vbCrLf & "2023/05/25 编译 主要名字更名英文 WFL Tool" & vbCrLf & "2024/01/01 编译 应用界面翻新工作基本完成" & vbCrLf & "2025/08/06 编译 更换新图标"
        LinkLabel9.Visible = True               '上一页
        LinkLabel8.Visible = False
    End Sub

    Private Sub LinkLabel9_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel9.LinkClicked
        Label5.Text = "WFL Tool 让修改系统变得更加容易，让系统附件更加” & vbCrLf & “易于寻找” & vbCrLf & ““ & vbCrLf & “版权所有 © 2021-2025 董博涛. 保留所有权利.” & vbCrLf & ““ & vbCrLf & “电脑功能启动器为 WFL Tool 的中文名” & vbCrLf & ““ & vbCrLf & “本应用中所有链接均为非本团队运营（包括更新本程” & vbCrLf & “序的链接），其中大部分为我们注册了相关平台账户” & vbCrLf & “上传的信息，我们对这些内容提供有限的支持。"
        LinkLabel8.Visible = True               '下一页
        LinkLabel9.Visible = False
    End Sub

    Private Sub Label4_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Label4.MouseDoubleClick
        Label6.Visible = True      '彩蛋-版本
    End Sub

    Private Sub 打开主界面ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开主界面ToolStripMenuItem.Click
        Form1.Show()
    End Sub

    Private Sub 退出程序ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 退出程序ToolStripMenuItem.Click
        End
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Dim NF12 As New Form12()
        NF12.Show()
        NF12.Button3.Visible = True
        NF12.Button1.Visible = False         '协议及调整协议界面
        NF12.Button2.Visible = False
    End Sub

    Private Sub LinkLabel10_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) 
        Dim NF11 As New Form11()
        NF11.Show()
    End Sub

    Private Sub Label6_DoubleClick(sender As Object, e As EventArgs) Handles Label6.DoubleClick
        Form4.Show()
        Label6.Visible = False        '彩蛋-介绍
    End Sub

End Class