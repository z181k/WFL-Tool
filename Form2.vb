﻿Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Shell("cmd.exe /c start %windir%\system32\iscsicpl.exe", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Shell("cmd.exe /c start %windir%\system32\odbcad32.exe", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Shell("cmd.exe /c start %windir%\syswow64\odbcad32.exe", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Shell("cmd.exe /c start %windir%\system32\cleanmgr.exe", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Shell("cmd.exe /c start %windir%\system32\mmc.exe", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Shell("cmd.exe /c start %windir%\system32\RecoveryDrive.exe", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Shell("cmd.exe /c start %windir%\system32\WF.msc", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Shell("cmd.exe /c start %windir%\system32\dfrgui.exe", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Shell("cmd.exe /c start %windir%\system32\perfmon.msc /s", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Shell("cmd.exe /c start %windir%\system32\perfmon.exe /res", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Shell("cmd.exe /c start msconfig.exe", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Shell("cmd.exe /c start taskmgr.exe", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Shell("msinfo32.exe", AppWinStyle.NormalFocus, False, -1)
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click

    End Sub

    Private Sub 返回主界面_LinkClicked(sender As Object, e As EventArgs) Handles 返回主界面.LinkClicked
        Form1.Show()
        Close()
    End Sub

    Private Sub 碎片整理和优化驱动器功能说明_LinkClicked(sender As Object, e As EventArgs) Handles 碎片整理和优化驱动器功能说明.LinkClicked
        MsgBox("此功能在 Win 10 及以上系统在使用固态硬盘时只有优化驱动器功能，在 Win 8 及以下系统在使用固态硬盘时碎片整理功能和优化驱动器功能都有，机械硬盘所有系统都有碎片整理功能和优化驱动器功能。因为碎片整理会给固态硬盘造成损伤，这些在固态硬盘支持碎片整理的系统发布时没有出现或流行固态硬盘，所以请不要在固态硬盘碎片整理，并且及时关闭这些系统对固态硬盘的自动碎片整理！", MsgBoxStyle.OkOnly, "碎片整理和优化驱动器功能说明")
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Dim cctButton As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\DBT\WFL Tool", True).GetValue("cctButton", "0")
        If cctButton = "1" Then
            '（.1存在.5砍了）
            Exit Sub
        End If
        If cctButton = "2" Then
            '（.1存在.5砍了）
            Exit Sub
        End If
        Shell("cmd.exe /c start %windir%\system32\compmgmt.msc /s", AppWinStyle.Hide, True, -1)  '计算机管理
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        CreateObject("shell.application").shellexecute("powershell.exe", "", "", "", 1)
    End Sub

    Private Sub WindowsPowershellISEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WindowsPowershellISEToolStripMenuItem.Click
        CreateObject("shell.application").shellexecute("powershell_ise.exe", "", "", "", 1)
    End Sub

    Private Sub WindowsPowershell管理员ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WindowsPowershell管理员ToolStripMenuItem.Click
        CreateObject("shell.application").shellexecute("powershell.exe", "", "", "runas", 1)
    End Sub

    Private Sub WindowsPowershellx86ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WindowsPowershellx86ToolStripMenuItem.Click
        CreateObject("shell.application").shellexecute("C:\Windows\Syswow64\WindowsPowershell\v1.0\powershell.exe", "", "", "", 1)
    End Sub

    Private Sub WindowsPowershellISE管理员ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WindowsPowershellISE管理员ToolStripMenuItem.Click
        CreateObject("shell.application").shellexecute("powershell_ise.exe", "", "", "runas", 1)
    End Sub

    Private Sub WindowsPowershellISEx86ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WindowsPowershellISEx86ToolStripMenuItem.Click
        CreateObject("shell.application").shellexecute("C:\Windows\Syswow64\windowspowershell\v1.0\powershell_ise.exe", "", "", "", 1)
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        CreateObject("shell.application").shellexecute("netplwiz.exe", "", "", "", 1)
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '读取设置
        Dim LegacyMoreUI As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WFL Tool", True).GetValue("LegacyMoreUI", "无")
        If LegacyMoreUI = "True" Then
            返回主界面.Visible = False
            快捷键返回BToolStripMenuItem.Enabled = False
            Me.ContextMenuStrip = ContextMenuStrip2
        End If
        Dim cctButton As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\DBT\WFL Tool", True).GetValue("cctButton", "0")
        If cctButton = "1" Then
            Button15.Text = "该功能不可用1去·	安全·1	安全·1A"            '（.1存在.5砍了）
        End If
        If cctButton = "2" Then
            Button15.Text = "该功能不可用"            '（.1存在.5砍了）
            ToolTip1.Active = True
        End If
    End Sub

    Private Sub 打开主页ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开主页ToolStripMenuItem.Click
        Form1.Show()
    End Sub

    Private Sub WindowsPowershellISEx86管理员ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WindowsPowershellISEx86管理员ToolStripMenuItem.Click
        CreateObject("shell.application").shellexecute("C:\Windows\Syswow64\WindowsPowershell\v1.0\powershell_ise.exe", "", "", "runas", 1)
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        CreateObject("shell.application").shellexecute("C:\Windows\Syswow64\WindowsPowershell\v1.0\powershell.exe", "", "", "runas", 1)
        'WindowsPowershellx86管理员
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        CreateObject("shell.application").shellexecute("powershell.exe", "", "", "", 1)
        'WindowsPowershell当前身份
    End Sub

    Private Sub 快捷键返回BToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 快捷键返回BToolStripMenuItem.Click
        Form1.Show()
        Close()
    End Sub
End Class