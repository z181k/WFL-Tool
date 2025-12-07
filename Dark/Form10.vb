Public Class Form10
    Private Sub 打开主界面ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开主界面ToolStripMenuItem.Click
        Form1.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click     '状态
        CreateObject("shell.application").shellexecute("cmd.EXE", "/c start WSCRIPT.EXE C:\windows\system32\slmgr.vbs /dlv&timeout /t 5&start wscript.exe C:\windows\system32\slmgr.vbs /xpr", "", "", 0)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Shell("WSCRIPT.EXE C:\windows\system32\slmgr.vbs /ato", AppWinStyle.NormalFocus, False, -1)        '激活
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Shell("WSCRIPT.EXE C:\windows\system32\slmgr.vbs /upk", AppWinStyle.NormalFocus, False, -1)   '卸载密钥
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox1.Text = "OPENwflT8304f392801" Then
            Dim NF1 As New Form1()                               '新建主窗体
            NF1.Show()
            TextBox1.Text = ""
            Exit Sub
        ElseIf TextBox1.Text = "OPENwflT8312f479018" Then          '任务管理器x86
            Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v cctButton /T REG_SZ /d 2 /f", AppWinStyle.Hide, True, -1)
            TextBox1.Text = ""
            Exit Sub
        ElseIf TextBox1.Text = "OPENwflT8312f479034" Then           '命令提示符管理员
            Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v cctButton /T REG_SZ /d 1 /f", AppWinStyle.Hide, True, -1)
            TextBox1.Text = ""
            Exit Sub
        ElseIf TextBox1.Text = "ENDwflT8312f479018" Then         '计算机管理
            Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v cctButton /T REG_SZ /d 0 /f", AppWinStyle.Hide, True, -1)
            Exit Sub
        ElseIf TextBox1.Text = "OPENwflT8312f519340" Then          '5周年页面
            Form3.Show()
            TextBox1.Text = ""
            Exit Sub
        ElseIf TextBox1.Text = " " Then
            MsgBox("请在下方输入框提供信息", 0, "密钥安装")
            Exit Sub
        ElseIf TextBox1.Text = "" Then                                 '保证不为空
            MsgBox("请在下方输入框提供信息", 0, "密钥安装")
            Exit Sub
        End If
        CreateObject("shell.application").shellexecute("WSCRIPT.EXE", "C:\windows\system32\slmgr.vbs /ipk " + TextBox1.Text, "", "runas", 1)
        TextBox1.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Then
            MsgBox("请在下方输入框提供信息", 0, "KMS 地址")
            Exit Sub
        ElseIf TextBox1.Text = " " Then                                 '保证不为空
            MsgBox("请在下方输入框提供信息", 0, "KMS 地址")
            Exit Sub
        End If                                                               '设置kms地址
            CreateObject("shell.application").shellexecute("WSCRIPT.EXE", "C:\windows\system32\slmgr.vbs /skms " + TextBox1.Text, "", "runas", 1)
        TextBox1.Text = ""
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        CreateObject("shell.application").shellexecute("WSCRIPT.EXE", "C:\windows\system32\slmgr.vbs /ipk W269N-WFGWX-YVC9B-4J6C9-T83GX", "", "runas", 1)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        CreateObject("shell.application").shellexecute("WSCRIPT.EXE", "C:\windows\system32\slmgr.vbs /ipk 6TP4R-GNPTD-KYYHQ-7B7DP-J447Y", "", "runas", 1)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        CreateObject("shell.application").shellexecute("WSCRIPT.EXE", "C:\windows\system32\slmgr.vbs /ipk NRG8B-VKK3Q-CXVCJ-9G2XF-6Q84J", "", "runas", 1)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        CreateObject("shell.application").shellexecute("WSCRIPT.EXE", "C:\windows\system32\slmgr.vbs /ipk NW6C2-QMPVW-D7KKK-3GKT6-VCFB2", "", "runas", 1)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        CreateObject("shell.application").shellexecute("WSCRIPT.EXE", "C:\windows\system32\slmgr.vbs /ipk NPPR9-FWDCX-D2C8J-H872K-2YT43", "", "runas", 1)
    End Sub
End Class