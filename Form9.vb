Public Class Form9


    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        'MsgBox("测试版不提供更新日志", 0, "WFL Tool")
        Dim upginfo As String = """RTM 版本(9024.1):" & vbCrLf & "新功能：" & vbCrLf & "1.关机选项更名为电源选项并且增加电池健康信息功能" & vbCrLf & "2.系统修改增加 win10/11 显示清楚的登录背景选项" & vbCrLf & "3.首页增加重启资源管理器按钮" & vbCrLf & "4.部分功能界面细节微调" & vbCrLf & "修复：" & vbCrLf & "1.解决更多功能中部分功能 UAC 弹出后自动最小化问题" & vbCrLf & "2.解决部分功能在系统盘不是 C 盘时无法打开问题" & vbCrLf & vbCrLf & "修补版本(9024.3):" & vbCrLf & "修复部分情况下主页右上角文字没有版本号问题"""
        On Error GoTo legacy
        Dim WinAppSdkUi As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\DBT\WFL Tool", "WinAppSdkUi", Nothing)
        If WinAppSdkUi = "1" Then              'WinAppSdk弹窗
            Dim InstallLocation As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool", "InstallLocation", Nothing)
            Shell(InstallLocation + "\MessageBox.exe " + upginfo + " ""当前版本更新日志"" 0 0 0", AppWinStyle.NormalFocus, False, -1)
        Else              '旧版弹窗
legacy:
            MsgBox(upginfo, 0, "当前版本更新日志")
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        On Error GoTo legacy
        Dim WinAppSdkUi As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\DBT\WFL Tool", "WinAppSdkUi", Nothing)
        If WinAppSdkUi = "1" Then              'WinAppSdk弹窗
            Dim InstallLocation As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool", "InstallLocation", Nothing)
            Shell(InstallLocation + "\MessageBox.exe ""本应用提供 x64 版本，对最新版本提供支持。由于从 Windows 11 开始，Microsoft 不再提供 x86 版本的 Windows，所以 x86 版本从 2025/10/17 起停止支持。不提供 arm 架构版本。"" ""版本声明"" 0 0 0", AppWinStyle.NormalFocus, False, -1)
        Else              '旧版弹窗
legacy:
            MsgBox("本应用只提供 x64 版本。对最新版本提供支持。由于从 Windows 11 开始，Microsoft 不再提供 x86 版本的 Windows，所以 x86 版本从 2025/10/17 起停止支持。不提供 arm 架构版本。", MsgBoxStyle.OkOnly, "版本声明")
        End If
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        On Error GoTo legacy
        Dim WinAppSdkUi As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\DBT\WFL Tool", "WinAppSdkUi", Nothing)
        If WinAppSdkUi = "1" Then              'WinAppSdk弹窗
            Dim InstallLocation As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool", "InstallLocation", Nothing)
            Shell(InstallLocation + "\MessageBox.exe ""最低支持 Windows Vista SP2，并且安装了相关运行库 (Windows 8 及以上系统自带运行库)，系统架构必须为 x64 或 x86，Vista 系统存在部分功能无法使用情况。注：只有 Windows NT 10.0 ( Win 10 和 Win 11 ) 才可以使用进入 WinRE 和 UWP 应用功能。"" ""系统要求"" 0 0 0", AppWinStyle.NormalFocus, False, -1)
        Else              '旧版弹窗
legacy:
            MsgBox("最低支持 Windows Vista SP2，并且安装了相关运行库 (Windows 8 及以上系统自带运行库)，系统架构必须为 x64 或 x86，Vista 系统存在部分功能无法使用情况" & vbCrLf & "注：只有 Windows NT 10.0 ( Win 10 和 Win 11 ) 才可以使用进入 WinRE 和 UWP 应用功能。", MsgBoxStyle.OkOnly, "系统要求")
        End If
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        On Error GoTo legacy
        Dim WinAppSdkUi As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\DBT\WFL Tool", "WinAppSdkUi", Nothing)
        If WinAppSdkUi = "1" Then              'WinAppSdk弹窗
            Dim InstallLocation As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool", "InstallLocation", Nothing)
            Shell(InstallLocation + "\MessageBox.exe ""邮箱: z181k@139.com 或 z181k@hotmail.com" & vbCrLf & "" & vbCrLf & "注：原来的 18734477184@139.com 现在只外发邮件，不接收邮件" & vbCrLf & "可以使用发送反馈按钮直接跳转到邮箱，注意删除发送反馈的主题"" ""联系我们"" 0 0 0", AppWinStyle.NormalFocus, False, -1)
        Else              '旧版弹窗
legacy:
            MsgBox("邮箱: z181k@139.com 或 z181k@hotmail.com" & vbCrLf & "" & vbCrLf & "注：原来的 18734477184@139.com 现在只外发邮件，不接收邮件" & vbCrLf & "可以使用发送反馈按钮直接跳转到邮箱，注意删除发送反馈的主题", MsgBoxStyle.OkOnly, "联系我们")
        End If
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
        Dim releasedate As String = "各个组件签名日期即该组件编译日期"
        On Error GoTo legacy
        Dim WinAppSdkUi As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\DBT\WFL Tool", "WinAppSdkUi", Nothing)
        If WinAppSdkUi = "1" Then              'WinAppSdk弹窗
            Dim InstallLocation As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool", "InstallLocation", Nothing)
            Shell(InstallLocation + "\MessageBox.exe ""全名: WFL Tool (x64)                                      版本类别: 安装版" & vbCrLf & "分支: RTM64.Tree3-Main.Release" & vbCrLf & "编译日期：" + releasedate + vbCrLf & "" & vbCrLf & "WinAppSdk 模块由 Bilibili@空糖_SuGar (UID:438929715) 提供支持" & vbCrLf & "" & vbCrLf & "电脑功能启动器是 WFL Tool 的中文名"" ""更多信息"" 0 0 0", AppWinStyle.NormalFocus, False, -1)
        Else              '旧版弹窗
legacy:
            MsgBox("全名: WFL Tool (x64)                                      版本类别: 安装版" & vbCrLf & "分支: RTM64.Tree3-Main.Release" & vbCrLf & "编译日期：" + releasedate + vbCrLf & "" & vbCrLf & "WinAppSdk 模块由 Bilibili@空糖_SuGar (UID:438929715) 提供支持" & vbCrLf & "" & vbCrLf & "电脑功能启动器是 WFL Tool 的中文名", MsgBoxStyle.OkOnly, "更多信息")
        End If
    End Sub

    Private Sub LinkLabel8_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel8.LinkClicked
        Label5.Text = "大事记：" & vbCrLf & "2021/5/9 发布第一个版本(V2.0.0)" & vbCrLf & "2022/7/7 发布第一个64位版本(V7.0.0.0)" & vbCrLf & "2023/1/10 (更新日期) 基于.NET Framework 4.5.2" & vbCrLf & "重构 x64 版本" & vbCrLf & "2022/12/6 (更新日期:2023/01/22) x64 版本源码丢" & vbCrLf & "失，应用重写" & vbCrLf & "2023/05/25 编译 主要名字更名英文 WFL Tool" & vbCrLf & "2024/01/01 编译 应用界面翻新工作基本完成" & vbCrLf & "2025/08/06 编译 更换新图标"
        LinkLabel9.Visible = True               '上一页
        LinkLabel8.Visible = False
    End Sub

    Private Sub LinkLabel9_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel9.LinkClicked
        Label5.Text = "WFL Tool 让修改系统变得更加容易，让系统附件更加” & vbCrLf & “易于寻找” & vbCrLf & ““ & vbCrLf & “版权所有 © 2021-2025 董博涛. 保留所有权利.” & vbCrLf & ““ & vbCrLf & “本软件是 Apache-2.0 许可证的开源软件” & vbCrLf & “使用本软件源码需同时遵守 WFL Tool 软件许可协议“ & vbCrLf & “和 Apache-2.0 许可证” & vbCrLf & vbCrLf & “应用中部分链接为非本团队运营，详见软件许可协议"
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
        Application.Exit()
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        '存在bug，新界面屏蔽
        '        Dim WinAppSdkUi As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\DBT\WFL Tool", "WinAppSdkUi", Nothing)
        '        If WinAppSdkUi = "1" Then              'WinAppSdk弹窗
        '            Dim InstallLocation As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool", "InstallLocation", Nothing)
        '            Shell(InstallLocation + "\MessageBox.exe ""请仔细阅读本协议。若安装或使用本软件之全部或其任何部分,就等于接受本协议内之所有条款。" & vbCrLf & "本软件所含文字材料和软件程序以及附属文件受到世界范围内的版权法保护。" & vbCrLf & vbCrLf & "1.特许使用" & vbCrLf & "董博涛及其团队(以下简称""""我们"""")授于在一台计算机(依据协议的具体系统要求)上使用本软件的非专有不可转让的权利。" & vbCrLf & vbCrLf & "2.软件的使用" & vbCrLf & "2.1在无损任何法定权利下及除本协议允许的权利外,不得修改、改编、分发、传输、转让、出版、复制或更改软件及其附属文件。" & vbCrLf & "2.2鉴于盗版使用本软件会对我们及您的计算机造成损害,在本协议有效期内及终止后,必尽一切努力确保软件和附属文件的安全及完整。本软件的正版以我们签署的数字签名并且从官方渠道下载为准。" & vbCrLf & vbCrLf & "3.终止" & vbCrLf & "任何时候毁掉软件及附属文件即是对本协议的终止。若违反任何条款,本协议亦将终止" & vbCrLf & vbCrLf & "4.保证" & vbCrLf & "4.1我们不保证本软件不会出现损坏您的数据的情况。" & vbCrLf & "4.2以上保证取代其他明示或默示的保证和陈述,特别但不仅限于：" & vbCrLf & "4.2.1我们未做出处上方内容之外关于本软件适用于任何目的或可在任何条件下使用的保证或陈述,即使该目的或条件可能为我们所知" & vbCrLf & "4.2.2我们不为软件的滥用和恶意使用承担任何责任;"" ""WFL Tool 软件许可协议 - 更新日期：2025/08/30" & vbCrLf & "第一页/共二页 - 关闭此窗口以前往下一页" & vbCrLf & "取消授权请前往 WFL Tool 选项"" 99 99 99", AppWinStyle.NormalFocus, True, -1)
        '            Shell(InstallLocation + "\MessageBox.exe ""4.2.3我们不保证软件运行不中断或无差错。" & vbCrLf & "4.2.4我们不为软件的运算和技术缺陷承担任何的责任" & vbCrLf & vbCrLf & "5.责任的有限性" & vbCrLf & "5.1我们的全部责任和对客户的唯一补救方法是为您提供本软件的正版最新版；" & vbCrLf & "5.2我们在任何情况下都不对任何因使用或无能力使用本软件及附属文件造成的损害负责(包括但不仅限于使用者死亡、人身伤害、数据丢失业务提失、收入亏损、声誉损失或其他任何相应损害)。" & vbCrLf & "5.3我们提供的第三方网址仅供查阅,我们不对第三方网站的任何内容负责，虽然他们可能承担了一些重要功能并且在本应用提供的窗口打开(所有在本应用提供的窗口打开的第三方功能：检查更新、更新本程序、获取帮助、开源地址" & vbCrLf & vbCrLf & "6.隐私权" & vbCrLf & "本软件收集和产生的所有数据（可能包括隐私信息）均不会上传，不会共享。但应用所需的运行库及其他第三方组件所产生的数据请遵守相关条款" & vbCrLf & vbCrLf & "7.管辖法律与开源许可证" & vbCrLf & "7.1本协议受中国内地法律管据,中国内地法院拥有司法权。我们有权更新协议后不通知您，因此请定期查看协议的最新版本，如您无法接受，请立刻停止使用本软件" & vbCrLf & "7.2本软件为开源软件，使用我们的源码需遵守 Apache-2.0 许可证和本协议，Apache-2.0 许可证详细内容见开源项目页面"" ""WFL Tool 软件许可协议 - 更新日期：2025/08/30" & vbCrLf & "第二页/共二页 - 所有内容已全部展示" & vbCrLf & "取消授权请前往 WFL Tool 选项"" 99 99 99", AppWinStyle.NormalFocus, True, -1)
        '        Else              '旧版弹窗
        'legacy:
        Dim NF12 As New Form12()
        NF12.Show()
        NF12.Button3.Visible = True
        NF12.Button1.Visible = False         '协议及调整协议界面
        NF12.Button2.Visible = False
        NF12.Label1.Visible = False
        '        End If
    End Sub

    Private Sub LinkLabel10_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) 
        Dim NF11 As New Form11()
        NF11.Show()
    End Sub

    Private Sub Label6_DoubleClick(sender As Object, e As EventArgs) Handles Label6.DoubleClick
        Form4.Show()
        Label6.Visible = False        '彩蛋-介绍
    End Sub

    Private Sub LinkLabel10_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel10.LinkClicked
        On Error GoTo legacy
        Dim EDGEWV2 As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Microsoft EdgeWebView", "Version", Nothing)
        If EDGEWV2 = "" Then               '判断EDGE WEBVIEW2是否存在
            GoTo legacy
        End If
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v EWV2webpageShow /T REG_SZ /d True /f", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v EWV2webpageTitle /T REG_SZ /d ""WFL Tool 项目开源页面 - Github"" /f", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v EWV2webpageURL /T REG_SZ /d https://github.com/z181k/WFL-Tool /f", AppWinStyle.Hide, True, -1)
        Shell("EWV2viewer\EWV2Viewer.exe", AppWinStyle.NormalFocus, False, -1)   '写入启动参数注册表并且启动ewv2
        Exit Sub
legacy:
        Shell("cmd.exe /c start https://github.com/z181k/WFL-Tool", AppWinStyle.Hide, True, -1)
    End Sub
End Class