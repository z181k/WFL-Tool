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
        If TextBox1.Text = "OPENwflT9504f260214" Then
            TextBox1.Text = ""
            Dim WebBrowserTitle As String
            WebBrowserTitle = InputBox("", "WebBrowserTitle")
            Dim WebBrowserURL As String
            WebBrowserURL = InputBox("", "WebBrowserURL")
            Dim NF4 As New Form4()
            NF4.Show()
            NF4.Text = WebBrowserTitle
            NF4.MaximizeBox = True
            NF4.WebBrowser1.Url = New Uri(WebBrowserURL)
            NF4.MaximumSize = New Size(0, 0)
            NF4.MinimumSize = New Size(0, 0)
            NF4.WebBrowser1.ScriptErrorsSuppressed = True
            Exit Sub
        ElseIf TextBox1.Text = " " Then
            MsgBox("请在输入框提供信息", 0, "密钥安装")
            Exit Sub
        ElseIf TextBox1.Text = "" Then                                 '保证不为空
            MsgBox("请在输入框提供信息", 0, "密钥安装")
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

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        CreateObject("shell.application").shellexecute("WSCRIPT.EXE", "C:\windows\system32\slmgr.vbs /rearm", "", "runas", 1)
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        CreateObject("shell.application").shellexecute("Slui.EXE", "4", "", "runas", 1)
    End Sub
End Class